using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.BusinessLayer;
using InventarioHSC.Model;

namespace InventarioHSC.Forms.Operacion
{
    public partial class Op_Constancias_BuzonE : System.Web.UI.Page
    {
        #region Variables

        private BLConstancias objCon = new BLConstancias();
        protected const int CeldaId = 1;

        #endregion Variables

        #region Metodos

        protected string ArmadoCadena(CheckBoxList chkl)
        {
            string Resultados = "";

            if (chkl.Items.Count > 0 && chkl.Items[0].Value == "0" && chkl.Items[0].Selected)
                return "";

            for (int w = 0; w < chkl.Items.Count; w++)
            {
                if (chkl.Items[w].Selected)
                {
                    Resultados += chkl.Items[w].Value + "|";
                }
            }

            return Resultados;
        }

        protected void CrearJS()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type='text/javascript'>");
            /**********Busca***********/
            sb.Append("function Busca() {");
            sb.Append("var accHost = $get('" + acc01.ClientID + "').AccordionBehavior;");
            sb.Append("accHost.set_SelectedIndex(1);");
            sb.Append("}");
            sb.Append("function catchEnter(e) {");
            sb.Append("var key;");
            sb.Append("if(window.event) {");
            sb.Append("    key = window.event.keyCode; }");
            sb.Append("else {");
            sb.Append("    key = e.which; }");
            sb.Append("if (key == 13) {");
            sb.Append("    Busca(); }");
            sb.Append("}");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "Permisos", sb.ToString());
            btnAplicarFiltro.Attributes.Add("onmousedown", "Busca();");
        }

        #endregion Metodos

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                objCon.ObtenerCatalogos(ref chklAdministradora, (int)DatosGenerales.ConstanciasCatalogos.Administradoras, 0, false, "");
                objCon.ObtenerCatalogos(ref chklPortafolio, (int)DatosGenerales.ConstanciasCatalogos.Portafolios_con_administradora, 0, false, "");
                grdDatos.DataSource = objCon.BuscarLotes("", "", "", "", "", "", "");
                grdDatos.DataBind();
                grdDatos.Columns[CeldaId].Visible = false;

                txtEjercicio.Text = DateTime.Now.AddYears(-1).Year.ToString();
                //CrearJS();
            }
        }

        protected void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            bool HayError = false;

            lblFechaLote.Text = "";
            lblFechaCarga.Text = "";

            if (!string.IsNullOrWhiteSpace(txtFechaLIni.Text) || !string.IsNullOrWhiteSpace(txtFechaLFin.Text))
            {
                if (!DatosGenerales.EsFecha(txtFechaLIni.Text) || !DatosGenerales.EsFecha(txtFechaLFin.Text))
                {
                    HayError = true;
                    lblFechaLote.Text = "Revise las fechas ingresadas.";
                }
            }

            if (!string.IsNullOrWhiteSpace(txtFechaCIni.Text) || !string.IsNullOrWhiteSpace(txtFechaCFin.Text))
            {
                if (!DatosGenerales.EsFecha(txtFechaCIni.Text) || !DatosGenerales.EsFecha(txtFechaCFin.Text))
                {
                    HayError = true;
                    lblFechaCarga.Text = "Revise las fechas ingresadas.";
                }
            }

            if (!HayError)
            {
                grdDatos.DataSource = objCon.BuscarLotes(txtIdentificador.Text, txtFechaCIni.Text, txtFechaCFin.Text, txtFechaLIni.Text, txtFechaLFin.Text, ArmadoCadena(chklAdministradora), ArmadoCadena(chklPortafolio));
                grdDatos.DataBind();
                grdDatos.Columns[CeldaId].Visible = false;
            }
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int Entero = 0;
            bool HayError = false;
            lblMensaje.Text = "";

            int.TryParse(txtEjercicio.Text, out Entero);

            if (Entero < 2015 || Entero > DateTime.Now.Year)
            {
                HayError = true;
                lblMensaje.Text += "Ejercicio incorrecto<br />";
            }

            if (HayError)
                return;

            string Lotes = "";
            int Id;

            Entero = 0;

            for (int w = 0; w < grdDatos.Rows.Count; w++)
            {
                CheckBox chkId = (CheckBox)grdDatos.Rows[w].FindControl("chkId");

                if (chkId.Checked)
                {
                    Id = 0;
                    int.TryParse(grdDatos.Rows[w].Cells[CeldaId].Text, out Id);

                    if (Id > 0)
                    {
                        Entero++;
                        Lotes += Id.ToString() + "|";
                    }
                }
            }

            if (Entero == 0)
            {
                lblMensaje.Text += "No ha seleccionado ningún elemento de la lista<br />";
                return;
            }

            if (!string.IsNullOrWhiteSpace(Lotes))
            {
                string Archivo = Server.MapPath("../Reportes/TmpFiles/") + DatosGenerales.GeneraNombreArchivoRnd("ConsBuzonE_", "txt");
                System.IO.TextWriter tw;
                int Ejercicio = 0;

                tw = new System.IO.StreamWriter(Archivo, false, System.Text.Encoding.UTF8);
                int.TryParse(txtEjercicio.Text, out Ejercicio);

                //GenerarTXT
                System.Data.DataTable Tabla = new System.Data.DataTable();

                Tabla = objCon.GenerarTXTBuzonE(Ejercicio, Lotes);

                for (int w = 0; w < Tabla.Rows.Count; w++)
                {
                    tw.WriteLine(Tabla.Rows[w][0].ToString());
                }

                tw.Close();

                DatosGenerales.EnviaMensaje("Se ha creado el archivo para envío a BuzonE. Puede descargarlo ahora. Para algunos navegadores se recomienda dar clic secundario sobre 'Descargar' y seleccionar 'Guardar enlace como...'.", "Proceso finalizado", System.IO.Path.GetFileName(Archivo), DatosGenerales.TiposMensaje.Informacion);
            }
        }

        #endregion Eventos
    }
}