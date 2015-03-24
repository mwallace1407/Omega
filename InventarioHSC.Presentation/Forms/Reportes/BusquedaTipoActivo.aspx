<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Sitio.Master" AutoEventWireup="true" CodeBehind="BusquedaTipoActivo.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.BusquedaTipoActivo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlFiltros" runat="server" Width="100%">
        <div style="background-color:#DAE7F6; border-color:#005DAA; border-style:inherit; width: 99%;">
            <table style="font-size:small;">
                <tr>
                    <td align="right">
                        <asp:Label ID="lblTipoActivo" runat="server" Text="Tipo Activo:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTipoActivo" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnBuscarTipoActivo" runat="server" Text="Buscar" />
                    </td>
                </tr>
            </table>
        </div>
        <div>

            <asp:GridView ID="gvGeneral" runat="server" Width="80%" Font-Size="Small" 
                HorizontalAlign="Center" AutoGenerateColumns="False" 
                EnableModelValidation="True" AllowPaging="True" BorderColor="#005DAA" 
                BorderStyle="Solid" CellPadding="0" Height="0px">
            <Columns>
                <asp:BoundField DataField="Ubicacion" HeaderText="Ubicaci&oacute;n" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="NoSerie" HeaderText="No.Serie" />
                <asp:BoundField DataField="TipoActivo" HeaderText="Tipo Activo" />
                <asp:BoundField DataField="Responsiva" HeaderText="Responsiva" />
            </Columns>
                <FooterStyle BackColor="#DAE7F6" />
                <HeaderStyle BackColor="#005DAA" Font-Bold="True" Font-Size="Small" 
                    Font-Strikeout="False" ForeColor="White" />
                <RowStyle Font-Size="Smaller" />
            </asp:GridView>            
        </div>
    </asp:Panel>
</asp:Content>
