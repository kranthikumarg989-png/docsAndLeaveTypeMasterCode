<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ReportBT.aspx.vb" Inherits="E_Management.ReportBT" 
    title="BUSINESS TRIP " %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<TABLE cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR>
<TD style="width: 16px; height: 16px;">
<IMG height=16 src="../../../images/top_lef.gif" width=16 /></TD>
<TD background="../../../images/top_mid.gif" style="width: 1208px; height: 16px;">
<IMG height=16 src="../../../images/top_mid.gif" width=16 /></TD>
<TD style="WIDTH: 25px; height: 16px;"><IMG height=16 src="../../../images/top_rig.gif" width=24 /></TD></TR>
<TR><TD style="HEIGHT: 365px; width: 16px;" background="../../../images/cen_lef.gif">
<IMG height=11 src="../../../images/cen_lef.gif" width=16 /></TD>
<TD style="HEIGHT: 365px; width: 1208px;" vAlign=top bgColor=#ffffff>
<TABLE><TBODY><TR><TD style="WIDTH: 776px; BORDER-BOTTOM: 2px solid; HEIGHT: 295px" colSpan=2>
<TABLE><TBODY><TR><TD style="HEIGHT: 24px" class="td_head" 
colSpan=2>Business Trip Reports Overall</TD></TR>
<TR><TD style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige">
<asp:Label id="Label26" runat="server" Width="143px" Text="Report TimeLine"></asp:Label></TD>
<TD style="HEIGHT: 26px">
<asp:TextBox id="txtfrom" runat="server" Width="87px"></asp:TextBox> 
~ <asp:TextBox id="txtto" runat="server" Height="14px" Width="77px"></asp:TextBox> 
<asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator> 
<asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><cc1:CalendarExtender id="ccefrom" runat="server" PopupButtonID="txtfrom" CssClass="cal_Theme1" Format="dd/MM/yy" TargetControlID="txtfrom"></cc1:CalendarExtender><cc1:CalendarExtender id="cceto" runat="server" PopupButtonID="txtto" CssClass="cal_Theme1" Format="dd/MM/yy" TargetControlID="txtto"></cc1:CalendarExtender></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 17px; BACKGROUND-COLOR: beige"><asp:Label id="Label27" runat="server" Text="Report By"></asp:Label></TD><TD 
style="HEIGHT: 17px"><asp:RadioButtonList id="rdoptions" runat="server" Width="408px" AutoPostBack="True" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                        <asp:ListItem Value="Sect">BySect</asp:ListItem>
                        <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
    <asp:ListItem Value="BT">By BTNo</asp:ListItem>
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                    </asp:RadioButtonList></TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</TD><TD 
style="HEIGHT: 24px"><asp:DropDownList id="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataValueField="departmentcode" DataTextField="dept">
                    </asp:DropDownList> </TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="lblsectr" runat="server" Text="Select Section"></asp:Label></TD><TD 
style="HEIGHT: 24px"><asp:DropDownList id="ddlsectrpt" runat="server" DataSourceID="selsectreport" DataValueField="sectioncode" DataTextField="sectioncode">
                    </asp:DropDownList></TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="lbldesigr" runat="server" Text="Select Designation"></asp:Label></TD><TD 
style="HEIGHT: 24px"><asp:DropDownList id="ddldesigr" runat="server" AutoPostBack="True" DataSourceID="SqlDesig" DataValueField="desig" DataTextField="desig">
                    </asp:DropDownList> </TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="lblempr" runat="server" Text="Enter Empcode"></asp:Label></TD><TD><asp:TextBox id="txtempidr" runat="server" Width="83px" AutoPostBack="True"></asp:TextBox></TD></TR>
    <tr>
        <td style="width: 148px; height: 24px; background-color: beige">
            <asp:Label ID="lblbt" runat="server" Text="Enter BT No."></asp:Label></td>
        <td>
            <asp:TextBox ID="txtbt" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
    </tr>
    <TR><TD style="HEIGHT: 26px" align=right 
colSpan=2> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="Button1" runat="server" SkinID="buttonskin1" Text="SHOW REPORT"></asp:Button> 
</TD></TR></TBODY></TABLE><asp:SqlDataSource id="selsectreport" runat="server" SelectCommand="SELECT [sectioncode] FROM [sectionmaster]" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"></asp:SqlDataSource> 
</TD></TR><asp:SqlDataSource id="sqlsect" runat="server" SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource><asp:SqlDataSource id="SqlDesig" runat="server" SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource><asp:SqlDataSource id="SqlDataSource1" runat="server" SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource><asp:SqlDataSource id="Sqlsecdept" runat="server" SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource></TBODY></TABLE></TD><TD 
style="WIDTH: 25px; HEIGHT: 365px" background="../../../images/cen_rig.gif"><IMG height=11 src="../../../images/cen_rig.gif" 
width=24 /></TD></TR><TR><TD style="width: 16px; height: 16px;"><IMG height=16 src="../../../images/bot_lef.gif" 
width=16 /></TD><TD 
background="../../../images/bot_mid.gif" style="width: 1208px; height: 16px"><IMG height=16 src="../../../images/bot_mid.gif" 
width=16 /></TD><TD style="WIDTH: 25px; height: 16px;"><IMG height=16 
src="../../../images/bot_rig.gif" width=24 
/></TD></TR></TBODY></TABLE>
</asp:Content>
