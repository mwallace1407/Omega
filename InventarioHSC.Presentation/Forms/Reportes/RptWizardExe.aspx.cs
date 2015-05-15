using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptWizardExe : System.Web.UI.Page
    {
        protected const int CeldaParam = 0;
        protected const string RDNulo = "~CampoNulo~";

        protected void CargaCatalogos()
        {
            BLReportes objRpt = new BLReportes();

            if (Session["UserNameLogin"] != null)
                objRpt.ReportesUsuario(ref ddlReportes, Session["UserNameLogin"].ToString());
        }

        protected void AsignarHidden(int Registro, System.Data.DataRow dr)
        {
            HiddenField hdd = new HiddenField();

            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddNombre");
            hdd.Value = dr["Nombre"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddTipo");
            hdd.Value = dr["Tipo"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddTipoDato");
            hdd.Value = dr["TipoDato"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddLongitud");
            hdd.Value = dr["Longitud"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddObligatorio");
            hdd.Value = dr["RDP_Obligatorio"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddEntrada");
            hdd.Value = dr["RDP_Entrada"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddCatId");
            hdd.Value = dr["RDC_Id"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddAceptaNulo");
            hdd.Value = dr["RDP_AceptaNulo"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddBusquedaAprox");
            hdd.Value = dr["RDP_BusquedaAproximada"].ToString();
            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddTexto");
            hdd.Value = dr["RDP_Texto"].ToString();
        }

        protected void AsignarLabel(int Registro, System.Data.DataRow dr)
        {
            Label lbl = new Label();

            lbl = (Label)grdParams.Rows[Registro].FindControl("lblTexto");
            lbl.Text = dr["RDP_Texto"].ToString();
            lbl = (Label)grdParams.Rows[Registro].FindControl("lblObligatorio");

            if (dr["RDP_Obligatorio"].ToString() == "1")
                lbl.Text = "Si";
            else
                lbl.Text = "No";
        }

        protected void CargaCatalogoLst(ref DropDownList ddl, string Id, string Conexion)
        {
            BLDatosGenerales objGen = new BLDatosGenerales();
            BLReportes objRpt = new BLReportes();
            System.Data.DataTable Resultados = new System.Data.DataTable();
            int RDC_Id = 0;
            string Script = "";

            int.TryParse(Id, out RDC_Id);
            Resultados = objRpt.ObtenerScriptCatalogo(RDC_Id);

            if (Resultados.Rows.Count > 0)
                Script = Resultados.Rows[0][0].ToString();

            Resultados = new System.Data.DataTable();

            if (RDC_Id > 0 && Script != "")
                Resultados = objGen.TestScript(Script, System.Configuration.ConfigurationManager.ConnectionStrings[Conexion].ConnectionString);

            if (Resultados.Rows.Count > 0)
            {
                ddl.DataValueField = "Valor";
                ddl.DataTextField = "Descripcion";
                ddl.DataSource = Resultados;
                ddl.DataBind();
            }
        }

        protected void CargaCatalogoChk(ref CheckBoxList chkl, string Id, string Conexion)
        {
            BLDatosGenerales objGen = new BLDatosGenerales();
            BLReportes objRpt = new BLReportes();
            System.Data.DataTable Resultados = new System.Data.DataTable();
            int RDC_Id = 0;
            string Script = "";

            int.TryParse(Id, out RDC_Id);
            Resultados = objRpt.ObtenerScriptCatalogo(RDC_Id);

            if (Resultados.Rows.Count > 0)
                Script = Resultados.Rows[0][0].ToString();

            Resultados = new System.Data.DataTable();

            if (RDC_Id > 0 && Script != "")
                Resultados = objGen.TestScript(Script, System.Configuration.ConfigurationManager.ConnectionStrings[Conexion].ConnectionString);

            if (Resultados.Rows.Count > 0)
            {
                chkl.DataValueField = "Valor";
                chkl.DataTextField = "Descripcion";
                chkl.DataSource = Resultados;
                chkl.DataBind();
            }
        }

        protected void HabilitarControles(int Registro, System.Data.DataRow dr)
        {
            HiddenField hdd = new HiddenField();
            HiddenField hdd2 = new HiddenField();
            HiddenField hdd3 = new HiddenField();
            HiddenField hdd4 = new HiddenField();
            CheckBox chk = new CheckBox();
            int Longitud = 0;

            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddAceptaNulo");
            hdd2 = (HiddenField)grdParams.Rows[Registro].FindControl("hddObligatorio");
            chk = (CheckBox)grdParams.Rows[Registro].FindControl("chkNull");
            chk.Checked = false;

            if (hdd.Value == "1")
                chk.Enabled = true;
            else
                chk.Enabled = false;

            if (hdd2.Value == "1")
                chk.Enabled = false;

            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddBusquedaAprox");
            chk = (CheckBox)grdParams.Rows[Registro].FindControl("chkBAprox");

            if (hdd.Value == "1")
                chk.Enabled = true;
            else
                chk.Enabled = false;

            hdd = (HiddenField)grdParams.Rows[Registro].FindControl("hddEntrada");

            TextBox txt = (TextBox)grdParams.Rows[Registro].FindControl("txtValor");
            TextBox txtm = (TextBox)grdParams.Rows[Registro].FindControl("txtmValor");
            CheckBox chkv = (CheckBox)grdParams.Rows[Registro].FindControl("chkValor");
            CheckBoxList chkl = (CheckBoxList)grdParams.Rows[Registro].FindControl("chklValor");
            Panel pnl = (Panel)grdParams.Rows[Registro].FindControl("pnlchkl");
            DropDownList ddl = (DropDownList)grdParams.Rows[Registro].FindControl("ddlValor");

            txt.Visible = false;
            txtm.Visible = false;
            chkv.Visible = false;
            chkl.Visible = false;
            pnl.Visible = false;
            ddl.Visible = false;

            hdd2 = (HiddenField)grdParams.Rows[Registro].FindControl("hddCatId");
            hdd3 = (HiddenField)grdParams.Rows[Registro].FindControl("hddLongitud");
            hdd4 = (HiddenField)grdParams.Rows[Registro].FindControl("hddTipoDato");
            int.TryParse(hdd3.Value, out Longitud);

            switch (hdd.Value)
            {
                case "txt":
                    txt.Visible = true;

                    if (Longitud <= 0)
                        Longitud = DatosGenerales.LongitudBaseCampo;

                    if (Longitud == -1)
                        Longitud = 0;

                    txt.MaxLength = Longitud;
                    txt.Style["text-align"] = "left";
                    AjaxControlToolkit.FilteredTextBoxExtender filter = (AjaxControlToolkit.FilteredTextBoxExtender)grdParams.Rows[Registro].FindControl("txtValor_FilteredTextBoxExtender");

                    switch (DatosGenerales.Equivalencia_SQLDotNet(hdd4.Value).ToLowerInvariant())
                    {
                        case "boolean":
                            txt.Visible = false;
                            chkv.Visible = true;
                            break;
                        case "datetime":
                            AjaxControlToolkit.MaskedEditExtender mask = (AjaxControlToolkit.MaskedEditExtender)grdParams.Rows[Registro].FindControl("txtValor_MaskedEditExtender");
                            AjaxControlToolkit.CalendarExtender cal = (AjaxControlToolkit.CalendarExtender)grdParams.Rows[Registro].FindControl("txtValor_CalendarExtender");
                            mask.Enabled = true;
                            cal.Enabled = true;
                            txt.Style["text-align"] = "center";
                            break;
                        case "decimal":
                        case "double":
                        case "single":
                            filter.Enabled = true;
                            filter.FilterType = AjaxControlToolkit.FilterTypes.Numbers | AjaxControlToolkit.FilterTypes.Custom;
                            filter.ValidChars = "-.";
                            break;
                        case "int16":
                        case "int32":
                        case "int64":
                            filter.Enabled = true;
                            filter.FilterType = AjaxControlToolkit.FilterTypes.Numbers | AjaxControlToolkit.FilterTypes.Custom;
                            filter.ValidChars = "-";
                            break;
                        case "byte":
                            filter.Enabled = true;
                            filter.FilterType = AjaxControlToolkit.FilterTypes.Numbers;
                            break;
                    }

                    break;
                case "txtm":
                    txtm.Visible = true;

                    if (Longitud <= 0)
                        Longitud = DatosGenerales.LongitudBaseCampo;

                    txtm.MaxLength = Longitud;
                    break;
                case "chk":
                    chkv.Visible = true;
                    break;
                case "lchk":
                    pnl.Visible = true;
                    chkl.Visible = true;
                    CargaCatalogoChk(ref chkl, hdd2.Value, hddConexion.Value);
                    break;
                case "lst":
                    ddl.Visible = true;
                    CargaCatalogoLst(ref ddl, hdd2.Value, hddConexion.Value);
                    break;
            }
        }

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

        protected string Validar()
        {
            string Errores = "";
            HiddenField hddEntrada = new HiddenField();
            HiddenField hddObligatorio = new HiddenField();
            HiddenField hddTipoDato = new HiddenField();
            HiddenField hddValor = new HiddenField();
            HiddenField hddLongitud = new HiddenField();

            for (int w = 0; w < grdParams.Rows.Count; w++)
            {
                hddEntrada = (HiddenField)grdParams.Rows[w].FindControl("hddEntrada");
                hddObligatorio = (HiddenField)grdParams.Rows[w].FindControl("hddObligatorio");
                hddTipoDato = (HiddenField)grdParams.Rows[w].FindControl("hddTipoDato");
                hddValor = (HiddenField)grdParams.Rows[w].FindControl("hddValor");
                hddLongitud = (HiddenField)grdParams.Rows[w].FindControl("hddLongitud");

                TextBox txt = (TextBox)grdParams.Rows[w].FindControl("txtValor");
                TextBox txtm = (TextBox)grdParams.Rows[w].FindControl("txtmValor");
                CheckBox chkv = (CheckBox)grdParams.Rows[w].FindControl("chkValor");
                CheckBoxList chkl = (CheckBoxList)grdParams.Rows[w].FindControl("chklValor");
                DropDownList ddl = (DropDownList)grdParams.Rows[w].FindControl("ddlValor");
                CheckBox chkNull = (CheckBox)grdParams.Rows[w].FindControl("chkNull");
                CheckBox chkBAprox = (CheckBox)grdParams.Rows[w].FindControl("chkBAprox");

                if (hddObligatorio.Value == "1")
                {
                    switch (hddEntrada.Value)
                    {
                        case "txt":
                            switch (DatosGenerales.Equivalencia_SQLDotNet(hddTipoDato.Value).ToLowerInvariant())
                            {
                                case "datetime":
                                    if (!DatosGenerales.EsFecha(txt.Text))
                                        Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Fecha incorrecta." + "<br/>";
                                    else
                                        hddValor.Value = txt.Text.Trim();
                                    break;
                                case "decimal":
                                case "double":
                                case "single":
                                    double testD = 0;

                                    if (!double.TryParse(txt.Text, out testD))
                                        Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Número decimal incorrecto." + "<br/>";
                                    else
                                        hddValor.Value = txt.Text.Trim();
                                    break;
                                case "int16":
                                case "int32":
                                case "int64":
                                    Int64 testI = 0;

                                    if (!Int64.TryParse(txt.Text, out testI))
                                        Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Número entero incorrecto." + "<br/>";
                                    else
                                        hddValor.Value = txt.Text.Trim();
                                    break;
                                case "byte":
                                    byte testB = 0;

                                    if (!byte.TryParse(txt.Text, out testB))
                                        Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Número entero incorrecto." + "<br/>";
                                    else
                                        hddValor.Value = txt.Text.Trim();
                                    break;
                                case "boolean":
                                    if (chkv.Checked)
                                        hddValor.Value = "1";
                                    else
                                        hddValor.Value = "0";
                                    break;
                                default:
                                    if (string.IsNullOrWhiteSpace(txt.Text))
                                    {
                                        Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Filtro vacío." + "<br/>";
                                    }
                                    else
                                    {
                                        int Longitud = 0;

                                        txt.Text = txt.Text.Trim();
                                        int.TryParse(hddLongitud.Value, out Longitud);

                                        if (chkBAprox.Checked && txt.Text.Length + 2 > Longitud)
                                            Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Cadena demasiado larga. Al usar búsqueda aproximada se restan dos caracteres." + "<br/>";
                                        else
                                            hddValor.Value = txt.Text;
                                    }
                                    break;
                            }
                            break;
                        case "txtm":
                            if (string.IsNullOrWhiteSpace(txtm.Text))
                                Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Filtro vacío." + "<br/>";
                            else
                                hddValor.Value = txtm.Text.Trim();
                            break;
                        case "chk":
                            if (chkv.Checked)
                                hddValor.Value = "1";
                            else
                                hddValor.Value = "0";
                            break;
                        case "lchk":
                            string Cadena = ArmadoCadena(chkl);

                            if (string.IsNullOrWhiteSpace(Cadena))
                                Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": No hay elementos seleccionados." + "<br/>";
                            else
                                hddValor.Value = Cadena;
                            break;
                        case "lst":
                            if (ddl.SelectedIndex > 0)
                                hddValor.Value = ddl.SelectedValue;
                            break;
                    }
                }
                else
                {
                    if (chkNull.Checked)
                    {
                        hddValor.Value = RDNulo;
                    }
                    else
                    {
                        switch (hddEntrada.Value)
                        {
                            case "txt":
                                if (!string.IsNullOrWhiteSpace(txt.Text))
                                {
                                    switch (DatosGenerales.Equivalencia_SQLDotNet(hddTipoDato.Value).ToLowerInvariant())
                                    {
                                        case "datetime":
                                            if (!DatosGenerales.EsFecha(txt.Text))
                                                Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Fecha incorrecta." + "<br/>";
                                            else
                                                hddValor.Value = txt.Text.Trim();
                                            break;
                                        case "decimal":
                                        case "double":
                                        case "single":
                                            double testD = 0;

                                            if (!double.TryParse(txt.Text, out testD))
                                                Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Número decimal incorrecto." + "<br/>";
                                            else
                                                hddValor.Value = txt.Text.Trim();
                                            break;
                                        case "int16":
                                        case "int32":
                                        case "int64":
                                            Int64 testI = 0;

                                            if (!Int64.TryParse(txt.Text, out testI))
                                                Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Número entero incorrecto." + "<br/>";
                                            else
                                                hddValor.Value = txt.Text.Trim();
                                            break;
                                        case "byte":
                                            byte testB = 0;

                                            if (!byte.TryParse(txt.Text, out testB))
                                                Errores += "Filtro #" + w.ToString().PadLeft(2, Convert.ToChar("0")) + ": Número entero incorrecto." + "<br/>";
                                            else
                                                hddValor.Value = txt.Text.Trim();
                                            break;
                                        case "boolean":
                                            if (chkv.Checked)
                                                hddValor.Value = "1";
                                            else
                                                hddValor.Value = "0";
                                            break;
                                        default:
                                            if (string.IsNullOrWhiteSpace(txt.Text))
                                                hddValor.Value = "";
                                            else
                                                hddValor.Value = txt.Text.Trim();
                                            break;
                                    }
                                }
                                else
                                {
                                    hddValor.Value = "";

                                    if (chkv.Visible)
                                    {
                                        if (chkv.Checked)
                                            hddValor.Value = "1";
                                        else
                                            hddValor.Value = "0";
                                    }
                                }
                                break;
                            case "txtm":
                                if (string.IsNullOrWhiteSpace(txtm.Text))
                                    hddValor.Value = "";
                                else
                                    hddValor.Value = txtm.Text.Trim();
                                break;
                            case "chk":
                                if (chkv.Checked)
                                    hddValor.Value = "1";
                                else
                                    hddValor.Value = "0";
                                break;
                            case "lchk":
                                string Cadena = ArmadoCadena(chkl);

                                if (string.IsNullOrWhiteSpace(Cadena))
                                    hddValor.Value = "";
                                else
                                    hddValor.Value = Cadena;
                                break;
                            case "lst":
                                if (ddl.SelectedIndex > 0)
                                    hddValor.Value = ddl.SelectedValue;
                                else
                                    hddValor.Value = "";
                                break;
                        }
                    }
                }

                if (hddValor.Value != "" && chkBAprox.Checked)
                    hddValor.Value = "%" + hddValor.Value + "%";
            }

            return Errores;
        }

        //protected string[][] ArmadoParametros()
        //{
        //    string[][] Params = new string[grdParams.Rows.Count][];
        //    HiddenField hddTipoDato = new HiddenField();
        //    HiddenField hddValor = new HiddenField();
        //    HiddenField hddNombre = new HiddenField();
        //    HiddenField hddLongitud = new HiddenField();
        //    int Longitud = 0; //Para forzar la salida de un número

        //    for (int w = 0; w < grdParams.Rows.Count; w++)
        //    {
        //        hddTipoDato = (HiddenField)grdParams.Rows[w].FindControl("hddTipoDato");
        //        hddValor = (HiddenField)grdParams.Rows[w].FindControl("hddValor");
        //        hddNombre = (HiddenField)grdParams.Rows[w].FindControl("hddNombre");
        //        hddLongitud = (HiddenField)grdParams.Rows[w].FindControl("hddLongitud");
        //        int.TryParse(hddLongitud.Value, out Longitud);


        //        Params[w] = new string[] { hddNombre.Value, hddValor.Value, hddTipoDato.Value.ToLowerInvariant(), Longitud.ToString() };
        //    }

        //    return Params;
        //}

        protected System.Data.DataTable ArmadoParametros()
        {
            System.Data.DataTable Params = new System.Data.DataTable("Parametros");
            System.Data.DataRow dr;
            HiddenField hddTipoDato = new HiddenField();
            HiddenField hddValor = new HiddenField();
            HiddenField hddNombre = new HiddenField();
            HiddenField hddLongitud = new HiddenField();
            int Longitud = 0; //Para forzar la salida de un número

            Params.Columns.Add("Nombre");
            Params.Columns.Add("Valor");
            Params.Columns.Add("Tipo");
            Params.Columns.Add("Longitud");

            for (int w = 0; w < grdParams.Rows.Count; w++)
            {
                hddTipoDato = (HiddenField)grdParams.Rows[w].FindControl("hddTipoDato");
                hddValor = (HiddenField)grdParams.Rows[w].FindControl("hddValor");
                hddNombre = (HiddenField)grdParams.Rows[w].FindControl("hddNombre");
                hddLongitud = (HiddenField)grdParams.Rows[w].FindControl("hddLongitud");
                int.TryParse(hddLongitud.Value, out Longitud);

                dr = Params.NewRow();
                dr["Nombre"] = hddNombre.Value;
                dr["Valor"] = hddValor.Value;
                dr["Tipo"] = hddTipoDato.Value.ToLowerInvariant();
                dr["Longitud"] = Longitud.ToString();
                Params.Rows.Add(dr);
            }

            Params.AcceptChanges();

            return Params;
        }

        protected void CargarReporte()
        {
            int RD_Id = 0;

            int.TryParse(ddlReportes.SelectedValue, out RD_Id);
            btnEjecutar.Visible = false;

            if (RD_Id > 0)
            {
                BLReportes objRpt = new BLReportes();
                System.Data.DataTable Resultados = new System.Data.DataTable();

                Resultados = objRpt.ObtenerParametrosReporteOrdenado(RD_Id);
                grdParams.DataSource = Resultados;
                grdParams.DataBind();
                grdParams.Columns[CeldaParam].Visible = false;

                if (Resultados.Rows.Count > 0)
                {
                    hddConexion.Value = Resultados.Rows[0]["RD_Conexion"].ToString();

                    for (int w = 0; w < Resultados.Rows.Count; w++)
                    {
                        AsignarHidden(w, Resultados.Rows[w]);
                        AsignarLabel(w, Resultados.Rows[w]);
                        HabilitarControles(w, Resultados.Rows[w]);
                    }
                }

                btnEjecutar.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

                CargaCatalogos();
                lblMensaje.Text = (ddlReportes.Items.Count - 1).ToString() + " reportes encontrados.";
                txtSearch.Focus();
            }
        }

        protected void ddlReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            string Errores = "";

            Errores = Validar();

            if (Errores != "")
            {
                mp1.Show();
                lblMsj.Text = "Errores encontrados: " + "<br/><br/>" + Errores;
            }
            else
            {
                int RD_Id = 0;

                int.TryParse(ddlReportes.SelectedValue, out RD_Id);

                if (RD_Id > 0)
                {
                    WS_Excel.ExportarSoapClient exportar = new WS_Excel.ExportarSoapClient();

                    exportar.EjecutarRD((int)DatosGenerales.TiposDocumentos.Reportes_Dinamicos, Session["UserNameLogin"].ToString(), Server.MapPath(DatosGenerales.RutaLocalReportesDinamicos), DatosGenerales.GeneraNombreArchivoRnd("RptWSDin_", "xlsx"), 250000,
                                        ArmadoParametros(),
                                        RD_Id);

                    Response.Redirect("DocumentosUsuario.aspx");
                }
                else
                {
                    mp1.Show();
                    lblMsj.Text = "Errores encontrados: " + "<br/><br/>No se obtuvo el Id del reporte.";
                }
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}