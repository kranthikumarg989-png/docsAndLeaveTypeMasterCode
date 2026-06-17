<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ApptForBurmese.aspx.vb" Inherits="E_Management.ApptForBurmese" 
    title="Appointment Letter For Burmese" %>
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
            <td style="height: 335px; width: 666px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="4" style="height: 12px" valign="top" align="left" class="td_head">
                            &nbsp;APPOINTMENT LETTER FOR BURMESE</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="height: 26px; background-color: beige" valign="top">
                            EMPLOYEE DETAILS</td>
                        <td align="left" colspan="2" style="height: 26px; background-color: beige" valign="top">
                            WITNESS DETAILS</td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Employee No.</td>
                        <td style="width: 305px;" valign="top" align="left">
                    
                        <asp:TextBox ID="empno" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empno"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                        </td><td style="width: 364px; background-color: beige;" valign="top" align="left">
                            Employee Code</td>
                        <td align="left" style="width: 404px;" valign="top">
                            <asp:TextBox ID="wempno" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="V2" runat="server" ControlToValidate="wempno" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            &nbsp;Department</td>
                        <td style="width: 305px;" valign="top" align="left">
                            <asp:Label ID="dept" runat="server"></asp:Label></td><td style="width: 364px; background-color: beige;" valign="top" align="left">
                            Employee Name</td>
                        <td align="left" style="width: 404px;" valign="top">
                            <asp:Label ID="wempname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Employee Name</td>
                        <td style="width: 305px;" valign="top" align="left">
                            <asp:Label ID="empname" runat="server"></asp:Label></td><td style="width: 364px; background-color: beige;" valign="top" align="left">
                            Designation</td>
                        <td align="left" style="width: 404px;" valign="top">
                            <asp:Label ID="wdesig" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Passport No.</td>
                        <td style="width: 305px;" valign="top" align="left">
                            <asp:Label ID="ppno" runat="server"></asp:Label></td><td style="background-color: beige; width: 364px;" valign="top" align="left">
                        </td>
                        <td align="left" style="width: 404px;" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 30px;" valign="top" align="left">
                            Section Code</td>
                        <td style="width: 305px; height: 30px;" valign="top" align="left">
                            <asp:Label ID="sect" runat="server"></asp:Label></td>
                        <td style="background-color: beige; width: 364px; height: 30px;" valign="top" align="left">
                        </td>
                        <td align="left" style="width: 404px; height: 30px;" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px;" valign="top" align="left" class="td_head" colspan="4">
                            APPOINTMENT DETAILS</td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Effective From</td>
                        <td style="width: 305px" valign="top" align="left">
                            <asp:TextBox ID="eff_frm" runat="server" MaxLength="3" Width="179px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="R5" runat="server" ControlToValidate="eff_frm"
                                ErrorMessage="!"></asp:RequiredFieldValidator></td>
                        <td style="background-color: beige; width: 364px;" valign="top" align="left">
                            Letter Date</td>
                        <td align="left" style="width: 404px" valign="top">
                            <asp:TextBox ID="letdt" runat="server" Width="191px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R8" runat="server" ControlToValidate="letdt" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 295px; height: 28px; background-color: beige" valign="top">
                            Effective To</td>
                        <td align="left" style="width: 305px" valign="top">
                            <asp:TextBox ID="eff_to" runat="server" Width="181px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R6" runat="server" ControlToValidate="eff_to" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                        <td align="left" style="background-color: beige; width: 364px;" valign="top">
                        </td>
                        <td align="left" style="width: 404px" valign="top">
                        </td>
                    </tr>
                </table>
                <asp:Label ID="labelmsg" runat="server"></asp:Label><br />
                <asp:Button ID="Saveaptburma" runat="server" Text="SAVE & PRINT" /></td>
        </tr>
    </table>
                <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="letdt" targetcontrolid="letdt">
                                            </cc1:CalendarExtender>
                        <cc1:calendarextender id="effrm" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="eff_frm" targetcontrolid="eff_frm"></cc1:calendarextender>
                <cc1:calendarextender id="effto" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="eff_to" targetcontrolid="eff_to">
                </cc1:CalendarExtender>
    
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