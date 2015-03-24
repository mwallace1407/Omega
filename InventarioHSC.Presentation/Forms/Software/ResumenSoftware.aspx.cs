using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Software
{
    public partial class ResumenSoftware : System.Web.UI.Page
    {
        public BLCatalogos objCatalogo = new BLCatalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCatalogos();

                if (chklEmpresas.Items.Count > 0)
                    chklEmpresas.Items[0].Selected = true;
                
                if (chklGrupos.Items.Count > 1)
                    chklGrupos.Items[1].Selected = true;

                if (chklUbicacion.Items.Count > 0)
                    chklUbicacion.Items[0].Selected = true;
            }
        }

        protected void CargaCatalogos()
        {
            objCatalogo.CargaEmpresasSoftware(ref chklEmpresas);
            chklEmpresas.DataBind();
            objCatalogo.CargaGruposSoftware(ref chklGrupos);
            chklGrupos.DataBind();
            objCatalogo.CargaUbicacionesSW(ref chklUbicacion);
            chklUbicacion.DataBind();
            DatosGenerales.ComboBooleano(ref ddlExistencia);
            ddlExistencia.DataBind();
        }

        protected void grdDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Buscar();
            grdDatos.PageIndex = e.NewPageIndex;
            grdDatos.DataBind();
        }

        protected bool HaySeleccionados(CheckBoxList chkl)
        {
            bool Existe = false;

            for (int w = 0; w < chkl.Items.Count; w++)
            {
                if (chkl.Items[w].Selected)
                {
                    Existe = true;
                    break;
                }
            }

            return Existe;
        }

        protected string Valida()
        {
            string EsValido = "";

            if (!HaySeleccionados(chklEmpresas))
                EsValido += "Debe seleccionar un elemento de la lista de Empresas<br />";

            if (!HaySeleccionados(chklGrupos))
                EsValido += "Debe seleccionar un elemento de la lista de Grupos<br />";

            if (!HaySeleccionados(chklUbicacion))
                EsValido += "Debe seleccionar un elemento de la lista de Ubicación<br />";

            return EsValido;
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

        protected string ArmadoCadena(CheckBoxList chkl, int IndiceCero)
        {
            string Resultados = "";

            if (chkl.Items.Count > 0 && chkl.Items[IndiceCero].Value == "0" && chkl.Items[IndiceCero].Selected)
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

        protected void ExportarGridAExcel(System.Web.UI.WebControls.GridView Grid)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.IO.StringWriter sw = new System.IO.StringWriter(sb);
                System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);
                Page page = new Page();
                System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();

                Grid.EnableViewState = false;

                //Deshabilitar la validación de eventos, sólo asp.net 2 ó posterior
                page.EnableEventValidation = false;

                //Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
                page.DesignerInitialize();
                page.Controls.Add(form);
                form.Controls.Add(Grid);
                page.RenderControl(htw);

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=Reporte.xls");
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.Write(sb.ToString());
                Response.End();
                sb = null;
                sw = null;
                htw = null;
                page = null;
                form = null;
            }
            catch { }
        }

        protected void Buscar()
        {
            try
            {
                string Validaciones = Valida();
                BLReportes reporte = new BLReportes();
                System.Data.DataSet Resumen = new System.Data.DataSet();
                System.Data.DataTable Resultados = new System.Data.DataTable();

                pnlGrid.Visible = false;

                if (Validaciones == "")
                {
                    Resumen = reporte.ReporteInventarioSW(ArmadoCadena(chklEmpresas),
                                                               ArmadoCadena(chklGrupos, 1),
                                                               txtDescripcionSW.Text,
                                                               txtVersiones.Text,
                                                               txtNoParte.Text,
                                                               txtLlaves.Text,
                                                               ArmadoCadena(chklUbicacion),
                                                               txtObservaciones.Text,
                                                               ddlExistencia.SelectedValue,
                                                               true);
                    Resultados = Resumen.Tables[0];
                    grdDatos.DataSource = Resultados;
                    grdDatos.DataBind();

                    if (grdDatos.Rows.Count == 0)
                    {
                        uscMsgBox1.AddMessage("No se encontraron registros para exportar", YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                    }
                    else
                    {
                        Accordion1.SelectedIndex = 1;
                        pnlGrid.Visible = true;

                        if (Resultados.TableName != "Error")
                        {
                            grdEmpresas.DataSource = Resumen.Tables[1];
                            grdEmpresas.DataBind();
                            grdGrupos.DataSource = Resumen.Tables[2];
                            grdGrupos.DataBind();
                            grdDescripciones.DataSource = Resumen.Tables[3];
                            grdDescripciones.DataBind();
                            grdLicencias.DataSource = Resumen.Tables[4];
                            grdLicencias.DataBind();
                            grdUbicaciones.DataSource = Resumen.Tables[5];
                            grdUbicaciones.DataBind();
                        }
                    }
                }
                else
                    uscMsgBox1.AddMessage(Validaciones, YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
            catch (Exception ex)
            {
                uscMsgBox1.AddMessage(ex.Message + "<br />" + ex.StackTrace, YaBu.MessageBox.uscMsgBox.enmMessageType.Error);
            }
        }

        protected System.Data.DataTable BuscarDT()
        {
            System.Data.DataTable Resultados = new System.Data.DataTable();

            string Validaciones = Valida();
            BLReportes reporte = new BLReportes();

            pnlGrid.Visible = false;

            if (Validaciones == "")
            {
                Resultados = reporte.ReporteInventarioSW(ArmadoCadena(chklEmpresas),
                                                           ArmadoCadena(chklGrupos, 1),
                                                           txtDescripcionSW.Text,
                                                           txtVersiones.Text,
                                                           txtNoParte.Text,
                                                           txtLlaves.Text,
                                                           ArmadoCadena(chklUbicacion),
                                                           txtObservaciones.Text,
                                                           ddlExistencia.SelectedValue,
                                                           false).Tables[0];

                if (Resultados.Rows.Count == 0)
                {
                    Accordion1.SelectedIndex = 0;
                    uscMsgBox1.AddMessage("No se encontraron registros para exportar", YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                }
                else
                {
                    Accordion1.SelectedIndex = 1;
                    pnlGrid.Visible = true;
                }
            }
            else
                uscMsgBox1.AddMessage(Validaciones, YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);

            return Resultados;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            GridView grdReporte = new GridView();

            grdReporte.AutoGenerateColumns = true;
            grdReporte.DataSource = BuscarDT();
            grdReporte.DataBind();
            ExportarGridAExcel(grdReporte);
        }
    }
}