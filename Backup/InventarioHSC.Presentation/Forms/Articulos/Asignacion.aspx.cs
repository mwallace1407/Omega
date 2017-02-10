using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;


namespace InventarioHSC
{
    public partial class Asignacion : System.Web.UI.Page
    {
        public BLArticulo bloArticulo = new BLArticulo();
        public List<Articulo> lstAgregar = new List<Articulo>();
        //public List<Articulo> lstQuitar = new List<Articulo>();
        //public List<Articulo> lstArticuloShow = new List<Articulo>();
        public BLResponsiva objectResponsiva = new BLResponsiva();
        public BLXLSResponsiva oDocResponsiva = new BLXLSResponsiva();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Warning.Visible = false;
                Info.Visible = false;
                Session["GridAdd"] = lstAgregar;
                CargaCatalogos();

                if (Request.QueryString["Saved"] != null && Request.QueryString["Responsiva"] != null)
                {
                    int valor = 0;

                    int.TryParse(Request.QueryString["Responsiva"].ToString(), out valor);

                    if (valor > 0)
                    {
                        txtResponsiva.Text = valor.ToString();
                        BuscarResponsiva();
                    }

                    int.TryParse(Request.QueryString["Saved"].ToString(), out valor);

                    if (valor == 2 && Request.QueryString["Err"] != null)
                        CambiaEstadoNotificacion("Warning", true, "Ha ocurrido un error al guardar la responsiva. " + Request.QueryString["Err"].ToString());

                    if (valor == 1)
                        CambiaEstadoNotificacion("Info", true, "La responsiva fue guardada correctamente.");
                }
            }

            Page.MaintainScrollPositionOnPostBack = false;
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

        protected void BuscarResponsiva()
        {
            txtNoSerie.Text = string.Empty;
            txtResponsiva.Enabled = true;
            ddlUsuarioAsignado.Enabled = true;
            pnlAsignacionActual.Visible = false;
            //fnLimpiaControlesMain();
            fnLimpiaControlDetalle();
            Session["GridAdd"] = null;
            gwvArticuloAsignado.DataBind();
            BLCatalogos oblCatalogos = new BLCatalogos();
            Articulo oArticulo = new Articulo();
            ArticuloHeader oArticuloHeader = new ArticuloHeader();
            List<Articulo> olstArticulo = new List<Articulo>();
            List<Articulo> olstArticuloHeader = new List<Articulo>();
            //btnBuscarResponsiva.Visible = false;
            //txtResponsiva.Enabled = false;

            try
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);


                if (!ddlUsuarioAsignado.SelectedItem.Value.Equals("1191"))
                {
                    ArrayList oParams = new ArrayList();
                    oParams.Add(string.Empty);
                    oParams.Add(txtResponsiva.Text);
                    oParams.Add(ddlUsuarioAsignado.SelectedItem.Value);
                    oParams.Add(0);
                    oParams.Add(0);

                    olstArticulo = bloArticulo.BuscaArticuloFitradoA(oParams);

                    if (olstArticulo.Count > Convert.ToInt16(Constantes.CantidadElementos.Vacio))
                    {
                        txtResponsiva.Text = olstArticulo[0].responsiva.ToString();
                    }
                    else
                    {
                        txtResponsiva.Enabled = true;
                        CambiaEstadoNotificacion("Info", true, "La responsiva buscada no existe.");
                        CambiaEstadoNotificacion("Warning", false, string.Empty);
                    }
                }
                else
                {
                    olstArticulo = bloArticulo.BuscarArticuloporResponsiva(txtResponsiva.Text);
                }

                olstArticuloHeader = ObtieneOrigenGridResponsiva();

                lstAgregar = olstArticuloHeader;
                Session["GridAdd"] = lstAgregar;

