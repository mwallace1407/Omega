<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="BuscarDocumento.aspx.cs" Inherits="InventarioHSC.Forms.MaxImage.BuscarDocumento" %>

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
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 350px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Buscar documentos</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipo de filtro:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlFiltro" runat="server" Width="202" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlFiltro" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlFiltro" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlFiltro" runat="server" Enabled="True" TargetControlID="rfv_ddlFiltro">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        <asp:Label ID="lblFiltro" runat="server" Text="Filtro:"></asp:Label>
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtFiltro" runat="server" Width="200" MaxLength="6" autocomplete="off"></asp:TextBox>
                        <asp:Label ID="lblExtra" runat="server" Text=""></asp:Label>
                        <asp:FilteredTextBoxExtender ID="ftxt_txtFiltro" runat="server" Enabled="True" FilterType="Numbers"
                            TargetControlID="txtFiltro">
                        </asp:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfv_txtFiltro" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtFiltro" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtFiltro" runat="server" Enabled="True" TargetControlID="rfv_txtFiltro">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 780px; height: 1px; text-align: center;">
                    <asp:Button ID="btnProcesar" runat="server" Text="Buscar" CssClass="boton" OnClick="btnProcesar_Click" />&nbsp&nbsp
                </div>
                <br />
                <br />
                <div style="width: 780px; overflow: auto; height: 175px; text-align: center;">
                    <asp:Label ID="lblNoRegs" runat="server" Text="No se encontraron registros" Font-Bold="True"
                        Visible="False"></asp:Label>
                    <br />
                    <asp:GridView ID="grdDatos" runat="server" Width="550px" CssClass="Grid" AutoGenerateColumns="False"
                        OnRowDataBound="grdDatos_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Crédito" DataField="Numero_Prestamo">
                                <HeaderStyle Width="70px" />
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText=" Número JIT" DataField="Numero_Jit">
                                <HeaderStyle Width="90px" />
                                <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Número Cliente" DataField="Codigo_Cliente">
                                <HeaderStyle Width="70px" />
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Nombre Cliente" DataField="Nombre_Cliente">
                                <HeaderStyle Width="250px" />
                                <ItemStyle Width="250px" />
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
                        <HeaderStyle CssClass="GridHeaderScroll" Width="550px"></HeaderStyle>
                        <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAltItem" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>