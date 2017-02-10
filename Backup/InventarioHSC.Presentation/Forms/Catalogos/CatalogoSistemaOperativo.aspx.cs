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
    public partial class CatalogoSistemaOperativo : System.Web.UI.Page
    {
        public BLSistemaOperativo objSistema = new BLSistemaOperativo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                //ActualizaGrid();
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

        //protected void gwvSistemaOperativo_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowIndex > -1)
        //        {
        //            if (e.Row.RowType == DataControlRowType.DataRow)
        //            {
        //                e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
        //                e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
        //                e.Row.Cells[0].ToolTip = "Eliminar";
        //                e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvSistemaOperativo','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CambiaEstadoNotificacion("Info", false, string.Empty);
        //        CambiaEstadoNotificacion("Warning", true, "Error:" + ex.Message);
        //    }
        //}

        //protected void gwvSistemaOperativo_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
            
        //    if (e.CommandName == "Eliminar")
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        string s_idItem = gwvSistemaOperativo.DataKeys[index].Values["idSistema"].ToString();
        //        int countArtAsig = 0;
        //        countArtAsig  = objSistema.EliminaSistemaOperativo(Convert.ToInt32(s_idItem));

        //        if (countArtAsig == 0)
        //        {
        //            string cleanMessage = "El Sistema Operativo se eliminó correctamente.";
        //            var sb = new System.Text.StringBuilder();
        //            sb.Append(@"<script language='javascript'>");
        //            sb.Append(@"alert('" + cleanMessage + "');");
        //            sb.Append(@"</script>");
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
        //        }
        //        else
        //        {
        //            string cleanMessage = "Aun existen Articulos con ese Sistema Operativo asignado, es necesario realizar la reasignación para poder eliminar";
        //            var sb = new System.Text.StringBuilder();
        //            sb.Append(@"<script language='javascript'>");
        //            sb.Append(@"alert('" + cleanMessage + "');");
        //            sb.Append(@"</script>");
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", sb.ToString(), false);
        //        }

        //    }
        //    ActualizaGrid();
        //}


        //protected void ActualizaGrid()
        //{
        //    gwvSistemaOperativo.DataSource = objSistema.ObtieneSistemaAll();
        //    gwvSistemaOperativo.DataBind();
        //}

        protected void fnLimpiaControlDetalle()
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }


        //protected void gwvSistemaOperativo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gwvSistemaOperativo.PageIndex = e.NewPageIndex;
        //    ActualizaGrid();
        //}

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idSistema = objSistema.InsertaSistemaOperativo(0, txtDescripcion.Text.ToUpper(), txtVersion.Text.Trim(), chkEstatus.Checked);

            if (idSistema != 0)
            {
                MsgBox.AddMessage("El sistema operativo fue dado de alta correctamente.", YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                //ActualizaGrid();
            }
        }
    }
}
