using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLPuesto
    {
        public BLPuesto()
        {

        }

        public Puesto ObtienePuesto(int id_Puesto)
        {
            DLPuesto dlPuesto = new DLPuesto();
            return dlPuesto.getPuestoporID(id_Puesto);
        }

        public List<Puesto> ObtienePuestos()
        {
            DLPuesto odlPuesto = new DLPuesto();
            List<Puesto> lstPto = new List<Puesto>();

            try
            {
                lstPto = odlPuesto.getPuestoAll();
                lstPto.RemoveAll(x => x.idPuesto == 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstPto;
        }

        public int InsertaPuesto(int i_idPuesto, string s_descripcion, string s_estatus)
        {
            Puesto objPuesto = new Puesto();
            DLPuesto odlPto = new DLPuesto();

            objPuesto.idPuesto = i_idPuesto;
            objPuesto.descripcion = s_descripcion;
            objPuesto.estatus = s_estatus;

            try
            {
                odlPto.InsertPuesto(ref objPuesto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objPuesto.idPuesto;
        }

        public int ActualizaPuesto(int i_idPuesto, string s_descripcion, string s_estatus)
        {
            Puesto objPuesto = new Puesto();
            DLPuesto odlPto = new DLPuesto();

            objPuesto.idPuesto = i_idPuesto;
            objPuesto.descripcion = s_descripcion;
            objPuesto.estatus = s_estatus;

            try
            {
                odlPto.UpdatePuesto(ref objPuesto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objPuesto.idPuesto;

        }

        public int EliminaPuesto(int i_idPuesto)
        {
            Puesto objPuesto = new Puesto();
            DLPuesto odlPto = new DLPuesto();
            int Total = 0;

            objPuesto = odlPto.getPuestoporID(i_idPuesto);
            objPuesto.estatus = "INACTIVO";

            try
            {
                Total = odlPto.ValidaAsignacionPuesto(objPuesto.idPuesto);
                if (Total == 0)
                {
                    odlPto.UpdatePuesto(ref objPuesto);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Total;
        }

        public int ValidaAsignacion(int i_idPuesto)
        {
            DLPuesto odlPto = new DLPuesto();
            int TotalC = 0;

            try
            {
                TotalC = odlPto.ValidaAsignacionPuesto(i_idPuesto);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return TotalC;
        }

    }
}
