using System;
using System.Web.UI;

namespace InventarioHSC.Forms.Controles
{
    public partial class DTP2 : System.Web.UI.UserControl
    {
        public string DateTime
        {
            get { return txtDateTime2.Text; }
            set { txtDateTime2.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DTP2 picker = this;
            ScriptManager.RegisterClientScriptBlock(picker, picker.GetType(), "message", "<script type=\"text/javascript\" language=\"javascript\">getDateTimePicker();</script>", false);
        }
    }
}