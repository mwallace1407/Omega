<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptDiscosSrv.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptDiscosSrv" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 465px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: REPORTE DE DISCOS EN UN SERVIDOR :.
            </div>
            <br />
            <div style="width: 830px; height: 155px;">
                <div style="width: 410px; height: 150px; float: left;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Servidores:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <div style="border: 3px ridge SteelBlue; height: 150px; overflow: scroll; overflow-x: hidden;">
                            <asp:CheckBoxList ID="chkServidores" runat="server" Width="250">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div style="width: 410px; height: 150px; float: right;">
                </div>
            </div>
            <br />
            <div style="width: 180px; text-align: left;">
                <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
            </div>
            <br />
            <asp:Button ID="btnProcesar" runat="server" Text="Generar Reporte" CssClass="boton"
                OnClick="btnProcesar_Click" />
            <br />
        </div>
    </div>
</asp:Content>
