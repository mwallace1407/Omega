<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="LecturaBoveda.aspx.cs" Inherits="InventarioHSC.Forms.Servidores.LecturaBoveda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
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
        var validFilesTypes = ["bkey"];
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
                label.innerHTML = "Archivo incorrecto. Se espera un archivo con la extensión \n\n" + validFilesTypes.join(", ");
            }
            else {
                label.style.color = "black";
                label.innerHTML = "Archivo correcto. Proceda a cargar la llave.";
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
    <uc1:uscMsgBox ID="MsgBox" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 350px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Obtener contraseñas de la bóveda</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 780px; text-align: center;">
                    <div style="width: 780px; text-align: left;">
                        <asp:Panel ID="pnlOpciones" runat="server" Visible="False" Width="545px">
                            <div style="width: 545px; text-align: left;">
                                <asp:RadioButton ID="rbSencilla" runat="server" Text="Consulta sencilla" GroupName="opt"
                                    Checked="True" />
                                <br />
                                <asp:RadioButton ID="rbMultiple" runat="server" Text="Consulta masiva" GroupName="opt" />
                                <br />
                                <br />
                                <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="boton" OnClick="btnSiguiente_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                    <asp:Panel ID="pnlCarga" runat="server" Visible="True">
                        Cargar el archivo que contiene la llave:
                        <br />
                        <asp:FileUpload ID="upFile" runat="server" CssClass="boton" />
                        <br />
                        <asp:Label ID="lblMsjCarga" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btnCargar" runat="server" Text="Cargar llave" CssClass="boton" OnClick="btnCargar_Click"
                            OnClientClick="return ValidateFile()" />
                        <asp:HiddenField ID="hddKey" runat="server" />
                        <asp:HiddenField ID="hddHash" runat="server" />
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="pnlDatos" runat="server" Visible="False">
                        <div style="width: 670px;">
                            <div style="width: 320px; float: left; text-align: left;">
                                <asp:DropDownList ID="ddlTiposS" runat="server" Width="302" AutoPostBack="True" OnSelectedIndexChanged="ddlTipos_SelectedIndexChanged">
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:DropDownList ID="ddlListaP" runat="server" Width="302" AutoPostBack="True" Visible="False"
                                    OnSelectedIndexChanged="ddlListaP_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div style="width: 350px; float: right; text-align: left;">
                                <asp:Panel ID="pnlMsjP" runat="server">
                                    <asp:Label ID="lblMsjP" runat="server" Text=""></asp:Label>
                                    <br />
                                </asp:Panel>
                                <asp:Image ID="imgPass" runat="server" Visible="False" ImageUrl="" />
                            </div>
                        </div>
                        <br />
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="pnlDatosM" runat="server" Visible="False">
                        <div style="width: 220px; text-align: left;">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="202" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlTipos_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <br />
                        </div>
                        <div style="width: 202px; text-align: right;">
                            <asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" 
                                CssClass="boton" onclick="btnExportar_Click"/>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
