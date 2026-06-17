<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="KPI HOd approve.aspx.vb" Inherits="E_Management.KPI_HOd_approve" 
    title="KPI HOD Approval" %>
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
            
                <asp:Label ID="Labe" runat="server" Font-Underline="True" ForeColor="DarkRed" Text="KPI Pending for Approval"></asp:Label><br />
                <br />
                &nbsp;<asp:Panel ID="Panel1" runat="server" GroupingText="Select Yr & mon">
                <table style="width: 239px">
                    <tr>
                        <td style="width: 100px">
                            Select Year</td>
                        <td style="width: 100px">
                           <asp:DropDownList ID="ddlyr" runat="server">
                                <asp:ListItem Value=2010>2010-2011</asp:ListItem>
                                <asp:ListItem Value=2011>2011-2012</asp:ListItem>
                                <asp:ListItem Value=2012>2012-2013</asp:ListItem>
                                <asp:ListItem value=2013>2013-2014</asp:ListItem>
                                <asp:ListItem value=2014>2014-2015</asp:ListItem>
                                <asp:ListItem Value=2015>2015-2016</asp:ListItem>
                                <asp:ListItem Value=2016>2016-2017</asp:ListItem>
                                <asp:ListItem Value=2017>2017-2018</asp:ListItem>
                                <asp:ListItem Value=2018>2018-2019</asp:ListItem>
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlyr"
                                ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Select Month</td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlmon" runat="server">
                                <asp:ListItem Value="1">JAN</asp:ListItem>
                                <asp:ListItem Value="2">FEB</asp:ListItem>
                                <asp:ListItem Value="3">MAR</asp:ListItem>
                                <asp:ListItem Value="4">APR</asp:ListItem>
                                <asp:ListItem Value="5">MAY</asp:ListItem>
                                <asp:ListItem Value="6">JUNE</asp:ListItem>
                                <asp:ListItem Value="7">JULY</asp:ListItem>
                                <asp:ListItem Value="8">AUG</asp:ListItem>
                                <asp:ListItem Value="9">SEP</asp:ListItem>
                                <asp:ListItem Value="10">OCT</asp:ListItem>
                                <asp:ListItem Value="11">NOV</asp:ListItem>
                                <asp:ListItem Value="12">DEC</asp:ListItem>
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlmon"
                                ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px" align="right">
                            <asp:Button ID="btnshow" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
                    </tr>
                </table>
                </asp:Panel>
                <br />
                <asp:Panel ID="Panel2" runat="server">
                  <table>
                
                   <tr>
               <td style="background-color: #5d7b9d">
               <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
               Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtsearch1" runat="server"></asp:TextBox>
               <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid1" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsearch1"
                ErrorMessage="Enter Empid/EmpName to search" ForeColor="white" ValidationGroup="search">
                </asp:RequiredFieldValidator>
                </td>
            </tr>
                    <tr>
                        <td style="width: 100px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" ShowFooter="True" EmptyDataText="No Records found">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                         <asp:BoundField DataField="slno" HeaderText="Sno" InsertVisible="False" ReadOnly="True"
                            SortExpression="slno" />
                        <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="Empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:TemplateField HeaderText="Dept-sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                    ID="Label5" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Total" SortExpression="total">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txttotal" runat="server" Text='<%# Bind("total") %>' Width="77px" AutoPostBack =true OnTextChanged="Calculatetotal"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpression1" runat="server" ControlToValidate="txttotal"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Grade" SortExpression="grade">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("grade") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgrade" runat="server" Text='<%# Bind("grade") %>' ForeColor=red ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" SortExpression="status" >
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal"  SelectedValue='<%# Bind("Status") %>'>
                                    <asp:ListItem>Scheduled</asp:ListItem>
                                    <asp:ListItem Value="HODAPPROVED">HOD Approve</asp:ListItem>
                                     <asp:ListItem>Reject</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateKPIApproval" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                                        </FooterTemplate>
                        </asp:TemplateField>
                       
                       
                       
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EmptyDataRowStyle Font-Size="Medium" ForeColor="Red" />
                </asp:GridView>
                        </td>
                    </tr>
                        </table>
                        
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server">
                <table>
                
                
             <tr>
               <td style="background-color: #5d7b9d">
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
               Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtsearch2" runat="server"></asp:TextBox>
               <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid2" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsearch2"
                ErrorMessage="Enter Empid/EmpName to search" ForeColor="white" ValidationGroup="search">
                </asp:RequiredFieldValidator>
                </td>
            </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" ShowFooter="True" EmptyDataText="No Records found">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="slno" HeaderText="Sno" InsertVisible="False" ReadOnly="True"
                            SortExpression="slno" />
                        <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="Empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:TemplateField HeaderText="Dept-sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                    ID="Label5" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Total" SortExpression="total">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txttotal" runat="server" AutoPostBack="true" OnTextChanged="Calculatetotal2"
                                    Text='<%# Bind("total") %>' Width="77px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpression1" runat="server" ControlToValidate="txttotal"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Grade" SortExpression="grade">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("grade") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgrade" runat="server" ForeColor="red" Text='<%# Bind("grade") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" SortExpression="status" >
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal"  SelectedValue='<%# Bind("Status") %>'>
                                    <asp:ListItem>Scheduled</asp:ListItem>
                                    <asp:ListItem Value="HODAPPROVED">HOD Approve</asp:ListItem>
                                    <asp:ListItem>Reject</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateKPIApproval2" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EmptyDataRowStyle Font-Size="Medium" ForeColor="Red" />
                </asp:GridView>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                  
                &nbsp;
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,kpi_grade_result.total, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON kpi_grade_result.empcode = empmaster.empcode WHERE (kpi_grade_result.yr = @yr) AND (kpi_grade_result.mnth = @mon) AND (empmaster.departmentcode in (@dept)) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled'">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlyr" Name="YR" PropertyName="SelectedValue"  />
                        <asp:ControlParameter ControlID="ddlmon" Name="mon" PropertyName="SelectedValue"  />
                        <asp:ControlParameter ControlID="label1" Name="dept" PropertyName="text"  />
                       
                      </SelectParameters>
                </asp:SqlDataSource>
                &nbsp; &nbsp;
                &nbsp;&nbsp;<br />
                <asp:Label ID="Label1" runat="server" Visible="False">9000,2000</asp:Label></td>
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
