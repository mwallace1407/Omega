using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Software
{
    public partial class AdministracionSoftware : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Warning.Visible = false;
                Info.Visible = false;
                LLenaUsuario();
                llenarArea_Solicita();
            }
        }

        private void llenarArea_Solicita()
        {
            BLAsignacion_Software asignacion = new BLAsignacion_Software();
            dplAreaSolicita.DataSource = asignacion.ObtenAreaAsignada();
            dplAreaSolicita.DataBind();
        }

        private void LLenaUsuario()
        {
            BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software();
            ddlUsuarioAsignado.DataSource = blAsignacionSoftware.UsuariosConAsignacionSoftware();
            ddlUsuarioAsignado.DataBind();
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            ddlUsuarioAsignado.SelectedIndex = 0;
            dplAreaSolicita.SelectedIndex = 0;
            cvUsuarioAsignado.Enabled = false;
            vcUsuarioAsiganado.Enabled = false;
            hdnNuevoUsuario.Value = "1";
            pnlNuevoUsuario.Visible = true;
            ddlUsuarioAsignado.SelectedIndex = 0;
            pnlUsuarioAsignado.Visible = false;
            pnlAsignacionSoftware.Visible = true;
            pnlLiberacion.Visible = true;
            gvwSoftwareAsignado.DataBind();
            gvLiberacionSoftware.DataBind();
            txtUsuarioNuevo.Focus();
        }

        protected void ddlUsuarioAsignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlUsuarioAsignado.SelectedItem.Value.Equals("Seleccionar") && !ddlUsuarioAsignado.SelectedItem.Value.Trim().Equals("--- Seleccionar ---"))
            {
                hdnNuevoUsuario.Value = "0";
                BLAsignacion_Software asinacionSoftware = new BLAsignacion_Software();
                pnlNuevoUsuario.Visible = false;
                pnlUsuarioAsignado.Visible = true;

                List<DetalleAsignacionSoftware> detalleAsignacion =
                    asinacionSoftware.DetalleAsignacionSoftware(ddlUsuarioAsignado.SelectedItem.Value);

                gvwSoftwareAsignado.DataSource = detalleAsignacion;
                gvwSoftwareAsignado.DataBind();

                string NombreUsuario = string.Empty;

                NombreUsuario = ddlUsuarioAsignado.SelectedItem.Value;

                BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software();

                gvLiberacionSoftware.DataSource = blAsignacionSoftware.DetalleAsignacionSoftware(NombreUsuario);
                gvLiberacionSoftware.DataBind();

                if (detalleAsignacion.Count > 0)
                {
                    pnlAsignacionSoftware.Visible = true;
                    pnlLiberacion.Visible = true;
                }
                else
                {
                    pnlAsignacionSoftware.Visible = false;
                    pnlLiberacion.Visible = false;
                }

                if (detalleAsignacion.Count > 0 && detalleAsignacion[0].Area_Solicita != "")
                {
                    dplAreaSolicita.SelectedValue = detalleAsignacion[0].Area_Solicita;
                }
                else
                {
                    dplAreaSolicita.SelectedIndex = 0;
                }
            }
            else
            {
                cvUsuarioAsignado.Enabled = true;
                vcUsuarioAsiganado.Enabled = true;
                pnlAsignacionSoftware.Visible = false;
                pnlLiberacion.Visible = false;
                gvwSoftwareAsignado.DataBind();
                gvLiberacionSoftware.DataBind();
            }
        }

        protected void btnAgregarLicencia_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["idSelectedSess"] = null;
            BLSoftware oblSoftware = new BLSoftware();

            gdvSoftware.DataSource = oblSoftware.ObtenSoftwareDisponible();
            gdvSoftware.DataBind();
            mpeDetalleAgregarLic.Show();
        }

        protected void btnGurdarLicencia_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = string.Empty;
                foreach (GridViewRow gr in gdvSoftware.Rows)
                {
                    CheckBox chkSeleccionado = (CheckBox)gr.Cells[0].FindControl("chkSelecciona");

                    if (chkSeleccionado.Checked)
                    {
                        string s_idImte = gdvSoftware.DataKeys[gr.RowIndex].Values["Cve_Asignacion"].ToString();

                        Asignacion_Software asignacionSoftware = new Asignacion_Software();
                        BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software(asignacionSoftware);
                        asignacionSoftware.Cve_Asignacion = Convert.ToInt32(s_idImte);
                        asignacionSoftware = blAsignacionSoftware.ObtenAsignacionSoftware();

                        if (hdnNuevoUsuario.Value.Equals("1"))
                        {
                            asignacionSoftware.Nombre_Usuario = txtUsuarioNuevo.Text;
                            asignacionSoftware.Area_Solicita = dplAreaSolicita.SelectedItem.Value;
                        }
                        else
                        {
                            asignacionSoftware.Nombre_Usuario = ddlUsuarioAsignado.SelectedItem.Value;
                            asignacionSoftware.Area_Solicita = dplAreaSolicita.SelectedItem.Value;
                        }

                        blAsignacionSoftware = new BLAsignacion_Software(asignacionSoftware);
                        mensaje = blAsignacionSoftware.ActualiaAsignacionSoftware();
                    }
                }

                if (mensaje.Equals("La Asignacion de software fue actualizado correctamente") || string.IsNullOrEmpty(mensaje))
                {
                    List<int> idSelected = HttpContext.Current.Session["idSelectedSess"] as List<int>;

                    if (idSelected != null)
                    {
                        foreach (int item in idSelected)
                        {
                            BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software();
                            Asignacion_Software asignacionSoftware = new Asignacion_Software();
                            asignacionSoftware.Cve_Asignacion = item;
                            asignacionSoftware = blAsignacionSoftware.ObtenAsignacionSoftware();

                            if (hdnNuevoUsuario.Value.Equals("1"))
                            {
                                asignacionSoftware.Nombre_Usuario = txtUsuarioNuevo.Text;
                                asignacionSoftware.Area_Solicita = dplAreaSolicita.SelectedItem.Value;
                            }
                            else
                            {
                                asignacionSoftware.Nombre_Usuario = ddlUsuarioAsignado.SelectedItem.Value;
                                asignacionSoftware.Area_Solicita = dplAreaSolicita.SelectedItem.Value;
                            }

                            blAsignacionSoftware = new BLAsignacion_Software(asignacionSoftware);
                            mensaje = blAsignacionSoftware.ActualiaAsignacionSoftware();
                        }
                    }

                    HttpContext.Current.Session["idSelectedSess"] = null;
                }

                if (mensaje.Equals("La Asignacion de software fue actualizado correctamente"))
                {
                    CambiaEstadoNotificacion("Info", true, "La Asignación de software se realizó correctamente");
                    CambiaEstadoNotificacion("Warning", false, string.Empty);

                    if (hdnNuevoUsuario.Value.Equals("1"))
                    {
                        string AreaSolicita = dplAreaSolicita.SelectedItem.Text;
                        LLenaUsuario();
                        llenarArea_Solicita();

                        ddlUsuarioAsignado.SelectedValue = txtUsuarioNuevo.Text;
                        dplAreaSolicita.SelectedValue = AreaSolicita;
                        pnlNuevoUsuario.Visible = false;
                        pnlUsuarioAsignado.Visible = true;
                    }
                    else
                    {
                        ddlUsuarioAsignado_SelectedIndexChanged(sender, e);
                    }

                    LabelInfo.Focus();
                    mpeDetalleAgregarLic.Hide();
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
                mpeDetalleAgregarLic.Hide();
                HttpContext.Current.Session["idSelectedSess"] = null;
            }
        }

        protected void btnRegresarLicencia_Click(object sender, EventArgs e)
        {
            mpeDetalleAgregarLic.Hide();
        }

        protected void gdvSoftware_PageIndexChanged(object sender, EventArgs e)
        {
            SelectionManager.RestoreSelection((GridView)sender);
        }

        protected void gdvSoftware_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BLSoftware oblSoftware = new BLSoftware();

            SelectionManager.KeepSelection((GridView)sender);

            gdvSoftware.DataSource = oblSoftware.ObtenSoftwareDisponible();
            gdvSoftware.PageIndex = e.NewPageIndex;
            gdvSoftware.DataBind();
        }

        protected void gvLiberacionSoftware_PageIndexChanged(object sender, EventArgs e)
        {
            SelectionManager.RestoreSelection((GridView)sender);
        }

        protected void gvLiberacionSoftware_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string NombreUsuario = string.Empty;

            if (hdnNuevoUsuario.Value.Equals("1"))
                NombreUsuario = txtUsuarioNuevo.Text;
            else
                NombreUsuario = ddlUsuarioAsignado.SelectedItem.Value;

            BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software();

            SelectionManager.KeepSelection((GridView)sender);

            gvLiberacionSoftware.DataSource = blAsignacionSoftware.DetalleAsignacionSoftware(NombreUsuario);
            gvLiberacionSoftware.PageIndex = e.NewPageIndex;
            gvLiberacionSoftware.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Inicio.aspx");
        }

        protected void btnLiberarSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                string Mensaje = string.Empty;

                foreach (GridViewRow gr in gvLiberacionSoftware.Rows)
                {
                    CheckBox chkSeleccionado = (CheckBox)gr.Cells[0].FindControl("chkSelecciona");

                    if (chkSeleccionado.Checked)
                    {
                        string s_idImte = gvLiberacionSoftware.DataKeys[gr.RowIndex].Values["Cve_Asignacion"].ToString();

                        Asignacion_Software asignacionSoftware = new Asignacion_Software();
                        asignacionSoftware.Cve_Asignacion = Convert.ToInt32(s_idImte);

                        BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software(asignacionSoftware);
                        asignacionSoftware = blAsignacionSoftware.ObtenAsignacionSoftware();
                        asignacionSoftware.Nombre_Usuario = "Disponible";
                        asignacionSoftware.Area_Solicita = null;

                        blAsignacionSoftware = new BLAsignacion_Software(asignacionSoftware);
                        Mensaje = blAsignacionSoftware.ActualiaAsignacionSoftware();
                    }
                }

                List<int> idSelected = HttpContext.Current.Session["idSelectedSess"] as List<int>;

                if (idSelected != null)
                {
                    foreach (int item in idSelected)
                    {
                        Asignacion_Software asignacionSoftware = new Asignacion_Software();
                        asignacionSoftware.Cve_Asignacion = item;

                        BLAsignacion_Software blAsignacionSoftware = new BLAsignacion_Software(asignacionSoftware);
                        asignacionSoftware = blAsignacionSoftware.ObtenAsignacionSoftware();
                        asignacionSoftware.Nombre_Usuario = "Disponible";
                        asignacionSoftware.Area_Solicita = null;

                        blAsignacionSoftware = new BLAsignacion_Software(asignacionSoftware);
                        blAsignacionSoftware.ActualiaAsignacionSoftware();
                    }
                }

                HttpContext.Current.Session["idSelectedSess"] = null;

                if (Mensaje.Equals("La Asignacion de software fue actualizado correctamente"))
                {
                    CambiaEstadoNotificacion("Info", true, "La liberación de software se realizó correctamente");
                    CambiaEstadoNotificacion("Warning", false, string.Empty);

                    if (hdnNuevoUsuario.Value.Equals("1"))
                    {
                        string AreaSolicita = dplAreaSolicita.SelectedItem.Text;
                        LLenaUsuario();
                        llenarArea_Solicita();

                        ddlUsuarioAsignado.SelectedValue = txtUsuarioNuevo.Text;
                        dplAreaSolicita.SelectedValue = AreaSolicita;
                        pnlNuevoUsuario.Visible = false;
                        pnlUsuarioAsignado.Visible = true;
                    }
                    else
                    {
                        ddlUsuarioAsignado_SelectedIndexChanged(sender, e);
                    }

                    LabelInfo.Focus();
                }
            }
            catch (Exception ex)
            {
                CambiaEstadoNotificacion("Info", false, string.Empty);
                CambiaEstadoNotificacion("Warning", true, "Error: " + ex.Message);
                LabelError.Focus();
                HttpContext.Current.Session["idSelectedSess"] = null;
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
    }
}