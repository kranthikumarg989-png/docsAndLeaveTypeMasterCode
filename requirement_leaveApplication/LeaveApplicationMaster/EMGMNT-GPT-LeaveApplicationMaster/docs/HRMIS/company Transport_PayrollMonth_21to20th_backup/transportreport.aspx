<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="transportreport.aspx.vb" Inherits="E_Management.transport_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:GridView ID="grdroute" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double"
        BorderWidth="3px" CellPadding="4" DataSourceID="sqlroute" GridLines="Horizontal"
        PageSize="25" Visible="False">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdarea" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double"
        BorderWidth="3px" CellPadding="4" DataSourceID="Sqlarea" GridLines="Horizontal"
        PageSize="25" Visible="False">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdarear" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double"
        BorderWidth="3px" CellPadding="4" DataSourceID="Sqlarea1" GridLines="Horizontal"
        PageSize="25" Visible="False">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdemp" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
        DataSourceID="Sqlemp" GridLines="Horizontal" AllowPaging="True" AllowSorting="True" Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
            <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
            <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
            <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdempR" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
        DataSourceID="SqlDataSource1" GridLines="Horizontal" AllowPaging="True" AllowSorting="True" Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
            <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
            <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
            <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdempar" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double"
        BorderWidth="3px" CellPadding="4" DataSourceID="SqlempAR" GridLines="Horizontal"
        Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
            <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
            <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
            <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdsupplier" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double"
        BorderWidth="3px" CellPadding="4" DataSourceID="Sqlsupplier" GridLines="Horizontal"
        Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="suppliername" HeaderText="Name" SortExpression="suppliername" />
            <asp:BoundField DataField="suppliericno" HeaderText="ICNO" SortExpression="suppliericno" />
            <asp:BoundField DataField="supplieraddress" HeaderText="Address" SortExpression="supplieraddress" />
            <asp:BoundField DataField="companyname" HeaderText="Com.Name" SortExpression="companyname" />
            <asp:BoundField DataField="companyregdno" HeaderText="com.Regd.no" SortExpression="companyregdno" />
            <asp:BoundField DataField="supplierhp" HeaderText="Hand ph" SortExpression="supplierhp" />
            <asp:BoundField DataField="supplierphoneno" HeaderText="Phone no" SortExpression="supplierphoneno" />
            <asp:BoundField DataField="supplierfax" HeaderText="Fax No" SortExpression="supplierfax" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdsuppR" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
        DataSourceID="sqlsuppR" GridLines="Horizontal" Visible="False" AllowPaging="True" AllowSorting="True" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="supplier" HeaderText="Supplier" SortExpression="supplier" />
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
            <asp:BoundField DataField="vehicletype" HeaderText="VehicleType" SortExpression="vehicletype" />
            <asp:BoundField DataField="vehicleno" HeaderText="Vehicle No" SortExpression="vehicleno" />
            <asp:BoundField DataField="drivername" HeaderText="Driver Name" SortExpression="drivername" />
            <asp:BoundField DataField="licenseno" HeaderText="License No" SortExpression="licenseno" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdPt" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
        CellPadding="4" DataSourceID="SqlPT" GridLines="Horizontal" Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
            <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
            <asp:BoundField DataField="shifta" HeaderText="Shift A" SortExpression="shifta" />
            <asp:BoundField DataField="shiftb" HeaderText="Shift B" SortExpression="shiftb" />
            <asp:BoundField DataField="shiftc" HeaderText="Shift C" SortExpression="shiftc" />
            <asp:BoundField DataField="shiftd" HeaderText="Shift D" SortExpression="shiftd" />
            <asp:BoundField DataField="shifte" HeaderText="Shift E" SortExpression="shifte" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdbv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
        CellPadding="4" DataSourceID="SqlBV" GridLines="Horizontal" Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="route" HeaderText="Route" SortExpression="route" />
            <asp:BoundField DataField="cost" HeaderText="Cost" SortExpression="cost" />
            <asp:BoundField DataField="typeofvehicle" HeaderText="Vehicle type" SortExpression="typeofvehicle" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdownE" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
        DataSourceID="Sqlvehie" GridLines="Horizontal" AllowPaging="True" AllowSorting="True" Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="tvehicleno" HeaderText="Vehicle No" SortExpression="tvehicleno" />
            <asp:BoundField DataField="tallowance" HeaderText="Allowance" SortExpression="tallowance" />
            <asp:BoundField DataField="tvehicletype" HeaderText="Vehicle Type" SortExpression="tvehicletype" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="grdvehid" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="Sqlvehidept" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Visible="False" PageSize="25">
           <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="tvehicleno" HeaderText="Vehicle No" SortExpression="tvehicleno" />
            <asp:BoundField DataField="tallowance" HeaderText="Allowance" SortExpression="tallowance" />
            <asp:BoundField DataField="tvehicletype" HeaderText="Vehicle Type" SortExpression="tvehicletype" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
        </Columns>
        <RowStyle BackColor="White" ForeColor="#333333" />
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:GridView ID="Grdvehisect" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="sqlvehisect" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
             <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="tvehicleno" HeaderText="Vehicle No" SortExpression="tvehicleno" />
            <asp:BoundField DataField="tallowance" HeaderText="Allowance" SortExpression="tallowance" />
            <asp:BoundField DataField="tvehicletype" HeaderText="Vehicle Type" SortExpression="tvehicletype" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView><asp:GridView ID="grdvehio" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="Sqlvehio" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Visible="False" PageSize="25">
        <RowStyle BackColor="White" ForeColor="#333333" />
      <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="tvehicleno" HeaderText="Vehicle No" SortExpression="tvehicleno" />
            <asp:BoundField DataField="tallowance" HeaderText="Allowance" SortExpression="tallowance" />
            <asp:BoundField DataField="tvehicletype" HeaderText="Vehicle Type" SortExpression="tvehicletype" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
            <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="Sqlvehio" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT trans_ownvehicle.empcode, trans_ownvehicle.tvehicleno, trans_ownvehicle.tallowance, trans_ownvehicle.tvehicletype, empmaster.empname,empmaster.sectioncode, empmaster.departmentcode FROM trans_ownvehicle INNER JOIN empmaster ON trans_ownvehicle.empcode = empmaster.empcode WHERE (empmaster.resigned <> 'Y') ">
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sqlvehisect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT trans_ownvehicle.empcode, trans_ownvehicle.tvehicleno, trans_ownvehicle.tallowance, trans_ownvehicle.tvehicletype, empmaster.empname,empmaster.sectioncode, empmaster.departmentcode FROM trans_ownvehicle INNER JOIN empmaster ON trans_ownvehicle.empcode = empmaster.empcode WHERE (empmaster.resigned <> 'Y') and empmaster.sectioncode = @sect">
        <SelectParameters>
            <asp:SessionParameter Name="sect" SessionField="vehisect" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="Sqlvehidept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT trans_ownvehicle.empcode, trans_ownvehicle.tvehicleno, trans_ownvehicle.tallowance, trans_ownvehicle.tvehicletype, empmaster.empname,empmaster.sectioncode, empmaster.departmentcode FROM trans_ownvehicle INNER JOIN empmaster ON trans_ownvehicle.empcode = empmaster.empcode WHERE (empmaster.resigned <> 'Y') and empmaster.departmentcode = @dept">
        <SelectParameters>
            <asp:SessionParameter Name="dept" SessionField="vehidept" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlvehie" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT trans_ownvehicle.empcode, trans_ownvehicle.tvehicleno, trans_ownvehicle.tallowance, trans_ownvehicle.tvehicletype, empmaster.empname,empmaster.sectioncode, empmaster.departmentcode FROM trans_ownvehicle INNER JOIN empmaster ON trans_ownvehicle.empcode = empmaster.empcode WHERE (empmaster.resigned <> 'Y') and empmaster.empcode = @emp">
        <SelectParameters>
            <asp:SessionParameter Name="emp" SessionField="emp" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlBV" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [route], [cost], [typeofvehicle] FROM [trans_cost]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlPT" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [route], [area], [shifta], [shiftb], [shiftc], [shiftd], [shifte] FROM [trans_pickuptimemaster]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlsuppR" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [supplier], [route], [vehicletype], [vehicleno], [licenseno], [drivername], [rno] FROM [trans_vehicleallotment] ORDER BY [supplier]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlsupplier" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [suppliername], [suppliericno], [supplieraddress], [companyname], [companyregdno], [supplierhp], [supplierphoneno], [supplierfax] FROM [trans_supplier] ORDER BY [suppliername]">
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlempAR" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select * from empmaster where (transportneeded='Y' or transportneeded='Yes') and (resigned <>'Y')  and ([route] = @route) and (area  =@area) order by route">
        <SelectParameters>
            <asp:SessionParameter Name="route" SessionField="route" />
            <asp:SessionParameter Name="area" SessionField="area" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlarea" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [area], [route] FROM [trans_areamaster] ORDER BY [area]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlemp" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select * from empmaster where (transportneeded='Y' or transportneeded='Yes') and (resigned <>'Y') order by route">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlarea1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [area], [route] FROM [trans_areamaster] WHERE ([route] = @route) ORDER BY [area]">
        <SelectParameters>
            <asp:SessionParameter Name="route" SessionField="route" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select * from empmaster where (transportneeded='Y' or transportneeded='Yes') and (resigned <>'Y') and ([route] = @route) order by route">
           <SelectParameters>
            <asp:SessionParameter Name="route" SessionField="route" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sqlroute" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [route] FROM [trans_routemaster] ORDER BY [route]"></asp:SqlDataSource>

</asp:Content>
