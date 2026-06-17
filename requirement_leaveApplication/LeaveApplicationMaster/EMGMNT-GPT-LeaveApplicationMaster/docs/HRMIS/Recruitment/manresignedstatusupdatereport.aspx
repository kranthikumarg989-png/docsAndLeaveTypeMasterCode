<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="manresignedstatusupdatereport.aspx.vb" Inherits="E_Management.manresignedstatusupdatereport" 
    title="REPLACEMENT REPORTS" %>
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
                        <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 295px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        <strong>RECRUITMENT REPORTS</strong></td>
                                </tr>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        REPLACEMENT REPORTS</td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Replacement Status</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:DropDownList ID="status" runat="server">
                                            <asp:ListItem Value="P">Pending</asp:ListItem>
                                            <asp:ListItem Value="O">Onhold</asp:ListItem>
                                            <asp:ListItem Value="H">Hired</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CheckBox ID="cb1" runat="server" AutoPostBack="True" Text="By using status" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label26" runat="server" Text="Report TimeLine" Width="143px"></asp:Label></td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:TextBox ID="txtfrom" runat="server" Width="87px"></asp:TextBox>
                                        ~
                                        <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"></asp:TextBox>&nbsp;
                                    </td>
                                    <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                    <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 17px; background-color: beige">
                                        <asp:Label ID="Label27" runat="server" Text="Report By"></asp:Label></td>
                                    <td style="width: 403px; height: 17px">
                                        <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            Width="437px">
                                            <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                            <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                            <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                                            <asp:ListItem Value="DD">By Dept &amp; Desig</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="A">* (ALL)</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                                    <td style="width: 403px; height: 24px">
                                        <asp:DropDownList ID="ddldeptr" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                            DataTextField="dept" DataValueField="departmentcode" AppendDataBoundItems="True">
                                            <asp:ListItem Value="-1">select</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="lblsectr" runat="server" Text="Select Section"></asp:Label></td>
                                    <td style="width: 403px; height: 24px">
                                        <asp:DropDownList ID="ddlsectrpt" runat="server" DataSourceID="selsectreport" DataTextField="sectioncode"
                                            DataValueField="sectioncode" AppendDataBoundItems="True">
                                            <asp:ListItem Value="-1">select</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="lbldesigr" runat="server" Text="Select Designation"></asp:Label></td>
                                    <td style="width: 403px; height: 24px">
                                        <asp:DropDownList ID="ddldesigr" runat="server" AutoPostBack="True" DataSourceID="SqlDesig"
                                            DataTextField="desig" DataValueField="desig" AppendDataBoundItems="True">
                                            <asp:ListItem Value="-1">select</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        By option</td>
                                    <td style="width: 403px">
                                        <asp:DropDownList ID="stscommon" runat="server">
                                            <asp:ListItem Value="-1">select</asp:ListItem>
                                            <asp:ListItem Value="P">Pending</asp:ListItem>
                                            <asp:ListItem Value="O">Onhold</asp:ListItem>
                                            <asp:ListItem Value="H">Hired</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="showrepOT" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                       <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster order by sectioncode">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation order by designationname">
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
