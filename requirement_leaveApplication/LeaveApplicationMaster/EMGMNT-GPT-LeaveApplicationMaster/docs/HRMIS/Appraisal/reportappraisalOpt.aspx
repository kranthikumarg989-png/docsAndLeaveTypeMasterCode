<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="reportappraisalOpt.aspx.vb" Inherits="E_Management.reportappraisalOpt" 
  title="Operator Appraisal Report" %>
        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 372px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 372px" valign="top">
                <table>
                    <tr>
                        <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 295px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        Operator &nbsp;Appraisal Report Overall</td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label26" runat="server" Text="Report TimeLine" Width="143px"></asp:Label></td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:TextBox ID="txtfrom" runat="server" Width="87px"></asp:TextBox>
                                        ~
                                        <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                                    <cc1:CalendarExtender ID="ccefrom" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                                        PopupButtonID="txtfrom" TargetControlID="txtfrom">
                                    </cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="cceto" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                                        PopupButtonID="txtto" TargetControlID="txtto">
                                    </cc1:CalendarExtender>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 17px; background-color: beige">
                                        <asp:Label ID="Label27" runat="server" Text="Report By"></asp:Label></td>
                                    <td style="width: 403px; height: 17px">
                                        <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            Width="408px">
                                            <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                            <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                            <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                                    <td style="width: 403px; height: 24px">
                                        <asp:DropDownList ID="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                            DataTextField="dept" DataValueField="departmentcode">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="lblsectr" runat="server" Text="Select Section"></asp:Label></td>
                                    <td style="width: 403px; height: 24px">
                                        <asp:DropDownList ID="ddlsectrpt" runat="server" DataSourceID="sqlsect" DataTextField="section"
                                            DataValueField="sectioncode">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
                                    <td style="width: 403px">
                                        <asp:TextBox ID="txtempidr" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="Button1" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="height: 26px">
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" Visible="False">
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        &nbsp;<asp:LinkButton ID="Lnlappraisal" runat="server" CommandArgument='<%# Eval("Rno", "{0}") %>'
                                                            Font-Underline="True" ForeColor="Blue" OnCommand="Appraisal_view1" Text='<%# Bind("Rno") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        </asp:GridView>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sqlgrid" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT empmaster.empcode, app_staffappraisal.empcode AS Expr1, app_staffappraisal.dateappraisal, empmaster.empname, empmaster.designation, empmaster.sectioncode, empmaster.departmentcode, empmaster.category, app_staffappraisal.finalgrade, app_staffappraisal.finalpoints, app_staffappraisal.finalweightage, app_staffappraisal.status, app_staffappraisal.rno FROM app_staffappraisal INNER JOIN empmaster ON app_staffappraisal.empcode = empmaster.empcode">
                                        </asp:SqlDataSource>
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode ">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="Sqlsecdept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept">
                    </asp:SqlDataSource>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 372px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>

