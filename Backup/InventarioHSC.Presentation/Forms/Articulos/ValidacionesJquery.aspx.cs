using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace InventarioHSC.Forms.Articulos
{
    public partial class ValidacionesJquery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool IsValidaBusqueda(string responsiva, string usuario)
        {
            if (string.IsNullOrEmpty(responsiva) && usuario.Equals("1191"))
                return false;
            else
                return true;
        }
    }
}