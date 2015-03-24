<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="BuscarDocumentoSAP.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.BuscarDocumentoSAP" %>

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
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 350px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Buscar documentos</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipo de documento:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlTipo" runat="server" Width="202" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlTipo" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlTipo" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlTipo" runat="server" Enabled="True" TargetControlID="rfv_ddlTipo">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <asp:Panel ID="pnlG1" runat="server" Wrap="True" Visible="False" DefaultButton="btnProcesar">
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Año:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlAnio" runat="server" Width="202" ValidationGroup="G1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_ddlAnio" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="ddlAnio" InitialValue="0" SetFocusOnError="True"
                                ValidationGroup="G1"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_ddlAnio" runat="server" Enabled="True" TargetControlID="rfv_ddlAnio">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Número de empleado:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:TextBox ID="txtFiltro" runat="server" Width="200" MaxLength="6" autocomplete="off"
                                ValidationGroup="G1"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftxt_txtFiltro" runat="server" Enabled="True" FilterType="Numbers"
                                TargetControlID="txtFiltro">
                            </asp:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="rfv_txtFiltro" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtFiltro" InitialValue="" SetFocusOnError="True"
                                ValidationGroup="G1"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtFiltro" runat="server" Enabled="True" TargetControlID="rfv_txtFiltro">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 780px; height: 1px; text-align: center;">
                        <asp:Button ID="btnProcesar" runat="server" Text="Buscar" CssClass="boton" OnClick="btnProcesar_Click"
                            ValidationGroup="G1" />&nbsp&nbsp
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlG2" runat="server" Wrap="True" Visible="False" DefaultButton="btnProcesar2">
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Año:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlAnio2" runat="server" Width="202" ValidationGroup="G2">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_ddlAnio2" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="ddlAnio2" InitialValue="0" SetFocusOnError="True"
                                ValidationGroup="G2"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_ddlAnio2" runat="server" Enabled="True" TargetControlID="rfv_ddlAnio2">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Categoría:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlSubTipo" runat="server" Width="202" ValidationGroup="G2">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_ddlSubTipo" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="ddlSubTipo" InitialValue="0" SetFocusOnError="True"
                                ValidationGroup="G2"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_ddlSubTipo" runat="server" Enabled="True"
                                TargetControlID="rfv_ddlSubTipo">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Periodo:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlPeriodo" runat="server" Width="202" ValidationGroup="G2">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_ddlPeriodo" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="ddlPeriodo" InitialValue="0" SetFocusOnError="True"
                                ValidationGroup="G2"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_ddlPeriodo" runat="server" Enabled="True"
                                TargetControlID="rfv_ddlPeriodo">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 780px; height: 1px; text-align: center;">
                        <asp:Button ID="btnProcesar2" runat="server" Text="Buscar" CssClass="boton" OnClick="btnProcesar2_Click"
                            ValidationGroup="G2" />&nbsp&nbsp
                    </div>
                </asp:Panel>
                <br />
                <br />
                <div style="width: 780px; overflow: auto; height: 175px; text-align: left;">
                    <asp:Label ID="lblNoRegs" runat="server" Text="No se encontraron registros" Font-Bold="True"
                        Visible="False"></asp:Label>
                    <br />
                    <asp:GridView ID="grdDatos" runat="server" Width="220px" AutoGenerateColumns="False"
                        OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" GridLines="None">
                        <Columns>
                            <asp:BoundField HeaderText="Concepto" DataField="Concepto">
                                <HeaderStyle Width="150px" HorizontalAlign="Left" />
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Archivo">
                                <EditItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkRuta" runat="server" Text="Descargar" CssClass="HyperLink"
                                        Target="_blank">Descargar</asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="70px" HorizontalAlign="Left" />
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Ruta" HeaderText="Ruta" HeaderStyle-CssClass="GridColumnHide"
                                ItemStyle-CssClass="GridColumnHide">
                                <HeaderStyle Width="1px" />
                                <ItemStyle Width="1px" />
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
            </div>
        </div>
    </div>
    <br />
</asp:Content>
