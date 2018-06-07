using System;

namespace InventarioHSC.Forms
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}