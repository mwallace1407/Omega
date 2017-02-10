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
    public partial class RptBalanzas : System.Web.UI.Page
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

            objCatalogo.CatalogoEjerciciosCHK(ref chkAnios, (int)DatosGenerales.ReportesSAP.Balanzas);
            chkAnios.DataBind();

            objCatalogo.CatalogoSociedadesCHK(ref chkSociedades, (int)DatosGenerales.ReportesSAP.Balanzas);
            chkSociedades.DataBind();

            objCatalogo.CatalogoCuentasCHK(ref chkCuentas, 0);
            chkCuentas.DataBind();

            if (chkAnios.Items.Count > 0)
                chkAnios.SelectedIndex = 0;

            if (chkSociedades.Items.Count > 0)
                chkSociedades.SelectedIndex = 0;

            if (chkCuentas.Items.Count > 0)
                chkCuentas.SelectedIndex = 0;
        }

        protected System.Data.DataTable Fijos()
        {
            System.Data.DataTable Res = new System.Data.DataTable();

            Res.Columns.Add("Anio");
            Res.Columns.Add("Ruta");

            string[] Archivos = System.IO.Directory.GetFiles(Server.MapPath("Fijos"), "Balanza_*.xlsx");
            System.Data.DataRow dr;

            foreach (string a in Archivos)
            {
                dr = Res.NewRow();
                dr[0] = System.IO.Path.GetFileNameWithoutExtension(a).Replace("Balanza_", "");
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
            int SelAnio, SelSoc, SelCue;

            btnProcesar.Enabled = false;
            SelAnio = chkAnios.Items.Cast<ListItem>().Count(li => li.Selected);
            SelSoc = chkSociedades.Items.Cast<ListItem>().Count(li => li.Selected);
            SelCue = chkCuentas.Items.Cast<ListItem>().Count(li => li.Selected);
            
            if (chkAnios.SelectedIndex == 0 || SelAnio >= chkAnios.Items.Count - 1) { TotSel++; }
            if (chkSociedades.SelectedIndex == 0 || SelSoc >= chkSociedades.Items.Count - 1) { TotSel++; }
            if (chkCuentas.SelectedIndex == 0 || SelCue >= chkCuentas.Items.Count - 1) { TotSel++; }

            int ItmsSel = SelAnio + SelSoc + SelCue;
            int Itms = chkAnios.Items.Count + chkSociedades.Items.Count + chkCuentas.Items.Count;

            if (TotSel == 3 || ItmsSel > (Itms * .25))
            {
                uscMsgBox1.AddMessage("Demasiados elementos seleccionados. No se generará el reporte.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
            else
            {
                if (chkAnios.Items[0].Selected == false && (chkSociedades.SelectedIndex == 0 || SelSoc >= chkSociedades.Items.Count - 1) && (chkCuentas.SelectedIndex == 0 || SelCue >= chkCuentas.Items.Count - 1))
                {
                    uscMsgBox1.AddMessage("La selección actual corresponde a los reportes encontrados en la sección 'Reporte con filtro por año'.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                }
                else
                {
                    //grdDatosF.DataSource = rep.Balanzas(ArmadoCadena(chkSociedades),
                    //                                    ArmadoCadena(chkAnios),
                    //                                    ArmadoCadena(chkCuentas),
                    //                                    Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
                    //grdDatosF.DataBind();
                    WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                    exportar.BalanzasContables((int)DatosGenerales.TiposDocumentos.Reporte_BalanzasContables, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSBalCont_", "xlsx"), 250000,
                                               ArmadoCadena(chkSociedades),
                                               ArmadoCadena(chkAnios),
                                               ArmadoCadena(chkCuentas));

                    Response.Redirect("DocumentosUsuario.aspx");
                }
            }

            //btnProcesar.Enabled = true;
            //LimpiarControles(false);
        }

        protected void LimpiarControles(bool LimpiarRes = true)
        {
            chkAnios.ClearSelection();
            chkAnios.Items[0].Selected = true;
            chkSociedades.ClearSelection();
            chkSociedades.Items[0].Selected = true;
            chkCuentas.ClearSelection();
            chkCuentas.Items[0].Selected = true;

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

        protected void chkSociedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (chkSociedades.Items[index].Selected)
                value = chkSociedades.Items[index].Value;

            if (value == "0")
            {
                chkSociedades.ClearSelection();
                chkSociedades.Items[0].Selected = true;
            }
            else
            {
                int selectedCount = chkSociedades.Items.Cast<ListItem>().Count(li => li.Selected);

                if (selectedCount > 0)
                    chkSociedades.Items[0].Selected = false;
                else
                    chkSociedades.Items[0].Selected = true;
            }
        }

        protected void chkCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (chkCuentas.Items[index].Selected)
                value = chkCuentas.Items[index].Value;

            if (value == "0")
            {
                chkCuentas.ClearSelection();
                chkCuentas.Items[0].Selected = true;
            }
            else
            {
                int selectedCount = chkCuentas.Items.Cast<ListItem>().Count(li => li.Selected);

                if (selectedCount > 0)
                    chkCuentas.Items[0].Selected = false;
                else
                    chkCuentas.Items[0].Selected = true;
            }
        }

    }
}