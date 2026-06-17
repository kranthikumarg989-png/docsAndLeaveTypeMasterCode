<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="HODapprovalLeaveabsentism.aspx.vb" Inherits="E_Management.HODapprovalLeaveabsentism" 
    title="HOD Approval - Leave Absentism" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon"
                    Text="MISCONDUCT ENTRIES  - PENDING HOD APPROVAL"></asp:Label>&nbsp;&nbsp;
                    <table>
            <tr>
                <td colspan="2" valign="top" style="height: 934px; width: 1104px;">
                    &nbsp;&nbsp;<br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333"
                        GridLines="None" EmptyDataText="No records" ShowFooter="True" CaptionAlign="Left">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="recordno" HeaderText="Rec. No." SortExpression="recordno" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="empno" HeaderText="Empno" SortExpression="empno" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Expr1" HeaderText="EmpName" SortExpression="empname" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="departmentcode" HeaderText="Dept" SortExpression="dept" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sectioncode" HeaderText="Sect" SortExpression="sect" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fromdate" HeaderText="FromDate" SortExpression="fromdate" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="todate" HeaderText="ToDate" SortExpression="todate" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="leavetype" HeaderText="LeaveType" SortExpression="leavetype" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Late Details" SortExpression="latehours">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("latehours") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("latehours") %>'></asp:Label>
                                    <asp:Label ID="lblhrs" runat="server" Text="hrs & " Visible="False"></asp:Label>
                                    <asp:Label
                                        ID="Label2" runat="server" Text='<%# Bind("latemins") %>'></asp:Label>
                                    <asp:Label ID="lblmins" runat="server" Text="mins" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl" runat="server" Text="-"></asp:Label>
                                    <asp:Label
                                            ID="Label3" runat="server" Text='<%# Bind("latefrom") %>'></asp:Label>
                                    <asp:Label ID="lblto" runat="server" Text="to"></asp:Label>
                                    <asp:Label
                                                ID="Label4" runat="server" Text='<%# Bind("lateto") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Remarks"  SortExpression="remark">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" ></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="TextBox15" runat="server" Height="50px"></asp:TextBox>
                            </ItemTemplate>
                               <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                             <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:RadioButtonList ID="rb" runat="server" width="75px">
                                    <asp:ListItem Value="s" Selected="True">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="A">Approve</asp:ListItem>
                                    <asp:ListItem Value="R">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                                     </ItemTemplate>
                                     <FooterTemplate>
                                <asp:Button ID="Button3" runat="server" OnClick="HodapprovalLeave" Text="SUBMIT" />
                            </FooterTemplate>                     
                            <HeaderStyle HorizontalAlign="Left" />
                               
                        </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White"/>
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT distinct tmp_leaveabsentism.recordno, tmp_leaveabsentism.empno, tmp_leaveabsentism.empname, tmp_leaveabsentism.dept, tmp_leaveabsentism.sect, tmp_leaveabsentism.fromdate, tmp_leaveabsentism.todate, tmp_leaveabsentism.leavetype, tmp_leaveabsentism.latehours, tmp_leaveabsentism.reason, tmp_leaveabsentism.latemins, tmp_leaveabsentism.latefrom, tmp_leaveabsentism.lateto, tmp_leaveabsentism.status, empmaster.empname AS Expr1, empmaster.departmentcode, empmaster.sectioncode FROM tmp_leaveabsentism INNER JOIN empmaster ON tmp_leaveabsentism.empno = empmaster.empcode">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 1104px">
                </td>
            </tr>
        </table>
    &nbsp;&nbsp;
    <br />
         </asp:Content>
       

