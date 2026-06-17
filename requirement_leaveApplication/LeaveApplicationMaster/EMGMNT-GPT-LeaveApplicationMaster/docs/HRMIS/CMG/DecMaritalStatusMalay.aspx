<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="DecMaritalStatusMalay.aspx.vb" Inherits="E_Management.DecMaritalStatusMalay" 
    title="Declaration of Marital Status (Malay)" %>
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

<table id="TABLE2" style="height: 292px" border="1">
        <tr>
            <td style="height: 335px; width: 405px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2" style="height: 12px" valign="top" align="left" class="td_head">
                            &nbsp;SURAT AKUAN TARAF PERKAWINAN</td>
                    </tr>
                    <tr>
                        <td style="width: 137px; background-color: beige; height: 25px;" valign="top" align="left">
                            Employee No.</td>
                        <td style="width: 272px;" valign="top" align="left" colspan="1">
                    
                        <asp:TextBox ID="empno" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empno"
                                    ErrorMessage="!" Width="1px"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 137px; background-color: beige; height: 25px;" valign="top" align="left">
                            Employee Name</td>
                        <td style="width: 272px;" valign="top" align="left" colspan="1">
                            <asp:Label ID="empname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 137px; height: 25px; background-color: beige" valign="top">
                            Designation</td>
                        <td align="left" colspan="1" style="width: 272px" valign="top">
                            <asp:Label ID="desig" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 137px; background-color: beige; height: 25px;" valign="top" align="left">
                            Department</td>
                        <td style="width: 272px;" valign="top" align="left" colspan="1">
                            <asp:Label ID="dept" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 137px; background-color: beige; height: 25px;" valign="top" align="left">
                            New
                            IC No.</td>
                        <td style="width: 272px;" valign="top" align="left" colspan="1">
                            <asp:Label ID="icno" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 137px; background-color: beige; height: 25px;" valign="top" align="left">
                            Section Code</td>
                        <td style="width: 272px;" valign="top" align="left" colspan="1">
                            <asp:Label ID="sect" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 137px; height: 25px; background-color: beige" valign="top">
                            Date Hired</td>
                        <td align="left" style="width: 272px" valign="top">
                            <asp:Label ID="doj" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 137px; height: 25px; background-color: beige" valign="top">
                            Letter Date</td>
                        <td align="left" style="width: 272px" valign="top">
                            <asp:TextBox ID="letdt" runat="server" Width="182px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RV1" runat="server" ControlToValidate="letdt" ErrorMessage="!"
                                Width="1px"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                <asp:Label ID="labelmsg" runat="server"></asp:Label><br />
                <asp:Button ID="Savemarstatus" runat="server" Text="SAVE & PRINT" /></td>
        </tr>
    </table>
                <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="letdt" targetcontrolid="letdt">
                                            </cc1:CalendarExtender>
                &nbsp;&nbsp;
    
       </td>
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