<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="manresignjoinrpt.aspx.vb" Inherits="E_Management.manresignjoinrpt" 
    title="Man Resign Join Report" %>

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
    <table>
        <tr><td class="td_head" colspan="3" >JOIN DETAILS</td></tr>
        <tr>
            <td bgcolor="beige" width="10%">
                Employee Code</td>
            <td bgcolor="beige" width="25%">
                <asp:TextBox ID="empcode" runat="server" MaxLength="6" Width="80px"></asp:TextBox>&nbsp;
                <asp:CheckBox ID="cb1" runat="server" AutoPostBack="True" Text="Search by using Empcode" /></td>
        </tr>
            <tr><td bgcolor="beige" width="10%">Select Date</td>
                <td bgcolor="beige" width="25%"><asp:TextBox ID="fromdt" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox
                        ID="todt" Width="80px" runat="server"></asp:TextBox></td>
            </tr>        
        <tr>
            <td bgcolor="beige" width="10%">Select Type</td>
            <td bgcolor="beige" width="25%">
                <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Value="dept">Department</asp:ListItem>
                    <asp:ListItem Value="desig">Designation</asp:ListItem>
                    <asp:ListItem Value="sect">Section</asp:ListItem>
                    <asp:ListItem Value="A">All</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td bgcolor="beige" width="10%">
                Department</td>
            <td bgcolor="beige" width="25%">
                <asp:DropDownList ID="dept" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="10%">
                Designation</td>
            <td bgcolor="beige" width="25%">
                <asp:DropDownList ID="desig" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlcat" runat="server">
                    <asp:ListItem Value="A">ALL</asp:ListItem>
                    <asp:ListItem Value="Y">Foreign</asp:ListItem>
                    <asp:ListItem Value="N">Local</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="10%">
                Section</td>
            <td bgcolor="beige" width="25%">
                <asp:DropDownList ID="section" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="10%">
            </td>
            <td bgcolor="beige" width="25%">
                &nbsp;<asp:Button ID="save" runat="server" BackColor="Beige" Text="Show" />
                &nbsp;<input id="Button1" style="background-color: beige" onclick="window.close()" type="button" value="Exit" /></td>
        </tr>
    </table>
    <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="fromdt" runat="server" CssClass="cal_Theme1"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="todt" runat="server" CssClass="cal_Theme1"></cc1:CalendarExtender>
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
