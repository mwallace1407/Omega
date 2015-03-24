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
    public class DLSeguridadUsuario
    {
        public UsuarioSeguridad getUserbyID(string idUsuario)
        {
            UsuarioSeguridad oUsuario = new UsuarioSeguridad();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Seguridad");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("      USR.UserName AS UserName ");
            sqlCommand.AppendLine("    , USR.Comment AS NombreCompleto ");
            sqlCommand.AppendLine("    , USR.IsLockedOut AS EstaBloqueado ");
            
            sqlCommand.AppendLine("FROM ");
            sqlCommand.AppendLine("    vw_aspnet_MembershipUsers	USR ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("    dbo.aspnet_Applications		APP ON USR.ApplicationId = APP.ApplicationId ");
            sqlCommand.AppendLine("WHERE ");
            sqlCommand.AppendLine("    UPPER(APP.ApplicationName) = 'INVENTARIOHSC' ");
            sqlCommand.AppendLine("AND ");
            sqlCommand.AppendLine("	USR.UserName = @idUsuario ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idUsuario", DbType.String, idUsuario);

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
                    oUsuario.idUsuario = dr["UserName"].ToString();
                    oUsuario.nombreCompleto = dr["NombreCompleto"].ToString();
                    oUsuario.estaBloqueado = Convert.ToInt32(dr["EstaBloqueado"]);
                }
            }
            return oUsuario;
        }

        public List<RolSeguridad> getRolesUserByID(string idUsuario)
        {
            RolSeguridad oRol = new RolSeguridad();
            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Seguridad");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("      URO.RoleName AS RoleName ");
            sqlCommand.AppendLine("    , URO.Description AS Description ");
            //            sqlCommand.AppendLine("    , URO.RoleName as RoleName");
            sqlCommand.AppendLine("FROM ");
            sqlCommand.AppendLine("    vw_aspnet_MembershipUsers	USR");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("    vw_aspnet_UsersInRoles		UIR ON USR.UserId = UIR.UserId ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("    vw_aspnet_Roles				URO ON UIR.RoleId = URO.RoleId");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("    dbo.aspnet_Applications		APP ON USR.ApplicationId = APP.ApplicationId ");
            sqlCommand.AppendLine("WHERE ");
            sqlCommand.AppendLine("    UPPER(APP.ApplicationName) = 'INVENTARIOHSC'");
            sqlCommand.AppendLine("AND ");
            sqlCommand.AppendLine("	USR.UserName = @idUsuario ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idUsuario", DbType.String, idUsuario);

            try
            {
                ds = db.ExecuteDataSet(selectCommand);
            }
            catch (DataException ex)
            {

                throw ex;
            }

            List<RolSeguridad> lstRoles = new List<RolSeguridad>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    oRol.RolNombre = dr["RoleName"].ToString();
                    oRol.RolDescripcion = dr["Description"].ToString();
                    lstRoles.Add(oRol);
                }
            }
            return lstRoles;
        }

        public string getGrupoByUserID(string idUsuario)
        {
            DataSet ds = new DataSet();
            string sGrupo = string.Empty;

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Seguridad");
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT ");
            sqlCommand.AppendLine("      GPO.GrupoName AS GrupoName ");
            //sqlCommand.AppendLine("    , URO.Description AS Description ");
            sqlCommand.AppendLine("FROM ");
            sqlCommand.AppendLine("    UsuarioEnGrupo   UEG");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("    aspnet_Users  USR ON USR.UserId = UEG.UserId ");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("    Grupo	        GPO ON GPO.GrupoId = UEG.GrupoId");
            sqlCommand.AppendLine("LEFT JOIN ");
            sqlCommand.AppendLine("    dbo.aspnet_Applications		APP ON GPO.ApplicationId = APP.ApplicationId ");
            sqlCommand.AppendLine("WHERE ");
            sqlCommand.AppendLine("    UPPER(APP.ApplicationName) = 'INVENTARIOHSC'");
            sqlCommand.AppendLine("AND ");
            sqlCommand.AppendLine("	USR.UserName = @idUsuario ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            db.AddInParameter(selectCommand, "@idUsuario", DbType.String, idUsuario);

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
                    sGrupo = dr["GrupoName"].ToString();
                }
            }
            return sGrupo;
        }
    }
}
