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
    public class DLMenu
    {
        public DLMenu()
        {

        }
        
        public List<sysMenu> getMenuporRol(int idRol)
        {
            string sMensaje = string.Empty;


            DataSet ds = new DataSet();


            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneMenuxPerfil");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pidPerfil", DbType.Int32, idRol);

            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                List<sysMenu> lstMenu = new List<sysMenu>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sysMenu oMenu = new sysMenu();
                        oMenu.idMenu = Convert.ToInt32(dr["idMenu"]);
                        oMenu.fcMenuClave = dr["fcMenuClave"].ToString();
                        oMenu.fcMenuNombre = dr["fcMenuNombre"].ToString();
                        oMenu.fcMenuRuta = dr["fcMenuRuta"].ToString();
                        oMenu.idMenuPadre = Convert.ToInt32(dr["idMenuPadre"]);
                        oMenu.fcCss = dr["fcCss"].ToString();
                        oMenu.Nivel = Convert.ToInt32(dr["Nivel"]);
                        oMenu.cmenuindex = dr["cmenuindex"].ToString();
                        oMenu.fcHtml = dr["fcHTML"].ToString();
                        lstMenu.Add(oMenu);
                    }
                }
                return lstMenu;

            }
            catch (DataException ex)
            {
                throw ex;
            }

        }

        public List<sysMenu> getMenuporUsuario(string UserId)
        {
            string sMensaje = string.Empty;


            DataSet ds = new DataSet();


            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneMenuxUsuario");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pidPerfil", DbType.String, UserId);

            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                List<sysMenu> lstMenu = new List<sysMenu>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sysMenu oMenu = new sysMenu();
                        oMenu.idMenu = Convert.ToInt32(dr["idMenu"]);
                        oMenu.fcMenuClave = dr["fcMenuClave"].ToString();
                        oMenu.fcMenuNombre = dr["fcMenuNombre"].ToString();
                        oMenu.fcMenuRuta = dr["fcMenuRuta"].ToString();
                        oMenu.idMenuPadre = Convert.ToInt32(dr["idMenuPadre"]);
                        oMenu.fcCss = dr["fcCss"].ToString();
                        oMenu.Nivel = Convert.ToInt32(dr["Nivel"]);
                        oMenu.cmenuindex = dr["cmenuindex"].ToString();
                        oMenu.fcHtml = dr["fcHTML"].ToString();
                        lstMenu.Add(oMenu);
                    }
                }
                return lstMenu;

            }
            catch (DataException ex)
            {
                throw ex;
            }

        }

        public List<sysMenu> getMenuHijosRolN(string UserName, int idMenuPadre, bool EsTopMenu, string NivelRuta)
        {
            string sMensaje = string.Empty;

            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneMenuHijosN");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@UserName", DbType.String, UserName);
            db.AddInParameter(dbCommand, "@idMenuPadre", DbType.Int32, idMenuPadre);
            db.AddInParameter(dbCommand, "@EsTopMenu", DbType.Boolean, EsTopMenu);
            db.AddInParameter(dbCommand, "@NivelRuta", DbType.String, NivelRuta);

            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                List<sysMenu> lstMenu = new List<sysMenu>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sysMenu oMenu = new sysMenu();
                        oMenu.idMenu = Convert.ToInt32(dr["idMenu"]);
                        oMenu.fcMenuClave = dr["fcMenuClave"].ToString();
                        oMenu.fcMenuNombre = dr["fcMenuNombre"].ToString();
                        oMenu.fcMenuRuta = dr["fcMenuRuta"].ToString();
                        oMenu.idMenuPadre = Convert.ToInt32(dr["idMenuPadre"]);
                        oMenu.fcCss = dr["fcCss"].ToString();
                        oMenu.Nivel = Convert.ToInt32(dr["Nivel"]);
                        oMenu.cmenuindex = dr["cmenuindex"].ToString();
                        oMenu.fcHtml = dr["fcHTML"].ToString();
                        lstMenu.Add(oMenu);
                    }
                }
                return lstMenu;

            }
            catch (DataException ex)
            {
                throw ex;
            }

        }

        public List<sysMenu> getMenuHijosRol(int idRol, int idMenuPadre)
        {
            string sMensaje = string.Empty;

            DataSet ds = new DataSet();

            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("Inventario");
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("stpS_ObtieneMenuHijos");
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand.ToString());
            dbCommand.CommandType = CommandType.StoredProcedure;

            db.AddInParameter(dbCommand, "@pidPerfil", DbType.Int32, idRol);
            db.AddInParameter(dbCommand, "@idMenuPadre", DbType.Int32, idMenuPadre);

            try
            {
                ds = db.ExecuteDataSet(dbCommand);

                List<sysMenu> lstMenu = new List<sysMenu>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sysMenu oMenu = new sysMenu();
                        oMenu.idMenu = Convert.ToInt32(dr["idMenu"]);
                        oMenu.fcMenuClave = dr["fcMenuClave"].ToString();
                        oMenu.fcMenuNombre = dr["fcMenuNombre"].ToString();
                        oMenu.fcMenuRuta = dr["fcMenuRuta"].ToString();
                        oMenu.idMenuPadre = Convert.ToInt32(dr["idMenuPadre"]);
                        oMenu.fcCss = dr["fcCss"].ToString();
                        oMenu.Nivel = Convert.ToInt32(dr["Nivel"]);
                        oMenu.cmenuindex = dr["cmenuindex"].ToString();
                        oMenu.fcHtml = dr["fcHTML"].ToString();
                        lstMenu.Add(oMenu);
                    }
                }
                return lstMenu;

            }
            catch (DataException ex)
            {
                throw ex;
            }

        }

    }
}
