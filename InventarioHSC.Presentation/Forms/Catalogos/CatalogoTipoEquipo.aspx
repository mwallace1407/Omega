<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogoTipoEquipo.aspx.cs"
    Inherits="InventarioHSC.CatalogoTipoEquipo" EnableEventValidation="false" Title="Catálogo de Tipos de equipo"
    MasterPageFile="~/Forms/Main.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="head" ContentPlaceHolderID="headMaster" runat="server">
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput-1.2.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.formatCurrency-1.0.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/additional-methods.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <%--<link href="../../App_Themes/Estilos/table_jui.css" rel="stylesheet"  type="text/css" />
    <link href="../../App_Themes/Estilos/EstiloInv.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/mainMaster.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server">
        <div class="ui-state-error" id="Warning" runat="server" style="text-align: left">
            <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                <asp:Label ID="LabelError" runat="server" Text=""></asp:Label></strong></div>
        <div class="ui-state-highlight" id="Info" runat="server" style="text-align: left">
            <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
        <div class="MainDiv" id="space">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <div class="CeldaImagenAzul">
                .: CATALOGO DE TIPOS DE EQUIPO :.
            </div>
            <br />
            <div class="MainDiv" style="text-align: left; height: 35px">
                Descripción:&nbsp;<asp:TextBox runat="server" ID="txtDescripcion" Text="" Width="300px">
                </asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="imgAgregar" runat="server" ImageUrl="~/App_Themes/Imagenes/Plus_green.png"
                    OnClick="imgAgregar_Click" Height="24px" Width="25px" ToolTip="Agregar al catálogo"
                    ImageAlign="Bottom" />
                <asp:ValidatorCalloutExtender ID="vceDesc" runat="server" TargetControlID="rfvDescripcion">
                </asp:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="La descripción es un dato requerido"
                    ForeColor="White" ControlToValidate="txtDescripcion">
                </asp:RequiredFieldValidator>
            </div>
            <div style="text-align: left; width: 500px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gwvTipoEquipo" runat="server" AutoGenerateColumns="False" DataKeyNames="idTipoEquipo"
                            Width="90%" EmptyDataText="No existe Informacion" OnRowCommand="gwvTipoEquipo_RowCommand"
                            OnRowDataBound="gwvTipoEquipo_RowDataBound" AllowPaging="true" OnPageIndexChanging="gwvTipoEquipo_PageIndexChanging"
                            PageSize="15">
                            <HeaderStyle CssClass="Encabezado" ForeColor="Black"></HeaderStyle>
                            <HeaderStyle CssClass="CeldaImagenVerde" HorizontalAlign="Center" />
                            <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                            <EmptyDataRowStyle BackColor="#DEDDF3" />
                            <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                            <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:Image ID="imgEliminar" runat="server" ToolTip="Eliminar" ImageUrl="~/App_Themes/Imagenes/ico_trashcan.gif" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="idTipoEquipo" HeaderText="ID" SortExpression="idTipoEquipo" />
                                <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <div id="Div1">
                <asp:Button ID="btnSalir" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                    Text="Salir" Width="120px" OnClick="btnSalir_Click" CausesValidation="false" />
                &nbsp;
            </div>
        </div>
    </div>
</asp:Content>
