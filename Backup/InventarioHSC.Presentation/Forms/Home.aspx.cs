using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms
{
    public partial class Home : System.Web.UI.Page
    {
        protected const int ColDesc = 0;
        protected const int ColLink = 1;
        protected const int ColText = 2;
        protected const float Rec_x = 0;
        protected const float Rec_y = 0;
        protected const float Rec_width = 180.0F;
        protected const float Rec_height = 100.0F;
        protected const string ImagenBase = "BasePrincipal.png";
        //Dar permisos a la carpeta de imágenes al usuario de servicio de red
        System.Data.DataTable Resultados = new System.Data.DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CrearJS();

                if (!Page.IsPostBack)
                {
                    Resultados = BLSeguridad.Top10PaginasUsuario(Session["UserNameLogin"].ToString()); //toolsGen.AdministracionUsuarios(OperacionesBD.HerramientasMSSQL.AccionesAdministracionUsuarios.Obtener_top10_paginas_por_usuario, Usu_Id: Usu_Id);

                    if (Resultados.TableName == "Error" && Resultados.Rows.Count > 0)
                        Model.DatosGenerales.EnviaMensajeH(Resultados.Rows[0][0].ToString(), "Error al cargar las páginas recientes", Model.DatosGenerales.TiposMensaje.Error);
                    else if (Resultados.TableName == "Error" && Resultados.Rows.Count == 0)
                        Model.DatosGenerales.EnviaMensajeH("No se obtuvo el detalle del error", "Error al cargar las páginas recientes", Model.DatosGenerales.TiposMensaje.Error);

                    CarouselUsr.Text = "";

                    //Limpiar imágenes anteriores del usuario
                    try
                    {
                        string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("UserImg"), "Fav_" + Session["UserNameLogin"].ToString() + "_", System.IO.SearchOption.TopDirectoryOnly);

                        foreach (string filePath in filePaths)
                            System.IO.File.Delete(filePath);
                    }
                    catch { }

                    for (int w = 0; w < Resultados.Rows.Count; w++)
                    {
                        CarouselUsr.Text += "<a href='" + Resultados.Rows[w][ColLink].ToString() + "'><img class = 'cloudcarousel' src='UserImg/" + GeneraImagen(Session["UserNameLogin"].ToString(), w, Resultados.Rows[w][ColDesc].ToString()) + "' alt='" + Resultados.Rows[w][ColText].ToString() + "' title='" + Resultados.Rows[w][ColDesc].ToString() + "' /></a>\n";
                    }
                }
            }
            catch (Exception ex)
            {
                if (Session["UserNameLogin"] == null)
                    Model.DatosGenerales.EnviaMensajeH("Ha finalizado la sesión del usuario", "Error al cargar la página", Model.DatosGenerales.TiposMensaje.Error);
                else
                    Model.DatosGenerales.EnviaMensajeH(ex.Message, "Error al cargar la página", Model.DatosGenerales.TiposMensaje.Error);
            }
        }

        protected string GeneraImagen(string UserId, int NoImg, string Texto)
        {
            string FileName = "BasePrincipal.png";
            //int deb = 0;
            try
            {
                FileName = "Fav_" + UserId + "_" + NoImg.ToString() + ".png";
                System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath("UserImg") + "\\" + ImagenBase, System.IO.FileMode.Open, System.IO.FileAccess.Read);
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
                //graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawString(Texto, drawFont, drawBrush, drawRect, drawFormat);

                //Para impedir error de GDI+ Generico en el Save se debe de dar permisos de escritura al usuario de ASP.NET
                b.Save(Server.MapPath("UserImg") + "\\" + FileName, image.RawFormat);

                fs.Close();
                image.Dispose();
                //b.Dispose();
            }
            catch (Exception ex) { FileName = "BasePrincipal.png"; Model.DatosGenerales.EnviaMensajeH(ex.Message, "Error GeneraImagen. Revise permisos de usuario IIS_IUSRS para Forms.", Model.DatosGenerales.TiposMensaje.Error); }

            return FileName;
        }

        protected void CrearJS()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type='text/JavaScript' src='../Scripts/jquery.min.js'></script>");
            sb.Append("<script type='text/JavaScript' src='../Scripts/cloud-carousel.min.js'></script>");
            sb.Append("<script>");
            sb.Append("$(document).ready(function(){");
            sb.Append("	$('#carousel1').CloudCarousel(");
            sb.Append("		{");
            sb.Append("			xPos: 400,");
            sb.Append("			yPos: 40,");
            sb.Append("			buttonLeft: $('#left-but'),");
            sb.Append("			buttonRight: $('#right-but'),");
            sb.Append("			altBox: $('#alt-text'),");
            sb.Append("			FPS: 60,"); //aumenta calidad de carrusel; > número == > calidad; > número == > procesamiento
            sb.Append("			titleBox: $('#title-text')");
            sb.Append("		}");
            sb.Append("	);");
            sb.Append("});");
            sb.Append("</script>");
            sb.Append("<script type='text/javascript'>");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "Principal", sb.ToString());
        }
    }
}