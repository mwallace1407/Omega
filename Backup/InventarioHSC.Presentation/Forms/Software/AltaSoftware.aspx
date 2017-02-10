<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="AltaSoftware.aspx.cs" Inherits="InventarioHSC.Forms.Software.AltaSoftware" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 460px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="CeldaImagenAzul">
            .: ALTA DE SOFTWARE :.
        </div>
        <br />
        <div class="MainDiv" style="text-align: left; height: 270px">
            <asp:Panel ID="pnlDatos" runat="server" DefaultButton="btnAgregar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="width: 355px; float: left;">
                            <div style="width: 100px; float: left; text-align: left;">
                                Empresa:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:DropDownList ID="ddlEmpresa" runat="server" Width="250" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged"
                                    AutoPostBack="True">
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
                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="250" Enabled="False" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged"
                                    AutoPostBack="True">
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
                                Software:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:DropDownList ID="ddlSoftware" runat="server" Width="250" Enabled="False">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddlSoftware" runat="server" ErrorMessage="Campo requerido"
                                    ControlToValidate="ddlSoftware" Display="None" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfve_ddlSoftware" runat="server" Enabled="True"
                                    TargetControlID="rfv_ddlSoftware">
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
                                <asp:TextBox runat="server" ID="txtDescripcion" Text="" Width="249px" MaxLength="750">
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
                                Ubicación:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:TextBox runat="server" ID="txtUbicacion" Text="" Width="249px" MaxLength="50">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txtUbicacion" runat="server" ErrorMessage="Campo requerido"
                                    ControlToValidate="txtUbicacion" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfve_txtUbicacion" runat="server" Enabled="True"
                                    TargetControlID="rfv_txtUbicacion">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 355px; float: left;">
                            <div style="width: 100px; float: left; text-align: left;">
                                No. Parte:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:TextBox runat="server" ID="txtNoParte" Text="" Width="249px" MaxLength="50">
                                </asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 355px; float: left;">
                            <div style="width: 100px; float: left; text-align: left;">
                                Llave:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:TextBox runat="server" ID="txtLlave" Text="" Width="249px" MaxLength="100">
                                </asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 355px; float: left;">
                            <div style="width: 100px; float: left; text-align: left;">
                                Observaciones:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:TextBox runat="server" ID="txtObservaciones" Text="" Width="249px" MaxLength="500"
                                    Height="50" TextMode="MultiLine">
                                </asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <div style="width: 355px; text-align: right;">
                            <asp:Button ID="btnAgregar" runat="server" CssClass="boton" Text="Agregar" Width="120px"
                                CausesValidation="true" OnClick="btnAgregar_Click" />&nbsp;
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
            <br />
            <div id="Div1" style="text-align: center;">
                <asp:Button ID="btnSalir" runat="server" CssClass="boton"
                    Text="Salir" Width="120px" OnClick="btnSalir_Click" CausesValidation="false" />
                &nbsp;
            </div>
            <br />
        </div>
    </div>
    <uc:uscMsgBox runat="server" ID="MsgBox" />
</asp:Content>
