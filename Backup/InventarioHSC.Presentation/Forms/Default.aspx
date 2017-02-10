<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventarioHSC.Forms.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table>
                <tr>
                    <td>
                        <asp:HyperLink ID="hlAlta" runat="server" NavigateUrl="~/Forms/Articulos/AltaArticulo.aspx">Alta de Artículos</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="hlConsulta" runat="server" NavigateUrl="~/Forms/Articulos/Asignacion.aspx?idItem=0">Asignación</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="hl" runat="server" NavigateUrl="~/Forms/Articulos/BusquedaArticulo.aspx">Consultas</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink3" runat="server">Alta de Artículos</asp:HyperLink>--%>
                    </td>
                </tr>
           </table>
    </div>
    </form>
</body>
</html>
