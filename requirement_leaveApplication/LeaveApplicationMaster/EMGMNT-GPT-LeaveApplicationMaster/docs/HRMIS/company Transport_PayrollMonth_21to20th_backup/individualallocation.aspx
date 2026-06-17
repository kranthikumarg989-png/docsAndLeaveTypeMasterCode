<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="individualallocation.aspx.vb" Inherits="E_Management.individualallocation" 
   %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="2" style="width: 538px">
        <tr>
            <td align="center" class="td_head" colspan="4" style="height: 17px" valign="middle">
                EMPLOYEE DETAILS</td>
        </tr>
        <tr>
            <td style="width: 60px; height: 17px; background-color: beige">
                EmpCode</td>
            <td style="width: 114px">
                <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Width="131px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="R3" runat="server" ControlToValidate="txtempcode"
                    ErrorMessage="!"></asp:RequiredFieldValidator></td>
            <td style="width: 71px; background-color: beige">
                EmpName</td>
            <td style="width: 108px; background-color: beige">
                <asp:Label ID="lblename" runat="server" BackColor="Transparent" ForeColor="DarkRed"
                    Width="179px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 60px; background-color: beige">
                Department</td>
            <td style="width: 114px; background-color: beige">
                <asp:Label ID="lbldept" runat="server" BackColor="Transparent" ForeColor="DarkRed"></asp:Label></td>
            <td style="width: 71px; background-color: beige">
                Section</td>
            <td style="width: 108px; background-color: beige">
                <asp:Label ID="lblsect" runat="server" BackColor="Transparent" ForeColor="DarkRed"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 60px; background-color: beige">
                Designation</td>
            <td style="width: 114px; background-color: beige">
                <asp:Label ID="lbldesig" runat="server" BackColor="Transparent" ForeColor="DarkRed"></asp:Label></td>
            <td style="width: 71px; color: #000000; background-color: beige">
            </td>
            <td style="width: 108px; color: #000000; background-color: beige">
            </td>
        </tr>
        <tr style="color: #000000">
            <td class="td_head" colspan="4">
                VEHICLE DETAILS</td>
        </tr>
        <tr>
            <td style="width: 60px; height: 6px; background-color: beige">
                Route</td>
            <td style="width: 114px; height: 6px; background-color: beige">
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
                    DataSourceID="SqlDataSource1" DataTextField="route" DataValueField="route">
                    <asp:ListItem Selected="True" Value="-1">--Select route--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
                    ErrorMessage="Select route" InitialValue="-1"></asp:RequiredFieldValidator></td>
            <td style="width: 71px; height: 6px; background-color: beige">
                Area</td>
            <td style="width: 108px; height: 6px; background-color: beige">
                &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True"
                    DataSourceID="SqlDataSource2" DataTextField="area" DataValueField="area">
                    <asp:ListItem Selected="True" Value="-1">--Select area--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2"
                    ErrorMessage="Select area" InitialValue="-1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="height: 17px">
                &nbsp;<asp:Button ID="btnsave" runat="server" SkinID="buttonskin1" Text="Save" /></td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 17px">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 17px" valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" Width="462px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
                        <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
                        <asp:BoundField DataField="transportneeded" HeaderText="Transportneeded" SortExpression="transportneeded" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [empcode], [empname], [area], [route], [transportneeded] FROM [empmaster] WHERE ([empcode] = @empcode)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtempcode" Name="empcode" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [route] FROM [trans_routemaster] ORDER BY [route]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [area] FROM [trans_areamaster] ORDER BY [area]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
