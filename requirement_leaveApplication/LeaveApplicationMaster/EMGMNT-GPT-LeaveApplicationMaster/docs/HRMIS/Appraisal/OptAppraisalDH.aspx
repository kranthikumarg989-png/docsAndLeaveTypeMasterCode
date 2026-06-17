<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OptAppraisalDH.aspx.vb" Inherits="E_Management.OptAppraisalDH" 
    title="Operator Appraisal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Underline="True" Text="Operator Appraisal Done by Section Head"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <itemtemplate>
</itemtemplate>
                           <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="True" ForeColor="Blue"
                        OnCommand="Appraisal_view" Text='<%# Bind("empcode") %>' CommandArgument ='<%# Eval("rno", "{0}") %>' ></asp:LinkButton>
           
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="dateofappraisal" HeaderText="Appraisal Date" SortExpression="dateofappraisal" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="purposeofappraisal" HeaderText="Purpose" SortExpression="purposeofappraisal" />
            <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
            <asp:BoundField DataField="grade" HeaderText="Grade" SortExpression="grade" />
            <asp:BoundField DataField="remarks" HeaderText="SH Remarks" SortExpression="remarks" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT app_operatorappraisal.empcode, app_operatorappraisal.dateofappraisal,  app_operatorappraisal.rno, app_operatorappraisal.purposeofappraisal, app_operatorappraisal.total, app_operatorappraisal.remarks, app_operatorappraisal.status, app_operatorappraisal.grade, empmaster.empname, empmaster.sectioncode, empmaster.departmentcode, empmaster.empcode AS Expr1 FROM app_operatorappraisal INNER JOIN empmaster ON app_operatorappraisal.empcode = empmaster.empcode WHERE (app_operatorappraisal.status = @status) AND (empmaster.departmentcode = @dept) order by rno desc">
        <SelectParameters>
            <asp:Parameter  Name="status" Type="String" />
            <asp:SessionParameter Name="dept" SessionField="dept" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
