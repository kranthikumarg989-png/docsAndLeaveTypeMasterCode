<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="man_recruitmentrequistionRHR.aspx.vb" Inherits="E_Management.man_recruitmentrequistionRHR" 
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
<table border="0" bordercolor="beige" bordercolorlight="beige" >
    <tr>
        <td colspan="4" width="25%">
        </td>
    </tr>
    <tr>
<td class="td_head" width="25%" align="center" colspan="4" style="height: 21px">REPLACEMENT REQUISITION FORM</td>
</tr>
<tr>
<td width="25%" bgcolor="beige" colspan="4">Requestor Details </td>
</tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">
            Req no&nbsp;
        </td>
        <td width="25%">
            <asp:Label ID="reqno" runat="server"></asp:Label>
        </td>
        <td align="right" bgcolor="beige" width="25%">
            Date
        </td>
        <td style="width: 25%">
            <asp:Label ID="datetoday" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">Employee No :</td> 
        <td width="25%" >
            <asp:TextBox ID="empcode" runat="server" AutoPostBack="True"></asp:TextBox></td>
        <td width="25%" align="right" bgcolor="beige" >Name :</td>
        <td style="width: 25%" >
            <asp:Label ID="name" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%; height: 21px;" >Section :</td>
        <td width="25%" style="height: 21px">
            <asp:Label ID="section" runat="server"></asp:Label></td>
        <td align="right" width="25%" bgcolor="beige" style="height: 21px">
            Department :</td>
        <td style="width: 25%; height: 21px;">
            <asp:Label ID="dept" runat="server"></asp:Label>
            &nbsp;</td>
    </tr>
     <tr><td colspan="4" bgcolor="beige">
         Left Employee Details</td></tr> 
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">Previous Empno
        </td>
        <td width="25%">
            <asp:TextBox ID="empcodepre" runat="server" AutoPostBack="True"></asp:TextBox></td>
        <td align="right" width="25%" bgcolor="beige">Name</td>
        <td style="width: 25%"><asp:Label ID="namepre" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">Section</td>
        <td width="25%"><asp:Label ID="sectionpre" runat="server"></asp:Label></td>
        <td align="right" width="25%" bgcolor="beige">Department</td>
        <td style="width: 25%"><asp:Label ID="deptpre" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">Designation</td>
        <td width="25%"><asp:Label ID="desigpre" runat="server"></asp:Label></td>
        <td align="right" width="25%" bgcolor="beige">Reason for leaving</td>
        <td style="width: 25%"><asp:TextBox ID="reasonpre" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige" colspan="4" width="25%">
            Replacement Requirements</td>
        </tr>
    <tr>
        <td bgcolor="beige" align="right" style="width: 25%">
            Gender&nbsp;</td>
         <td width="25%">
             <asp:DropDownList ID="gender" runat="server">
                 <asp:ListItem Value="M">Male</asp:ListItem>
                 <asp:ListItem Value="F">Female</asp:ListItem>
             </asp:DropDownList></td>
          <td bgcolor="beige" align="right" width="25%">
              Date&nbsp; of Required&nbsp;
          </td>
          <td style="width: 25%">
              <asp:TextBox ID="datetojoin" runat="server"></asp:TextBox></td>
        
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">
            Replacement on temporary</td>
        <td width="25%">
            <asp:DropDownList ID="temp" runat="server">
                <asp:ListItem Value="N">No</asp:ListItem>
                <asp:ListItem Value="Y">Yes</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="right" bgcolor="beige" width="25%">
            No of months(if temporary)</td>
        <td style="width: 25%">
            <asp:TextBox ID="tempmonth" runat="server" MaxLength="2"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">
            Required designation
        </td>
        <td width="25%">
            <asp:DropDownList ID="ddldesig" runat="server" DataSourceID="SqlDataSource1" DataTextField="designation" DataValueField="designation">
            </asp:DropDownList>
        </td>
        <td align="right" bgcolor="beige" width="25%">
            Educational Qualification
        </td>
        <td style="width: 25%">
            <asp:TextBox ID="edu" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">
            Job description
        </td>
        <td width="25%">
            <asp:TextBox ID="job" TextMode="MultiLine"  runat="server"></asp:TextBox>
        </td>
        <td align="right" bgcolor="beige" width="25%">
            Professional qualifications
        </td>
        <td style="width: 25%"><asp:TextBox ID="prof" TextMode="MultiLine"  runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="beige" style="width: 25%">
            Experience details
        </td>
        <td width="25%"><asp:TextBox ID="exp" TextMode="MultiLine"  runat="server"></asp:TextBox>
        </td>
        <td align="right" bgcolor="beige" width="25%">
            Other skills
        </td>
        <td style="width: 25%"><asp:TextBox ID="otherskills" TextMode="MultiLine"  runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" colspan="4" width="25%"><asp:Button ID="save" runat="server" Text="Save" BackColor="Beige" />  <input type="button" value="Exit" onclick="window.close()" style="background-color: beige" id="Button1">
        </td>       
    </tr>
    </table> 
    <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="datetojoin" runat="server">
    </cc1:CalendarExtender>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                SelectCommand="select DISTINCT designation from empmaster"></asp:SqlDataSource>
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

