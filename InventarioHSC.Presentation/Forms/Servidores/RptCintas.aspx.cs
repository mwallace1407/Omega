using System;
using System.Web.UI;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Servidores
{
    public partial class RptCintas : System.Web.UI.Page
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
            //txtCinta.Enabled = false;
            btnProcesar.Enabled = false;
            //txtCinta.Text = "";

            if (TR_Id > 0)
            {
                ddlObj.DataValueField = "Valor";
                ddlObj.DataTextField = "Descripcion";
                ddlObj.DataSource = objSrv.BuscarObjetosRespaldo(TR_Id);
                ddlObj.DataBind();

                if (ddlObj.Items.Count > 0)
                {
                    ddlObj.Enabled = true;
                    //txtCinta.Enabled = true;
                    btnProcesar.Enabled = true;
                }
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            BLServidores objSrv = new BLServidores();
            int TR_Id = 0;
            int Obj_Id = 0;

            lblMsj.Text = "";
            txtCinta.Text = txtCinta.Text.Trim();

            int.TryParse(ddlFiltro.SelectedValue, out TR_Id);
            int.TryParse(ddlObj.SelectedValue, out Obj_Id);

            string Archivo = objSrv.ReporteCintas(TR_Id, Obj_Id, txtCinta.Text, Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos));

            if (Archivo.Length > 4 && Archivo.Substring(0, 5) != "Error")
            {
                Archivo = DatosGenerales.RutaReportesDinamicos + Archivo;
            }
            else
            {
                lblMsj.Text = Archivo;
            }

            if (Archivo != "")
                Response.Redirect(Archivo);
            else
                DatosGenerales.EnviaMensaje("No se encontraron resultados para su búsqueda.", "Exportar a Excel", DatosGenerales.TiposMensaje.Informacion);
        }
    }
}