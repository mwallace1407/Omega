<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="AltaAplicaciones.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.AltaAplicaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 550px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: ALTA DE APLICACIONES :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Estado:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlEstado" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlEstado" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlEstado" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlEstado" runat="server" Enabled="True" TargetControlID="rfv_ddlEstado">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Tipo:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlTipo" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlTipo" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlTipo" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlTipo" runat="server" Enabled="True" TargetControlID="rfv_ddlTipo">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Servidor principal:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlServidorP" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlServidorP" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlServidorP" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlServidorP" runat="server" Enabled="True" TargetControlID="rfv_ddlServidorP">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Servidor BD:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlServidor" runat="server" Width="202" 
                        AutoPostBack="True" onselectedindexchanged="ddlServidor_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlServidor" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlServidor" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlServidor" runat="server" Enabled="True" TargetControlID="rfv_ddlServidor">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    BD principal:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlBD" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlBD" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlBD" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlBD" runat="server" Enabled="True" TargetControlID="rfv_ddlBD">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Nombre:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtNombre" runat="server" Width="200" MaxLength="100" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_txtNombre" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="txtNombre" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_txtNombre" runat="server" Enabled="True" TargetControlID="rfv_txtNombre">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left; height: 58px;">
                    Descripción:
                </div>
                <div style="width: 275px; float: right; text-align: left; height: 58px;">
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="200" MaxLength="500" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_txtDescripcion" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="txtDescripcion" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_txtDescripcion" runat="server" Enabled="True"
                        TargetControlID="rfv_txtDescripcion">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left; height: 25px;">
                    En TFS:
                </div>
                <div style="width: 275px; float: right; text-align: left; height: 25px;">
                    <asp:CheckBox ID="chkEnTFS" runat="server" />
                </div>
            </div>
            <br />
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Productiva:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:CheckBox ID="chkProductiva" runat="server" />
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Ruta de acceso:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtUbicacion" runat="server" Width="200" MaxLength="100" autocomplete="off"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Observaciones:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="200" MaxLength="1000" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <br /><br />
            <br />
            <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click" />
        </div>
    </div>
</asp:Content>
