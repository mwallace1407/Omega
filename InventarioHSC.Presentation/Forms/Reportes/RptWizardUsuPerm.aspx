<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptWizardUsuPerm.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptWizardUsuPerm" %>

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
                Administrar permisos de usuario para ejecutar reportes</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:Accordion ID="acc01" runat="server" ContentCssClass="AcordionRoundedOpacity"
                    FadeTransitions="True" HeaderCssClass="AcordionRoundedOpacityTitle" Width="780px">
                    <Panes>
                        <asp:AccordionPane ID="accPnl01" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                Paso 1: Buscar usuario</Header>
                            <Content>
                                <asp:Panel ID="pnlBusqueda" runat="server" DefaultButton="btnBuscar">
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
                                    <asp:Panel ID="pnlDatos" runat="server" Visible="False">
                                        <asp:GridView ID="grdDatos" runat="server" Width="660px" AutoGenerateColumns="False"
                                            ForeColor="#333333" GridLines="None" OnRowDataBound="grdDatos_RowDataBound">
                                            <Columns>
                                                <asp:BoundField HeaderText="" DataField="Id">
                                                    <HeaderStyle Width="1px" />
                                                    <ItemStyle Width="1px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="" DataField="Autorizado">
                                                    <HeaderStyle Width="1px" />
                                                    <ItemStyle Width="1px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Conexión" DataField="Conexion" HtmlEncode="False" HtmlEncodeFormatString="False"
                                                    ConvertEmptyStringToNull="False">
                                                    <HeaderStyle Width="120px" />
                                                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Reporte" DataField="Reporte" HtmlEncode="False" HtmlEncodeFormatString="False"
                                                    ConvertEmptyStringToNull="False">
                                                    <HeaderStyle Width="480px" />
                                                    <ItemStyle Width="480px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Autorizado">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkAutorizado" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <SelectedRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle Width="120px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                                            </HeaderStyle>
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle CssClass="GridItem" />
                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                        </asp:GridView>
                                    </asp:Panel>
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