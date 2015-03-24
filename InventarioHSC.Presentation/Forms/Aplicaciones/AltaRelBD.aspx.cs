using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class AltaRelBD : System.Web.UI.Page
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
            if (ddlAplicacion.SelectedValue != "0")
            {
                objCatalogo.ListaServidoresCompletaApp(ref ddlServidor);
                ddlServidor.DataBind();
                ddlBD.DataSource = null;
                ddlBD.DataBind();
            }
            else
            {
                ddlServidor.DataSource = null;
                ddlServidor.DataBind();
                ddlBD.DataSource = null;
                ddlBD.DataBind();
            }
        }

        protected void ddlServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlServidor.SelectedValue != "0")
            {
                objCatalogo.ListaBDPorServidorApp(ref ddlBD, Convert.ToInt32(ddlServidor.SelectedValue), Convert.ToInt32(ddlAplicacion.SelectedValue));
                ddlBD.DataBind();

                if (ddlBD.Items.Count == 2)
                    ddlBD.SelectedIndex = 1;
            }
            else
            {
                ddlBD.DataSource = null;
                ddlBD.DataBind();
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLSoftware objGrupoSoftware = new BLSoftware();
                string Resp = "";
                int App_Id = 0;
                int BD_Id = 0;

                int.TryParse(ddlAplicacion.SelectedValue, out App_Id);
                int.TryParse(ddlBD.SelectedValue, out BD_Id);

                if (App_Id > 0 && BD_Id > 0)
                    Resp = objGrupoSoftware.InsertarAppRelBD(App_Id, BD_Id, chkPropietaria.Checked);
                else
                    MsgBoxU.AddMessage("Se debe seleccionar una aplicación y una base de datos", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "I", App_Id, BD_Id);

                if (Resp == "")
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Alta de Relacion Aplicación-BD", DatosGenerales.TiposMensaje.Informacion);
                else
                    DatosGenerales.EnviaMensaje(Resp, "Alta de Relacion Aplicación-BD", DatosGenerales.TiposMensaje.Error);
            }
        }
    }
}