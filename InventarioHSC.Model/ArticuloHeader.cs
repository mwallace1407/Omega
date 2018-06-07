using System;

namespace InventarioHSC.Model
{
    public class ArticuloHeader
    {
        private Int64 _IdItem;
        private int? _Responsiva;
        private string _NoSerie;
        private int _IdTipoEquipo;
        private string _TipoEquipo;
        private string _Ubicacion;
        private string _UsuarioAsignado;
        private string _Puesto;

        public Int64 idItem
        {
            get { return _IdItem; }
            set { _IdItem = value; }
        }

        public int? responsiva
        {
            get { return _Responsiva; }
            set { _Responsiva = value; }
        }

        public string noSerie
        {
            get { return _NoSerie; }
            set { _NoSerie = value; }
        }

        public int idTipoEquipo
        {
            get { return _IdTipoEquipo; }
            set { _IdTipoEquipo = value; }
        }

        public string tipoEquipo
        {
            get { return _TipoEquipo; }
            set { _TipoEquipo = value; }
        }

        public string ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }

        public string usuarioAsignado
        {
            get { return _UsuarioAsignado; }
            set { _UsuarioAsignado = value; }
        }

        public string puesto
        {
            get { return _Puesto; }
            set { _Puesto = value; }
        }
    }
}