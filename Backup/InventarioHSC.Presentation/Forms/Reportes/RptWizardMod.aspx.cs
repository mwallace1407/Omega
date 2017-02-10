using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InventarioHSC.Model;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Reportes
{
    public partial class RptWizardMod : System.Web.UI.Page
    {
        protected const int CeldaNombre = 1;
        protected const int CeldaTipo = 2;
        protected const int CeldaTipoDato = 3;
        protected const int CeldaLongitud = 4;
        protected const int CeldaObligatorio = 5;
        protected const int CeldaEntrada = 6;
        protected const int CeldaCat = 7;
        protected const int CeldaBAprox = 9;
        protected const int CeldaDescripcion = 10;

        #region Metodos
        protected void CargaCatalogos()
        {
            //Cargar lista de conecciones
            ListItem itm = new ListItem();

            foreach (System.Configuration.ConnectionStringSettings c in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                if (!string.IsNullOrWhiteSpace(c.ConnectionString) && c.Name.ToLower() != "localsqlserver")
                {
                    itm = new ListItem(c.Name, c.Name);
                    ddlCnx.Items.Add(itm);
                }
            }

            DatosGenerales.OrdenarDDL(ref ddlCnx);
            itm = new ListItem("Seleccionar", "");
            ddlCnx.Items.Insert(0, itm);

            //Cargar tipos de script
            BLCatalogos objCat = new BLCatalogos();

            objCat.ListaTiposScript(ref ddlTipoScript);
            ddlTipoScript.DataBind();

            if (ddlTipoScript.Items.Count > 0)
                ddlTipoScript.Items[0].Value = "";
        }

        #region Paso02
        protected void Limpieza02(bool Completa = false)
        {
            lblMsj02.Text = "";
            btnAgregar02.Enabled = false;
            pnlEstilo02.Visible = false;
            ddlResultadoPaso02.DataSource = null;
            ddlResultadoPaso02.DataBind();
            chkResultadoPaso02.DataSource = null;
            chkResultadoPaso02.DataBind();

            if (Completa)
            {
                txtDescripcion02.Text = "";
                txtScriptPaso02.Text = "";
                rbEstilochk02.Checked = false;
                rbEstiloddl02.Checked = false;
            }
        }

        protected bool Validar02()
        {
            BLDatosGenerales objGen = new BLDatosGenerales();
            System.Data.DataTable Resultados = new System.Data.DataTable();
            bool HayError = true;

            Limpieza02();

            if (string.IsNullOrWhiteSpace(ddlCnx.SelectedValue))
            {
                lblMsj02.Text = "Conexión incorrecta.";
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion02.Text))
            {
                lblMsj02.Text = "Descripción incorrecta.";
                return true;
            }

            Resultados = objGen.TestScript(txtScriptPaso02.Text, System.Configuration.ConfigurationManager.ConnectionStrings[ddlCnx.SelectedValue].ConnectionString);

            if (Resultados.Columns.Count != 2 || !(Resultados.Columns.Contains("Valor") & Resultados.Columns.Contains("Descripcion")))
            {
                txtScriptPaso02.Text = objGen.FormatearSQL_TextoSimple(txtScriptPaso02.Text, 4);

                if (string.IsNullOrWhiteSpace(txtScriptPaso02.Text))
                    txtScriptPaso02.Text = "";

                lblMsj02.Text = "El Query ingresado no cumple con los requerimientos. Verifique.";
            }
            else
            {
                //Script correcto
                ddlResultadoPaso02.DataValueField = "Valor";
                ddlResultadoPaso02.DataTextField = "Descripcion";
                ddlResultadoPaso02.DataSource = Resultados;
                ddlResultadoPaso02.DataBind();

                ListItem itm = new ListItem("", "");
                ddlResultadoPaso02.Items.Insert(0, itm);

                chkResultadoPaso02.DataValueField = "Valor";
                chkResultadoPaso02.DataTextField = "Descripcion";
                chkResultadoPaso02.DataSource = Resultados;
                chkResultadoPaso02.DataBind();

                pnlEstilo02.Visible = true;

                txtScriptPaso02.Text = objGen.FormatearSQL_TextoSimple(txtScriptPaso02.Text, 4);
                hddTipo02.Value = Resultados.Columns[0].DataType.ToString().Replace("System.", "");
                btnProcesar02.Enabled = true;
                btnAgregar02.Enabled = true;
                HayError = false;
            }

            return HayError;
        }
        #endregion Paso02
        #region Paso04
        #region Stored
        protected void CargaStored()
        {
            BLCatalogos objCat = new BLCatalogos();

            objCat.ListaStoreds(ref ddlStored, ddlCnx.SelectedValue, true);
        }

        protected void CargaParamsStored()
        {
            BLReportes objRep = new BLReportes();

            hddGridStoredProcesado.Value = "0";
            grdParams.DataSource = objRep.ParametrosStored(ddlCnx.SelectedValue, ddlStored.SelectedValue);
            grdParams.DataBind();
            grdParams.Columns[CeldaTipo].Visible = false;
            hddGridStoredProcesado.Value = "1";
        }

        protected string ValidarGridParams()
        {
            string Errores = "";

            if (string.IsNullOrWhiteSpace(txtNombreReporte.Text))
            {
                Errores = "Debe asignar un nombre a su reporte.";
                txtNombreReporte.Focus();
                return Errores;
            }

            for (int w = 0; w < grdParams.Rows.Count; w++)
            {
                CheckBox chkO = (CheckBox)grdParams.Rows[w].FindControl("chkObligatorio");

                if (chkO.Checked)
                {
                    Label lblN = (Label)grdParams.Rows[w].FindControl("lblNull");

                    lblN.Text = "No";
                }

                Label lblE = (Label)grdParams.Rows[w].FindControl("lblEntrada");

                if (lblE.Text == "")
                {
                    Errores = "Debe asignar un tipo de entrada para cada parámetro.";
                    break;
                }

                Label lblD = (Label)grdParams.Rows[w].FindControl("lblDesc");

                if (string.IsNullOrWhiteSpace(lblD.Text) || lblD.Text == "&nbsp;")
                {
                    Errores = "Debe asignar una descripción para cada parámetro.";
                    break;
                }
            }

            return Errores;
        }

        protected void CompararDatos(int RD_Id, bool PreviamenteCargado = true)
        {
            System.Data.DataTable Resultados = new System.Data.DataTable();
            BLReportes objRpt = new BLReportes();

            Resultados = objRpt.ObtenerParametrosReporte(RD_Id);

            txtNombreReporte.Text = ddlReportesStored.SelectedItem.Text;
            ddlStored.SelectedValue = Resultados.Rows[0]["RD_Script"].ToString();

            if (PreviamenteCargado)
            {
                grdParams.SelectedIndex = -1;
                pnlTipo04.Visible = false;

                if (!string.IsNullOrWhiteSpace(ddlStored.SelectedValue))
                {
                    CargaParamsStored();
                }
                else
                {
                    grdParams.DataSource = null;
                    grdParams.DataBind();
                }

                if (grdParams.Rows.Count > 0)
                {
                    btnProcesar04.Visible = true;
                    pnlGrid.Visible = true;
                }
                else
                {
                    btnProcesar04.Visible = false;
                    pnlGrid.Visible = false;
                }
            }

            for (int w = 0; w < Resultados.Rows.Count; w++)
            {
                foreach (GridViewRow row in grdParams.Rows)
                {
                    if (Resultados.Rows[w]["Nombre"].ToString() == row.Cells[CeldaNombre].Text)
                    {
                        Label lblE = (Label)row.FindControl("lblEntrada");
                        Label lblC = (Label)row.FindControl("lblCat");
                        Label lblN = (Label)row.FindControl("lblNull");
                        Label lblB = (Label)row.FindControl("lblBAprox");
                        Label lblD = (Label)row.FindControl("lblDesc");
                        CheckBox chkO = (CheckBox)row.FindControl("chkObligatorio");

                        if (Resultados.Rows[w]["RDP_Obligatorio"].ToString() == "1")
                            chkO.Checked = true;
                        else
                            chkO.Checked = false;

                        lblE.Text = Resultados.Rows[w]["RDP_Entrada"].ToString();
                        lblC.Text = Resultados.Rows[w]["RDC_Id"].ToString();
                        lblD.Text = Resultados.Rows[w]["RDP_Texto"].ToString();

                        if (Resultados.Rows[w]["RDP_AceptaNulo"].ToString() == "1")
                            lblN.Text = "Si";
                        else
                            lblN.Text = "No";

                        if (Resultados.Rows[w]["RDP_BusquedaAproximada"].ToString() == "1")
                            lblB.Text = "Si";
                        else
                            lblB.Text = "No";

                        if (chkO.Checked)
                            lblN.Text = "No";

                        row.Cells[CeldaTipoDato].Text = Resultados.Rows[w]["TipoDato"].ToString();
                        row.Cells[CeldaLongitud].Text = Resultados.Rows[w]["Longitud"].ToString();

                        break;
                    }
                }
            }

            pnlStoredC.Visible = true;
        }
        #endregion Stored
        #region Query
        private IEnumerable<string> AnalizarScript(string Script)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string[] Separador = { " " };

            Script = Script.Replace(Environment.NewLine, "?? ");
            Script = Script.Replace("\r", "?? ");
            Script = Script.Replace("\n", "?? ");

            foreach (char c in Script)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_' || c == '@' || c == ' ')
                {
                    sb.Append(c);
                }
            }

            string[] Resultados = sb.ToString().Split(Separador, StringSplitOptions.RemoveEmptyEntries);
            List<string> Variables = new List<string>();

            foreach (string str in Resultados)
            {
                if (str.Length == 1)
                {
                    if (str.Substring(0, 1) == "@")
                        Variables.Add(str);
                }
                else if (str.Length > 1)
                {
                    if (str.Substring(0, 1) == "@" && str.Substring(1, 1) != "@")
                        Variables.Add(str);
                }
            }

            Variables.Sort();

            return Variables.Distinct();
        }

        protected void RegistrarQuery()
        {
            BLDatosGenerales objGen = new BLDatosGenerales();

            if (string.IsNullOrWhiteSpace(txtScriptPaso04.Text))
                btnIngresarQ.Text = "Ingresar script";
            else
                btnIngresarQ.Text = "Modificar script";

            txtScriptPaso04.Text = objGen.FormatearSQL_TextoSimple(txtScriptPaso04.Text, 4);

            IEnumerable<string> Variables = AnalizarScript(txtScriptPaso04.Text);

            if (Variables.Count() > 0)
            {
                BLReportes objRpt = new BLReportes();

                grdParamsQ.DataSource = objRpt.CargarParametrosScript(Variables);
                grdParamsQ.DataBind();
                grdParamsQ.Columns[CeldaTipo].Visible = false;
                btnProcesar04Q.Visible = true;
                pnlGridQ.Visible = true;
            }
            else
            {
                grdParamsQ.DataSource = null;
                grdParamsQ.DataBind();
                btnProcesar04Q.Visible = false;
                pnlGridQ.Visible = false;
                lblMsj04Script.Text = "No se encontraron variables en el script.";
            }
        }

        protected void ValidarTD()
        {
            if (DatosGenerales.Equivalencia_SQLDotNet(ddlTipoDatoQ.SelectedValue) == "String")
                pnlLongitud04Q.Visible = true;
            else
                pnlLongitud04Q.Visible = false;

            hddAplicaLongitud.Value = pnlLongitud04Q.Visible == true ? "1" : "0";
            chkAprox04Q.Checked = false;

            if (DatosGenerales.Equivalencia_SQLDotNet(ddlTipoDatoQ.SelectedValue) == "String" && !ddlTipoDatoQ.SelectedValue.ToLower().Contains("date") && !ddlTipoDatoQ.SelectedValue.ToLower().Contains("time"))
                pnlAprox04Q.Visible = true;
            else
                pnlAprox04Q.Visible = false;

            if (hddAplicaLongitud.Value == "1")
                txtLongitud04Q.Focus();
        }

        protected string ValidarGridParamsQ()
        {
            string Errores = "";

            if (string.IsNullOrWhiteSpace(txtNombreReporteQ.Text))
            {
                Errores = "Debe asignar un nombre a su reporte.";
                txtNombreReporteQ.Focus();
                return Errores;
            }

            for (int w = 0; w < grdParamsQ.Rows.Count; w++)
            {
                CheckBox chkO = (CheckBox)grdParamsQ.Rows[w].FindControl("chkObligatorio");

                if (chkO.Checked)
                {
                    Label lblN = (Label)grdParamsQ.Rows[w].FindControl("lblNull");

                    lblN.Text = "No";
                }

                Label lblE = (Label)grdParamsQ.Rows[w].FindControl("lblEntrada");

                if (lblE.Text == "")
                {
                    Errores = "Debe asignar un tipo de entrada para cada parámetro.";
                    break;
                }

                if (string.IsNullOrWhiteSpace(grdParamsQ.Rows[w].Cells[CeldaTipoDato].Text) || grdParamsQ.Rows[w].Cells[CeldaTipoDato].Text == "&nbsp;")
                {
                    Errores = "Debe asignar un tipo de dato para cada parámetro.";
                    break;
                }

                //if (string.IsNullOrWhiteSpace(grdParamsQ.Rows[w].Cells[CeldaTipo].Text) || grdParamsQ.Rows[w].Cells[CeldaTipo].Text == "&nbsp;")
                //{
                //    Errores = "Debe asignar un tipo para cada parámetro.";
                //    break;
                //}

                Label lblD = (Label)grdParamsQ.Rows[w].FindControl("lblDesc");

                if (string.IsNullOrWhiteSpace(lblD.Text) || lblD.Text == "&nbsp;")
                {
                    Errores = "Debe asignar una descripción para cada parámetro.";
                    break;
                }
            }

            return Errores;
        }

        protected void CompararDatosQ(int RD_Id, bool PreviamenteCargado = true)
        {
            System.Data.DataTable Resultados = new System.Data.DataTable();
            BLReportes objRpt = new BLReportes();

            Resultados = objRpt.ObtenerParametrosReporte(RD_Id);

            txtNombreReporteQ.Text = ddlReportesTexto.SelectedItem.Text;


            if (PreviamenteCargado)
            {
                txtScriptPaso04.Text = Resultados.Rows[0]["RD_Script"].ToString();
                RegistrarQuery();
            }

            for (int w = 0; w < Resultados.Rows.Count; w++)
            {
                foreach (GridViewRow row in grdParamsQ.Rows)
                {
                    if (Resultados.Rows[w]["Nombre"].ToString() == row.Cells[CeldaNombre].Text)
                    {
                        Label lblE = (Label)row.FindControl("lblEntrada");
                        Label lblC = (Label)row.FindControl("lblCat");
                        Label lblN = (Label)row.FindControl("lblNull");
                        Label lblB = (Label)row.FindControl("lblBAprox");
                        Label lblD = (Label)row.FindControl("lblDesc");
                        CheckBox chkO = (CheckBox)row.FindControl("chkObligatorio");

                        if (Resultados.Rows[w]["RDP_Obligatorio"].ToString() == "1")
                            chkO.Checked = true;
                        else
                            chkO.Checked = false;

                        lblE.Text = Resultados.Rows[w]["RDP_Entrada"].ToString();
                        lblC.Text = Resultados.Rows[w]["RDC_Id"].ToString();
                        lblD.Text = Resultados.Rows[w]["RDP_Texto"].ToString();

                        if (Resultados.Rows[w]["RDP_AceptaNulo"].ToString() == "1")
                            lblN.Text = "Si";
                        else
                            lblN.Text = "No";

                        if (Resultados.Rows[w]["RDP_BusquedaAproximada"].ToString() == "1")
                            lblB.Text = "Si";
                        else
                            lblB.Text = "No";

                        if (chkO.Checked)
                            lblN.Text = "No";

                        row.Cells[CeldaTipoDato].Text = Resultados.Rows[w]["TipoDato"].ToString();
                        row.Cells[CeldaLongitud].Text = Resultados.Rows[w]["Longitud"].ToString();

                        break;
                    }
                }
            }

            pnlTextoC.Visible = true;
        }
        #endregion Query
        #endregion Paso04
        #endregion Metodos
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCatalogos();
            }
        }

        #region Paso01
        protected void btnProcesar01_Click(object sender, EventArgs e)
        {
            lblMsj01.Text = "";

            if (!string.IsNullOrWhiteSpace(ddlCnx.SelectedValue))
            {
                pnlPaso01.Visible = false;
                pnlPaso02.Visible = true;
                hddPasoAnterior01.Value = "2";
            }
            else
            {
                lblMsj01.Text = "Debe seleccionar un elemento de la lista.";
            }
        }

        protected void btnProcesar01P03_Click(object sender, EventArgs e)
        {
            pnlPaso01.Visible = false;
            pnlPaso03.Visible = true;
            hddPasoAnterior01.Value = "1";
        }
        #endregion Paso01
        #region Paso02
        protected void btnValidar02_Click(object sender, EventArgs e)
        {
            Validar02();
        }

        protected void btnAgregar02_Click(object sender, EventArgs e)
        {
            if (!Validar02())
            {
                if (!rbEstiloddl02.Checked && !rbEstilochk02.Checked)
                {
                    lblMsj02.Text = "Debe seleccionar un estilo.";
                }
                else
                {
                    BLReportes objRpt = new BLReportes();
                    string Resp = "";

                    if (rbEstilochk02.Checked)
                        Resp = objRpt.InsertarCatalogo(DatosGenerales.EstiloReportesDinamicos.eCheckBoxList, txtDescripcion02.Text.Trim(), txtScriptPaso02.Text.Trim(), ddlCnx.SelectedValue, false, hddTipo02.Value);
                    else
                        Resp = objRpt.InsertarCatalogo(DatosGenerales.EstiloReportesDinamicos.eDropDownList, txtDescripcion02.Text.Trim(), txtScriptPaso02.Text.Trim(), ddlCnx.SelectedValue, false, hddTipo02.Value);

                    if (!Resp.Contains("Existe"))
                    {
                        MsgBox.AddMessage("Se ha agregado el catálogo", YaBu.MessageBox.uscMsgBox.enmMessageType.Success);
                        Limpieza02(true);
                    }
                    else
                    {
                        MsgBox.AddMessage("Ya existe un catálogo con ese nombre. Ingrese uno diferente.", YaBu.MessageBox.uscMsgBox.enmMessageType.Attention);
                        txtDescripcion02.Focus();
                    }
                }
            }
        }

        protected void btnProcesar02_Click(object sender, EventArgs e)
        {
            pnlPaso02.Visible = false;
            pnlPaso03.Visible = true;
        }

        protected void btnRegresar02_Click(object sender, EventArgs e)
        {
            pnlPaso01.Visible = true;
            pnlPaso02.Visible = false;
        }
        #endregion Paso02
        #region Paso03
        protected void btnProcesar03_Click(object sender, EventArgs e)
        {
            lblMsj03.Text = "";
            int TipoScript = 0;

            int.TryParse(ddlTipoScript.SelectedValue, out TipoScript);
            pnlTexto.Visible = false;
            pnlStored.Visible = false;
            pnlSSIS.Visible = false;

            if (!string.IsNullOrWhiteSpace(ddlTipoScript.SelectedValue))
            {
                BLCatalogos objCat = new BLCatalogos();

                pnlPaso03.Visible = false;
                pnlPaso04.Visible = true;

                switch (TipoScript)
                {
                    case (int)DatosGenerales.TiposScript.Texto:
                        pnlTexto.Visible = true;
                        objCat.ListaReportes(ref ddlReportesTexto, (int)DatosGenerales.TiposScript.Texto, ddlCnx.SelectedValue);
                        break;
                    case (int)DatosGenerales.TiposScript.Stored:
                        pnlStored.Visible = true;
                        objCat.ListaReportes(ref ddlReportesStored, (int)DatosGenerales.TiposScript.Stored, ddlCnx.SelectedValue);
                        CargaStored();
                        break;
                    case (int)DatosGenerales.TiposScript.Paquete:
                        pnlSSIS.Visible = true;
                        break;
                }

                BLReportes objRpt = new BLReportes();

                DatosGenerales.TipoCatalogoRpt(ref ddlTipo04);
                DatosGenerales.TipoCatalogoRpt(ref ddlTipo04Q);

                ddlTipoDatoQ.DataValueField = "Valor";
                ddlTipoDatoQ.DataTextField = "Descripcion";
                ddlTipoDatoQ.DataSource = objRpt.ObtenerTiposDato(ddlCnx.SelectedValue);
                ddlTipoDatoQ.DataBind();
            }
            else
            {
                lblMsj03.Text = "Debe seleccionar un elemento de la lista.";
            }
        }

        protected void btnRegresar03_Click(object sender, EventArgs e)
        {
            if (hddPasoAnterior01.Value == "1")
                pnlPaso01.Visible = true;
            else if (hddPasoAnterior01.Value == "2")
                pnlPaso02.Visible = true;
            else
                pnlPaso01.Visible = true;

            pnlPaso03.Visible = false;
        }
        #endregion Paso03
        #region Paso04
        #region Stored
        protected void grdParams_RowSelected(object sender, EventArgs e)
        {
            if (grdParams.SelectedIndex != -1)
            {
                Label lbl = (Label)grdParams.SelectedRow.FindControl("lblBAprox");
                CheckBox chkO = (CheckBox)grdParams.SelectedRow.FindControl("chkObligatorio");
                Label lblE = (Label)grdParams.SelectedRow.FindControl("lblEntrada");
                Label lblN = (Label)grdParams.SelectedRow.FindControl("lblNull");
                Label lblC = (Label)grdParams.SelectedRow.FindControl("lblCat");
                Label lblD = (Label)grdParams.SelectedRow.FindControl("lblDesc");

                pnlTipo04.Visible = true;
                pnlCat04.Visible = false;

                ddlTipo04.SelectedIndex = 0;
                chkAprox04.Checked = false;
                chkNull04.Checked = false;

                if (lblN.Text == "Si" && !chkO.Checked)
                    chkNull04.Checked = true;
                else
                    chkNull04.Checked = false;

                if (lbl.Text != "N/A")
                    pnlAprox04.Visible = true;
                else
                    pnlAprox04.Visible = false;

                if (lbl.Text == "Si")
                    chkAprox04.Checked = true;
                else
                    chkAprox04.Checked = false;

                if (chkO.Checked)
                    pnlNull04.Visible = false;
                else
                    pnlNull04.Visible = true;

                if (!string.IsNullOrWhiteSpace(lblE.Text))
                    ddlTipo04.SelectedValue = lblE.Text;

                txtCampoDesc.Text = lblD.Text;

                if (ddlTipo04.SelectedValue == "lst" || ddlTipo04.SelectedValue == "lchk")
                {
                    BLCatalogos objCat = new BLCatalogos();

                    pnlCat04.Visible = true;

                    if (ddlTipo04.SelectedValue == "lst")
                        objCat.ListaCatalogos(ref ddlCat04, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eDropDownList);
                    else
                        objCat.ListaCatalogos(ref ddlCat04, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eCheckBoxList);

                    if (ddlCat04.Items.Count > 0 && lblC.Text != "0")
                        ddlCat04.SelectedValue = lblC.Text;
                }
                else
                {
                    pnlCat04.Visible = false;
                }
            }
        }

        protected void grdParams_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DatosGenerales.Equivalencia_SQLDotNet(e.Row.Cells[CeldaTipoDato].Text) == "String" && !e.Row.Cells[CeldaTipoDato].Text.ToLower().Contains("date") && !e.Row.Cells[CeldaTipoDato].Text.ToLower().Contains("time"))
                {
                    Label lbl = (Label)e.Row.FindControl("lblBAprox");

                    lbl.Text = "No";
                }
            }
        }

        protected void ddlStored_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdParams.SelectedIndex = -1;
            pnlTipo04.Visible = false;

            if (!string.IsNullOrWhiteSpace(ddlStored.SelectedValue))
            {
                CargaParamsStored();
            }
            else
            {
                grdParams.DataSource = null;
                grdParams.DataBind();
            }

            if (grdParams.Rows.Count > 0)
            {
                btnProcesar04.Visible = true;
                pnlGrid.Visible = true;
            }
            else
            {
                btnProcesar04.Visible = false;
                pnlGrid.Visible = false;
            }
        }

        protected void ddlTipo04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo04.SelectedValue == "lst" || ddlTipo04.SelectedValue == "lchk")
            {
                BLCatalogos objCat = new BLCatalogos();

                pnlCat04.Visible = true;

                if (ddlTipo04.SelectedValue == "lst")
                    objCat.ListaCatalogos(ref ddlCat04, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eDropDownList);
                else
                    objCat.ListaCatalogos(ref ddlCat04, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eCheckBoxList);

                if (ddlCat04.Items.Count > 0)
                    ddlCat04.SelectedIndex = 0;
            }
            else
            {
                pnlCat04.Visible = false;
            }
        }

        protected void btnAsignar04_Click(object sender, EventArgs e)
        {
            bool Continuar = true;

            lblMsjCat04.Text = "";

            if (ddlTipo04.SelectedValue == "lst" || ddlTipo04.SelectedValue == "lchk")
            {
                int Cat_Id = 0;

                int.TryParse(ddlCat04.SelectedValue, out Cat_Id);

                if (Cat_Id <= 0)
                {
                    Continuar = false;
                    lblMsjCat04.Text = "Debe seleccionar un catálogo.";
                }
            }

            txtCampoDesc.Text = txtCampoDesc.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtCampoDesc.Text))
            {
                Continuar = false;
                lblMsjCat04.Text = "Debe ingresar una descripción.";
            }

            if (Continuar)
            {
                GridViewRow row = grdParams.SelectedRow;

                Label lblE = (Label)row.FindControl("lblEntrada");

                lblE.Text = ddlTipo04.SelectedValue;

                Label lblB = (Label)row.FindControl("lblBAprox");

                if (chkAprox04.Checked)
                    lblB.Text = "Si";
                else
                    lblB.Text = "No";

                Label lblN = (Label)row.FindControl("lblNull");

                if (chkNull04.Checked)
                    lblN.Text = "Si";
                else
                    lblN.Text = "No";

                Label lblD = (Label)row.FindControl("lblDesc");

                lblD.Text = txtCampoDesc.Text;

                if (ddlTipo04.SelectedValue == "lst" || ddlTipo04.SelectedValue == "lchk")
                {
                    Label lblC = (Label)row.FindControl("lblCat");

                    lblC.Text = ddlCat04.SelectedValue;

                    if (ddlCat04.Items.Count > 0)
                        ddlCat04.SelectedIndex = 0;
                }

                ddlTipo04.SelectedIndex = 0;
                pnlTipo04.Visible = false;
                pnlCat04.Visible = false;
                grdParams.SelectedIndex = -1;
            }
        }

        protected void btnRegresar04_Click(object sender, EventArgs e)
        {
            pnlPaso03.Visible = true;
            pnlPaso04.Visible = false;
        }

        protected void btnProcesar04_Click(object sender, EventArgs e)
        {
            int RDTS_Id = 0;

            pnlTipo04.Visible = false;
            lblMsjGrid04.Text = ValidarGridParams();

            int.TryParse(ddlTipoScript.SelectedValue, out RDTS_Id);

            if (lblMsjGrid04.Text == "")
            {
                BLReportes objRpt = new BLReportes();
                int RD_Id = 0;
                string MsjBD = "";

                int.TryParse(ddlReportesStored.SelectedValue, out RD_Id);

                if (RD_Id > 0)
                {
                    bool AplicarBorradoPrevio = true;
                    int MsjBDExiste = objRpt.ActualizarReporte(RD_Id, txtNombreReporte.Text.Trim(), ddlStored.SelectedValue, Session["UserNameLogin"].ToString());

                    if (MsjBDExiste == 1)
                    {
                        for (int w = 0; w < grdParams.Rows.Count; w++)
                        {
                            BLReportes.RptDinamicosParametro param = new BLReportes.RptDinamicosParametro(grdParams.Rows[w]);

                            MsjBD += objRpt.InsertarParametro(RD_Id, param.Nombre, param.Tipo, param.TipoDato, param.Longitud, param.Obligatorio, param.Entrada, param.Catalogo, param.AceptaNulo, param.BusquedaAproximada, param.Descripcion, AplicarBorradoPrevio);
                            AplicarBorradoPrevio = false;
                        }

                        if (MsjBD == "")
                            MsjBD = "OK";
                    }
                    else
                    {
                        MsjBD = "Ya existe un reporte con ese nombre.";
                    }
                }
                else
                {
                    lblMsjGrid04.Text = "No se obtuvo el ID del reporte.";
                }

                if (MsjBD == "OK")
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Modificación de reporte", DatosGenerales.TiposMensaje.Informacion);
                else
                    lblMsjGrid04.Text = MsjBD;
            }
        }

        protected void ddlReportesStored_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RD_Id = 0;

            int.TryParse(ddlReportesStored.SelectedValue, out RD_Id);
            pnlStoredC.Visible = false;
            lblMsjGrid04.Text = "";
            pnlGrid.Visible = false;
            pnlTipo04.Visible = false;

            if (grdParams.Rows.Count > 0)
                grdParams.SelectedIndex = -1;

            if (RD_Id > 0)
                CompararDatos(RD_Id);
        }
        #endregion Sotred
        #region Query
        protected void grdParamsQ_RowSelected(object sender, EventArgs e)
        {
            if (grdParamsQ.SelectedIndex != -1)
            {
                Label lbl = (Label)grdParamsQ.SelectedRow.FindControl("lblBAprox");
                CheckBox chkO = (CheckBox)grdParamsQ.SelectedRow.FindControl("chkObligatorio");
                Label lblE = (Label)grdParamsQ.SelectedRow.FindControl("lblEntrada");
                Label lblN = (Label)grdParamsQ.SelectedRow.FindControl("lblNull");
                Label lblC = (Label)grdParamsQ.SelectedRow.FindControl("lblCat");
                Label lblD = (Label)grdParamsQ.SelectedRow.FindControl("lblDesc");

                pnlTipo04Q.Visible = true;
                pnlCat04Q.Visible = false;

                ddlTipo04Q.SelectedIndex = 0;
                chkAprox04Q.Checked = false;
                chkNull04Q.Checked = false;
                txtLongitud04Q.Text = "";

                if (lblN.Text == "Si" && !chkO.Checked)
                    chkNull04Q.Checked = true;
                else
                    chkNull04Q.Checked = false;

                if (lbl.Text != "N/A")
                    pnlAprox04Q.Visible = true;
                else
                    pnlAprox04Q.Visible = false;

                if (lbl.Text == "Si")
                    chkAprox04Q.Checked = true;
                else
                    chkAprox04Q.Checked = false;

                if (chkO.Checked)
                    pnlNull04Q.Visible = false;
                else
                    pnlNull04Q.Visible = true;

                txtLongitud04Q.Text = grdParamsQ.SelectedRow.Cells[CeldaLongitud].Text;
                txtCampoDescQ.Text = lblD.Text;

                if (!string.IsNullOrWhiteSpace(lblE.Text))
                    ddlTipo04Q.SelectedValue = lblE.Text;

                if (!string.IsNullOrWhiteSpace(grdParamsQ.SelectedRow.Cells[CeldaTipoDato].Text) && grdParamsQ.SelectedRow.Cells[CeldaTipoDato].Text != "&nbsp;")
                    ddlTipoDatoQ.SelectedValue = grdParamsQ.SelectedRow.Cells[CeldaTipoDato].Text;
                else
                    ddlTipoDatoQ.SelectedIndex = 0;

                if (ddlTipo04Q.SelectedValue == "lst" || ddlTipo04Q.SelectedValue == "lchk")
                {
                    BLCatalogos objCat = new BLCatalogos();

                    pnlCat04Q.Visible = true;

                    if (ddlTipo04Q.SelectedValue == "lst")
                        objCat.ListaCatalogos(ref ddlCat04Q, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eDropDownList);
                    else
                        objCat.ListaCatalogos(ref ddlCat04Q, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eCheckBoxList);

                    if (ddlCat04Q.Items.Count > 0 && lblC.Text != "0")
                        ddlCat04Q.SelectedValue = lblC.Text;
                }
                else
                {
                    pnlCat04Q.Visible = false;
                }

                ValidarTD();
            }
        }

        protected void grdParamsQ_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DatosGenerales.Equivalencia_SQLDotNet(e.Row.Cells[CeldaTipoDato].Text) == "String" && !e.Row.Cells[CeldaTipoDato].Text.ToLower().Contains("date") && !e.Row.Cells[CeldaTipoDato].Text.ToLower().Contains("time"))
                {
                    Label lbl = (Label)e.Row.FindControl("lblBAprox");

                    lbl.Text = "Nor";
                }

                if (string.IsNullOrWhiteSpace(e.Row.Cells[CeldaTipoDato].Text) || e.Row.Cells[CeldaTipoDato].Text == "&nbsp;")
                {
                    Label lbl = (Label)e.Row.FindControl("lblBAprox");

                    lbl.Text = "N/A";
                }
            }
        }

        protected void btnProcesar04Q_Click(object sender, EventArgs e)
        {
            int RDTS_Id = 0;

            pnlTipo04Q.Visible = false;
            lblMsjGrid04Q.Text = ValidarGridParamsQ();

            int.TryParse(ddlTipoScript.SelectedValue, out RDTS_Id);

            if (lblMsjGrid04Q.Text == "")
            {
                BLReportes objRpt = new BLReportes();
                int RD_Id = 0;
                string MsjBD = "";

                int.TryParse(ddlReportesTexto.SelectedValue, out RD_Id);

                if (RD_Id > 0)
                {
                    bool AplicarBorradoPrevio = true;
                    int MsjBDExiste = objRpt.ActualizarReporte(RD_Id, txtNombreReporteQ.Text.Trim(), txtScriptPaso04.Text.Trim(), Session["UserNameLogin"].ToString());

                    if (MsjBDExiste == 1)
                    {
                        for (int w = 0; w < grdParamsQ.Rows.Count; w++)
                        {
                            BLReportes.RptDinamicosParametro param = new BLReportes.RptDinamicosParametro(grdParamsQ.Rows[w]);

                            MsjBD += objRpt.InsertarParametro(RD_Id, param.Nombre, param.Tipo, param.TipoDato, param.Longitud, param.Obligatorio, param.Entrada, param.Catalogo, param.AceptaNulo, param.BusquedaAproximada, param.Descripcion, AplicarBorradoPrevio);
                            AplicarBorradoPrevio = false;
                        }

                        if (MsjBD == "")
                            MsjBD = "OK";
                    }
                    else
                    {
                        MsjBD = "Ya existe un reporte con ese nombre.";
                    }
                }
                else
                {
                    lblMsjGrid04Q.Text = "No se obtuvo el ID del reporte.";
                }

                if (MsjBD == "OK")
                    DatosGenerales.EnviaMensaje("Proceso finalizado", "Modificación de reporte", DatosGenerales.TiposMensaje.Informacion);
                else
                    lblMsjGrid04Q.Text = MsjBD;
            }
        }

        protected void btnRegresar04Q_Click(object sender, EventArgs e)
        {
            pnlPaso03.Visible = true;
            pnlPaso04.Visible = false;
        }

        protected void btnIngresarQ_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTipo04Q_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo04Q.SelectedValue == "lst" || ddlTipo04Q.SelectedValue == "lchk")
            {
                BLCatalogos objCat = new BLCatalogos();

                pnlCat04Q.Visible = true;

                if (ddlTipo04Q.SelectedValue == "lst")
                    objCat.ListaCatalogos(ref ddlCat04Q, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eDropDownList);
                else
                    objCat.ListaCatalogos(ref ddlCat04Q, ddlCnx.SelectedValue, (int)DatosGenerales.EstiloReportesDinamicos.eCheckBoxList);

                if (ddlCat04Q.Items.Count > 0)
                    ddlCat04Q.SelectedIndex = 0;
            }
            else
            {
                pnlCat04Q.Visible = false;
            }
        }

        protected void btnAsignar04Q_Click(object sender, EventArgs e)
        {
            bool Continuar = true;
            int longitud = 0;

            int.TryParse(txtLongitud04Q.Text, out longitud);
            lblMsjCat04Q.Text = "";

            if (ddlTipo04Q.SelectedValue == "lst" || ddlTipo04Q.SelectedValue == "lchk")
            {
                int Cat_Id = 0;

                int.TryParse(ddlCat04Q.SelectedValue, out Cat_Id);

                if (Cat_Id <= 0)
                {
                    Continuar = false;
                    lblMsjCat04Q.Text = "Debe seleccionar un catálogo.";
                }
            }

            if (string.IsNullOrWhiteSpace(txtCampoDescQ.Text))
            {
                Continuar = false;
                lblMsjCat04Q.Text = "Debe ingresar una descripción.";
            }

            if (hddAplicaLongitud.Value == "1")
            {
                if (longitud == 0)
                {
                    Continuar = false;
                    lblMsjCat04Q.Text = "Debe ingresar una longitud.";
                    txtLongitud04Q.Focus();
                }
            }

            if (Continuar)
            {
                GridViewRow row = grdParamsQ.SelectedRow;

                Label lblE = (Label)row.FindControl("lblEntrada");

                lblE.Text = ddlTipo04Q.SelectedValue;

                Label lblB = (Label)row.FindControl("lblBAprox");

                if (chkAprox04Q.Checked)
                    lblB.Text = "Si";
                else
                    lblB.Text = "No";

                Label lblN = (Label)row.FindControl("lblNull");

                if (chkNull04Q.Checked)
                    lblN.Text = "Si";
                else
                    lblN.Text = "No";

                Label lblD = (Label)row.FindControl("lblDesc");

                lblD.Text = txtCampoDescQ.Text;

                if (ddlTipo04Q.SelectedValue == "lst" || ddlTipo04Q.SelectedValue == "lchk")
                {
                    Label lblC = (Label)row.FindControl("lblCat");

                    lblC.Text = ddlCat04Q.SelectedValue;

                    if (ddlCat04Q.Items.Count > 0)
                        ddlCat04Q.SelectedIndex = 0;
                }

                ddlTipo04Q.SelectedIndex = 0;
                pnlTipo04Q.Visible = false;
                pnlCat04Q.Visible = false;
                grdParamsQ.SelectedIndex = -1;

                if (longitud < 0)
                    longitud = -1;
                else if (longitud > 8000)
                    longitud = 8000;

                if (hddAplicaLongitud.Value == "1")
                    row.Cells[CeldaLongitud].Text = longitud.ToString();
                else
                    row.Cells[CeldaLongitud].Text = "";

                row.Cells[CeldaTipoDato].Text = ddlTipoDatoQ.SelectedValue.ToLower();
            }
        }

        protected void btnRegistrarQ_Click(object sender, EventArgs e)
        {
            int RD_Id = 0;

            int.TryParse(ddlReportesTexto.SelectedValue, out RD_Id);
            RegistrarQuery();
            CompararDatosQ(RD_Id, false);
        }

        protected void ddlTipoDatoQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLongitud04Q.Text = "";

            ValidarTD();
        }

        protected void ddlReportesTexto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RD_Id = 0;

            int.TryParse(ddlReportesTexto.SelectedValue, out RD_Id);
            pnlTextoC.Visible = false;
            lblMsjGrid04Q.Text = "";
            pnlGridQ.Visible = false;
            pnlTipo04Q.Visible = false;

            if (grdParamsQ.Rows.Count > 0)
                grdParamsQ.SelectedIndex = -1;

            if (RD_Id > 0)
                CompararDatosQ(RD_Id);
        }
        #endregion Query
        #endregion Paso04

        #endregion Eventos
    }
}