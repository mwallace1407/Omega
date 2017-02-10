<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_Cartero_GenerarCarta.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_Cartero_GenerarCarta" %>

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
            width: 710px;
            height: 600px;
        }
        .modalPopup2
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ToolkitScriptManager>
    <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 590px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Generar Carta</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <asp:Panel ID="pnlDatos" runat="server" DefaultButton="btnProcesar">
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Fecha documento:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtFechaDocumento" runat="server" Width="92" MaxLength="10" autocomplete="off"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtFechaDocumento_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaDocumento">
                            </asp:MaskedEditExtender>
                            <asp:Button ID="btnRecalcular" runat="server" Text="Recalcular fecha" CssClass="boton"
                                CausesValidation="False" OnClick="btnRecalcular_Click" />
                            <asp:CalendarExtender ID="txtFechaDocumento_CalendarExtender" runat="server" Enabled="True"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TargetControlID="txtFechaDocumento">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfv_txtFechaDocumento" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtFechaDocumento" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtFechaDocumento" runat="server" Enabled="True"
                                TargetControlID="rfv_txtFechaDocumento">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Nombre destinatario:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtDestinatario01" runat="server" Width="200" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtDestinatario01" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtDestinatario01" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtDestinatario01" runat="server" Enabled="True"
                                TargetControlID="rfv_txtDestinatario01">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Notaría destinatario:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtDestinatario02" runat="server" Width="200" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtDestinatario02" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtDestinatario02" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtDestinatario02" runat="server" Enabled="True"
                                TargetControlID="rfv_txtDestinatario02">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Número préstamo:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtNumeroPrestamo" runat="server" Width="200" MaxLength="6"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtNumeroPrestamo_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="999999" MaskType="None" TargetControlID="txtNumeroPrestamo">
                            </asp:MaskedEditExtender>
                            <asp:RequiredFieldValidator ID="rfv_txtNumeroPrestamo" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtNumeroPrestamo" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtNumeroPrestamo" runat="server" Enabled="True"
                                TargetControlID="rfv_txtNumeroPrestamo">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Nombre acreditado:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtAcreditado" runat="server" Width="200" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtAcreditado" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtAcreditado" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtAcreditado" runat="server" Enabled="True"
                                TargetControlID="rfv_txtAcreditado">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Dirección garantía:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtDireccion" runat="server" Width="200" MaxLength="250" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtDireccion" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtDireccion" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtDireccion" runat="server" Enabled="True"
                                TargetControlID="rfv_txtDireccion">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Número escritura:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtNumeroEscritura" runat="server" Width="200" MaxLength="200" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtNumeroEscritura" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtNumeroEscritura" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtNumeroEscritura" runat="server" Enabled="True"
                                TargetControlID="rfv_txtNumeroEscritura">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Nombre Notario:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtNombreNotario" runat="server" Width="200" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtNombreNotario" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtNombreNotario" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtNombreNotario" runat="server" Enabled="True"
                                TargetControlID="rfv_txtNombreNotario">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Número notaría:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtNumeroNotaria" runat="server" Width="200" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtNumeroNotaria" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtNumeroNotaria" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtNumeroNotaria" runat="server" Enabled="True"
                                TargetControlID="rfv_txtNumeroNotaria">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Fecha firma escritura:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtFechaFirmaEscritura" runat="server" Width="200" MaxLength="10"
                                autocomplete="off"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtFechaFirmaEscritura_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaFirmaEscritura">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="txtFechaFirmaEscritura_CalendarExtender" runat="server"
                                Enabled="True" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TargetControlID="txtFechaFirmaEscritura">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfv_txtFechaFirmaEscritura" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtFechaFirmaEscritura" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtFechaFirmaEscritura" runat="server" Enabled="True"
                                TargetControlID="rfv_txtFechaFirmaEscritura">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Nombre revisor:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtNombreRevisor" runat="server" Width="200" MaxLength="200">Alejandra Sosa Magaña</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtNombreRevisor" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtNombreRevisor" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtNombreRevisor" runat="server" Enabled="True"
                                TargetControlID="rfv_txtNombreRevisor">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Correo revisor:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtCorreoRevisor" runat="server" Width="200" MaxLength="200">asosa@sucasita.com.mx</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtCorreoRevisor" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtCorreoRevisor" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtCorreoRevisor" runat="server" Enabled="True"
                                TargetControlID="rfv_txtCorreoRevisor">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Nombre representante:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtNombreRepresentante" runat="server" Width="200" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtNombreRepresentante" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtNombreRepresentante" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtNombreRepresentante" runat="server" Enabled="True"
                                TargetControlID="rfv_txtNombreRepresentante">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Fecha vigencia:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtFechaVigencia" runat="server" Width="200" MaxLength="10" autocomplete="off"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtFechaVigencia_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaVigencia">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="txtFechaVigencia_CalendarExtender" runat="server" Enabled="True"
                                FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TargetControlID="txtFechaVigencia">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfv_txtFechaVigencia" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtFechaVigencia" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtFechaVigencia" runat="server" Enabled="True"
                                TargetControlID="rfv_txtFechaVigencia">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Nombre firma:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtNombreFirma" runat="server" Width="200" MaxLength="200">LCP Ma. del Pilar Martinez Alcocer</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtNombreFirma" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtNombreFirma" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtNombreFirma" runat="server" Enabled="True"
                                TargetControlID="rfv_txtNombreFirma">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 340px;">
                        <div style="width: 125px; float: left; text-align: left;">
                            Puesto firma:
                        </div>
                        <div style="width: 215px; float: right; text-align: left;">
                            <asp:TextBox ID="txtPuestoFirma" runat="server" Width="200" MaxLength="200">Gerente Mesa de Control</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtPuestoFirma" runat="server" ErrorMessage="Campo requerido"
                                Display="None" ControlToValidate="txtPuestoFirma" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfve_txtPuestoFirma" runat="server" Enabled="True"
                                TargetControlID="rfv_txtPuestoFirma">
                            </asp:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 780px; height: 1px; text-align: center;">
                    <asp:Button ID="btnLimpiarDatos" runat="server" Text="Limpiar datos" CssClass="boton"
                            OnClick="btnLimpiarDatos_Click" CausesValidation="False" />&nbsp&nbsp&nbsp
                        <asp:Button ID="btnVistaPrevia" runat="server" Text="Vista Previa" CssClass="boton"
                            OnClick="btnVistaPrevia_Click" CausesValidation="False" />&nbsp&nbsp&nbsp
                        <asp:Button ID="btnProcesar" runat="server" Text="Generar carta" CssClass="boton"
                            OnClick="btnProcesar_Click" />
                        <asp:HiddenField ID="hddMesesVigencia" runat="server" Value="3" />
                        <asp:HiddenField ID="hddConvenio" runat="server" Value="Cuenta: 51500823063" />
                    </div>
                </asp:Panel>
            </div>
            <br />
        </div>
    </div>
    <br />
    <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlPrevia" TargetControlID="btnFalso"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPrevia" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div style="width: 710px; height: 600px; background-color: #FFFFFF;">
            <div style="width: 710px; height: 600px;">
                <div style="text-align: justify; width: 710px; height: 560px; overflow: auto;">
                    <asp:Literal ID="CodigoHTML" runat="server"></asp:Literal>
                </div>
                <div style="text-align: center; width: 710px; height: 40px;">
                    <br />
                    <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="boton" CausesValidation="False" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <div style="display: none">
        <asp:Button ID="btnFalso" runat="server" Text="" Visible="True" /></div>
    <div style="display: none">
        <asp:Button ID="btnFalso2" runat="server" Text="" Visible="True" /></div>
    <asp:ModalPopupExtender ID="mp2" runat="server" PopupControlID="pnlResultado" TargetControlID="btnFalso2"
        BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlResultado" runat="server" CssClass="modalPopup2" align="center"
        Style="display: none">
        <div style="text-align: center; width: 300px; height: 85px; background-color: #FFFFFF;">
            <asp:Label ID="lblReferencia" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnArchivo" runat="server" Text="Abrir PDF" CssClass="boton" CausesValidation="False"
                OnClick="btnArchivo_Click" Enabled="False" />&nbsp&nbsp
            <asp:Button ID="btnClose2" runat="server" Text="Cerrar" CssClass="boton" CausesValidation="False"
                OnClick="btnClose2_Click" />
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hddArchivo" runat="server" />
    <asp:HiddenField ID="hddArchivoSencillo" runat="server" />
</asp:Content>
