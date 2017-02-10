<%@ Page Title="Generar llave" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="GenerarLlave.aspx.cs" Inherits="InventarioHSC.Forms.Servidores.GenerarLlave" %>

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
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 350px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Generar llave para bóveda</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                Cada llave generada es única e irremplazable, resguárdela en un lugar seguro ya
                que en caso de pérdida las contraseñas encriptadas con ésta no podrán ser recuperadas.
                <br />
                <br />
                <asp:RadioButton ID="rbTodos" runat="server" Text="Enviar llave a todos los usuarios autorizados"
                    GroupName="rb" AutoPostBack="True" OnCheckedChanged="rbTodos_CheckedChanged" />
                <br />
                <asp:RadioButton ID="rbEspecial" runat="server" Text="Enviar llave a un correo específico"
                    GroupName="rb" AutoPostBack="True" OnCheckedChanged="rbEspecial_CheckedChanged" />&nbsp&nbsp
                <asp:TextBox ID="txtCorreo" runat="server" Width="200" MaxLength="75" autocomplete="off"
                    Visible="False"></asp:TextBox>
                <br />
                <br />
                <div style="width: 780px; height: 1px; text-align: center;">
                    <asp:Button ID="btnProcesar" runat="server" Text="Generar" CssClass="boton" OnClick="btnProcesar_Click"
                        Enabled="False" />
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
