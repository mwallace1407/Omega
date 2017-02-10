<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="CatalogoEmpresasSoftware.aspx.cs" Inherits="InventarioHSC.Forms.Catalogos.CatalogoEmpresasSoftware" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 210px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="CeldaImagenAzul">
            .: ALTA DE EMPRESAS DE SOFTWARE :.
        </div>
        <br />
        <div class="MainDiv" style="text-align: left; height: 170px">
            <asp:Panel ID="pnlDatos" runat="server" DefaultButton="btnAgregar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="width: 355px; float: left;">
                            <div style="width: 100px; float: left; text-align: left;">
                                Empresa:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txtDescripcion" runat="server" ErrorMessage="Campo requerido"
                                    Display="None" ControlToValidate="txtDescripcion" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfve_txtDescripcion" runat="server" Enabled="True"
                                    TargetControlID="rfv_txtDescripcion">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 355px; text-align: right;">
                            <asp:Button ID="btnAgregar" runat="server" CssClass="boton" Text="Agregar" Width="120px"
                                CausesValidation="true" onclick="btnAgregar_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
            <br />
            <div id="Div1" style="text-align: center;">
                <asp:Button ID="btnSalir" runat="server" CssClass="boton" Text="Salir" Width="120px"
                    CausesValidation="false" onclick="btnSalir_Click" />
            </div>
            <br />
        </div>
    </div>
    <uc:uscMsgBox runat="server" ID="MsgBox" />
</asp:Content>
