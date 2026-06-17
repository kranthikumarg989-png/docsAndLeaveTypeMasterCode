<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PFPallStaff.aspx.vb" Inherits="E_Management.PFPallStaff" 
    title="PFP Allowance Staff" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 16px; width: 3px;">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1111px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px; width: 3px;">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" style="width: 1111px">
                &nbsp;&nbsp;

<table id="TABLE2" style="height: 292px" border="1">
        <tr>
            <td style="height: 52px; width: 666px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="4" style="height: 12px" valign="top" align="left" class="td_head">
                            &nbsp;NOTIFICATION LETTER ON PAY FOR PERFORMANCE ALLOWANCE - STAFF</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 77px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label2" runat="server" Text="Employee No." Width="94px"></asp:Label></td>
                        <td align="left" style="width: 410px; height: 26px" valign="top">
                            <asp:TextBox ID="empcode" runat="server" AutoPostBack="True" Width="173px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="empcode" ErrorMessage="!"></asp:RequiredFieldValidator><%--<asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empcode"
                            ErrorMessage="Code !"></asp:RequiredFieldValidator>--%></td>
                        <td align="left" style="width: 125px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label14" runat="server" Text="Employee Name" Width="113px"></asp:Label></td>
                        <td align="left" style="width: 171px; height: 26px" valign="top">
                            &nbsp;<asp:Label ID="name" runat="server" Width="170px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 77px; height: 11px; background-color: beige" valign="top">
                            <asp:Label ID="Label3" runat="server" Text="Department" Width="69px"></asp:Label></td>
                        <td align="left" style="width: 410px; height: 11px" valign="top">
                            &nbsp;<asp:Label ID="dept" runat="server" Width="175px"></asp:Label>
                        </td>
                        <td align="left" style="width: 125px; height: 11px; background-color: beige" valign="top">
                            <asp:Label ID="Label15" runat="server" ForeColor="Black" Text="Designation" Width="122px"></asp:Label></td>
                        <td align="left" style="width: 171px; height: 11px" valign="top">
                            &nbsp;<asp:Label ID="desig" runat="server" Width="172px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px;" valign="top" align="left" class="td_head" colspan="4">
                            APPOINTMENT DETAILS</td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Effective From</td>
                        <td style="width: 410px" valign="top" align="left">
                            <asp:TextBox ID="eff_frm" runat="server" MaxLength="3" Width="179px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="eff_frm" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                        <td style="background-color: beige; width: 364px;" valign="top" align="left" rowspan="2">
                            Letter Date</td>
                        <td align="left" style="width: 404px" valign="top" rowspan="2">
                            <asp:TextBox ID="letdt" runat="server" Width="191px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R3" runat="server" ControlToValidate="letdt" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 295px; height: 30px; background-color: beige" valign="top">
                            PFP Amount</td>
                        <td align="left" style="width: 410px; height: 30px;" valign="top">
                            <asp:TextBox ID="pfpamt" runat="server" Width="178px"></asp:TextBox></td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="SavePFPstaff" runat="server" Text="SAVE & PRINT" /></td>
        </tr>
    </table>
                <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="letdt" targetcontrolid="letdt">
                                            </cc1:CalendarExtender>
                        <cc1:calendarextender id="effrm" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="eff_frm" targetcontrolid="eff_frm"></cc1:calendarextender>
                &nbsp;&nbsp;
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentcode], [departmentname] FROM [department] ORDER BY [departmentcode], [departmentname]">
                </asp:SqlDataSource>
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 3px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1111px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>
