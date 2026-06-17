<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="domesticwastereportgrid.aspx.vb" Inherits="E_Management.domesticwastereportgrid" 
    title="Schedule/ Domestic Waste Report By Items" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;SCHEDULE/ DOMESTIC WASTE REPORT BY ITEMS<br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CaptionAlign="Left" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" ShowFooter="True" GridLines="None">
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
            <asp:BoundField DataField="Expr1" HeaderText="Consign. Note No." SortExpression="Expr1" />
            <asp:BoundField DataField="Expr5" HeaderText="PO. No." SortExpression="Expr5" />
            <asp:TemplateField HeaderText="Weight" SortExpression="Expr2">
                <EditItemTemplate>
                               </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Expr2") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="addtotal"  runat="server" Text=  "lll"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Expr3" HeaderText="Date Disposal" SortExpression="Expr3" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false"/>
            <asp:BoundField DataField="Expr4" HeaderText="Supplier Name" SortExpression="Expr4" />
            </Columns>
    </asp:GridView>
    <asp:Label ID="total" runat="server"></asp:Label>
   </asp:Content>
