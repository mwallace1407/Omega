<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="ReubicarEquipos.aspx.cs" Inherits="InventarioHSC.Forms.Articulos.ReubicarEquipos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 900px; margin-left: auto; margin-right: auto; height: 450px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 900px;" class="divRoundedOpacityTitle">
                Reubicación de equipos</div>
            <br />
            <div style="padding-left: 10px; width: 900px;">
                <asp:Panel ID="pnlBusqueda" runat="server" DefaultButton="btnBuscar">
                    <div style="width: 710px;">
                        <div style="width: 175px; float: left; text-align: left;">
                            Ingrese el criterio a buscar:
                        </div>
                        <div style="width: 525px; float: right; text-align: left;">
                            <asp:TextBox ID="txtBuscar" runat="server" MaxLength="20" Width="202px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtBuscar" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtBuscar" InitialValue="" SetFocusOnError="True"
                                ValidationGroup="G01"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtBuscar" runat="server" Enabled="True" TargetControlID="rfv_txtBuscar">
                            </asp:ValidatorCalloutExtender>
                            &nbsp
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="boton" OnClick="btnBuscar_Click"
                                ValidationGroup="G01" />
                        </div>
                    </div>
                    <br />
                    <br />
                </asp:Panel>
                <asp:Label ID="lblMsj" runat="server" Text=""></asp:Label>
                <asp:Panel ID="pnlDatos" runat="server" HorizontalAlign="Left" Visible="False">
                    <div style="width: 880px; height: 250px; overflow: auto; text-align: left;">
                        <asp:GridView ID="grdDatos" runat="server" Width="850px" AutoGenerateColumns="False"
                            ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:BoundField HeaderText="" DataField="idItem">
                                    <HeaderStyle Width="1px" />
                                    <ItemStyle Width="1px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Reubicar">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkReubicar" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="No. Serie" DataField="NoSerie" HtmlEncode="False" HtmlEncodeFormatString="False"
                                    ConvertEmptyStringToNull="False" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                <asp:BoundField HeaderText="Tipo de equipo" DataField="TipoEquipo" HtmlEncode="False"
                                    HtmlEncodeFormatString="False" ConvertEmptyStringToNull="False" ItemStyle-HorizontalAlign="Left">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Marca" DataField="Marca" HtmlEncode="False" HtmlEncodeFormatString="False"
                                    ConvertEmptyStringToNull="False" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                <asp:BoundField HeaderText="Modelo" DataField="Modelo" HtmlEncode="False" HtmlEncodeFormatString="False"
                                    ConvertEmptyStringToNull="False" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                <asp:BoundField HeaderText="Ubicación" DataField="Ubicacion" HtmlEncode="False" HtmlEncodeFormatString="False"
                                    ConvertEmptyStringToNull="False" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                <asp:BoundField HeaderText="Responsiva" DataField="Responsiva" HtmlEncode="False"
                                    HtmlEncodeFormatString="False" ConvertEmptyStringToNull="False" ItemStyle-HorizontalAlign="Left">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Usuario" DataField="Usuario" HtmlEncode="False" HtmlEncodeFormatString="False"
                                    ConvertEmptyStringToNull="False" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
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
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 115px; float: left; text-align: left;">
                            Nueva ubicación:
                        </div>
                        <div style="width: 585px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlUbicaciones" runat="server" Width="202">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_ddlUbicaciones" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="ddlUbicaciones" InitialValue="0" 
                                SetFocusOnError="True" ValidationGroup="G02"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_ddlUbicaciones" runat="server" Enabled="True"
                                TargetControlID="rfv_ddlUbicaciones">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 880px; text-align: center;">
                        <asp:Button ID="btnProcesar" runat="server" Text="Reubicar equipos" 
                            CssClass="boton" onclick="btnProcesar_Click" ValidationGroup="G02" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
