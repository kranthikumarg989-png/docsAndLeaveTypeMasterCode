<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptLeaveEntitilement.aspx.vb" Inherits="E_Management.RptLeaveEntitilement" 
    title="LEAVE ENTITILEMENT REPORT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 473px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 222px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 473px; height: 222px" valign="top">
                <table style="height: 175px">
                    <tr>
                        <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 187px" valign="top">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        Leave Entitilement Report</td>
                                </tr>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 14px; background-color: beige">
                                        <asp:Label ID="Label37" runat="server" Text="Report By"></asp:Label></td>
                                    <td style="width: 230px; height: 14px">
                                        <asp:RadioButtonList ID="rdoentby" runat="server" AutoPostBack="True" Height="19px"
                                            RepeatDirection="Horizontal" Width="307px">
                                            <asp:ListItem Value="Desig">By Deisgnation</asp:ListItem>
                                            <asp:ListItem Value="dept">ByDept</asp:ListItem>
                                            <asp:ListItem Value="emp">By Emp</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label38" runat="server" Text="Select Department"></asp:Label></td>
                                    <td style="width: 230px; height: 24px">
                                        <asp:DropDownList ID="ddlentdept" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                            DataTextField="dept" DataValueField="departmentcode">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label39" runat="server" Text="Select Designation"></asp:Label></td>
                                    <td style="width: 230px">
                                        <asp:DropDownList ID="ddlentdesig" runat="server" AutoPostBack="True" DataSourceID="SqlDesig"
                                            DataTextField="desig" DataValueField="desig">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        <asp:Label ID="lblemp" runat="server" Text="EmpCode"></asp:Label></td>
                                    <td style="width: 230px">
                                        <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Width="85px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="btnentrpt" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 222px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 473px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
    
      <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department">
                    </asp:SqlDataSource>
</asp:Content>
