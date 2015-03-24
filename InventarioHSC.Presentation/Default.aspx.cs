using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;
using System.IO;

namespace InventarioHSC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {

        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            BLSeguridad objSeg = new BLSeguridad();
            if (Membership.ValidateUser(Login1.UserName.ToString().ToUpper(), "SuCasita_123"))
            {
                if (objSeg.ValidaUsuario(Login1.UserName.ToString().ToLower(), Login1.Password.ToString()))
                {
                    e.Authenticated = true;
                    Session["UserNameLogin"] = Login1.UserName.ToString().ToLower();
                    Session["NombreCompletoUsuario"] = objSeg.DatosDelUsuario(Login1.UserName.ToString().ToLower());
                    Session["NombreCompletoRol"] = objSeg.GrupoDelUsuario(Login1.UserName.ToString().ToLower());
                    VerificarMantenimiento();
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
        }

        protected void VerificarMantenimiento()
        {
            try
            {
                BLDatosGenerales objGen = new BLDatosGenerales();

                if (DatosGenerales.CalculateDateDiff(DatosGenerales.ObtieneFechaHora(objGen.ObtenerParametroSistema(DatosGenerales.ParamMtto)), DateTime.Now).TotalDays > Convert.ToDouble(DatosGenerales.VigenciaEstandarDocumentos))
                {
                    LimpiaTemporales(Server.MapPath("Forms/Reportes/" + DatosGenerales.RutaLocalReportesDinamicos));                    
                }
            }
            catch { }
        }

        protected void LimpiaTemporales(string Ruta)
        {
            string[] Archivos = Directory.GetFiles(Ruta);
            int Borrados = 0;
            double Tamanno = 0;
            int Vigencia = 0;
            BLDatosGenerales gen = new BLDatosGenerales();

            int.TryParse(gen.ObtenerParametroSistema("VigenciaArchivos"), out Vigencia);

            if (Vigencia <= 0)
                Vigencia = DatosGenerales.VigenciaEstandarDocumentos * -1;
            else
                Vigencia = Vigencia * -1;

            if (Archivos.Count() > 0)
            {
                foreach (string Archivo in Archivos)
                {
                    FileInfo fi = new FileInfo(Archivo);

                    if (fi.CreationTime <= DateTime.Now.AddDays(Vigencia))
                    {
                        try
                        {
                            File.Delete(Archivo);
                            Tamanno += Convert.ToDouble(fi.Length);
                            gen.EliminarArchivo(Path.GetFileName(Archivo));
                        }
                        catch { }
                        finally { Borrados++; }
                    }
                }

                BLDatosGenerales objGen = new BLDatosGenerales();

                objGen.EstablecerParametroSistema(DatosGenerales.ParamMtto, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                Tamanno = (Tamanno / 1024) / 1024;

                System.Data.DataTable Resultados = new System.Data.DataTable();

                Resultados = gen.ObtenerDocumentosUsuario("", (Int16)DatosGenerales.EstadosDocumentos.Vigentes);

                if (Resultados.TableName != "Error")
                {
                    for (int w = 0; w < Resultados.Rows.Count; w++)
                    {
                        if (!File.Exists(Path.Combine(Ruta, Resultados.Rows[0][1].ToString())))
                            gen.EliminarArchivo(Path.GetFileName(Resultados.Rows[0][1].ToString()));
                    }
                }
            }
        }
    }
}