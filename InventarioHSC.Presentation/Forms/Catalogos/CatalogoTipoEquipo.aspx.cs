using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;



namespace InventarioHSC
{
    public partial class CatalogoTipoEquipo : System.Web.UI.Page
    {
        public BLTipoEquipo objTipoEquipo = new BLTipoEquipo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                ActualizaGrid();
            }
        }

        protected void gwvTipoEquipo_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvTipoEquipo','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
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

        protected void gwvTipoEquipo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string s_idItem = gwvTipoEquipo.DataKeys[index].Values["idTipoEquipo"].ToString();
                int countArticulos = 0;
                countArticulos = objTipoEquipo.EliminaTipoEquipo(Convert.ToInt32(s_idItem));

                if (countArticulos == 0)
                {
                    string cleanMessage = "El Tipo de Equipo se eliminó correctamente.";
                    var sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('" + cleanMessage + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                }
                else
                {
                    string cleanMessage = "Aun existen Articulos con ese Tipo de Equipo asignado, es necesario realizar la reasignación para poder eliminar";
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
            gwvTipoEquipo.DataSource = objTipoEquipo.ObtieneTipoEquipoAll();
            gwvTipoEquipo.DataBind();
        }

        protected void fnLimpiaControlDetalle()
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void gwvTipoEquipo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwvTipoEquipo.PageIndex = e.NewPageIndex;
            ActualizaGrid();
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            int idRegion = objTipoEquipo.InsertaTipoEquipo(0, txtDescripcion.Text.ToUpper(), "ACTIVO");
            txtDescripcion.Text = string.Empty;

            if (idRegion != 0)
            {
                CambiaEstadoNotificacion("Info", true, "El Tipo de Equipo fue dado de alta correctamente.");
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                ActualizaGrid();
            }
        }
    }
}
