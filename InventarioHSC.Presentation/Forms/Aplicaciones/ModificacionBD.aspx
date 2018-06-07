<%@ Page Title="Modificar datos de BD" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="ModificacionBD.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.ModificacionBD" %>

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
    <div id="contenidoLogueado2" runat="server" style="height: 800px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: MODIFICAR DATOS DE BD :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Base de datos:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlBD" runat="server" Width="202" AutoPostBack="True" OnSelectedIndexChanged="ddlBD_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <asp:Panel ID="pnlContent" runat="server" Enabled="False">
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Servidor:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlServidor" runat="server" Width="202" OnSelectedIndexChanged="ddlServidor_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlServidor" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlServidor" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlServidor" runat="server" Enabled="True"
                            TargetControlID="rfv_ddlServidor">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Instancia BD:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlInstanciaBD" runat="server" Width="202">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlInstanciaBD" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlInstanciaBD" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlInstanciaBD" runat="server" Enabled="True"
                            TargetControlID="rfv_ddlInstanciaBD">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Nombre de BD:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:TextBox ID="txtNombre" runat="server" Width="200" MaxLength="50" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtNombre" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtNombre" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtNombre" runat="server" Enabled="True" TargetControlID="rfv_txtNombre">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Productiva:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:CheckBox ID="chkProductiva" runat="server" />
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Activa:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:CheckBox ID="chkActiva" runat="server" AutoPostBack="True" OnCheckedChanged="chkActiva_CheckedChanged" />
                        <asp:Panel ID="pnlBaja" runat="server" Visible="False">
                            Fecha Baja:
                            <asp:TextBox ID="txtFechaBaja" runat="server"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtFechaBaja_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" MaskType="Date" TargetControlID="txtFechaBaja" UserDateFormat="DayMonthYear"
                                Mask="99/99/9999">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="txtFechaBaja_CalendarExtender" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" TargetControlID="txtFechaBaja" TodaysDateFormat="dd/MMMM/yyyy">
                            </asp:CalendarExtender>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div style="width: 810px;">
                    <div style="width: 410px; float: left;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Respaldos:
                        </div>
                        <div style="width: 275px; float: right; text-align: left;">
                            <asp:Button ID="btnAgregarCinta" runat="server" Text="Agregar cinta" CssClass="boton"
                                OnClick="btnAgregarCinta_Click" />
                            <asp:Panel ID="pnlCinta" runat="server" Visible="False">
                                No. Cinta:
                                <asp:TextBox ID="txtCinta" runat="server" MaxLength="25"></asp:TextBox>
                                <br />
                                Observaciones:
                                <asp:TextBox ID="txtObservacionesCinta" runat="server" MaxLength="150" Height="60px"
                                    TextMode="MultiLine" Width="245px"></asp:TextBox>
                                <br />
                                <label style="font-size: xx-small">
                                    Si desea registrar la cinta con una fecha diferente a la actual utilice el módulo
                                    de registro de cintas.</label>
                            </asp:Panel>
                        </div>
                    </div>
                    <div style="width: 400px; float: right; text-align: left;">
                        <asp:Panel ID="pnlURespaldo" runat="server" Visible="False">
                            Datos del último respaldo:
                            <br />
                            <asp:GridView ID="grdCintas" runat="server" Width="370px" AutoGenerateColumns="True"
                                ForeColor="#333333" GridLines="None">
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle Width="120px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                    HorizontalAlign="Center"></HeaderStyle>
                                <PagerStyle BackColor="#284775" ForeColor="White" />
                                <RowStyle CssClass="GridItemLeft" />
                                <AlternatingRowStyle CssClass="GridAltItemLeft" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
                <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>