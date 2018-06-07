namespace InventarioHSC.Model
{
    public class UbicacionSW
    {
        private string _idUbicacion;
        private string _descripcion;

        public string idUbicacion
        {
            get { return _idUbicacion; }
            set { _idUbicacion = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}