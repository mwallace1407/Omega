<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uscMsgBox.ascx.cs" Inherits="YaBu.MessageBox.uscMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .mpBg
    {
        background-color: #000000;
        filter: alpha(opacity=30);
        opacity: 0.3;
    }
    .mp
    {
        background-color: white;
        border-width: 3px;
        border-style: solid;
        border-color: Gray;
        padding: 3px;
    }
    .mpHd
    {
        background-color: #797979;
        border-color: White;
        border-width: 1px;
        color: White;
        font-weight: bold;
        width: 100%;
        height: 16px;
    }
    .mpClose
    {
        text-align: center;
        width: 100%;
    }
    .mpCloseButton
    {
        position: absolute;
        right: 4px;
        width: 17px;
        height: 18px;
    }
</style>
<asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <asp:Button ID="btnD" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Button ID="btnD2" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Panel ID="pnlMsg" runat="server" CssClass="mp" Style="display: none" Width="550px">
            <asp:Panel ID="pnlMsgHD" runat="server" CssClass="mpHd" HorizontalAlign="Center">
                Mensaje
            </asp:Panel>
            <asp:GridView ID="grvMsg" runat="server" ShowHeader="false" Width="100%" 
                AutoGenerateColumns="false" BorderWidth="0px">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgErr" runat="server" ImageUrl="~/App_Themes/Imagenes/err.png" Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Error) ? true : false %>' />
                                        <asp:Image ID="imgSuc" runat="server" ImageUrl="~/App_Themes/Imagenes/suc.png" Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Success) ? true : false %>' />
                                        <asp:Image ID="imgAtt" runat="server" ImageUrl="~/App_Themes/Imagenes/att.png" Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Attention) ? true : false %>' />
                                        <asp:Image ID="imgInf" runat="server" ImageUrl="~/App_Themes/Imagenes/inf.png" Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Info) ? true : false %>' />
                                    </td>
                                    <td>
                                        <%# Eval("MessageText")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="mpClose">
                <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" CausesValidation="false" Width="60px" />
                <asp:Button ID="btnPostOK" runat="server" Text="OK" CausesValidation="false" OnClick="btnPostOK_Click"
                    Visible="false" Width="60px" />
                <asp:Button ID="btnPostCancel" runat="server" Text="Cancel" CausesValidation="false"
                    OnClick="btnPostCancel_Click" Visible="false" Width="60px" />
            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpeMsg" runat="server" TargetControlID="btnD" PopupControlID="pnlMsg"
            PopupDragHandleControlID="pnlMsgHD" BackgroundCssClass="mpBg" DropShadow="true"
            OkControlID="btnOK">
        </asp:ModalPopupExtender>
    </ContentTemplate>
</asp:UpdatePanel>
