<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ReportIndivKPIbyQtr.aspx.vb" Inherits="E_Management.ReportIndivKPIbyQtr" 
    title="Individual KPI Reports By Quarter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 617px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 352px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 617px; height: 352px;" valign="top">
                <br />
                <table>
                    <tr>
                        <td class="td_head" colspan="4">
                            <asp:Label ID="Label1" runat="server" Text="INDIVIDUAL KPI REPROTS BY QUARTER"></asp:Label></td>
                    </tr>
                    <tr>
                      
                   
                                    <td style="height: 17px; background-color: beige; width: 123px;">
                                        EmpCode</td>
                                    <td style="width: 184px; background-color: beige;">
                                        <asp:Label ID="lblempcode" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; ">
                                        EmpName</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 123px; height: 17px;">
                                        Department</td>
                                    <td style="background-color: beige; width: 184px;">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: beige;">
                                        Section</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 123px; height: 17px;">
                                        Designation</td>
                                    <td style="background-color: beige; width: 184px;">
                                        <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                                    <td style="background-color: beige;">
                            Revision No</td>
                                    <td style="background-color: beige; width: 196px;">
                <asp:Label ID="lblrev1" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                </tr>
                       
                </table>
                <br />
                <table style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; border-left: darkgray 1px solid; border-bottom: darkgray 1px solid">
                    <tr>
                        <td  >
                            <asp:Panel ID="Panel2" runat="server" GroupingText="DAILY KPI SETTINGS">
                            <asp:GridView ID="grddaily" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Vertical" ShowFooter="True" Width="565px">
                                <Columns>
                                  <asp:BoundField DataField="slno" HeaderText="SNo" SortExpression="slno" />
                                  
                                    <asp:BoundField DataField="MajorKPI_Details" HeaderText="Major KPI" SortExpression="MajorKPI_Details" />
                                    <asp:BoundField DataField="SubKPI_Details" HeaderText="Sub KPI" SortExpression="SubKPI_Details" />
                                    <asp:BoundField DataField="curent" HeaderText="Current" SortExpression="curent" />
                                    <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                    <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                                    <asp:TemplateField HeaderText="Checked" SortExpression="checked">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("checked") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("checked") %>' Enabled="False"
                                                EnableViewState="False" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                 
                              
                                       
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Panel ID="Panel1" runat="server" GroupingText="WEEKLY KPI SEETINGS">
                            <asp:GridView ID="grdweekly" runat="server" AutoGenerateColumns="False" DataSourceID="Sqlweekly" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Vertical" ShowFooter="True" Width="563px">
                            <Columns>
                                <asp:BoundField DataField="slno" HeaderText="SNo" SortExpression="slno" />
                                <asp:BoundField DataField="MajorKPI_Details" HeaderText="Major KPI" SortExpression="MajorKPI_Details" />
                                <asp:BoundField DataField="SubKPI_Details" HeaderText="Sub KPI" SortExpression="SubKPI_Details" />
                                <asp:BoundField DataField="curent" HeaderText="Current" SortExpression="curent" />
                                <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                                <asp:TemplateField HeaderText="Checked" SortExpression="checked">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("checked") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("checked") %>' Enabled="False" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" GroupingText="MONTHLY KPI SETTINGS">
                            <asp:GridView ID="grdmonthly" runat="server" AutoGenerateColumns="False" DataSourceID="SqlMonthly" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Vertical" ShowFooter="True" Width="563px">
                            <Columns>
                                <asp:BoundField DataField="slno" HeaderText="SNo" SortExpression="slno" />
                                <asp:BoundField DataField="MajorKPI_Details" HeaderText="Major KPI" SortExpression="MajorKPI_Details" />
                                <asp:BoundField DataField="SubKPI_Details" HeaderText="Sub KPI" SortExpression="SubKPI_Details" />
                                <asp:BoundField DataField="curent" HeaderText="Current" SortExpression="curent" />
                                <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                                <asp:TemplateField HeaderText="Checked" SortExpression="checked">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("checked") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("checked") %>' Enabled="False" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;<asp:Label ID="q1" runat="server" Visible="False"></asp:Label><asp:Label ID="Q2" runat="server" Visible="False"></asp:Label><asp:Label ID="q3" runat="server" Visible="False"></asp:Label><asp:Label ID="q4" runat="server" Visible="False"></asp:Label><asp:Label ID="lblrev" runat="server" ForeColor="Maroon" Visible="False"></asp:Label><asp:Label ID="lblyr" runat="server" Visible="False"></asp:Label><asp:Label ID="lblmon" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left">
                            TOTAL:
                            <asp:Label ID="LBLTOT" runat="server" Text="0"></asp:Label>&nbsp; GRADE :<asp:Label
                                ID="LBLGRADE" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr >
                    <td align="right" >
                        &nbsp;&nbsp;
                        </td>
                                
                    </tr>
                </table>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT slno, checked, MajorKPI_Details, SubKPI_Details, curent, target, subweightage, day1, day2, day3, day4, day5, day6, day7, day8, day9, day10, day11, day12, day13, day14, day15, day16, day17, day18, day19, day20, day21, day22, day23, day24, day25, day26, day27, day30, day31, day29, day28, updbasis, quarter FROM KPI_IndividualSetting WHERE (Employee_Code = @Employee_Code) AND (revision = @revision) AND (KPI_Year = @KPI_Year) AND (updbasis = 'D') AND (quarter = @qtr)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Employee_Code" SessionField="emp" Type="String" />
                                    <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
                                    <asp:SessionParameter Name="qtr" SessionField="qtr" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                <asp:SqlDataSource ID="Sqlweekly" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT slno, checked, MajorKPI_Details, SubKPI_Details, curent, target, subweightage, day1, day2, day3, day4, day5, day6, day7, day8, day9, day10, day11, day12, day13, day14, day15, day16, day17, day18, day19, day20, day21, day22, day23, day24, day25, day26, day27, day30, day31, day29, day28, updbasis FROM KPI_IndividualSetting WHERE (Employee_Code = @Employee_Code) AND (revision = @revision) AND (KPI_Year = @KPI_Year) AND (updbasis = 'W') AND (quarter = @qtr)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Employee_Code" SessionField="emp" Type="String" />
                        <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32" />
                        <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
                        <asp:SessionParameter Name="qtr" SessionField="qtr" />
                        
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlMonthly" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT slno, checked, MajorKPI_Details, SubKPI_Details, curent, target, subweightage, day1, day2, day3, day4, day5, day6, day7, day8, day9, day10, day11, day12, day13, day14, day15, day16, day17, day18, day19, day20, day21, day22, day23, day24, day25, day26, day27, day30, day31, day29, day28, updbasis FROM KPI_IndividualSetting WHERE (Employee_Code = @Employee_Code) AND (revision = @revision) AND (KPI_Year = @KPI_Year) AND (updbasis = 'M') AND (quarter = @qtr)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Employee_Code" SessionField="emp" Type="String" />
                        <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32" />
                        <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
                        <asp:SessionParameter Name="qtr" SessionField="qtr" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 352px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 617px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>

</asp:Content>
