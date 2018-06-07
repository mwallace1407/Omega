using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC
{
    public partial class BusquedaArticulo : System.Web.UI.Page
    {
        public BLArticulo oblArticulo = new BLArticulo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Warning.Visible = false;
                Info.Visible = false;
                CargaCatalogos();
            }
        }

        public void CargaCatalogos()
        {
            BLCatalogos oblCatalogos = new BLCatalogos();

            oblCatalogos.CargaTipoEquipo(ref ddlTipoArticulo);
            ddlTipoArticulo.DataBind();

            oblCatalogos.CargaUsuarioBusca(ref ddlUsuario);
            ddlUsuario.DataBind();

            oblCatalogos.CargaUbicacion(ref ddlUbicacion);
            ddlUbicacion.DataBind();
        }

        protected void chklstFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chklstFiltros.Items[0].Selected)
            {
                txtNoSerie.Enabled = true;
            }
            else
            {
                txtNoSerie.Enabled = false;
                txtNoSerie.Text = string.Empty;
            }
            if (chklstFiltros.Items[1].Selected)
            {
                txtResponsiva.Enabled = true;
            }
            else
            {
                txtResponsiva.Enabled = false;
                txtResponsiva.Text = string.Empty;
            }
            if (chklstFiltros.Items[2].Selected)
            {
                ddlUsuario.Enabled = true;
            }
            else
            {
                ddlUsuario.Enabled = false;
                ddlUsuario.SelectedIndex = 0;
            }
            if (chklstFiltros.Items[3].Selected)
            {
                ddlUbicacion.Enabled = true;
            }
            else
            {
                ddlUbicacion.Enabled = false;
                ddlUbicacion.SelectedValue = "0";
            }
            if (chklstFiltros.Items[4].Selected)
            {
                ddlTipoArticulo.Enabled = true;
            }
            else
            {
                ddlTipoArticulo.Enabled = false;
                ddlTipoArticulo.SelectedValue = "0";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LabelInfo.Visible = false;
            LabelInfo.Text = "";
            Info.Visible = false;

            ArrayList Params = new ArrayList();
            if (chklstFiltros.Items[0].Selected || chklstFiltros.Items[1].Selected || chklstFiltros.Items[2].Selected || chklstFiltros.Items[3].Selected || chklstFiltros.Items[4].Selected)
            {
                Params.Add(txtNoSerie.Text);
                Params.Add(txtResponsiva.Text);
                Params.Add(chklstFiltros.Items[2].Selected ? Convert.ToInt32(ddlUsuario.SelectedValue) : 0);
                Params.Add(Convert.ToInt32(ddlUbicacion.SelectedValue));
                Params.Add(Convert.ToInt32(ddlTipoArticulo.SelectedValue));

                gvwArticulos.DataSource = oblArticulo.BuscaArticuloFitrado(Params);
                gvwArticulos.DataBind();

                grvTotalGeneral.DataSource = oblArticulo.BuscaTotal(Params, 1);
                grvTotalGeneral.DataBind();

                grvTotalUbicacion.DataSource = oblArticulo.BuscaTotal(Params, 2);
                grvTotalUbicacion.DataBind();

                grvTotalTipo.DataSource = oblArticulo.BuscaTotal(Params, 3);
                grvTotalTipo.DataBind();
            }

            if (gvwArticulos.Rows.Count > 0)
            {
                ExportaExcel.Visible = true;
                pnlTotales.Visible = true;
            }
            else
            {
                ExportaExcel.Visible = false;
                pnlTotales.Visible = false;
                LabelInfo.Visible = true;
                LabelInfo.Text = "No hay elementos para exportar";
                Info.Visible = true;
            }
        }

        protected void gvwArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowIndex > -1)
            //    {
            //        if (e.Row.RowType == DataControlRowType.DataRow)
            //        {
            //            e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
            //            e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
            //            e.Row.Cells[0].ToolTip = "Editar";
            //            e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gvwArticulos','Editar$" + (e.Row.RowIndex).ToString().Trim() + "')");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LabelError.Visible = true;
            //    LabelError.Text = ex.Message;
            //    Warning.Visible = true;
            //}
        }

        protected void gvwArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Articulo objArticulo = new Articulo();

            if (e.CommandName == "Edit")
            {
                string sPagina = "~/Forms/Articulos/ConsultaArticulo.aspx?idItem=";
                int index = Convert.ToInt32(e.CommandArgument);
                string s_idImte = gvwArticulos.DataKeys[index].Values["idItem"].ToString();
                string sURL = sPagina + s_idImte + "&Auto=1";
                Response.Redirect(sURL);
            }
        }

        protected void gvwArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ArrayList Params = new ArrayList();

            Params.Add(txtNoSerie.Text);
            Params.Add(txtResponsiva.Text);
            Params.Add(chklstFiltros.Items[2].Selected ? Convert.ToInt32(ddlUsuario.SelectedValue) : 0);
            Params.Add(Convert.ToInt32(ddlUbicacion.SelectedValue));
            Params.Add(Convert.ToInt32(ddlTipoArticulo.SelectedValue));
            gvwArticulos.DataSource = oblArticulo.BuscaArticuloFitrado(Params);
            gvwArticulos.PageIndex = e.NewPageIndex;
            gvwArticulos.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void ExportaExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (gvwArticulos.Rows.Count > 0)
            {
                if (this.gvwArticulos.PageCount > 1)
                {
                    ArrayList Params = new ArrayList();
                    //if (chklstFiltros.Items[0].Selected || chklstFiltros.Items[1].Selected || chklstFiltros.Items[2].Selected || chklstFiltros.Items[3].Selected)
                    //{
                    Params.Add(txtNoSerie.Text);
                    Params.Add(txtResponsiva.Text);

                    if (ddlUsuario.SelectedItem.Text.Trim() != "NO ASIGNADO" && ddlUsuario.SelectedItem.Text.Trim() != "")
                        Params.Add(Convert.ToInt32(ddlUsuario.SelectedValue));
                    else
                        Params.Add(0);

                    Params.Add(Convert.ToInt32(ddlUbicacion.SelectedValue));
                    Params.Add(Convert.ToInt32(ddlTipoArticulo.SelectedValue));

                    gvwArticulos.AllowPaging = false;
                    gvwArticulos.DataSource = oblArticulo.BuscaArticuloFitrado(Params);
                    gvwArticulos.DataBind();
                    //}
                }

                string rutaArchivo = this.gvwArticulos.ToExcel(Server.MapPath("~/Forms/Docs/Export/"), "Resultado_de_Articulos");
                Response.Redirect("~/Handlers/HandlerDescargaExcel.ashx?rutaArchivo=" + rutaArchivo + "&nombreArchivo=Resultado_de_Articulos.xlsx");
            }
            else
            {
                LabelInfo.Visible = true;
                LabelInfo.Text = "No hay elementos para exportar";
                Info.Visible = true;
            }
        }
    }
}