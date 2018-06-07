using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptWizardAut : System.Web.UI.Page
    {
        protected const int CeldaId = 1;
        protected const int CeldaConexion = 2;
        protected const int CeldaScript = 3;
        protected const int CeldaAutorizado = 4;
        protected const int CeldaTipo = 5;
        protected const int CeldaNombre = 6;

        protected void CargaDatos()
        {
            BLReportes objRpt = new BLReportes();

            grdDatos.DataSource = objRpt.ObtenerReportesAutorizaciones();
            grdDatos.DataBind();

            grdDatos.Columns[CeldaId].Visible = false;
            grdDatos.Columns[CeldaConexion].Visible = false;
            grdDatos.Columns[CeldaScript].Visible = false;
            grdDatos.Columns[CeldaAutorizado].Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaDatos();
            }
        }

        protected void grdDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLowerInvariant() == "detalle")
            {
                int grdId = -1;

                int.TryParse(e.CommandArgument.ToString(), out grdId);

                if (grdId >= 0)
                {
                    BLReportes objRpt = new BLReportes();

                    txtScript.Text = grdDatos.Rows[grdId].Cells[CeldaScript].Text;
                    lblConexion.Text = "Conexión: " + grdDatos.Rows[grdId].Cells[CeldaConexion].Text;
                    lblTipo.Text = "Tipo: " + grdDatos.Rows[grdId].Cells[CeldaTipo].Text;

                    if (grdDatos.Rows[grdId].Cells[CeldaTipo].Text.ToLowerInvariant() == "stored procedure")
                    {
                        lblTipo.Text = "Tipo: " + grdDatos.Rows[grdId].Cells[CeldaTipo].Text + " (" + grdDatos.Rows[grdId].Cells[CeldaScript].Text + ")";
                        txtScript.Text = objRpt.ScriptStored(grdDatos.Rows[grdId].Cells[CeldaConexion].Text, grdDatos.Rows[grdId].Cells[CeldaScript].Text);
                    }

                    mp1.Show();
                }
            }
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkAutorizado");

                if (e.Row.Cells[CeldaAutorizado].Text == "S")
                    chk.Checked = true;
            }
        }

        protected void chkAutorizado_CheckedChanged(object sender, EventArgs e)
        {
            BLReportes objRpt = new BLReportes();
            GridViewRow row = (GridViewRow)((DataControlFieldCell)((CheckBox)sender).Parent).Parent;
            CheckBox chk = (CheckBox)row.FindControl("chkAutorizado");
            int RD_Id = 0;
            bool EsCat = false;

            int.TryParse(row.Cells[CeldaId].Text, out RD_Id);

            if (row.Cells[CeldaTipo].Text.ToLowerInvariant() == "catálogo")
                EsCat = true;

            if (RD_Id > 0)
            {
                objRpt.ActualizarAutorizacionReporte(RD_Id, chk.Checked, EsCat);

                if (chk.Checked)
                    MsgBox.AddMessage("El reporte " + row.Cells[CeldaNombre].Text + " fue dado de alta.", YaBu.MessageBox.uscMsgBox.enmMessageType.Success);
                else
                    MsgBox.AddMessage("El reporte " + row.Cells[CeldaNombre].Text + " fue dado de baja.", YaBu.MessageBox.uscMsgBox.enmMessageType.Success);
            }
            else
            {
                MsgBox.AddMessage("No se obtuvo el Id del reporte", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
            }
        }
    }
}