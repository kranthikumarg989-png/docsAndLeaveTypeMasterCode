<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="reportsummary.aspx.vb" Inherits="E_Management.reportsummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="tb1"  runat="server">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="tb2" runat="server">
    </cc1:CalendarExtender>
    <table >
        <tbody>
            <tr>
                <td class="td_head" colspan="2" >
                    Security Report</td>
            </tr>
            <tr>
                <td >
                    Select Date Field</td>
                <td >
                    <asp:TextBox ID="tb1" runat="server" Width="80px" ></asp:TextBox>
                    &nbsp; --------
                    <asp:TextBox ID="tb2" runat="server" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="Button1" runat="server" BackColor="LightSteelBlue" BorderColor="Gray" BorderWidth="1px" Text="Show" />
                    
                </td>
            </tr>
            <tr>
                <td colspan="1" >
                    <asp:Label ID="Label1" runat="server" Text="Gatepass Personal :"  Font-Bold="False" Font-Size="Medium" ></asp:Label></td>
                <td colspan="2" >
                    <asp:Label ID="gppers" runat="server" Font-Size="Medium"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    <asp:Label ID="Label2" runat="server"  Text="Gatepass Official :" Font-Size="Medium" ></asp:Label></td>
                <td colspan="2">
                    <asp:Label ID="gpoff" runat="server" Font-Size="Medium" ></asp:Label>
                    <asp:Label ID="total" runat="server" Font-Size="Medium"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1">
                    <asp:Label ID="label3" runat="server"  Text="Clinic Pass :" Font-Size="Medium"></asp:Label></td>
                <td colspan="2">
                    <asp:Label ID="clinicpass" runat="server" Font-Size="Medium"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1">
                    <asp:Label ID="Label4" runat="server" Text="Customer Pass :" Font-Size="Medium" ></asp:Label></td>
                <td colspan="2">
                    <asp:Label ID="Customerpass" runat="server" Font-Size="Medium"></asp:Label></td>
            </tr>
        </tbody>
    </table>
                    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>