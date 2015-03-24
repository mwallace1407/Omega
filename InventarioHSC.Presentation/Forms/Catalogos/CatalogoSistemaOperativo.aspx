<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogoSistemaOperativo.aspx.cs"
    Inherits="InventarioHSC.CatalogoSistemaOperativo" EnableEventValidation="false"
    Title="Catálogo de Sistemas Operativos" MasterPageFile="~/Forms/Main.Master" %>

<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc" TagName="uscMsgBox" %>
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
    <%--<link href="../../App_Themes/Estilos/table_jui.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/EstiloInv.css" rel="stylesheet" type="text/css" />--%>
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
                .: CATALOGO DE SISTEMAS OPERATIVOS :.
            </div>
            <br />
            <div class="MainDiv" style="text-align: left; height: 135px">
                <div style="width: 400px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                        Descripción:
                    </div>
                    <div style="width: 300px; float: right;">
                        <asp:TextBox runat="server" ID="txtDescripcion" Text="" Width="300px" MaxLength="50">
                        </asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 400px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                        Versión:
                    </div>
                    <div style="width: 300px; float: right;">
                        <asp:TextBox runat="server" ID="txtVersion" Text="" Width="300px" MaxLength="50">
                        </asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 400px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                        Estatus:
                    </div>
                    <div style="width: 300px; float: right;">
                        <asp:CheckBox ID="chkEstatus" runat="server" Checked="True" />
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 400px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                    </div>
                    <div style="width: 300px; float: right; text-align: right;">
                        <asp:Button ID="btnAgregar" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                            Text="Agregar" Width="120px" CausesValidation="true" OnClick="btnAgregar_Click" />
                    </div>
                </div>
                <br />
                <br />
                <asp:ValidatorCalloutExtender ID="vceDesc" runat="server" TargetControlID="rfvDescripcion">
                </asp:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="La descripción es un dato requerido"
                    ForeColor="White" ControlToValidate="txtDescripcion" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="rfve_txtVersion" runat="server" TargetControlID="rfv_txtVersion">
                </asp:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="rfv_txtVersion" runat="server" ErrorMessage="La versión es un dato requerido"
                    ForeColor="White" ControlToValidate="txtVersion" Display="None"></asp:RequiredFieldValidator>
            </div>
            <%--<div style="text-align: left; width: 500px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gwvSistemaOperativo" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="idSistema" Width="90%" EmptyDataText="No existe Informacion" OnRowCommand="gwvSistemaOperativo_RowCommand"
                            OnRowDataBound="gwvSistemaOperativo_RowDataBound" AllowPaging="true" OnPageIndexChanging="gwvSistemaOperativo_PageIndexChanging"
                            PageSize="10">
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
                                <asp:BoundField DataField="idSistema" HeaderText="ID" SortExpression="idSistema" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="descripcion" />
                                <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="version" />
                                <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="estatus" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>
            <br />
            <div id="Div1">
                <asp:Button ID="btnSalir" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                    Text="Salir" Width="120px" OnClick="btnSalir_Click" CausesValidation="false" />
                &nbsp;
            </div>
            <uc:uscMsgBox runat="server" ID="MsgBox" />
        </div>
    </div>
</asp:Content>
