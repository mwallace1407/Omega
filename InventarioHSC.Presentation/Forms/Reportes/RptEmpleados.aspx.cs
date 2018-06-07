using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptEmpleados : System.Web.UI.Page
    {
        protected const int CeldaRuta = 2;
        protected const int CeldaNombre = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        protected void CargaCatalogos()
        {
            grdDatos.DataSource = Fijos();
            grdDatos.DataBind();
        }

        protected System.Data.DataTable Fijos()
        {
            System.Data.DataTable Res = new System.Data.DataTable();

            Res.Columns.Add("Anio");
            Res.Columns.Add("Ruta");

            string[] Archivos = System.IO.Directory.GetFiles(Server.MapPath("Fijos"), "Empleados_*.xlsx");
            System.Data.DataRow dr;

            foreach (string a in Archivos)
            {
                dr = Res.NewRow();
                dr[0] = System.IO.Path.GetFileNameWithoutExtension(a).Replace("Empleados_", "");
                dr[1] = DatosGenerales.RutaReportesFijos + System.IO.Path.GetFileName(a);

                Res.Rows.Add(dr);
            }

            return Res;
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[CeldaNombre].Style.Add("text-align", "left");

                HyperLink lnkRuta = (HyperLink)e.Row.FindControl("lnkRuta");

                if (e.Row.Cells[CeldaRuta].Text == "")
                    lnkRuta.Visible = false;

                lnkRuta.NavigateUrl = e.Row.Cells[CeldaRuta].Text;
                lnkRuta.Text = "Descargar";
            }
        }
    }
}