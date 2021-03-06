﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventarioHSC.WS_Excel {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WS_Excel.ExportarSoap")]
    public interface ExportarSoap {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ReportePolizas")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ReportePolizas(int TipoDocumento, string UserName, System.DateTime FechaIni, System.DateTime FechaFin, int NumeroMovimiento, string Cuenta, string DescripcionCuenta, string DescripcionEncabezado, int Moneda, bool BusquedaEstricta, string RutaArchivos, string Archivo, int RegistrosPorHoja);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/RelSrvApp")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void RelSrvApp(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Srv_Id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/RelBDApp")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void RelBDApp(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string AppBD_Id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/RelSrvBD")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void RelSrvBD(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Srv_Id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/DiscosSrv")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DiscosSrv(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Srv_Id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/GeneralAplicaciones")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void GeneralAplicaciones(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string AppSt_Id, string AppT_Id, string App_EnTFS, string App_Productiva);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/GeneralServidores")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void GeneralServidores(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string idSO, string idEquipo, string Srv_Tipo, string Srv_EsVirtual, string Srv_Estado);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/InventarioEquipos")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void InventarioEquipos(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string idTipoEquipo, string idMarca, string idUbicacion, string idUsuario, string Responsiva, string Modelo, string NoSerie, string FechaMovimientoIni, string FechaMovimientoFin, string idEstado);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/EjecutarRD")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void EjecutarRD(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, System.Data.DataTable Parametros, int RD_Id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/Acumulados_SAP")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void Acumulados_SAP(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Anio, string Empleados, string Concepto_Nomina);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/AsignacionOrganizativa")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void AsignacionOrganizativa(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/AuxiliaresContables")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void AuxiliaresContables(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Ejercicio, string Cuenta_Mayor);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/AuxiliaresDetalle")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void AuxiliaresDetalle(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Ejercicio, string Cuenta_Mayor);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/BalanzasContables")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void BalanzasContables(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Ejercicio, string Cuenta_Mayor);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ContratosLaborales")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ContratosLaborales(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/Cuentas")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void Cuentas(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Cuenta_Mayor);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/DatosBancarios")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DatosBancarios(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/DatosPersonales")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DatosPersonales(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/Direcciones")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void Direcciones(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/HorariosLaborales")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void HorariosLaborales(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IngresoEmpleados")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void IngresoEmpleados(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/MedidasRH")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void MedidasRH(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/NumAntEmp")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void NumAntEmp(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/RemuneracionEconomica")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void RemuneracionEconomica(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/CintasRespaldo")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void CintasRespaldo(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, int Tipo, int Obj_Id, string RC_Cinta);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/MonitoreoSW")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void MonitoreoSW(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string UsuarioRevisor, string Pass, string Dominio, bool RevisarTodos, string EquipoEspecifico);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/InventarioSW")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void InventarioSW(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string SWE_Id, string SWG_Id, string SW_Descripcion, string SW_Version, string SWEx_NoParte, string SWEx_Llave, string SWEx_Ubicacion, string SWEx_Observaciones, string SWEx_EnExistencia);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/RegistrarArchivoTempGeneral")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void RegistrarArchivoTempGeneral(int TipoDocumento, string UserName, string Archivo, bool Finalizado);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ExportarSoapChannel : InventarioHSC.WS_Excel.ExportarSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExportarSoapClient : System.ServiceModel.ClientBase<InventarioHSC.WS_Excel.ExportarSoap>, InventarioHSC.WS_Excel.ExportarSoap {
        
        public ExportarSoapClient() {
        }
        
        public ExportarSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExportarSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExportarSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExportarSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ReportePolizas(int TipoDocumento, string UserName, System.DateTime FechaIni, System.DateTime FechaFin, int NumeroMovimiento, string Cuenta, string DescripcionCuenta, string DescripcionEncabezado, int Moneda, bool BusquedaEstricta, string RutaArchivos, string Archivo, int RegistrosPorHoja) {
            base.Channel.ReportePolizas(TipoDocumento, UserName, FechaIni, FechaFin, NumeroMovimiento, Cuenta, DescripcionCuenta, DescripcionEncabezado, Moneda, BusquedaEstricta, RutaArchivos, Archivo, RegistrosPorHoja);
        }
        
        public void RelSrvApp(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Srv_Id) {
            base.Channel.RelSrvApp(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Srv_Id);
        }
        
        public void RelBDApp(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string AppBD_Id) {
            base.Channel.RelBDApp(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, AppBD_Id);
        }
        
        public void RelSrvBD(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Srv_Id) {
            base.Channel.RelSrvBD(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Srv_Id);
        }
        
        public void DiscosSrv(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Srv_Id) {
            base.Channel.DiscosSrv(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Srv_Id);
        }
        
        public void GeneralAplicaciones(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string AppSt_Id, string AppT_Id, string App_EnTFS, string App_Productiva) {
            base.Channel.GeneralAplicaciones(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, AppSt_Id, AppT_Id, App_EnTFS, App_Productiva);
        }
        
        public void GeneralServidores(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string idSO, string idEquipo, string Srv_Tipo, string Srv_EsVirtual, string Srv_Estado) {
            base.Channel.GeneralServidores(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, idSO, idEquipo, Srv_Tipo, Srv_EsVirtual, Srv_Estado);
        }
        
        public void InventarioEquipos(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string idTipoEquipo, string idMarca, string idUbicacion, string idUsuario, string Responsiva, string Modelo, string NoSerie, string FechaMovimientoIni, string FechaMovimientoFin, string idEstado) {
            base.Channel.InventarioEquipos(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, idTipoEquipo, idMarca, idUbicacion, idUsuario, Responsiva, Modelo, NoSerie, FechaMovimientoIni, FechaMovimientoFin, idEstado);
        }
        
        public void EjecutarRD(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, System.Data.DataTable Parametros, int RD_Id) {
            base.Channel.EjecutarRD(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Parametros, RD_Id);
        }
        
        public void Acumulados_SAP(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Anio, string Empleados, string Concepto_Nomina) {
            base.Channel.Acumulados_SAP(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Anio, Empleados, Concepto_Nomina);
        }
        
        public void AsignacionOrganizativa(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.AsignacionOrganizativa(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void AuxiliaresContables(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Ejercicio, string Cuenta_Mayor) {
            base.Channel.AuxiliaresContables(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Sociedad, Ejercicio, Cuenta_Mayor);
        }
        
        public void AuxiliaresDetalle(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Ejercicio, string Cuenta_Mayor) {
            base.Channel.AuxiliaresDetalle(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Sociedad, Ejercicio, Cuenta_Mayor);
        }
        
        public void BalanzasContables(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Ejercicio, string Cuenta_Mayor) {
            base.Channel.BalanzasContables(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Sociedad, Ejercicio, Cuenta_Mayor);
        }
        
        public void ContratosLaborales(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.ContratosLaborales(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void Cuentas(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Sociedad, string Cuenta_Mayor) {
            base.Channel.Cuentas(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Sociedad, Cuenta_Mayor);
        }
        
        public void DatosBancarios(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.DatosBancarios(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void DatosPersonales(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.DatosPersonales(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void Direcciones(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.Direcciones(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void HorariosLaborales(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.HorariosLaborales(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void IngresoEmpleados(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.IngresoEmpleados(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void MedidasRH(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.MedidasRH(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void NumAntEmp(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.NumAntEmp(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void RemuneracionEconomica(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string Empleados) {
            base.Channel.RemuneracionEconomica(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Empleados);
        }
        
        public void CintasRespaldo(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, int Tipo, int Obj_Id, string RC_Cinta) {
            base.Channel.CintasRespaldo(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, Tipo, Obj_Id, RC_Cinta);
        }
        
        public void MonitoreoSW(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string UsuarioRevisor, string Pass, string Dominio, bool RevisarTodos, string EquipoEspecifico) {
            base.Channel.MonitoreoSW(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, UsuarioRevisor, Pass, Dominio, RevisarTodos, EquipoEspecifico);
        }
        
        public void InventarioSW(int TipoDocumento, string UserName, string RutaArchivos, string Archivo, int RegistrosPorHoja, string SWE_Id, string SWG_Id, string SW_Descripcion, string SW_Version, string SWEx_NoParte, string SWEx_Llave, string SWEx_Ubicacion, string SWEx_Observaciones, string SWEx_EnExistencia) {
            base.Channel.InventarioSW(TipoDocumento, UserName, RutaArchivos, Archivo, RegistrosPorHoja, SWE_Id, SWG_Id, SW_Descripcion, SW_Version, SWEx_NoParte, SWEx_Llave, SWEx_Ubicacion, SWEx_Observaciones, SWEx_EnExistencia);
        }
        
        public void RegistrarArchivoTempGeneral(int TipoDocumento, string UserName, string Archivo, bool Finalizado) {
            base.Channel.RegistrarArchivoTempGeneral(TipoDocumento, UserName, Archivo, Finalizado);
        }
    }
}
