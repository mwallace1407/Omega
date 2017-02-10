using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;
using System.Data;

namespace InventarioHSC.Forms.Aplicaciones
{
    public partial class ModificarServidor : System.Web.UI.Page
    {
        
        public static DataTable USel = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SiNoNull(ref ddlEsVirtual);
                Estado(ref ddlEstado);
                DatosGenerales.TipoEquipo(ref ddlTipo);
                UnidadesHDD(ref ddlUnidad);
                CargaCatalogos();
            }
        }

        #region Catalogos
        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            objCatalogo.CargaSOAplicaciones(ref ddlSO);
            ddlSO.DataBind();
            objCatalogo.CargaServidoresAplicaciones(ref ddlEquipo);
            ddlEquipo.DataBind();
            objCatalogo.ListaServidoresCompletaApp(ref ddlServidor);
            ddlServidor.DataBind();
        }
        #endregion Catalogos
        #region CatalogosFijos
        protected void SiNoNull(ref DropDownList ddl)
        {
            DataTable Combo = new DataTable();
            System.Data.DataRow row;

            Combo.Columns.Add("Id");
            Combo.Columns.Add("Descripcion");
            Combo.AcceptChanges();

            row = Combo.NewRow();
            row[0] = "";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "S";
            row[1] = "SI";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "N";
            row[1] = "NO";
            Combo.Rows.Add(row);

            Combo.AcceptChanges();
            ddl.DataValueField = "Id";
            ddl.DataTextField = "Descripcion";
            ddl.DataSource = Combo;
            ddl.DataBind();
        }

        protected void Estado(ref DropDownList ddl)
        {
            DataTable Combo = new DataTable();
            System.Data.DataRow row;

            Combo.Columns.Add("Id");
            Combo.Columns.Add("Descripcion");
            Combo.AcceptChanges();

            row = Combo.NewRow();
            row[0] = "";
            row[1] = "";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "A";
            row[1] = "Activo";
            Combo.Rows.Add(row);

            row = Combo.NewRow();
            row[0] = "I";
            row[1] = "Inactivo";
            Combo.Rows.Add(row);

            Combo.AcceptChanges();
            ddl.DataValueField = "Id";
            ddl.DataTextField = "Descripcion";
            ddl.DataSource = Combo;
            ddl.DataBind();
        }

        protected DataTable LetrasUnidad()
        {
            DataTable Combo = new DataTable();
            System.Data.DataRow row;

            Combo.Columns.Add("Unidad");
            Combo.Columns.Add("Capacidad");
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

            ddl.DataValueField = "Unidad";
            ddl.DataTextField = "Unidad";
            ddl.DataSource = Combo;
            ddl.DataBind();
        }
        #endregion CatalogosFijos

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

        protected void btnProcesarD_Click(object sender, EventArgs e)
        {
            int CapHDD = 0;
            System.Data.DataRow row;

            int.TryParse(txtCapacidad.Text, out CapHDD);

            if (CapHDD > 0)
            {
                row = USel.NewRow();
                row[0] = ddlUnidad.SelectedValue;
                row[1] = CapHDD.ToString();
                USel.Rows.Add(row);
                USel.AcceptChanges();

                ddlUnidad.DataSource = MinusDT(LetrasUnidad(), "Unidad", USel, "Unidad");
                ddlUnidad.DataBind();

                grdDiscos.DataSource = USel;
                grdDiscos.DataBind();
                txtCapacidad.Text = "";
            }
            else
            {
                MsgBoxU.AddMessage("La capacidad del disco debe ser mayor a cero", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }

        protected void ddlUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCapacidad.Focus();
        }

        protected void grdDiscos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            //foreach (DataControlFieldCell cell in grdDiscos.Rows[e.RowIndex].Cells)
            //{
            //    for (int w = 0; w < USel.Rows.Count; w++)
            //    {
            //        if (USel.Rows[w][0].ToString() == cell.Text)
            //        {
            //            USel.Rows[w].Delete();
            //            USel.AcceptChanges();

            //            ddlUnidad.DataSource = MinusDT(LetrasUnidad(), "Unidad", USel, "Unidad");
            //            ddlUnidad.DataBind();

            //            grdDiscos.DataSource = USel;
            //            grdDiscos.DataBind();
            //            break;
            //        }
            //    }
            //}
        }

        protected void grdDiscos_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            grdDiscos.DataSource = USel;
            grdDiscos.PageIndex = e.NewPageIndex;
            grdDiscos.DataBind();
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            BLSoftware objGrupoSoftware = new BLSoftware();
            Model.Servidores server = new Model.Servidores();
            string Resp = "";
            int RAM = 0;
            int Srv_Id = 0;

            int.TryParse(ddlServidor.SelectedItem.Value, out Srv_Id);
            server.id = Srv_Id;

            if (ddlEstado.SelectedValue == "A")
                server.Estado = true;
            else
                server.Estado = false;

            if (ddlEsVirtual.SelectedValue == "S")
                server.EsVirtual = true;
            else
                server.EsVirtual = false;

            server.idItem = Convert.ToInt32(ddlEquipo.SelectedValue);
            server.idSistema = Convert.ToInt32(ddlSO.SelectedValue);
            server.IP = txtIP.Text;
            server.Llave = txtLlave.Text;
            server.Nombre = txtNombreEquipo.Text;
            int.TryParse(txtRAM.Text, out RAM);
            server.RAM = RAM;
            server.Tipo = ddlTipo.SelectedValue;
            server.TotalHDD = 0;

            Resp = objGrupoSoftware.ActualizarServidorApp(server, USel, txtObservaciones.Text.Trim());
            objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "U", server.id);
            
            SiNoNull(ref ddlEsVirtual);
            Estado(ref ddlEstado);
            DatosGenerales.TipoEquipo(ref ddlTipo);
            UnidadesHDD(ref ddlUnidad);
            CargaCatalogos();
            txtNombreEquipo.Text = "";
            txtCapacidad.Text = "";
            txtIP.Text = "";
            txtLlave.Text = "";
            txtRAM.Text = "";
            grdDiscos.DataSource = null;
            grdDiscos.DataBind();

            if (server.id > 0)
                DatosGenerales.EnviaMensaje("Proceso finalizado", "Modificación de servidor", DatosGenerales.TiposMensaje.Informacion);
            else
                DatosGenerales.EnviaMensaje(Resp, "Modificación de servidor", DatosGenerales.TiposMensaje.Error);
        }

        protected void ddlServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLSoftware sw = new BLSoftware();
            int Srv_Id = 0;

            int.TryParse(ddlServidor.SelectedItem.Value, out Srv_Id);
            txtLlave.Text = "";

            if (Srv_Id > 0)
            {
                DataTable InfoServidor = new DataTable();
                DataTable InfoDiscos = new DataTable();

                pnlContent.Enabled = true;
                sw.InformacionGeneralServidor(Srv_Id, ref InfoServidor, ref InfoDiscos);
                lnkDiscos.NavigateUrl = "ModificarDiscos.aspx?Srv=" + Srv_Id.ToString();

                if (InfoServidor.Rows.Count > 0)
                {
                    if (InfoServidor.Columns.Contains("idItem")) { ddlEquipo.SelectedValue = InfoServidor.Rows[0]["idItem"].ToString(); }
                    if (InfoServidor.Columns.Contains("idSistema")) { ddlSO.SelectedValue = InfoServidor.Rows[0]["idSistema"].ToString(); }
                    if (InfoServidor.Columns.Contains("Srv_EsVirtual")) { ddlEsVirtual.SelectedValue = InfoServidor.Rows[0]["Srv_EsVirtual"].ToString(); }
                    if (InfoServidor.Columns.Contains("Srv_Tipo")) { ddlTipo.SelectedValue = InfoServidor.Rows[0]["Srv_Tipo"].ToString(); }
                    if (InfoServidor.Columns.Contains("Srv_Estado")) { ddlEstado.SelectedValue = InfoServidor.Rows[0]["Srv_Estado"].ToString(); }
                    if (InfoServidor.Columns.Contains("Srv_Observaciones")) { txtObservaciones.Text = InfoServidor.Rows[0]["Srv_Observaciones"].ToString(); }

                    if (InfoServidor.Columns.Contains("Srv_Nombre")) { txtNombreEquipo.Text = InfoServidor.Rows[0]["Srv_Nombre"].ToString(); }
                    if (InfoServidor.Columns.Contains("Srv_IP")) { txtIP.Text = InfoServidor.Rows[0]["Srv_IP"].ToString(); }
                    if (InfoServidor.Columns.Contains("Srv_RAM")) { txtRAM.Text = InfoServidor.Rows[0]["Srv_RAM"].ToString(); }
                    if (InfoServidor.Columns.Contains("Srv_RAM")) { txtRAM.Text = InfoServidor.Rows[0]["Srv_RAM"].ToString(); }

                    USel.Rows.Clear();
                    USel = InfoDiscos;
                    grdDiscos.DataSource = InfoDiscos;
                    grdDiscos.DataBind();

                    ddlUnidad.DataSource = MinusDT(LetrasUnidad(), "Unidad", USel, "Unidad");
                    ddlUnidad.DataBind();
                }
            }
            else
            {
                pnlContent.Enabled = false;

                if (ddlEquipo.Items.Count > 0) { ddlEquipo.SelectedIndex = 0; }
                if (ddlSO.Items.Count > 0) { ddlSO.SelectedIndex = 0; }
                if (ddlEsVirtual.Items.Count > 0) { ddlEsVirtual.SelectedIndex = 0; }
                if (ddlTipo.Items.Count > 0) { ddlTipo.SelectedIndex = 0; }
                if (ddlEstado.Items.Count > 0) { ddlEstado.SelectedIndex = 0; }

                txtNombreEquipo.Text = "";
                txtIP.Text = "";
                txtRAM.Text = "";

                ddlUnidad.Items.Clear();
                UnidadesHDD(ref ddlUnidad);
                txtCapacidad.Text = "";
                grdDiscos.DataSource = null;
                grdDiscos.DataBind();
            }
        }

        protected DateTime ObtieneFecha(string Fecha)
        {
            DateTime f;

            if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out f))
                return f;
            else
                return new DateTime(1900, 1, 1);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int Obj_Id = 0;
            DateTime Fecha = ObtieneFecha(txtFechaRespaldo.Text);

            txtCinta.Text = txtCinta.Text.Trim();
            int.TryParse(ddlServidor.SelectedValue, out Obj_Id);
            lblMsj.Visible = false;

            if (Page.IsValid && Obj_Id > 0 && txtCinta.Text != "" && Fecha.ToString("ddMMyyyy") != "01011900")
            {
                BLServidores objSrv = new BLServidores();

                objSrv.RegistrarCinta(3, Obj_Id, txtCinta.Text, txtObservacionesCinta.Text.Trim(), Fecha);
                lblMsj.Text = "Cinta registrada.";
                lblMsj.ForeColor = System.Drawing.Color.DarkGreen;
            }
            else
            {
                lblMsj.Text = "No se registró. Datos incorrectos.";
                lblMsj.ForeColor = System.Drawing.Color.DarkRed;
            }

            lblMsj.Visible = true;
        }
    }
}