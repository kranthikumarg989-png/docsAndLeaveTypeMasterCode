<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/ems.Master" CodeBehind="jobinterviewstatus.aspx.vb" Inherits="E_Management.jobinterviewstatus" %>
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
<tr><td colspan="4" width="25%"></td></tr>
        <tr><td align="center" class="td_head" colspan="4" width="25%">Job Interview status</td></tr>
    <tr><td align="right" bgcolor="beige" colspan="4" width="25%">Date :<asp:Label ID="datetoday" runat="server"></asp:Label></td></tr>
    <tr>
        <td colspan="4" bgcolor="beige" width="25%">Applicant Details</td>
    </tr>
    <tr>
    <td width="25%" bgcolor="beige">Job Application no </td>
        <td width="25%" colspan="2"><asp:DropDownList ID="ddlapplno" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Column1" DataValueField="Column1" AppendDataBoundItems="True">
            <asp:ListItem Value="-1">-----------Select-------------</asp:ListItem>
        </asp:DropDownList>
            &nbsp;
        </td>
              <td width="25%" align="right" bgcolor="beige"><asp:LinkButton ID="lnkbtn" runat="server" Font-Underline="True" ForeColor="Blue" >View Details</asp:LinkButton></td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%" style="height: 21px">
            Name</td>
        <td  width="25%" >
            <asp:Label ID="name" runat="server"></asp:Label></td>
        <td align="right" bgcolor="beige" width="25%">Date Applied</td>
        <td  width="25%">
            <asp:Label ID="dateapplied" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%">
            Position Applied</td>
        <td width="25%">
            <asp:Label ID="position" runat="server"></asp:Label>
            &nbsp;</td>
        <td align="right" bgcolor="beige" width="25%">
            Interviewed by (empno)</td>
        <td width="25%">
            <asp:TextBox ID="intby" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%">
            Status</td>
        <td width="25%">
            <asp:DropDownList ID="status" runat="server" AutoPostBack="True">
                <asp:ListItem Value="-1">----- Select Result-----</asp:ListItem>
                <asp:ListItem>KIV</asp:ListItem>
                <asp:ListItem Value="REJ">REJ</asp:ListItem>
                <asp:ListItem Value="SEL">SEL</asp:ListItem>
                <asp:ListItem>S</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="right" bgcolor="beige" width="25%">
        </td>
        <td width="25%">
        </td>
    </tr>
    <tr>
        <td bgcolor="beige" colspan="4" width="25%" align="right"><asp:Button ID="save" runat="server" Text="Save" BackColor="Beige" />
            <input type="button" value="Exit" onclick="window.close()" style="background-color: beige" id="Button1"></td>      
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