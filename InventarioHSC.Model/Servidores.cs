namespace InventarioHSC.Model
{
    public class Servidores
    {
        private int _Srvid;
        private int _idSistema;
        private int _idItem;
        private int _SrvRAM;
        private long _SrvTotalHDD;
        private string _SrvNombre;
        private string _SrvTipo;
        private string _SrvIP;
        private string _SrvLlave;
        private bool _SrvEsVirtual;
        private bool _SrvEstado;

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