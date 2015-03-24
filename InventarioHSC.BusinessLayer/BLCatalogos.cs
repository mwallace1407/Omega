using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLCatalogos
    {
        public BLCatalogos()
        {

        }

        public void CargaTipoEquipo(ref DropDownList oddlTipoEquipo)
        {
            DLTipoEquipo DataLayerTipoEquipo = new DLTipoEquipo();
            oddlTipoEquipo.DataSource = DataLayerTipoEquipo.getTipoEquipoAll();
            oddlTipoEquipo.DataValueField = "idTipoEquipo";
            oddlTipoEquipo.DataTextField = "Descripcion";
        }

        public void CargaMarcaporTipoEquipo(ref DropDownList oddlMarca, int idTipoEquipo)
        {
            DLMarca DataLayerMarca = new DLMarca();
            oddlMarca.DataSource = DataLayerMarca.getMarcaPorTipoEquipo(idTipoEquipo);
            oddlMarca.DataValueField = "idMarca";
            oddlMarca.DataTextField = "descripcion";
            oddlMarca.DataBind();
        }

        public void CargaTipoEquipo(ref CheckBoxList ochkTipoEquipo)
        {
            DLTipoEquipo DataLayerTipoEquipo = new DLTipoEquipo();
            ochkTipoEquipo.DataSource = DataLayerTipoEquipo.getTipoEquipoAll();
            ochkTipoEquipo.DataValueField = "idTipoEquipo";
            ochkTipoEquipo.DataTextField = "Descripcion";
        }
        public void CargaMarca(ref DropDownList oddlMarca)
        {
            DLMarca DataLayerMarca = new DLMarca();
            oddlMarca.DataSource = DataLayerMarca.getMarcaAll();
            oddlMarca.DataValueField = "idMarca";
            oddlMarca.DataTextField = "Descripcion";
        }

        public void CargaSistemaOperativo(ref DropDownList oddlSistemaOperativo)
        {
            DLSistemaOperativo DataLayerSistemaOperativo = new DLSistemaOperativo();
            oddlSistemaOperativo.DataSource = DataLayerSistemaOperativo.getSistemaOperativoAll();
            oddlSistemaOperativo.DataValueField = "idSistema";
            oddlSistemaOperativo.DataTextField = "Descripcion";
        }

        public void CargaProveedor(ref DropDownList oddlCargaProveedor)
        {
            DLProveedor DataLayerProveedor = new DLProveedor();
            oddlCargaProveedor.DataSource = DataLayerProveedor.getProveedorAll();
            oddlCargaProveedor.DataValueField = "idProveedor";
            oddlCargaProveedor.DataTextField = "Descripcion";
        }

        public void CargaUsuario(ref DropDownList oddlUsuario)
        {
            DLUsuario DataLayerUsuario = new DLUsuario();

            List<Usuario> usu = new List<Usuario>();
            usu = DataLayerUsuario.getUsuarioAll();
            usu.RemoveAll(x => x.idUsuario == 0);
            usu.RemoveAll(x => x.idUsuario == 1184);
            usu.RemoveAll(x => x.idUsuario == 1186);
            //usu.RemoveAll(x => x.idUsuario == 1191);
            oddlUsuario.DataSource = usu;
            oddlUsuario.DataValueField = "idUsuario";
            oddlUsuario.DataTextField = "Nombre";
        }

        public void CargaUsuarioBusca(ref DropDownList oddlUsuario)
        {
            DLUsuario DataLayerUsuario = new DLUsuario();
            List<Usuario> usu = new List<Usuario>();
            usu = DataLayerUsuario.getUsuarioAll();
            //usu.RemoveAll(x => x.idUsuario != 1186);

            var index = usu.FindIndex(x => x.idUsuario == 1186);
            var item = usu[index];
            usu[index] = usu[0];
            usu[0] = item;
            usu.OrderBy(x => x.nombre);
            oddlUsuario.DataSource = usu;
            oddlUsuario.DataValueField = "idUsuario";
            oddlUsuario.DataTextField = "Nombre";

        }

        public void CargaUsuarioAlta(ref DropDownList oddlUsuario)
        {
            DLUsuario DataLayerUsuario = new DLUsuario();

            List<Usuario> usu = new List<Usuario>();
            usu = DataLayerUsuario.getUsuarioAll();
            usu.RemoveAll(x => x.idUsuario != 1186);

            usu.OrderBy(x => x.nombre);
            oddlUsuario.DataSource = usu;
            oddlUsuario.DataValueField = "idUsuario";
            oddlUsuario.DataTextField = "Nombre";
        }

        public void CargaUbicacion(ref DropDownList oddlUbicacion)
        {
            DLUbicacion DataLayerUbicacion = new DLUbicacion();
            List<Ubicacion> ubicacion = DataLayerUbicacion.getUbicacionAll();
            //ubicacion.RemoveAll(x => x.descripcion == "");
            ubicacion.RemoveAll(x => x.descripcion == "FALTANTE");
            oddlUbicacion.DataSource = ubicacion;
            oddlUbicacion.DataValueField = "idUbicacion";
            oddlUbicacion.DataTextField = "Descripcion";
        }

        public void CargaUbicacionAsignacionResponsiva(ref DropDownList oddlUbicacion)
        {
            DLUbicacion DataLayerUbicacion = new DLUbicacion();
            List<Ubicacion> ubicacion = DataLayerUbicacion.getUbicacionAll();
            //ubicacion.RemoveAll(x => x.descripcion == "");
            oddlUbicacion.DataSource = ubicacion;
            oddlUbicacion.DataValueField = "idUbicacion";
            oddlUbicacion.DataTextField = "Descripcion";
        }

        public void CargaUbicacionBodegas(ref DropDownList oddlUbicacion)
        {
            //int[] Arreglo = {9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 
            //                  24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41,
            //                    42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 
            //                        62, 63, 64, 65, 66, 67, 68, 69, 74, 75, 76, 77, 78, 79};

            List<Ubicacion> lstUbi = new List<Ubicacion>();

            DLUbicacion DataLayerUbicacion = new DLUbicacion();
            lstUbi = DataLayerUbicacion.getUbicacionAll(true);

            //foreach (int id in Arreglo)
            //{
            //    lstUbi.RemoveAll(x => x.idUbicacion == id);
            //}

            oddlUbicacion.DataSource = lstUbi;
            oddlUbicacion.DataValueField = "idUbicacion";
            oddlUbicacion.DataTextField = "Descripcion";
        }

        public void CargaEstado(ref DropDownList oddlEstado)
        {
            DLEstado DataLayerEstado = new DLEstado();
            oddlEstado.DataSource = DataLayerEstado.getEstadoAll();
            oddlEstado.DataValueField = "idEstado";
            oddlEstado.DataTextField = "Descripcion";
        }

        public void CargaPuesto(ref DropDownList oddlPuesto)
        {
            DLPuesto DataLayerPuesto = new DLPuesto();
            oddlPuesto.DataSource = DataLayerPuesto.getPuestoAll();
            oddlPuesto.DataValueField = "idPuesto";
            oddlPuesto.DataTextField = "descripcion";
        }

        public void CargaRegion(ref DropDownList oddlRegion)
        {
            DLRegion DataLayerRegion = new DLRegion();
            oddlRegion.DataSource = DataLayerRegion.getRegionAll();
            oddlRegion.DataValueField = "idRegion";
            oddlRegion.DataTextField = "Nombre";
        }

        public string ObtienePuesto(int idUsuario)
        {
            Puesto oPuesto = new Puesto();
            Usuario oUsuario = new Usuario();
            DLUsuario DataLayerUsuario = new DLUsuario();
            DLPuesto DataLayerPuesto = new DLPuesto();

            oUsuario = DataLayerUsuario.getUsuarioporID(idUsuario);
            oPuesto = DataLayerPuesto.getPuestoporID(oUsuario.idPuesto);

            return oPuesto.descripcion;
        }

        public string ObtieneRegion(int idUbicacion)
        {
            Ubicacion oUbicacion = new Ubicacion();
            Region oRegion = new Region();

            DLUbicacion DataLayerUbicacion = new DLUbicacion();
            DLRegion DataLayerRegion = new DLRegion();

            oUbicacion = DataLayerUbicacion.getUbicacionporID(idUbicacion);
            oRegion = DataLayerRegion.getRegionporID(oUbicacion.idRegion);

            return oRegion.nombre;
        }

        //Software
        public void CargaEmpresasSoftware(ref DropDownList oddlESW, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlESW.DataSource = DataLayerSoftware.getEmpresasSoftwareAll(IncluirValorInicial);
            oddlESW.DataValueField = "idEmpresasSoftware";
            oddlESW.DataTextField = "descripcion";
        }

        public void CargaEmpresasSoftware(ref CheckBoxList oddlESW, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlESW.DataSource = DataLayerSoftware.getEmpresasSoftwareChk(IncluirValorInicial);
            oddlESW.DataValueField = "idEmpresasSoftware";
            oddlESW.DataTextField = "descripcion";
        }

        public void CargaGruposSoftware(ref DropDownList oddlGpo, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlGpo.DataSource = DataLayerSoftware.getGruposSoftwareAll(IncluirValorInicial);
            oddlGpo.DataValueField = "idGruposSoftware";
            oddlGpo.DataTextField = "descripcion";
        }

        public void CargaGruposSoftware(ref CheckBoxList oddlGpo, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlGpo.DataSource = DataLayerSoftware.getGruposSoftwareChk(IncluirValorInicial);
            oddlGpo.DataValueField = "idGruposSoftware";
            oddlGpo.DataTextField = "descripcion";
        }

        public void CargaCatalogoSoftware(ref DropDownList oddlSW, int SWE_Id, int SWG_Id, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlSW.DataSource = DataLayerSoftware.getCatalogoSoftware(SWE_Id, SWG_Id, IncluirValorInicial);
            oddlSW.DataValueField = "id";
            oddlSW.DataTextField = "descripcion";
        }

        public void CargaCatalogoSoftwareCombo(ref DropDownList oddlSW, int SWE_Id, int SWG_Id, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlSW.DataSource = DataLayerSoftware.getCatalogoSoftwareCombo(SWE_Id, SWG_Id, IncluirValorInicial);
            oddlSW.DataValueField = "id";
            oddlSW.DataTextField = "descripcion";
        }

        public void CargaUbicacionesSW(ref DropDownList oddlU, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerArticulo = new DLSoftware();
            oddlU.DataSource = DataLayerArticulo.getUbicacionesAll(IncluirValorInicial);
            oddlU.DataValueField = "idUbicacion";
            oddlU.DataTextField = "descripcion";
        }

        public void CargaUbicacionesSW(ref CheckBoxList oddlU, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerArticulo = new DLSoftware();
            oddlU.DataSource = DataLayerArticulo.getUbicacionesAll(IncluirValorInicial);
            oddlU.DataValueField = "idUbicacion";
            oddlU.DataTextField = "descripcion";
        }

        //Equipo
        public void CargaTiposEquipo(ref DropDownList oddlTE, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlTE.DataSource = DataLayerArticulo.getTiposEquipoAll(IncluirValorInicial);
            oddlTE.DataValueField = "idTipoEquipo";
            oddlTE.DataTextField = "descripcion";
        }

        public void CargaTiposEquipo(ref CheckBoxList oddlTE, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlTE.DataSource = DataLayerArticulo.getTiposEquipoAll(IncluirValorInicial);
            oddlTE.DataValueField = "idTipoEquipo";
            oddlTE.DataTextField = "descripcion";
        }

        public void CargaMarcas(ref DropDownList oddlM, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlM.DataSource = DataLayerArticulo.getMarcasAll(IncluirValorInicial);
            oddlM.DataValueField = "idMarca";
            oddlM.DataTextField = "descripcion";
        }

        public void CargaMarcas(ref CheckBoxList oddlM, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlM.DataSource = DataLayerArticulo.getMarcasAll(IncluirValorInicial);
            oddlM.DataValueField = "idMarca";
            oddlM.DataTextField = "descripcion";
        }

        public void CargaUbicaciones(ref DropDownList oddlU, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlU.DataSource = DataLayerArticulo.getUbicacionesAll(IncluirValorInicial);
            oddlU.DataValueField = "idUbicacion";
            oddlU.DataTextField = "descripcion";
        }

        public void CargaUbicaciones(ref CheckBoxList oddlU, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlU.DataSource = DataLayerArticulo.getUbicacionesAll(IncluirValorInicial);
            oddlU.DataValueField = "idUbicacion";
            oddlU.DataTextField = "descripcion";
        }

        public void CargaUsuarios(ref CheckBoxList oddlU, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlU.DataSource = DataLayerArticulo.getUsuariosAll(IncluirValorInicial);
            oddlU.DataValueField = "idUsuario";
            oddlU.DataTextField = "nombre";
        }

        public void CargaEstados(ref CheckBoxList oddlU, bool IncluirValorInicial = true)
        {
            DLArticulo DataLayerArticulo = new DLArticulo();
            oddlU.DataSource = DataLayerArticulo.getEstadosAll(IncluirValorInicial);
            oddlU.DataValueField = "Valor";
            oddlU.DataTextField = "Descripcion";
        }

        public void CargaUsuariosSistema(ref DropDownList oddlU, bool IncluirValorInicial = true)
        {
            DLUsuario dlUsuario = new DLUsuario();

            oddlU.DataSource = dlUsuario.CatalogoUsuariosSistema(IncluirValorInicial);
            oddlU.DataValueField = "Descripcion";
            oddlU.DataTextField = "Descripcion2";
        }

        public void CargaUsuariosSistema(ref CheckBoxList oddlU, bool IncluirValorInicial = true)
        {
            DLUsuario dlUsuario = new DLUsuario();

            oddlU.DataSource = dlUsuario.CatalogoUsuariosSistema(IncluirValorInicial);
            oddlU.DataValueField = "Descripcion";
            oddlU.DataTextField = "Descripcion2";
        }

        #region Aplicaciones
        public void CargaSOAplicaciones(ref DropDownList oddlSO, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlSO.DataSource = DataLayerSoftware.getSistemasOperativosApp(IncluirValorInicial);
            oddlSO.DataValueField = "idSistema";
            oddlSO.DataTextField = "descripcion";
        }

        public void CargaSOAplicaciones(ref CheckBoxList oddlSO, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlSO.DataSource = DataLayerSoftware.getSistemasOperativosAppChk(IncluirValorInicial);
            oddlSO.DataValueField = "idSistema";
            oddlSO.DataTextField = "descripcion";
        }

        public void CargaTiposServidor(ref CheckBoxList oddlSO, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlSO.DataSource = DataLayerSoftware.getTiposServidorAppChk(IncluirValorInicial);
            oddlSO.DataValueField = "Valor";
            oddlSO.DataTextField = "Descripcion";
        }

        public void CargaServidoresAplicaciones(ref DropDownList oddlSO, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlSO.DataSource = DataLayerSoftware.getListaServidoresApp(IncluirValorInicial);
            oddlSO.DataValueField = "id";
            oddlSO.DataTextField = "Nombre";
        }

        public void CatalogoBD(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.getCatalogoBD(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaServidoresApp(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.getServidoresApp(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaServidoresCompletaApp(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.getServidoresCompletaApp(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public System.Data.DataTable ListaServidoresCompletaApp(bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            System.Data.DataTable Resultados = new System.Data.DataTable();

            Resultados.Columns.Add("Srv_Id");
            Resultados.Columns.Add("Srv_Nombre");
            Resultados.Columns.Add("EsPropietaria");

            foreach (System.Data.DataRow dr in DataLayerSoftware.getServidoresCompletaApp(IncluirValorInicial).Rows)
            {
                System.Data.DataRow drN;

                drN = Resultados.NewRow();
                drN[0] = dr[0].ToString();
                drN[1] = dr[1].ToString();
                drN[2] = "";

                Resultados.Rows.Add(drN);
            }

            Resultados.AcceptChanges();

            return Resultados;
        }

        public void ListaServidoresCompletaApp(ref CheckBoxList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.getServidoresCompletaAppChk(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }
        
        public void ObtenerInstanciaBD(ref DropDownList oddlInst, int Srv_Id)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlInst.DataSource = DataLayerSoftware.ObtenerInstanciaBD(Srv_Id);
            oddlInst.DataValueField = "Valor";
            oddlInst.DataTextField = "Descripcion";
        }

        public void ListaInstanciasBD(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaInstanciasBD(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ObtenerBDServidor(ref DropDownList oddlBD, int Srv_Id)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ObtenerBDServidor(Srv_Id);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaBDConServidor(ref CheckBoxList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaBDConServidor(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaEstadosApp(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaEstadosApp(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaEstadosApp(ref CheckBoxList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaEstadosAppChk(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaTiposApp(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaTiposApp(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaTiposApp(ref CheckBoxList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaTiposAppChk(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaAppConServer(ref DropDownList oddlApp, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlApp.DataSource = DataLayerSoftware.ListaAppConServer(IncluirValorInicial);
            oddlApp.DataValueField = "Valor";
            oddlApp.DataTextField = "Descripcion";
        }

        public void ListaServidoresExclusionApp(ref DropDownList oddlBD, int App_Id, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaServidoresExclusionApp(App_Id, IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaBDPorServidorApp(ref DropDownList oddlBD, int Srv_Id, int App_Id, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlBD.DataSource = DataLayerSoftware.ListaBDPorServidorApp(Srv_Id, App_Id, IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaBDConServerInstancia(ref DropDownList oddl, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddl.DataSource = DataLayerSoftware.ListaBDConServerInstancia(IncluirValorInicial);
            oddl.DataValueField = "Valor";
            oddl.DataTextField = "Descripcion";
        }

        public System.Data.DataTable ListaBDConServerInstancia(bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            
            return DataLayerSoftware.ListaBDConServerInstancia(IncluirValorInicial);
        }

        public System.Data.DataTable ListaBDConServerInstanciaRel(bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();

            return DataLayerSoftware.ListaBDConServerInstanciaRel(IncluirValorInicial);
        }

        public void ListaTiposAlmacenamiento(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();

            oddlBD.DataSource = DataLayerSoftware.ListaTiposAlmacenamiento(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }

        public void ListaUsosDisco(ref DropDownList oddlBD, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();

            oddlBD.DataSource = DataLayerSoftware.ListaUsosDisco(IncluirValorInicial);
            oddlBD.DataValueField = "Valor";
            oddlBD.DataTextField = "Descripcion";
        }
        #endregion Aplicaciones
        #region MaxImage
        public void ListaTiposFiltroMaxI(ref DropDownList oddlF, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlF.DataSource = DataLayerSoftware.ListaTiposFiltroMaxI(IncluirValorInicial);
            oddlF.DataValueField = "Valor";
            oddlF.DataTextField = "Descripcion";
        }
        #endregion MaxImage
        #region SAP

        private System.Data.DataTable Catalogos(DatosGenerales.OpcionesCatalogosSAP Catalogo, int Id, bool IncluirValorInicial = true)
        {
            DLSAP sap = new DLSAP();

            return sap.Catalogos(Catalogo, Id, IncluirValorInicial);
        }

        public void CatalogoEjercicios(ref DropDownList ddl, int Id, bool IncluirValorInicial = true)
        {
            ddl.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Ejercicios, Id, IncluirValorInicial);
            ddl.DataValueField = "Valor";
            ddl.DataTextField = "Descripcion";
        }

        public void CatalogoEjerciciosCHK(ref CheckBoxList chk, int Id, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Ejercicios_CHK, Id, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoSociedades(ref CheckBoxList chk, int Id, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Sociedades, Id, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoSociedadesCHK(ref CheckBoxList chk, int Id, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Sociedades_CHK, Id, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public System.Data.DataTable CatalogoSociedadesGrid()
        {
            return Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Sociedades_Grid, 0, false);
        }

        public void CatalogoCuentasBalanza(ref CheckBoxList chk, int Id, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Cuentas_Balanza, Id, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoCuentasBalanzaCHK(ref CheckBoxList chk, int Id, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Cuentas_Balanza_CHK, Id, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoCuentasCHK(ref CheckBoxList chk, int Id, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Cuentas_CHK, Id, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoEmpleadosCHK(ref CheckBoxList chk, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_Empleados_CHK, 0, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoConceptosNominaCHK(ref CheckBoxList chk, bool IncluirValorInicial = true)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_ConceptosNomina_CHK, 0, IncluirValorInicial);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoTipoDocSAP(ref DropDownList chk)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_TipoDocSAP, 0, false);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoSubTipoDocSAP(ref DropDownList chk)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_SubTipoDocSAP, 0, false);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoPeriodoDocSAP(ref DropDownList chk)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_PeriodoDocSAP, 0, false);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }

        public void CatalogoAnioDocSAP(ref DropDownList chk)
        {
            chk.DataSource = Catalogos(DatosGenerales.OpcionesCatalogosSAP.Catalogo_AnioDocSAP, 0, false);
            chk.DataValueField = "Valor";
            chk.DataTextField = "Descripcion";
        }
        #endregion SAP
        #region Servidores
        public void ListaTiposRespaldo(ref DropDownList oddlF, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();

            oddlF.DataSource = DataLayerSoftware.ListaTiposRespaldo(IncluirValorInicial);
            oddlF.DataValueField = "Valor";
            oddlF.DataTextField = "Descripcion";
        }

        public void ListaEstadosTareas(ref DropDownList oddlF, bool IncluirValorInicial = true)
        {
            DLServidores dlServidores = new DLServidores();

            oddlF.DataSource = dlServidores.ListaEstadosTareas(IncluirValorInicial);
            oddlF.DataValueField = "Valor";
            oddlF.DataTextField = "Descripcion";
        }

        public void CategoriasTarea(ref DropDownList oddlF, string UserName)
        {
            DLServidores dlServidores = new DLServidores();

            oddlF.DataSource = dlServidores.CategoriasTarea(UserName);
            oddlF.DataValueField = "Valor";
            oddlF.DataTextField = "Descripcion";
        }

        public void ObtenerTareasDeUsuario(ref DropDownList oddlF, string UserName)
        {
            DLServidores dlServidores = new DLServidores();

            oddlF.DataSource = dlServidores.ObtenerTareasDeUsuario(UserName);
            oddlF.DataValueField = "Valor";
            oddlF.DataTextField = "Descripcion";
        }
        #endregion Servidores
        #region Abanks
        public void ObtenerMonedasAbanks(ref DropDownList oddlF, bool IncluirValorInicial = true)
        {
            DLOperaciones dlObj = new DLOperaciones();

            oddlF.DataSource = dlObj.ObtenerMonedasAbanks(IncluirValorInicial);
            oddlF.DataValueField = "Valor";
            oddlF.DataTextField = "Descripcion";
        }
        #endregion Abanks
        #region ReportesDinamicos
        public void ListaTiposScript(ref DropDownList oddlT, bool IncluirValorInicial = true)
        {
            DLRptDinamicos dlObj = new DLRptDinamicos();

            oddlT.DataSource = dlObj.ListaTiposScript(IncluirValorInicial);
            oddlT.DataValueField = "Valor";
            oddlT.DataTextField = "Descripcion";
        }

        public void ListaStoreds(ref DropDownList oddlT, string Cnx, bool IncluirValorInicial = true)
        {
            DLRptDinamicos dlObj = new DLRptDinamicos();

            oddlT.DataSource = dlObj.ListaStoreds(Cnx);
            oddlT.DataValueField = "Valor";
            oddlT.DataTextField = "Descripcion";
            oddlT.DataBind();

            if (IncluirValorInicial)
            {
                ListItem itm = new ListItem("Seleccionar procedimiento", "");

                oddlT.Items.Insert(0, itm);
            }
        }

        public void ListaCatalogos(ref DropDownList oddlT, string Cnx, int TipoCat, bool IncluirValorInicial = true)
        {
            DLRptDinamicos dlObj = new DLRptDinamicos();

            oddlT.DataSource = dlObj.ListaCatalogos(Cnx, TipoCat);
            oddlT.DataValueField = "Valor";
            oddlT.DataTextField = "Descripcion";
            oddlT.DataBind();

            if (IncluirValorInicial)
            {
                ListItem itm = new ListItem("Seleccionar catálogo", "0");

                oddlT.Items.Insert(0, itm);
            }
        }

        public void ListaReportes(ref DropDownList oddlT, int TipoScript, string Cnx, bool IncluirValorInicial = true)
        {
            DLRptDinamicos dlObj = new DLRptDinamicos();

            oddlT.DataSource = dlObj.ListaReportes(TipoScript, Cnx);
            oddlT.DataValueField = "Valor";
            oddlT.DataTextField = "Descripcion";
            oddlT.DataBind();

            if (IncluirValorInicial)
            {
                ListItem itm = new ListItem("Seleccionar reporte", "0");

                oddlT.Items.Insert(0, itm);
            }
        }
        #endregion ReportesDinamicos
    }
}
