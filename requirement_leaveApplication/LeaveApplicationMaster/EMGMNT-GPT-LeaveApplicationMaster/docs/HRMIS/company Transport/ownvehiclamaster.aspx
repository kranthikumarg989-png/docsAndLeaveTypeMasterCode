<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ownvehiclamaster.aspx.vb" Inherits="E_Management.ownvehiclamaster" 
   %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="2" style="width: 448px">
        <tr>
            <td align="center" class="td_head" colspan="4" style="height: 17px" valign="middle">
                EMPLOYEE DETAILS</td>
        </tr>
        <tr>
            <td style="width: 51px; height: 17px; background-color: beige">
                EmpCode</td>
            <td style="width: 116px">
                <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Width="94px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="R4" runat="server" ControlToValidate="txtempcode"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 34px; background-color: beige">
                EmpName</td>
            <td style="width: 301px; background-color: beige">
                <asp:Label ID="lblename" runat="server" BackColor="Transparent" ForeColor="DarkRed"
                    Width="179px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 51px; background-color: beige">
                Department</td>
            <td style="width: 116px; background-color: beige">
                <asp:Label ID="lbldept" runat="server" BackColor="Transparent" ForeColor="DarkRed"></asp:Label></td>
            <td style="width: 34px; background-color: beige">
                Section</td>
            <td style="width: 301px; background-color: beige">
                <asp:Label ID="lblsect" runat="server" BackColor="Transparent" ForeColor="DarkRed"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 51px; background-color: beige">
                Designation</td>
            <td style="width: 116px; background-color: beige">
                <asp:Label ID="lbldesig" runat="server" BackColor="Transparent" ForeColor="DarkRed"></asp:Label></td>
            <td style="width: 34px; background-color: beige">
            </td>
            <td style="width: 301px; background-color: beige">
            </td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">
                VEHICLE DETAILS</td>
        </tr>
        <tr>
            <td style="width: 51px; height: 26px; background-color: beige">
                Vehicle Type</td>
            <td style="width: 116px; height: 26px; background-color: beige">
                <asp:TextBox ID="txtvtype" runat="server" Width="111px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtvtype"
                    ErrorMessage="!!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 34px; height: 26px; background-color: beige">
                Vehicle No.</td>
            <td style="width: 301px; height: 26px; background-color: beige">
                <asp:TextBox ID="txtvno" runat="server" Width="94px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtvno"
                    ErrorMessage="!!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 51px; background-color: beige">
                Allowance</td>
            <td colspan="3" style="background-color: beige">
                <asp:TextBox ID="txtallowance" runat="server" Width="109px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtallowance"
                    ErrorMessage="!!" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtallowance"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="a"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="height: 17px">
                <asp:Button ID="btnsave" runat="server" SkinID="buttonskin1" Text="Save" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 17px">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 17px">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
                    GridLines="None" PageSize="20" Width="466px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="tvehicleno" HeaderText="VehicleNo" SortExpression="tvehicleno" />
                        <asp:BoundField DataField="tvehicletype" HeaderText="VehicleType" SortExpression="tvehicletype" />
                        <asp:BoundField DataField="tallowance" HeaderText="Allowance" SortExpression="tallowance" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [empcode], [tvehicleno], [tallowance], [tvehicletype] FROM [trans_ownvehicle] ORDER BY [rno] DESC">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
