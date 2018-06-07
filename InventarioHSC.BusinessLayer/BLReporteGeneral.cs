using System;
using System.Collections.Generic;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLReporteGeneral
    {
        public BLReporteGeneral()
        {
        }

        public List<ReporteGeneral> ObtieneReporteGeneral()
        {
            DLReporteGeneral odlReporteGeneral = new DLReporteGeneral();
            List<ReporteGeneral> lstReporteGeneral = new List<ReporteGeneral>();

            try
            {
                lstReporteGeneral = odlReporteGeneral.getReporteGeneral();
                //lstTipo.RemoveAll(x => x.idTipoEquipo == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstReporteGeneral;
        }
    }
}