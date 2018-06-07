using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using Microsoft.Reporting.WebForms;

namespace InventarioHSC
{
    public partial class CatalogoPuesto : System.Web.UI.Page
    {
        public BLPuesto objPuesto = new BLPuesto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                ActualizaGrid();
            }
        }

        public void CambiaEstadoNotificacion(string TipoEtiqueta, bool Accion, string Mensaje)
        {
            if (TipoEtiqueta == "Warning")
            {
                Warning.Visible = Accion;
                LabelError.Visible = Accion;
                LabelError.Font.Size = 10;
                LabelError.Text = Mensaje;
            }
            else
            {
                Info.Visible = Accion;
                LabelInfo.Visible = Accion;
                LabelInfo.Font.Size = 10;
                LabelInfo.Text = Mensaje;
            }
        }

        protected void gwvPuesto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[0].ToolTip = "Eliminar";
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvPuesto','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
            }
        }

        protected void gwvPuesto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string s_idItem = gwvPuesto.DataKeys[index].Values["idPuesto"].ToString();
                int CountPuesto = 0;
                CountPuesto = objPuesto.EliminaPuesto(Convert.ToInt32(s_idItem));

                if (CountPuesto == 0)
                {
                    string cleanMessage = "El puesto fué agregado correctamente.";
                    var sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('" + cleanMessage + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                }
                else
                {
                    string cleanMessage = "Aun existen Usuarios con ese puesto asignado, es necesario realizar la reasignación para poder eliminar";
                    var sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('" + cleanMessage + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                }
            }

            ActualizaGrid();
        }

        protected void ActualizaGrid()
        {
            gwvPuesto.DataSource = objPuesto.ObtienePuestos();
            gwvPuesto.DataBind();
        }

        protected void fnLimpiaControlDetalle()
        {
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void gwvPuesto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwvPuesto.PageIndex = e.NewPageIndex;
            ActualizaGrid();
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            int idPuesto = objPuesto.InsertaPuesto(0, txtDescripcion.Text.ToUpper(), "ACTIVO");

            CambiaEstadoNotificacion("Info", true, "El puesto fue dado de alta correctamente.");
            CambiaEstadoNotificacion("Warning", false, string.Empty);
            ActualizaGrid();
        }
    }
}