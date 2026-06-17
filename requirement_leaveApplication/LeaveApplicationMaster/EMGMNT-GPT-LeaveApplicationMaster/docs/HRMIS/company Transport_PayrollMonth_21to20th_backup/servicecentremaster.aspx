<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="servicecentremaster.aspx.vb" Inherits="E_Management.servicecentre" 
%>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 328px">
        <tr>
            <td class="td_head" colspan="2">
                SERVICE CENTRE MASTER</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Centre Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox2" runat="server" Width="171px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Adddress1</td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="173px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 35px;">
                Address2</td>
            <td style="width: 100px; height: 35px;">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="174px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td align="right" style="width: 100px">
                <asp:Button ID="Button1" runat="server" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" AutoGenerateEditButton="True"
                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                    Width="280px" DataKeyNames=rno>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="centre" HeaderText="Centre" SortExpression="centre" />
                        <asp:TemplateField HeaderText="Address1" SortExpression="address1">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("address1") %>' TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("address1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address2" SortExpression="address2">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("address2") %>' TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("address2") %>'></asp:Label>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM [servicecentre] ORDER BY [rno] DESC"
                    DeleteCommand ="delete from servicecentre where rno=@rno"
                    UpdateCommand ="update servicecentre set address1=@address1,address2=@address2,centre=@centre where rno=@rno">
                        <UpdateParameters >
                        <asp:Parameter Name=address1 Type=string />
                        <asp:Parameter Name=address2 Type=string />
                        <asp:Parameter Name=centre Type=string />
                        </UpdateParameters>           
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
