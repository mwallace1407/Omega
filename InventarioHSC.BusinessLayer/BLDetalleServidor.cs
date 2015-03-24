using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLDetalleServidor
    {
        public BLDetalleServidor()
        {

        }

        public DetalleServidor ObtieneDetalleServidor(int idItem)
        {
            DetalleServidor oDetalleServidor = new DetalleServidor();
            DLDetalleServidor oDataDetalleServidor = new DLDetalleServidor();


            try
            {
                oDetalleServidor = oDataDetalleServidor.getDetalleServidorporID(idItem);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return oDetalleServidor;
        }

        public void InsertaDetalleServidor(long i_idItem, int i_CantidadProcesadores, string s_TipoProcesador, int i_CantidadDiscos, string s_CapacidadDiscos, string s_NombreServidor, string s_DireccionIP)
        {
            DetalleServidor  objDetalleServidor = new DetalleServidor();
            DLDetalleServidor odlDetalleServidor = new DLDetalleServidor();


            objDetalleServidor.idItem = i_idItem;
            objDetalleServidor.cantidadProcesadores = i_CantidadProcesadores;
            objDetalleServidor.tipoProcesador = s_TipoProcesador;
            objDetalleServidor.cantidadDiscos = i_CantidadDiscos;
            objDetalleServidor.capacidadDiscos = s_CapacidadDiscos;
            objDetalleServidor.nombreServidor = s_NombreServidor;
            objDetalleServidor.direccionIP = s_DireccionIP;

            try
            {
                odlDetalleServidor.InsertDetalleServidor(ref objDetalleServidor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaDetalleServidor(int i_idItem, int i_CantidadProcesadores, string s_TipoProcesador, int i_CantidadDiscos, string s_CapacidadDiscos, string s_NombreServidor, string s_DireccionIP)
        {
            DetalleServidor objDetalleServidor = new DetalleServidor();
            DLDetalleServidor odlDetalleServidor = new InventarioHSC.DataLayer.DLDetalleServidor();

            objDetalleServidor.idItem = i_idItem;
            objDetalleServidor.cantidadProcesadores = i_CantidadProcesadores;
            objDetalleServidor.tipoProcesador = s_TipoProcesador;
            objDetalleServidor.cantidadDiscos = i_CantidadDiscos;
            objDetalleServidor.capacidadDiscos = s_CapacidadDiscos;
            objDetalleServidor.nombreServidor = s_NombreServidor;
            objDetalleServidor.direccionIP = s_DireccionIP;

            try
            {
                odlDetalleServidor.InsertDetalleServidor(ref objDetalleServidor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
