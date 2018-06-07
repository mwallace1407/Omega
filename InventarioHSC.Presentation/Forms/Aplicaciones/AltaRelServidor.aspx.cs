using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class AltaRelServidor : System.Web.UI.Page
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
            objCatalogo.ListaAppConServer(ref ddlAplicacion);
            ddlAplicacion.DataBind();
        }

        protected void ddlAplicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCatalogo.ListaServidoresExclusionApp(ref ddlServidorR, Convert.ToInt32(ddlAplicacion.SelectedValue));
            ddlServidorR.DataBind();

            if (ddlServidorR.Items.Count == 2)
                ddlServidorR.SelectedIndex = 1;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();
                string Resp = "";
                int App_Id = 0;
                int Srv_Id = 0;

                int.TryParse(ddlAplicacion.SelectedValue, out App_Id);
                int.TryParse(ddlServidorR.SelectedValue, out Srv_Id);

                if (App_Id > 0 && Srv_Id > 0)
                    Resp = objGrupoSoftware.InsertarAppRelServer(App_Id, Srv_Id, chkPropietaria.Checked);
                else
                    MsgBoxU.AddMessage("Se debe seleccionar una aplicación y un servidor", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "I", App_Id, Srv_Id);

                if (Resp == "")
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Alta de Relacion Aplicación-Servidor", DatosGenerales.TiposMensaje.Informacion);
                else
                    DatosGenerales.EnviaMensaje(Resp, "Alta de Relacion Aplicación-Servidor", DatosGenerales.TiposMensaje.Error);
            }
        }
    }
}