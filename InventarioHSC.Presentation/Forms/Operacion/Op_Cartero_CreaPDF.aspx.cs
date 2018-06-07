using System;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_Cartero_CreaPDF : System.Web.UI.Page
    {
        protected void ObtenerCarta(int Cart_Id)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BLOperaciones objOp = new BLOperaciones();
            int Cart_Id = 0;

            if (Request.QueryString["CartId"] != null)
                int.TryParse(Request.QueryString["CartId"].ToString(), out Cart_Id);

            if (Cart_Id > 0)
            {
                lblMsj.ForeColor = System.Drawing.Color.Black;
                lblMsj.Text = "Generando PDF...";

                string Archivo = DatosGenerales.GeneraNombreArchivoRnd("Carta_", "pdf");
                string MensajeBD = "";

                Archivo = System.IO.Path.Combine(Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos), Archivo);
                MensajeBD = objOp.CrearPDFCartaGenerada(Archivo, Cart_Id);

                if (MensajeBD == "OK")
                {
                    Response.Redirect(DatosGenerales.RutaReportesDinamicos + System.IO.Path.GetFileName(Archivo));
                }
                else
                {
                    lblMsj.ForeColor = System.Drawing.Color.DarkRed;
                    lblMsj.Text = MensajeBD;
                }
            }
            else
            {
                lblMsj.ForeColor = System.Drawing.Color.DarkRed;
                lblMsj.Text = "No se encontró la carta especificada.";
            }
        }
    }
}