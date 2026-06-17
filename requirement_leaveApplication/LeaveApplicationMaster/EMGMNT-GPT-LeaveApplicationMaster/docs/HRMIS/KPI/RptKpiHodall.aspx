<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptKpiHodall.aspx.vb" Inherits="E_Management.RptKpiHodall" 
    title="KPI HOD Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Q1 Settings"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1"
                    ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                        <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                        <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                        <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                        <asp:TemplateField HeaderText="Cur-Tar" SortExpression="curent">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("curent") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("curent") %>'></asp:Label>-<asp:Label
                                    ID="Label2" runat="server" Text='<%# Bind("target") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="uom" HeaderText="Uom" SortExpression="uom" />
                        <asp:BoundField DataField="UpdBasis" HeaderText="UpdateOn" SortExpression="UpdBasis" />
                        <asp:BoundField DataField="revision" HeaderText="Revision" SortExpression="revision" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;<asp:Label ID="Label5" runat="server" Text="Q2 Settings"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2"
                    ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                        <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                        <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                        <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                        <asp:TemplateField HeaderText="Cur-Tar" SortExpression="curent">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("curent") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("curent") %>'></asp:Label>-<asp:Label
                                    ID="Label2" runat="server" Text='<%# Bind("target") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="uom" HeaderText="Uom" SortExpression="uom" />
                        <asp:BoundField DataField="UpdBasis" HeaderText="UpdateOn" SortExpression="UpdBasis" />
                        <asp:BoundField DataField="revision" HeaderText="Revision" SortExpression="revision" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label4" runat="server" Text="Q3 Settings"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource3"
                    ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                        <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                        <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                        <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                        <asp:TemplateField HeaderText="Cur-Tar" SortExpression="curent">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("curent") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("curent") %>'></asp:Label>-<asp:Label
                                    ID="Label2" runat="server" Text='<%# Bind("target") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="uom" HeaderText="Uom" SortExpression="uom" />
                        <asp:BoundField DataField="UpdBasis" HeaderText="UpdateOn" SortExpression="UpdBasis" />
                        <asp:BoundField DataField="revision" HeaderText="Revision" SortExpression="revision" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="Q4 Settings"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource4"
                    ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                        <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                        <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                        <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                        <asp:TemplateField HeaderText="Cur-Tar" SortExpression="curent">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("curent") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("curent") %>'></asp:Label>-<asp:Label
                                    ID="Label2" runat="server" Text='<%# Bind("target") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="uom" HeaderText="Uom" SortExpression="uom" />
                        <asp:BoundField DataField="UpdBasis" HeaderText="UpdateOn" SortExpression="UpdBasis" />
                        <asp:BoundField DataField="revision" HeaderText="Revision" SortExpression="revision" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT KPI_IndividualSetting.MajorKPI_Details, KPI_IndividualSetting.SubKPI_Details, KPI_IndividualSetting.subweightage, KPI_IndividualSetting.uom, KPI_IndividualSetting.curent, KPI_IndividualSetting.target, KPI_SubSetting.UpdBasis, kpi_tempreport_hod.empcode, kpi_tempreport_hod.revision, empmaster.empcode AS Expr1, empmaster.empname, empmaster.designation, empmaster.sectioncode, KPI_IndividualSetting.checked, KPI_IndividualSetting.q1 FROM empmaster INNER JOIN kpi_tempreport_hod ON empmaster.empcode = kpi_tempreport_hod.empcode INNER JOIN KPI_IndividualSetting INNER JOIN KPI_SubSetting ON KPI_IndividualSetting.Employee_Code = KPI_SubSetting.Employee_Code AND KPI_IndividualSetting.Sub_KPINO = KPI_SubSetting.Sub_KPINO ON kpi_tempreport_hod.revision = KPI_IndividualSetting.revision WHERE (KPI_IndividualSetting.checked = '-1') AND (KPI_IndividualSetting.q1 = '[True]') and (KPI_IndividualSetting.kpi_year = @yr) AND (empmaster.sectioncode = @sect)">
        <SelectParameters>
            <asp:SessionParameter Name="sect" SessionField="KPIhodS" />
            <asp:SessionParameter Name="yr" SessionField="kpiyrh" />
            
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT KPI_IndividualSetting.MajorKPI_Details, KPI_IndividualSetting.SubKPI_Details, KPI_IndividualSetting.subweightage, KPI_IndividualSetting.uom, KPI_IndividualSetting.curent, KPI_IndividualSetting.target, KPI_SubSetting.UpdBasis, kpi_tempreport_hod.empcode, kpi_tempreport_hod.revision, empmaster.empcode AS Expr1, empmaster.empname, empmaster.designation, empmaster.sectioncode, KPI_IndividualSetting.checked, KPI_IndividualSetting.q1 FROM empmaster INNER JOIN kpi_tempreport_hod ON empmaster.empcode = kpi_tempreport_hod.empcode INNER JOIN KPI_IndividualSetting INNER JOIN KPI_SubSetting ON KPI_IndividualSetting.Employee_Code = KPI_SubSetting.Employee_Code AND KPI_IndividualSetting.Sub_KPINO = KPI_SubSetting.Sub_KPINO ON kpi_tempreport_hod.revision = KPI_IndividualSetting.revision WHERE (KPI_IndividualSetting.checked = '-1') AND (KPI_IndividualSetting.q2 = '[True]') and (KPI_IndividualSetting.kpi_year = @yr) AND (empmaster.sectioncode = @sect)">
        <SelectParameters>
            <asp:SessionParameter Name="sect" SessionField="kpisecth" />
              <asp:SessionParameter Name="yr" SessionField="kpiyrh" />
            
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT KPI_IndividualSetting.MajorKPI_Details, KPI_IndividualSetting.SubKPI_Details, KPI_IndividualSetting.subweightage, KPI_IndividualSetting.uom, KPI_IndividualSetting.curent, KPI_IndividualSetting.target, KPI_SubSetting.UpdBasis, kpi_tempreport_hod.empcode, kpi_tempreport_hod.revision, empmaster.empcode AS Expr1, empmaster.empname, empmaster.designation, empmaster.sectioncode, KPI_IndividualSetting.checked, KPI_IndividualSetting.q1 FROM empmaster INNER JOIN kpi_tempreport_hod ON empmaster.empcode = kpi_tempreport_hod.empcode INNER JOIN KPI_IndividualSetting INNER JOIN KPI_SubSetting ON KPI_IndividualSetting.Employee_Code = KPI_SubSetting.Employee_Code AND KPI_IndividualSetting.Sub_KPINO = KPI_SubSetting.Sub_KPINO ON kpi_tempreport_hod.revision = KPI_IndividualSetting.revision WHERE (KPI_IndividualSetting.checked = '-1') AND (KPI_IndividualSetting.q3 = '[True]') and (KPI_IndividualSetting.kpi_year = @yr) AND (empmaster.sectioncode = @sect)">
        <SelectParameters>
            <asp:SessionParameter Name="sect" SessionField="kpisecth" />
             <asp:SessionParameter Name="yr" SessionField="kpiyrh" />
            
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT KPI_IndividualSetting.MajorKPI_Details, KPI_IndividualSetting.SubKPI_Details, KPI_IndividualSetting.subweightage, KPI_IndividualSetting.uom, KPI_IndividualSetting.curent, KPI_IndividualSetting.target, KPI_SubSetting.UpdBasis, kpi_tempreport_hod.empcode, kpi_tempreport_hod.revision, empmaster.empcode AS Expr1, empmaster.empname, empmaster.designation, empmaster.sectioncode, KPI_IndividualSetting.checked, KPI_IndividualSetting.q1 FROM empmaster INNER JOIN kpi_tempreport_hod ON empmaster.empcode = kpi_tempreport_hod.empcode INNER JOIN KPI_IndividualSetting INNER JOIN KPI_SubSetting ON KPI_IndividualSetting.Employee_Code = KPI_SubSetting.Employee_Code AND KPI_IndividualSetting.Sub_KPINO = KPI_SubSetting.Sub_KPINO ON kpi_tempreport_hod.revision = KPI_IndividualSetting.revision WHERE (KPI_IndividualSetting.checked = '-1') AND (KPI_IndividualSetting.q4 = '[True]') and (KPI_IndividualSetting.kpi_year = @yr) AND (empmaster.sectioncode = @sect)">
        <SelectParameters>
            <asp:SessionParameter Name="sect" SessionField="kpisecth" />
             <asp:SessionParameter Name="yr" SessionField="kpiyrh" />
            
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

</asp:Content>
