namespace InventarioHSC.Model
{
    public class EmpresasSoftware
    {
        private int _idEmpresasSoftware;
        private string _descripcion;

        public int idEmpresasSoftware
        {
            get { return _idEmpresasSoftware; }
            set { _idEmpresasSoftware = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}