<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="JSReport.aspx.vb" Inherits="E_Management.JSReport" 
    %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<TABLE cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR><TD width=16><IMG height=16 src="../../images/top_lef.gif" 
width=16 /></TD><TD 
background="../../images/top_mid.gif" height=16><IMG height=16 src="../../images/top_mid.gif" 
width=16 /></TD><TD style="WIDTH: 25px"><IMG height=16 src="../../images/top_rig.gif" 
width=24 /></TD></TR><TR><TD style="HEIGHT: 372px" width=16 
background="../../images/cen_lef.gif"><IMG 
height=11 src="../../images/cen_lef.gif" width=16 /></TD><TD style="HEIGHT: 372px" vAlign=top 
bgColor=#ffffff><TABLE><TBODY><TR><TD 
style="WIDTH: 776px; BORDER-BOTTOM: 2px solid; HEIGHT: 295px" colSpan=2><TABLE><TBODY><TR><TD style="HEIGHT: 24px" class="td_head" 
colSpan=2>
    JS Report Overall</TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 17px; BACKGROUND-COLOR: beige"><asp:Label id="Label27" runat="server" Text="Report By"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 17px"><asp:RadioButtonList id="rdoptions" runat="server" Width="408px" AutoPostBack="True" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                        <asp:ListItem Value="Sect">BySect</asp:ListItem>
                        <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                    </asp:RadioButtonList></TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</TD><TD 
style="WIDTH: 403px; HEIGHT: 24px"><asp:DropDownList id="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataValueField="departmentcode" DataTextField="dept" AppendDataBoundItems="True" Enabled="False">
    <asp:ListItem Value="-1">-Select Dept-</asp:ListItem>
                    </asp:DropDownList> </TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="lblsectr" runat="server" Text="Select Section"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 24px"><asp:DropDownList id="ddlsectrpt" runat="server" DataSourceID="selsectreport" DataValueField="sectioncode" DataTextField="sect" AppendDataBoundItems="True" AutoPostBack="True" Enabled="False">
    <asp:ListItem Selected="True" Value="-1">-Select Sect-</asp:ListItem>
                    </asp:DropDownList></TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 24px; BACKGROUND-COLOR: beige"><asp:Label id="lbldesigr" runat="server" Text="Select Designation"></asp:Label></TD><TD 
style="WIDTH: 403px; HEIGHT: 24px"><asp:DropDownList id="ddldesigr" runat="server" AutoPostBack="True" DataSourceID="SqlDesig" DataValueField="desig" DataTextField="desig" AppendDataBoundItems="True" Enabled="False">
    <asp:ListItem Selected="True" Value="-1">-Select Designation-</asp:ListItem>
                    </asp:DropDownList> </TD></TR><TR><TD 
style="WIDTH: 148px; HEIGHT: 26px; BACKGROUND-COLOR: beige"><asp:Label id="lblempr" runat="server" Text="ByEmployee"></asp:Label></TD><TD 
style="WIDTH: 403px; height: 26px;"><asp:TextBox id="txtempidr" runat="server" Width="83px" AutoPostBack="True" Enabled="False"></asp:TextBox></TD></TR>
    <tr>
        <td align="left" colspan="2" style="height: 26px">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataSourceID="sqlreport" ForeColor="#333333" GridLines="Vertical" AllowPaging="True" PageSize="20" Width="560px" AllowSorting="True">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                       <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" OnCommand  ="PrintJs" Font-Underline="True"
                                ForeColor="#5D7B9D" Text='<%# Eval("empcode") %>'  CommandArgument='<%# Eval("empcode", "{0}") %>'></asp:LinkButton>                                                      
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                    <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                    <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
                    <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:SqlDataSource ID="sqlreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                SelectCommand="SELECT [empcode], [empname], [designation], [departmentcode], [sectioncode],Category FROM [empmaster] WHERE (([empcode] = @empcode) or ([departmentcode] = @departmentcode) or ([sectioncode] = @sectioncode) or([designation] = @designation)) AND(([empcode] <> @empcode2) AND ([designation] <> @designation2)) and resigned = 'N'">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtempidr" Name="empcode" PropertyName="Text" />
                    <asp:ControlParameter ControlID="ddldeptr" Name="departmentcode" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="ddlsectrpt" Name="sectioncode" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="ddldesigr" Name="designation" PropertyName="SelectedValue" />
                    <asp:Parameter DefaultValue="SAFE001" Name="empcode2" />
                    <asp:Parameter DefaultValue="Operator" Name="designation2" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource id="selsectreport" runat="server" SelectCommand="SELECT [sectioncode] + '-' + sectionname as sect, sectioncode FROM [sectionmaster] order by sectioncode " ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"></asp:SqlDataSource> 
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333"
                GridLines="Vertical" PageSize="20" Width="558px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                     <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                       <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="False" OnCommand  ="PrintJs" Font-Underline="True"
                                ForeColor="#5D7B9D" Text='<%# Eval("empcode") %>'  CommandArgument='<%# Eval("empcode", "{0}") %>'></asp:LinkButton>                                                      
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                    <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                    <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                    <asp:BoundField DataField="departmentcode" HeaderText="Department" SortExpression="departmentcode" />
                    <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                SelectCommand="SELECT [empcode], [empname], [designation], [sectioncode], [departmentcode], [category] FROM [empmaster] WHERE ([resigned] = @resigned) ORDER BY [empcode]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="N" Name="resigned" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
</TBODY></TABLE>
    &nbsp;
</TD></TR><asp:SqlDataSource id="sqlsect" runat="server" SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource><asp:SqlDataSource id="SqlDesig" runat="server" SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation order by designationname" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource><asp:SqlDataSource id="SqlDataSource1" runat="server" SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode " ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource><asp:SqlDataSource id="Sqlsecdept" runat="server" SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>">
                    </asp:SqlDataSource></TBODY></TABLE></TD><TD 
style="WIDTH: 25px; HEIGHT: 372px" background="../../images/cen_rig.gif"><IMG height=11 src="../../images/cen_rig.gif" 
width=24 /></TD></TR><TR><TD width=16 height=16><IMG height=16 src="../../images/bot_lef.gif" 
width=16 /></TD><TD 
background="../../images/bot_mid.gif" height=16><IMG height=16 src="../../images/bot_mid.gif" 
width=16 /></TD><TD style="WIDTH: 25px" 
height=16><IMG height=16 
src="../../images/bot_rig.gif" width=24 
/></TD></TR></TBODY></TABLE>
</asp:Content>
