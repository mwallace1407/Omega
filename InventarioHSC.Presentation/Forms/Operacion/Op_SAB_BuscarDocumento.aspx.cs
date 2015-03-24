using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_SAB_BuscarDocumento : System.Web.UI.Page
    {
        protected const int CeldaRuta = 2;
        protected const int CeldaNombre = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    e.Row.VerticalAlign = VerticalAlign.Bottom;
                    e.Row.Style.Add("height", "60px");
                }

                e.Row.Cells[CeldaNombre].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            lblNoRegs.Visible = false;
            txtFiltro.Text = txtFiltro.Text.Trim();

            if (Page.IsValid && txtFiltro.Text.Length >= 5)
            {
                BLOperaciones obj = new BLOperaciones();
                System.Data.DataTable Resultados = new System.Data.DataTable();

                Resultados = obj.BuscarDocumentosSAB(txtFiltro.Text);

                if (Resultados.TableName != "Error")
                {
                    grdDatos.DataSource = Resultados;
                    grdDatos.DataBind();

                    if (grdDatos.Rows.Count == 0)
                        lblNoRegs.Visible = true;
                    else
                        lblNoRegs.Visible = false;
                }
                else
                {
                    DatosGenerales.EnviaMensaje(Resultados.Rows[0][0].ToString(), "Error al realizar búsqueda", DatosGenerales.TiposMensaje.Error);
                }
            }
            else
            {
                DatosGenerales.EnviaMensaje("Debe ingresar por lo menos 3 caracteres como filtro de búsqueda.", "Advertencia", DatosGenerales.TiposMensaje.Advertencia);
            }
        }
    }
}