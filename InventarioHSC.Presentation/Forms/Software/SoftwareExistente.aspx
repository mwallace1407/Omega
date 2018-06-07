<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SoftwareExistente.aspx.cs"
    Inherits="InventarioHSC.Forms.Software.SoftwareExistente" MasterPageFile="~/Forms/Main.Master"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="head" ContentPlaceHolderID="headMaster" runat="server">
    <title>Consulta de Software</title>
    <%--<script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/ui.datepicker-es.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput-1.2.2.js" type="text/javascript"></script>--%>
    <link href="../../App_Themes/Estilos/estilo1.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../App_Themes/Estilos/estilo1a.css" rel="stylesheet" type="text/css" />--%>
    <script src="../../Scripts/FusionCharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server">
        <div class="MainDiv" id="space">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="ui-state-error" id="Warning" runat="server" style="text-align: left">
                                <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                                    <asp:Label ID="LabelWarning" runat="server" Text=""></asp:Label></strong></div>
                            <div class="ui-state-highlight" id="Info" runat="server" style="text-align: left">
                                <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                                    <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                        .: NUEVO SOFTWARE :.
                    </div>
                    <br />
                    <div style="text-align: left;">
                        <asp:Button ID="btnAgregarSoft" runat="server" ToolTip="Agregar Software" Text="Agregar"
                            CssClass="ui-corner-all ui-state-default cancel" OnClick="btnAgregarSoft_Click" />
                    </div>
                    <br />
                    <br />
                    <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                        .: SOFTWARE :.
                    </div>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="width: 370px;">
                <div style="width: 115px; float: left; text-align: left;">
                    <asp:Label runat="server" ID="lblDescipSoft" Text="Nombre Software:"></asp:Label>
                </div>
                <div style="width: 255px; float: right;">
                    <asp:TextBox runat="server" ID="DescripcionSoftware" Width="250"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 370px;">
                <div style="width: 115px; float: left; text-align: left;">
                    <asp:Label runat="server" ID="lblVersion" Text="Version"></asp:Label>
                </div>
                <div style="width: 255px; float: right;">
                    <asp:TextBox runat="server" ID="txtVersion" MaxLength="50" Width="250"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 370px;">
                <div style="width: 115px; float: left; text-align: left;">
                    <asp:Label runat="server" ID="lblCantidad" Text="Cantidad"></asp:Label>
                </div>
                <div style="width: 255px; float: right;">
                    <asp:TextBox runat="server" ID="txtCantidad" MaxLength="5" Width="250"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="REV1" ErrorMessage="<p>*Solo se admiten números"
                        ControlToValidate="txtCantidad" ValidationGroup="vgBusqueda" runat="server" Display="none"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                    <asp:ValidatorCalloutExtender runat="server" ID="vceCantidad" TargetControlID="REV1">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="text-align: center;">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnBuscar" Width="80px" runat="server" Height="24px" Text="Buscar"
                            CausesValidation="true" ValidationGroup="vgBusqueda" CssClass="ui-corner-all ui-state-default cancel"
                            OnClick="btnBuscar_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" Width="80px" runat="server" Text="Salir" CssClass="ui-corner-all ui-state-default cancel"
                            CausesValidation="false" OnClick="btnCancelar_Click" Height="24px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <br />
            <div style="text-align: left;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="ExportaExcel" runat="server" ToolTip="Catalogo de Software"
                            ImageUrl="~/App_Themes/Imagenes/Excel-icon.png" OnClick="ExportaExcel_Click" />
                        Exportar a excel
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hdnCve_Software" runat="server" Value="0" />
                        <asp:HiddenField ID="hdnCve_Asignacion" runat="server" Value="0" />
                        <asp:HiddenField ID="hdnGenerrarControles" runat="server" Value="0" />
                        <asp:GridView ID="gvwSoftware" runat="server" AutoGenerateColumns="False" DataKeyNames="Cve_Software"
                            Width="90%" EmptyDataText="No existe Informacion" AllowPaging="True" OnPageIndexChanging="gvwSoftware_PageIndexChanging"
                            PageSize="20" OnRowCommand="gvwSoftware_RowCommand" OnRowDataBound="gvwSoftware_RowDataBound">
                            <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                            <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                            <PagerSettings Mode="NextPreviousFirstLast" />
                            <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                            <EmptyDataRowStyle BackColor="#DEDDF3" />
                            <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                            <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="Editar" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:Image ID="imgEditar" runat="server" ToolTip="Editar Registro" ImageUrl="~/App_Themes/Imagenes/pencil.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cve_Software" HeaderText="Clave" InsertVisible="False"
                                    ReadOnly="True" SortExpression="Cve_Software" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Nombre Licencia" InsertVisible="False"
                                    ReadOnly="True" SortExpression="Descripcion" />
                                <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                                <asp:BoundField DataField="NumeroLicencias" HeaderText="Cantidad de Licencias" SortExpression="NoLicencias" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <br />
            <div class="CeldaImagenLightBlue">
                Resumen de Totales
            </div>
            <br />
            <br />
            <div>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvTotalTipo" runat="server" AutoGenerateColumns="False" Width="65%"
                            EmptyDataText="No existe Informacion" AllowPaging="False">
                            <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                            <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                            <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                            <EmptyDataRowStyle BackColor="#DEDDF3" />
                            <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                            <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="concepto" HeaderText="Concepto" InsertVisible="False"
                                    ReadOnly="True" SortExpression="concepto" />
                                <asp:BoundField DataField="conteo" HeaderText="Cantidad" SortExpression="Concepto" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <div style="text-align: left">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="btnExcelDetalleE" runat="server" ToolTip="Asignación de Software"
                            ImageUrl="~/App_Themes/Imagenes/Excel-icon.png" OnClick="btnExcelDetalleE_Click" />
                        <asp:Button ID="btnAgregarDetalle" Enabled="false" ToolTip="Agregar Licencia de Software"
                            CssClass="ui-corner-all ui-state-default cancel" runat="server" Text="Agregar"
                            OnClick="btnAgregarDetalle_Click" />
                        &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div style="overflow: auto">
                            <asp:GridView ID="gvwDetalle" runat="server" AutoGenerateColumns="False" DataKeyNames="Cve_Asignacion"
                                Width="100%" EmptyDataText="No existe Informacion" AllowPaging="True" OnPageIndexChanging="gvwDetalle_PageIndexChanging"
                                PageSize="15" OnRowCommand="gvwDetalle_RowCommand" OnRowDataBound="gvwDetalle_RowDataBound">
                                <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                <PagerSettings Mode="NextPreviousFirstLast" />
                                <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                <EmptyDataRowStyle BackColor="#DEDDF3" />
                                <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Editar" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Image ID="imgEditar" runat="server" ToolTip="Editar Registro" ImageUrl="~/App_Themes/Imagenes/pencil.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Cve_Software" HeaderText="Clave" InsertVisible="False"
                                        ReadOnly="True" SortExpression="Cve_Software" Visible="false" />
                                    <asp:BoundField DataField="Nombre_Usuario" HeaderText="Nombre Usuario" InsertVisible="False"
                                        ReadOnly="True" SortExpression="Nombre_Usuario" />
                                    <asp:BoundField DataField="Key" HeaderText="Key" InsertVisible="False" ReadOnly="True"
                                        SortExpression="Key" />
                                    <asp:BoundField DataField="Lenguaje" HeaderText="Lenguaje" SortExpression="Lenguaje" />
                                    <asp:BoundField DataField="Material" HeaderText="Material" SortExpression="Material" />
                                    <asp:BoundField DataField="Area_Solicita" HeaderText="Area Solicita" SortExpression="Area_Solicita" />
                                    <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" />
                                    <asp:BoundField Visible="false" DataField="Lote_Code" HeaderText="Lote Code" SortExpression="Lote_Code" />
                                    <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" SortExpression="Proveedor   " />
                                    <asp:BoundField DataField="Numero_Factura" Visible="false" HeaderText="Numero Factura"
                                        SortExpression="Numero_Factura" />
                                    <asp:BoundField DataField="Numero_Requisicion_Compra" Visible="false" HeaderText="Requisicion Compra"
                                        SortExpression="Numero_Requisicion_Compra" />
                                    <asp:BoundField DataField="Centro_Costo" Visible="false" HeaderText="Centro de Costo"
                                        SortExpression="Centro_Costo" />
                                    <asp:BoundField DataField="Pesos" HeaderText="Pesos" SortExpression="Pesos" />
                                    <asp:BoundField DataField="Dolares" HeaderText="Dolares" SortExpression="Dolares" />
                                    <asp:BoundField DataField="Incluido_Responsiva" Visible="false" HeaderText="Incluido Responsiva"
                                        SortExpression="Incluido_Responsiva" />
                                    <asp:BoundField DataField="Fecha_Vencimiento" HeaderText="Fecha de Vencimiento" SortExpression="Fecha_Vencimiento" />
                                    <asp:BoundField DataField="Numero_Taejeta" Visible="false" HeaderText="Numero Tarjeta"
                                        SortExpression="Numero_Taejeta" />
                                    <asp:BoundField DataField="Responsiva" Visible="false" HeaderText="Responsiva" SortExpression="Responsiva" />
                                    <asp:BoundField DataField="Observaciones" Visible="false" HeaderText="Observaciones"
                                        SortExpression="Observaciones" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <asp:Panel runat="server" ID="pnlAuxiliar" Style="display: none;">
                    <asp:Panel runat="server" ID="ActualizaDatos" Width="250px" Height="170px" Style="display: none;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </asp:Panel>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="ActualizaDatosd" Width="250px" Height="170px" Style="display: none;"
        BackColor="White">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table class="tablaW" style="width: 100%">
                    <tr>
                        <td colspan="2" class="CeldaImagenVerde" align="center" style="width: 100%; text-align: center;">
                            <asp:Label runat="server" ID="lblInfo" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            <asp:Label runat="server" ID="Label1" Text="Nombre Licencia:"></asp:Label>
                        </td>
                        <td style="width: 60%">
                            <asp:TextBox runat="server" ID="txtNombreLicenciaU" MaxLength="250"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombreLicenciaU" runat="server" ControlToValidate="txtNombreLicenciaU"
                                CssClass="label" ErrorMessage='El campo "Nombre Licencia" es requerido' ToolTip='El campo "Nombre Licencia" es requerido'
                                Display="None" SetFocusOnError="true" ValidationGroup="vgEditarRegistro">*
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender runat="server" ID="vceNombreLicenciaU" TargetControlID="rfvNombreLicenciaU">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" ID="Label2" Text="Version:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVersionU" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvVersionU" runat="server" ControlToValidate="txtVersionU"
                                CssClass="label" ErrorMessage='El campo "Version" es requerido' ToolTip='El campo "Version" es requerido'
                                Display="None" SetFocusOnError="true" ValidationGroup="vgEditarRegistro">*
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender runat="server" ID="vceVersionU" TargetControlID="rfvVersionU">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" ID="Label3" Text="Cantidad:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCantidadU" MaxLength="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCantidadU" runat="server" ControlToValidate="txtCantidadU"
                                CssClass="label" ErrorMessage='El campo "Cantidad" es requerido' ToolTip='El campo "Cantidad" es requerido'
                                Display="None" SetFocusOnError="true" ValidationGroup="vgEditarRegistro">*
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender runat="server" ID="vceCantidadU" TargetControlID="rfvCantidadU">
                            </asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator ID="revCantidadU" ErrorMessage="<p>*Solo se admiten números"
                                ControlToValidate="txtCantidadU" ValidationGroup="vgEditarRegistro" runat="server"
                                Display="none" ValidationExpression="\d+">
                            </asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender runat="server" ID="cveCantidadU" TargetControlID="revCantidadU">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnRegresar" Width="80px" Height="24px" runat="server" CausesValidation="false"
                                        Text="Regresar" CssClass="ui-corner-all ui-state-default cancel" OnClick="btnRegresar_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Height="24px" ValidationGroup="vgEditarRegistro"
                                        CssClass="ui-corner-all ui-state-default cancel" CausesValidation="true" OnClick="btnGuardar_Click"
                                        Width="80px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlAuxDetalle" Style="display: none;">
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlDetalle" Width="480px" Height="600px" Style="display: none;">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="dv" style="overflow: auto; height: 580; width: 440px;">
                    <asp:Table ID="TableDetalle" CssClass="tablaW" Width="100%" runat="server">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" CssClass="CeldaImagenVerde" Width="100%" Style="text-align: center;">
                                <asp:Label runat="server" ID="lblTituloPanelDetalle" Text=""></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label4" Text="Numero de Licencia a Agregar" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="dplNUmeroLicencia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dplNUmeroLicencia_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cvNumeroLicen" runat="server" ValidationGroup="vgEditarDetalleRegistro"
                                    ControlToValidate="dplNUmeroLicencia" ErrorMessage="Seleccione el numero de Licencias"
                                    Operator="NotEqual" Display="None" SetFocusOnError="true" ValueToCompare="0"></asp:CompareValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vcVantidadLicenias" TargetControlID="cvNumeroLicen">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label5" Text="Nombre Usuario:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtNombreUsuarioD" ReadOnly="true" MaxLength="250"
                                    Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvNombreUsuarioD" runat="server" ControlToValidate="txtNombreUsuarioD"
                                    CssClass="label" ErrorMessage='El campo "Nombre Usuario" es requerido' ToolTip='El campo "Nombre Usuario" es requerido'
                                    Display="None" SetFocusOnError="true" ValidationGroup="vgEditarDetalleRegistro">*
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceNombreUsuarioD" TargetControlID="rfvNombreUsuarioD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label Text="Key:" runat="server" ID="lblKeyDetalle" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtKeyD" Width="200px" MaxLength="100" />
                                <asp:RequiredFieldValidator ID="rfvKeyD" runat="server" ControlToValidate="txtKeyD"
                                    CssClass="label" ErrorMessage='El campo "Key" es requerido' ToolTip='El campo "Key" es requerido'
                                    Display="None" SetFocusOnError="true" ValidationGroup="vgEditarDetalleRegistro">*
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceKeyD" TargetControlID="rfvKeyD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label6" Text="Lenguaje:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtLenguajeD" Width="200px" MaxLength="50" />
                                <asp:RequiredFieldValidator ID="rfvLenguajeD" runat="server" ControlToValidate="txtLenguajeD"
                                    CssClass="label" ErrorMessage='El campo "Lenguaje" es requerido' ToolTip='El campo "Lenguaje" es requerido'
                                    Display="None" SetFocusOnError="true" ValidationGroup="vgEditarDetalleRegistro">*
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceLenguajeD" TargetControlID="rfvLenguajeD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label7" Text="Material:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtMaterialD" Width="200px" MaxLength="50" />
                                <asp:RequiredFieldValidator ID="rfvMaterialD" runat="server" ControlToValidate="txtMaterialD"
                                    CssClass="label" ErrorMessage='El campo "Material" es requerido' ToolTip='El campo "Material" es requerido'
                                    Display="None" SetFocusOnError="true" ValidationGroup="vgEditarDetalleRegistro">*
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceMaterialD" TargetControlID="rfvMaterialD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label8" Text="Area Solicita:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtAreaSolicitaD" Width="200px" MaxLength="50" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label9" Text="Sucursal:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtSucursalD" Width="200px" MaxLength="50" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label10" Text="Lote_Code:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtLoteCodeD" Width="200px" MaxLength="100" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label11" Text="Proveedor:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtProveedorD" Width="200px" MaxLength="250" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label12" Text="Numero Factura:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtNoFacturaD" Width="200px" />
                                <asp:RegularExpressionValidator ID="rfvNoFacturaD" ErrorMessage="<p>*Solo se admiten números"
                                    ControlToValidate="txtCantidad" ValidationGroup="vgEditarDetalleRegistro" runat="server"
                                    Display="none" ValidationExpression="\d+">
                                </asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceNoFacturaD" TargetControlID="rfvNoFacturaD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label13" Text="Fecha Compra:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtFechaCompraD" Width="200px" />
                                <asp:CustomValidator ID="cvFechaCompraD" runat="server" SetFocusOnError="true" ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy"
                                    Display="None" ValidateEmptyText="false" ValidationGroup="vgEditarDetalleRegistro"
                                    ControlToValidate="txtFechaCompraD" ClientValidationFunction="ValidaFecha_Cliente">
                                </asp:CustomValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceValidaFechaCompraD" TargetControlID="cvFechaCompraD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label14" Text="Numero Requisicion Compra:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtNoRequisicionCompraD" Width="200px" />
                                <asp:RegularExpressionValidator ID="revNoRequisicionCompraD" ErrorMessage="<p>*Solo se admiten números"
                                    ControlToValidate="txtNoRequisicionCompraD" ValidationGroup="vgEditarDetalleRegistro"
                                    runat="server" Display="none" ValidationExpression="\d+">
                                </asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceNoRequisicionCompraD" TargetControlID="revNoRequisicionCompraD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label15" Text="Centro_Costo:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtCentroCostosD" Width="200px" MaxLength="50" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label16" Text="Pesos:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtPesosD" Width="200px" />
                                <asp:CustomValidator ID="cvPesosD" runat="server" SetFocusOnError="true" ErrorMessage="El formato es incorrecto"
                                    Display="None" ValidateEmptyText="false" ValidationGroup="vgEditarDetalleRegistro"
                                    ControlToValidate="txtPesosD" ClientValidationFunction="ValidaDecimal_Cliente">
                                </asp:CustomValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vcePesosD" TargetControlID="cvPesosD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label17" Text="Dolares:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtDolaresD" Width="200px" />
                                <asp:CustomValidator ID="cvDolaresD" runat="server" SetFocusOnError="true" ErrorMessage="El formato es incorrecto"
                                    Display="None" ValidateEmptyText="false" ValidationGroup="vgEditarDetalleRegistro"
                                    ControlToValidate="txtDolaresD" ClientValidationFunction="ValidaDecimal_Cliente">
                                </asp:CustomValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceDolaresD" TargetControlID="cvDolaresD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label18" Text="Incluido_Responsiva:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtIncluido_ResponsivaD" Width="200px" MaxLength="50" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label19" Text="Fecha Vencimiento:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtFechaVencimientoD" Width="200px" />
                                <asp:CustomValidator ID="cvFechaVencimientoD" runat="server" SetFocusOnError="true"
                                    ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy" Display="None"
                                    ValidateEmptyText="false" ValidationGroup="vgEditarDetalleRegistro" ControlToValidate="txtFechaVencimientoD"
                                    ClientValidationFunction="ValidaFecha_Cliente">
                                </asp:CustomValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceFechaVencimientoD" TargetControlID="cvFechaVencimientoD">
                                </asp:ValidatorCalloutExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label20" Text="Numero Tarjeta:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtNoTarjetaD" Width="200px" MaxLength="100" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label21" Text="Responsiva:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="txtResponsivaD" Width="200px" MaxLength="50" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label22" Text="Observaciones:" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtObservacionD" Width="200px" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                &nbsp;&nbsp;&nbsp;
                            </asp:TableCell>
                            <asp:TableCell>
                                &nbsp;&nbsp;&nbsp;
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:Button ID="btnRegresarD" Width="80px" runat="server" Text="Regresar" CausesValidation="false"
                                    CssClass="ui-corner-all ui-state-default cancel" OnClick="btnRegresarD_Click" />
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:Button ID="btnGuardaDetalle" ValidationGroup="vgEditarDetalleRegistro" Width="80px"
                                    runat="server" Text="Guardar" CssClass="ui-corner-all ui-state-default cancel"
                                    CausesValidation="true" OnClick="btnGuardaDetalle_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                &nbsp;&nbsp;&nbsp;
                            </asp:TableCell>
                            <asp:TableCell>
                                &nbsp;&nbsp;&nbsp;
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ModalPopupExtender ID="mpeDetalleAsignacion" Y="20" runat="server" TargetControlID="pnlAuxDetalle"
        PopupControlID="pnlDetalle" BackgroundCssClass="Shadow" />
    <asp:ModalPopupExtender ID="mpeDatosSoftware" runat="server" TargetControlID="pnlAuxiliar"
        PopupControlID="ActualizaDatos" BackgroundCssClass="Shadow" />
    <script language="javascript" type="text/javascript">

        function ValidaFecha_Cliente(source, clientside_arguments) {
            clientside_arguments.IsValid = false;

            jQuery.ajax({
                type: "POST",
                async: false,
                url: "SoftwareExistente.aspx/IsDateValid",
                data: "{date: '" + clientside_arguments.Value + "'}",
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

        function ValidaDecimal_Cliente(source, clientside_arguments) {
            clientside_arguments.IsValid = false;

            jQuery.ajax({
                type: "POST",
                async: false,
                url: "SoftwareExistente.aspx/IsDecimalValid",
                data: "{monto: '" + clientside_arguments.Value + "'}",
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

        function updateChartTotalesSoftware(arg) {
            if (arg != "") {
                var chart_GraficaDetalle = new FusionCharts("../../FusionCharts/Pie3D.swf", "graTotales", "500", "300", "0", "0", "0");
                chart_GraficaDetalle.setDataXML(arg);
                chart_GraficaDetalle.setTransparent(false);
                chart_GraficaDetalle.render("graTotalesDiv");
            }
            else {
                var chart_GraficaDetalle = new FusionCharts("../../FusionCharts/Pie3D.swf", "graTotales", "500", "300", "0", "0", "0");
                chart_GraficaDetalle.setDataXML("<chart></chart>");
                chart_GraficaDetalle.setTransparent(false);
                chart_GraficaDetalle.render("graTotalesDiv");
            }
        }
    </script>
</asp:Content>