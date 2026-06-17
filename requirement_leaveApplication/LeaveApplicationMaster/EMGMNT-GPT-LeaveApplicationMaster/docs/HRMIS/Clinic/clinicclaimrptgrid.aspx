<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="clinicclaimrptgrid.aspx.vb" Inherits="E_Management.clinicclaimrptgrid" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Blue" Text="CLINIC CLAIM REPORT"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BorderColor="Gray" BorderWidth="1px" CaptionAlign="Left" CellPadding="4"
        ForeColor="#333333" ShowFooter="True" AllowSorting="True" PageSize="25">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
         <asp:TemplateField HeaderText="S.No">
            <EditItemTemplate>
            </EditItemTemplate>
                <ItemTemplate>
                      <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField DataField="Empcode" HeaderText="EmpNo" SortExpression="Empcode" />
            <asp:BoundField DataField="Empname" HeaderText="EmpName" SortExpression="Empname" />
             <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
              <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="clinicname" HeaderText="Consult Clinic" SortExpression="clinicname" />
            <asp:TemplateField HeaderText="Date of Consult" SortExpression="DateCheck" >
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateCheck", "{0:dd-MM-yyy}") %>'></asp:Label>
                </ItemTemplate>
               <FooterTemplate>
                            <asp:Label ID="lbl1" runat="server" Text="Total="></asp:Label>
               </FooterTemplate>
                      </asp:TemplateField>
            <asp:TemplateField HeaderText="Billamount" SortExpression="billamount">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("billamount") %>'></asp:Label>
                </ItemTemplate>
                 <FooterTemplate>
                 <asp:Label ID="lbl2" runat="server" Text="0"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="claim" HeaderText="claim" SortExpression="claim" />
            </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>

</asp:Content>
