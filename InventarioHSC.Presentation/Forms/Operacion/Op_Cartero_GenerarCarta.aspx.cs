using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;
using System.IO;
using iTextSharp.text.pdf;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_Cartero_GenerarCarta : System.Web.UI.Page
    {
        #region Metodos
        protected string ArmarCadena()
        {
            string Cadena = System.IO.File.ReadAllText(Server.MapPath("CartaLiberacionDN.html"));

            Cadena = Cadena.Replace("@@FechaDoc", DatosGenerales.CrearFechas(txtFechaDocumento.Text, DatosGenerales.FormatosFecha.Dianum_Mestxt_Anno));
            Cadena = Cadena.Replace("@@Destinatario01", txtDestinatario01.Text);
            Cadena = Cadena.Replace("@@Destinatario02", txtDestinatario02.Text);
            Cadena = Cadena.Replace("@@NumeroCredito", txtNumeroPrestamo.Text);
            Cadena = Cadena.Replace("@@Acreditado", txtAcreditado.Text);
            Cadena = Cadena.Replace("@@Direccion", txtDireccion.Text);
            Cadena = Cadena.Replace("@@NumeroEscritura", txtNumeroEscritura.Text);
            Cadena = Cadena.Replace("@@NombreNotario", txtNombreNotario.Text);
            Cadena = Cadena.Replace("@@NumeroNotaria", txtNumeroNotaria.Text);
            Cadena = Cadena.Replace("@@FechaFirmaEscritura", DatosGenerales.CrearFechas(txtFechaFirmaEscritura.Text, DatosGenerales.FormatosFecha.Diatxt_Dianum_Mestxt_Anno));
            Cadena = Cadena.Replace("@@NombreRevisor", txtNombreRevisor.Text);
            Cadena = Cadena.Replace("@@CorreoRevisor", txtCorreoRevisor.Text);
            Cadena = Cadena.Replace("@@NombreRepresentante", txtNombreRepresentante.Text);
            Cadena = Cadena.Replace("@@FechaVigencia", DatosGenerales.CrearFechas(txtFechaVigencia.Text, DatosGenerales.FormatosFecha.Diatxt_Dianum_Mestxt_Anno));
            Cadena = Cadena.Replace("@@NombreFirma", txtNombreFirma.Text);
            Cadena = Cadena.Replace("@@PuestoFirma", txtPuestoFirma.Text);
            Cadena = Cadena.Replace("@@ImagenFirma", Server.MapPath("../../App_Themes/Imagenes/firma.jpg"));
            Cadena = Cadena.Replace("@@ImagenLogo", Server.MapPath("../../App_Themes/Imagenes/LogoHSC.png"));
            Cadena = Cadena.Replace("@@ImagenPie", Server.MapPath("../../App_Themes/Imagenes/piePag.png"));
            
            return Cadena;
        }

        protected string EncriptarPDF(string Archivo)
        {
            string ArchivoE = "";

            try
            {
                Random rnd = new Random();
                string Key = DateTime.Now.AddMinutes(rnd.NextDouble()).ToString("yyyyMMMMddddHHmmssfffff");
                //string Key = "Pruebas";
                string CarpetaArchivo = Path.GetDirectoryName(Archivo);

                ArchivoE = Path.Combine(CarpetaArchivo, Path.GetFileNameWithoutExtension(Archivo) + rnd.Next().ToString() + ".pdf");

                using (Stream input = new FileStream(Archivo, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (Stream output = new FileStream(ArchivoE, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        PdfReader reader = new PdfReader(input);
                        PdfEncryptor.Encrypt(reader, output, true, null, Key, PdfWriter.ALLOW_PRINTING);
                    }
                }

                if (File.Exists(ArchivoE))
                    File.Delete(Archivo);
            }
            catch (Exception ex)
            {
                ArchivoE = "Error: " + ex.Message;
            }

            return ArchivoE;
        }

        protected string Convertir_HTMLaPDF(string Archivo, string CodigoHTML)
        {
            string ArchivoR = "";

            try
            {
                object TargetFile = Archivo;
                string ModifiedFileName = string.Empty;
                string FinalFileName = string.Empty;

                HtmlToPdfBuilder builder = new HtmlToPdfBuilder(iTextSharp.text.PageSize.LETTER);
                HtmlPdfPage first = builder.AddPage();
                first.AppendHtml(CodigoHTML);
                byte[] file = builder.RenderPdf();
                System.IO.File.WriteAllBytes(TargetFile.ToString(), file);

                ArchivoR = EncriptarPDF(Archivo);
            }
            catch (Exception ex)
            {
                ArchivoR = "Error: " + ex.Message;
            }

            return ArchivoR;
        }
        #endregion Metodos

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");

            if (!Page.IsPostBack)
            {
                int MesesVigencia = 0;

                int.TryParse(hddMesesVigencia.Value, out MesesVigencia);
                txtFechaDocumento.Text = DateTime.Now.ToString("dd/MM/yyyy");

                if (MesesVigencia > 0)
                    txtFechaVigencia.Text = DateTime.Now.AddMonths(MesesVigencia).ToString("dd/MM/yyyy");

                txtDestinatario01.Focus();
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int NumeroPrestamo = 0;

                int.TryParse(txtNumeroPrestamo.Text, out NumeroPrestamo);

                if (!DatosGenerales.EsFecha(txtFechaDocumento.Text))
                {
                    MsgBoxU.AddMessage("Fecha de documento errónea", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    return;
                }

                if (!DatosGenerales.EsFecha(txtFechaFirmaEscritura.Text))
                {
                    MsgBoxU.AddMessage("Fecha de firma errónea", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    return;
                }

                if (!DatosGenerales.EsFecha(txtFechaVigencia.Text))
                {
                    MsgBoxU.AddMessage("Fecha de vigencia errónea", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    return;
                }

                if (NumeroPrestamo <= 0)
                {
                    MsgBoxU.AddMessage("Número de préstamo incorrecto", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    return;
                }

                string Archivo = DatosGenerales.GeneraNombreArchivoRnd("Carta_", "pdf");

                Archivo = Path.Combine(Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos), Archivo);
                Archivo = Convertir_HTMLaPDF(Archivo, ArmarCadena());

                if (!Archivo.Contains("Error"))
                {
                    BLOperaciones obj = new BLOperaciones();
                    string Referencia = "";

                    hddArchivoSencillo.Value = Path.GetFileName(Archivo);
                    hddArchivo.Value = DatosGenerales.RutaReportesDinamicos + Path.GetFileName(Archivo);
                    Referencia = obj.RegistrarCarta(Session["UserNameLogin"].ToString(), DatosGenerales.ObtieneFecha(txtFechaDocumento.Text), Convert.ToInt32(txtNumeroPrestamo.Text), txtAcreditado.Text, File.ReadAllBytes(Archivo));

                    if (Referencia.Length == 16 && !Referencia.Contains("Error"))
                    {
                        lblReferencia.Text = "Se ha generado la carta asociada a la referencia: " + Referencia + ". " + hddConvenio.Value;
                        btnArchivo.Enabled = true;
                    }
                    else
                    {
                        lblReferencia.Text = Referencia;
                        btnArchivo.Enabled = false;
                    }

                    mp2.Show();
                }
                else
                {
                    DatosGenerales.EnviaMensaje("Error al generar la carta", "Generar carta", DatosGenerales.TiposMensaje.Informacion);
                }
            }
        }

        protected void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            CodigoHTML.Text = ArmarCadena();
            mp1.Show();
        }

        protected void btnRecalcular_Click(object sender, EventArgs e)
        {
            DateTime Fecha = DatosGenerales.ObtieneFecha(txtFechaDocumento.Text);
            int MesesVigencia = 0;

            int.TryParse(hddMesesVigencia.Value, out MesesVigencia);

            if (Fecha.ToString("yyyyMMdd") != "19000101")
                txtFechaVigencia.Text = Fecha.AddMonths(MesesVigencia).ToString("dd/MM/yyyy");
        }

        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            //Response.Redirect(hddArchivo.Value);
            //Response.Write("<script type='text/javascript'>window.open('" + hddArchivo.Value + "','_blank');</script>");
            WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

            exportar.RegistrarArchivoTempGeneral((int)DatosGenerales.TiposDocumentos.Cartero_Cartas, Session["UserNameLogin"].ToString(), hddArchivoSencillo.Value, true);

            Response.Redirect("../Reportes/DocumentosUsuario.aspx");
        }

        protected void btnClose2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Op_Cartero_GenerarCarta.aspx");
        }

        protected void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Op_Cartero_GenerarCarta.aspx");
        }
        #endregion Eventos

    }
}