<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_Cartero_LiberarCarta.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_Cartero_LiberarCarta" %>

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
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 255px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Liberar cartas</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:Panel ID="pnlRef" runat="server" DefaultButton="btnValidar">
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            No. de referencia:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:TextBox ID="txtReferencia" runat="server" Width="200" MaxLength="16"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtReferencia_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtReferencia">
                            </asp:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="rfv_txtReferencia" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtReferencia" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtReferencia" runat="server" Enabled="True"
                                TargetControlID="rfv_txtReferencia">
                            </asp:ValidatorCalloutExtender>
                            <asp:HiddenField ID="hddReferencia" runat="server" />
                            <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 780px; height: 1px; text-align: center;">
                        <asp:Button ID="btnValidar" runat="server" Text="Validar referencia" CssClass="boton"
                            OnClick="btnValidar_Click" />&nbsp&nbsp
                    </div>
                </asp:Panel>
                <br />
                <br />
                <asp:Panel ID="pnlDatos" runat="server" Visible="False" ClientIDMode="Inherit" DefaultButton="btnProcesar">
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Folio cartero:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:Label ID="lblFolioCartero" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Folio CastorTel:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:Label ID="lblFolioCastorTel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Cliente:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Préstamo:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:Label ID="lblPrestamo" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Tipo de carta:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:Label ID="lblTipoCarta" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div style="width: 710px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Dirección garantía:
                        </div>
                        <div style="width: 575px; float: right; text-align: left;">
                            <asp:Label ID="lblDireccionGarantia" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 780px; height: 1px; text-align: center;">
                        <asp:Button ID="btnProcesar" runat="server" Text="Liberar carta" CssClass="boton"
                            OnClick="btnProcesar_Click" />&nbsp&nbsp
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton" OnClick="btnCancelar_Click" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
