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
    public partial class ModificarInstancia : System.Web.UI.Page
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

            objCatalogo.ListaInstanciasBD(ref ddlInstancia);
            ddlInstancia.DataBind();
            objCatalogo.ListaServidoresCompletaApp(ref ddlServidor);
            ddlServidor.DataBind();
            objCatalogo.CatalogoBD(ref ddlBD);
            ddlBD.DataBind();
        }
        #endregion Catalogos

        protected void ddlInstancia_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLSoftware sw = new BLSoftware();
            int AppSB_Id = 0;

            int.TryParse(ddlInstancia.SelectedItem.Value, out AppSB_Id);
            txtNombre.Text = "";

            if (AppSB_Id > 0)
            {
                DataTable Info = new DataTable();

                pnlContent.Enabled = true;
                sw.InformacionGeneralInstancia(AppSB_Id, ref Info);

                if (Info.Rows.Count > 0)
                {
                    if (Info.Columns.Contains("Srv_Id")) { ddlServidor.SelectedValue = Info.Rows[0]["Srv_Id"].ToString(); }
                    if (Info.Columns.Contains("BD_Id")) { ddlBD.SelectedValue = Info.Rows[0]["BD_Id"].ToString(); }

                    if (Info.Columns.Contains("AppSB_Nombre")) { txtNombre.Text = Info.Rows[0]["AppSB_Nombre"].ToString(); }
                }
            }
            else
            {
                pnlContent.Enabled = false;

                if (ddlServidor.Items.Count > 0) { ddlServidor.SelectedIndex = 0; }
                if (ddlBD.Items.Count > 0) { ddlBD.SelectedIndex = 0; }
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();
                int AppSB_Id = 0;
                int Srv_Id = 0;
                int BD_Id = 0;

                int.TryParse(ddlInstancia.SelectedValue, out AppSB_Id);
                int.TryParse(ddlServidor.SelectedValue, out Srv_Id);
                int.TryParse(ddlBD.SelectedValue, out BD_Id);

                if (Srv_Id > 0 && BD_Id > 0 && AppSB_Id > 0)
                    objGrupoSoftware.ActualizarInstanciaBD(AppSB_Id, Srv_Id, BD_Id, txtNombre.Text.Trim());
                else
                    MsgBoxU.AddMessage("Se debe seleccionar un servidor y un tipo de base de datos", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "U", AppSB_Id);

                DatosGenerales.EnviaMensaje("Proceso finalizado", "Modificación de instancia BD", DatosGenerales.TiposMensaje.Informacion);
                
            }
        }
    }
}