<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_Constancias_Carga.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_Constancias_Carga" %>

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
    <script type="text/javascript">
        var validFilesTypes = ["txt"];
        function ValidateFile() {
            var file = document.getElementById("<%=upFile.ClientID%>");
            var label = document.getElementById("<%=lblMsjCarga.ClientID%>");
            var path = file.value;
            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes.length; i++) {
                if (ext == validFilesTypes[i]) {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) {
                label.style.color = "red";
                label.innerHTML = "Tipo de archivo incorrecto. Se espera un archivo con la extensión \n\n" + validFilesTypes.join(", ");
            }
            else {
                label.style.color = "black";
                label.innerHTML = "Tipo de archivo correcto.";
            }
            return isValidFile;
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
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 550px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Carga de datos para constancias</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:Panel ID="pnlCarga" runat="server" Visible="True">
                    Cargar el archivo enviado por la administradora:
                    <br />
                    <asp:FileUpload ID="upFile" runat="server" CssClass="boton" />
                    <br />
                    <asp:Button ID="btnValidar" runat="server" Text="Validar archivo" CssClass="boton"
                        OnClientClick="return ValidateFile()" OnClick="btnValidar_Click" />
                    <br />
                    <asp:Label ID="lblMsjCarga" runat="server" Text=""></asp:Label>&nbsp
                    <asp:HyperLink ID="lnkLog" runat="server" Visible="False" Target="_blank">detalle de errores</asp:HyperLink>
                    <asp:HiddenField ID="hddArchivoCorrecto" runat="server" Value="0" />
                    <asp:HiddenField ID="hddArchivoOriginal" runat="server" Value="" />
                </asp:Panel>
                <asp:Label ID="lblCarga" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <div class="anchotot">
                    <div class="pnlizq">
                        Administradora:
                    </div>
                    <div class="pnlder">
                        <asp:DropDownList ID="ddlAdministradora" runat="server" Width="202" OnSelectedIndexChanged="ddlAdministradora_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Image ID="imgReqAdmin" runat="server" ImageUrl="~/App_Themes/Imagenes/trans_16x16.gif" />&nbsp
                        <asp:Label ID="lblReqAdmin" runat="server" ForeColor="#CC0000"></asp:Label>
                    </div>
                </div>
                <br />
                <br />
                <div class="anchotot">
                    <div class="pnlizq">
                        Portafolio:
                    </div>
                    <div class="pnlder">
                        <asp:DropDownList ID="ddlPortafolio" runat="server" Width="202" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlPortafolio_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Image ID="imgReqPort" runat="server" ImageUrl="~/App_Themes/Imagenes/trans_16x16.gif" />&nbsp
                        <asp:Label ID="lblReqPort" runat="server" ForeColor="#CC0000" Visible="True"></asp:Label>
                    </div>
                </div>
                <br />
                <br />
                <div class="anchotot">
                    <div class="pnlizq">
                        Fecha de lote:
                    </div>
                    <div class="pnlder">
                        <asp:TextBox ID="txtFecha" runat="server" Width="200" autocomplete="off"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtFecha_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha">
                        </asp:MaskedEditExtender>
                        <asp:Image ID="imgReqFecha" runat="server" ImageUrl="~/App_Themes/Imagenes/trans_16x16.gif" />&nbsp
                        <asp:Label ID="lblReqFecha" runat="server" ForeColor="#CC0000"></asp:Label>
                    </div>
                </div>
                <br />
                <br />
                <div class="anchotot">
                    <div class="pnlizq">
                        Identificador de lote:
                    </div>
                    <div class="pnlder">
                        <asp:TextBox ID="txtIdentificador" runat="server" Width="200" MaxLength="50" autocomplete="off"></asp:TextBox>
                        &nbsp(Opcional)
                    </div>
                </div>
                <br />
                <asp:Label ID="lblExistente" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
                <asp:Button ID="btnCargar" runat="server" Text="Cargar datos" CssClass="boton" OnClick="btnCargar_Click"
                    Enabled="False" />
                <asp:HiddenField ID="hddIgnorarValidacion" runat="server" Value="0" />
                <asp:HiddenField ID="hddArchivo" runat="server" Value="" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>