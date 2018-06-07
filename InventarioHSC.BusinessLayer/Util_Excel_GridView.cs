#region Importaciones

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetGear;

#endregion Importaciones

#region Comentarios

//-- =============================================
//-- Autor:		            Julio Cesar Barron Galindo
//-- Fecha Modificacion:	21/06/2012
//-- =============================================

#endregion Comentarios

namespace InventarioHSC.BusinessLayer
{
    /// <summary>
    /// Clase que genera un Excel Por medio de los gridView que contiene una pagina
    /// </summary>
    public class Util_Excel_GridView
    {
        //Creamos el header
        private string[] headerColumns = new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R",
            "S","T","U","V","W","X","Y","Z","AA","AB","AC","AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO",
            "AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ","BA","BB","BC","BD","BE","BF","BG","BH","BI","BJ",
            "BK","BL","BM","BN","BO","BP","BQ","BR","BS","BT","BU","BV","BW","BX","BY","BZ","CA","CB","CC","CD","CE",
            "CF","CG","CH","CI","CJ","CK","CL","CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV","CW","CX","CY","CZ",
            "DA","DB","DC","DD","DE","DF","DG","DH","DI","DJ","DK","DL","DM","DN","DO","DP","DQ","DR","DS","DT","DU",
            "DV","DW","DX","DY","DZ","EA","EB","EC","ED","EE","EF","EG","EH","EI","EJ","EK","EL","EM","EN","EO","EP",
            "EQ","ER","ES","ET","EU","EV","EW","EX","EY","EZ"};

        private SpreadsheetGear.IWorkbook workbook;
        private SpreadsheetGear.IWorksheet worksheet;
        private SpreadsheetGear.IRange cells;
        private SpreadsheetGear.IRange RangeCells;
        private List<GridView> listGidViewToExcel = new List<GridView>();
        private int rowIndex = 1;
        public ConfiguracionExcel configExcel { get; set; }
        public List<GridView> ListGidViewToExcel { get; set; }
        private int counterPage = new int();
        private bool gridViewsPorHoja = new bool();
        public bool revisaFormatoCaldaXCelda { get; set; }

        public Util_Excel_GridView()
        {
            workbook = SpreadsheetGear.Factory.GetWorkbook();
            worksheet = workbook.Worksheets[counterPage];
            cells = worksheet.Cells;
        }

        public void ExportarExcel(DataSet ds, string ruta, string NombreArchivo)
        {
            int Countertables = 0;

            foreach (System.Data.DataTable itemTable in ds.Tables)
            {
                Countertables++;

                if (Countertables > 1)
                {
                    CreaHoja(itemTable.TableName.Contains("Table") ? "Hoja" + Countertables : itemTable.TableName);
                }

                //foreach (System.Data.DataRow item in itemTable.Rows)
                //{
                if (Countertables == 1)
                {
                    worksheet.Name = itemTable.TableName.Contains("Table") ? "Hoja" + Countertables : itemTable.TableName;
                }

                CreaEncabezadosExcel(itemTable);
                CreaCuerpoExcel(itemTable);
                //}
            }

            workbook.SaveAs(ruta + NombreArchivo, SpreadsheetGear.FileFormat.OpenXMLWorkbook);
        }

