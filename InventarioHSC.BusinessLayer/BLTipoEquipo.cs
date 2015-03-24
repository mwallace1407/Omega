using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLTipoEquipo
    {
        public BLTipoEquipo()
        {

        }
        
        public List<TipoEquipo> ObtieneTipoEquipoAll()
        {
            DLTipoEquipo odlTipoEquipo = new DLTipoEquipo();
            List<TipoEquipo> lstTipo = new List<TipoEquipo>();

            try
            {
                lstTipo = odlTipoEquipo.getTipoEquipoAll();
                lstTipo.RemoveAll(x => x.idTipoEquipo == 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstTipo;
        }

        public int InsertaTipoEquipo(int i_idTipoEquipo, string s_descripcion, string s_estatus)
        {
            TipoEquipo objTipoEquipo = new TipoEquipo();
            DLTipoEquipo odlTipo = new DLTipoEquipo();

            objTipoEquipo.idTipoEquipo = i_idTipoEquipo;
            objTipoEquipo.descripcion = s_descripcion;
            objTipoEquipo.estatus = s_estatus;

            try
            {
                odlTipo.InsertTipoEquipo(ref objTipoEquipo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objTipoEquipo.idTipoEquipo;
        }

        public int ActualizaTipoEquipo(int i_idTipoEquipo, string s_descripcion, string s_estatus)
        {
            TipoEquipo objTipoEquipo = new TipoEquipo();
            DLTipoEquipo odlTipo = new DLTipoEquipo();

            objTipoEquipo.idTipoEquipo = i_idTipoEquipo;
            objTipoEquipo.descripcion = s_descripcion;
            objTipoEquipo.estatus = s_estatus;

            try
            {
                odlTipo.UpdateTipoEquipo(ref objTipoEquipo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objTipoEquipo.idTipoEquipo;
        }

        public int EliminaTipoEquipo(int i_idTipoEquipo)
        {
            TipoEquipo objTipoEquipo = new TipoEquipo();
            DLTipoEquipo odlTipo = new DLTipoEquipo();
            int TotalTipos;

            objTipoEquipo = odlTipo.getTipoEquipoporID(i_idTipoEquipo);
            objTipoEquipo.estatus = "INACTIVO";

            try
            {
                TotalTipos = odlTipo.ValidarTiposAsignados(i_idTipoEquipo);
                if (TotalTipos == 0)
                {
                    odlTipo.UpdateTipoEquipo(ref objTipoEquipo);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return TotalTipos;
        }

        public int ValidaAsignacionTipo(int i_idTipoEquipo)
        {

            int TotalAignados;
            DLTipoEquipo odlTipo = new DLTipoEquipo();

            try
            {
                TotalAignados = odlTipo.ValidarTiposAsignados(i_idTipoEquipo);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return TotalAignados;

        }
    }
}
