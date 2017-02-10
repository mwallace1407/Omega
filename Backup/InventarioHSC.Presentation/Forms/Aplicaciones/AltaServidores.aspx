<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="AltaServidores.aspx.cs" Inherits="InventarioHSC.Forms.Aplicaciones.AltaServidores"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Forms/Controles/uscMsgBox.ascx" TagPrefix="uc1" TagName="uscMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div id="contenidoLogueado2" runat="server" style="height: 900px">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="MainDiv">
            <div class="CeldaImagenAzul">
                .: ALTA DE SERVIDORES PARA APLICACIONES :.
            </div>
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Equipo fisico:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlEquipo" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlEquipo" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlEquipo" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlEquipo" runat="server" Enabled="True" TargetControlID="rfv_ddlEquipo">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Sistema Operativo:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlSO" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlSO" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlSO" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlSO" runat="server" Enabled="True" TargetControlID="rfv_ddlSO">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Equipo Virtualizado:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlEsVirtual" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlEsVirtual" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlEsVirtual" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlEsVirtual" runat="server" Enabled="True"
                        TargetControlID="rfv_ddlEsVirtual">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Tipo:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlTipo" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlTipo" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlTipo" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlTipo" runat="server" Enabled="True" TargetControlID="rfv_ddlTipo">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Estado:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:DropDownList ID="ddlEstado" runat="server" Width="202">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_ddlEstado" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="ddlEstado" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_ddlEstado" runat="server" Enabled="True" TargetControlID="rfv_ddlEstado">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Nombre de equipo:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtNombreEquipo" runat="server" Width="200" MaxLength="50" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_txtNombreEquipo" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="txtNombreEquipo" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_txtNombreEquipo" runat="server" Enabled="True"
                        TargetControlID="rfv_txtNombreEquipo">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Dirección IP:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtIP" runat="server" Width="200" MaxLength="39" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_txtIP" runat="server" ErrorMessage="Campo requerido"
                        Display="None" ControlToValidate="txtIP" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="rfve_txtIP" runat="server" Enabled="True" TargetControlID="rfv_txtIP">
                    </asp:ValidatorCalloutExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    RAM (En MB):
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtRAM" runat="server" Width="200" MaxLength="10" autocomplete="off"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="ftxt_txtRAM" runat="server" Enabled="True" FilterType="Numbers"
                            TargetControlID="txtRAM">
                        </asp:FilteredTextBoxExtender>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Llave de Windows:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtLlave" runat="server" Width="200" MaxLength="30" autocomplete="off"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 410px; height: 100px;">
                <div style="width: 125px; float: left; text-align: left;">
                    Observaciones:
                </div>
                <div style="width: 275px; float: right; text-align: left;">
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="200" MaxLength="1000" TextMode="MultiLine" Height="100"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div style="border: medium ridge #ffffff; width: 410px;">
                <asp:Panel ID="pnlDiscos" runat="server" DefaultButton="btnProcesarD">
                    Ingrese las unidades de almacenamiento del equipo.
                    <br />
                    <br />
                    <div style="height: 30px; background-color: rgba(73,114,158,0.5); text-align: left;">
                        Unidad:
                        <asp:DropDownList ID="ddlUnidad" runat="server" Width="50" AutoPostBack="True" OnSelectedIndexChanged="ddlUnidad_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp&nbsp&nbsp&nbsp Capacidad (En MB):
                        <asp:TextBox ID="txtCapacidad" autocomplete="off" runat="server" Width="50" MaxLength="10"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftxt_txtCapacidad" runat="server" Enabled="True"
                                FilterType="Numbers" TargetControlID="txtCapacidad">
                            </asp:FilteredTextBoxExtender>
                        &nbsp&nbsp&nbsp&nbsp
                        <asp:Button ID="btnProcesarD" runat="server" Text="Agregar" CssClass="boton" OnClick="btnProcesarD_Click"
                            CausesValidation="False" />
                    </div>
                    <br />
                    <asp:GridView ID="grdDiscos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False" OnRowDeleting="grdDiscos_RowDeleting" OnPageIndexChanging="grdDiscos_PageIndexChanging"
                        AllowPaging="True" PageSize="7">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="XX-Small" />
                        <Columns>
                            <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                            <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
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
                <uc1:uscMsgBox ID="MsgBoxU" runat="server" />
            </div>
            <br />
            <br />
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="boton" OnClick="btnProcesar_Click" />
        </div>
    </div>
</asp:Content>
