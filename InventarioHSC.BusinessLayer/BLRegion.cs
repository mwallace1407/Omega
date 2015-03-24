using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLRegion
    {
        public BLRegion()
        {

        }

        public List<Region> ObtieneRegionAll()
        {
            DLRegion odlRegion = new DLRegion();
            List<Region> lstReg = new List<Region>();

            try
            {
                lstReg = odlRegion.getRegionAll();
                lstReg.RemoveAll(x => x.idRegion == 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstReg;
        }

        public int InsertaRegion(int i_idRegion, string s_descripcion, string s_estatus)
        {
            Region objRegion = new Region();
            DLRegion odlReg = new DLRegion();

            objRegion.idRegion = i_idRegion;
            objRegion.nombre = s_descripcion;
            objRegion.status = s_estatus;

            try
            {
                odlReg.InsertRegion(ref objRegion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objRegion.idRegion;
        }

        public int ActualizaRegion(int i_idRegion, string s_descripcion, string s_estatus)
        {
            Region objRegion = new Region();
            DLRegion odlReg = new DLRegion();

            objRegion.idRegion = i_idRegion;
            objRegion.nombre = s_descripcion;
            objRegion.status = s_estatus;

            try
            {
                odlReg.UpdateRegion(ref objRegion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objRegion.idRegion;
        }

        public int EliminaRegion(int i_idRegion)
        {
            Region objRegion = new Region();
            DLRegion odlReg = new DLRegion();
            int TotalSucursales;

            objRegion = odlReg.getRegionporID(i_idRegion);
            objRegion.status = "INACTIVO";

            try
            {
                TotalSucursales = odlReg.CountSucursalRegion(i_idRegion);
                if (TotalSucursales == 0)
                {
                    odlReg.UpdateRegion(ref objRegion);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return TotalSucursales;
        }

        public int ValidaAsignacionRegion(int i_idRegion)
        {

            int TotalAignados;
            DLRegion odlReg = new DLRegion();

            try
            {
                TotalAignados = odlReg.CountSucursalRegion(i_idRegion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return TotalAignados;

        }

        public Region OntenRegionXID(int id_Region)
        {
            DLRegion dlRegion = new DLRegion();
            Region region = dlRegion.getRegionporID(id_Region);

            return region;
        }
    }
}
