using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.MaxImage
{
    public partial class BuscarDocumento : System.Web.UI.Page
    {
        protected const int CeldaRuta = 5;
        protected const int CeldaNombre = 3;
        public BLCatalogos objCatalogo = new BLCatalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }

            txtFiltro.Focus();
        }

        protected void CargaCatalogos()
        {
            objCatalogo.ListaTiposFiltroMaxI(ref ddlFiltro, false);
            ddlFiltro.DataBind();
        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            lblExtra.Text = "";
            lblNoRegs.Visible = false;
            grdDatos.DataSource = null;
            grdDatos.DataBind();
            ftxt_txtFiltro.ValidChars = "";

            switch(ddlFiltro.SelectedValue)
            {
                case "CR":
                    txtFiltro.MaxLength = 6;
                    ftxt_txtFiltro.FilterType = AjaxControlToolkit.FilterTypes.Numbers;
                    lblFiltro.Text = "Crédito:";
                    break;
                case "NJ":
                    txtFiltro.MaxLength = 16;
                    ftxt_txtFiltro.FilterType = AjaxControlToolkit.FilterTypes.Numbers;
                    lblFiltro.Text = "Número JIT:";
                    break;
                case "NC":
                    txtFiltro.MaxLength = 6;
                    ftxt_txtFiltro.FilterType = AjaxControlToolkit.FilterTypes.Numbers;
                    lblFiltro.Text = "Número de cliente:";
                    break;
                case "CL":
                    txtFiltro.MaxLength = 300;
                    ftxt_txtFiltro.FilterType = AjaxControlToolkit.FilterTypes.LowercaseLetters | AjaxControlToolkit.FilterTypes.Custom;
                    ftxt_txtFiltro.ValidChars = " ";
                    lblFiltro.Text = "Nombre del cliente:";
                    lblExtra.Text = "(ApPaterno ApMaterno Nombre(s) o alguno de ellos)";
                    break;
            }
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    e.Row.VerticalAlign = VerticalAlign.Bottom;
                    e.Row.Style.Add("height", "60px");
                }

                e.Row.Cells[CeldaNombre].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                //lnkRuta.NavigateUrl = "../Descargas.aspx?File=" + HttpContext.Current.Server.UrlEncode(Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(e.Row.Cells[CeldaRuta].Text)));
                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            lblNoRegs.Visible = false;

            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();

                switch (ddlFiltro.SelectedValue)
                {
                    case "CR":
                        grdDatos.DataSource = objGrupoSoftware.BuscarDocumentoMI(ddlFiltro.SelectedValue, Numero_Prestamo: Convert.ToInt32(txtFiltro.Text));
                        break;
                    case "NJ":
                        grdDatos.DataSource = objGrupoSoftware.BuscarDocumentoMI(ddlFiltro.SelectedValue, Numero_Jit: txtFiltro.Text);
                        break;
                    case "NC":
                        grdDatos.DataSource = objGrupoSoftware.BuscarDocumentoMI(ddlFiltro.SelectedValue, Codigo_Cliente: Convert.ToInt32(txtFiltro.Text));
                        break;
                    case "CL":
                        grdDatos.DataSource = objGrupoSoftware.BuscarDocumentoMI(ddlFiltro.SelectedValue, Nombre: txtFiltro.Text);
                        break;
                }

                grdDatos.DataBind();

                if (grdDatos.Rows.Count == 0)
                {
                    lblNoRegs.Visible = true;
                }
            }
        }
    }
}