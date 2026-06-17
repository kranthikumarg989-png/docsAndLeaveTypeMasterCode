<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TrainingRpts.aspx.vb" Inherits="E_Management.TrainingRpts" 
    title="Training Reports" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
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
                    <tr>
                        <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 295px">
                            <table>
                                <tr>
                                    <td class="td_head" colspan="2" style="height: 24px">
                                        <strong>TRAINING REPORTS</strong></td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 26px; background-color: beige">
                                        <asp:Label ID="Label26" runat="server" Text="Report TimeLine" Width="143px" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 26px">
                                        <asp:TextBox ID="txtfrom" runat="server" Width="115px"></asp:TextBox>
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                         
                                         <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                        &nbsp;
                                                                                    ~
                                        <asp:TextBox ID="txtto" runat="server" Height="14px" Width="115px"></asp:TextBox>
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                         <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfrom"
                                    ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtto"
                                    ErrorMessage="Please Select End Date"></asp:RequiredFieldValidator></td>
                                   
                                   
                                   
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 14px; background-color: beige">
                                        <asp:Label ID="Label27" runat="server" Text="Report By" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 14px" valign="middle">
                                        <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            Width="583px">
                                            <asp:ListItem Value="Dept">Dept</asp:ListItem>
                                            <asp:ListItem>PrgmCategory</asp:ListItem>
                                            <asp:ListItem>Training</asp:ListItem>
                                            <asp:ListItem Value="Emp">Emp</asp:ListItem>
                                            <asp:ListItem>Dept&amp;Desig</asp:ListItem>
                                            <asp:ListItem Value="Sect">Sect</asp:ListItem>
                                            <asp:ListItem Value="Desig">Desig</asp:ListItem>
                                            <asp:ListItem>Method</asp:ListItem>
                                            <asp:ListItem>Type</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="O">* (ALL)</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="lbldeptr" runat="server" Text="Select Department" Font-Bold="False"></asp:Label>&nbsp;</td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="ddldept" runat="server" DataSourceID="SqlDataSource1"
                                            DataTextField="dept" DataValueField="departmentcode" Width="260px" AutoPostBack="True" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label31" runat="server" Text="Select Programme Category" Width="177px" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="ddlpc" runat="server" DataSourceID="SqlDataSource2"
                                            DataTextField="td_programme" DataValueField="td_programme" Width="260px" AutoPostBack="True" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Method" Width="177px"></asp:Label></td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="CmbMethod" runat="server" Width="260px">
                                            <asp:ListItem>THEORY</asp:ListItem>
                                            <asp:ListItem>PRACTICAL</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="Type"
                                            Width="177px"></asp:Label></td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="CmbType" runat="server" Width="260px">
                                            <asp:ListItem>INTERNAL</asp:ListItem>
                                            <asp:ListItem>EXTERNAL PROVIDER</asp:ListItem>
                                            <asp:ListItem>PUBLIC TRAINING</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label11" runat="server" Text="Select Training" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="ddltr" runat="server" DataSourceID="SqlDataSource3" Width="260px" AutoPostBack="True" AppendDataBoundItems="True" DataTextField="td_trainingattended" DataValueField="td_trainingattended">
                                            <asp:ListItem Selected="True" Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 26px; background-color: beige">
                                        <asp:Label ID="Label1" runat="server" Text="ByEmployee" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 26px;">
                                        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" Width="253px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 65px; background-color: beige">
                                        <asp:Label ID="Label21" runat="server" Text="Select Dept & Desig" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 65px">
                                        <asp:DropDownList ID="ddl2" runat="server" DataSourceID="SqlDataSource1"
                                            DataTextField="dept" DataValueField="departmentcode" Width="260px" AutoPostBack="True" AppendDataBoundItems="True" >
                                            <asp:ListItem Selected="True" Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList><br />
                                        <br />
                                        <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" DataSourceID="SqlDesig"
                                            DataTextField="desig" DataValueField="desig" Width="260px" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="Label2" runat="server" Text="Select Section" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="ddlsect" runat="server"  DataTextField="sectioncode"
                                            DataValueField="sectioncode" DataSourceID="selsectreport" Width="260px" AutoPostBack="True" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1">---select---</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                        <asp:Label ID="lbldesigr" runat="server" Text="Select Designation" Font-Bold="False"></asp:Label></td>
                                    <td style="width: 575px; height: 24px">
                                        <asp:DropDownList ID="ddldesig" runat="server" AutoPostBack="True" DataSourceID="SqlDesig"
                                            DataTextField="desig" DataValueField="desig" Width="260px" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 241px; height: 24px; background-color: beige">
                                    </td>
                                    <td style="width: 575px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 26px">
                                        &nbsp;<asp:Button ID="showtTrainingReport" runat="server" SkinID="buttonskin1" Text="SHOW REPORT" />
                                    </td>
                                </tr>
                            </table>
                            <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [sectionmaster] ORDER BY [sectioncode]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT td_programme FROM td_employeetraining ORDER BY td_programme ">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT td_trainingattended FROM td_employeetraining ORDER BY td_trainingattended">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT LTRIM(RTRIM(designationname)) AS desig FROM designation ORDER BY LTRIM(RTRIM(designationname))">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT departmentcode + '-' + departmentname AS dept, departmentcode FROM department ORDER BY departmentcode + '-' + departmentname">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="Sqlsecdept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept">
                    </asp:SqlDataSource>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 372px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        
    </table>
</asp:Content>
