using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
namespace InventarioHSC.Forms
{
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            //BLSeguridad objSeg = new BLSeguridad();
            //if (Membership.ValidateUser(Login1.UserName.ToString().ToUpper(), "SuCasita_123"))
            //{
            //}

            //            if(objSeg.ValidaUsuario(Login1.UserName.ToString().ToLower(), Login1.Password.ToString())
            //{
            //            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
            //                    }
            //else
            //{
            //            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            //            jScript.Append("<Script>" + Environment.NewLine);
            //            jScript.Append("alert('Usuario o Contraseña invalida');" + Environment.NewLine);
            //            jScript.Append("</Script>" + Environment.NewLine);
            //            ClientScript.RegisterStartupScript(this.GetType(), "Bookmark", jScript.ToString());
            //}

        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            BLSeguridad objSeg = new BLSeguridad();
            if (Membership.ValidateUser(Login1.UserName.ToString().ToUpper(), "SuCasita_123"))
            {
                if (objSeg.ValidaUsuario(Login1.UserName.ToString().ToLower(), Login1.Password.ToString()))
                {
                    e.Authenticated = true;
                    Session["NombreCompletoUsuario"] = objSeg.DatosDelUsuario(Login1.UserName.ToString().ToLower());
                    Session["NombreCompletoRol"] = objSeg.GrupoDelUsuario(Login1.UserName.ToString().ToLower());
                }
                //FormsAuthentication.Authenticate(Login1.UserName.ToString().ToUpper(), "SuCasita_123");
            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            //BLSeguridad objSeg = new BLSeguridad();
            //if (Membership.ValidateUser(Login1.UserName.ToString().ToUpper(), "SuCasita_123"))
            //{
            //    if (objSeg.ValidaUsuario(Login1.UserName.ToString().ToLower(), Login1.Password.ToString()))
            //    {
            //        ((TextBox)Login1.FindControl("Password")).Text = "SuCasita_123";
            //        FormsAuthentication.Authenticate(Login1.UserName.ToString().ToUpper(), "SuCasita_123");
            //    }
            //}

        }
    }
}