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
    public class DLServidores
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

        public string RegistrarCinta(DatosGenerales.TiposRespaldoCintas Tipo, int Obj_Id, string RC_Cinta, string RC_Observaciones, DateTime RC_FechaRespaldo)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptI_RegistrarCinta");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@TR_Id", DbType.Int32, (int)Tipo);
                db.AddInParameter(selectCommand, "@Obj_Id", DbType.Int32, Obj_Id);
                db.AddInParameter(selectCommand, "@RC_Cinta", DbType.String, RC_Cinta);
                db.AddInParameter(selectCommand, "@RC_Observaciones", DbType.String, RC_Observaciones);
                db.AddInParameter(selectCommand, "@RC_FechaRespaldo", DbType.DateTime, RC_FechaRespaldo);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string RegistrarCinta(int Tipo, int Obj_Id, string RC_Cinta, string RC_Observaciones, DateTime RC_FechaRespaldo)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptI_RegistrarCinta");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@TR_Id", DbType.Int32, Tipo);
                db.AddInParameter(selectCommand, "@Obj_Id", DbType.Int32, Obj_Id);
                db.AddInParameter(selectCommand, "@RC_Cinta", DbType.String, RC_Cinta);
                db.AddInParameter(selectCommand, "@RC_Observaciones", DbType.String, RC_Observaciones);
                db.AddInParameter(selectCommand, "@RC_FechaRespaldo", DbType.DateTime, RC_FechaRespaldo);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string ReporteCintas(int? Tipo, int? Obj_Id, string RC_Cinta, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_Cintas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@TR_Id", DbType.Int32, Tipo);
                db.AddInParameter(selectCommand, "@Obj_Id", DbType.Int32, Obj_Id);
                db.AddInParameter(selectCommand, "@RC_Cinta", DbType.String, RC_Cinta);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos + "\\");
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public DataTable ListaEstadosTareas(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_estados_tareas).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_estados_tareas).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resultados = ds.Tables[0];
                }

                return Resultados;
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public DataTable CategoriasTarea(string UserName)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;
            DataTable Resultados;

            try
            {
                Resultados = new DataTable("Resultados");
                selectCommand = db.GetSqlStringCommand("stpS_CategoriasTareas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);

                Resultados = db.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch (Exception ex)
            {
                Resultados = new DataTable("Error");
                DataRow dr;

                Resultados.Columns.Add("Error");
                dr = Resultados.NewRow();
                dr[0] = ex.Message;
                Resultados.Rows.Add(dr);
                Resultados.AcceptChanges();
            }

            return Resultados;
        }

        public DataTable ObtenerTareas(string UserName, DateTime SrvT_Inicio, DateTime SrvT_Fin, int? SrvET_Id = null, int? SrvCT_Id = null, bool? SrvT_EsPrivada = null)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;
            DataTable Resultados;

            try
            {
                Resultados = new DataTable("Resultados");
                selectCommand = db.GetSqlStringCommand("stpS_ObtenerTareasServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@FechaIni", DbType.DateTime, SrvT_Inicio);
                db.AddInParameter(selectCommand, "@FechaFin", DbType.DateTime, SrvT_Fin);
                db.AddInParameter(selectCommand, "@SrvET_Id", DbType.Int32, SrvET_Id);
                db.AddInParameter(selectCommand, "@SrvCT_Id", DbType.Int32, SrvCT_Id);
                db.AddInParameter(selectCommand, "@SrvT_EsPrivada", DbType.Boolean, SrvT_EsPrivada);

                Resultados = db.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch (Exception ex)
            {
                Resultados = new DataTable("Error");
                DataRow dr;

                Resultados.Columns.Add("Error");
                dr = Resultados.NewRow();
                dr[0] = ex.Message;
                Resultados.Rows.Add(dr);
                Resultados.AcceptChanges();
            }

            return Resultados;
        }

        public string AgregarCategoria(string UserName, string SrvCT_Descripcion)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptI_ServidoresCategoriasTareas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@SrvCT_Descripcion", DbType.String, SrvCT_Descripcion);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string AgregarInvolucradoTarea(int SrvT_Id, string UserName)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptI_ServidoresInvolucradosTareas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@SrvT_Id", DbType.Int32, SrvT_Id);
                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string RegistrarTarea(int SrvET_Id, int SrvCT_Id, string UserName, DateTime SrvT_Inicio, DateTime SrvT_Fin, string SrvT_Descripcion, bool SrvT_EsPrivada)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptI_RegistrarTarea");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@SrvET_Id", DbType.Int32, SrvET_Id);
                db.AddInParameter(selectCommand, "@SrvCT_Id", DbType.Int32, SrvCT_Id);
                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@SrvT_Inicio", DbType.DateTime, SrvT_Inicio);
                db.AddInParameter(selectCommand, "@SrvT_Fin", DbType.DateTime, SrvT_Fin);
                db.AddInParameter(selectCommand, "@SrvT_Descripcion", DbType.String, SrvT_Descripcion);
                db.AddInParameter(selectCommand, "@SrvT_EsPrivada", DbType.Boolean, SrvT_EsPrivada);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string ActualizarTarea(int SrvT_Id, int SrvET_Id, int SrvCT_Id, DateTime SrvT_Inicio, DateTime SrvT_Fin, string SrvT_Descripcion, bool SrvT_EsPrivada, bool BorrarInvolucrados)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("sptU_ServidoresTareas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@SrvT_Id", DbType.Int32, SrvT_Id);
                db.AddInParameter(selectCommand, "@SrvET_Id", DbType.Int32, SrvET_Id);
                db.AddInParameter(selectCommand, "@SrvCT_Id", DbType.Int32, SrvCT_Id);
                db.AddInParameter(selectCommand, "@SrvT_Inicio", DbType.DateTime, SrvT_Inicio);
                db.AddInParameter(selectCommand, "@SrvT_Fin", DbType.DateTime, SrvT_Fin);
                db.AddInParameter(selectCommand, "@SrvT_Descripcion", DbType.String, SrvT_Descripcion);
                db.AddInParameter(selectCommand, "@SrvT_EsPrivada", DbType.Boolean, SrvT_EsPrivada);
                db.AddInParameter(selectCommand, "@BorrarInvolucrados", DbType.Boolean, BorrarInvolucrados);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public DataSet ObtenerDetalleTarea(int SrvT_Id)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;
            DataSet ds = new DataSet();

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ObtenerDetalleTarea");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@SrvT_Id", DbType.String, SrvT_Id);

                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                DataTable Resultados = new DataTable("Error");
                DataRow dr;

                Resultados.Columns.Add("Error");
                dr = Resultados.NewRow();
                dr[0] = ex.Message;
                Resultados.Rows.Add(dr);
                Resultados.AcceptChanges();
                ds.Tables.Add(Resultados);
            }

            return ds;
        }

        public DataTable ObtenerTareasDeUsuario(string UserName)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;
            DataTable Resultados;

            try
            {
                Resultados = new DataTable("Resultados");
                selectCommand = db.GetSqlStringCommand("stpS_ObtenerTareasUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);

                Resultados = db.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch (Exception ex)
            {
                Resultados = new DataTable("Error");
                DataRow dr;

                Resultados.Columns.Add("Error");
                dr = Resultados.NewRow();
                dr[0] = ex.Message;
                Resultados.Rows.Add(dr);
                Resultados.AcceptChanges();
            }

            return Resultados;
        }

        public string TareasAExcel(string UserName, int? SrvET_Id, int? SrvCT_Id, DateTime? SrvT_Inicio, DateTime? SrvT_Fin, bool? SrvT_EsPrivada, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ObtenerTareasServidores");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@FechaIni", DbType.DateTime, SrvT_Inicio);
                db.AddInParameter(selectCommand, "@FechaFin", DbType.DateTime, SrvT_Fin);
                db.AddInParameter(selectCommand, "@SrvET_Id", DbType.Int32, SrvET_Id);
                db.AddInParameter(selectCommand, "@SrvCT_Id", DbType.Int32, SrvCT_Id);
                db.AddInParameter(selectCommand, "@SrvT_EsPrivada", DbType.Boolean, SrvT_EsPrivada);

                MsjBD = GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos + "\\");
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }
    }
}