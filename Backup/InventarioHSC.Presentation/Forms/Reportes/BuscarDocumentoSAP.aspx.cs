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
    public partial class BuscarDocumentoSAP : System.Web.UI.Page
    {
        protected const int CeldaRuta = 2;
        protected const int CeldaDescarga = 1;
        protected const int CeldaConcepto = 0;

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

            objCatalogo.CatalogoTipoDocSAP(ref ddlTipo);
            ddlTipo.DataBind();
            objCatalogo.CatalogoSubTipoDocSAP(ref ddlSubTipo);
            ddlSubTipo.DataBind();
            objCatalogo.CatalogoPeriodoDocSAP(ref ddlPeriodo);
            ddlPeriodo.DataBind();
            objCatalogo.CatalogoAnioDocSAP(ref ddlAnio);
            ddlAnio.DataBind();
            objCatalogo.CatalogoAnioDocSAP(ref ddlAnio2);
            ddlAnio2.DataBind();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdDatos.DataSource = null;
            grdDatos.DataBind();

            switch(ddlTipo.SelectedValue)
            {
                case "C":
                    pnlG1.Visible = true;
                    pnlG2.Visible = false;
                    break;
                case "F":
                    pnlG1.Visible = true;
                    pnlG2.Visible = false;
                    break;
                case "R":
                    pnlG1.Visible = false;
                    pnlG2.Visible = true;
                    break;
                default:
                    pnlG1.Visible = false;
                    pnlG2.Visible = false;
                    break;
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            BLReportes rep = new BLReportes();
            int Anio;

            lblNoRegs.Visible=false;
            lblNoRegs.Text = "No se encontraron registros";
            int.TryParse(ddlAnio.SelectedValue, out Anio);

            if (Page.IsValid)
            {
                int Empleado = 0;

                int.TryParse(txtFiltro.Text, out Empleado);
                grdDatos.DataSource = rep.Documentos(ddlTipo.SelectedValue, "", Anio, Empleado.ToString());
                grdDatos.DataBind();

                if (grdDatos.Rows.Count == 0)
                    lblNoRegs.Visible = true;
            }
            else
            {
                lblNoRegs.Text = "No se ha ingresado toda la información necesaria. Revise por favor.";
            }
        }

        protected void btnProcesar2_Click(object sender, EventArgs e)
        {
            BLReportes rep = new BLReportes();
            int Anio;

            lblNoRegs.Visible = false;
            lblNoRegs.Text = "No se encontraron registros";
            int.TryParse(ddlAnio2.SelectedValue, out Anio);

            if (Page.IsValid)
            {
                grdDatos.DataSource = rep.Documentos(ddlTipo.SelectedValue, ddlSubTipo.SelectedValue, Anio, ddlPeriodo.SelectedValue);
                grdDatos.DataBind();

                if (grdDatos.Rows.Count == 0)
                    lblNoRegs.Visible = true;
            }
            else
            {
                lblNoRegs.Text = "No se ha ingresado toda la información necesaria. Revise por favor.";
            }
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                e.Row.Cells[CeldaConcepto].Style.Add("text-align", "left");
                e.Row.Cells[CeldaDescarga].Style.Add("text-align", "left");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";
            }
        }
    }
}