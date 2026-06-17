<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptOTBudgetSetting.aspx.vb" Inherits="E_Management.RptOTBudgetSetting" 
    title="OT BUDGET SETTING REPORT" StylesheetTheme="buttonems" %>
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
               
    <table>
        <tr>
            <td colspan="2">
                <strong><span style="font-size: 10pt">Select an option for OT Budget Setting Reports</span>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                From Date</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtfrom" runat="server" Width="76px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                    SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                To Date</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 162px">
                <asp:Panel ID="Panel1" runat="server" GroupingText="Select Report Option" Width="100%">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="OD">By Department</asp:ListItem>
                    <asp:ListItem Value="S">By Section</asp:ListItem>
                    <asp:ListItem Value="IS">By  Individual Section</asp:ListItem>
                    <asp:ListItem Value="CSO">Overall Dept  by Staff &amp; Opt</asp:ListItem>
                    <asp:ListItem Value="OSO">Overall Staff and Operator</asp:ListItem>
                </asp:RadioButtonList></asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:DropDownList ID="ddldeptr" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode"
                    Visible="False">
                    <asp:ListItem Selected="True" Value="-1">--Select a Department--</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:DropDownList ID="ddlsectrpt" runat="server" AppendDataBoundItems="True" DataSourceID="selsectreport"
                    DataTextField="sectioncode" DataValueField="sectioncode" Visible="False">
                    <asp:ListItem Selected="True" Value="-1">--Select a Section--</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                &nbsp;
                <asp:Button ID="btnshow" runat="server" Text="SHOW" SkinID="buttonskin1" /></td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
                &nbsp;
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
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
       <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                    <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
</asp:Content>
