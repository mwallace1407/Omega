using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Services;

namespace InventarioHSC.Forms.Articulos
{
    /// <summary>
    /// Summary description for hdlDescargaExcel
    /// </summary>
    ///
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class hdlDescargaExcel : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                String sNomArch = context.Request.Params.Get("sNomArch").ToString();
                String sRuta = context.Request.Params.Get("sRuta").ToString();
                FileStream fStm = new FileStream(sRuta + "/" + sNomArch, FileMode.Open);
                Int32 intTamano = (Int32)fStm.Length;
                Byte[] bArray = new Byte[intTamano];

                fStm.Read(bArray, 0, intTamano);
                fStm.Flush();
                fStm.Close();

                if (File.Exists(sRuta + "/" + sNomArch))
                {
                    File.Delete(sRuta + "/" + sNomArch);
                }

                context.Response.Clear();
                context.Response.Buffer = true;
                context.Response.ContentType = "application/xlsx";
                context.Response.AddHeader("Content-Disposition", "attachment;filename=" + sNomArch);
                context.Response.Charset = "UTF-8"; //"UTF-8" "ISO-8859-1"
                context.Response.ContentEncoding = Encoding.GetEncoding("UTF-8"); //"UTF-8" "ISO-8859-1"
                context.Response.OutputStream.Write(bArray, 0, bArray.Length);
                context.Response.End();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}