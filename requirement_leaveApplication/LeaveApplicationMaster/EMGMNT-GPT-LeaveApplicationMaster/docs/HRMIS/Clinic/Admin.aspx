<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Admin.aspx.vb" Inherits="E_Management.Admin" 
    title="CLINIC ADMIN ENTRY" %>
                <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<div align = "center">

    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="ADMIN CLINIC DETAILS ENTRY"></asp:Label><br />
    <hr color="silver" width="75%" />
    &nbsp;<br />
      <table cellpadding="0" cellspacing="0" >
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
    <table>
        <tr>
            <td >
                <asp:Panel ID="Panel2" runat="server" GroupingText="Employee Details">
                    <table style="vertical-align: middle; text-align: left">
                        <tr>
                            <td colspan="2" style="font-weight: bold; font-variant: normal">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                            <td colspan="1" style="font-weight: bold; width: 158px; font-variant: normal">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-variant: normal;">
                                Employee Code
                            </td>
                            <td style="width: 103px">
                                <asp:Label ID="txtempcode" runat="server"></asp:Label></td>
                            <td style="width: 158px">
                                <asp:DropDownList ID="DDLEmpcode" runat="server" Width="320px" Enabled="False" AutoPostBack="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr style="color: #000000">
                            <td style="font-weight: bold; font-variant: normal;">
                                Employee Name</td>
                            <td style="width: 103px" >
                                <asp:Label ID="txtempname" runat="server"  ></asp:Label></td>
                            <td style="width: 158px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-variant: normal;">
                                Dept - Sect</td>
                            <td style="width: 103px" >
                                <asp:Label ID="txtdept" runat="server"> </asp:Label></td>
                            <td style="width: 158px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-variant: normal;">
                                Balance Amount (RM)</td>
                            <td style="width: 103px" >
                                &nbsp;<asp:Label ID="lblbal" runat="server" BackColor="Yellow" Font-Bold="True" ForeColor="#C04000"></asp:Label></td>
                            <td style="width: 158px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-variant: normal; height: 26px;">
                                Symptoms</td>
                            <td style="width: 103px; height: 26px" >
                                <asp:Label ID="txtsymptom" runat="server" ></asp:Label></td>
                            <td style="width: 158px; height: 26px">
                                <asp:DropDownList ID="CmbReason" runat="server" AutoPostBack="True" CssClass="form-control"
                                    Font-Size="9pt" ForeColor="Black" Width="320px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; height: 26px; font-variant: normal">
                            </td>
                            <td style="width: 103px; height: 26px">
                            </td>
                            <td style="width: 158px; height: 26px">
                                <asp:TextBox ID="TxtOthers" runat="server" AutoPostBack="True" TextMode="MultiLine"
                                    Width="309px" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; height: 26px; font-variant: normal">
                            </td>
                            <td style="width: 103px; height: 26px">
                                <asp:Label ID="LblAppliedDate" runat="server">Visit Date</asp:Label></td>
                            <td style="width: 158px; height: 26px">
                                <asp:TextBox ID="TxtAppliedOn" runat="server" Visible="False" Width="104px" AutoPostBack="True"></asp:TextBox></td>
                                 <cc1:calendarextender id="Calendarextender1" runat="server" cssclass="cal_Theme1" format="dd-MMM-yyyy"
                                            popupbuttonid="TxtAppliedOn" targetcontrolid="TxtAppliedOn"></cc1:calendarextender>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-variant: normal">
                                Clinic Name</td>
                            <td colspan="2">
                                <asp:DropDownList ID="DDLClinicName" runat="server" Width="424px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-variant: normal">
                                Bill Number</td>
                            <td colspan="2">
                                <asp:TextBox ID="TxtBillNo" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Treatement Details">
                    <table style="vertical-align: middle; text-align: left">
                        <tr style="color: #000000">
                            <td style=" background-color: beige; ">
                                Clinic Cost</td>
                            <td>
                                <asp:TextBox ID="txtcost" runat="server" Width="73px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtcost"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="78px"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcost"
                                    ErrorMessage="Key in Cost!!"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="background-color: beige; ">
                                MC</td>
                            <td >
                                <asp:RadioButtonList ID="rdomc" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style=" background-color: beige; height: 26px;">
                                <asp:Label ID="LBLFROM" runat="server" Text="MC Date" Visible="False"></asp:Label></td>
                            <td style="height: 26px" >
                                <asp:TextBox ID="txtfrom" runat="server" Visible="False" Width="66px"></asp:TextBox>&nbsp;
                                
                                <asp:Label ID="lblsym" runat="server" Text="~" Width="2px" Visible="False"></asp:Label>
                                <asp:TextBox ID="txtto" runat="server" Visible="False" Width="65px"></asp:TextBox></td>
                                  <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                            popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                        <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                            popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                        </tr>
                        <tr>
                            <td style=" background-color: beige; ">
                                <asp:Label ID="lbldays" runat="server" Text="No.Of Days" Visible="False"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="txtdays" runat="server" Visible="False" Width="65px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style=" background-color: beige;">
                                Remarks (If any)</td>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td align="right" >
                                <asp:Button ID="Button1" runat="server" Text="SAVE" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbldate" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="LBLPASS" runat="server" Visible="False"></asp:Label></td>
        </tr>
    </table>
                </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; ">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
    <br />
    <hr color="silver" width="75%" />
    &nbsp;<br />
    &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
        NavigateUrl="~/HRMIS/Clinic/clinicpassqueue.aspx">Back To List</asp:HyperLink></div>
</asp:Content>

                                 