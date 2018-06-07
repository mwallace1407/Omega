<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Op_GenerarConstancia.aspx.cs" Inherits="InventarioHSC.Forms.Operacion.Op_GenerarConstancia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript">
        $(function () {
            $('[id$=btnProcesar]').click(function () {
                $(this).css('display', 'none');
                $('span#spanMsj').show();
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 800px; margin-left: auto; margin-right: auto; height: 250px; text-align: left;"
            class="divRoundedOpacity">
            <div style="width: 800px;" class="divRoundedOpacityTitle">
                Generar constancias</div>
            <br />
            <div style="padding-left: 10px; width: 780px;">
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        No. de préstamo:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:TextBox ID="txtPrestamo" runat="server" Width="200" MaxLength="6"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtPrestamo" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="txtPrestamo" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_txtPrestamo" runat="server" Enabled="True"
                            TargetControlID="rfv_txtPrestamo">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Tipo de cliente:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlTipoCliente" runat="server" Width="202">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlTipoCliente" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlTipoCliente" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlTipoCliente" runat="server" Enabled="True"
                            TargetControlID="rfv_ddlTipoCliente">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                        Año:
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlAnno" runat="server" Width="202">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlAnno" runat="server" ErrorMessage="Campo requerido"
                            Display="None" ControlToValidate="ddlAnno" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlAnno" runat="server" Enabled="True" TargetControlID="rfv_ddlAnno">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:CheckBox ID="chkForzar" runat="server" Text="Ignorar validaciones" />
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:Label ID="lblMsj" runat="server" ForeColor="#CC0000"></asp:Label>
                    </div>
                </div>
                <div style="width: 710px;">
                    <div style="width: 125px; float: left; text-align: left;">
                    </div>
                    <div style="width: 575px; float: right; text-align: left;">
                        <asp:Literal ID="ltlDescarga" runat="server"></asp:Literal>
                    </div>
                </div>
                <br />
                <br />
                <div style="width: 780px; height: 1px; text-align: center;">
                    <asp:Button ID="btnProcesar" runat="server" Text="Generar" CssClass="boton" OnClick="btnProcesar_Click" />&nbsp&nbsp
                    <%--<span id="spanMsj" style="display: none;">Generando..</span>--%>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>