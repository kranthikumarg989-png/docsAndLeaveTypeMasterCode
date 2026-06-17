<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="rPTlEAVEoVERALLSUMMARY.aspx.vb" Inherits="E_Management.rPTlEAVEoVERALLSUMMARY" 
    title="OVERALL LEAVE SUMMARY" %>
        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<TABLE style="WIDTH: 60%" cellSpacing=0 cellPadding=0><TBODY><TR><TD width=16><IMG height=16 src="../../images/top_lef.gif" 
width=16 /></TD><TD 
background="../../images/top_mid.gif" height=16><IMG height=16 src="../../images/top_mid.gif" 
width=16 /></TD><TD style="WIDTH: 25px"><IMG height=16 src="../../images/top_rig.gif" 
width=24 /></TD></TR><TR><TD style="HEIGHT: 372px" width=16 
background="../../images/cen_lef.gif"><IMG 
height=11 src="../../images/cen_lef.gif" width=16 /></TD><TD style="HEIGHT: 372px" vAlign=top 
bgColor=#ffffff><TABLE><TBODY><TR><TD 
style="WIDTH: 776px; BORDER-BOTTOM: 2px solid; HEIGHT: 295px" colSpan=2><TABLE><TBODY><TR><TD style="HEIGHT: 24px" class="td_head" 
colSpan=2>Overall Leave summary </TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="Label36" runat="server" Width="143px" Text="Report TimeLine"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 26px"><asp:TextBox id="txtsumfrom" runat="server" Width="87px"></asp:TextBox> 
~ <asp:TextBox id="txtsumto" runat="server" Height="14px" Width="77px"></asp:TextBox> 
<asp:RequiredFieldValidator id="RequiredFieldValidator17" runat="server" ControlToValidate="txtsumto">*</asp:RequiredFieldValidator> 
<asp:RequiredFieldValidator id="RequiredFieldValidator18" runat="server" ControlToValidate="txtsumfrom" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><cc1:CalendarExtender id="CalendarExtender5" runat="server" PopupButtonID="txtsumfrom" CssClass="cal_Theme1" Format="dd/MM/yy" TargetControlID="txtsumfrom"></cc1:CalendarExtender><cc1:CalendarExtender id="CalendarExtender6" runat="server" PopupButtonID="txtsumto" CssClass="cal_Theme1" Format="dd/MM/yy" TargetControlID="txtsumto"></cc1:CalendarExtender></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 17px; BACKGROUND-COLOR: beige"><asp:Label id="Label40" runat="server" Text="Report By"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 17px"><asp:RadioButtonList id="rdosumby" runat="server" Width="408px" AutoPostBack="True" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                                    <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                                    <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                                                    <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                                                </asp:RadioButtonList></TD></TR>
    <tr>
        <td style="width: 148px; height: 24px; background-color: beige">
            <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label></td>
        <td style="width: 403px; height: 24px">
            <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True">
                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                <asp:ListItem Value="S">Staff</asp:ListItem>
                <asp:ListItem Value="LO">Local Operator</asp:ListItem>
                <asp:ListItem Value="FO">Foreign Operator</asp:ListItem>
                <asp:ListItem>All</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList3"
                InitialValue="-1">*</asp:RequiredFieldValidator></td>
    </tr>
    <TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="Label41" runat="server" Text="Select Department"></asp:Label>&nbsp;</TD><TD 
style="WIDTH: 403px; HEIGHT: 24px"><asp:DropDownList id="ddlsumdept" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataValueField="departmentcode" DataTextField="dept" Enabled="False">
                                                </asp:DropDownList> 
</TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="Label42" runat="server" Text="Select Section"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 24px"><asp:DropDownList id="ddlsumsect" runat="server" DataSourceID="selsectreport" DataValueField="sectioncode" DataTextField="sectioncode" Enabled="False">
                                                </asp:DropDownList></TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="Label43" runat="server" Text="Select Designation"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 24px"><asp:DropDownList id="ddlsumdesig" runat="server" AutoPostBack="True" DataSourceID="SqlDesig" DataValueField="desig" DataTextField="desig" Enabled="False">
                                                </asp:DropDownList> 
</TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 26px; BACKGROUND-COLOR: beige"><asp:Label id="Label44" runat="server" Text="ByEmployee"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 26px"><asp:TextBox id="txtsumemp" runat="server" Width="83px" AutoPostBack="True" Enabled="False"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 26px" align=right 
colSpan=2> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="btnsumrpt" runat="server" SkinID="buttonskin1" Text="SHOW REPORT"></asp:Button> 
</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD><TD 
style="WIDTH: 25px; HEIGHT: 372px" background="../../images/cen_rig.gif"><IMG height=11 src="../../images/cen_rig.gif" 
width=24 /></TD></TR><TR><TD width=16 height=16><IMG height=16 src="../../images/bot_lef.gif" 
width=16 /></TD><TD 
background="../../images/bot_mid.gif" height=16><IMG height=16 src="../../images/bot_mid.gif" 
width=16 /></TD><TD style="WIDTH: 25px" 
height=16><IMG height=16 
src="../../images/bot_rig.gif" width=24 
/></TD></TR></TBODY></TABLE>
  <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode ">
                    </asp:SqlDataSource>
                     <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [sectionmaster] WHERE ([departmentcode] = @departmentcode) ORDER BY [sectioncode]">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="ddlsumdept" Name="departmentcode" PropertyName="SelectedValue"
                                 Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
</asp:Content>
