using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

#region Comentarios

//-- =============================================
//-- Autor:		            Julio Cesar Barron Galindo
//-- Fecha Modificacion:	21/06/2012
//-- =============================================

#endregion Comentarios

namespace InventarioHSC.BusinessLayer
{
    public static class Util_MetodosExtendidos
    {
        public static List<GridView> FilterIDGridView(this List<GridView> listGridView, List<string> listGridOmitir)
        {
            List<GridView> listGridFiltrados = new List<GridView>();

            if (listGridOmitir != null)
            {
                listGridOmitir.ForEach(y =>
                {
                    listGridView.ForEach(x =>
                    {
                        if (x.ID != y)
                            if (!listGridFiltrados.Contains(x))
                                if (x.Rows.Count > 0)
                                    listGridFiltrados.Add(x);
                    });
                });
            }
            else
            {
                listGridView.ForEach(X =>
                {
                    if (X.Rows.Count > 0)
                        listGridFiltrados.Add(X);
                });

                return listGridFiltrados;
            }

            if (listGridOmitir.Count > 0)
                return listGridFiltrados;
            else
            {
                listGridView.ForEach(X =>
                {
                    if (X.Rows.Count > 0)
                        listGridFiltrados.Add(X);
                });

                return listGridFiltrados;
            }
        }

        public static string ToExcel(this GridView grid, string sRuta, string NombreArchivo, string sNombreHoja = "Hoja", string[] ArrOmitir = null, string[] arrDataKeys = null)
        {
            List<string> listGridViewXHoja = new List<string>();
            listGridViewXHoja.Add(grid.ID);

            Dictionary<HojaExcel, List<string>> hojasExcel = new Dictionary<HojaExcel, List<string>>();
            hojasExcel.Add(new HojaExcel(1, sNombreHoja, "", "A:E"), listGridViewXHoja);

            Util_Excel_GridView Excel = new Util_Excel_GridView();

            List<GridView> gridViewPagina = new List<GridView>();
            gridViewPagina.Add(grid as GridView);

            NombreArchivo = NombreArchivo + DateTime.Now.ToString("ddMMyyyyHHmmssff") + ".xlsx";
            Excel.ListGidViewToExcel = gridViewPagina;
            Excel.configExcel = new ConfiguracionExcel(hojasExcel, gridOmitidos: null, ruta: sRuta, nombreArchivo: NombreArchivo, corteHoja: 1, Datakeys: arrDataKeys, Omitir: ArrOmitir);
            Excel.ExportarExcel();
            return (sRuta + NombreArchivo);
        }

        public static List<GridView> GetIDGridView(this List<GridView> listGridView, List<string> getListGrid)
        {
            List<GridView> listGridFiltrados = new List<GridView>();

            getListGrid.ForEach(y =>
            {
                listGridView.ForEach(x =>
                {
                    if (x.ID == y)
                        if (!listGridFiltrados.Contains(x))
                            if (x.Rows.Count > 0)
                                listGridFiltrados.Add(x);
                });
            });

            return listGridFiltrados;
        }

        public static string ToExcel(this System.Data.DataSet dataset, string sRuta, string NombreArchivo)
        {
            Util_Excel_GridView Excel = new Util_Excel_GridView();
            Excel.ExportarExcel(dataset, sRuta, NombreArchivo);

            return (sRuta + NombreArchivo);
        }

        public static string removerAcentos(this String texto)
        {
            string consignos = "áàäéèëíìïóòöúùuÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
            string sinsignos = "aaaeeeiiiooouuuAAAEEEIIIOOOUUUcC";

            StringBuilder textoSinAcentos = new StringBuilder(texto.Length);
            int indexConAcento;

            texto.ToCharArray().ToList().ForEach(x =>
            {
                indexConAcento = consignos.IndexOf(x);
                if (indexConAcento > -1)
                    textoSinAcentos.Append(sinsignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos.Append(x);
            });

            foreach (char caracter in texto)
            {
            }
            return textoSinAcentos.ToString();
        }

        public static string ConvertirCaracteresHTML(this String texto)
        {
            string[] HTMLCaracter = new string[] { "&gt;" };
            string[] equivalencia = new string[] { ">" };
            string NuevaCadena = texto;

            int indexCaracter = new int();

            HTMLCaracter.ToList().ForEach(z =>
            {
                if (texto.Contains(z))
                {
                    NuevaCadena = texto.Replace(z, equivalencia[indexCaracter]);
                }

                indexCaracter++;
            });

            return NuevaCadena.ToString();
        }

        public static string ConvertirAcentosHTML(this String texto)
        {
            string[] HTMLconsignos = new string[] { "&#193;", "&#225;", "&#201;", "&#233;", "&#205;", "&#237;", "&#211;", "&#243;", "&#218;", "&#250;", "&#241;", "&#209;", "&#165;", "&#42;" };
            string[] consignos = new string[] { "Á", "á", "É", "é", "Í", "í", "Ó", "ó", "Ú", "ú", "ñ", "Ñ", "¥", "*" };
            string NuevaCadena = texto;

            int indexConAcento = new int();

            HTMLconsignos.ToList().ForEach(z =>
            {
                if (texto.Contains(z))
                {
                    NuevaCadena = texto.Replace(z, consignos[indexConAcento]);
                }

                indexConAcento++;
            });

            return NuevaCadena.ToString();
        }
    }
}