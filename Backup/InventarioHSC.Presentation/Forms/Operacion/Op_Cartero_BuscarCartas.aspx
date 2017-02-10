<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_Cartero_BuscarCartas.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_Cartero_BuscarCartas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 545px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Buscar cartas</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:Panel ID="pnlRef" runat="server" DefaultButton="btnBuscar">
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            No. de prestamo:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:TextBox ID="txtPrestamo" runat="server" Width="200" MaxLength="6"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtPrestamo_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" Mask="999999" MaskType="None" TargetControlID="txtPrestamo">
                            </asp:MaskedEditExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Nombre de cliente:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:TextBox ID="txtAcreditado" runat="server" Width="200" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Rango de fechas:<asp:CheckBox ID="chkFechas" runat="server" AutoPostBack="False"
                                Checked="True" />
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:TextBox ID="txtFechaIni" runat="server" Width="200" MaxLength="10"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtFechaIni_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaIni">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" Enabled="True"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TargetControlID="txtFechaIni">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:TextBox ID="txtFechaFin" runat="server" Width="200" MaxLength="10"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtFechaFin_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaFin">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" Enabled="True"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TargetControlID="txtFechaFin">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div style="width: 780px; height: 1px; text-align: center;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="boton" OnClick="btnBuscar_Click" />&nbsp&nbsp
                    </div>
                </asp:Panel>
                <br />
                <br />
                <asp:Panel ID="pnlDatos" runat="server" Visible="False" ClientIDMode="Inherit">
                    <asp:GridView ID="grdDatos" runat="server" Width="710px" AutoGenerateColumns="False"
                        OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" OnPageIndexChanging="grdDatos_PageIndexChanging"
                        GridLines="None" AllowPaging="True">
                        <Columns>
                            <asp:BoundField HeaderText="Cart_Id" DataField="Cart_Id">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Préstamo" DataField="Cart_NumeroPrestamo">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Acreditado" DataField="Cart_NombreAcreditado">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Referencia" DataField="Cart_Referencia">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Fecha Documento" DataField="Cart_FechaDocumento">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Fecha Creación" DataField="Cart_FechaCreacion">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Usuario" DataField="Usuario">
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
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle Width="120px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                        </HeaderStyle>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAltItem" />
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
