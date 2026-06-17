<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="StockReport.aspx.vb" Inherits="E_Management.StockReport1" %>

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
            <td background="../../../images/cen_lef.gif" width="16">
                <img height="11" src="../../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" align="center">
                <table cellpadding="0" cellspacing="0" style="width: 500px">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="border-left-color: #33ffff; border-bottom-color: #33ffff; border-top-color: #33ffff;
                                        height: 24px; background-color: #507cd1; border-right-color: #33ffff" align="center">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="Stock Report"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td >
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                                    <asp:RadioButtonList ID="rbSearchList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="D">By Department</asp:ListItem>
                                                        <asp:ListItem Value="I">By Item</asp:ListItem>
                                                        <asp:ListItem Selected="True">All</asp:ListItem>
                                                    </asp:RadioButtonList><table runat="server" cellpadding="0" cellspacing="0" style="width: 100%" id="TbDepartment">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td runat="server" id="TDEmployee">
                                                    <table cellpadding="0" cellspacing="0" style="width: 70%" runat="server" id="TdDepartment">
                                                        <tr>
                                                            <td style="width: 30%; height: 24px; background-color: #f5f8f1">
                                                                <asp:Label ID="Label4" runat="server" Text="Department" Width="100%"></asp:Label></td>
                                                            <td style="width: 70%; height: 24px; background-color: #f5f8f1" align="left" colspan="2">
                                                                <asp:DropDownList ID="ddlDepartment" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                    ToolTip="Department" Width="200px">
                                                                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                                        <tr>
                                                            <td runat="server">
                                                                <table cellpadding="0" cellspacing="0" style="width: 70%" runat="server" id="TdItem">
                                                                    <tr>
                                                                        <td style="width: 30%; height: 24px; background-color: #f5f8f1">
                                                                            <asp:Label ID="Label3" runat="server" Text="Item" Width="100%"></asp:Label></td>
                                                                        <td align="left" colspan="3" style="width: 70%; height: 24px; background-color: #f5f8f1">
                                                                            <asp:DropDownList ID="ddlItem" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                    ToolTip="Item" Width="200px">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td align="left" colspan="5" style="height: 24px; background-color: #f5f8f1">
                                                                <asp:Label ID="lblMsg" runat="server" Width="100%" ForeColor="Red"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
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
                                <tr>
                                    <td align="center">
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
