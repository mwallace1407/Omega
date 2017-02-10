<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventarioHSC.Default" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <title>Sistema Omega Ω</title>
    <link rel="shortcut icon" href="favicon.ico" />
    <link href="App_Themes/Estilos/login-box.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Estilos/estilo1.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" rel="Stylesheet"
        type="text/css" />
    <style type="text/css">
        html, body
        {
            font: Trebuchet MS;
        }
        .footer
        {
            background-color: #1a5395;
            color: #ffffff;
            padding: 10px 0;
            text-align: center;
            line-height: normal;
            margin: 0 0 30px 0;
            font-size: small;
            border-radius: 0 0 4px 4px;
            -webkit-border-radius: 0 0 4px 4px;
            -moz-border-radius: 0 0 4px 4px;
            background-image: -o-linear-gradient(-90deg,rgba(255,255,255,0.38),rgba(255,255,255,0.16));
            background-image: -moz-linear-gradient(-90deg,rgba(255,255,255,0.38),rgba(255,255,255,0.16));
            background-image: -webkit-gradient(linear,50% 0%,50% 100%,from(rgba(255,255,255,0.38)),to(rgba(255,255,255,0.16)));
            background-image: -webkit-linear-gradient(-90deg,rgba(255,255,255,0.38),rgba(255,255,255,0.16));
        }
        
        img.grayscale
        {
            filter: url("data:image/svg+xml;utf8,<svg xmlns=\'http://www.w3.org/2000/svg\'><filter id=\'grayscale\'><feColorMatrix type=\'matrix\' values=\'0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0 0 0 1 0\'/></filter></svg>#grayscale"); /* Firefox 3.5+ */
            filter: gray; /* IE6-9 */
            -webkit-filter: grayscale(100%); /* Chrome 19+ & Safari 6+ */
        }
        
        img.grayscale:hover
        {
            filter: none;
            -webkit-filter: grayscale(0%);
        }
    </style>
    <script type="text/javascript">
        function FocusPrimero() {
            document.getElementById("Login1").focus();
        }

        function grayscale(image, bPlaceImage) {
            var myCanvas = document.createElement("canvas");
            var myCanvasContext = myCanvas.getContext("2d");

            var imgWidth = image.width;
            var imgHeight = image.height;
            // You'll get some string error if you fail to specify the dimensions
            myCanvas.width = imgWidth;
            myCanvas.height = imgHeight;
            //  alert(imgWidth);
            myCanvasContext.drawImage(image, 0, 0);

            // This function cannot be called if the image is not rom the same domain.
            // You'll get security error if you do.
            var imageData = myCanvasContext.getImageData(0, 0, imgWidth, imgHeight);

            // This loop gets every pixels on the image and
            for (j = 0; j < imageData.height; i++) {
                for (i = 0; i < imageData.width; j++) {
                    var index = (i * 4) * imageData.width + (j * 4);
                    var red = imageData.data[index];
                    var green = imageData.data[index + 1];
                    var blue = imageData.data[index + 2];
                    var alpha = imageData.data[index + 3];
                    var average = (red + green + blue) / 3;
                    imageData.data[index] = average;
                    imageData.data[index + 1] = average;
                    imageData.data[index + 2] = average;
                    imageData.data[index + 3] = alpha;
                }
            }

            if (bPlaceImage) {
                var myDiv = document.createElement("div");
                myDiv.appendChild(myCanvas);
                image.parentNode.appendChild(myCanvas);
            }
            return myCanvas.toDataURL();
        }
    </script>
</head>
<body onloadeddata="FocusPrimero();" style="background-image: url('App_Themes/Imagenes/SuCasitaWater.png');
    background-repeat: repeat; background-attachment: fixed">
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center; width: 1000px; height: 395px; margin-left: auto;
            margin-right: auto;">
            <div style="float: left; height: 75px;">
                <div style="float: left; width: 203px; height: 75px; text-align: left;">
                </div>
                <div style="float: right; width: 576px; height: 75px; font-size: small; display: table-cell;
                    vertical-align: top;">
                </div>
            </div>
            <div style="float: right; width: 221px; height: 75px;">
                <span style="height: 45px; font-size: small; display: table-cell; vertical-align: top;">
                </span>
            </div>
            <div style="width: 1000px; height: 300px;">
                <div style="text-align: center; width: 525px; margin-left: auto; margin-right: auto;">
                    <div style="width: 135px; float: left">
                        <asp:Image runat="server" ID="imgCasita" ImageUrl="~/App_Themes/Imagenes/CastorParado.png"
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
                    <br />
                    <div style="height: 220px;">
                        &nbsp</div>
                    <div style="border-style: none; width: 525px; font-size: small; color: #808080; text-align: center;">
                        <div style="width: 525px;">
                            Navegadores recomendados:</div>
                        <div style="width: 525px;">
                            <a href="Docs/Chrome.exe" style="color: #FFFFFF">
                                <img src="App_Themes/Imagenes/Google_Chrome_icon_small.png" alt="Chrome" title="Chrome"
                                    style="border-style: none" class="grayscale" />
                            </a>&nbsp <a href="http://www.mozilla.org/es-MX/firefox/" style="color: #FFFFFF">
                                <img src="App_Themes/Imagenes/firefox_icon_small.png" alt="Firefox" title="Firefox"
                                    style="border-style: none" class="grayscale" />
                            </a>&nbsp <a href="http://www.opera.com/download/" style="color: #FFFFFF">
                                <img src="App_Themes/Imagenes/Opera_icon_small.png" alt="Opera" title="Opera" style="border-style: none"
                                    class="grayscale" />
                            </a>&nbsp <a href="http://es.maxthon.com/" style="color: #FFFFFF">
                                <img src="App_Themes/Imagenes/Maxthon_icon_small.png" alt="Maxthon" title="Maxthon"
                                    style="border-style: none" class="grayscale" />
                            </a>&nbsp <a href="http://www.apple.com/mx/downloads/" style="color: #FFFFFF">
                                <img src="App_Themes/Imagenes/Safari_icon_small.png" alt="Safari" title="Safari"
                                    style="border-style: none" class="grayscale" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 1000px; height: 50px;" class="footer">
                Sistema Omega Ω
                <br />
                Copyright &copy; Hipotecaria Su Casita 2015
            </div>
        </div>
    </div>
    </form>
</body>
</html>
