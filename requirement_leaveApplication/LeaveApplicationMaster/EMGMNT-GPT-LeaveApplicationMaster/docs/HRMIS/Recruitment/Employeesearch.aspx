<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Employeesearch.aspx.vb" Inherits="E_Management.Employeesearch" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <br />
    &nbsp;<table>
        <tr>
            <td align="left" valign="top">
<table border="1" bordercolor="#000099">
    <tr>
        <td colspan="2" class="td_head">
            <strong>
            Employee Search</strong></td>
        </tr>
<tr>
<td bgcolor="beige" style="width: 6px">
    Select&nbsp; by</td>
<td >
<asp:DropDownList ID="ddl" runat="server" Width="153px">
        <asp:ListItem Value="n">Name</asp:ListItem>
        <asp:ListItem Value="e">Emp Code</asp:ListItem>
        <asp:ListItem Value="d">Department</asp:ListItem>
        <asp:ListItem Value="s">Section</asp:ListItem>
        <asp:ListItem Value="dsg">Designation</asp:ListItem>
    </asp:DropDownList></td>
</tr>
    <tr>
        <td bgcolor="beige" style="width: 6px">
            <asp:Label ID="Label" runat="server" Text="Key in" Width="72px"></asp:Label></td>
        <td>
            <asp:TextBox ID="keyin" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="td_head" colspan="2">
            <span style="text-decoration: underline"><strong>
            Optional Search(Filter)</strong></span></td>
    </tr>
    <tr>
        <td bgcolor="beige" style="width: 6px">
            <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label></td>
        <td>
            <asp:DropDownList ID="gnder" runat="server">
                <asp:ListItem Value="s">Select </asp:ListItem>
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td bgcolor="beige" style="width: 6px">
                <asp:Label ID="lblforeign" runat="server" Text="Foreign Emp" Width="78px"></asp:Label></td>
        <td>
            <asp:DropDownList ID="forn" runat="server">
                <asp:ListItem Value="s">Select</asp:ListItem>
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
    <td colspan="2" align="right">
        <asp:Label ID="errmsg" runat="server" Font-Underline="True" ForeColor="Red"></asp:Label>
        <asp:Button ID="search" runat="server" Text="Search" /></td>
    </tr>
</table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        BorderColor="Gray" BorderWidth="1px" CellPadding="4" ForeColor="#333333" PageSize="25" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
        <asp:TemplateField HeaderText="No">
        <ItemTemplate>
        <%# Container.DataItemIndex + 1 %>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Underline="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

