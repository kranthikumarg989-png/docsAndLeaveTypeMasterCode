<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Master_USDLimit.aspx.vb" Inherits="E_Management.Master_USDLimit" 
    title="USD master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<div align=center>
  <hr width="75%" color ="silver"  />
    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="Enter USD Limit for Business Trip"></asp:Label>
    <br />
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True"
     CellPadding="4" DataKeyNames="rno" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="rno" HeaderText="Rno" ReadOnly="True" SortExpression="rno" />
            <asp:TemplateField HeaderText="USD" SortExpression="amount">
                <EditItemTemplate>
                    <asp:TextBox ID="txttamt" runat="server" Text='<%# Bind("amount") %>'></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttamt" ErrorMessage="!"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txttamt" ErrorMessage="Enter only Numbers"
                            ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [amount], [rno] FROM [HRMIS_BT_USDLIMIT]"
        UpdateCommand = "update [HRMIS_BT_USDLIMIT] set amount = @amount where rno = @rno" >
         <UpdateParameters>
               <asp:Parameter Name=rno Type=String />   
         </UpdateParameters>
    </asp:SqlDataSource>

    
    
  <hr width="75%" color ="silver"  />
</div>
</asp:Content>
