using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;

namespace InventarioHSC.DataLayer
{
    public class DLOperaciones
    {
        #region Cartero
        public DataTable LeerDatosFolio(string SolId)
        {
            DataTable MsjBD = new DataTable();
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Cartero");
            DbCommand selectCommand = null;

            try
            {
                string Query = "";

                Query += ScriptsOperaciones.Cartero_ObtenerDatosFolio;
                Query = Query.Replace("@@FolioCartero", SolId);

                selectCommand = db.GetSqlStringCommand(Query);
                selectCommand.CommandType = CommandType.Text;

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0)
                    MsjBD = MensajeBD.Tables[0];
                else
                    MsjBD = null;
            }
            catch
            {
                MsjBD = null;
            }

            return MsjBD;
        }

        private string LogLiberarCarta(string SolId, string UserId)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_Op_LogLiberacionCartas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@SolId", DbType.Int32, SolId);
                db.AddInParameter(selectCommand, "@UserId", DbType.String, UserId);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        private string LiberarCarta(string SolId, string SolCveCC)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("CastorTel");
            DbCommand selectCommand = null;

            try
            {
                string Query = "";

                //CastorTel
                Query = ScriptsOperaciones.Cartero_RegistroPagoCastortel_1;
                Query = Query.Replace("@@FolioCastorTel", SolCveCC);

                selectCommand = db.GetSqlStringCommand(Query);
                selectCommand.CommandType = CommandType.Text;

                db.ExecuteNonQuery(selectCommand);

                //CastorTel bitacora
                Query = ScriptsOperaciones.Cartero_RegistroPagoCastortel_2;
                Query = Query.Replace("@@FolioCastorTel", SolCveCC);
                Query = Query.Replace("@@FolioCartero", SolId);

                selectCommand = db.GetSqlStringCommand(Query);
                selectCommand.CommandType = CommandType.Text;

                db.ExecuteNonQuery(selectCommand);

                MsjBD = "";
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        public string LiberarCarta(string SolId, string SolCveCC, string UserId)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Cartero");
            DbCommand selectCommand = null;

            try
            {
                string Query = "";

                LogLiberarCarta(SolId, UserId);

                //Cartero
                Query += ScriptsOperaciones.Cartero_LiberarCartaPagada;
                Query = Query.Replace("@@FolioCastorTel", SolCveCC);

                selectCommand = db.GetSqlStringCommand(Query);
                selectCommand.CommandType = CommandType.Text;

                db.ExecuteNonQuery(selectCommand);

                MsjBD = LiberarCarta(SolId, SolCveCC);

                if (MsjBD == "")
                    MsjBD = "OK";
            }
            catch(Exception ex)
            {
                MsjBD = ex.Message;
            }

            return MsjBD;
        }

