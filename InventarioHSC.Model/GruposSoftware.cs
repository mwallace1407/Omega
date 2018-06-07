namespace InventarioHSC.Model
{
    public class GruposSoftware
    {
        private int _idGruposSoftware;
        private string _descripcion;

        public int idGruposSoftware
        {
            get { return _idGruposSoftware; }
            set { _idGruposSoftware = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}