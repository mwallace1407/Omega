<%@ Page Title="Modificar relaciones entre aplicación y bases de datos" Language="C#"
    MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true" CodeBehind="ModificarRelAppBD.aspx.cs"
    Inherits="InventarioHSC.Forms.Aplicaciones.ModificarRelAppBD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 540px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: MODIFICAR RELACIONES ENTRE APLICACIÓN Y BASES DE DATOS :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 85px; float: left; text-align: left;">
                    &nbsp Aplicación:
                </div>
                <div style="width: 325px; float: right; text-align: left;">
                    &nbsp
                    <asp:DropDownList ID="ddlApp" runat="server" Width="202" AutoPostBack="True" OnSelectedIndexChanged="ddlApp_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <br />
                <br />
                <br />
                <div style="border: medium ridge #ffffff; width: 410px;">
                    <asp:Panel ID="pnlRel" runat="server" DefaultButton="btnProcesarD" Enabled="False">
                        Puede agregar o eliminar la relación con una BD.
                        <br />
                        <br />
                        <div style="height: 110px; background-color: rgba(73,114,158,0.5); text-align: left;">
                            <br />
                            <div style="width: 410px;">
                                <div style="width: 85px; float: left; text-align: left;">
                                    &nbsp Base de datos:
                                </div>
                                <div style="width: 325px; float: right; text-align: left;">
                                    &nbsp
                                    <asp:DropDownList ID="ddlBD" runat="server" Width="202">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="width: 410px;">
                                <div style="width: 85px; float: left; text-align: left;">
                                    &nbsp Es propietaria:
                                </div>
                                <div style="width: 325px; float: right; text-align: left;">
                                    &nbsp
                                    <asp:CheckBox ID="chkEsPropietaria" runat="server" />
                                </div>
                            </div>
                            <br />
                            <br />
                            &nbsp
                            <asp:Button ID="btnProcesarD" runat="server" Text="Agregar" CssClass="boton" OnClick="btnProcesarD_Click"
                                CausesValidation="False" />
                        </div>
                        <br />
                        <div style="height: auto; max-height: 170px; overflow: auto; width: 340px;">
                            <asp:GridView ID="grdDatos" runat="server" Width="300px" AutoGenerateColumns="False"
                                OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" GridLines="None" OnRowDeleting="grdDatos_RowDeleting">
                                <Columns>
                                    <asp:BoundField HeaderText="Base de datos" DataField="AppBD_Nombre">
                                        <HeaderStyle Width="210px" />
                                        <ItemStyle Width="210px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Es Propietaria">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkEsProp" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="90px" />
                                        <ItemStyle Width="90px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EsPropietaria" HeaderText="" HeaderStyle-CssClass="GridColumnHide"
                                        ItemStyle-CssClass="GridColumnHide">
                                        <HeaderStyle Width="1px" />
                                        <ItemStyle Width="1px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AppBD_Id" HeaderText="" HeaderStyle-CssClass="GridColumnHide"
                                        ItemStyle-CssClass="GridColumnHide">
                                        <HeaderStyle Width="1px" />
                                        <ItemStyle Width="1px" />
                                    </asp:BoundField>
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Imagenes/Delete.png"
                                        CausesValidation="False" ShowDeleteButton="True" />
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
                        <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click" />
                        <br />
                        <br />
                    </asp:Panel>
                    <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
                </div>
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>