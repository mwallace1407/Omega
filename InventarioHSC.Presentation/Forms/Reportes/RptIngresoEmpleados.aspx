<%@ Page Title="Reporte para el ingreso de empleados" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="RptIngresoEmpleados.aspx.cs" Inherits="InventarioHSC.Forms.Reportes.RptIngresoEmpleados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 470px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: REPORTE PARA EL INGRESO DE EMPLEADOS :.
            </div>
            <br />
            <asp:UpdatePanel ID="UPnl" runat="server">
                <ContentTemplate>
                    <div style="width: 200px; text-align: left;">
                        <asp:Panel ID="pnlOpciones" runat="server">
                            <asp:RadioButton ID="rbAnual" runat="server" GroupName="rbOpciones" Text="Reporte con filtro global"
                                AutoPostBack="True" Checked="True" OnCheckedChanged="rbAnual_CheckedChanged" />
                            <br />
                            <asp:RadioButton ID="rbFiltros" runat="server" Text="Reporte con filtro por empleado"
                                GroupName="rbOpciones" AutoPostBack="True" OnCheckedChanged="rbFiltros_CheckedChanged" />
                        </asp:Panel>
                    </div>
                    <br />
                    <asp:Panel ID="pnlAnual" runat="server" Visible="True">
                        <div style="width: 180px; text-align: left;">
                            <asp:GridView ID="grdDatos" runat="server" Width="120px" AutoGenerateColumns="False"
                                OnRowDataBound="grdDatos_RowDataBound" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField HeaderText="Concepto" DataField="Emp">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Archivo">
                                        <EditItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkRuta" runat="server" Text="Descargar" CssClass="HyperLink"
                                                Target="_blank">Descargar</asp:HyperLink>
                                        </ItemTemplate>
                                        <HeaderStyle Width="70px" />
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
                    </asp:Panel>
                    <asp:Panel ID="pnlFiltros" runat="server" Visible="False">
                        <div style="width: 360px; height: 100px;">
                            <div style="width: 75px; float: left; text-align: left;">
                                Empleados:
                            </div>
                            <div style="width: 275px; float: right; text-align: left;">
                                <div style="border: 3px ridge SteelBlue; height: 100px; overflow: scroll; overflow-x: hidden;">
                                    <asp:CheckBoxList ID="chkEmpleados" runat="server" Width="250" AutoPostBack="True"
                                        OnSelectedIndexChanged="chkEmpleados_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div style="width: 200px; text-align: left;">
                            <asp:GridView ID="grdDatosF" runat="server" Width="250px" AutoGenerateColumns="False"
                                OnRowDataBound="grdDatosF_RowDataBound" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField HeaderText="Concepto" DataField="Concepto">
                                        <HeaderStyle Width="180px" />
                                        <ItemStyle Width="180px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Archivo">
                                        <EditItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkRuta" runat="server" Text="Descargar" CssClass="HyperLink"
                                                Target="_blank">Descargar</asp:HyperLink>
                                        </ItemTemplate>
                                        <HeaderStyle Width="70px" />
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
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:Button ID="btnProcesar" runat="server" Text="Generar Reporte" CssClass="boton"
                        OnClick="btnProcesar_Click" Visible="False" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UPrg" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UPnl">
                <ProgressTemplate>
                    <div style="top: 0px; height: 100%; background-color: Gray; opacity: 0.9; filter: alpha(opacity=90);
                        vertical-align: middle; left: 0px; z-index: 999999; width: 100%; position: absolute;
                        text-align: center;">
                        <div style="text-align: center; width: 100px; height: 120px; position: absolute;
                            left: 46%; top: 42%; color: #DDDDDD; font-size: large; font-weight: bold;">
                            <img src="../../App_Themes/Imagenes/gears_animated.gif" alt="Procesando..." style="border-width: 0px;
                                width: 100px; height: 100px;" />
                            <br />
                            Procesando...
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>
</asp:Content>