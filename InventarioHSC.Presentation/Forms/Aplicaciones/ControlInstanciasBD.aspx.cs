using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class ControlInstanciasBD : System.Web.UI.Page
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
            objCatalogo.CatalogoBD(ref ddlTipoBD);
            ddlTipoBD.DataBind();
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
                int.TryParse(ddlTipoBD.SelectedValue, out BD_Id);

                if (Srv_Id > 0 && BD_Id > 0)
                    Resp = objGrupoSoftware.InsertarInstanciaBD(Srv_Id, BD_Id, txtNombre.Text.Trim());
                else
                    MsgBoxU.AddMessage("Se debe seleccionar un servidor y un tipo de base de datos", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                int IdMod = 0;

                int.TryParse(Resp, out IdMod);
                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "I", IdMod);

                if (IdMod > 0)
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Alta de instancias BD", DatosGenerales.TiposMensaje.Informacion);
                else
                    DatosGenerales.EnviaMensaje(Resp, "Alta de instancias BD", DatosGenerales.TiposMensaje.Error);
            }
        }
    }
}