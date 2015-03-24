using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using InventarioHSC.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace InventarioHSC.DataLayer
{
    public class DLUsuario
    {
        public DLUsuario()
        {

        }

        public Usuario getUsuarioporID(int idUsuario)
        {
            Usuario oUsuario = new Usuario();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT idUsuario ");
            sqlCommand.AppendLine("		, Nombre ");
            sqlCommand.AppendLine("		, ISNULL(idPuesto, 0) AS idPuesto ");
            sqlCommand.AppendLine("FROM Usuario ");
            sqlCommand.AppendLine("WHERE idUsuario = @idUsuario ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idUsuario", DbType.Int32, idUsuario);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oUsuario.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oUsuario.nombre = dr["Nombre"].ToString();
                    oUsuario.idPuesto = Convert.ToInt32(dr["idPuesto"]);
                }
            }
            return oUsuario;
        }

        public Usuario getUsuarioporNombre(string ssNombre)
        {
            Usuario oUsuario = new Usuario();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT idUsuario ");
            sqlCommand.AppendLine("		, Nombre ");
            sqlCommand.AppendLine("		, ISNULL(idPuesto, 0) AS idPuesto ");
            sqlCommand.AppendLine("FROM Usuario "); 
            sqlCommand.AppendLine("AND   Nombre = @Nombre");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@Nombre", DbType.String, ssNombre);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oUsuario.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    oUsuario.nombre = dr["Nombre"].ToString();
                    oUsuario.idPuesto = Convert.ToInt32(dr["idPuesto"]);
                }
            }
            return oUsuario;
        }

        public List<Usuario> getUsuarioAll()
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT 0 AS idUsuario ");
            sqlCommand.AppendLine(" 	  , '' AS Nombre ");
            sqlCommand.AppendLine(" 	  , 0 AS idPuesto ");
            sqlCommand.AppendLine("	  , '' AS puestoDesc  ");
            sqlCommand.AppendLine(" UNION  ");
            sqlCommand.AppendLine(" SELECT   U.idUsuario  ");
            sqlCommand.AppendLine("  		, U.Nombre  ");
            sqlCommand.AppendLine("  		, ISNULL(U.idPuesto, 0) AS idPuesto  ");
            sqlCommand.AppendLine("		, P.Descripcion AS puestoDesc ");
            sqlCommand.AppendLine(" FROM Usuario U  ");
            sqlCommand.AppendLine(" INNER JOIN Puesto P ON p.idPuesto = U.idPuesto ");
            sqlCommand.AppendLine(" WHERE U.Estatus = 1");
            sqlCommand.AppendLine(" ORDER by Nombre  ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                List<Usuario> lstUsuario = new List<Usuario>();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Usuario oUsuario = new Usuario();
                        oUsuario.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                        oUsuario.nombre = dr["Nombre"].ToString();
                        oUsuario.idPuesto = Convert.ToInt32(dr["idPuesto"]);
                        oUsuario.puestoDesc = dr["puestoDesc"].ToString();
                        lstUsuario.Add(oUsuario);
                    }
                }
                return lstUsuario;
            }
            catch (DataException ex)
            {

                throw ex;
            }
        }

        public void InsertUsuario(ref Usuario oUsuario)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpI_Usuario");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pNombre", DbType.String, oUsuario.nombre);
            db.AddInParameter(dbCommand, "@pidPuesto", DbType.Int64, oUsuario.idPuesto);
            db.AddOutParameter(dbCommand, "@pidUsuario", DbType.Int64, 4);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                oUsuario.idUsuario = Convert.ToInt32(db.GetParameterValue(dbCommand, "@pidUsuario"));
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public void UpdateUsuario(ref Usuario oUsuario)
        {
            string sMensaje = string.Empty;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE Usuario ");
            sqlCommand.AppendLine("SET Nombre = @pNombre ");
            sqlCommand.AppendLine("  , idPuesto  = @pidPuesto ");
            sqlCommand.AppendLine("  , Estatus  = @pEstatus ");
            sqlCommand.AppendLine("WHERE idUsuario = @pidUsuario");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pNombre", DbType.String, oUsuario.nombre);
            db.AddInParameter(dbCommand, "@pidPuesto", DbType.Int32, oUsuario.idPuesto);
            db.AddInParameter(dbCommand, "@pEstatus", DbType.Boolean, oUsuario.estatus == "ACTIVO" ? 1 : 0);
            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, oUsuario.idUsuario);

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }

        public int CountArticuloUsuario(int idUsuario)
        {
            int total = 0;
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" SELECT  ");
            sqlCommand.AppendLine(" 	COUNT(idUsuario) ");
            sqlCommand.AppendLine(" FROM Articulo ");
            sqlCommand.AppendLine(" WHERE idUsuario = @pidUsuario");

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            db.AddInParameter(dbCommand, "@pidUsuario", DbType.Int32, idUsuario);

            try
            {
                total = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (DataException ex)
            {
                throw ex;
            }

            return total;
        }

        public DataTable CatalogoUsuariosSistema(bool IncluirValorInicial = true)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("EXEC stpS_Catalogos");

            if (IncluirValorInicial)
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Usuarios_Sistema).ToString() + ", 1, 0, 0");
            else
                sqlCommand.AppendLine(((int)DatosGenerales.OpcionesCatalogosStored.Catalogo_Usuarios_Sistema).ToString() + ", 0, 0, 0");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
            catch (DataException ex)
            {
                throw ex;
            }
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
                selectCommand = db.GetSqlStringCommand("stpS_BuscaUsuarios");
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
                selectCommand = db.GetSqlStringCommand("stpS_LeePermisosUsuario");
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

        public DataTable ActualizaPermisosUsuario(string UserId, int idMenu, bool Usu_Autorizado)
        {
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;
            DataTable Resultados;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpU_PermisosMenu");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@Usu_Id", DbType.String, UserId);
                db.AddInParameter(selectCommand, "@Menu_Id", DbType.Int32, idMenu);
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
