<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptWizardExe.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptWizardExe" %>

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
        <div style="width: 900px; margin-left: auto; margin-right: auto; height: 500px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 900px;" class="divRoundedOpacityTitle">
                Ejecución de reportes dinámicos</div>
            <br />
            <div style="padding-left: 10px; width: 880px;">
                
            </div>
        </div>
    </div>
</asp:Content>
