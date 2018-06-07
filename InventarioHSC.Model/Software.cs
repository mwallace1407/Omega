namespace InventarioHSC.Model
{
    public class Software
    {
        public int Cve_Asignacion { get; set; }
        private int cve_Software;

        public int Cve_Software
        {
            get { return cve_Software; }
            set { cve_Software = value; }
        }

        public string Descripcion { get; set; }
        public string Version { get; set; }
        public int NumeroLicencias { get; set; }
        public string Serial { get; set; }
    }
}