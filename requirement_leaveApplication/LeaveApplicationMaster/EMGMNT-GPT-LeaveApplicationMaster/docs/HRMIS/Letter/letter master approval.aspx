<%@ Page Language="vb" AutoEventWireup="false" masterpagefile="~/ems.Master" title="Letter master approval" CodeBehind="letter master approval.aspx.vb" Inherits="E_Management.letter_master_approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Height="128px" ShowFooter="True" Style="left: 152px; position: relative; top: 8px"
        Width="848px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                SortExpression="slno" />
            <asp:BoundField DataField="lettername" HeaderText="lettername" SortExpression="lettername" />
            <asp:BoundField DataField="lettercontents" HeaderText="lettercontents" SortExpression="lettercontents" />
            <asp:BoundField DataField="revision" HeaderText="revision" SortExpression="revision" />
            <asp:TemplateField HeaderText="status" SortExpression="status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" OnClick="UpdategpApproval" Style="position: relative" Text="Submit" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"  Style="position: relative" Height="48px" Width="120px" SelectedValue='<%# Bind("status") %>' >
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                        <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                        <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                    </asp:RadioButtonList>
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
        SelectCommand="SELECT [slno], [lettername], [lettercontents], [revision], [status] FROM [HRMIS_ER_MASTER_LETTER] where status=@sts">
        <SelectParameters>
        <asp:Parameter Name="sts" Type="string" DefaultValue="Scheduled" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>