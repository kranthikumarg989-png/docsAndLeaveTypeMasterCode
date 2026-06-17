<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MMBT.aspx.vb" Inherits="E_Management.MMBT" 
title="Maruwa Group of Companies -Business Trip "  %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label id="Label1" runat="server" ForeColor="#C00000" Font-Bold="True" Text="BUSINESS TRIP RECORDS - MARUWA MALAYSIA" Font-Underline="True"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" BorderColor="Gray" AllowPaging="True" BorderWidth="1px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Departmentcode" SortExpression="departmentcode" />
            <asp:BoundField DataField="sectioncode" HeaderText="Sectioncode" SortExpression="sectioncode" />
            <asp:BoundField DataField="app_date" HeaderText="App_date" SortExpression="app_date" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false" />
            <asp:BoundField DataField="noofcolleague" HeaderText="Noofcolleague" SortExpression="noofcolleague" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false"  />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false"  />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
        SelectCommand="select acc_businesstrip.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,acc_businesstrip.fromdate,acc_businesstrip.todate,CONVERT(VARCHAR(10),app_date,110)as app_date,acc_businesstrip.noofcolleague&#13;&#10;from empmaster inner join acc_businesstrip on &#13;&#10;empmaster.empcode=acc_businesstrip.empcode where fromdate=@appldate">
 <SelectParameters>
 <asp:Parameter Name="appldate" />
 </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    
<asp:Label id="Label2" runat="server" ForeColor="#C00000" Font-Bold="True" Text="BUSINESS TRIP RECORDS - MARUWA MELAKA" Font-Underline="True" Visible="False"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource2" ForeColor="#333333" BorderColor="Gray" AllowPaging="True" BorderWidth="1px" Visible="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Departmentcode" SortExpression="departmentcode" />
            <asp:BoundField DataField="sectioncode" HeaderText="Sectioncode" SortExpression="sectioncode" />
            <asp:BoundField DataField="app_date" HeaderText="App_date" SortExpression="app_date" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="noofcolleague" HeaderText="Noofcolleague" SortExpression="noofcolleague" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
        SelectCommand="select acc_businesstrip.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,acc_businesstrip.fromdate,acc_businesstrip.todate,CONVERT(VARCHAR(10),app_date,110)as app_date,acc_businesstrip.noofcolleague&#13;&#10;from empmaster inner join acc_businesstrip on &#13;&#10;empmaster.empcode=acc_businesstrip.empcode where fromdate=@appldate">
 <SelectParameters>
 <asp:Parameter Name="appldate" />
 </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:Label id="Label3" runat="server" ForeColor="#C00000" Font-Bold="True" Text="BUSINESS TRIP RECORDS - MARUWA LIGHTINGS" Font-Underline="True" Visible="False"></asp:Label>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource3" ForeColor="#333333" BorderColor="Gray" AllowPaging="True" BorderWidth="1px" Visible="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Departmentcode" SortExpression="departmentcode" />
            <asp:BoundField DataField="sectioncode" HeaderText="Sectioncode" SortExpression="sectioncode" />
            <asp:BoundField DataField="app_date" HeaderText="App_date" SortExpression="app_date" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="noofcolleague" HeaderText="Noofcolleague" SortExpression="noofcolleague" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis %>"
        SelectCommand="select acc_businesstrip.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,acc_businesstrip.fromdate,acc_businesstrip.todate,CONVERT(VARCHAR(10),app_date,110)as app_date,acc_businesstrip.noofcolleague&#13;&#10;from empmaster inner join acc_businesstrip on &#13;&#10;empmaster.empcode=acc_businesstrip.empcode where fromdate=@appldate">
 <SelectParameters>
 <asp:Parameter Name="appldate" />
 </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:Label id="Label4" runat="server" ForeColor="#C00000" Font-Bold="True" Text="BUSINESS TRIP RECORDS - MARUWA OUTSOURCE" Font-Underline="True"></asp:Label>
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource4" ForeColor="#333333" BorderColor="Gray" AllowPaging="True" BorderWidth="1px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Departmentcode" SortExpression="departmentcode" />
            <asp:BoundField DataField="sectioncode" HeaderText="Sectioncode" SortExpression="sectioncode" />
            <asp:BoundField DataField="app_date" HeaderText="App_date" SortExpression="app_date" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false" />
            <asp:BoundField DataField="noofcolleague" HeaderText="Noofcolleague" SortExpression="noofcolleague" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false"  />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false"  />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:OutsourceHRMIS%>"
        SelectCommand="select acc_businesstrip.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,acc_businesstrip.fromdate,acc_businesstrip.todate,CONVERT(VARCHAR(10),app_date,110)as app_date,acc_businesstrip.noofcolleague&#13;&#10;from empmaster inner join acc_businesstrip on &#13;&#10;empmaster.empcode=acc_businesstrip.empcode where fromdate=@appldate">
 <SelectParameters>
 <asp:Parameter Name="appldate" />
 </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

