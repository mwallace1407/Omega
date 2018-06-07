<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_SisCre.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_SisCre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div style="font-size: x-large; font-weight: bold; padding-top: 25px; padding-bottom: 25px">
        Redireccionando...
        <asp:Button ID="btnRedirect" runat="server" Text="Button" OnClick="btnRedirect_Click"
            OnClientClick="SetTarget();" Visible="False" />
        <asp:HyperLink ID="lnkApp" runat="server" NavigateUrl="http://hoperaciones:84/SisCredApp/SisCreWin.application"
            Target="_blank" Visible="False">SisCred</asp:HyperLink>
    </div>
</asp:Content>