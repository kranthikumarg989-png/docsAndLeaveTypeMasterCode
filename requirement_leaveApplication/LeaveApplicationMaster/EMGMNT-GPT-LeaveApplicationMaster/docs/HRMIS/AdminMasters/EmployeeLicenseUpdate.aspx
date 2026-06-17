<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="EmployeeLicenseUpdate.aspx.vb" Inherits="E_Management.EmployeeLicenseUpdate" 
    title="Untitled Page" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<br />
<br />
<%--<table>
<tr>
<td style="height: 22px">
    <asp:RadioButton ID="Rbtn1" runat="server" AutoPostBack="True" Checked="True" GroupName="G1" Text="Employee License Information" /></td>
<td style="height: 22px">
    &nbsp;&nbsp;
    <asp:RadioButton ID="Rbtn2" runat="server" AutoPostBack="True" GroupName="G1" Text="Supplier License Information" /></td>
</tr>
</table>--%>
<table>
 <tr>
        <td bgcolor="darkblue" colspan="4" style="text-align: center">
            <asp:Label ID="Label6" runat="server" BackColor="MidnightBlue" BorderStyle="None"
                Font-Bold="True" ForeColor="#FFFFFF" Text="Update Employee  License Info" Width="724px"></asp:Label></td>
    </tr>
</table>


<table runat="server" id="tbl1" Width="724px">
   
    <tr>
        <td bgcolor="beige">
            <asp:Label ID="Label1" runat="server" Text="Employee Code"></asp:Label></td>
        <td>
           <%-- <asp:DropDownList ID="CmbEmpCode" runat="server" AutoPostBack="True" Width="155px">
            </asp:DropDownList></td>--%>
            <asp:Label ID="LblEmpCode" runat="server" Text=""></asp:Label></td>
        <td bgcolor="beige">
            <asp:Label ID="Label8" runat="server" Text="Employee Name"></asp:Label></td>
        <td>
            <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:Label ID="Label3" runat="server" Text="vehicle Number"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtCarNumber" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:Label ID="Label4" runat="server" Text="License No"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtLicenseNo" runat="server">-</asp:TextBox></td>
        <td bgcolor="beige">
            <asp:Label ID="Label5" runat="server" Text="License Expiry Date"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtLicenseExpiryDate" runat="server" Width="83px"></asp:TextBox><cc1:CalendarExtender
            ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
            PopupButtonID="TxtLicenseExpiryDate" TargetControlID="TxtLicenseExpiryDate">
            </cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtLicenseExpiryDate"
                ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:Label ID="Label2" runat="server" Text="Road Tax No"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtRoadTaxNo" runat="server">-</asp:TextBox></td>
        <td bgcolor="beige">
            <asp:Label ID="Label7" runat="server" Text="Road Tax Expiry Date"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtRoadTaxExpiryDate" runat="server" Width="83px"></asp:TextBox><cc1:CalendarExtender
            ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
            PopupButtonID="TxtRoadTaxExpiryDate" TargetControlID="TxtRoadTaxExpiryDate">
            </cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRoadTaxExpiryDate"
                ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td colspan="3" bgcolor="beige">
            <asp:Label ID="LblMsg" runat="server" Font-Bold="True" ForeColor="#006600" Width="402px"></asp:Label></td>
        <td style="text-align: center" bgcolor="beige">
            <asp:Button ID="BtnUpdate" runat="server" Text="Save" /></td>
    </tr>
    
</table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
