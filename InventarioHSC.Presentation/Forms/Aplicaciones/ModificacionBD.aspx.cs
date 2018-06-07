using System;
using System.Data;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class ModificacionBD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        #region Catalogos

        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            objCatalogo.ListaBDConServerInstancia(ref ddlBD);
            ddlBD.DataBind();
            objCatalogo.ListaServidoresCompletaApp(ref ddlServidor);
            ddlServidor.DataBind();
        }

        protected void CargaInstancias()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            objCatalogo.ObtenerInstanciaBD(ref ddlInstanciaBD, Convert.ToInt32(ddlServidor.SelectedValue));
            ddlInstanciaBD.DataBind();

            if (ddlInstanciaBD.Items.Count == 2)
                ddlInstanciaBD.SelectedIndex = 1;
        }

        protected void ddlServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaInstancias();
        }

        #endregion Catalogos

        protected void ddlBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLSoftware sw = new BLSoftware();
            int AppBD_Id = 0;

            int.TryParse(ddlBD.SelectedItem.Value, out AppBD_Id);
            txtNombre.Text = "";
            chkActiva.Checked = false;
            chkProductiva.Checked = false;
            pnlURespaldo.Visible = false;

            if (AppBD_Id > 0)
            {
                DataTable Info = new DataTable();

                pnlContent.Enabled = true;
                sw.InformacionGeneralBD(AppBD_Id, ref Info);

                if (Info.Rows.Count > 0)
                {
                    if (Info.Columns.Contains("Srv_Id")) { ddlServidor.SelectedValue = Info.Rows[0]["Srv_Id"].ToString(); }

                    CargaInstancias();

                    if (Info.Columns.Contains("AppSB_Id")) { ddlInstanciaBD.SelectedValue = Info.Rows[0]["AppSB_Id"].ToString(); }

                    if (Info.Columns.Contains("AppBD_Nombre")) { txtNombre.Text = Info.Rows[0]["AppBD_Nombre"].ToString(); }

                    if (Info.Columns.Contains("AppBD_Activa")) { if (Info.Rows[0]["AppBD_Activa"].ToString() == "S") { chkActiva.Checked = true; } else { chkActiva.Checked = false; } }

                    if (Info.Columns.Contains("AppBD_Productiva")) { if (Info.Rows[0]["AppBD_Productiva"].ToString() == "S") { chkProductiva.Checked = true; } else { chkProductiva.Checked = false; } }

                    if (Info.Columns.Contains("AppBD_FechaBaja"))
                    {
                        if (!chkActiva.Checked)
                            pnlBaja.Visible = true;
                        else
                            pnlBaja.Visible = false;

                        if (Info.Rows[0]["AppBD_FechaBaja"].ToString() != "01/01/1900")
                            txtFechaBaja.Text = Info.Rows[0]["AppBD_FechaBaja"].ToString();
                    }

                    pnlBaja.Visible = !chkActiva.Checked;

                    grdCintas.DataSource = sw.ObtenerUltimaCinta((int)DatosGenerales.TiposRespaldoCintas.Base_Datos, AppBD_Id);
                    grdCintas.DataBind();
                    pnlURespaldo.Visible = true;
                }
            }
            else
            {
                pnlContent.Enabled = false;

                if (ddlServidor.Items.Count > 0) { ddlServidor.SelectedIndex = 0; }
                if (ddlInstanciaBD.Items.Count > 0) { ddlInstanciaBD.SelectedIndex = 0; }
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();
                BLServidores objGrupoServidores = new BLServidores();
                int AppBD_Id = 0;
                int AppSB_Id = 0;
                DateTime? AppBD_FechaBaja;

                int.TryParse(ddlBD.SelectedValue, out AppBD_Id);
                int.TryParse(ddlInstanciaBD.SelectedValue, out AppSB_Id);
                txtNombre.Text = txtNombre.Text.Trim();
                txtCinta.Text = txtCinta.Text.Trim();
                txtObservacionesCinta.Text = txtObservacionesCinta.Text.Trim();

                AppBD_FechaBaja = DatosGenerales.ConvierteFecha(txtFechaBaja.Text);

                if (txtFechaBaja.Text != "" && AppBD_FechaBaja == null)
                {
                    MsgBoxU.AddMessage("Formato de fecha incorrecto", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    return;
                }

                if (txtNombre.Text != "" && AppBD_Id > 0 && AppSB_Id > 0)
                    objGrupoSoftware.ActualizarBD(AppBD_Id, AppSB_Id, txtNombre.Text, chkActiva.Checked, chkProductiva.Checked, AppBD_FechaBaja);
                else
                    MsgBoxU.AddMessage("Se debe seleccionar un servidor, una instancia y un nombre", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                if (txtCinta.Text != "" && pnlCinta.Visible == true)
                    objGrupoServidores.RegistrarCinta(DatosGenerales.TiposRespaldoCintas.Base_Datos, AppBD_Id, txtCinta.Text, txtObservacionesCinta.Text, DateTime.Now);

                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "U", AppSB_Id);

                DatosGenerales.EnviaMensaje("Proceso finalizado", "Modificación de BD", DatosGenerales.TiposMensaje.Informacion);
            }
        }

        protected void btnAgregarCinta_Click(object sender, EventArgs e)
        {
            btnAgregarCinta.Visible = false;
            pnlCinta.Visible = true;
        }

        protected void chkActiva_CheckedChanged(object sender, EventArgs e)
        {
            pnlBaja.Visible = !chkActiva.Checked;
        }
    }
}