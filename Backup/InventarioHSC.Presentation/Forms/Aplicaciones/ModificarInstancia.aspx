<%@ Page Title="Modificar datos de instancias BD" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="ModificarInstancia.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.ModificarInstancia" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 800px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: MODIFICAR DATOS DE INSTANCIAS BD :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Instancia:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlInstancia" runat="server" Width="202" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlInstancia_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <asp:Panel ID="pnlContent" runat="server" Enabled="False">
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
                        Nombre de instancia (opcional):
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:TextBox ID="txtNombre" runat="server" Width="200" MaxLength="50" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
                <br />
                <br />
                <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
