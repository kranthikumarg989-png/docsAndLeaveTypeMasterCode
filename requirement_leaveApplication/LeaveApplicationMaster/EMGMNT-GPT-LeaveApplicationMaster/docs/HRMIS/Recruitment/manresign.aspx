<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="manresign.aspx.vb" Inherits="E_Management.manresign" 
    title="Man resign" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr><td class="td_head" colspan="3" >
            RESIGN DETAILS</td></tr>
        <tr>
            <td bgcolor="beige" width="10%">
                Employee Code</td>
            <td bgcolor="beige" width="25%">
                <asp:TextBox ID="empcode" runat="server" MaxLength="6" Width="80px"></asp:TextBox>&nbsp;
                <asp:CheckBox ID="cb1" runat="server" AutoPostBack="True" Text="Search by using Empcode" /></td>
        </tr>
            <tr><td bgcolor="beige" width="10%" style="height: 26px">Select Date</td>
                <td bgcolor="beige" width="25%" style="height: 26px"><asp:TextBox ID="fromdt" runat="server" Width="80px"></asp:TextBox>~<asp:TextBox
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
</asp:Content>