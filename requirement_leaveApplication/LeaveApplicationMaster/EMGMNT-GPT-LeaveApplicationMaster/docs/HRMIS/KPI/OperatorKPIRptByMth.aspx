<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OperatorKPIRptByMth.aspx.vb" Inherits="E_Management.OperatorKPIRptByMth" 
    title="Operator KPI report -By Month" %>
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
                        <td colspan="2" style="width: 565px; border-bottom: 2px solid; height: 295px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        KPI Operator Report Overall</td>
                                </tr>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 256px; height: 26px; background-color: beige">
                                        Choose Year</td>
                                    <td style="width: 412px; height: 26px">
                                        <asp:DropDownList ID="kpiyear" runat="server" AppendDataBoundItems="True" Width="126px">
                                            <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                            <asp:ListItem>2002-2003</asp:ListItem>
                                            <asp:ListItem>2003-2004</asp:ListItem>
                                            <asp:ListItem>2004-2005</asp:ListItem>
                                            <asp:ListItem>2005-2006</asp:ListItem>
                                            <asp:ListItem>2006-2007</asp:ListItem>
                                            <asp:ListItem>2007-2008</asp:ListItem>
                                            <asp:ListItem>2008-2009</asp:ListItem>
                                            <asp:ListItem>2009-2010</asp:ListItem>
                                            <asp:ListItem>2010-2011</asp:ListItem>
                                            <asp:ListItem>2011-2012</asp:ListItem>
                                            <asp:ListItem>2012-2013</asp:ListItem>
                                            <asp:ListItem>2013-2014</asp:ListItem>
                                            <asp:ListItem>2014-2015</asp:ListItem>
                                            <asp:ListItem>2015-2016</asp:ListItem>
                                            <asp:ListItem>2016-2017</asp:ListItem>
                                            <asp:ListItem>2017-2018</asp:ListItem>
                                            <asp:ListItem>2018-2019</asp:ListItem>
                                            <asp:ListItem>2019-2020</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="kpiyear"
                                            ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator></td>
                                   
                                   
                                   
                                </tr>
                                <tr>
                                    <td style="width: 256px; height: 26px; background-color: beige">
                                        Choose Month</td>
                                    <td style="width: 412px; height: 26px">
                                        <asp:DropDownList ID="Qoption" runat="server" AppendDataBoundItems="True" Width="127px">
                                            <asp:ListItem Value="-1" Selected="True">--- Select ---</asp:ListItem>
                                            <asp:ListItem>01</asp:ListItem>
                                            <asp:ListItem>02</asp:ListItem>
                                            <asp:ListItem>03</asp:ListItem>
                                            <asp:ListItem>04</asp:ListItem>
                                            <asp:ListItem>05</asp:ListItem>
                                            <asp:ListItem>06</asp:ListItem>
                                            <asp:ListItem>07</asp:ListItem>
                                            <asp:ListItem>08</asp:ListItem>
                                            <asp:ListItem>09</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Qoption"
                                            ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 256px; height: 26px; background-color: beige">
                                        Employee Type</td>
                                    <td style="width: 412px; height: 26px">
                                        <asp:DropDownList ID="emptype" runat="server" AppendDataBoundItems="True" Width="127px">
                                             <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                            <asp:ListItem Value="Y">Foreign</asp:ListItem>
                                            <asp:ListItem Value="N">Local</asp:ListItem>
                                            <asp:ListItem Value="NS">Non-Staff</asp:ListItem>
                                            <asp:ListItem Value="Both">All</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 256px; height: 17px; background-color: beige">
                                        <asp:Label ID="Label27" runat="server" Text="Report By"></asp:Label></td>
                                    <td style="width: 412px; height: 17px">
                                        <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            Width="408px">
                                             <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                            <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                            <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="O">* (ALL)</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="ONS">* ALL Non Staff</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="width: 256px; height: 24px; background-color: beige">
                                        <asp:Label ID="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                            DataTextField="dept" DataValueField="departmentcode" Width="218px">
                                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 256px; height: 24px; background-color: beige">
                                        <asp:Label ID="lblsectr" runat="server" Text="Select Section"></asp:Label></td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="ddlsectrpt" runat="server" DataSourceID="selsectreport" DataTextField="sectioncode"
                                            DataValueField="sectioncode" Width="218px">
                                            <asp:ListItem Value="-1">---select---</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 256px; height: 24px; background-color: beige">
                                        <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
                                    <td style="width: 412px">
                                        <asp:TextBox ID="txtempidr" runat="server" AutoPostBack="True" Width="123px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="showrepKPI" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                            <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [sectionmaster] ORDER BY [sectioncode]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="Sqlsecdept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept">
                    </asp:SqlDataSource>
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

