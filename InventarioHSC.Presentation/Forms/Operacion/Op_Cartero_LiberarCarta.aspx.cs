using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_Cartero_LiberarCarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            lblMsj.Text = "";
            pnlDatos.Visible = false;

            BLOperaciones obj = new BLOperaciones();
            BLOperaciones.FolioCartero folio;

            if (txtReferencia.Text.Length == 16)
            {
                int SolId = 0;

                int.TryParse(txtReferencia.Text.Substring(8, 7), out SolId);
                folio = obj.LeerDatosFolio(SolId);

                if (folio.FolioCastorTel != "" && folio.FolioCastorTel != "0")
                {
                    lblCliente.Text = folio.NombreCliente;
                    lblDireccionGarantia.Text = folio.DireccionGarantia;
                    lblFolioCastorTel.Text = folio.FolioCastorTel;
                    lblPrestamo.Text = folio.Credito;
                    lblTipoCarta.Text = folio.TipoCarta;
                    lblFolioCartero.Text = SolId.ToString();
                    pnlDatos.Visible = true;
                    hddReferencia.Value = txtReferencia.Text;
                }
                else
                {
                    lblMsj.Text = "No se encontraron coincidencias para la referencia proporcionada";
                }
            }
            else
            {
                lblMsj.Text = "Número de referencia incorrecto";
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLOperaciones obj = new BLOperaciones();
                string Msj = "";

                Msj = obj.LiberarCarta(lblFolioCartero.Text, lblFolioCastorTel.Text, Session["UserNameLogin"].ToString());

                if (Msj == "OK")
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Liberación de Carta", DatosGenerales.TiposMensaje.Informacion);
                else
                    DatosGenerales.EnviaMensaje(Msj, "Alta de BD", DatosGenerales.TiposMensaje.Error);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Op_Cartero_LiberarCarta.aspx");
        }
    }
}