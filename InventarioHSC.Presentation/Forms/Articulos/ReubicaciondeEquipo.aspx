<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReubicaciondeEquipo.aspx.cs"
    Inherits="InventarioHSC.ReubicaciondeEquipo" EnableEventValidation="false" Title="Reubicación de Artículos"
    MasterPageFile="~/Forms/Main.Master" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="head" ContentPlaceHolderID="headMaster" runat="server">
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/ui.datepicker-es.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput-1.2.2.js" type="text/javascript"></script>
    <link href="../../App_Themes/Estilos/estilo1.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" rel="stylesheet"
        type="text/css" />
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
            <asp:UpdatePanel runat="server" ID="upnlPanel">
                <ContentTemplate>
                    <div class="CeldaImagenAzul" style="text-align: center;">
                        .: Monitor de Búsqueda de Artículos :.
                    </div>
                    <br />
                    <div style="text-align: center;">
                        <div style="width: 520px; margin-left: auto; margin-right: auto;">
                            <asp:CheckBoxList ID="chklstFiltros" runat="server" Height="16px" RepeatDirection="Horizontal"
                                Width="517px" OnSelectedIndexChanged="chklstFiltros_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>Ubicacion</asp:ListItem>
                                <asp:ListItem>Usuario</asp:ListItem>
                                <asp:ListItem>Articulo</asp:ListItem>
                                <asp:ListItem>Número de Serie</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <br />
                    <div style="width: 360px;">
                        <div style="width: 105px; float: left; text-align: left;">
                            <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación:"></asp:Label>
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlUbicacion" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 360px;">
                        <div style="width: 105px; float: left; text-align: left;">
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario Asignado:"></asp:Label>
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlUsuario" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 360px;">
                        <div style="width: 105px; float: left; text-align: left;">
                            <asp:Label ID="lblTipoArticulo" runat="server" Text="Tipo de Articulo:"></asp:Label>
                        </div>
                        <div style="width: 255px; float: right;">
                            <asp:DropDownList ID="ddlTipoArticulo" runat="server" Enabled="false" Width="250px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 515px; height: 90px">
                        <div style="width: 105px; float: left; text-align: left;">
                            Número de Serie:
                        </div>
                        <div style="width: 410px; float: right;">
                            <asp:TextBox ID="txtNoSerie" runat="server" Enabled="false" Height="85px" TextMode="MultiLine"
                                Width="410px"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 515px;">
                        <div style="width: 105px; float: left; text-align: left;">
                        </div>
                        <div style="width: 410px; float: right; text-align: left;">
                            * Puede colocar una o más series, separadas entre sí por comas (,)
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="text-align: center;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="ui-corner-all ui-state-default cancel"
                            OnClick="btnBuscar_Click" Height="24px" Width="53px" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" Text="Salir" CssClass="ui-corner-all ui-state-default cancel"
                            CausesValidation="false" OnClick="btnCancelar_Click" Height="24px" Width="53px" />
                    </div>
                    <br />
                    <div style="text-align: center;">
                        <div style="width: 715px; margin-left: auto; margin-right: auto;">
                            <asp:GridView ID="gvwArticulos" runat="server" AutoGenerateColumns="False" DataKeyNames="idItem"
                                Width="715" EmptyDataText="No existe Informacion" AllowPaging="True" OnPageIndexChanging="gvwArticulos_PageIndexChanging"
                                OnPageIndexChanged="gvwArticulos_PageIndexChanged" PageSize="20">
                                <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                <PagerSettings Mode="NextPreviousFirstLast" />
                                <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                <EmptyDataRowStyle BackColor="#DEDDF3" />
                                <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:TemplateField>
                                        <%--<HeaderTemplate>
                                                               <asp:CheckBox ID="ChkAll" runat="server" />
                                                           </HeaderTemplate>--%>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelecciona" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Responsiva" HeaderText="Responsiva" InsertVisible="False"
                                        ReadOnly="True" SortExpression="Responsiva" />
                                    <asp:BoundField DataField="NoSerie" HeaderText="NoSerie" SortExpression="NoSerie" />
                                    <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo de Equipo" SortExpression="TipoEquipo" />
                                    <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" SortExpression="Ubicacion" />
                                    <asp:BoundField DataField="UsuarioAsignado" HeaderText="Usuario Asignado" SortExpression="UsuarioAsignado"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="Puesto" HeaderText="Puesto" SortExpression="Puesto" ReadOnly="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <asp:Panel ID="pnlTotales" runat="server" Visible="False" Height="350" ScrollBars="Auto">
                        <div style="text-align: center;">
                            <div style="width: 800px; margin-left: auto; margin-right: auto;">
                                <div class="CeldaImagenLightBlue" style="text-align: center;">
                                    Resumen de totales
                                </div>
                                <br />
                                <div style="width: 533px; float: left">
                                    <div style="width: 267px; float: left">
                                        <asp:GridView ID="grvTotalGeneral" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                            Width="50%" EmptyDataText="No existe Informacion" AllowPaging="False">
                                            <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                            <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                            <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                            <EmptyDataRowStyle BackColor="#DEDDF3" />
                                            <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundField DataField="concepto" HeaderText="" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="concepto" />
                                                <asp:BoundField DataField="conteo" HeaderText="Total" SortExpression="Concepto" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div style="width: 266px; float: right">
                                        <asp:GridView ID="grvTotalUbicacion" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                            Width="50%" EmptyDataText="No existe Informacion" AllowPaging="False">
                                            <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                            <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                            <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                            <EmptyDataRowStyle BackColor="#DEDDF3" />
                                            <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundField DataField="concepto" HeaderText="Ubicación" InsertVisible="False"
                                                    ReadOnly="True" SortExpression="concepto" />
                                                <asp:BoundField DataField="conteo" HeaderText="Total" SortExpression="Concepto" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div style="width: 267px; float: right">
                                    <asp:GridView ID="grvTotalTipo" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                        Width="55%" EmptyDataText="No existe Informacion" AllowPaging="False">
                                        <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                        <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                        <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                        <EmptyDataRowStyle BackColor="#DEDDF3" />
                                        <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:BoundField DataField="concepto" HeaderText="Tipo de Equipo" InsertVisible="False"
                                                ReadOnly="True" SortExpression="concepto" />
                                            <asp:BoundField DataField="conteo" HeaderText="Total" SortExpression="Concepto" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlReasignacion" runat="server" Visible="False" Height="95">
                        <div style="text-align: center;">
                            <div style="width: 800px; margin-left: auto; margin-right: auto;">
                                <div class="CeldaImagenLightBlue" style="text-align: center;">
                                    Reasignación a Ubicación
                                </div>
                                <br />
                                <div>
                                    Nueva Ubicación:&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlUbicacionDestino" runat="server" Height="22px" Width="173px"
                                        OnSelectedIndexChanged="ddlUbicacionDestino_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <div style="text-align: center;">
                                    <asp:Panel ID="divResultado" runat="server">
                                        <asp:Button ID="btnReubicar" runat="server" Text="Mover" Width="130px" CssClass="ui-corner-all ui-state-default cancel"
                                            OnClick="btnReubicar_Click" Visible="false" />
                                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnReubicar"
                                            ConfirmText="Se modificará la ubicación de los elementos seleccionados en el grid, ¿Seguro que desea continuar?">
                                        </asp:ConfirmButtonExtender>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
