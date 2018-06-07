using System;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC
{
    public partial class ConsultaArticulo : System.Web.UI.Page
    {
        public Articulo objectArticulo = new Articulo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Warning.Visible = false;
                Info.Visible = false;
                hdnParametros.Value = Request.QueryString["idItem"];
                CargaCatalogos();

                if (Request.QueryString["idItem"] != null)
                {
                    hddAuto.Value = "0";
                    hdnParametros.Value = Request.QueryString["idItem"];
                    pnlPagina.Visible = true;

                    if (Request.QueryString["Auto"] != null)
                        hddAuto.Value = Request.QueryString["Auto"];

                    if (hdnParametros.Value == "0")
                    {
                        txtParametroBusqueda.Text = string.Empty;
                    }
                    else
                    {
                        txtParametroBusqueda.Text = hdnParametros.Value;
                        fnBuscaArticuloporID();
                    }

                    if (hddAuto.Value == "1")
                        Editar();
                }
                else
                {
                    Warning.Visible = true;
                    LabelError.Text = "No hay parámetros suficientes para cargar la página";
                    pnlPagina.Visible = false;
                    Response.Redirect("BusquedaArticulo.aspx", false);
                }
            }
        }

        public void CargaCatalogos()
        {
            BLCatalogos oblCatalogos = new BLCatalogos();

            oblCatalogos.CargaTipoEquipo(ref ddlTipoArticulo);
            ddlTipoArticulo.DataBind();

            oblCatalogos.CargaMarca(ref ddlMarca);
            ddlMarca.DataBind();

            oblCatalogos.CargaSistemaOperativo(ref ddlSistemaOperativo);
            ddlSistemaOperativo.DataBind();

            oblCatalogos.CargaProveedor(ref ddlProveedor);
            ddlProveedor.DataBind();

            oblCatalogos.CargaUsuario(ref ddlUsuarioAsignado);
            ddlUsuarioAsignado.DataBind();

            oblCatalogos.CargaUbicacion(ref ddlUbicacion);
            ddlUbicacion.DataBind();

            oblCatalogos.CargaEstado(ref ddlEstado);
            ddlEstado.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            fnBuscaArticuloporSerie();
        }

        protected void fnBuscaArticuloporSerie()
        {
            BLArticulo bloArticulo = new BLArticulo();
            objectArticulo = bloArticulo.BuscarArticuloPorSerie(txtParametroBusqueda.Text);
            LlenaControles();
        }

        protected void fnBuscaArticuloporID()
        {
            BLArticulo bloArticulo = new BLArticulo();
            objectArticulo = bloArticulo.BuscaArticuloPorID(Convert.ToInt64(hdnParametros.Value));
            LlenaControles();
        }

        protected void LlenaControles()
        {
            txtParametroBusqueda.Text = objectArticulo.noSerie;
            hdnParametros.Value = objectArticulo.idItem.ToString();
            txtNoSerie.Text = objectArticulo.noSerie;
            ddlTipoArticulo.SelectedValue = objectArticulo.idTipoEquipo.ToString();
            ddlMarca.SelectedValue = objectArticulo.idMarca.ToString();
            txtModelo.Text = objectArticulo.modelo;
            txtProcesador.Text = objectArticulo.procesador;
            txtMemoria.Text = objectArticulo.ram;
            ddlSistemaOperativo.SelectedValue = objectArticulo.idSistema.ToString();
            txtDiscoDuro.Text = objectArticulo.discoDuro;
            ddlProveedor.SelectedValue = objectArticulo.idProveedor.ToString();
            txtFactura.Text = objectArticulo.factura;
            txtFechaCompra.Text = objectArticulo.fechaCompra;
            txtRequisicion.Text = objectArticulo.requisicion;
            txtCCadquisicion.Text = objectArticulo.centroCostosAdquisicion;
            txtResponsiva.Text = objectArticulo.responsiva.ToString();
            txtValorPesos.Text = objectArticulo.valorPesos.ToString();
            txtValorDolares.Text = objectArticulo.valorUSD.ToString();
            txtNoCastor.Text = objectArticulo.codigoCastor;
            ddlUbicacion.SelectedValue = objectArticulo.idUbicacion.ToString();
            ddlEstado.SelectedValue = objectArticulo.idEstado.ToString();
            txtObservaciones.Text = objectArticulo.observacion1;
            txtCambioRYS.Text = objectArticulo.cambioRYS;

            if (objectArticulo.idUsuario > 0 && objectArticulo.idUsuario != BLArticulo.UsuarioNoAsignado)
                ddlUsuarioAsignado.SelectedValue = objectArticulo.idUsuario.ToString();
        }

        protected void Editar()
        {
            if (btnAccion.Text == "Editar")
            {
                fnActivaControles(true);
                btnAccion.Text = "Guardar";
            }
            else
            {
                btnAccion.Text = "Editar";
                fnActivaControles(false);
                string sMensaje = string.Empty;
                CargaValores();
                try
                {
                    BLArticulo oblArticulo = new BLArticulo(objectArticulo);
                    sMensaje = oblArticulo.actualizaArticulo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                string Clientscript = "<script>alert(' " + sMensaje + "')</script>";

                if (!this.IsStartupScriptRegistered("Alertas"))
                {
                    this.RegisterStartupScript("Alertas", Clientscript);
                }
            }
        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
            Editar();
        }

        protected void CargaValores()
        {
            int? respon = null;
            int responsi;

            if (!string.IsNullOrEmpty(txtResponsiva.Text.Trim()))
                int.TryParse(txtResponsiva.Text, out responsi);
            else
                responsi = 0;

            if (responsi != 0)
                respon = responsi;

            objectArticulo.idItem = Convert.ToInt64(hdnParametros.Value);
            objectArticulo.noSerie = txtNoSerie.Text;
            objectArticulo.idTipoEquipo = Convert.ToInt32(ddlTipoArticulo.SelectedValue);
            objectArticulo.idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            objectArticulo.modelo = txtModelo.Text;
            objectArticulo.procesador = txtProcesador.Text;
            objectArticulo.ram = txtMemoria.Text;
            objectArticulo.idSistema = Convert.ToInt32(ddlSistemaOperativo.SelectedValue);
            objectArticulo.discoDuro = txtDiscoDuro.Text;
            objectArticulo.idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
            objectArticulo.factura = txtFactura.Text;
            objectArticulo.fechaCompra = txtFechaCompra.Text;
            objectArticulo.requisicion = txtRequisicion.Text;
            objectArticulo.centroCostosAdquisicion = txtCCadquisicion.Text;
            objectArticulo.responsiva = respon;
            objectArticulo.valorPesos = Convert.ToDouble(txtValorPesos.Text);
            objectArticulo.valorUSD = Convert.ToDouble(txtValorDolares.Text);
            objectArticulo.stock = string.Empty;
            objectArticulo.codigoCastor = txtNoCastor.Text;
            objectArticulo.idUsuario = Convert.ToInt32(ddlUsuarioAsignado.SelectedValue);
            objectArticulo.idUbicacion = Convert.ToInt32(ddlUbicacion.SelectedValue);
            objectArticulo.idEstado = Convert.ToInt32(ddlEstado.SelectedValue);
            objectArticulo.observacion1 = txtObservaciones.Text;
            objectArticulo.observacion2 = string.Empty;
            objectArticulo.observacion3 = string.Empty;
            objectArticulo.posibleFaltanteFlag = false;
            objectArticulo.cambioRYS = txtCambioRYS.Text;
            objectArticulo.fechaMovimiento = DateTime.Today;
        }

        public void fnActivaControles(bool bAcivado)
        {
            //txtNoSerie.Enabled = bAcivado;
            //ddlTipoArticulo.Enabled = bAcivado;
            ddlMarca.Enabled = bAcivado;
            txtModelo.Enabled = bAcivado;
            txtProcesador.Enabled = bAcivado;
            txtMemoria.Enabled = bAcivado;
            ddlSistemaOperativo.Enabled = bAcivado;
            txtDiscoDuro.Enabled = bAcivado;
            ddlProveedor.Enabled = bAcivado;
            txtFactura.Enabled = bAcivado;
            txtFechaCompra.Enabled = bAcivado;
            txtRequisicion.Enabled = bAcivado;
            txtCCadquisicion.Enabled = bAcivado;
            txtResponsiva.Enabled = bAcivado;
            txtValorPesos.Enabled = bAcivado;
            txtValorDolares.Enabled = bAcivado;
            txtNoCastor.Enabled = bAcivado;
            ddlUsuarioAsignado.Enabled = bAcivado;
            ddlUbicacion.Enabled = bAcivado;
            ddlEstado.Enabled = bAcivado;
            txtObservaciones.Enabled = bAcivado;
            txtCambioRYS.Enabled = bAcivado;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }
    }
}