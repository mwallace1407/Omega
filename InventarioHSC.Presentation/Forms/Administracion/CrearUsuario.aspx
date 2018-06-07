<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="CrearUsuario.aspx.cs" Inherits="InventarioHSC.Forms.Administracion.CrearUsuario" %>

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
                Crear Usuario</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Usuario:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtUsuario" runat="server" Width="200" MaxLength="20" autocomplete="off"></asp:TextBox>
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
                        E-Mail:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtEMail" runat="server" Width="200" MaxLength="100" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtEMail" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtEMail" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtEMail" runat="server" Enabled="True" TargetControlID="rfv_txtEMail">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Nombre:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtNombre" runat="server" Width="200" MaxLength="150" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtNombre" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtNombre" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtNombre" runat="server" Enabled="True" TargetControlID="rfv_txtNombre">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 780px; height: 1px; text-align: center;">
                    <asp:Button ID="btnProcesar" runat="server" Text="Crear Usuario" CssClass="boton"
                        OnClick="btnProcesar_Click" />&nbsp&nbsp
                </div>
                <br />
                <br />
            </div>
        </div>
    </div>
    <br />
</asp:Content>