using System;
using System.Collections;
using System.Collections.Generic;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLArticulo
    {
        private Articulo objectArticulo = new Articulo();
        public DLArticulo DataLayerArticulo = new DLArticulo();
        public long id_Item { get; set; }
        public static int UsuarioNoAsignado = 1186;

        public BLArticulo()
        {
        }

        public BLArticulo(Articulo oArticulo)
        {
            objectArticulo = oArticulo;
        }

        public List<Articulo> getResponsivasAnteriores(int idUsuario)
        {
            DLArticulo dlArticulo = new DLArticulo();
            return dlArticulo.getResponsivasAnteriores(idUsuario);
        }

        public string validaAlta(bool IgnorarSerie)
        {
            Articulo valArticulo = new Articulo();
            string sMensaje = string.Empty;
            sMensaje = "OK";

            valArticulo = DataLayerArticulo.getArticulobySerie(objectArticulo.noSerie);

            if (valArticulo.noSerie != string.Empty || valArticulo.noSerie != null)
            {
                if (valArticulo.idMarca == objectArticulo.idMarca && valArticulo.idTipoEquipo == objectArticulo.idTipoEquipo)
                {
                    if (IgnorarSerie)
                        sMensaje = validaRequeridosAlta();
                    else
                        sMensaje = "Validación: El número de serie que requiere dar de alta ya existe para ese tipo de artículo.";
                }
                else
                {
                    sMensaje = validaRequeridosAlta();
                }
            }
            else
            {
                sMensaje = validaRequeridosAlta();
            }

            return sMensaje;
        }

        public string ValidaActualizaArticulo()
        {
            Articulo valArticulo = new Articulo();
            string sMensaje = string.Empty;
            sMensaje = "OK";

            valArticulo = DataLayerArticulo.getArticulobyID(objectArticulo.idItem);

            if (valArticulo.noSerie != valArticulo.noSerie)
            {
                if (valArticulo.idMarca == objectArticulo.idMarca && valArticulo.idTipoEquipo == objectArticulo.idTipoEquipo)
                {
                    sMensaje = "Validación: No se puede modificar el Número de Serie.";
                }
                else
                {
                    sMensaje = validaRequeridosAlta();
                }
            }
            else
            {
                sMensaje = validaRequeridosAlta();
            }

            return sMensaje;
        }

        private string validaRequeridosAlta()
        {
            int iValidacion = 0;
            string sMensajeReq = "Los siguientes elementos son requeridos para dar de alta el artículo: ";
            string sMensajeVal = "OK";
            if (objectArticulo.noSerie == string.Empty)
            {
                sMensajeReq += "Número de Serie. ";
                iValidacion = 1;
            }
            if (objectArticulo.idTipoEquipo == 0)
            {
                sMensajeReq += "Tipo de Equipo. ";
                iValidacion = 1;
            }
            if (objectArticulo.idMarca == 0)
            {
                sMensajeReq += "Marca. ";
                iValidacion = 1;
            }
            if (objectArticulo.idUbicacion == 0)
            {
                sMensajeReq += "Ubicación. ";
                iValidacion = 1;
            }

            if (iValidacion == 0)
            {
                sMensajeReq = sMensajeVal;
            }
            return sMensajeReq;
        }

        public string insertaArticuloNuevo(bool IgnorarSerie = false)
        {
            string Resultado = string.Empty;
            string SalidaMensaje = string.Empty;
            Resultado = validaAlta(IgnorarSerie);

            if (Resultado == "OK")
            {
                try
                {
                    DataLayerArticulo.InsertArticulo(ref objectArticulo);
                    SalidaMensaje = "El artículo '" + objectArticulo.idItem.ToString() + "' con No. de Serie '" + objectArticulo.noSerie + "' fue agregado correctamente";
                    id_Item = objectArticulo.idItem;
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

        public string NuevaGeneracionResponsiva()
        {
            DLArticulo dlArticulo = new DLArticulo();

            if (dlArticulo.NuevaGeneracionResponsiva())
            {
                string NumerorResponsiva = string.Empty;
                int responsivaArticulo = Convert.ToInt32(dlArticulo.NuevaGeneracionResponsivaMax());
                int responsivaArticuloH = Convert.ToInt32(dlArticulo.NuevaGeneracionResponsivaMaxHistorico());

                if (responsivaArticulo > responsivaArticuloH)
                    NumerorResponsiva = responsivaArticulo.ToString();
                else
                    NumerorResponsiva = responsivaArticuloH.ToString();

                return NumerorResponsiva;
            }
            else
            {
                return dlArticulo.NuevaGeneracionResponsivaMaxHistorico();
            }
        }

        public string actualizaArticulo()
        {
            string Resultado = "OK";
            string SalidaMensaje = string.Empty;

            if (Resultado == "OK")
            {
                try
                {
                    DataLayerArticulo.UpdateArticulo(objectArticulo);
                    SalidaMensaje = "El artículo '" + objectArticulo.idItem.ToString() + "' con No. de Serie '" + objectArticulo.noSerie + "' fue modificado correctamente";
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

        public string actualizaAsignacion(Articulo objArticuloAct)
        {
            string Resultado = string.Empty;
            string SalidaMensaje = string.Empty;
            try
            {
                DataLayerArticulo.UpdateArticulo(objArticuloAct);
                id_Item = objArticuloAct.idItem;
                SalidaMensaje = "El artículo '" + objArticuloAct.idItem.ToString() + "' con No. de Serie '" + objArticuloAct.noSerie + "' fue modificado correctamente";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return SalidaMensaje;
        }

        public void InsertArticuloHistorico(Articulo objArticuloAc)
        {
            DataLayerArticulo.InsertArticuloHistorico(objArticuloAc);
        }

        public Articulo BuscaArticuloPorID(Int64 i_idItem)
        {
            Articulo objArticulo = new Articulo();
            objArticulo = DataLayerArticulo.getArticulobyID(i_idItem);
            return objArticulo;
        }

        public Articulo BuscarArticuloPorSerie(string s_Serie)
        {
            Articulo objArticulo = new Articulo();
            objArticulo = DataLayerArticulo.getArticulobySerie(s_Serie);
            return objArticulo;
        }

        public List<Articulo> getFiltroArticulo(int idTipoEquipo = 0, int idMarca = 0, int idUbicacion = 0, string Modelo = "", string NoSerie = "FALTANOSERIE"
            , bool SinNumeroSerie = false, bool Ilegible = false)
        {
            List<Articulo> alstArticulo = new List<Articulo>();
            alstArticulo = DataLayerArticulo.getFiltroArticulo(idTipoEquipo, idMarca, idUbicacion, Modelo, NoSerie, SinNumeroSerie, Ilegible);
            return alstArticulo;
        }

        public List<Articulo> BuscarArticuloporResponsiva(string s_Responsiva)
        {
            List<Articulo> alstArticulo = new List<Articulo>();
            alstArticulo = DataLayerArticulo.getArticulobyResponsiva(s_Responsiva);
            return alstArticulo;
        }

        public string BuscaResponsivaCorrespondiente(string s_NoSerie)
        {
            string sResponsiva = DataLayerArticulo.getResponsivaSerie(s_NoSerie);
            return sResponsiva;
        }

        public List<Articulo> BuscaArticuloFitradoA(ArrayList a_Params)
        {
            string sNoSerie = a_Params[0].ToString();
            int sResponsiva;
            int.TryParse(a_Params[1].ToString(), out sResponsiva);

            int iIDUsuario = Convert.ToInt32(a_Params[2]);
            int iIDUbicacion = Convert.ToInt32(a_Params[3]);
            int iIDTipoEquipo = Convert.ToInt32(a_Params[4]);
            List<Articulo> l_lstArticulos = new List<Articulo>();
            l_lstArticulos = DataLayerArticulo.getArticulosFilteredA(sNoSerie, sResponsiva, iIDUsuario, iIDUbicacion, iIDTipoEquipo);

            return l_lstArticulos;
        }

        public List<ArticuloHeader> BuscaArticuloFitrado(ArrayList a_Params)
        {
            string sNoSerie = a_Params[0].ToString();
            int sResponsiva;
            int.TryParse(a_Params[1].ToString(), out sResponsiva);
            int iIDUsuario = Convert.ToInt32(a_Params[2]);
            int iIDUbicacion = Convert.ToInt32(a_Params[3]);
            int iIDTipoEquipo = Convert.ToInt32(a_Params[4]);
            List<ArticuloHeader> l_lstArticulos = new List<ArticuloHeader>();
            l_lstArticulos = DataLayerArticulo.getArticulosFiltered(sNoSerie, sResponsiva, iIDUsuario, iIDUbicacion, iIDTipoEquipo);

            return l_lstArticulos;
        }

        public List<Total> BuscaTotal(ArrayList a_Params, int i_id)
        {
            string sNoSerie = a_Params[0].ToString();
            int sResponsiva;
            int.TryParse(a_Params[1].ToString(), out sResponsiva);
            int iIDUsuario = Convert.ToInt32(a_Params[2]);
            int iIDUbicacion = Convert.ToInt32(a_Params[3]);
            int iIDTipoEquipo = Convert.ToInt32(a_Params[4]);

            List<Total> l_lstTotal = new List<Total>();
            l_lstTotal = DataLayerArticulo.getTotalesFiltered(sNoSerie, sResponsiva, iIDUsuario, iIDUbicacion, iIDTipoEquipo, i_id);

            return l_lstTotal;
        }

        //public List<ArticuloHeader> ObtieneDatosGridMain(GridView grvSource)
        //{
        //    List<ArticuloHeader> lstHeader = new List<ArticuloHeader>();

        //    foreach (DataKey dk in grvSource.DataKeys)
        //    {
        //    }
        //    //foreach (GridViewRow grvs in grvSource.Rows)
        //    //{
        //    //    grvs.Cells[]

        //    //}
        //}

        public List<Articulo> getResponsivaAnterior(int responsi, int idUsuario)
        {
            DLArticulo dlArticulo = new DLArticulo();

            return dlArticulo.getResponsivaAnterior(responsi, idUsuario);
        }

        public string ReubicarEquipos(int idItem, int idUbicacion)
        {
            DLArticulo objArt = new DLArticulo();

            return objArt.ReubicarEquipos(idItem, idUbicacion);
        }

        public System.Data.DataTable BuscarArticulosUnity(string Clave)
        {
            DLArticulo objArt = new DLArticulo();

            return objArt.BuscarArticulosUnity(Clave);
        }

        public void ListaUbicacionesR(ref System.Web.UI.WebControls.DropDownList ddl, bool IncluirValorInicial = true)
        {
            DLArticulo objArt = new DLArticulo();

            ddl.DataSource = objArt.ListaUbicacionesR(IncluirValorInicial);
            ddl.DataValueField = "Valor";
            ddl.DataTextField = "Descripcion";
            ddl.DataBind();

            if (IncluirValorInicial)
                ddl.Items[0].Text = "";
        }
    }
}