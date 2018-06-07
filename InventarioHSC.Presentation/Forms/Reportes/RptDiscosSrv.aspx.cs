using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptDiscosSrv : System.Web.UI.Page
    {
        protected const int CeldaRuta = 2;
        protected const int CeldaNombre = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            objCatalogo.ListaServidoresCompletaApp(ref chkServidores);
            chkServidores.DataBind();

            if (chkServidores.Items.Count > 0)
                chkServidores.SelectedIndex = 0;
        }

        protected string ArmadoCadena(CheckBoxList chkl)
        {
            string Resultados = "";

            if (chkl.Items.Count > 0 && chkl.Items[0].Value == "0" && chkl.Items[0].Selected)
                return "";

            for (int w = 0; w < chkl.Items.Count; w++)
            {
                if (chkl.Items[w].Selected)
                {
                    Resultados += chkl.Items[w].Value + "|";
                }
            }

            return Resultados;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //BLReportes rep = new BLReportes();

            //btnProcesar.Enabled = false;

            //string Archivo = "";

            if (chkServidores.Items[0].Selected == false)
            {
                //Archivo = rep.ReporteDiscosSrv(ArmadoCadena(chkServidores), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.DiscosSrv((int)DatosGenerales.TiposDocumentos.Reporte_DiscosEnServidor, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSDiscosSrv_", "xlsx"), 250000,
                                   ArmadoCadena(chkServidores));

                Response.Redirect("DocumentosUsuario.aspx");
            }
            else
            {
                //Archivo = rep.ReporteDiscosSrv("", Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.DiscosSrv((int)DatosGenerales.TiposDocumentos.Reporte_DiscosEnServidor, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSDiscosSrv_", "xlsx"), 250000,
                                   "");

                Response.Redirect("DocumentosUsuario.aspx");
            }

            //if (Archivo.Length > 4 && Archivo.Substring(0, 5) != "Error")
            //{
            //    Archivo = DatosGenerales.RutaReportesDinamicos + Archivo;
            //}
            //else
            //{
            //    lblMsj.Text = Archivo;
            //}

            //if (Archivo != "")
            //    Response.Redirect(Archivo);
            //else
            //    DatosGenerales.EnviaMensaje("No se encontraron resultados para su búsqueda.", "Exportar a Excel", DatosGenerales.TiposMensaje.Informacion);

            //btnProcesar.Enabled = true;
            //chkServidores.ClearSelection();
            //chkServidores.Items[0].Selected = true;
        }
    }
}