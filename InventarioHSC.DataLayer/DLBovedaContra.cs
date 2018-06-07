using System;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InventarioHSC.DataLayer
{
    public class DLBovedaContra
    {
        public string GuardarLlave(string UserName, string BCL_Hash)
        {
            string Errores = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_BovedaGuardarLlave");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@BCL_Hash", DbType.String, BCL_Hash);

                db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }

            return Errores;
        }

        public DataTable ObtenerParametros()
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_BovedaObtenerParametros");
                selectCommand.CommandType = CommandType.StoredProcedure;

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = new DataSet();
                DataTable Errores = new DataTable("Error");
                DataRow dr;

                Errores.Columns.Add("Error");
                dr = Errores.NewRow();
                dr[0] = ex.Message;
                Errores.Rows.Add(dr);
                Errores.AcceptChanges();

                MensajeBD.Tables.Add(Errores);
            }

            return MensajeBD.Tables[0];
        }

        public int VerificarHash(string BCL_Hash)
        {
            int Conteo = 0;
            DataTable MensajeBD = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_BovedaVerificaHash");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@BCL_Hash", DbType.String, BCL_Hash);

                MensajeBD.Load(db.ExecuteReader(selectCommand));

                if (MensajeBD.Rows.Count > 0)
                    int.TryParse(MensajeBD.Rows[0][0].ToString(), out Conteo);
            }
            catch
            {
                Conteo = 0;
            }

            return Conteo;
        }

        public DataTable ObtenerListaTipos()
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_BovedaListaTipos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = new DataSet();
                DataTable Errores = new DataTable("Error");
                DataRow dr;

                Errores.Columns.Add("Valor");
                Errores.Columns.Add("Descripcion");
                dr = Errores.NewRow();
                dr[0] = "Error al obtener los datos";
                dr[1] = ex.Message;
                Errores.Rows.Add(dr);
                Errores.AcceptChanges();

                MensajeBD.Tables.Add(Errores);
            }

            return MensajeBD.Tables[0];
        }

        public string IngresarLog(int BCA_Id, int BC_Id, string UserName, string BCLog_Observaciones)
        {
            string Errores = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_BovedaGuardarLog");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@BCA_Id", DbType.Int32, BCA_Id);
                db.AddInParameter(selectCommand, "@BC_Id", DbType.Int32, BC_Id);
                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@BCLog_Observaciones", DbType.String, BCLog_Observaciones);

                db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }

            return Errores;
        }

        public string IngresarContrasenna(string BCL_Hash, int BCT_Id, string UserName, string BC_Objeto, string BC_Login, string BC_Pass)
        {
            string Errores = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_BovedaIngresarContrasenna");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@BCL_Hash", DbType.String, BCL_Hash);
                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@BCT_Id", DbType.Int32, BCT_Id);
                db.AddInParameter(selectCommand, "@BC_Objeto", DbType.String, BC_Objeto);
                db.AddInParameter(selectCommand, "@BC_Login", DbType.String, BC_Login);
                db.AddInParameter(selectCommand, "@BC_Pass", DbType.String, BC_Pass);

                db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }

            return Errores;
        }

        public DataTable ObtenerListaP(string BCL_Hash, int BCT_Id)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_BovedaLecturaListaP");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@BCL_Hash", DbType.String, BCL_Hash);
                db.AddInParameter(selectCommand, "@BCT_Id", DbType.Int32, BCT_Id);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MensajeBD = new DataSet();
                DataTable Errores = new DataTable("Error");
                DataRow dr;

                Errores.Columns.Add("Valor");
                Errores.Columns.Add("Descripcion");
                dr = Errores.NewRow();
                dr[0] = "Error al obtener los datos";
                dr[1] = ex.Message;
                Errores.Rows.Add(dr);
                Errores.AcceptChanges();

                MensajeBD.Tables.Add(Errores);
            }

            return MensajeBD.Tables[0];
        }

        public DataTable ObtenerPassEncriptado(int BC_Id)
        {
            DataTable MensajeBD = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_BovedaLectura");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@BC_Id", DbType.Int32, BC_Id);

                MensajeBD.Load(db.ExecuteReader(selectCommand));
            }
            catch { }

            return MensajeBD;
        }
    }
}