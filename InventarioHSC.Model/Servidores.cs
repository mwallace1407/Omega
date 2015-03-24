using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioHSC.Model
{
    public class Servidores
    {
        int _Srvid;
        int _idSistema;
        int _idItem;
        int _SrvRAM;
        long _SrvTotalHDD;
        string _SrvNombre;
        string _SrvTipo;
        string _SrvIP;
        string _SrvLlave;
        bool _SrvEsVirtual;
        bool _SrvEstado;

        public int id
        {
            get { return _Srvid; }
            set { _Srvid = value; }
        }
        public int idSistema
        {
            get { return _idSistema; }
            set { _idSistema = value; }
        }
        public int idItem
        {
            get { return _idItem; }
            set { _idItem = value; }
        }
        public int RAM
        {
            get { return _SrvRAM; }
            set { _SrvRAM = value; }
        }
        public long TotalHDD
        {
            get { return _SrvTotalHDD; }
            set { _SrvTotalHDD = value; }
        }
        public string Nombre
        {
            get { return _SrvNombre; }
            set { _SrvNombre = value; }
        }
        public string Tipo
        {
            get { return _SrvTipo; }
            set { _SrvTipo = value; }
        }
        public string IP
        {
            get { return _SrvIP; }
            set { _SrvIP = value; }
        }
        public string Llave
        {
            get { return _SrvLlave; }
            set { _SrvLlave = value; }
        }
        public bool EsVirtual
        {
            get { return _SrvEsVirtual; }
            set { _SrvEsVirtual = value; }
        }
        public bool Estado
        {
            get { return _SrvEstado; }
            set { _SrvEstado = value; }
        }
    }
}
