using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;
using System.Data;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class ModificarAplicacion : System.Web.UI.Page
    {
        public BLCatalogos objCatalogo = new BLCatalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            objCatalogo.ListaAppConServer(ref ddlApp);
            ddlApp.DataBind();
            objCatalogo.ListaEstadosApp(ref ddlEstado);
            ddlEstado.DataBind();
            objCatalogo.ListaTiposApp(ref ddlTipo);
            ddlTipo.DataBind();

        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();
                int AppSt_Id = 0;
                int AppT_Id = 0;
                int App_Id = 0;

                int.TryParse(ddlEstado.SelectedValue, out AppSt_Id);
                int.TryParse(ddlTipo.SelectedValue, out AppT_Id);
                int.TryParse(ddlApp.SelectedValue, out App_Id);

                if (AppSt_Id > 0 && AppT_Id > 0 && App_Id > 0)
                    objGrupoSoftware.ActualizarApp(App_Id, AppSt_Id, AppT_Id, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), chkEnTFS.Checked, chkProductiva.Checked, txtObservaciones.Text.Trim(), txtUbicacion.Text.Trim());
                else
                    MsgBoxU.AddMessage("Faltan campos por seleccionar", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "U", App_Id);

                DatosGenerales.EnviaMensaje("Proceso finalizado", "Modificación de aplicación", DatosGenerales.TiposMensaje.Informacion);
            }
        }

        protected void ddlApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLSoftware sw = new BLSoftware();
            int App_Id = 0;

            int.TryParse(ddlApp.SelectedItem.Value, out App_Id);
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtObservaciones.Text = "";
            txtUbicacion.Text = "";
            chkEnTFS.Checked = false;
            chkProductiva.Checked = false;

            if (App_Id > 0)
            {
                DataTable Info = new DataTable();

                pnlContent.Enabled = true;
                sw.InformacionGeneralApp(App_Id, ref Info);

                if (Info.Rows.Count > 0)
                {
                    if (Info.Columns.Contains("AppSt_Id")) { ddlEstado.SelectedValue = Info.Rows[0]["AppSt_Id"].ToString(); }
                    if (Info.Columns.Contains("AppT_Id")) { ddlTipo.SelectedValue = Info.Rows[0]["AppT_Id"].ToString(); }

                    if (Info.Columns.Contains("App_Descripcion")) { txtDescripcion.Text = Info.Rows[0]["App_Descripcion"].ToString(); }
                    if (Info.Columns.Contains("App_Nombre")) { txtNombre.Text = Info.Rows[0]["App_Nombre"].ToString(); }
                    if (Info.Columns.Contains("App_Observaciones")) { txtObservaciones.Text = Info.Rows[0]["App_Observaciones"].ToString(); }
                    if (Info.Columns.Contains("App_Ubicacion")) { txtUbicacion.Text = Info.Rows[0]["App_Ubicacion"].ToString(); }

                    if (Info.Columns.Contains("App_EnTFS")) { if (Info.Rows[0]["App_EnTFS"].ToString() == "S") { chkEnTFS.Checked = true; } else { chkEnTFS.Checked = false; } }
                    if (Info.Columns.Contains("App_Productiva")) { if (Info.Rows[0]["App_Productiva"].ToString() == "S") { chkProductiva.Checked = true; } else { chkProductiva.Checked = false; } }
                }
            }
            else
            {
                pnlContent.Enabled = false;

                if (ddlEstado.Items.Count > 0) { ddlEstado.SelectedIndex = 0; }
                if (ddlTipo.Items.Count > 0) { ddlTipo.SelectedIndex = 0; }
            }

        }
    }
}