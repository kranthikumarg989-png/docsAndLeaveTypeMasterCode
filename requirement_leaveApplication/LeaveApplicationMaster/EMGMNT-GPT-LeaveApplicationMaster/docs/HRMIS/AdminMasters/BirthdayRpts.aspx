<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BirthdayRpts.aspx.vb" Inherits="E_Management.BirthdayRpts" 
    title="Birthday Reports" %>
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
                <table style="height: 199px">
                    <tr>
                        <td colspan="2" style="width: 733px; border-bottom: 2px solid; height: 295px" valign="top">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        <strong>BIRTHDAY &nbsp;REPORTS</strong></td>
                                </tr>
                                <tr>
                                    <td style="width: 151px; height: 26px; background-color: beige">
                                        Select company</td>
                                    <td style="width: 575px; height: 26px">
                                        <asp:RadioButtonList ID="RBcomp" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="MM">Maruwa Malaysia</asp:ListItem>
                                            <asp:ListItem Value="MEL">Maruwa Melaka</asp:ListItem>
                                            <asp:ListItem Value="MO">Maruwa Outsource</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RBcomp"
                                            ErrorMessage="Select One Company"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 151px; height: 26px; background-color: beige">
                                        <asp:Label ID="Label26" runat="server" Text="Report TimeLine" Width="143px" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 26px">
                                        <asp:TextBox ID="txtfrom" runat="server" Width="115px"></asp:TextBox><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                                                                    ~
                                        <asp:TextBox ID="txtto" runat="server" Height="14px" Width="115px"></asp:TextBox>
                                        &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfrom"
                                    ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtto"
                                    ErrorMessage="Please Select End Date"></asp:RequiredFieldValidator>&nbsp;
                                    </td>
                                   
                                   
                                   
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="showtTrainingReport" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="Sqlsecdept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept">
                    </asp:SqlDataSource>
                </table>
                                         <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd-MM"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                                         
                                         <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd-MM"
                                            popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
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
