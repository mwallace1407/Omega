using System;
using System.Collections.Generic;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLMarca
    {
        public BLMarca()
        {
        }

        public List<Marca> ObtieneMarcaAll()
        {
            DLMarca odlMarca = new DLMarca();
            List<Marca> lstMar = new List<Marca>();

            try
            {
                lstMar = odlMarca.getMarcaAll();
                lstMar.RemoveAll(x => x.idMarca == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstMar;
        }

        public int InsertaMarca(int i_idMarca, string s_descripcion, string s_estatus)
        {
            Marca objMarca = new Marca();
            DLMarca odlMar = new DLMarca();

            objMarca.idMarca = i_idMarca;
            objMarca.descripcion = s_descripcion;
            objMarca.estatus = s_estatus;

            try
            {
                odlMar.InsertMarca(ref objMarca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMarca.idMarca;
        }

        public int ActualizaMarca(int i_idMarca, string s_descripcion, string s_estatus)
        {
            Marca objMarca = new Marca();
            DLMarca odlMar = new DLMarca();

            objMarca.idMarca = i_idMarca;
            objMarca.descripcion = s_descripcion;
            objMarca.estatus = s_estatus;

            try
            {
                odlMar.UpdateMarca(ref objMarca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMarca.idMarca;
        }

        public int EliminaMarca(int i_idMarca)
        {
            Marca objMarca = new Marca();
            DLMarca odlMar = new DLMarca();
            objMarca = odlMar.getMarcaporID(i_idMarca);
            int TotalMarcasAsignadas;
            objMarca.estatus = "INACTIVO";

            try
            {
                TotalMarcasAsignadas = odlMar.CountMarcaArticulo(i_idMarca);
                if (TotalMarcasAsignadas == 0)
                {
                    odlMar.UpdateMarca(ref objMarca);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TotalMarcasAsignadas;
        }

        public int ValidaAsignacionMarca(int i_idMarca)
        {
            int TotalAignados;
            DLMarca odlMarca = new DLMarca();

            try
            {
                TotalAignados = odlMarca.CountMarcaArticulo(i_idMarca);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return TotalAignados;
        }
    }
}