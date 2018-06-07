<%@ Page Title="Modificar datos de servidores para aplicaciones" Language="C#" MasterPageFile="~/Forms/Main.Master"
    AutoEventWireup="true" CodeBehind="ModificarServidor.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.ModificarServidor" %>

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
            padding-left: 10px;
            width: 350px;
            height: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 930px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: MODIFICAR DATOS DE SERVIDORES PARA APLICACIONES :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Servidor:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlServidor" runat="server" Width="202" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlServidor_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <asp:Panel ID="pnlContent" runat="server" Enabled="False">
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Equipo fisico:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlEquipo" runat="server" Width="202" ValidationGroup="General">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlEquipo" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlEquipo" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlEquipo" runat="server" Enabled="True" TargetControlID="rfv_ddlEquipo">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Sistema Operativo:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlSO" runat="server" Width="202" ValidationGroup="General">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlSO" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlSO" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlSO" runat="server" Enabled="True" TargetControlID="rfv_ddlSO">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Equipo Virtualizado:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlEsVirtual" runat="server" Width="202" ValidationGroup="General">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlEsVirtual" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlEsVirtual" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlEsVirtual" runat="server" Enabled="True"
                            TargetControlID="rfv_ddlEsVirtual">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipo:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlTipo" runat="server" Width="202" ValidationGroup="General">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlTipo" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlTipo" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlTipo" runat="server" Enabled="True" TargetControlID="rfv_ddlTipo">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Estado:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlEstado" runat="server" Width="202" ValidationGroup="General">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlEstado" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlEstado" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlEstado" runat="server" Enabled="True" TargetControlID="rfv_ddlEstado">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px; display: none;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Nombre de equipo:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:TextBox ID="txtNombreEquipo" runat="server" Width="200" MaxLength="50" autocomplete="off"
                            Enabled="False" ValidationGroup="General"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtNombreEquipo" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtNombreEquipo" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtNombreEquipo" runat="server" Enabled="True"
                            TargetControlID="rfv_txtNombreEquipo">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Dirección IP:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:TextBox ID="txtIP" runat="server" Width="200" MaxLength="39" autocomplete="off"
                            ValidationGroup="General"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtIP" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtIP" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtIP" runat="server" Enabled="True" TargetControlID="rfv_txtIP">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        RAM (En MB):
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:TextBox ID="txtRAM" runat="server" Width="200" MaxLength="10" autocomplete="off"
                            ValidationGroup="General"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="ftxt_txtRAM" runat="server" Enabled="True" FilterType="Numbers"
                            TargetControlID="txtRAM">
                        </asp:FilteredTextBoxExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Llave de Windows:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:TextBox ID="txtLlave" runat="server" Width="200" MaxLength="30" autocomplete="off"
                            ValidationGroup="General"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px;">
                    <div style="width: 125px; float: left; text-align: left;">
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:Button ID="btnCintas" runat="server" Text="Registrar cinta" CssClass="boton" />
                        <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="#990000" Visible="False"></asp:Label>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 410px; height: 100px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Observaciones:
                    </div>
                    <div style="width: 275px; float: right; text-align: left;">
                        <asp:TextBox ID="txtObservaciones" runat="server" Width="200" MaxLength="1000" TextMode="MultiLine"
                            Height="100" ValidationGroup="General"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div style="border: medium ridge #ffffff; width: 410px;">
                    <asp:Panel ID="pnlDiscos" runat="server" DefaultButton="btnProcesarD">
                        <%--Ingrese las unidades de almacenamiento del equipo.--%>
                        Información de discos. Para modificar debe ir a la página de administración de discos
                        duros
                        <asp:HyperLink ID="lnkDiscos" runat="server" Target="_blank">aquí</asp:HyperLink>.
                        <br />
                        <br />
                        <div style="height: 30px; background-color: rgba(73,114,158,0.5); text-align: left;
                            display: none;">
                            Unidad:
                            <asp:DropDownList ID="ddlUnidad" runat="server" Width="50" AutoPostBack="True" OnSelectedIndexChanged="ddlUnidad_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp&nbsp&nbsp&nbsp Capacidad (En MB):
                            <asp:TextBox ID="txtCapacidad" autocomplete="off" runat="server" Width="50" MaxLength="10"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftxt_txtCapacidad" runat="server" Enabled="True"
                                FilterType="Numbers" TargetControlID="txtCapacidad">
                            </asp:FilteredTextBoxExtender>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Button ID="btnProcesarD" runat="server" Text="Agregar" CssClass="boton" OnClick="btnProcesarD_Click"
                                CausesValidation="False" Enabled="False" />
                        </div>
                        <asp:GridView ID="grdDiscos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                            AutoGenerateColumns="False" OnRowDeleting="grdDiscos_RowDeleting" OnPageIndexChanging="grdDiscos_PageIndexChanging"
                            AllowPaging="True" PageSize="7">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="XX-Small" />
                            <Columns>
                                <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                                <asp:BoundField DataField="Capacidad" HeaderText="Capacidad (MB)" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Imagenes/Delete.png"
                                    CausesValidation="False" ShowDeleteButton="True" Visible="False" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" Font-Size="XX-Small" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="XX-Small" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" Font-Size="XX-Small" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </asp:Panel>
                    <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
                </div>
                <br />
                <br />
                <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click"
                    ValidationGroup="General" />
                <br />
                <!-- ModalPopupExtender -->
                <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlModal" TargetControlID="btnCintas"
                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlModal" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                    <div style="width: 350px;">
                        <div style="width: 100px; float: left; text-align: left;">
                            Fecha respaldo:
                        </div>
                        <div style="width: 250px; float: right; text-align: left;">
                            <asp:TextBox ID="txtFechaRespaldo" runat="server" Width="200" MaxLength="10" autocomplete="off"
                                ValidationGroup="Cinta"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtFechaRespaldo_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaRespaldo">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="txtFechaRespaldo_CalendarExtender" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" TargetControlID="txtFechaRespaldo">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfv_txtFechaRespaldo" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtFechaRespaldo" InitialValue="" SetFocusOnError="True"
                                ValidationGroup="Cinta"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtFechaRespaldo" runat="server" Enabled="True"
                                TargetControlID="rfv_txtFechaRespaldo">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 350px;">
                        <div style="width: 100px; float: left; text-align: left;">
                            No. de cinta:
                        </div>
                        <div style="width: 250px; float: right; text-align: left;">
                            <asp:TextBox ID="txtCinta" runat="server" Width="200" MaxLength="25" autocomplete="off"
                                ValidationGroup="Cinta"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtCinta" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtCinta" InitialValue="" SetFocusOnError="True"
                                ValidationGroup="Cinta"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtCinta" runat="server" Enabled="True" TargetControlID="rfv_txtCinta">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 350px;">
                        <div style="width: 100px; float: left; text-align: left;">
                            Observaciones:
                        </div>
                        <div style="width: 250px; float: right; text-align: left;">
                            <asp:TextBox ID="txtObservacionesCinta" runat="server" Width="200" MaxLength="150"
                                autocomplete="off" Height="75px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtObservacionesCinta" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtObservacionesCinta" InitialValue="" SetFocusOnError="True"
                                ValidationGroup="Cinta"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtObservacionesCinta" runat="server" Enabled="True"
                                TargetControlID="rfv_txtObservacionesCinta">
                            </asp:ValidatorCalloutExtender>
                            <br />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div style="width: 350px;">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="boton" OnClick="btnRegistrar_Click"
                            ValidationGroup="Cinta" />&nbsp
                        <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="boton" />
                    </div>
                </asp:Panel>
                <!-- ModalPopupExtender -->
            </asp:Panel>
        </div>
    </div>
</asp:Content>