using System;
using System.Web.UI;

namespace InventarioHSC.Forms.Servidores
{
    public partial class imgProc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["img"] != null)
                {
                    string Archivo = System.IO.Path.Combine(Server.MapPath("../Reportes/TmpFiles/"), Request.QueryString["img"].ToString());

                    System.Drawing.Bitmap img = LoadBitmapUnlocked(Archivo);

                    try
                    {
                        System.IO.File.Delete(Archivo);
                    }
                    catch { }

                    img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        protected System.Drawing.Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (System.Drawing.Bitmap bm = new System.Drawing.Bitmap(file_name))
            {
                return new System.Drawing.Bitmap(bm);
            }
        }
    }
}