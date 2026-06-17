<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="man_recruitmentrequistion.aspx.vb" Inherits="E_Management.man_recruitmentrequistion" %>

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
<table >
    <tr>
        <td colspan="4" width="25%">
        </td>
    </tr>
<tr>
<td class="td_head" width="25%" align="center" colspan="4">NEW RECRUITMENT REQUISITION FORM</td>
</tr>
<tr>
<td width="25%" bgcolor="beige" colspan="4">Requestor Details </td>
</tr>
    <tr>
        <td align="right" width="25%" bgcolor="#f5f5dc">
            Req No :</td>
        <td width="25%">
            <asp:Label ID="reqno" runat="server"></asp:Label>
            </td>
        <td align="right" width="25%" bgcolor="#f5f5dc">Date :</td>
        <td width="25%"><asp:Label ID="lbldate" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td width="25%" align="right" bgcolor="#f5f5dc">Employee No :</td> 
        <td width="25%" ><asp:TextBox ID="empcode" runat="server" AutoPostBack="True"></asp:TextBox></td>
        <td width="25%" align="right" bgcolor="#f5f5dc" >Name :</td>
        <td width="25%" ><asp:Label ID="empname" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="right" width="25%" bgcolor="#f5f5dc">Section :</td>
        <td width="25%"><asp:Label ID="section" runat="server"></asp:Label></td>
        <td align="right" width="25%" bgcolor="#f5f5dc">
            Department :</td>
        <td width="25%"><asp:Label ID="department" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td colspan="4" bgcolor="beige">
        Requisition Details</td>
    </tr>
    <tr>
        <td align="right" width="25%" bgcolor="beige">
            Gender
        </td>
        <td width="25%"><asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="right" width="25%" bgcolor="beige">
            Date of Required</td>
        <td width="25%">
            <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td align="right" width="25%" style="height: 26px" bgcolor="beige"  >Post to be advertised/Filled</td>
        <td width="25%" style="height: 26px" ><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="designation" DataValueField="designation">
        </asp:DropDownList>
        </td>
        <td align="right" width="25%" style="height: 26px" bgcolor="beige" >
            Number of Vacancies :</td>
        <td width="25%" style="height: 26px">
            <asp:TextBox ID="noofvacancies" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right" width="25%" bgcolor="beige" >
            How did the Post fall Vacant</td>
        <td width="25%" >
            <asp:TextBox ID="vacantpost" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td align="right" width="25%" bgcolor="beige" >
            Educational Qualification</td>
        <td width="25%" ><asp:TextBox ID="qualific" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right"width="25%" bgcolor="beige" >Professional Qualification
        </td>
        <td  width="25%"><asp:TextBox ID="professional" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        
        <td align="right" width="25%" bgcolor="beige">Experience Details 
        </td>
        <td width="25%"><asp:TextBox ID="experience" runat="server" TextMode="MultiLine"></asp:TextBox></td>
      
    </tr>
    <tr>
        <td align="right" width="25%" bgcolor="beige" >Other Skills </td>
        <td  width="25%" ><asp:TextBox ID="otherskills" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        <td align="right"width="25%" bgcolor="beige">Job description</td>
        <td width="25%">
            <asp:TextBox ID="jobdesc" TextMode="MultiLine" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td width="25%" colspan="4" bgcolor="beige">
            Job Description</td>
           </tr>
    <tr>
    <td width="25%" align="right" bgcolor="beige">Primary Responsibilities</td>
        <td colspan="3" width="25%">
            <asp:TextBox ID="response" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" width="25%" align="right" >
            <asp:Button ID="save" runat="server" Text="Save" BackColor="Beige" /></td>
         <td colspan="2" width="25%">
            <input type="button" value="Exit" onclick="window.close()" style="background-color: beige" id="Button1"></td>
    </tr>
</table>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate">
    </cc1:CalendarExtender>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
            SelectCommand="select distinct(designation) from man_jobcode "></asp:SqlDataSource> 
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

