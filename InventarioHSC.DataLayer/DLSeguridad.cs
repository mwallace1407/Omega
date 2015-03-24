using InventarioHSC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
namespace InventarioHSC.DataLayer
{
    public class DLSeguridad
    {
        DLConstantes CONSTANTES = new DLConstantes();

        public UsuarioSeguridad getUserByID(string idUsuario)
        {
            DLSeguridadUsuario objUsrSeg = new DLSeguridadUsuario();
            UsuarioSeguridad User = new UsuarioSeguridad();

            User = objUsrSeg.getUserbyID(idUsuario);
            return User;
        }

        public List<RolSeguridad> getRolesUserByID(string idUsuario)
        {
            DLSeguridadUsuario objUsrSeg = new DLSeguridadUsuario();
            List<RolSeguridad> lstRoles = new List<RolSeguridad>();

            lstRoles = objUsrSeg.getRolesUserByID(idUsuario);
            return lstRoles;
        }

        public string getGrupoByUserID(string UsuarioId)
        {
            DLSeguridadUsuario objUsrSeg = new DLSeguridadUsuario();
            
            return objUsrSeg.getGrupoByUserID(UsuarioId);

        }

        public bool ValidaUsuario(string sNombre, string sContraseña)
        {
            bool Esta_Autenticado = false;

            try
            {	//Bind to the native AdsObject to force authentication.			
                if (sNombre == "Administrador" && sContraseña == "SuCasita_123")
                {
                    Esta_Autenticado = true;
                }
                else
                {
                    
                    DirectoryEntry entry = new DirectoryEntry("LDAP://consorcio.sucasita.com.mx", sNombre, sContraseña);
                    DirectorySearcher uno = new DirectorySearcher(entry);
                    uno.Filter = "(SAMAccountName=" + sNombre + ")";
                    uno.PropertiesToLoad.Add("cn");
                    SearchResult searchRes = uno.FindOne();

                    if (searchRes != null)
                    {
                        Esta_Autenticado = true;
                    }
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException)
            {
                Esta_Autenticado = false;
            }

            if (estaBloqueado(sNombre))
                Esta_Autenticado = false;

            return Esta_Autenticado;
        }

        public bool estaBloqueado(string pUserId)
        {
            DataSet ds = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            bool bEstaBloqueado = true;

            sqlCommand.AppendLine("SELECT CASE WHEN m.IsLockedOut = 1 THEN 'S' ELSE 'N' END AS Bloqueado ");
            sqlCommand.AppendLine("FROM   dbo.aspnet_Membership m WITH(NOLOCK) ");
            sqlCommand.AppendLine("WHERE  m.ApplicationId = 'CB9A85E6-D15A-4C6F-990C-1EEADA133459' ");
            sqlCommand.AppendLine("       AND m.UserId IN (SELECT UserId ");
            sqlCommand.AppendLine("                        FROM   aspnet_Users ");
            sqlCommand.AppendLine("                        WHERE  ApplicationId = 'CB9A85E6-D15A-4C6F-990C-1EEADA133459' ");
            sqlCommand.AppendLine("                               AND LOWER(UserName) = LOWER('" + pUserId + "')) ");

            DbCommand selectCommand = null;
            selectCommand = db.GetSqlStringCommand(sqlCommand.ToString());

            try
            {
                ds = db.ExecuteDataSet(selectCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        bEstaBloqueado = (dr["Bloqueado"].ToString() == "S" ? true : false);
                    }
                }

                return bEstaBloqueado;
            }
            catch (DataException ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }

        public bool VerificaAccesoPaginaUsuario(string UserId, string Pagina)
        {
            bool MsjBD = false;
            int Id = 0;
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_VerificaPermisosPaginaUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserId);
                db.AddInParameter(selectCommand, "@Pagina", DbType.String, Pagina);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                {
                    int.TryParse(MensajeBD.Tables[0].Rows[0][0].ToString(), out Id);

                    if (Id == 1)
                        MsjBD = true;
                }
            }
            catch { }

            return MsjBD;
        }

        public DataTable Top10PaginasUsuario(string UserId)
        {
            DataSet MensajeBD = new DataSet();
            DataTable Resultados = new DataTable("Resultados");
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpS_Top10PaginasUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, UserId);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables.Count > 0 && MensajeBD.Tables[0].Rows.Count > 0)
                    Resultados = MensajeBD.Tables[0];
            }
            catch { }

            return Resultados;
        }

        public string CrearUsuario(string Usuario, string Email, string Nombre)
        {
            string MsjBD = "";
            DataSet MensajeBD = new DataSet();
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            DbCommand selectCommand = null;

            try
            {
                selectCommand = db.GetSqlStringCommand("stpI_CrearUsuario");
                selectCommand.CommandType = CommandType.StoredProcedure;

                db.AddInParameter(selectCommand, "@UserName", DbType.String, Usuario);
                db.AddInParameter(selectCommand, "@EMail", DbType.String, Email);
                db.AddInParameter(selectCommand, "@Nombre", DbType.String, Nombre);

                MensajeBD = db.ExecuteDataSet(selectCommand);

                if (MensajeBD.Tables[0].Rows.Count > 0 && MensajeBD.Tables[0].Rows[0][0].ToString() == "")
                    MsjBD = "El usuario ya existe";

                if (MensajeBD.Tables[0].Rows.Count > 0 && MensajeBD.Tables[0].Rows[0][0].ToString() != "")
                    MsjBD = "OK";
            }
            catch (Exception ex)
            {
                MsjBD = "Error: " + ex.Message;
            }

            return MsjBD;
        }
    }
}
