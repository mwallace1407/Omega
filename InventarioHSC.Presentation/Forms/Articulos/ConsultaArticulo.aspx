<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaArticulo.aspx.cs"
    Inherits="InventarioHSC.ConsultaArticulo" Title="Consulta de Artículos" MasterPageFile="~/Forms/Main.Master"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="head" ContentPlaceHolderID="headMaster" runat="server">
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
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server">
        <div class="MainDiv" id="space">
            <div class="ui-state-error" id="Warning" runat="server" style="text-align: left">
                <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                    <asp:Label ID="LabelError" runat="server" Text=""></asp:Label></strong></div>
            <div class="ui-state-highlight" id="Info" runat="server" style="text-align: left">
                <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                    <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:Panel runat="server" ID="pnlPagina">
                <asp:HiddenField ID="hdnParametros" runat="server" />
                <asp:HiddenField ID="hddAuto" runat="server" />
                <div class="CeldaImagenAzul" style="text-align: center;">
                    .: Consulta de artículo en inventario :.
                </div>
                <br />
                <div style="width: 420px;">
                    <div style="float: left; width: 335px">
                        <div style="float: left; width: 160px;">
                            <asp:Label ID="lblSearch" runat="server">Localizar por No. de Serie:</asp:Label>
                        </div>
                        <div style="float: right; width: 175px">
                            <asp:TextBox ID="txtParametroBusqueda" runat="server" Width="168px" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div style="float: right; width: 85px">
                        <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" Text="Localizar"
                            CssClass="ui-corner-all ui-state-default cancel" OnClick="btnBuscar_Click"></asp:Button>
                    </div>
                </div>
                <div>
                    <asp:Label ID="lblInmueble" runat="server" Visible="False"></asp:Label>
                </div>
                <br />
                <br />
                <br />
                <div>
                    <div class="CeldaImagenAzul" style="text-align: left;">
                        .: Datos Generales del Artículo :.
                    </div>
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            No. de Serie:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtNoSerie" runat="server" Width="249px" Enabled="false" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Tipo de Artículo:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlTipoArticulo" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Marca:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlMarca" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Estado de Conservación:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlEstado" runat="server" Width="250px" Enabled="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Sistema Operativo:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlSistemaOperativo" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Modelo:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtModelo" runat="server" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Procesador:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtProcesador" runat="server" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Memoria RAM:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtMemoria" runat="server" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Disco Duro:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtDiscoDuro" runat="server" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
                <div>
                    <div class="CeldaImagenAzul" style="text-align: left;">
                        .: Información de la Compra :.
                    </div>
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Proveedor:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlProveedor" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            No. de Factura:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtFactura" runat="server" Enabled="false" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Fecha de Compra:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtFechaCompra" runat="server" Height="24px" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Valor en Pesos:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtValorPesos" runat="server" Enabled="false" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Valor en Dólares:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtValorDolares" runat="server" Enabled="false" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            No. de Requisición:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtRequisicion" runat="server" Enabled="false" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Centro de Costos de Adquisición:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtCCadquisicion" runat="server" Enabled="false" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
                <div>
                    <div class="CeldaImagenAzul" style="text-align: left;">
                        .: Información de Asignación de Usuario :.
                    </div>
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Usuario Asignado:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlUsuarioAsignado" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            No. de Responsiva:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtResponsiva" runat="server" Enabled="false" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Número de Castor:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtNoCastor" runat="server" Enabled="false" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Puesto:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtPuesto" runat="server" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Cambio RYS
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtCambioRYS" runat="server" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
                <div>
                    <div class="CeldaImagenAzul" style="text-align: left;">
                        .: Ubicación del Artículo :.
                    </div>
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Ubicación:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlUbicacion" runat="server" Width="250px" Enabled="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 395px;">
                        <div style="width: 140px; float: left; text-align: left;">
                            Región:
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:TextBox ID="txtRegion" runat="server" Width="249px" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
                <div>
                    <div class="CeldaImagenAzul" style="text-align: left;">
                        .: Observaciones :.
                    </div>
                    <br />
                    <div style="width: 978px">
                        <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" MaxLength="2000"
                            TextMode="MultiLine" Width="100%" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div id="Botones" style="text-align: center;">
                    <asp:Button ID="btnAccion" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                        Text="Editar" Width="120px" OnClick="btnAccion_Click" />
                    &nbsp;
                    <asp:Button ID="btnSalir" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                        Text="Salir" Width="120px" OnClick="btnSalir_Click" />
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
