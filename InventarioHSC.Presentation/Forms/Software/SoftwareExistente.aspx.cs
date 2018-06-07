using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Software
{
    public partial class SoftwareExistente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["sortOrder"] = "";

                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);

                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.DataSource = oblSoftware.ObtieneSoftware();
                gvwSoftware.DataBind();

                List<TotalesSoftware> totalesSoftware =
                    oblSoftware.ObtieneTotalesSoftware(0);

                grvTotalTipo.DataSource = totalesSoftware;
                grvTotalTipo.DataBind();
                LLenaComboNumeroLicencias();
            }
            else
            {
                if (hdnGenerrarControles.Value.Equals("1") && !hdnCve_Software.Value.Equals("0"))
                {
                    InventarioHSC.Model.Software sofware = new Model.Software();
                    BLSoftware bolSoftware = new BLSoftware();
                    sofware = bolSoftware.Software(Convert.ToInt32(hdnCve_Software.Value));

                    string agregarTR = string.Empty;
                    TableDetalle.Controls[3].Visible = false;

                    GeneraControles(sofware.NumeroLicencias);
                }
            }
        }

        public void CambiaEstadoNotificacion(string TipoEtiqueta, bool Accion, string Mensaje)
        {
            if (TipoEtiqueta == "Warning")
            {
                Warning.Visible = Accion;
                LabelWarning.Visible = Accion;
                LabelWarning.Font.Size = 10;
                LabelWarning.Text = Mensaje;
            }
            else
            {
                Info.Visible = Accion;
                LabelInfo.Visible = Accion;
                LabelInfo.Font.Size = 10;
                LabelInfo.Text = Mensaje;
            }
        }

        private void LLenaComboNumeroLicencias()
        {
            for (int i = 0; i < 101; i++)
            {
                dplNUmeroLicencia.Items.Add(i.ToString());
            }
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLSoftware oblSoftware = new BLSoftware();

                List<TotalesSoftware> totalesSoftware =
                        oblSoftware.ObtieneTotalesSoftware(0);

                string xmlData = oblSoftware.xmlDataTotales(totalesSoftware);

                StringBuilder Clientscript = new StringBuilder();
                Clientscript.Append("<script>");
                Clientscript.Append("updateChartTotalesSoftware(\"" + xmlData + "\");");
                Clientscript.Append("</script>");

                if (!ClientScript.IsStartupScriptRegistered("udpChart"))
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "udpChart", Clientscript.ToString(), false);
            }
        }

        protected void gvwSoftware_Sorting(object sender, GridViewSortEventArgs e)
        {
            bindGridView(e.SortExpression, sortOrder);
        }

        public string sortOrder
        {
            get
            {
                if (ViewState["sortOrder"].ToString() == "desc")
                {
                    ViewState["sortOrder"] = "asc";
                }
                else
                {
                    ViewState["sortOrder"] = "desc";
                }

                return ViewState["sortOrder"].ToString();
            }
            set
            {
                ViewState["sortOrder"] = value;
            }
        }

        public void bindGridView(string sortExp, string sortDir)
        {
            DataSet myDataSet = new DataSet();

            DataView myDataView = new DataView();
            myDataView = myDataSet.Tables[0].DefaultView;

            if (sortExp != string.Empty)
            {
                myDataView.Sort = string.Format("{0} {1}", sortExp, sortDir);
            }

            gvwSoftware.DataSource = myDataView;
            gvwSoftware.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Trim().Equals("") && txtVersion.Text.Trim().Equals("") && DescripcionSoftware.Text.Trim().Equals(""))
            {
                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.DataSource = oblSoftware.ObtieneSoftware();
                gvwSoftware.DataBind();

                List<TotalesSoftware> totalesSoftware =
                    oblSoftware.ObtieneTotalesSoftware(0);

                grvTotalTipo.DataSource = totalesSoftware;
                grvTotalTipo.DataBind();

                gvwDetalle.DataBind();

                string xmlData = oblSoftware.xmlDataTotales(totalesSoftware);

                StringBuilder Clientscript = new StringBuilder();
                Clientscript.Append("<script>");
                Clientscript.Append("updateChartTotalesSoftware(\"" + xmlData + "\");");
                Clientscript.Append("</script>");

                if (!ClientScript.IsStartupScriptRegistered("udpChart"))
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "udpChart", Clientscript.ToString(), false);

                hdnCve_Software.Value = "0";
            }
            else
            {
                int? valueIntNull = null;
                int? pCantidad = txtCantidad.Text.Trim().Equals("") ? valueIntNull : Convert.ToInt32(txtCantidad.Text);
                string pNombreLicencia = DescripcionSoftware.Text.Trim().Equals("") ? null : DescripcionSoftware.Text;
                string pVersion = txtVersion.Text.Trim().Equals("") ? null : txtVersion.Text;

                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.DataSource = oblSoftware.OntieneFiltroSoftware(pNombreLicencia, pVersion, pCantidad);
                gvwSoftware.DataBind();

                List<TotalesSoftware> totalesSoftware =
                    oblSoftware.ObtieneTotalesSoftware(pNombreLicencia, pVersion, pCantidad);

                grvTotalTipo.DataSource = totalesSoftware;
                grvTotalTipo.DataBind();

                gvwDetalle.DataBind();

                string xmlData = oblSoftware.xmlDataTotales(totalesSoftware);

                StringBuilder Clientscript = new StringBuilder();
                Clientscript.Append("<script>");
                Clientscript.Append("updateChartTotalesSoftware(\"" + xmlData + "\");");
                Clientscript.Append("</script>");

                if (!ClientScript.IsStartupScriptRegistered("udpChart"))
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "udpChart", Clientscript.ToString(), false);

                hdnCve_Software.Value = "0";
            }

            HabilitarBotonAgregarDetalle(false);
        }

        protected void gvwSoftware_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[0].ToolTip = "Editar";
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gvwSoftware','Editar$" + (e.Row.RowIndex).ToString().Trim() + "')");

                        e.Row.Cells[1].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[1].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[1].ToolTip = "Informacion General";
                        e.Row.Cells[1].Attributes.Add("OnClick", "javascript:__doPostBack('gvwSoftware','InfoGen$" + (e.Row.RowIndex).ToString().Trim() + "')");

                        e.Row.Cells[2].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[2].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[2].ToolTip = "Informacion General";
                        e.Row.Cells[2].Attributes.Add("OnClick", "javascript:__doPostBack('gvwSoftware','InfoGen$" + (e.Row.RowIndex).ToString().Trim() + "')");

                        e.Row.Cells[3].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[3].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[3].ToolTip = "Informacion General";
                        e.Row.Cells[3].Attributes.Add("OnClick", "javascript:__doPostBack('gvwSoftware','InfoGen$" + (e.Row.RowIndex).ToString().Trim() + "')");

                        e.Row.Cells[4].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[4].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[4].ToolTip = "Informacion General";
                        e.Row.Cells[4].Attributes.Add("OnClick", "javascript:__doPostBack('gvwSoftware','InfoGen$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                LabelWarning.Visible = true;
                LabelWarning.Text = ex.Message;
                Warning.Visible = true;
            }
        }

        protected void gvwSoftware_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("Page"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int cve_Software = Convert.ToInt32(gvwSoftware.DataKeys[index].Value);
                hdnCve_Software.Value = cve_Software.ToString();

                if (e.CommandName.Equals("InfoGen"))
                {
                    BLSoftware oblSoftware = new BLSoftware();
                    BLAsignacion_Software oblAsiganacionSoftware = new BLAsignacion_Software();

                    List<TotalesSoftware> totalesSoftware =
                        oblSoftware.ObtieneTotalesSoftware(cve_Software);

                    grvTotalTipo.DataSource = totalesSoftware;
                    grvTotalTipo.DataBind();

                    gvwDetalle.DataSource = oblAsiganacionSoftware.ObtieneAsignacionSoftware(cve_Software);
                    gvwDetalle.DataBind();

                    InventarioHSC.Model.Software software = oblSoftware.Software(Convert.ToInt32(hdnCve_Software.Value));

                    string xmlData = oblSoftware.xmlDataTotales(totalesSoftware, software.Descripcion);

                    HabilitarBotonAgregarDetalle(true);

                    StringBuilder Clientscript = new StringBuilder();
                    Clientscript.Append("<script>");
                    Clientscript.Append("updateChartTotalesSoftware(\"" + xmlData + "\");");
                    Clientscript.Append("</script>");

                    if (!ClientScript.IsStartupScriptRegistered("udpChart"))
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "udpChart", Clientscript.ToString(), false);
                }
                else if (e.CommandName.Equals("Editar"))
                {
                    hdnCve_Software.Value = cve_Software.ToString();
                    lblInfo.Text = ".: Actualizar :.";
                    CargarDatosSoftware();
                    txtCantidadU.Enabled = false;
                    mpeDatosSoftware.Show();
                }
            }
        }

        private void CargarDatosSoftware()
        {
            BLSoftware oblSoftware = new BLSoftware();
            InventarioHSC.Model.Software software = oblSoftware.Software(Convert.ToInt32(hdnCve_Software.Value));

            txtNombreLicenciaU.Text = software.Descripcion;
            txtCantidadU.Text = software.NumeroLicencias.ToString();
            txtVersionU.Text = software.Version;
        }

        private void LimpiaDatosSoftware()
        {
            txtNombreLicenciaU.Text = "";
            txtCantidadU.Text = "";
            txtVersionU.Text = "";
        }

        protected void gvwDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BLAsignacion_Software oblAsiganacionSoftware = new BLAsignacion_Software();

            gvwDetalle.DataSource = oblAsiganacionSoftware.ObtieneAsignacionSoftware(Convert.ToInt32(hdnCve_Software.Value));
            gvwDetalle.PageIndex = e.NewPageIndex;
            gvwDetalle.DataBind();
        }

        protected void gvwDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[0].ToolTip = "Editar";
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gvwDetalle','Editar$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                LabelWarning.Visible = true;
                LabelWarning.Text = ex.Message;
                Warning.Visible = true;
            }
        }

        protected void gvwDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("Page"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int cve_Asignacion = Convert.ToInt32(gvwDetalle.DataKeys[index].Value);
                hdnCve_Asignacion.Value = cve_Asignacion.ToString();

                if (e.CommandName.Equals("Editar"))
                {
                    LimpiaPanelDetalle();
                    TableDetalle.Controls[1].Visible = false;
                    lblKeyDetalle.Enabled = true;
                    txtKeyD.Enabled = true;
                    rfvKeyD.Enabled = true;
                    vceKeyD.Enabled = true;
                    TableDetalle.Controls[3].Visible = true;
                    CargaPanelDetalle();
                    lblTituloPanelDetalle.Text = ".: Actualizar Licencia :.";
                    mpeDetalleAsignacion.Show();
                }
            }
        }

        protected void gvwSoftware_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (txtCantidad.Text.Trim().Equals("") && txtVersion.Text.Trim().Equals("") && DescripcionSoftware.Text.Trim().Equals(""))
            {
                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.DataSource = oblSoftware.ObtieneSoftware();
                gvwSoftware.PageIndex = e.NewPageIndex;
                gvwSoftware.DataBind();
            }
            else
            {
                int? valueIntNull = null;
                int? pCantidad = txtCantidad.Text.Trim().Equals("") ? valueIntNull : Convert.ToInt32(txtCantidad.Text);
                string pNombreLicencia = DescripcionSoftware.Text.Trim().Equals("") ? null : DescripcionSoftware.Text;
                string pVersion = txtVersion.Text.Trim().Equals("") ? null : txtVersion.Text;

                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.DataSource = oblSoftware.OntieneFiltroSoftware(pNombreLicencia, pVersion, pCantidad);
                gvwSoftware.PageIndex = e.NewPageIndex;
                gvwSoftware.DataBind();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void btnRegresarD_Click(object sender, EventArgs e)
        {
            hdnGenerrarControles.Value = "0";
            mpeDetalleAsignacion.Hide();
        }

        protected void btnGuardaDetalle_Click(object sender, EventArgs e)
        {
            DateTime? value = null;
            int? valueInt = null;
            decimal? valueDecimal = null;

            try
            {
                if (hdnCve_Asignacion.Value.Equals("0"))
                {
                    if (!this.dplNUmeroLicencia.SelectedItem.Text.Equals("0"))
                    {
                        Asignacion_Software asiSoftware = new Asignacion_Software();
                        int numeroDeLicencias = Convert.ToInt32(dplNUmeroLicencia.SelectedItem.Text);
                        BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software(asiSoftware);

                        for (int i = 0; i < numeroDeLicencias; i++)
                        {
                            asiSoftware.Cve_Software = Convert.ToInt32(hdnCve_Software.Value);
                            asiSoftware.Area_Solicita = txtAreaSolicitaD.Text.Trim().Equals("") ? null : txtAreaSolicitaD.Text;
                            asiSoftware.Centro_Costo = txtCentroCostosD.Text.Trim().Equals("") ? null : txtCentroCostosD.Text;
                            asiSoftware.Dolares = txtDolaresD.Text.Trim().Equals("") ? valueDecimal : Convert.ToDecimal(txtDolaresD.Text);
                            asiSoftware.Fecha_Compra = txtFechaCompraD.Text.Trim().Equals("") ? value : Convert.ToDateTime(txtFechaCompraD.Text);
                            asiSoftware.Fecha_Vencimiento = txtFechaVencimientoD.Text.Trim().Equals("") ? value : Convert.ToDateTime(txtFechaVencimientoD.Text);
                            asiSoftware.Responsiva = txtIncluido_ResponsivaD.Text.Trim().Equals("") ? null : txtIncluido_ResponsivaD.Text;

                            int initContador = 4;

                            TextBox textKey = (TextBox)TableDetalle.FindControl("txtKeyR" + initContador);

                            if (textKey != null)
                            {
                                asiSoftware.Key = textKey.Text;
                            }

                            asiSoftware.Lenguaje = txtLenguajeD.Text.Equals("") ? null : txtLenguajeD.Text;
                            asiSoftware.Lote_Code = txtLoteCodeD.Text.Equals("") ? null : txtLoteCodeD.Text;
                            asiSoftware.Material = txtMaterialD.Text.Equals("") ? null : txtMaterialD.Text;
                            asiSoftware.Numero_Factura = txtNoFacturaD.Text.Trim().Equals("") ? valueInt : Convert.ToInt32(txtNoFacturaD.Text);
                            asiSoftware.Nombre_Usuario = txtNombreUsuarioD.Text;
                            asiSoftware.Numero_Requisicion_Compra = txtNoRequisicionCompraD.Text.Trim().Equals("") ? valueInt : Convert.ToInt32(txtNoRequisicionCompraD.Text);
                            asiSoftware.Numero_Taejeta = txtNoTarjetaD.Text.Equals("") ? null : txtNoTarjetaD.Text;
                            asiSoftware.Observaciones = txtObservacionD.Text.Equals("") ? null : txtObservacionD.Text;
                            asiSoftware.Pesos = txtPesosD.Text.Trim().Equals("") ? valueDecimal : Convert.ToDecimal(txtPesosD.Text);
                            asiSoftware.Proveedor = txtProveedorD.Text.Equals("") ? null : txtProveedorD.Text;
                            asiSoftware.Responsiva = txtResponsivaD.Text.Equals("") ? null : txtResponsivaD.Text;
                            asiSoftware.Sucursal = txtSucursalD.Text.Equals("") ? null : txtSucursalD.Text;

                            blAsignacionSoftware.insertaAsignacionSoftwareNuevo();

                            initContador++;
                        }

                        gvwDetalle.DataSource = blAsignacionSoftware.ObtieneAsignacionSoftware(asiSoftware.Cve_Software);
                        gvwDetalle.DataBind();

                        BLSoftware oblSoftware = new BLSoftware();
                        BLAsignacion_Software oblAsiganacionSoftware = new BLAsignacion_Software();

                        List<TotalesSoftware> totalesSoftware =
                            oblSoftware.ObtieneTotalesSoftware(asiSoftware.Cve_Software);

                        grvTotalTipo.DataSource = totalesSoftware;
                        grvTotalTipo.DataBind();

                        InventarioHSC.Model.Software software = oblSoftware.Software(Convert.ToInt32(hdnCve_Software.Value));

                        string xmlData = oblSoftware.xmlDataTotales(totalesSoftware, software.Descripcion);

                        HabilitarBotonAgregarDetalle(true);

                        StringBuilder Clientscript = new StringBuilder();
                        Clientscript.Append("<script>");
                        Clientscript.Append("updateChartTotalesSoftware(\"" + xmlData + "\");");
                        Clientscript.Append("</script>");

                        if (!ClientScript.IsStartupScriptRegistered("udpChart"))
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "udpChart", Clientscript.ToString(), false);

                        mpeDetalleAsignacion.Hide();
                    }
                    else
                    {
                        LabelInfo.Focus();
                        Warning.Visible = false;
                        LabelWarning.Text = "";
                        LabelInfo.Text = "Seleccione el numero de licencias";
                        Info.Visible = true;
                    }
                }
                else
                {
                    Asignacion_Software asiSoftware = new Asignacion_Software();

                    asiSoftware.Cve_Software = Convert.ToInt32(hdnCve_Software.Value);
                    asiSoftware.Cve_Asignacion = Convert.ToInt32(hdnCve_Asignacion.Value);
                    asiSoftware.Area_Solicita = txtAreaSolicitaD.Text.Trim().Equals("") ? null : txtAreaSolicitaD.Text;
                    asiSoftware.Centro_Costo = txtCentroCostosD.Text.Trim().Equals("") ? null : txtCentroCostosD.Text;
                    asiSoftware.Dolares = txtDolaresD.Text.Trim().Equals("") ? valueDecimal : Convert.ToDecimal(txtDolaresD.Text);
                    asiSoftware.Fecha_Compra = txtFechaCompraD.Text.Trim().Equals("") ? value : Convert.ToDateTime(txtFechaCompraD.Text);
                    asiSoftware.Fecha_Vencimiento = txtFechaVencimientoD.Text.Trim().Equals("") ? value : Convert.ToDateTime(txtFechaVencimientoD.Text);
                    asiSoftware.Incluido_Responsiva = txtIncluido_ResponsivaD.Text.Trim().Equals("") ? null : txtIncluido_ResponsivaD.Text;
                    asiSoftware.Key = txtKeyD.Text;
                    asiSoftware.Lenguaje = txtLenguajeD.Text.Trim().Equals("") ? null : txtLenguajeD.Text;
                    asiSoftware.Lote_Code = txtLoteCodeD.Text.Equals("") ? null : txtLoteCodeD.Text;
                    asiSoftware.Material = txtMaterialD.Text.Equals("") ? null : txtMaterialD.Text;
                    asiSoftware.Numero_Factura = txtNoFacturaD.Text.Trim().Equals("") ? valueInt : Convert.ToInt32(txtNoFacturaD.Text);
                    asiSoftware.Nombre_Usuario = txtNombreUsuarioD.Text;
                    asiSoftware.Numero_Requisicion_Compra = txtNoRequisicionCompraD.Text.Trim().Equals("") ? valueInt : Convert.ToInt32(txtNoRequisicionCompraD.Text);
                    asiSoftware.Numero_Taejeta = txtNoTarjetaD.Text.Equals("") ? null : txtNoTarjetaD.Text;
                    asiSoftware.Observaciones = txtObservacionD.Text.Equals("") ? null : txtObservacionD.Text;
                    asiSoftware.Pesos = txtPesosD.Text.Trim().Equals("") ? valueDecimal : Convert.ToDecimal(txtPesosD.Text);
                    asiSoftware.Proveedor = txtProveedorD.Text.Trim().Equals("") ? null : txtProveedorD.Text;
                    asiSoftware.Responsiva = txtResponsivaD.Text.Equals("") ? null : txtResponsivaD.Text;
                    asiSoftware.Sucursal = txtSucursalD.Text.Trim().Equals("") ? null : txtSucursalD.Text;

                    BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software(asiSoftware);
                    string mensaje = blAsignacionSoftware.ActualiaAsignacionSoftware();

                    gvwDetalle.DataSource = blAsignacionSoftware.ObtieneAsignacionSoftware(Convert.ToInt32(hdnCve_Software.Value));
                    gvwDetalle.DataBind();

                    EnviaMensaje(mensaje);
                    mpeDetalleAsignacion.Hide();
                }

                hdnGenerrarControles.Value = "0";
            }
            catch (Exception ex)
            {
                LabelWarning.Focus();
                Warning.Visible = true;
                LabelWarning.Text = "Ocurrio un Error en el Proceso: " + ex.Message;
                LabelInfo.Text = "";
                Info.Visible = false;
                hdnGenerrarControles.Value = "0";
                mpeDetalleAsignacion.Hide();
            }
        }

        private void HabilitarBotonAgregarDetalle(bool enable)
        {
            btnAgregarDetalle.Enabled = enable;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            mpeDatosSoftware.Hide();
        }

        protected void btnAgregarSoft_Click(object sender, EventArgs e)
        {
            LimpiaDatosSoftware();
            txtCantidadU.Enabled = true;
            hdnCve_Software.Value = "0";
            mpeDatosSoftware.Show();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!hdnCve_Software.Value.Equals("0"))
                {
                    Model.Software sofware = new Model.Software();
                    sofware.Cve_Software = Convert.ToInt32(hdnCve_Software.Value);
                    sofware.Descripcion = txtNombreLicenciaU.Text;
                    sofware.Version = txtVersionU.Text;
                    sofware.NumeroLicencias = Convert.ToInt32(txtCantidadU.Text);

                    BLSoftware blSoftware = new BLSoftware(sofware);
                    blSoftware.actualizaSoftware();
                }
                else
                {
                    InventarioHSC.Model.Software sofware = new Model.Software();
                    sofware.Cve_Software = 0;
                    sofware.Descripcion = txtNombreLicenciaU.Text;
                    sofware.Version = txtVersionU.Text;
                    sofware.NumeroLicencias = Convert.ToInt32(txtCantidadU.Text);

                    BLSoftware blSoftware = new BLSoftware(sofware);
                    string respuesta = blSoftware.insertaSoftwareNuevo();

                    if (respuesta != "OK")
                    {
                        Warning.Visible = false;
                        LabelWarning.Text = "";
                        LabelInfo.Text = respuesta;
                        LabelInfo.Focus();
                        Info.Visible = true;
                        btnBuscar_Click(sender, e);
                        mpeDatosSoftware.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                Warning.Visible = true;
                LabelWarning.Text = "Ocurrio un Error en el Proceso: " + ex.Message;
                LabelWarning.Focus();
                LabelInfo.Text = "";
                Info.Visible = false;
            }
        }

        protected void ExportaExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (gvwSoftware.PageCount > 1)
            {
                cambiodePagina();
            }

            string rutaArchivo = this.gvwSoftware.ToExcel(Server.MapPath("~/Forms/Docs/Export/"), "Resultado_de_Software");
            Response.Redirect("~/Handlers/HandlerDescargaExcel.ashx?rutaArchivo=" + rutaArchivo + "&nombreArchivo=Resultado_de_Software.xlsx");
        }

        protected void btnExcelDetalleE_Click(object sender, EventArgs e)
        {
            if (gvwDetalle.PageCount > 1)
            {
                BLAsignacion_Software oblAsiganacionSoftware = new BLAsignacion_Software();
                gvwDetalle.AllowPaging = false;
                gvwDetalle.DataSource = oblAsiganacionSoftware.ObtieneAsignacionSoftware(Convert.ToInt32(this.hdnCve_Software.Value));
                gvwDetalle.DataBind();
            }

            string rutaArchivo = this.gvwDetalle.ToExcel(Server.MapPath("~/Forms/Docs/Export/"), "Resultado_de_Asignacion_Software");
            Response.Redirect("~/Handlers/HandlerDescargaExcel.ashx?rutaArchivo=" + rutaArchivo + "&nombreArchivo=Resultado_de_Asignacion_Software.xlsx");
        }

        protected void ExportaExcelConDetalle_Click(object sender, ImageClickEventArgs e)
        {
        }

        private void LimpiaPanelDetalle()
        {
            txtAreaSolicitaD.Text = "";
            txtCentroCostosD.Text = "";
            txtDolaresD.Text = "";
            txtFechaCompraD.Text = "";
            txtFechaVencimientoD.Text = "";
            txtIncluido_ResponsivaD.Text = "";
            txtKeyD.Text = "";
            txtLenguajeD.Text = "";
            txtLoteCodeD.Text = "";
            txtMaterialD.Text = "";
            txtNoFacturaD.Text = "";
            txtNombreUsuarioD.Text = "";
            txtNoRequisicionCompraD.Text = "";
            txtNoTarjetaD.Text = "";
            txtObservacionD.Text = "";
            txtPesosD.Text = "";
            txtProveedorD.Text = "";
            txtResponsivaD.Text = "";
            txtSucursalD.Text = "";
        }

        private void cambiodePagina()
        {
            if (txtCantidad.Text.Trim().Equals("") && txtVersion.Text.Trim().Equals("") && DescripcionSoftware.Text.Trim().Equals(""))
            {
                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.AllowPaging = false;
                gvwSoftware.DataSource = oblSoftware.ObtieneSoftware();
                gvwSoftware.DataBind();
            }
            else
            {
                int? valueIntNull = null;
                int? pCantidad = txtCantidad.Text.Trim().Equals("") ? valueIntNull : Convert.ToInt32(txtCantidad.Text);
                string pNombreLicencia = DescripcionSoftware.Text.Trim().Equals("") ? null : DescripcionSoftware.Text;
                string pVersion = txtVersion.Text.Trim().Equals("") ? null : txtVersion.Text;

                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.AllowPaging = false;
                gvwSoftware.DataSource = oblSoftware.OntieneFiltroSoftware(pNombreLicencia, pVersion, pCantidad);
                gvwSoftware.DataBind();
            }
        }

        private void ExtraerDetalle()
        {
            if (txtCantidad.Text.Trim().Equals("") && txtVersion.Text.Trim().Equals("") && DescripcionSoftware.Text.Trim().Equals(""))
            {
                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.AllowPaging = false;
                gvwSoftware.DataSource = oblSoftware.ObtieneSoftware();
                gvwSoftware.DataBind();
            }
            else
            {
                int? valueIntNull = null;
                int? pCantidad = txtCantidad.Text.Trim().Equals("") ? valueIntNull : Convert.ToInt32(txtCantidad.Text);
                string pNombreLicencia = DescripcionSoftware.Text.Trim().Equals("") ? null : DescripcionSoftware.Text;
                string pVersion = txtVersion.Text.Trim().Equals("") ? null : txtVersion.Text;

                BLSoftware oblSoftware = new BLSoftware();
                gvwSoftware.AllowPaging = false;
                gvwSoftware.DataSource = oblSoftware.OntieneFiltroSoftware(pNombreLicencia, pVersion, pCantidad);
                gvwSoftware.DataBind();
            }
        }

        private void CargaPanelDetalle()
        {
            Asignacion_Software asiSoftware = new Asignacion_Software();
            asiSoftware.Cve_Asignacion = Convert.ToInt32(hdnCve_Asignacion.Value);
            BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software(asiSoftware);
            asiSoftware = blAsignacionSoftware.ObtenAsignacionSoftware();

            txtAreaSolicitaD.Text = asiSoftware.Area_Solicita;
            txtCentroCostosD.Text = asiSoftware.Centro_Costo;
            txtDolaresD.Text = asiSoftware.Dolares.ToString();
            txtFechaCompraD.Text = asiSoftware.Fecha_Compra.ToString();
            txtFechaVencimientoD.Text = asiSoftware.Fecha_Vencimiento.ToString();
            txtIncluido_ResponsivaD.Text = asiSoftware.Incluido_Responsiva;
            txtKeyD.Text = asiSoftware.Key;
            txtLenguajeD.Text = asiSoftware.Lenguaje;
            txtLoteCodeD.Text = asiSoftware.Lote_Code;
            txtMaterialD.Text = asiSoftware.Material;
            txtNoFacturaD.Text = asiSoftware.Numero_Factura.ToString();
            txtNombreUsuarioD.Text = asiSoftware.Nombre_Usuario;
            txtNoRequisicionCompraD.Text = asiSoftware.Numero_Requisicion_Compra.ToString();
            txtNoTarjetaD.Text = asiSoftware.Numero_Taejeta;
            txtObservacionD.Text = asiSoftware.Observaciones;
            txtPesosD.Text = asiSoftware.Pesos.ToString();
            txtProveedorD.Text = asiSoftware.Proveedor;
            txtResponsivaD.Text = asiSoftware.Responsiva;
            txtSucursalD.Text = asiSoftware.Sucursal;
        }

        private void CargaPanelDetalleaGREGAR()
        {
            int cve_Asignacion = Convert.ToInt32(gvwDetalle.DataKeys[0].Value);
            Asignacion_Software asiSoftware = new Asignacion_Software();
            asiSoftware.Cve_Asignacion = cve_Asignacion;
            BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software(asiSoftware);
            asiSoftware = blAsignacionSoftware.ObtenAsignacionSoftware();

            txtAreaSolicitaD.Text = asiSoftware.Area_Solicita;
            txtCentroCostosD.Text = asiSoftware.Centro_Costo;
            txtDolaresD.Text = asiSoftware.Dolares.ToString();
            txtFechaCompraD.Text = asiSoftware.Fecha_Compra.ToString();
            txtFechaVencimientoD.Text = asiSoftware.Fecha_Vencimiento.ToString();
            txtIncluido_ResponsivaD.Text = asiSoftware.Incluido_Responsiva;
            txtLenguajeD.Text = asiSoftware.Lenguaje;
            txtLoteCodeD.Text = asiSoftware.Lote_Code;
            txtMaterialD.Text = asiSoftware.Material;
            txtNoFacturaD.Text = asiSoftware.Numero_Factura.ToString();
            txtNoRequisicionCompraD.Text = asiSoftware.Numero_Requisicion_Compra.ToString();
            txtNoTarjetaD.Text = asiSoftware.Numero_Taejeta;
            txtObservacionD.Text = asiSoftware.Observaciones;
            txtPesosD.Text = asiSoftware.Pesos.ToString();
            txtProveedorD.Text = asiSoftware.Proveedor;
            txtResponsivaD.Text = asiSoftware.Responsiva;
            txtSucursalD.Text = asiSoftware.Sucursal;
        }

        private void EnviaMensaje(string mensaje)
        {
            string Clientscript = "<script>alert('" + mensaje + "')</script>";

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "WOpen", Clientscript, false);
        }

        protected void dplNUmeroLicencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!hdnCve_Software.Value.Equals("0"))
            {
                TableDetalle.Controls[3].Visible = false;

                GeneraControles(Convert.ToInt32(dplNUmeroLicencia.SelectedItem.Text));
            }
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            LimpiaPanelDetalle();
            txtNombreUsuarioD.Text = "Disponible";
            hdnCve_Asignacion.Value = "0";
            int cveSoftware = Convert.ToInt32(hdnCve_Software.Value);

            BLAsignacion_Software oblAsiganacionSoftware = new BLAsignacion_Software();
            lblKeyDetalle.Enabled = false;
            txtKeyD.Enabled = false;
            rfvKeyD.Enabled = false;
            vceKeyD.Enabled = false;
            TableDetalle.Controls[3].Visible = false;
            TableDetalle.Controls[1].Visible = true;

            if (oblAsiganacionSoftware.ObtieneAsignacionSoftware(cveSoftware).Count == 0)
            {
                InventarioHSC.Model.Software sofware = new Model.Software();
                BLSoftware bolSoftware = new BLSoftware();
                sofware = bolSoftware.Software(cveSoftware);
                dplNUmeroLicencia.SelectedValue = sofware.NumeroLicencias.ToString();

                hdnGenerrarControles.Value = "1";
                GeneraControles(sofware.NumeroLicencias);
            }
            else
            {
                dplNUmeroLicencia.SelectedValue = "0";
            }

            lblTituloPanelDetalle.Text = ".: Agregar Licencia :.";
            mpeDetalleAsignacion.Show();
        }

        private void GeneraControles(int numeroControles)
        {
            if (numeroControles != 0)
            {
                for (int i = 4; i < (4 + numeroControles); i++)
                {
                    TableRow tRow = new TableRow();

                    TableCell tCell1 = new TableCell();
                    tCell1.HorizontalAlign = HorizontalAlign.Right;
                    TableCell tCell2 = new TableCell();
                    Label lblKetDetalle2 = new Label();
                    lblKetDetalle2.ID = "lblKetDetalle" + i;
                    lblKetDetalle2.Text = "Key " + (i - 3) + ":";
                    TextBox txtKeyD2 = new TextBox();
                    txtKeyD2.ID = "txtKeyR" + i;
                    txtKeyD2.Text = "";
                    txtKeyD2.Width = 200;
                    RequiredFieldValidator rfvKeyD2 = new RequiredFieldValidator();
                    rfvKeyD2.Display = ValidatorDisplay.None;
                    rfvKeyD2.SetFocusOnError = true;
                    rfvKeyD2.ControlToValidate = "txtKeyR" + i;
                    rfvKeyD2.ErrorMessage = "El campo \"" + "Key " + (i - 3) + "\" es requerido";
                    rfvKeyD2.ValidationGroup = "vgEditarDetalleRegistro";
                    rfvKeyD2.CssClass = "label";
                    rfvKeyD2.ID = "rfvKeyDR" + i;

                    ValidatorCalloutExtender vceKeyD2 = new ValidatorCalloutExtender();
                    vceKeyD2.ID = "vceKeyDR" + i;
                    vceKeyD2.TargetControlID = "rfvKeyDR" + i;

                    tCell1.Controls.Add(lblKetDetalle2);
                    tCell2.Controls.Add(txtKeyD2);
                    tCell2.Controls.Add(rfvKeyD2);
                    tCell2.Controls.Add(vceKeyD2);

                    tRow.Controls.Add(tCell1);
                    tRow.Controls.Add(tCell2);
                    TableDetalle.Controls.AddAt(i, tRow);
                }
            }
        }
    }
}