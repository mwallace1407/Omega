using System;
using System.Web.UI;
using De_CryptDLL;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_SisCre : System.Web.UI.Page
    {
        private string Codificar(string Texto)
        {
            De_Crypt cr = new De_Crypt();

            return cr.Encriptar(Texto, DatosGenerales.UserDec + DateTime.Now.ToString("ddMMyyyy"), true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserNameLogin"] != null && Session["UserNameLogin"].ToString() != "")
                {
                    btnRedirect_Click(new object(), new EventArgs());
                }
                else
                {
                    Response.Redirect("~/Forms/sessionTimeout.html");
                }
            }
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            De_Crypt cr = new De_Crypt();
            string Usuario = Codificar(Session["UserNameLogin"].ToString());

            //Response.Redirect(DatosGenerales.RutaSisCre + "Default.aspx?cred=" + HttpContext.Current.Server.UrlEncode(Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(Usuario))));
            Response.Redirect("http://hoperaciones:84/SisCredApp/SisCreWin.application");
        }
    }
}