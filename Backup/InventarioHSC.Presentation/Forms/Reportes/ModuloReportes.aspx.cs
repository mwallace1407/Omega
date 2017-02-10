using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Text;
using InventarioHSC.BusinessLayer;

namespace InventarioHSC.Forms.Reportes
{
    public partial class ModuloReportes : System.Web.UI.Page
    {
        public string Checados { get; set; }
        public string Indices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(ModuloReportes));
            CambiaEstadoNotificacion("Info", false, string.Empty);
            CambiaEstadoNotificacion("Warning", false, string.Empty);

            //this.btnEjecutar.Click += new EventHandler(btnEjecutar_Click);
            this.rbReportes.SelectedIndexChanged += new EventHandler(rbReportes_SelectedIndexChanged);

            if (!Page.IsPostBack)
            {
                Checados = string.Empty;
                Indices = string.Empty;
                this.LlenaIndices();
            }
        }

        public void CambiaEstadoNotificacion(string TipoEtiqueta, bool Accion, string Mensaje)
        {
            if (TipoEtiqueta == "Warning")
            {
                Warning.Visible = Accion;
                LabelError.Visible = Accion;
                LabelError.Font.Size = 10;
                LabelError.Text = Mensaje;
            }
            else
            {
                Info.Visible = Accion;
                LabelInfo.Visible = Accion;
                LabelInfo.Font.Size = 10;
                LabelInfo.Text = Mensaje;
            }
        }

        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["Inventario"].ConnectionString;
            SqlDataSource dsReportes = null;

            if (dsReportes != null)
                dsReportes.SelectParameters.Clear();

            string sSel = ObtieneSeleccionados();

            switch (rbReportes.SelectedValue)
            { 
                case "1":
                    if (ddlUbicacion.SelectedValue != "" || ddlUbicacion.SelectedValue != "0")
                    {
                        dsReportes = new SqlDataSource(strConnString, GeneraConsultaDataSource(rbReportes.SelectedValue));
                        dsReportes.SelectParameters.Add("idUbicacion", ddlUbicacion.SelectedValue.ToString());

                        ReportDataSource rdsReporteGeneral = new ReportDataSource("dsReporteGeneral", dsReportes);

                        rvReportes.LocalReport.DataSources.Clear();
                        rvReportes.LocalReport.ReportPath = @"Forms\Reportes\ReporteGeneral.rdlc";
                        rvReportes.LocalReport.DataSources.Add(rdsReporteGeneral);
                        rvReportes.LocalReport.Refresh();
                        rvReportes.Visible = true;
                    }
                    break;
                case "2":
                    if (ddlUsuario.SelectedValue != "" || ddlUsuario.SelectedValue != "0")
                    {
                        dsReportes = new SqlDataSource(strConnString, GeneraConsultaDataSource(rbReportes.SelectedValue));
                        dsReportes.SelectParameters.Add("Nombre", ddlUsuario.SelectedItem.Text);

                        ReportDataSource rdsReportePorUsuario = new ReportDataSource("dsReporteUsuario", dsReportes);
                        rvReportes.LocalReport.DataSources.Clear();
                        rvReportes.LocalReport.ReportPath = @"Forms\Reportes\ReportePorUsuario.rdlc";
                        rvReportes.LocalReport.DataSources.Add(rdsReportePorUsuario);
                        rvReportes.LocalReport.Refresh();
                    }
                    break;
                case "3":
                    if (txtResponsiva.Text != string.Empty || txtResponsiva.Text != "")
                    {
                        dsReportes = new SqlDataSource(strConnString, GeneraConsultaDataSource(rbReportes.SelectedValue));
                        dsReportes.SelectParameters.Add("Responsiva", txtResponsiva.Text);
                        ReportDataSource rdsReporteHistoriaXResponsiva = new ReportDataSource("dsHistoriaPorResponsiva", dsReportes);

                        rvReportes.LocalReport.DataSources.Clear();
                        rvReportes.LocalReport.ReportPath = @"Forms\Reportes\ReporteHistoriaPorResponsiva.rdlc";
                        rvReportes.LocalReport.DataSources.Add(rdsReporteHistoriaXResponsiva);
                        rvReportes.LocalReport.Refresh();
                    }
                    break;
                case "4":
                    dsReportes = new SqlDataSource(strConnString, GeneraConsultaDataSource(rbReportes.SelectedValue));
                    if (ddlUbicacion.SelectedValue != "" || ddlUbicacion.SelectedValue != "0" &&
                        sSel != "" || sSel != "0")
                    {
                        dsReportes.SelectParameters.Add("idTipoEquipo", sSel);
                        dsReportes.SelectParameters.Add("idUbicacion", ddlUbicacion.SelectedValue);
                    }
                    ReportDataSource rdsReporteXTipoActivo = new ReportDataSource("dsTipoActivo", dsReportes);
                    rvReportes.LocalReport.DataSources.Clear();
                    rvReportes.LocalReport.ReportPath = @"Forms\Reportes\ReportePorTipoActivo.rdlc";
                    rvReportes.LocalReport.DataSources.Add(rdsReporteXTipoActivo);
                    rvReportes.LocalReport.Refresh();
                    break;
                case "5":
                    if (txtNoSerie.Text != string.Empty || txtNoSerie.Text != "")
                    {
                        dsReportes = new SqlDataSource(strConnString, GeneraConsultaDataSource(rbReportes.SelectedValue));
                        dsReportes.SelectParameters.Add("NoSerie", txtNoSerie.Text);
                        ReportDataSource rdsReporteMovimientos = new ReportDataSource("dsReporteMovimientos", dsReportes);

                        rvReportes.LocalReport.DataSources.Clear();
                        rvReportes.LocalReport.ReportPath = @"Forms\Reportes\ReporteMovimientos.rdlc";
                        rvReportes.LocalReport.DataSources.Add(rdsReporteMovimientos);
                        rvReportes.LocalReport.Refresh();
                    }
                    break;
                case "6":
                    if (txtNoSerie.Text != string.Empty || txtNoSerie.Text != "")
                    {
                        dsReportes = new SqlDataSource(strConnString, GeneraConsultaDataSource(rbReportes.SelectedValue));
                        dsReportes.SelectParameters.Add("NoSerie", txtNoSerie.Text);
                        ReportDataSource rdsReporteDuplicados = new ReportDataSource("dsReporteDuplicados", dsReportes);

                        rvReportes.LocalReport.DataSources.Clear();
                        rvReportes.LocalReport.ReportPath = @"Forms\Reportes\ReporteDuplicados.rdlc";
                        rvReportes.LocalReport.DataSources.Add(rdsReporteDuplicados);
                        rvReportes.LocalReport.Refresh();
                    }
                    break;
            }
        }
        void rbReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLCatalogos Catalogos = new BLCatalogos();

            rvReportes.LocalReport.DataSources.Clear();
            rvReportes.LocalReport.ReportPath = "";
            rvReportes.LocalReport.Refresh();

            switch (rbReportes.SelectedValue)
            { 
                case "1":
                    Catalogos.CargaUbicacion(ref ddlUbicacion);
                    ddlUbicacion.DataBind();
                    pnlUbicacion.Visible = true;
                    pnlTipoActivoC.Visible = false;
                    pnlUsuario.Visible = false;
                    pnlNumeroSerie.Visible = false;
                    pnlResponsiva.Visible = false;
                    break;
                case "2":
                    Catalogos.CargaUsuario(ref ddlUsuario);
                    ddlUsuario.DataBind();
                    pnlUbicacion.Visible = false;
                    pnlTipoActivoC.Visible = false;
                    pnlUsuario.Visible = true;
                    pnlNumeroSerie.Visible = false;
                    pnlResponsiva.Visible = false;
                    break;
                case "3":
                    pnlUbicacion.Visible = false;
                    pnlTipoActivoC.Visible = false;
                    pnlUsuario.Visible = false;
                    pnlNumeroSerie.Visible = false;
                    pnlResponsiva.Visible = true;
                    break;
                case "4":
                    Catalogos.CargaUbicacion(ref ddlUbicacion);
                    Catalogos.CargaTipoEquipo(ref chkTipoActivo);
                    ddlUbicacion.DataBind();
                    chkTipoActivo.DataBind();
                    pnlUbicacion.Visible = true;
                    pnlTipoActivoC.Visible = true;
                    pnlUsuario.Visible = false;
                    pnlNumeroSerie.Visible = false;
                    pnlResponsiva.Visible = false;
                    break;
                case "5":
                    txtNoSerie.Text = string.Empty;
                    pnlUbicacion.Visible = false;
                    pnlTipoActivoC.Visible = false;
                    pnlUsuario.Visible = false;
                    pnlNumeroSerie.Visible = true;
                    pnlResponsiva.Visible = false;
                    break;
                case "6":
                    txtNoSerie.Text = string.Empty;
                    pnlUbicacion.Visible = false;
                    pnlTipoActivoC.Visible = false;
                    pnlUsuario.Visible = false;
                    pnlNumeroSerie.Visible = true;
                    pnlResponsiva.Visible = false;
                    break;
            }
        }
        private string GeneraConsultaDataSource(string Reporte)
        {
            StringBuilder strB = new StringBuilder();

            strB.AppendLine("SELECT ");
            strB.AppendLine("		USU.Nombre Usuario, ");
            strB.AppendLine("		UBI.Descripcion  AS Ubicacion, ");
            strB.AppendLine("		REG.Nombre Region, ");
            strB.AppendLine("		TEQ.Descripcion TipoActivo, ");
            strB.AppendLine("		ART.NoSerie, ");
            strB.AppendLine("		ART.CodigoCastor, ");
            strB.AppendLine("		ART.Observacion1,");
            strB.AppendLine("		ART.Observacion2, ");
            strB.AppendLine("		ART.Observacion3, ");
            strB.AppendLine("		CASE ");
            strB.AppendLine("			WHEN ART.idTipoEquipo  = 1 OR ART.idTipoEquipo  = 2 OR ART.idTipoEquipo = 3 THEN ");
            strB.AppendLine("				'MODELO:' + ISNULL(LTRIM(RTRIM(ART.Modelo)), '') + ");
            strB.AppendLine("				', PROCESADOR: ' + ISNULL(ART.Procesador, '') + ");
            strB.AppendLine("				', RAM: ' + ISNULL(ART.RAM, '') + ");
            strB.AppendLine("				', DISCO DURO: ' + ISNULL(ART.DiscoDuro, '') + ");
            strB.AppendLine("				', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
            strB.AppendLine("				', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
            strB.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
            strB.AppendLine("			ELSE ");
            strB.AppendLine("				'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
            strB.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
            strB.AppendLine("		END AS Observacion, ");
            strB.AppendLine("		ART.Responsiva,");
            strB.AppendLine("		CASE ");
            strB.AppendLine("			WHEN ISNULL(ART.NoSerie, '') = '' AND ISNULL(ART.NoSerie, '') = '' THEN 'HSC' ");
            strB.AppendLine("		END Tipo ");
            strB.AppendLine("FROM Articulo ART ");
            //strB.AppendLine("LEFT JOIN ");
            //strB.AppendLine("	ArticuloJCB JCB ON ");
            //strB.AppendLine("	ART.NoSerie = JCB.NoSerie ");
            //strB.AppendLine("LEFT JOIN ");
            //strB.AppendLine("	ArticuloCorporativo AC ON ");
            //strB.AppendLine("	ART.NoSerie = AC.NoSerie ");
            strB.AppendLine("INNER JOIN ");
            strB.AppendLine("	TipoEquipo TEQ ON ");
            strB.AppendLine("	ART.idTipoEquipo = TEQ.idTipoEquipo ");
            strB.AppendLine("LEFT JOIN ");
            strB.AppendLine("	Usuario USU ON ");
            strB.AppendLine("	ART.idUsuario = USU.idUsuario	");
            strB.AppendLine("LEFT JOIN ");
            strB.AppendLine("	Ubicacion UBI ON");
            strB.AppendLine("	ART.idUbicacion = UBI.idUbicacion ");
            strB.AppendLine("AND UBI.Estatus = 1 ");
            //strB.AppendLine("LEFT JOIN ");
            //strB.AppendLine("	Ubicacion UBIAC ON ");
            //strB.AppendLine("	AC.idUbicacion = UBIAC.idUbicacion ");
            //strB.AppendLine("AND UBIAC.Estatus = 1 ");
            strB.AppendLine("LEFT JOIN ");
            strB.AppendLine("	Region REG ON ");
            strB.AppendLine("	UBI.idRegion = REG.idRegion ");
            strB.AppendLine("AND REG.Estatus = 1 ");
            strB.AppendLine("LEFT JOIN ");
            strB.AppendLine("	Marca MAR ON ");
            strB.AppendLine("	ART.idMarca = MAR.idMarca ");
            strB.AppendLine("LEFT JOIN ");
            strB.AppendLine("	Proveedor PRO ON ");
            strB.AppendLine("	ART.idProveedor = PRO.idProveedor ");
            strB.AppendLine("LEFT JOIN ");
            strB.AppendLine("	SistemaOperativo SO ON ");
            strB.AppendLine("	ART.idSistema = SO.idSistema ");

            switch (Reporte)
            { 
                case "1":
                    strB.AppendLine("WHERE ART.idUbicacion = @idUbicacion ");
                    strB.AppendLine("ORDER BY USU.Nombre, ART.NoSerie");
                    break;
                case "2":
                    strB.AppendLine("WHERE USU.Nombre = @Nombre ");
                    strB.AppendLine("ORDER BY USU.Nombre, ART.NoSerie ");
                    break;
                case "3":
                    strB.AppendLine("WHERE ART.Responsiva = @Responsiva ");
                    strB.AppendLine("ORDER BY USU.Nombre, ART.NoSerie ");
                    break;
                case "4":
                    if (ddlUbicacion.SelectedValue != "" || ddlUbicacion.SelectedValue != "0")
                    {
                        strB.AppendLine("WHERE ART.idTipoEquipo in (@idTipoEquipo) ");
                        strB.AppendLine("AND ART.idUbicacion = @idUbicacion ");
                        strB.AppendLine("ORDER BY USU.Nombre, ART.NoSerie ");
                    }
                    break;
                case "5":
                    strB.Remove(0, strB.Length - 1);
                    strB.AppendLine("SELECT ");
                    strB.AppendLine("		USU.Nombre Usuario, ");
                    strB.AppendLine("		CASE ");
                    strB.AppendLine("			WHEN ISNULL(AC.IdUbicacion, 0) <> 0 AND AC.IdUbicacion <> 1 THEN UBIAC.Descripcion");
                    strB.AppendLine("			WHEN ISNULL(JCB.IdUbicacion, 0) <> 0 AND JCB.IdUbicacion <> 1 THEN UBIJCB.Descripcion");
                    strB.AppendLine("			ELSE UBI.Descripcion ");
                    strB.AppendLine("		END AS Ubicacion, ");
                    strB.AppendLine("		REG.Nombre Region, ");
                    strB.AppendLine("		TEQ.Descripcion TipoActivo, ");
                    strB.AppendLine("		ART.NoSerie, ");
                    strB.AppendLine("		ART.CodigoCastor, ");
                    strB.AppendLine("		ART.Observacion1, ");
                    strB.AppendLine("		ART.Observacion2, ");
                    strB.AppendLine("		ART.Observacion3, ");
                    strB.AppendLine("		CASE ");
                    strB.AppendLine("			WHEN ART.idTipoEquipo  = 1 OR ART.idTipoEquipo  = 2 OR ART.idTipoEquipo = 3 THEN ");
                    strB.AppendLine("				'MODELO:' + ISNULL(LTRIM(RTRIM(ART.Modelo)), '') + ");
                    strB.AppendLine("				', PROCESADOR: ' + ISNULL(ART.Procesador, '') + ");
                    strB.AppendLine("				', RAM: ' + ISNULL(ART.RAM, '') + ");
                    strB.AppendLine("				', DISCO DURO: ' + ISNULL(ART.DiscoDuro, '') + ");
                    strB.AppendLine("				', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                    strB.AppendLine("				', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                    strB.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                    strB.AppendLine("			ELSE ");
                    strB.AppendLine("				'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                    strB.AppendLine("				', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                    strB.AppendLine("		END AS Observacion, ");
                    strB.AppendLine("		ART.Responsiva, ");
                    strB.AppendLine("		CASE ");
                    strB.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') = '' AND ISNULL(AC.NoSerie, '') = '' THEN 'HSC' ");
                    strB.AppendLine("			WHEN ISNULL(AC.NoSerie, '') <> '' THEN 'CORP' ");
                    strB.AppendLine("			WHEN ISNULL(JCB.NoSerie, '') <> '' THEN 'JCB' ");
                    strB.AppendLine("		END Tipo, ");
                    strB.AppendLine("		TM.Descripcion, ");
                    strB.AppendLine("		CONVERT(VARCHAR(10), HM.fechaMovimiento, 103) FechaMov,");
                    strB.AppendLine("		CONVERT(VARCHAR(10), HM.fechaTransaccion, 103) FechaTran");
                    strB.AppendLine("FROM Articulo ART ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	ArticuloCorporativo AC ON");
                    strB.AppendLine("	ART.NoSerie = AC.NoSerie");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	ArticuloJCB JCB ON");
                    strB.AppendLine("	ART.NoSerie = JCB.NoSerie");
                    strB.AppendLine("INNER JOIN ");
                    strB.AppendLine("	Historico_Movimiento HM ON");
                    strB.AppendLine("	HM.idItem = ART.idItem");
                    strB.AppendLine("INNER JOIN");
                    strB.AppendLine("	TipoMovimiento TM ON");
                    strB.AppendLine("	HM.idTipoMovimiento = tm.idTipoMovimiento");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	TipoEquipo TEQ ON ");
                    strB.AppendLine("	ART.idTipoEquipo = TEQ.idTipoEquipo ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	Usuario USU ON ");
                    strB.AppendLine("	ART.idUsuario = USU.idUsuario ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	Ubicacion UBI ON ");
                    strB.AppendLine("	ART.idUbicacion = UBI.idUbicacion ");
                    strB.AppendLine("AND UBI.Estatus = 1 ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	Ubicacion UBIJCB ON ");
                    strB.AppendLine("	JCB.idUbicacion = UBIJCB.idUbicacion ");
                    strB.AppendLine("AND UBIJCB.Estatus = 1 ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	Ubicacion UBIAC ON ");
                    strB.AppendLine("	AC.idUbicacion = UBIAC.idUbicacion ");
                    strB.AppendLine("AND UBIAC.Estatus = 1 ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	Region REG ON ");
                    strB.AppendLine("	UBI.idRegion = REG.idRegion ");
                    strB.AppendLine("AND REG.Estatus = 1 ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	Marca MAR ON ");
                    strB.AppendLine("	ART.idMarca = MAR.idMarca ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	Proveedor PRO ON ");
                    strB.AppendLine("	ART.idProveedor = PRO.idProveedor ");
                    strB.AppendLine("LEFT JOIN ");
                    strB.AppendLine("	SistemaOperativo SO ON ");
                    strB.AppendLine("	ART.idSistema = SO.idSistema");
                    strB.AppendLine("WHERE ART.NoSerie = @NoSerie");
                    break;
                case "6":
                    strB.Remove(0, strB.Length - 1);
                    strB.AppendLine("	SELECT ");
                    strB.AppendLine("			USU.Nombre Usuario, ");
                    strB.AppendLine("			UBI.Descripcion Ubicacion, ");
                    strB.AppendLine("			REG.Nombre Region, ");
                    strB.AppendLine("			TEQ.Descripcion TipoActivo, ");
                    strB.AppendLine("			JCB.NoSerie, ");
                    strB.AppendLine("			JCB.CodigoCastor, ");
                    strB.AppendLine("			JCB.Observacion1,");
                    strB.AppendLine("			JCB.Observacion2, ");
                    strB.AppendLine("			JCB.Observacion3, ");
                    strB.AppendLine("		    CASE ");
                    strB.AppendLine("			    WHEN JCB.idTipoEquipo  = 1 OR JCB.idTipoEquipo  = 2 OR JCB.idTipoEquipo = 3 THEN ");
                    strB.AppendLine("				    'MODELO:' + ISNULL(LTRIM(RTRIM(JCB.Modelo)), '') + ");
                    strB.AppendLine("				    ', PROCESADOR: ' + ISNULL(JCB.Procesador, '') + ");
                    strB.AppendLine("				    ', RAM: ' + ISNULL(JCB.RAM, '') + ");
                    strB.AppendLine("				    ', DISCO DURO: ' + ISNULL(JCB.DiscoDuro, '') + ");
                    strB.AppendLine("				    ', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                    strB.AppendLine("				    ', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                    strB.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                    strB.AppendLine("			    ELSE ");
                    strB.AppendLine("				    'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                    strB.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                    strB.AppendLine("		    END AS Observacion, ");
                    strB.AppendLine("			JCB.Responsiva, ");
                    strB.AppendLine("			'JCB' Tipo ");
                    strB.AppendLine("	FROM Articulo ART ");
                    strB.AppendLine("	LEFT JOIN  ");
                    strB.AppendLine("		ArticuloJCB JCB ON");
                    strB.AppendLine("		ART.NoSerie = JCB.NoSerie");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		TipoEquipo TEQ ON ");
                    strB.AppendLine("		JCB.idTipoEquipo = TEQ.idTipoEquipo ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Usuario USU ON ");
                    strB.AppendLine("		JCB.idUsuario = USU.idUsuario ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Ubicacion UBI ON ");
                    strB.AppendLine("		JCB.idUbicacion = UBI.idUbicacion ");
                    strB.AppendLine("	AND UBI.Estatus = 1 ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Region REG ON ");
                    strB.AppendLine("		UBI.idRegion = REG.idRegion ");
                    strB.AppendLine("	AND REG.Estatus = 1 ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Marca MAR ON ");
                    strB.AppendLine("		JCB.idMarca = MAR.idMarca ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Proveedor PRO ON ");
                    strB.AppendLine("		JCB.idProveedor = PRO.idProveedor ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		SistemaOperativo SO ON ");
                    strB.AppendLine("		JCB.idSistema = SO.idSistema");
                    strB.AppendLine("	WHERE JCB.NoSerie = @NoSerie");
                    strB.AppendLine("	UNION ALL ");
                    strB.AppendLine("	SELECT ");
                    strB.AppendLine("			USU.Nombre Usuario, ");
                    strB.AppendLine("			UBI.Descripcion Ubicacion, ");
                    strB.AppendLine("			REG.Nombre Region, ");
                    strB.AppendLine("			TEQ.Descripcion TipoActivo, ");
                    strB.AppendLine("			HSC.NoSerie, ");
                    strB.AppendLine("			HSC.CodigoCastor, ");
                    strB.AppendLine("			HSC.Observacion1,");
                    strB.AppendLine("			HSC.Observacion2, ");
                    strB.AppendLine("			HSC.Observacion3, ");
                    strB.AppendLine("		    CASE ");
                    strB.AppendLine("			    WHEN HSC.idTipoEquipo  = 1 OR HSC.idTipoEquipo  = 2 OR HSC.idTipoEquipo = 3 THEN ");
                    strB.AppendLine("				    'MODELO:' + ISNULL(LTRIM(RTRIM(HSC.Modelo)), '') + ");
                    strB.AppendLine("				    ', PROCESADOR: ' + ISNULL(HSC.Procesador, '') + ");
                    strB.AppendLine("				    ', RAM: ' + ISNULL(HSC.RAM, '') + ");
                    strB.AppendLine("				    ', DISCO DURO: ' + ISNULL(HSC.DiscoDuro, '') + ");
                    strB.AppendLine("				    ', SISTEMA OPERATIVO: ' + ISNULL(SO.Descripcion, '') + ");
                    strB.AppendLine("				    ', MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                    strB.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                    strB.AppendLine("			    ELSE ");
                    strB.AppendLine("				    'MARCA: ' + ISNULL(MAR.Descripcion, '') + ");
                    strB.AppendLine("				    ', PROVEEDOR: ' + ISNULL(PRO.Descripcion, '') ");
                    strB.AppendLine("		    END AS Observacion, ");
                    strB.AppendLine("			HSC.Responsiva, ");
                    strB.AppendLine("			'CORP' Tipo ");
                    strB.AppendLine("	FROM Articulo ART ");
                    strB.AppendLine("	LEFT JOIN  ");
                    strB.AppendLine("		ArticuloCorporativo HSC ON");
                    strB.AppendLine("		ART.NoSerie = HSC.NoSerie");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		TipoEquipo TEQ ON ");
                    strB.AppendLine("		HSC.idTipoEquipo = TEQ.idTipoEquipo ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Usuario USU ON ");
                    strB.AppendLine("		HSC.idUsuario = USU.idUsuario ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Ubicacion UBI ON ");
                    strB.AppendLine("		HSC.idUbicacion = UBI.idUbicacion ");
                    strB.AppendLine("	AND UBI.Estatus = 1 ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Region REG ON ");
                    strB.AppendLine("		UBI.idRegion = REG.idRegion ");
                    strB.AppendLine("	AND REG.Estatus = 1 ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Marca MAR ON ");
                    strB.AppendLine("		HSC.idMarca = MAR.idMarca ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		Proveedor PRO ON ");
                    strB.AppendLine("		HSC.idProveedor = PRO.idProveedor ");
                    strB.AppendLine("	LEFT JOIN ");
                    strB.AppendLine("		SistemaOperativo SO ON ");
                    strB.AppendLine("		HSC.idSistema = SO.idSistema");
                    strB.AppendLine("	WHERE HSC.NoSerie = @NoSerie");
                    break;
            }
            return strB.ToString();
        }
        internal void LlenaIndices()
        {
            BLReportes rpTipoActivoLista = new BLReportes();

            hdnIndicesChk.Value += rpTipoActivoLista.RegresaIndexTipoActivo();
        }
        internal string ObtieneSeleccionados()
        {
            string sSeleccion = string.Empty;
            string[] aSeleccion = hdnRespuesta.Value.Split(new Char[] { '|' });

            for (int i = 0; i < aSeleccion.Length; i++)
            {
                if (aSeleccion[i].ToString() != string.Empty)
                    sSeleccion += aSeleccion[i].ToString() + ",";
            }

            if (sSeleccion != string.Empty)
                return sSeleccion.Substring(0, sSeleccion.LastIndexOf(","));
            else
                return "";
        }
    }
}