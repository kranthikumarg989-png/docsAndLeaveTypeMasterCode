<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="HODApproveSUbKPI.aspx.vb" Inherits="E_Management.HODApproveSUbKPI" 
    title="SUB KPI APPROVAL" %>
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
            <td bgcolor="#ffffff" valign="top">
                <table>
                    <tr>
                        <td align="center">
                            <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Black" Text="Sub KPI Records for Approval"
                                ></asp:Label></td>
                    </tr>
                      <tr>
               <td style="background-color: #5d7b9d">
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
               Text="SEARCH by Empcode/Name/Sect/Dept "></asp:Label>:<asp:TextBox ID="txtsearch1" runat="server"></asp:TextBox>
               <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid1" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsearch1"
                ErrorMessage="Enter Empid/EmpName to search" ForeColor="white" ValidationGroup="search">
                </asp:RequiredFieldValidator>
                </td>
            </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" ShowFooter="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Sub_KPINO" HeaderText="SubKPINo" InsertVisible="False"
                                        ReadOnly="True" SortExpression="Sub_KPINO" />
                                    <asp:BoundField DataField="Employee_Code" HeaderText="Empcode" SortExpression="Employee_Code" />
                                    <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                                    <asp:BoundField DataField="departmentcode" HeaderText="Dept" SortExpression="Department" />
                                    <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="Section" />
                                   
                                    <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                                    <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                                    <asp:TemplateField HeaderText="Q1" SortExpression="q1">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("q1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Q1" runat="server" Checked='<%# Bind("q1") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Q2" SortExpression="q2">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("q2") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Q2" runat="server" Checked='<%# Bind("q2") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Q3" SortExpression="q3">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("q3") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Q3" runat="server" Checked='<%# Bind("q3") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Q4" SortExpression="q4">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("q4") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Q4" runat="server" Checked='<%# Bind("q4") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="uom" HeaderText="UOM" SortExpression="uom" />
                                    <asp:TemplateField HeaderText="Cur-Tar" SortExpression="curent">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("curent") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("curent") %>'></asp:Label>~<asp:Label
                                                ID="Label2" runat="server" Text='<%# Eval("target") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UpdateBy" SortExpression="UpdBasis">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("UpdBasis") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="Rbupd" runat="server" SelectedValue='<%# Bind("UpdBasis") %>'>
                                                <asp:ListItem Value="D">Daily</asp:ListItem>
                                                <asp:ListItem Value="W">Weekly</asp:ListItem>
                                                <asp:ListItem Value="M">Monthly</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="Rbstatus" runat="server" SelectedValue='<%# Bind("Status") %>'>
                                                <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                                <asp:ListItem Value="A">Approve</asp:ListItem>
                                                <asp:ListItem Value="R">Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                          <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateLeaveApproval" SkinID="buttonskin1"
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
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT KPI_SubSetting.MajorKPI_Details, KPI_SubSetting.Sub_KPINO, KPI_SubSetting.SubKPI_Details, ltrim(rtrim(KPI_SubSetting.q4)) as q4, ltrim(rtrim(KPI_SubSetting.q3)) as q3, ltrim(rtrim(KPI_SubSetting.q2)) as q2, ltrim(rtrim(KPI_SubSetting.q1)) as q1, KPI_SubSetting.uom, KPI_SubSetting.curent, KPI_SubSetting.target, Ltrim(Rtrim(KPI_SubSetting.UpdBasis)) as updbasis, KPI_SubSetting.Status, KPI_SubSetting.Employee_Code, empmaster.empname FROM KPI_SubSetting INNER JOIN empmaster ON KPI_SubSetting.Employee_Code = empmaster.empcode WHERE (KPI_SubSetting.Status = 'S') AND (KPI_SubSetting.Department_Code = @Department_Code)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Department_Code" SessionField="_edept" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
        
        
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
