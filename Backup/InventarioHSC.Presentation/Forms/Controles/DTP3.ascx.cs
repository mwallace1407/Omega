using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioHSC.Forms.Controles
{
    public partial class DTP3 : System.Web.UI.UserControl
    {
        public string DateTime
        {
            get { return txtDateTime3.Text; }
        }

        public void setDateTime(string DateTime)
        {
            txtDateTime3.Text = DateTime;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DTP3 picker = this;
            ScriptManager.RegisterClientScriptBlock(picker, picker.GetType(), "message", "<script type=\"text/javascript\" language=\"javascript\">getDateTimePicker();</script>", false);

            if (!Page.IsPostBack)
                txtDateTime3.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}