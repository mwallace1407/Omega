using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class AltaBD : System.Web.UI.Page
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
            objCatalogo.ListaServidoresApp(ref ddlServidor);
            ddlServidor.DataBind();
        }

        protected void ddlServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCatalogo.ObtenerInstanciaBD(ref ddlInstanciaBD, Convert.ToInt32(ddlServidor.SelectedValue));
            ddlInstanciaBD.DataBind();

            if (ddlInstanciaBD.Items.Count == 2)
                ddlInstanciaBD.SelectedIndex = 1;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();
                string Resp = "";
                int Srv_Id = 0;
                int BD_Id = 0;

                int.TryParse(ddlServidor.SelectedValue, out Srv_Id);
                int.TryParse(ddlInstanciaBD.SelectedValue, out BD_Id);

                if (Srv_Id > 0 && BD_Id > 0)
                    Resp = objGrupoSoftware.InsertarBDServidor(BD_Id, txtNombre.Text.Trim(), chkActiva.Checked, chkProductiva.Checked);
                else
                    MsgBoxU.AddMessage("Se debe seleccionar un servidor y una instancia de base de datos", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                int IdMod = 0;

                int.TryParse(Resp, out IdMod);
                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "I", IdMod);

                if (IdMod > 0)
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Alta de BD", DatosGenerales.TiposMensaje.Informacion);
                else
                    DatosGenerales.EnviaMensaje(Resp, "Alta de BD", DatosGenerales.TiposMensaje.Error);
            }
        }
    }
}