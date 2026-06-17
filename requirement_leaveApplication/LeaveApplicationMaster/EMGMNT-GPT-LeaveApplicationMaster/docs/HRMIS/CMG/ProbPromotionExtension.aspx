<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ProbPromotionExtension.aspx.vb" Inherits="E_Management.ProbPromotionExtension" 
    title="Letter For Unsuccessful Promotion Probationary Period" %>
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

<table id="TABLE2" style="height: 292px" border="1">
        <tr>
            <td style="height: 297px; width: 518px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2" style="height: 12px" valign="top" align="left" class="td_head">
                            &nbsp;LETTER FOR UNSUCCESSFUL PROMOTION PROBATIONARY PERIOD<br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 183px; background-color: beige; height: 28px;" valign="top" align="left">
                            Employee No.</td>
                        <td style="width: 398px;" valign="top" align="left" colspan="1">
                    
                        <asp:TextBox ID="empno" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empno"
                                    ErrorMessage="!" Width="1px"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 183px; background-color: beige; height: 28px;" valign="top" align="left">
                            Employee Name</td>
                        <td style="width: 398px;" valign="top" align="left" colspan="1">
                            <asp:Label ID="empname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 183px; background-color: beige; height: 28px;" valign="top" align="left">
                            Department</td>
                        <td style="width: 398px;" valign="top" align="left" colspan="1">
                            <asp:Label ID="dept" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 183px; background-color: beige; height: 28px;" valign="top" align="left">
                            Designation</td>
                        <td style="width: 398px;" valign="top" align="left" colspan="1">
                            <asp:Label ID="desig" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 183px; background-color: beige; height: 30px;" valign="top" align="left">
                            Letter Date</td>
                        <td style="width: 398px;" valign="top" align="left" colspan="1">
                            <asp:TextBox ID="letdt" runat="server" Width="182px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="V3" runat="server" ControlToValidate="letdt" ErrorMessage="!"
                                Width="1px"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 183px; background-color: beige; height: 26px;" valign="top" align="left">
                            No.of Months</td>
                        <td style="width: 398px; height: 26px;" valign="top" align="left">
                            <asp:TextBox ID="months" runat="server" Width="183px"></asp:TextBox>&nbsp;
                            <asp:RegularExpressionValidator ID="V2" runat="server" ControlToValidate="months"
                                ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="117px"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 183px; height: 28px; background-color: beige" valign="top">
                            Probation Period Listed</td>
                        <td align="left" style="width: 398px" valign="top">
                            <asp:TextBox ID="probperiod" runat="server" TextMode="MultiLine" Width="253px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="V4" runat="server" ControlToValidate="probperiod"
                                ErrorMessage="!" Width="1px"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                <asp:Label ID="labelmsg" runat="server"></asp:Label><br />
                <asp:Button ID="Saveprobext" runat="server" Text="SAVE & PRINT" /></td>
        </tr>
    </table>
                <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="letdt" targetcontrolid="letdt">
                                            </cc1:CalendarExtender>
                &nbsp;&nbsp;
    
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
