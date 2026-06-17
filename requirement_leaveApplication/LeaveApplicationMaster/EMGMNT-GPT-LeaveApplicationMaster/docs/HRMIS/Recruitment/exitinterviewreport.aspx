<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="exitinterviewreport.aspx.vb" Inherits="E_Management.exitinterviewreport" 
    title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 372px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 372px" valign="top">
                <table>
                    <tr>
                        <td colspan="2" style="height: 136px" >
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2">
                                        <strong>EXIT INTERVIEW REPORTS</strong></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        &nbsp;Empcode&nbsp;</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:TextBox ID="empcode" runat="server" Width="87px"></asp:TextBox>
                                        <asp:CheckBox ID="cb1" runat="server" AutoPostBack="True" Text="By using Emp No" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label26" runat="server" Text="Report TimeLine" Width="143px"></asp:Label></td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:TextBox ID="txtfrom" runat="server" Width="87px"></asp:TextBox>
                                        ~
                                        <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"></asp:TextBox>&nbsp;
                                    </td>
                                    <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                    <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="showrepOT" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                         </td>
                    </tr>
                  
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 372px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
