<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ReportKPIPerformance.aspx.vb" Inherits="E_Management.ReportKPIPerformance" 
    title="Performance Report-KPI" %>
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
                <asp:Panel ID="Panel1" runat="server" GroupingText="Select Yr & mon">
                    <table style="width: 603px; height: 348px;">
                        <tr>
                            <td style="width: 243px; height: 21px">
                                Options
                            </td>
                            <td style="height: 21px; width: 411px;">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                    Width="347px">
                                    <asp:ListItem Value="mth">By Month</asp:ListItem>
                                    <asp:ListItem Value="yr">By Year</asp:ListItem>
                                    <asp:ListItem Value="hyr">By Half yr</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 243px">
                                Select Year</td>
                            <td style="width: 411px">
                                <asp:DropDownList ID="ddlyr" runat="server" Enabled="False">
                                  
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
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 243px; height: 37px;">
                                Select Month</td>
                            <td style="width: 411px; height: 37px">
                                <asp:DropDownList ID="ddlmon" runat="server" Enabled="False">
                                <asp:ListItem Value="1">JAN</asp:ListItem>
                                <asp:ListItem Value="2">FEB</asp:ListItem>
                                <asp:ListItem Value="3">MAR</asp:ListItem>
                                <asp:ListItem Value="4">APR</asp:ListItem>
                                <asp:ListItem Value="5">MAY</asp:ListItem>
                                <asp:ListItem Value="6">JUNE</asp:ListItem>
                                <asp:ListItem Value="7">JULY</asp:ListItem>
                                <asp:ListItem Value="8">AUG</asp:ListItem>
                                <asp:ListItem Value="9">SEP</asp:ListItem>
                                <asp:ListItem Value="10">OCT</asp:ListItem>
                                <asp:ListItem Value="11">NOV</asp:ListItem>
                                <asp:ListItem Value="12">DEC</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 243px; height: 37px">
                                Select Half yr option</td>
                            <td style="width: 411px; height: 37px">
                                <asp:DropDownList ID="ddlhalf" runat="server" Enabled="False">
                                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1h">1st Haf</asp:ListItem>
                                    <asp:ListItem Value="2h">2nd Half</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 243px">
                                Report by</td>
                            <td style="width: 411px">
                                <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                    Width="408px">
                                    <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                    <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                    <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                                    <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 243px; height: 24px;">
                                Department</td>
                            <td style="height: 24px; width: 411px;">
                                <asp:DropDownList ID="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                    DataTextField="dept" DataValueField="departmentcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 243px">
                                Section</td>
                            <td style="width: 411px">
                                <asp:DropDownList ID="ddlsectrpt" runat="server" DataSourceID="selsectreport" DataTextField="sectioncode"
                                    DataValueField="sectioncode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 243px">
                                Designation</td>
                            <td style="width: 411px">
                                <asp:DropDownList ID="ddldesigr" runat="server" AutoPostBack="True" DataSourceID="SqlDesig"
                                    DataTextField="desig" DataValueField="desig">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 243px">
                                Employee code</td>
                            <td style="width: 411px">
                                <asp:TextBox ID="txtempidr" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 243px">
                            </td>
                            <td align="right" style="width: 411px">
                                <asp:Button ID="btnshow" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
                        </tr>
                    </table>
                </asp:Panel>
         
         <asp:SqlDataSource id="SqlDataSource1" runat="server" SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode " ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig  from designation order by designationname ">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectioncode] FROM [sectionmaster] order by sectioncode  ">
                </asp:SqlDataSource>
                                &nbsp;
         
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
