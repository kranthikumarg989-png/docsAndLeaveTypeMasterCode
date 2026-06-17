<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ApptLetterPartTimeEmp.aspx.vb" Inherits="E_Management.ApptLetterPartTimeEmp" 
    title="Appointment Letter For Part Time Employees" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px; height: 16px;">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 372px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 372px" valign="top">
                <table>
                    <tr>
                        <td colspan="2" style="width: 386px; border-bottom: 2px solid; height: 156px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        Appointment Letter For Part Time Employees</td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 26px; background-color: beige">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Name"></asp:Label></td>
                                    <td style="width: 575px; height: 26px">
                                        <asp:TextBox ID="name" runat="server" Width="254px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="name" ErrorMessage="!"
                                            Width="8px"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 562px; height: 26px; background-color: beige">
                                        <asp:Label ID="LABEL10" runat="server" Font-Bold="False" Text="ICNO"></asp:Label></td>
                                    <td style="width: 575px; height: 26px">
                                        <asp:TextBox ID="icno" runat="server" Width="254px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                            ID="V2" runat="server" ControlToValidate="icno" ErrorMessage="!" Width="8px"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 26px; background-color: beige">
                                        <asp:Label ID="Label26" runat="server" Text="Date of Join" Width="81px" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 26px">
                                        <asp:TextBox ID="doj" runat="server" Width="254px"></asp:TextBox><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="doj"
                                    ErrorMessage="!" Width="8px"></asp:RequiredFieldValidator>
                                        </td>
                                   
                                   
                                   
                                </tr>
                                <tr>
                                    <td style="width: 277px; height: 22px; background-color: beige">
                                        <asp:Label ID="lbldeptr" runat="server" Text="Date of Issue" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 22px">
                                        <asp:TextBox ID="doi" runat="server" Height="14px" Width="254px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="doi"
                                    ErrorMessage="!" Width="1px"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="labelmsg" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px; text-align: center;">
                                        &nbsp;<asp:Button ID="showaptpart" runat="server" SkinID="buttonskin1" Text="SAVE & PRINT" />
                                    </td>
                                </tr>
                            </table>
                            &nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT DISTINCT [departmentcode] FROM [empmaster] ORDER BY [departmentcode]">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="Sqlsecdept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept">
                    </asp:SqlDataSource>
                </table>
                                         
                                         <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="doj" targetcontrolid="doj"></cc1:calendarextender>
                                         <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                        popupbuttonid="doi" targetcontrolid="doi"></cc1:calendarextender>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 372px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        
    </table>
</asp:Content>