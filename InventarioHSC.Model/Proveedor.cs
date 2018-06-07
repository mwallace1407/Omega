namespace InventarioHSC.Model
{
    public class Proveedor
    {
        private int _idProveedor;
        private string _descripcion;
        private string _estatus;

        public int idProveedor
        {
            get { return _idProveedor; }
            set { _idProveedor = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
    }
}