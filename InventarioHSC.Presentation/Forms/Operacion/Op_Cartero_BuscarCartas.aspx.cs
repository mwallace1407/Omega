using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_Cartero_BuscarCartas : System.Web.UI.Page
    {
        protected const int CeldaId = 0;
        public System.Data.DataTable Resultados = new System.Data.DataTable();

        protected void Cargar()
        {
            BLReportes objRep = new BLReportes();
            DateTime FechaIni = DatosGenerales.ObtieneFecha(txtFechaIni.Text);
            DateTime FechaFin = DatosGenerales.ObtieneFecha(txtFechaFin.Text);
            DateTime FechaTmp;
            int Prestamo = 0;

            pnlDatos.Visible = false;
            lblMsj.Text = "";

            if (chkFechas.Checked)
            {
                if (FechaIni.ToString("yyyyMMdd") == "19000101" || FechaFin.ToString("yyyyMMdd") == "19000101")
                {
                    lblMsj.Text = "Fecha incorrecta. Revise.";
                    return;
                }

                if (FechaIni > FechaFin)
                {
                    FechaTmp = FechaIni;
                    FechaIni = FechaFin;
                    FechaFin = FechaTmp;
                    txtFechaIni.Text = FechaIni.ToString("dd/MM/yyyy");
                    txtFechaFin.Text = FechaFin.ToString("dd/MM/yyyy");
                }
            }

            int.TryParse(txtPrestamo.Text, out Prestamo);
            grdDatos.Columns[CeldaId].Visible = true;
            grdDatos.DataSource = objRep.ReporteCartasGeneradas(Prestamo, txtAcreditado.Text, chkFechas.Checked, FechaIni, FechaFin);
            grdDatos.DataBind();
            grdDatos.Columns[CeldaId].Visible = false;

            if (grdDatos.Rows.Count > 0)
                pnlDatos.Visible = true;
            else
                lblMsj.Text = "No se encontraron resultados.";
        }

        protected void Cargar(int Pagina)
        {
            BLReportes objRep = new BLReportes();
            DateTime FechaIni = DatosGenerales.ObtieneFecha(txtFechaIni.Text);
            DateTime FechaFin = DatosGenerales.ObtieneFecha(txtFechaFin.Text);
            DateTime FechaTmp;
            int Prestamo = 0;

            pnlDatos.Visible = false;
            lblMsj.Text = "";

            if (chkFechas.Checked)
            {
                if (FechaIni.ToString("yyyyMMdd") == "19000101" || FechaFin.ToString("yyyyMMdd") == "19000101")
                {
                    lblMsj.Text = "Fecha incorrecta. Revise.";
                    return;
                }

                if (FechaIni > FechaFin)
                {
                    FechaTmp = FechaIni;
                    FechaIni = FechaFin;
                    FechaFin = FechaTmp;
                    txtFechaIni.Text = FechaIni.ToString("dd/MM/yyyy");
                    txtFechaFin.Text = FechaFin.ToString("dd/MM/yyyy");
                }
            }

            int.TryParse(txtPrestamo.Text, out Prestamo);
            grdDatos.Columns[CeldaId].Visible = true;
            grdDatos.DataSource = objRep.ReporteCartasGeneradas(Prestamo, txtAcreditado.Text, chkFechas.Checked, FechaIni, FechaFin);
            grdDatos.PageIndex = Pagina;
            grdDatos.DataBind();
            grdDatos.Columns[CeldaId].Visible = false;

            if (grdDatos.Rows.Count > 0)
                pnlDatos.Visible = true;
            else
                lblMsj.Text = "No se encontraron resultados.";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFechaIni.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                txtFechaFin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }

            //DataBound();
        }

        protected void DataBound()
        {
            int Cart_Id = 0;

            foreach (GridViewRow Row in grdDatos.Rows)
            {
                Row.Cells[CeldaId].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)Row.FindControl("lnkRuta");

                if (!int.TryParse(Row.Cells[CeldaId].Text, out Cart_Id))
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = "Op_Cartero_CreaPDF.aspx?CartId=" + Cart_Id.ToString();
                lnkRuta.Text = "Descargar";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int Cart_Id = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[CeldaId].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (!int.TryParse(e.Row.Cells[CeldaId].Text, out Cart_Id))
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = "Op_Cartero_CreaPDF.aspx?CartId=" + Cart_Id.ToString();
                lnkRuta.Text = "Descargar";
            }
        }

        protected void grdDatos_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            Cargar(e.NewPageIndex);
        }
    }
}