        public void ExportarExcel()
        {
            int counterItems = new int();
            ListGidViewToExcel = ListGidViewToExcel.FilterIDGridView(configExcel.OmitirGridView);
            List<GridView> listGridViewAtPage = new List<GridView>();
            int countItems = configExcel.HojaGridView.ToList().Count();

            configExcel.HojaGridView.ToList().ForEach(x =>
            {
                counterItems++;
                counterPage++;

                if (x.Key.Indice == 1)
                    worksheet.Name = x.Key.NombreHoja;

                if ((counterPage + (x.Key.Indice - counterPage)) == x.Key.Indice && x.Key.Indice != 1)
                    CreaHoja(x.Key.NombreHoja);

                if (x.Value != null)
                {
                    gridViewsPorHoja = true;
                    int counterGridXPage = new int();
                    listGridViewAtPage = ListGidViewToExcel.GetIDGridView(x.Value);

                    CreaTituloHojaExcel(x.Key.RangeTitle, x.Key.Titulo);

                    listGridViewAtPage.ForEach(z =>
                    {
                        counterGridXPage++;
                        CreaEncabezadosExcel(z);
                        CreaCuerpoExcel(z);
                        CreaFooterExcel(z);
                        if (listGridViewAtPage.Count > 1 && listGridViewAtPage.Count != counterGridXPage)
                            CorteHoja(x.Key.NombreHoja);
                    });
                }
                else
                {
                    CreaTituloHojaExcel(x.Key.RangeTitle, x.Key.Titulo);

                    ListGidViewToExcel.ForEach(k =>
                    {
                        if (counterPage > x.Key.Indice)
                            CreaTituloHojaExcel(x.Key.RangeTitle, x.Key.Titulo);

                        CreaEncabezadosExcel(k);
                        CreaCuerpoExcel(k);
                        if (ListGidViewToExcel.Count != counterPage)
                            CorteHoja(x.Key.NombreHoja);
                    });
                    workbook.SaveAs(configExcel.Ruta + configExcel.NombreArchivo, SpreadsheetGear.FileFormat.OpenXMLWorkbook);
                }

                if (gridViewsPorHoja && counterItems == countItems)
                    workbook.SaveAs(configExcel.Ruta + configExcel.NombreArchivo, SpreadsheetGear.FileFormat.OpenXMLWorkbook);
            });
        }

        private void CreaTituloHojaExcel(string rangTitle, string titulo)
        {
            if (titulo.Trim() != "")
            {
                worksheet.Cells[(rangTitle.Split(':')[0]).ToString() + rowIndex + ":" + (rangTitle.Split(':')[1]).ToString() + rowIndex].Merge();
                cells[(rangTitle.Split(':')[0]).ToString() + rowIndex.ToString()].Formula = titulo;
                rowIndex++;
            }
        }

        private void CorteHoja(string nombreHoja)
        {
            rowIndex++;

            if (rowIndex >= configExcel.CorteHoja)
            {
                worksheet = workbook.Worksheets.Add();
                cells = worksheet.Cells;
                worksheet.Name = nombreHoja + headerColumns[counterPage];
                rowIndex = 1;
                counterPage++;
            }
            else
                rowIndex++;
        }

        private void CreaHoja(string nombreHoja)
        {
            worksheet = workbook.Worksheets.Add();
            cells = worksheet.Cells;
            worksheet.Name = nombreHoja;
            rowIndex = 1;
            counterPage++;
        }

        private void ObtenRango(GridView gridView)
        {
            if (configExcel.ArrDatakeys != null)
            {
                RangeCells = cells["A" + rowIndex + ":" + headerColumns[gridView.Columns.Count - 1 - configExcel.LstIndOmitir.Count() + configExcel.ArrDatakeys.Length] + rowIndex];
            }
            else
            {
                RangeCells = cells["A" + rowIndex + ":" + headerColumns[gridView.Columns.Count - 1 - configExcel.LstIndOmitir.Count()] + rowIndex];
            }
        }

        private void ObtenRango(DataTable ds)
        {
            RangeCells = cells["A" + rowIndex + ":" + headerColumns[ds.Columns.Count - 1] + rowIndex];
        }

