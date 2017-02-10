<%@ Control Language="c#" AutoEventWireup="True" Codebehind="bnrGeneral.ascx.cs" Inherits="InventarioHSC.Presentacion.General.bnrGeneral" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<%
				string urlSitio;
				urlSitio = "http://"+HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
				if (HttpContext.Current.Request.ApplicationPath!="/")
				{
					urlSitio = urlSitio+HttpContext.Current.Request.ApplicationPath;
				}
%>
<div id="top">
	<table cellspacing="0" cellpadding="0" border="0" width="100%">
		<tr>
			<td width="220">
				<img alt="Logo" src="~/App_Themes/Imagenes/logo_horizontal.png" border="0" runat="server"/></td>
			<td><h3>Sistema de Administración de Inmuebles.</h3>
				<p>Bienvenido:
					<asp:label Font-Bold="True" id="LabelUser" runat="server"></asp:label>
				</p>
			</td>
		</tr>
	</table>
</div>
<script type="text/javascript" src="<%Response.Write(urlSitio);%>/scripts/milonic_src.js"></script>
<div class="milonic">
    <a href="http://www.milonic.com/">JavaScript Menu, DHTML Menu Powered By Milonic</a>
</div>
<script type="text/javascript" src="<%Response.Write(urlSitio);%>/scripts/mmenudom.js"></script>
<!--<asp:Label ID="labBR" Runat="server"></asp:Label>-->
