<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntregaEquipo.aspx.cs"
    Inherits="InventarioHSC.EntregaEquipo" EnableEventValidation="false" %>

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
    <script src="../../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput-1.2.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.formatCurrency-1.0.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/additional-methods.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <link href="../../App_Themes/Estilos/table_jui.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/EstiloInv.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/mainMaster.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    </script>
    <style type="text/css">
        .style3
        {
            font-weight: bold;
            color: #FFFFFF;
            background: url('../../App_Themes/Imagenes/greenHeader.png') repeat-x;
            font-size: 12px;
            text-align: left;
            vertical-align: middle;
        }
        .style5
        {
            width: 499px;
        }
        .style6
        {
            width: 20%;
            text-align: left;
        }
        .style7
        {
            width: 13%;
        }
        .style9
        {
            width: 20%;
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
            width: 25%;
        }
        .style13
        {
            width: 8%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdnParametros" runat="server" />
    <%--Tabla header--%>
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
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="ui-state-error" id="Warning" runat="server">
                    <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                        <asp:Label ID="LabelError" runat="server" Text=""></asp:Label></strong></div>
                <div class="ui-state-highlight" id="Info" runat="server">
                    <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                        <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="ui-corner-all ui-widget ui-widget-content" id="space">
            <table width="100%">
                <tr>
                    <td class="CeldaImagenAzul">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.: USUARIO:.
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td class="style7">
                                No. de Responsiva:
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="txtResponsiva" runat="server" Enabled="true" Width="250px"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnBuscarResponsiva" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                                    Height="24px" Text="Buscar" ValidationGroup="vtgValidaBusquedaResponivas" Width="75px"
                                    OnClick="btnBuscarResponsiva_Click" CausesValidation="true" />
                                <asp:CustomValidator ID="cvUsuarioNoresponsiva" runat="server" SetFocusOnError="true"
                                    ErrorMessage='Introduzca la responsiva o Seleccione un Usuario' Display="None"
                                    ValidateEmptyText="true" ValidationGroup="vtgValidaBusquedaResponivas" ControlToValidate="txtResponsiva"
                                    ClientValidationFunction="ValidaUsuarioNoResponsiva_Cliente">
                                </asp:CustomValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceuarioNoresponsiva" TargetControlID="cvUsuarioNoresponsiva">
                                </asp:ValidatorCalloutExtender>
                                <%--<asp:RequiredFieldValidator ID="rfeResponsiva" runat="server" ErrorMessage="Introduzca la responsiva a buscar"
                                    ControlToValidate="txtResponsiva" ForeColor="White" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="vceResponsiva" runat="server" TargetControlID="rfeResponsiva">
                                </asp:ValidatorCalloutExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                Usuario Asignado:
                            </td>
                            <td class="style12">
                                <asp:DropDownList ID="ddlUsuarioAsignado" runat="server" Enabled="true" Width="250px">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cvUsuarioAsignado" runat="server" ValidationGroup="vgGuardaResponsiva"
                                    ControlToValidate="ddlUsuarioAsignado" ErrorMessage="Seleccione un usuario" Operator="NotEqual"
                                    Display="None" SetFocusOnError="true" ValueToCompare="1191">
                                </asp:CompareValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vcUsuarioAsiganado" TargetControlID="cvUsuarioAsignado">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td class="style16">
                                Puesto:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPuesto" runat="server" Height="24px" Width="250px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                Responsiva Anterior:
                            </td>
                            <td>
                                <asp:GridView ID="gvResponsivasAnteriores" runat="server"
                                AutoGenerateColumns="False"
                                EmptyDataText="No existe Informacion"
                                DataKeyNames="Identificador"
                                OnRowCommand="gvResponsivasAnteriores_RowCommand"
                                OnRowDataBound="gvResponsivasAnteriores_RowDataBound" Width="95%">
                                <HeaderStyle CssClass="Encabezado" ForeColor="Black" />
                                <HeaderStyle CssClass="CeldaImagenVerde" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E7D6A9" Font-Bold="True" />
                                <EmptyDataRowStyle BackColor="#DEDDF3" />
                                <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="ResponsivaAnterior" HeaderText="Responsiva"
                                        SortExpression="ResponsivaAnterior" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        </tr>--%>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table width="100%">
                <tr>
                    <td class="CeldaImagenAzul">
                        &nbsp;&nbsp;&nbsp;&nbsp;.: UBICACION :.
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <%--                    <tr>
                        <td class="style3" colspan="4">
                            Ubicación
                        </td>
                    </tr>--%>
                        <tr>
                            <td class="style6">
                                Ubicación:
                            </td>
                            <td align="left" class="style10">
                                <asp:DropDownList ID="ddlUbicacion" runat="server" Height="24px" Width="185px" Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <td align="left" class="style11">
                                Región:
                            </td>
                            <td align="left" class="style5" style="width: 25%">
                                <asp:TextBox ID="txtRegion" runat="server" Height="24px" Width="120px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table width="100%">
                <tr>
                    <td class="CeldaImagenAzul">
                        .: INFORMACIÓN DE EQUIPO ASIGNADO :.
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="center" class="CeldaImagenLightBlue" style="width: 40%">
                        Asignación Actual
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gwvArticuloAsignado" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="idItem" EmptyDataText="No existe Informacion" OnRowCommand="gwvArticuloAsignado_RowCommand"
                                    OnRowDataBound="gwvArticuloAsignado_RowDataBound" Width="95%">
                                    <HeaderStyle CssClass="Encabezado" ForeColor="Black" />
                                    <HeaderStyle CssClass="CeldaImagenVerde" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E7D6A9" Font-Bold="True" />
                                    <EmptyDataRowStyle BackColor="#DEDDF3" />
                                    <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Quitar" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:Image ID="imgEditar" runat="server" ImageUrl="~/App_Themes/Imagenes/ico_trashcan.gif"
                                                    ToolTip="Quitar Registro" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NoSerie" HeaderText="NoSerie" SortExpression="NoSerie" />
                                        <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo de Equipo" SortExpression="TipoEquipo" />
                                        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                                        <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" SortExpression="Ubicacion" />
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnQuitarTodo" runat="server" Text="Quitar Todo" CssClass="button2"
                                    Visible="false" OnClick="btnQuitarTodo_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lbtnfake" runat="server">
                        </asp:LinkButton>
                        <asp:ModalPopupExtender ID="mpeDetalle" runat="server" TargetControlID="panelAux"
                            CancelControlID="btnRegresar" PopupControlID="pnlPopUpDetalle" BackgroundCssClass="Shadow">
                        </asp:ModalPopupExtender>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <asp:Panel runat="server" ID="panelAux" Style="display: none;">
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlPopUpDetalle" Style="display: none;">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <table class="tablaW">
                            <tr>
                                <td colspan="4" class="CeldaImagenVerde">
                                    &nbsp; .: Detalle :.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Procesador:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProcesador" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                                </td>
                                <td>
                                    Memoria RAM:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMemoria" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sistema Operativo:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSistemaOperativo" runat="server" Enabled="false" Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Disco Duro:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscoDuro" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="ui-corner-all ui-state-default cancel"
                                        OnClick="btnRegresar_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
            <br />
            <div id="Botones" align="center">
                <asp:Button ID="btnSalir" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                    Text="Salir" Width="120px" OnClick="btnSalir_Click" />
                &nbsp;
                <asp:Button ID="btnGuardar" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                    Text="Guardar" Width="120px" OnClick="btnGuardar_Click" />
                &nbsp;
                <asp:Button ID="btnDocumento" runat="server" Text="VerDocumento" CssClass="ui-corner-all ui-state-default cancel"
                    OnClick="btnDocumento_Click" />
            </div>
        </div>
        <div>
        </div>
    </div>
    <%--Div Footer--%>
    <div id="footer">
        Sistema Omega Ω
        <br />
        Hipotecaria Su Casita 2013
    </div>
    <%--Fin Div Footer--%>
    </form>
</body>
<script type="text/javascript" language="javascript">
    var ddlUser = $('ddlUsuarioAsignado');
    var ddlUserpop = $('ddlpopUser');

    $('#btnOK').click(function () {
        alert("Has hecho clic");
    });

    function ValidaUsuarioNoResponsiva_Cliente(source, clientside_arguments) {
        clientside_arguments.IsValid = false;
        var value2 = $("#<%= ddlUsuarioAsignado.ClientID %>").val();

        jQuery.ajax({
            type: "POST",
            async: false,
            url: "ValidacionesJquery.aspx/IsValidaBusqueda",
            data: "{responsiva: '" + clientside_arguments.Value + "',usuario:'" + value2 + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                clientside_arguments.IsValid = msg.d;
            },
            error: function (msg) {
                clientside_arguments.IsValid = false;
            }
        });

        return clientside_arguments.IsValid;
    }

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args) {
        if (args.get_error() != undefined) {
            args.set_errorHandled(true);
        }
    }
</script>
</html>