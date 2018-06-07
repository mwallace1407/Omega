using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Articulos
{
    public partial class ReubicarEquipos : System.Web.UI.Page
    {
        protected const int CeldaId = 0;

        protected void CargaCatalogos()
        {
            BLArticulo objArt = new BLArticulo();

            objArt.ListaUbicacionesR(ref ddlUbicaciones);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
                txtBuscar.Focus();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BLArticulo objArt = new BLArticulo();

            lblMsj.Text = "";
            pnlDatos.Visible = false;
            grdDatos.DataSource = objArt.BuscarArticulosUnity(txtBuscar.Text);
            grdDatos.DataBind();

            ddlUbicaciones.SelectedIndex = -1;

            if (grdDatos.Rows.Count > 0)
            {
                grdDatos.Columns[CeldaId].Visible = false;
                pnlDatos.Visible = true;
            }
            else
            {
                lblMsj.Text = "No se encontraron resultados para el criterio ingresado";
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            BLArticulo objArt = new BLArticulo();
            int idItem = 0;
            int idUbicacion = 0;

            int.TryParse(ddlUbicaciones.SelectedValue, out idUbicacion);

            if (idUbicacion > 0)
            {
                for (int w = 0; w < grdDatos.Rows.Count; w++)
                {
                    CheckBox chkReubicar = (CheckBox)grdDatos.Rows[w].FindControl("chkReubicar");

                    if (chkReubicar.Checked)
                    {
                        int.TryParse(grdDatos.Rows[w].Cells[CeldaId].Text, out idItem);

                        if (idItem > 0)
                        {
                            objArt.ReubicarEquipos(idItem, idUbicacion);
                        }
                    }
                }

                DatosGenerales.EnviaMensaje("Proceso finalizado", "Reubicación de equipos", DatosGenerales.TiposMensaje.Informacion);
            }
        }
    }
}