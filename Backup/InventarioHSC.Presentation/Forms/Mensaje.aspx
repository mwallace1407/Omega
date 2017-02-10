<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="InventarioHSC.Forms.Mensaje" ValidateRequest="false"  %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <title>Mensajes del sistema</title>
    <link rel="stylesheet" href="../App_Themes/Menu/menu2.css" type="text/css" />
    <link rel="stylesheet" href="../App_Themes/Estilos/estilo1.css" type="text/css" />
</head>
<body onload="Foco();" style="background-image: url('../App_Themes/Imagenes/SuCasitaWater.png');
    background-repeat: repeat; background-attachment: fixed">
    <form id="form1" runat="server">
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="text-align: center; width: 800px; margin-left: auto; margin-right: auto;">
            <div class="MensajeIzqS">
            </div>
            <div style="text-align: left;" class="divRoundedOpacity">
                <div class="divRoundedOpacityTitle" style="font-weight: bold; font-size: large;">
                    Mensaje del sistema</div>
                <div style="text-align: center">
                    &nbsp<br />
                    <asp:Image ID="imgMensaje" runat="server" Height="50px" Width="50px" ImageUrl="~/App_Themes/Imagenes/info.png" />
                </div>
                <div style="padding-left: 10px">
                    <br />
                    <asp:Label ID="lblTitulo" runat="server" Text="Título:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="lblTituloDesc" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Text="Descripción:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="lblMensajeDesc" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                </div>
                <div style="text-align: center">
                    <input id="btnRegresar" type="button" value="Regresar" class="boton"
                        onmousedown="Regresa();" onkeypress="catchEnter(event);" />
                    <br />
                    <br />
                    <asp:HiddenField ID="hddPagina" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
