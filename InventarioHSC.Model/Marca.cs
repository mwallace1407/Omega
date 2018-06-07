namespace InventarioHSC.Model
{
    public class Marca
    {
        private int _idMarca;
        private string _descripcion;
        private string _estatus;

        public int idMarca
        {
            get { return _idMarca; }
            set { _idMarca = value; }
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