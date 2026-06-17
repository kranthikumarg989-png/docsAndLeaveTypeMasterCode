<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Route Master.aspx.vb" Inherits="E_Management.Route_Master" Theme="buttonems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table align=center style="width: 356px" >
        <tr>
            <td class="td_head" colspan="2">
                ROUTE MASTER</td>
        </tr>
        <tr>
            <td style="width: 86px">
                Route code</td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="Enter Route code !!!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 86px">
                route Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox2" runat="server" Width="141px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Route Name!!!"
                    ValidationGroup="a" Width="102px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 86px">
            </td>
            <td align="right" style="width: 100px">
                <asp:Button ID="btnadd" runat="server" SkinID="buttonskin1" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="Sqlroute" ForeColor="#333333"
                    GridLines="None" Width="374px" DataKeyNames="RouteCode,Route">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="routecode" HeaderText="RouteCode" SortExpression="routecode" />
                        <asp:BoundField DataField="route" HeaderText="RouteName" SortExpression="route" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="Sqlroute" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [routecode], [route] FROM [trans_routemaster] ORDER BY [route]"
                     DeleteCommand = "delete from trans_routemaster where routecode = @routecode and route=@route" >
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

</asp:Content>
