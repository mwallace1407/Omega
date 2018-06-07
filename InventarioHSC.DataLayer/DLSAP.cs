using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InventarioHSC.DataLayer
{
    public class DLSAP
    {
        #region OpenXml

        static private int rowsPerSheet = 250000;
        private DataTable ResultsData = new DataTable();

        public string GenerarExcel(IDataReader reader, string RutaArchivos)
        {
            string Archivo = "";
            DataTable dtSchema = reader.GetSchemaTable();
            int c = 0;
            bool firstTime = true;
            var listCols = new List<DataColumn>();

            if (dtSchema != null)
            {
                foreach (DataRow drow in dtSchema.Rows)
                {
                    string columnName = Convert.ToString(drow["ColumnName"]);
                    var column = new DataColumn(columnName, (Type)(drow["DataType"]));

                    column.Unique = (bool)drow["IsUnique"];
                    column.AllowDBNull = (bool)drow["AllowDBNull"];
                    column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                    listCols.Add(column);
                    ResultsData.Columns.Add(column);
                }
            }

            while (reader.Read())
            {
                DataRow dataRow = ResultsData.NewRow();

                for (int i = 0; i < listCols.Count; i++)
                {
                    dataRow[(listCols[i])] = reader[i];
                }

                ResultsData.Rows.Add(dataRow);
                c++;

                if (c == rowsPerSheet)
                {
                    c = 0;
                    Archivo = ExportToOxml(firstTime, Archivo, RutaArchivos);
                    ResultsData.Clear();
                    firstTime = false;
                }
            }

            if (ResultsData.Rows.Count > 0)
            {
                Archivo = ExportToOxml(firstTime, Archivo, RutaArchivos);
                ResultsData.Clear();
            }

            reader.Close();

            return Archivo;
        }

        private string ExportToOxml(bool firstTime, string fileName, string RutaArchivos)
        {
            //Check if the file exists.
            if (firstTime)
            {
                Random rnd = new Random();

                fileName = "Reporte_" + DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(1000).ToString().PadLeft(4, Convert.ToChar("0")) + ".xlsx";

                while (System.IO.File.Exists(fileName))
                    fileName = "Reporte_" + DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(1000).ToString().PadLeft(4, Convert.ToChar("0")) + ".xlsx";
            }

            uint sheetId = 1; //Start at the first sheet in the Excel workbook.

            if (firstTime)
            {
                //This is the first time of creating the excel file and the first sheet.
                // Create a spreadsheet document by supplying the filepath.
                // By default, AutoSave = true, Editable = true, and Type = xlsx.
                SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.
                    Create(RutaArchivos + fileName, SpreadsheetDocumentType.Workbook);

                // Add a WorkbookPart to the document.
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                var bold1 = new Bold();
                CellFormat cf = new CellFormat();

                // Add Sheets to the Workbook.
                Sheets sheets;
                sheets = spreadsheetDocument.WorkbookPart.Workbook.
                    AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                var sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                        GetIdOfPart(worksheetPart),
                    SheetId = sheetId,
                    Name = "Hoja" + sheetId
                };
                sheets.Append(sheet);

                //Add Header Row.
                var headerRow = new Row();
                foreach (DataColumn column in ResultsData.Columns)
                {
                    var cell = new Cell
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(column.ColumnName)
                    };
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                foreach (DataRow row in ResultsData.Rows)
                {
                    var newRow = new Row();
                    foreach (DataColumn col in ResultsData.Columns)
                    {
                        var cell = new Cell
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(row[col].ToString())
                        };
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }
                workbookpart.Workbook.Save();

                spreadsheetDocument.Close();
            }
            else
            {
                // Open the Excel file that we created before, and start to add sheets to it.
                var spreadsheetDocument = SpreadsheetDocument.Open(RutaArchivos + fileName, true);

                var workbookpart = spreadsheetDocument.WorkbookPart;
                if (workbookpart.Workbook == null)
                    workbookpart.Workbook = new Workbook();

                var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);
                var sheets = spreadsheetDocument.WorkbookPart.Workbook.Sheets;

                if (sheets.Elements<Sheet>().Any())
                {
                    //Set the new sheet id
                    sheetId = sheets.Elements<Sheet>().Max(s => s.SheetId.Value) + 1;
                }
                else
                {
                    sheetId = 1;
                }

                // Append a new worksheet and associate it with the workbook.
                var sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                        GetIdOfPart(worksheetPart),
                    SheetId = sheetId,
                    Name = "Hoja" + sheetId
                };
                sheets.Append(sheet);

                //Add the header row here.
                var headerRow = new Row();

                foreach (DataColumn column in ResultsData.Columns)
                {
                    var cell = new Cell
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(column.ColumnName)
                    };
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                foreach (DataRow row in ResultsData.Rows)
                {
                    var newRow = new Row();

                    foreach (DataColumn col in ResultsData.Columns)
                    {
                        var cell = new Cell
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(row[col].ToString())
                        };
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }

                workbookpart.Workbook.Save();

                // Close the document.
                spreadsheetDocument.Close();
            }

            return fileName;
        }

        #endregion OpenXml

        #region EPPlus

        //public void Test_EPP(string Archivo, string Reg)
        //{
        //    string Query = "";

        //    Query += "SELECT TOP " + Reg + " * FROM Acumulados_RH";

        //    Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
        //    DbCommand selectCommand = null;
        //    const int LimitChunk = 100000;
        //    const int LimitRows = 500000;
        //    int Chunk = 0;
        //    int Row = 1;
        //    int ActualRow = 0;
        //    int Pagina = 1;
        //    bool ProcesarEncabezados = true;

        //    try
        //    {
        //        selectCommand = db.GetSqlStringCommand(Query);
        //        selectCommand.CommandType = CommandType.Text;

        //        using (IDataReader reader = db.ExecuteReader(selectCommand))
        //        {
        //            int TotCols = reader.FieldCount;
        //            DataTable Tabla = new DataTable();
        //            System.IO.FileInfo fi = new System.IO.FileInfo(Archivo);

        //            using (ExcelPackage pck = new ExcelPackage(fi))
        //            {
        //                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Página " + Pagina.ToString().PadLeft(2, Convert.ToChar("0")));
        //                ws.Cells["A1"].Value = "";
        //                pck.Save();
        //            }

        //            while (reader.Read())
        //            {
        //                Chunk++;
        //                ActualRow++;

        //                string[] campos = new string[TotCols];
        //                var listOfArr = new List<string[]>();

        //                if (ProcesarEncabezados)
        //                {
        //                    Tabla = new DataTable();

        //                    for (int index = 0; index < reader.FieldCount; index++)
        //                    {
        //                        Tabla.Columns.Add(Convert.ToString(reader.GetName(index)));
        //                    }

        //                    ProcesarEncabezados = false;
        //                    //Guardar(Archivo, Row, Pagina, Tabla);
        //                }

        //                DataRow dr;

        //                dr = Tabla.NewRow();

        //                for (int index = 0; index < reader.FieldCount; index++)
        //                {
        //                    dr[index] = Convert.ToString(reader.GetValue(index));
        //                }

        //                Tabla.Rows.Add(dr);

        //                if (Chunk == LimitChunk)
        //                {
        //                    Tabla.AcceptChanges();
        //                    GuardarEPP(Archivo, Row, Pagina, Tabla);
        //                    Row += Chunk;
        //                    Chunk = 0;

        //                    Tabla = new DataTable();

        //                    for (int index = 0; index < reader.FieldCount; index++)
        //                    {
        //                        Tabla.Columns.Add(Convert.ToString(reader.GetName(index)));
        //                    }
        //                }

        //                if (ActualRow == LimitRows)
        //                {
        //                    Pagina++;
        //                    ActualRow = 0;
        //                    Row = 0;
        //                    ProcesarEncabezados = true;

        //                    using (ExcelPackage pck = new ExcelPackage(fi))
        //                    {
        //                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Página " + Pagina.ToString().PadLeft(2, Convert.ToChar("0")));
        //                        ws.Cells[1, 1].Value = 0;
        //                        pck.Save();
        //                    }
        //                }
        //            }

        //            if (Tabla.Rows.Count > 0)
        //            {
        //                if (Row == 0)
        //                    Row = 1;

        //                GuardarEPP(Archivo, Row, Pagina, Tabla);
        //            }

        //            reader.Close();
        //            reader.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.IO.FileInfo fi = new System.IO.FileInfo(Archivo);

        //        using (ExcelPackage pck = new ExcelPackage(fi))
        //        {
        //            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Errores");
        //            ws.Cells[1, 1].Value = ex.Message;
        //            ws.Cells[2, 1].Value = ex.StackTrace;
        //            pck.Save();
        //        }
        //    }
        //}

        //private void GuardarEPP(string Archivo, int Row, int Pagina, DataTable Datos)
        //{
        //    System.IO.FileInfo fi = new System.IO.FileInfo(Archivo);

        //    if (Row == 0) { Row = 1; }

        //    using (ExcelPackage pck = new ExcelPackage(fi))
        //    {
        //        ExcelWorksheet ws = pck.Workbook.Worksheets["Página " + Pagina.ToString().PadLeft(2, Convert.ToChar("0"))];
        //        ws.Cells[Row, 1].LoadFromDataTable(Datos, true);
        //        pck.Save();
        //    }
        //}

        #endregion EPPlus

        #region BD

        public DataTable Catalogos(DatosGenerales.OpcionesCatalogosSAP Catalogo, int Id, bool IncluirValorInicial)
        {
            DataTable Resultados = new DataTable();
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sp_Catalogos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Accion", DbType.Int32, (int)Catalogo);
                db.AddInParameter(selectCommand, "@IncluirValorInicial", DbType.Boolean, IncluirValorInicial);
                db.AddInParameter(selectCommand, "@Id", DbType.Int32, Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    Resultados = MensajeBD.Tables[0];
            }
            catch { }

            return Resultados;
        }

        #region FICO

        public string Balanzas(string Sociedad, string Ejercicio, string Cuenta_Mayor, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_Balanzas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Sociedad", DbType.String, Sociedad);
                db.AddInParameter(selectCommand, "@Ejercicio", DbType.String, Ejercicio);
                db.AddInParameter(selectCommand, "@Cuenta_Mayor", DbType.String, Cuenta_Mayor);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string Auxiliares(string Sociedad, string Ejercicio, string Cuenta_Mayor, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_Auxiliares");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Sociedad", DbType.String, Sociedad);
                db.AddInParameter(selectCommand, "@Ejercicio", DbType.String, Ejercicio);
                db.AddInParameter(selectCommand, "@Cuenta_Mayor", DbType.String, Cuenta_Mayor);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string AuxiliaresDetalle(string Sociedad, string Ejercicio, string Cuenta_Mayor, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_AuxiliaresDetalle");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Sociedad", DbType.String, Sociedad);
                db.AddInParameter(selectCommand, "@Ejercicio", DbType.String, Ejercicio);
                db.AddInParameter(selectCommand, "@Cuenta_Mayor", DbType.String, Cuenta_Mayor);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string Cuentas(string Sociedad, string Cuenta_Mayor, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_CatalogoCuentas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Sociedad", DbType.String, Sociedad);
                db.AddInParameter(selectCommand, "@Cuenta_Mayor", DbType.String, Cuenta_Mayor);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        #endregion FICO

        #region RH

        public string IngresoEmpleados(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_IngresoEmpleados");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string AsignacionOrganizativa(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_AsignacionOrganizativa");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string DatosBancarios(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_DatosBancarios");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string NumeroAnterior(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_NumeroAnterior");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string DatosPersonales(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_DatosPersonales");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string Direcciones(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_Direcciones");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string ContratoLaboral(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_ContratoLaboral");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string RemuneracionEconomica(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_RemuneracionEconomica");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string HorarioLaboral(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_HorarioLaboral");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string Medidas(string No_pers, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_Medidas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@No_pers", DbType.String, No_pers);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public string Acumulados(string Anio, string No_Pers, string Concepto_Nomina, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("spR_AcumuladosRH");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Anio", DbType.String, Anio);
                db.AddInParameter(selectCommand, "@No_Pers", DbType.String, No_Pers);
                db.AddInParameter(selectCommand, "@Concepto_Nomina", DbType.String, Concepto_Nomina);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public DataTable Documentos(string Rep_Tipo, string Rep_SubTipo, int Rep_Anno, string Rep_Clave)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("SAP");
            DbCommand selectCommand = null;
            DataTable Resultados = new DataTable();

            try
            {
                selectCommand = db.GetSqlStringCommand("sp_BuscarDocumento");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Rep_Tipo", DbType.String, Rep_Tipo);
                db.AddInParameter(selectCommand, "@Rep_SubTipo", DbType.String, Rep_SubTipo);
                db.AddInParameter(selectCommand, "@Rep_Anno", DbType.String, Rep_Anno);
                db.AddInParameter(selectCommand, "@Rep_Clave", DbType.String, Rep_Clave);

                Resultados = db.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch { }

            return Resultados;
        }

        #endregion RH

        #endregion BD
    }
}