<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="WasteWaterMonitoringgridrpt.aspx.vb" Inherits="E_Management.WasteWaterMonitoringgridrpt" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
   <table width="100%">
   <tr>
   <td width="25%">
       Select Year
       <asp:DropDownList ID="year" runat="server" DataSourceID="SqlDataSource2" DataTextField="year1" DataValueField="year1" AppendDataBoundItems="True">
       <asp:ListItem Value="-1">Select year</asp:ListItem>
   </asp:DropDownList>
       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; Select Month&nbsp;<asp:DropDownList ID="month" runat="server">
           <asp:ListItem Value="-1">Select Month</asp:ListItem>
           <asp:ListItem Value="Y">January</asp:ListItem>
           <asp:ListItem Value="F">February</asp:ListItem>
	       <asp:ListItem Value="R">March</asp:ListItem>
	       <asp:ListItem Value="P">April</asp:ListItem>
		   <asp:ListItem Value="M">May</asp:ListItem>
		   <asp:ListItem Value="U">June</asp:ListItem>
	       <asp:ListItem Value="J">July</asp:ListItem>
           <asp:ListItem Value="A">August</asp:ListItem>
	       <asp:ListItem Value="S">September</asp:ListItem>
	       <asp:ListItem Value="O">October</asp:ListItem>
	       <asp:ListItem Value="N">November</asp:ListItem>
	       <asp:ListItem Value="D">December</asp:ListItem>
           </asp:DropDownList>
       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Select Plantno&nbsp;<asp:DropDownList ID="plant" runat="server">
           <asp:ListItem Value="-1">Select Plant No</asp:ListItem>
           <asp:ListItem Value="1">Plant1</asp:ListItem>
           <asp:ListItem Value="2">Plant2</asp:ListItem>
           <asp:ListItem>Plant1,Plant2                 </asp:ListItem>
       </asp:DropDownList>
       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
       &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="show" runat="server" BackColor="LightSteelBlue"
           Text="SHOW" CommandArgument="yr,mn,plt" /></td>
   </tr>
   </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="0" ForeColor="#333333" AutoGenerateColumns="False" AllowSorting="True" PageSize="31" Width="863px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="day1" HeaderText="Day" SortExpression="day1" />
            <asp:BoundField DataField="year1" HeaderText="Year" SortExpression="year1" />
            <asp:BoundField DataField="month1" HeaderText="Month" SortExpression="month1" />
            <asp:BoundField DataField="incoming" HeaderText="Incoming" SortExpression="incoming" />
            <asp:BoundField DataField="waterph" HeaderText="Waterph" SortExpression="waterph" />
            <asp:BoundField DataField="cod" HeaderText="Cod" SortExpression="cod" />
            <asp:BoundField DataField="plantno" HeaderText="PlantNo" SortExpression="plantno" />
            <asp:BoundField DataField="datadate" HeaderText="Date" SortExpression="datadate" DataFormatString="{0:dd/MM/yy}" HtmlEncode="false"/>
        </Columns>
    </asp:GridView>
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SqlconDMIS %>"
        SelectCommand="select*from wastewater where year1=@yr and month1=@mn and plantno=@plt order by day1">
       <SelectParameters>
       <asp:ControlParameter />
       </SelectParameters>
        </asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SqlconDMIS %>"
        SelectCommand="select distinct(year1) from wastewater order by year1 desc&#13;&#10;">
    </asp:SqlDataSource>
</asp:Content>
