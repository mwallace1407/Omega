<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="InventarioHSC.Forms.Home" %>

<asp:Content ID="head" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; height: 400px; margin-left: auto; margin-right: auto;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Módulos frecuentemente visitados
            </div>
            <!--Carrusel-->
            <br />
            <input id="left-but" type="button" value="Girar carrusel" class="boton" />
            <%--<input id="right-but" type="button" value=">>" class="boton" />--%>
            <div id="carousel1" style="width: 800px; height: 285px; overflow: scroll;">
                <asp:Literal ID="CarouselUsr" runat="server"></asp:Literal>
            </div>
            <label id="alt-text">
            </label>
            <label id="title-text">
            </label>
            <!--Fin Carrusel-->
        </div>
    </div>
    <br />
</asp:Content>