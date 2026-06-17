<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptOTbudgetCSC.aspx.vb" Inherits="E_Management.RptOTbudgetCSC" 
    title="OT BUDGET CATEGORIZED BY DEPT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <br />
    OT BUDGET SETTING - BY DEPT CATEGORY &nbsp;
    <asp:Label ID="LBLFROM" runat="server" Text="Label"></asp:Label>
    TO
    <asp:Label ID="LBLTO" runat="server" Text="Label"></asp:Label><br />
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ShowFooter="True">
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:BoundField DataField="department" HeaderText="Department" ReadOnly="True" SortExpression="department" />
            <asp:TemplateField HeaderText="Category" SortExpression="Category">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Category") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="TOTAL"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Maxhours" SortExpression="maxhours">
                  <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("maxhours") %>'></asp:Label>
                  </ItemTemplate>
                  <FooterTemplate>
                       <asp:Label ID="Lbltotal" runat="server" Text="0" BackColor="#FFFF80" Font-Bold="True" ForeColor="#C04000"></asp:Label>
                  </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Gainsboro" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT  department.departmentcode +'-'+ department.departmentname as department ,tbl_MaxOTSetting.Category, &#13;&#10;SUM(tbl_MaxOTSetting.MaxHours) AS maxhours FROM  tbl_MaxOTSetting &#13;&#10;INNER JOIN sectionmaster ON tbl_MaxOTSetting.sect = sectionmaster.sectioncode &#13;&#10;INNER JOIN  department ON sectionmaster.departmentcode = department.departmentcode &#13;&#10;WHERE (tbl_MaxOTSetting.startdate = @FROM)&#13;&#10; AND (tbl_MaxOTSetting.enddate = @TO )AND ((tbl_MaxOTSetting.status = 'A')or (tbl_MaxOTSetting.status = 'S'))&#13;&#10; GROUP BY department.departmentname, tbl_MaxOTSetting.Category, department.departmentcode&#13;&#10; ORDER BY department.departmentcode &#13;&#10;">
        <SelectParameters>
            <asp:SessionParameter Name="FROM" SessionField="budgetfrom" />
            <asp:SessionParameter DefaultValue="" Name="TO" SessionField="budgetto" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
