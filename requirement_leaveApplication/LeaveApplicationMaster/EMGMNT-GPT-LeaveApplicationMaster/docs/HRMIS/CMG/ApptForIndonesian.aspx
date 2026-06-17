<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ApptForIndonesian.aspx.vb" Inherits="E_Management.ApptForIndonesian" 
    title="APPOINTMENT LETTER FOR INDONESIANS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 16px; width: 3px;">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1111px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px; width: 3px;">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" style="width: 1111px">
                &nbsp;&nbsp;

<table id="TABLE2" style="height: 292px" border="1">
        <tr>
            <td style="height: 243px; width: 666px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="4" style="height: 12px" valign="top" align="left" class="td_head">
                            &nbsp;APPOINTMENT LETTER FOR INDONESIAN</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 26px; background-color: beige" valign="top">
                            EMPLOYEE DETAILS</td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Employee No.</td>
                        <td valign="top" align="left" colspan="3">
                    
                        <asp:TextBox ID="empno" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empno"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 295px; background-color: beige; height: 28px;" valign="top" align="left">
                            Department</td>
                        <td style="width: 305px;" valign="top" align="left">
                            <asp:Label ID="dept" runat="server"></asp:Label></td><td style="width: 364px; background-color: beige;" valign="top" align="left">
                            Designation</td>
                        <td align="left" style="width: 404px;" valign="top">
                            <asp:Label ID="desig" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 60px;" valign="top" align="left">
                            Employee Name</td>
                        <td style="width: 305px; height: 60px;" valign="top" align="left">
                            <asp:Label ID="empname" runat="server"></asp:Label></td><td style="width: 364px; background-color: beige; height: 60px;" valign="top" align="left">
                                Address 1</td>
                        <td align="left" style="width: 404px; height: 60px;" valign="top">
                            <asp:Label ID="addr1" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 58px;" valign="top" align="left">
                            Passport No.</td>
                        <td style="width: 305px; height: 58px;" valign="top" align="left">
                            <asp:Label ID="ppno" runat="server"></asp:Label></td><td style="background-color: beige; width: 364px; height: 58px;" valign="top" align="left">
                                Address 2</td>
                        <td align="left" style="width: 404px; height: 58px;" valign="top">
                            <asp:Label ID="addr2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 295px; background-color: beige; height: 54px;" valign="top" align="left">
                            Section Code</td>
                        <td style="width: 305px; height: 54px;" valign="top" align="left">
                            <asp:Label ID="sect" runat="server"></asp:Label></td>
                        <td style="background-color: beige; width: 364px; height: 54px;" valign="top" align="left">
                            Address 3</td>
                        <td align="left" style="width: 404px; height: 54px;" valign="top">
                            <asp:Label ID="addr3" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="labelmsg" runat="server"></asp:Label>
                <asp:Button ID="Saveaptindo" runat="server" Text="SAVE & PRINT" />
                &nbsp;</td>
        </tr>
    </table>
                &nbsp;&nbsp;
                <asp:Label ID="txtBirthDate" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="LblShowAge" runat="server" Visible="False"></asp:Label></td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 3px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1111px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>