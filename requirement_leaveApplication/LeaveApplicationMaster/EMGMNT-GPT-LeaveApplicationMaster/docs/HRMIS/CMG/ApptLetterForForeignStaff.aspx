<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ApptLetterForForeignStaff.aspx.vb" Inherits="E_Management.ApptLetterForForeignStaff" 
    title="Appointment Letter For Foreign Staff" %>
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
                        <td colspan="2" style="width: 384px; border-bottom: 2px solid; height: 156px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="3" style="height: 24px;">
                                        Printing
                                        Appointment Letters</td>
                                </tr>
                                <tr>
                                    <td style="width: 185px; height: 26px; background-color: beige" colspan="2">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Employee No."></asp:Label>&nbsp;</td>
                                    <td style="width: 285px; height: 26px">
                                        <asp:TextBox ID="empcode" runat="server" Width="150px" AutoPostBack="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empcode" ErrorMessage="!"
                                            Width="8px"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 185px; height: 26px; background-color: beige" colspan="2">
                                        <asp:Label ID="LABEL10" runat="server" Font-Bold="False" Text="Employee Name" Width="109px"></asp:Label>&nbsp;
                                    </td>
                                    <td style="width: 285px; height: 26px">
                                        &nbsp;<asp:Label ID="empname" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 185px; height: 26px; background-color: beige" colspan="2">
                                        <asp:Label ID="Label26" runat="server" Text="Department" Width="81px" Font-Bold="False"></asp:Label><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>&nbsp;
                                    </td>
                                    <td style="width: 285px; height: 26px">
                                        &nbsp;<asp:Label ID="dept" runat="server"></asp:Label></td>
                                   
                                   
                                   
                                </tr>
                                <tr>
                                    <td style="width: 185px; height: 22px; background-color: beige" colspan="2">
                                        <asp:Label ID="lbldeptr" runat="server" Text="Section" Font-Bold="False"></asp:Label>&nbsp;</td>
                                    <td style="width: 285px; height: 22px">
                                        &nbsp;<asp:Label ID="sect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3" style="height: 21px" class="td_head">
                                        Appointment Letter For Staff (Foreign)</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px; text-align: left; width: 185px;background-color: beige">
                                                <asp:Label ID="Label2" runat="server" Text="Contract Period"></asp:Label></td>
                                    <td align="left" colspan="1" style="width: 285px; height: 26px; text-align: left">
                                        <asp:TextBox ID="contperiod" runat="server"></asp:TextBox>&nbsp; Months</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px; text-align: left; width: 185px;background-color: beige">
                                                    <asp:Label ID="Label1" runat="server" Text="Date of Commencement"></asp:Label>&nbsp;
                                    </td>
                                    <td align="right" colspan="1" style="width: 285px; height: 26px; text-align: left">
                                        <asp:Label ID="doj" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="width: 185px; height: 26px; text-align: left; background-color: beige">
                                                    <asp:Label ID="Label4" runat="server" Text="NRIC" Width="43px"></asp:Label></td>
                                    <td align="right" colspan="1" style="width: 285px; height: 26px; text-align: left">
                                        <asp:TextBox ID="nric" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="width: 185px; height: 26px; background-color: beige; text-align: left">
                                                    <asp:Label ID="Label5" runat="server" Text="Basic Salary"></asp:Label></td>
                                    <td align="right" colspan="1" style="width: 285px; height: 26px; text-align: left">
                                        <asp:TextBox ID="basicsal" runat="server" AutoPostBack="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="width: 185px; height: 26px; text-align: left; background-color: beige">
                                                    <asp:Label ID="Label6" runat="server" Text="Position Allowance"></asp:Label></td>
                                    <td align="right" colspan="1" style="width: 285px; height: 26px; text-align: left">
                                        <asp:TextBox ID="hra" runat="server" AutoPostBack="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="width: 185px; height: 26px; text-align: left; background-color: beige">
                                                    <asp:Label ID="Label11" runat="server" Text="Total"></asp:Label></td>
                                    <td align="right" colspan="1" style="width: 285px; height: 26px; text-align: left">
                                        <asp:Label ID="tot" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="width: 185px; height: 26px; text-align: left; background-color: beige">
                                                    <asp:Label ID="Label15" runat="server" Text="Achievement Target"></asp:Label></td>
                                    <td align="right" colspan="1" style="width: 285px; height: 26px; text-align: left">
                                        <asp:DropDownList ID="target" runat="server" Width="158px" AppendDataBoundItems="True">
                                            <asp:ListItem Value="-">--- Select ---</asp:ListItem>
                                            <asp:ListItem>60%</asp:ListItem>
                                            <asp:ListItem>80%</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="3" style="height: 51px; text-align: center">
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtBirthDate" runat="server" Visible="False"></asp:TextBox>
                            <asp:Label ID="lblshowage" runat="server" Visible="False"></asp:Label><br />
                                        &nbsp;<asp:Button ID="showaptstaffforeign" runat="server" SkinID="buttonskin1" Text="SAVE & PRINT" /></td>
                                </tr>
                            </table>
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="LblAge" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 384px;">
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
