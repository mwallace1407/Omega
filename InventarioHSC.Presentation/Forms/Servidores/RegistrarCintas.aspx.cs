using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Servidores
{
    public partial class RegistrarCintas : System.Web.UI.Page
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
            objCatalogo.ListaTiposRespaldo(ref ddlFiltro);
            ddlFiltro.DataBind();
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            BLServidores objSrv = new BLServidores();
            int TR_Id = 0;
            int Obj_Id = 0;

            lblMsj.Visible = false;
            txtCinta.Text = txtCinta.Text.Trim();
            DateTime Fecha = ObtieneFecha(txtFechaRespaldo.Text);

            if (Page.IsValid && txtCinta.Text != "" && Fecha.ToString("ddMMyyyy") != "01011900")
            {
                int.TryParse(ddlFiltro.SelectedValue, out TR_Id);
                int.TryParse(ddlObj.SelectedValue, out Obj_Id);

                objSrv.RegistrarCinta(TR_Id, Obj_Id, txtCinta.Text, txtObservacionesCinta.Text.Trim(), Fecha);
                DatosGenerales.EnviaMensaje("Proceso finalizado", "Alta de respaldos en cinta", DatosGenerales.TiposMensaje.Informacion);
            }
            else
            {
                lblMsj.Visible = true;
            }
        }

        protected DateTime ObtieneFecha(string Fecha)
        {
            DateTime f;

            if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out f))
                return f;
            else
                return new DateTime(1900, 1, 1);
        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLServidores objSrv = new BLServidores();
            int TR_Id = 0;

            if (ddlObj.Items.Count > 0)
                ddlObj.SelectedIndex = -1;

            int.TryParse(ddlFiltro.SelectedValue, out TR_Id);
            ddlObj.DataSource = null;
            ddlObj.DataBind();
            ddlObj.Enabled = false;
            txtCinta.Enabled = false;
            txtObservacionesCinta.Enabled = false;
            btnProcesar.Enabled = false;
            txtCinta.Text = "";
            txtObservacionesCinta.Text = "";
            txtFechaRespaldo.Text = "";

            if (TR_Id > 0)
            {
                ddlObj.DataValueField = "Valor";
                ddlObj.DataTextField = "Descripcion";
                ddlObj.DataSource = objSrv.BuscarObjetosRespaldo(TR_Id);
                ddlObj.DataBind();

                if (ddlObj.Items.Count > 0)
                {
                    ddlObj.Enabled = true;
                    txtCinta.Enabled = true;
                    btnProcesar.Enabled = true;
                    txtObservacionesCinta.Enabled = true;
                    txtFechaRespaldo.Enabled = true;
                    txtFechaRespaldo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        }
    }
}