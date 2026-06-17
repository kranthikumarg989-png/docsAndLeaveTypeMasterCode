<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="IndustrialTraining.aspx.vb" Inherits="E_Management.IndustrialTraining" 
    title="Industrial Training Offer" %>
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

<table id="TABLE2">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 615px; height: 21px; background-color: tan;">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Black" Text="OFFER FOR INDUSTRIAL TRAINING IN MARUWA (M) SDN. BHD."></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 615px; height: 227px; text-align: left;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1" style="background-color: tan"><tr>
                    <td style="background-color: tan; height: 25px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Name" Width="49px"></asp:Label></td>
                    <td style="height: 25px; width: 147px; background-color: tan;" valign="top" align="left">
                        <asp:TextBox ID="name" runat="server" Width="171px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="name" ErrorMessage="Name !"
                            InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td style="background-color: tan; width: 104px;" valign="top" align="left">
                        <asp:Label ID="Label14" runat="server" Text="IC No." Width="46px"></asp:Label></td>
                    <td style="height: 25px; background-color: tan;" valign="top" align="left">
                        <asp:TextBox ID="icno" runat="server" Width="170px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="V2" runat="server" ControlToValidate="icno" ErrorMessage="IC No. !"
                            InitialValue="-1"></asp:RequiredFieldValidator></td>
                </tr>
                    <tr>
                        <td style="background-color: tan; height: 11px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Address 1" Width="77px"></asp:Label></td>
                        <td style="width: 147px; height: 11px; background-color: tan;" valign="top" align="left">
                            <asp:TextBox ID="add1" runat="server" TextMode="MultiLine" Width="170px"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="V3" runat="server" ControlToValidate="add1" ErrorMessage="Address 1 !"
                                InitialValue="-1"></asp:RequiredFieldValidator></td>
                        <td align="left" style="width: 104px; background-color: tan;" valign="top">
                            <asp:Label ID="Label20" runat="server" Text="Address 2" Width="70px"></asp:Label></td>
                        <td align="left" style="height: 11px; width: 215px; background-color: tan;" valign="top" colspan="3">
                            <asp:TextBox ID="add2" runat="server" TextMode="MultiLine" Width="170px"></asp:TextBox><br />
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6" style="height: 5px;" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" style="height: 11px; background-color: beige" valign="middle">
                            <table id="Table3" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td style="width: 91px; background-color: beige; height: 11px;" valign="top" align="left">
                                        <asp:Label ID="label28" runat="server" Text="Letter Date" Width="77px"></asp:Label></td>
                                    <td style="width: 182px; height: 11px;" valign="top" align="left">
                                        <asp:TextBox ID="letdt" runat="server" Width="170px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="V4" runat="server" ControlToValidate="letdt" ErrorMessage="Letter Date !"></asp:RequiredFieldValidator><cc1:calendarextender id="C1" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="letdt" targetcontrolid="letdt"></cc1:calendarextender></td>
                                    <td align="left" style="width: 122px; background-color: beige; height: 11px;" valign="top">
                                        <asp:Label ID="Label25" runat="server" Text="Application Date" Width="107px"></asp:Label></td>
                                    <td align="left" style="height: 11px; width: 222px;" valign="top" colspan="3">
                                        <asp:TextBox ID="applndt" runat="server" Width="170px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="V20" runat="server" ControlToValidate="applndt" ErrorMessage="App. Date !"></asp:RequiredFieldValidator><cc1:calendarextender id="C2" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="applndt" targetcontrolid="applndt"></cc1:calendarextender></td>
                                </tr>
                            </table>
                            <table id="Table4" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td style="width: 91px; background-color: beige; height: 11px;" valign="top" align="left">
                                        <asp:Label ID="label8" runat="server" Text="Training Programme From Date" Width="77px"></asp:Label></td>
                                    <td style="width: 179px; height: 11px;" valign="top" align="left">
                                        <asp:TextBox ID="prgmfrm" runat="server" Width="170px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="V34" runat="server" ControlToValidate="prgmfrm" ErrorMessage="Training from Date !"></asp:RequiredFieldValidator>
                                        <cc1:calendarextender id="C3" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy" targetcontrolid="prgmfrm">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td align="left" style="width: 123px; background-color: beige; height: 11px;" valign="top">
                                        <asp:Label ID="Label15" runat="server" Text="Training Programme To Date" Width="86px"></asp:Label></td>
                                    <td align="left" style="height: 11px; width: 209px;" valign="top" colspan="3">
                                        <asp:TextBox ID="prgmto" runat="server" Width="170px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="V36" runat="server" ControlToValidate="prgmto" ErrorMessage="Training to Date !"
                                            InitialValue="-1"></asp:RequiredFieldValidator>
                                        <cc1:calendarextender id="C4" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy" targetcontrolid="prgmto">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                            </table><table id="Table5" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td style="width: 91px; background-color: beige; height: 11px;" valign="top" align="left">
                                        <asp:Label ID="label30" runat="server" Text="Department" Width="77px"></asp:Label></td>
                                    <td style="width: 179px; height: 11px;" valign="top" align="left">
                                        <asp:TextBox ID="dept" runat="server" Width="170px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="V30" runat="server" ControlToValidate="dept" ErrorMessage="Department !"
                                            InitialValue="-1"></asp:RequiredFieldValidator></td>
                                    <td align="left" style="width: 124px; background-color: beige; height: 11px;" valign="top">
                                        <asp:Label ID="Label31" runat="server" Text="Duration (in weeks)" Width="60px"></asp:Label></td>
                                    <td align="left" style="height: 11px; width: 207px;" valign="top" colspan="3">
                                        <asp:TextBox ID="duration" runat="server" Width="170px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="V32" runat="server" ControlToValidate="duration"
                                            ErrorMessage="Duration !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" style="height: 49px; text-align: center;" valign="middle">
                            <asp:Button ID="SAVEIT" runat="server" Text=" SAVE & PRINT" />
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                &nbsp;<asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
                &nbsp; &nbsp;
                &nbsp;&nbsp;<br />
                &nbsp; &nbsp;
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