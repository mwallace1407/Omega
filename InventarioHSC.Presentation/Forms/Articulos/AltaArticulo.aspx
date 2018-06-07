<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="InventarioHSC._AltaArticulo"
    EnableEventValidation="false" Title="Alta de Artículos" MasterPageFile="~/Forms/Main.Master"
    MaintainScrollPositionOnPostback="true" %>

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
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server">
        <div class="MainDiv" id="space">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:HiddenField ID="hdnParametros" runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="ui-state-error" id="Warning" runat="server" style="text-align: left">
                        <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                            <asp:Label ID="LabelError" runat="server" Text=""></asp:Label></strong></div>
                    <div class="ui-state-highlight" id="Info" runat="server" style="text-align: left">
                        <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                            <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hdnGeneracionDeControles" runat="server" Value="0" />
                    <asp:Panel runat="server" ID="pnlHeaderDatosGenerales">
                        <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                            .: DESCRIPCIÓN GENERAL DEL ARTÍCULO :.
                        </div>
                        <br />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlDatosGenerales">
                        <div>
                            <div style="text-align: left;">
                                <div style="width: 350px; margin-left: auto; margin-right: auto; text-align: center;">
                                    <asp:RadioButton ID="radioSN" GroupName="rdbSerie" AutoPostBack="true" Text="Sin Numero de Serie"
                                        runat="server" OnCheckedChanged="radioSN_CheckedChanged" />
                                    <asp:RadioButton ID="radioIlegible" GroupName="rdbSerie" AutoPostBack="true" Text="Ilegible"
                                        runat="server" OnCheckedChanged="radioIlegible_CheckedChanged" />
                                    <asp:RadioButton ID="radioCon" Checked="true" GroupName="rdbSerie" AutoPostBack="true"
                                        runat="server" Text="Con Numero de Serie" OnCheckedChanged="radioCon_CheckedChanged" />
                                </div>
                            </div>
                            <br />
                            <div style="width: 405px;">
                                <div style="width: 150px; float: left; text-align: left;">
                                    No. de Serie:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:TextBox ID="txtNoSerie" runat="server" Width="249px" Enabled="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfeNoserie" runat="server" ErrorMessage="Introduzca No. de Serier"
                                        ControlToValidate="txtNoSerie" ValidationGroup="vgGuardaRegistroArticulo" Display="None"
                                        SetFocusOnError="true" ForeColor="White" Font-Size="Smaller">
                                    </asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceNoSerie" runat="server" TargetControlID="rfeNoserie">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 405px;">
                                <div style="width: 150px; float: left; text-align: left;">
                                    Modelo:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:TextBox ID="txtModelo" runat="server" Width="249px" Enabled="true"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 405px;">
                                <div style="width: 150px; float: left; text-align: left;">
                                    Tipo de Artículo:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:DropDownList ID="ddlTipoArticulo" runat="server" Enabled="true" Width="250px"
                                        OnSelectedIndexChanged="ddlTipoArticulo_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvTipoArticulo" runat="server" ValidationGroup="vgGuardaRegistroArticulo"
                                        ControlToValidate="ddlTipoArticulo" ErrorMessage="Seleccione un Tipo de Articulo"
                                        Operator="NotEqual" Display="None" SetFocusOnError="true" ValueToCompare="0">
                                    </asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender runat="server" ID="vcTipoArticulo" TargetControlID="cvTipoArticulo">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 405px;">
                                <div style="width: 150px; float: left; text-align: left;">
                                    Marca:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:DropDownList ID="ddlMarca" runat="server" Enabled="true" Width="250px">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvMarca" runat="server" ValidationGroup="vgGuardaRegistroArticulo"
                                        ControlToValidate="ddlMarca" ErrorMessage="Seleccione Marca" Operator="NotEqual"
                                        Display="None" SetFocusOnError="true" ValueToCompare="0">
                                    </asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender runat="server" ID="vcMarca" TargetControlID="cvMarca">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 405px;">
                                <div style="width: 150px; float: left; text-align: left;">
                                    Estado de Conservación:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:DropDownList ID="ddlEstado" runat="server" Width="250px">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvEstado" runat="server" ValidationGroup="vgGuardaRegistroArticulo"
                                        ControlToValidate="ddlEstado" ErrorMessage="Seleccione  Estado de Conservación"
                                        Operator="NotEqual" Display="None" SetFocusOnError="true" ValueToCompare="0">
                                    </asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender runat="server" ID="vceEstado" TargetControlID="cvEstado">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 405px; text-align: left;">
                                <asp:CheckBox ID="chkIgnorarSerie" runat="server" Checked="True" Text="Ignorar series duplicadas"
                                    Visible="False" />
                            </div>
                            <br />
                            <br />
                        </div>
                    </asp:Panel>
                    <br />
                    <asp:Panel runat="server" ID="pnlUbicacionHeader">
                        <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                            .: UBICACIÓN :.
                        </div>
                        <br />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlUbicacion">
                        <div>
                            <div style="width: 405px;">
                                <div style="width: 150px; float: left; text-align: left;">
                                    Ubicación:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlUbicacion" AutoPostBack="true" runat="server" Width="250px"
                                                OnSelectedIndexChanged="ddlUbicacion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="vUbicacion" runat="server" ValidationGroup="vgGuardaRegistroArticulo"
                                                ControlToValidate="ddlUbicacion" ErrorMessage="Seleccione Ubicación" Operator="NotEqual"
                                                Display="None" SetFocusOnError="true" ValueToCompare="0">
                                            </asp:CompareValidator><asp:ValidatorCalloutExtender runat="server" ID="vceUbicacion"
                                                TargetControlID="vUbicacion">
                                            </asp:ValidatorCalloutExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 405px;">
                                <div style="width: 150px; float: left; text-align: left;">
                                    Región:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtRegion" runat="server" Width="249px"></asp:TextBox></ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <br />
                            <br />
                        </div>
                    </asp:Panel>
                    <br />
                    <asp:Panel runat="server" ID="pnlHeaderObservaciones">
                        <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                            .: OBSERVACIONES :.
                        </div>
                        <br />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlObservaciones">
                        <div style="width: 978px">
                            <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" MaxLength="2000"
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <br />
                    <div id="Botones" style="text-align: center;">
                        <asp:Button ID="btnGuardar" runat="server" ValidationGroup="vgGuardaRegistroArticulo"
                            CausesValidation="true" CssClass="ui-corner-all ui-state-default cancel" Text="Guardar"
                            Width="120px" OnClick="btnGuardar_Click" />&nbsp;
                        <asp:Button ID="btnLimpiar" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                            Text="Limpiar" Width="120px" OnClick="btnLimpiar_Click" />&nbsp;
                        <asp:Button ID="btnSalir" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                            Text="Salir" Width="120px" OnClick="btnSalir_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>