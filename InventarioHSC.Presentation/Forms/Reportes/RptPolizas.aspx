<%@ Page Title="Reporte de pólizas" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="RptPolizas.aspx.cs"
    Inherits="InventarioHSC.Forms.Reportes.RptPolizas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 470px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: REPORTE DE PÓLIZAS :.
            </div>
            <br />
            <asp:UpdatePanel ID="UPnl" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlAnual" runat="server" Visible="True">
                        <div style="width: 180px; text-align: left;">
                            Reporte con filtro por año:
                            <br />
                            <br />
                            <asp:GridView ID="grdDatos" runat="server" Width="120px" AutoGenerateColumns="False"
                                OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField HeaderText="Año" DataField="Anio">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
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
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
