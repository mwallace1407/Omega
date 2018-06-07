using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class AltaAplicaciones : System.Web.UI.Page
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
            objCatalogo.ListaEstadosApp(ref ddlEstado);
            ddlEstado.DataBind();
            objCatalogo.ListaTiposApp(ref ddlTipo);
            ddlTipo.DataBind();
            objCatalogo.ListaServidoresCompletaApp(ref ddlServidor);
            ddlServidor.DataBind();
            objCatalogo.ListaServidoresCompletaApp(ref ddlServidorP);
            ddlServidorP.DataBind();
        }

        protected void ddlServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCatalogo.ObtenerBDServidor(ref ddlBD, Convert.ToInt32(ddlServidor.SelectedValue));
            ddlBD.DataBind();

            if (ddlBD.Items.Count == 2)
                ddlBD.SelectedIndex = 1;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();
                string Resp = "";
                int AppSt_Id = 0;
                int AppT_Id = 0;
                int Srv_Id = 0;
                int AppBD_Id = 0;

                int.TryParse(ddlEstado.SelectedValue, out AppSt_Id);
                int.TryParse(ddlTipo.SelectedValue, out AppT_Id);
                int.TryParse(ddlServidorP.SelectedValue, out Srv_Id);
                int.TryParse(ddlBD.SelectedValue, out AppBD_Id);

                if (AppSt_Id > 0 && AppT_Id > 0 && AppBD_Id > 0)
                    Resp = objGrupoSoftware.InsertarAplicacion(AppSt_Id, AppT_Id, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), chkEnTFS.Checked, chkProductiva.Checked, txtObservaciones.Text.Trim(), txtUbicacion.Text.Trim(), Srv_Id, true, AppBD_Id, true);
                else
                    MsgBoxU.AddMessage("Faltan campos por seleccionar", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                int IdMod = 0;

                int.TryParse(Resp, out IdMod);
                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "I", IdMod);

                if (IdMod > 0)
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Alta de aplicación", DatosGenerales.TiposMensaje.Informacion);
                else
                    DatosGenerales.EnviaMensaje(Resp, "Alta de aplicación", DatosGenerales.TiposMensaje.Error);
            }
        }
    }
}