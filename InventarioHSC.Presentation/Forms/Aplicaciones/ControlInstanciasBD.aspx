<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="ControlInstanciasBD.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.ControlInstanciasBD" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 230px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: CONTROL DE INSTANCIAS DE BASE DE DATOS :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Servidor:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlServidor" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlServidor" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlServidor" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlServidor" runat="server" Enabled="True"
                        TargetControlID="rfv_ddlServidor">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Tipo BD:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlTipoBD" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlTipoBD" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlTipoBD" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlTipoBD" runat="server" Enabled="True" TargetControlID="rfv_ddlTipoBD">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Nombre de instancia (opcional):
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="256" Width="200" autocomplete="off"></asp:TextBox>
                </div>
            </div>
            <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click" />
        </div>
    </div>
</asp:Content>