<%@ Page Title="Administración de Reportes" Language="C#" AutoEventWireup="true"
    CodeBehind="ModuloReportes.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.ModuloReportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asignación a Usuarios</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <%--<script src="../../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput-1.2.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.formatCurrency-1.0.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/additional-methods.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>--%>
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <link href="../../App_Themes/Estilos/table_jui.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/EstiloInv.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/mainMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/CheckList.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style5
        {
            width: 499px;
        }
        .style6
        {
            width: 17%;
            text-align: left;
        }
        .style7
        {
            width: 13%;
        }
        .style9
        {
            width: 17%;
        }
        .style10
        {
            width: 329px;
        }
        .style11
        {
            width: 23%;
        }
        .style12
        {
            width: 32%;
        }
        .style13
        {
            font-weight: bold;
            color: #383838;
            background: rgb(195,217,255); /* Old browsers */
            background: -moz-linear-gradient(top, rgba(195,217,255,1) 0%, rgba(177,200,239,1) 41%, rgba(152,176,217,1) 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(195,217,255,1)), color-stop(41%,rgba(177,200,239,1)), color-stop(100%,rgba(152,176,217,1))); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, rgba(195,217,255,1) 0%,rgba(177,200,239,1) 41%,rgba(152,176,217,1) 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, rgba(195,217,255,1) 0%,rgba(177,200,239,1) 41%,rgba(152,176,217,1) 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, rgba(195,217,255,1) 0%,rgba(177,200,239,1) 41%,rgba(152,176,217,1) 100%); /* IE10+ */
            background: rgb(195,217,255); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#c3d9ff', endColorstr='#98b0d9',GradientType=0 ); /* IE6-9 */
            font-size: 12px;
            text-align: left;
            vertical-align: middle;
            width: 56%;
        }
        .style14
        {
            width: 56%;
        }
        .style16
        {
            width: 9%;
        }
        .style17
        {
            width: 7%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <table style="width: 100%; height: 97px;">
            <tr style="width: 100%">
                <td align="left" style="width: 20%; height: 40px;" class="logo">
                </td>
                <td align="left">
                </td>
                <td align="right">
                </td>
                <td align="right">
                </td>
            </tr>
        </table>
    </div>
    <%--Fin Tabla header--%>
    <div id="contenidoLogueado2" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="ui-state-error" id="Warning" runat="server">
                    <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                        <asp:Label ID="LabelError" runat="server" Text="" Font-Size="Small"></asp:Label></strong></div>
                <div class="ui-state-highlight" id="Info" runat="server">
                    <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                        <asp:Label ID="LabelInfo" runat="server" Text="" Font-Size="Small"></asp:Label></strong></div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="ui-corner-all ui-widget ui-widget-content" id="space">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td class="CeldaImagenAzul">
                                .: Reportes :.
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="page">
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rbReportes" runat="server" AutoPostBack="true" Font-Size="Small"
                                    RepeatColumns="6">
                                    <asp:ListItem Text="Reporte General" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Reporte por usuario" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Reporte Histórico" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Reporte por Tipo de Activo" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Reporte Movimientos" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Reporte Duplicados" Value="6"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel runat="server" ID="pnlReportes" EnableTheming="True">
                        <asp:Panel runat="server" ID="pnlUbicacion" Visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUbicacion" Text="Ubicación:" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUbicacion" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlUsuario" Visible="false">
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="ddlUsuario" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlTipoActivoC" Visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTipoActivo" runat="server" Text="Tipo de Activo:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnTipoActivo" runat="server" CssClass="button2" Text="Tipo Activo" />
                                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" X="250" Y="20" CancelControlID="btnCancel"
                                            OkControlID="btnOkay" TargetControlID="btnTipoActivo" PopupControlID="pnlTipoActivo"
                                            PopupDragHandleControlID="PopupHeader" Drag="true" BackgroundCssClass="ModalPopupBG">
                                        </asp:ModalPopupExtender>
                                        <asp:Panel ID="pnlTipoActivo" Style="display: none" runat="server">
                                            <div class="Popup" style="overflow: auto; height: 500px;">
                                                <div class="PopupBody">
                                                    <asp:CheckBoxList ID="chkTipoActivo" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                        CellSpacing="5">
                                                    </asp:CheckBoxList>
                                                </div>
                                                <div class="Controls">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <input id="btnOkay" type="button" class="ui-corner-all ui-state-default cancel" value="Aceptar"
                                                                    onclick="VerificaSeleccionados();" />
                                                            </td>
                                                            <td align="center">
                                                                <input id="btnCancel" type="button" class="ui-corner-all ui-state-default cancel"
                                                                    value="Cancelar" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlResponsiva" Visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblResponsiva" Text="Responsiva:" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtResponsiva" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlNumeroSerie" Visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNoSerie" runat="server" Text="No. Serie:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoSerie" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" Width="100%">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnEjecutar" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                                            OnClick="btnEjecutar_Click" Text="Ejecutar" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlVisualizadorReportes" Style="text-align: center;">
                            <rsweb:ReportViewer ID="rvReportes" runat="server" Width="95%">
                            </rsweb:ReportViewer>
                        </asp:Panel>
                        <%-- <table class="page" width="100%" style="font-size: large;">
                                <tr>
                                    <td align="right" class="style2">
                                    </td>
                                    <td align="left" class="style3">
                                    </td>
                                    <td align="right" valign="top" class="style1">
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style2">
                                    </td>
                                    <td align="left" class="style3" colspan="3">
                                        RepositionMode="RepositionOnWindowResizeAndScroll"
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style2">
                                    </td>
                                    <td align="left" class="style3">
                                    </td>
                                    <td align="right" class="style1">
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                    </td>
                                </tr>
                            </table>--%>
                    </asp:Panel>
                    <asp:HiddenField ID="hdnIndicesChk" runat="server" />
                    <asp:HiddenField ID="hdnRespuesta" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function VerificaSeleccionados() {
            var sArreglo;
            var sFramentos;
            var chkSeleccionados = "";
            var sIndice;
            var sIdTipoActivo;

            for (var i = 0; i < document.forms[0].elements.length; i++) {
                var elemento = document.forms[0].elements[i];
                if (elemento.type == "checkbox") {
                    if (elemento.checked)
                        chkSeleccionados += elemento.name.substring(elemento.name.lastIndexOf("$") + 1, elemento.name.length) + "|";
                }
            }
            VerificaValor(chkSeleccionados);
        }
        function VerificaValor(chkSeleccionados) {
            chkSeleccionados = chkSeleccionados.toString().split("|");

            for (var i = 0; i < document.forms[0].elements.length; i++) {
                var elemento = document.forms[0].elements[i];
                if (elemento.name == "hdnIndicesChk") {
                    sArreglo = elemento.value;
                    sArreglo = sArreglo.split("@");
                    for (var j = 0; j < sArreglo.length - 1; j++) {
                        sFramentos = sArreglo[j].split("|");
                        sIndice = sFramentos[2].toString();
                        sIdTipoActivo = sFramentos[0].toString();
                        for (var x = 0; x < chkSeleccionados.length; x++) {
                            if (chkSeleccionados[x] == sIndice) {
                                for (var y = 0; y < document.forms[0].elements.length; y++) {
                                    var elemento = document.forms[0].elements[y];
                                    if (elemento.name == "hdnRespuesta") {
                                        elemento.value = elemento.value + sIdTipoActivo + "|";
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    </script>
    </form>
</body>
</html>