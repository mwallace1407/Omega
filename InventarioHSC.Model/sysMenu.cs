namespace InventarioHSC.Model
{
    public class sysMenu
    {
        private int _idMenu;

        public int idMenu
        {
            get { return _idMenu; }
            set { _idMenu = value; }
        }

        private string _fcMenuClave;

        public string fcMenuClave
        {
            get { return _fcMenuClave; }
            set { _fcMenuClave = value; }
        }

        private string _fcMenuNombre;

        public string fcMenuNombre
        {
            get { return _fcMenuNombre; }
            set { _fcMenuNombre = value; }
        }

        private string _fcMenuRuta;

        public string fcMenuRuta
        {
            get { return _fcMenuRuta; }
            set { _fcMenuRuta = value; }
        }

        private int _idMenuPadre;

        public int idMenuPadre
        {
            get { return _idMenuPadre; }
            set { _idMenuPadre = value; }
        }

        private string _fcCss;

        public string fcCss
        {
            get { return _fcCss; }
            set { _fcCss = value; }
        }

        private int _nivel;

        public int Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }

        private string _cmenuindex;

        public string cmenuindex
        {
            get { return _cmenuindex; }
            set { _cmenuindex = value; }
        }

        private string _fcHtml;

        public string fcHtml
        {
            get { return _fcHtml; }
            set { _fcHtml = value; }
        }

        private bool _bMenuEstatus;

        public bool bMenuEstatus
        {
            get { return _bMenuEstatus; }
            set { _bMenuEstatus = value; }
        }
    }
}