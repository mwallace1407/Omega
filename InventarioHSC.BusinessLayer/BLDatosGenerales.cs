using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventarioHSC.DataLayer;
using System.Data;
using InventarioHSC.Model;
using System.Web.UI.WebControls;

namespace InventarioHSC.BusinessLayer
{
    public class BLDatosGenerales
    {
        public BLDatosGenerales()
        { 
        }
        public void ObtieneDatosGenerales(string[] sParametros)
        {
            DLDatosGenerales datosGenerales = new DLDatosGenerales();
            StringBuilder strB = new StringBuilder();

            List<DatosGenerales> lstDatosGenerales = datosGenerales.getDatosGenerales(sParametros);
        }
        public DataView ObtieneDatosGrid(string sTipoActivo)
        {
            DLDatosGenerales datosGenerales = new DLDatosGenerales();
            DataView dv = datosGenerales.getDatosGenerales(sTipoActivo);

            return dv;
        }

        public void EstablecerParametroSistema(string Parametro, string Valor)
        {
            DLDatosGenerales datosGenerales = new DLDatosGenerales();

            datosGenerales.EstablecerParametroSistema(Parametro, Valor);
        }

        public string ObtenerParametroSistema(string Parametro)
        {
            DLDatosGenerales datosGenerales = new DLDatosGenerales();

            return datosGenerales.ObtenerParametroSistema(Parametro);
        }

        public DataTable ObtenerDocumentosUsuario(string UserName, Int16 Finalizado)
        {
            DLDatosGenerales datosGenerales = new DLDatosGenerales();

            return datosGenerales.ObtenerDocumentosUsuario(UserName, Finalizado);
        }

        public string EliminarArchivo(string DocU_Nombre)
        {
             DLDatosGenerales datosGenerales = new DLDatosGenerales();

             return datosGenerales.EliminarArchivo(DocU_Nombre); 
        }

        public DataTable TestScript(string Query, string Cnx)
        {
            DLDatosGenerales datosGenerales = new DLDatosGenerales();

            return datosGenerales.TestScript(Query, Cnx);
        }

        public string FormatearSQL_HTML(string Script)
        {
            BLFormatSQL formatter = new BLFormatSQL();

            return formatter.FormatTSqlToHTML(Script);
        }

        public string FormatearSQL_TextoSimple(string Script, int TabSpaces = 4)
        {
            BLFormatSQL formatter = new BLFormatSQL();
            string formatted = formatter.FormatTSqlToString(Script);
            string tabs = "";

            for (int w = 0; w < TabSpaces; w++)
                tabs += " ";

            return formatted.Replace("\t", tabs);
        }
    }
}
