using System;
using System.Web.UI;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Servidores
{
    public partial class MonitoreoRemotoSW : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtEquipo.Focus();
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            lblMsj.Text = "";
            pnlMsj.Visible = false;

            if (!chkRevisarTodos.Checked && string.IsNullOrWhiteSpace(txtEquipo.Text))
            {
                lblMsj.Text = "Debe especificar un nombre de equipo.";
                pnlMsj.Visible = true;
                txtEquipo.Focus();
                return;
            }

            string Pass = "";
            De_CryptDLL.De_Crypt cripto = new De_CryptDLL.De_Crypt();
            WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

            Pass = cripto.Encriptar(txtPass.Text, DatosGenerales.StandardKey, true);

            exportar.MonitoreoSW((int)DatosGenerales.TiposDocumentos.Reporte_MonitoreoSW, Session["UserNameLogin"].ToString(), Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSMonSW_", "xlsx"), 250000,
                             txtUsuario.Text,
                             Pass,
                             txtDominio.Text,
                             chkRevisarTodos.Checked,
                             txtEquipo.Text);

            Response.Redirect("../Reportes/DocumentosUsuario.aspx");
        }

        #endregion Eventos
    }
}