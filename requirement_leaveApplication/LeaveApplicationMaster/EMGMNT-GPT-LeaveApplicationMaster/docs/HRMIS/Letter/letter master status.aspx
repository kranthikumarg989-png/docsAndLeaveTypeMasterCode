<%@ Page Language="vb" AutoEventWireup="false" masterpagefile="~/ems.Master"  CodeBehind="letter master status.aspx.vb" title="Letter master Status" Inherits="E_Management.letter_master_status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;
    <br />
    &nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Style="left: 32px; position: relative; top: -38px" ShowFooter="True" Width="896px" Height="344px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
         <asp:BoundField DataField="slno" HeaderText="Slno" InsertVisible="False" ReadOnly="True" SortExpression="slno" />
            <asp:BoundField DataField="lettername" HeaderText="Lettername" SortExpression="lettername" />
            <asp:BoundField DataField="lettercontents" HeaderText="Lettercontents" SortExpression="lettercontents" />
            <asp:BoundField DataField="revision" HeaderText="Revision" SortExpression="revision" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            <asp:TemplateField HeaderText="Close" SortExpression="clse">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("clse") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="UpdategpApproval" Style="position: relative"
                        Text="Submit" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal"
                         Style="left: 8px; position: relative; top: 0px" Width="72px">
                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        <asp:ListItem Value="No">No</asp:ListItem>
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
        SelectCommand="SELECT [lettername], [lettercontents], [revision], [status], [clse], [slno] FROM [HRMIS_ER_MASTER_LETTER] where clse=@clssts">
        <SelectParameters>
        <asp:Parameter Name="clssts"  Type="string" DefaultValue="No" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
