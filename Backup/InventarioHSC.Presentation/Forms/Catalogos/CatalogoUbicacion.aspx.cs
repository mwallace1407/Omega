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
    public partial class CatalogoUbicacion : System.Web.UI.Page
    {
        public BLUbicacion objUbicacion = new BLUbicacion();
        public BLCatalogos objCatalogo = new BLCatalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                CargaCatalogos();
                ActualizaGrid();
            }
        }

        protected void gwvUbicacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[0].ToolTip = "Eliminar Asignación";
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvUbicacion','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
            }
        }

        protected void gwvUbicacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string s_idItem = gwvUbicacion.DataKeys[index].Values["idUbicacion"].ToString();
                int countArtAsig = 0;
                countArtAsig = objUbicacion.EliminaUbicacion(Convert.ToInt32(s_idItem));

                if (countArtAsig == 0)
                {
                    string cleanMessage = "La Ubicación fué eliminada correctamente.";
                    var sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('" + cleanMessage + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                }
                else
                {
                    string cleanMessage = "La Ubicación que requiere eliminar aun tiene articulos asignados";
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
            gwvUbicacion.DataSource = objUbicacion.ObtieneUbicacionAll();
            gwvUbicacion.DataBind();
        }

        protected void CargaCatalogos()
        {
            objCatalogo.CargaRegion(ref ddlRegion);
            ddlRegion.DataBind();
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


        protected void gwvUbicacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwvUbicacion.PageIndex = e.NewPageIndex;
            ActualizaGrid();
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlRegion.SelectedValue == "0")
            {
                string cleanMessage = "Es necesario seleccionar una Región.";
                var sb = new System.Text.StringBuilder();
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('" + cleanMessage + "');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
            }
            else
            {
                int idUsuario = objUbicacion.InsertaUbicacion(0, txtDescripcion.Text, Convert.ToInt32(ddlRegion.SelectedValue), "ACTIVO");
                txtDescripcion.Text = string.Empty;
                
                if (idUsuario != 0)
                {
                    CambiaEstadoNotificacion("Info", true, "La ubicación fue dada de alta correctamente.");
                    CambiaEstadoNotificacion("Warning", false, string.Empty);
                    ActualizaGrid();
                }
            }
        }
    }
}
