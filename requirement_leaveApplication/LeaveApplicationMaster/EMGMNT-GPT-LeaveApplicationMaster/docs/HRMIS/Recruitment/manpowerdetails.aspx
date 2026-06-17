<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="manpowerdetails.aspx.vb" Inherits="E_Management.manpowerdetails" 
    title="Untitled Page" %>
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
            <td bgcolor="#ffffff"  valign="top">
                <table>
                    <tr>
                        <td colspan="2" >
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" >
                                        <strong>MANPOWER DEATILS</strong></td>
                                </tr>
                                <tr>
                                    <td bgcolor="beige">
                                        Details By</td>
                                    <td>
                                        <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="597px">
                                            <asp:ListItem Value="D">Dept</asp:ListItem>
                                            <asp:ListItem Value="DSG">Desig</asp:ListItem>
                                            <asp:ListItem Value="S">Sec</asp:ListItem>
                                            <asp:ListItem Value="OP">OPERATORS</asp:ListItem>
                                            <asp:ListItem>ALL</asp:ListItem>
                                            <asp:ListItem Value="OA">Overall Summary</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td bgcolor="beige" >
                                        Department</td>
                                    <td >
                                        <asp:DropDownList ID="dept" runat="server" DataSourceID="SqlDataSource1"
                                            DataTextField="dept" DataValueField="departmentcode" AppendDataBoundItems="True">
                                            <asp:ListItem Value="-1">Select Department</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td bgcolor="beige" style="height: 24px" >
                                        Designation</td>
                                    <td style="height: 24px" >
                                        <asp:DropDownList ID="desig" runat="server" DataSourceID="SqlDesig"
                                            DataTextField="desig" DataValueField="desig" AppendDataBoundItems="True">
                                            <asp:ListItem Value="-1">Select Designation</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td bgcolor="beige">
                                        Section</td>
                                    <td >
                                        <asp:DropDownList ID="sect" runat="server" DataSourceID="SqlDataSource2" DataTextField="Column1"
                                            DataValueField="sectioncode" AppendDataBoundItems="True">
                                            <asp:ListItem Value="-1">Select Section</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td bgcolor="beige" >
                                        Operators</td>
                                    <td style="width: 403px">
                                        <asp:DropDownList ID="opr" runat="server">
                                            <asp:ListItem Value="LO">Local operators</asp:ListItem>
                                            <asp:ListItem Value="FO">Foreign operators</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="showrepOT" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select (LTRIM(RTRIM(designationname))) as desig from designation order by designationname">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode ">
                    </asp:SqlDataSource>
                           </table>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select sectioncode+'--'+sectionname,sectioncode from sectionmaster order by sectioncode">
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

