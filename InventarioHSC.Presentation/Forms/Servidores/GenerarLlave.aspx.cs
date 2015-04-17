using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Servidores
{
    public partial class GenerarLlave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            BLBovedaContra objBov = new BLBovedaContra();
            string Errores = "";

            if (rbTodos.Checked)
                Errores = objBov.GuardarLlave(Session["UserNameLogin"].ToString());

            if (rbEspecial.Checked)
            {
                txtCorreo.Text = txtCorreo.Text.Trim();

                if (DatosGenerales.EsEmail(txtCorreo.Text))
                    Errores = objBov.GuardarLlave(Session["UserNameLogin"].ToString(), txtCorreo.Text);
                else
                    Errores = "No es un correo válido";
            }

            if(Errores == "")
                DatosGenerales.EnviaMensaje("Revise su correo para obtenerla. Puede tardar unos minutos.", "Llave generada", DatosGenerales.TiposMensaje.Informacion);
            else
                DatosGenerales.EnviaMensaje(Errores, "Proceso interrumpido", DatosGenerales.TiposMensaje.Error);
        }

        protected void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnProcesar.Enabled = true;
            txtCorreo.Visible = false;
            rbEspecial.Text = "Enviar llave a un correo específico";
            btnProcesar.Focus();
        }

        protected void rbEspecial_CheckedChanged(object sender, EventArgs e)
        {
            btnProcesar.Enabled = true;
            txtCorreo.Visible = true;
            rbEspecial.Text = "Enviar llave a un correo específico:";
            txtCorreo.Focus();
        }
    }
}