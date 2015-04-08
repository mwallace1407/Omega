using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace InventarioHSC.DataLayer
{
    public class DLRptDinamicos
    {
        public void InsertarTipoDatoCatalogo(int RDC_Id, string RDC_TipoDatoValor)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            
            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_RptDinamicosCatTipoDato");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RDC_Id", DbType.Int32, RDC_Id);
                db.AddInParameter(selectCommand, "@RDC_TipoDatoValor", DbType.String, RDC_TipoDatoValor);

                db.ExecuteDataSet(selectCommand);
            }
            catch { }
        }

        public string InsertarCatalogo(int RDE_Id, string RDC_Descripcion, string RDC_Script, string RDC_Conexion, bool RDC_Autorizado, string RDC_TipoDatoValor)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            
            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_RptDinamicosCatalogo");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RDE_Id", DbType.Int32, RDE_Id);
                db.AddInParameter(selectCommand, "@RDC_Descripcion", DbType.String, RDC_Descripcion);
                db.AddInParameter(selectCommand, "@RDC_Script", DbType.String, RDC_Script);
                db.AddInParameter(selectCommand, "@RDC_Conexion", DbType.String, RDC_Conexion);
                db.AddInParameter(selectCommand, "@RDC_Autorizado", DbType.Boolean, RDC_Autorizado);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0)
                {
                    if (MensajeBD.Tables[0].Rows.Count > 0)
                    {
                        int RDC_Id = 0;

                        MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
                        int.TryParse(MsjBD, out RDC_Id);

                        if (RDC_Id > 0)
                        {
                            InsertarTipoDatoCatalogo(RDC_Id, RDC_TipoDatoValor);
                        }
                    }
                }
            }
            catch { }

            return MsjBD;
        }

        public DataTable ListaTiposScript(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_tipos_script).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_tipos_script).ToString() + ", 0, 0, 0");

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

        public DataTable ListaCatalogos(string RDC_Conexion, int RDE_Id)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosCatalogos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RDC_Conexion", DbType.String, RDC_Conexion);
                db.AddInParameter(selectCommand, "@RDE_Id", DbType.Int32, RDE_Id);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch 
            {
                Tabla = new DataTable("Error");
                Tabla.Columns.Add("Valor");
                Tabla.Columns.Add("Descripcion");
                Tabla.AcceptChanges();
            }

            return Tabla;
        }

        public DataTable ListaStoreds(string Cnx)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>(Cnx);
            DataTable Resultados = new DataTable();

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(DatosGenerales.QueryStored);

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

        public DataTable ParametrosStored(string Cnx, string Stored)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>(Cnx);
            DataTable Resultados = new DataTable();

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(DatosGenerales.QueryDetalleStored);

            try
            {
                db.AddInParameter(selectCommand, "@Stored", DbType.String, Stored);

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

        public string ScriptStored(string Cnx, string Stored)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>(Cnx);
            DataTable Resultados = new DataTable();

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(DatosGenerales.QueryScriptStored);

            try
            {
                db.AddInParameter(selectCommand, "@Stored", DbType.String, Stored);

                ds = db.ExecuteDataSet(selectCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resultados = ds.Tables[0];
                }

                if (Resultados.Rows.Count > 0)
                    return Resultados.Rows[0][0].ToString();
                else
                    return "No se obtuvo el script";
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int InsertarReporte(string RD_Nombre, int RDTS_Id, string RD_Script, string RD_Conexion, bool RD_Activo, string UserName)
        {
            int MsjBD = 0;
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_RptDinamicos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RD_Nombre", DbType.String, RD_Nombre);
                db.AddInParameter(selectCommand, "@RDTS_Id", DbType.Int32, RDTS_Id);
                db.AddInParameter(selectCommand, "@RD_Script", DbType.String, RD_Script);
                db.AddInParameter(selectCommand, "@RD_Conexion", DbType.String, RD_Conexion);
                db.AddInParameter(selectCommand, "@RD_Activo", DbType.Boolean, RD_Activo);
                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0)
                {
                    if (MensajeBD.Tables[0].Rows.Count > 0)
                        int.TryParse(MensajeBD.Tables[0].Rows[0][0].ToString(), out MsjBD);
                }
            }
            catch { }

            return MsjBD;
        }

        public string InsertarParametro(int RD_Id, string RDP_Nombre, string RDP_Tipo, string RDP_TipoDato, int RDP_Longitud, bool RDP_Obligatorio, string RDP_Entrada, int RDC_Id, bool RDP_AceptaNulo, bool RDP_BusquedaAproximada, string RDP_Texto, bool AplicarBorradoPrevio)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_RptDinamicosParam");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RD_Id", DbType.Int32, RD_Id);
                db.AddInParameter(selectCommand, "@RDP_Nombre", DbType.String, RDP_Nombre);
                db.AddInParameter(selectCommand, "@RDP_Tipo", DbType.String, RDP_Tipo);
                db.AddInParameter(selectCommand, "@RDP_TipoDato", DbType.String, RDP_TipoDato);
                db.AddInParameter(selectCommand, "@RDP_Longitud", DbType.Int32, RDP_Longitud);
                db.AddInParameter(selectCommand, "@RDP_Obligatorio", DbType.Boolean, RDP_Obligatorio);
                db.AddInParameter(selectCommand, "@RDP_Entrada", DbType.String, RDP_Entrada);
                db.AddInParameter(selectCommand, "@RDC_Id", DbType.Int32, RDC_Id);
                db.AddInParameter(selectCommand, "@RDP_AceptaNulo", DbType.Boolean, RDP_AceptaNulo);
                db.AddInParameter(selectCommand, "@RDP_BusquedaAproximada", DbType.Boolean, RDP_BusquedaAproximada);
                db.AddInParameter(selectCommand, "@RDP_Texto", DbType.String, RDP_Texto);
                db.AddInParameter(selectCommand, "@AplicarBorradoPrevio", DbType.Boolean, AplicarBorradoPrevio);

                db.ExecuteNonQuery(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = "Error (" + RDP_Nombre + "): " + ex.Message;
            }

            return MsjBD;
        }

        public DataTable ObtenerTiposDato(string Cnx)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>(Cnx);
            DataTable Resultados = new DataTable();

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(DatosGenerales.QueryTiposDato);

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

        public DataTable ListaReportes(int RDTS_Id, string RD_Conexion)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosPorTipo");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RDTS_Id", DbType.Int32, RDTS_Id);
                db.AddInParameter(selectCommand, "@RD_Conexion", DbType.String, RD_Conexion);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch
            {
                Tabla = new DataTable("Error");
                Tabla.Columns.Add("Valor");
                Tabla.Columns.Add("Descripcion");
                Tabla.AcceptChanges();
            }

            return Tabla;
        }

        public DataTable ObtenerParametrosReporte(int RD_Id)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosParametros");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RD_Id", DbType.Int32, RD_Id);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch (DataException ex)
            {
                throw ex;
            }

            return Tabla;
        }

        public int ActualizarReporte(int RD_Id, string RD_Nombre, string RD_Script, string UserName)
        {
            int MsjBD = 0;
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_RptDinamicos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RD_Id", DbType.Int32, RD_Id);
                db.AddInParameter(selectCommand, "@RD_Nombre", DbType.String, RD_Nombre);
                db.AddInParameter(selectCommand, "@RD_Script", DbType.String, RD_Script);
                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0)
                {
                    if (MensajeBD.Tables[0].Rows.Count > 0)
                        int.TryParse(MensajeBD.Tables[0].Rows[0][0].ToString(), out MsjBD);
                }
            }
            catch { }

            return MsjBD;
        }

        public DataTable ObtenerReportesAutorizaciones(bool? Autorizado = null)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosAutorizaciones");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Autorizado", DbType.Boolean, Autorizado);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch (DataException ex)
            {
                throw ex;
            }

            return Tabla;
        }

        public void ActualizarAutorizacionReporte(int RD_Id, bool RD_Activo, bool EsCat)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_RptDinamicosAut");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RD_Id", DbType.Int32, RD_Id);
                db.AddInParameter(selectCommand, "@RD_Activo", DbType.Boolean, RD_Activo);
                db.AddInParameter(selectCommand, "@EsCat", DbType.Boolean, EsCat);

                db.ExecuteDataSet(selectCommand);
            }
            catch { }
        }

        public DataTable ReportesUsuario(string UserName)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosReportesUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch
            {
                Tabla = new DataTable("Error");
                Tabla.Columns.Add("Valor");
                Tabla.Columns.Add("Descripcion");
                Tabla.AcceptChanges();
            }

            return Tabla;
        }

        public DataTable ObtenerScriptCatalogo(int RDC_Id)
        {
            DataTable Tabla = new DataTable();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosScriptCatalogo");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@RDC_Id", DbType.Int32, RDC_Id);
                Tabla.Load(db.ExecuteReader(selectCommand));
            }
            catch (DataException ex)
            {
                throw ex;
            }

            return Tabla;
        }

        #region Permisos_Usuario
        public List<Usuario> BuscarUsuarioPermisos(string strBusqueda)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;
            List<Usuario> lstUsuarios = new List<Usuario>();

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosBuscaUsuarios");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Usu_Nombres", DbType.String, strBusqueda);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in MensajeBD.Tables[0].Rows)
                    {
                        Usuario oUsuario = new Usuario();

                        oUsuario.puestoDesc = dr["Valor"].ToString();
                        oUsuario.nombre = dr["Descripcion"].ToString();
                        lstUsuarios.Add(oUsuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstUsuarios;
        }

        public DataTable LeePermisosUsuario(string UserId)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_RptDinamicosLeePermisosUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Usu_Id", DbType.String, UserId);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (MensajeBD.Tables.Count > 0)
                return MensajeBD.Tables[0];
            else
                return null;
        }

        public DataTable ActualizaPermisosUsuario(string UserId, int RD_Id, bool Usu_Autorizado)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;
            DataTable Resultados;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_RptDinamicosPermisos");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Usu_Id", DbType.String, UserId);
                db.AddInParameter(selectCommand, "@RD_Id", DbType.Int32, RD_Id);
                db.AddInParameter(selectCommand, "@Usu_Autorizado", DbType.Boolean, Usu_Autorizado);

                Resultados = new DataTable("Resultados");
                DataRow dr;

                Resultados.Columns.Add("Resultados");
                dr = Resultados.NewRow();
                dr[0] = "";
                Resultados.Rows.Add(dr);
                Resultados.AcceptChanges();

                MensajeBD = db.ExecuteDataSet(selectCommand);
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
        #endregion Permisos_Usuario
    }
}
