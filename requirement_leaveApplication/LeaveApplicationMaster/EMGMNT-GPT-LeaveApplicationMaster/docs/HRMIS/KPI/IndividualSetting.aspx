<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="IndividualSetting.aspx.vb" Inherits="E_Management.IndividualSetting" 
    title="KPI Individual Setting" %>
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
                                        &nbsp;</td>
                                    <td style="background-color: beige; width: 196px;">
                                        </td>
                                </tr>
                       
                </table>
                <table>
                         
                    <tr>
                        <td colspan="3" style="height: 24px">
                            <asp:Label ID="Label5" runat="server" Font-Underline="True" ForeColor="Gray" Visible="False">KPI INDIVIDUAL SETTING</asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 248px; height: 24px;">
                            Select Quarter to Set/View KPI</td>
                        <td colspan="2">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                <asp:ListItem>Q1</asp:ListItem>
                                <asp:ListItem>Q2</asp:ListItem>
                                <asp:ListItem>Q3</asp:ListItem>
                                <asp:ListItem>Q4</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 227px">
                            Revision No</td>
                        <td colspan="2">
                <asp:Label ID="lblrev1" runat="server" ForeColor="Maroon"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 227px">
                            Click to Revise your KPI settings</td>
                        <td colspan="2">
                            <asp:Button ID="btnRevise" runat="server" Text="Revise" /></td>
                    </tr>
                    <tr>
                        <td style="width: 227px; height: 21px;">
                            <asp:Label ID="q1" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="Q2" runat="server" Visible="False"></asp:Label>&nbsp;
                            <asp:Label ID="q3" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="q4" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblrev" runat="server" ForeColor="Maroon" Visible="False"></asp:Label></td>
                        <td style="width: 100px; height: 21px;">
                        </td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Label ID="lblyr" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblmon" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <table style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; border-left: darkgray 1px solid; border-bottom: darkgray 1px solid">
                    <tr>
                        <td  >
                            <asp:Panel ID="Panel2" runat="server" GroupingText="DAILY KPI SETTINGS">
                            <asp:GridView ID="grddaily" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Vertical" ShowFooter="True" PageSize="100">
                                <Columns>
                                  <asp:BoundField DataField="slno" HeaderText="SNo" SortExpression="slno" />
                                  
                                    <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                                    <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                                    <asp:BoundField DataField="curent" HeaderText="Current" SortExpression="curent" />
                                    <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                    <asp:TemplateField HeaderText="Weightage" SortExpression="subweightage">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("subweightage") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtweight1" runat="server" Text='<%# Bind("subweightage") %>' Width="50px" OnTextChanged="Calculatetotal1" AutoPostBack="true" Enabled=false></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="RegularExpression1" runat="server"
                                ControlToValidate="txtweight1" ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                ></asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                              <FooterTemplate>
                                                     <asp:Label ID="Lblweight1" runat="server" Text="0"></asp:Label>
                                             </FooterTemplate>
                                     
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server"  Checked = '<%# Bind("checked") %>' OnCheckedChanged ="enableTB" AutoPostBack=true >  </asp:CheckBox>
                            </ItemTemplate>
                                
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
                            <asp:GridView ID="grdweekly" runat="server" AutoGenerateColumns="False" DataSourceID="Sqlweekly" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Vertical" ShowFooter="True" PageSize="100">
                            <Columns>
                                <asp:BoundField DataField="slno" HeaderText="SNo" SortExpression="slno" />
                                <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                                <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                                <asp:BoundField DataField="curent" HeaderText="Current" SortExpression="curent" />
                                <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                <asp:TemplateField HeaderText="Weightage" SortExpression="subweightage">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("subweightage") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtweight2" runat="server" Text='<%# Bind("subweightage") %>' Width="50px" OnTextChanged="Calculatetotal2" AutoPostBack="true" Enabled=false></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValida" runat="server"
                                ControlToValidate="txtweight2" ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                ></asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                           <FooterTemplate>
                                                     <asp:Label ID="Lblweight2" runat="server" Text="0"></asp:Label>
                                             </FooterTemplate>
                                     
                                    </asp:TemplateField> <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("checked") %>' AutoPostBack=true OnCheckedChanged ="enableTB2" />
                                    </ItemTemplate>
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
                            <asp:GridView ID="grdmonthly" runat="server" AutoGenerateColumns="False" DataSourceID="SqlMonthly" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Vertical" ShowFooter="True" PageSize="100">
                            <Columns>
                                <asp:BoundField DataField="slno" HeaderText="SNo" SortExpression="slno" />
                                <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                                <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                                <asp:BoundField DataField="curent" HeaderText="Current" SortExpression="curent" />
                                <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                         <asp:TemplateField HeaderText="Weightage" SortExpression="subweightage">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("subweightage") %>' Width="25px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtweight3" runat="server" Text='<%# Bind("subweightage") %>' Width="49px" OnTextChanged="Calculatetotal3" AutoPostBack="true"  Enabled=false ></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValida" runat="server"
                                ControlToValidate="txtweight3" ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                ></asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                           <FooterTemplate>
                                                     <asp:Label ID="Lblweight3" runat="server" Text="0"></asp:Label>
                                             </FooterTemplate>
                                      
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("checked") %>' AutoPostBack=true OnCheckedChanged ="enableTB3" />
                                    </ItemTemplate>
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
                            <asp:Label ID="Label1" runat="server" Text="KPI Total Weightage" BackColor="#FFE0C0" ForeColor="#C04000"></asp:Label>
                            :
                            <asp:Label ID="lbltot" runat="server" Text="0" BackColor="#FFE0C0" ForeColor="#C04000"></asp:Label></td>
                    </tr>
                    <tr >
                    <td align="right" >
                        <asp:Label ID="Label4" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button ID="btnsave" runat="server" Text="Save All Settings" Visible="False" /></td>
                                
                    </tr>
                </table>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
                                SelectCommand="SELECT slno, checked, MajorKPI_Details, SubKPI_Details, curent, target, subweightage, day1, day2, day3, day4, day5, day6, day7, day8, day9, day10, day11, day12, day13, day14, day15, day16, day17, day18, day19, day20, day21, day22, day23, day24, day25, day26, day27, day30, day31, day29, day28, updbasis, quarter FROM KPI_IndividualSetting WHERE (Employee_Code = @Employee_Code) AND (revision = @revision) AND (KPI_Year = @KPI_Year) AND (updbasis = 'D') AND (quarter = @qtr)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Employee_Code" SessionField="empcode" Type="String" />
                                    <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="DropDownList1" Name="qtr" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                <br />
                <asp:SqlDataSource ID="Sqlweekly" runat="server" ConnectionString="Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
                                SelectCommand="SELECT slno, checked, MajorKPI_Details, SubKPI_Details, curent, target, subweightage, day1, day2, day3, day4, day5, day6, day7, day8, day9, day10, day11, day12, day13, day14, day15, day16, day17, day18, day19, day20, day21, day22, day23, day24, day25, day26, day27, day30, day31, day29, day28, updbasis FROM KPI_IndividualSetting WHERE (Employee_Code = @Employee_Code) AND (revision = @revision) AND (KPI_Year = @KPI_Year) AND (updbasis = 'W') AND (quarter = @qtr)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Employee_Code" SessionField="empcode" Type="String" />
                        <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32" />
                        <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
 <asp:ControlParameter ControlID="DropDownList1" Name="qtr" PropertyName="SelectedValue" />
                        
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlMonthly" runat="server" ConnectionString="Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
                                SelectCommand="SELECT slno, checked, MajorKPI_Details, SubKPI_Details, curent, target, subweightage, day1, day2, day3, day4, day5, day6, day7, day8, day9, day10, day11, day12, day13, day14, day15, day16, day17, day18, day19, day20, day21, day22, day23, day24, day25, day26, day27, day30, day31, day29, day28, updbasis FROM KPI_IndividualSetting WHERE (Employee_Code = @Employee_Code) AND (revision = @revision) AND (KPI_Year = @KPI_Year) AND (updbasis = 'M') AND (quarter = @qtr)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Employee_Code" SessionField="empcode" Type="String" />
                        <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32" />
                        <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="qtr" PropertyName="SelectedValue" />
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
