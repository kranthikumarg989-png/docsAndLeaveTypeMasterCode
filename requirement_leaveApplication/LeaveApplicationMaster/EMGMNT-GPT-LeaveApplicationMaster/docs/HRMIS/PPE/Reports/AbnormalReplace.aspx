<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="AbnormalReplace.aspx.vb" Inherits="E_Management.AbnormalReplace1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
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
                            <table cellspacing="0" cellpadding="0" style="width: 286px">
                                <tr>
                                    <td colspan="2" style="height: 30px">
                                        <asp:Label ID="Label8" runat="server" ForeColor="DarkRed" Font-Bold="True" Font-Size="12pt"
                                            Text="Abnormal Report" Font-Underline="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 30px" valign="middle">
                                        <asp:RadioButtonList ID="rbAbnormal" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="AR" Selected="True">Abnormal Replace</asp:ListItem>
                                            <asp:ListItem Value="AL">Abnormal Lifespan</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 112px; height: 30px;">
                                        Employee Id&nbsp;</td>
                                    <td style="height: 30px" align="left">
                                        &nbsp;<asp:TextBox ID="txtEmp" runat="server" ToolTip="Employee Code"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 112px; height: 36px">
                                    </td>
                                    <td align="left" style="height: 36px" valign="bottom">
                                        <asp:Button ID="btnSearch" runat="Server" Text="Search" /></td>
                                </tr>
                                <tr height="5">
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
