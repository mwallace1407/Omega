using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace InventarioHSC.Forms
{
    public partial class Mensaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session.Count > 0)
                {
                    hddPagina.Value = "";

                    try
                    {
                        hddPagina.Value = Request.UrlReferrer.ToString();
                    }
                    catch
                    {
                        hddPagina.Value = "../Default.aspx";
                    }
                }
                else
                {
                    hddPagina.Value = "../Default.aspx";
                }

                if (Request.QueryString["Tipo"] != null)
                {
                    switch (Request.QueryString["Tipo"].ToString())
                    {
                        case "I":
                            imgMensaje.ImageUrl = "~/App_Themes/Imagenes/info.png";
                            break;
                        case "A":
                            imgMensaje.ImageUrl = "~/App_Themes/Imagenes/warning.png";
                            break;
                        case "E":
                            imgMensaje.ImageUrl = "~/App_Themes/Imagenes/error.png";
                            break;
                    }
                }

                if (Request.QueryString["Titulo"] != null && Request.QueryString["Titulo"].ToString() != "")
                {
                    lblTituloDesc.Text = Encoding.Unicode.GetString(Convert.FromBase64String(Request.QueryString["Titulo"].ToString()));
                }

                if (Request.QueryString["Mensaje"] != null && Request.QueryString["Mensaje"].ToString() != "")
                {
                    lblMensajeDesc.Text = Encoding.Unicode.GetString(Convert.FromBase64String(Request.QueryString["Mensaje"].ToString()));
                }
                else
                {
                    lblMensaje.Visible = false;
                }
            }

            CrearJS();
        }

        protected void CrearJS()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type='text/javascript'>");
            sb.Append("function Regresa() {");
            sb.Append("self.location = '" + hddPagina.Value + "';");
            sb.Append("}");
            sb.Append("function Foco() {");
            sb.Append("document.getElementById('btnRegresar').focus();");
            sb.Append("}");
            sb.Append("function catchEnter(e) {");
            sb.Append("var key;");
            sb.Append("if(window.event) {");
            sb.Append("    key = window.event.keyCode; }");
            sb.Append("else {");
            sb.Append("    key = e.which; }");
            sb.Append("if (key == 13 || key == 32) {");
            sb.Append("    Regresa(); }");
            sb.Append("}");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "Mensajes", sb.ToString());
        }
    }
}