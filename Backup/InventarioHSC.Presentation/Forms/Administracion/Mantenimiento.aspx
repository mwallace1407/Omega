<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Mantenimiento.aspx.cs" Inherits="InventarioHSC.Forms.Administracion.Mantenimiento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 470px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: MANTENIMIENTO DEL SISTEMA :.
            </div>
            <br />
            <asp:UpdatePanel ID="UPnl" runat="server">
                <ContentTemplate>
                    <div style="width: 605px">
                        <div style="width: 300px; float: left">
                            <fieldset>
                                <legend>Limpiar archivos temporales antiguos:</legend>
                                <asp:Button ID="btnLimpiaReportes" runat="server" Text="Limpiar" CssClass="boton" OnClick="btnLimpiaReportes_Click" />
                                <br />
                                <asp:Label ID="lblLimpiaReportes" runat="server" Text=""></asp:Label>
                            </fieldset>
                        </div>
                        <div style="width: 300px; float: right">
                            <fieldset>
                                <legend>Limpiar reportes temporales antiguos:</legend>
                                <asp:Button ID="btnLimpiaReportesSAP" runat="server" Text="Limpiar" CssClass="boton"
                                    OnClick="btnLimpiaReportesSAP_Click" />
                                <br />
                                <asp:Label ID="lblLimpiaReportesSAP" runat="server" Text=""></asp:Label>
                            </fieldset>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UPrg" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UPnl">
                <ProgressTemplate>
                    <div style="top: 0px; height: 100%; background-color: Gray; opacity: 0.9; filter: alpha(opacity=90);
                        vertical-align: middle; left: 0px; z-index: 999999; width: 100%; position: absolute;
                        text-align: center;">
                        <div style="text-align: center; width: 100px; height: 120px; position: absolute;
                            left: 46%; top: 42%; color: #DDDDDD; font-size: large; font-weight: bold;">
                            <img src="../../App_Themes/Imagenes/gears_animated.gif" alt="Procesando..." style="border-width: 0px;
                                width: 100px; height: 100px;" />
                            <br />
                            Procesando...
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>
</asp:Content>
