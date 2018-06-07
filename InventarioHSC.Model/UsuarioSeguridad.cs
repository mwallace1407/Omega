namespace InventarioHSC.Model
{
    public class UsuarioSeguridad
    {
        private string _idUsuario;
        private string _nombreCompleto;
        private int _estaBloqueado;

        public string idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string nombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = value; }
        }

        public int estaBloqueado
        {
            get { return _estaBloqueado; }
            set { _estaBloqueado = value; }
        }
    }
}