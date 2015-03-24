using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class DetalleServidor
    {
        private Int64 _IdItem;
        private int _CantidadProcesadores;
        private string _TipoProcesador;
        private int _CantidadDiscos;
        private string _CapacidadDiscos;
        private string _NombreServidor;
        private string _DireccionIP;

        public Int64 idItem
        {
            get { return _IdItem; }
            set { _IdItem = value; }
        }
        public int cantidadProcesadores
        {
            get { return _CantidadProcesadores; }
            set { _CantidadProcesadores = value; }
        }
        public string tipoProcesador
        {
            get { return _TipoProcesador; }
            set { _TipoProcesador = value; }
        }
        public int cantidadDiscos
        {
            get { return _CantidadDiscos; }
            set { _CantidadDiscos = value; }
        }
        public string capacidadDiscos
        {
            get { return _CapacidadDiscos; }
            set { _CapacidadDiscos = value; }
        }
        public string nombreServidor
        {
            get { return _NombreServidor; }
            set { _NombreServidor = value; }
        }
        public string direccionIP
        {
            get { return _DireccionIP; }
            set { _DireccionIP = value; }
        }
    }
}
