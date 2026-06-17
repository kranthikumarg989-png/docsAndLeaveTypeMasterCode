<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ReportMajorSubKPIIndivandDept.aspx.vb" Inherits="E_Management.ReportMajorSubKPIIndivandDept" 
    title="KPI Reports By Individual/ Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server"><table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 617px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 352px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 617px; height: 352px;" valign="top">
                <asp:Panel ID="Panel1" runat="server" GroupingText="Select KPI Reports By">
                    <table style="width: 239px">
                        <tr>
                            <td style="width: 280px">
                                Choose Year</td>
                            <td style="width: 563px; height: 21px">
                          <asp:DropDownList ID="yearddl" runat="server">
                                  
                                <asp:ListItem Value=2010>2010-2011</asp:ListItem>
                                <asp:ListItem Value=2011>2011-2012</asp:ListItem>
                                <asp:ListItem Value=2012>2012-2013</asp:ListItem>
                                <asp:ListItem value=2013>2013-2014</asp:ListItem>
                                <asp:ListItem value=2014>2014-2015</asp:ListItem>
                                <asp:ListItem Value=2015>2015-2016</asp:ListItem>
                                <asp:ListItem Value=2016>2016-2017</asp:ListItem>
                                <asp:ListItem Value=2017>2017-2018</asp:ListItem>
                                <asp:ListItem Value=2018>2018-2019</asp:ListItem>
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 280px;">
                                Options
                            </td>
                            <td style="height: 21px; width: 563px;">
                                <asp:RadioButtonList ID="optionsrb" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                    Width="252px">
                                    <asp:ListItem Value="indiv">By Individual</asp:ListItem>
                                    <asp:ListItem Value="dept">By Department</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 280px">
                                Employee code</td>
                            <td style="width: 563px">
                                <asp:TextBox ID="txtempidr" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 280px">
                                Select
                                Department</td>
                            <td style="width: 563px">
                                <asp:DropDownList ID="ddldeptr" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode">
                                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 280px">
                            </td>
                            <td align="right" style="width: 563px; height: 26px">
                                <asp:Button ID="btnshow" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig  from designation order by designationname ">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectioncode] FROM [sectionmaster] order by sectioncode  ">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [KPI_Year] FROM [KPI_MajorSetting] ORDER BY [KPI_Year]">
                </asp:SqlDataSource>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode ">
                </asp:SqlDataSource>
         
           </td>
           </tr>
                <tr>
                
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 617px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>

</asp:Content>
