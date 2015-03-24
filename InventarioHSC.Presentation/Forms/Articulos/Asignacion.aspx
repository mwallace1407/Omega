<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignacion.aspx.cs" Inherits="InventarioHSC.Asignacion"
    EnableEventValidation="false" Title="Asignación a Usuarios" MasterPageFile="~/Forms/Main.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="head" ContentPlaceHolderID="headMaster" runat="server">
    <script type="text/javascript">
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
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="ui-state-error" id="Warning" runat="server" style="text-align: left">
                    <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                        <asp:Label ID="LabelError" runat="server" Text=""></asp:Label></strong></div>
                <div class="ui-state-highlight" id="Info" runat="server" style="text-align: left">
                    <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                        <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
                <asp:HiddenField ID="hdnNuevaResponsiva" runat="server" Value="0" />
                <asp:HiddenField ID="hdnResponsivaAnterior" runat="server" Value="" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="MainDiv" id="space">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="CeldaImagenAzul">
                        .: NUEVA RESPONSIVA :.
                    </div>
                    <br />
                    <div style="width: 125px;">
                        <asp:Button ID="btnNueva" runat="server" Text="Generar nueva" CssClass="boton" Height="24px"
                            Width="125px" CausesValidation="false" OnClick="btnNueva_Click" />
                    </div>
                    <br />
                    <div class="CeldaImagenAzul">
                        .: BUSCAR RESPONSIVA :.
                    </div>
                    <br />
                    <asp:Panel ID="pnlBusquedaResponsiva" runat="server" DefaultButton="btnBuscarResponsiva">
                        <div style="width: 453px;">
                            <div style="width: 370px; float: left;">
                                <div style="width: 115px; float: left; text-align: left;">
                                    No. de Responsiva:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:TextBox ID="txtResponsiva" runat="server" Enabled="true" Width="250px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvUsuarioNoresponsiva" runat="server" SetFocusOnError="true"
                                        ErrorMessage='Introduzca la responsiva o Seleccione un Usuario' Display="None"
                                        ValidateEmptyText="true" ValidationGroup="vtgValidaBusquedaResponivas" ControlToValidate="txtResponsiva"
                                        ClientValidationFunction="ValidaUsuarioNoResponsiva_Cliente">
                                    </asp:CustomValidator>
                                    <asp:ValidatorCalloutExtender runat="server" ID="vceuarioNoresponsiva" TargetControlID="cvUsuarioNoresponsiva">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <div style="width: 83px; float: right;">
                                <asp:Button ID="btnBuscarResponsiva" runat="server" CssClass="boton" Height="24px"
                                    Text="Buscar" ValidationGroup="vtgValidaBusquedaResponivas" Width="75px" OnClick="btnBuscarResponsiva_Click"
                                    CausesValidation="true" />
                            </div>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                    <div style="width: 370px;">
                        <div style="width: 115px; float: left; text-align: left;">
                            Usuario Asignado:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlUsuarioAsignado" runat="server" Enabled="true" Width="250px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvUsuarioAsignado" runat="server" ValidationGroup="vgGuardaResponsiva"
                                ControlToValidate="ddlUsuarioAsignado" ErrorMessage="Seleccione un usuario" Operator="NotEqual"
                                Display="None" SetFocusOnError="true" ValueToCompare="1191">
                            </asp:CompareValidator>
                            <asp:ValidatorCalloutExtender runat="server" ID="vcUsuarioAsiganado" TargetControlID="cvUsuarioAsignado">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 370px;">
                        <div style="width: 115px; float: left; text-align: left;">
                            Puesto:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtPuesto" runat="server" Width="250px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 570px;">
                        <div style="width: 115px; float: left; text-align: left;">
                            Responsiva Anterior:
                        </div>
                        <div style="width: 455px; float: right;">
                            <asp:GridView ID="gvResponsivasAnteriores" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No existe Informacion" DataKeyNames="Identificador" OnRowCommand="gvResponsivasAnteriores_RowCommand"
                                OnRowDataBound="gvResponsivasAnteriores_RowDataBound" Width="95%">
                                <HeaderStyle CssClass="Encabezado" ForeColor="Black" />
                                <HeaderStyle CssClass="CeldaImagenVerde" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E7D6A9" Font-Bold="True" />
                                <EmptyDataRowStyle BackColor="#DEDDF3" />
                                <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="ResponsivaAnterior" HeaderText="Responsiva" SortExpression="ResponsivaAnterior" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="CeldaImagenAzul">
                        .: EQUIPO ASIGNADO :.
                    </div>
                    <br />
                    <div class="CeldaImagenLightBlue">
                        Equipo a Asignar&nbsp<asp:TextBox ID="txtidItem" runat="server" Visible="false"></asp:TextBox>
                    </div>
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            Filtrar Por Tipo de Equipo:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlTipoArticulo" runat="server" AutoPostBack="true" Enabled="false"
                                Width="250px" OnSelectedIndexChanged="ddlTipoArticulo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            Filtrar Por Marca:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlMarca" AppendDataBoundItems="true" runat="server" Enabled="false"
                                Width="250px">
                                <asp:ListItem Text="" Value="0" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            Filtrar Por Ubicacion:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="dplUbicacionFiltro" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            Modelo:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtModelo" runat="server" Enabled="false" Width="250px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            No. de Serie:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtNoSerie" runat="server" Enabled="true" ValidationGroup="SerieReq"
                                Width="250px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            Incluir:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:CheckBox ID="chkSN" Text="S/N" runat="server" ToolTip="Sin Numero de Serie" />
                            <asp:CheckBox ID="chkIlegible" runat="server" Text="Ilegible" ToolTip="Serie Ilegible" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:Button ID="btnBuscarArticulo" runat="server" Enabled="false" CausesValidation="true"
                                CssClass="boton" Height="24px" OnClick="btnBuscarArticulo_Click" Text="Buscar"
                                ValidationGroup="SerieReq" Width="75px" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div>
                        <asp:ImageButton ID="imgAgregar" runat="server" Height="24px" ImageUrl="~/App_Themes/Imagenes/Plus_green.png"
                            OnClick="imgAgregar_Click" Visible="false" Width="25px" />
                    </div>
                    <div class="CeldaImagenLightBlue">
                        Asignación Actual
                    </div>
                    <div style="width: 80%">
                        <asp:Panel ID="pnlAsignacionActual" runat="server" Height="200" ScrollBars="Auto">
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
                                    <%--<asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Image ID="imgEditar" runat="server" ImageUrl="~/App_Themes/Imagenes/ico_trashcan.gif" />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>--%>
                                    <asp:ButtonField CommandName="Eliminar" ButtonType="Image" HeaderText="Eliminar"
                                        ImageUrl="~/App_Themes/Imagenes/ico_trashcan.gif" />
                                    <asp:BoundField DataField="NoSerie" HeaderText="NoSerie" SortExpression="NoSerie" />
                                    <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo de Equipo" SortExpression="TipoEquipo" />
                                    <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                                    <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" SortExpression="Ubicacion" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <br />
                    <br />
                    <div class="CeldaImagenAzul">
                        .: UBICACION :.
                    </div>
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            Ubicación:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlUbicacion" Enabled="false" AutoPostBack="true" runat="server"
                                Height="24px" Width="250px" Style="margin-left: 0px" OnSelectedIndexChanged="ddlUbicacion_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvUbicacionEquipo" runat="server" ValidationGroup="vgGuardaResponsiva"
                                ControlToValidate="ddlUbicacion" ErrorMessage="Seleccione una Ubicación" Operator="NotEqual"
                                Display="None" SetFocusOnError="true" ValueToCompare="0">
                            </asp:CompareValidator>
                            <asp:ValidatorCalloutExtender runat="server" ID="vceUbicacionEquipo" TargetControlID="cvUbicacionEquipo">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 410px;">
                        <div style="width: 155px; float: left; text-align: left;">
                            Región:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtRegion" runat="server" ReadOnly="true" Height="24px" Width="250px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="CeldaImagenAzul">
                        .: OBSERVACIONES :.
                    </div>
                    <br />
                    <asp:Panel runat="server" ID="pnlObservaciones">
                        <div style="width: 978px">
                            <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" MaxLength="2000"
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                    <div id="Botones" style="text-align: center">
                        <asp:Button ID="btnSalir" runat="server" CssClass="boton" Text="Salir" Width="120px"
                            OnClick="btnSalir_Click" CausesValidation="false" />
                        &nbsp;
                        <asp:Button ID="btnGuardar" runat="server" CssClass="boton" Text="Guardar" Width="120px"
                            ValidationGroup="vgGuardaResponsiva" CausesValidation="true" OnClick="btnGuardar_Click" />
                        &nbsp;
                        <asp:Button ID="btnDocumento" runat="server" Text="Ver Documento" Enabled="false"
                            CssClass="boton" OnClick="btnDocumento_Click1" CausesValidation="false" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Panel ID="panelito" runat="server" Style="display: none">
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlPopUpDetalle" Style="display: none">
            <div class="CeldaImagenLightBlue">
                .: Detalle :.
            </div>
            <br />
            <div style="width: 360px;">
                <div style="width: 105px; float: left; text-align: left;">
                    Procesador:
                </div>
                <div style="width: 255px; float: right;">
                    <asp:TextBox ID="txtProcesador" runat="server" Enabled="false" Width="250px"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 360px;">
                <div style="width: 105px; float: left; text-align: left;">
                    Memoria RAM:
                </div>
                <div style="width: 255px; float: right;">
                    <asp:TextBox ID="txtMemoria" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 360px;">
                <div style="width: 105px; float: left; text-align: left;">
                    Sistema Operativo:
                </div>
                <div style="width: 255px; float: right;">
                    <asp:DropDownList ID="ddlSistemaOperativo" runat="server" Enabled="false" Width="250px">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 360px;">
                <div style="width: 105px; float: left; text-align: left;">
                    Disco Duro:
                </div>
                <div style="width: 255px; float: right;">
                    <asp:TextBox ID="txtDiscoDuro" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 360px; text-align: center;">
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="boton" />
            </div>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlShowAlert" Style="display: none">
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlAlert" Style="display: none">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="tablaW" style="width: 280px;">
                        <div class="CeldaImagenAzul" style="text-align: center;">
                            <asp:Label ID="lblAlerta" runat="server" Text="Asignación">
                            </asp:Label>
                        </div>
                        <div style="height: 130px; background-color: WhiteSmoke;">
                            <br />
                            <br />
                            <asp:Label ID="lblAlertaMsj" runat="server" Text="Seleccione el usuario al que se le asignará equipo"></asp:Label>
                            <br />
                            <br />
                            <asp:DropDownList ID="ddlpopUser" runat="server" Width="250px" Enabled="true">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Button ID="btnOk" runat="server" CssClass="boton" Text="Aceptar" OnClick="btnOk_Click"
                                CausesValidation="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlAuxBusquedaArticulo" Style="display: none">
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlBusquedaArticulo" Style="display: none" Width="560px">
            <div class="tablaW" style="width: 560px;">
                <div class="CeldaImagenAzul" style="text-align: center;">
                    .: Busqueda de Articulo :.
                </div>
            </div>
            <div style="height: 330px; background-color: WhiteSmoke;">
                <br />
                <div style="width: 530px; margin-left: auto; margin-right: auto;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grvFiltroArticulos" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="idItem" EmptyDataText="No existe Informacion" AllowPaging="true"
                                PageSize="10" Width="530" OnPageIndexChanging="grvFiltroArticulos_PageIndexChanging"
                                OnPageIndexChanged="grvFiltroArticulos_PageIndexChanged">
                                <HeaderStyle CssClass="Encabezado" ForeColor="Black" />
                                <HeaderStyle CssClass="CeldaImagenVerde" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E7D6A9" Font-Bold="True" />
                                <EmptyDataRowStyle BackColor="#DEDDF3" />
                                <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelecciona" runat="server" />
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
                </div>
                <br />
                <div>
                    <div style="width: 50%; float: left; text-align: center;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnGurdar" runat="server" CssClass="boton" Text="Aceptar" OnClick="btnAceptar_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="width: 50%; float: right; text-align: center;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnRegresarDetalle" CssClass="boton" runat="server" Text="Regresar"
                                    OnClick="btnRegresarDetalle_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="AuxMensajeEliminarTodos">
        </asp:Panel>
        <asp:Panel runat="server" ID="MensajeEliminarTodos" Width="560px" Style="display: none;">
            <table style="width: 100%" class="tablaW">
                <tr>
                    <td colspan="2" class="CeldaImagenAzul" style="text-align: center; text-align: center;">
                        .: Liberación de Artículos :.
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Desea liberar todos los artículos de esta responsiva?
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: center;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnCancelarLiberacion" CssClass="boton" runat="server" Text="Regresar"
                                    OnClick="btnCancelarLiberacion_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 50%; text-align: center;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnAceptarLineracion" runat="server" CssClass="boton" Text="Aceptar"
                                    OnClick="btnAceptarLineracion_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <asp:ModalPopupExtender ID="mpeLiberacionArticulos" runat="server" TargetControlID="AuxMensajeEliminarTodos"
            DropShadow="true" PopupControlID="MensajeEliminarTodos" BackgroundCssClass="Shadow">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeDetalle" runat="server" TargetControlID="panelito"
            DropShadow="true" CancelControlID="btnRegresar" PopupControlID="pnlPopUpDetalle"
            BackgroundCssClass="Shadow">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeBusquedaArticulo" runat="server" TargetControlID="pnlAuxBusquedaArticulo"
            DropShadow="true" PopupControlID="pnlBusquedaArticulo" BackgroundCssClass="Shadow">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpeAlert" runat="server" TargetControlID="pnlShowAlert"
            DropShadow="true" PopupControlID="pnlAlert" BackgroundCssClass="Shadow">
        </asp:ModalPopupExtender>
    </div>
</asp:Content>
