<%@ Page Language="vb" AutoEventWireup="false"  masterpagefile="~/ems.Master"  CodeBehind="Letter intro.aspx.vb" Inherits="E_Management.Letter_intro"  Title="Letter intro"%>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">


        `<br />
    <br />
    <br />
    <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
        &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Style="left: 16px; position: relative; top: 64px"
                Text="Letter Type"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" Style="left: 40px; position: relative;
                top: 64px" Width="88px">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>ER</asp:ListItem>
                <asp:ListItem>CMG</asp:ListItem>
            </asp:DropDownList><asp:TextBox ID="TextBox1" runat="server" Style="left: -46px; position: relative;
                top: 96px" Width="160px"></asp:TextBox><asp:Button ID="Button1" runat="server" Style="left: -214px; position: relative;
                top: 144px" Text="Save" BorderColor="Transparent" /><asp:Label ID="Label2" runat="server" Style="left: -350px; position: relative; top: 96px"
                Text="Letter Name"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:GridView ID="GridView1" runat="server" Style="left: 336px; position: relative;
            top: -92px" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="328px" Width="824px" AllowPaging="True" ShowFooter="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="slno" HeaderText="Slno" InsertVisible="False" ReadOnly="True"
                    SortExpression="slno" />
                <asp:BoundField DataField="letter" HeaderText="letter" SortExpression="letter" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                <asp:BoundField DataField="createdby" HeaderText="Createdby" SortExpression="createdby" />
                <asp:BoundField DataField="createddate" HeaderText="Createddate" SortExpression="createddate" />
                <asp:BoundField DataField="modifiedby" HeaderText="Modifiedby" SortExpression="modifiedby" />
                <asp:BoundField DataField="modifieddate" HeaderText="Modifieddate" SortExpression="modifieddate" />
                <asp:BoundField DataField="lettertype" HeaderText="Lettertype" SortExpression="lettertype" />
                <asp:TemplateField HeaderText="Delete">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Delete" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="Button2" runat="server" OnClick="UpdategpApproval" Style="position: relative"
                            Text="Submit" />
                    </FooterTemplate>
                </asp:TemplateField>
                             </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EmptyDataTemplate>
                <asp:Label ID="Label3" runat="server" Style="position: relative" Text="Label"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcon1 %>"
            SelectCommand="SELECT * FROM [HRMIS_ER_LETTER] order by slno"></asp:SqlDataSource>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
</asp:Content>
