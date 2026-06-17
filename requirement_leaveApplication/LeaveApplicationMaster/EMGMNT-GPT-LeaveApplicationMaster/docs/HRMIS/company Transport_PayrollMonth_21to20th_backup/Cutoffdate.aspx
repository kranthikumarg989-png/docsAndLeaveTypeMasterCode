<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Cutoffdate.aspx.vb" Inherits="E_Management.Cutoffdate" 
    title="CutOff Date" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        AutoGenerateEditButton="True" CellPadding="4" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
        <RowStyle BackColor="White" ForeColor="#330099" />
        <Columns>
            <asp:TemplateField HeaderText="CutOffDate" SortExpression="Targetdate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="2" Text='<%# Bind("Targetdate") %>'
                        Width="74px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                            runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Mention Cutoff Date"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                                ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="117px"></asp:RegularExpressionValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="Enter Number from 1 to 31" MaximumValue="31" MinimumValue="1"></asp:RangeValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Targetdate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT DISTINCT [Targetdate] FROM [cutoffdate]"
         UpdateCommand="Proc_cutoffdate" UpdateCommandType=StoredProcedure>
         <UpdateParameters>
         <asp:Parameter Name=targetdate Type=int16 />
         <asp:SessionParameter Name = mby SessionField=empcode Type=string />
         </UpdateParameters>
         
              
        </asp:SqlDataSource>

</asp:Content>
