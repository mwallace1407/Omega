using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Administracion
{
    public partial class Mantenimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LimpiaTemporales(string Ruta, ref Label lblText)
        {
            string[] Archivos = Directory.GetFiles(Ruta);
            int Borrados = 0;
            double Tamanno = 0;
            int Vigencia = 0;
            BLDatosGenerales gen = new BLDatosGenerales();

            lblText.Text = "";
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

                if (Archivos.Count() == 1)
                {
                    if (Borrados == 1)
                        lblText.Text = "Se encontró " + Archivos.Count().ToString() + " archivo; " + Borrados.ToString() + " fue candidato para la limpieza.<br />Se han liberado " + Math.Round(Tamanno, 2).ToString("0.00") + "MB.";
                    else
                        lblText.Text = "Se encontró " + Archivos.Count().ToString() + " archivo; No hubo candidatos para la limpieza.";
                }
                else
                {
                    if (Borrados == 1)
                        lblText.Text = "Se encontraron " + Archivos.Count().ToString() + " archivos; " + Borrados.ToString() + " fue candidato para la limpieza.<br />Se han liberado " + Math.Round(Tamanno, 2).ToString("0.00") + "MB.";
                    else if (Borrados == 0)
                        lblText.Text = "Se encontraron " + Archivos.Count().ToString() + " archivos; No hubo candidatos para la limpieza.";
                    else
                        lblText.Text = "Se encontraron " + Archivos.Count().ToString() + " archivos; " + Borrados.ToString() + " fueron candidatos para la limpieza.<br />Se han liberado " + Math.Round(Tamanno, 2).ToString("0.00") + "MB.";
                }

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
                else
                {
                    lblText.Text += Environment.NewLine + Resultados.Rows[0][0].ToString();
                }
            }
            else
            {
                lblText.Text = "No hay archivos que sean candidatos para la limpieza";
            }
        }

        protected void btnLimpiaReportes_Click(object sender, EventArgs e)
        {
            LimpiaTemporales(Server.MapPath("../" + DatosGenerales.RutaLocalReportesGeneral), ref lblLimpiaReportes);
        }

        protected void btnLimpiaReportesSAP_Click(object sender, EventArgs e)
        {
            LimpiaTemporales(Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos), ref lblLimpiaReportesSAP);
        }
    }
}