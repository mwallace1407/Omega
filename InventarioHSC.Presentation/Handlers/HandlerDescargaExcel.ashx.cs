using System;
using System.IO;
using System.Web;

namespace InventarioHSC.Handlers
{
    public class HandlerDescargaExcel : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>

        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string ruta = context.Request.Params.Get("rutaArchivo");
            string NombreArchivo = context.Request.Params.Get("nombreArchivo");

            FileStream fStm = new FileStream(ruta, System.IO.FileMode.Open);
            Int32 intTamano = (Int32)fStm.Length;
            Byte[] bArray = new Byte[intTamano];

            fStm.Read(bArray, 0, intTamano);
            fStm.Flush();
            fStm.Close();

            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.ContentType = "application/vnd.ms-excel";
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo);
            context.Response.Charset = "ISO-8859-1"; //"UTF-8"
            context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); //"UTF-8"
            context.Response.OutputStream.Write(bArray, 0, intTamano);
            context.Response.End();
        }

        #endregion IHttpHandler Members
    }
}