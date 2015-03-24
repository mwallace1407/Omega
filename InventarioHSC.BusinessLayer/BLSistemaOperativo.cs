using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLSistemaOperativo
    {
        public BLSistemaOperativo()
        {

        }

        public List<SistemaOperativo> ObtieneSistemaAll()
        {
            DLSistemaOperativo odlSistema = new DLSistemaOperativo();
            List<SistemaOperativo> lstSist = new List<SistemaOperativo>();

            try
            {
                lstSist = odlSistema.getSistemaOperativoAll();
                lstSist.RemoveAll(x => x.idSistema == 0);
                lstSist.OrderBy(x => x.idSistema).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstSist;
        }

        public int InsertaSistemaOperativo(int i_idSistema, string s_descripcion, string s_version, bool b_estatus)
        {
            SistemaOperativo objSistema = new SistemaOperativo();
            DLSistemaOperativo odlSistema = new DLSistemaOperativo();

            objSistema.idSistema = i_idSistema;
            objSistema.descripcion = s_descripcion;
            objSistema.estatus = b_estatus;
            objSistema.version = s_version;

            try
            {
                odlSistema.InsertSistemaOperativo(ref objSistema);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objSistema.idSistema;
        }

        public int ActualizaSistemaOperativo(int i_idSistema, string s_descripcion, string s_version, bool b_estatus)
        {
            SistemaOperativo objSistema = new SistemaOperativo();
            DLSistemaOperativo odlSistema = new DLSistemaOperativo();

            objSistema.idSistema = i_idSistema;
            objSistema.descripcion = s_descripcion;
            objSistema.estatus = b_estatus;
            objSistema.version = s_version;

            try
            {
                odlSistema.UpdateSistemaOperativo(ref objSistema);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objSistema.idSistema;
        }

        public int EliminaSistemaOperativo(int i_idSistema)
        {
            SistemaOperativo objSistema = new SistemaOperativo();
            DLSistemaOperativo odlSistema = new DLSistemaOperativo();
            int TotalArticulos;

            objSistema = odlSistema.getSistemaOperativoporID(i_idSistema);
            objSistema.estatus = false;

            try
            {
                TotalArticulos = odlSistema.CountArticuloSistemaOperativo(i_idSistema);
                if (TotalArticulos == 0)
                {
                    odlSistema.UpdateSistemaOperativo(ref objSistema);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return TotalArticulos;
        }

        public int ValidaSistemaAsignado(int i_idSistema)
        {

            int TotalArticulos;
            DLSistemaOperativo odlSis = new DLSistemaOperativo();

            try
            {
                TotalArticulos = odlSis.CountArticuloSistemaOperativo(i_idSistema);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return TotalArticulos;

        }

    }
}
