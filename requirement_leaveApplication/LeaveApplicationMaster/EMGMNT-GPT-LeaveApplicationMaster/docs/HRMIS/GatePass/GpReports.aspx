<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="GpReports.aspx.vb" Inherits="E_Management.GpReports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 532px">
        <tr>
            <td style="height: 26px; background-color: #cccc99">
                <asp:Label ID="Label2" runat="server" Text="Report TimeLine" Width="143px"></asp:Label></td>
            <td style="width: 403px; height: 26px">
                <asp:TextBox ID="txtfrom" runat="server" Width="87px"></asp:TextBox>
                ~
                <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfrom"
                    SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender><cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender></tr>
        <tr>
            <td style="height: 33px; background-color: #cccc99">
                <asp:Label ID="Label5" runat="server" Text="Report By"></asp:Label></td>
            <td style="width: 403px; height: 33px">
                <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                    <asp:ListItem Value="Sect">BySect</asp:ListItem>
                    <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                    <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                    <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="height: 24px; background-color: #cccc99">
                <asp:Label ID="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
            <td style="width: 403px; height: 24px">
                <asp:DropDownList ID="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                    DataTextField="dept" DataValueField="departmentcode">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 24px; background-color: #cccc99">
                <asp:Label ID="lblsectr" runat="server" Text="Select Section"></asp:Label></td>
            <td style="width: 403px; height: 24px">
                <asp:DropDownList ID="ddlsectr" runat="server" DataSourceID="sqlsect" AutoPostBack=true
                    DataTextField="section" DataValueField="sectioncode">
                </asp:DropDownList>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 24px; background-color: #cccc99">
                <asp:Label ID="lbldesigr" runat="server" Text="Select Designation"></asp:Label></td>
            <td style="width: 403px; height: 24px">
                <asp:DropDownList ID="ddldesigr" runat="server" AutoPostBack="True" DataSourceID="SqlDesig"
                    DataTextField="desig" DataValueField="desig">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="background-color: #cccc99">
                <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
            <td style="width: 403px">
                <asp:TextBox ID="txtempidr" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="height: 26px">
                &nbsp;<asp:Button ID="Button1" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
            </td>
        </tr>
    </table>
        <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
          
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation order by designationname">
                    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode">
                    </asp:SqlDataSource>
</asp:Content>
