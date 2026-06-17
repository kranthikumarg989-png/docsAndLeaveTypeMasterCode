<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/ems.Master"  Title="Update - License Info" CodeBehind="UpdateLicenseInfo.aspx.vb" Inherits="E_Management.UpdateLicenseInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table>
<tr>
<td style="height: 22px">
    <asp:RadioButton ID="Rbtn1" runat="server" AutoPostBack="True" Checked="True" GroupName="G1" Text="Employee License Information" /></td>
<td style="height: 22px">
    &nbsp;&nbsp;
    <asp:RadioButton ID="Rbtn2" runat="server" AutoPostBack="True" GroupName="G1" Text="Supplier License Information" /></td>
</tr>
</table>
<table runat=server id=tbl1>
    <tr>
        <td bgcolor="darkblue" colspan="4" style="text-align: center">
            <asp:Label ID="Label6" runat="server" BackColor="MidnightBlue" BorderStyle="None"
                Font-Bold="True" ForeColor="#FFFFFF" Text="Update Employee  License Info" Width="724px"></asp:Label></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:Label ID="Label1" runat="server" Text="Employee Code"></asp:Label></td>
        <td>
            <asp:DropDownList ID="CmbEmpCode" runat="server" AutoPostBack="True" Width="155px">
            </asp:DropDownList></td>
        <td>
            <asp:Label ID="LblEmpCode" runat="server"></asp:Label></td>
        <td>
            <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:Label ID="Label3" runat="server" Text="Car Number"></asp:Label></td>
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
            <asp:Button ID="BtnUpdate" runat="server" Text="Update and Print" /></td>
    </tr>
    
</table>
    <br /><table runat=server id=tbl2 visible="false">
        <tr>
            <td bgcolor="darkblue" colspan="4" style="text-align: center">
                <asp:Label ID="Label8" runat="server" BackColor="MidnightBlue" BorderStyle="None"
                    Font-Bold="True" ForeColor="White" Text="Update Supplier(Van Driver)  License Info"
                    Width="724px"></asp:Label></td>
        </tr>
        <tr>
            <td bgcolor="beige">
                <asp:Label ID="Label9" runat="server" Text="Supplier"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="CmbSupplier" runat="server" AutoPostBack="True" Width="516px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td bgcolor="beige" style="height: 21px">
                <asp:Label ID="LblSupplierCode" runat="server">.</asp:Label></td>
            <td colspan="3" bgcolor="beige">
                <asp:Label ID="LblSupplierName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td bgcolor="beige" rowspan="1">
                <asp:Label ID="Label12" runat="server" Text="VAN Number"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtVanNumber" runat="server"></asp:TextBox></td>
            <td bgcolor="beige">
                <asp:DropDownList ID="CMBVanNo" runat="server" AutoPostBack="True" Width="160px">
                </asp:DropDownList></td>
            <td style="width: 73px">
                </td>
        </tr>
        <tr>
            <td bgcolor="beige" rowspan="1">
                <asp:Label ID="Label10" runat="server" Text="Driver Name"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtDriverName" runat="server"></asp:TextBox></td>
            <td bgcolor="beige">
                &nbsp;<asp:Label ID="Label11" runat="server" Text="IC NUMBER"></asp:Label></td>
            <td style="width: 73px">
                <asp:TextBox ID="TXTICNO" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige">
                <asp:Label ID="Label13" runat="server" Text="License No"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtLicenseNo1" runat="server">-</asp:TextBox></td>
            <td bgcolor="beige">
                <asp:Label ID="Label14" runat="server" Text="License Expiry Date"></asp:Label></td>
            <td style="width: 73px">
                <asp:TextBox ID="TxtLicenseExpiryDate1" runat="server" Width="83px"></asp:TextBox><cc1:CalendarExtender
            ID="CalendarExtender3" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
            PopupButtonID="TxtLicenseExpiryDate1" TargetControlID="TxtLicenseExpiryDate1">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtLicenseExpiryDate1"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td bgcolor="beige">
                <asp:Label ID="Label15" runat="server" Text="Road Tax No"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtRoadTaxNo1" runat="server">-</asp:TextBox></td>
            <td bgcolor="beige">
                <asp:Label ID="Label16" runat="server" Text="Road Tax Expiry Date"></asp:Label></td>
            <td style="width: 73px">
                <asp:TextBox ID="TxtRoadTaxExpiryDate1" runat="server" Width="83px"></asp:TextBox><cc1:CalendarExtender
            ID="CalendarExtender4" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
            PopupButtonID="TxtRoadTaxExpiryDate1" TargetControlID="TxtRoadTaxExpiryDate1">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtRoadTaxExpiryDate1"
                    ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="3" bgcolor="beige" style="height: 26px">
                <asp:Label ID="LblMsg2" runat="server" Font-Bold="True" ForeColor="#006600" Width="402px"></asp:Label></td>
            <td style="text-align: center; width: 73px; height: 26px;" bgcolor="beige">
                <asp:Button ID="BtnUpdate1" runat="server" Text="Update and Print" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>