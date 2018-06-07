using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptCuentas : System.Web.UI.Page
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

            objCatalogo.CatalogoSociedadesCHK(ref chkSociedades, 0);
            chkSociedades.DataBind();

            objCatalogo.CatalogoCuentasCHK(ref chkCuentas, 0);
            chkCuentas.DataBind();

            if (chkSociedades.Items.Count > 0)
                chkSociedades.SelectedIndex = 0;

            if (chkCuentas.Items.Count > 0)
                chkCuentas.SelectedIndex = 0;
        }

        protected System.Data.DataTable Fijos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();
            System.Data.DataTable Res = new System.Data.DataTable();
            System.Data.DataTable Datos = new System.Data.DataTable();

            Datos = objCatalogo.CatalogoSociedadesGrid();
            Res.Columns.Add("Sociedad");
            Res.Columns.Add("Ruta");

            string[] Archivos = System.IO.Directory.GetFiles(Server.MapPath("Fijos"), "Cuentas_*.xlsx");
            System.Data.DataRow dr;

            foreach (string a in Archivos)
            {
                for (int w = 0; w < Datos.Rows.Count; w++)
                {
                    if (Datos.Rows[w][0].ToString() == System.IO.Path.GetFileNameWithoutExtension(a).Replace("Cuentas_", ""))
                    {
                        dr = Res.NewRow();
                        dr[0] = Datos.Rows[w][1].ToString();
                        dr[1] = DatosGenerales.RutaReportesFijos + System.IO.Path.GetFileName(a);

                        Res.Rows.Add(dr);

                        break;
                    }
                }
            }

            Res.DefaultView.Sort = "Sociedad asc";
            Res = Res.DefaultView.ToTable();

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

        protected void grdDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDatos.PageIndex = e.NewPageIndex;
            grdDatos.DataSource = Fijos();
            grdDatos.DataBind();
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
            int SelCue;

            btnProcesar.Enabled = false;
            SelCue = chkCuentas.Items.Cast<ListItem>().Count(li => li.Selected);

            if (chkSociedades.Items[0].Selected == false && (chkCuentas.SelectedIndex == 0 || SelCue >= chkCuentas.Items.Count - 1))
            {
                uscMsgBox1.AddMessage("La selección actual corresponde a los reportes encontrados en la sección 'Reporte con filtro por sociedad'.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
            else
            {
                //grdDatosF.DataSource = rep.Cuentas(ArmadoCadena(chkSociedades),
                //                                   ArmadoCadena(chkCuentas),
                //                                   Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos));
                //grdDatosF.DataBind();
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.Cuentas((int)DatosGenerales.TiposDocumentos.Reporte_CuentasContables, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSCtaCont_", "xlsx"), 250000,
                                 ArmadoCadena(chkSociedades),
                                 ArmadoCadena(chkCuentas));

                Response.Redirect("DocumentosUsuario.aspx");
            }

            //btnProcesar.Enabled = true;
            //LimpiarControles(false);
        }

        protected void LimpiarControles(bool LimpiarRes = true)
        {
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

        protected void rbSociedades_CheckedChanged(object sender, EventArgs e)
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