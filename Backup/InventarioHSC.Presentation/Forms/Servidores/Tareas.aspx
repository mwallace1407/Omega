<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Main.Master" AutoEventWireup="true"
    CodeBehind="Tareas.aspx.cs" Inherits="InventarioHSC.Forms.Servidores.Tareas" %>

<%@ Register Src="~/Forms/Controles/DTP3.ascx" TagPrefix="uc" TagName="DTP3" %>
<%@ Register Src="~/Forms/Controles/DTP2.ascx" TagPrefix="uc" TagName="DTP2" %>
<%@ Register Src="~/Forms/Controles/DTP.ascx" TagPrefix="uc" TagName="DTP" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="../../App_Themes/Estilos/Redmon/jquery-ui-1.7.2.custom.css" type="text/css"
        rel="stylesheet" />
    <link href="../../App_Themes/Estilos/estilo1.css" type="text/css" rel="stylesheet" />
    <%--Calendario--%>
    <link href="../../App_Themes/Estilos/DTP/bootstrap-combined.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../App_Themes/Estilos/DTP/bootstrap-datetimepicker.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap-datetimepicker.pt-BR.js" type="text/javascript"></script>
    <%--Fin Calendario--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
        <div style="width: 1000px; margin-left: auto; margin-right: auto; height: 600px;
            text-align: left;" class="divRoundedOpacity">
            <div style="width: 1000px;" class="divRoundedOpacityTitle">
                Administración de tareas</div>
            <br />
            <div style="padding-left: 10px; width: 320px; float: left; overflow: auto; height: 540px;">
                <asp:HiddenField ID="hddUsuario" runat="server" />
                <div style="width: 310px;">
                    <div style="width: 85px; float: left; text-align: left;">
                        Acción:
                    </div>
                    <div style="width: 225px; float: right; text-align: left;">
                        <asp:DropDownList ID="ddlAccion" runat="server" Width="202" AutoPostBack="True" OnSelectedIndexChanged="ddlAccion_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlAccion" runat="server" ControlToValidate="ddlAccion"
                            Display="None" ErrorMessage="Campo requerido" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfve_ddlAccion" runat="server" Enabled="True" TargetControlID="rfv_ddlAccion">
                        </asp:ValidatorCalloutExtender>
                        <br />
                        <asp:CheckBox ID="chkModoCal" runat="server" Text="Ver horario completo" AutoPostBack="True"
                            OnCheckedChanged="chkModoCal_CheckedChanged" />
                    </div>
                </div>
                <br />
                <br />
                <br />
                <asp:Panel ID="pnlTarea" runat="server" Visible="False" Width="310px">
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Tarea:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlTareas" runat="server" Width="202" AutoPostBack="True" OnSelectedIndexChanged="ddlTareas_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                </asp:Panel>
                <asp:Panel ID="pnlUsuario" runat="server" Visible="False" Width="310px">
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Usuario:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlUsuario" runat="server" Width="202" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" 
                                CssClass="boton" onclick="btnExportar_Click" />
                        </div>
                    </div>
                    <br />
                    <br />
                </asp:Panel>
                <asp:Panel ID="pnlDatos" runat="server" Visible="False" Width="310px">
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Estado:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlEstado" runat="server" Width="202">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Categoría:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <asp:DropDownList ID="ddlCategoria" AutoPostBack="true" runat="server" Width="202"
                                OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <asp:Panel ID="pnlCat" runat="server" Visible="False" Width="310px">
                        Agregar nueva categoría:
                        <br />
                        <asp:TextBox ID="txtNuevaCat" runat="server" MaxLength="50" Width="200px"></asp:TextBox>&nbsp
                        <asp:Button ID="btnNuevaCat" runat="server" Text="Agregar" CssClass="boton" OnClick="btnNuevaCat_Click" />
                        <br />
                        <br />
                    </asp:Panel>
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Fecha inicial:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <uc:DTP runat="server" ID="dtpIni" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Fecha final:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <uc:DTP2 runat="server" ID="dtpFin" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Descripción:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="75" Width="200px" TextMode="MultiLine"
                                Height="50px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div style="width: 310px;">
                        <div style="width: 85px; float: left; text-align: left;">
                            Tarea privada:
                        </div>
                        <div style="width: 225px; float: right; text-align: left;">
                            <asp:CheckBox ID="chkPrivada" runat="server" OnCheckedChanged="chkPrivada_CheckedChanged"
                                AutoPostBack="True" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <asp:Panel ID="pnlInvolucrados" runat="server" Width="310">
                        <div style="width: 305px;">
                            <div style="width: 90px; float: left; text-align: left;">
                                Involucrados:
                            </div>
                            <div style="width: 215px; float: right; text-align: left; height: 100px; overflow: auto;">
                                <asp:CheckBoxList ID="chk_Involucrados" runat="server" Height="100px">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div style="width: 300px; height: 1px; text-align: right; padding-right: 10px;">
                        <asp:Button ID="btnProcesar" runat="server" Text="Registrar tarea" CssClass="boton"
                            Enabled="False" OnClick="btnProcesar_Click" />&nbsp&nbsp
                    </div>
                </asp:Panel>
                <br />
                <br />
            </div>
            <div style="color: #333333; padding-right: 10px; padding-left: 10px; float: right;
                width: 650px; overflow: scroll; height: 540px;">
                <uc:DTP3 runat="server" ID="dtp03" ViewStateMode="Enabled" />
                <asp:Button ID="btnCambiar" runat="server" Text="Cambiar fecha" CssClass="boton"
                    OnClick="btnCambiar_Click" CausesValidation="false" />
                <div style="width: 870px">
                    <DayPilot:DayPilotCalendar ID="cal01" runat="server" TimeFormat="Clock24Hours" BusinessBeginsHour="8"
                        BusinessEndsHour="21" NonBusinessBackColor="#E3E3F9" ShowHeader="True" Font-Size="X-Small"
                        Font-Strikeout="False" CssOnly="False" EventFontSize="7pt" EventBackColor="#FFFFD5"
                        BackColor="White" HourHalfBorderColor="#DADADA" HourBorderColor="#A2A2A2" HourNameBackColor="#CCCCCC"
                        EventBorderColor="#FF6600" DurationBarColor="#FF9933" HeaderDateFormat="dd-MM-yyyy"
                        HideFreeCells="False" BorderColor="#333333" Width="850px" CellHeight="18" Days="7" />
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
