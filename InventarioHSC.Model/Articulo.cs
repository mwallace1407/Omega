using System;

namespace InventarioHSC.Model
{
    public class Articulo : ICloneable
    {
        private Int64 _idItem;
        private string _noSerie;
        private int _idTipoEquipo;
        private int _idMarca;
        private string _modelo;
        private string _procesador;
        private string _ram;
        private string _discoDuro;
        private int _idSistema;
        private int _idProveedor;
        private string _factura;
        private string _fechaCompra;
        private string _requisicion;
        private string _centroCostosAdquisicion;
        private int? _responsiva;
        public int? IdUsuarioAnterior { get; set; }
        public string ResponsivaAnterior { get; set; }
        private double _valorPesos;
        private double _valorUSD;
        private string _stock;
        private string _codigoCastor;
        private int? _idUsuario;
        private int _idUbicacion;
        private int _idEstado;
        private string _observacion1;
        private string _observacion2;
        private string _observacion3;
        private string _ObservacionesResponsiva;
        private bool _posibleFaltanteFlag;
        private string _cambioRYS;
        private DateTime? _fechaMovimiento;

        public int? IdUsuarioNuevo { get; set; }

        public Int64 idItem
        {
            get { return _idItem; }
            set { _idItem = value; }
        }

        public string Identificador { get; set; }
        public string Puesto { get; set; }

        public string noSerie
        {
            get { return _noSerie; }
            set { _noSerie = value; }
        }

        public int idTipoEquipo
        {
            get { return _idTipoEquipo; }
            set { _idTipoEquipo = value; }
        }

        public string UsuarioAsignado { get; set; }
        public string Marca { get; set; }

        public string Ubicacion { get; set; }

        public string TipoEquipo { get; set; }

        public int idMarca
        {
            get { return _idMarca; }
            set { _idMarca = value; }
        }

        public string modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        public string procesador
        {
            get { return _procesador; }
            set { _procesador = value; }
        }

        public string ram
        {
            get { return _ram; }
            set { _ram = value; }
        }

        public string discoDuro
        {
            get { return _discoDuro; }
            set { _discoDuro = value; }
        }

        public int idSistema
        {
            get { return _idSistema; }
            set { _idSistema = value; }
        }

        public int idProveedor
        {
            get { return _idProveedor; }
            set { _idProveedor = value; }
        }

        public string factura
        {
            get { return _factura; }
            set { _factura = value; }
        }

        public string fechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
        }

        public string requisicion
        {
            get { return _requisicion; }
            set { _requisicion = value; }
        }

        public string centroCostosAdquisicion
        {
            get { return _centroCostosAdquisicion; }
            set { _centroCostosAdquisicion = value; }
        }

        public int? responsiva
        {
            get { return _responsiva; }
            set { _responsiva = value; }
        }

        public double valorPesos
        {
            get { return _valorPesos; }
            set { _valorPesos = value; }
        }

        public double valorUSD
        {
            get { return _valorUSD; }
            set { _valorUSD = value; }
        }

        public string stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public string codigoCastor
        {
            get { return _codigoCastor; }
            set { _codigoCastor = value; }
        }

        public int? idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int idUbicacion
        {
            get { return _idUbicacion; }
            set { _idUbicacion = value; }
        }

        public int idEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public string observacion1
        {
            get { return _observacion1; }
            set { _observacion1 = value; }
        }

        public string observacion2
        {
            get { return _observacion2; }
            set { _observacion2 = value; }
        }

        public string observacion3
        {
            get { return _observacion3; }
            set { _observacion3 = value; }
        }

        public string ObservacionesResponsiva
        {
            get { return _ObservacionesResponsiva; }
            set { _ObservacionesResponsiva = value; }
        }

        public bool posibleFaltanteFlag
        {
            get { return _posibleFaltanteFlag; }
            set { _posibleFaltanteFlag = value; }
        }

        public string cambioRYS
        {
            get { return _cambioRYS; }
            set { _cambioRYS = value; }
        }

        public DateTime? fechaMovimiento
        {
            get { return _fechaMovimiento; }
            set { _fechaMovimiento = value; }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}