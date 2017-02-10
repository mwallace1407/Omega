<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptWizardExe.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptWizardExe" %>

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
        .modalBackground
        {
            background-color: Silver;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 350px;
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
    <script type="text/javascript">

        var ddlText, ddlValue, ddl, lblMesg;

        function CacheItems() {

            ddlText = new Array();
            ddlValue = new Array();
            ddl = document.getElementById("<%=ddlReportes.ClientID %>");
            lblMesg = document.getElementById("<%=lblMensaje.ClientID%>");

            for (var i = 0; i < ddl.options.length; i++) {
                ddlText[ddlText.length] = ddl.options[i].text;
                ddlValue[ddlValue.length] = ddl.options[i].value;
            }
        }

        window.onload = CacheItems;

        function FilterItems(value) {

            ddl.options.length = 0;

            for (var i = 0; i < ddlText.length; i++) {
                if (ddlText[i].toLowerCase().indexOf(value) != -1) {
                    AddItem(ddlText[i], ddlValue[i]);
                }
            }

            if (ddl.options.length >= 1) {
                if (ddl.options.length == 1) {
                    lblMesg.innerHTML = ddl.options.length + " reporte encontrado.";
                }
                else {
                    lblMesg.innerHTML = ddl.options.length + " reportes encontrados.";
                }
            }
            else {
                lblMesg.innerHTML = ddl.options.length + " reportes encontrados.";
            }

            if (ddl.options.length == 0) {
                AddItem("No se encontraron reportes", "");
                lblMesg.innerHTML = "0 reportes encontrados.";
            }
        }

        function AddItem(text, value) {

            var opt = document.createElement("option");

            opt.text = text;
            opt.value = value;
            ddl.options.add(opt);
        }

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
    <input id="Hid_Sno" type="hidden" name="hddclick" runat="server" />
    <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlModal" TargetControlID="Hid_Sno"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlModal" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div style="height: 330px; overflow: auto; text-align: left;">
            <asp:Label ID="lblMsj" runat="server" Text=""></asp:Label><br />
        </div>
        <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="boton" />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 900px; margin-left: auto; margin-right: auto; height: 550px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 900px;" class="divRoundedOpacityTitle">
                Ejecución de reportes dinámicos</div>
            <br />
            <div style="padding-left: 10px; width: 880px;">
                <asp:Panel ID="pnlReportes" runat="server" DefaultButton="btnCargar">
                    Filtrar lista:<br />
                    <asp:TextBox ID="txtSearch" runat="server" onkeyup="FilterItems(this.value)" Width="248px" autocomplete="off"></asp:TextBox><br />
                    <asp:DropDownList ID="ddlReportes" runat="server" Width="250" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlReportes_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="btnCargar" runat="server" Text="Cargar reporte" CssClass="boton" OnClick="btnCargar_Click" />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:HiddenField ID="hddConexion" runat="server" />
                </asp:Panel>
                <asp:Panel ID="pnlVariables" runat="server">
                    <br />
                    <div style="height: 410px; width: 745px; overflow: auto; text-align: left; float: left">
                        <asp:GridView ID="grdParams" runat="server" Width="720px" AutoGenerateColumns="False"
                            ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:BoundField HeaderText="" DataField="Nombre">
                                    <HeaderStyle Width="1px" />
                                    <ItemStyle Width="1px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Filtros" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTexto" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Obligatorio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblObligatorio" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valores" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hddNombre" runat="server" />
                                        <asp:HiddenField ID="hddTipo" runat="server" />
                                        <asp:HiddenField ID="hddTipoDato" runat="server" />
                                        <asp:HiddenField ID="hddLongitud" runat="server" />
                                        <asp:HiddenField ID="hddObligatorio" runat="server" />
                                        <asp:HiddenField ID="hddEntrada" runat="server" />
                                        <asp:HiddenField ID="hddCatId" runat="server" />
                                        <asp:HiddenField ID="hddAceptaNulo" runat="server" />
                                        <asp:HiddenField ID="hddBusquedaAprox" runat="server" />
                                        <asp:HiddenField ID="hddTexto" runat="server" />
                                        <asp:HiddenField ID="hddValor" runat="server" />
                                        <asp:TextBox ID="txtValor" runat="server" Width="265" Visible="False" autocomplete="off"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="txtValor_FilteredTextBoxExtender" runat="server"
                                            Enabled="False" TargetControlID="txtValor">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:MaskedEditExtender ID="txtValor_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="False" Mask="99/99/9999" MaskType="Date" TargetControlID="txtValor">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="txtValor_CalendarExtender" runat="server" Enabled="False"
                                            FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TargetControlID="txtValor">
                                        </asp:CalendarExtender>
                                        <asp:TextBox ID="txtmValor" runat="server" Width="265" Visible="False" TextMode="MultiLine"
                                            Height="75"></asp:TextBox>
                                        <asp:CheckBox ID="chkValor" runat="server" Visible="False" />
                                        <asp:Panel ID="pnlchkl" runat="server" Visible="False">
                                            <div style="height: 100px; overflow: auto; width: 265px;">
                                                <asp:CheckBoxList ID="chklValor" runat="server" Visible="False" Width="255">
                                                </asp:CheckBoxList>
                                            </div>
                                        </asp:Panel>
                                        <asp:DropDownList ID="ddlValor" runat="server" Visible="False" Width="265">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="270px" />
                                    <ItemStyle Width="270px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enviar nulo">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkNull" runat="server" Checked="False" Enabled="False" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Búsqueda Aprox.">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBAprox" runat="server" Checked="False" Enabled="False" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle Width="120px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                            </HeaderStyle>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                        </asp:GridView>
                    </div>
                    <div style="width: 120px; overflow: auto; text-align: left; float: right">
                        <asp:Button ID="btnEjecutar" runat="server" Text="Ejecutar" CssClass="boton" OnClick="btnEjecutar_Click"
                            Visible="False" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
