using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InventarioHSC.DataLayer
{
    public class DLConstancias
    {
        public DataTable ObtenerCatalogos(int Cat_Id, int Valor01 = 0)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ConstanciasCatalogos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Cat_Id", DbType.Int32, Cat_Id);
                db.AddInParameter(selectCommand, "@Valor01", DbType.Int32, Valor01);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch (Exception ex)
            {
                DataRow dr;

                Tabla = new DataTable("Error");
                Tabla.Columns.Add("Valor");
                Tabla.Columns.Add("Descripcion");
                dr = Tabla.NewRow();
                dr[0] = "0";
                dr[1] = ex.Message;
                Tabla.Rows.Add(dr);
                Tabla.AcceptChanges();
            }

            return Tabla;
        }

        public string VerificarExistencia(int ConA_Id, int ConP_Id, Int16 ConL_Anio)
        {
            string MensajeBD = "";
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ConstanciasLotes");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@ConA_Id", DbType.Int32, ConA_Id);
                db.AddInParameter(selectCommand, "@ConP_Id", DbType.Int32, ConP_Id);
                db.AddInParameter(selectCommand, "@ConL_Anio", DbType.Int16, ConL_Anio);
                Tabla.Load(db.ExecuteReader(selectCommand));

                if (Tabla.Rows.Count > 0)
                {
                    MensajeBD = Tabla.Rows[0][0].ToString();
                }
                else
                {
                    MensajeBD = "Error: No se obtuvieron resultados.";
                }
            }
            catch (Exception ex)
            {
                MensajeBD = "Error: " + ex.Message;
            }

            return MensajeBD;
        }

        public string InsertarLote(int ConA_Id, int ConP_Id, DateTime ConL_Fecha, Int16 ConL_Anio, string ConL_NombreArchivo, string ConL_Identificador)
        {
            string MensajeBD = "";
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_ConstanciasLotes");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@ConA_Id", DbType.Int32, ConA_Id);
                db.AddInParameter(selectCommand, "@ConP_Id", DbType.Int32, ConP_Id);
                db.AddInParameter(selectCommand, "@ConL_Fecha", DbType.DateTime, ConL_Fecha);
                db.AddInParameter(selectCommand, "@ConL_Anio", DbType.Int16, ConL_Anio);
                db.AddInParameter(selectCommand, "@ConL_NombreArchivo", DbType.String, ConL_NombreArchivo);
                db.AddInParameter(selectCommand, "@ConL_Identificador", DbType.String, ConL_Identificador);

                Tabla.Load(db.ExecuteReader(selectCommand));

                if (Tabla.Rows.Count > 0)
                {
                    MensajeBD = Tabla.Rows[0][0].ToString();
                }
                else
                {
                    MensajeBD = "Error: No se obtuvieron resultados.";
                }
            }
            catch (Exception ex)
            {
                MensajeBD = "Error: " + ex.Message;
            }

            return MensajeBD;
        }

        public string InsertarDetalle(int ConL_Id,
            string Col01, string Col02, string Col03, string Col04, string Col05,
            string Col06, string Col07, string Col08, string Col09, string Col10,
            string Col11, string Col12, string Col13, string Col14, string Col15,
            string Col16, string Col17, string Col18, string Col19, string Col20,
            string Col21, string Col22)
        {
            string MensajeBD = "";
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_ConstanciasDatos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@ConL_Id", DbType.Int32, ConL_Id);
                db.AddInParameter(selectCommand, "@ConD_Col01", DbType.String, Col01);
                db.AddInParameter(selectCommand, "@ConD_Col02", DbType.String, Col02);
                db.AddInParameter(selectCommand, "@ConD_Col03", DbType.String, Col03);
                db.AddInParameter(selectCommand, "@ConD_Col04", DbType.String, Col04);
                db.AddInParameter(selectCommand, "@ConD_Col05", DbType.String, Col05);
                db.AddInParameter(selectCommand, "@ConD_Col06", DbType.String, Col06);
                db.AddInParameter(selectCommand, "@ConD_Col07", DbType.String, Col07);
                db.AddInParameter(selectCommand, "@ConD_Col08", DbType.String, Col08);
                db.AddInParameter(selectCommand, "@ConD_Col09", DbType.String, Col09);
                db.AddInParameter(selectCommand, "@ConD_Col10", DbType.String, Col10);
                db.AddInParameter(selectCommand, "@ConD_Col11", DbType.String, Col11);
                db.AddInParameter(selectCommand, "@ConD_Col12", DbType.String, Col12);
                db.AddInParameter(selectCommand, "@ConD_Col13", DbType.String, Col13);
                db.AddInParameter(selectCommand, "@ConD_Col14", DbType.String, Col14);
                db.AddInParameter(selectCommand, "@ConD_Col15", DbType.String, Col15);
                db.AddInParameter(selectCommand, "@ConD_Col16", DbType.String, Col16);
                db.AddInParameter(selectCommand, "@ConD_Col17", DbType.String, Col17);
                db.AddInParameter(selectCommand, "@ConD_Col18", DbType.String, Col18);
                db.AddInParameter(selectCommand, "@ConD_Col19", DbType.String, Col19);
                db.AddInParameter(selectCommand, "@ConD_Col20", DbType.String, Col20);
                db.AddInParameter(selectCommand, "@ConD_Col21", DbType.String, Col21);
                db.AddInParameter(selectCommand, "@ConD_Col22", DbType.String, Col22);

                db.ExecuteNonQuery(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = "Error: " + ex.Message.Replace("\r", " ").Replace("\n", " ");
            }

            return MensajeBD;
        }

        public DataTable BuscarLotes(string Descripcion = null, DateTime? FechaCargaIni = null, DateTime? FechaCargaFin = null, DateTime? FechaLoteIni = null, DateTime? FechaLoteFin = null, string Administradoras = null, string Portafolios = null)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ConstanciasBuscarLotes");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Descripcion", DbType.String, Descripcion);
                db.AddInParameter(selectCommand, "@FechaCargaIni", DbType.DateTime, FechaCargaIni);
                db.AddInParameter(selectCommand, "@FechaCargaFin", DbType.DateTime, FechaCargaFin);
                db.AddInParameter(selectCommand, "@FechaLoteIni", DbType.DateTime, FechaLoteIni);
                db.AddInParameter(selectCommand, "@FechaLoteFin", DbType.DateTime, FechaLoteFin);
                db.AddInParameter(selectCommand, "@Administradoras", DbType.String, Administradoras);
                db.AddInParameter(selectCommand, "@Portafolios", DbType.String, Portafolios);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch (Exception ex)
            {
                DataRow dr;

                Tabla = new DataTable("Error");
                Tabla.Columns.Add("Descripcion");
                dr = Tabla.NewRow();
                dr[1] = ex.Message;
                Tabla.Rows.Add(dr);
                Tabla.AcceptChanges();
            }

            return Tabla;
        }

        public DataTable GenerarTXTSAT(string Lotes)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ConstanciasGenerarTXTSAT");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Lotes", DbType.String, Lotes);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch (Exception ex)
            {
                DataRow dr;

                Tabla = new DataTable("Error");
                Tabla.Columns.Add("Descripcion");
                dr = Tabla.NewRow();
                dr[1] = ex.Message;
                Tabla.Rows.Add(dr);
                Tabla.AcceptChanges();
            }

            return Tabla;
        }

        public DataTable GenerarTXTBuzonE(string Ejercicio, string Lotes)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_ConstanciasGenerarTXTBuzonE");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Ejercicio", DbType.String, Ejercicio);
                db.AddInParameter(selectCommand, "@Lotes", DbType.String, Lotes);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch (Exception ex)
            {
                DataRow dr;

                Tabla = new DataTable("Error");
                Tabla.Columns.Add("Descripcion");
                dr = Tabla.NewRow();
                dr[1] = ex.Message;
                Tabla.Rows.Add(dr);
                Tabla.AcceptChanges();
            }

            return Tabla;
        }
    }
}