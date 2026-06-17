<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ReportHODKPI.aspx.vb" Inherits="E_Management.ReportHODKPI" 
    title="HOD KPI REPORT" %>
                <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table>
                    <tr>
                        <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 295px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        HOD KPI Report
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 17px; background-color: beige">
                                        Select
                                    </td>
                                    <td style="width: 403px; height: 17px">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            Width="220px">
                                            <asp:ListItem Value="yr">By Year</asp:ListItem>
                                            <asp:ListItem Value="qr">By Quarter</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 17px; background-color: beige">
                                        Year</td>
                                    <td style="width: 403px; height: 17px">
                                        <asp:DropDownList ID="ddlyr" runat="server" Enabled="False">
                                            <asp:ListItem>2010</asp:ListItem>
                                            <asp:ListItem>2011</asp:ListItem>
                                            <asp:ListItem>2012</asp:ListItem>
                                            <asp:ListItem>2013</asp:ListItem>
                                            <asp:ListItem>2014</asp:ListItem>
                                            <asp:ListItem>2015</asp:ListItem>
                                            <asp:ListItem>2016</asp:ListItem>
                                            <asp:ListItem>2017</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                            <asp:ListItem>2021</asp:ListItem>
                                            <asp:ListItem>2022</asp:ListItem>
                                            <asp:ListItem>2023</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 17px; background-color: beige">
                                        Quarter</td>
                                    <td style="width: 403px; height: 17px">
                                        <asp:DropDownList ID="ddlmon" runat="server" Enabled="False">
                                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                            <asp:ListItem>Q1</asp:ListItem>
                                            <asp:ListItem>Q2</asp:ListItem>
                                            <asp:ListItem>Q3</asp:ListItem>
                                            <asp:ListItem>Q3</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 17px; background-color: beige">
                                        <asp:Label ID="Label30" runat="server" Text="Report By"></asp:Label></td>
                                    <td style="width: 403px; height: 17px">
                                        <asp:RadioButtonList ID="hodrdorpt" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            Width="408px">
                                            <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                            <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label32" runat="server" Text="Select Section"></asp:Label></td>
                                    <td style="width: 403px; height: 24px">
                                        <asp:DropDownList ID="hodddlsect" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                                            DataTextField="sectioncode" DataValueField="sectioncode">
                                        </asp:DropDownList></td>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                        SelectCommand="SELECT [sectioncode] FROM [sectionmaster] WHERE ([departmentcode] = @departmentcode)">
                                        <FilterParameters>
                                            <asp:SessionParameter Name="departmentcode" SessionField="_edept" Type="String" />
                                        </FilterParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="departmentcode" SessionField="_edept" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label34" runat="server" Text="ByEmployee"></asp:Label></td>
                                    <td style="width: 403px">
                                        <asp:TextBox ID="hodtxtemp" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="hodbtnrpt" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
