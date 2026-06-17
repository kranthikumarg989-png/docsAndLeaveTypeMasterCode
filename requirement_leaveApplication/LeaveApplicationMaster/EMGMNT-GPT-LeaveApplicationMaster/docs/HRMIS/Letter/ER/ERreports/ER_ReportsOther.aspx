<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ER_ReportsOther.aspx.vb" Inherits="E_Management.ER_ReportsOther" 
    title="ER Reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                        <td colspan="2" style="height: 136px" >
                            <table border="1">
                                <tr>
                                    <td class="td_head" colspan="2">
                                        <strong>ER REPORTS</strong></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Date Field</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:TextBox ID="txtfrom" runat="server" Width="98px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom"
                                            ErrorMessage="!"></asp:RequiredFieldValidator>~
                                        <asp:TextBox ID="txtto" runat="server" Height="14px" Width="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
                                            ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                    <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                    <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Select type</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:RadioButtonList ID="rb1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="226px">
                                            <asp:ListItem Value="emp">By Emp</asp:ListItem>
                                            <asp:ListItem Value="dpt">By Dept</asp:ListItem>
                                            <asp:ListItem Value="sec">By sect</asp:ListItem>
                                            <asp:ListItem Value="all">All</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rb1"
                                            ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 26px; background-color: beige">
                                        Employee No</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:TextBox ID="empcode" runat="server" Width="107px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 26px; background-color: beige">
                                        Department</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:DropDownList ID="dept" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1"
                                            DataTextField="fs" DataValueField="departmentcode" Width="277px">
                                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Section</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:DropDownList ID="sect" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="Column1" DataValueField="sectioncode" Width="276px">
                                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Select Letter Name</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:DropDownList ID="lettername" runat="server" Width="278px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px; text-align: center;">
                                        &nbsp;<asp:Button ID="showrepOT" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                         </td>
                    </tr>
                  
                </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select departmentcode + '- '+departmentname as fs,departmentcode from department order by departmentcode">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select sectioncode+'-'+sectionname,sectioncode from sectionmaster order by sectioncode">
                </asp:SqlDataSource>

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
