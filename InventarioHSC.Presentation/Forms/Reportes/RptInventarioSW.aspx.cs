using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptInventarioSW : System.Web.UI.Page
    {
        public BLCatalogos objCatalogo = new BLCatalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCatalogos();
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

            if (chklEmpresas.Items.Count > 0)
                chklEmpresas.SelectedIndex = 0;

            if (chklUbicacion.Items.Count > 0)
                chklUbicacion.SelectedIndex = 0;

            if (chklGrupos.Items.Count > 1)
                chklGrupos.SelectedIndex = 1;
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

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            string Validaciones = Valida();
            //BLReportes reporte = new BLReportes();

            if (Validaciones == "")
            {
                //grdDatos.DataSource = reporte.ReporteInventarioSW(ArmadoCadena(chklEmpresas),
                //                                           ArmadoCadena(chklGrupos, 1),
                //                                           txtDescripcionSW.Text,
                //                                           txtVersiones.Text,
                //                                           txtNoParte.Text,
                //                                           txtLlaves.Text,
                //                                           ArmadoCadena(chklUbicacion),
                //                                           txtObservaciones.Text,
                //                                           ddlExistencia.SelectedItem.Text,
                //                                           false).Tables[0];
                //grdDatos.DataBind();

                //if (grdDatos.Rows.Count > 0)
                //    ExportarGridAExcel(grdDatos);
                //else
                //    uscMsgBox1.AddMessage("No se encontraron registros para exportar", YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.InventarioSW((int)DatosGenerales.TiposDocumentos.Reporte_InventarioSW, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSSrvApp_", "xlsx"), 250000,
                                      ArmadoCadena(chklEmpresas),
                                      ArmadoCadena(chklGrupos, 1),
                                      txtDescripcionSW.Text,
                                      txtVersiones.Text,
                                      txtNoParte.Text,
                                      txtLlaves.Text,
                                      ArmadoCadena(chklUbicacion),
                                      txtObservaciones.Text,
                                      ddlExistencia.SelectedItem.Text);

                Response.Redirect("DocumentosUsuario.aspx");
            }
            else
            {
                uscMsgBox1.AddMessage(Validaciones, YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }
    }
}