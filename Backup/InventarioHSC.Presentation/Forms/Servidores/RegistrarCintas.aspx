<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RegistrarCintas.aspx.cs" Inherits="InventarioHSC.Forms.Servidores.RegistrarCintas" %>

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
                Registro de respaldos</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipo de respaldo:
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
                        Objeto a respaldar:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlObj" runat="server" Width="202" Enabled="False">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlObj" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlObj" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlObj" runat="server" Enabled="True" TargetControlID="rfv_ddlObj">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Fecha respaldo:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtFechaRespaldo" runat="server" Width="200" MaxLength="10" autocomplete="off"
                            Enabled="False"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtFechaRespaldo_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaRespaldo">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="txtFechaRespaldo_CalendarExtender" runat="server" Enabled="True"
                            Format="dd/MM/yyyy" TargetControlID="txtFechaRespaldo">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfv_txtFechaRespaldo" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtFechaRespaldo" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtFechaRespaldo" runat="server" Enabled="True"
                            TargetControlID="rfv_txtFechaRespaldo">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        No. de cinta:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtCinta" runat="server" Width="200" MaxLength="25" autocomplete="off"
                            Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtCinta" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtCinta" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtCinta" runat="server" Enabled="True" TargetControlID="rfv_txtCinta">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Observaciones:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtObservacionesCinta" runat="server" Width="200" MaxLength="150"
                            autocomplete="off" Enabled="False" Height="75px" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblMsj" runat="server" Text="Datos incorrectos" 
                            ForeColor="#990000" Visible="False"></asp:Label>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <div style="width: 780px; height: 1px; text-align: center;">
                    <asp:Button ID="btnProcesar" runat="server" Text="Registrar" CssClass="boton" OnClick="btnProcesar_Click"
                        Enabled="False" />&nbsp&nbsp
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
