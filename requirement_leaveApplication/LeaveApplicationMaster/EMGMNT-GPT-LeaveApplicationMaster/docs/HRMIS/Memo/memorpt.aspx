<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="memorpt.aspx.vb" Inherits="E_Management.memorpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
 <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px" valign="top">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td class="td_head" colspan="2" style="height: 24px">
                                                    Select Report Field</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 148px; height: 24px; background-color: beige">
                                                    <asp:Label ID="Label26" runat="server" Text="Report TimeLine" Width="143px"></asp:Label></td>
                                                <td style="width: 403px; height: 26px">
                                                    <asp:TextBox ID="tb1" runat="server" Width="87px"></asp:TextBox>
                                                    ~
                                                    <asp:TextBox ID="tb2" runat="server" Height="14px" Width="77px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tb2">*</asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tb1"
                                                        SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                                                
                                            </tr>
                                            <tr>
                                                <td style="width: 148px; height: 10px; background-color: beige">
                                                    <asp:Label ID="Label27" runat="server" Text="Report By"></asp:Label></td>
                                                <td style="width: 403px; height: 10px">
                                                    <asp:RadioButtonList ID="rbl1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                        Width="408px">
                                                        <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 148px; height: 24px; background-color: beige">
                                                    <asp:Label ID="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                                                <td style="width: 403px; height: 24px">
                                                    <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                                        DataTextField="dept" DataValueField="departmentcode">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 148px; height: 26px; background-color: beige">
                                                    <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
                                                <td style="width: 403px; height: 26px;">
                                                    <asp:TextBox ID="tb3" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2" style="height: 26px">
                                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" SkinID="buttonskin1"
                                                        Text="SHOW REPORT" />
                                                </td>
                                            </tr>
                                            </tbody>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333"
                                        Height="1px" AllowPaging="True" AllowSorting="True" PageSize="25" AutoGenerateColumns="False" DataKeyNames="Serialno" GridLines="None">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="Serialno" HeaderText="Serialno" ReadOnly="True" SortExpression="Serialno" />
                                            <asp:BoundField DataField="Emp_no" HeaderText="Emp. No" SortExpression="Emp_no" />
                                            <asp:BoundField DataField="Emp_name" HeaderText="Emp. Name" SortExpression="Emp_name" />
                                            <asp:BoundField DataField="Dept" HeaderText="Department" SortExpression="Dept" />
                                            <asp:BoundField DataField="Sumit_date" HeaderText="Submit Date" ReadOnly="True" SortExpression="Sumit_date" dataformatstring="{0:dd-MMM-yyy}" HtmlEncode=False />
                                            <asp:BoundField DataField="To_dept" HeaderText="To Dept" SortExpression="To_dept" />
                                            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                                            <asp:BoundField DataField="Approvedby" HeaderText="Approvedby" SortExpression="Approvedby" />
                                            <asp:BoundField DataField="Approved_date" HeaderText="Approved_date" ReadOnly="True" SortExpression="Approved_date" dataformatstring="{0:dd-MMM-yyy}" HtmlEncode=False />
                                        <asp:HyperLinkField DataNavigateUrlFields="serialno" DataNavigateUrlFormatString="memoreportapp.aspx?slno={0}"
                                                HeaderText="View" Target="_blank" Text="view">
                                                <ControlStyle Font-Underline="True" />
                                            </asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select Serialno,Emp_no,Emp_name,Dept,CONVERT(VARCHAR(10),sumit_date,110)as Sumit_date,To_dept,Subject,Approvedby,CONVERT(VARCHAR(10),approved_date,110)as Approved_date from memo ">
                </asp:SqlDataSource>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tb1">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tb2">
                    </cc1:CalendarExtender>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode">
                            </asp:SqlDataSource>
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

