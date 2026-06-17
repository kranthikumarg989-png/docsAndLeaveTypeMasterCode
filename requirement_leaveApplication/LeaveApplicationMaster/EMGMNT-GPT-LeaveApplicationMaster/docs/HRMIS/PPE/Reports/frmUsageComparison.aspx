<%@ Page Language="vb" AutoEventWireup="false" Codebehind="frmUsageComparison.aspx.vb"
    MasterPageFile="~/ems.Master" Inherits="E_Management.frmUsageComparison" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <script language="javascript" type="text/javascript">
  function CompareRpt(Fdt,Tdt)
           {
//           alert("wel");
//           alert(Issueno);
            PrintCompareRpt= window.open('frmRptUsageComparision.aspx?FDt='+Fdt+"&TDt="+ Tdt,'CompareRpt','height=600,width=990,scrollbars=yes,resizable=yes');
            if(window.focus)
             {
             PrintCompareRpt.focus();              
             }    
              return false;
           }   
           
function validatedate() 
{ 
if (event.keyCode >= 48 && event.keyCode <= 57 || event.keyCode==32) 
  event.returnValue = false;
else
event.returnValue=false;
}

    </script>

    <table cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td width="16">
                <img height="16" src="../../../images/top_lef.gif" width="16" /></td>
            <td background="../../../images/top_mid.gif" height="16" style="width: 447px">
                <img height="16" src="../../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../../images/cen_lef.gif" width="16" style="height: 100px">
                <img height="11" src="../../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 100px">
                <table cellpadding="0" cellspacing="0" style="width: 700px">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="4" style="height: 19px">
                                        <asp:Label ID="Label8" runat="server" ForeColor="DarkRed" Font-Bold="True" Font-Size="12pt"
                                            Text="Received By Emp Summary" Font-Underline="False"></asp:Label></td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 81px">
                                        From Date
                                    </td>
                                    <td style="width: 175px">
                                        <asp:TextBox ID="txtFromDt" runat="server"  onkeypress="return validatedate();"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvFDt" runat="server" ControlToValidate="txtFromDt"
                                            ValidationGroup="val" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <cc1:CalendarExtender ID="cetxtFromDt" runat="server" TargetControlID="txtFromDt"
                                            PopupButtonID="txtFromDt">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td style="width: 79px">
                                        To Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToDt" runat="server"  onkeypress="return validatedate();"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvToDt" runat="server" ControlToValidate="txtToDt"
                                            ValidationGroup="val" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <cc1:CalendarExtender ID="cetxtToDt" runat="server" TargetControlID="txtToDt" PopupButtonID="txtToDt">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnSearch" runat="Server" Text="Search" ValidationGroup ="val" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../../images/cen_rig.gif" style="width: 24px; height: 100px;">
                <img height="11" src="../../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../../images/bot_lef.gif" width="16" /></td>
            <td background="../../../images/bot_mid.gif" height="16" style="width: 447px">
                <img height="16" src="../../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
