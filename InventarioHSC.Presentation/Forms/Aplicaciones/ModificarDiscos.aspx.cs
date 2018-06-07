using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class ModificarDiscos : System.Web.UI.Page
    {
        #region Variables

        public static DataTable USel = new DataTable();

        protected const int SrvD_Unidad = 1;
        protected const int SrvD_Capacidad = 2;
        protected const int SrvTA_Descripcion = 3;
        protected const int SrvUD_Descripcion = 4;
        protected const int TipoEquipo = 5;
        protected const int NoSerie = 6;
        protected const int SrvD_Observaciones = 7;
        protected const int SrvTA_Id = 8;
        protected const int SrvUD_Id = 9;
        protected const int idItem = 10;
        protected const int idTipoEquipo = 11;
        protected const string AccionAgregar = "0";
        protected const string AccionModificar = "1";
        protected const int TipoEquipoDesconocido = 1;
        protected const int TipoEquipoInterno = 2;

        #endregion Variables

        #region Catalogos

        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            objCatalogo.ListaServidoresCompletaApp(ref ddlServidor);
            ddlServidor.DataBind();
            objCatalogo.ListaTiposAlmacenamiento(ref ddlTipoAlmacenamiento);
            ddlTipoAlmacenamiento.DataBind();
            objCatalogo.ListaUsosDisco(ref ddlUsoDisco);
            ddlUsoDisco.DataBind();
            objCatalogo.CargaTiposEquipo(ref ddlTipoEquipo);
            ddlTipoEquipo.DataBind();
        }

        protected DataTable LetrasUnidad()
        {
            DataTable Combo = new DataTable();
            System.Data.DataRow row;

            Combo.Columns.Add("SrvD_Unidad");
            Combo.Columns.Add("SrvD_Capacidad");
            Combo.Columns.Add("SrvTA_Id");
            Combo.Columns.Add("SrvUD_Id");
            Combo.Columns.Add("idItem");
            Combo.Columns.Add("SrvTA_Descripcion");
            Combo.Columns.Add("SrvUD_Descripcion");
            Combo.Columns.Add("TipoEquipo");
            Combo.Columns.Add("NoSerie");
            Combo.Columns.Add("SrvD_Observaciones");
            Combo.AcceptChanges();

            #region Letras

            row = Combo.NewRow();
            row[0] = "A";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "B";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "C";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "D";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "E";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "F";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "G";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "H";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "I";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "J";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "K";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "L";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "M";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "N";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "O";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "P";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "Q";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "R";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "S";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "T";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "U";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "V";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "W";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "X";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "Y";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "Z";
            row[1] = "";
            Combo.Rows.Add(row);

            Combo.AcceptChanges();

            #endregion Letras

            return Combo;
        }

        protected void UnidadesHDD(ref DropDownList ddl)
        {
            DataTable Combo = new DataTable();

            Combo = LetrasUnidad();
            USel = new DataTable();
            USel = Combo.Clone();

            ddl.DataValueField = "SrvD_Unidad";
            ddl.DataTextField = "SrvD_Unidad";
            ddl.DataSource = Combo;
            ddl.DataBind();
        }

        #endregion Catalogos

        #region Metodos

        protected void EsconderColumnas() //Llamar siempre después de cada DataBind a grdDiscos
        {
            grdDiscos.Columns[SrvTA_Id].Visible = false;
            grdDiscos.Columns[SrvUD_Id].Visible = false;
            grdDiscos.Columns[idItem].Visible = false;
            grdDiscos.Columns[idTipoEquipo].Visible = false;
        }

        protected void CargaDiscos(int Srv_Id)
        {
            BLSoftware sw = new BLSoftware();
            DataTable InfoDiscos = new DataTable();

            sw.InformacionCompletaDiscos(Srv_Id, ref InfoDiscos);
            pnlDiscos.Enabled = true;
            //Agregar campos a USel --> en eso me quedé
            if (InfoDiscos.Rows.Count > 0)
            {
                USel.Rows.Clear();
                USel = InfoDiscos;
                grdDiscos.DataSource = InfoDiscos;
                grdDiscos.DataBind();
                EsconderColumnas();

                ddlUnidad.DataSource = MinusDT(LetrasUnidad(), "SrvD_Unidad", USel, "SrvD_Unidad");
                ddlUnidad.DataBind();
            }
        }

        protected DataTable MinusDT(DataTable Tabla1, string ColT1, DataTable Tabla2, string ColT2)
        {
            DataTable NoEncontradas = new DataTable();
            bool Existe;

            NoEncontradas = Tabla1.Clone();

            for (int w = 0; w < Tabla1.Rows.Count; w++)
            {
                Existe = false;

                for (int w2 = 0; w2 < Tabla2.Rows.Count; w2++)
                {
                    if (Tabla1.Rows[w][ColT1].ToString() == Tabla2.Rows[w2][ColT2].ToString())
                    {
                        Existe = true;
                        break;
                    }
                }

                if (!Existe)
                    NoEncontradas.ImportRow(Tabla1.Rows[w]);
            }

            NoEncontradas.AcceptChanges();

            return NoEncontradas;
        }

        protected void LimpiarCampos()
        {
            lblUnidad.Text = "";
            lblUnidadT.Text = "Agregar Unidad:";
            txtCapacidad.Text = "";
            txtObservaciones.Text = "";

            if (ddlTipoAlmacenamiento.Items.Count > 0)
            {
                ddlTipoAlmacenamiento.ClearSelection();
                ddlTipoAlmacenamiento.Items[0].Selected = true;
            }

            if (ddlUnidad.Items.Count > 0)
            {
                ddlUnidad.ClearSelection();
                ddlUnidad.Items[0].Selected = true;
            }

            if (ddlUsoDisco.Items.Count > 0)
            {
                ddlUsoDisco.ClearSelection();
                ddlUsoDisco.Items[0].Selected = true;
            }

            if (ddlTipoEquipo.Items.Count > 0)
            {
                ddlTipoEquipo.ClearSelection();
                ddlTipoEquipo.Items[0].Selected = true;
            }

            ddlEquipo.DataSource = null;
            ddlEquipo.DataBind();
        }

        protected void LlenaEquipos(int idTipoEquipo, bool CargaDesdeGrid)
        {
            BLSoftware sw = new BLSoftware();

            ddlEquipo.Items.Clear();
            ddlEquipo.Enabled = false;

            if (idTipoEquipo > 0)
            {
                ddlEquipo.Enabled = true;
                sw.ObtenerEquipos(ref ddlEquipo, idTipoEquipo, CargaDesdeGrid ? false : true);
                ddlEquipo.DataBind();

                if (CargaDesdeGrid)
                {
                    for (int w = 0; w < ddlEquipo.Items.Count; w++)
                    {
                        if (ddlEquipo.Items[w].Value == grdDiscos.SelectedRow.Cells[idItem].Text)
                        {
                            ddlEquipo.Items[w].Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                ddlEquipo.DataSource = null;
                ddlEquipo.DataBind();
            }
        }

        #endregion Metodos

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int Srv_Id = 0;

                CargaCatalogos();
                UnidadesHDD(ref ddlUnidad);

                if (Request.QueryString["Srv"] != null)
                    int.TryParse(Request.QueryString["Srv"].ToString(), out Srv_Id);

                if (Srv_Id > 0)
                {
                    for (int w = 0; w < ddlServidor.Items.Count; w++)
                    {
                        if (Srv_Id.ToString() == ddlServidor.Items[w].Value)
                        {
                            ddlServidor.Items[w].Selected = true;
                            CargaDiscos(Srv_Id);
                            pnlAgregar.Visible = true;
                            pnlAgregar.Enabled = true;
                            btnAgregar.Visible = true;
                            break;
                        }
                    }
                }
            }
        }

        protected void ddlServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Srv_Id = 0;

            int.TryParse(ddlServidor.SelectedItem.Value, out Srv_Id);
            pnlDiscos.Enabled = false;

            if (Srv_Id > 0)
            {
                CargaDiscos(Srv_Id);
                btnAgregar.Visible = true;
                pnlAgregar.Visible = true;
                pnlAgregar.Enabled = true;
                grdDiscos.Visible = true;
            }
            else
            {
                btnAgregar.Visible = false;
                pnlAgregar.Visible = false;
                pnlAgregar.Enabled = false;
                grdDiscos.Visible = false;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            hddAccion.Value = AccionAgregar;
            ddlUnidad.Visible = true;
            LimpiarCampos();
            mp1.Show();
        }

        protected void btnProcesarD_Click(object sender, EventArgs e)
        {
            int CapHDD = 0;
            int Srv_Id = 0;
            int SrvTA_Id = 0;
            int SrvUD_Id = 0;
            int idItem = 0;
            string SrvD_Unidad = "";
            System.Data.DataRow row;

            int.TryParse(txtCapacidad.Text, out CapHDD);
            int.TryParse(ddlServidor.SelectedValue, out Srv_Id);
            int.TryParse(ddlTipoAlmacenamiento.SelectedValue, out SrvTA_Id);
            int.TryParse(ddlUsoDisco.SelectedValue, out SrvUD_Id);
            int.TryParse(ddlEquipo.SelectedValue, out idItem);
            txtObservaciones.Text = txtObservaciones.Text.Trim();

            if (hddAccion.Value == AccionAgregar)
                SrvD_Unidad = ddlUnidad.SelectedValue;
            else
                SrvD_Unidad = lblUnidad.Text;

            if (hddAccion.Value == AccionAgregar && ddlUnidad.Items.Count == 0)
            {
                MsgBoxU.AddMessage("Ya no hay unidades disponibles para asignar", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                return;
            }

            if (!(SrvTA_Id == TipoEquipoDesconocido || SrvTA_Id == TipoEquipoInterno))
            {
                if (!(idItem > 0))
                {
                    MsgBoxU.AddMessage("Debe seleccionar un equipo.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                    return;
                }
            }

            if (CapHDD > 0 && Srv_Id > 0 && SrvTA_Id > 0 && SrvUD_Id > 0)
            {
                BLSoftware sw = new BLSoftware();

                row = USel.NewRow();
                row[0] = ddlUnidad.SelectedValue;
                row[1] = CapHDD.ToString();
                USel.Rows.Add(row);
                USel.AcceptChanges();

                ddlUnidad.DataSource = MinusDT(LetrasUnidad(), "SrvD_Unidad", USel, "SrvD_Unidad");
                ddlUnidad.DataBind();

                sw.InsertarDiscoServidorApp(Srv_Id, CapHDD, SrvD_Unidad, SrvTA_Id, SrvUD_Id, idItem, txtObservaciones.Text);

                //CargaDiscos(Srv_Id);
                txtCapacidad.Text = "";
                Response.Redirect("ModificarDiscos.aspx?Srv=" + Srv_Id.ToString());
            }
            else
            {
                MsgBoxU.AddMessage("Información ingresada de manera incorrecta. Verifique.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }

        protected void grdDiscos_RowSelected(object sender, EventArgs e)
        {
            GridViewRow row = grdDiscos.SelectedRow;

            LimpiarCampos();
            btnProcesarD.Text = "Modificar disco";
            lblUnidadT.Text = "Unidad seleccionada:";
            lblUnidad.Text = row.Cells[SrvD_Unidad].Text;
            ddlUnidad.Visible = false;
            txtCapacidad.Text = row.Cells[SrvD_Capacidad].Text;
            txtObservaciones.Text = Server.HtmlDecode(row.Cells[SrvD_Observaciones].Text);
            ddlTipoAlmacenamiento.ClearSelection();
            ddlUsoDisco.ClearSelection();
            ddlTipoEquipo.ClearSelection();
            hddAccion.Value = AccionModificar;

            for (int w = 0; w < ddlTipoAlmacenamiento.Items.Count; w++)
            {
                if (ddlTipoAlmacenamiento.Items[w].Value == row.Cells[SrvTA_Id].Text)
                {
                    ddlTipoAlmacenamiento.Items[w].Selected = true;
                    break;
                }
            }

            for (int w = 0; w < ddlUsoDisco.Items.Count; w++)
            {
                if (ddlUsoDisco.Items[w].Value == row.Cells[SrvUD_Id].Text)
                {
                    ddlUsoDisco.Items[w].Selected = true;
                    break;
                }
            }

            for (int w = 0; w < ddlTipoEquipo.Items.Count; w++)
            {
                if (ddlTipoEquipo.Items[w].Value == row.Cells[idTipoEquipo].Text)
                {
                    ddlTipoEquipo.Items[w].Selected = true;
                    LlenaEquipos(Convert.ToInt32(ddlTipoEquipo.Items[w].Value), true);
                    break;
                }
            }

            mp1.Show();
        }

        protected void grdDiscos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            foreach (DataControlFieldCell cell in grdDiscos.Rows[e.RowIndex].Cells)
            {
                for (int w = 0; w < USel.Rows.Count; w++)
                {
                    if (USel.Rows[w][0].ToString() == cell.Text)
                    {
                        BLSoftware sw = new BLSoftware();
                        int Srv_Id = 0;

                        int.TryParse(ddlServidor.SelectedItem.Value, out Srv_Id);

                        if (Srv_Id > 0)
                        {
                            USel.Rows[w].Delete();
                            USel.AcceptChanges();

                            ddlUnidad.DataSource = MinusDT(LetrasUnidad(), "SrvD_Unidad", USel, "SrvD_Unidad");
                            ddlUnidad.DataBind();

                            sw.BorrarDiscosServidorApp(Srv_Id, cell.Text);
                            //CargaDiscos(Srv_Id);
                            Response.Redirect("ModificarDiscos.aspx?Srv=" + Srv_Id.ToString());
                        }
                        break;
                    }
                }
            }
        }

        protected void grdDiscos_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            grdDiscos.DataSource = USel;
            grdDiscos.PageIndex = e.NewPageIndex;
            grdDiscos.DataBind();
            EsconderColumnas();
        }

        protected void ddlTipoEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTipoEquipo = 0;

            int.TryParse(ddlTipoEquipo.SelectedValue, out idTipoEquipo);

            LlenaEquipos(idTipoEquipo, false);
            mp1.Show();
        }

        #endregion Eventos
    }
}