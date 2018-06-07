using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptPolizasAbanks : System.Web.UI.Page
    {
        protected const int CeldaRuta = 2;
        protected const int CeldaNombre = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");

            if (!Page.IsPostBack)
            {
                btnProcesar.Visible = false;
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();
            BLDatosGenerales objGen = new BLDatosGenerales();
            int AnnoMin = 0;
            int AnnoMax = 0;

            grdDatos.DataSource = Fijos();
            grdDatos.DataBind();

            objCatalogo.ObtenerMonedasAbanks(ref ddlMoneda);
            ddlMoneda.DataBind();

            hddAnnoMin.Value = objGen.ObtenerParametroSistema("PolizaAnnoMin");
            hddAnnoMax.Value = objGen.ObtenerParametroSistema("PolizaAnnoMax");

            int.TryParse(hddAnnoMin.Value, out AnnoMin);
            int.TryParse(hddAnnoMax.Value, out AnnoMax);

            if (AnnoMin <= 0 || AnnoMax <= 0 || AnnoMax <= AnnoMin)
            {
                btnProcesar.Enabled = false;
                uscMsgBox1.AddMessage("No se encontraron todos los parámetros requeridos. Contacte al administrador del sistema.", YaBu.MessageBox.uscMsgBox.enmMessageType.Error);
            }
        }

        protected System.Data.DataTable Fijos()
        {
            System.Data.DataTable Res = new System.Data.DataTable();

            Res.Columns.Add("Anio");
            Res.Columns.Add("Ruta");

            string[] Archivos = System.IO.Directory.GetFiles(Server.MapPath("Fijos"), "PolizasAba_*.xlsx");
            System.Data.DataRow dr;

            foreach (string a in Archivos)
            {
                dr = Res.NewRow();
                dr[0] = System.IO.Path.GetFileNameWithoutExtension(a).Replace("PolizasAba_", "");
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

        protected void GenerarReporte(DateTime FechaIni, DateTime FechaFin, int NumeroMovimiento, string Cuenta, string DescripcionCuenta, string DescripcionEncabezado, int Moneda, bool BusquedaEstricta)
        {
            WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

            exportar.ReportePolizas((int)DatosGenerales.TiposDocumentos.Reporte_Polizas_Abanks, Session["UserNameLogin"].ToString(), FechaIni, FechaFin, NumeroMovimiento, Cuenta, DescripcionCuenta, DescripcionEncabezado, Moneda, BusquedaEstricta, Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSPolAb_", "xlsx"), 250000);

            Response.Redirect("DocumentosUsuario.aspx");
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //BLReportes rep = new BLReportes();

            //btnProcesar.Enabled = false;

            if (Page.IsValid && !Page.IsCallback)
            {
                DateTime FechaIni = DatosGenerales.ObtieneFecha(txtFechaIni.Text);
                DateTime FechaFin = DatosGenerales.ObtieneFecha(txtFechaFin.Text);
                int AnnoMin = 0;
                int AnnoMax = 0;
                int NumeroMovimiento = 0;

                int.TryParse(hddAnnoMin.Value, out AnnoMin);
                int.TryParse(hddAnnoMax.Value, out AnnoMax);

                if (FechaIni.Year >= AnnoMin && FechaFin.Year >= AnnoMin && FechaIni.Year <= AnnoMax && FechaFin.Year <= AnnoMax && FechaFin >= FechaIni)
                {
                    if (FechaFin.AddMonths(-3) <= FechaIni)
                    {
                        if (FechaIni.Year == FechaFin.Year)
                        {
                            int Moneda = 0;

                            int.TryParse(ddlMoneda.SelectedValue, out Moneda);

                            if (!string.IsNullOrWhiteSpace(txtNoMovimiento.Text))
                            {
                                int.TryParse(txtNoMovimiento.Text, out NumeroMovimiento);

                                if (NumeroMovimiento > 0)
                                {
                                    GenerarReporte(FechaIni, FechaFin, NumeroMovimiento, txtCuenta.Text.Trim(), txtDescripcionCuenta.Text.Trim(), txtDescripcionEncabezado.Text.Trim(), Moneda, chkBusquedaEstricta.Checked);
                                    //LimpiarControles(false);
                                }
                                else
                                {
                                    uscMsgBox1.AddMessage("Número de movimiento incorrecto.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                                }
                            }
                            else
                            {
                                GenerarReporte(FechaIni, FechaFin, NumeroMovimiento, txtCuenta.Text.Trim(), txtDescripcionCuenta.Text.Trim(), txtDescripcionEncabezado.Text.Trim(), Moneda, chkBusquedaEstricta.Checked);
                                //LimpiarControles(false);
                            }
                        }
                        else
                        {
                            uscMsgBox1.AddMessage("El rango de fechas debe ubicarse en el mismo año.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                        }
                    }
                    else
                    {
                        uscMsgBox1.AddMessage("El rango de fechas no debe ser mayor a tres meses. Se recomienda usar el reporte con filtro por año.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    }
                }
                else
                {
                    uscMsgBox1.AddMessage("Rango de fechas incorrecto.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                }
            }

            //UPrg.Visible = false;
            //btnProcesar.Enabled = true;
        }

        protected void LimpiarControles(bool LimpiarRes = true)
        {
            txtFechaIni.Text = "";
            txtFechaFin.Text = "";
            txtNoMovimiento.Text = "";
            txtCuenta.Text = "";
            txtDescripcionCuenta.Text = "";
            txtDescripcionEncabezado.Text = "";
            if (ddlMoneda.Items.Count > 0) { ddlMoneda.SelectedIndex = 0; }
            chkBusquedaEstricta.Checked = false;

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
            txtFechaIni.Focus();
        }
    }
}