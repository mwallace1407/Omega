<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptWizardMod.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptWizardMod" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
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
            width: 600px;
            height: 450px;
        }

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
    <uc1:uscMsgBox ID="MsgBox" runat="server" />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 900px; margin-left: auto; margin-right: auto; height: 620px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 900px;" class="divRoundedOpacityTitle">
                Asistente para la modificación de reportes</div>
            <br />
            <div style="padding-left: 10px; width: 880px;">
                <asp:Panel ID="pnlPaso01" runat="server">
                    <asp:HiddenField ID="hddPasoAnterior01" runat="server" />
                    Conexión.
                    <hr />
                    <br />
                    Seleccionar la conexión que utilizará el reporte:
                    <br />
                    <div style="width: 302px;">
                        <div style="width: 302px; text-align: left;">
                            <asp:DropDownList ID="ddlCnx" runat="server" Width="302">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div style="width: 302px;">
                        <div style="width: 302px; text-align: right;">
                            <asp:Button ID="btnProcesar01" runat="server" Text="Agregar catálogos" CssClass="boton"
                                OnClick="btnProcesar01_Click" />
                            <asp:Button ID="btnProcesar01P03" runat="server" Text="Siguiente paso" CssClass="boton"
                                OnClick="btnProcesar01P03_Click" />
                        </div>
                    </div>
                    <br />
                    <div style="width: 500px;">
                        <div style="width: 500px; text-align: left;">
                            <asp:Label ID="lblMsj01" runat="server" Text="" ForeColor="#990000"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <br />
                </asp:Panel>
                <asp:Panel ID="pnlPaso02" runat="server" Visible="False">
                    Creación de catálogos para utilizar en el reporte.
                    <hr />
                    <br />
                    Ingrese la descripción del catálogo:
                    <br />
                    <div style="width: 455px; text-align: left; float: left;">
                        <asp:TextBox ID="txtDescripcion02" runat="server" Width="450px" Wrap="False" MaxLength="50"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    Para dar de alta catálogos, deben poseer sólo dos campos: "Valor" y "Descripcion":
                    <br />
                    <div style="width: 780px; height: 100px;">
                        <div style="width: 455px; text-align: left; float: left;">
                            <asp:TextBox ID="txtScriptPaso02" runat="server" TextMode="MultiLine" Height="250px"
                                Width="450px" Wrap="False"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblMsj02" runat="server" Text="" ForeColor="#990000"></asp:Label>
                        </div>
                        <div style="width: 320px; text-align: left; float: right; padding-left: 5px;">
                            <asp:Panel ID="pnlEstilo02" runat="server" Wrap="True" Visible="False">
                                Escoja el estilo:
                                <br />
                                <div style="width: 320px;">
                                    <div style="width: 20px; float: left;">
                                        <asp:RadioButton ID="rbEstiloddl02" runat="server" GroupName="rbEstilo" />
                                    </div>
                                    <div style="width: 300px; float: right;">
                                        <asp:DropDownList ID="ddlResultadoPaso02" runat="server" Width="250">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div style="width: 320px; height: 150px;">
                                    <div style="width: 20px; float: left;">
                                        <asp:RadioButton ID="rbEstilochk02" runat="server" GroupName="rbEstilo" />
                                    </div>
                                    <div style="width: 300px; float: right;">
                                        <div style="border: 3px ridge SteelBlue; height: 150px; width: 250px; overflow: scroll;
                                            overflow-x: hidden;">
                                            <asp:CheckBoxList ID="chkResultadoPaso02" runat="server" Height="150" Width="250">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <br />
                    <div style="width: 455px; text-align: right;">
                        <asp:Button ID="btnRegresar02" runat="server" Text="Paso anterior" CssClass="boton"
                            OnClick="btnRegresar02_Click" />
                        <asp:Button ID="btnValidar02" runat="server" Text="Validar" CssClass="boton" OnClick="btnValidar02_Click" />
                        <asp:Button ID="btnAgregar02" runat="server" Text="Guardar catálogo" CssClass="boton"
                            OnClick="btnAgregar02_Click" Enabled="False" />
                        <asp:Button ID="btnProcesar02" runat="server" Text="Siguiente paso" CssClass="boton"
                            OnClick="btnProcesar02_Click" />
                    </div>
                    <br />
                    <br />
                    <asp:HiddenField ID="hddTipo02" runat="server" />
                </asp:Panel>
                <asp:Panel ID="pnlPaso03" runat="server" Visible="False">
                    Tipo de Script.
                    <hr />
                    <br />
                    Seleccionar el tipo de script del reporte:
                    <br />
                    <div style="width: 202px;">
                        <div style="width: 202px; text-align: left;">
                            <asp:DropDownList ID="ddlTipoScript" runat="server" Width="202">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div style="width: 202px;">
                        <div style="width: 202px; text-align: right;">
                            <asp:Button ID="btnRegresar03" runat="server" Text="Paso anterior" CssClass="boton"
                                OnClick="btnRegresar03_Click" />
                            <asp:Button ID="btnProcesar03" runat="server" Text="Siguiente paso" CssClass="boton"
                                OnClick="btnProcesar03_Click" />
                        </div>
                    </div>
                    <br />
                    <div style="width: 500px;">
                        <div style="width: 500px; text-align: left;">
                            <asp:Label ID="lblMsj03" runat="server" Text="" ForeColor="#990000"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <br />
                </asp:Panel>
                <asp:Panel ID="pnlPaso04" runat="server" Visible="False">
                    Creación de reporte.
                    <hr />
                    <br />
                    <asp:Panel ID="pnlTexto" runat="server" Visible="False">
                        <div style="width: 880px;">
                            <div style="width: 620px; text-align: left; float: left;">
                                <asp:DropDownList ID="ddlReportesTexto" runat="server" Width="202" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlReportesTexto_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp
                                <asp:Button ID="btnRegresar04Q" runat="server" Text="Paso anterior" CssClass="boton"
                                    OnClick="btnRegresar04Q_Click" />
                                <br />
                                <br />
                                <asp:Panel ID="pnlTextoC" runat="server" Visible="False">
                                    <asp:Button ID="btnIngresarQ" runat="server" Text="Ingresar script" CssClass="boton"
                                        OnClick="btnIngresarQ_Click" />&nbsp
                                    <asp:Label ID="lblMsj04Script" runat="server" Text="" ForeColor="#990000"></asp:Label>
                                    <br />
                                    <br />
                                </asp:Panel>
                                <div style="text-align: left; height: 450px; width: 620px; overflow: auto;">
                                    <asp:Panel ID="pnlGridQ" runat="server" Visible="False">
                                        Nombre del reporte:<br />
                                        <asp:TextBox ID="txtNombreReporteQ" runat="server" Width="402" MaxLength="100"></asp:TextBox>
                                        <br />
                                        <br />
                                        Parámetros:
                                        <br />
                                        <asp:GridView ID="grdParamsQ" runat="server" Width="600px" AutoGenerateColumns="False"
                                            OnSelectedIndexChanged="grdParamsQ_RowSelected" OnRowDataBound="grdParamsQ_RowDataBound"
                                            ForeColor="#333333" GridLines="None">
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Imagenes/Editar.png"
                                                    CausesValidation="False" ShowSelectButton="True" SelectText="" />
                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                                                    <HeaderStyle Width="230px" />
                                                    <ItemStyle Width="230px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tipo" DataField="Tipo">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tipo dato" DataField="TipoDato">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Longitud" DataField="Longitud">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Obligatorio">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkObligatorio" runat="server" Checked="True" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entrada">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEntrada" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Catálogo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCat" runat="server" Text="0"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Acepta nulo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNull" runat="server" Text="No"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Busq. Aprox.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBAprox" runat="server" Text="N/A"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descripción">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="270px" />
                                                    <ItemStyle Width="270px" />
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
                                        <div style="text-align: right; padding-right: 20px;">
                                            <asp:Label ID="lblMsjGrid04Q" runat="server" Text="" ForeColor="#990000"></asp:Label>
                                            &nbsp
                                            <asp:Button ID="btnProcesar04Q" runat="server" Text="Actualizar reporte" CssClass="boton"
                                                OnClick="btnProcesar04Q_Click" Visible="False" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div style="text-align: left; height: 480px; width: 250px; overflow: auto; float: right;">
                                <asp:Panel ID="pnlTipo04Q" runat="server" Visible="False">
                                    Descripción del campo:
                                    <br />
                                    <asp:TextBox ID="txtCampoDescQ" runat="server" Width="200" MaxLength="75" autocomplete="off">
                                    </asp:TextBox>
                                    <br />
                                    <br />
                                    Seleccione el tipo de dato para el campo:
                                    <br />
                                    <asp:DropDownList ID="ddlTipoDatoQ" runat="server" Width="202" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlTipoDatoQ_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hddAplicaLongitud" runat="server" />
                                    <br />
                                    <br />
                                    <asp:Panel ID="pnlLongitud04Q" runat="server" Visible="False">
                                        <div style="text-align: left; width: 55px; float: left;">
                                            <asp:TextBox ID="txtLongitud04Q" runat="server" Width="50px" MaxLength="4"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="txtLongitud04Q_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" Mask="9999" MaskType="Number" TargetControlID="txtLongitud04Q"
                                                AcceptNegative="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                AutoComplete="False">
                                            </asp:MaskedEditExtender>
                                            <asp:MaskedEditValidator ID="mev_txtLongitud04Q" runat="server" ControlToValidate="txtLongitud04Q"
                                                ControlExtender="txtLongitud04Q_MaskedEditExtender" MaximumValue="8000" MinimumValue="-1"
                                                Display="Dynamic" InvalidValueMessage="Valor incorrecto"></asp:MaskedEditValidator>
                                        </div>
                                        <div style="font-size: small; width: 195px; float: right;">
                                            (-1 equivale a MAX)</div>
                                        <br />
                                        <br />
                                    </asp:Panel>
                                    Seleccione el tipo de entrada para el campo:
                                    <br />
                                    <asp:DropDownList ID="ddlTipo04Q" runat="server" Width="202" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlTipo04Q_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Panel ID="pnlCat04Q" runat="server" Visible="False">
                                        <asp:DropDownList ID="ddlCat04Q" runat="server" Width="202">
                                        </asp:DropDownList>
                                        <br />
                                    </asp:Panel>
                                    <asp:Panel ID="pnlNull04Q" runat="server" Visible="False">
                                        <asp:CheckBox ID="chkNull04Q" runat="server" Text="Permitir valor nulo" />
                                        <br />
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAprox04Q" runat="server" Visible="False">
                                        <asp:CheckBox ID="chkAprox04Q" runat="server" Text="Permitir búsqueda aproximada"
                                            ToolTip="Se utiliza si el parámetro se encuentra en conjunto con el operador 'Like'." />
                                        <br />
                                    </asp:Panel>
                                    <asp:Label ID="lblMsjCat04Q" runat="server" Text="" ForeColor="#990000"></asp:Label>
                                    <br />
                                    <asp:Button ID="btnAsignar04Q" runat="server" Text="Asignar" CssClass="boton" OnClick="btnAsignar04Q_Click" />
                                </asp:Panel>
                            </div>
                        </div>
                        <!-- ModalPopupExtender -->
                        <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlModalQ" TargetControlID="btnIngresarQ"
                            CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlModalQ" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                            <asp:TextBox ID="txtScriptPaso04" runat="server" Width="580" Height="395" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnRegistrarQ" runat="server" Text="Registrar" CssClass="boton" OnClick="btnRegistrarQ_Click" />
                            <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="boton" />
                        </asp:Panel>
                        <!-- ModalPopupExtender -->
                    </asp:Panel>
                    <asp:Panel ID="pnlStored" runat="server" Visible="False">
                        <div style="width: 880px;">
                            <div style="width: 620px; text-align: left; float: left;">
                                <asp:DropDownList ID="ddlReportesStored" runat="server" Width="202" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlReportesStored_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp
                                <asp:Button ID="btnRegresar04" runat="server" Text="Paso anterior" CssClass="boton"
                                    OnClick="btnRegresar04_Click" />
                                <asp:Panel ID="pnlStoredC" runat="server" Visible="False">
                                    <asp:DropDownList ID="ddlStored" runat="server" Width="202" AutoPostBack="True" OnSelectedIndexChanged="ddlStored_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                </asp:Panel>
                                <div style="text-align: left; height: 450px; width: 620px; overflow: auto;">
                                    <asp:Panel ID="pnlGrid" runat="server" Visible="False">
                                        <asp:HiddenField ID="hddGridStoredProcesado" runat="server" />
                                        Nombre del reporte:<br />
                                        <asp:TextBox ID="txtNombreReporte" runat="server" Width="402" MaxLength="100"></asp:TextBox>
                                        <br />
                                        <br />
                                        Parámetros:
                                        <br />
                                        <asp:GridView ID="grdParams" runat="server" Width="600px" AutoGenerateColumns="False"
                                            OnSelectedIndexChanged="grdParams_RowSelected" OnRowDataBound="grdParams_RowDataBound"
                                            ForeColor="#333333" GridLines="None">
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Imagenes/Editar.png"
                                                    CausesValidation="False" ShowSelectButton="True" SelectText="" />
                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                                                    <HeaderStyle Width="230px" />
                                                    <ItemStyle Width="230px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tipo" DataField="Tipo">
                                                    <HeaderStyle Width="230px" />
                                                    <ItemStyle Width="230px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tipo dato" DataField="TipoDato">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Longitud" DataField="Longitud">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Obligatorio">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkObligatorio" runat="server" Checked="True" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entrada">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEntrada" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Catálogo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCat" runat="server" Text="0"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Acepta nulo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNull" runat="server" Text="No"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Busq. Aprox.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBAprox" runat="server" Text="N/A"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descripción">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="270px" />
                                                    <ItemStyle Width="270px" />
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
                                        <div style="text-align: right; padding-right: 20px;">
                                            <asp:Label ID="lblMsjGrid04" runat="server" Text="" ForeColor="#990000"></asp:Label>
                                            &nbsp
                                            <asp:Button ID="btnProcesar04" runat="server" Text="Actualizar reporte" CssClass="boton"
                                                OnClick="btnProcesar04_Click" Visible="False" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div style="text-align: left; height: 480px; width: 250px; overflow: auto; float: right;">
                                <asp:Panel ID="pnlTipo04" runat="server" Visible="False">
                                    Descripción del campo:
                                    <br />
                                    <asp:TextBox ID="txtCampoDesc" runat="server" Width="200" MaxLength="75" autocomplete="off">
                                    </asp:TextBox>
                                    <br />
                                    <br />
                                    Seleccione el tipo de entrada para el campo:
                                    <br />
                                    <asp:DropDownList ID="ddlTipo04" runat="server" Width="202" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo04_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Panel ID="pnlCat04" runat="server" Visible="False">
                                        <asp:DropDownList ID="ddlCat04" runat="server" Width="202">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblMsjCat04" runat="server" Text="" ForeColor="#990000"></asp:Label>
                                        <br />
                                    </asp:Panel>
                                    <asp:Panel ID="pnlNull04" runat="server" Visible="False">
                                        <asp:CheckBox ID="chkNull04" runat="server" Text="Permitir valor nulo" />
                                        <br />
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAprox04" runat="server" Visible="False">
                                        <asp:CheckBox ID="chkAprox04" runat="server" Text="Permitir búsqueda aproximada"
                                            ToolTip="Se utiliza si el parámetro se encuentra en conjunto con el operador 'Like'." />
                                        <br />
                                    </asp:Panel>
                                    <asp:Button ID="btnAsignar04" runat="server" Text="Asignar" CssClass="boton" OnClick="btnAsignar04_Click" />
                                </asp:Panel>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlSSIS" runat="server" Visible="False">
                    </asp:Panel>
                    <br />
                    <br />
                </asp:Panel>
            </div>
        </div>
    </div>
    <br />
</asp:Content>