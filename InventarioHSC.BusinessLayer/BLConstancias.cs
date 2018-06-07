using System;
using System.Data;
using System.Web.UI.WebControls;
using InventarioHSC.DataLayer;
using InventarioHSC.Model;

namespace InventarioHSC.BusinessLayer
{
    public class BLConstancias
    {
        private DLConstancias dlObj = new DLConstancias();

        #region Catalogos

        public void ObtenerCatalogos(ref DropDownList oddl, int Cat_Id, int Valor01 = 0, bool IncluirValorInicial = true, string Descripcion = "")
        {
            oddl.DataSource = dlObj.ObtenerCatalogos(Cat_Id, Valor01);
            oddl.DataValueField = "Valor";
            oddl.DataTextField = "Descripcion";
            oddl.DataBind();

            if (IncluirValorInicial)
            {
                ListItem itm = new ListItem(Descripcion, "");

                oddl.Items.Insert(0, itm);
            }
        }

        public void ObtenerCatalogos(ref CheckBoxList ochkl, int Cat_Id, int Valor01 = 0, bool IncluirValorInicial = true, string Descripcion = "")
        {
            ochkl.DataSource = dlObj.ObtenerCatalogos(Cat_Id, Valor01);
            ochkl.DataValueField = "Valor";
            ochkl.DataTextField = "Descripcion";
            ochkl.DataBind();

            if (IncluirValorInicial)
            {
                ListItem itm = new ListItem(Descripcion, "");

                ochkl.Items.Insert(0, itm);
            }
        }

        #endregion Catalogos

        #region Metodos

        public string VerificarExistencia(int ConA_Id, int ConP_Id, DateTime Fecha)
        {
            return dlObj.VerificarExistencia(ConA_Id, ConP_Id, (Int16)Fecha.Year);
        }

        public string InsertarLote(int ConA_Id, int ConP_Id, DateTime ConL_Fecha, string ConL_NombreArchivo, string ConL_Identificador)
        {
            return dlObj.InsertarLote(ConA_Id, ConP_Id, ConL_Fecha, (Int16)ConL_Fecha.Year, ConL_NombreArchivo, ConL_Identificador);
        }

        public string InsertarDetalle(int ConL_Id, string Linea)
        {
            string[] DatosDetalle = Linea.Split(new char[] { '|' }, StringSplitOptions.None);
            string Col01 = DatosDetalle[0];
            string Col02 = DatosDetalle[1];
            string Col03 = DatosDetalle[2];
            string Col04 = DatosDetalle[3];
            string Col05 = DatosDetalle[4];
            string Col06 = DatosDetalle[5];
            string Col07 = DatosDetalle[6];
            string Col08 = DatosDetalle[7];
            string Col09 = DatosDetalle[8];
            string Col10 = DatosDetalle[9];
            string Col11 = DatosDetalle[10];
            string Col12 = DatosDetalle[11];
            string Col13 = DatosDetalle[12];
            string Col14 = DatosDetalle[13];
            string Col15 = DatosDetalle[14];
            string Col16 = DatosDetalle[15];
            string Col17 = DatosDetalle[16];
            string Col18 = DatosDetalle[17];
            string Col19 = DatosDetalle[18];
            string Col20 = DatosDetalle[19];
            string Col21 = DatosDetalle[20];
            string Col22 = DatosDetalle[21];

            return dlObj.InsertarDetalle(ConL_Id,
                Col01, Col02, Col03, Col04, Col05,
                Col06, Col07, Col08, Col09, Col10,
                Col11, Col12, Col13, Col14, Col15,
                Col16, Col17, Col18, Col19, Col20,
                Col21, Col22);
        }

        public DataTable BuscarLotes(string Descripcion, string FechaCargaIni, string FechaCargaFin, string FechaLoteIni, string FechaLoteFin, string Administradoras, string Portafolios)
        {
            DateTime? FCI;
            DateTime? FCF;
            DateTime? FLI;
            DateTime? FLF;

            if (string.IsNullOrWhiteSpace(Descripcion))
                Descripcion = null;

            if (string.IsNullOrWhiteSpace(Administradoras))
                Administradoras = null;

            if (string.IsNullOrWhiteSpace(Portafolios))
                Portafolios = null;

            if (DatosGenerales.EsFecha(FechaCargaIni))
                FCI = DatosGenerales.ObtieneFecha(FechaCargaIni);
            else
                FCI = null;

            if (DatosGenerales.EsFecha(FechaCargaFin))
                FCF = DatosGenerales.ObtieneFecha(FechaCargaFin);
            else
                FCF = null;

            if (DatosGenerales.EsFecha(FechaLoteIni))
                FLI = DatosGenerales.ObtieneFecha(FechaLoteIni);
            else
                FLI = null;

            if (DatosGenerales.EsFecha(FechaLoteFin))
                FLF = DatosGenerales.ObtieneFecha(FechaLoteFin);
            else
                FLF = null;

            return dlObj.BuscarLotes(Descripcion, FCI, FCF, FLI, FLF, Administradoras, Portafolios);
        }

        public DataTable GenerarTXTSAT(string Lotes)
        {
            return dlObj.GenerarTXTSAT(Lotes);
        }

        public DataTable GenerarTXTBuzonE(int Ejercicio, string Lotes)
        {
            return dlObj.GenerarTXTBuzonE(Ejercicio.ToString(), Lotes);
        }

        #endregion Metodos
    }
}