<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="RptWizardAut.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptWizardAut" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <br />
    <br />
    <br />
    <uc1:uscMsgBox ID="MsgBox" runat="server" />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 700px; margin-left: auto; margin-right: auto; height: 450px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 700px;" class="divRoundedOpacityTitle">
                Autorización de reportes dinámicos</div>
            <br />
            <div style="padding-left: 10px; width: 680px; height: 370px; overflow: auto;">
                Los cambios son aplicados al momento de usar la casilla de verificación del registro
                correspondiente.
                <br />
                <br />
                <asp:GridView ID="grdDatos" runat="server" Width="660px" AutoGenerateColumns="False"
                    ForeColor="#333333" GridLines="None" OnRowCommand="grdDatos_RowCommand" OnRowDataBound="grdDatos_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRevisar" runat="server" CommandName="Detalle" CommandArgument="<%#Container.DataItemIndex%>"
                                    Text="Detalle" ForeColor="#D75600">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="70px" />
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="" DataField="Id">
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="" DataField="Conexion">
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="" DataField="Script" HtmlEncode="False" HtmlEncodeFormatString="False"
                            ConvertEmptyStringToNull="False">
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="" DataField="Autorizado">
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo" HtmlEncode="False" HtmlEncodeFormatString="False"
                            ConvertEmptyStringToNull="False">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" HtmlEncode="False" HtmlEncodeFormatString="False"
                            ConvertEmptyStringToNull="False">
                            <HeaderStyle Width="480px" />
                            <ItemStyle Width="480px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Autorizado">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAutorizado" runat="server" OnCheckedChanged="chkAutorizado_CheckedChanged"
                                    AutoPostBack="true" />
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
        </div>
        <!-- ModalPopupExtender -->
        <input id="Hid_Sno" type="hidden" name="hddclick" runat="server" />
        <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlModalQ" TargetControlID="Hid_Sno"
            CancelControlID="btnClose" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlModalQ" runat="server" CssClass="modalPopup" Style="display: none;
            text-align: center;">
            <div style="text-align: left;">
                <asp:Label ID="lblConexion" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </div>
            <asp:TextBox ID="txtScript" runat="server" Width="580" Height="350" TextMode="MultiLine"
                ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="boton" />
        </asp:Panel>
        <!-- ModalPopupExtender -->
    </div>
    <br />
    <br />
</asp:Content>