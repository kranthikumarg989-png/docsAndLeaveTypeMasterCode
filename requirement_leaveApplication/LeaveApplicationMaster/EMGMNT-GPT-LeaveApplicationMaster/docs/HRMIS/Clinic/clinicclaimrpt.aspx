<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="clinicclaimrpt.aspx.vb" Inherits="E_Management.clinicclaimrpt" 
    title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px" valign="top">
                <table id="TABLE2" language="javascript" onclick="return TABLE1_onclick()">
                    <tr>
                        <td class="td_head" colspan="2" >
                            CLINIC CLAIM REPORT</td>                      
                    </tr>
                    <tr>
                    <td bgcolor="beige">
                        Select Date :</td>
                    <td >
                        <asp:TextBox ID="fromdt" runat="server" ForeColor="Gray" Width="75px">From date</asp:TextBox>~<asp:TextBox
                            ID="todt" runat="server" ForeColor="Gray" Width="75px">To date</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td bgcolor="beige" >
                            Claim :</td>
                        <td >
                            <asp:DropDownList ID="claim" runat="server">
                                <asp:ListItem>Individual</asp:ListItem>
                                <asp:ListItem>Panel</asp:ListItem>
                            </asp:DropDownList><asp:CheckBox ID="cb1" runat="server" Text="All" AutoPostBack="True" /></td>
                                              
                    </tr>
                  <tr>
                  <td bgcolor="beige" >
                      Employee No :</td>
                  <td >
                      <asp:TextBox ID="empcode" runat="server" Width="75px"></asp:TextBox><asp:CheckBox
                          ID="cb2" runat="server" Text="All Emp" AutoPostBack="True" /></td>
                      <tr>
                          <td colspan="2" align="right">
                              <asp:Button ID="save" runat="server" BackColor="LightSteelBlue" Text="Save" /></td>
                      </tr>
                      </table>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" cssclass="cal_Theme1" format="dd/MM/yy" popupbuttonid="fromdt" targetcontrolid="fromdt">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" cssclass="cal_Theme1" format="dd/MM/yy" popupbuttonid="todt" targetcontrolid="todt">
                </cc1:CalendarExtender>
                
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
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
</asp:Content>

