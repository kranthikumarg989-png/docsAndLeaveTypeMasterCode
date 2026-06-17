<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="supplierMaster.aspx.vb" Inherits="E_Management.supplierMaster" 
 %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 605px">
        <tr>
            <td class="td_head" colspan="4" style="height: 17px">
                SUPPLIER MASTER</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 17px">
                Supplier Name</td>
            <td style="width: 100px; height: 17px">
                <asp:TextBox ID="txtsupplier" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsupplier"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 17px">
                Address</td>
            <td style="width: 100px; height: 17px">
                <asp:TextBox ID="txtadrs" runat="server" TextMode="MultiLine" Width="149px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtadrs"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 17px;">
                Ic Number</td>
            <td style="width: 100px; height: 17px;">
                <asp:TextBox ID="txtIC" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIC"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 17px;">
                Fax</td>
            <td style="width: 100px; height: 17px;">
                <asp:TextBox ID="txtfax" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Phone no</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtPh" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
                HP No.</td>
            <td style="width: 100px">
                <asp:TextBox ID="txthp" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txthp"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 1px">
                Company Name</td>
            <td style="width: 100px;">
                <asp:TextBox ID="txtcompany" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcompany"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 1px">
                Company Regd.No</td>
            <td style="width: 100px; height: 1px">
                <asp:TextBox ID="txtcompregd" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Button ID="btnadd" runat="server" Text="ADD" SkinID="buttonskin1" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 336px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="Sqlsupplier" DataKeyNames="supplierno" ForeColor="#333333" GridLines="None" Width="80%" AllowPaging="True" AllowSorting="True" AutoGenerateEditButton="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="suppliername" HeaderText="SupplierName" SortExpression="suppliername" />
                        <asp:BoundField DataField="suppliericno" HeaderText="SupplierICNO" SortExpression="suppliericno" />
                        <asp:TemplateField HeaderText="Supplier Address" SortExpression="supplieraddress">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("supplieraddress") %>' TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("supplieraddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Supplier Phone No." SortExpression="supplierphoneno">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("supplierphoneno") %>' TextMode="SingleLine"></asp:TextBox>
                            <asp:RegularExpressionValidator id="R1" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="TextBox2"></asp:RegularExpressionValidator></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("supplierphoneno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="supplierphoneno" HeaderText="SupplierPhone" SortExpression="supplierphoneno" />
                        <asp:BoundField DataField="supplierhp" HeaderText="SupplierHP" SortExpression="supplierhp" />
                        <%--<asp:TemplateField HeaderText="Supplier HP No." SortExpression="supplierhp">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("supplierhp") %>' TextMode="SingleLine"></asp:TextBox>
                            <asp:RegularExpressionValidator id="R2" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="TextBox3"></asp:RegularExpressionValidator></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("supplierhp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="supplierfax" HeaderText="SupplierFax" SortExpression="supplierfax" />
                        <%--<asp:TemplateField HeaderText="Supplier Fax" SortExpression="supplierfax">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("supplierfax") %>' TextMode="SingleLine"></asp:TextBox>
                            <asp:RegularExpressionValidator id="R4" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="TextBox4"></asp:RegularExpressionValidator></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("supplierfax") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="companyname" HeaderText="CompanyName" SortExpression="companyname" />
                        <%--<asp:TemplateField HeaderText="Company Name" SortExpression="companyname">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("companyname") %>' TextMode="SingleLine"></asp:TextBox>
                            <asp:RegularExpressionValidator id="R5" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="TextBox5"></asp:RegularExpressionValidator></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("supplierfax") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="companyregdno" HeaderText="CompanyRegdno" SortExpression="companyregdno" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="Sqlsupplier" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT supplierno,[suppliername], [supplieraddress], [supplierphoneno], [supplierhp], [suppliericno], [companyname], [companyregdno], [supplierfax] FROM [trans_supplier] ORDER BY [createdtime] DESC"
                    DeleteCommand = "delete from trans_supplier where supplierno = @supplierno"
                    UpdateCommand ="HRMIS_TRANSPORT_UPDATESUP" UpdateCommandType =StoredProcedure>
                                  <UpdateParameters >
                            <asp:Parameter Name=supplierno Type=Int16  />
                    <asp:Parameter Name = suppliername Type=string />
                    <asp:Parameter Name = supplieraddress Type=string />
                    <asp:Parameter Name = supplierphoneno Type=string />
                    <asp:Parameter Name = supplierhp Type=string />
                    <asp:Parameter Name = supplierfax Type=string />                    
                    <asp:Parameter Name = suppliericno Type=string />
                    <asp:Parameter Name = companyname Type=string />
                    <asp:Parameter Name = companyregdno Type=string />
                            <asp:SessionParameter Name=empname SessionField = empcode Type=string />
            
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
