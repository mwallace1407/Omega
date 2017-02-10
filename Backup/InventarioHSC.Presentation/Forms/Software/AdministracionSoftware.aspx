<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministracionSoftware.aspx.cs"
    Inherits="InventarioHSC.Forms.Software.AdministracionSoftware" EnableEventValidation="false"
    Title="Administración de Software" MasterPageFile="~/Forms/Main.Master" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="head" ContentPlaceHolderID="headMaster" runat="server">
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style2
        {
            width: 600px;
        }
        
        .style3
        {
            width: 550px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var chkBox = $("input[id$='gdvSoftware_ctl01_ChkAll']");
            chkBox.click(
             function () {
                 $("#gdvSoftware INPUT[type='checkbox']")
                 .attr('checked', chkBox
                 .is(':checked'));
             });

            // To deselect CheckAll when a GridView CheckBox
            // is unchecked
            $("#gdvSoftware INPUT[type='checkbox']").click(
        function (e) {
            if (!$(this)[0].checked) {
                chkBox.attr("checked", false);
            }
        });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server">
        <div class="MainDiv" id="space">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="ui-state-error" id="Warning" runat="server" style="text-align: left">
                                <span class="ui-icon ui-icon-alert" style="float: left"></span><strong>
                                    <asp:Label ID="LabelError" runat="server" Text=""></asp:Label></strong></div>
                            <div class="ui-state-highlight" id="Info" runat="server" style="text-align: left">
                                <span class="ui-icon ui-icon-info" style="float: left"></span><strong>
                                    <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label></strong></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                        .: NUEVA ASIGNACIÓN :.
                    </div>
                    <br />
                    <div style="text-align: left;">
                        <asp:Button ID="btnNuevoUsuario" runat="server" Text="Nuevo Usuario" CssClass="ui-corner-all ui-state-default cancel"
                            OnClick="btnNuevoUsuario_Click" />
                    </div>
                    <br />
                    <br />
                    <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                        .: DATOS DEL USUARIO :.
                    </div>
                    <br />
                    <div style="text-align: left;">
                        <asp:Panel ID="pnlNuevoUsuario" runat="server" Visible="False">
                            <div style="width: 370px;">
                                <div style="width: 115px; float: left; text-align: left;">
                                    Nombre del usuario:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:TextBox Width="248px" ID="txtUsuarioNuevo" runat="server" Visible="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfUsuarioNuevo" runat="server" ControlToValidate="txtUsuarioNuevo"
                                        CssClass="label" ErrorMessage='El campo "Usuario Asignado:" es requerido' ToolTip='El campo "Usuario Asignado:" es requerido'
                                        Display="None" SetFocusOnError="true" ValidationGroup="vgAsignaUsuarioNuevo">*
                                    </asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender runat="server" ID="vceUsuarioNuevo" TargetControlID="rfUsuarioNuevo">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="pnlUsuarioAsignado" runat="server">
                            <div style="width: 370px;">
                                <div style="width: 115px; float: left; text-align: left;">
                                    Usuario Asignado:
                                </div>
                                <div style="width: 255px; float: right;">
                                    <asp:DropDownList ID="ddlUsuarioAsignado" CausesValidation="false" AppendDataBoundItems="true"
                                        DataTextField="Nombre_Usuario" DataValueField="Nombre_Usuario" AutoPostBack="true"
                                        runat="server" Enabled="true" Width="250px" OnSelectedIndexChanged="ddlUsuarioAsignado_SelectedIndexChanged">
                                        <asp:ListItem Text="--- Selecccionar ---" Value="Seleccionar" />
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvUsuarioAsignado" runat="server" ValidationGroup="vgAsignaUsuarioNuevo"
                                        ControlToValidate="ddlUsuarioAsignado" ErrorMessage="Seleccione un usuario" Operator="NotEqual"
                                        Display="None" SetFocusOnError="true" ValueToCompare="Seleccionar">
                                    </asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender runat="server" ID="vcUsuarioAsiganado" TargetControlID="cvUsuarioAsignado">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
                            <br />
                        </asp:Panel>
                        <div style="width: 370px;">
                            <div style="width: 115px; float: left; text-align: left;">
                                Area:
                            </div>
                            <div style="width: 255px; float: right;">
                                <asp:DropDownList ID="dplAreaSolicita" Width="250px" AppendDataBoundItems="true"
                                    runat="server">
                                    <asp:ListItem Text="--- Selecccionar ---" Value="Seleccionar" />
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cvAreaSolicita" runat="server" ValidationGroup="vgAsignaUsuarioNuevo"
                                    ControlToValidate="dplAreaSolicita" ErrorMessage="Seleccione un Area" Operator="NotEqual"
                                    Display="None" SetFocusOnError="true" ValueToCompare="Seleccionar">
                                </asp:CompareValidator>
                                <asp:ValidatorCalloutExtender runat="server" ID="vceAreaSolicita" TargetControlID="cvAreaSolicita">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                    <br />
                    <asp:Panel runat="server" ID="pnlAsignacionSoftware" Visible="False">
                        <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                            .: ASIGNACIÓN DE SOFTWARE :.
                        </div>
                        <br />
                        <div style="width: 600px; text-align: left;">
                            <div style="width: 600px;">
                                <asp:HiddenField ID="hdnNuevoUsuario" runat="server" Value="0" />
                                <asp:GridView ID="gvwSoftwareAsignado" runat="server" AutoGenerateColumns="False"
                                    Width="600" EmptyDataText="No existe Informacion" AllowPaging="True" PageSize="20">
                                    <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                    <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                    <PagerSettings Mode="NextPreviousFirstLast" />
                                    <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                    <EmptyDataRowStyle BackColor="#DEDDF3" />
                                    <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Nombre Licencia" InsertVisible="False"
                                            ReadOnly="True" SortExpression="Nombre Licencia" />
                                        <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                                        <asp:BoundField DataField="Serial" HeaderText="Key" InsertVisible="False" ReadOnly="True"
                                            SortExpression="Serial" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <div style="width: 600px; text-align: left;">
                                <asp:Button ID="btnAgregarLicencia" ToolTip="Agregar Licencias de Software" runat="server"
                                    ValidationGroup="vgAsignaUsuarioNuevo" Width="100px" CausesValidation="true"
                                    Text="Agregar" CssClass="ui-corner-all ui-state-default cancel" OnClick="btnAgregarLicencia_Click"
                                    Visible="True" />
                            </div>
                        </div>
                        <br />
                        <br />
                    </asp:Panel>
                    <br />
                    <asp:Panel runat="server" ID="pnlLiberacion" Visible="False">
                        <div class="CeldaImagenAzul" style="text-align: left; cursor: default;">
                            .: LIBERACION DE SOFTWARE :.
                        </div>
                        <br />
                        <div style="width: 600px; text-align: left;">
                            <div style="width: 600px;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvLiberacionSoftware" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="Cve_Asignacion" Width="600" EmptyDataText="No existe Informacion"
                                            AllowPaging="True" OnPageIndexChanging="gvLiberacionSoftware_PageIndexChanging"
                                            OnPageIndexChanged="gvLiberacionSoftware_PageIndexChanged" PageSize="15">
                                            <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                            <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                            <PagerSettings Mode="NextPreviousFirstLast" />
                                            <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                            <EmptyDataRowStyle BackColor="#DEDDF3" />
                                            <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelecciona" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Nombre Licencia" InsertVisible="False"
                                                    ReadOnly="True" SortExpression="Nombre Licencia" />
                                                <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                                                <asp:BoundField DataField="Serial" HeaderText="Key" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="Serial" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div style="width: 600px; text-align: left;">
                                <asp:Button ID="btnLiberarSoftware" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                                    ToolTip="Liberar Software Asignado" ValidationGroup="vgAsignaUsuarioNuevo" CausesValidation="true"
                                    Text="Liberar" OnClick="btnLiberarSoftware_Click" Width="100px" />
                            </div>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                    <div style="text-align: center;">
                        <asp:Button ID="btnCancelar" Width="80px" runat="server" Text="Salir" CssClass="ui-corner-all ui-state-default cancel"
                            CausesValidation="false" OnClick="btnCancelar_Click" Height="24px" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Panel runat="server" ID="pnlAux">
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlDetalleAgregarLic" Style="display: none;">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div id="dv" style="overflow: auto; height: 475px; width: 600px; background-color: #FFFFFF;">
                            <div class="CeldaImagenAzul" style="text-align: center; cursor: default;">
                                .: Agregar Licencia de Software :.
                            </div>
                            <br />
                            <div style="text-align: center;">
                                <div style="width: 590px; margin-left: auto; margin-right: auto;">
                                    <asp:GridView ID="gdvSoftware" runat="server" AutoGenerateColumns="False" DataKeyNames="Cve_Asignacion"
                                        Width="590" EmptyDataText="No existe Informacion" AllowPaging="True" OnPageIndexChanging="gdvSoftware_PageIndexChanging"
                                        OnPageIndexChanged="gdvSoftware_PageIndexChanged" PageSize="15">
                                        <HeaderStyle CssClass="Encabezado" ForeColor="White"></HeaderStyle>
                                        <HeaderStyle CssClass="CeldaImagenAzul" HorizontalAlign="Center" />
                                        <PagerSettings Mode="NextPreviousFirstLast" />
                                        <SelectedRowStyle Font-Bold="True" BackColor="#E7D6A9" />
                                        <EmptyDataRowStyle BackColor="#DEDDF3" />
                                        <AlternatingRowStyle BackColor="#DEDDF3" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelecciona" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Nombre Licencia" InsertVisible="False"
                                                ReadOnly="True" SortExpression="Nombre Licencia" />
                                            <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                                            <asp:BoundField DataField="Serial" HeaderText="Key" InsertVisible="False" ReadOnly="True"
                                                SortExpression="Serial" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <br />
                            <div>
                                <div style="width: 300px; float: left; text-align: center;">
                                    <asp:Button ID="btnRegresarLicencia" CssClass="ui-corner-all ui-state-default cancel"
                                        runat="server" Text="Regresar" OnClick="btnRegresarLicencia_Click" />
                                </div>
                                <div style="width: 300px; float: right; text-align: center;">
                                    <asp:Button ID="btnGurdarLicencia" runat="server" CssClass="ui-corner-all ui-state-default cancel"
                                        Text="Guardar" OnClick="btnGurdarLicencia_Click" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpeDetalleAgregarLic" runat="server" TargetControlID="pnlAux"
                PopupControlID="pnlDetalleAgregarLic" BackgroundCssClass="Shadow" Y="50" />
        </div>
    </div>
</asp:Content>
