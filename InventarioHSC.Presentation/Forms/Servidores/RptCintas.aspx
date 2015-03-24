<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptCintas.aspx.cs" Inherits="InventarioHSC.Forms.Servidores.RptCintas" %>

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
                Reporte de respaldos</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px;">
                    <div style="width: 325px; float: left; text-align: left;">
                        Para generar un reporte completo deje los filtros en blanco
                    </div>
                    <div style="width: 375px; float: right; text-align: left;">
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        No. de cinta:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                        <asp:TextBox ID="txtCinta" runat="server" Width="200" MaxLength="25" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipo de respaldo:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlFiltro" runat="server" Width="202" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Objeto respaldado:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlObj" runat="server" Width="202" Enabled="False">
                        </asp:DropDownList>
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
                    <asp:Button ID="btnProcesar" runat="server" Text="Generar reporte" CssClass="boton"
                        OnClick="btnProcesar_Click" />&nbsp&nbsp
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
