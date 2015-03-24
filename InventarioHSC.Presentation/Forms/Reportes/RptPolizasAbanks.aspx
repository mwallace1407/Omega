<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptPolizasAbanks.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptPolizasAbanks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="600">
    </asp:ToolkitScriptManager>
    <uc1:uscMsgBox ID="uscMsgBox1" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <br />
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 475px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Reporte de pólizas de Abanks
            </div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:UpdatePanel ID="UPnl" runat="server">
                    <ContentTemplate>
                        <div style="width: 180px; text-align: left;">
                            <asp:Panel ID="pnlOpciones" runat="server">
                                <asp:RadioButton ID="rbAnual" runat="server" GroupName="rbOpciones" Text="Reporte con filtro por año"
                                    AutoPostBack="True" Checked="True" OnCheckedChanged="rbAnual_CheckedChanged" />
                                <br />
                                <asp:RadioButton ID="rbFiltros" runat="server" Text="Reporte con filtros especiales"
                                    GroupName="rbOpciones" AutoPostBack="True" OnCheckedChanged="rbFiltros_CheckedChanged" />
                            </asp:Panel>
                        </div>
                        <br />
                        <asp:Panel ID="pnlAnual" runat="server" Visible="True">
                            <div style="width: 180px; text-align: left;">
                                <asp:GridView ID="grdDatos" runat="server" Width="120px" AutoGenerateColumns="False"
                                    OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" GridLines="None">
                                    <Columns>
                                        <asp:BoundField HeaderText="Año" DataField="Anio">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Archivo">
                                            <EditItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkRuta" runat="server" Text="Descargar" CssClass="HyperLink"
                                                    Target="_blank">Descargar</asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="70px" />
                                            <ItemStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Ruta" HeaderText="Ruta" HeaderStyle-CssClass="GridColumnHide"
                                            ItemStyle-CssClass="GridColumnHide">
                                            <HeaderStyle Width="1px" />
                                            <ItemStyle Width="1px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle Width="120px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                                    </HeaderStyle>
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle CssClass="GridItem" />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlFiltros" runat="server" Visible="False">
                            <fieldset style="border: medium ridge #C0C0C0; width: 350px;">
                                <legend>Rango de fechas:</legend>
                                <div style="width: 340px;">
                                    <div style="width: 125px; float: left; text-align: left;">
                                        Fecha inicial:
                                    </div>
                                    <div style="width: 215px; float: right; text-align: left;">
                                        <asp:TextBox ID="txtFechaIni" runat="server" Width="200" MaxLength="10" Text="01/01/2012"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtFechaIni_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaIni">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" Enabled="True"
                                            Format="dd/MM/yyyy" TargetControlID="txtFechaIni">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="rfv_txtFechaIni" runat="server" ErrorMessage="Campo requerido"
                                            Display="None" ControlToValidate="txtFechaIni" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfve_txtFechaIni" runat="server" Enabled="True"
                                            TargetControlID="rfv_txtFechaIni">
                                        </asp:ValidatorCalloutExtender>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div style="width: 340px;">
                                    <div style="width: 125px; float: left; text-align: left;">
                                        Fecha final:
                                    </div>
                                    <div style="width: 215px; float: right; text-align: left;">
                                        <asp:TextBox ID="txtFechaFin" runat="server" Width="200" MaxLength="10" Text="01/04/2012"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtFechaFin_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaFin">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" Enabled="True"
                                            Format="dd/MM/yyyy" TargetControlID="txtFechaFin">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="rfv_txtFechaFin" runat="server" ErrorMessage="Campo requerido"
                                            Display="None" ControlToValidate="txtFechaFin" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfve_txtFechaFin" runat="server" Enabled="True"
                                            TargetControlID="rfv_txtFechaFin">
                                        </asp:ValidatorCalloutExtender>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hddAnnoMin" runat="server" />
                                <asp:HiddenField ID="hddAnnoMax" runat="server" />
                            </fieldset>
                            <br />
                            <div style="width: 340px;">
                                <div style="width: 125px; float: left; text-align: left;">
                                    No. de movimiento:
                                </div>
                                <div style="width: 215px; float: right; text-align: left;">
                                    <asp:TextBox ID="txtNoMovimiento" runat="server" Width="200" MaxLength="11"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 340px;">
                                <div style="width: 125px; float: left; text-align: left;">
                                    Cuenta:
                                </div>
                                <div style="width: 215px; float: right; text-align: left;">
                                    <asp:TextBox ID="txtCuenta" runat="server" Width="200" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 340px;">
                                <div style="width: 125px; float: left; text-align: left;">
                                    Descripción cuenta:
                                </div>
                                <div style="width: 215px; float: right; text-align: left;">
                                    <asp:TextBox ID="txtDescripcionCuenta" runat="server" Width="200" MaxLength="120"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 340px;">
                                <div style="width: 125px; float: left; text-align: left;">
                                    Descripción encabezado:
                                </div>
                                <div style="width: 215px; float: right; text-align: left;">
                                    <asp:TextBox ID="txtDescripcionEncabezado" runat="server" Width="200" MaxLength="120"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 340px;">
                                <div style="width: 125px; float: left; text-align: left;">
                                    Moneda:
                                </div>
                                <div style="width: 215px; float: right; text-align: left;">
                                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="202">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 440px;">
                                <div style="width: 125px; float: left; text-align: left;">
                                    Búsqueda estricta:
                                </div>
                                <div style="width: 315px; float: right; text-align: left;">
                                    <asp:CheckBox ID="chkBusquedaEstricta" runat="server" />&nbsp(Utilizarlo cuando
                                    se ingresan valores específicos)
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 300px; text-align: left;">
                                <asp:GridView ID="grdDatosF" runat="server" Width="300px" AutoGenerateColumns="False"
                                    OnRowDataBound="grdDatosF_RowDataBound" ForeColor="#333333" GridLines="None">
                                    <Columns>
                                        <asp:BoundField HeaderText="Concepto" DataField="Concepto">
                                            <HeaderStyle Width="230px" />
                                            <ItemStyle Width="230px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Archivo">
                                            <EditItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkRuta" runat="server" Text="Descargar" CssClass="HyperLink"
                                                    Target="_blank">Descargar</asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="70px" />
                                            <ItemStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Ruta" HeaderText="Ruta" HeaderStyle-CssClass="GridColumnHide"
                                            ItemStyle-CssClass="GridColumnHide">
                                            <HeaderStyle Width="1px" />
                                            <ItemStyle Width="1px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle Width="220px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                                    </HeaderStyle>
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle CssClass="GridItem" />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                        <br />
                        <asp:Button ID="btnProcesar" runat="server" Text="Generar Reporte" CssClass="boton"
                            OnClick="btnProcesar_Click" Visible="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UPrg" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UPnl">
                    <ProgressTemplate>
                        <div id="divProgress" style="top: 0px; height: 100%; background-color: Gray; opacity: 0.9; filter: alpha(opacity=90);
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
        <br />
    </div>
</asp:Content>
