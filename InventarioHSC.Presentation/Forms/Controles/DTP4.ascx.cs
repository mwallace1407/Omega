using System;
using System.Web.UI;

namespace InventarioHSC.Forms.Controles
{
    public partial class DTP4 : System.Web.UI.UserControl
    {
        public string DateTime
        {
            get { return txtDateTime4.Text; }
        }

        public void setDateTime(string DateTime)
        {
            txtDateTime4.Text = DateTime;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DTP4 picker = this;
            ScriptManager.RegisterClientScriptBlock(picker, picker.GetType(), "message", "<script type=\"text/javascript\" language=\"javascript\">getDateTimePicker();</script>", false);

            if (!Page.IsPostBack)
                txtDateTime4.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}