        private string ActualizaReferencia(int Cart_Id)
        {
            string Referencia = DatosGenerales.GeneraReferencia(Cart_Id.ToString());

            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_ReferenciaCarta");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Cart_Id", DbType.Int32, Cart_Id);
                db.AddInParameter(selectCommand, "@Cart_Referencia", DbType.String, Referencia);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                MsjBD = ex.Message;
            }

            return Referencia;
        }

        public string RegistrarCarta(string UserName, DateTime Cart_FechaDocumento, int Cart_NumeroPrestamo, string Cart_NombreAcreditado, byte[] Cart_Archivo)
        {
            string MsjBD = "";
            int Cart_Id = 0;
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_RegistrarCarta");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserName);
                db.AddInParameter(selectCommand, "@Cart_FechaDocumento", DbType.DateTime, Cart_FechaDocumento);
                db.AddInParameter(selectCommand, "@Cart_NumeroPrestamo", DbType.Int32, Cart_NumeroPrestamo);
                db.AddInParameter(selectCommand, "@Cart_NombreAcreditado", DbType.String, Cart_NombreAcreditado);
                db.AddInParameter(selectCommand, "@Cart_Archivo", DbType.Binary, Cart_Archivo);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0)
                {
                    if (MensajeBD.Tables[0].Rows.Count > 0)
                    {
                        MsjBD = MensajeBD.Tables[0].Rows[0][0].ToString();
                        int.TryParse(MsjBD, out Cart_Id);

                        if (Cart_Id > 0)
                            MsjBD = ActualizaReferencia(Cart_Id);
                        else
                            MsjBD = "Error: Referencia incorrecta";
                    }
                    else
                    {
                        MsjBD = "Error: No hay registros";
                    }
                }
                else
                {
                    MsjBD = "Error: No hay tablas";
                }
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public DataTable ReporteCartasGeneradas(int? Cart_NumeroPrestamo, string Cart_NombreAcreditado, DateTime? Cart_FechaCreacionIni, DateTime? Cart_FechaCreacionFin)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_CartasGeneradas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Cart_NumeroPrestamo", DbType.Int32, Cart_NumeroPrestamo);
                db.AddInParameter(selectCommand, "@Cart_NombreAcreditado", DbType.String, Cart_NombreAcreditado);
                db.AddInParameter(selectCommand, "@Cart_FechaCreacionIni", DbType.DateTime, Cart_FechaCreacionIni);
                db.AddInParameter(selectCommand, "@Cart_FechaCreacionFin", DbType.DateTime, Cart_FechaCreacionFin);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD.Tables[0];
        }

        public string CrearPDFCartaGenerada(string Archivo, int Cart_Id)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("SELECT Cart_Archivo FROM Cartero_CartasGeneradas WHERE Cart_Id = " + Cart_Id.ToString());
                selectCommand.CommandType = CommandType.Text;

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0)
                {
                    if (MensajeBD.Tables[0].Rows.Count > 0)
                    {
                        byte[] buffer = (byte[])MensajeBD.Tables[0].Rows[0][0];
                        System.IO.File.WriteAllBytes(Archivo, buffer);

                        MsjBD = "OK";
                    }
                    else
                    {
                        MsjBD = "Error: No hay registros";
                    }
                }
                else
                {
                    MsjBD = "Error: No hay tablas";
                }
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }

        public DataTable ListaTiposFiltroCartasSHF(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Tipos_Busqueda_CartasSHF).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Tipos_Busqueda_CartasSHF).ToString() + ", 0, 0, 0");

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

        public DataTable BuscarCartaSHF(string Tipo, int Numero_Prestamo, int Codigo_Cliente, string Numero_Jit, string Nombre)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_CarteroBuscarCartaSHF");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Tipo", DbType.String, Tipo);
                db.AddInParameter(selectCommand, "@Numero_Prestamo", DbType.Int32, Numero_Prestamo);
                db.AddInParameter(selectCommand, "@Codigo_Cliente", DbType.Int32, Codigo_Cliente);
                db.AddInParameter(selectCommand, "@Numero_Jit", DbType.String, Numero_Jit);
                db.AddInParameter(selectCommand, "@Nombre", DbType.String, Nombre);

                MensajeBD = db.ExecuteDataSet(selectCommand);
            }
            catch { }

            return MensajeBD.Tables[0];
        }
        #endregion Cartero
        #region AAE
        public DataTable BuscarDocumentosAAE(string CadenaBusqueda)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_BuscarDocumentosAAE");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@CadenaBusqueda", DbType.String, CadenaBusqueda);

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
        #endregion AAE
        #region SAB
        public DataTable BuscarDocumentosSAB(string CadenaBusqueda)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_BuscarDocumentosSAB");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@CadenaBusqueda", DbType.String, CadenaBusqueda);

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
        #endregion SAB
        #region Abanks
        public DataTable ObtenerMonedasAbanks(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DataTable Resultados = new DataTable();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_monedas_Abanks).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Lista_monedas_Abanks).ToString() + ", 0, 0, 0");

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

        public string ReportePolizas(int Anno, DateTime FechaIni, DateTime FechaFin, int? NumeroMovimiento, string Cuenta, string DescripcionCuenta, string DescripcionEncabezado, int? Moneda, bool BusquedaEstricta, string RutaArchivos)
        {
            string MsjBD = "";
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            DbCommand selectCommand = null;
            DLExportar exportar = new DLExportar();

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_AbanksPolizas");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Anno", DbType.Int32, Anno);
                db.AddInParameter(selectCommand, "@BusquedaEstricta", DbType.Boolean, BusquedaEstricta);
                db.AddInParameter(selectCommand, "@Numero_Mov", DbType.Int32, NumeroMovimiento);
                db.AddInParameter(selectCommand, "@Fecha_MovIni", DbType.DateTime, FechaIni);
                db.AddInParameter(selectCommand, "@Fecha_MovFin", DbType.DateTime, FechaFin);
                db.AddInParameter(selectCommand, "@Descripcion_Encabezado", DbType.String, DescripcionEncabezado);
                db.AddInParameter(selectCommand, "@Cuenta", DbType.String, Cuenta);
                db.AddInParameter(selectCommand, "@Desc_Cuenta", DbType.String, DescripcionCuenta);
                db.AddInParameter(selectCommand, "@Cod_Moneda_Original", DbType.Int32, Moneda);

                MsjBD = exportar.GenerarExcel(db.ExecuteReader(selectCommand), RutaArchivos);
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }
        #endregion Abanks
        #region Intranet
        public DataTable BuscarDocumentosIntranet(string CadenaBusqueda)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpR_BuscarDocumentosIntranet");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@CadenaBusqueda", DbType.String, CadenaBusqueda);

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
        #endregion Intranet
    }
}
