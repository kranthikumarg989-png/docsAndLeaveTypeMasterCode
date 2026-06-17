<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PayrollLeaveCancel.aspx.vb" Inherits="E_Management.PayrollLeaveCancel" 
     title="PAYROLL LEAVE CANCELATION" %>
                <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 16px" width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table>
                    <tr>
                        <td class="td_head" style="height: 23px">
                            PAYROLL LEAVE CANCELLATION
                        </td>
                    </tr>
                    <tr>
                            <td style="height: 26px;">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                    Text="Key in empcode "></asp:Label>:<asp:TextBox ID="txtsearchapp" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2"
                        runat="server" ImageAlign="AbsMiddle" Height="20px"
                        ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGridapp" 
                        BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsearchapp"
                                    ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search"></asp:RequiredFieldValidator></td>
                        </tr>
                    <tr>
                        <td style="vertical-align: middle">
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:GridView ID="GrdLeaveCancel" runat="server" AllowPaging="false" AllowSorting="true"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlLeavecancel" ForeColor="#333333"
                                GridLines="None" ShowFooter="true" Visible="False">
                                <Columns>
                                    <asp:BoundField DataField="appno" HeaderText="appno" SortExpression="appno" />
                                    <asp:BoundField DataField="applicationdate" DataFormatString="{0:dd-MMM-yy}" HeaderText="Appliedon"  HtmlEncode="False" 
                                        SortExpression="applicationdate" />
                                    <asp:TemplateField HeaderText="EmpCode" SortExpression="empno">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empno") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Labeloremp" runat="server" Text='<%# Bind("empno") %>'></asp:Label>-
                                            <asp:Label ID="Labelprname" runat="server" Text='<%# Eval("empname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                                    <asp:TemplateField HeaderText="AppliedDates" SortExpression="fromdate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Labelprfrom" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                            <asp:Label ID="Labelprto" runat="server" Text='<%# Eval("todate", "{0:dd-MMM-yy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="grantedleave" HeaderText="GrantedDays" SortExpression="grantedleave" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="leavetype" HeaderText="leavetype" SortExpression="leavetype" />
                                    <asp:BoundField DataField="reason" HeaderText="reason" SortExpression="reason" />
                                    <asp:TemplateField HeaderText="status" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="rbprstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                                <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                                <asp:ListItem Value="CANCELLED">Cancel</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateLeavePRApproval" SkinID="buttonskin1"
                                                Text="CANCEL LEAVE" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
                                    <asp:BoundField DataField="carryfwd" HeaderText="cfwd" SortExpression="cfwd" />
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlLeavecancel" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT *,(Ltrim(rtrim(status))) as status, Empmaster.empname, Empmaster.designation, Empmaster.sectioncode, Empmaster.departmentcode FROM Leaveform Leaveform INNER JOIN Empmaster Empmaster ON (Empmaster.empcode = Leaveform.empno)  and (leaveform.fromdate >= @from) and (leaveform.todate <= @to) and (leaveform.status = 'APPROVED') ORDER BY APPNO DESC">
                                <SelectParameters>
                                    <asp:Parameter Name="from" />
                                    <asp:Parameter Name="to" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
