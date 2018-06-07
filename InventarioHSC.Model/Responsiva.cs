namespace InventarioHSC.Model
{
    public class Responsiva
    {
        private string _IdResponsiva;
        private string _Usuario;
        private string _Puesto;
        private string _Sucursal;
        private string _Tipoequipo;
        private string _Modelo;
        private string _Marca;
        private string _Noserie;
        private string _Procesador;
        private string _Memoria;
        private string _Discoduro;
        private string _Observacion1;
        private string _Observacion2;
        private string _ObservacionesResponsiva;

        public string idResponsiva
        {
            get { return _IdResponsiva; }
            set { _IdResponsiva = value; }
        }

        public string usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string puesto
        {
            get { return _Puesto; }
            set { _Puesto = value; }
        }

        public string sucursal
        {
            get { return _Sucursal; }
            set { _Sucursal = value; }
        }

        public string tipoequipo
        {
            get { return _Tipoequipo; }
            set { _Tipoequipo = value; }
        }

        public string modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public string noserie
        {
            get { return _Noserie; }
            set { _Noserie = value; }
        }

        public string procesador
        {
            get { return _Procesador; }
            set { _Procesador = value; }
        }

        public string memoria
        {
            get { return _Memoria; }
            set { _Memoria = value; }
        }

        public string discoduro
        {
            get { return _Discoduro; }
            set { _Discoduro = value; }
        }

        public string observacion1
        {
            get { return _Observacion1; }
            set { _Observacion1 = value; }
        }

        public string observacion2
        {
            get { return _Observacion2; }
            set { _Observacion2 = value; }
        }

        public string ObservacionesResponsiva
        {
            get { return _ObservacionesResponsiva; }
            set { _ObservacionesResponsiva = value; }
        }
    }
}