<%@ Page Title="Reporte para el inventario de equipos" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="RptInventarioEquipos.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptInventarioEquipos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 700px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: REPORTE PARA EL INVENTARIO DE EQUIPOS :.
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipos de equipo:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklTipoEquipo" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Marcas:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklMarca" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Ubicaciones:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklUbicacion" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Usuarios:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklUsuarios" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Estado:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chkEstados" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Modelos:
                        <br />
                        <label style="font-size: xx-small">
                            (Separados por pipeline "|")
                        </label>
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtModelos" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="4000"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        No. de serie:
                        <br />
                        <label style="font-size: xx-small">
                            (Separados por pipeline "|")
                        </label>
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtNoSerie" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="4000"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Responsivas:
                        <br />
                        <label style="font-size: xx-small">
                            (Separadas por pipeline "|")
                        </label>
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtResponsivas" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="4000"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div style="width: 410px; height: 30px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Fecha de movimiento inicial:
                </div>
                <div style="width: 275px; float: right; text-align: center;">
                    <asp:TextBox ID="txtFechaIni" runat="server" Width="275"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtFechaIni_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaIni">
                    </asp:MaskedEditExtender>
                    <asp:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" Enabled="True"
                        Format="dd/MM/yyyy" TargetControlID="txtFechaIni" TodaysDateFormat="dd/MM/yyyy"
                        PopupPosition="BottomRight">
                    </asp:CalendarExtender>
                </div>
            </div>
            <br />
            <div style="width: 410px; height: 30px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Fecha de movimiento final:
                </div>
                <div style="width: 275px; float: right; text-align: center;">
                    <asp:TextBox ID="txtFechaFin" runat="server" Width="275"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtFechaFin_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaFin">
                    </asp:MaskedEditExtender>
                    <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" Enabled="True"
                        Format="dd/MM/yyyy" TargetControlID="txtFechaFin" TodaysDateFormat="dd/MM/yyyy"
                        PopupPosition="BottomRight">
                    </asp:CalendarExtender>
                </div>
            </div>
            <br />
            <asp:Button ID="btnProcesar" runat="server" Text="Generar Reporte" CssClass="boton"
                OnClick="btnProcesar_Click" />
            <br />
            <asp:Panel ID="pnlGrid" runat="server" Visible="False">
                <asp:GridView ID="grdDatos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
    <uc1:uscMsgBox ID="uscMsgBox1" runat="server" />
</asp:Content>
