<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="PermisosUsuario.aspx.cs" Inherits="InventarioHSC.Forms.Catalogos.PermisosUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 450px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Administrar permisos de usuario</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:Accordion ID="acc01" runat="server" ContentCssClass="AcordionRoundedOpacity"
                    FadeTransitions="True" HeaderCssClass="AcordionRoundedOpacityTitle" Width="780px">
                    <Panes>
                        <asp:AccordionPane ID="accPnl01" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                Paso 1: Buscar usuario</Header>
                            <Content>
                                <asp:Panel ID="pnlBusqueda" runat="server">
                                    <asp:TextBox ID="txtUsuario" runat="server" autocomplete="off" MaxLength="15"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="boton" OnClick="btnBuscar_Click" />
                                    <br />
                                    <br />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="accPnl02" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                Paso 2: Asignar permisos</Header>
                            <Content>
                                <div style="width: 780px; overflow: auto; height: 275px;">
                                    <asp:DropDownList ID="cboUsuarios" runat="server" AutoPostBack="true" Visible="False"
                                        OnSelectedIndexChanged="cboUsuarios_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:GridView ID="grdDatos" runat="server" Width="760px" CssClass="Grid" AutoGenerateColumns="False"
                                        OnRowDataBound="grdDatos_RowDataBound">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Menu_Id">
                                                <HeaderStyle />
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Descripción" DataField="Menu_Descripcion">
                                                <HeaderStyle Width="500px" />
                                                <ItemStyle Width="500px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Auto" DataField="PerW_Autorizado">
                                                <HeaderStyle />
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Autorizado">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAutorizado" runat="server" ClientIDMode="Predictable" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="80px" />
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Menú" DataField="Menu_Texto">
                                                <HeaderStyle Width="160px" />
                                                <ItemStyle Width="160px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle CssClass="GridHeaderScroll" Width="760"></HeaderStyle>
                                        <RowStyle CssClass="GridItem" />
                                        <AlternatingRowStyle CssClass="GridAltItem" />
                                    </asp:GridView>
                                    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="ControlesValidadoresAlt"></asp:Label>
                                </div>
                            </Content>
                        </asp:AccordionPane>
                    </Panes>
                </asp:Accordion>
                <div style="float: left; width: 780px; height: 1px; text-align: center;">
                    <br />
                    <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click"
                        Enabled="False" />&nbsp&nbsp
                        <br />
                        <asp:Button ID="btnNueva" runat="server" Text="Nueva búsqueda" CssClass="boton" OnClick="btnNueva_Click"
                        Enabled="False" />&nbsp&nbsp
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
