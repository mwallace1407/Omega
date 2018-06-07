using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Servidores
{
    public partial class Tareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserNameLogin"] != null && Session["UserNameLogin"].ToString() != "")
                    CargaDatos(Session["UserNameLogin"].ToString(), DateTime.Now, true);
                else
                    Response.Redirect("~/Forms/sessionTimeout.html", false);
            }
        }

        protected DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        protected void CargaDatos(string UserLogin, DateTime Fecha, bool PrimeraCarga = false)
        {
            BLServidores objSrv = new BLServidores();
            BLCatalogos objCat = new BLCatalogos();
            System.Data.DataTable Res = new System.Data.DataTable();

            //hddUsuario.Value = UserLogin;
            Res = objSrv.ObtenerTareas(UserLogin, DatosGenerales.FechaInicioSemana(Fecha, DayOfWeek.Monday), DatosGenerales.FechaInicioSemana(Fecha, DayOfWeek.Monday).AddDays(7));
            cal01.Visible = false;

            if (Res.TableName != "Error")
            {
                cal01.Visible = true;
                cal01.DataSource = Res;
                cal01.DataStartField = "FechaInicio";
                cal01.DataEndField = "FechaFin";
                cal01.DataTextField = "Descripcion";
                cal01.DataValueField = "IdTarea";

                cal01.StartDate = DatosGenerales.FechaInicioSemana(Fecha, DayOfWeek.Monday);
                cal01.Days = 7;
                cal01.DataBind();

                if (PrimeraCarga)
                {
                    hddUsuario.Value = UserLogin;
                    ddlAccion.Items.Add(new ListItem("Seleccione una opción", "0"));
                    ddlAccion.Items.Add(new ListItem("Crear tarea", "1"));
                    ddlAccion.Items.Add(new ListItem("Editar tarea", "2"));
                    ddlAccion.Items.Add(new ListItem("Visualizar tareas", "3"));

                    objCat.CargaUsuariosSistema(ref ddlUsuario, true);
                    ddlUsuario.DataBind();

                    for (int w = 0; w < ddlUsuario.Items.Count; w++)
                    {
                        if (ddlUsuario.Items[w].Value.Trim() == "")
                        {
                            ddlUsuario.Items[w].Text = " -Seleccionar usuario- ";
                        }

                        if (ddlUsuario.Items[w].Value == UserLogin)
                        {
                            ddlUsuario.SelectedIndex = w;
                            break;
                        }
                    }

                    objCat.CargaUsuariosSistema(ref chk_Involucrados, false);
                    chk_Involucrados.DataBind();

                    for (int w = 0; w < chk_Involucrados.Items.Count; w++)
                    {
                        if (chk_Involucrados.Items[w].Value == UserLogin)
                        {
                            chk_Involucrados.Items.RemoveAt(w);
                            break;
                        }
                    }

                    objCat.ListaEstadosTareas(ref ddlEstado, false);
                    ddlEstado.DataBind();

                    ddlTareas.DataSource = Res;
                    ddlTareas.DataTextField = "Descripcion";
                    ddlTareas.DataValueField = "IdTarea";
                }

                if (ddlUsuario.SelectedIndex > 0)
                {
                    objCat.CategoriasTarea(ref ddlCategoria, UserLogin);
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Add(new ListItem("Crear nueva categoría", "-1"));
                    ddlCategoria.Items.Add(new ListItem("Todas", "-2"));

                    for (int w = 0; w <= ddlCategoria.Items.Count; w++)
                    {
                        if (ddlCategoria.Items[w].Value == "-2")
                        {
                            ddlCategoria.SelectedIndex = w;
                            btnProcesar.Enabled = true;
                            break;
                        }
                    }

                    if (/*ddlUsuario.SelectedValue == hddUsuario.Value && */ddlCategoria.Items.Count == 2)
                    {
                        pnlCat.Visible = true;

                        for (int w = 0; w <= ddlCategoria.Items.Count; w++)
                        {
                            if (ddlCategoria.Items[w].Value == "-1")
                            {
                                ddlCategoria.SelectedIndex = w;
                                break;
                            }
                        }
                    }
                    else
                    {
                        pnlCat.Visible = false;
                    }
                }
            }
            else
            {
                DatosGenerales.EnviaMensaje(Res.Rows[0][0].ToString(), "Error al cargar el calendario del usuario " + UserLogin, DatosGenerales.TiposMensaje.Error);
            }
        }

        protected void ddlAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDatos.Visible = false;
            pnlTarea.Visible = false;
            pnlUsuario.Visible = false;
            ddlTareas.Items.Clear();
            LimpiarCampos();

            switch (ddlAccion.SelectedValue)
            {
                case "1": //Crear
                    pnlDatos.Visible = true;
                    btnProcesar.Text = "Registrar tarea";
                    break;

                case "2": //Editar
                    BLCatalogos objCat = new BLCatalogos();

                    pnlTarea.Visible = true;
                    btnProcesar.Text = "Actualizar tarea";
                    objCat.ObtenerTareasDeUsuario(ref ddlTareas, hddUsuario.Value);
                    ddlTareas.DataBind();
                    break;

                case "3": //Visualizar
                    btnProcesar.Text = "Visualizar tareas";
                    pnlUsuario.Visible = true;
                    break;

                default:
                    break;
            }
        }

        protected void ddlTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLServidores objSrv = new BLServidores();

            int SrvT_Id = 0;

            int.TryParse(ddlTareas.SelectedValue, out SrvT_Id);

            if (SrvT_Id > 0)
            {
                System.Data.DataSet ds = objSrv.ObtenerDetalleTarea(SrvT_Id);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].TableName != "Error")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            pnlTarea.Visible = false;
                            pnlDatos.Visible = true;

                            for (int w = 0; w < ddlEstado.Items.Count; w++)
                            {
                                if (ddlEstado.Items[w].Value == ds.Tables[0].Rows[0]["SrvET_Id"].ToString())
                                {
                                    ddlEstado.SelectedIndex = w;
                                    break;
                                }
                            }

                            for (int w = 0; w < ddlCategoria.Items.Count; w++)
                            {
                                if (ddlCategoria.Items[w].Value == ds.Tables[0].Rows[0]["SrvCT_Id"].ToString())
                                {
                                    ddlCategoria.SelectedIndex = w;
                                    break;
                                }
                            }

                            if (EsFecha(ds.Tables[0].Rows[0]["SrvT_Inicio"].ToString()))
                                dtpIni.DateTime = ds.Tables[0].Rows[0]["SrvT_Inicio"].ToString();

                            if (EsFecha(ds.Tables[0].Rows[0]["SrvT_Fin"].ToString()))
                                dtpFin.DateTime = ds.Tables[0].Rows[0]["SrvT_Fin"].ToString();

                            txtDescripcion.Text = ds.Tables[0].Rows[0]["SrvT_Descripcion"].ToString();

                            if (ds.Tables[0].Rows[0]["SrvT_EsPrivada"].ToString() == "S")
                                chkPrivada.Checked = true;
                            else
                                chkPrivada.Checked = false;

                            if (!chkPrivada.Checked)
                            {
                                //for (int w = 0; w < chk_Involucrados.Items.Count; w++)
                                //{
                                //    chk_Involucrados.Items[w].Selected = false;
                                //}
                                if (ds.Tables.Count > 1)
                                {
                                    for (int w = 0; w < ds.Tables[1].Rows.Count; w++)
                                    {
                                        for (int w2 = 0; w2 < chk_Involucrados.Items.Count; w2++)
                                        {
                                            if (ds.Tables[1].Rows[w]["UserName"].ToString() == chk_Involucrados.Items[w2].Value)
                                            {
                                                chk_Involucrados.Items[w2].Selected = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                pnlInvolucrados.Visible = false;
                            }
                        }
                        else
                        {
                            DatosGenerales.EnviaMensaje("No se obtuvieron datos para la tarea seleccionada", "Carga de tarea", DatosGenerales.TiposMensaje.Error);
                        }
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                            DatosGenerales.EnviaMensaje("Error en consulta: " + ds.Tables[1].Rows[0][0].ToString(), "Carga de tarea", DatosGenerales.TiposMensaje.Error);
                        else
                            DatosGenerales.EnviaMensaje("Error en consulta", "Carga de tarea", DatosGenerales.TiposMensaje.Error);
                    }
                }
                else
                {
                    DatosGenerales.EnviaMensaje("No se obtuvieron datos para la tarea seleccionada (DataSet vacío)", "Carga de tarea", DatosGenerales.TiposMensaje.Error);
                }
            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BLCatalogos objCat = new BLCatalogos();

            //objCat.CategoriasTarea(ref ddlCategoria, ddlUsuario.SelectedValue);
            //ddlCategoria.DataBind();

            //if (ddlUsuario.SelectedValue == hddUsuario.Value)
            //    ddlCategoria.Items.Add(new ListItem("Crear nueva categoría", "-1"));
            if (ddlUsuario.SelectedValue != "")
            {
                btnExportar.Enabled = true;
                CargaDatos(ddlUsuario.SelectedValue, DateTime.Now);
            }
            else
            {
                btnExportar.Enabled = false;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedValue == "-1")
            {
                pnlCat.Visible = true;
                btnProcesar.Enabled = false;
                txtNuevaCat.Focus();
            }
            else
            {
                pnlCat.Visible = false;
                btnProcesar.Enabled = true;
            }
        }

        protected void chkModoCal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModoCal.Checked)
                cal01.HeightSpec = DayPilot.Web.Ui.Enums.HeightSpecEnum.Full;
            else
                cal01.HeightSpec = DayPilot.Web.Ui.Enums.HeightSpecEnum.BusinessHoursNoScroll;
        }

        protected void btnNuevaCat_Click(object sender, EventArgs e)
        {
            BLCatalogos objCat = new BLCatalogos();
            BLServidores objSrv = new BLServidores();

            txtNuevaCat.Text = txtNuevaCat.Text.Trim();

            if (txtNuevaCat.Text != "")
                objSrv.AgregarCategoria(hddUsuario.Value, txtNuevaCat.Text);

            txtNuevaCat.Text = "";
            pnlCat.Visible = false;

            objCat.CategoriasTarea(ref ddlCategoria, hddUsuario.Value);
            ddlCategoria.DataBind();

            //if (ddlUsuario.SelectedValue == hddUsuario.Value)
            ddlCategoria.Items.Add(new ListItem("Crear nueva categoría", "-1"));

            ddlCategoria.Items.Add(new ListItem("Todas", "-2"));
            btnProcesar.Enabled = false;

            for (int w = 0; w <= ddlCategoria.Items.Count; w++)
            {
                if (ddlCategoria.Items[w].Value == "-2")
                {
                    ddlCategoria.SelectedIndex = w;
                    btnProcesar.Enabled = true;
                    break;
                }
            }

            if (/*ddlUsuario.SelectedValue == hddUsuario.Value && */ddlCategoria.Items.Count == 2)
            {
                pnlCat.Visible = true;

                for (int w = 0; w <= ddlCategoria.Items.Count; w++)
                {
                    if (ddlCategoria.Items[w].Value == "-1")
                    {
                        ddlCategoria.SelectedIndex = w;
                        break;
                    }
                }
            }
            else
            {
                pnlCat.Visible = false;
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            DateTime.TryParse(dtp03.DateTime, out dt);

            if (ddlAccion.SelectedValue == "3")
                CargaDatos(ddlUsuario.SelectedValue, dt);
            else
                CargaDatos(hddUsuario.Value, dt);
        }

        protected bool EsFecha(string Fecha)
        {
            DateTime f;

            if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out f))
                return true;
            else
                return false;
        }

        protected DateTime ObtieneFecha(string Fecha)
        {
            DateTime f;

            if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out f))
                return f;
            else
                return new DateTime(1900, 1, 1);
        }

        protected bool FechasCorrectas(DateTime FechaIni, DateTime FechaFin)
        {
            bool Res = true;

            if (FechaIni >= FechaFin)
            {
                Res = false;
            }
            else
            {
                if (FechaIni.AddMinutes(5) > FechaFin)
                    Res = false;
            }

            return Res;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLServidores objSrv = new BLServidores();
                int SrvT_Id = 0;
                int Categoria = 0;
                bool HayError = false;

                int.TryParse(ddlCategoria.SelectedValue, out Categoria);

                switch (ddlAccion.SelectedValue)
                {
                    case "1":
                        if (Categoria <= 0 || !EsFecha(dtpIni.DateTime) || !EsFecha(dtpFin.DateTime) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
                        {
                            DatosGenerales.EnviaMensaje("Datos incorrectos. Revise las fechas y que se encuentre un texto en la descripción.", "Alta de tarea", DatosGenerales.TiposMensaje.Advertencia);
                            HayError = true;
                        }

                        if (!FechasCorrectas(ObtieneFecha(dtpIni.DateTime), ObtieneFecha(dtpFin.DateTime)))
                        {
                            DatosGenerales.EnviaMensaje("Datos incorrectos. Revise que la fecha final no sea mayor que la inicial y que la tarea tenga una duración mínima de 5 minutos.", "Alta de tarea", DatosGenerales.TiposMensaje.Advertencia);
                            HayError = true;
                        }

                        if (!HayError)
                        {
                            int.TryParse(objSrv.RegistrarTarea(Convert.ToInt32(ddlEstado.SelectedValue), Convert.ToInt32(ddlCategoria.SelectedValue), hddUsuario.Value, ObtieneFecha(dtpIni.DateTime), ObtieneFecha(dtpFin.DateTime), txtDescripcion.Text, chkPrivada.Checked), out SrvT_Id);

                            if (SrvT_Id > 0)
                            {
                                if (!chkPrivada.Checked)
                                {
                                    for (int w = 0; w < chk_Involucrados.Items.Count; w++)
                                    {
                                        if (chk_Involucrados.Items[w].Selected)
                                            objSrv.AgregarInvolucradoTarea(SrvT_Id, chk_Involucrados.Items[w].Value);
                                    }
                                }
                            }
                            else
                            {
                                DatosGenerales.EnviaMensaje("No se obtuvo el Id de la tarea. Es posible que no se haya registrado correctamente.", "Alta de tarea", DatosGenerales.TiposMensaje.Error);
                            }

                            Response.Redirect("Tareas.aspx");
                        }

                        break;

                    case "2":
                        if (Categoria <= 0 || !EsFecha(dtpIni.DateTime) || !EsFecha(dtpFin.DateTime) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
                        {
                            DatosGenerales.EnviaMensaje("Datos incorrectos. Revise las fechas y que se encuentre un texto en la descripción.", "Modificar tarea", DatosGenerales.TiposMensaje.Advertencia);
                            HayError = true;
                        }

                        if (!FechasCorrectas(ObtieneFecha(dtpIni.DateTime), ObtieneFecha(dtpFin.DateTime)))
                        {
                            DatosGenerales.EnviaMensaje("Datos incorrectos. Revise que la fecha final no sea mayor que la inicial y que la tarea tenga una duración mínima de 5 minutos.", "Modificar tarea", DatosGenerales.TiposMensaje.Advertencia);
                            HayError = true;
                        }

                        if (!HayError)
                        {
                            int.TryParse(ddlTareas.SelectedValue, out SrvT_Id);

                            if (SrvT_Id > 0)
                            {
                                objSrv.ActualizarTarea(SrvT_Id, Convert.ToInt32(ddlEstado.SelectedValue), Convert.ToInt32(ddlCategoria.SelectedValue), ObtieneFecha(dtpIni.DateTime), ObtieneFecha(dtpFin.DateTime), txtDescripcion.Text, chkPrivada.Checked, true);

                                if (!chkPrivada.Checked)
                                {
                                    for (int w = 0; w < chk_Involucrados.Items.Count; w++)
                                    {
                                        if (chk_Involucrados.Items[w].Selected)
                                            objSrv.AgregarInvolucradoTarea(SrvT_Id, chk_Involucrados.Items[w].Value);
                                    }
                                }
                            }
                            else
                            {
                                DatosGenerales.EnviaMensaje("No se obtuvo el Id de la tarea. No se podrán modificar los datos.", "Modificar tarea", DatosGenerales.TiposMensaje.Error);
                            }

                            Response.Redirect("Tareas.aspx");
                        }

                        break;
                }
            }
        }

        protected void chkPrivada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrivada.Checked)
                pnlInvolucrados.Visible = false;
            else
                pnlInvolucrados.Visible = true;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            BLServidores objSrv = new BLServidores();

            if (ddlUsuario.SelectedValue != "")
            {
                string Archivo = "";

                if (ddlUsuario.SelectedValue != hddUsuario.Value)
                    Archivo = objSrv.TareasAExcel(ddlUsuario.SelectedValue, null, null, null, null, false, Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos));
                else
                    Archivo = objSrv.TareasAExcel(ddlUsuario.SelectedValue, null, null, null, null, null, Server.MapPath("../Reportes/" + DatosGenerales.RutaLocalReportesDinamicos));

                if (Archivo.Length > 4 && Archivo.Substring(0, 5) != "Error")
                {
                    Archivo = DatosGenerales.RutaReportesDinamicos + Archivo;
                }
                else
                {
                    DatosGenerales.EnviaMensaje("Error al generar el archivo: " + Archivo, "Exportar a Excel", DatosGenerales.TiposMensaje.Error);
                }

                if (Archivo != "")
                    Response.Redirect(Archivo);
                else
                    DatosGenerales.EnviaMensaje("El usuario no tiene tareas públicas registradas.", "Exportar a Excel", DatosGenerales.TiposMensaje.Informacion);
            }
        }

        protected void LimpiarCampos()
        {
            if (ddlEstado.Items.Count > 0)
                ddlEstado.SelectedIndex = 0;

            if (ddlCategoria.Items.Count > 0)
                ddlCategoria.SelectedIndex = 0;

            txtNuevaCat.Text = "";
            txtDescripcion.Text = "";
            dtpIni.DateTime = "";
            dtpFin.DateTime = "";
            chkPrivada.Checked = false;

            foreach (ListItem itm in chk_Involucrados.Items)
            {
                itm.Selected = false;
            }
        }
    }
}