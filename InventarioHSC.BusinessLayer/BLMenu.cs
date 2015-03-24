using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLMenu
    {
        public DLMenu odlMenu = new DLMenu();
        public BLMenu()
        {

        }

        public List<sysMenu> ObtieneOpcionesporPerfil(int idPerfil)
        {
            List<sysMenu> oSysMenu = new List<sysMenu>();
            try
            {
                oSysMenu = odlMenu.getMenuporRol(idPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oSysMenu;
        }

        public List<sysMenu> ObtieneOpcionesporUsuario(string UserId)
        {
            List<sysMenu> oSysMenu = new List<sysMenu>();

            try
            {
                oSysMenu = odlMenu.getMenuporUsuario(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oSysMenu;
        }

        public List<sysMenu> ObtieneHijosPorIDN(string UserName, int idMenuItem, bool EsTopMenu, string NivelRuta)
        {
            List<sysMenu> oSysMenu = new List<sysMenu>();

            try
            {
                oSysMenu = odlMenu.getMenuHijosRolN(UserName, idMenuItem, EsTopMenu, NivelRuta);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return oSysMenu;

        }

        public List<sysMenu> ObtieneHijosPorID(int idPerfil, int idMenuItem)
        {
            List<sysMenu> oSysMenu = new List<sysMenu>();

            try
            {
                oSysMenu = odlMenu.getMenuHijosRol(idPerfil, idMenuItem);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return oSysMenu;

        }

    }
}
