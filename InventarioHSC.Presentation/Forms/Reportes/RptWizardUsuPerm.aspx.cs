using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptWizardUsuPerm : System.Web.UI.Page
    {
        #region Variables

        public BLReportes objRpt = new BLReportes();
        protected const int CeldaId = 0;
        protected const int CeldaAutorizado = 1;
        protected const int CeldaConexion = 2;
        protected const int CeldaReporte = 3;
        private System.Data.DataTable Resultados = new System.Data.DataTable();

        #endregion Variables

        #region Metodos

        protected void CrearJS()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type='text/javascript'>");
            /**********Busca***********/
            sb.Append("function Busca() {");
            sb.Append("var accHost = $get('" + acc01.ClientID + "').AccordionBehavior;");
            sb.Append("accHost.set_SelectedIndex(1);");
            sb.Append("}");
            sb.Append("function catchEnter(e) {");
            sb.Append("var key;");
            sb.Append("if(window.event) {");
            sb.Append("    key = window.event.keyCode; }");
            sb.Append("else {");
            sb.Append("    key = e.which; }");
            sb.Append("if (key == 13) {");
            sb.Append("    Busca(); }");
            sb.Append("}");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "Permisos", sb.ToString());
            btnBuscar.Attributes.Add("onmousedown", "Busca();");
            txtUsuario.Attributes.Add("onkeypress", "catchEnter(event);");
        }

        #endregion Metodos

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            CrearJS();

            if (!Page.IsPostBack)
            {
                if (Session.Count == 0)
                    Response.Redirect("~/Default.aspx");

                txtUsuario.Focus();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            btnNueva.Enabled = false;
            btnProcesar.Enabled = false;
            cboUsuarios.DataSource = null;
            cboUsuarios.DataBind();
            grdDatos.DataSource = null;
            grdDatos.DataBind();

            if (txtUsuario.Text.Trim() == "")
            {
                cboUsuarios.Visible = false;
                lblMensaje.Text = "Debe ingresar un valor en la caja de texto";
                return;
            }

            if (txtUsuario.Text.Trim().Length < 3)
            {
                cboUsuarios.Visible = false;
                lblMensaje.Text = "Debe ingresar por lo menos tres caracteres para la búsqueda";
                return;
            }

            objRpt.BuscarUsuarioPermisos(ref cboUsuarios, txtUsuario.Text.Trim());
            cboUsuarios.DataBind();

            if (cboUsuarios.Items.Count <= 1)
            {
                cboUsuarios.Visible = false;
                lblMensaje.Text = "No se encontraron usuarios que coincidan con el texto '" + txtUsuario.Text + "'";
                btnNueva.Enabled = true;
            }
            else
            {
                cboUsuarios.Visible = true;
                lblMensaje.Text = "";
            }
        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("RptWizardUsuPerm.aspx", false);
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                string Usuario = "";
                int RD_Id = 0;
                string Res = "";
                string chkVal = "";

                Usuario = cboUsuarios.SelectedValue;

                if (Usuario != "" && grdDatos.Rows.Count > 0)
                {
                    for (int w = 0; w < grdDatos.Rows.Count; w++)
                    {
                        CheckBox chkAutorizado = (CheckBox)grdDatos.Rows[w].FindControl("chkAutorizado");

                        if (chkAutorizado.Checked)
                            chkVal = "1";
                        else
                            chkVal = "0";

                        if (chkVal != grdDatos.Rows[w].Cells[CeldaAutorizado].Text)
                        {
                            int.TryParse(grdDatos.Rows[w].Cells[CeldaId].Text, out RD_Id);
                            Resultados = new System.Data.DataTable();
                            Resultados = objRpt.ActualizaPermisosUsuario(Usuario, RD_Id, chkAutorizado.Checked);

                            if (Resultados.TableName == "Error" && Resultados.Rows.Count > 0)
                                Res += Resultados.Rows[0][0].ToString() + "<br />";
                        }
                    }

                    if (Res == "")
                        Model.DatosGenerales.EnviaMensaje("Se han aplicado los cambios en los permisos", "Operación satisfactoria", Model.DatosGenerales.TiposMensaje.Informacion);
                    else
                        Model.DatosGenerales.EnviaMensaje(Res, "Error al aplicar cambios", Model.DatosGenerales.TiposMensaje.Error);
                }
                else
                {
                    Model.DatosGenerales.EnviaMensaje("No hay datos suficientes para procesar los permisos", "Datos insuficientes", Model.DatosGenerales.TiposMensaje.Advertencia);
                }
            }
            catch (Exception ex)
            {
                Model.DatosGenerales.EnviaMensaje(ex.Message, "Ha ocurrido un error al aplicar los permisos", Model.DatosGenerales.TiposMensaje.Error);
            }
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkAutorizado");

                if (e.Row.Cells[CeldaAutorizado].Text == "S")
                    chk.Checked = true;
            }
        }

        protected void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pnlDatos.Visible = false;
                btnProcesar.Enabled = false;

                if (cboUsuarios.SelectedItem.Text != "")
                {
                    grdDatos.DataSource = objRpt.LeePermisosUsuario(cboUsuarios.SelectedValue);
                    grdDatos.DataBind();

                    cboUsuarios.Visible = false;
                    grdDatos.Columns[CeldaId].Visible = false;
                    grdDatos.Columns[CeldaAutorizado].Visible = false;
                    btnNueva.Enabled = true;
                    btnProcesar.Enabled = true;
                    pnlDatos.Visible = true;
                }
                else
                {
                    grdDatos.DataSource = null;
                    grdDatos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Model.DatosGenerales.EnviaMensaje(ex.Message, "Ha ocurrido un error al seleccionar el usuario", Model.DatosGenerales.TiposMensaje.Error);
            }
        }

        #endregion Eventos
    }
}