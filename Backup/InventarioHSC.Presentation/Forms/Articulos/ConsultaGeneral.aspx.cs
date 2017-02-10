using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC
{
    public partial class ConsultaGeneral : System.Web.UI.Page
    {
        public BLReporteGeneral oblReporteGeneral = new BLReporteGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Warning.Visible = false;
                Info.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvwReporteGeneral.DataSource = oblReporteGeneral.ObtieneReporteGeneral();
            gvwReporteGeneral.DataBind();

        }

        //protected void gvwArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowIndex > -1)
        //        {
        //            if (e.Row.RowType == DataControlRowType.DataRow)
        //            {
        //                e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
        //                e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
        //                e.Row.Cells[0].ToolTip = "Editar";
        //                e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gvwArticulos','Editar$" + (e.Row.RowIndex).ToString().Trim() + "')");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LabelWarning.Visible = true;
        //        LabelWarning.Text = ex.Message;
        //        Warning.Visible = true;
        //    }

        //}

        //protected void gvwArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    Articulo objArticulo = new Articulo();

        //    if (e.CommandName == "Editar")
        //    {
        //        string sPagina = "~/Forms/Articulos/ConsultaArticulo.aspx?idItem=";
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        string s_idImte = gvwArticulos.DataKeys[index].Values["idItem"].ToString();
        //        string sURL = sPagina + s_idImte;
        //        Response.Redirect(sURL);
        //    }
        //}

        protected void gvwReporteGeneral_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ArrayList Params = new ArrayList();

            gvwReporteGeneral.DataSource = oblReporteGeneral.ObtieneReporteGeneral();
            gvwReporteGeneral.PageIndex = e.NewPageIndex;
            gvwReporteGeneral.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void ExportaExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (this.gvwReporteGeneral.PageCount > 1)
            {
                gvwReporteGeneral.AllowPaging = false;
                gvwReporteGeneral.DataSource = oblReporteGeneral.ObtieneReporteGeneral();
                gvwReporteGeneral.DataBind();
            }

            string rutaArchivo = this.gvwReporteGeneral.ToExcel(Server.MapPath("~/Forms/Docs/Export/"), "Resultado_de_Articulos");
            Response.Redirect("~/Handlers/HandlerDescargaExcel.ashx?rutaArchivo=" + rutaArchivo + "&nombreArchivo=Resultado_de_Articulos.xlsx");
        }
    }
}