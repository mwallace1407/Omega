namespace InventarioHSC.Model
{
    public class TipoEquipo
    {
        private int _idTipoEquipo;
        private string _descripcion;
        private string _estatus;

        public int idTipoEquipo
        {
            get { return _idTipoEquipo; }
            set { _idTipoEquipo = value; }
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