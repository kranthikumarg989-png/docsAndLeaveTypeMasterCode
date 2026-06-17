<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptbudgetOTallDept.aspx.vb" Inherits="E_Management.RptbudgetOTallDept" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <br />
    OT BUDGET SETTING FROM&nbsp;
    <asp:Label ID="LBLFROM" runat="server" Text="Label"></asp:Label>
    TO
    <asp:Label ID="LBLTO" runat="server" Text="Label"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="startdate" HeaderText="Startdate" SortExpression="startdate"  DataFormatString="{0:dd-MM-yyyy}"  />
            <asp:BoundField DataField="enddate" HeaderText="Enddate" SortExpression="enddate"  DataFormatString="{0:dd-MM-yyyy}" />
            <asp:TemplateField HeaderText="Section" SortExpression="sectioncode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("sectioncode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("sectioncode") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sectionname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department" SortExpression="departmentcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                        ID="Label4" runat="server" Text='<%# Eval("departmentname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:TemplateField HeaderText="MaxHours" SortExpression="MaxHours">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("MaxHours") %>'></asp:Label>
                </ItemTemplate>
                  <FooterTemplate>
                       <asp:Label ID="lbltot" runat="server" Text="0" BackColor="#FFFF80" Font-Bold="True" ForeColor="#C04000"></asp:Label>
                  </FooterTemplate>
            </asp:TemplateField>
               <asp:BoundField DataField="Status" HeaderText="status" SortExpression="status" />
        </Columns>
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT tbl_MaxOTSetting.status,tbl_MaxOTSetting.startdate, sectionmaster.sectioncode, department.departmentcode, tbl_MaxOTSetting.enddate, tbl_MaxOTSetting.sect, tbl_MaxOTSetting.Category, tbl_MaxOTSetting.MaxHours, sectionmaster.sectionname, department.departmentname &#13;&#10;FROM tbl_MaxOTSetting tbl_MaxOTSetting&#13;&#10;&#9; INNER JOIN (sectionmaster sectionmaster&#13;&#10;&#9;&#9; INNER JOIN department department&#13;&#10;&#9;&#9;&#9; ON (sectionmaster.departmentcode = department.departmentcode))&#13;&#10;&#9;&#9; ON (tbl_MaxOTSetting.sect = sectionmaster.sectioncode) &#13;&#10;WHERE tbl_MaxOTSetting.startdate >=@from&#13;&#10;&#13;&#10;AND tbl_MaxOTSetting.enddate <=@to">
        <SelectParameters>
            <asp:SessionParameter Name="from" SessionField="budgetfrom" />
            <asp:SessionParameter DefaultValue="" Name="to" SessionField="budgetto" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
