using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Servidores
{
    public partial class LecturaBoveda : System.Web.UI.Page
    {
        #region Variables

        protected const float Rec_x = 0;
        protected const float Rec_y = 0;
        protected const float Rec_width = 325.0F;
        protected const float Rec_height = 100.0F;
        protected const string ImagenBase = "BasePrincipalP.png";

        #endregion Variables

        #region Metodos

        protected void GeneraImagen(string Texto)
        {
            imgPass.Visible = false;

            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath("~/Forms/UserImg") + "\\" + ImagenBase, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                //fs.Close();
                System.Drawing.Bitmap b = new System.Drawing.Bitmap(image);
                System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(b);
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                System.Drawing.RectangleF drawRect = new System.Drawing.RectangleF(Rec_x, Rec_y, Rec_width, Rec_height);
                System.Drawing.Pen whitePen = new System.Drawing.Pen(System.Drawing.Color.Transparent);
                graphics.DrawRectangle(whitePen, Rec_x, Rec_y, Rec_width, Rec_height);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.Alignment = System.Drawing.StringAlignment.Center;
                drawFormat.LineAlignment = System.Drawing.StringAlignment.Center;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                graphics.DrawString(Texto, drawFont, drawBrush, drawRect, drawFormat);

                //Para impedir error de GDI+ Generico en el Save se debe de dar permisos de escritura al usuario de ASP.NET
                string Archivo = System.IO.Path.Combine(Server.MapPath("../Reportes/TmpFiles/"), DatosGenerales.GeneraNombreArchivoRnd("Bov_", "png"));
                b.Save(Archivo, image.RawFormat);
                imgPass.ImageUrl = "imgProc.aspx?img=" + System.IO.Path.GetFileName(Archivo);
                imgPass.Visible = true;
                pnlMsjP.Visible = false;

                fs.Close();
                image.Dispose();
                //System.IO.File.Delete(Archivo);
            }
            catch (Exception ex)
            {
                lblMsjP.Text = "No se pudo generar la imagen: " + ex.Message;
            }
        }

        #endregion Metodos

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLBovedaContra objBov = new BLBovedaContra();

                string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                objBov.ObtenerListaTipos(ref ddlTiposS);
            }

            if (IsPostBack && hddKey.Value == "")
            {
                bool fileOK = false;
                string path = Server.MapPath("../Reportes/TmpFiles/");

                pnlDatos.Visible = false;
                pnlDatosM.Visible = false;

                if (upFile.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(upFile.FileName).ToLower();
                    string[] allowedExtensions = { ".bkey" };

                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                            fileOK = true;
                    }

                    if (fileOK)
                    {
                        try
                        {
                            BLBovedaContra objBov = new BLBovedaContra();
                            string Archivo = path + DatosGenerales.GeneraNombreArchivoRnd("Bov_", "bkey");

                            upFile.PostedFile.SaveAs(Archivo);
                            hddKey.Value = System.IO.File.ReadAllText(Archivo);
                            System.IO.File.Delete(Archivo);

                            if (objBov.VerificarHash(DatosGenerales.ObtenerHashCadena(hddKey.Value)) > 0)
                            {
                                pnlCarga.Visible = false;
                                hddHash.Value = DatosGenerales.ObtenerHashCadena(hddKey.Value);
                                objBov.ObtenerListaTipos(ref ddlTiposS);

                                if (rbMultiple.Checked)
                                    pnlDatosM.Visible = true;
                                else
                                    pnlDatos.Visible = true;
                            }
                            else
                            {
                                lblMsjCarga.Text = "No se encontró el Hash suministrado.";
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMsjCarga.Text = "No se pudo cargar el archivo: " + ex.Message;
                        }
                    }
                    else
                    {
                        lblMsjCarga.Text = "Tipo de archivo incorrecto.";
                    }
                }
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            pnlCarga.Visible = true;
            pnlOpciones.Visible = false;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
        }

        protected void ddlTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlMsjP.Visible = true;
            imgPass.Visible = false;

            BLBovedaContra objBov = new BLBovedaContra();
            int Tipo = 0;

            lblMsjP.Text = "";
            int.TryParse(ddlTiposS.SelectedValue, out Tipo);

            if (Tipo > 0)
            {
                objBov.ObtenerListaP(ref ddlListaP, hddHash.Value, Tipo);

                if (ddlListaP.Items.Count > 1)
                {
                    ddlListaP.Visible = true;
                }
                else
                {
                    ddlListaP.Visible = false;
                    lblMsjP.Text = "No se encontraron contraseñas encriptadas con la llave proporcionada";
                }
            }
            else
            {
                ddlListaP.DataSource = null;
                ddlListaP.DataBind();
                ddlListaP.Visible = false;
            }
        }

        protected void ddlListaP_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlMsjP.Visible = true;
            imgPass.Visible = false;

            BLBovedaContra objBov = new BLBovedaContra();
            De_CryptDLL.De_Crypt crypto = new De_CryptDLL.De_Crypt();
            int Id = 0;

            int.TryParse(ddlListaP.SelectedValue, out Id);
            BLBovedaContra.DatosPass Datos = new BLBovedaContra.DatosPass(Id);

            if (Datos.Pass != "")
                GeneraImagen(crypto.Desencriptar(Datos.Pass, Datos.Objeto + Datos.Login + hddKey.Value, true));
            else
                lblMsjP.Text = "No se encontraron contraseñas encriptadas con el elemento seleccionado";
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
        }

        #endregion Eventos
    }
}