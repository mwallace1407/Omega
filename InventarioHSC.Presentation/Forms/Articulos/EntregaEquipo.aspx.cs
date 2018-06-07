using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;
using Microsoft.Reporting.WebForms;

namespace InventarioHSC
{
    public partial class EntregaEquipo : System.Web.UI.Page
    {
        public BLArticulo bloArticulo = new BLArticulo();
        public List<Articulo> lstAgregar = new List<Articulo>();
        public List<Articulo> lstQuitar = new List<Articulo>();
        public BLResponsiva objectResponsiva = new BLResponsiva();
        public BLXLSResponsiva oDocResponsiva = new BLXLSResponsiva();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Warning.Visible = false;
                Info.Visible = false;
                Session["GridAdd"] = lstAgregar;
                Session["GridDell"] = lstQuitar;
                CargaCatalogos();
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

        protected void btnBuscarResponsiva_Click(object sender, EventArgs e)
        {
            txtResponsiva.Enabled = true;
            ddlUsuarioAsignado.Enabled = true;
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
                    LabelInfo.Text = "";
                    Info.Visible = false;
                    ddlUsuarioAsignado.SelectedValue = olstArticulo[0].idUsuario.ToString();
                    txtPuesto.Text = oblCatalogos.ObtienePuesto
                        (olstArticulo[0].idUsuario.HasValue ? olstArticulo[0].idUsuario.Value : 0);
                    ddlUbicacion.SelectedValue = olstArticulo[0].idUbicacion.ToString();
                    txtRegion.Text = oblCatalogos.ObtieneRegion(olstArticulo[0].idUbicacion);

                    gwvArticuloAsignado.DataSource = olstArticuloHeader;
                    gwvArticuloAsignado.DataBind();

                    btnDocumento.Enabled = true;
                    btnQuitarTodo.Enabled = true;
                    btnQuitarTodo.Visible = true;
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

        public void CargaCatalogos()
        {
            LabelInfo.Text = "";
            Info.Visible = false;
            LabelError.Text = "";
            Warning.Visible = false;

            BLCatalogos oblCatalogos = new BLCatalogos();

            oblCatalogos.CargaSistemaOperativo(ref ddlSistemaOperativo);
            ddlSistemaOperativo.DataBind();

            oblCatalogos.CargaUbicacion(ref ddlUbicacion);
            ddlUbicacion.DataBind();

            oblCatalogos.CargaUsuario(ref ddlUsuarioAsignado);
            ddlUsuarioAsignado.DataBind();

            //oblCatalogos.CargaUsuarioAlta(ref ddlUsuarioAsignado);
            //ddlUsuarioAsignado.DataBind();
        }

        protected void fnLimpiaControlesMain()
        {
            ddlUsuarioAsignado.SelectedValue = "1191";
            txtPuesto.Text = string.Empty;
        }

        protected void fnLimpiaControlDetalle()
        {
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
                lstQuitar.Add(ArticuloAquitar);
                lstAgregar.RemoveAll(x => x.idItem == ArticuloAquitar.idItem);

                Session["GridAdd"] = lstAgregar;
                Session["GridDell"] = lstQuitar;

                ActualizaGrid();
            }
        }

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

                        //if (hdnNuevaResponsiva.Value.Equals("1"))
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

        protected void btnQuitarTodo_Click(object sender, EventArgs e)
        {
            lstAgregar = (List<Articulo>)Session["GridAdd"];
            lstQuitar = (List<Articulo>)Session["GridDell"];

            if (lstAgregar != null)
            {
                Articulo[] artArray = new Articulo[lstAgregar.Count];

                lstAgregar.CopyTo(artArray);

                foreach (Articulo arthq in artArray)
                {
                    lstQuitar.Add(arthq);
                    lstAgregar.RemoveAll(x => x.idItem == arthq.idItem);
                }

                Session["GridDell"] = lstQuitar;
                lstAgregar.Clear();
                gwvArticuloAsignado.DataSource = lstAgregar;
                gwvArticuloAsignado.DataBind();
            }
        }

        protected void btnDocumento_Click(object sender, EventArgs e)
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            txtProcesador.Text = string.Empty;
            txtMemoria.Text = string.Empty;
            txtDiscoDuro.Text = string.Empty;
            mpeDetalle.Hide();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //lstAgregar = (List<Articulo>)Session["GridAdd"];
            lstQuitar = (List<Articulo>)Session["GridDell"];

            string sFinalMsg = string.Empty;

            foreach (Articulo ArDel in lstQuitar)
            {
                // ArDel.idUbicacion = Convert.ToInt32(ddlUbicacion.SelectedValue);
                ArDel.idUsuario = Convert.ToInt32(Constantes.UsuarioValido.NoAsignado);
                ArDel.responsiva = null;
                ArDel.codigoCastor = string.Empty;
                bloArticulo.actualizaAsignacion(ArDel);
            }

            sFinalMsg = "Se actualizó la información de la responsiva correspondiente.";
            Info.Visible = true;
            LabelInfo.Text = sFinalMsg;
            btnDocumento.Visible = true;
        }
    }
}