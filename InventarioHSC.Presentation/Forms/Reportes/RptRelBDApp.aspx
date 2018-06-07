<%@ Page Title="Reporte de aplicaciones ligadas a una BD" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="RptRelBDApp.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptRelBDApp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                .: REPORTE DE APLICACIONES LIGADAS A UNA BD :.
            </div>
            <br />
            <div style="width: 830px; height: 155px;">
                <div style="width: 410px; height: 150px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Bases de datos:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 150px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chkBD" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 150px; float: right;">
                </div>
            </div>
            <br />
            <div style="width: 180px; text-align: left;">
                <asp:GridView ID="grdDatos" runat="server" Width="300px" AutoGenerateColumns="False"
                    OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="Concepto" DataField="Concepto">
                            <HeaderStyle Width="230px" />
                            <ItemStyle Width="230px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Archivo">
                            <EditItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkRuta" runat="server" Text="Descargar" CssClass="HyperLink"
                                    Target="_blank">Descargar</asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle Width="70px" />
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Ruta" HeaderText="Ruta" HeaderStyle-CssClass="GridColumnHide"
                            ItemStyle-CssClass="GridColumnHide">
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle Width="120px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                    </HeaderStyle>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle CssClass="GridItem" />
                    <AlternatingRowStyle CssClass="GridAltItem" />
                </asp:GridView>
            </div>
            <br />
            <asp:Button ID="btnProcesar" runat="server" Text="Generar Reporte" CssClass="boton"
                OnClick="btnProcesar_Click" />
            <br />
        </div>
    </div>
</asp:Content>