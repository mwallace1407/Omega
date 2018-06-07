<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="ModificarDiscos.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.ModificarDiscos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 395px;
            height: 395px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 700px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: MODIFICAR INFORMACIÓN DE ALMACENAMIENTO PARA UN SERVIDOR :.
            </div>
            <br />
            Los cambios realizados en esta página se aplican de manera directa.
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Servidor:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlServidor" runat="server" Width="202" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlServidor_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <asp:Panel ID="pnlDiscos" runat="server" Enabled="False">
                    <asp:GridView ID="grdDiscos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False" OnRowDeleting="grdDiscos_RowDeleting" OnSelectedIndexChanged="grdDiscos_RowSelected"
                        OnPageIndexChanging="grdDiscos_PageIndexChanging" AllowPaging="True" PageSize="7">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="XX-Small" />
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Imagenes/Editar.png"
                                CausesValidation="False" ShowSelectButton="True" />
                            <asp:BoundField DataField="SrvD_Unidad" HeaderText="Unidad" />
                            <asp:BoundField DataField="SrvD_Capacidad" HeaderText="Capacidad (MB)" />
                            <asp:BoundField DataField="SrvTA_Descripcion" HeaderText="Tipo Almacenamiento" />
                            <asp:BoundField DataField="SrvUD_Descripcion" HeaderText="Uso de disco" />
                            <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo de Equipo" />
                            <asp:BoundField DataField="NoSerie" HeaderText="No. Serie" />
                            <asp:BoundField DataField="SrvD_Observaciones" HeaderText="Observaciones" HtmlEncode="false" />
                            <asp:BoundField DataField="SrvTA_Id" HeaderText="SrvTA_Id" />
                            <asp:BoundField DataField="SrvUD_Id" HeaderText="SrvUD_Id" />
                            <asp:BoundField DataField="idItem" HeaderText="idItem" />
                            <asp:BoundField DataField="idTipoEquipo" HeaderText="idTipoEquipo" />
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Imagenes/Delete.png"
                                CausesValidation="False" ShowDeleteButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" Font-Size="XX-Small" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="XX-Small" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" Font-Size="XX-Small" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </asp:Panel>
            </div>
            <br />
            <div style="width: 345px; text-align: right;">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar unidad" CssClass="boton"
                    OnClick="btnAgregar_Click" CausesValidation="False" Visible="False" />
                <asp:HiddenField ID="hddAccion" runat="server" />
            </div>
            <br />
            <div style="width: 360px;">
                <!-- ModalPopupExtender -->
                <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlAgregar" TargetControlID="btnFalso"
                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlAgregar" runat="server" Enabled="False" CssClass="modalPopup" align="center"
                    Style="display: none">
                    <div style="border: medium ridge #ffffff; text-align: left; height: 360px; width: 350px;">
                        <br />
                        <div style="width: 345px;">
                            <div style="width: 135px; float: left; text-align: left; padding-left: 5px;">
                                <asp:Label ID="lblUnidadT" runat="server" Text="Agregar Unidad:"></asp:Label>
                            </div>
                            <div style="width: 205px; float: right; text-align: left;">
                                <asp:DropDownList ID="ddlUnidad" runat="server" Width="50">
                                </asp:DropDownList>
                                <asp:Label ID="lblUnidad" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 345px;">
                            <div style="width: 135px; float: left; text-align: left; padding-left: 5px;">
                                Capacidad (En MB):
                            </div>
                            <div style="width: 205px; float: right; text-align: left;">
                                <asp:TextBox ID="txtCapacidad" autocomplete="off" runat="server" Width="50" MaxLength="10"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="ftxt_txtCapacidad" runat="server" Enabled="True"
                                    FilterType="Numbers" TargetControlID="txtCapacidad">
                                </asp:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="rfv_txtCapacidad" runat="server" ErrorMessage="Campo requerido"
                                    Display="None" ControlToValidate="txtCapacidad" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfve_txtCapacidad" runat="server" Enabled="True"
                                    TargetControlID="rfv_txtCapacidad">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 345px;">
                            <div style="width: 135px; float: left; text-align: left; padding-left: 5px;">
                                Tipo almacenamiento:
                            </div>
                            <div style="width: 205px; float: right; text-align: left;">
                                <asp:DropDownList ID="ddlTipoAlmacenamiento" runat="server" Width="202">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddlTipoAlmacenamiento" runat="server" ErrorMessage="Campo requerido"
                                    Display="None" ControlToValidate="ddlTipoAlmacenamiento" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfve_ddlTipoAlmacenamiento" runat="server" Enabled="True"
                                    TargetControlID="rfv_ddlTipoAlmacenamiento">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 345px;">
                            <div style="width: 135px; float: left; text-align: left; padding-left: 5px;">
                                Uso de disco:
                            </div>
                            <div style="width: 205px; float: right; text-align: left;">
                                <asp:DropDownList ID="ddlUsoDisco" runat="server" Width="202">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddlUsoDisco" runat="server" ErrorMessage="Campo requerido"
                                    Display="None" ControlToValidate="ddlUsoDisco" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfve_ddlUsoDisco" runat="server" Enabled="True"
                                    TargetControlID="rfv_ddlUsoDisco">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 345px;">
                            <div style="width: 135px; float: left; text-align: left; padding-left: 5px;">
                                Tipo equipo:
                            </div>
                            <div style="width: 205px; float: right; text-align: left;">
                                <asp:DropDownList ID="ddlTipoEquipo" runat="server" Width="202" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlTipoEquipo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddlTipoEquipo" runat="server" ErrorMessage="Campo requerido"
                                    Display="None" ControlToValidate="ddlTipoEquipo" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfve_ddlTipoEquipo" runat="server" Enabled="True"
                                    TargetControlID="rfv_ddlTipoEquipo">
                                </asp:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 345px;">
                            <div style="width: 135px; float: left; text-align: left; padding-left: 5px;">
                                Equipo asignado:
                            </div>
                            <div style="width: 205px; float: right; text-align: left;">
                                <asp:DropDownList ID="ddlEquipo" runat="server" Width="202">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 345px; height: 100px;">
                            <div style="width: 135px; float: left; text-align: left; padding-left: 5px;">
                                Observaciones:
                            </div>
                            <div style="width: 205px; float: right; text-align: left;">
                                <asp:TextBox ID="txtObservaciones" runat="server" Width="200" MaxLength="500" TextMode="MultiLine"
                                    Height="100" ValidationGroup="General"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="width: 345px; text-align: right;">
                            <asp:Button ID="btnProcesarD" runat="server" Text="Agregar" CssClass="boton" OnClick="btnProcesarD_Click"
                                CausesValidation="False" />&nbsp
                            <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="boton" />
                        </div>
                    </div>
                </asp:Panel>
                <!-- ModalPopupExtender -->
            </div>
        </div>
    </div>
    <div style="display: none">
        <asp:Button ID="btnFalso" runat="server" Text="" Visible="True" /></div>
</asp:Content>