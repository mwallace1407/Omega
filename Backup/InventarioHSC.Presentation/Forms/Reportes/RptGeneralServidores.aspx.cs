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
    public partial class RptGeneralServidores : System.Web.UI.Page
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
            objCatalogo.ListaServidoresCompletaApp(ref chklEquipos);
            chklEquipos.DataBind();
            objCatalogo.CargaSOAplicaciones(ref chklSO);
            chklSO.DataBind();
            objCatalogo.CargaTiposServidor(ref chklTipos);
            chklTipos.DataBind();
            DatosGenerales.ComboBooleano(ref ddlEstado);
            ddlEstado.DataBind();
            DatosGenerales.ComboBooleano(ref ddlEsVirtual);
            ddlEsVirtual.DataBind();

            if (chklEquipos.Items.Count > 0)
                chklEquipos.SelectedIndex = 0;

            if (chklSO.Items.Count > 0)
                chklSO.SelectedIndex = 0;

            if (chklTipos.Items.Count > 0)
                chklTipos.SelectedIndex = 0;
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

            if (!HaySeleccionados(chklEquipos))
                EsValido += "Debe seleccionar un elemento de la lista de Equipos<br />";

            if (!HaySeleccionados(chklSO))
                EsValido += "Debe seleccionar un elemento de la lista de Sistemas Operativos<br />";

            if (!HaySeleccionados(chklTipos))
                EsValido += "Debe seleccionar un elemento de la lista de Tipos<br />";

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
                //grdDatos.DataSource = reporte.ReporteGeneralServidores(ArmadoCadena(chklSO),
                //                                           ArmadoCadena(chklEquipos),
                //                                           ArmadoCadena(chklTipos),
                //                                           ddlEsVirtual.SelectedItem.Text,
                //                                           ddlEstado.SelectedItem.Text).Tables[0];
                //grdDatos.DataBind();

                //if (grdDatos.Rows.Count > 0)
                //    ExportarGridAExcel(grdDatos);
                //else
                //    uscMsgBox1.AddMessage("No se encontraron registros para exportar", YaBu.MessageBox.uscMsgBox.enmMessageType.Info);
                WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                exportar.GeneralServidores((int)DatosGenerales.TiposDocumentos.Reporte_GeneralDeServidores, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSGenSrv_", "xlsx"), 250000,
                                           ArmadoCadena(chklSO),
                                           ArmadoCadena(chklEquipos),
                                           ArmadoCadena(chklTipos),
                                           ddlEsVirtual.SelectedItem.Text,
                                           ddlEstado.SelectedItem.Text);

                Response.Redirect("DocumentosUsuario.aspx");
            }
            else
                uscMsgBox1.AddMessage(Validaciones, YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
        }
    }
}