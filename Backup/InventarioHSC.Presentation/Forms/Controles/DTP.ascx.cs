using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioHSC.Forms.Controles
{
    public partial class DTP : System.Web.UI.UserControl
    {
        public string DateTime
        {
            get { return txtDateTime.Text; }
            set { txtDateTime.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DTP picker = this;
            ScriptManager.RegisterClientScriptBlock(picker, picker.GetType(), "message", "<script type=\"text/javascript\" language=\"javascript\">getDateTimePicker();</script>", false);
        }
    }
}