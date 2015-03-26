using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Threading;

namespace InventarioHSC.BusinessLayer
{
    public class BLReportes
    {
        public BLReportes()
        { 
        }

        public string RegresaIndexTipoActivo()
        {
            string sRegresa = string.Empty;
            int iCont = 0;

            DLTipoEquipo oTipoActivo = new DLTipoEquipo();

            List<TipoEquipo> lstTipoEquipo = oTipoActivo.getTipoEquipoAll();

            foreach(TipoEquipo sTipoActivo in lstTipoEquipo)
            {
                sRegresa += sTipoActivo.idTipoEquipo + "|" + sTipoActivo.descripcion + "|" + iCont + "@";
                iCont += 1;
            }

            return sRegresa;
        }

        #region Equipos
        public DataTable ReporteInventarioEquipo(string idTipoEquipo, string idMarca, string idUbicacion, string idUsuario, string Responsiva, string Modelo, string NoSerie, string FechaMovimientoIni, string FechaMovimientoFin, string idEstado)
        {
            DLArticulo Reporte = new DLArticulo();
            DateTime? FechaIni;
            DateTime? FechaFin;

            if (idTipoEquipo.Trim() == "")
                idTipoEquipo = null;

            if (idMarca.Trim() == "")
                idMarca = null;

            if (idUbicacion.Trim() == "")
                idUbicacion = null;

            if (idUsuario.Trim() == "")
                idUsuario = null;

            if (Responsiva.Trim() == "")
                Responsiva = null;

            if (Modelo.Trim() == "")
                Modelo = null;

            if (NoSerie.Trim() == "")
                NoSerie = null;

            if (idEstado.Trim() == "")
                idEstado = null;

            if (FechaMovimientoIni.Trim() == "" || FechaMovimientoIni.Replace(" ", "") == "//")
                FechaIni = null;
            else
                FechaIni = DateTime.ParseExact(FechaMovimientoIni, "dd/MM/yyyy", Thread.CurrentThread.CurrentCulture);

            if (FechaMovimientoFin.Trim() == "" || FechaMovimientoFin.Replace(" ", "") == "//")
                FechaFin = null;
            else
                FechaFin = DateTime.ParseExact(FechaMovimientoFin + " 23:59:59", "dd/MM/yyyy HH:mm:ss", Thread.CurrentThread.CurrentCulture);

            return Reporte.InventarioEquipos(idTipoEquipo, idMarca, idUbicacion, idUsuario, Responsiva, Modelo, NoSerie, FechaIni, FechaFin, idEstado);
        }
        #endregion Equipos
        #region Aplicaciones
        public DataSet ReporteInventarioSW(string SWE_Id, string SWG_Id, string SW_Descripcion, string SW_Version, string SWEx_NoParte, string SWEx_Llave, string SWEx_Ubicacion, string SWEx_Observaciones, string SWEx_EnExistencia, bool IncluirEstadisticas)
        {
            DLSoftware Reporte = new DLSoftware();
            bool? EnExistencia = null;

            SWEx_EnExistencia = SWEx_EnExistencia.Trim();

            if (SWE_Id.Trim() == "")
                SWE_Id = null;

            if (SWG_Id.Trim() == "")
                SWG_Id = null;

            if (SW_Descripcion.Trim() == "")
                SW_Descripcion = null;

            if (SW_Version.Trim() == "")
                SW_Version = null;

            if (SWEx_NoParte.Trim() == "")
                SWEx_NoParte = null;

            if (SWEx_Llave.Trim() == "")
                SWEx_Llave = null;

            if (SWEx_Ubicacion.Trim() == "")
                SWEx_Ubicacion = null;

            if (SWEx_Observaciones.Trim() == "")
                SWEx_Observaciones = null;

            if (SWEx_EnExistencia == "NO")
                EnExistencia = false;
            else if (SWEx_EnExistencia == "SI")
                EnExistencia = true;

            return Reporte.InventarioSW(SWE_Id, SWG_Id, SW_Descripcion, SW_Version, SWEx_NoParte, SWEx_Llave, SWEx_Ubicacion, SWEx_Observaciones, EnExistencia, IncluirEstadisticas);
        }

