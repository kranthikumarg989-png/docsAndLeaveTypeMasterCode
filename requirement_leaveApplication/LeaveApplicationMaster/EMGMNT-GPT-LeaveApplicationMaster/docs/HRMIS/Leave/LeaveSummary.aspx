<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="LeaveSummary.aspx.vb" Inherits="E_Management.LeaveSummary1" 
    title="LEAVE SUMMARY" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16" style="width: 340px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 124px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 340px; height: 124px" valign="top">
                <table style="width: 471px">
                    <tr>
                        <td class="td_head" colspan="2" style="height: 24px">
                            Leave Summary Report</td>
                    </tr>
                    <tr>
                        <td style="width: 148px; height: 24px; background-color: beige">
                            <asp:Label ID="Label31" runat="server" Text="Report TimeLine" Width="143px"></asp:Label></td>
                        <td style="width: 403px; height: 26px">
                            <asp:TextBox ID="rpttxtfrom" runat="server" Width="87px"></asp:TextBox>
                            ~
                            <asp:TextBox ID="rpttxtto" runat="server" Height="14px" Width="77px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rpttxtto">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="rpttxtfrom"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                        <cc1:calendarextender id="CalendarExtender3" runat="server" cssclass="cal_Theme1"
                            format="dd/MM/yy" popupbuttonid="rpttxtfrom" targetcontrolid="rpttxtfrom"></cc1:calendarextender>
                        <cc1:calendarextender id="CalendarExtender4" runat="server" cssclass="cal_Theme1"
                            format="dd/MM/yy" popupbuttonid="rpttxtto" targetcontrolid="rpttxtto"></cc1:calendarextender>
                    </tr>
                    <tr>
                        <td style="width: 148px; height: 24px; background-color: beige">
                            <asp:Label ID="Label33" runat="server" Text="Select Leave type" Width="143px"></asp:Label></td>
                        <td style="width: 403px; height: 26px">
                            <asp:DropDownList ID="rptddlltype" runat="server">
                                <asp:ListItem Value="-1">- Select Leave type -</asp:ListItem>
                                <asp:ListItem>Annual</asp:ListItem>
                                <asp:ListItem>Calamity</asp:ListItem>
                                <asp:ListItem Value="CompanyHoliday">Company Holiday</asp:ListItem>
                                <asp:ListItem>Compassionate</asp:ListItem>
                                <asp:ListItem Value="Emergency">Emergency - Annual</asp:ListItem>
                                <asp:ListItem Value="EmergencyUP">EmergencyUnpaid</asp:ListItem>
                                <asp:ListItem>Marriage - Children</asp:ListItem>
                                <asp:ListItem>Maternity</asp:ListItem>
                                <asp:ListItem>Medical</asp:ListItem>
                                <asp:ListItem>Paternity</asp:ListItem>
                                <asp:ListItem Value="PlanEmergency">Plan Emergency - Annual</asp:ListItem>
                                <asp:ListItem Value="PlanEmergencyUP">Plan Emergency - Unpaid</asp:ListItem>
                                <asp:ListItem>Unpaid</asp:ListItem>
                                <asp:ListItem Value="Hospitalization">Hospitalization</asp:ListItem>
                                <asp:ListItem Value="marriage-self">Marriage-Self</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="height: 26px">
                            &nbsp;<asp:Button ID="btnrptsummary" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" /></td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 124px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 340px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>

</asp:Content>
