using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace InventarioHSC.Forms.Software
{
    public partial class ValidacionesJquery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool IsDateValid(string date)
        {
            DateTime result;
            return DateTime.TryParse(date, out result);
        }

        [WebMethod]
        public static bool IsDecimalValid(string monto)
        {
            decimal result;
            return decimal.TryParse(monto, out result);
        }
    }
}