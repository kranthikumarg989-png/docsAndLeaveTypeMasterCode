<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Selfstatus.aspx.vb" Inherits="E_Management.Selfstatus" 
    title="My Leave status" %>
        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table>
                    <tr>
                        <td class="td_head" style="height: 23px">
                            My Leave History / Status&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head" style="height: 23px">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="Sqlleave" ForeColor="#333333"
                                GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno" />
                                    <asp:BoundField DataField="applicationdate" DataFormatString="{0:dd/MM/yy}" HeaderText="AppliedOn"  HtmlEncode="False" 
                                        SortExpression="fromdate" />
                                    <asp:BoundField DataField="days" HeaderText="No.of Days" SortExpression="days" />
                                    <asp:TemplateField HeaderText="Applied Dates" SortExpression="fromdate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="leavetype" HeaderText="Type" SortExpression="leavetype" />
                                    <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" />
                                    <asp:BoundField DataField="statusreason" HeaderText="Remarks" SortExpression="statusreason" />
                                    <asp:TemplateField HeaderText="Status" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("appno", "{0}") %>'
                                                Text='<%# Eval("status") %>'> </asp:Label>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("appno", "{0}") %>'
                                                ForeColor="#0000C0" OnCommand="getLeaveData" Text='<%# Eval("status") %>'></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" CommandArgument='<%# Eval("appno", "{0}") %>'
                                                ForeColor="RED" OnCommand="leavecancel" Text="CANCEL"></asp:LinkButton>
                                            <cc1:confirmbuttonextender id="confirmgpcancel" runat="server" confirmonformsubmit="true"
                                                confirmtext="Are you sure you want to cancel the Leave" targetcontrolid="LinkButton5">
                           </cc1:confirmbuttonextender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="Sqlleave" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT * FROM [Leaveform] WHERE (([fromdate] >= @from) AND ([fromdate] <= DateAdd(d,90,@to))) AND ([empno] = @empcode)  order by appno desc">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="" Name="from" />
                                    <asp:Parameter DefaultValue="" Name="to" />
                                    <asp:Parameter DefaultValue="" Name="empcode" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            &nbsp;
                        </td>
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
