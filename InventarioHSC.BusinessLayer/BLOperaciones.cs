using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventarioHSC.Model;
using InventarioHSC.DataLayer;

namespace InventarioHSC.BusinessLayer
{
    public class BLOperaciones
    {
        #region Cartero
        public struct FolioCartero
        {
            public string FolioCastorTel;
            public string NombreCliente;
            public string Credito;
            public string TipoCarta;
            public string DireccionGarantia;
        };

        public FolioCartero LeerDatosFolio(int SolId)
        {
            FolioCartero folio;
            DLOperaciones obj = new DLOperaciones();
            DataTable Resultados = new DataTable();

            Resultados = obj.LeerDatosFolio(SolId.ToString());
            folio.FolioCastorTel = "";
            folio.NombreCliente = "";
            folio.Credito = "";
            folio.TipoCarta = "";
            folio.DireccionGarantia = "";

            if (Resultados != null && Resultados.Rows.Count == 1)
            {
                folio.FolioCastorTel = Resultados.Rows[0][0].ToString();
                folio.NombreCliente = Resultados.Rows[0][1].ToString();
                folio.Credito = Resultados.Rows[0][2].ToString();
                folio.TipoCarta = Resultados.Rows[0][3].ToString();
                folio.DireccionGarantia = Resultados.Rows[0][4].ToString();
            }

            return folio;
        }

        public string LiberarCarta(string SolId, string SolCveCC, string UserId)
        {
            DLOperaciones obj = new DLOperaciones();

            return obj.LiberarCarta(SolId, SolCveCC, UserId);
        }

        public string RegistrarCarta(string UserName, DateTime Cart_FechaDocumento, int Cart_NumeroPrestamo, string Cart_NombreAcreditado, byte[] Cart_Archivo)
        {
            DLOperaciones obj = new DLOperaciones();

            return obj.RegistrarCarta(UserName, Cart_FechaDocumento, Cart_NumeroPrestamo, Cart_NombreAcreditado, Cart_Archivo);
        }

        public string CrearPDFCartaGenerada(string Archivo, int Cart_Id)
        {
            DLOperaciones obj = new DLOperaciones();

            return obj.CrearPDFCartaGenerada(Archivo, Cart_Id);
        }

        public void ListaTiposFiltroCartasSHF(ref System.Web.UI.WebControls.DropDownList oddlF, bool IncluirValorInicial = true)
        {
            DLSoftware DataLayerSoftware = new DLSoftware();
            oddlF.DataSource = DataLayerSoftware.ListaTiposFiltroMaxI(IncluirValorInicial);
            oddlF.DataValueField = "Valor";
            oddlF.DataTextField = "Descripcion";
            oddlF.DataBind();
        }

        public System.Data.DataTable BuscarCartaSHF(string Tipo, int Numero_Prestamo = 0, int Codigo_Cliente = 0, string Numero_Jit = "", string Nombre = "")
        {
            DLOperaciones odlSoftware = new DLOperaciones();

            return odlSoftware.BuscarCartaSHF(Tipo, Numero_Prestamo, Codigo_Cliente, Numero_Jit, Nombre);
        }
        #endregion Cartero
        #region AAE
        public DataTable BuscarDocumentosAAE(string CadenaBusqueda)
        {
            DLOperaciones obj = new DLOperaciones();

            return obj.BuscarDocumentosAAE(CadenaBusqueda);
        }
        #endregion AAE
        #region SAB
        public DataTable BuscarDocumentosSAB(string CadenaBusqueda)
        {
            DLOperaciones obj = new DLOperaciones();

            return obj.BuscarDocumentosSAB(CadenaBusqueda);
        }
        #endregion SAB
        #region AAE
        public DataTable BuscarDocumentosIntranet(string CadenaBusqueda)
        {
            DLOperaciones obj = new DLOperaciones();

            return obj.BuscarDocumentosIntranet(CadenaBusqueda);
        }
        #endregion AAE
    }
}
