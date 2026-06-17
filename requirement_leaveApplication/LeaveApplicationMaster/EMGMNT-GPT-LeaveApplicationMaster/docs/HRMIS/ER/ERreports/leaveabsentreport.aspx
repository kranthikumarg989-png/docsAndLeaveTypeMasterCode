<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="leaveabsentreport.aspx.vb" Inherits="E_Management.leaveabsentreport" 
    title="Leave Absentism Reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                        <td colspan="2" style="width: 530px; border-bottom: 2px solid; height: 156px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        Absent/ Abscond/ Return Late/ Late Coming/ Over Night/ Other Misconduct Reports</td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 26px; background-color: beige">
                                        <asp:Label ID="Label26" runat="server" Text="Report Time Line" Width="143px" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 26px">
                                        <asp:TextBox ID="txtfrom" runat="server" Width="115px" AutoPostBack="True"></asp:TextBox><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfrom"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                                        ~
                                        <asp:TextBox ID="txtto" runat="server" Height="14px" Width="115px" AutoPostBack="True"></asp:TextBox><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtto"
                                    ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                   
                                   
                                   
                                </tr>
                                <tr>
                                    <td style="width: 277px; height: 22px; background-color: beige">
                                        <asp:Label ID="Label2" runat="server" Text="View All"></asp:Label></td>
                                    <td style="width: 575px; height: 22px">
                                                    <asp:CheckBox ID="cb" runat="server" AutoPostBack="True" Text="All" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="lbldeptr" runat="server" Text="Leave Type" Font-Bold="False"></asp:Label>&nbsp;</td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="leavetype" runat="server" Width="258px" AutoPostBack="True">
                                            <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                            <asp:ListItem>Absent</asp:ListItem>
                                            <asp:ListItem>Abscond</asp:ListItem>
                                            <asp:ListItem>LateComing</asp:ListItem>
                                            <asp:ListItem>LateReturn</asp:ListItem>
                                            <asp:ListItem>MisConduct</asp:ListItem>
                                            <asp:ListItem>OverNight</asp:ListItem>
                                            <asp:ListItem>RanAway</asp:ListItem>
                                        </asp:DropDownList>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 22px; background-color: beige">
                                        <asp:Label ID="Label21" runat="server" Text="Select Department" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 22px">
                                        <asp:DropDownList ID="dept" runat="server" DataSourceID="SqlDataSource1"
                                            DataTextField="departmentcode" DataValueField="departmentcode" Width="260px" AutoPostBack="True" AppendDataBoundItems="True" >
                                            <asp:ListItem Selected="True" Value="-1">--- Select ---</asp:ListItem>
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 22px; background-color: beige">
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="ByEmployee No."></asp:Label></td>
                                    <td style="width: 575px; height: 22px">
                                                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" Width="254px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px; text-align: center;">
                                        &nbsp;<asp:Button ID="showtTrainingReport" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
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
                            <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT [td_programme] FROM [td_employeetraining] ORDER BY [td_programme]">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT [td_trainingattended] FROM [td_employeetraining] ORDER BY [td_trainingattended]">
                            </asp:SqlDataSource>
                                         
                                         <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                         <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
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
