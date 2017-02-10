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
    public partial class CatalogoUsuario : System.Web.UI.Page
    {
        public BLUsuario objUsuario = new BLUsuario();
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

        protected void gwvUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvUsuario','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
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

        protected void gwvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string s_idItem = gwvUsuario.DataKeys[index].Values["idUsuario"].ToString();
                int countArtAsig = 0;
                countArtAsig  = objUsuario.EliminaUsuario(Convert.ToInt32(s_idItem));

                if (countArtAsig == 0)
                {
                    string cleanMessage = "El Usuario fué eliminado correctamente.";
                    var sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('" + cleanMessage + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                }
                else
                {
                    string cleanMessage = "El usuario que requiere eliminar aun tiene articulos asignados";
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
            gwvUsuario.DataSource = objUsuario.ObtieneUsuarioAll();
            gwvUsuario.DataBind();
        }

        protected void CargaCatalogos()
        {
            objCatalogo.CargaPuesto(ref ddlPuesto);
            ddlPuesto.DataBind();
        }

        protected void fnLimpiaControlDetalle()
        {
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }


        protected void gwvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwvUsuario.PageIndex = e.NewPageIndex;
            ActualizaGrid();
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlPuesto.SelectedValue == "0")
            {
                string cleanMessage = "Es necesario seleccionar un puesto.";
                var sb = new System.Text.StringBuilder();
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('" + cleanMessage + "');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
            }
            else
            {
                int idUsuario = objUsuario.InsertaUsuario(0, txtDescripcion.Text, Convert.ToInt32(ddlPuesto.SelectedValue), "ACTIVO");
                txtDescripcion.Text = string.Empty;
                if (idUsuario != 0)
                {
                    //string cleanMessage = "El Usuario se agregó correctamente.";
                    //var sb = new System.Text.StringBuilder();
                    //sb.Append(@"<script language='javascript'>");
                    //sb.Append(@"alert('" + cleanMessage + "');");
                    //sb.Append(@"</script>");
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                    CambiaEstadoNotificacion("Info", true, "El usuario fue dado de alta correctamente.");
                    CambiaEstadoNotificacion("Warning", false, string.Empty);
                    ActualizaGrid();
                }
            }
        }
    }
}
