using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using Microsoft.Reporting.WebForms;

namespace InventarioHSC
{
    public partial class CatalogoProveedor : System.Web.UI.Page
    {
        public BLProveedores objProveedor = new BLProveedores();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                ActualizaGrid();
            }
        }

        protected void gwvProveedor_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvProveedor','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
            }
        }

        protected void gwvProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string s_idItem = gwvProveedor.DataKeys[index].Values["idProveedor"].ToString();
                int CountProveed = 0;

                CountProveed = objProveedor.EliminaProveedor(Convert.ToInt32(s_idItem));

                if (CountProveed == 0)
                {
                    string cleanMessage = "El proveedor se eliminó correctamente.";
                    var sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('" + cleanMessage + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                }
                else
                {
                    string cleanMessage = "Aun existen Articulos con ese proveedor asignado, es necesario realizar la reasignación para poder eliminar";
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
            gwvProveedor.DataSource = objProveedor.ObtieneProveedores();
            gwvProveedor.DataBind();
        }

        protected void fnLimpiaControlDetalle()
        {
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

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void gwvProveedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwvProveedor.PageIndex = e.NewPageIndex;
            ActualizaGrid();
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            int idProveedor = objProveedor.InsertaProveedor(0, txtDescripcion.Text.ToUpper(), "ACTIVO");
            txtDescripcion.Text = string.Empty;

            if (idProveedor != 0)
            {
                CambiaEstadoNotificacion("Info", true, "El proveedor fue dado de alta correctamente.");
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                ActualizaGrid();
            }
        }
    }
}