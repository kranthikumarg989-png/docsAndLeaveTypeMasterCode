<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="clinicbalancereportgrid.aspx.vb" Inherits="E_Management.clinicbalancereportgrid" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Blue" Text="Clinic Balance Report"></asp:Label>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BorderColor="Gray" BorderWidth="1px" CaptionAlign="Left" CellPadding="4"
        ForeColor="#333333" AllowSorting="True" PageSize="25">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
         <asp:TemplateField HeaderText="S.No">
            <EditItemTemplate>
            </EditItemTemplate>
                <ItemTemplate>
                      <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField DataField="Empno" HeaderText="EmpNo" SortExpression="Empno" />
            <asp:BoundField DataField="Empname" HeaderText="Employee Name" SortExpression="Empname" />
             <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
              <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
              <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
             <asp:BoundField DataField="Expr1" HeaderText="Bill" SortExpression="Expr1" />
            <asp:TemplateField HeaderText="Balance">
                <ItemTemplate>
                    <asp:Label ID="label" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Content>
