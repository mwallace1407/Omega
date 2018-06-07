<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_Constancias_Generacion.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_Constancias_Generacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: Silver;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            width: 200px;
            height: 170px;
            display: none;
            position: fixed;
            z-index: 999;
            color: Black;
            font-weight: bold;
        }
        .pnlizq
        {
            width: 125px;
            float: left;
            text-align: left;
        }
        .pnlder
        {
            width: 575px;
            float: right;
            text-align: left;
        }
        .anchotot
        {
            width: 710px;
        }
    </style>
    <script src="../../Scripts/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="loading">
        <img src="../../App_Themes/Imagenes/gears_animated.gif" alt="" />
        <br />
        Procesando tarea...
    </div>
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 600px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Generar TXT para el SAT</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:Accordion ID="acc01" runat="server" ContentCssClass="AcordionRoundedOpacity"
                    FadeTransitions="True" HeaderCssClass="AcordionRoundedOpacityTitle" Width="780px"
                    SelectedIndex="3">
                    <Panes>
                        <asp:AccordionPane ID="accPnl01" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                Filtros</Header>
                            <Content>
                                <asp:Panel ID="pnlBusqueda" runat="server">
                                    <br />
                                    <div class="anchotot">
                                        <div class="pnlizq">
                                            Descripción:
                                        </div>
                                        <div class="pnlder">
                                            <asp:TextBox ID="txtIdentificador" runat="server" Width="200" MaxLength="25" autocomplete="off"></asp:TextBox>
                                            &nbsp(Nombre del archivo y/o identificador de lote)
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="anchotot">
                                        <div class="pnlizq">
                                            Fecha de lote:
                                        </div>
                                        <div class="pnlder">
                                            De:
                                            <asp:TextBox ID="txtFechaLIni" runat="server" Width="77" autocomplete="off"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="txtFechaLIni_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaLIni">
                                            </asp:MaskedEditExtender>
                                            &nbsp a:
                                            <asp:TextBox ID="txtFechaLFin" runat="server" Width="77" autocomplete="off"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="txtFechaLFin_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaLFin">
                                            </asp:MaskedEditExtender>
                                            &nbsp
                                            <asp:Label ID="lblFechaLote" runat="server" ForeColor="#CC0000"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="anchotot">
                                        <div class="pnlizq">
                                            Fecha de carga:
                                        </div>
                                        <div class="pnlder">
                                            De:
                                            <asp:TextBox ID="txtFechaCIni" runat="server" Width="77" autocomplete="off"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="txtFechaCIni_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaCIni">
                                            </asp:MaskedEditExtender>
                                            &nbsp a:
                                            <asp:TextBox ID="txtFechaCFin" runat="server" Width="77" autocomplete="off"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="txtFechaCFin_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaCFin">
                                            </asp:MaskedEditExtender>
                                            &nbsp
                                            <asp:Label ID="lblFechaCarga" runat="server" ForeColor="#CC0000"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="anchotot">
                                        <div class="pnlizq" style="height: 110px">
                                            Administradora:
                                        </div>
                                        <div class="pnlder" style="height: 110px">
                                            <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;
                                                width: 270px;">
                                                <asp:CheckBoxList ID="chklAdministradora" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="anchotot">
                                        <div class="pnlizq" style="height: 110px">
                                            Portafolio:
                                        </div>
                                        <div class="pnlder" style="height: 110px">
                                            <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;
                                                width: 270px;">
                                                <asp:CheckBoxList ID="chklPortafolio" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div>
                                        <asp:Button ID="btnAplicarFiltro" runat="server" Text="Aplicar filtros" CssClass="boton"
                                            OnClick="btnAplicarFiltro_Click" />
                                    </div>
                                    <br />
                                    <br />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="accPnl02" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                Datos para encabezado</Header>
                            <Content>
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        Tipo de registro:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtTipoReg" runat="server" Width="80" autocomplete="off" MaxLength="1"
                                            Text="1"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtTipoReg_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="9" MaskType="Number" TargetControlID="txtTipoReg">
                                        </asp:MaskedEditExtender>
                                        Valor por defecto: 1
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        Consecutivo de registro:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtConsecutivoReg" runat="server" Width="80" autocomplete="off"
                                            MaxLength="1" Text="1"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtConsecutivoReg_MaskedEditExtender" runat="server"
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" Enabled="True" Mask="9" MaskType="Number" TargetControlID="txtConsecutivoReg">
                                        </asp:MaskedEditExtender>
                                        Valor por defecto: 1
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        Fecha de presentación:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtFechaPresentacion" runat="server" Width="80" autocomplete="off"
                                            MaxLength="10"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtFechaPresentacion_MaskedEditExtender" runat="server"
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaPresentacion">
                                        </asp:MaskedEditExtender>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        Ejercicio reportado:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtEjercicioReportado" runat="server" Width="80" autocomplete="off"
                                            MaxLength="4"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtEjercicioReportado_MaskedEditExtender" runat="server"
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" Enabled="True" Mask="9999" MaskType="Number" TargetControlID="txtEjercicioReportado">
                                        </asp:MaskedEditExtender>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        RFC:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtRFC" runat="server" Width="80" autocomplete="off" MaxLength="12"
                                            Text="HSC941011SU6"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtRFC_MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="LLL999999??9" MaskType="None" TargetControlID="txtRFC">
                                        </asp:MaskedEditExtender>
                                    </div>
                                </div>
                                <br />
                                <br />
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                Datos para sumario</Header>
                            <Content>
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        Tipo de registro:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtTipoRegSum" runat="server" Width="80" autocomplete="off" MaxLength="1"
                                            Text="9"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtTipoRegSum_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="9" MaskType="Number" TargetControlID="txtTipoRegSum">
                                        </asp:MaskedEditExtender>
                                        Valor por defecto: 9
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        Tipo de declaración:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtTipoDeclaracion" runat="server" Width="80" autocomplete="off"
                                            MaxLength="1" Text="1"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtTipoDeclaracion_MaskedEditExtender" runat="server"
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" Enabled="True" Mask="9" MaskType="Number" TargetControlID="txtTipoDeclaracion">
                                        </asp:MaskedEditExtender>
                                        Normal: 1; Complementaria: 2
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="anchotot">
                                    <div class="pnlizq">
                                        Fecha de última declaración:
                                    </div>
                                    <div class="pnlder">
                                        <asp:TextBox ID="txtFechaUltimaD" runat="server" Width="80" autocomplete="off" MaxLength="10"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtFechaUltimaD_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaUltimaD">
                                        </asp:MaskedEditExtender>
                                        Sólo si es complementaria
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="accPnl03" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                Datos disponibles</Header>
                            <Content>
                                <div>
                                    <br />
                                    <asp:GridView ID="grdDatos" runat="server" Width="730px" AutoGenerateColumns="False"
                                        OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" GridLines="None" AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkId" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="25px" />
                                                <ItemStyle Width="25px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="" DataField="Id" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="1px" />
                                                <ItemStyle Width="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Administradora" DataField="Administradora" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Portafolios" DataField="Portafolios" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha de carga" DataField="Fecha_carga" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha de lote" DataField="Fecha_lote" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Identificador" DataField="Identificador" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Archivo" DataField="Archivo" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="125px" />
                                                <ItemStyle Width="125px" />
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
                                <br />
                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Button ID="btnGenerar" runat="server" Text="Generar documento" CssClass="boton"
                                    OnClick="btnGenerar_Click" />
                                <br />
                                <br />
                            </Content>
                        </asp:AccordionPane>
                    </Panes>
                </asp:Accordion>
                <br />
            </div>
        </div>
        <br />
    </div>
</asp:Content>