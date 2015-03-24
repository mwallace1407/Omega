using System;

namespace InventarioHSC.Model
{
    public class Asignacion_Software
    {
        public int Cve_Asignacion { get; set; }
        public int Cve_Software { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Key { get; set; }
        public string Lenguaje { get; set; }
        public string Material { get; set; }
        public string Area_Solicita { get; set; }
        public string Sucursal { get; set; }
        public string Lote_Code { get; set; }
        public string Proveedor { get; set; }
        public int? Numero_Factura { get; set; }
        public DateTime? Fecha_Compra { get; set; }
        public int? Numero_Requisicion_Compra { get; set; }
        public string Centro_Costo { get; set; }
        public decimal? Pesos { set; get; }
        public decimal? Dolares { get; set; }
        public string Incluido_Responsiva { get; set; }
        public DateTime? Fecha_Vencimiento { get; set; }
        public string Numero_Taejeta { get; set; }
        public string Responsiva { get; set; }
        public string Observaciones { set; get; }
    }
}