        private void CreaCuerpoExcel(GridView gridView)
        {
            foreach (GridViewRow item in gridView.Rows)
            {
                ObtenRango(gridView);
                CreaEstiloCeldas(ref RangeCells, gridView, item);
                if (revisaFormatoCaldaXCelda)
                    CreaEstiloCeldaSingle(ref RangeCells, gridView, item);

                int x = 0;
                int j = 0;
                foreach (TableCell tCell in item.Cells)
                {
                    if (!configExcel.LstIndOmitir.Contains(x))
                    {
                        if (tCell.Controls.Count > 0)
                        {
                            for (int k = 0; k < tCell.Controls.Count; k++)
                            {
                                string Tipo = tCell.Controls[k].GetType().ToString();
                                switch (Tipo)
                                {
                                    case "System.Web.UI.DataBoundLiteralControl":
                                        DataBoundLiteralControl objDBLC = (DataBoundLiteralControl)tCell.Controls[k];
                                        cells[headerColumns[x - j] + rowIndex.ToString()].Value = objDBLC.Text.removerAcentos().Replace("&nbsp;", "");
                                        break;

                                    case "System.Web.UI.WebControls.CheckBox":
                                        CheckBox objCheckBox = (CheckBox)tCell.Controls[k];
                                        string strSIoNO = string.Empty;
                                        if (objCheckBox.Checked)
                                            strSIoNO = "Si";
                                        else
                                            strSIoNO = "No";
                                        cells[headerColumns[x - j] + rowIndex.ToString()].Value = strSIoNO;
                                        break;

                                    case "System.Web.UI.WebControls.DataControlLinkButton":
                                        LinkButton objLinkButton = (LinkButton)tCell.Controls[k];
                                        cells[headerColumns[x - j] + rowIndex.ToString()].Value = objLinkButton.Text.removerAcentos().Replace("&nbsp;", "");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            cells[headerColumns[x - j] + rowIndex.ToString()].Value = item.Cells[x].Text.ConvertirAcentosHTML().Replace("&nbsp;", "").ConvertirCaracteresHTML();
                        }
                    }
                    else
                    {
                        j++;
                    }
                    x++;
                }

                if (configExcel.ArrDatakeys != null)
                {
                    foreach (string sllave in configExcel.ArrDatakeys)
                    {
                        string sKey = gridView.DataKeys[Convert.ToInt32(rowIndex) - 2].Values[sllave].ToString();
                        cells[headerColumns[x - j] + rowIndex.ToString()].Value = sKey.ConvertirAcentosHTML().Replace("&nbsp;", "");
                        x++;
                    }
                }

                rowIndex++;
            }
        }

        private void CreaCuerpoExcel(DataTable ds)
        {
            foreach (DataRow item in ds.Rows)
            {
                ObtenRango(ds);
                CreaEstiloCeldas(ref RangeCells);

                int x = 0;

                foreach (DataColumn itemColumns in ds.Columns)
                {
                    string valor = item[x].ToString().ConvertirAcentosHTML().Replace("&nbsp;", "").Trim();

                    //if (valor.StartsWith("="))
                    //{
                    //     //cells[headerColumns[x] + rowIndex.ToString()].Formula = "'" + valor;

                    //    string valorReplace = valor.Replace("=CONCATENAR(\"", "");
                    //    valorReplace = valorReplace.Replace("\")", "");
                    //    //
                    //    cells[headerColumns[x] + rowIndex.ToString()].Value = "'" + valorReplace;

                    //}
                    //else
                    //{
                    cells[headerColumns[x] + rowIndex.ToString()].Value = valor;
                    //}

                    x++;
                }

                rowIndex++;
            }
        }

        private void CreaFooterExcel(GridView gridView)
        {
            GridViewRow item = gridView.FooterRow;
            ObtenRango(gridView);
            CreaEstiloFooter(ref RangeCells, gridView, item);

            int i = 0;
            int j = 0;
            foreach (TableCell Celda in gridView.FooterRow.Cells)
            {
                if (!configExcel.LstIndOmitir.Contains(i))
                {
                    cells[headerColumns[i - j] + rowIndex.ToString()].Value = item.Cells[i - j].Text.removerAcentos().Replace("&nbsp;", "");
                }
                else
                {
                    j++;
                }
                i++;
            }
            rowIndex++;
        }

        private void CreaEncabezadosExcel(DataTable ds)
        {
            int indexHeader = new int();

            foreach (DataColumn itemColumns in ds.Columns)
            {
                cells[headerColumns[indexHeader] + rowIndex.ToString()].Formula = itemColumns.Caption;
                indexHeader++;
            }

            ObtenRango(ds);

            CreaEstiloEncabezado(ref RangeCells);
            rowIndex++;
        }

        private void CreaEncabezadosExcel(GridView gridView)
        {
            int indexHeader = new int();
            int j = 0;
            if (configExcel.ArrOmitir == null)
            {
                foreach (DataControlField itemColumns in gridView.Columns)
                {
                    cells[headerColumns[indexHeader] + rowIndex.ToString()].Formula = itemColumns.HeaderText;
                    indexHeader++;
                }
            }
            else
            {
                foreach (DataControlField itemColumns in gridView.Columns)
                {
                    if (configExcel.ArrOmitir.Contains(itemColumns.HeaderText.ToLower()))
                    {
                        configExcel.LstIndOmitir.Add(indexHeader);
                        j++;
                    }
                    else
                    {
                        cells[headerColumns[indexHeader - j] + rowIndex.ToString()].Formula = itemColumns.HeaderText;
                    }
                    indexHeader++;
                }
            }

            if (configExcel.ArrDatakeys != null)
            {
                foreach (string llave in configExcel.ArrDatakeys)
                {
                    cells[headerColumns[indexHeader - j] + rowIndex.ToString()].Formula = llave;
                    indexHeader++;
                }
            }
            ObtenRango(gridView);

            CreaEstiloEncabezado(ref RangeCells, gridView);
            rowIndex++;
        }

        private void CreaEstiloEncabezado(ref SpreadsheetGear.IRange RangeCells, GridView gridView)
        {
            RangeCells.Font.Size = 8;
            RangeCells.Font.Name = "Arial";
            RangeCells.Font.Bold = true;
            RangeCells.Font.Color = ColorHeaderFont(gridView);
            RangeCells.Interior.Color = ColorHeader(gridView);
        }

        private void CreaEstiloEncabezado(ref SpreadsheetGear.IRange RangeCells)
        {
            RangeCells.Font.Size = 8;
            RangeCells.Font.Name = "Arial";
            RangeCells.Font.Bold = true;
            RangeCells.Font.Color = System.Drawing.Color.White;
            RangeCells.Interior.Color = System.Drawing.Color.Blue;
        }

        private System.Drawing.Color ColorRowFontSingle(GridView Grid, GridViewRow Row, int index)
        {
            System.Drawing.Color cAux = System.Drawing.Color.Black;

            if (Row.Cells[index].ForeColor.Name != "0")
                cAux = Row.Cells[index].ForeColor;
            else
            {
                if (Grid.RowStyle.ForeColor.Name != "0")
                {
                    if (Row.RowIndex % 2 == 0)
                        cAux = Grid.RowStyle.ForeColor;
                    else
                        cAux = Grid.AlternatingRowStyle.ForeColor;
                }
                else
                    cAux = RegresaColorFont(Row);
            }

            return cAux;
        }

        private System.Drawing.Color ColorRowFont(GridView Grid, GridViewRow Row)
        {
            System.Drawing.Color cAux = System.Drawing.Color.Black;

            if (Row.ForeColor.Name != "0")
                cAux = Row.ForeColor;
            else
            {
                if (Grid.RowStyle.ForeColor.Name != "0")
                {
                    if (Row.RowIndex % 2 == 0)
                        cAux = Grid.RowStyle.ForeColor;
                    else
                        cAux = Grid.AlternatingRowStyle.ForeColor;
                }
                else
                    cAux = RegresaColorFont(Row);
            }

            return cAux;
        }

        private System.Drawing.Color ColorRowSingle(GridView Grid, GridViewRow Row, int index)
        {
            System.Drawing.Color cAux = System.Drawing.Color.White;

            if (Row.Cells[index].BackColor.Name != "0")
                cAux = Row.Cells[index].BackColor;
            else if (Row.BackColor.Name != "0")
                cAux = Row.BackColor;
            else
            {
                if (Grid.RowStyle.BackColor.Name != "0")
                {
                    if (Row.RowIndex % 2 == 0)
                        cAux = Grid.RowStyle.BackColor;
                    else
                        cAux = Grid.AlternatingRowStyle.BackColor;
                }
            }
            return cAux;
        }

        private System.Drawing.Color ColorFooterRowFont(GridView Grid, GridViewRow Row)
        {
            System.Drawing.Color cAux = System.Drawing.Color.Black;

            if (Grid.FooterStyle.ForeColor.Name != "0")
                cAux = Grid.FooterStyle.ForeColor;

            return cAux;
        }

        private System.Drawing.Color RegresaColor(GridViewRow Row)
        {
            //System.Drawing.Color cAux = System.Drawing.Color.White;
            System.Drawing.Color cAux = System.Drawing.Color.DarkBlue;

            if (Row.BackColor.Name != "0")
                cAux = Row.BackColor;
            else
            {
                if (Row.Style.Value != null)
                {
                    string Rgb = Row.Style.Value;
                    string[] arrRGB = Rgb.Split(';');
                    for (int j = 0; j < arrRGB.Length; j++)
                    {
                        if (arrRGB[j].Contains("background-color"))
                        {
                            string[] arrAux = arrRGB[j].Split(':');
                            Rgb = arrAux[1];
                        }
                    }
                    cAux = System.Drawing.ColorTranslator.FromHtml(Rgb);
                }
            }
            return cAux;
        }

        private System.Drawing.Color ColorRow(GridView Grid, GridViewRow Row)
        {
            System.Drawing.Color cAux = System.Drawing.Color.White;

            if (Row.BackColor.Name != "0")
                cAux = Row.BackColor;
            else
            {
                if (Grid.RowStyle.BackColor.Name != "0")
                {
                    if (Row.RowIndex % 2 == 0)
                        cAux = Grid.RowStyle.BackColor;
                    else
                        cAux = Grid.AlternatingRowStyle.BackColor;
                }
            }
            return cAux;
        }

        private System.Drawing.Color ColorFooterRow(GridView Grid, GridViewRow Row)
        {
            System.Drawing.Color cAux = System.Drawing.Color.Black;

            if (Row.BackColor.Name != "0")
                cAux = Row.BackColor;
            else
            {
                if (Grid.FooterStyle.BackColor.Name != "0")
                {
                    cAux = Grid.FooterStyle.BackColor;
                }
            }
            return cAux;
        }

        private System.Drawing.Color ColorHeaderFont(GridView Grid)
        {
            System.Drawing.Color cAux = System.Drawing.Color.Black;

            if (Grid.HeaderStyle.ForeColor.Name != "0")
                cAux = Grid.HeaderStyle.ForeColor;
            else
                cAux = RegresaColorFont(Grid.HeaderRow);

            return cAux;
        }

        private System.Drawing.Color RegresaColorFont(GridViewRow Row)
        {
            System.Drawing.Color cAux = System.Drawing.Color.Black;

            if (Row.ForeColor.Name != "0")
                cAux = Row.ForeColor;
            else
            {
                if (Row.Style.Value != null)
                {
                    string Rgb = Row.Style.Value;
                    string[] arrRGB = Rgb.Split(';');

                    for (int j = 0; j < arrRGB.Length; j++)
                    {
                        if (arrRGB[j].Contains("color"))
                        {
                            string[] arrAux = arrRGB[j].Split(':');
                            if (arrAux[0] == "color")
                            {
                                Rgb = arrAux[1];
                            }
                        }
                    }

                    cAux = System.Drawing.ColorTranslator.FromHtml(Rgb);
                }
            }
            return cAux;
        }

        private void CreaEstiloFooter(ref SpreadsheetGear.IRange RangeCells, GridView gridView, GridViewRow Row)
        {
            RangeCells.Font.Size = 8;
            RangeCells.Font.Name = "Arial";
            RangeCells.Font.Color = ColorFooterRowFont(gridView, Row);
            RangeCells.Interior.Color = ColorFooterRow(gridView, Row);
        }

        private void CreaEstiloCeldas(ref SpreadsheetGear.IRange RangeCells, GridView gridView, GridViewRow Row)
        {
            RangeCells.Font.Size = 8;
            RangeCells.Font.Name = "Arial";
            RangeCells.Font.Color = ColorRowFont(gridView, Row);
            RangeCells.Interior.Color = ColorRow(gridView, Row);
        }

        private void CreaEstiloCeldaSingle(ref SpreadsheetGear.IRange RangeCells, GridView gridView, GridViewRow Row)
        {
            int cunterColumns = 0;
            foreach (IRange celda in RangeCells.Cells)
            {
                celda.Font.Size = 8;
                celda.Font.Name = "Arial";
                celda.Font.Color = ColorRowFontSingle(gridView, Row, cunterColumns);
                celda.Interior.Color = ColorRowSingle(gridView, Row, cunterColumns);

                cunterColumns++;
            }
        }

        private void CreaEstiloCeldas(ref SpreadsheetGear.IRange RangeCells)
        {
            RangeCells.Font.Size = 8;
            RangeCells.Font.Name = "Arial";
            RangeCells.Font.Color = System.Drawing.Color.Black;
            RangeCells.Interior.Color = System.Drawing.Color.Transparent;
        }

        private System.Drawing.Color ColorHeader(GridView Grid)
        {
            System.Drawing.Color cAux = System.Drawing.Color.White;

            if (Grid.HeaderStyle.BackColor.Name != "0")
                cAux = Grid.HeaderStyle.BackColor;
            else
            {
                cAux = RegresaColor(Grid.HeaderRow);
            }
            return cAux;
        }
    }

    /// <summary>
    /// estructura que contiene las caracteristicas por cada hoja de Excel que se generé
    /// </summary>
    public class HojaExcel
    {
        public int Indice { get; set; }
        public string NombreHoja { get; set; }
        public string Titulo { get; set; }
        public string RangeTitle { get; set; }

        public HojaExcel()
        {
            this.RangeTitle = "A:B";
        }

        public HojaExcel(int indice, string nombreHoja, string titulo, string rangeTitle = "A:B")
        {
            this.Indice = indice;
            this.NombreHoja = nombreHoja;
            this.Titulo = titulo;
            this.RangeTitle = rangeTitle;
        }
    }

    /// <summary>
    /// Clase que contiene la cofiguracion del excel la cual se apoya de la structura HojaExcel
    /// y una lista en donde la lista contendra los grid que va a ir en esa Hoja si es que no se qiere que vayan todos los grid en una sola hoja de excel.
    /// </summary>
    public class ConfiguracionExcel
    {
        private Dictionary<HojaExcel, List<string>> hojaGridView = new Dictionary<HojaExcel, List<string>>();
        private List<string> omitirGridView = new List<string>();
        public string Ruta { get; set; }
        public string NombreArchivo { get; set; }
        private string[] arrDatakeys;
        private List<int> lstIndOmitir = new List<int>();
        private string[] arrOmitir;

        public List<int> LstIndOmitir
        {
            get { return lstIndOmitir; }
            set { lstIndOmitir = value; }
        }

        public string[] ArrOmitir
        {
            get { return arrOmitir; }
            set { arrOmitir = value; }
        }

        public string[] ArrDatakeys
        {
            get { return arrDatakeys; }
            set { arrDatakeys = value; }
        }

        public List<string> OmitirGridView
        {
            get { return omitirGridView; }
            set { omitirGridView = value; }
        }

        public Dictionary<HojaExcel, List<string>> HojaGridView
        {
            get { return hojaGridView; }
            set { hojaGridView = value; }
        }

        public int CorteHoja { get; set; }

        public ConfiguracionExcel()
        {
            this.CorteHoja = 60000;
        }

        public ConfiguracionExcel(Dictionary<HojaExcel, List<string>> hojaExcelGridView, List<string> gridOmitidos, string ruta, string nombreArchivo, int corteHoja = 60000, string[] Datakeys = null, string[] Omitir = null)
        {
            this.omitirGridView = gridOmitidos;
            this.hojaGridView = hojaExcelGridView;
            this.Ruta = ruta;
            this.NombreArchivo = nombreArchivo;
            this.CorteHoja = corteHoja;
            this.arrDatakeys = Datakeys;
            this.arrOmitir = Omitir;
        }
    }
}