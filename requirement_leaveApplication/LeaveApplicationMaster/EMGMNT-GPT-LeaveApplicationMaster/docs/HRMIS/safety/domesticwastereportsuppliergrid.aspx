<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="domesticwastereportsuppliergrid.aspx.vb" Inherits="E_Management.domesticwastereportsuppliergrid" 
    title="Schedule/ Domestic Waste Reports By Supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;SCEHDULE/ DOMESTIC WASTE REPORTS BY SUPPLIER
    <br />
    <asp:GridView ID="GridView1" runat="server" CaptionAlign="Left" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
       <asp:TemplateField HeaderText="No">
            <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                      <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Expr5" HeaderText="Major Type" SortExpression="Expr5" />
            <asp:BoundField DataField="Expr6" HeaderText="Items" SortExpression="Expr6" />
            <asp:BoundField DataField="Expr1" HeaderText="Consign. Note No" SortExpression="Expr1" />
            <asp:BoundField DataField="Expr7" HeaderText="PO. No." SortExpression="Expr7" />
            <asp:BoundField DataField="Expr2" HeaderText="Weight" SortExpression="Expr2" />
            <asp:BoundField DataField="Expr3" HeaderText="Date Disposal" SortExpression="Expr3" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false"/>
            <asp:BoundField DataField="Expr4" HeaderText="Supplier Name" SortExpression="Expr4" />
            </Columns>
    </asp:GridView>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;
    <asp:Label ID="total" runat="server"></asp:Label>
</asp:Content>