        public DataSet ReporteGeneralServidores(string idSO, string idEquipo, string Srv_Tipo, string Srv_EsVirtual, string Srv_Estado)
        {
            DLSoftware Reporte = new DLSoftware();
            bool? Srv_EsVirtualb = null;
            bool? Srv_Estadob = null;

            Srv_EsVirtual = Srv_EsVirtual.Trim();
            Srv_Estado = Srv_Estado.Trim();

            if (idSO.Trim() == "")
                idSO = null;

            if (idEquipo.Trim() == "")
                idEquipo = null;

            if (Srv_Tipo.Trim() == "")
                Srv_Tipo = null;

            if (Srv_EsVirtual == "NO")
                Srv_EsVirtualb = false;
            else if (Srv_EsVirtual == "SI")
                Srv_EsVirtualb = true;

            if (Srv_Estado == "NO")
                Srv_Estadob = false;
            else if (Srv_Estado == "SI")
                Srv_Estadob = true;

            return Reporte.ReporteGeneralServidores(idSO, idEquipo, Srv_Tipo, Srv_EsVirtualb, Srv_Estadob);
        }

        public DataSet ReporteGeneralAplicaciones(string AppSt_Id, string AppT_Id, string App_EnTFS, string App_Productiva)
        {
            DLSoftware Reporte = new DLSoftware();
            bool? App_EnTFSb = null;
            bool? App_Productivab = null;

            App_EnTFS = App_EnTFS.Trim();
            App_Productiva = App_Productiva.Trim();

            if (AppSt_Id.Trim() == "")
                AppSt_Id = null;

            if (AppT_Id.Trim() == "")
                AppT_Id = null;

            if (App_EnTFS == "NO")
                App_EnTFSb = false;
            else if (App_EnTFS == "SI")
                App_EnTFSb = true;

            if (App_Productiva == "NO")
                App_Productivab = false;
            else if (App_Productiva == "SI")
                App_Productivab = true;

            return Reporte.ReporteGeneralAplicaciones(AppSt_Id, AppT_Id, App_EnTFSb, App_Productivab);
        }

        public DataTable ReporteRelSrvApp(string Srv_Id, string RutaArchivos)
        {
            DLSoftware sw = new DLSoftware();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Srv_Id.Trim() == "")
                Srv_Id = null;

