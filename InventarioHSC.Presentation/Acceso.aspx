<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Sitio.Master" AutoEventWireup="true"
    CodeBehind="Acceso.aspx.cs" Inherits="InventarioHSC.Forms.Acceso" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Themes/Estilos/login-box.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Estilos/estilo1.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" rel="Stylesheet"
        type="text/css" />
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('input[type="text"]').addClass("Textbox");
            $('input[type="text"]').focus(function () {
                $(this).removeClass("Textbox").addClass("Hover");
                if (this.value == this.defaultValue) {
                    this.value = '';
                }
                if (this.value != this.defaultValue) {
                    this.select();
                }
            });
            $('input[type="text"]').blur(function () {
                $(this).removeClass("Hover").addClass("Textbox");
                if ($.trim(this.value == '')) {
                    this.value = (this.defaultValue ? this.defaultValue : '');
                }
            });
        });
    </script>--%>
    <div>
        <table style="vertical-align: top; width: 100%; border-collapse: collapse;">
            <tr>
                <td style="text-align: center">
                    <%--<img alt="Don Vertice" src="APP_THEMES/AZUL/IMAGENES/CastorColor.png" style="width: 80px; height: 80px" />--%>
                </td>
            </tr>
        </table>
        <div>
            <div style="text-align: center; width: 525px; margin-left: auto; margin-right: auto;">
                <div style="width: 135px; float: left">
                    <asp:Image runat="server" ID="imgCasita" ImageUrl="~/App_Themes/Imagenes/CastorParado.jpg"
                        Height="136px" Width="131px" /></div>
                <div style="width: 384px; height: 50px; float: right">
                </div>
                <div style="width: 384px; float: right; text-align: left;">
                    <asp:Panel ID="pnlLog" runat="server" HorizontalAlign="Center">
                        <asp:Login ID="Login1" runat="server" CssClass="Login" DestinationPageUrl="~/Forms/Home.aspx"
                            DisplayRememberMe="false" FailureText="Intento fallido. Por favor trate de nuevo."
                            LoginButtonText="Acceder" OnLoggedIn="Login1_LoggedIn" PasswordLabelText="Password:"
                            PasswordRequiredErrorMessage="El password es obligatorio." RememberMeSet="false"
                            RememberMeText="" TitleText="" TextBoxStyle-CssClass="Textbox" UserNameLabelText="Usuario:"
                            UserNameRequiredErrorMessage="El nombre de usuario es obligatorio." Width="283px"
                            OnLoginError="Login1_LoginError" OnAuthenticate="Login1_Authenticate" OnLoggingIn="Login1_LoggingIn">
                            <TitleTextStyle BackColor="#006699" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                            <LoginButtonStyle CssClass="ui-corner-all ui-state-default cancel" />
                            <TextBoxStyle BorderStyle="None" Width="200px" />
                        </asp:Login>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>