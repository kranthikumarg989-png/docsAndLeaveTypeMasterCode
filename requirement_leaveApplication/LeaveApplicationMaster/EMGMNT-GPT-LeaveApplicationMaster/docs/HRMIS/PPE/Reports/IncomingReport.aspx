<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="IncomingReport.aspx.vb" Inherits="E_Management.IncomingReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
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
            <td background="../../../images/cen_lef.gif" width="16">
                <img height="11" src="../../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" align="center">
                <table cellpadding="0" cellspacing="0" style="width: 600px">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="border-left-color: #33ffff; border-bottom-color: #33ffff; border-top-color: #33ffff;
                                        height: 24px; background-color: #507cd1; border-right-color: #33ffff" align="center">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="Incoming Report"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td >
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                                    <asp:RadioButtonList ID="rbSearchList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                                        <asp:ListItem>By Department</asp:ListItem>
                                                        <asp:ListItem Selected="True">All</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 20%; height: 24px; background-color: #f5f8f1">
                                                                <asp:Label ID="Label2" runat="server" Text="Req Date"></asp:Label></td>
                                                            <td style="width: 40%; height: 24px; background-color: #f5f8f1">
                                                                <asp:TextBox ID="txtFrom" runat="server" Font-Bold="True" Font-Size="X-Small" ToolTip="From Date"
                                                                    Width="195px"></asp:TextBox></td>
                                                            <td align="left" colspan="2" style="width: 40%; height: 24px; background-color: #f5f8f1">
                                                                <asp:TextBox ID="txtTo" runat="server" Font-Bold="True" Font-Size="X-Small" ToolTip="To Date"
                                                                    Width="200px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFrom"
                                                        WatermarkText="From Date">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtFrom"
                                                        TargetControlID="txtFrom">
                                                    </cc1:CalendarExtender>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtTo"
                                                        WatermarkText="To Date">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtTo"
                                                        TargetControlID="txtTo">
                                                    </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 19px; background-color: #f5f8f1">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                                    <table runat="server" cellpadding="0" cellspacing="0" style="width: 100%" id="TbDepartment">
                                                        <tr>
                                                            <td style="width: 20%; height: 24px; background-color: #f5f8f1">
                                                                <asp:Label ID="Label4" runat="server" Text="Department" Width="100%"></asp:Label></td>
                                                            <td style="width: 40%; height: 24px; background-color: #f5f8f1">
                                                                <asp:DropDownList ID="ddlDepartment" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                    ToolTip="Emp Name" Width="200px">
                                                                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" colspan="2" style="width: 40%; height: 24px; background-color: #f5f8f1">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="height: 19px; background-color: #f5f8f1">
                                                            </td>
                                                        </tr>
                                                    </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 100px">
                                                                <asp:Button ID="btnReset" runat="server" Text="Reset" /></td>
                                                <td style="width: 100px">
                                                                <asp:Button ID="btnSearch" runat="server" Text="View Report" ToolTip="View Report" /></td>
                                            </tr>
                                        </table>
                                    </td>
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
