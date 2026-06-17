<%@ Page Language="vb" AutoEventWireup="false" Codebehind="frmPendingPayable.aspx.vb"
    MasterPageFile="~/ems.Master" Inherits="E_Management.frmPendingPayable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <script language="javascript" type="text/javascript">
  function IssuePeningRpt(Dpt)
           {
            PrintPendingRpt= window.open('frmRPTpendingPayable.aspx?Dept='+ Dpt,'PendingRpt','height=600,width=990,scrollbars=yes,resizable=yes');
            if(window.focus)
             {
             PrintPendingRpt.focus();              
             }    
              return false;
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
                <table cellpadding="0" cellspacing="0" style="width: 500px">
                    <tr>
                        <td align ="center">
                            <table cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label8" runat="server" ForeColor="DarkRed" Font-Bold="True" Font-Size="12pt"
                                            Text="Pending Payables" Font-Underline="False"></asp:Label></td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 47px">
                                        Dept
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDept" runat="Server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnSearch" runat="Server" Text="Search" /></td>
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
