﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="AltaBD.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.AltaBD" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 290px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: ALTA DE BASE DE DATOS PARA UN SERVIDOR :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Servidor:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlServidor" runat="server" Width="202" OnSelectedIndexChanged="ddlServidor_SelectedIndexChanged"
                        AutoPostBack="True">
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
                    Instancia BD:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlInstanciaBD" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlInstanciaBD" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlInstanciaBD" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlInstanciaBD" runat="server" Enabled="True"
                        TargetControlID="rfv_ddlInstanciaBD">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Nombre de BD:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtNombre" runat="server" Width="200" MaxLength="128" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_txtNombre" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="txtNombre" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_txtNombre" runat="server" Enabled="True" TargetControlID="rfv_txtNombre">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Activa:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:CheckBox ID="chkActiva" runat="server" Checked="True" />
                </div>
            </div>
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
            <br />
            <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click" />
        </div>
    </div>
</asp:Content>