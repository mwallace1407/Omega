<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="DocumentosUsuario.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.DocumentosUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <meta http-equiv="refresh" content="60" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ToolkitScriptManager>
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <br />
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 510px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Administrador de documentos
            </div>
            <div style="width: 800px; padding-top: 5px;">
                <div style="padding-left: 10px; width: 680px; float: left; text-align: left;">
                    <asp:Label ID="lblDocVigencia" runat="server" Text=""></asp:Label>
                </div>
                <div style="padding-right: 10px; width: 100px; float: right; text-align: right;">
                    <asp:ImageButton ID="btnRefresh" runat="server" Height="20px" ImageUrl="~/App_Themes/Imagenes/Refresh.png"
                        OnClick="btnRefresh_Click" ToolTip="Recargar datos" Width="20px" />
                </div>
            </div>
            <br />
            <br />
            <asp:Panel ID="pnlDatos" runat="server" Visible="True">
                <div style="width: 780px; text-align: left; padding-left: 10px;">
                    <asp:TabContainer ID="tab01" runat="server" Width="780" ScrollBars="Vertical" Height="400"
                        CssClass="Tab">
                        <asp:TabPanel ID="tpnlFinalizados" runat="server" HeaderText="Finalizados">
                            <ContentTemplate>
                                <div style="width: 750px; text-align: left; padding-left: 10px; padding-top: 10px;">
                                    <asp:Label ID="lblFinalizados" runat="server" Text=""></asp:Label><br />
                                    <asp:GridView ID="grdDatosFinalizados" runat="server" Width="730px" AutoGenerateColumns="False"
                                        OnRowDataBound="grdDatosFinalizados_RowDataBound" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Archivo" ItemStyle-HorizontalAlign="Left">
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
                                            <asp:BoundField HeaderText="Tipo" DataField="Tipo" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="160px" />
                                                <ItemStyle Width="160px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha creación" DataField="Fecha" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Archivo" HeaderText="Ruta" HeaderStyle-CssClass="GridColumnHide"
                                                ItemStyle-CssClass="GridColumnHide">
                                                <HeaderStyle Width="1px" />
                                                <ItemStyle Width="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="374px" />
                                                <ItemStyle Width="374px" />
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
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="tpnlPendientes" runat="server" HeaderText="Pendientes">
                            <ContentTemplate>
                                <div style="width: 750px; text-align: left; padding-left: 10px; padding-top: 10px;">
                                    <asp:Label ID="lblPendientes" runat="server" Text=""></asp:Label><br />
                                    <asp:GridView ID="grdDatosPendientes" runat="server" Width="730px" AutoGenerateColumns="False"
                                        ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:BoundField HeaderText="Tipo" DataField="Tipo" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="160px" />
                                                <ItemStyle Width="160px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha creación" DataField="Fecha" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Archivo" DataField="Archivo" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="230px" />
                                                <ItemStyle Width="230px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="215px" />
                                                <ItemStyle Width="215px" />
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
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="tpnlEliminados" runat="server" HeaderText="Eliminados">
                            <ContentTemplate>
                                <div style="width: 750px; text-align: left; padding-left: 10px; padding-top: 10px;">
                                    <asp:Label ID="lblEliminados" runat="server" Text=""></asp:Label><br />
                                    <asp:GridView ID="grdDatosEliminados" runat="server" Width="730px" AutoGenerateColumns="False"
                                        ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:BoundField HeaderText="Tipo" DataField="Tipo" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="160px" />
                                                <ItemStyle Width="160px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha creación" DataField="Fecha" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Archivo" DataField="Archivo" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="230px" />
                                                <ItemStyle Width="230px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="215px" />
                                                <ItemStyle Width="215px" />
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
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </div>
            </asp:Panel>
        </div>
    </div>
    <br />
</asp:Content>