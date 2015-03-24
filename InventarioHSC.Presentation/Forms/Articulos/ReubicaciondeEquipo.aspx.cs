using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC
{
    public partial class ReubicaciondeEquipo : System.Web.UI.Page
    {
        public BLArticulo oblArticulo = new BLArticulo();
        List<Articulo> lstAgregar = new List<Articulo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Warning.Visible = false;
                Info.Visible = false;
                CargaCatalogos();
                divResultado.Visible = false;
                Session["GridAdd2"] = null;
            }
        }

        public void CargaCatalogos()
        {
            BLCatalogos oblCatalogos = new BLCatalogos();

            oblCatalogos.CargaTipoEquipo(ref ddlTipoArticulo);
            ddlTipoArticulo.DataBind();

            oblCatalogos.CargaUsuarioBusca(ref ddlUsuario);
            ddlUsuario.DataBind();

            oblCatalogos.CargaUbicacion(ref ddlUbicacion);
            ddlUbicacion.DataBind();

            oblCatalogos.CargaUbicacionBodegas(ref ddlUbicacionDestino);
            ddlUbicacionDestino.DataBind();

        }
        //no serie Usuario ubicación tipo equipo
        protected void chklstFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ubicación 
            if (chklstFiltros.Items[0].Selected)
            {
                ddlUbicacion.Enabled = true;
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                CambiaEstadoNotificacion("Info", false, string.Empty);
            }
            else
            {
                ddlUbicacion.Enabled = false;
                ddlUbicacion.SelectedIndex = 0;
            }

            //Usuario 
            if (chklstFiltros.Items[1].Selected)
            {
                ddlUsuario.Enabled = true;
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                CambiaEstadoNotificacion("Info", false, string.Empty);
            }
            else
            {
                ddlUsuario.Enabled = false;
                ddlUsuario.SelectedIndex = 0;
            }

            //tipo equipo
            if (chklstFiltros.Items[2].Selected)
            {
                ddlTipoArticulo.Enabled = true;
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                CambiaEstadoNotificacion("Info", false, string.Empty);
            }
            else
            {
                ddlTipoArticulo.Enabled = false;
                ddlTipoArticulo.SelectedValue = "0";
            }

            //no serie
            if (chklstFiltros.Items[3].Selected)
            {
                txtNoSerie.Enabled = true;
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                CambiaEstadoNotificacion("Info", false, string.Empty);
            }
            else
            {
                txtNoSerie.Enabled = false;
                txtNoSerie.Text = string.Empty;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["idSelectedSess"] = null;
            ArrayList Params = new ArrayList();

            pnlTotales.Visible = false;
            pnlReasignacion.Visible = false;

            if (chklstFiltros.Items[0].Selected || chklstFiltros.Items[1].Selected || chklstFiltros.Items[2].Selected || chklstFiltros.Items[3].Selected)
            {
                if (chklstFiltros.Items[0].Selected && ddlUbicacion.SelectedItem.Text.Trim() == string.Empty)
                {
                    CambiaEstadoNotificacion("Warning", true, "Se requiere seleccionar una ubicación Válida.");
                    return;
                }
                if (chklstFiltros.Items[1].Selected && ddlUsuario.SelectedItem.Text.Trim() == string.Empty)
                {
                    CambiaEstadoNotificacion("Warning", true, "Se debe seleccionar un usuario válido.");
                    return;
                }
                
                if (chklstFiltros.Items[2].Selected && ddlTipoArticulo.SelectedItem.Text.Trim() == string.Empty)
                {
                    CambiaEstadoNotificacion("Warning", true, "Se debe seleccionar un Tipo de Articulo válido.");
                    return;
                }
                if (chklstFiltros.Items[3].Selected && txtNoSerie.Text == string.Empty)
                {
                    CambiaEstadoNotificacion("Warning", true, "Se debe escribir al menos un Número de Serie.");
                    return;
                }

                Params.Add(txtNoSerie.Text.Replace("\r\n", " ").Trim());
                Params.Add(string.Empty);
                Params.Add(chklstFiltros.Items[1].Selected ? Convert.ToInt32(ddlUsuario.SelectedValue) : 0);
                Params.Add(chklstFiltros.Items[0].Selected ? Convert.ToInt32(ddlUbicacion.SelectedValue) : 0);
                Params.Add(chklstFiltros.Items[2].Selected ? Convert.ToInt32(ddlTipoArticulo.SelectedValue) : 0);

                List<Articulo> LISaRT = oblArticulo.BuscaArticuloFitradoA(Params);
                Session["GridAdd2"] = LISaRT;
                gvwArticulos.DataSource = LISaRT;
                gvwArticulos.DataBind();

                if (gvwArticulos.Rows.Count > 0)
                {
                    divResultado.Visible = true;
                    pnlTotales.Visible = true;
                    pnlReasignacion.Visible = true;
                }

                grvTotalGeneral.DataSource = oblArticulo.BuscaTotal(Params, 1);
                grvTotalGeneral.DataBind();

                grvTotalUbicacion.DataSource = oblArticulo.BuscaTotal(Params, 2);
                grvTotalUbicacion.DataBind();

                grvTotalTipo.DataSource = oblArticulo.BuscaTotal(Params, 3);
                grvTotalTipo.DataBind();
            }
            else
            {
                CambiaEstadoNotificacion("Warning", true, "Es necesario seleccioar al menos un criterio de búsqueda");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void gvwArticulos_PageIndexChanged(object sender, EventArgs e)
        {
            SelectionManager.RestoreSelection((GridView)sender);
        }

        protected void gvwArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SelectionManager.KeepSelection((GridView)sender);

            ArrayList Params = new ArrayList();
            Params.Add(txtNoSerie.Text);
            Params.Add(string.Empty);
            Params.Add(chklstFiltros.Items[1].Selected ? Convert.ToInt32(ddlUsuario.SelectedValue) : 0);
            Params.Add(chklstFiltros.Items[0].Selected ? Convert.ToInt32(ddlUbicacion.SelectedValue) : 0);
            Params.Add(chklstFiltros.Items[2].Selected ? Convert.ToInt32(ddlTipoArticulo.SelectedValue) : 0);
            Params.Add(Convert.ToInt32(ddlTipoArticulo.SelectedValue));
            gvwArticulos.DataSource = oblArticulo.BuscaArticuloFitrado(Params);
            gvwArticulos.PageIndex = e.NewPageIndex;
            gvwArticulos.DataBind();
        }

        protected void btnReubicar_Click(object sender, EventArgs e)
        {
            try
            {
                BLResponsiva objectResponsiva = new BLResponsiva();
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", false, string.Empty);
                string ResponsivaAnterior = string.Empty;

                string sMensaje = string.Empty;
                List<int?> lstUsuario = new List<int?>();
                int cont = 0;

                foreach (GridViewRow gr in gvwArticulos.Rows)
                {
                    CheckBox chkSeleccionado = (CheckBox)gr.Cells[0].FindControl("chkSelecciona");

                    if (chkSeleccionado.Checked)
                    {
                        cont++;
                        BLArticulo objectArticulo = new BLArticulo();
                        string s_idImte = gvwArticulos.DataKeys[gr.RowIndex].Values["idItem"].ToString();
                        Articulo objArticulo = objectArticulo.BuscaArticuloPorID(Convert.ToInt64(s_idImte));
                        ResponsivaAnterior = objArticulo.responsiva.ToString();
                        Articulo articuloHistorico = new Articulo();
                        articuloHistorico = (Articulo)objArticulo.Clone();

                        if (articuloHistorico.idUsuario != null)
                            if (!lstUsuario.Contains(objArticulo.idUsuario))
                                lstUsuario.Add(objArticulo.idUsuario);

                        objArticulo.idUbicacion = Convert.ToInt32(ddlUbicacionDestino.SelectedValue);
                        objArticulo.idUsuario = null;
                        objArticulo.responsiva = 5000;
                        objArticulo.fechaMovimiento = DateTime.Now;

                        BLArticulo oblArticulo = new BLArticulo(objArticulo);
                        sMensaje = oblArticulo.actualizaArticulo();
                        articuloHistorico.IdUsuarioNuevo = null;
                        oblArticulo.InsertArticuloHistorico(articuloHistorico);

                        CambiaEstadoNotificacion("Info", true, "Los Artículos se reubicaron correctamente");
                        divResultado.Visible = false;
                        chklstFiltros.Items[0].Selected = false;
                        chklstFiltros.Items[1].Selected = false;
                        chklstFiltros.Items[2].Selected = false;
                        chklstFiltros.Items[3].Selected = false;
                        txtNoSerie.Text = string.Empty;
                        ddlUbicacion.SelectedItem.Text = "";
                        ddlTipoArticulo.SelectedItem.Text = "";
                        ddlUsuario.SelectedItem.Text = "";
                    }
                }

                if (cont == 0)
                {
                    CambiaEstadoNotificacion("Warning", true, "Es necesario seleccionar al menos un elemento de la cuadrícula.");
                }
                //else
                //{
                    

                //    foreach (int item in lstUsuario)
                //    {
                //        string NumeroResponsiva = objectResponsiva.GeneraNoResponsiva();
                //        BLArticulo objectArticulo = new BLArticulo();

                //        ArrayList Params = new ArrayList();
                //        Params.Add(string.Empty);
                //        Params.Add(string.Empty);
                //        Params.Add(item);
                //        Params.Add(0);
                //        Params.Add(0);
                //        Params.Add(0);
                //        List<Articulo> articulosAsignados = objectArticulo.BuscaArticuloFitradoA(Params);

                //        foreach (Articulo itemArticulo in articulosAsignados)
                //        {
                //            Articulo articuloHistorico = new Articulo();
                //            articuloHistorico = (Articulo)itemArticulo.Clone();

                //            itemArticulo.responsiva = Convert.ToInt32(NumeroResponsiva);

                //            BLArticulo oblArticulo = new BLArticulo(itemArticulo);
                //            sMensaje = oblArticulo.actualizaArticulo();
                //            articuloHistorico.IdUsuarioNuevo = itemArticulo.idUsuario;
                //            oblArticulo.InsertArticuloHistorico(articuloHistorico); 
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlUbicacionDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReubicar.Visible = true;
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

    }
}