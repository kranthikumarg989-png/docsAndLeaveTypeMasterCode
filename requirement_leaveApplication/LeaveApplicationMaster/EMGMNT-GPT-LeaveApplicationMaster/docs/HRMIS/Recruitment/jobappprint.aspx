<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="jobappprint.aspx.vb" Inherits="E_Management.jobappprint" 
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
            <td bgcolor="#ffffff" style="height: 372px" valign="top">
<table>
        <tr><td class="td_head" colspan="3" >
            JOB
            APPLICATION PRINT</td></tr>
        <tr>
            <td bgcolor="beige" width="10%">
                Application No</td>
            <td bgcolor="beige" width="25%">
                <asp:DropDownList ID="ddlapplno" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Column1" DataValueField="Column1">
                    <asp:ListItem>Select Application No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="10%">
            </td>
            <td bgcolor="beige" width="25%" align="center">
               <asp:Button ID="view" runat="server" BackColor="Beige" Text="View" />
                &nbsp;&nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select convert(varchar(20), applicationno) +'--' + name +'--'+ positionapplied +'--'+ status from jobapplication where status<>'REJ' and status<>'SEL' order by applicationno desc">
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