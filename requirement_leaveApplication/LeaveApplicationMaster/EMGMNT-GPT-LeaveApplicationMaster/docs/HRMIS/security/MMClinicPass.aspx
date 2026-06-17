<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MMClinicPass.aspx.vb" Inherits="E_Management.MMClinicPass" 
    title="Maruwa Malaysia Group of companies Clinic Pass Out" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label id="Label1" runat="server" ForeColor="#C00000" Font-Bold="True" Text="CLINIC PASSOUT" Font-Underline="True"></asp:Label>
    &nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" AllowPaging="True" CaptionAlign="Left" PageSize="25" AllowSorting="True" GridLines="None">
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="department" HeaderText="Dept code" SortExpression="department" />
            <asp:BoundField DataField="sickness" HeaderText="Purpose" SortExpression="sickness" />
             <asp:BoundField DataField="dateapplied" HeaderText="Dateapplied" SortExpression="dateapplied" dataformatstring="{0:dd-MMM-yyy}"  HtmlEncode="false" />
             <asp:BoundField DataField="etimeout" HeaderText="Timeout" SortExpression="etimeuot" dataformatstring="{0:t}"  HtmlEncode="false" />
             <asp:BoundField DataField="etimein" HeaderText="Timein" SortExpression="etimein" dataformatstring="{0:t}"  HtmlEncode="false" />
             <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
             
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
        SelectCommand="SELECT clinicstaffgatepass.passno,clinicstaffgatepass.etimein,clinicstaffgatepass.etimeout,clinicstaffgatepass.dateapplied,clinicstaffgatepass.empcode,clinicstaffgatepass.status,clinicstaffgatepass.department,clinicstaffgatepass.sickness, empmaster.empname FROM clinicstaffgatepass INNER JOIN empmaster ON clinicstaffgatepass.empcode = empmaster.empcode where dateapplied=@mydate and (status='F' or status='S' or status ='A')">
        <SelectParameters>
        <asp:Parameter Name="mydate"  />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
        Text="CLINIC PASSOUT - MARUWA MELAKA" Visible="False"></asp:Label><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AllowPaging="True" CaptionAlign="Left" PageSize="25" AllowSorting="True" GridLines="None" Visible="False">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
                <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                <asp:BoundField DataField="department" HeaderText="Dept code" SortExpression="department" />
                <asp:BoundField DataField="sickness" HeaderText="Purpose" SortExpression="sickness" />
                <asp:BoundField DataField="dateapplied" HeaderText="Dateapplied" SortExpression="dateapplied" dataformatstring="{0:dd-MMM-yyy}"  HtmlEncode="False" />
                <asp:BoundField DataField="etimeout" HeaderText="Timeout" SortExpression="etimeuot" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:BoundField DataField="etimein" HeaderText="Timein" SortExpression="etimein" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    <asp:SqlDataSource ID="MaruwaMelaka" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
        SelectCommand="SELECT clinicstaffgatepass.passno,clinicstaffgatepass.etimein,clinicstaffgatepass.etimeout,clinicstaffgatepass.dateapplied,clinicstaffgatepass.empcode,clinicstaffgatepass.status,clinicstaffgatepass.department,clinicstaffgatepass.sickness, empmaster.empname FROM clinicstaffgatepass INNER JOIN empmaster ON clinicstaffgatepass.empcode = empmaster.empcode where dateapplied=@mydate and (status='F' or status='S' or status ='A')">
        <SelectParameters>
            <asp:Parameter Name="mydate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
        Text="CLINIC PASSOUT - MARUWA LIGHTINGS" Visible="False"></asp:Label><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="MaruwaLightings" CellPadding="4" ForeColor="#333333" AllowPaging="True" CaptionAlign="Left" PageSize="25" AllowSorting="True" GridLines="None" Visible="False">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
                <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                <asp:BoundField DataField="department" HeaderText="Dept code" SortExpression="department" />
                <asp:BoundField DataField="sickness" HeaderText="Purpose" SortExpression="sickness" />
                <asp:BoundField DataField="dateapplied" HeaderText="Dateapplied" SortExpression="dateapplied" dataformatstring="{0:dd-MMM-yyy}"  HtmlEncode="False" />
                <asp:BoundField DataField="etimeout" HeaderText="Timeout" SortExpression="etimeuot" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:BoundField DataField="etimein" HeaderText="Timein" SortExpression="etimein" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    <asp:SqlDataSource ID="MaruwaLightings" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis %>"
        SelectCommand="SELECT clinicstaffgatepass.passno,clinicstaffgatepass.etimein,clinicstaffgatepass.etimeout,clinicstaffgatepass.dateapplied,clinicstaffgatepass.empcode,clinicstaffgatepass.status,clinicstaffgatepass.department,clinicstaffgatepass.sickness, empmaster.empname FROM clinicstaffgatepass INNER JOIN empmaster ON clinicstaffgatepass.empcode = empmaster.empcode where dateapplied=@mydate and (status='F' or status='S' or status ='A')">
        <SelectParameters>
            <asp:Parameter Name="mydate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
        Text="CLINIC PASSOUT - MARUWA OUTSOURCE"></asp:Label><asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="MaruwaOutsource" CellPadding="4" ForeColor="#333333" AllowPaging="True" CaptionAlign="Left" PageSize="25" AllowSorting="True" GridLines="None">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
                <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                <asp:BoundField DataField="department" HeaderText="Dept code" SortExpression="department" />
                <asp:BoundField DataField="sickness" HeaderText="Purpose" SortExpression="sickness" />
                <asp:BoundField DataField="dateapplied" HeaderText="Dateapplied" SortExpression="dateapplied" dataformatstring="{0:dd-MMM-yyy}"  HtmlEncode="False" />
                <asp:BoundField DataField="etimeout" HeaderText="Timeout" SortExpression="etimeuot" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:BoundField DataField="etimein" HeaderText="Timein" SortExpression="etimein" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    <asp:SqlDataSource ID="MaruwaOutsource" runat="server" ConnectionString="<%$ ConnectionStrings:OutsourceHRMIS %>"
        SelectCommand="SELECT clinicstaffgatepass.passno,clinicstaffgatepass.etimein,clinicstaffgatepass.etimeout,clinicstaffgatepass.dateapplied,clinicstaffgatepass.empcode,clinicstaffgatepass.status,clinicstaffgatepass.department,clinicstaffgatepass.sickness, empmaster.empname FROM clinicstaffgatepass INNER JOIN empmaster ON clinicstaffgatepass.empcode = empmaster.empcode where dateapplied=@mydate and (status='F' or status='S' or status ='A')">
        <SelectParameters>
            <asp:Parameter Name="mydate" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    <br />
</asp:Content>
