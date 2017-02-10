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
    public partial class CatalogoMarca : System.Web.UI.Page
    {
        public BLMarca objMarca = new BLMarca();
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

        protected void gwvMarca_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvMarca','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
            }
        }

        protected void gwvMarca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string s_idItem = gwvMarca.DataKeys[index].Values["idMarca"].ToString();
                int countSucursal = 0;
                countSucursal = objMarca.EliminaMarca(Convert.ToInt32(s_idItem));
                   
                if (countSucursal == 0)
                {
                    string cleanMessage = "La Marca se eliminó correctamente.";
                    var sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('" + cleanMessage + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
                }
                else
                {
                    string cleanMessage = "Aun existen sucursales con esa Marca asignada, es necesario realizar la reasignación para poder eliminar";
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
            gwvMarca.DataSource = objMarca.ObtieneMarcaAll();
            gwvMarca.DataBind();
        }


        protected void fnLimpiaControlDetalle()
        {

        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {


        }

        protected void gwvMarca_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwvMarca.PageIndex = e.NewPageIndex;
            ActualizaGrid();
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            int idMarca = objMarca.InsertaMarca(0, txtDescripcion.Text.ToUpper(), "ACTIVO");
            txtDescripcion.Text = string.Empty;
            if (idMarca != 0)
            {
                CambiaEstadoNotificacion("Info", true, "La marca fue dada de alta correctamente.");
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                ActualizaGrid();
            }

        }
    }
}
