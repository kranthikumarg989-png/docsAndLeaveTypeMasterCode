<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PCExpityListEA.aspx.vb" Inherits="E_Management.PCExpityListEA" 
    title="Probation / Contract Expiry List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td style="height: 18px">
                <asp:Label ID="Label1" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="STAFF PROBATION EXPIRY LIST"
                    Width="535px"></asp:Label><br />
                <asp:Panel ID="Panel1" runat="server" GroupingText="SEARCH">
                    <table style="width: 239px">
                        <tr>
                            <td style="width: 100px">
                                Select
                            </td>
                            <td style="width: 100px">
                                <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                    Width="408px">
                                    <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                    <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                    <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                                    <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="all">* (ALL)</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lbldeptr" runat="server" Text="Select Department" Width="131px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
                                    DataTextField="dept" DataValueField="departmentcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 24px">
                                <asp:Label ID="lblsectr" runat="server" Text="Select Section" Width="98px"></asp:Label></td>
                            <td style="width: 100px; height: 24px">
                                <asp:DropDownList ID="ddlsectrpt" runat="server" DataSourceID="sqlsect" DataTextField="sectioncode"
                                    DataValueField="sectioncode">
                                    <asp:ListItem Selected="True" Value="-1">--select--</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 24px;">
                                <asp:Label ID="lbldesigr" runat="server" Text="Select Designation" Width="132px"></asp:Label></td>
                            <td style="width: 100px; height: 24px;">
                                <asp:DropDownList ID="ddldesigr" runat="server" AutoPostBack="True" DataSourceID="SqlDesig"
                                    DataTextField="desig" DataValueField="desig">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtempidr" runat="server" Width="83px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td align="right" style="width: 100px">
                                <asp:Button ID="btnshow" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="#C00000"></asp:Label></asp:Panel>
            </td>
        </tr>
         <tr>
                <td colspan="2" valign="top" style="height: 6px;background-color: #5d7b9d"">
                   
               <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
               Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtsearch2" runat="server"></asp:TextBox>
               <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid2" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsearch2"
                ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search">
                </asp:RequiredFieldValidator>
                </td>
                
            </tr>
        <tr>
            <td>
                <asp:GridView ID="gridview1" runat="server" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                    PageSize="20">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="Lnlappraisal" runat="server" CommandArgument='<%# Eval("empcode", "{0}") %>'
                                    Font-Underline="True" ForeColor="Blue" OnCommand="Appraisal_view1" Text='<%# Bind("empcode") %>'></asp:LinkButton>
                                     <asp:Label ID="Lab1" runat="server" Text='<%# Bind("empcode") %>' Visible=False />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                    ID="Label3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="emptype" HeaderText="Emptype" SortExpression="emptype" />
                        <asp:BoundField DataField="probation" HeaderText="Probation" SortExpression="probation" />
                        <asp:BoundField DataField="dateofjoin" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" HeaderText="Dateofjoin"
                            SortExpression="dateofjoin"  />
                        <asp:BoundField DataField="probationends" DataFormatString="{0:dd-MMM-yyyy}"  HtmlEncode="False" HeaderText="Prob.Exp on"
                            ReadOnly="True" SortExpression="probationends" />
                        <asp:BoundField DataField="diff" HeaderText="Days Remain" ReadOnly="True" SortExpression="diff" />
                        <asp:TemplateField HeaderText="Appraisal &lt;br&gt; Done" SortExpression="appraisal">
                            <ItemTemplate>
                                <asp:Label ID="lblappraisal" runat="server" Text='<%# Bind("appraisal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridV" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource2" ForeColor="#333333" ShowFooter="True" AllowPaging="True" PageSize="20" Caption="OPERATOR PROBATION EXPIRY LIST">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                       <asp:BoundField DataField="Rno" HeaderText="rno" SortExpression="rno"  />
                        <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("rno", "{0}") %>'
                                    Font-Underline="True" ForeColor="Blue" OnCommand="Appraisal_view" Text='<%# Bind("empcode") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="dateofappraisal" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" HeaderText="Appraisal Date"
                            SortExpression="dateofappraisal" />
                        <asp:BoundField DataField="purposeofappraisal" HeaderText="Purpose" SortExpression="purposeofappraisal" />
                        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                        <asp:BoundField DataField="grade" HeaderText="Grade" SortExpression="grade" />
                        <asp:BoundField DataField="remarks" HeaderText="SH Remarks" SortExpression="remarks" >
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ratedbyempno" HeaderText="Appraisal doneby" SortExpression="ratedbyempno" />
                        <asp:BoundField DataField="reviewby" HeaderText="Review By" SortExpression="reviewby" />
                     
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmployementStatus">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem Value="C">Confirmation</asp:ListItem>
                                    <asp:ListItem Value="E">Extend Probation (1 Mth)</asp:ListItem>
                                    <asp:ListItem Value="EC">Extend contract</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateAppraisal" Text="Save" />
                            </FooterTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
               <asp:SqlDataSource id="SqlDataSource2" runat="server" SelectCommand="SELECT *, empmaster.empname, empmaster.sectioncode, empmaster.departmentcode, empmaster.empcode AS Expr1 FROM app_operatorappraisal INNER JOIN empmaster ON app_operatorappraisal.empcode = empmaster.empcode WHERE (app_operatorappraisal.status = 'AD') and designation = 'operator' and empmaster.foreignemp = 'N' and resigned = 'N' order by rno desc" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
       
    </asp:SqlDataSource>
    
           
                
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
         SelectCommand="hrmis_appraisal_alert_EA1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
         
            <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT sectioncode + '-' + sectionname AS section, sectioncode, departmentcode FROM sectionmaster WHERE (departmentcode = @dept) ORDER BY sectioncode">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddldeptr" Name="dept" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation order by designationname">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode ">
                </asp:SqlDataSource>
         
     </asp:Content>

