<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PCExpiryListCommon.aspx.vb" Inherits="E_Management.PCExpiryListCommon" 
    title="Probation / Contract Expiry List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="STAFF PROBATION EXPIRY LIST" Width="446px"></asp:Label></td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridProbation" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" PageSize="20">
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
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("empcode") %>'
                    CausesValidation="false" CommandArgument='<%# Eval("empcode", "{0}") %>'
                        ForeColor="BLUE" OnCommand="rptappraisal" ></asp:LinkButton>
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
            <asp:BoundField DataField="dateofjoin" HeaderText="Dateofjoin" SortExpression="dateofjoin"  DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" />
            <asp:BoundField DataField="probationends" HeaderText="Prob.Exp on" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False"
                SortExpression="probationends" />
            <asp:BoundField DataField="diff" HeaderText="Days Remain" ReadOnly="True" SortExpression="diff" />
            <asp:TemplateField HeaderText="Appraisal &lt;br&gt; Done" SortExpression="appraisal">
                 <ItemTemplate>
                    <asp:Label ID="lblappraisal" runat="server" Text='<%# Bind("appraisal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
       <asp:BoundField DataField="confirmd" HeaderText="Employement Status" SortExpression="confirmd" />
            
            
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="OPERATOR PROBATION EXPIRY LIST"
                    Width="446px"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" PageSize="20">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                 <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
            
                <ItemTemplate>
                    <asp:Label ID="lblopt" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                    <asp:LinkButton ID="LinkButtonopt" runat="server" Text='<%# Eval("empcode") %>'
                    CausesValidation="false" CommandArgument='<%# Eval("empcode", "{0}") %>'
                        ForeColor="BLUE" OnCommand="rptappraisal_opt" ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
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
                    <asp:BoundField DataField="dateofjoin" HeaderText="Dateofjoin" SortExpression="dateofjoin"  DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" />
                    <asp:BoundField DataField="probationends" HeaderText="Prob.Exp on" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" 
                SortExpression="probationends" />
                    <asp:BoundField DataField="diff" HeaderText="Days Remain" ReadOnly="True" SortExpression="diff" />
                    <asp:TemplateField HeaderText="Appraisal &lt;br&gt; Done" SortExpression="appraisal">
                        <ItemTemplate>
                            <asp:Label ID="lblappraisalo" runat="server" Text='<%# Bind("appraisal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    <asp:BoundField DataField="confirmd" HeaderText="Employement Status" SortExpression="confirmd" />
                </Columns>
            </asp:GridView>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
                
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
         SelectCommand="hrmis_appraisal_alert" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
         SelectCommand="hrmis_appraisal_alert_OPT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
     </asp:Content>
