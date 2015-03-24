using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;


namespace InventarioHSC.BusinessLayer
{
    public class BLUbicacion
    {
        public BLUbicacion()
        {

        }

        public List<Ubicacion> ObtieneUbicacionAll()
        {
            DLUbicacion odlUbicacion = new DLUbicacion();
            List<Ubicacion> lstUbi = new List<Ubicacion>();
            List<Ubicacion> lstretUbicacion = new List<Ubicacion>();

            try
            {
                lstUbi = odlUbicacion.getUbicacionAll();
                lstUbi.RemoveAll(x => x.idUbicacion == 0);
                lstretUbicacion = lstUbi.OrderBy(x => x.idUbicacion).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstretUbicacion;
        }

        public Ubicacion ObtenUbicacionXID(int id_Ubicacion)
        {
            DLUbicacion ubicacion = new DLUbicacion();
            return ubicacion.getUbicacionporID(id_Ubicacion);
        }

        public int InsertaUbicacion(int i_idUbicacion, string s_descripcion, int i_idRegion, string s_estatus)
        {
            Ubicacion objUbicacion = new Ubicacion();
            DLUbicacion odlUbicacion = new DLUbicacion();

            objUbicacion.idUbicacion = i_idUbicacion;
            objUbicacion.descripcion = s_descripcion;
            objUbicacion.idRegion = i_idRegion;
            objUbicacion.descRegion = string.Empty;
            objUbicacion.estatus = s_estatus;

            try
            {
                odlUbicacion.InsertUbicacion(ref objUbicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objUbicacion.idUbicacion;
        }

        public int ActualizaUbicacion(int i_idUbicacion, string s_descripcion, int i_idRegion, string s_estatus)
        {
            Ubicacion objUbicacion = new Ubicacion();
            DLUbicacion odlUbicacion = new DLUbicacion();

            objUbicacion.idUbicacion = i_idUbicacion;
            objUbicacion.descripcion = s_descripcion;
            objUbicacion.idRegion = i_idRegion;
            objUbicacion.estatus = s_estatus;

            try
            {
                odlUbicacion.UpdateUbicacion(ref objUbicacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objUbicacion.idUbicacion;
        }

        public int EliminaUbicacion(int i_idUbicacion)
        {
            Ubicacion objUbicacion = new Ubicacion();
            DLUbicacion odlUbicacion = new DLUbicacion();

            int TotalArticulos;
            objUbicacion = odlUbicacion.getUbicacionporID(i_idUbicacion);
            objUbicacion.idRegion = 8;
            objUbicacion.estatus = "INACTIVO";

            try
            {
                TotalArticulos = odlUbicacion.CountArticuloUbicacion(i_idUbicacion);
                if (TotalArticulos == 0)
                {
                    odlUbicacion.UpdateUbicacion(ref objUbicacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TotalArticulos;
        }

        public int ValidaUbicacionAsignado(int i_idUbicacion)
        {
            int TotalArticulos;
            DLUbicacion odlUbi = new DLUbicacion();

            try
            {
                TotalArticulos = odlUbi.CountArticuloUbicacion(i_idUbicacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return TotalArticulos;
        }
    }
}
