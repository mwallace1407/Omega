using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptRemuneracionEconomica : System.Web.UI.Page
    {
        protected const int CeldaRuta = 2;
        protected const int CeldaNombre = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnProcesar.Visible = false;
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            grdDatos.DataSource = Fijos();
            grdDatos.DataBind();

            objCatalogo.CatalogoEmpleadosCHK(ref chkEmpleados);
            chkEmpleados.DataBind();

            if (chkEmpleados.Items.Count > 0)
                chkEmpleados.SelectedIndex = 0;
        }

        protected System.Data.DataTable Fijos()
        {
            System.Data.DataTable Res = new System.Data.DataTable();

            Res.Columns.Add("Emp");
            Res.Columns.Add("Ruta");

            string[] Archivos = System.IO.Directory.GetFiles(Server.MapPath("Fijos"), "RemuneracionEconomica_*.xlsx");
            System.Data.DataRow dr;

            foreach (string a in Archivos)
            {
                dr = Res.NewRow();
                dr[0] = System.IO.Path.GetFileNameWithoutExtension(a).Replace("RemuneracionEconomica_", "");
                dr[1] = DatosGenerales.RutaReportesFijos + System.IO.Path.GetFileName(a);

                Res.Rows.Add(dr);
            }

            return Res;
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[CeldaNombre].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";
            }
        }

        protected void grdDatosF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[CeldaNombre].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";
            }
        }

        protected string ArmadoCadena(CheckBoxList chkl)
        {
            string Resultados = "";

            if (chkl.Items.Count > 0 && chkl.Items[0].Value == "0" && chkl.Items[0].Selected)
                return "";

            for (int w = 0; w < chkl.Items.Count; w++)
            {
                if (chkl.Items[w].Selected)
                {
                    Resultados += chkl.Items[w].Value + "|";
                }
            }

            return Resultados;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //BLReportes rep = new BLReportes();

            //grdDatosF.DataSource = rep.RemuneracionEconomica(ArmadoCadena(chkEmpleados),
            //                                                 Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
            //grdDatosF.DataBind();
            WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

            exportar.RemuneracionEconomica((int)DatosGenerales.TiposDocumentos.Reporte_RemuneracionEconomica, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSRemEco_", "xlsx"), 250000,
                                           ArmadoCadena(chkEmpleados));

            Response.Redirect("DocumentosUsuario.aspx");

            //btnProcesar.Enabled = true;
            //LimpiarControles(false);
        }

        protected void LimpiarControles(bool LimpiarRes = true)
        {
            chkEmpleados.ClearSelection();
            chkEmpleados.Items[0].Selected = true;

            if (LimpiarRes)
            {
                grdDatosF.DataSource = null;
                grdDatosF.DataBind();
            }
        }

        protected void rbAnual_CheckedChanged(object sender, EventArgs e)
        {
            pnlAnual.Visible = true;
            pnlFiltros.Visible = false;
            btnProcesar.Visible = false;
            btnProcesar.Enabled = false;
            LimpiarControles();
        }

        protected void rbFiltros_CheckedChanged(object sender, EventArgs e)
        {
            pnlAnual.Visible = false;
            pnlFiltros.Visible = true;
            btnProcesar.Visible = true;
            btnProcesar.Enabled = true;
            LimpiarControles();
        }

        protected void chkEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (chkEmpleados.Items[index].Selected)
                value = chkEmpleados.Items[index].Value;

            if (value == "0")
            {
                chkEmpleados.ClearSelection();
                chkEmpleados.Items[0].Selected = true;
            }
            else
            {
                int selectedCount = chkEmpleados.Items.Cast<ListItem>().Count(li => li.Selected);

                if (selectedCount > 0)
                    chkEmpleados.Items[0].Selected = false;
                else
                    chkEmpleados.Items[0].Selected = true;
            }
        }
    }
}