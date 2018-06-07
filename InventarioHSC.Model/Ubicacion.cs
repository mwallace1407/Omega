namespace InventarioHSC.Model
{
    public class Ubicacion
    {
        private int _idUbicacion;
        private string _descripcion;
        private int _idRegion;
        private string _descRegion;
        private string _estatus;

        public int idUbicacion
        {
            get { return _idUbicacion; }
            set { _idUbicacion = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int idRegion
        {
            get { return _idRegion; }
            set { _idRegion = value; }
        }

        public string descRegion
        {
            get { return _descRegion; }
            set { _descRegion = value; }
        }

        public string estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
    }
}