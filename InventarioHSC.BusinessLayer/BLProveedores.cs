using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLProveedores
    {
        public BLProveedores()
        {
        
        }

        public List<Proveedor> ObtieneProveedores()
        {
            DLProveedor odlProv = new DLProveedor();
            List<Proveedor> lstProv = new List<Proveedor>();

            try
            {
                lstProv = odlProv.getProveedorAll();
                lstProv.RemoveAll(x => x.idProveedor == 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstProv;
        }

        public int InsertaProveedor(int i_idProveedor, string s_descripcion, string s_estatus)
        {
            Proveedor objProveed = new Proveedor();
            DLProveedor odlProv = new DLProveedor();

            objProveed.idProveedor = i_idProveedor;
            objProveed.descripcion = s_descripcion;
            objProveed.estatus = s_estatus;

            try
            {
                odlProv.InsertProveedor(ref objProveed);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objProveed.idProveedor;
        }

        public int ActualizaProveedor(int i_idProveedor, string s_descripcion, string s_estatus)
        {
            Proveedor objProveed = new Proveedor();
            DLProveedor odlProv = new DLProveedor();

            objProveed.idProveedor = i_idProveedor;
            objProveed.descripcion = s_descripcion;
            objProveed.estatus = s_estatus;

            try
            {
                odlProv.UpdateProveedor(ref objProveed);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objProveed.idProveedor;

        }

        public int EliminaProveedor(int i_idProveedor)
        {
            Proveedor objProveed = new Proveedor();
            DLProveedor odlProv = new DLProveedor();

            objProveed = odlProv.getProveedorID(i_idProveedor);
            objProveed.estatus = "INACTIVO";

            int iTotal = 0;

            try
            {
                iTotal = odlProv.ValidarProveedoresAsignados(objProveed.idProveedor);

                if (iTotal == 0)
                {
                    odlProv.UpdateProveedor(ref objProveed);    
                }          
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return iTotal;
        }


        public int ValidaEliminacion(int i_idProveedor)
        {
            DLProveedor odlProv = new DLProveedor();
            int iTotal = 0;

            try
            {
                iTotal = odlProv.ValidarProveedoresAsignados(i_idProveedor);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return iTotal;
        }

    }
}
