using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;
using System.Text.RegularExpressions;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptInventarioEquipos : System.Web.UI.Page
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
            objCatalogo.CargaTiposEquipo(ref chklTipoEquipo);
            chklTipoEquipo.DataBind();
            objCatalogo.CargaMarcas(ref chklMarca);
            chklMarca.DataBind();
            objCatalogo.CargaUbicaciones(ref chklUbicacion);
            chklUbicacion.DataBind();
            objCatalogo.CargaUsuarios(ref chklUsuarios);
            chklUsuarios.DataBind();
            objCatalogo.CargaEstados(ref chkEstados);
            chkEstados.DataBind();

            if (chklTipoEquipo.Items.Count > 0)
                chklTipoEquipo.SelectedIndex = 0;

            if (chklMarca.Items.Count > 0)
                chklMarca.SelectedIndex = 0;

            if (chklUbicacion.Items.Count > 0)
                chklUbicacion.SelectedIndex = 0;

            if (chklUsuarios.Items.Count > 0)
                chklUsuarios.SelectedIndex = 0;

            if (chkEstados.Items.Count > 0)
                chkEstados.SelectedIndex = 0;
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
            Match match = Regex.Match(txtResponsivas.Text, @"^[0-9|]+$");

            if (txtResponsivas.Text.Trim() != "" && !match.Success)
                EsValido += "El texto capturado en responsivas no coincide con el formato requerido<br/ >";

            if (!HaySeleccionados(chklMarca))
                EsValido += "Debe seleccionar un elemento de la lista de Marcas<br />";

            if (!HaySeleccionados(chklTipoEquipo))
                EsValido += "Debe seleccionar un elemento de la lista de Tipos de equipo<br />";

            if (!HaySeleccionados(chklUbicacion))
                EsValido += "Debe seleccionar un elemento de la lista de Ubicación<br />";

            if (!HaySeleccionados(chklUsuarios))
                EsValido += "Debe seleccionar un elemento de la lista de Usuarios<br />";

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
                //grdDatos.DataSource = reporte.ReporteInventarioEquipo(ArmadoCadena(chklTipoEquipo),
                //                                           ArmadoCadena(chklMarca),
                //                                           ArmadoCadena(chklUbicacion),
                //                                           ArmadoCadena(chklUsuarios),
                //                                           txtResponsivas.Text,
                //                                           txtModelos.Text,
                //                                           txtNoSerie.Text,
                //                                           txtFechaIni.Text,
                //                                           txtFechaFin.Text,
                //                                           ArmadoCadena(chkEstados));
                //grdDatos.DataBind();

                //if (grdDatos.Rows.Count > 0)
                //    ExportarGridAExcel(grdDatos);
                //else
                //    uscMsgBox1.AddMessage("No se encontraron registros para exportar", YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.InventarioEquipos((int)DatosGenerales.TiposDocumentos.Reporte_InventarioEquipos, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSInvEq_", "xlsx"), 250000,
                                           ArmadoCadena(chklTipoEquipo),
                                           ArmadoCadena(chklMarca),
                                           ArmadoCadena(chklUbicacion),
                                           ArmadoCadena(chklUsuarios),
                                           txtResponsivas.Text,
                                           txtModelos.Text,
                                           txtNoSerie.Text,
                                           txtFechaIni.Text,
                                           txtFechaFin.Text,
                                           ArmadoCadena(chkEstados));

                Response.Redirect("DocumentosUsuario.aspx");
            }
            else
            {
                uscMsgBox1.AddMessage(Validaciones, YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }
    }
}