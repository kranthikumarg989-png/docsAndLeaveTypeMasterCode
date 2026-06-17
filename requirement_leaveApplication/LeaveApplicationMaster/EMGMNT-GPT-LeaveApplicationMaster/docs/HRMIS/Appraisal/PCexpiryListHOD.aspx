<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PCexpiryListHOD.aspx.vb" Inherits="E_Management.PCexpiryListHOD" 
      title="Probation Expiry List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="STAFF PROBATION EXPIRY LIST" Width="535px"></asp:Label></td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridProbation" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="20">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                        <asp:LinkButton ID="Lnlappraisal" runat="server" Font-Underline="True" ForeColor="Blue"
                        OnCommand="Appraisal_view" Text='<%# Bind("empcode") %>' CommandArgument ='<%# Eval("empcode", "{0}") %>' ></asp:LinkButton>
                           </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
            <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="emptype" HeaderText="Emptype" SortExpression="emptype" />
            <asp:BoundField DataField="probation" HeaderText="Probation" SortExpression="probation" />
            <asp:BoundField DataField="dateofjoin" HeaderText="Dateofjoin" SortExpression="dateofjoin"  DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False"  />
            <asp:BoundField DataField="probationends" HeaderText="Prob.Exp on" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False"
                SortExpression="probationends" />
            <asp:BoundField DataField="diff" HeaderText="Days Remain" ReadOnly="True" SortExpression="diff" />
            <asp:TemplateField HeaderText="Appraisal &lt;br&gt; Done" SortExpression="appraisal">
                 <ItemTemplate>
                    <asp:Label ID="lblappraisal" runat="server" Text='<%# Bind("appraisal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
       
         
            
            
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="OPERATOR PROBATION EXPIRY LIST"
                    Width="535px"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="20">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnlappraisal" runat="server" CommandArgument='<%# Eval("empcode", "{0}") %>'
                                Font-Underline="True" ForeColor="Blue" OnCommand="Appraisal_view1" Text='<%# Bind("empcode") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                    <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                    <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                ID="Label3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="emptype" HeaderText="Emptype" SortExpression="emptype" />
                    <asp:BoundField DataField="probation" HeaderText="Probation" SortExpression="probation" />
                    <asp:BoundField DataField="dateofjoin" HeaderText="Dateofjoin" SortExpression="dateofjoin"  DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False"  />
                    <asp:BoundField DataField="probationends" HeaderText="Prob.Exp on" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" 
                SortExpression="probationends" />
                    <asp:BoundField DataField="diff" HeaderText="Days Remain" ReadOnly="True" SortExpression="diff" />
                    <asp:TemplateField HeaderText="Appraisal &lt;br&gt; Done" SortExpression="appraisal">
                        <ItemTemplate>
                            <asp:Label ID="lblappraisal" runat="server" Text='<%# Bind("appraisal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                </Columns>
            </asp:GridView>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 17px;">
            </td>
        </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="hrmis_appraisal_alert_hod_OPT" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter  Name="dept" SessionField="dept" Type="String" />
                        
                    </SelectParameters>                    
                </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="hrmis_appraisal_alert_hod" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter  Name="dept" SessionField="dept" Type="String" />
            <asp:SessionParameter Name="emp" SessionField="empcode" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
