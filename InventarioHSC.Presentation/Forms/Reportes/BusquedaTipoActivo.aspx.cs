using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Reportes
{
    public partial class BusquedaTipoActivo : System.Web.UI.Page
    {
        public string TipoActivo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LimpiaDatos();
            this.btnBuscarTipoActivo.Click += new EventHandler(btnBuscarTipoActivo_Click);
            this.gvGeneral.PageIndexChanging += new GridViewPageEventHandler(gvGeneral_PageIndexChanging);

            if (!Page.IsPostBack)
                txtTipoActivo.Text = string.Empty;
        }
        protected void btnBuscarTipoActivo_Click(object sender, EventArgs e)
        {
            if (this.txtTipoActivo.Text != string.Empty)
            {
                this.TipoActivo = txtTipoActivo.Text;
                LlenarGrid();
                gvGeneral.DataBind();
                txtTipoActivo.Text = string.Empty;
            }
        }
        protected void gvGeneral_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGeneral.PageIndex = e.NewPageIndex;
            LlenarGrid();
            gvGeneral.DataBind();
        }
        private void LimpiaDatos()
        {
            gvGeneral.DataSource = null;
            gvGeneral.DataBind();
        }
        private void LlenarGrid()
        {
            BLDatosGenerales dG = new BLDatosGenerales();
            gvGeneral.DataSource = dG.ObtieneDatosGrid(txtTipoActivo.Text);
       }
    }
}