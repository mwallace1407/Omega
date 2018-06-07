#region Importaciones

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using a = DocumentFormat.OpenXml.Drawing;
using ap = DocumentFormat.OpenXml.ExtendedProperties;
using vt = DocumentFormat.OpenXml.VariantTypes;

#endregion Importaciones

#region Comentarios

//-- =============================================
//-- Autor:		            Julio Cesar Barron Galindo
//-- Fecha Modificacion:	21/06/2012
//-- =============================================

#endregion Comentarios

namespace InventarioHSC.BusinessLayer
{
    public class Util_Genera_Excel
    {
        public void CreatePackage(string filePath, string NombreHoja)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                AddParts(package, NombreHoja);
            }
        }

        private void AddParts(SpreadsheetDocument parent, string NombreHoja)
        {
            var extendedFilePropertiesPart1 = parent.AddNewPart<ExtendedFilePropertiesPart>("rId3");

            var coreFilePropertiesPart1 = parent.AddNewPart<CoreFilePropertiesPart>("rId2");
            var workbookPart1 = parent.AddWorkbookPart();
            var workbookStylesPart1 = workbookPart1.AddNewPart<WorkbookStylesPart>("rId3");
            var themePart1 = workbookPart1.AddNewPart<ThemePart>("rId2");
            var worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>("rId1");

            GenerateExtendedFilePropertiesPart1(NombreHoja).Save(extendedFilePropertiesPart1);
            GenerateWorkbookPart1(NombreHoja, workbookPart1.GetIdOfPart(worksheetPart1)).Save(workbookPart1);
            GenerateCoreFilePropertiesPart1(coreFilePropertiesPart1);
            GenerateWorkbookStylesPart1().Save(workbookStylesPart1);
            GenerateThemePart1().Save(themePart1);
            GenerateWorksheetPart1().Save(worksheetPart1);
        }

        private ap.Properties GenerateExtendedFilePropertiesPart1(string NombreHoja)
        {
            var element =
                new ap.Properties(
                    new ap.Application("Microsoft Excel"),
                    new ap.DocumentSecurity("0"),
                    new ap.ScaleCrop("false"),
                    new ap.HeadingPairs(
                        new vt.VTVector(
                            new vt.Variant(
                                new vt.VTLPSTR("Hojas de cálculo")),
                            new vt.Variant(
                                new vt.VTInt32("1"))
                        ) { BaseType = vt.VectorBaseValues.Variant, Size = (UInt32Value)2U }),
                    new ap.TitlesOfParts(
                        new vt.VTVector(
                            new vt.VTLPSTR(NombreHoja)
                        ) { BaseType = vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U }),
                    new ap.LinksUpToDate("false"),
                    new ap.SharedDocument("false"),
                    new ap.HyperlinksChanged("false"));
            return element;
        }

        public void GenerateCoreFilePropertiesPart1(OpenXmlPart part)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(part.GetStream());
            writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n<cp:coreProperties xmlns:cp=\"http://schemas.openxmlformats.org/package/2006/metadata/core-properties\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:dcterms=\"http://purl.org/dc/terms/\" xmlns:dcmitype=\"http://purl.org/dc/dcmitype/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><dc:creator>Horacio Santoyo Liahut</dc:creator><cp:lastModifiedBy>Horacio Santoyo Liahut</cp:lastModifiedBy><dcterms:created xsi:type=\"dcterms:W3CDTF\">2009-09-11T18:43:48Z</dcterms:created><dcterms:modified xsi:type=\"dcterms:W3CDTF\">2009-09-11T18:44:25Z</dcterms:modified></cp:coreProperties>");
            writer.Flush();
            writer.Close();
        }

        private Workbook GenerateWorkbookPart1(string NombreHoja, string id)
        {
            var element =
                new Workbook(
                    new FileVersion() { ApplicationName = "xl", LastEdited = "4", LowestEdited = "4", BuildVersion = "4506" },
                    new WorkbookProperties() { DefaultThemeVersion = (UInt32Value)124226U },
                    new BookViews(
                        new WorkbookView() { XWindow = 240, YWindow = 30, WindowWidth = (UInt32Value)20055U, WindowHeight = (UInt32Value)8160U }),
                    new Sheets(
                        new Sheet() { Name = NombreHoja, SheetId = (UInt32Value)1U, Id = id }),
                    new CalculationProperties() { CalculationId = (UInt32Value)125725U });
            return element;
        }

        private Stylesheet GenerateWorkbookStylesPart1()
        {
            var element =
                new Stylesheet(
                    new Fonts(
                        new Font(
                            new FontSize() { Val = 9D },
                            new Color() { Theme = (UInt32Value)1U },
                            new FontName() { Val = "Arial" },
                            new FontFamily() { Val = 2 },
                            new FontScheme() { Val = FontSchemeValues.Minor })
                    ) { Count = (UInt32Value)1U },
                    new Fills(
                        new Fill(
                            new PatternFill() { PatternType = PatternValues.None }),
                        new Fill(
                            new PatternFill() { PatternType = PatternValues.Gray125 })
                    ) { Count = (UInt32Value)2U },
                    new Borders(
                        new Border(
                            new LeftBorder(),
                            new RightBorder(),
                            new TopBorder(),
                            new BottomBorder(),
                            new DiagonalBorder())
                    ) { Count = (UInt32Value)1U },
                    new CellStyleFormats(
                        new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U }
                    ) { Count = (UInt32Value)1U },
                    new CellFormats(
                        new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U }
                    ) { Count = (UInt32Value)1U },
                    new CellStyles(
                        new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U }
                    ) { Count = (UInt32Value)1U },
                    new DifferentialFormats() { Count = (UInt32Value)0U },
                    new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium9", DefaultPivotStyle = "PivotStyleLight16" });
            return element;
        }

        private a.Theme GenerateThemePart1()
        {
            var element =
                new a.Theme(
                    new a.ThemeElements(
                        new a.ColorScheme(
                            new a.Dark1Color(
                                new a.SystemColor() { Val = a.SystemColorValues.WindowText, LastColor = "000000" }),
                            new a.Light1Color(
                                new a.SystemColor() { Val = a.SystemColorValues.Window, LastColor = "FFFFFF" }),
                            new a.Dark2Color(
                                new a.RgbColorModelHex() { Val = "1F497D" }),
                            new a.Light2Color(
                                new a.RgbColorModelHex() { Val = "EEECE1" }),
                            new a.Accent1Color(
                                new a.RgbColorModelHex() { Val = "4F81BD" }),
                            new a.Accent2Color(
                                new a.RgbColorModelHex() { Val = "C0504D" }),
                            new a.Accent3Color(
                                new a.RgbColorModelHex() { Val = "9BBB59" }),
                            new a.Accent4Color(
                                new a.RgbColorModelHex() { Val = "8064A2" }),
                            new a.Accent5Color(
                                new a.RgbColorModelHex() { Val = "4BACC6" }),
                            new a.Accent6Color(
                                new a.RgbColorModelHex() { Val = "F79646" }),
                            new a.Hyperlink(
                                new a.RgbColorModelHex() { Val = "0000FF" }),
                            new a.FollowedHyperlinkColor(
                                new a.RgbColorModelHex() { Val = "800080" })
                        ) { Name = "Office" },
                        new a.FontScheme(
                            new a.MajorFont(
                                new a.LatinFont() { Typeface = "Cambria" },
                                new a.EastAsianFont() { Typeface = "" },
                                new a.ComplexScriptFont() { Typeface = "" },
                                new a.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" },
                                new a.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" },
                                new a.SupplementalFont() { Script = "Hans", Typeface = "宋体" },
                                new a.SupplementalFont() { Script = "Hant", Typeface = "新細明體" },
                                new a.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" },
                                new a.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" },
                                new a.SupplementalFont() { Script = "Thai", Typeface = "Tahoma" },
                                new a.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" },
                                new a.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" },
                                new a.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" },
                                new a.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" },
                                new a.SupplementalFont() { Script = "Knda", Typeface = "Tunga" },
                                new a.SupplementalFont() { Script = "Guru", Typeface = "Raavi" },
                                new a.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" },
                                new a.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" },
                                new a.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" },
                                new a.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" },
                                new a.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" },
                                new a.SupplementalFont() { Script = "Deva", Typeface = "Mangal" },
                                new a.SupplementalFont() { Script = "Telu", Typeface = "Gautami" },
                                new a.SupplementalFont() { Script = "Taml", Typeface = "Latha" },
                                new a.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" },
                                new a.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" },
                                new a.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" },
                                new a.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" },
                                new a.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" },
                                new a.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" },
                                new a.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" },
                                new a.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" }),
                            new a.MinorFont(
                                new a.LatinFont() { Typeface = "Calibri" },
                                new a.EastAsianFont() { Typeface = "" },
                                new a.ComplexScriptFont() { Typeface = "" },
                                new a.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" },
                                new a.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" },
                                new a.SupplementalFont() { Script = "Hans", Typeface = "宋体" },
                                new a.SupplementalFont() { Script = "Hant", Typeface = "新細明體" },
                                new a.SupplementalFont() { Script = "Arab", Typeface = "Arial" },
                                new a.SupplementalFont() { Script = "Hebr", Typeface = "Arial" },
                                new a.SupplementalFont() { Script = "Thai", Typeface = "Tahoma" },
                                new a.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" },
                                new a.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" },
                                new a.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" },
                                new a.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" },
                                new a.SupplementalFont() { Script = "Knda", Typeface = "Tunga" },
                                new a.SupplementalFont() { Script = "Guru", Typeface = "Raavi" },
                                new a.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" },
                                new a.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" },
                                new a.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" },
                                new a.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" },
                                new a.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" },
                                new a.SupplementalFont() { Script = "Deva", Typeface = "Mangal" },
                                new a.SupplementalFont() { Script = "Telu", Typeface = "Gautami" },
                                new a.SupplementalFont() { Script = "Taml", Typeface = "Latha" },
                                new a.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" },
                                new a.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" },
                                new a.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" },
                                new a.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" },
                                new a.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" },
                                new a.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" },
                                new a.SupplementalFont() { Script = "Viet", Typeface = "Arial" },
                                new a.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" })
                        ) { Name = "Office" },
                        new a.FormatScheme(
                            new a.FillStyleList(
                                new a.SolidFill(
                                    new a.SchemeColor() { Val = a.SchemeColorValues.PhColor }),
                                new a.GradientFill(
                                    new a.GradientStopList(
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Tint() { Val = 50000 },
                                                new a.SaturationModulation() { Val = 300000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 0 },
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Tint() { Val = 37000 },
                                                new a.SaturationModulation() { Val = 300000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 35000 },
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Tint() { Val = 15000 },
                                                new a.SaturationModulation() { Val = 350000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 100000 }),
                                    new a.LinearGradientFill() { Angle = 16200000, Scaled = true }
                                ) { RotateWithShape = true },
                                new a.GradientFill(
                                    new a.GradientStopList(
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Shade() { Val = 51000 },
                                                new a.SaturationModulation() { Val = 130000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 0 },
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Shade() { Val = 93000 },
                                                new a.SaturationModulation() { Val = 130000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 80000 },
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Shade() { Val = 94000 },
                                                new a.SaturationModulation() { Val = 135000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 100000 }),
                                    new a.LinearGradientFill() { Angle = 16200000, Scaled = false }
                                ) { RotateWithShape = true }),
                            new a.LineStyleList(
                                new a.Outline(
                                    new a.SolidFill(
                                        new a.SchemeColor(
                                            new a.Shade() { Val = 95000 },
                                            new a.SaturationModulation() { Val = 105000 }
                                        ) { Val = a.SchemeColorValues.PhColor }),
                                    new a.PresetDash() { Val = a.PresetLineDashValues.Solid }
                                ) { Width = 9525, CapType = a.LineCapValues.Flat, CompoundLineType = a.CompoundLineValues.Single, Alignment = a.PenAlignmentValues.Center },
                                new a.Outline(
                                    new a.SolidFill(
                                        new a.SchemeColor() { Val = a.SchemeColorValues.PhColor }),
                                    new a.PresetDash() { Val = a.PresetLineDashValues.Solid }
                                ) { Width = 25400, CapType = a.LineCapValues.Flat, CompoundLineType = a.CompoundLineValues.Single, Alignment = a.PenAlignmentValues.Center },
                                new a.Outline(
                                    new a.SolidFill(
                                        new a.SchemeColor() { Val = a.SchemeColorValues.PhColor }),
                                    new a.PresetDash() { Val = a.PresetLineDashValues.Solid }
                                ) { Width = 38100, CapType = a.LineCapValues.Flat, CompoundLineType = a.CompoundLineValues.Single, Alignment = a.PenAlignmentValues.Center }),
                            new a.EffectStyleList(
                                new a.EffectStyle(
                                    new a.EffectList(
                                        new a.OuterShadow(
                                            new a.RgbColorModelHex(
                                                new a.Alpha() { Val = 38000 }
                                            ) { Val = "000000" }
                                        ) { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false })),
                                new a.EffectStyle(
                                    new a.EffectList(
                                        new a.OuterShadow(
                                            new a.RgbColorModelHex(
                                                new a.Alpha() { Val = 35000 }
                                            ) { Val = "000000" }
                                        ) { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false })),
                                new a.EffectStyle(
                                    new a.EffectList(
                                        new a.OuterShadow(
                                            new a.RgbColorModelHex(
                                                new a.Alpha() { Val = 35000 }
                                            ) { Val = "000000" }
                                        ) { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false }),
                                        new a.LightRig(
                                            new a.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 }
                                        ) { Rig = a.LightRigValues.ThreePoints, Direction = a.LightRigDirectionValues.Top })),
                            new a.BackgroundFillStyleList(
                                new a.SolidFill(
                                    new a.SchemeColor() { Val = a.SchemeColorValues.PhColor }),
                                new a.GradientFill(
                                    new a.GradientStopList(
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Tint() { Val = 40000 },
                                                new a.SaturationModulation() { Val = 350000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 0 },
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Tint() { Val = 45000 },
                                                new a.Shade() { Val = 99000 },
                                                new a.SaturationModulation() { Val = 350000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 40000 },
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Shade() { Val = 20000 },
                                                new a.SaturationModulation() { Val = 255000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 100000 }),
                                    new a.PathGradientFill(
                                        new a.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 }
                                    ) { Path = a.PathShadeValues.Circle }
                                ) { RotateWithShape = true },
                                new a.GradientFill(
                                    new a.GradientStopList(
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Tint() { Val = 80000 },
                                                new a.SaturationModulation() { Val = 300000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 0 },
                                        new a.GradientStop(
                                            new a.SchemeColor(
                                                new a.Shade() { Val = 30000 },
                                                new a.SaturationModulation() { Val = 200000 }
                                            ) { Val = a.SchemeColorValues.PhColor }
                                        ) { Position = 100000 }),
                                    new a.PathGradientFill(
                                        new a.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 }
                                    ) { Path = a.PathShadeValues.Circle }
                                ) { RotateWithShape = true })
                        ) { Name = "Office" }),
                    new a.ObjectDefaults(),
                    new a.ExtraColorSchemeList()
                ) { Name = "Tema de Office" };
            return element;
        }

        private Worksheet GenerateWorksheetPart1()
        {
            var element =
                new Worksheet(
                    new SheetDimension() { Reference = "A1" },
                    new SheetViews(
                        new SheetView() { TabSelected = true, WorkbookViewId = (UInt32Value)0U }),
                    new SheetFormatProperties() { BaseColumnWidth = (UInt32Value)10U, DefaultRowHeight = 15D },
                    new SheetData(),
                    new PageMargins() { Left = 0.7D, Right = 0.7D, Top = 0.75D, Bottom = 0.75D, Header = 0.3D, Footer = 0.3D });
            return element;
        }
    }
}