                if (olstArticulo.Count > Convert.ToInt16(Constantes.CantidadElementos.Vacio))
                {
                    txtResponsiva.Enabled = false;
                    pnlAsignacionActual.Visible = true;
                    LabelInfo.Text = "";
                    Info.Visible = false;
                    ddlUsuarioAsignado.SelectedValue = olstArticulo[0].idUsuario.ToString();
                    txtPuesto.Text = oblCatalogos.ObtienePuesto
                        (olstArticulo[0].idUsuario.HasValue ? olstArticulo[0].idUsuario.Value : 0);
                    ddlUbicacion.SelectedValue = olstArticulo[0].idUbicacion.ToString();
                    txtObservaciones.Text = olstArticulo[0].ObservacionesResponsiva;
                    txtRegion.Text = oblCatalogos.ObtieneRegion(olstArticulo[0].idUbicacion);

                    gwvArticuloAsignado.DataSource = olstArticuloHeader;
                    gwvArticuloAsignado.DataBind();

                    ddlTipoArticulo.Enabled = true;
                    ddlMarca.Enabled = true;
                    txtModelo.Enabled = true;
                    dplUbicacionFiltro.Enabled = true;

                    btnBuscarArticulo.Enabled = true;
                    btnDocumento.Enabled = true;
                }
                else
                {
                    CambiaEstadoNotificacion("Info", true, "La responsiva buscada no existe.");
                    CambiaEstadoNotificacion("Warning", false, string.Empty);
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
            }
        }

        protected void btnBuscarResponsiva_Click(object sender, EventArgs e)
        {
            BuscarResponsiva();
        }

        protected void btnRegresarDetalle_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["idSelectedSess"] = null;
            mpeBusquedaArticulo.Hide();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            List<int> lista = (List<int>)HttpContext.Current.Session["idSelectedSess"];
            List<int> ListaTotal = new List<int>();

            try
            {
                foreach (GridViewRow gr in grvFiltroArticulos.Rows)
                {
                    CheckBox chkSeleccionado = (CheckBox)gr.Cells[0].FindControl("chkSelecciona");

                    if (chkSeleccionado.Checked)
                        ListaTotal.Add(Convert.ToInt32(grvFiltroArticulos.DataKeys[gr.RowIndex].Value));
                }

                if (lista != null)
                    ListaTotal.AddRange(lista);

                foreach (GridViewRow item in gwvArticuloAsignado.Rows)
                {
                    int idItem = Convert.ToInt32(gwvArticuloAsignado.DataKeys[item.RowIndex].Value);

                    if (ListaTotal.Contains(idItem))
                    {
                        ListaTotal.Remove(idItem);
                    }
                }

                foreach (int item in ListaTotal)
                {
                    Articulo oFindArticulo = new Articulo();
                    BLArticulo oblArticulo = new BLArticulo();
                    oFindArticulo = oblArticulo.BuscaArticuloPorID(item);
                    List<Articulo> oFindArticuloHeader = new List<Articulo>();

                    Articulo objectArticulo = new Articulo();

                    lstAgregar = (List<Articulo>)Session["GridAdd"];

                    if (lstAgregar != null)
                        lstAgregar.Add(oFindArticulo);
                    else
                    {
                        lstAgregar = new List<Articulo>();
                        lstAgregar.Add(oFindArticulo);
                    }

                    Session["GridAdd"] = lstAgregar;
                }

                ActualizaGrid();
                fnLimpiaControlDetalle();

                mpeBusquedaArticulo.Hide();
                HttpContext.Current.Session["idSelectedSess"] = null;
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
                mpeBusquedaArticulo.Hide();
                HttpContext.Current.Session["idSelectedSess"] = null;
            }
        }

        protected void grvFiltroArticulos_PageIndexChanged(object sender, EventArgs e)
        {
            SelectionManager.RestoreSelection((GridView)sender);
        }

        protected void grvFiltroArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<Articulo> oFindArticulo = new List<Articulo>();
            BLArticulo oblArticulo = new BLArticulo();
            int idMarca = ddlMarca.Items.Count == 0 ? 0 : Convert.ToInt32(ddlMarca.SelectedItem.Value);

            oFindArticulo =
                oblArticulo.getFiltroArticulo
                (Convert.ToInt32(ddlTipoArticulo.SelectedItem.Value),
                    idMarca,
                    Convert.ToInt32(dplUbicacionFiltro.SelectedItem.Value),
                    txtModelo.Text,
                    txtNoSerie.Text);

            SelectionManager.KeepSelection((GridView)sender);

            grvFiltroArticulos.DataSource = oFindArticulo;
            grvFiltroArticulos.PageIndex = e.NewPageIndex;
            grvFiltroArticulos.DataBind();
        }

        protected void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            CambiaEstadoNotificacion("Info", false, string.Empty);
            CambiaEstadoNotificacion("Warning", false, string.Empty);

            List<Articulo> oFindArticulo = new List<Articulo>();
            BLArticulo oblArticulo = new BLArticulo();
            int idMarca = ddlMarca.Items.Count == 0? 0: Convert.ToInt32(ddlMarca.SelectedItem.Value);

            oFindArticulo = 
                oblArticulo.getFiltroArticulo
                (Convert.ToInt32(ddlTipoArticulo.SelectedItem.Value),
                    idMarca,
                    Convert.ToInt32(dplUbicacionFiltro.SelectedItem.Value),
                    txtModelo.Text,
                    txtNoSerie.Text,
                    chkSN.Checked,
                    chkIlegible.Checked);

            // TODO: Poner Validaciones de Negocio
            // - que serie exista
            // - que serie que no exista ya asignada a esa responsiva
            // - Que no esté en una ubicación no permitida (Salida por Venta, Sotano 3, Mal estado)
            string sMensajeValidacion = string.Empty;

            //if (oFindArticulo.idItem != null && oFindArticulo.idItem != Convert.ToInt16(Constantes.CantidadElementos.Vacio))
            //{

            if (oFindArticulo.Count > 0)
            {
                grvFiltroArticulos.DataSource = oFindArticulo;
                grvFiltroArticulos.DataBind();
                mpeBusquedaArticulo.Show();
            }
            else
            {
                CambiaEstadoNotificacion("Info", true, "No se encontraron artículos con los filtro seleccionados.");
                CambiaEstadoNotificacion("Warning", false, string.Empty);
            }

            //foreach (Articulo item in oFindArticulo)
            //{
            //    Validacion val = fnValidacionSerie(item);
            //    if (val.validate)
            //    {
            //        txtidItem.Text = item.idItem.ToString();
            //        ddlTipoArticulo.SelectedValue = item.idTipoEquipo.ToString();
            //        ddlMarca.SelectedValue = item.idMarca.ToString();
            //        txtModelo.Text = item.modelo.ToString();
            //        //ddlEstado.SelectedValue = oFindArticulo.idEstado.ToString();
            //        //txtProcesador.Text = oFindArticulo.procesador.ToString();
            //        //txtMemoria.Text = oFindArticulo.ram.ToString();
            //        //ddlSistemaOperativo.SelectedValue = oFindArticulo.idSistema.ToString();
            //        //txtDiscoDuro.Text = oFindArticulo.discoDuro.ToString();
            //        //lbtnDetalle.Enabled = true;
            //        //btnAgregar.Visible = true;
            //        imgAgregar.Visible = true;
            //    }
            //    else
            //    {
            //        fnLimpiaControlDetalle();
            //        CambiaEstadoNotificacion("Info", true, val.message);
            //        CambiaEstadoNotificacion("Warning", false, string.Empty);
            //    } 
            //}
            //}
            //else
            //{
            //    CambiaEstadoNotificacion("Info", true, "El No. de Serie buscando no se encuentra.");
            //    CambiaEstadoNotificacion("Warning", false, string.Empty);
            //}
        }

        //protected void btnAgregar_Click(object sender, EventArgs e)
        //{

        //}
        
        protected void ActualizaGrid()
        {
            lstAgregar = (List<Articulo>)Session["GridAdd"];

            gwvArticuloAsignado.DataSource = lstAgregar;
            gwvArticuloAsignado.DataBind();
        }

        protected List<Articulo> ObtieneOrigenGridResponsiva()
        {
            //List<ArticuloHeader> oolstArticuloHeader = new List<ArticuloHeader>();
            ArrayList oParams = new ArrayList();
            oParams.Add(string.Empty);
            oParams.Add(txtResponsiva.Text);
            if (!ddlUsuarioAsignado.SelectedItem.Value.Equals("1191"))
                oParams.Add(Convert.ToInt32(ddlUsuarioAsignado.SelectedItem.Value));
            else
                oParams.Add(0);

            oParams.Add(0);
            oParams.Add(0);

            return bloArticulo.BuscaArticuloFitradoA(oParams);
        }

        protected List<Articulo> ObtieneOrigenGridResponsiva(string responsiva)
        {
            //List<ArticuloHeader> oolstArticuloHeader = new List<ArticuloHeader>();
            ArrayList oParams = new ArrayList();
            oParams.Add(string.Empty);
            oParams.Add(responsiva);
            oParams.Add(0);
            oParams.Add(0);
            oParams.Add(0);

            return bloArticulo.BuscaArticuloFitradoA(oParams);
        }

        protected List<Articulo> ObtieneElementoGridSerie()
        {
            //List<ArticuloHeader> oolstArticuloHeader = new List<ArticuloHeader>();
            ArrayList oParams = new ArrayList();
            oParams.Add(txtNoSerie.Text);
            oParams.Add(string.Empty);
            oParams.Add(0);
            oParams.Add(0);
            oParams.Add(0);

            return bloArticulo.BuscaArticuloFitradoA(oParams);
        }

        public void CargaCatalogos()
        {
            LabelInfo.Text = "";
            Info.Visible = false;
            LabelError.Text = "";
            Warning.Visible = false;

            BLCatalogos oblCatalogos = new BLCatalogos();

            oblCatalogos.CargaTipoEquipo(ref ddlTipoArticulo);
            ddlTipoArticulo.DataBind();

            //oblCatalogos.CargaMarca(ref ddlMarca);
            //ddlMarca.DataBind();

            oblCatalogos.CargaSistemaOperativo(ref ddlSistemaOperativo);
            ddlSistemaOperativo.DataBind();

            oblCatalogos.CargaUbicacion(ref ddlUbicacion);
            ddlUbicacion.DataBind();

            oblCatalogos.CargaUbicacionAsignacionResponsiva(ref dplUbicacionFiltro);
            dplUbicacionFiltro.DataBind();

            //oblCatalogos.CargaEstado(ref ddlEstado);
            //ddlEstado.DataBind();

            oblCatalogos.CargaUsuario(ref ddlUsuarioAsignado);
            ddlUsuarioAsignado.DataBind();

            oblCatalogos.CargaUsuario(ref ddlpopUser);
            ddlpopUser.DataBind();
        }

        protected void fnLimpiaControlesMain()
        {
            ddlUsuarioAsignado.SelectedValue= "1191";
            txtPuesto.Text = string.Empty;
        }

        protected void fnLimpiaControlDetalle()
        {
            txtidItem.Text = string.Empty;
            ddlTipoArticulo.SelectedValue = "0";
            dplUbicacionFiltro.SelectedIndex = 0;
            ddlMarca.SelectedValue = "0";
            txtModelo.Text = string.Empty;
            txtNoSerie.Text = string.Empty;
            //ddlEstado.SelectedValue = "0";
            txtProcesador.Text = string.Empty;
            txtMemoria.Text = string.Empty;
            ddlSistemaOperativo.SelectedValue = "0";
            txtDiscoDuro.Text = string.Empty;
            //lbtnDetalle.Enabled = false;
            imgAgregar.Visible = false;
        }

        protected void gvResponsivasAnteriores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[0].ToolTip = "Responsiva";
                        e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gvResponsivasAnteriores','Select$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
            }
        }

        protected void gvResponsivasAnteriores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridView dr = (GridView)sender;
                string responsi = dr.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                string responsiAntrerior = dr.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                List<Articulo> olstArticulo;

                //if(responsiAntrerior.Equals("Anterior"))
                //    olstArticulo = ObtieneOrigenGridResponsivaAnterior(responsi);
                //else
                olstArticulo = ObtieneOrigenGridResponsiva(responsi);

                Session["GridAdd"] = olstArticulo;

                ActualizaGrid();
            }
        }

        //private List<Articulo> ObtieneOrigenGridResponsivaAnterior(string responsi)
        //{
        //    bloArticulo = new BLArticulo();
        //    return bloArticulo.getResponsivaAnterior(responsi, Convert.ToInt32(ddlUsuarioAsignado.SelectedItem.Value));
        //}

        protected void gwvArticuloAsignado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[0].Attributes.Add("onmousemove", "this.style.cursor='hand';");
                        e.Row.Cells[0].Attributes.Add("onmouseleave", "this.style.cursor='default';");
                        e.Row.Cells[0].ToolTip = "Quitar Articulo";
                        
                        if(hdnNuevaResponsiva.Value.Equals("1"))
                            e.Row.Cells[0].Attributes.Add("OnClick", "javascript:__doPostBack('gwvArticuloAsignado','Eliminar$" + (e.Row.RowIndex).ToString().Trim() + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
            }
        }

        private void RemueveAtributoQuitarArticulo()
        {
            foreach (GridViewRow item in gwvArticuloAsignado.Rows)
            {
                item.Cells[0].Attributes.Remove("OnClick");
            }
        }

        protected void gwvArticuloAsignado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                lstAgregar = (List<Articulo>)Session["GridAdd"];

                if (lstAgregar == null)
                    lstAgregar = new List<Articulo>();

                int index = Convert.ToInt32(e.CommandArgument);
                string s_idItem = gwvArticuloAsignado.DataKeys[index].Values["idItem"].ToString();
                Articulo ArticuloAquitar = bloArticulo.BuscaArticuloPorID(Convert.ToInt64(s_idItem));
                lstAgregar.RemoveAll(x => x.idItem == ArticuloAquitar.idItem);
                
                Session["GridAdd"] = lstAgregar;

                ActualizaGrid();
            }
        }

        protected Validacion fnValidacionSerie(Articulo objArt)
        {
            Validacion oValida = new Validacion();

            oValida = BLValidaciones.ValidaArticuloDisponibilidad(objArt);
            oValida = BLValidaciones.ValidaAsignacion(objArt);

            lstAgregar = (List<Articulo>)Session["GridAdd"];

            if (lstAgregar != null)
            {
                foreach (Articulo item in lstAgregar)
                {
                    if (objArt.noSerie == item.noSerie)
                    {
                        oValida.validate = false;
                        oValida.message = "El Artículo con Serie " + objArt.noSerie + " ya está asignado a esa responsiva.";
                    }
                } 
            }

            return oValida;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }
            
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int? responsiva = null;
                int responsi;
                string NumeroResponsiva = string.Empty;

                if (!string.IsNullOrEmpty(txtResponsiva.Text.Trim()))
                    int.TryParse(txtResponsiva.Text, out responsi);
                else
                    responsi = 0;

                if (responsi != 0)
                    responsiva = responsi;

                lstAgregar = (List<Articulo>)Session["GridAdd"];

                string sFinalMsg = string.Empty;

                if (lstAgregar != null)
                {
                    List<Articulo> responsivasAnterioresList =
                            bloArticulo.getResponsivasAnteriores(Convert.ToInt32(ddlUsuarioAsignado.SelectedValue));

                    if (responsivasAnterioresList.Count > 0)
                        hdnResponsivaAnterior.Value = responsivasAnterioresList[0].ResponsivaAnterior;
                    else
                        hdnResponsivaAnterior.Value = "";

                    NumeroResponsiva = objectResponsiva.GeneraNoResponsiva();

                    foreach (Articulo ArAdd in lstAgregar)
                    {   
                        Articulo articuloHistorico = (Articulo)ArAdd.Clone();
                        ArAdd.idUbicacion = Convert.ToInt32(ddlUbicacion.SelectedValue);
                        ArAdd.idUsuario = Convert.ToInt32(ddlUsuarioAsignado.SelectedValue);
                        ArAdd.responsiva = Convert.ToInt32(NumeroResponsiva);
                        ArAdd.fechaMovimiento = DateTime.Now;
                        ArAdd.ObservacionesResponsiva = txtObservaciones.Text;
                        bloArticulo.actualizaAsignacion(ArAdd);
                        articuloHistorico.IdUsuarioNuevo = Convert.ToInt32(ddlUsuarioAsignado.SelectedItem.Value);
                        bloArticulo.InsertArticuloHistorico(articuloHistorico);
                    }

                    if (lstAgregar.Count > 0)
                    {
                        if (!hdnResponsivaAnterior.Value.Equals(""))
                        {
                            List<Articulo> anteriores = bloArticulo.getResponsivaAnterior
                                (Convert.ToInt32(hdnResponsivaAnterior.Value), Convert.ToInt32(ddlUsuarioAsignado.SelectedItem.Value));

                            foreach (Articulo item in anteriores)
                            {
                                Articulo articuloHistoricov = (Articulo)item.Clone();
                                item.idUsuario = null;
                                item.responsiva = 5000;
                                item.observacion1 = "";
                                item.observacion2 = "";
                                item.observacion3 = "";
                                item.ObservacionesResponsiva = "";
                                item.idUbicacion = 72; //Enviado al SAT
                                bloArticulo.actualizaAsignacion(item);
                                articuloHistoricov.IdUsuarioNuevo = null;
                                bloArticulo.InsertArticuloHistorico(articuloHistoricov);
                            }

                            hdnResponsivaAnterior.Value = "";
                        }

                        txtResponsiva.Text = NumeroResponsiva;
                    }
                    else
                    {
                        mpeLiberacionArticulos.Show();
                    }
                }
                else
                {
                    mpeLiberacionArticulos.Show();
                }

                int ValidaRes = 0;

                int.TryParse(txtResponsiva.Text, out ValidaRes);

                if (ValidaRes > 0 && lstAgregar.Count == 0)
                    LiberarTodos();

                if (lstAgregar != null && lstAgregar.Count > 0)
                {
                    sFinalMsg = "Se actualizó la información de la responsiva correspondiente.";
                    CambiaEstadoNotificacion("Info", true, sFinalMsg);
                    CambiaEstadoNotificacion("Warning", false, string.Empty);
                    LabelInfo.Focus();

                    btnDocumento.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnBuscarArticulo.Enabled = false;
                    ddlUbicacion.Enabled = false;
                    gvResponsivasAnteriores.Enabled = false;
                    RemueveAtributoQuitarArticulo();
                }
            }
            catch (Exception ex)
            {
                //CambiaEstadoNotificacion("Info", false, string.Empty);
                //CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                //LabelError.Focus();
                Response.Redirect("~/Forms/Articulos/Asignacion.aspx?Saved=2&Err=" + ex.Message);
            }

            Response.Redirect("~/Forms/Articulos/Asignacion.aspx?Saved=1&Responsiva=" + txtResponsiva.Text);
        }

        protected void btnCancelarLiberacion_Click(object sender, EventArgs e)
        {
            mpeLiberacionArticulos.Hide();
        }

        protected void LiberarTodos()
        {
            try
            {
                int? responsiva = null;
                int responsi;

                if (!string.IsNullOrEmpty(txtResponsiva.Text.Trim()))
                    int.TryParse(txtResponsiva.Text, out responsi);
                else
                    responsi = 0;

                if (responsi != 0)
                    responsiva = responsi;

                lstAgregar = (List<Articulo>)Session["GridAdd"];

                string sFinalMsg = string.Empty;


                List<Articulo> responsivasAnterioresList =
                        bloArticulo.getResponsivasAnteriores(Convert.ToInt32(ddlUsuarioAsignado.SelectedValue));

                if (responsivasAnterioresList.Count > 0)
                    hdnResponsivaAnterior.Value = responsivasAnterioresList[0].ResponsivaAnterior;
                else
                    hdnResponsivaAnterior.Value = "";

                if (!hdnResponsivaAnterior.Value.Equals(""))
                {
                    List<Articulo> anteriores = bloArticulo.getResponsivaAnterior
                        (Convert.ToInt32(hdnResponsivaAnterior.Value), Convert.ToInt32(ddlUsuarioAsignado.SelectedItem.Value));

                    foreach (Articulo item in anteriores)
                    {
                        Articulo articuloHistoricov = (Articulo)item.Clone();
                        item.idUsuario = null;
                        item.responsiva = 5000;
                        item.observacion1 = "";
                        item.observacion2 = "";
                        item.observacion3 = "";
                        item.ObservacionesResponsiva = "";
                        item.idUbicacion = 72; //Enviado al SAT
                        bloArticulo.actualizaAsignacion(item);
                        articuloHistoricov.IdUsuarioNuevo = null;
                        bloArticulo.InsertArticuloHistorico(articuloHistoricov);
                    }

                    hdnResponsivaAnterior.Value = "";
                }

                txtResponsiva.Text = string.Empty;
                btnDocumento.Enabled = false;

                sFinalMsg = "Se actualizó la información de la responsiva correspondiente.";
                CambiaEstadoNotificacion("Info", true, sFinalMsg);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                LabelInfo.Focus();

                btnDocumento.Enabled = false;
                btnGuardar.Enabled = false;
                btnBuscarArticulo.Enabled = false;
                ddlUbicacion.Enabled = false;
                gvResponsivasAnteriores.DataBind();
                gvResponsivasAnteriores.Enabled = false;
                RemueveAtributoQuitarArticulo();
                mpeLiberacionArticulos.Hide();
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
            }
        }

        protected void btnAceptarLineracion_Click(object sender, EventArgs e)
        {
            LiberarTodos();
        }

        protected void btnDocumento_Click1(object sender, EventArgs e)
        {
            string Path = @"~\Docs\Responsiva\";
            string NombreArc = "Responsiva_" + txtResponsiva.Text.Replace("/", "").Replace(".", "").Replace("-", "") + ".xlsx";
            //si no existe el directorio lo crea
            if (!System.IO.Directory.Exists(Server.MapPath(Path)))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(Path));
            }
            string sRutaArchivo = Server.MapPath(@"~\Docs\Responsiva\") + NombreArc;
            oDocResponsiva.CreatePackage(sRutaArchivo, txtResponsiva.Text);
            Response.Redirect("hdlDescargaExcel.ashx?sRuta=" + Server.MapPath(Path) + "&sNomArch=" + NombreArc); 
        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            CambiaEstadoNotificacion("Info", false, string.Empty);
            CambiaEstadoNotificacion("Warning", false, string.Empty);
            hdnResponsivaAnterior.Value = "";
            ddlTipoArticulo.Enabled = true;
            ddlTipoArticulo.SelectedIndex = 0;
            ddlTipoArticulo_SelectedIndexChanged(sender, e);
            ddlUbicacion.SelectedIndex = 0;
            txtRegion.Text = string.Empty;
            dplUbicacionFiltro.SelectedIndex = 0;
            dplUbicacionFiltro.Enabled = true;
            gvResponsivasAnteriores.Enabled = true;
            ddlpopUser.SelectedIndex = 0;
            txtNoSerie.Text = string.Empty;
            txtModelo.Enabled = true;
            chkIlegible.Checked = false;
            chkSN.Checked = false;
            gwvArticuloAsignado.DataBind();
            imgAgregar.Visible = true;
            btnBuscarArticulo.Visible = true;
            btnBuscarArticulo.Enabled = true;
            ddlUbicacion.Enabled = true;
            fnLimpiaControlDetalle();
            Session["GridAdd"] = null;
            btnGuardar.Enabled = true;
            btnBuscarArticulo.Enabled = true;
            hdnNuevaResponsiva.Value = "1";
            btnDocumento.Enabled = false;
            mpeAlert.Show();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                BLCatalogos oblCatalogos = new BLCatalogos();
                BLArticulo blArtivculo = new BLArticulo();
                BLUsuario blUsuario = new BLUsuario();
                Usuario usuario = new Usuario();
                ddlUsuarioAsignado.SelectedValue = ddlpopUser.SelectedValue;
                txtResponsiva.Enabled = false;
                ddlUsuarioAsignado.Enabled = false;
                usuario = blUsuario.ObtenUsuario(Convert.ToInt32(ddlUsuarioAsignado.SelectedItem.Value));
                txtResponsiva.Text = objectResponsiva.GeneraNoResponsiva();
                txtPuesto.Text = oblCatalogos.ObtienePuesto(usuario.idUsuario);
                List<Articulo> responsivasAnterioresList = blArtivculo.getResponsivasAnteriores(usuario.idUsuario);

                if (responsivasAnterioresList.Count > 0)
                    hdnResponsivaAnterior.Value = responsivasAnterioresList[0].ResponsivaAnterior;

                gvResponsivasAnteriores.DataSource = responsivasAnterioresList;
                gvResponsivasAnteriores.DataBind();
                mpeAlert.Hide();
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
                mpeAlert.Hide();
            }
        }

        protected void lbtnDetalle_Click(object sender, ImageClickEventArgs e)
        {
            mpeDetalle.Show();
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Articulo oFindArticulo = new Articulo();
                BLArticulo oblArticulo = new BLArticulo();
                oFindArticulo = oblArticulo.BuscarArticuloPorSerie(txtNoSerie.Text);
                List<Articulo> oFindArticuloHeader = new List<Articulo>();
                Articulo objectArticulo = new Articulo();
                Validacion objValidate = new Validacion();
                BLValidaciones objValidaciones = new BLValidaciones();

                objValidate = BLValidaciones.ValidaAsignacion(oFindArticulo);

                if (objValidate.validate)
                {
                    lstAgregar = (List<Articulo>)Session["GridAdd"];
                    oFindArticuloHeader = ObtieneElementoGridSerie();
                    lstAgregar.Add(oFindArticuloHeader[0]);
                    lstAgregar.Add(oblArticulo.BuscarArticuloPorSerie(oFindArticuloHeader[0].noSerie));
                    Session["GridAdd"] = lstAgregar;
                    ActualizaGrid();
                    txtNoSerie.Text = string.Empty;
                    fnLimpiaControlDetalle();
                }
                else
                {
                    CambiaEstadoNotificacion("Info", true, objValidate.message);
                    CambiaEstadoNotificacion("Warning", false, string.Empty);
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
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

        protected void ddlTipoArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!ddlTipoArticulo.SelectedItem.Value.Equals("0"))
            {
                ddlMarca.Items.Clear();
                ddlMarca.Items.Add(new ListItem("","0"));
                ddlMarca.Enabled = true;
                BLCatalogos blCatalogos = new BLCatalogos();
                blCatalogos.CargaMarcaporTipoEquipo(ref ddlMarca,Convert.ToInt32(ddlTipoArticulo.SelectedItem.Value));
            }
            else
            {
                ddlMarca.SelectedIndex = 0;
                ddlMarca.Enabled = false;
            }
        }
    }
}