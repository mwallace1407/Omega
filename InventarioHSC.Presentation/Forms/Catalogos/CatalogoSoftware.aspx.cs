using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Catalogos
{
    public partial class CatalogoSoftware : System.Web.UI.Page
    {
        public BLSoftware objSoftware = new BLSoftware();
        public BLCatalogos objCatalogo = new BLCatalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCatalogos();
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
                MsgBox.AddMessage("Error: " + ex.Message, YaBu.MessageBox.uscMsgBox.enmMessageType.Error);
            }
        }

        protected void CargaCatalogos()
        {
            objCatalogo.CargaEmpresasSoftware(ref ddlEmpresa);
            ddlEmpresa.DataBind();
            objCatalogo.CargaGruposSoftware(ref ddlGrupo, false);
            ddlGrupo.DataBind();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    MsgBox.AddMessage(objSoftware.InsertaCatalogo(Convert.ToInt32(ddlEmpresa.SelectedValue), Convert.ToInt32(ddlGrupo.SelectedValue), txtDescripcion.Text.Trim(), txtVersion.Text.Trim()), YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                    ddlEmpresa.SelectedIndex = 0;
                    ddlGrupo.SelectedIndex = 0;
                    txtDescripcion.Text = "";
                    txtVersion.Text = "";
                    ddlEmpresa.Focus();
                }
                catch (Exception ex)
                {
                    MsgBox.AddMessage("Error: " + ex.Message, YaBu.MessageBox.uscMsgBox.enmMessageType.Error);
                }
            }
            else
            {
                MsgBox.AddMessage("Hay campos pendientes por llenar", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }
    }
}