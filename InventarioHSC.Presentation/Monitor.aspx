<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monitor.aspx.cs" Inherits="InventarioHSC.Monitor" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Monitor de rendimiento</title>
</head>
<body style="background-image: url('App_Themes/Imagenes/SuCasitaWater.png'); background-repeat: repeat;
    background-attachment: fixed">
    <form id="form1" runat="server">
    <div>
        <h1 style="font-size: x-large">
            Estadísticas del servidor
            <asp:Label ID="lblSrv" runat="server" Text=""></asp:Label></h1>
        <br />
        <i>Estas estadísticas fueron obtenidas el
            <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></i>
        <br />
        <br />
        <div style="width: 640px;">
            <div style="float: left; width: 320px;">
                <b>Memoria RAM:&nbsp<asp:Label ID="lblRAM" runat="server" Text="" Font-Size="X-Small"></asp:Label></b>
                <br />
                <br />
                <br />
                <asp:Chart ID="chartRAM" runat="server" Height="200px" Width="300px">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Title1" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div style="float: right; width: 320px;">
                <b>Procesador:</b>
                <br />
                <br />
                <br />
                <asp:Chart ID="chartProc" runat="server" Height="200px" Width="300px">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Title1" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
        <br />
        <br />
        <div style="width: 660px;">
            <div style="float: left; width: 330px;">
                <b>Disco principal:</b>
                <br />
                <br />
                <br />
                <asp:Chart ID="chartDiscoP" runat="server" Height="200px" Width="320px">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Title1" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div style="float: right; width: 330px;">
                <b>Actividad en disco:</b>
                <br />
                <br />
                <br />
                <asp:Chart ID="chartDiscoAc" runat="server" Height="200px" Width="300px">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Title1" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </div>
    </form>
</body>
</html>