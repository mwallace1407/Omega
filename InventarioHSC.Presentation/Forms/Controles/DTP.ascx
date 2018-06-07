<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DTP.ascx.cs" Inherits="InventarioHSC.Forms.Controles.DTP" %>
<style type="text/css">
    .textBoxDTP
    {
        width: 157px;
        border-radius: 4px 4px 4px 4px;
        color: #555555;
        display: inline-block;
        font-size: 14px;
        height: 20px;
        line-height: 20px;
        margin-bottom: 10px;
        padding: 4px 6px;
        vertical-align: middle;
        background-color: #FFFFFF;
        border: 1px solid #CCCCCC;
        box-shadow: 0 1px 1px rgba(0, 0, 0, 0.075) inset;
        transition: border 0.2s linear 0s, box-shadow 0.2s linear 0s;
        font-family: Helvetica Neue,Helvetica,Arial,sans-serif;
    }
</style>
<script type="text/javascript">
    function getDateTimePicker() {
        $('#datetimepicker').DateTimePickerNew({
            format: 'dd/MM/yyyy hh:mm',
            language: 'es',
            weekStart: 1
        });
    }
</script>
<div id="datetimepicker" class="input-append date" style="width: 205px;">
    <asp:TextBox ID="txtDateTime" CssClass="textBoxDTP" runat="server"></asp:TextBox>
    <span class="add-on"><i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
    </span>
</div>
<script type="text/javascript">
    $('#datetimepicker').DateTimePickerNew({
        format: 'dd/MM/yyyy hh:mm',
        language: 'es',
        weekStart: 1
    });
</script>