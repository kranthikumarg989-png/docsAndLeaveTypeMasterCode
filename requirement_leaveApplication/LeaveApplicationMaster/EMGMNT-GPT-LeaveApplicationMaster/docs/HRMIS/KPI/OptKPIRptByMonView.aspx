<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OptKPIRptByMonView.aspx.vb" Inherits="E_Management.OptKPIRptByMonView" 
   title="Operator KPI report -By Month" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td align="center" style="height: 21px">
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="DarkRed" Text="OPERATOR MONTHLY KPI REPORT "></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="MONTH"></asp:Label>
                :<asp:Label ID="LBLMON" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td >
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
        <RowStyle BackColor="White" ForeColor="#003399" />
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <Columns>
            <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" SortExpression="EmpCode" />
            <asp:BoundField DataField="EmpName" HeaderText="EmpName" SortExpression="EmpName" />
            <asp:BoundField DataField="Dept-Sect" HeaderText="Dept-Sect" ReadOnly="True" SortExpression="Dept-Sect" />
          
            <asp:BoundField DataField="point1" HeaderText="TOTAL" SortExpression="point1" />
            <asp:BoundField DataField="point2" HeaderText="TOTAL" SortExpression="Point2" />
            <asp:BoundField DataField="point3" HeaderText="TOTAL" SortExpression="Point3"  />
            <asp:BoundField DataField="point4" HeaderText="TOTAL" SortExpression="point4" />
            <asp:BoundField DataField="point5" HeaderText="TOTAL" SortExpression="point5"  />
            <asp:BoundField DataField="point6" HeaderText="TOTAL" SortExpression="point6" />
            <asp:BoundField DataField="point7" HeaderText="TOTAL" SortExpression="point7" />
            <asp:BoundField DataField="point8" HeaderText="TOTAL" SortExpression="point8" />
            <asp:BoundField DataField="point9" HeaderText="TOTAL" SortExpression="point9" />
            <asp:BoundField DataField="point10" HeaderText="TOTAL" SortExpression="point10" />
            <asp:BoundField DataField="point11" HeaderText="TOTAL" SortExpression="point11" />
            <asp:BoundField DataField="point12" HeaderText="TOTAL" SortExpression="point12" />
          
            <asp:BoundField DataField="grade1" HeaderText="Grade" SortExpression="grade1" />
            <asp:BoundField DataField="grade2" HeaderText="Grade" SortExpression="grade2" />
            <asp:BoundField DataField="grade3" HeaderText="Grade" SortExpression="grade3" />
            <asp:BoundField DataField="grade4" HeaderText="Grade" SortExpression="grade4" />
            <asp:BoundField DataField="grade5" HeaderText="Grade" SortExpression="grade5" />
            <asp:BoundField DataField="grade6" HeaderText="Grade" SortExpression="grade6" />
            <asp:BoundField DataField="grade7" HeaderText="Grade" SortExpression="grade7" />
            <asp:BoundField DataField="grade8" HeaderText="Grade" SortExpression="grade8" />
            <asp:BoundField DataField="grade9" HeaderText="Grade" SortExpression="grade9" />
            <asp:BoundField DataField="grade10" HeaderText="Grade" SortExpression="grade10" />
            <asp:BoundField DataField="grade11" HeaderText="Grade" SortExpression="grade11" />
            <asp:BoundField DataField="grade12" HeaderText="Grade" SortExpression="grade12" />
           
           
        </Columns>
    </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select empmaster.EmpCode,EmpName,Departmentcode +'-' + sectioncode as 'Dept-Sect',Designation, performancedatainput.* FROM  performancedatainput INNER JOIN empmaster  ON performancedatainput.empcode=empmaster.empcode&#13;&#10;where (empmaster.empcode = @dept) and (empmaster.resigned <>'Y') and designation = 'Operator'&#13;&#10;and  performancedatainput.year1 = @yr and performancedatainput.option1 = @mon&#13;&#10;&#9;&#9;&#9;    order by empmaster.empcode">
                    <SelectParameters>
                        <asp:SessionParameter Name="dept" SessionField="KPIYEAR1" />
                        <asp:SessionParameter Name="yr" SessionField="KPIYEAR1" />
                        <asp:SessionParameter Name="mon" SessionField="KPIMON1" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
