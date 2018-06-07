<%@ Page Title="Alta y modificación de contraseñas" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="AltaBoveda.aspx.cs" Inherits="InventarioHSC.Forms.Servidores.AltaBoveda" %>

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
            padding-left: 10px;
            width: 450px;
            height: 255px;
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
    <script type="text/javascript">
        var validFilesTypes2 = ["xlsx"];
        function ValidateFile2() {
            var file = document.getElementById("<%=upFileM.ClientID%>");
            var label = document.getElementById("<%=lblMsjCargaM.ClientID%>");
            var path = file.value;
            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes2.length; i++) {
                if (ext == validFilesTypes2[i]) {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) {
                label.style.color = "red";
                label.innerHTML = "Archivo incorrecto. Se espera un archivo con la extensión \n\n" + validFilesTypes2.join(", ");
            }
            else {
                label.style.color = "black";
                label.innerHTML = "Archivo correcto. Proceda a cargar el Excel.";
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
    <!-- ModalPopupExtender-->
    <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlModal" TargetControlID="btnHelp"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlModal" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <asp:Image ID="imgHelp" runat="server" Height="219" Width="427" ImageUrl="~/Forms/Servidores/Help.png" /><br />
        <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="boton" />
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <uc1:uscMsgBox ID="MsgBox" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 350px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Crear o modificar contraseñas de la bóveda</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 780px; text-align: center;">
                    <div style="width: 780px; text-align: left;">
                        <asp:Panel ID="pnlOpciones" runat="server" Visible="True" Width="545px">
                            <div style="width: 270px; float: left; text-align: left;">
                                <asp:RadioButton ID="rbSencilla" runat="server" Text="Carga sencilla" GroupName="opt"
                                    Checked="True" />
                                <br />
                                <asp:RadioButton ID="rbMultiple" runat="server" Text="Carga masiva" GroupName="opt" />
                                &nbsp (<asp:HyperLink ID="lnkDown" runat="server" NavigateUrl="~/Forms/Servidores/Ejemplo.xlsx">Descargar plantilla</asp:HyperLink>)
                                <asp:ImageButton ID="btnHelp" runat="server" Height="16px" ImageUrl="~/App_Themes/Imagenes/Question.png"
                                    Width="16px" />
                                <br />
                                <br />
                                <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="boton" OnClick="btnSiguiente_Click" />
                            </div>
                            <div style="width: 275px; float: right; text-align: left;">
                                <asp:GridView ID="grdDatos" runat="server" Width="250px" AutoGenerateColumns="False"
                                    ForeColor="#333333" GridLines="None">
                                    <Columns>
                                        <asp:BoundField HeaderText="Id" DataField="Valor">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle Width="50px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Tipo de objeto" DataField="Descripcion">
                                            <HeaderStyle Width="200px" />
                                            <ItemStyle Width="200px" HorizontalAlign="Left" />
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
                    </div>
                    <asp:Panel ID="pnlCarga" runat="server" Visible="False">
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
                        <div style="width: 410px;">
                            <div style="width: 125px; float: left; text-align: left;">
                                Tipo:
                            </div>
                            <div style="width: 275px; float: right; text-align: left;">
                                <asp:DropDownList ID="ddlTipos" runat="server" Width="202">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 410px;">
                            <div style="width: 125px; float: left; text-align: left;">
                                Objeto:
                            </div>
                            <div style="width: 275px; float: right; text-align: left;">
                                <asp:TextBox ID="txtObjeto" runat="server" Width="200" MaxLength="100" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 410px;">
                            <div style="width: 125px; float: left; text-align: left;">
                                Usuario:
                            </div>
                            <div style="width: 275px; float: right; text-align: left;">
                                <asp:TextBox ID="txtUsuario" runat="server" Width="200" MaxLength="150" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 410px;">
                            <div style="width: 125px; float: left; text-align: left;">
                                Contraseña:
                            </div>
                            <div style="width: 275px; float: right; text-align: left;">
                                <asp:TextBox ID="txtPass" runat="server" Width="200" MaxLength="150" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 780px; text-align: center;">
                            <asp:Button ID="btnProcesar" runat="server" Text="Ingresar a bóveda" CssClass="boton"
                                OnClick="btnProcesar_Click" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlDatosM" runat="server" Visible="False">
                        <asp:Panel ID="pnlCargaExcel" runat="server" Visible="True">
                            Cargar el archivo de Excel:
                            <br />
                            <asp:FileUpload ID="upFileM" runat="server" CssClass="boton" />
                            <asp:HiddenField ID="hddArchivoExcel" runat="server" />
                            <br />
                            <asp:Label ID="lblMsjCargaM" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btnCargar2" runat="server" Text="Cargar Excel" CssClass="boton" OnClientClick="return ValidateFile2()"
                                OnClick="btnCargar2_Click" />
                            <br />
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="pnlPostCargaExcel" runat="server" Visible="False">
                            <asp:Label ID="lblExcel" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        </asp:Panel>
                        <asp:Button ID="btnProcesarM" runat="server" Text="Ingresar a bóveda" CssClass="boton"
                            OnClick="btnProcesarM_Click" />
                    </asp:Panel>
                </div>
            </div>
        </div>
        <br />
    </div>
</asp:Content>