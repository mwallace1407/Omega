<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="MonitoreoRemotoSW.aspx.cs" Inherits="InventarioHSC.Forms.Servidores.MonitoreoRemotoSW" %>

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
                Monitoreo remoto de Software</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Dominio:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtDominio" runat="server" Width="200" MaxLength="50" autocomplete="off"
                            Text="consorcio"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtDominio" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtDominio" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtDominio" runat="server" Enabled="True"
                            TargetControlID="rfv_txtDominio">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Equipo:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtEquipo" runat="server" Width="200" MaxLength="50" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Usuario revisor:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtUsuario" runat="server" Width="200" MaxLength="50" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtUsuario" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtUsuario" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtUsuario" runat="server" Enabled="True"
                            TargetControlID="rfv_txtUsuario">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Contraseña:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtPass" runat="server" Width="200" MaxLength="50" autocomplete="off"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtPass" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtPass" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtPass" runat="server" Enabled="True" TargetControlID="rfv_txtPass">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Revisar todos:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:CheckBox ID="chkRevisarTodos" runat="server" />
                    </div>
                </div>
                <br />
                <asp:Panel ID="pnlMsj" runat="server" Visible="False" Width="710">
                    <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="#990000"></asp:Label>
                </asp:Panel>
                <br />
                <div style="width: 780px; height: 1px; text-align: center;">
                    <asp:Button ID="btnProcesar" runat="server" Text="Registrar" CssClass="boton" OnClick="btnProcesar_Click" />&nbsp&nbsp
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>