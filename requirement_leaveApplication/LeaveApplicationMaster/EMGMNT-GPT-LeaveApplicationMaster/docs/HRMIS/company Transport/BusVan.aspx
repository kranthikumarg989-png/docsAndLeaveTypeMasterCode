<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BusVan.aspx.vb" Inherits="E_Management.BusVan" 
%>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 462px">
        <tr>
            <td class="td_head" colspan="4" style="height: 17px">
                BUS/VAN COST MASTER</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 17px">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                Route</td>
            <td style="width: 159px">
                <asp:DropDownList ID="ddlroute" runat="server" DataSourceID="SqlDataSource1" DataTextField="route"
                    DataValueField="route" AppendDataBoundItems="True">
                    <asp:ListItem Value="-1" Selected="True">-Select Type-</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlroute"
                    ErrorMessage="Select route" ValidationGroup="a" InitialValue="-1">!</asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Vehicle Type</td>
            <td style="width: 203px">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Bus</asp:ListItem>
                    <asp:ListItem>Van</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 11px;">
                Cost</td>
            <td style="width: 159px; height: 11px;">
                <asp:TextBox ID="TextBox1" runat="server" Width="87px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="Enter Cost" ValidationGroup="a">!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="!" ValidationExpression="^\d*$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
            <td style="width: 100px; height: 11px;">
                Capacity</td>
            <td style="width: 203px; height: 11px;">
                <asp:TextBox ID="TextBox2" runat="server" Width="90px">0</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="!" ValidationExpression="^\d*$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="height: 3px">
                <asp:Button ID="btnadd" runat="server" SkinID="buttonskin1" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 3px">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 133px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource2" ForeColor="#333333" Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateEditButton="True" PageSize="15" DataKeyNames="number">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:TemplateField HeaderText="Route" SortExpression="route">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="sqlroute" DataTextField="route"
                                    DataValueField="route" SelectedValue='<%# Bind("route") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="sqlroute" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT [route] FROM [trans_routemaster] ORDER BY [route]"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("route") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vehicle Type" SortExpression="typeofvehicle">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("typeofvehicle") %>'>
                                    <asp:ListItem>Bus</asp:ListItem>
                                    <asp:ListItem>Van</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("typeofvehicle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="cost" SortExpression="cost">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cost") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage="!" Text="Only Number" ValidationExpression="^\d*$" ValidationGroup="a"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("cost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Capacity" SortExpression="capacity">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("capacity") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2"
                                    ErrorMessage="!" Text="Only Number" ValidationExpression="^\d*$" ValidationGroup="a"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("capacity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [route] FROM [trans_routemaster] ORDER BY [route]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [route], [cost], [typeofvehicle], [capacity] ,number FROM [trans_cost] order by number desc"
         DeleteCommand = "delete from [trans_cost] where number =@number"
          UpdateCommand ="HRMIS_TRANSPORT_UPDATECOST" UpdateCommandType=StoredProcedure  >
        <DeleteParameters>
            <asp:Parameter Name="number" />
        </DeleteParameters>
        <UpdateParameters>
        <asp:Parameter Type=Int32 Name="number" />
        <asp:Parameter Type=String Name = "route" />
        <asp:Parameter Type=Int32 Name = "cost" />
        <asp:Parameter Type=Int32 Name = "capacity" />
        <asp:Parameter Type=String Name = "typeofvehicle" />
        <asp:SessionParameter Name=empname SessionField = empcode Type=string />
                
        
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
