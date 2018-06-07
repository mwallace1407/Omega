using System;
using System.Text;
using System.Web;
using System.Web.UI;

namespace InventarioHSC.Forms
{
    public partial class Descargas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["File"] != null && Request.QueryString["File"].ToString() != "")
                {
                    Download(Encoding.Unicode.GetString(Convert.FromBase64String(Request.QueryString["File"].ToString())));
                }
            }
        }

        protected void Download(string strURL)
        {
            try
            {
                System.Net.WebClient req = new System.Net.WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + strURL + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch { }
        }
    }
}