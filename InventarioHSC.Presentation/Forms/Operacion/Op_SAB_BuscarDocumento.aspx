<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_SAB_BuscarDocumento.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_SAB_BuscarDocumento" %>

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
                Buscar documentos SAB</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px; text-align: left;">
                    Palabra(s) clave a buscar:
                    <br />
                    <asp:TextBox ID="txtFiltro" runat="server" Width="200" MaxLength="50" autocomplete="off"></asp:TextBox>&nbsp
                    Mínimo 5 caracteres.
                    <asp:RequiredFieldValidator ID="rfv_txtFiltro" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="txtFiltro" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_txtFiltro" runat="server" Enabled="True" TargetControlID="rfv_txtFiltro">
                    </asp:ValidatorCalloutExtender>
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
                            <asp:BoundField HeaderText="Archivo" DataField="Archivo">
                                <HeaderStyle Width="479px" />
                                <ItemStyle Width="479px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Descargas">
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
                                ItemStyle-CssClass="GridColumnHide" HtmlEncode="False" HtmlEncodeFormatString="False">
                                <HeaderStyle Width="1px" />
                                <ItemStyle Width="1px" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle Width="550px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                        </HeaderStyle>
                        <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAltItem" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>