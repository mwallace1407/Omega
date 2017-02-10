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
    public partial class RptRelSrvBD : System.Web.UI.Page
    {
        protected const int CeldaRuta = 2;
        protected const int CeldaNombre = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            objCatalogo.ListaServidoresCompletaApp(ref chkServidores);
            chkServidores.DataBind();

            if (chkServidores.Items.Count > 0)
                chkServidores.SelectedIndex = 0;
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[CeldaNombre].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";
            }
        }

        protected string ArmadoCadena(CheckBoxList chkl)
        {
            string Resultados = "";

            if (chkl.Items.Count > 0 && chkl.Items[0].Value == "0" && chkl.Items[0].Selected)
                return "";

            for (int w = 0; w < chkl.Items.Count; w++)
            {
                if (chkl.Items[w].Selected)
                {
                    Resultados += chkl.Items[w].Value + "|";
                }
            }

            return Resultados;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //BLReportes rep = new BLReportes();

            //btnProcesar.Enabled = false;

            if (chkServidores.Items[0].Selected == false)
            {
                //grdDatos.DataSource = rep.ReporteRelSrvBD(ArmadoCadena(chkServidores),
                //                                          Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
                //grdDatos.DataBind();
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.RelSrvBD((int)DatosGenerales.TiposDocumentos.Reporte_BDEnServidor, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSSrvBD_", "xlsx"), 250000,
                                   ArmadoCadena(chkServidores));

                Response.Redirect("DocumentosUsuario.aspx");
            }
            else
            {
                //grdDatos.DataSource = rep.ReporteRelSrvBD("",
                //                                          Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
                //grdDatos.DataBind();
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.RelSrvBD((int)DatosGenerales.TiposDocumentos.Reporte_BDEnServidor, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSSrvBD_", "xlsx"), 250000,
                                   "");

                Response.Redirect("DocumentosUsuario.aspx");
            }

            //btnProcesar.Enabled = true;
            //chkServidores.ClearSelection();
            //chkServidores.Items[0].Selected = true;
        }
    }
}