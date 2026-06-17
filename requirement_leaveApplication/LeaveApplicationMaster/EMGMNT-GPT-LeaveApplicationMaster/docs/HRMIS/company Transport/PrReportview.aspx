<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PrReportview.aspx.vb" Inherits="E_Management.PrReportview" 
    title="Production Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;<table>
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Font-Underline="True" ForeColor="Maroon"
                    Text="Production Schedule Details for  "></asp:Label>
                <asp:Label ID="lbldetails" runat="server" Font-Size="Medium"  Font-Underline="True" ForeColor="Maroon" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 204px">
    
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
        ShowFooter="True" Visible="False" EmptyDataText="No Records found!!!!">
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Dept" SortExpression="departmentcode" />
             <asp:BoundField DataField="sectioncode" HeaderText="Sect" SortExpression="departmentcode" />
            <asp:BoundField DataField="fromdate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" HeaderText="Fromdate"
                SortExpression="Fromdate" Visible=false   />
            <asp:BoundField DataField="todate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" HeaderText="Todate"
                SortExpression="todate" Visible=false   />
            <asp:BoundField DataField="groupcode" HeaderText="Groupcode" SortExpression="groupcode" />
          
            
            <asp:BoundField DataField="day1" HeaderText="1" SortExpression="day1" />
            <asp:BoundField DataField="day2" HeaderText="2" SortExpression="day2" />
            <asp:BoundField DataField="day3" HeaderText="3" SortExpression="day3" />
            <asp:BoundField DataField="day4" HeaderText="4" SortExpression="day4" />
            <asp:BoundField DataField="day5" HeaderText="5" SortExpression="day5" />
            <asp:BoundField DataField="day6" HeaderText="6" SortExpression="day6" />
            <asp:BoundField DataField="day7" HeaderText="7" SortExpression="day7" />
            <asp:BoundField DataField="day8" HeaderText="8" SortExpression="day8" />
            <asp:BoundField DataField="day9" HeaderText="9" SortExpression="day9" />
            <asp:BoundField DataField="day10" HeaderText="10" SortExpression="day10" />
            <asp:BoundField DataField="day11" HeaderText="11" SortExpression="day11" />
            <asp:BoundField DataField="day12" HeaderText="12" SortExpression="day12" />
            <asp:BoundField DataField="day13" HeaderText="13" SortExpression="day13" />
            <asp:BoundField DataField="day14" HeaderText="14" SortExpression="day14" />
            <asp:BoundField DataField="day15" HeaderText="15" SortExpression="day15" />
            <asp:BoundField DataField="day16" HeaderText="16" SortExpression="day16" />
            <asp:BoundField DataField="day17" HeaderText="17" SortExpression="day17" />
            <asp:BoundField DataField="day18" HeaderText="18" SortExpression="day18" />
            <asp:BoundField DataField="day19" HeaderText="19" SortExpression="day19" />
            <asp:BoundField DataField="day20" HeaderText="20" SortExpression="day20" />
            <asp:BoundField DataField="day21" HeaderText="21" SortExpression="day21" />
            <asp:BoundField DataField="day22" HeaderText="22" SortExpression="day22" />
            <asp:BoundField DataField="day23" HeaderText="23" SortExpression="day23" />
            <asp:BoundField DataField="day24" HeaderText="24" SortExpression="day24" />
            <asp:BoundField DataField="day25" HeaderText="25" SortExpression="day25" />
            <asp:BoundField DataField="day26" HeaderText="26" SortExpression="day26" />
            <asp:BoundField DataField="day27" HeaderText="27" SortExpression="day27" />
            <asp:BoundField DataField="day28" HeaderText="28" SortExpression="day28" />
            <asp:BoundField DataField="day29" HeaderText="29" SortExpression="day29" />
            <asp:BoundField DataField="day30" HeaderText="30" SortExpression="day30" />
            <asp:BoundField DataField="day31" HeaderText="31" SortExpression="day31" />
            <asp:BoundField DataField="keyinby" HeaderText="keyinby" SortExpression="keyinby"              />
            <asp:BoundField DataField="datekeyin" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" HeaderText="Keyindate"
                SortExpression="datekeyin"  />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <EmptyDataRowStyle Font-Size="Medium" ForeColor="#C00000" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;<br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT empmaster.empname, trans_productionrequest.empcode, trans_productionrequest.departmentcode, trans_productionrequest.sectioncode, trans_productionrequest.fromdate, trans_productionrequest.todate, LTRIM(RTRIM(trans_productionrequest.day1)) AS day1, LTRIM(RTRIM(trans_productionrequest.day2)) AS day2, LTRIM(RTRIM(trans_productionrequest.day3)) AS day3, LTRIM(RTRIM(trans_productionrequest.day4)) AS day4, LTRIM(RTRIM(trans_productionrequest.day5)) AS day5, LTRIM(RTRIM(trans_productionrequest.day6)) AS day6, LTRIM(RTRIM(trans_productionrequest.day7)) AS day7, LTRIM(RTRIM(trans_productionrequest.day8)) AS day8, LTRIM(RTRIM(trans_productionrequest.day9)) AS day9, LTRIM(RTRIM(trans_productionrequest.day10)) AS day10, LTRIM(RTRIM(trans_productionrequest.day11)) AS day11, LTRIM(RTRIM(trans_productionrequest.day12)) AS day12, LTRIM(RTRIM(trans_productionrequest.day13)) AS day13, LTRIM(RTRIM(trans_productionrequest.day14)) AS day14, LTRIM(RTRIM(trans_productionrequest.day15)) AS day15, LTRIM(RTRIM(trans_productionrequest.day16)) AS day16, LTRIM(RTRIM(trans_productionrequest.day17)) AS day17, LTRIM(RTRIM(trans_productionrequest.day18)) AS day18, LTRIM(RTRIM(trans_productionrequest.day19)) AS day19, LTRIM(RTRIM(trans_productionrequest.day20)) AS day20, LTRIM(RTRIM(trans_productionrequest.day21)) AS day21, LTRIM(RTRIM(trans_productionrequest.day22)) AS day22, LTRIM(RTRIM(trans_productionrequest.day23)) AS day23, LTRIM(RTRIM(trans_productionrequest.day24)) AS day24, LTRIM(RTRIM(trans_productionrequest.day25)) AS day25, LTRIM(RTRIM(trans_productionrequest.day26)) AS day26, LTRIM(RTRIM(trans_productionrequest.day27)) AS day27, LTRIM(RTRIM(trans_productionrequest.day28)) AS day28, LTRIM(RTRIM(trans_productionrequest.day29)) AS day29, LTRIM(RTRIM(trans_productionrequest.day30)) AS day30, LTRIM(RTRIM(trans_productionrequest.day31)) AS day31, trans_productionrequest.groupcode FROM trans_productionrequest INNER JOIN empmaster ON trans_productionrequest.empcode = empmaster.empcode ">
    </asp:SqlDataSource>

</asp:Content>
