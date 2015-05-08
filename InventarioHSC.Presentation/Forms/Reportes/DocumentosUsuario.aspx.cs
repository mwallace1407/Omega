using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class DocumentosUsuario : System.Web.UI.Page
    {
        protected const int CeldaRuta = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaDatos();

                if (Request.QueryString["Tipo"] != null)
                {
                    switch (Request.QueryString["Tipo"].ToLower())
                    {
                        case "p":
                            tab01.ActiveTabIndex = 1;
                            break;
                        default:
                            tab01.ActiveTabIndex = 0;
                            break;
                    }
                }
            }
        }

        protected void CargaDatos()
        {
            BLDatosGenerales obj = new BLDatosGenerales();
            System.Data.DataTable Resultados = new System.Data.DataTable();

            if (Session["UserNameLogin"] == null)
                return;

            //Tres segundos para que reportes pequeños se generen y no se muestren erróneamente como pendientes
            System.Threading.Thread.Sleep(3000);

            //Finalizados
            Resultados = obj.ObtenerDocumentosUsuario(Session["UserNameLogin"].ToString(), (Int16)DatosGenerales.EstadosDocumentos.Finalizados);

            if (Resultados.TableName != "Error")
            {
                grdDatosFinalizados.DataSource = Resultados;
                grdDatosFinalizados.DataBind();
            }
            else
            {
                DatosGenerales.EnviaMensaje(Resultados.Rows[0][0].ToString(), "Error al obtener finalizados.", DatosGenerales.TiposMensaje.Error);
            }

            //Pendientes
            Resultados = obj.ObtenerDocumentosUsuario(Session["UserNameLogin"].ToString(), (Int16)DatosGenerales.EstadosDocumentos.Pendientes);

            if (Resultados.TableName != "Error")
            {
                grdDatosPendientes.DataSource = Resultados;
                grdDatosPendientes.DataBind();
            }
            else
            {
                DatosGenerales.EnviaMensaje(Resultados.Rows[0][0].ToString(), "Error al obtener pendientes.", DatosGenerales.TiposMensaje.Error);
            }

            //Eliminados
            Resultados = obj.ObtenerDocumentosUsuario(Session["UserNameLogin"].ToString(), (Int16)DatosGenerales.EstadosDocumentos.Eliminados);

            if (Resultados.TableName != "Error")
            {
                grdDatosEliminados.DataSource = Resultados;
                grdDatosEliminados.DataBind();
            }
            else
            {
                DatosGenerales.EnviaMensaje(Resultados.Rows[0][0].ToString(), "Error al obtener eliminados.", DatosGenerales.TiposMensaje.Error);
            }

            if (grdDatosFinalizados.Rows.Count == 0)
                lblFinalizados.Text = "No se encontraron documentos listos para descargar.";
            else
                lblFinalizados.Text = "A continuación se muestran los documentos que están listos para ser descargados:";

            if (grdDatosPendientes.Rows.Count == 0)
                lblPendientes.Text = "No se encontraron documentos pendientes.";
            else
                lblPendientes.Text = "A continuación se muestran los documentos que se están generando, una vez finalizados los podrá visualizar en la pestaña de pendientes:";

            if (grdDatosEliminados.Rows.Count == 0)
                lblEliminados.Text = "No se encontraron documentos eliminados.";
            else
                lblEliminados.Text = "A continuación se muestra un historial reciente de documentos generados:";

            if (grdDatosPendientes.Rows.Count > 0)
                tab01.ActiveTabIndex = 1;

            BLDatosGenerales gen = new BLDatosGenerales();
            int Vigencia = 0;

            int.TryParse(gen.ObtenerParametroSistema("VigenciaArchivos"), out Vigencia);

            if (Vigencia <= 0)
                Vigencia = DatosGenerales.VigenciaEstandarDocumentos;

            lblDocVigencia.Text = "Los documentos con una antigüedad mayor a " + Vigencia + " días, serán eliminados.";
        }

        protected void grdDatosFinalizados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";

                if (e.Row.Cells[CeldaRuta].Text == "#")
                {
                    lnkRuta.Enabled = false;
                    lnkRuta.ForeColor = System.Drawing.Color.SteelBlue;
                    lnkRuta.Font.Strikeout = true;
                }
            }
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DocumentosUsuario.aspx");
        }
    }
}