<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptbudgetOverall.aspx.vb" Inherits="E_Management.RptbudgetOverall" 
    title="Report Overall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <br />
    Overall OT budget&nbsp;
    <asp:Label ID="LBLFROM" runat="server" Text="Label"></asp:Label>
    TO
    <asp:Label ID="LBLTO" runat="server" Text="Label"></asp:Label><br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="startdate" HeaderText="startdate" SortExpression="startdate"  DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false"/>
            <asp:BoundField DataField="enddate" HeaderText="Enddate" SortExpression="enddate"  DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
            <asp:BoundField DataField="maxhours" HeaderText="Maxhours" ReadOnly="True" SortExpression="maxhours" />
        </Columns>
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT tbl_MaxOTSetting.Category, tbl_MaxOTSetting.startdate, tbl_MaxOTSetting.enddate,  Sum(tbl_MaxOTSetting.MaxHours)  AS maxhours &#13;&#10;FROM (tbl_MaxOTSetting tbl_MaxOTSetting&#13;&#10;&#9; INNER JOIN sectionmaster sectionmaster&#13;&#10;&#9;&#9; ON (tbl_MaxOTSetting.sect = sectionmaster.sectioncode)&#13;&#10;&#9; INNER JOIN department department&#13;&#10;&#9;&#9; ON (sectionmaster.departmentcode = department.departmentcode)) &#13;&#10;WHERE ((tbl_MaxOTSetting.startdate =@from) AND (tbl_MaxOTSetting.enddate = @to))&#13;&#10; AND ((tbl_MaxOTSetting.status = 'A') or (tbl_MaxOTSetting.status = 's')) &#13;&#10;GROUP BY tbl_MaxOTSetting.enddate, tbl_MaxOTSetting.Category, tbl_MaxOTSetting.startdate">
        <SelectParameters>
            <asp:SessionParameter Name="from" SessionField="budgetfrom" />
            <asp:SessionParameter Name="to" SessionField="budgetto" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
