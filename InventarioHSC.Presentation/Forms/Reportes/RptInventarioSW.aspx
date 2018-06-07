<%@ Page Title="Reporte para el inventario de software" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="RptInventarioSW.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptInventarioSW" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 765px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: REPORTE PARA EL INVENTARIO DE SOFTWARE :.
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Empresas:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklEmpresas" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Grupos:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklGrupos" runat="server" Width="250">
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
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Versiones:
                        <br />
                        <label style="font-size: xx-small">
                            (Separadas por pipeline "|")
                        </label>
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtVersiones" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="4000"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        No. de parte:
                        <br />
                        <label style="font-size: xx-small">
                            (Separados por pipeline "|")
                        </label>
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtNoParte" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="4000"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Llaves:
                        <br />
                        <label style="font-size: xx-small">
                            (Separadas por pipeline "|")
                        </label>
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtLlaves" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="4000"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                </div>
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Descripción de SW:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtDescripcionSW" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="500"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Observaciones:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:TextBox ID="txtObservaciones" runat="server" Width="250" Height="100" TextMode="MultiLine"
                                MaxLength="500"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div style="width: 410px; height: 30px;">
                <div style="width: 125px; float: left; text-align: left;">
                    En existencia:
                </div>
                <div style="width: 275px; float: right; text-align: center;">
                    <asp:DropDownList ID="ddlExistencia" runat="server" Width="275px">
                    </asp:DropDownList>
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