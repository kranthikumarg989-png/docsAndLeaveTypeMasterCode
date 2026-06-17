<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptKPISujmmaryMonrpt.aspx.vb" Inherits="E_Management.RptKPISujmmaryMonrpt" 
    title="KPI SUMMARY REPORT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td align="center" style="height: 21px">
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="DarkRed" Text="EMPLOYEE PERFORMANCE SUMMARY"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="Empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                    ID="Label15" runat="server" Text='<%# Bind("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="yr" HeaderText="Year" SortExpression="yr" />
                        <asp:TemplateField HeaderText="JAN &lt;br&gt; Tot-Grade" SortExpression="p1">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("p1") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("p1") %>'></asp:Label>-<asp:Label
                                    ID="Label13" runat="server" Text='<%# Bind("g1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Feb &lt;br&gt; Tot-Grade" SortExpression="p2">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("p2") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("p2") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MAR &lt;br&gt; Tot-Grade" SortExpression="p3">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("p3") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("p3") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g3") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="APR &lt;br&gt; Tot-Grade" SortExpression="p4">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("p4") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("p4") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g4") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MAY &lt;br&gt; Tot-Grade" SortExpression="p5">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("p5") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("p5") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g5") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="JUNE &lt;br&gt; Tot-Grade" SortExpression="p6">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("p6") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("p6") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g6") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="JULY &lt;br&gt; Tot-Grade" SortExpression="p7">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("p7") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("p7") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g7") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AUG &lt;br&gt; Tot-Grade" SortExpression="p8">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("p8") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("p8") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g8") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SEP &lt;br&gt; Tot-Grade" SortExpression="p9">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("p9") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("p9") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g9") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OCT &lt;br&gt; Tot-Grade" SortExpression="p10">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("p10") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("p10") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g10") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOV &lt;br&gt; Tot-Grade" SortExpression="p11">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("p11") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("p11") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g11") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DEC &lt;br&gt; Tot-Grade" SortExpression="p12">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("p12") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("p12") %>'></asp:Label>-<asp:Label
                                    ID="Label1" runat="server" Text='<%# Bind("g12") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="avg" HeaderText="Avg" SortExpression="avg" >
                            <ItemStyle BackColor="#FF8000" ForeColor="Yellow" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gradeavg" HeaderText="AvgGrade" SortExpression="gradeavg" >
                            <ItemStyle BackColor="#FF8000" ForeColor="#FFFF80" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT KPI_summaryRpt_temp.Empcode, KPI_summaryRpt_temp.yr, KPI_summaryRpt_temp.p1, KPI_summaryRpt_temp.p2, KPI_summaryRpt_temp.p3, KPI_summaryRpt_temp.p4, KPI_summaryRpt_temp.p5, KPI_summaryRpt_temp.p6, KPI_summaryRpt_temp.p7, KPI_summaryRpt_temp.p8, KPI_summaryRpt_temp.p9, KPI_summaryRpt_temp.p10, KPI_summaryRpt_temp.p11, KPI_summaryRpt_temp.p12, KPI_summaryRpt_temp.g1, KPI_summaryRpt_temp.g2, KPI_summaryRpt_temp.g3, KPI_summaryRpt_temp.g4, KPI_summaryRpt_temp.g5, KPI_summaryRpt_temp.g6, KPI_summaryRpt_temp.g7, KPI_summaryRpt_temp.g8, KPI_summaryRpt_temp.g9, KPI_summaryRpt_temp.g10, KPI_summaryRpt_temp.avg, KPI_summaryRpt_temp.gradeavg, KPI_summaryRpt_temp.g11, KPI_summaryRpt_temp.g12, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode FROM KPI_summaryRpt_temp INNER JOIN empmaster ON KPI_summaryRpt_temp.Empcode = empmaster.empcode ORDER BY KPI_summaryRpt_temp.Empcode"></asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1">
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="Empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                    ID="Label15" runat="server" Text='<%# Bind("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
            <asp:BoundField DataField="yr" HeaderText="Year" SortExpression="yr" />
          
            <asp:TemplateField HeaderText="APR &lt;br&gt; Tot-Grade" SortExpression="p4">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("p4") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("p4") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g4") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MAY &lt;br&gt; Tot-Grade" SortExpression="p5">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("p5") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("p5") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g5") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="JUNE &lt;br&gt; Tot-Grade" SortExpression="p6">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("p6") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("p6") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g6") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="JULY &lt;br&gt; Tot-Grade" SortExpression="p7">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("p7") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("p7") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g7") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AUG &lt;br&gt; Tot-Grade" SortExpression="p8">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("p8") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("p8") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g8") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SEP &lt;br&gt; Tot-Grade" SortExpression="p9">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("p9") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("p9") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g9") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="avg" HeaderText="Avg" SortExpression="avg" >
                <ItemStyle BackColor="#FF8000" ForeColor="Yellow" />
            </asp:BoundField>
            <asp:BoundField DataField="gradeavg" HeaderText="AvgGrade" SortExpression="gradeavg" >
                <ItemStyle BackColor="#FF8000" ForeColor="#FFFF80" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
    <br />
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1">
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="Empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                    ID="Label15" runat="server" Text='<%# Bind("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
            <asp:BoundField DataField="yr" HeaderText="Year" SortExpression="yr" />
          
          
            <asp:TemplateField HeaderText="OCT &lt;br&gt; Tot-Grade" SortExpression="p10">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("p10") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("p10") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g10") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NOV &lt;br&gt; Tot-Grade" SortExpression="p11">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("p11") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("p11") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g11") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DEC &lt;br&gt; Tot-Grade" SortExpression="p12">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("p12") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("p12") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g12") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
              <asp:TemplateField HeaderText="JAN &lt;br&gt; Tot-Grade" SortExpression="p1">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("p1") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("p1") %>'></asp:Label>-<asp:Label
                        ID="Label13" runat="server" Text='<%# Bind("g1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Feb &lt;br&gt; Tot-Grade" SortExpression="p2">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("p2") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("p2") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MAR &lt;br&gt; Tot-Grade" SortExpression="p3">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("p3") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("p3") %>'></asp:Label>-<asp:Label
                        ID="Label1" runat="server" Text='<%# Bind("g3") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="avg" HeaderText="Avg" SortExpression="avg" >
                <ItemStyle BackColor="#FF8000" ForeColor="Yellow" />
            </asp:BoundField>
            <asp:BoundField DataField="gradeavg" HeaderText="AvgGrade" SortExpression="gradeavg" >
                <ItemStyle BackColor="#FF8000" ForeColor="#FFFF80" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>

</asp:Content>
