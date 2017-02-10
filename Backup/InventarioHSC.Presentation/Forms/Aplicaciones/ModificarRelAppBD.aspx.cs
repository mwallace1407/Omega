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
    public partial class ModificarRelAppBD : System.Web.UI.Page
    {
        public static DataTable USel = new DataTable();
        protected const int CeldaNombre = 0;
        protected const int CeldaCheck = 1;
        protected const int CeldaProp = 2;
        protected const int CeldaId = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            BLCatalogos objCatalogo = new BLCatalogos();

            objCatalogo.ListaAppConServer(ref ddlApp);
            ddlApp.DataBind();

            USel = new DataTable();
            USel.Columns.Add("AppBD_Id");
            USel.Columns.Add("AppBD_Nombre");
            USel.Columns.Add("EsPropietaria");

            ddlBD.DataValueField = "AppBD_Id";
            ddlBD.DataTextField = "AppBD_Nombre";
        }

        protected void ddlApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLSoftware sw = new BLSoftware();
            BLCatalogos objCatalogo = new BLCatalogos();
            int App_Id = 0;

            USel.Rows.Clear();
            int.TryParse(ddlApp.SelectedValue, out App_Id);
            pnlRel.Enabled = false;

            if (App_Id > 0)
            {
                pnlRel.Enabled = true;
                USel = sw.InformacionRelAppBD(App_Id);
                grdDatos.DataSource = USel;
                grdDatos.DataBind();

                ddlBD.DataSource = MinusDT(objCatalogo.ListaBDConServerInstanciaRel(), "AppBD_Id", USel, "AppBD_Id");
                ddlBD.DataBind();
            }
            else
            {
                grdDatos.DataSource = null;
                grdDatos.DataBind();
                ddlBD.DataSource = null;
                ddlBD.DataBind();
                chkEsPropietaria.Checked = false;
            }
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[CeldaNombre].Style.Add("text-align", "left");

                CheckBox chkEsProp = (CheckBox)e.Row.FindControl("chkEsProp");

                if (e.Row.Cells[CeldaProp].Text == "S")
                    chkEsProp.Checked = true;
            }
        }

        protected void grdDatos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            ProcesarUSel();

            foreach (DataControlFieldCell cell in grdDatos.Rows[e.RowIndex].Cells)
            {
                for (int w = 0; w < USel.Rows.Count; w++)
                {
                    if (USel.Rows[w][0].ToString() == cell.Text)
                    {
                        BLCatalogos objCatalogo = new BLCatalogos();

                        USel.Rows[w].Delete();
                        USel.AcceptChanges();

                        ddlBD.DataSource = MinusDT(objCatalogo.ListaBDConServerInstanciaRel(), "AppBD_Id", USel, "AppBD_Id");
                        ddlBD.DataBind();

                        grdDatos.DataSource = USel;
                        grdDatos.DataBind();
                        break;
                    }
                }
            }
        }

        protected void ProcesarUSel()
        {
            BLSoftware objGrupoSoftware = new BLSoftware();
            bool Chk;
            int Srv_Id = 0;
            System.Data.DataRow row;

            USel.Rows.Clear();

            foreach (GridViewRow rowG in grdDatos.Rows)
            {
                Srv_Id = 0;
                Chk = ((CheckBox)rowG.FindControl("chkEsProp")).Checked;
                int.TryParse(rowG.Cells[CeldaId].Text, out Srv_Id);

                row = USel.NewRow();
                row[0] = Srv_Id.ToString();
                row[1] = rowG.Cells[CeldaNombre].Text;
                row[2] = Chk ? "S" : "N";
                USel.Rows.Add(row);
            }

            USel.AcceptChanges();
        }

        protected void btnProcesarD_Click(object sender, EventArgs e)
        {
            int Srv_Id = 0;
            System.Data.DataRow row;

            int.TryParse(ddlBD.SelectedValue, out Srv_Id);

            if (Srv_Id > 0)
            {
                BLCatalogos objCatalogo = new BLCatalogos();

                ProcesarUSel();
                row = USel.NewRow();
                row[0] = Srv_Id.ToString();
                row[1] = ddlBD.SelectedItem.Text;
                row[2] = chkEsPropietaria.Checked ? "S" : "N";
                USel.Rows.Add(row);
                USel.AcceptChanges();

                ddlBD.DataSource = MinusDT(objCatalogo.ListaBDConServerInstanciaRel(), "AppBD_Id", USel, "AppBD_Id");
                ddlBD.DataBind();

                grdDatos.DataSource = USel;
                grdDatos.DataBind();
            }
            else
            {
                MsgBoxU.AddMessage("Debe seleccionar una BD", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }

            if (ddlBD.Items.Count > 0)
            {
                ddlBD.SelectedIndex = 0;
                btnProcesarD.Enabled = true;
            }
            else
            {
                btnProcesarD.Enabled = false;
            }

            chkEsPropietaria.Checked = false;
        }

        protected void ProcesarGrid(int App_Id)
        {
            BLSoftware objGrupoSoftware = new BLSoftware();
            bool Chk;
            int AppBD_Id = 0;

            foreach (GridViewRow row in grdDatos.Rows)
            {
                AppBD_Id = 0;
                Chk = ((CheckBox)row.FindControl("chkEsProp")).Checked;
                int.TryParse(row.Cells[CeldaId].Text, out AppBD_Id);

                objGrupoSoftware.InsertarAppRelBD(App_Id, AppBD_Id, Chk);
                objGrupoSoftware.HistoricoApp(this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx", Session["UserNameLogin"].ToString(), "I", App_Id, AppBD_Id);
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            BLSoftware objGrupoSoftware = new BLSoftware();
            int App_Id = 0;
            string Res = "";

            int.TryParse(ddlApp.SelectedValue, out App_Id);

            if (App_Id > 0)
            {
                Res = objGrupoSoftware.BorrarAppRelBD(App_Id);

                if (Res == "OK")
                {
                    ProcesarGrid(App_Id);
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Modificación de relación App-BD", DatosGenerales.TiposMensaje.Informacion);
                }
                else
                {
                    MsgBoxU.AddMessage("Error: " + Res, YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                }
            }
            else
            {
                MsgBoxU.AddMessage("Debe seleccionar una aplicación", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
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
    }
}