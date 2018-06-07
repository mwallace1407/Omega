<%@ Page Title="Catálogo de Software" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="CatalogoSoftware.aspx.cs" Inherits="InventarioHSC.Forms.Catalogos.CatalogoSoftware" %>

<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc" TagName="uscMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 300px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="CeldaImagenAzul">
            .: CATALOGO DE SOFTWARE :.
        </div>
        <br />
        <div class="MainDiv" style="text-align: left; height: 35px">
            <asp:Panel ID="pnlDatos" runat="server" DefaultButton="btnAgregar">
                <div style="width: 355px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                        Empresa:
                    </div>
                    <div style="width: 255px; float: right;">
                        <asp:DropDownList ID="ddlEmpresa" runat="server" Width="250">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlEmpresa" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlEmpresa" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlEmpresa" runat="server" Enabled="True"
                            TargetControlID="rfv_ddlEmpresa">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 355px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                        Grupo:
                    </div>
                    <div style="width: 255px; float: right;">
                        <asp:DropDownList ID="ddlGrupo" runat="server" Width="250">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlGrupo" runat="server" ErrorMessage="Campo requerido"
                            ControlToValidate="ddlGrupo" Display="None" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlGrupo" runat="server" Enabled="True" TargetControlID="rfv_ddlGrupo">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 355px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                        Descripción:
                    </div>
                    <div style="width: 255px; float: right;">
                        <asp:TextBox runat="server" ID="txtDescripcion" Text="" Width="249px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtDescripcion" runat="server" ErrorMessage="Campo requerido"
                            ControlToValidate="txtDescripcion" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtDescripcion" runat="server" Enabled="True"
                            TargetControlID="rfv_txtDescripcion">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 355px; float: left;">
                    <div style="width: 100px; float: left; text-align: left;">
                        Version:
                    </div>
                    <div style="width: 255px; float: right;">
                        <asp:TextBox runat="server" ID="txtVersion" Text="" Width="249px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtVersion" runat="server" ErrorMessage="Campo requerido"
                            ControlToValidate="txtVersion" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtVersion" runat="server" Enabled="True"
                            TargetControlID="rfv_txtVersion">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 355px; text-align: right;">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                        Text="Agregar" Width="120px" CausesValidation="true" OnClick="btnAgregar_Click" />&nbsp;
                </div>
            </asp:Panel>
            <br />
            <br />
            <div id="Div1" style="text-align: center;">
                <asp:Button ID="btnSalir" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                    Text="Salir" Width="120px" OnClick="btnSalir_Click" CausesValidation="false" />
                &nbsp;
            </div>
            <br />
        </div>
    </div>
    <uc:uscMsgBox runat="server" ID="MsgBox" />
</asp:Content>