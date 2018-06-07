<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreacionUsuario.aspx.cs"
    Inherits="InventarioHSC.Forms.Administracion.CreacionUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <%--<script src="../../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.maskedinput-1.2.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.formatCurrency-1.0.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/additional-methods.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.dataTables.min.js" type="text/javascript"></script>--%>
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <link href="../../App_Themes/Estilos/table_jui.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/EstiloInv.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/Estilos/mainMaster.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <table style="width: 100%; height: 97px;">
            <tr style="width: 100%">
                <td align="left" style="width: 20%; height: 40px;" class="logo">
                </td>
                <td align="left">
                </td>
                <td align="right">
                </td>
                <td align="right">
                </td>
            </tr>
        </table>
    </div>
    <div id="contenidoLogueado2" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="ui-state-error" id="Warning" runat="server">
                    <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                        <asp:Label ID="LabelError" runat="server" Text="" Font-Size="Small"></asp:Label></strong></div>
                <div class="ui-state-highlight" id="Info" runat="server">
                    <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                        <asp:Label ID="LabelInfo" runat="server" Text="" Font-Size="Small"></asp:Label></strong></div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="0" width="100%" cellspacing="0">
                    <tr>
                        <td class="CeldaImagenAzul">
                            .: Crear una cuenta nueva :.
                        </td>
                    </tr>
                </table>
                <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser">
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                            <ContentTemplate>
                                <p>
                                    Las contraseñas deben tener un mínimo de
                                    <%= Membership.MinRequiredPasswordLength %>
                                    caracteres de longitud.
                                </p>
                                <%--<span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>--%>
                                <%--<asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                         ValidationGroup="RegisterUserValidationGroup" />--%>
                                <div class="accountInfo">
                                    <fieldset class="register">
                                        <legend>Información de la cuenta</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        CssClass="failureNotification" Display="None" SetFocusOnError="true" ErrorMessage="Indicar Usuario"
                                                        ToolTip="Indicar Usuario" ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vceUsuario" runat="server" TargetControlID="UserNameRequired">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                        CssClass="failureNotification" Display="None" SetFocusOnError="true" ErrorMessage="Indicar E-mail"
                                                        ToolTip="Indicar E-mail" ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="EmailRequired">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        CssClass="failureNotification" Display="None" SetFocusOnError="true" ErrorMessage="Indicar contraseña"
                                                        ToolTip="Indicar contraseña" ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vcePasswordRequiered" runat="server" TargetControlID="PasswordRequired">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                                        Display="None" ErrorMessage="Indicar Confirmacion de Contraseña" ID="ConfirmPasswordRequired"
                                                        runat="server" ToolTip="Indicar Confirmacion de Contraseña" ValidationGroup="RegisterUserValidationGroup">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vceConfirmarPassword" runat="server" TargetControlID="ConfirmPasswordRequired">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                        ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="None"
                                                        ErrorMessage="La confirmacion de contraseña no coincide." ValidationGroup="RegisterUserValidationGroup"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <p>
                                        <center>
                                            <asp:Button ID="CreateUserButton" CssClass="ui-corner-all ui-state-default cancel"
                                                runat="server" CommandName="MoveNext" Text="Crear Usuario" ValidationGroup="RegisterUserValidationGroup" />
                                        </center>
                                    </p>
                                </div>
                            </ContentTemplate>
                            <CustomNavigationTemplate>
                            </CustomNavigationTemplate>
                        </asp:CreateUserWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>