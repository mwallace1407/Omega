<%@ Page Title="Reporte General de Aplicaciones" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="RptGeneralAplicaciones.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptGeneralAplicaciones" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 465px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: REPORTE PARA EL INVENTARIO DE APLICACIONES :.
            </div>
            <br />
            <div style="width: 830px; height: 105px;">
                <div style="width: 410px; height: 100px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Estados:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklEstados" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 100px; float: right;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipos:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chklTipos" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div style="width: 410px; height: 30px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Es productiva:
                </div>
                <div style="width: 275px; float: right; text-align: center;">
                    <asp:DropDownList ID="ddlEsProductiva" runat="server" Width="275px">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div style="width: 410px; height: 30px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Está en TFS:
                </div>
                <div style="width: 275px; float: right; text-align: center;">
                    <asp:DropDownList ID="ddlTFS" runat="server" Width="275px">
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