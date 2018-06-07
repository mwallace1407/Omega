namespace InventarioHSC.Model
{
    public class SoftwareExistente
    {
        private int _SWEX_Id;
        private int _SW_Id;
        private string _Descripcion;
        private string _NoParte;
        private string _Llave;
        private string _Ubicacion;
        private string _Observaciones;
        private bool _EnExistencia;

        public int SW_Id
        {
            get { return _SW_Id; }
            set { _SW_Id = value; }
        }

        public int Id
        {
            get { return _SWEX_Id; }
            set { _SWEX_Id = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string NoParte
        {
            get { return _NoParte; }
            set { _NoParte = value; }
        }

        public string Llave
        {
            get { return _Llave; }
            set { _Llave = value; }
        }

        public string Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public bool EnExistencia
        {
            get { return _EnExistencia; }
            set { _EnExistencia = value; }
        }
    }
}