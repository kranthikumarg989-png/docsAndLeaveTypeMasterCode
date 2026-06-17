<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="empmasterrpt.aspx.vb" Inherits="E_Management.empmasterrpt" MasterPageFile="~/ems.Master" title="Print EmpMaster Data" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="height: 16px" width="16">
        </td>
        <td background="../../images/top_mid.gif" style="width: 1262px; height: 16px">
        </td>
        <td style="width: 24px; height: 16px">
        </td>
    </tr>
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

<table style="width: 1000px; height: 145px" id="TABLE2">
    <tr>
        <td style="width: 123px; height: 152px"><table id="Table3" border="1" cellpadding="1" cellspacing="1" onclick="return TABLE1_onclick()" style="width: 300px; height: 152px">
            <tr>
                <td align="left" colspan="2" style="height: 12px" valign="top">
                    <asp:Label ID="Label3" runat="server" Font-Underline="True" ForeColor="Maroon" Text="PRINT EMPLOYEE DETAILS" Width="397px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 429px; height: 39px; background-color: beige" valign="top">
                    <asp:Label ID="Label4" runat="server" Text="Employee Code" Width="132px"></asp:Label></td>
                <td align="left" style="width: 1215px; height: 39px" valign="top">
                    <asp:TextBox ID="empno" runat="server" Width="185px" AutoPostBack="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="empno" ErrorMessage="!"></asp:RequiredFieldValidator><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="measurementname"
                        ErrorMessage="Please Mention Measurement Name"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 53px; text-align: center" valign="middle">
                    &nbsp;<asp:Button ID="prinemp" runat="server" Text="PRINT" />&nbsp; &nbsp;&nbsp;</td>
            </tr>
        </table>
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
    </table></asp:Content>
