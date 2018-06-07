using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Software
{
    public partial class AltaSoftware : System.Web.UI.Page
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
                int SW_Id = 0;

                int.TryParse(ddlSoftware.SelectedValue, out SW_Id);

                try
                {
                    if (SW_Id > 0)
                    {
                        MsgBox.AddMessage(objSoftware.InsertaInventario(SW_Id, txtDescripcion.Text.Trim(), txtNoParte.Text.Trim(), txtLlave.Text.Trim(), txtUbicacion.Text.Trim(), txtObservaciones.Text.Trim()), YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                        ddlEmpresa.SelectedIndex = 0;
                        ddlGrupo.SelectedIndex = 0;
                        ddlGrupo.Enabled = false;
                        ddlSoftware.Items.Clear();
                        ddlSoftware.DataSource = null;
                        ddlSoftware.DataBind();
                        ddlSoftware.Enabled = false;
                        txtDescripcion.Text = "";
                        txtNoParte.Text = "";
                        txtUbicacion.Text = "";
                        txtLlave.Text = "";
                        txtObservaciones.Text = "";
                        ddlEmpresa.Focus();
                    }
                    else
                    {
                        MsgBox.AddMessage("Debe seleccionar un software de la lista", YaBu.MessageBox.uscMsgBox.enmMessageType.Error);
                    }
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

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmpresa.SelectedValue != "" && ddlEmpresa.SelectedValue != "0")
                ddlGrupo.Enabled = true;
            else
                ddlGrupo.Enabled = false;

            ddlGrupo.SelectedIndex = 0;
            ddlSoftware.Items.Clear();
            ddlSoftware.DataSource = null;
            ddlSoftware.DataBind();
            ddlSoftware.Enabled = false;
        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlGrupo.SelectedValue != "" && ddlGrupo.SelectedValue != "0")
                {
                    objCatalogo.CargaCatalogoSoftwareCombo(ref ddlSoftware, Convert.ToInt32(ddlEmpresa.SelectedValue), Convert.ToInt32(ddlGrupo.SelectedValue));
                    ddlSoftware.DataBind();

                    if (ddlSoftware.Items.Count > 1)
                    {
                        ddlSoftware.Enabled = true;
                    }
                    else
                    {
                        ddlSoftware.Items.Clear();
                        ddlSoftware.DataSource = null;
                        ddlSoftware.DataBind();
                        ddlSoftware.Enabled = false;
                        MsgBox.AddMessage("No se encontraron resultados para la empresa y grupo seleccionados", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    }
                }
                else
                {
                    ddlSoftware.Items.Clear();
                    ddlSoftware.DataSource = null;
                    ddlSoftware.DataBind();
                    ddlSoftware.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ddlSoftware.DataSource = null;
                ddlSoftware.DataBind();
                MsgBox.AddMessage("Error: " + ex.Message, YaBu.MessageBox.uscMsgBox.enmMessageType.Error);
            }
        }
    }
}