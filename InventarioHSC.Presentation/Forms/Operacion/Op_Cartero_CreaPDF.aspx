<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_Cartero_CreaPDF.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_Cartero_CreaPDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <asp:Label ID="lblMsj" runat="server" Text="Generando PDF..."></asp:Label>
    </div>
</asp:Content>