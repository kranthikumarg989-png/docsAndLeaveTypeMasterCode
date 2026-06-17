<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="jobapplicationreport.aspx.vb" Inherits="E_Management.jobapplicationreport" 
    title="Untitled Page" %>
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
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2">
                                        <strong>JOB APPLICATION REPORTS</strong></td>
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
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Select Type</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                            <asp:ListItem Value="desi">Designation</asp:ListItem>
                                            <asp:ListItem Value="as">Applicationstatus</asp:ListItem>
                                            <asp:ListItem Value="at">Applied Throw</asp:ListItem>
                                            <asp:ListItem Value="a" Selected="True">All</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 26px; background-color: beige">
                                        Designation</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:DropDownList ID="ddldesi" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="designationname">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Application Status</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:DropDownList ID="ddlas" runat="server">
                                            <asp:ListItem>Select status</asp:ListItem>
                                            <asp:ListItem>KIV</asp:ListItem>
                                            <asp:ListItem>REJECT</asp:ListItem>
                                            <asp:ListItem Value="S">PENDING</asp:ListItem>
                                            <asp:ListItem Value="Sel">Selected</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 24px; background-color: beige">
                                        Application Throw</td>
                                    <td style="width: 403px; height: 26px">
                                        <asp:DropDownList ID="ddlat" runat="server">
                                            <asp:ListItem Value="-1">Select status</asp:ListItem>
                                            <asp:ListItem Value="IN">Internet</asp:ListItem>
                                            <asp:ListItem Value="LO">Local</asp:ListItem>
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
                  
                </table>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select designationname from designation"></asp:SqlDataSource>

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

