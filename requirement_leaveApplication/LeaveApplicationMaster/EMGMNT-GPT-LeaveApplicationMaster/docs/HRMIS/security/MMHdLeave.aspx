<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MMHdLeave.aspx.vb" Inherits="E_Management.MMHdLeave" 
    title="Maruwa Group of Companies- Half-Day Leave " %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label id="Label1" runat="server" ForeColor="#C00000" Font-Bold="True" Text="HALF-DAY LEAVE - MARUWA MALAYSIA" Font-Underline="True"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" Height="1px" Width="720px" BorderColor="#000001" BorderWidth="1px" BackColor="Gray">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empno" HeaderText="Empcode" SortExpression="empno" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
            <asp:BoundField DataField="approvedby" HeaderText="Approvedby" SortExpression="approvedby" />
            <asp:BoundField DataField="applicationdate" HeaderText="Applicationdate" SortExpression="applicationdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="false" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="false" />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="false" />
            <asp:BoundField DataField="workfor" HeaderText="No of day" SortExpression="workfor" />
            <asp:BoundField DataField="leavetime" HeaderText="Leavetime" SortExpression="leavetime" dataformatstring="{0:t}"  HtmlEncode="false" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
        SelectCommand="select leaveform.empno,empmaster.empname,leaveform.department,leaveform.approvedby,leaveform.applicationdate,leaveform.fromdate,leaveform.todate,leaveform.workfor,leaveform.leavetime,leaveform.status&#13;&#10;from empmaster inner join leaveform on empmaster.empcode=leaveform.empno where (status='Approved' or status='S')and fromdate=@apdate and ((workfor = '0.5') or (carryfwd='Y' and nocf='0.5' and workfor='0'))">
        <SelectParameters>
        <asp:Parameter Name="apdate" />
        </SelectParameters>
            </asp:SqlDataSource>
    &nbsp;
<asp:Label id="Label2" runat="server" ForeColor="#C00000" Font-Bold="True" Text="HALF-DAY LEAVE - MARUWA MELAKA" Font-Underline="True" Visible="False"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" Height="1px" Width="720px" BorderColor="#000001" BorderWidth="1px" BackColor="Gray" Visible="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empno" HeaderText="Empcode" SortExpression="empno" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
            <asp:BoundField DataField="approvedby" HeaderText="Approvedby" SortExpression="approvedby" />
            <asp:BoundField DataField="applicationdate" HeaderText="Applicationdate" SortExpression="applicationdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="workfor" HeaderText="No of day" SortExpression="workfor" />
            <asp:BoundField DataField="leavetime" HeaderText="Leavetime" SortExpression="leavetime" dataformatstring="{0:t}"  HtmlEncode="False" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
        SelectCommand="select leaveform.empno,empmaster.empname,leaveform.department,leaveform.approvedby,leaveform.applicationdate,leaveform.fromdate,leaveform.todate,leaveform.workfor,leaveform.leavetime,leaveform.status&#13;&#10;from empmaster inner join leaveform on empmaster.empcode=leaveform.empno where (status='Approved' or status='S')and fromdate=@apdate and ((workfor = '0.5') or (carryfwd='Y' and nocf='0.5' and workfor='0'))">
        <SelectParameters>
        <asp:Parameter Name="apdate" />
        </SelectParameters>
            </asp:SqlDataSource>
    &nbsp;
    <asp:Label id="Label3" runat="server" ForeColor="#C00000" Font-Bold="True" Text="HALF-DAY LEAVE - MARUWA LIGHTINGS" Font-Underline="True" Visible="False"></asp:Label>
    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" Height="1px" Width="720px" BorderColor="#000001" BorderWidth="1px" BackColor="Gray" Visible="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empno" HeaderText="Empcode" SortExpression="empno" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
            <asp:BoundField DataField="approvedby" HeaderText="Approvedby" SortExpression="approvedby" />
            <asp:BoundField DataField="applicationdate" HeaderText="Applicationdate" SortExpression="applicationdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="workfor" HeaderText="No of day" SortExpression="workfor" />
            <asp:BoundField DataField="leavetime" HeaderText="Leavetime" SortExpression="leavetime" dataformatstring="{0:t}"  HtmlEncode="False" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis  %>"
        SelectCommand="select leaveform.empno,empmaster.empname,leaveform.department,leaveform.approvedby,leaveform.applicationdate,leaveform.fromdate,leaveform.todate,leaveform.workfor,leaveform.leavetime,leaveform.status&#13;&#10;from empmaster inner join leaveform on empmaster.empcode=leaveform.empno where (status='Approved' or status='S')and fromdate=@apdate and ((workfor = '0.5') or (carryfwd='Y' and nocf='0.5' and workfor='0'))">
        <SelectParameters>
        <asp:Parameter Name="apdate" />
        </SelectParameters>
            </asp:SqlDataSource>
    &nbsp;
    <asp:Label id="Label4" runat="server" ForeColor="#C00000" Font-Bold="True" Text="HALF-DAY LEAVE - MARUWA OUTSOURCE" Font-Underline="True"></asp:Label>
    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource4" ForeColor="#333333" Height="1px" Width="720px" BorderColor="#000001" BorderWidth="1px" BackColor="Gray">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empno" HeaderText="Empcode" SortExpression="empno" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
            <asp:BoundField DataField="approvedby" HeaderText="Approvedby" SortExpression="approvedby" />
            <asp:BoundField DataField="applicationdate" HeaderText="Applicationdate" SortExpression="applicationdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="workfor" HeaderText="No of day" SortExpression="workfor" />
            <asp:BoundField DataField="leavetime" HeaderText="Leavetime" SortExpression="leavetime" dataformatstring="{0:t}"  HtmlEncode="False" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:OutsourceHRMIS%>"
        SelectCommand="select leaveform.empno,empmaster.empname,leaveform.department,leaveform.approvedby,leaveform.applicationdate,leaveform.fromdate,leaveform.todate,leaveform.workfor,leaveform.leavetime,leaveform.status&#13;&#10;from empmaster inner join leaveform on empmaster.empcode=leaveform.empno where (status='Approved' or status='S')and fromdate=@apdate and ((workfor = '0.5') or (carryfwd='Y' and nocf='0.5' and workfor='0'))">
        <SelectParameters>
        <asp:Parameter Name="apdate" />
        </SelectParameters>
            </asp:SqlDataSource>
    &nbsp;
</asp:Content>