            string Archivo = sw.ReporteRelSrvApp(Srv_Id, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de relación Srv-App";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable ReporteRelBDApp(string AppBD_Id, string RutaArchivos)
        {
            DLSoftware sw = new DLSoftware();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (AppBD_Id.Trim() == "")
                AppBD_Id = null;

            string Archivo = sw.ReporteRelBDApp(AppBD_Id, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de relación BD-App";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable ReporteRelSrvBD(string Srv_Id, string RutaArchivos)
        {
            DLSoftware sw = new DLSoftware();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Srv_Id.Trim() == "")
                Srv_Id = null;

            string Archivo = sw.ReporteRelSrvBD(Srv_Id, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de relación Srv-BD";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public string ReporteDiscosSrv(string Srv_Id, string RutaArchivos)
        {
            DLSoftware sw = new DLSoftware();

            if (Srv_Id.Trim() == "")
                Srv_Id = null;

            return sw.ReporteDiscosSrv(Srv_Id, RutaArchivos + "\\");
        }
        #endregion Aplicaciones
        #region SAP
        #region FICO
        public DataTable Balanzas(string Sociedad, string Ejercicio, string Cuenta_Mayor, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Sociedad.Trim() == "")
                Sociedad = null;

            if (Ejercicio.Trim() == "")
                Ejercicio = null;

            if (Cuenta_Mayor.Trim() == "")
                Cuenta_Mayor = null;

            string Archivo = sap.Balanzas(Sociedad, Ejercicio, Cuenta_Mayor, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de balanzas";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable Auxiliares(string Sociedad, string Ejercicio, string Cuenta_Mayor, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Sociedad.Trim() == "")
                Sociedad = null;

            if (Ejercicio.Trim() == "")
                Ejercicio = null;

            if (Cuenta_Mayor.Trim() == "")
                Cuenta_Mayor = null;

            string Archivo = sap.Auxiliares(Sociedad, Ejercicio, Cuenta_Mayor, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de auxiliares";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable AuxiliaresDetalle(string Sociedad, string Ejercicio, string Cuenta_Mayor, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Sociedad.Trim() == "")
                Sociedad = null;

            if (Ejercicio.Trim() == "")
                Ejercicio = null;

            if (Cuenta_Mayor.Trim() == "")
                Cuenta_Mayor = null;

            string Archivo = sap.AuxiliaresDetalle(Sociedad, Ejercicio, Cuenta_Mayor, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte detalle de auxiliares";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable Cuentas(string Sociedad, string Cuenta_Mayor, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Sociedad.Trim() == "")
                Sociedad = null;

            if (Cuenta_Mayor.Trim() == "")
                Cuenta_Mayor = null;

            string Archivo = sap.Cuentas(Sociedad, Cuenta_Mayor, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de cuentas";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }
        #endregion FICO
        #region RH
        public DataTable IngresoEmpleados(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.IngresoEmpleados(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte ingreso de empleados";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable AsignacionOrganizativa(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.AsignacionOrganizativa(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de asignación organizativa";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable DatosBancarios(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.DatosBancarios(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de datos bancarios";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable NumeroAnterior(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.NumeroAnterior(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de número anterior de empleado";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable DatosPersonales(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.DatosPersonales(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de datos personales";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable Direcciones(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.Direcciones(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de direcciones";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable ContratoLaboral(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.ContratoLaboral(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de contrato laboral";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }
        
        public DataTable RemuneracionEconomica(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.RemuneracionEconomica(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de remuneración económica";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable HorarioLaboral(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.HorarioLaboral(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de horario laboral";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable Medidas(string Empleados, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Empleados.Trim() == "")
                Empleados = null;

            string Archivo = sap.Medidas(Empleados, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de medidas";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }
        //Acumulados(string Anio,string No_Pers, string Concepto_Nomina, string RutaArchivos)
        public DataTable Acumulados(string Anio, string Empleados, string Concepto_Nomina, string RutaArchivos)
        {
            DLSAP sap = new DLSAP();
            DataTable Res = new DataTable();

            Res.Columns.Add("Concepto");
            Res.Columns.Add("Ruta");

            if (Anio.Trim() == "")
                Anio = null;

            if (Empleados.Trim() == "")
                Empleados = null;

            if (Concepto_Nomina.Trim() == "")
                Concepto_Nomina = null;

            string Archivo = sap.Acumulados(Anio, Empleados, Concepto_Nomina, RutaArchivos + "\\");
            DataRow dr;

            dr = Res.NewRow();
            dr[0] = "Reporte de acumulados";
            dr[1] = DatosGenerales.RutaReportesDinamicos + Archivo;
            Res.Rows.Add(dr);

            return Res;
        }

        public DataTable Documentos(string Rep_Tipo, string Rep_SubTipo, int Rep_Anno, string Rep_Clave)
        {
            DLSAP sap = new DLSAP();

            if (Rep_SubTipo.Trim() == "")
                Rep_SubTipo = null;

            return sap.Documentos(Rep_Tipo, Rep_SubTipo, Rep_Anno, Rep_Clave);
        }
        #endregion RH
        #endregion SAP
        #region Operacion
        public DataTable ReporteCartasGeneradas(int? NumeroPrestamo, string NombreAcreditado, bool AplicaRangoFechas, DateTime Fechaini, DateTime Fechafin)
        {
            DLOperaciones objOp = new DLOperaciones();

            DateTime? FechaIni;
            DateTime? FechaFin;

            if (NumeroPrestamo <= 0)
                NumeroPrestamo = null;

            if (NombreAcreditado.Trim() == "")
                NombreAcreditado = null;

            if (AplicaRangoFechas)
            {
                if (Fechaini.ToString("yyyyMMdd") == "19000101")
                    FechaIni = null;
                else
                    FechaIni = Fechaini;

                if (Fechafin.ToString("yyyyMMdd") == "19000101")
                    FechaFin = null;
                else
                    FechaFin = Fechafin;

                if (FechaFin != null)
                    FechaFin = Fechafin.AddDays(1).AddSeconds(-1);
            }
            else
            {
                FechaIni = null;
                FechaFin = null;
            }

            return objOp.ReporteCartasGeneradas(NumeroPrestamo, NombreAcreditado, FechaIni, FechaFin);
        }
        #endregion Operacion
        #region Abanks
        public DataTable ReportePolizas(DateTime FechaIni, DateTime FechaFin, int NumeroMovimiento, string Cuenta, string DescripcionCuenta, string DescripcionEncabezado, int Moneda, bool BusquedaEstricta, string RutaArchivos)
        {
            DLOperaciones objOp = new DLOperaciones();
            int? NumeroMovimientoN = null;
            int? MonedaN = null;

            if (NumeroMovimiento > 0)
                NumeroMovimientoN = NumeroMovimiento;

            if (Moneda > 0)
                MonedaN = Moneda;

            if (string.IsNullOrWhiteSpace(Cuenta))
                Cuenta = null;

            if (string.IsNullOrWhiteSpace(DescripcionCuenta))
                DescripcionCuenta = null;

            if (string.IsNullOrWhiteSpace(DescripcionEncabezado))
                DescripcionEncabezado = null;

            //FechaFin = FechaFin.AddDays(1).AddMilliseconds(-1);

            string Archivo = objOp.ReportePolizas(FechaIni.Year, FechaIni, FechaFin, NumeroMovimientoN, Cuenta, DescripcionCuenta, DescripcionEncabezado, MonedaN, BusquedaEstricta, RutaArchivos + "\\");

            DataTable Tabla = new DataTable();
            DataRow dr;

            Tabla.Columns.Add("Concepto");
            Tabla.Columns.Add("Ruta");
            dr = Tabla.NewRow();

            if (Archivo.Length > 4 && Archivo.Substring(0, 5) != "Error")
            {
                dr[0] = "Reporte de pólizas abanks";
                dr[1] = Archivo = DatosGenerales.RutaReportesDinamicos + Archivo;
            }
            else
            {
                dr[0] = "Error al generar: " + Archivo;
                dr[1] = "#";
            }

            Tabla.Rows.Add(dr);

            return Tabla;
        }
        #endregion Abanks
        #region Dinamicos
        public string InsertarCatalogo(DatosGenerales.EstiloReportesDinamicos Estilo, string Descripcion, string Script, string Conexion, bool Autorizado, string TipoDato)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.InsertarCatalogo((int)Estilo, Descripcion, Script, Conexion, Autorizado, TipoDato);
        }

        public DataTable ParametrosStored(string Cnx, string Stored)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.ParametrosStored(Cnx, Stored);
        }

        public string ScriptStored(string Cnx, string Stored)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.ScriptStored(Cnx, Stored);
        }

        public int InsertarReporte(string RD_Nombre, int RDTS_Id, string RD_Script, string RD_Conexion, bool RD_Activo, string UserName)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.InsertarReporte(RD_Nombre, RDTS_Id, RD_Script, RD_Conexion, RD_Activo, UserName);
        }

        public string InsertarParametro(int RD_Id, string RDP_Nombre, string RDP_Tipo, string RDP_TipoDato, int RDP_Longitud, bool RDP_Obligatorio, string RDP_Entrada, int RDC_Id, bool RDP_AceptaNulo, bool RDP_BusquedaAproximada, string RDP_Texto, bool AplicarBorradoPrevio)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.InsertarParametro(RD_Id, RDP_Nombre, RDP_Tipo, RDP_TipoDato, RDP_Longitud, RDP_Obligatorio, RDP_Entrada, RDC_Id, RDP_AceptaNulo, RDP_BusquedaAproximada, RDP_Texto, AplicarBorradoPrevio);
        }

        public DataTable CargarParametrosScript(IEnumerable<string> Variables)
        {
            DataTable Resultados = new DataTable();

            Resultados.Columns.Add("Nombre");
            Resultados.Columns.Add("Tipo");
            Resultados.Columns.Add("TipoDato");
            Resultados.Columns.Add("Longitud");

            foreach (string str in Variables)
            {
                DataRow dr = Resultados.NewRow();

                dr["Nombre"] = str;
                dr["Tipo"] = "IN";
                dr["TipoDato"] = "";
                dr["Longitud"] = "";
                Resultados.Rows.Add(dr);
            }

            Resultados.AcceptChanges();

            return Resultados;
        }

        public DataTable ObtenerTiposDato(string Cnx)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.ObtenerTiposDato(Cnx);
        }

        public DataTable ObtenerParametrosReporte(int RD_Id)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.ObtenerParametrosReporte(RD_Id);
        }

        public int ActualizarReporte(int RD_Id, string RD_Nombre, string RD_Script, string UserName)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            return objRpt.ActualizarReporte(RD_Id, RD_Nombre, RD_Script, UserName);
        }

        public DataTable ObtenerReportesAutorizaciones(bool? Autorizado = null)
        {
             DLRptDinamicos objRpt = new DLRptDinamicos();

             return objRpt.ObtenerReportesAutorizaciones(Autorizado);
        }

        public void ActualizarAutorizacionReporte(int Id, bool Autorizado, bool EsCat)
        {
            DLRptDinamicos objRpt = new DLRptDinamicos();

            objRpt.ActualizarAutorizacionReporte(Id, Autorizado, EsCat);
        }

        #region Permisos_Usuarios
        public void BuscarUsuarioPermisos(ref DropDownList oddlUsu, string strBusqueda)
        {
            DLRptDinamicos odlRpt = new DLRptDinamicos();

            oddlUsu.DataValueField = "puestoDesc";
            oddlUsu.DataTextField = "nombre";
            oddlUsu.DataSource = odlRpt.BuscarUsuarioPermisos(strBusqueda);
        }

        public System.Data.DataTable LeePermisosUsuario(string UserId)
        {
            DLRptDinamicos odlRpt = new DLRptDinamicos();

            return odlRpt.LeePermisosUsuario(UserId);
        }

        public System.Data.DataTable ActualizaPermisosUsuario(string UserId, int RD_Id, bool Usu_Autorizado)
        {
            DLRptDinamicos odlRpt = new DLRptDinamicos();

            return odlRpt.ActualizaPermisosUsuario(UserId, RD_Id, Usu_Autorizado);
        }
        #endregion Permisos_Usuarios

        public struct RptDinamicosParametro
        {
            public string Nombre;
            public string Tipo;
            public string TipoDato;
            public int Longitud;
            public bool Obligatorio;
            public string Entrada;
            public int Catalogo;
            public bool AceptaNulo;
            public bool BusquedaAproximada;
            public string Descripcion;

            private const int CeldaNombre = 1;
            private const int CeldaTipo = 2;
            private const int CeldaTipoDato = 3;
            private const int CeldaLongitud = 4;
            private const int CeldaObligatorio = 5;
            private const int CeldaEntrada = 6;
            private const int CeldaCat = 7;
            private const int CeldaANulo = 8;
            private const int CeldaBAprox = 9;

            public RptDinamicosParametro(GridViewRow row)
            {
                CheckBox chkO = (CheckBox)row.FindControl("chkObligatorio");
                Label lblE = (Label)row.FindControl("lblEntrada");
                Label lblC = (Label)row.FindControl("lblCat");
                Label lblN = (Label)row.FindControl("lblNull");
                Label lblB = (Label)row.FindControl("lblBAprox");
                Label lblD = (Label)row.FindControl("lblDesc");
                
                Nombre = row.Cells[CeldaNombre].Text;
                Tipo = row.Cells[CeldaTipo].Text;
                TipoDato = row.Cells[CeldaTipoDato].Text;
                int.TryParse(row.Cells[CeldaLongitud].Text, out Longitud);
                Obligatorio = chkO.Checked;
                Entrada = lblE.Text;
                int.TryParse(lblC.Text, out Catalogo);

                if (lblN.Text.ToLowerInvariant() == "si")
                    AceptaNulo = true;
                else
                    AceptaNulo = false;

                if (lblB.Text.ToLowerInvariant() == "si")
                    BusquedaAproximada = true;
                else
                    BusquedaAproximada = false;

                if (Obligatorio)
                    AceptaNulo = false;

                Descripcion = lblD.Text;
            }
        }
        #endregion Dinamicos
    }
}
