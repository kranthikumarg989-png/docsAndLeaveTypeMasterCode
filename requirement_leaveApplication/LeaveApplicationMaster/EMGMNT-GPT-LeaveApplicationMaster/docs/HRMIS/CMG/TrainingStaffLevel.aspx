<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TrainingStaffLevel.aspx.vb" Inherits="E_Management.TrainingStaffLevel" 
    title="Training Staff Level" %>
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
            <td style="height: 217px; width: 666px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="4" style="height: 12px" valign="top" align="left" class="td_head">
                            TRAINING STAFF LEVEL</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 26px; background-color: beige" valign="top">
                            EMPLOYEE DETAILS</td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Employee Name</td>
                        <td style="width: 305px;" valign="top" align="left">
                    
                        <asp:TextBox ID="empname" runat="server" Width="181px" AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empname"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                        </td><td style="width: 364px; background-color: beige;" valign="top" align="left">
                            Position</td>
                        <td align="left" style="width: 404px;" valign="top">
                            <asp:DropDownList ID="desig" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                DataTextField="designation" DataValueField="designation" Width="184px" AppendDataBoundItems="True">
                                <asp:ListItem Value="-">---Select---</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="V2" runat="server" ControlToValidate="desig" ErrorMessage="!" InitialValue="-"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Department</td>
                        <td style="width: 305px;" valign="top" align="left">
                            <asp:DropDownList ID="dept" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                                DataTextField="departmentcode" DataValueField="departmentcode" Width="188px" AppendDataBoundItems="True">
                                <asp:ListItem Value="-">---Select---</asp:ListItem>
                            </asp:DropDownList>&nbsp;
                            <asp:RequiredFieldValidator ID="V3" runat="server" ControlToValidate="dept" ErrorMessage="!" InitialValue="-"></asp:RequiredFieldValidator></td><td style="width: 364px; background-color: beige;" valign="top" align="left">
                            IC No.</td>
                        <td align="left" style="width: 404px;" valign="top">
                            <asp:TextBox ID="icno" runat="server" Width="176px">-</asp:TextBox>&nbsp;
                            <%--<asp:RequiredFieldValidator ID="V4" runat="server" ControlToValidate="icno" ErrorMessage="!"></asp:RequiredFieldValidator>--%></td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            From</td>
                        <td style="width: 305px;" valign="top" align="left">
                            <asp:TextBox ID="eff_frm" runat="server" MaxLength="3" Width="184px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="V5" runat="server" ControlToValidate="eff_frm" ErrorMessage="!"></asp:RequiredFieldValidator></td><td style="width: 364px; background-color: beige;" valign="top" align="left">
                            To</td>
                        <td align="left" style="width: 404px;" valign="top">
                            <asp:TextBox ID="eff_to" runat="server" Width="176px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="V6" runat="server" ControlToValidate="eff_to" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Date of Issue</td>
                        <td style="width: 305px;" valign="top" align="left">
                            <asp:TextBox ID="letdt" runat="server" Width="184px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="V7" runat="server" ControlToValidate="letdt" ErrorMessage="!"></asp:RequiredFieldValidator></td><td style="background-color: beige; width: 364px;" valign="top" align="left">
                        </td>
                        <td align="left" style="width: 404px;" valign="top">
                        </td>
                    </tr>
                </table>
                <asp:Label ID="labelmsg" runat="server"></asp:Label><br />
                <asp:Button ID="Savetrstaff" runat="server" Text="SAVE & PRINT" /></td>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [designation] FROM [empmaster] ORDER BY [designation]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentcode] FROM [empmaster] ORDER BY [departmentcode]">
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
