<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="checkOutPrintNew.aspx.vb" Inherits="E_Management.checkOutPrintNew"  MasterPageFile="~/ems.Master" title="-" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <table cellpadding="5" cellspacing="0" border="0" width="100%" style="padding-left:20px;padding-right:20px;">
                <tr><td align="center">CheckOut Date</td></tr>
       <tr>
        <td align="center">
            <asp:TextBox runat="server" CssClass="datepicker" ID="txtdatepicker"></asp:TextBox>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnSubmit" />
        </td>
      </tr>
                <tr><td align="center" id="batchname" runat="server">Batch No</td></tr>
        <tr>
        <td align="center">
            <asp:DropDownList ID="ddlbatchno" runat="server" CssClass= "form-control" AutoPostBack="true" Width="128px" Height="22px"></asp:DropDownList>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Print" ID="btnPrint" Height="26px" Width="61px" />
        </td>
       </tr>
</table>
   
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $('.numberonly').keyup(function (e) {
            var rgx = /^\-?[0-9]*\.?[0-9]*$/;
            this.value =  this.value.match(rgx);
        });

    </script>
    <script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("input:text").blur(function () {
            $(this).val($.trim($(this).val()));
        });

        $(function () {
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>    </asp:Content>
