<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="WeeklyMaxOThrs.aspx.vb" Inherits="E_Management.WeeklyMaxOThrs" 
    title="Maximum OT hours in a week" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table style="width: 1000px; height: 145px" id="TABLE2" onclick="return TABLE2_onclick()">
        <tr>
            <td style="height: 249px;" valign="top" colspan="2">
                <table id="TABLE1" style="width: 550px; height: 14px" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left" colspan="2" style="background-color: beige" valign="middle">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="SET MAXIMUM WEEKLY OT HOURS"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60px; background-color: beige;" valign="middle" align="left">
                            <asp:Label ID="MH" runat="server" Text="Maximum Hours" Width="129px"></asp:Label></td>
                        <td style="width: 1094px;" valign="middle" align="left">
                            <asp:TextBox ID="maxhrs" runat="server" MaxLength="3" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="maxhrs"
                                    ErrorMessage="Please Mention Maximum OT Hours"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="maxhrs"></asp:RegularExpressionValidator></td></tr>
                    <tr>
                        <td style="width: 287px; height: 3px;" valign="top">
                            <asp:Label ID="lbledit" runat="server" Text="-" Visible="False" Width="32px"></asp:Label></td>
                        <td align="left" style="width: 1094px; height: 3px;" valign="top">
                <asp:Button ID="SubmitOT" runat="server" Text="SUBMIT" />&nbsp; &nbsp;<asp:Button ID="cancelOT" runat="server" Text="CANCEL" /></td>
                    <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label></tr>
                </table>
                <br />
                &nbsp;&nbsp;
                </td>
        </tr>
    </table>
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>