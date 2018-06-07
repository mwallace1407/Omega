namespace InventarioHSC.Model
{
    public class CatalogoSoftware
    {
        private int _id;
        private int _idEmpresa;
        private int _idGrupo;
        private string _descripcion;
        private string _version;
        private bool _estatus;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        public int idGrupo
        {
            get { return _idGrupo; }
            set { _idGrupo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public bool Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
    }
}