namespace InventarioHSC.Model
{
    public class TipoMovimiento
    {
        private int _idTipoMovimiento;
        private string _descripcion;
        private bool _estatus;

        public int idTipoMovimiento
        {
            get { return _idTipoMovimiento; }
            set { _idTipoMovimiento = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public bool estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
    }
}