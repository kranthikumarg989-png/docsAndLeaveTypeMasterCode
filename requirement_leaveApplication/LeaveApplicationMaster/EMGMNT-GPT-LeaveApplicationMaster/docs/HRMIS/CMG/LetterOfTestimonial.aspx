<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="LetterOfTestimonial.aspx.vb" Inherits="E_Management.LetterOfTestimonial" 
    title="Letter Of Testimonial" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1196px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 622px; width: 1196px;">
                <table id="TABLE2" border="1">
                    <tr>
                        <td style="width: 654px; height: 198px; text-align: center;" align="center" valign="top">
                            <table cellpadding="1" cellspacing="1" id="TABLE1" onclick="return TABLE1_onclick()" >
                                <tbody>
                                    <tr>
                                        <td align="left" class="td_head" colspan="4" style="height: 12px; text-align: center"
                                            valign="top">
                                            &nbsp;LETTER OF TESTIMONIAL</td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 295px; height: 28px; background-color: beige" valign="top">
                                            Employee No.</td>
                                        <td align="left" style="width: 205px" valign="top">
                                            <asp:TextBox ID="empno" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>&nbsp;
                                            <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empno" ErrorMessage="!"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left" style="width: 364px; background-color: beige" valign="top">
                                            Employee Name</td>
                                        <td align="left" style="width: 404px" valign="top">
                                            <asp:Label ID="name" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 295px; height: 28px; background-color: beige" valign="top">
                                            Department</td>
                                        <td align="left" style="width: 205px" valign="top">
                                            <asp:Label ID="dept" runat="server"></asp:Label></td>
                                        <td align="left" style="width: 364px; background-color: beige" valign="top">
                                            Designation</td>
                                        <td align="left" style="width: 404px" valign="top">
                                            <asp:Label ID="desig" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 295px; height: 28px; background-color: beige" valign="top">
                                            Date Hired</td>
                                        <td align="left" style="width: 205px" valign="top">
                                            <asp:Label ID="doj" runat="server"></asp:Label></td>
                                        <td align="left" style="width: 364px; background-color: beige" valign="top">
                                            New ICNO</td>
                                        <td align="left" style="width: 404px" valign="top">
                                            <asp:Label ID="newicno" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="td_head" colspan="4" style="height: 12px; text-align: center"
                                            valign="top">
                                            &nbsp;LETTER DETAILS</td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 295px; height: 28px; background-color: beige" valign="top">
                                            Letter Date</td>
                                        <td align="left" style="width: 205px" valign="top">
                                            <asp:TextBox ID="letdt" runat="server" MaxLength="3" Width="179px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="letdt" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                        <td align="left" style="width: 364px; background-color: beige" valign="top">
                                            Working Till</td>
                                        <td align="left" style="width: 404px" valign="top">
                                            <asp:TextBox ID="wrktil" runat="server" Width="175px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="R3" runat="server" ControlToValidate="wrktil" ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:Label ID="labelmsg" runat="server"></asp:Label><br />
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="LoTsave" runat="server" Text="SAVE & PRINT" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                    </tr>
                </table>
                <cc1:calendarextender id="ltdt" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="letdt" targetcontrolid="letdt">
                </cc1:CalendarExtender><cc1:calendarextender id="worktill" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="wrktil" targetcontrolid="wrktil">
                </cc1:CalendarExtender>
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 622px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1196px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>