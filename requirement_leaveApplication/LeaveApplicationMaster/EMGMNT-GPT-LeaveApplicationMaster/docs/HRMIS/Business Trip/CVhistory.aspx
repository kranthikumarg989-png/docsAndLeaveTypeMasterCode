<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CVhistory.aspx.vb" Inherits="E_Management.CVhistory" 
    title="CV history" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageAlign="Right" ImageUrl="~/images/maruwa_a.JPG" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <br />
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="SaddleBrown"
                    Text="Customer Visit Hstory"></asp:Label></td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
        <Columns>
            <asp:BoundField DataField="recno" HeaderText="BT Ref" SortExpression="recno" />
            <asp:BoundField DataField="custname" HeaderText="Visitor" SortExpression="custname" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Deptcode" SortExpression="departmentcode" />
            <asp:BoundField DataField="vfromdate" HeaderText="Fromdate" SortExpression="vfromdate" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
            <asp:BoundField DataField="vtodate" HeaderText="Todate" SortExpression="vtodate"  DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false"/>
            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
            <asp:BoundField DataField="partipiciants" HeaderText="Partipiciants" SortExpression="partipiciants" />
            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
    &nbsp;<br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT acc_businesstrip.recno, HRMIS_BT_CUSTOMERVISITDETAILS.custname, empmaster.empname, empmaster.departmentcode, HRMIS_BT_CUSTOMERVISITDETAILS.vfromdate, HRMIS_BT_CUSTOMERVISITDETAILS.vtodate, HRMIS_BT_CUSTOMERVISITDETAILS.purpose, HRMIS_BT_CUSTOMERVISITDETAILS.partipiciants, HRMIS_BT_CUSTOMERVISITDETAILS.Details FROM acc_businesstrip INNER JOIN HRMIS_BT_CUSTOMERVISITDETAILS ON acc_businesstrip.recno = HRMIS_BT_CUSTOMERVISITDETAILS.btnum INNER JOIN empmaster ON acc_businesstrip.empcode = empmaster.empcode WHERE (HRMIS_BT_CUSTOMERVISITDETAILS.custname = @cust)">
        <SelectParameters>
            <asp:QueryStringParameter Name="cust" QueryStringField="cust" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
