<%@ Page Language="vb" AutoEventWireup="false" masterpagefile="~/ems.Master" CodeBehind="letter status.aspx.vb" Title="Letter Status" Inherits="E_Management.letter_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;
    <br />
    &nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Height="8px" ShowFooter="True" Style="left: 16px; position: relative; top: -69px"
        Width="992px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True" SortExpression="slno" />
            <asp:BoundField DataField="lettertype" HeaderText="lettertype" SortExpression="lettertype" />
            <asp:BoundField DataField="letter" HeaderText="letter" SortExpression="letter" />
            <asp:BoundField DataField="createdby" HeaderText="createdby" SortExpression="createdby" />
            <asp:BoundField DataField="createddate" HeaderText="createddate" SortExpression="createddate" />
            <asp:BoundField DataField="modifiedby" HeaderText="modifiedby" SortExpression="modifiedby" />
            <asp:BoundField DataField="modifieddate" HeaderText="modifieddate" SortExpression="modifieddate" />
            <asp:TemplateField HeaderText="status" SortExpression="status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Bind("status") %>'
                        Style="position: relative">
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                        <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                        <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" OnClick="UpdategpApproval" Style="position: relative" Text="Submit" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcon1 %>"
        SelectCommand="SELECT * FROM [HRMIS_ER_LETTER] where status=@sts ">
    <SelectParameters>
    <asp:Parameter name="sts" Type="string" DefaultValue="Scheduled" />
    </SelectParameters>
        </asp:SqlDataSource>
 </asp:Content>