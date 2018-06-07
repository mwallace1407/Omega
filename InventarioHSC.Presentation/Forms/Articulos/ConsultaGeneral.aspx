<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaGeneral.aspx.cs"
    Inherits="InventarioHSC.ConsultaGeneral" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de Artículos</title>
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/ui.datepicker-es.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput-1.2.2.js" type="text/javascript"></script>
    <link href="../../App_Themes/Estilos/estilo1.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="../../App_Themes/Estilos/estilo1a.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/mainMaster.css" rel="stylesheet" type="text/css" />
</head>
<body ms_positioning="GridLayout" method="post">
    <form id="form1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <%--Tabla header--%>
    <div id="header">
        <table style="width: 100%; height: 97px; position: absolute;">
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
    <div id="DivPrincipal" style="width: 90%; margin-left: 100px; margin-top: 40px; position: static;
        top: 109px; left: -7px; height: 899px;">
        <div id="divitulos" class="ui-corner-all ui-widget ui-widget-content">
            <table id="TableTitulos" cellspacing="1" cellpadding="1" width="90%" align="center"
                border="0" runat="server">
                <tr>
                    <td>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="CeldaTituloE" style="height: 20px" colspan="2">
                        .::Monitor de Búsqueda de Artículos::.
                    </td>
                </tr>
            </table>
            <br />
            <div class="ui-state-error" id="Warning" runat="server">
                <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                    <asp:Label ID="LabelWarning" runat="server" Text=""></asp:Label></strong></div>
            <div class="ui-state-highlight" id="Info" runat="server">
                <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                    <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
            <br />
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <table width="90%" cellspacing="1" cellpadding="1" id="TPrincipal">
                <tr>
                    <td class="CeldaDetalleNota" style="height: 23px" align="center" colspan="4">
                        <font color="red">Nota:&nbsp;&nbsp;</font>Esta marca indica que los campos (<font
                            color="red">*</font>) son requeridos
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%">
                    </td>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="ui-corner-all ui-state-default cancel"
                            OnClick="btnBuscar_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" Text="Salir" CssClass="ui-corner-all ui-state-default cancel"
                            CausesValidation="false" OnClick="btnCancelar_Click" Height="24px" Width="53px" />
                    </td>
                    <td style="width: 25%">
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%">
                    </td>
                    <td style="width: 25%">
                        &nbsp;
                    </td>
                    <td style="width: 25%">
                        &nbsp;
                    </td>
                    <td style="width: 25%">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="ExportaExcel" runat="server" ImageUrl="~/App_Themes/Imagenes/Excel-icon.png"
                                    OnClick="ExportaExcel_Click" /></ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table width="90%" cellspacing="1" cellpadding="1" id="Table1">
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView ID="gvwReporteGeneral" runat="server" AutoGenerateColumns="false" DataKeyNames="id"
                            Width="90%" EmptyDataText="No existe Informacion" AllowPaging="True" OnPageIndexChanging="gvwReporteGeneral_PageIndexChanging"
                            PageSize="20">
                            <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                            <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                            <PagerSettings Mode="NextPreviousFirstLast" />
                            <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                            <EmptyDataRowStyle BackColor="#DEDDF3" />
                            <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                            <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                    SortExpression="id" />
                                <asp:BoundField DataField="noSerie" HeaderText="Serie" SortExpression="noSerie" />
                                <asp:BoundField DataField="idTipoEquipo" HeaderText="idTipoEquipo" SortExpression="idTipoEquipo" />
                                <asp:BoundField DataField="tipoEquipo" HeaderText="Tipo de Equipo" SortExpression="tipoEquipo" />
                                <asp:BoundField DataField="idMarca" HeaderText="idMarca" SortExpression="idMarca" />
                                <asp:BoundField DataField="marca" HeaderText="Marca" SortExpression="marca" />
                                <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="modelo" />
                                <asp:BoundField DataField="procesador" HeaderText="Procesador" SortExpression="procesador" />
                                <asp:BoundField DataField="rAM" HeaderText="RAM" SortExpression="rAM" />
                                <asp:BoundField DataField="discoDuro" HeaderText="Disco Duro" SortExpression="discoDuro" />
                                <asp:BoundField DataField="idSistema" HeaderText="idSistema" SortExpression="idSistema" />
                                <asp:BoundField DataField="sistemaOperativo" HeaderText="Sistema Operativo" SortExpression="sistemaOperativo" />
                                <asp:BoundField DataField="idProveedor" HeaderText="idProveedor" SortExpression="idProveedor" />
                                <asp:BoundField DataField="proveedor" HeaderText="Proveedor" SortExpression="proveedor" />
                                <asp:BoundField DataField="factura" HeaderText="Factura" SortExpression="factura" />
                                <asp:BoundField DataField="fechaCompra" HeaderText="Fecha de Compra" SortExpression="fechaCompra" />
                                <asp:BoundField DataField="requisicion" HeaderText="Requisición" SortExpression="requisicion" />
                                <asp:BoundField DataField="centroCostosAdquisicion" HeaderText="Centro de Costos"
                                    SortExpression="centroCostosAdquisicion" />
                                <asp:BoundField DataField="responsiva" HeaderText="Responsiva" SortExpression="responsiva" />
                                <asp:BoundField DataField="ValorPesos" HeaderText="Valor (Pesos)" SortExpression="ValorPesos" />
                                <asp:BoundField DataField="ValorUSD" HeaderText="Valor (USD)" SortExpression="ValorUSD" />
                                <asp:BoundField DataField="stock" HeaderText="Stock" SortExpression="stock" />
                                <asp:BoundField DataField="codigoCastor" HeaderText="Codigo de Castor" SortExpression="codigoCastor" />
                                <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" SortExpression="idUsuario" />
                                <asp:BoundField DataField="usuarioAsignado" HeaderText="Usuario Asignado" SortExpression="usuarioAsignado" />
                                <asp:BoundField DataField="idUbicacion" HeaderText="idUbicacion" SortExpression="idUbicacion" />
                                <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" SortExpression="ubicacion" />
                                <asp:BoundField DataField="idEstado" HeaderText="Estado" SortExpression="idEstado" />
                                <asp:BoundField DataField="estadoConservacion" HeaderText="Estado de Conservación"
                                    SortExpression="estadoConservacion" />
                                <asp:BoundField DataField="observacion1" HeaderText="Observacion 1" SortExpression="observacion1" />
                                <asp:BoundField DataField="observacion2" HeaderText="Observación 2" SortExpression="observacion2" />
                                <asp:BoundField DataField="observacion3" HeaderText="Observacion 3" SortExpression="observacion3" />
                                <asp:BoundField DataField="posibleFaltanteFlag" HeaderText="Posible Faltante" SortExpression="posibleFaltanteFlag" />
                                <asp:BoundField DataField="cambioRYS" HeaderText="cambio RYS" SortExpression="cambioRYS" />
                                <asp:BoundField DataField="fechaMovimiento" HeaderText="Fecha Movimiento" SortExpression="fechaMovimiento" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
    <%--Div Footer--%>
    <%--Fin Div Footer--%>
    </form>
    <div id="footer" style="width: 100%; position: inherit">
        Sistema Omega Ω </br> Hipotecaria Su Casita 2013
    </div>
</body>
</html>