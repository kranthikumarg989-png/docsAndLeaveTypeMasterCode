<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CheckoutPrint.aspx.vb" Inherits="E_Management.CheckoutPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Checkout Memo</title>
    <style type="text/css">
    body {
        font-family: "Source Sans Pro","Helvetica Neue",Helvetica,Arial,sans-serif;
        font-weight: 400;
        font-size:12px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="5" cellspacing="0" border="0" width="100%" style="padding-left:20px;padding-right:20px;">
    <tr>
        <td align="center">
            <table cellpadding="5" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="33%" align="left"><img src="../../images/logo.jpg" alt="Maruwa" /></td><td width="33%" align="center" valign="middle"><b><h1>Checkout Memo</h1></b></td><td width="33%" align="right" valign="middle"><asp:Label ID="lblPrintDate" runat="server"></asp:Label></td>
            </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" CssClass="grid" DataKeyNames="rno" width="100%">
              <Columns>
                <asp:TemplateField HeaderText="S.No.">
                    <ItemTemplate><%#Container.DataItemIndex + 1%></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" />
                <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Section" HeaderText="Section" />
                <asp:BoundField DataField="DateofHire" HeaderText="Hired date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Permitexpiry" HeaderText="Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Yrs" HeaderText="Yrs" />
                <asp:BoundField DataField="arriveddate" HeaderText="Arrival Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="LastWorking" HeaderText="LastWorking Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Payment" HeaderText="Salary Payment Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="SendBack" HeaderText="Send Back Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Replacement" HeaderText="Replacement" />
                <asp:BoundField DataField="HRPurpose" HeaderText="HR Purpose" />
                <asp:TemplateField HeaderText="Sign" ItemStyle-Width="200px">
                    <ItemTemplate></ItemTemplate>
                </asp:TemplateField>
              </Columns>
              </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <table cellpadding="3" cellspacing="0" style="border-style:solid;border-width:1px" rules="all" width="100%">
            <tr>
                <th width="250px" align="center">Prepared By HR</th><th width="250px" align="center">Approved By Plant Manager</th><th width="250px" align="center">Logistic Arrangement by Hostel</th><th width="250px" align="center">Payment by Payroll</th>
            </tr>
            <tr>
                <td height="50px">&nbsp;</td><td></td><td></td><td></td>
            </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td><h3>Acknowledge By</h3></td>
    </tr>
    <tr>
        <td>
            <table cellpadding="3" cellspacing="0" style="border-style:solid;border-width:1px" rules="all" width="100%">
            <tr>
                <th width="200px" align="center">Substrate</th><th width="200px" align="center">TPH</th><th width="200px" align="center">CV</th><th width="200px" align="center">Fmagnet</th><th width="200px" align="center">Fsheet</th><th width="200px" align="center">Others</th>
            </tr>
            <tr>
                <td height="50px">&nbsp;</td><td></td><td></td><td></td><td></td><td></td>
            </tr>
            </table>
        </td>
    </tr>
    </table>
    </form>
</body>
<script type="text/javascript">
    window.print();
</script>
</html>
