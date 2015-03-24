using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLSoftware
    {
        private Software objectSoftware = new Software();
        public DLSoftware DataLayerSoftware = new DLSoftware();

        public BLSoftware()
        {

        }
        public BLSoftware(Software oSoftware)
        {
            objectSoftware = oSoftware;
        }

        public string validaAlta()
        {
            string sMensaje = string.Empty;
            sMensaje = "OK";

            List<Software> valSoftware = DataLayerSoftware.getSoftware(objectSoftware.Descripcion);

            if (valSoftware.Count > 0)
            {
                sMensaje = "Validación: Ya existe un software con la descripción '" + objectSoftware.Descripcion + "'";    
            }

            return sMensaje;
        }

        public string insertaSoftwareNuevo()
        {
            string Resultado = string.Empty;
            string SalidaMensaje = string.Empty;
            Resultado = validaAlta();

            if (Resultado == "OK")
            {
                try
                {
                    DataLayerSoftware.InsertSoftware(ref objectSoftware);
                    SalidaMensaje = "El software '" + objectSoftware.Descripcion.ToString() + "' fue agregado correctamente";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                SalidaMensaje = Resultado;
            }

            return SalidaMensaje;
        }

        public string actualizaSoftware()
        {
            string Resultado = "OK";
            string SalidaMensaje = string.Empty;

            if (Resultado == "OK")
            {
                try
                {
                    DataLayerSoftware.UpdateArticulo(objectSoftware);
                    SalidaMensaje = "El software '" + objectSoftware.Descripcion + "' fue modificado correctamente";
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else
            {
                SalidaMensaje = Resultado;
            }

            return SalidaMensaje;
        }

        public List<Software> ObtieneSoftware()
        {
            List<Software> alstSoftware = new List<Software>();
            alstSoftware = DataLayerSoftware.getSoftware();
            return alstSoftware;
        }

        public List<Software> OntieneFiltroSoftware(string NombreLicencia, string version , int? cantidad)
        {
            List<Software> alstSoftware = new List<Software>();
            alstSoftware = DataLayerSoftware.getSoftware(NombreLicencia, version, cantidad);
            return alstSoftware;
        }

        public List<Software> ObtieneSoftwareDetalle()
        {
            List<Software> alstSoftware = new List<Software>();
            alstSoftware = DataLayerSoftware.getSoftwareDetalle();
            return alstSoftware;
        }

        public List<Software> OntieneFiltroSoftwareDetalle(string NombreLicencia, string version, int? cantidad)
        {
            List<Software> alstSoftware = new List<Software>();
            alstSoftware = DataLayerSoftware.getSoftwareDetalle(NombreLicencia, version, cantidad);
            return alstSoftware;
        }

        public List<TotalesSoftware> ObtieneTotalesSoftware(string NombreLicencia, string version, int? cantidad)
        {
            return DataLayerSoftware.ObtieneTotalesSoftware(NombreLicencia, version, cantidad);
        }

        public List<Software> ObtenSoftwareDisponible()
        {
            List<Software> alstSoftware = new List<Software>();
            alstSoftware = DataLayerSoftware.getSoftwareDsiponible();
            return alstSoftware;
        }

        public List<TotalesSoftware> ObtieneTotalesSoftware(int cve_Software)
        {
            return DataLayerSoftware.ObtieneTotalesSoftware(cve_Software);
        }

        public List<TotalesSoftware> ObtieneFiltroTotalesSoftware(int cve_Software)
        {
            return DataLayerSoftware.ObtieneTotalesSoftware(cve_Software);
        }

        public Software Software(int cve_Software)
        {
            return DataLayerSoftware.Software(cve_Software);
        }

        public string xmlDataTotales(List<TotalesSoftware> totales, string titulo = "")
        {
            //Now, we need to convert this data into XML. We convert using string concatenation.
            string xmlData;
            //Initialize <chart> element
            if (totales.Count > 0)
            {
                xmlData = "<chart caption='Resumen de Totales " + titulo  + "' xAxisName='Motivo' showValues='0' yAxisName='Porcentaje' formatNumberScale='0' showBorder='0' >";
                //Convert data to XML and append 

                foreach (TotalesSoftware itemSoftware in totales)
                {
                    xmlData += "<set label='" + itemSoftware.concepto + "' value='" + itemSoftware.conteo + "' />";
                }

                xmlData += "<styles>";
                xmlData += "<definition>";
                xmlData += "<style name='MyFirstFontStyle' type='font' size='8' color='005588' bold='1.5'/>";
                xmlData += "<style name='MySecondFontStyle' type='font' face='Arial' size='11' color='005588' bold='1'/>";
                xmlData += "<style name='MyFirstAnimationStyle' type='animation' param='_xScale' start='0' duration='2' />";
                xmlData += "</definition>";
                xmlData += "<application>";
                xmlData += "<apply toObject='DATALABELS' styles='MyFirstFontStyle' />";
                xmlData += "<apply toObject='CAPTION' styles='MySecondFontStyle' />";
                xmlData += "<apply toObject='Canvas' styles='MyFirstAnimationStyle' />";
                xmlData += "</application>";
                xmlData += "</styles>";
                //Close <chart> element
                xmlData += "</chart>";

                return xmlData;
            }
            else
            {
                return "";
            }
        }

        public string InsertaCatalogo(int Empresa, int Grupo, string Descripcion, string Version, bool Estatus = true)
        {
            CatalogoSoftware objSoftware = new CatalogoSoftware();
            DLSoftware odlSoftware = new DLSoftware();

            objSoftware.idEmpresa = Empresa;
            objSoftware.idGrupo = Grupo;
            objSoftware.Descripcion = Descripcion;
            objSoftware.Version = Version;
            objSoftware.Estatus = Estatus;

            return odlSoftware.InsertaCatalogo(ref objSoftware);
        }

        public string InsertaInventario(int SW_Id, string Descripcion, string NoParte, string Llave, string Ubicacion, string Observaciones, bool EnExistencia = true)
        {
            SoftwareExistente objSoftware = new SoftwareExistente();
            DLSoftware odlSoftware = new DLSoftware();

            objSoftware.Id = 0;
            objSoftware.SW_Id = SW_Id;
            objSoftware.Descripcion = Descripcion;
            objSoftware.NoParte = NoParte;
            objSoftware.Llave = Llave;
            objSoftware.Ubicacion = Ubicacion;
            objSoftware.Observaciones = Observaciones;
            objSoftware.EnExistencia = EnExistencia;

            return odlSoftware.InsertaInventario(ref objSoftware);
        }

        public string InsertaEmpresaSoftware(string Descripcion)
        {
            EmpresasSoftware objSoftware = new EmpresasSoftware();
            DLSoftware odlSoftware = new DLSoftware();

            objSoftware.descripcion = Descripcion;

            return odlSoftware.InsertaEmpresaSoftware(ref objSoftware);
        }

        public string InsertaGrupoSoftware(string Descripcion)
        {
            GruposSoftware objSoftware = new GruposSoftware();
            DLSoftware odlSoftware = new DLSoftware();

            objSoftware.descripcion = Descripcion;

            return odlSoftware.InsertaGrupoSoftware(ref objSoftware);
        }
        #region Aplicaciones
        public void HistoricoApp(string Pagina, string UserId, string HApp_Tipo, int HApp_IdModificado, int HApp_IdModificado2 = 0)
        {
            DLSoftware odlSoftware = new DLSoftware();

            odlSoftware.HistoricoApp(Pagina, UserId, HApp_Tipo, HApp_IdModificado, HApp_IdModificado2);
        }

        public string InsertarServidorApp(Servidores server, System.Data.DataTable Discos, string Srv_Observaciones)
        {
            DLSoftware odlSoftware = new DLSoftware();
            
            return odlSoftware.InsertarServidorApp(server, Discos, Srv_Observaciones);
        }

        public string ActualizarServidorApp(Servidores server, System.Data.DataTable Discos, string Srv_Observaciones)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.ActualizarServidorApp(server, Discos, Srv_Observaciones);
        }

        public string InsertarInstanciaBD(int Srv_Id, int BD_Id, string AppSB_Nombre)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.InsertarInstanciaBD(Srv_Id, BD_Id, AppSB_Nombre);
        }

        public string ActualizarInstanciaBD(int AppSB_Id, int Srv_Id, int BD_Id, string AppSB_Nombre)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.ActualizarInstanciaBD(AppSB_Id, Srv_Id, BD_Id, AppSB_Nombre);
        }

        public string InsertarBDServidor(int AppSB_Id, string AppBD_Nombre, bool AppBD_Activa, bool AppBD_Productiva)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.InsertarBDServidor(AppSB_Id, AppBD_Nombre, AppBD_Activa, AppBD_Productiva);
        }

        public string BorrarDiscosServidorApp(int Srv_Id, string SrvD_Unidad)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.BorrarDiscosServidorApp(Srv_Id, SrvD_Unidad);
        }

        public string InsertarDiscoServidorApp(int Srv_Id, int SrvD_Capacidad, string SrvD_Unidad, int SrvTA_Id, int SrvUD_Id, int idItem, string SrvD_Observaciones)
        {
            DLSoftware odlSoftware = new DLSoftware();
            string Res = "";

            odlSoftware.BorrarDiscosServidorApp(Srv_Id, SrvD_Unidad);

            Res = odlSoftware.InsertarDiscoServidorApp(Srv_Id, SrvD_Capacidad, SrvD_Unidad, SrvTA_Id, SrvUD_Id, idItem, SrvD_Observaciones);

            if (Res != "")
                Res += "Error al insertar unidad " + SrvD_Unidad + ": " + Res.Replace(Environment.NewLine, "\t") + Environment.NewLine;

            return Res;
        }

        public string InsertarDiscosServidorApp(int Srv_Id, System.Data.DataTable Discos)
        {
            DLSoftware odlSoftware = new DLSoftware();
            string Res = "";
            string ResTemp = "";

            odlSoftware.BorrarDiscosServidorApp(Srv_Id);

            for (int w = 0; w < Discos.Rows.Count; w++)
            {
                ResTemp = odlSoftware.InsertarDiscoServidorApp(Srv_Id, Convert.ToInt32(Discos.Rows[w]["SrvD_Capacidad"].ToString()), Discos.Rows[w]["SrvD_Unidad"].ToString(), Convert.ToInt32(Discos.Rows[w]["SrvTA_Id"].ToString()), Convert.ToInt32(Discos.Rows[w]["SrvUD_Id"].ToString()), Convert.ToInt32(Discos.Rows[w]["idItem"].ToString()), Discos.Rows[w]["SrvD_Observaciones"].ToString());

                if (ResTemp != "")
                    Res += "Error al insertar unidad " + Discos.Rows[w]["SrvD_Unidad"].ToString() + ": " + ResTemp.Replace(Environment.NewLine, "\t") + Environment.NewLine;
            }

            return Res;
        }

        public string InsertarAplicacion(int AppSt_Id, int AppT_Id, string App_Nombre, string App_Descripcion, bool App_EnTFS, bool App_Productiva, string App_Observaciones, string App_Ubicacion, int Srv_Id, bool Srv_EsPropietaria, int AppBD_Id, bool BD_EsPropietaria)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.InsertarAplicacion(AppSt_Id, AppT_Id, App_Nombre, App_Descripcion, App_EnTFS, App_Productiva, App_Observaciones, App_Ubicacion, Srv_Id, Srv_EsPropietaria, AppBD_Id, BD_EsPropietaria);
        }

        public string InsertarAppRelServer(int App_Id, int Srv_Id, bool EsPropietaria)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.InsertarAppRelServer(App_Id, Srv_Id, EsPropietaria);
        }

        public string BorrarAppRelServer(int App_Id)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.BorrarAppRelServer(App_Id);
        }

        public string BorrarAppRelBD(int App_Id)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.BorrarAppRelBD(App_Id);
        }

        public string InsertarAppRelBD(int App_Id, int AppBD_Id, bool EsPropietaria)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.InsertarAppRelBD(App_Id, AppBD_Id, EsPropietaria);
        }

        public void InformacionGeneralServidor(int Srv_Id, ref System.Data.DataTable InfoServidor, ref System.Data.DataTable InfoDiscos)
        {
            DLSoftware odlSoftware = new DLSoftware();
            System.Data.DataSet ds = new System.Data.DataSet();

            ds = odlSoftware.InformacionGeneralServidor(Srv_Id);

            if (ds.Tables.Count > 1)
            {
                InfoServidor = ds.Tables[0];
                InfoDiscos = ds.Tables[1];
            }
            else
            {
                InfoServidor = new System.Data.DataTable();
                InfoDiscos = new System.Data.DataTable();
            }
        }

        public void InformacionCompletaDiscos(int Srv_Id, ref System.Data.DataTable InfoDiscos)
        {
            DLSoftware odlSoftware = new DLSoftware();
            System.Data.DataSet ds = new System.Data.DataSet();

            ds = odlSoftware.InformacionCompletaDiscos(Srv_Id);

            if (ds.Tables.Count > 0)
                InfoDiscos = ds.Tables[0];
            else
                InfoDiscos = new System.Data.DataTable();
        }

        public void ObtenerEquipos(ref System.Web.UI.WebControls.DropDownList oddlInst, int Srv_Id, bool Exclusion)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();

            oddlInst.DataSource = DataLayerSoftware.ObtenerEquipos(Srv_Id, Exclusion);
            oddlInst.DataValueField = "Valor";
            oddlInst.DataTextField = "Descripcion";
        }

        public void InformacionGeneralInstancia(int AppSB_Id, ref System.Data.DataTable Info)
        {
            DLSoftware odlSoftware = new DLSoftware();
            System.Data.DataSet ds = new System.Data.DataSet();

            ds = odlSoftware.InformacionGeneralInstancia(AppSB_Id);

            if (ds.Tables.Count > 0)
            {
                Info = ds.Tables[0];
            }
            else
            {
                Info = new System.Data.DataTable();
            }
        }

        public void InformacionGeneralBD(int AppBD_Id, ref System.Data.DataTable Info)
        {
            DLSoftware odlSoftware = new DLSoftware();
            System.Data.DataSet ds = new System.Data.DataSet();

            ds = odlSoftware.InformacionGeneralBD(AppBD_Id);

            if (ds.Tables.Count > 0)
            {
                Info = ds.Tables[0];
            }
            else
            {
                Info = new System.Data.DataTable();
            }
        }

        public System.Data.DataTable ObtenerUltimaCinta(int TR_Id, int Obj_Id)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.ObtenerUltimaCinta(TR_Id, Obj_Id);
        }

        public string ActualizarBD(int AppBD_Id, int AppSB_Id, string AppBD_Nombre, bool AppBD_Activa, bool AppBD_Productiva, DateTime? AppBD_FechaBaja)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.ActualizarBD(AppBD_Id, AppSB_Id, AppBD_Nombre, AppBD_Activa, AppBD_Productiva, AppBD_FechaBaja);
        }

        public void InformacionGeneralApp(int App_Id, ref System.Data.DataTable Info)
        {
            DLSoftware odlSoftware = new DLSoftware();
            System.Data.DataSet ds = new System.Data.DataSet();

            ds = odlSoftware.InformacionGeneralApp(App_Id);

            if (ds.Tables.Count > 0)
            {
                Info = ds.Tables[0];
            }
            else
            {
                Info = new System.Data.DataTable();
            }
        }

        public string ActualizarApp(int App_Id, int AppSt_Id, int AppT_Id, string App_Nombre, string App_Descripcion, 
                                    bool App_EnTFS, bool App_Productiva, string App_Observaciones, string App_Ubicacion)
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.ActualizarApp(App_Id, AppSt_Id, AppT_Id, App_Nombre, App_Descripcion, 
                                             App_EnTFS, App_Productiva, App_Observaciones, App_Ubicacion);
        }

        public System.Data.DataTable InformacionRelAppSrv(int App_Id)
        {
            System.Data.DataTable Info = new System.Data.DataTable();
            DLSoftware odlSoftware = new DLSoftware();
            System.Data.DataSet ds = new System.Data.DataSet();

            ds = odlSoftware.InformacionRelAppSrv(App_Id);

            if (ds.Tables.Count > 0)
            {
                Info = ds.Tables[0];
            }
            else
            {
                Info = new System.Data.DataTable();
            }

            return Info;
        }

        public System.Data.DataTable InformacionRelAppBD(int App_Id)
        {
            System.Data.DataTable Info = new System.Data.DataTable();
            DLSoftware odlSoftware = new DLSoftware();
            System.Data.DataSet ds = new System.Data.DataSet();

            ds = odlSoftware.InformacionRelAppBD(App_Id);

            if (ds.Tables.Count > 0)
            {
                Info = ds.Tables[0];
            }
            else
            {
                Info = new System.Data.DataTable();
            }

            return Info;
        }
        #endregion Aplicaciones
        #region MaxImage
        public System.Data.DataTable BuscarDocumentoMI(string Tipo, int Numero_Prestamo = 0, int Codigo_Cliente = 0, string Numero_Jit = "", string Nombre = "")
        {
            DLSoftware odlSoftware = new DLSoftware();

            return odlSoftware.BuscarDocumentoMI(Tipo, Numero_Prestamo, Codigo_Cliente, Numero_Jit, Nombre);
        }
        #endregion MaxImage
    }
}
