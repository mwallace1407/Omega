using System;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC
{
    public partial class _AltaArticulo : System.Web.UI.Page
    {
        public Articulo Params = new Articulo();
        public DetalleServidor obDetalleServidor = new DetalleServidor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["isServer"] = 0;
                //Panel1.Visible = false;
                //pnlDetallePCServidor.Visible = false;

                Warning.Visible = false;
                Info.Visible = false;
                //txtResponsiva.Enabled = false;
                //txtNoCastor.Enabled = false;
                //ddlUsuarioAsignado.Enabled = false;
                //txtPuesto.Enabled = false;
                //txtCambioRYS.Enabled = false;
                CargaCatalogos();
                //LLenaCombosprocesador();
                //LLenaCombosDiscos();
            }

            //if (hdnGeneracionDeControles.Value.Equals("1"))
            //    GeneraControles(Convert.ToInt32(ddlDiscosDuros.SelectedItem.Value));
        }

        public void CargaCatalogos()
        {
            BLCatalogos oblCatalogos = new BLCatalogos();

            oblCatalogos.CargaTipoEquipo(ref ddlTipoArticulo);
            ddlTipoArticulo.DataBind();

            oblCatalogos.CargaMarca(ref ddlMarca);
            ddlMarca.DataBind();

            //oblCatalogos.CargaSistemaOperativo(ref ddlSistemaOperativo);
            //ddlSistemaOperativo.DataBind();

            //oblCatalogos.CargaProveedor(ref ddlProveedor);
            //ddlProveedor.DataBind();

            //oblCatalogos.CargaUsuarioAlta(ref ddlUsuarioAsignado);
            //ddlUsuarioAsignado.DataBind();

            oblCatalogos.CargaUbicacionBodegas(ref ddlUbicacion);
            ddlUbicacion.DataBind();

            oblCatalogos.CargaEstado(ref ddlEstado);
            ddlEstado.DataBind();
        }

        public enum TipoEquipo
        {
            SERVIDOR = 18,
            CONTROLADORA = 32,
            STORAGE = 43
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string sMensaje = string.Empty;
            CargaValores();
            try
            {
                BLArticulo oblArticulo = new BLArticulo(Params);

                if (radioCon.Checked)
                {
                    Articulo arti = oblArticulo.BuscarArticuloPorSerie(Params.noSerie);

                    if (arti.idItem != 0)
                    {
                        sMensaje = "Ya Existe un articulo con este No. de serie";
                    }
                }

                if (string.IsNullOrEmpty(sMensaje))
                    sMensaje = oblArticulo.insertaArticuloNuevo(chkIgnorarSerie.Checked);

                if (Params.idTipoEquipo == (int)TipoEquipo.SERVIDOR || Params.idTipoEquipo == (int)TipoEquipo.CONTROLADORA || Params.idTipoEquipo == (int)TipoEquipo.STORAGE)
                {
                    string cpacidadeDiscos = string.Empty;
                    string pibe = string.Empty;

                    //for (int i = 3; i < (Convert.ToInt32(ddlDiscosDuros.SelectedItem.Value) + 3) ; i++)
                    //{
                    //    TextBox textKey = (TextBox)tblDetalleServidor.FindControl("txtTamDisco" + i);

                    //    if (textKey != null)
                    //    {
                    //        cpacidadeDiscos += pibe + textKey.Text;
                    //    }

                    //    pibe = "|";
                    //}

                    //BLDetalleServidor blDetalle = new BLDetalleServidor();
                    //blDetalle.InsertaDetalleServidor(oblArticulo.id_Item,
                    //    Convert.ToInt32(ddlProcesadores.SelectedItem.Value),
                    //    txtTipoProcesadores.Text,
                    //    Convert.ToInt32(ddlDiscosDuros.SelectedItem.Value),
                    //    cpacidadeDiscos,
                    //    txtNombreServidor.Text,
                    //    txtDireccionIP.Text);
                }

                CambiaEstadoNotificacion("Info", true, sMensaje);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                LimpiarCampos(false);
                LabelInfo.Focus();
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
            }
        }

        protected void CargaValores()
        {
            Params.idItem = 0;
            Params.noSerie = txtNoSerie.Text;
            Params.idTipoEquipo = Convert.ToInt32(ddlTipoArticulo.SelectedValue);
            Params.idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            Params.modelo = txtModelo.Text;
            //Params.idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
            //Params.factura = txtFactura.Text;
            //Params.fechaCompra = txtFechaCompra.Text;
            //Params.requisicion = txtRequisicion.Text;
            //Params.centroCostosAdquisicion = txtCCadquisicion.Text;
            //Params.responsiva = txtResponsiva.Text;
            //Params.valorPesos = Convert.ToDouble(txtValorPesos.Text);
            //Params.valorUSD = Convert.ToDouble(txtValorDolares.Text);
            Params.stock = string.Empty;
            //Params.codigoCastor = txtNoCastor.Text;
            //Params.idUsuario = Convert.ToInt32(ddlUsuarioAsignado.SelectedValue);
            Params.idUbicacion = Convert.ToInt32(ddlUbicacion.SelectedValue);
            Params.idEstado = Convert.ToInt32(ddlEstado.SelectedValue);
            Params.observacion1 = txtObservaciones.Text;
            Params.observacion2 = string.Empty;
            Params.observacion3 = string.Empty;
            Params.posibleFaltanteFlag = false;
            //Params.cambioRYS = txtCambioRYS.Text;
            Params.fechaMovimiento = DateTime.Today;

            //switch (Convert.ToInt16(Session["isServer"]))
            //{
            //    case 1:
            //        obDetalleServidor.idItem = Params.idItem;
            //        obDetalleServidor.cantidadProcesadores = Convert.ToInt32(ddlProcesadores.SelectedValue);
            //        obDetalleServidor.tipoProcesador = txtTipoProcesadores.Text;
            //        Params.idSistema = Convert.ToInt32(ddlSistemaOperativo.SelectedValue);
            //    case 2:
            //        Params.ram = txtMemoria.Text;
            //        Params.procesador = txtProcesador.Text;
            //        Params.discoDuro = txtDiscoDuro.Text;
            //        Params.idSistema = Convert.ToInt32(ddlSistemaOperativo.SelectedValue);
            //    case "NOTEBOOK":
            //    case "MAC BOOK":
            //        Params.discoDuro = txtDiscoDuro.Text;
            //        Params.procesador = txtProcesador.Text;
            //            default:
            //        break;
            //}
        }

        protected void LimpiarCampos(bool LimpiarMsj)
        {
            txtNoSerie.Text = string.Empty;
            txtNoSerie.Enabled = true;

            if (LimpiarMsj)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
            }

            if (ddlTipoArticulo.Items.Count > 0)
                ddlTipoArticulo.SelectedIndex = 0;

            if (ddlMarca.Items.Count > 0)
                ddlMarca.SelectedIndex = 0;

            if (ddlEstado.Items.Count > 0)
                ddlEstado.SelectedIndex = 0;

            //if (ddlSistemaOperativo.Items.Count > 0)
            //    ddlSistemaOperativo.SelectedIndex = 0;

            //if (ddlProcesadores.Items.Count > 0)
            //    ddlProcesadores.SelectedIndex = 0;

            //if (ddlDiscosDuros.Items.Count > 0)
            //    ddlDiscosDuros.SelectedIndex = 0;

            if (ddlUbicacion.Items.Count > 0)
                ddlUbicacion.SelectedIndex = 0;

            txtModelo.Text = "";
            //txtMemoria.Text = "";
            //txtProcesador.Text = "";
            //txtDiscoDuro.Text = "";
            //txtNombreServidor.Text = "";
            //txtDireccionIP.Text = "";
            //txtTipoProcesadores.Text = "";
            txtRegion.Text = "";
            txtObservaciones.Text = "";

            radioCon.Checked = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(true);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        //private void LLenaCombosprocesador()
        //{
        //    for (int i = 0; i < 21; i++)
        //    {
        //        ddlProcesadores.Items.Add(i.ToString());
        //        //ddlDiscosDuros.Items.Add(i.ToString());
        //    }
        //}

        //private void LLenaCombosDiscos()
        //{
        //    for (int i = 0; i < 11; i++)
        //    {
        //        //ddlProcesadores.Items.Add(i.ToString());
        //        ddlDiscosDuros.Items.Add(i.ToString());
        //    }
        //}

        private void GeneraControles(int numeroControles)
        {
            if (numeroControles != 0)
            {
                for (int i = 3; i < (3 + numeroControles); i++)
                {
                    TableRow tRow = new TableRow();

                    TableCell tCell1 = new TableCell();
                    tCell1.HorizontalAlign = HorizontalAlign.Right;
                    TableCell tCell2 = new TableCell();
                    tCell1.HorizontalAlign = HorizontalAlign.Left;
                    Label lblDiscoTamanio = new Label();
                    lblDiscoTamanio.ID = "lblDiscoTamanio" + i;
                    lblDiscoTamanio.Text = "Tamaño disco " + (i - 2) + ":";
                    TextBox txtTamDisco2 = new TextBox();
                    txtTamDisco2.ID = "txtTamDisco" + i;
                    txtTamDisco2.Text = "";
                    txtTamDisco2.Width = 120;
                    RequiredFieldValidator rfvKeyD2 = new RequiredFieldValidator();
                    rfvKeyD2.Display = ValidatorDisplay.None;
                    rfvKeyD2.SetFocusOnError = true;
                    rfvKeyD2.ControlToValidate = "txtTamDisco" + i;
                    rfvKeyD2.ErrorMessage = "El campo \"" + "Tamaño disco " + (i - 2) + "\" es requerido";
                    rfvKeyD2.ValidationGroup = "vgGuardaRegistroArticulo";
                    rfvKeyD2.CssClass = "label";
                    rfvKeyD2.ID = "rfvTamDisco" + i;

                    ValidatorCalloutExtender vceKeyD2 = new ValidatorCalloutExtender();
                    vceKeyD2.ID = "vceTamDisco" + i;
                    vceKeyD2.TargetControlID = "rfvTamDisco" + i;

                    tCell1.Controls.Add(lblDiscoTamanio);
                    tCell2.Controls.Add(txtTamDisco2);
                    tCell2.Controls.Add(rfvKeyD2);
                    tCell2.Controls.Add(vceKeyD2);

                    TableCell tCell3 = new TableCell();
                    TableCell tCell4 = new TableCell();

                    tRow.Controls.Add(tCell1);
                    tRow.Controls.Add(tCell2);
                    tRow.Controls.Add(tCell3);
                    tRow.Controls.Add(tCell4);
                    //tblDetalleServidor.Controls.AddAt(i, tRow);
                }
            }
        }

        //protected void ddlDiscosDuros_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GeneraControles(Convert.ToInt32(ddlDiscosDuros.SelectedValue));
        //    hdnGeneracionDeControles.Value = "1";
        //}

        protected void ddlTipoArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlTipoArticulo.SelectedItem.ToString())
            {
                case "CONTROLADORA":
                case "STORAGE":
                case "SERVIDOR":
                    //Panel1.Visible = true;
                    // lblDiscoDuroPC.Visible = false;
                    //txtDiscoDuro.Visible = false;
                    //lblProcePC.Visible = false;
                    //txtProcesador.Visible = false;
                    //pnlDetallePCServidor.Visible = true;
                    //tblDetalleServidor.Visible = true;
                    Session["isServer"] = 1;
                    //hdnGeneracionDeControles.Value = "1";
                    break;

                case "PC":
                case "NOTEBOOK":
                case "MAC BOOK":
                    //Panel1.Visible = true;
                    //pnlDetallePCServidor.Visible = true;
                    //lblDiscoDuroPC.Visible = true;
                    //txtDiscoDuro.Visible = true;
                    //lblProcePC.Visible = true;
                    //txtProcesador.Visible = true;
                    //tblDetalleServidor.Visible = false;
                    //hdnGeneracionDeControles.Value = "0";
                    Session["isServer"] = 2;
                    break;

                default:
                    //Panel1.Visible = false;
                    //pnlDetallePCServidor.Visible = false;
                    //lblDiscoDuroPC.Visible = false;
                    //txtDiscoDuro.Visible = false;
                    //lblProcePC.Visible = false;
                    //txtProcesador.Visible = false;
                    //tblDetalleServidor.Visible = false;
                    Session["isServer"] = 0;
                    //hdnGeneracionDeControles.Value = "0";
                    break;
            }
        }

        protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLCatalogos oblCatalogos = new BLCatalogos();
                txtRegion.Text = oblCatalogos.ObtieneRegion(Convert.ToInt32(ddlUbicacion.SelectedValue));
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
            }
        }

        public void CambiaEstadoNotificacion(string TipoEtiqueta, bool Accion, string Mensaje)
        {
            if (TipoEtiqueta == "Warning")
            {
                Warning.Visible = Accion;
                LabelError.Visible = Accion;
                LabelError.Font.Size = 10;
                LabelError.Text = Mensaje;
            }
            else
            {
                Info.Visible = Accion;
                LabelInfo.Visible = Accion;
                LabelInfo.Font.Size = 10;
                LabelInfo.Text = Mensaje;
            }
        }

        protected void radioSN_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSN.Checked)
            {
                txtNoSerie.Enabled = false;
                txtNoSerie.Text = "S/N";
                chkIgnorarSerie.Visible = true;
                chkIgnorarSerie.Checked = true;
            }
        }

        protected void radioIlegible_CheckedChanged(object sender, EventArgs e)
        {
            if (radioIlegible.Checked)
            {
                txtNoSerie.Enabled = false;
                txtNoSerie.Text = "ILEGIBLE";
                chkIgnorarSerie.Visible = true;
                chkIgnorarSerie.Checked = true;
            }
        }

        protected void radioCon_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCon.Checked)
            {
                txtNoSerie.Text = string.Empty;
                txtNoSerie.Enabled = true;
                chkIgnorarSerie.Visible = false;
                chkIgnorarSerie.Checked = false;
            }
        }
    }
}