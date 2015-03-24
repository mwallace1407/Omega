using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;
using A = DocumentFormat.OpenXml.Drawing;
using Xdr = DocumentFormat.OpenXml.Drawing.Spreadsheet;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;
using InventarioHSC.DataLayer;

namespace InventarioHSC.Model
{
    
    public class BLXLSResponsiva
    {
        private List<Responsiva> oResponsiva = new List<Responsiva>();
        private DLResponsiva dlResponsiva = new DLResponsiva();
        // Creates a SpreadsheetDocument.
        public void CreatePackage(string filePath)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                CreateParts(package);
            }
        }

        public void CreatePackage(string filePath, string s_responsiva)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                oResponsiva = dlResponsiva.GetDatosResponsiva(s_responsiva);
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part.
        private void CreateParts(SpreadsheetDocument document)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            WorkbookPart workbookPart1 = document.AddWorkbookPart();
            GenerateWorkbookPart1Content(workbookPart1);

            WorksheetPart worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>("rId3");
            GenerateWorksheetPart1Content(worksheetPart1);

            WorksheetPart worksheetPart2 = workbookPart1.AddNewPart<WorksheetPart>("rId2");
            GenerateWorksheetPart2Content(worksheetPart2);

            WorksheetPart worksheetPart3 = workbookPart1.AddNewPart<WorksheetPart>("rId1");
            GenerateWorksheetPart3Content(worksheetPart3);

            DrawingsPart drawingsPart1 = worksheetPart3.AddNewPart<DrawingsPart>("rId2");
            GenerateDrawingsPart1Content(drawingsPart1);

            ImagePart imagePart1 = drawingsPart1.AddNewPart<ImagePart>("image/png", "rId1");
            GenerateImagePart1Content(imagePart1);

            SpreadsheetPrinterSettingsPart spreadsheetPrinterSettingsPart1 = worksheetPart3.AddNewPart<SpreadsheetPrinterSettingsPart>("rId1");
            GenerateSpreadsheetPrinterSettingsPart1Content(spreadsheetPrinterSettingsPart1);

            SharedStringTablePart sharedStringTablePart1 = workbookPart1.AddNewPart<SharedStringTablePart>("rId6");
            GenerateSharedStringTablePart1Content(sharedStringTablePart1);

            WorkbookStylesPart workbookStylesPart1 = workbookPart1.AddNewPart<WorkbookStylesPart>("rId5");
            GenerateWorkbookStylesPart1Content(workbookStylesPart1);

            ThemePart themePart1 = workbookPart1.AddNewPart<ThemePart>("rId4");
            GenerateThemePart1Content(themePart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Excel";
            Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
            documentSecurity1.Text = "0";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "Hojas de cálculo";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "3";

            variant2.Append(vTInt321);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)3U };
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "Hoja1";
            Vt.VTLPSTR vTLPSTR3 = new Vt.VTLPSTR();
            vTLPSTR3.Text = "Hoja2";
            Vt.VTLPSTR vTLPSTR4 = new Vt.VTLPSTR();
            vTLPSTR4.Text = "Hoja3";

            vTVector2.Append(vTLPSTR2);
            vTVector2.Append(vTLPSTR3);
            vTVector2.Append(vTLPSTR4);

            titlesOfParts1.Append(vTVector2);
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "14.0300";

            properties1.Append(application1);
            properties1.Append(documentSecurity1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(linksUpToDate1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of workbookPart1.
        private void GenerateWorkbookPart1Content(WorkbookPart workbookPart1)
        {
            Workbook workbook1 = new Workbook();
            workbook1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            FileVersion fileVersion1 = new FileVersion() { ApplicationName = "xl", LastEdited = "5", LowestEdited = "5", BuildVersion = "9302" };
            WorkbookProperties workbookProperties1 = new WorkbookProperties() { DefaultThemeVersion = (UInt32Value)124226U };

            BookViews bookViews1 = new BookViews();
            WorkbookView workbookView1 = new WorkbookView() { XWindow = 360, YWindow = 45, WindowWidth = (UInt32Value)15315U, WindowHeight = (UInt32Value)8505U };

            bookViews1.Append(workbookView1);

            Sheets sheets1 = new Sheets();
            Sheet sheet1 = new Sheet() { Name = "Hoja1", SheetId = (UInt32Value)1U, Id = "rId1" };
            Sheet sheet2 = new Sheet() { Name = "Hoja2", SheetId = (UInt32Value)2U, Id = "rId2" };
            Sheet sheet3 = new Sheet() { Name = "Hoja3", SheetId = (UInt32Value)3U, Id = "rId3" };

            sheets1.Append(sheet1);
            sheets1.Append(sheet2);
            sheets1.Append(sheet3);
            CalculationProperties calculationProperties1 = new CalculationProperties() { CalculationId = (UInt32Value)145621U };

            workbook1.Append(fileVersion1);
            workbook1.Append(workbookProperties1);
            workbook1.Append(bookViews1);
            workbook1.Append(sheets1);
            workbook1.Append(calculationProperties1);

            workbookPart1.Workbook = workbook1;
        }

        // Generates content of worksheetPart1.
        private void GenerateWorksheetPart1Content(WorksheetPart worksheetPart1)
        {
            Worksheet worksheet1 = new Worksheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            worksheet1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            SheetDimension sheetDimension1 = new SheetDimension() { Reference = "A1" };

            SheetViews sheetViews1 = new SheetViews();
            SheetView sheetView1 = new SheetView() { WorkbookViewId = (UInt32Value)0U };

            sheetViews1.Append(sheetView1);
            SheetFormatProperties sheetFormatProperties1 = new SheetFormatProperties() { BaseColumnWidth = (UInt32Value)10U, DefaultRowHeight = 15D, DyDescent = 0.25D };
            SheetData sheetData1 = new SheetData();
            PageMargins pageMargins1 = new PageMargins() { Left = 0.7D, Right = 0.7D, Top = 0.75D, Bottom = 0.75D, Header = 0.3D, Footer = 0.3D };

            worksheet1.Append(sheetDimension1);
            worksheet1.Append(sheetViews1);
            worksheet1.Append(sheetFormatProperties1);
            worksheet1.Append(sheetData1);
            worksheet1.Append(pageMargins1);

            worksheetPart1.Worksheet = worksheet1;
        }

        // Generates content of worksheetPart2.
        private void GenerateWorksheetPart2Content(WorksheetPart worksheetPart2)
        {
            Worksheet worksheet2 = new Worksheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            worksheet2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheet2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheet2.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            SheetDimension sheetDimension2 = new SheetDimension() { Reference = "A1" };

            SheetViews sheetViews2 = new SheetViews();
            SheetView sheetView2 = new SheetView() { WorkbookViewId = (UInt32Value)0U };

            sheetViews2.Append(sheetView2);
            SheetFormatProperties sheetFormatProperties2 = new SheetFormatProperties() { BaseColumnWidth = (UInt32Value)10U, DefaultRowHeight = 15D, DyDescent = 0.25D };
            SheetData sheetData2 = new SheetData();
            PageMargins pageMargins2 = new PageMargins() { Left = 0.7D, Right = 0.7D, Top = 0.75D, Bottom = 0.75D, Header = 0.3D, Footer = 0.3D };

            worksheet2.Append(sheetDimension2);
            worksheet2.Append(sheetViews2);
            worksheet2.Append(sheetFormatProperties2);
            worksheet2.Append(sheetData2);
            worksheet2.Append(pageMargins2);

            worksheetPart2.Worksheet = worksheet2;
        }

        // Generates content of worksheetPart3.
        private void GenerateWorksheetPart3Content(WorksheetPart worksheetPart3)
        {
            Dictionary<string, string> Margecells = new Dictionary<string, string>();

            Worksheet worksheet3 = new Worksheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            worksheet3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheet3.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheet3.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            SheetDimension sheetDimension3 = new SheetDimension() { Reference = "A2:H46" };

            SheetViews sheetViews3 = new SheetViews();

            SheetView sheetView3 = new SheetView() { ShowGridLines = false, TabSelected = true, ZoomScaleNormal = (UInt32Value)100U, WorkbookViewId = (UInt32Value)0U };
            Selection selection1 = new Selection() { ActiveCell = "E19", SequenceOfReferences = new ListValue<StringValue>() { InnerText = "E19" } };

            sheetView3.Append(selection1);

            sheetViews3.Append(sheetView3);
            SheetFormatProperties sheetFormatProperties3 = new SheetFormatProperties() { BaseColumnWidth = (UInt32Value)10U, DefaultRowHeight = 15D, DyDescent = 0.25D };

            Columns columns1 = new Columns();
            Column column1 = new Column() { Min = (UInt32Value)1U, Max = (UInt32Value)1U, Width = 6.5703125D, CustomWidth = true };
            Column column2 = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = 15D, CustomWidth = true };
            Column column3 = new Column() { Min = (UInt32Value)5U, Max = (UInt32Value)5U, Width = 14.5703125D, CustomWidth = true };
            Column column4 = new Column() { Min = (UInt32Value)6U, Max = (UInt32Value)6U, Width = 11D, CustomWidth = true };
            Column column5 = new Column() { Min = (UInt32Value)7U, Max = (UInt32Value)7U, Width = 12.140625D, CustomWidth = true };

            columns1.Append(column1);
            columns1.Append(column2);
            columns1.Append(column3);
            columns1.Append(column4);
            columns1.Append(column5);

            SheetData sheetData3 = new SheetData();

            Row row1 = new Row() { RowIndex = (UInt32Value)2U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 18D, DyDescent = 0.25D };

            Cell cell1 = new Cell() { CellReference = "C2", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue1 = new CellValue();
            cellValue1.Text = "0";

            cell1.Append(cellValue1);
            Cell cell2 = new Cell() { CellReference = "D2", StyleIndex = (UInt32Value)5U };
            Cell cell3 = new Cell() { CellReference = "E2", StyleIndex = (UInt32Value)5U };
            Cell cell4 = new Cell() { CellReference = "F2", StyleIndex = (UInt32Value)5U };
            Cell cell5 = new Cell() { CellReference = "G2", StyleIndex = (UInt32Value)5U };
            Cell cell6 = new Cell() { CellReference = "H2", StyleIndex = (UInt32Value)5U };

            row1.Append(cell1);
            row1.Append(cell2);
            row1.Append(cell3);
            row1.Append(cell4);
            row1.Append(cell5);
            row1.Append(cell6);
            sheetData3.Append(row1);

            Row row2 = new Row() { RowIndex = (UInt32Value)3U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };

            Cell cell7 = new Cell() { CellReference = "C3", StyleIndex = (UInt32Value)6U, DataType = CellValues.SharedString };
            CellValue cellValue2 = new CellValue();
            cellValue2.Text = "1";

            cell7.Append(cellValue2);
            Cell cell8 = new Cell() { CellReference = "D3", StyleIndex = (UInt32Value)6U };
            Cell cell9 = new Cell() { CellReference = "E3", StyleIndex = (UInt32Value)6U };
            Cell cell10 = new Cell() { CellReference = "F3", StyleIndex = (UInt32Value)6U };
            Cell cell11 = new Cell() { CellReference = "G3", StyleIndex = (UInt32Value)6U };
            Cell cell12 = new Cell() { CellReference = "H3", StyleIndex = (UInt32Value)6U };

            row2.Append(cell7);
            row2.Append(cell8);
            row2.Append(cell9);
            row2.Append(cell10);
            row2.Append(cell11);
            row2.Append(cell12);
            sheetData3.Append(row2);

            Row row3 = new Row() { RowIndex = (UInt32Value)4U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };

            Cell cell13 = new Cell() { CellReference = "C4", StyleIndex = (UInt32Value)6U, DataType = CellValues.SharedString };
            CellValue cellValue3 = new CellValue();
            cellValue3.Text = "2";

            cell13.Append(cellValue3);
            Cell cell14 = new Cell() { CellReference = "D4", StyleIndex = (UInt32Value)6U };
            Cell cell15 = new Cell() { CellReference = "E4", StyleIndex = (UInt32Value)6U };
            Cell cell16 = new Cell() { CellReference = "F4", StyleIndex = (UInt32Value)6U };
            Cell cell17 = new Cell() { CellReference = "G4", StyleIndex = (UInt32Value)6U };
            Cell cell18 = new Cell() { CellReference = "H4", StyleIndex = (UInt32Value)6U };

            row3.Append(cell13);
            row3.Append(cell14);
            row3.Append(cell15);
            row3.Append(cell16);
            row3.Append(cell17);
            row3.Append(cell18);
            sheetData3.Append(row3);

            Margecells.Add("Titulo1", "C2:H2");
            Margecells.Add("Titulo2", "C3:H3");
            Margecells.Add("Titulo3", "C4:H4");

            Row row4 = new Row() { RowIndex = (UInt32Value)6U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell19 = new Cell() { CellReference = "A6", StyleIndex = (UInt32Value)1U };
            Cell cell20 = new Cell() { CellReference = "B6", StyleIndex = (UInt32Value)1U };
            Cell cell21 = new Cell() { CellReference = "C6", StyleIndex = (UInt32Value)1U };
            Cell cell22 = new Cell() { CellReference = "D6", StyleIndex = (UInt32Value)1U };
            Cell cell23 = new Cell() { CellReference = "E6", StyleIndex = (UInt32Value)1U };

            Cell cell24 = new Cell() { CellReference = "G6", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue4 = new CellValue();
            cellValue4.Text = "3";

            cell24.Append(cellValue4);

            Cell cell25 = new Cell() { CellReference = "H6", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue5 = new CellValue();
            cellValue5.Text = "19";
            //Cell cell25 = new Cell() { CellReference = "H6", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            //CellValue cellValue5 = new CellValue();
            //cellValue5.Text = "19";

            cell25.Append(cellValue5);

            row4.Append(cell19);
            row4.Append(cell20);
            row4.Append(cell21);
            row4.Append(cell22);
            row4.Append(cell23);
            row4.Append(cell24);
            row4.Append(cell25);
            sheetData3.Append(row4);

            Row row5 = new Row() { RowIndex = (UInt32Value)7U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell26 = new Cell() { CellReference = "A7", StyleIndex = (UInt32Value)1U };
            Cell cell27 = new Cell() { CellReference = "B7", StyleIndex = (UInt32Value)1U };
            Cell cell28 = new Cell() { CellReference = "C7", StyleIndex = (UInt32Value)1U };
            Cell cell29 = new Cell() { CellReference = "D7", StyleIndex = (UInt32Value)1U };
            Cell cell30 = new Cell() { CellReference = "E7", StyleIndex = (UInt32Value)1U };
            Cell cell31 = new Cell() { CellReference = "F7", StyleIndex = (UInt32Value)1U };
            //Cell cell32 = new Cell() { CellReference = "G7", StyleIndex = (UInt32Value)1U };
            //Cell cell33 = new Cell() { CellReference = "H7", StyleIndex = (UInt32Value)1U };

            Cell cell32 = new Cell() { CellReference = "G7", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cell32a = new CellValue();
            cell32a.Text = "Fecha:";
            cell32.Append(cell32a);

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
            Cell cell33 = new Cell() { CellReference = "H7", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cell33a = new CellValue();
            cell33a.Text = DateTime.Now.ToString("dd/MMM/yyyy", ci);
            cell33.Append(cell33a);

            row5.Append(cell26);
            row5.Append(cell27);
            row5.Append(cell28);
            row5.Append(cell29);
            row5.Append(cell30);
            row5.Append(cell31);
            row5.Append(cell32);
            row5.Append(cell33);
            sheetData3.Append(row5);

            Row row6 = new Row() { RowIndex = (UInt32Value)8U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell34 = new Cell() { CellReference = "A8", StyleIndex = (UInt32Value)1U };

            Cell cell35 = new Cell() { CellReference = "B8", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue6 = new CellValue();
            cellValue6.Text = "4";

            cell35.Append(cellValue6);

            Cell cell36 = new Cell() { CellReference = "C8", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue7 = new CellValue();
            cellValue7.Text = "18";

            //Cell cell36 = new Cell() { CellReference = "C8", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            //CellValue cellValue7 = new CellValue();
            //cellValue7.Text = "18";

            cell36.Append(cellValue7);
            Cell cell37 = new Cell() { CellReference = "D8", StyleIndex = (UInt32Value)1U };
            Cell cell38 = new Cell() { CellReference = "E8", StyleIndex = (UInt32Value)1U };
            Cell cell39 = new Cell() { CellReference = "F8", StyleIndex = (UInt32Value)1U };
            Cell cell40 = new Cell() { CellReference = "G8", StyleIndex = (UInt32Value)1U };
            Cell cell41 = new Cell() { CellReference = "H8", StyleIndex = (UInt32Value)1U };

            row6.Append(cell34);
            row6.Append(cell35);
            row6.Append(cell36);
            row6.Append(cell37);
            row6.Append(cell38);
            row6.Append(cell39);
            row6.Append(cell40);
            row6.Append(cell41);
            sheetData3.Append(row6);

            Row row7 = new Row() { RowIndex = (UInt32Value)9U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell42 = new Cell() { CellReference = "A9", StyleIndex = (UInt32Value)1U };

            Cell cell43 = new Cell() { CellReference = "B9", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue8 = new CellValue();
            cellValue8.Text = "22";

            cell43.Append(cellValue8);

            Cell cell44 = new Cell() { CellReference = "C9", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue9 = new CellValue();
            cellValue9.Text = "21";

            cell44.Append(cellValue9);
            Cell cell45 = new Cell() { CellReference = "D9", StyleIndex = (UInt32Value)1U };
            Cell cell46 = new Cell() { CellReference = "E9", StyleIndex = (UInt32Value)1U };
            Cell cell47 = new Cell() { CellReference = "F9", StyleIndex = (UInt32Value)1U };
            Cell cell48 = new Cell() { CellReference = "G9", StyleIndex = (UInt32Value)1U };
            Cell cell49 = new Cell() { CellReference = "H9", StyleIndex = (UInt32Value)1U };

            row7.Append(cell42);
            row7.Append(cell43);
            row7.Append(cell44);
            row7.Append(cell45);
            row7.Append(cell46);
            row7.Append(cell47);
            row7.Append(cell48);
            row7.Append(cell49);
            sheetData3.Append(row7);

            Row row8 = new Row() { RowIndex = (UInt32Value)10U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell50 = new Cell() { CellReference = "A10", StyleIndex = (UInt32Value)1U };
            Cell cell51 = new Cell() { CellReference = "B10", StyleIndex = (UInt32Value)1U };
            Cell cell52 = new Cell() { CellReference = "C10", StyleIndex = (UInt32Value)1U };
            Cell cell53 = new Cell() { CellReference = "D10", StyleIndex = (UInt32Value)1U };
            Cell cell54 = new Cell() { CellReference = "E10", StyleIndex = (UInt32Value)1U };
            Cell cell55 = new Cell() { CellReference = "F10", StyleIndex = (UInt32Value)1U };
            Cell cell56 = new Cell() { CellReference = "G10", StyleIndex = (UInt32Value)1U };
            Cell cell57 = new Cell() { CellReference = "H10", StyleIndex = (UInt32Value)1U };
            
            row8.Append(cell50);
            row8.Append(cell51);
            row8.Append(cell52);
            row8.Append(cell53);
            row8.Append(cell54);
            row8.Append(cell55);
            row8.Append(cell56);
            row8.Append(cell57);
            sheetData3.Append(row8);

            Row row9 = new Row() { RowIndex = (UInt32Value)11U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell58 = new Cell() { CellReference = "A11", StyleIndex = (UInt32Value)1U };

            Cell cell59 = new Cell() { CellReference = "B11", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue10 = new CellValue();
            cellValue10.Text = "5";

            cell59.Append(cellValue10);

            Cell cell60 = new Cell() { CellReference = "C11", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue11 = new CellValue();
            cellValue11.Text = "20";

            cell60.Append(cellValue11);
            Cell cell61 = new Cell() { CellReference = "D11", StyleIndex = (UInt32Value)1U };
            Cell cell62 = new Cell() { CellReference = "E11", StyleIndex = (UInt32Value)1U };
            Cell cell63 = new Cell() { CellReference = "F11", StyleIndex = (UInt32Value)1U };
            Cell cell64 = new Cell() { CellReference = "G11", StyleIndex = (UInt32Value)1U };
            Cell cell65 = new Cell() { CellReference = "H11", StyleIndex = (UInt32Value)1U };

            row9.Append(cell58);
            row9.Append(cell59);
            row9.Append(cell60);
            row9.Append(cell61);
            row9.Append(cell62);
            row9.Append(cell63);
            row9.Append(cell64);
            row9.Append(cell65);
            sheetData3.Append(row9);

            Row row10 = new Row() { RowIndex = (UInt32Value)12U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell66 = new Cell() { CellReference = "A12", StyleIndex = (UInt32Value)1U };
            Cell cell67 = new Cell() { CellReference = "B12", StyleIndex = (UInt32Value)1U };
            Cell cell68 = new Cell() { CellReference = "C12", StyleIndex = (UInt32Value)1U };
            Cell cell69 = new Cell() { CellReference = "D12", StyleIndex = (UInt32Value)1U };
            Cell cell70 = new Cell() { CellReference = "E12", StyleIndex = (UInt32Value)1U };
            Cell cell71 = new Cell() { CellReference = "F12", StyleIndex = (UInt32Value)1U };
            Cell cell72 = new Cell() { CellReference = "G12", StyleIndex = (UInt32Value)1U };
            Cell cell73 = new Cell() { CellReference = "H12", StyleIndex = (UInt32Value)1U };

            row10.Append(cell66);
            row10.Append(cell67);
            row10.Append(cell68);
            row10.Append(cell69);
            row10.Append(cell70);
            row10.Append(cell71);
            row10.Append(cell72);
            row10.Append(cell73);
            sheetData3.Append(row10);

            Margecells.Add("Parametro2", "B13:H13");

            Row row11 = new Row() { RowIndex = (UInt32Value)13U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 23.25D, CustomHeight = true, DyDescent = 0.25D };
            Cell cell74 = new Cell() { CellReference = "A13", StyleIndex = (UInt32Value)1U };

            Cell cell75 = new Cell() { CellReference = "B13", StyleIndex = (UInt32Value)28U, DataType = CellValues.SharedString };
            CellValue cellValue12 = new CellValue();
            cellValue12.Text = "23";

            cell75.Append(cellValue12);
            Cell cell76 = new Cell() { CellReference = "C13", StyleIndex = (UInt32Value)28U };
            Cell cell77 = new Cell() { CellReference = "D13", StyleIndex = (UInt32Value)28U };
            Cell cell78 = new Cell() { CellReference = "E13", StyleIndex = (UInt32Value)28U };
            Cell cell79 = new Cell() { CellReference = "F13", StyleIndex = (UInt32Value)28U };
            Cell cell80 = new Cell() { CellReference = "G13", StyleIndex = (UInt32Value)28U };
            Cell cell81 = new Cell() { CellReference = "H13", StyleIndex = (UInt32Value)28U };

            row11.Append(cell74);
            row11.Append(cell75);
            row11.Append(cell76);
            row11.Append(cell77);
            row11.Append(cell78);
            row11.Append(cell79);
            row11.Append(cell80);
            row11.Append(cell81);
            sheetData3.Append(row11);

            Row row12 = new Row() { RowIndex = (UInt32Value)14U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 15.75D, ThickBot = true, DyDescent = 0.3D };
            Cell cell82 = new Cell() { CellReference = "A14", StyleIndex = (UInt32Value)1U };
            Cell cell83 = new Cell() { CellReference = "B14", StyleIndex = (UInt32Value)1U };
            Cell cell84 = new Cell() { CellReference = "G14", StyleIndex = (UInt32Value)1U };
            Cell cell85 = new Cell() { CellReference = "H14", StyleIndex = (UInt32Value)1U };

            row12.Append(cell82);
            row12.Append(cell83);
            row12.Append(cell84);
            row12.Append(cell85);
            sheetData3.Append(row12);

            Row row13 = new Row() { RowIndex = (UInt32Value)15U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 15.75D, ThickBot = true, DyDescent = 0.3D };
            Cell cell86 = new Cell() { CellReference = "A15", StyleIndex = (UInt32Value)4U };

            Cell cell87 = new Cell() { CellReference = "B15", StyleIndex = (UInt32Value)3U, DataType = CellValues.SharedString };
            CellValue cellValue13 = new CellValue();
            cellValue13.Text = "6";

            cell87.Append(cellValue13);

            Cell cell88 = new Cell() { CellReference = "C15", StyleIndex = (UInt32Value)7U, DataType = CellValues.SharedString };
            CellValue cellValue14 = new CellValue();
            cellValue14.Text = "7";

            cell88.Append(cellValue14);
            Cell cell89 = new Cell() { CellReference = "D15", StyleIndex = (UInt32Value)7U };

            Cell cell90 = new Cell() { CellReference = "E15", StyleIndex = (UInt32Value)7U, DataType = CellValues.SharedString };
            CellValue cellValue15 = new CellValue();
            cellValue15.Text = "8";

            cell90.Append(cellValue15);
            Cell cell91 = new Cell() { CellReference = "F15", StyleIndex = (UInt32Value)8U };

            Cell cell92 = new Cell() { CellReference = "G15", StyleIndex = (UInt32Value)7U, DataType = CellValues.SharedString };
            CellValue cellValue16 = new CellValue();
            cellValue16.Text = "9";

            cell92.Append(cellValue16);
            Cell cell93 = new Cell() { CellReference = "H15", StyleIndex = (UInt32Value)9U };

            //row13.Append(cell86);
            row13.Append(cell87);
            row13.Append(cell88);
            row13.Append(cell89);
            row13.Append(cell90);
            row13.Append(cell91);
            row13.Append(cell92);
            row13.Append(cell93);
            sheetData3.Append(row13);

            Margecells.Add("Modelo", "C15:D15");
            Margecells.Add("Marca", "E15:F15");
            Margecells.Add("NSerie", "G15:H15");

            UInt32 contadorRows = 16;
            int contadorEstilos = 1;
            UInt32 SCA = 0;
            UInt32 SCB = 0;
            UInt32 SCC = 0;
            UInt32 SCD = 0;
            UInt32 SCE = 0;
            UInt32 SCF = 0;
            UInt32 SCG = 0;
            UInt32 SCH = 0;

            foreach (Responsiva itemResponsiva in oResponsiva)
            {
                if (contadorEstilos == 1 && oResponsiva.Count != 1 )
                {
                    SCA = 1;
                    SCB = 2;
                    SCC = 10;
                    SCD = 10;
                    SCE = 10;
                    SCF = 10;
                    SCG = 10;
                    SCH = 11;
                }
                else if (contadorEstilos == oResponsiva.Count)
                {
                    SCA = 1;
                    SCB = 25;
                    SCC = 26;
                    SCD = 26;
                    SCE = 26;
                    SCF = 26;
                    SCG = 26;
                    SCH = 27;
                }
                else
                {
                    SCA = 1;
                    SCB = 2;
                    SCC = 10;
                    SCD = 10;
                    SCE = 10;
                    SCF = 10;
                    SCG = 10;
                    SCH = 11;
                }

                Row row14 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
                Cell cell94 = new Cell() { CellReference = "A" + contadorRows, StyleIndex = (UInt32Value)SCA };

                Cell cell95 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)SCB, DataType = CellValues.String };
                CellValue cellValue17 = new CellValue();
                cellValue17.Text = itemResponsiva.tipoequipo;

                cell95.Append(cellValue17);

                Cell cell96 = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)SCC, DataType = CellValues.String };
                CellValue cellValue18 = new CellValue();
                cellValue18.Text = itemResponsiva.modelo;

                cell96.Append(cellValue18);
                Cell cell97 = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)SCD };

                Cell cell98 = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)SCE, DataType = CellValues.String };
                CellValue cellValue19 = new CellValue();
                cellValue19.Text = itemResponsiva.marca;

                cell98.Append(cellValue19);
                Cell cell99 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)SCF };

                Cell cell100 = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)SCG, DataType = CellValues.String };
                CellValue cellValue20 = new CellValue();
                cellValue20.Text = itemResponsiva.noserie;

                cell100.Append(cellValue20);
                Cell cell101 = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)SCH };

                row14.Append(cell94);
                row14.Append(cell95);
                row14.Append(cell96);
                row14.Append(cell97);
                row14.Append(cell98);
                row14.Append(cell99);
                row14.Append(cell100);
                row14.Append(cell101);

                Margecells.Add("Modelo" + contadorRows, "C" + contadorRows + ":D" + contadorRows);
                Margecells.Add("Marca" + contadorRows, "E" + +contadorRows + ":F" + +contadorRows);
                Margecells.Add("NSerie" + contadorRows, "G" + contadorRows + ":H" + contadorRows);

                sheetData3.Append(row14);
                contadorRows++;
                contadorEstilos++;
            }

            //Total de artículos
            Row row26b = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };

            Cell cell183b = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)12U, DataType = CellValues.SharedString };
            CellValue cellValue21b = new CellValue();
            cellValue21b.Text = "Total de artículos asignados: " + oResponsiva.Count.ToString() + ".";

            cell183b.Append(cellValue21b);
            Cell cell127b = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)13U };
            Cell cell128b = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)13U };

            Margecells.Add("TotalArticulos", "B" + contadorRows + ":D" + contadorRows);
            row26b.Append(cell183b);
            row26b.Append(cell127b);
            row26b.Append(cell128b);
            contadorRows++;
            sheetData3.Append(row26b);

            contadorRows++;

            #region Cambio  forma Dinamica (No funciona)
            ////Row row15 = new Row() { RowIndex = (UInt32Value)17U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell102 = new Cell() { CellReference = "A17", StyleIndex = (UInt32Value)2U };
            ////Cell cell103 = new Cell() { CellReference = "B17", StyleIndex = (UInt32Value)3U };
            ////Cell cell104 = new Cell() { CellReference = "C17", StyleIndex = (UInt32Value)4U };
            ////Cell cell105 = new Cell() { CellReference = "D17", StyleIndex = (UInt32Value)4U };
            ////Cell cell106 = new Cell() { CellReference = "E17", StyleIndex = (UInt32Value)4U };
            ////Cell cell107 = new Cell() { CellReference = "F17", StyleIndex = (UInt32Value)4U };
            ////Cell cell108 = new Cell() { CellReference = "G17", StyleIndex = (UInt32Value)4U };
            ////Cell cell109 = new Cell() { CellReference = "H17", StyleIndex = (UInt32Value)11U };

            ////row15.Append(cell102);
            ////row15.Append(cell103);
            ////row15.Append(cell104);
            ////row15.Append(cell105);
            ////row15.Append(cell106);
            ////row15.Append(cell107);
            ////row15.Append(cell108);
            ////row15.Append(cell109);

            ////Row row16 = new Row() { RowIndex = (UInt32Value)18U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell110 = new Cell() { CellReference = "A18", StyleIndex = (UInt32Value)2U };
            ////Cell cell111 = new Cell() { CellReference = "B18", StyleIndex = (UInt32Value)3U };
            ////Cell cell112 = new Cell() { CellReference = "C18", StyleIndex = (UInt32Value)4U };
            ////Cell cell113 = new Cell() { CellReference = "D18", StyleIndex = (UInt32Value)4U };
            ////Cell cell114 = new Cell() { CellReference = "E18", StyleIndex = (UInt32Value)4U };
            ////Cell cell115 = new Cell() { CellReference = "F18", StyleIndex = (UInt32Value)4U };
            ////Cell cell116 = new Cell() { CellReference = "G18", StyleIndex = (UInt32Value)4U };
            ////Cell cell117 = new Cell() { CellReference = "H18", StyleIndex = (UInt32Value)11U };

            ////row16.Append(cell110);
            ////row16.Append(cell111);
            ////row16.Append(cell112);
            ////row16.Append(cell113);
            ////row16.Append(cell114);
            ////row16.Append(cell115);
            ////row16.Append(cell116);
            ////row16.Append(cell117);

            ////Row row17 = new Row() { RowIndex = (UInt32Value)19U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell118 = new Cell() { CellReference = "A19", StyleIndex = (UInt32Value)2U };
            ////Cell cell119 = new Cell() { CellReference = "B19", StyleIndex = (UInt32Value)3U };
            ////Cell cell120 = new Cell() { CellReference = "C19", StyleIndex = (UInt32Value)4U };
            ////Cell cell121 = new Cell() { CellReference = "D19", StyleIndex = (UInt32Value)4U };
            ////Cell cell122 = new Cell() { CellReference = "E19", StyleIndex = (UInt32Value)4U };
            ////Cell cell123 = new Cell() { CellReference = "F19", StyleIndex = (UInt32Value)4U };
            ////Cell cell124 = new Cell() { CellReference = "G19", StyleIndex = (UInt32Value)4U };
            ////Cell cell125 = new Cell() { CellReference = "H19", StyleIndex = (UInt32Value)11U };

            ////row17.Append(cell118);
            ////row17.Append(cell119);
            ////row17.Append(cell120);
            ////row17.Append(cell121);
            ////row17.Append(cell122);
            ////row17.Append(cell123);
            ////row17.Append(cell124);
            ////row17.Append(cell125);

            ////Row row18 = new Row() { RowIndex = (UInt32Value)20U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell126 = new Cell() { CellReference = "A20", StyleIndex = (UInt32Value)2U };
            ////Cell cell127 = new Cell() { CellReference = "B20", StyleIndex = (UInt32Value)3U };
            ////Cell cell128 = new Cell() { CellReference = "C20", StyleIndex = (UInt32Value)4U };
            ////Cell cell129 = new Cell() { CellReference = "D20", StyleIndex = (UInt32Value)4U };
            ////Cell cell130 = new Cell() { CellReference = "E20", StyleIndex = (UInt32Value)4U };
            ////Cell cell131 = new Cell() { CellReference = "F20", StyleIndex = (UInt32Value)4U };
            ////Cell cell132 = new Cell() { CellReference = "G20", StyleIndex = (UInt32Value)4U };
            ////Cell cell133 = new Cell() { CellReference = "H20", StyleIndex = (UInt32Value)11U };

            ////row18.Append(cell126);
            ////row18.Append(cell127);
            ////row18.Append(cell128);
            ////row18.Append(cell129);
            ////row18.Append(cell130);
            ////row18.Append(cell131);
            ////row18.Append(cell132);
            ////row18.Append(cell133);

            ////Row row19 = new Row() { RowIndex = (UInt32Value)21U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell134 = new Cell() { CellReference = "B21", StyleIndex = (UInt32Value)6U };
            ////Cell cell135 = new Cell() { CellReference = "C21", StyleIndex = (UInt32Value)7U };
            ////Cell cell136 = new Cell() { CellReference = "D21", StyleIndex = (UInt32Value)7U };
            ////Cell cell137 = new Cell() { CellReference = "E21", StyleIndex = (UInt32Value)7U };
            ////Cell cell138 = new Cell() { CellReference = "F21", StyleIndex = (UInt32Value)7U };
            ////Cell cell139 = new Cell() { CellReference = "G21", StyleIndex = (UInt32Value)7U };
            ////Cell cell140 = new Cell() { CellReference = "H21", StyleIndex = (UInt32Value)5U };

            ////row19.Append(cell134);
            ////row19.Append(cell135);
            ////row19.Append(cell136);
            ////row19.Append(cell137);
            ////row19.Append(cell138);
            ////row19.Append(cell139);
            ////row19.Append(cell140);

            ////Row row20 = new Row() { RowIndex = (UInt32Value)22U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell141 = new Cell() { CellReference = "B22", StyleIndex = (UInt32Value)6U };
            ////Cell cell142 = new Cell() { CellReference = "C22", StyleIndex = (UInt32Value)7U };
            ////Cell cell143 = new Cell() { CellReference = "D22", StyleIndex = (UInt32Value)7U };
            ////Cell cell144 = new Cell() { CellReference = "E22", StyleIndex = (UInt32Value)7U };
            ////Cell cell145 = new Cell() { CellReference = "F22", StyleIndex = (UInt32Value)7U };
            ////Cell cell146 = new Cell() { CellReference = "G22", StyleIndex = (UInt32Value)7U };
            ////Cell cell147 = new Cell() { CellReference = "H22", StyleIndex = (UInt32Value)5U };

            ////row20.Append(cell141);
            ////row20.Append(cell142);
            ////row20.Append(cell143);
            ////row20.Append(cell144);
            ////row20.Append(cell145);
            ////row20.Append(cell146);
            ////row20.Append(cell147);

            ////Row row21 = new Row() { RowIndex = (UInt32Value)23U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell148 = new Cell() { CellReference = "B23", StyleIndex = (UInt32Value)6U };
            ////Cell cell149 = new Cell() { CellReference = "C23", StyleIndex = (UInt32Value)7U };
            ////Cell cell150 = new Cell() { CellReference = "D23", StyleIndex = (UInt32Value)7U };
            ////Cell cell151 = new Cell() { CellReference = "E23", StyleIndex = (UInt32Value)7U };
            ////Cell cell152 = new Cell() { CellReference = "F23", StyleIndex = (UInt32Value)7U };
            ////Cell cell153 = new Cell() { CellReference = "G23", StyleIndex = (UInt32Value)7U };
            ////Cell cell154 = new Cell() { CellReference = "H23", StyleIndex = (UInt32Value)5U };

            ////row21.Append(cell148);
            ////row21.Append(cell149);
            ////row21.Append(cell150);
            ////row21.Append(cell151);
            ////row21.Append(cell152);
            ////row21.Append(cell153);
            ////row21.Append(cell154);

            ////Row row22 = new Row() { RowIndex = (UInt32Value)24U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell155 = new Cell() { CellReference = "B24", StyleIndex = (UInt32Value)6U };
            ////Cell cell156 = new Cell() { CellReference = "C24", StyleIndex = (UInt32Value)7U };
            ////Cell cell157 = new Cell() { CellReference = "D24", StyleIndex = (UInt32Value)7U };
            ////Cell cell158 = new Cell() { CellReference = "E24", StyleIndex = (UInt32Value)7U };
            ////Cell cell159 = new Cell() { CellReference = "F24", StyleIndex = (UInt32Value)7U };
            ////Cell cell160 = new Cell() { CellReference = "G24", StyleIndex = (UInt32Value)7U };
            ////Cell cell161 = new Cell() { CellReference = "H24", StyleIndex = (UInt32Value)5U };

            ////row22.Append(cell155);
            ////row22.Append(cell156);
            ////row22.Append(cell157);
            ////row22.Append(cell158);
            ////row22.Append(cell159);
            ////row22.Append(cell160);
            ////row22.Append(cell161);

            ////Row row23 = new Row() { RowIndex = (UInt32Value)25U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell162 = new Cell() { CellReference = "B25", StyleIndex = (UInt32Value)6U };
            ////Cell cell163 = new Cell() { CellReference = "C25", StyleIndex = (UInt32Value)7U };
            ////Cell cell164 = new Cell() { CellReference = "D25", StyleIndex = (UInt32Value)7U };
            ////Cell cell165 = new Cell() { CellReference = "E25", StyleIndex = (UInt32Value)7U };
            ////Cell cell166 = new Cell() { CellReference = "F25", StyleIndex = (UInt32Value)7U };
            ////Cell cell167 = new Cell() { CellReference = "G25", StyleIndex = (UInt32Value)7U };
            ////Cell cell168 = new Cell() { CellReference = "H25", StyleIndex = (UInt32Value)5U };

            ////row23.Append(cell162);
            ////row23.Append(cell163);
            ////row23.Append(cell164);
            ////row23.Append(cell165);
            ////row23.Append(cell166);
            ////row23.Append(cell167);
            ////row23.Append(cell168);

            ////Row row24 = new Row() { RowIndex = (UInt32Value)26U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            ////Cell cell169 = new Cell() { CellReference = "B26", StyleIndex = (UInt32Value)6U };
            ////Cell cell170 = new Cell() { CellReference = "C26", StyleIndex = (UInt32Value)7U };
            ////Cell cell171 = new Cell() { CellReference = "D26", StyleIndex = (UInt32Value)7U };
            ////Cell cell172 = new Cell() { CellReference = "E26", StyleIndex = (UInt32Value)7U };
            ////Cell cell173 = new Cell() { CellReference = "F26", StyleIndex = (UInt32Value)7U };
            ////Cell cell174 = new Cell() { CellReference = "G26", StyleIndex = (UInt32Value)7U };
            ////Cell cell175 = new Cell() { CellReference = "H26", StyleIndex = (UInt32Value)5U };

            ////row24.Append(cell169);
            ////row24.Append(cell170);
            ////row24.Append(cell171);
            ////row24.Append(cell172);
            ////row24.Append(cell173);
            ////row24.Append(cell174);
            ////row24.Append(cell175);

            ////Row row25 = new Row() { RowIndex = (UInt32Value)27U, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 15.75D, ThickBot = true, DyDescent = 0.3D };
            ////Cell cell176 = new Cell() { CellReference = "B27", StyleIndex = (UInt32Value)8U };
            ////Cell cell177 = new Cell() { CellReference = "C27", StyleIndex = (UInt32Value)9U };
            ////Cell cell178 = new Cell() { CellReference = "D27", StyleIndex = (UInt32Value)9U };
            ////Cell cell179 = new Cell() { CellReference = "E27", StyleIndex = (UInt32Value)9U };
            ////Cell cell180 = new Cell() { CellReference = "F27", StyleIndex = (UInt32Value)9U };
            ////Cell cell181 = new Cell() { CellReference = "G27", StyleIndex = (UInt32Value)9U };
            ////Cell cell182 = new Cell() { CellReference = "H27", StyleIndex = (UInt32Value)10U };

            ////row25.Append(cell176);
            ////row25.Append(cell177);
            ////row25.Append(cell178);
            ////row25.Append(cell179);
            ////row25.Append(cell180);
            ////row25.Append(cell181);
            ////row25.Append(cell182); 
            #endregion

            Row row26 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };

            Cell cell183 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)12U, DataType = CellValues.SharedString };
            CellValue cellValue21 = new CellValue();
            cellValue21.Text = "10";

            cell183.Append(cellValue21);
            Cell cell127A = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)13U };
            Cell cell128A = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)13U };

            Margecells.Add("ParametroN0ta2", "B" + contadorRows + ":D" + contadorRows);
            row26.Append(cell183);
            row26.Append(cell127A);
            row26.Append(cell128A);
            contadorRows++;
            sheetData3.Append(row26);

            Row row27 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 41.25D, CustomHeight = true, DyDescent = 0.25D };

            Cell cell184 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)29U, DataType = CellValues.SharedString };
            CellValue cellValue22 = new CellValue();
            cellValue22.Text = "11";

            cell184.Append(cellValue22);

            Margecells.Add("Clausula1", "B" + contadorRows + ":H" + contadorRows);
            Cell cell130A = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell131A = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell132A = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell133A = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell134A = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell135A = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)30U };
            row27.Append(cell184);
            row27.Append(cell130A);
            row27.Append(cell131A);
            row27.Append(cell132A);
            row27.Append(cell133A);
            row27.Append(cell134A);
            row27.Append(cell135A);
            contadorRows++;
            sheetData3.Append(row27);

            Row row28 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 56.25D, CustomHeight = true, DyDescent = 0.25D };

            Cell cell185 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)29U, DataType = CellValues.SharedString };
            CellValue cellValue23 = new CellValue();
            cellValue23.Text = "12";

            cell185.Append(cellValue23);
            Cell cell137A = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell138A = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell139A = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell140A = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell141A = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell142A = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)30U };

            Margecells.Add("Clausula2", "B" + contadorRows + ":H" + contadorRows);
            row28.Append(cell185);
            row28.Append(cell137A);
            row28.Append(cell138A);
            row28.Append(cell139A);
            row28.Append(cell140A);
            row28.Append(cell141A);
            row28.Append(cell142A);
            contadorRows++;
            sheetData3.Append(row28);

            Row row29 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };

            Cell cell186 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)29U, DataType = CellValues.SharedString };
            CellValue cellValue24 = new CellValue();
            cellValue24.Text = "13";

            cell186.Append(cellValue24);
            Cell cell144A = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell145A = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell146A = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell147A = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell148A = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)30U };
            Cell cell149A = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)30U };

            Margecells.Add("Clausula3", "B" + contadorRows + ":H" + contadorRows);
            row29.Append(cell186);
            row29.Append(cell144A);
            row29.Append(cell145A);
            row29.Append(cell146A);
            row29.Append(cell147A);
            row29.Append(cell148A);
            row29.Append(cell149A);
            sheetData3.Append(row29);
            contadorRows += 2;

            //Row row30 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };

            //Cell cell187 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            //CellValue cellValue25 = new CellValue();
            //cellValue25.Text = "14";

            //cell187.Append(cellValue25);

            //row30.Append(cell187);
            //contadorRows++;
            //sheetData3.Append(row30);

            Row row31 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 15.75D, ThickBot = true, DyDescent = 0.3D };

            Cell cell188 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue26 = new CellValue();
            cellValue26.Text = "24";

            cell188.Append(cellValue26);

            row31.Append(cell188);
            contadorRows++;
            sheetData3.Append(row31);

            Margecells.Add("Observaciones", "B" + contadorRows + ":H" + (contadorRows + 3));

            Row row32 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };

            Cell cell189 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)14U, DataType = CellValues.SharedString };
            CellValue cellValue27 = new CellValue();
            cellValue27.Text = "25";

            cell189.Append(cellValue27);
            Cell cell190 = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)15U };
            Cell cell191 = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)15U };
            Cell cell192 = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)15U };
            Cell cell193 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)15U };
            Cell cell194 = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)15U };
            Cell cell195 = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)16U };

            row32.Append(cell189);
            row32.Append(cell190);
            row32.Append(cell191);
            row32.Append(cell192);
            row32.Append(cell193);
            row32.Append(cell194);
            row32.Append(cell195);
            contadorRows++;
            sheetData3.Append(row32);

            Row row33 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell196 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)17U };
            Cell cell197 = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell198 = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell199 = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell200 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell201 = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell202 = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)19U };

            row33.Append(cell196);
            row33.Append(cell197);
            row33.Append(cell198);
            row33.Append(cell199);
            row33.Append(cell200);
            row33.Append(cell201);
            row33.Append(cell202);
            contadorRows++;
            sheetData3.Append(row33);

            Row row34 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, DyDescent = 0.25D };
            Cell cell203 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)17U };
            Cell cell204 = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell205 = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell206 = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell207 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell208 = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)18U };
            Cell cell209 = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)19U };

            row34.Append(cell203);
            row34.Append(cell204);
            row34.Append(cell205);
            row34.Append(cell206);
            row34.Append(cell207);
            row34.Append(cell208);
            row34.Append(cell209);
            sheetData3.Append(row34);
            contadorRows++;

            Row row35 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "1:8" }, Height = 15.75D, ThickBot = true, DyDescent = 0.3D };
            Cell cell210 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)20U };
            Cell cell211 = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)21U };
            Cell cell212 = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)21U };
            Cell cell213 = new Cell() { CellReference = "E" + contadorRows, StyleIndex = (UInt32Value)21U };
            Cell cell214 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)21U };
            Cell cell215 = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)21U };
            Cell cell216 = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)22U };

            row35.Append(cell210);
            row35.Append(cell211);
            row35.Append(cell212);
            row35.Append(cell213);
            row35.Append(cell214);
            row35.Append(cell215);
            row35.Append(cell216);
            sheetData3.Append(row35);
            contadorRows += 5;

            Row row36 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "2:7" }, DyDescent = 0.25D };
            Cell cell217 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)23U };
            Cell cell218 = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)23U };
            Cell cell218a = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)23U };
            Cell cell219 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)23U };
            Cell cell220 = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)23U };
            Cell cell220a = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)23U };

            Margecells.Add("Firmac", "B" + contadorRows + ":D" + contadorRows);
            Margecells.Add("FirmaE", "F" + contadorRows + ":H" + contadorRows);
            row36.Append(cell217);
            row36.Append(cell218);
            row36.Append(cell218a);
            row36.Append(cell219);
            row36.Append(cell220);
            row36.Append(cell220a);
            contadorRows++;
            sheetData3.Append(row36);

            Row row37 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "2:7" }, DyDescent = 0.25D };

            Cell cell221 = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)24U, DataType = CellValues.SharedString };
            CellValue cellValue28 = new CellValue();
            cellValue28.Text = "18";

            cell221.Append(cellValue28);
            Cell cell222 = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)24U };
            Cell cell222a = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)24U };

            Cell cell223 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)24U, DataType = CellValues.SharedString };
            CellValue cellValue29 = new CellValue();
            cellValue29.Text = "27";

            //Cell cell186A = new Cell() { CellReference = "G35", StyleIndex = (UInt32Value)13U };
            Cell cell186A = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)24U };
            Cell cell186b = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)24U };

            cell223.Append(cellValue29);

            Margecells.Add("Nombrec", "B" + contadorRows + ":D" + contadorRows);
            Margecells.Add("ParametroNota", "F" + contadorRows + ":H" + contadorRows);
            row37.Append(cell221);
            row37.Append(cell222);
            row37.Append(cell222a);
            row37.Append(cell223);
            row37.Append(cell186A);
            row37.Append(cell186b);
            contadorRows++;
            sheetData3.Append(row37);

            Row row38 = new Row() { RowIndex = (UInt32Value)contadorRows, Spans = new ListValue<StringValue>() { InnerText = "2:7" }, DyDescent = 0.25D };

            Cell cell224a = new Cell() { CellReference = "B" + contadorRows, StyleIndex = (UInt32Value)24U, DataType = CellValues.SharedString };
            CellValue cellValue30a = new CellValue();
            cellValue30a.Text = "Recibe equipo(s)";

            cell224a.Append(cellValue30a);

            Cell cell224b = new Cell() { CellReference = "C" + contadorRows, StyleIndex = (UInt32Value)24U };
            Cell cell224c = new Cell() { CellReference = "D" + contadorRows, StyleIndex = (UInt32Value)24U };

            Cell cell224 = new Cell() { CellReference = "F" + contadorRows, StyleIndex = (UInt32Value)24U, DataType = CellValues.SharedString };
            CellValue cellValue30 = new CellValue();
            cellValue30.Text = "28";

            cell224.Append(cellValue30);
            Cell cell225 = new Cell() { CellReference = "G" + contadorRows, StyleIndex = (UInt32Value)24U };
            Cell cell225a = new Cell() { CellReference = "H" + contadorRows, StyleIndex = (UInt32Value)24U };

            Margecells.Add("ParamRecibe", "B" + contadorRows + ":D" + contadorRows);
            Margecells.Add("NombreE", "F" + contadorRows + ":H" + contadorRows);
            row38.Append(cell224a);
            row38.Append(cell224b);
            row38.Append(cell224c);
            row38.Append(cell224);
            row38.Append(cell225);
            row38.Append(cell225a);
            contadorRows++;
            sheetData3.Append(row38);

           
            MergeCells mergeCells1 = new MergeCells() { Count = (UInt32Value)Convert.ToUInt32(Margecells.Count()) };

            foreach (var item in Margecells)
            {
                MergeCell mergeCell1 = new MergeCell() { Reference = item.Value };
                mergeCells1.Append(mergeCell1);
            }

            PageMargins pageMargins3 = new PageMargins() { Left = 0.25D, Right = 0.25D, Top = 0.75D, Bottom = 0.75D, Header = 0.3D, Footer = 0.3D };
            PageSetup pageSetup1 = new PageSetup() { Orientation = OrientationValues.Portrait, Id = "rId1" };
            Drawing drawing1 = new Drawing() { Id = "rId2" };

            worksheet3.Append(sheetDimension3);
            worksheet3.Append(sheetViews3);
            worksheet3.Append(sheetFormatProperties3);
            worksheet3.Append(columns1);
            worksheet3.Append(sheetData3);
            worksheet3.Append(mergeCells1);
            worksheet3.Append(pageMargins3);
            worksheet3.Append(pageSetup1);
            worksheet3.Append(drawing1);

            worksheetPart3.Worksheet = worksheet3;
        }

        // Generates content of drawingsPart1.
        private void GenerateDrawingsPart1Content(DrawingsPart drawingsPart1)
        {
            Xdr.WorksheetDrawing worksheetDrawing1 = new Xdr.WorksheetDrawing();
            worksheetDrawing1.AddNamespaceDeclaration("xdr", "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
            worksheetDrawing1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            Xdr.TwoCellAnchor twoCellAnchor1 = new Xdr.TwoCellAnchor() { EditAs = Xdr.EditAsValues.OneCell };

            Xdr.FromMarker fromMarker1 = new Xdr.FromMarker();
            Xdr.ColumnId columnId1 = new Xdr.ColumnId();
            columnId1.Text = "0";
            Xdr.ColumnOffset columnOffset1 = new Xdr.ColumnOffset();
            columnOffset1.Text = "274546";
            Xdr.RowId rowId1 = new Xdr.RowId();
            rowId1.Text = "0";
            Xdr.RowOffset rowOffset1 = new Xdr.RowOffset();
            rowOffset1.Text = "89088";

            fromMarker1.Append(columnId1);
            fromMarker1.Append(columnOffset1);
            fromMarker1.Append(rowId1);
            fromMarker1.Append(rowOffset1);

            Xdr.ToMarker toMarker1 = new Xdr.ToMarker();
            Xdr.ColumnId columnId2 = new Xdr.ColumnId();
            columnId2.Text = "1";
            Xdr.ColumnOffset columnOffset2 = new Xdr.ColumnOffset();
            columnOffset2.Text = "979108";
            Xdr.RowId rowId2 = new Xdr.RowId();
            rowId2.Text = "4";
            Xdr.RowOffset rowOffset2 = new Xdr.RowOffset();
            rowOffset2.Text = "78441";

            toMarker1.Append(columnId2);
            toMarker1.Append(columnOffset2);
            toMarker1.Append(rowId2);
            toMarker1.Append(rowOffset2);

            Xdr.Picture picture1 = new Xdr.Picture();

            Xdr.NonVisualPictureProperties nonVisualPictureProperties1 = new Xdr.NonVisualPictureProperties();
            Xdr.NonVisualDrawingProperties nonVisualDrawingProperties1 = new Xdr.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "1 Imagen" };

            Xdr.NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties1 = new Xdr.NonVisualPictureDrawingProperties();
            A.PictureLocks pictureLocks1 = new A.PictureLocks() { NoChangeAspect = true };

            nonVisualPictureDrawingProperties1.Append(pictureLocks1);

            nonVisualPictureProperties1.Append(nonVisualDrawingProperties1);
            nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);

            Xdr.BlipFill blipFill1 = new Xdr.BlipFill();

            A.Blip blip1 = new A.Blip() { Embed = "rId1" };
            blip1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");

            A.BlipExtensionList blipExtensionList1 = new A.BlipExtensionList();

            A.BlipExtension blipExtension1 = new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" };

            A14.UseLocalDpi useLocalDpi1 = new A14.UseLocalDpi() { Val = false };
            useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            blipExtension1.Append(useLocalDpi1);

            blipExtensionList1.Append(blipExtension1);

            blip1.Append(blipExtensionList1);

            A.Stretch stretch1 = new A.Stretch();
            A.FillRectangle fillRectangle1 = new A.FillRectangle();

            stretch1.Append(fillRectangle1);

            blipFill1.Append(blip1);
            blipFill1.Append(stretch1);

            Xdr.ShapeProperties shapeProperties1 = new Xdr.ShapeProperties();

            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset1 = new A.Offset() { X = 274546L, Y = 89088L };
            A.Extents extents1 = new A.Extents() { Cx = 1142712L, Cy = 789453L };

            transform2D1.Append(offset1);
            transform2D1.Append(extents1);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);

            picture1.Append(nonVisualPictureProperties1);
            picture1.Append(blipFill1);
            picture1.Append(shapeProperties1);
            Xdr.ClientData clientData1 = new Xdr.ClientData();

            twoCellAnchor1.Append(fromMarker1);
            twoCellAnchor1.Append(toMarker1);
            twoCellAnchor1.Append(picture1);
            twoCellAnchor1.Append(clientData1);

            worksheetDrawing1.Append(twoCellAnchor1);

            drawingsPart1.WorksheetDrawing = worksheetDrawing1;
        }

        // Generates content of imagePart1.
        private void GenerateImagePart1Content(ImagePart imagePart1)
        {
            System.IO.Stream data = GetBinaryDataStream(imagePart1Data);
            imagePart1.FeedData(data);
            data.Close();
        }

        // Generates content of spreadsheetPrinterSettingsPart1.
        private void GenerateSpreadsheetPrinterSettingsPart1Content(SpreadsheetPrinterSettingsPart spreadsheetPrinterSettingsPart1)
        {
            System.IO.Stream data = GetBinaryDataStream(spreadsheetPrinterSettingsPart1Data);
            spreadsheetPrinterSettingsPart1.FeedData(data);
            data.Close();
        }

        // Generates content of sharedStringTablePart1.
        private void GenerateSharedStringTablePart1Content(SharedStringTablePart sharedStringTablePart1)
        {
            string responsiva = string.Empty;
            string Usuario = string.Empty;
            string puesto = string.Empty;
            string sucursal = string.Empty;
            string observacionEquipo = string.Empty;

            foreach (var item in oResponsiva)
            {
                //observacionEquipo += item.observacion1 + " " + item.observacion2; 
                observacionEquipo = item.ObservacionesResponsiva;
            }

            if (oResponsiva.Count > 0)
            {
                responsiva = oResponsiva[0].idResponsiva;
                Usuario = oResponsiva[0].usuario;
                puesto = oResponsiva[0].puesto;
                sucursal = oResponsiva[0].sucursal;
            }

            DLParametro dlParametro = new DLParametro();
            List<Parametro> parametros = dlParametro.getParaemetrobyDescripcionLike("RespText");

            SharedStringTable sharedStringTable1 = new SharedStringTable() { Count = (UInt32Value)30U, UniqueCount = (UInt32Value)29U };

            SharedStringItem sharedStringItem1 = new SharedStringItem();
            Text text1 = new Text();
            text1.Text = "HIPOTECARIA SU CASITA";

            sharedStringItem1.Append(text1);

            SharedStringItem sharedStringItem2 = new SharedStringItem();
            Text text2 = new Text();
            text2.Text = "SISTEMAS";

            sharedStringItem2.Append(text2);

            SharedStringItem sharedStringItem3 = new SharedStringItem();
            Text text3 = new Text();
            text3.Text = "CARTA RESPONSIVA DE ASIGNACIÓN DE EQUIPO DE CÓMPUTO";

            sharedStringItem3.Append(text3);

            SharedStringItem sharedStringItem4 = new SharedStringItem();
            Text text4 = new Text();
            text4.Text = "No. Responsiva:";

            sharedStringItem4.Append(text4);

            SharedStringItem sharedStringItem5 = new SharedStringItem();
            Text text5 = new Text();
            text5.Text = "At\'n:";

            sharedStringItem5.Append(text5);

            SharedStringItem sharedStringItem6 = new SharedStringItem();
            Text text6 = new Text();
            text6.Text = "Sucursal:";

            sharedStringItem6.Append(text6);

            SharedStringItem sharedStringItem7 = new SharedStringItem();
            Text text7 = new Text();
            text7.Text = "Tipo de Equipo.";

            sharedStringItem7.Append(text7);

            SharedStringItem sharedStringItem8 = new SharedStringItem();
            Text text8 = new Text();
            text8.Text = "Modelo";

            sharedStringItem8.Append(text8);

            SharedStringItem sharedStringItem9 = new SharedStringItem();
            Text text9 = new Text();
            text9.Text = "Marca";

            sharedStringItem9.Append(text9);

            SharedStringItem sharedStringItem10 = new SharedStringItem();
            Text text10 = new Text();
            text10.Text = "No. de Serie";

            sharedStringItem10.Append(text10);

            SharedStringItem sharedStringItem11 = new SharedStringItem();
            Text text11 = new Text();
            text11.Text = "Se consideran las siguientes cláusulas:";

            sharedStringItem11.Append(text11);

            SharedStringItem sharedStringItem12 = new SharedStringItem();
            Text text12 = new Text();
            text12.Text = parametros[1].par_Valor;

            sharedStringItem12.Append(text12);

            SharedStringItem sharedStringItem13 = new SharedStringItem();
            Text text13 = new Text();
            text13.Text = parametros[2].par_Valor;

            sharedStringItem13.Append(text13);

            SharedStringItem sharedStringItem14 = new SharedStringItem();
            Text text14 = new Text();
            text14.Text = parametros[3].par_Valor;

            sharedStringItem14.Append(text14);

            SharedStringItem sharedStringItem15 = new SharedStringItem();
            Text text15 = new Text();
            text15.Text = "tagclausula4";

            sharedStringItem15.Append(text15);

            SharedStringItem sharedStringItem16 = new SharedStringItem();
            Text text16 = new Text();
            text16.Text = "tagUsuario";

            sharedStringItem16.Append(text16);

            SharedStringItem sharedStringItem17 = new SharedStringItem();
            Text text17 = new Text();
            text17.Text = "tagResponsiva";

            sharedStringItem17.Append(text17);

            SharedStringItem sharedStringItem18 = new SharedStringItem();
            Text text18 = new Text();
            text18.Text = "tagSucursal";

            sharedStringItem18.Append(text18);

            SharedStringItem sharedStringItem19 = new SharedStringItem();
            Text text19 = new Text();
            text19.Text = Usuario;

            sharedStringItem19.Append(text19);

            SharedStringItem sharedStringItem20 = new SharedStringItem();
            Text text20 = new Text();
            text20.Text = responsiva;

            sharedStringItem20.Append(text20);

            SharedStringItem sharedStringItem21 = new SharedStringItem();
            Text text21 = new Text();
            text21.Text = sucursal;

            sharedStringItem21.Append(text21);

            SharedStringItem sharedStringItem22 = new SharedStringItem();
            Text text22 = new Text();
            text22.Text = puesto;

            sharedStringItem22.Append(text22);

            SharedStringItem sharedStringItem23 = new SharedStringItem();
            Text text23 = new Text();
            text23.Text = "Puesto:";

            sharedStringItem23.Append(text23);

            SharedStringItem sharedStringItem24 = new SharedStringItem();
            Text text24 = new Text();
            text24.Text = parametros[0].par_Valor;

            sharedStringItem24.Append(text24);

            SharedStringItem sharedStringItem25 = new SharedStringItem();
            Text text25 = new Text();
            text25.Text = "Observaciones";

            sharedStringItem25.Append(text25);

            SharedStringItem sharedStringItem26 = new SharedStringItem();
            Text text26 = new Text();
            text26.Text = observacionEquipo;                                             //***** TODO:

            sharedStringItem26.Append(text26);

            SharedStringItem sharedStringItem27 = new SharedStringItem();
            Text text27 = new Text();
            text27.Text = "0tagMarca1";                                                  //***** TODO:   16

            sharedStringItem27.Append(text27);

            SharedStringItem sharedStringItem28 = new SharedStringItem();
            Text text28 = new Text();
            text28.Text = parametros[4].par_Valor.ToUpper();//"Entregó Equipo personal de TI";    //***** TODO: 17

            sharedStringItem28.Append(text28);

            SharedStringItem sharedStringItem29 = new SharedStringItem();
            Text text29 = new Text();
            text29.Text = "Entrega equipo(s)";//parametros[4].par_Valor;    //***** TODO: 18

            sharedStringItem29.Append(text29);


            sharedStringTable1.Append(sharedStringItem1);
            sharedStringTable1.Append(sharedStringItem2);
            sharedStringTable1.Append(sharedStringItem3);
            sharedStringTable1.Append(sharedStringItem4);
            sharedStringTable1.Append(sharedStringItem5);
            sharedStringTable1.Append(sharedStringItem6);
            sharedStringTable1.Append(sharedStringItem7);
            sharedStringTable1.Append(sharedStringItem8);
            sharedStringTable1.Append(sharedStringItem9);
            sharedStringTable1.Append(sharedStringItem10);
            sharedStringTable1.Append(sharedStringItem11);
            sharedStringTable1.Append(sharedStringItem12);
            sharedStringTable1.Append(sharedStringItem13);
            sharedStringTable1.Append(sharedStringItem14);
            sharedStringTable1.Append(sharedStringItem15);
            sharedStringTable1.Append(sharedStringItem16);
            sharedStringTable1.Append(sharedStringItem17);
            sharedStringTable1.Append(sharedStringItem18);
            sharedStringTable1.Append(sharedStringItem19);
            sharedStringTable1.Append(sharedStringItem20);
            sharedStringTable1.Append(sharedStringItem21);
            sharedStringTable1.Append(sharedStringItem22);
            sharedStringTable1.Append(sharedStringItem23);
            sharedStringTable1.Append(sharedStringItem24);
            sharedStringTable1.Append(sharedStringItem25);
            sharedStringTable1.Append(sharedStringItem26);
            sharedStringTable1.Append(sharedStringItem27);
            sharedStringTable1.Append(sharedStringItem28);
            sharedStringTable1.Append(sharedStringItem29);

            sharedStringTablePart1.SharedStringTable = sharedStringTable1;
        }

        // Generates content of workbookStylesPart1.
        private void GenerateWorkbookStylesPart1Content(WorkbookStylesPart workbookStylesPart1)
        {
            Stylesheet stylesheet1 = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)7U, KnownFonts = true };

            Font font1 = new Font();
            FontSize fontSize1 = new FontSize() { Val = 11D };
            Color color1 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontScheme1);

            Font font2 = new Font();
            FontSize fontSize2 = new FontSize() { Val = 14D };
            Color color2 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName2 = new FontName() { Val = "Arial" };
            FontFamilyNumbering fontFamilyNumbering2 = new FontFamilyNumbering() { Val = 2 };

            font2.Append(fontSize2);
            font2.Append(color2);
            font2.Append(fontName2);
            font2.Append(fontFamilyNumbering2);

            Font font3 = new Font();
            FontSize fontSize3 = new FontSize() { Val = 10D };
            Color color3 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName3 = new FontName() { Val = "Arial" };
            FontFamilyNumbering fontFamilyNumbering3 = new FontFamilyNumbering() { Val = 2 };

            font3.Append(fontSize3);
            font3.Append(color3);
            font3.Append(fontName3);
            font3.Append(fontFamilyNumbering3);

            Font font4 = new Font();
            FontSize fontSize4 = new FontSize() { Val = 8D };
            Color color4 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName4 = new FontName() { Val = "Arial" };
            FontFamilyNumbering fontFamilyNumbering4 = new FontFamilyNumbering() { Val = 2 };

            font4.Append(fontSize4);
            font4.Append(color4);
            font4.Append(fontName4);
            font4.Append(fontFamilyNumbering4);

            Font font5 = new Font();
            FontSize fontSize5 = new FontSize() { Val = 8D };
            Color color5 = new Color() { Theme = (UInt32Value)0U };
            FontName fontName5 = new FontName() { Val = "Arial" };
            FontFamilyNumbering fontFamilyNumbering5 = new FontFamilyNumbering() { Val = 2 };

            font5.Append(fontSize5);
            font5.Append(color5);
            font5.Append(fontName5);
            font5.Append(fontFamilyNumbering5);

            Font font6 = new Font();
            FontSize fontSize6 = new FontSize() { Val = 7.5D };
            Color color6 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName6 = new FontName() { Val = "Arial" };
            FontFamilyNumbering fontFamilyNumbering6 = new FontFamilyNumbering() { Val = 2 };

            font6.Append(fontSize6);
            font6.Append(color6);
            font6.Append(fontName6);
            font6.Append(fontFamilyNumbering6);

            Font font7 = new Font();
            FontSize fontSize7 = new FontSize() { Val = 7.5D };
            Color color7 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName7 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering7 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme2 = new FontScheme() { Val = FontSchemeValues.Minor };

            font7.Append(fontSize7);
            font7.Append(color7);
            font7.Append(fontName7);
            font7.Append(fontFamilyNumbering7);
            font7.Append(fontScheme2);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);
            fonts1.Append(font4);
            fonts1.Append(font5);
            fonts1.Append(font6);
            fonts1.Append(font7);

            Fills fills1 = new Fills() { Count = (UInt32Value)3U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            Fill fill3 = new Fill();

            PatternFill patternFill3 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor1 = new ForegroundColor() { Theme = (UInt32Value)3U };
            BackgroundColor backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };

            patternFill3.Append(foregroundColor1);
            patternFill3.Append(backgroundColor1);

            fill3.Append(patternFill3);

            fills1.Append(fill1);
            fills1.Append(fill2);
            fills1.Append(fill3);

            Borders borders1 = new Borders() { Count = (UInt32Value)11U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            Border border2 = new Border();

            LeftBorder leftBorder2 = new LeftBorder() { Style = BorderStyleValues.Medium };
            Color color8 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder2.Append(color8);

            RightBorder rightBorder2 = new RightBorder() { Style = BorderStyleValues.Medium };
            Color color9 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder2.Append(color9);

            TopBorder topBorder2 = new TopBorder() { Style = BorderStyleValues.Medium };
            Color color10 = new Color() { Indexed = (UInt32Value)64U };

            topBorder2.Append(color10);

            BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Medium };
            Color color11 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder2.Append(color11);
            DiagonalBorder diagonalBorder2 = new DiagonalBorder();

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);
            border2.Append(diagonalBorder2);

            Border border3 = new Border();

            LeftBorder leftBorder3 = new LeftBorder() { Style = BorderStyleValues.Medium };
            Color color12 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder3.Append(color12);
            RightBorder rightBorder3 = new RightBorder();

            TopBorder topBorder3 = new TopBorder() { Style = BorderStyleValues.Medium };
            Color color13 = new Color() { Indexed = (UInt32Value)64U };

            topBorder3.Append(color13);
            BottomBorder bottomBorder3 = new BottomBorder();
            DiagonalBorder diagonalBorder3 = new DiagonalBorder();

            border3.Append(leftBorder3);
            border3.Append(rightBorder3);
            border3.Append(topBorder3);
            border3.Append(bottomBorder3);
            border3.Append(diagonalBorder3);

            Border border4 = new Border();
            LeftBorder leftBorder4 = new LeftBorder();
            RightBorder rightBorder4 = new RightBorder();

            TopBorder topBorder4 = new TopBorder() { Style = BorderStyleValues.Medium };
            Color color14 = new Color() { Indexed = (UInt32Value)64U };

            topBorder4.Append(color14);
            BottomBorder bottomBorder4 = new BottomBorder();
            DiagonalBorder diagonalBorder4 = new DiagonalBorder();

            border4.Append(leftBorder4);
            border4.Append(rightBorder4);
            border4.Append(topBorder4);
            border4.Append(bottomBorder4);
            border4.Append(diagonalBorder4);

            Border border5 = new Border();
            LeftBorder leftBorder5 = new LeftBorder();

            RightBorder rightBorder5 = new RightBorder() { Style = BorderStyleValues.Medium };
            Color color15 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder5.Append(color15);

            TopBorder topBorder5 = new TopBorder() { Style = BorderStyleValues.Medium };
            Color color16 = new Color() { Indexed = (UInt32Value)64U };

            topBorder5.Append(color16);
            BottomBorder bottomBorder5 = new BottomBorder();
            DiagonalBorder diagonalBorder5 = new DiagonalBorder();

            border5.Append(leftBorder5);
            border5.Append(rightBorder5);
            border5.Append(topBorder5);
            border5.Append(bottomBorder5);
            border5.Append(diagonalBorder5);

            Border border6 = new Border();

            LeftBorder leftBorder6 = new LeftBorder() { Style = BorderStyleValues.Medium };
            Color color17 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder6.Append(color17);
            RightBorder rightBorder6 = new RightBorder();
            TopBorder topBorder6 = new TopBorder();
            BottomBorder bottomBorder6 = new BottomBorder();
            DiagonalBorder diagonalBorder6 = new DiagonalBorder();

            border6.Append(leftBorder6);
            border6.Append(rightBorder6);
            border6.Append(topBorder6);
            border6.Append(bottomBorder6);
            border6.Append(diagonalBorder6);

            Border border7 = new Border();
            LeftBorder leftBorder7 = new LeftBorder();

            RightBorder rightBorder7 = new RightBorder() { Style = BorderStyleValues.Medium };
            Color color18 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder7.Append(color18);
            TopBorder topBorder7 = new TopBorder();
            BottomBorder bottomBorder7 = new BottomBorder();
            DiagonalBorder diagonalBorder7 = new DiagonalBorder();

            border7.Append(leftBorder7);
            border7.Append(rightBorder7);
            border7.Append(topBorder7);
            border7.Append(bottomBorder7);
            border7.Append(diagonalBorder7);

            Border border8 = new Border();

            LeftBorder leftBorder8 = new LeftBorder() { Style = BorderStyleValues.Medium };
            Color color19 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder8.Append(color19);
            RightBorder rightBorder8 = new RightBorder();
            TopBorder topBorder8 = new TopBorder();

            BottomBorder bottomBorder8 = new BottomBorder() { Style = BorderStyleValues.Medium };
            Color color20 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder8.Append(color20);
            DiagonalBorder diagonalBorder8 = new DiagonalBorder();

            border8.Append(leftBorder8);
            border8.Append(rightBorder8);
            border8.Append(topBorder8);
            border8.Append(bottomBorder8);
            border8.Append(diagonalBorder8);

            Border border9 = new Border();
            LeftBorder leftBorder9 = new LeftBorder();
            RightBorder rightBorder9 = new RightBorder();
            TopBorder topBorder9 = new TopBorder();

            BottomBorder bottomBorder9 = new BottomBorder() { Style = BorderStyleValues.Medium };
            Color color21 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder9.Append(color21);
            DiagonalBorder diagonalBorder9 = new DiagonalBorder();

            border9.Append(leftBorder9);
            border9.Append(rightBorder9);
            border9.Append(topBorder9);
            border9.Append(bottomBorder9);
            border9.Append(diagonalBorder9);

            Border border10 = new Border();
            LeftBorder leftBorder10 = new LeftBorder();

            RightBorder rightBorder10 = new RightBorder() { Style = BorderStyleValues.Medium };
            Color color22 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder10.Append(color22);
            TopBorder topBorder10 = new TopBorder();

            BottomBorder bottomBorder10 = new BottomBorder() { Style = BorderStyleValues.Medium };
            Color color23 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder10.Append(color23);
            DiagonalBorder diagonalBorder10 = new DiagonalBorder();

            border10.Append(leftBorder10);
            border10.Append(rightBorder10);
            border10.Append(topBorder10);
            border10.Append(bottomBorder10);
            border10.Append(diagonalBorder10);

            Border border11 = new Border();
            LeftBorder leftBorder11 = new LeftBorder();
            RightBorder rightBorder11 = new RightBorder();
            TopBorder topBorder11 = new TopBorder();

            BottomBorder bottomBorder11 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color24 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder11.Append(color24);
            DiagonalBorder diagonalBorder11 = new DiagonalBorder();

            border11.Append(leftBorder11);
            border11.Append(rightBorder11);
            border11.Append(topBorder11);
            border11.Append(bottomBorder11);
            border11.Append(diagonalBorder11);

            borders1.Append(border1);
            borders1.Append(border2);
            borders1.Append(border3);
            borders1.Append(border4);
            borders1.Append(border5);
            borders1.Append(border6);
            borders1.Append(border7);
            borders1.Append(border8);
            borders1.Append(border9);
            borders1.Append(border10);
            borders1.Append(border11);

            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

            cellStyleFormats1.Append(cellFormat1);

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)31U };
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true };
            CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)5U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };
            CellFormat cellFormat5 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)4U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)2U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true, ApplyBorder = true, ApplyAlignment = true };
            CellFormat cellFormat6 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };

            CellFormat cellFormat7 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };
            Alignment alignment1 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };

            cellFormat7.Append(alignment1);

            CellFormat cellFormat8 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)2U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };
            Alignment alignment2 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };

            cellFormat8.Append(alignment2);
            CellFormat cellFormat9 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)4U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)3U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true, ApplyBorder = true };
            CellFormat cellFormat10 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)3U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true, ApplyBorder = true };
            CellFormat cellFormat11 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)4U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true, ApplyBorder = true };
            CellFormat cellFormat12 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };
            CellFormat cellFormat13 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)6U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };
            CellFormat cellFormat14 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true };
            CellFormat cellFormat15 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };

            CellFormat cellFormat16 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)2U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment3 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat16.Append(alignment3);

            CellFormat cellFormat17 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)3U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment4 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat17.Append(alignment4);

            CellFormat cellFormat18 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)4U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment5 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat18.Append(alignment5);

            CellFormat cellFormat19 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)5U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment6 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat19.Append(alignment6);

            CellFormat cellFormat20 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment7 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat20.Append(alignment7);

            CellFormat cellFormat21 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)6U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment8 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat21.Append(alignment8);

            CellFormat cellFormat22 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)7U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment9 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat22.Append(alignment9);

            CellFormat cellFormat23 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)8U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment10 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat23.Append(alignment10);

            CellFormat cellFormat24 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)9U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment11 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Top };

            cellFormat24.Append(alignment11);

            CellFormat cellFormat25 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)10U, FormatId = (UInt32Value)0U, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment12 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };

            cellFormat25.Append(alignment12);

            CellFormat cellFormat26 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };
            Alignment alignment13 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };

            cellFormat26.Append(alignment13);
            CellFormat cellFormat27 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)7U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };
            CellFormat cellFormat28 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)8U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };
            CellFormat cellFormat29 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)9U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };

            CellFormat cellFormat30 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };
            Alignment alignment14 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Center, WrapText = true };

            cellFormat30.Append(alignment14);

            CellFormat cellFormat31 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)5U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };
            Alignment alignment15 = new Alignment() { WrapText = true };

            cellFormat31.Append(alignment15);

            CellFormat cellFormat32 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)6U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };
            Alignment alignment16 = new Alignment() { WrapText = true };

            cellFormat32.Append(alignment16);

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);
            cellFormats1.Append(cellFormat4);
            cellFormats1.Append(cellFormat5);
            cellFormats1.Append(cellFormat6);
            cellFormats1.Append(cellFormat7);
            cellFormats1.Append(cellFormat8);
            cellFormats1.Append(cellFormat9);
            cellFormats1.Append(cellFormat10);
            cellFormats1.Append(cellFormat11);
            cellFormats1.Append(cellFormat12);
            cellFormats1.Append(cellFormat13);
            cellFormats1.Append(cellFormat14);
            cellFormats1.Append(cellFormat15);
            cellFormats1.Append(cellFormat16);
            cellFormats1.Append(cellFormat17);
            cellFormats1.Append(cellFormat18);
            cellFormats1.Append(cellFormat19);
            cellFormats1.Append(cellFormat20);
            cellFormats1.Append(cellFormat21);
            cellFormats1.Append(cellFormat22);
            cellFormats1.Append(cellFormat23);
            cellFormats1.Append(cellFormat24);
            cellFormats1.Append(cellFormat25);
            cellFormats1.Append(cellFormat26);
            cellFormats1.Append(cellFormat27);
            cellFormats1.Append(cellFormat28);
            cellFormats1.Append(cellFormat29);
            cellFormats1.Append(cellFormat30);
            cellFormats1.Append(cellFormat31);
            cellFormats1.Append(cellFormat32);

            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
            TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleLight16" };

            StylesheetExtensionList stylesheetExtensionList1 = new StylesheetExtensionList();

            StylesheetExtension stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            X14.SlicerStyles slicerStyles1 = new X14.SlicerStyles() { DefaultSlicerStyle = "SlicerStyleLight1" };

            stylesheetExtension1.Append(slicerStyles1);

            stylesheetExtensionList1.Append(stylesheetExtension1);

            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);
            stylesheet1.Append(tableStyles1);
            stylesheet1.Append(stylesheetExtensionList1);

            workbookStylesPart1.Stylesheet = stylesheet1;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Tema de Office" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Office" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "1F497D" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "EEECE1" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "4F81BD" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "C0504D" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "9BBB59" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "8064A2" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4BACC6" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "F79646" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0000FF" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "800080" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme2 = new A.FontScheme() { Name = "Office" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Cambria" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Tahoma" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont1);
            majorFont1.Append(eastAsianFont1);
            majorFont1.Append(complexScriptFont1);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Tahoma" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont2);
            minorFont1.Append(eastAsianFont2);
            minorFont1.Append(complexScriptFont2);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme2.Append(majorFont1);
            fontScheme2.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Office" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill1.Append(schemeColor1);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint1 = new A.Tint() { Val = 50000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 300000 };

            schemeColor2.Append(tint1);
            schemeColor2.Append(saturationModulation1);

            gradientStop1.Append(schemeColor2);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 35000 };

            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint2 = new A.Tint() { Val = 37000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 300000 };

            schemeColor3.Append(tint2);
            schemeColor3.Append(saturationModulation2);

            gradientStop2.Append(schemeColor3);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint3 = new A.Tint() { Val = 15000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 350000 };

            schemeColor4.Append(tint3);
            schemeColor4.Append(saturationModulation3);

            gradientStop3.Append(schemeColor4);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 16200000, Scaled = true };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade1 = new A.Shade() { Val = 51000 };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 130000 };

            schemeColor5.Append(shade1);
            schemeColor5.Append(saturationModulation4);

            gradientStop4.Append(schemeColor5);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 80000 };

            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade2 = new A.Shade() { Val = 93000 };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 130000 };

            schemeColor6.Append(shade2);
            schemeColor6.Append(saturationModulation5);

            gradientStop5.Append(schemeColor6);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade3 = new A.Shade() { Val = 94000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 135000 };

            schemeColor7.Append(shade3);
            schemeColor7.Append(saturationModulation6);

            gradientStop6.Append(schemeColor7);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 16200000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill1);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline1 = new A.Outline() { Width = 9525, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill2 = new A.SolidFill();

            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade4 = new A.Shade() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 105000 };

            schemeColor8.Append(shade4);
            schemeColor8.Append(saturationModulation7);

            solidFill2.Append(schemeColor8);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline1.Append(solidFill2);
            outline1.Append(presetDash1);

            A.Outline outline2 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill3.Append(schemeColor9);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline2.Append(solidFill3);
            outline2.Append(presetDash2);

            A.Outline outline3 = new A.Outline() { Width = 38100, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill4.Append(schemeColor10);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline3.Append(solidFill4);
            outline3.Append(presetDash3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();

            A.EffectList effectList1 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 38000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList1.Append(outerShadow1);

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();

            A.EffectList effectList2 = new A.EffectList();

            A.OuterShadow outerShadow2 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha2 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex12.Append(alpha2);

            outerShadow2.Append(rgbColorModelHex12);

            effectList2.Append(outerShadow2);

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow3 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha3 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex13.Append(alpha3);

            outerShadow3.Append(rgbColorModelHex13);

            effectList3.Append(outerShadow3);

            A.Scene3DType scene3DType1 = new A.Scene3DType();

            A.Camera camera1 = new A.Camera() { Preset = A.PresetCameraValues.OrthographicFront };
            A.Rotation rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 0 };

            camera1.Append(rotation1);

            A.LightRig lightRig1 = new A.LightRig() { Rig = A.LightRigValues.ThreePoints, Direction = A.LightRigDirectionValues.Top };
            A.Rotation rotation2 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 };

            lightRig1.Append(rotation2);

            scene3DType1.Append(camera1);
            scene3DType1.Append(lightRig1);

            A.Shape3DType shape3DType1 = new A.Shape3DType();
            A.BevelTop bevelTop1 = new A.BevelTop() { Width = 63500L, Height = 25400L };

            shape3DType1.Append(bevelTop1);

            effectStyle3.Append(effectList3);
            effectStyle3.Append(scene3DType1);
            effectStyle3.Append(shape3DType1);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill5.Append(schemeColor11);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint4 = new A.Tint() { Val = 40000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

            schemeColor12.Append(tint4);
            schemeColor12.Append(saturationModulation8);

            gradientStop7.Append(schemeColor12);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 40000 };

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint5 = new A.Tint() { Val = 45000 };
            A.Shade shade5 = new A.Shade() { Val = 99000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 350000 };

            schemeColor13.Append(tint5);
            schemeColor13.Append(shade5);
            schemeColor13.Append(saturationModulation9);

            gradientStop8.Append(schemeColor13);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade6 = new A.Shade() { Val = 20000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 255000 };

            schemeColor14.Append(shade6);
            schemeColor14.Append(saturationModulation10);

            gradientStop9.Append(schemeColor14);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);

            A.PathGradientFill pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle1 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

            pathGradientFill1.Append(fillToRectangle1);

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(pathGradientFill1);

            A.GradientFill gradientFill4 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList4 = new A.GradientStopList();

            A.GradientStop gradientStop10 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint6 = new A.Tint() { Val = 80000 };
            A.SaturationModulation saturationModulation11 = new A.SaturationModulation() { Val = 300000 };

            schemeColor15.Append(tint6);
            schemeColor15.Append(saturationModulation11);

            gradientStop10.Append(schemeColor15);

            A.GradientStop gradientStop11 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade7 = new A.Shade() { Val = 30000 };
            A.SaturationModulation saturationModulation12 = new A.SaturationModulation() { Val = 200000 };

            schemeColor16.Append(shade7);
            schemeColor16.Append(saturationModulation12);

            gradientStop11.Append(schemeColor16);

            gradientStopList4.Append(gradientStop10);
            gradientStopList4.Append(gradientStop11);

            A.PathGradientFill pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 };

            pathGradientFill2.Append(fillToRectangle2);

            gradientFill4.Append(gradientStopList4);
            gradientFill4.Append(pathGradientFill2);

            backgroundFillStyleList1.Append(solidFill5);
            backgroundFillStyleList1.Append(gradientFill3);
            backgroundFillStyleList1.Append(gradientFill4);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme2);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);

            themePart1.Theme = theme1;
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Luis Alberto Gonzalez Galvez";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2012-05-31T18:37:08Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2012-05-31T23:25:20Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Luis Alberto Gonzalez Galvez";
            document.PackageProperties.LastPrinted = System.Xml.XmlConvert.ToDateTime("2012-05-31T23:24:25Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
        }

        #region Binary Data

        private string imagePart1Data = "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";
        private string spreadsheetPrinterSettingsPart1Data = "SABQACAATABhAHMAZQByAEoAZQB0ACAAUAA0ADUAMQA1ACAAUABDAEwANgAAAAAAAAAAAAAAAAAAAAAAAAAAAAEEAAbcAFQhQ/+ABwEAAQDqCm8IZAABAA8AWAICAAEAWAIDAAEATABlAHQAdABlAHIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAACAAAAAgAAABUBAAD/////AAAAAAAAAAAAAAAAAAAAAERJTlUiAMgGBAlQGPY9mE4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOgAAAAEAAAAAAAAAAAAAAAAAAAABAAAAAAABAAEAAAAAAAEAAAABAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAQABAAEAAQABAAEAAQABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAyAYAAFNNVEoAAAAAEAC4BkgAUAAgAEwAYQBzAGUAcgBKAGUAdAAgAFAANAA1ADEANQAgAFAAQwBMADYAAABJbnB1dEJpbgBQcmludGVyU2VsZWN0AFJFU0RMTABVbmlyZXNETEwAUmVzb2x1dGlvbgA2MDBkcGkAT3JpZW50YXRpb24AUE9SVFJBSVQASFBPcmllbnRSb3RhdGUxODAARmFsc2UARHVwbGV4AE5PTkUAUGFwZXJTaXplAExFVFRFUgBNZWRpYVR5cGUAQXV0bwBDb2xsYXRlAE9OAE91dHB1dEJpbgBBdXRvAEhQSW1hZ2VTaGlmdABPZmYASFBBdXRvRHVwbGV4U2NhbGluZwBUcnVlAENvbG9yTW9kZQAyNGJwcABUZXh0QXNCbGFjawBGYWxzZQBUVEFzQml0bWFwc1NldHRpbmcAVFRNb2RlT3V0bGluZQBSRVRDaG9pY2UAVHJ1ZQBIUEJhY2tTaWRlUHJpbnRpbmcARmFsc2UASlBFR0VuYWJsZQBCZXN0AFNtb290aGluZwBUcnVlAFByaW50UXVhbGl0eUdyb3VwAFBRR3JvdXBfMQBIUENvbG9yTW9kZQBNT05PQ0hST01FX01PREUASFBQRExUeXBlAFBETF9QQ0w2AEhQUEpMRW5jb2RpbmcAVVRGOABIUEpvYkFjY291bnRpbmcASFBKT0JBQ0NUX0pPQkFDTlQASFBCb3JuT25EYXRlAEhQQk9EAEhQSm9iQnlKb2JPdmVycmlkZQBKQkpPAEhQWE1MRmlsZVVzZWQAaHBtY3BhcDYueG1sAEhQU3RhcGxpbmdPcHBvc2VkAEZhbHNlAEhQUENMNlBhc3NUaHJvdWdoAFRydWUASFBTbWFydER1cGxleFNpbmdsZVBhZ2VKb2IAVHJ1ZQBIUFNtYXJ0RHVwbGV4T2RkUGFnZUpvYgBUcnVlAEhQTWFudWFsRHVwbGV4RGlhbG9nSXRlbXMASW5zdHJ1Y3Rpb25JRF8wMV9GQUNFRE9XTi1OT1JPVEFURQBIUE1hbnVhbEZlZWRPcmllbnRhdGlvbgBGQUNFRE9XTgBIUE91dHB1dEJpbk9yaWVudGF0aW9uAEZBQ0VET1dOAFN0YXBsaW5nAE5vbmUASFBNYW51YWxEdXBsZXhEaWFsb2dNb2RlbABNb2RlbGVzcwBIUE1hbnVhbER1cGxleFBhZ2VPcmRlcgBFdmVuUGFnZXNGaXJzdABIUE1hcE1hbnVhbEZlZWRUb1RyYXkxAFRydWUASFBQcmludE9uQm90aFNpZGVzTWFudWFsbHkARmFsc2UASFBTdHJhaWdodFBhcGVyUGF0aABGYWxzZQBIUFNlbmRQSkxVc2FnZUNtZABDVVJJAEhQQ292ZXJzAE90aGVyX1BhZ2VzAEZyb250X0NvdmVyX2Zyb21fRmVlZGVyX0lucHV0QmluAE5vbmUAQmFja19Db3Zlcl9mcm9tX0ZlZWRlcl9JbnB1dEJpbgBOb25lAEpSQ29uc3RyYWludHMASlJDSERQYXJ0aWFsAEpSSERJbnN0YWxsZWQASlJIRE9mZgBKUkhETm90SW5zdGFsbGVkAEpSSERPZmYASFBDb25zdW1lckN1c3RvbVBhcGVyAFRydWUAUFNBbGlnbm1lbnRGaWxlAEhQWkxTd243AEhQU21hcnRIdWJfT25saW5lZGlhZ25vc3RpY3Rvb2xzAFRSVUUASFBTbWFydEh1Yl9TdXBwb3J0YW5kdHJvdWJsZXNob290aW5nAFRSVUUASFBTbWFydEh1Yl9Qcm9kdWN0bWFudWFscwBUUlVFAEhQU21hcnRIdWJfQ2hlY2tmb3Jkcml2ZXJ1cGRhdGVzAFRSVUUASFBTbWFydEh1Yl9Db2xvcnByaW50aW5nYWNjZXNzdXNhZ2UAVFJVRQBIUFNtYXJ0SHViX09yZGVyc3VwcGxpZXMAVFJVRQBIUFNtYXJ0SHViX1Nob3dtZWhvdwBUUlVFAFBTU2VydmljZXNfUHJpbnRjb2xvcnVzYWdlam9ibG9nAFRSVUUASFBTbWFydEh1YgBJbmV0X1NJRF8yNjNfQklEXzUxNF9ISURfMjY1AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABQGAAASVVQSBAAEQAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAEAZAABAAEAAwACAAAAAgAAAAIAAABMAGUAdAB0AGUAcgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAOoKbwgAAP///////////////wEAAAAGAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAWwBuAG8AbgBlAF0AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIABbAG4AbwBuAGUAXQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADQAAABQAAAAAAAAAAEAAAAAAAAAwMDAAAAAAADAwMAAAAAAAAAAAAAAAAAAAAAAAAEAAAABAAAAZAAAAAAAAAAAAAAAAAAAAAAAgD8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEwAQQBHAE8ATgBaAEEATABFAFoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAAAAAAAAAAAAAAAEAAAAPAAAAFQEAAAAAAAAPAAAAFQEAAAAAAAD/////AAAAAAAAAAAPAAAAFQEAAA8AAAAVAQAAAAAAAAAAAAAAAAAAAAAAADQIAAA0CAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZAAAAAEAAABQAHIAaQBuAHQAIABkAHIAaQB2AGUAcgAgAGgAbwBzAHQAIABmAG8AcgAgADMAMgBiAGkAdAAgAGEAcABwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAP////9zcGx3b3c2NC5leGUAAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAAEAAAABAAAAAQAAAA8AAAAVAQAADwAAABUBAAAPAAAAFQEAAA8AAAAVAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAEAAAAAABDADoAXABXAGkAbgBkAG8AdwBzAFwAcwBwAGwAdwBvAHcANgA0AC4AZQB4AGUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";

        private System.IO.Stream GetBinaryDataStream(string base64String)
        {
            return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
        }

        #endregion



    }
}

