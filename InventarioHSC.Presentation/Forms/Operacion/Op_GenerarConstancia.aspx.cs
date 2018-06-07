using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_GenerarConstancia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            DatosGenerales.ComboAnnosConstancia(ref ddlAnno);
            ddlAnno.DataBind();

            foreach (WS_PDF.TipoPDF r in Enum.GetValues(typeof(WS_PDF.TipoPDF)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(WS_PDF.TipoPDF), r), r.ToString());
                ddlTipoCliente.Items.Add(item);
            }
        }

        private void ProcesarArchivo(byte[] Datos, string MsjError, int Numero_Prestamo, int Anno)
        {
            try
            {
                lblMsj.Text = "";

                if (MsjError == "")
                {
                    string Archivo = Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos) + "/" + DatosGenerales.GeneraNombreArchivoRnd("Constancia_", "pdf");
                    System.IO.BinaryWriter binWriter = new System.IO.BinaryWriter(System.IO.File.Open(Archivo, System.IO.FileMode.CreateNew, System.IO.FileAccess.ReadWrite));

                    binWriter.Write(Datos);
                    binWriter.Close();
                    ltlDescarga.Text = "<a href='" + DatosGenerales.RutaReportesDinamicos + System.IO.Path.GetFileName(Archivo) + "' class='HyperLink'>Descargar archivo</a>";

                    WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                    exportar.RegistrarArchivoTempGeneral((int)DatosGenerales.TiposDocumentos.Constancias, Session["UserNameLogin"].ToString(), System.IO.Path.GetFileName(Archivo), true);

                    Response.Redirect("../Reportes/DocumentosUsuario.aspx");
                }
                else
                {
                    lblMsj.Text = MsjError;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = "Error: " + ex.Message;
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            lblMsj.Text = "";
            ltlDescarga.Text = "";

            if (Page.IsValid)
            {
                int Numero_Prestamo = 0;
                int Anno = 0;

                int.TryParse(txtPrestamo.Text, out Numero_Prestamo);
                int.TryParse(ddlAnno.SelectedValue, out Anno);

                if (Numero_Prestamo > 0)
                {
                    WS_PDF.GenerarSoapClient wsGenerarPDF = new WS_PDF.GenerarSoapClient();
                    WS_PDF.Archivo archivoPDF;

                    if (ddlTipoCliente.SelectedItem.Text == "Acreditado")
                        archivoPDF = wsGenerarPDF.GenerarPDF(Numero_Prestamo, WS_PDF.TipoPDF.Acreditado, Anno, 100, "1", chkForzar.Checked);
                    else
                        archivoPDF = wsGenerarPDF.GenerarPDF(Numero_Prestamo, WS_PDF.TipoPDF.Coacreditado, Anno, 100, "1", chkForzar.Checked);

                    ProcesarArchivo(archivoPDF.Datos, archivoPDF.MsjError, Numero_Prestamo, Anno);
                }
                else
                {
                    lblMsj.Text = "Número de préstamo incorrecto";
                }
            }
        }
    }
}