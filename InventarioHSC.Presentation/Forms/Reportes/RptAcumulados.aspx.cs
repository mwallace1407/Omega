using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptAcumulados : System.Web.UI.Page
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

            objCatalogo.CatalogoEjerciciosCHK(ref chkAnios, (int)DatosGenerales.ReportesSAP.Acumulados_RH);
            chkAnios.DataBind();

            objCatalogo.CatalogoEmpleadosCHK(ref chkEmpleados);
            chkEmpleados.DataBind();

            objCatalogo.CatalogoConceptosNominaCHK(ref chkConceptos);
            chkConceptos.DataBind();

            if (chkAnios.Items.Count > 0)
                chkAnios.SelectedIndex = 0;

            if (chkEmpleados.Items.Count > 0)
                chkEmpleados.SelectedIndex = 0;

            if (chkConceptos.Items.Count > 0)
                chkConceptos.SelectedIndex = 0;
        }

        protected System.Data.DataTable Fijos()
        {
            System.Data.DataTable Res = new System.Data.DataTable();

            Res.Columns.Add("Anio");
            Res.Columns.Add("Ruta");

            string[] Archivos = System.IO.Directory.GetFiles(Server.MapPath("Fijos"), "Acumulados_*.xlsx");
            System.Data.DataRow dr;

            foreach (string a in Archivos)
            {
                dr = Res.NewRow();
                dr[0] = System.IO.Path.GetFileNameWithoutExtension(a).Replace("Acumulados_", "");
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
            int TotSel = 0;
            int SelAnio, SelEmp, SelCon;

            //btnProcesar.Enabled = false;
            SelAnio = chkAnios.Items.Cast<ListItem>().Count(li => li.Selected);
            SelEmp = chkEmpleados.Items.Cast<ListItem>().Count(li => li.Selected);
            SelCon = chkConceptos.Items.Cast<ListItem>().Count(li => li.Selected);

            if (chkAnios.SelectedIndex == 0 || SelAnio >= chkAnios.Items.Count - 1) { TotSel++; }
            if (chkEmpleados.SelectedIndex == 0 || SelEmp >= chkEmpleados.Items.Count - 1) { TotSel++; }
            if (chkConceptos.SelectedIndex == 0 || SelCon >= chkConceptos.Items.Count - 1) { TotSel++; }

            int ItmsSel = SelAnio + SelEmp + SelCon;
            int Itms = chkAnios.Items.Count + chkEmpleados.Items.Count + chkConceptos.Items.Count;

            if (TotSel == 3 || ItmsSel > (Itms * .25))
            {
                uscMsgBox1.AddMessage("Demasiados elementos seleccionados. No se generará el reporte.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                btnProcesar.Enabled = true;
                LimpiarControles(false);
            }
            else
            {
                if (chkAnios.Items[0].Selected == false && (chkEmpleados.SelectedIndex == 0 || SelEmp >= chkEmpleados.Items.Count - 1) && (chkConceptos.SelectedIndex == 0 || SelCon >= chkConceptos.Items.Count - 1))
                {
                    uscMsgBox1.AddMessage("La selección actual corresponde a los reportes encontrados en la sección 'Reporte con filtro por año'.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    btnProcesar.Enabled = true;
                    LimpiarControles(false);
                }
                else
                {
                    WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                    exportar.Acumulados_SAP((int)DatosGenerales.TiposDocumentos.Reporte_Acumulados_SAP, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSAcum_", "xlsx"), 250000,
                                            ArmadoCadena(chkAnios),
                                            ArmadoCadena(chkEmpleados),
                                            ArmadoCadena(chkConceptos));
                    Response.Redirect("DocumentosUsuario.aspx");
                    //grdDatosF.DataSource = rep.Acumulados(ArmadoCadena(chkAnios),
                    //                                      ArmadoCadena(chkEmpleados),
                    //                                      ArmadoCadena(chkConceptos),
                    //                                      Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
                    //grdDatosF.DataBind();
                }
            }
        }

        protected void LimpiarControles(bool LimpiarRes = true)
        {
            chkAnios.ClearSelection();
            chkAnios.Items[0].Selected = true;
            chkEmpleados.ClearSelection();
            chkEmpleados.Items[0].Selected = true;
            chkConceptos.ClearSelection();
            chkConceptos.Items[0].Selected = true;

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

        protected void chkAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (chkAnios.Items[index].Selected)
                value = chkAnios.Items[index].Value;

            if (value == "0")
            {
                chkAnios.ClearSelection();
                chkAnios.Items[0].Selected = true;
            }
            else
            {
                int selectedCount = chkAnios.Items.Cast<ListItem>().Count(li => li.Selected);

                if (selectedCount > 0)
                    chkAnios.Items[0].Selected = false;
                else
                    chkAnios.Items[0].Selected = true;
            }
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

        protected void chkConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (chkConceptos.Items[index].Selected)
                value = chkConceptos.Items[index].Value;

            if (value == "0")
            {
                chkConceptos.ClearSelection();
                chkConceptos.Items[0].Selected = true;
            }
            else
            {
                int selectedCount = chkConceptos.Items.Cast<ListItem>().Count(li => li.Selected);

                if (selectedCount > 0)
                    chkConceptos.Items[0].Selected = false;
                else
                    chkConceptos.Items[0].Selected = true;
            }
        }
    }
}