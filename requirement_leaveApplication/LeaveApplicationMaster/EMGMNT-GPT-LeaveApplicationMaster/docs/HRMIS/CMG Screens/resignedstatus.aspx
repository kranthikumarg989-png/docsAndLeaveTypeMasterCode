<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="resignedstatus.aspx.vb" Inherits="E_Management.resignedstatus" 
    title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<script language="javascript" type="text/javascript">
<!--

function TABLE1_onclick() {

}

// -->
</script>

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
                <table id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
                    <tr>
                        <td class="td_head" colspan="4" width="25%">
                            <strong>RESIGNED STATUS UPDATE</strong></td>                      
                    </tr>
                    <tr>
                    <td width="25%" >
                        Employee No</td>
                    <td width="25%" ><asp:TextBox ID="empcode" runat="server" MaxLength="6" Width="80px" AutoPostBack="True"></asp:TextBox></td>
                    <td width="25%" >
                        Name</td>
                    <td width="25%" >
                        <asp:Label ID="name" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="25%">
                            Department</td>
                        <td width="25%">
                            <asp:Label ID="department" runat="server"></asp:Label></td>
                        <td width="25%">
                            Section</td>
                        <td width="25%">
                            <asp:Label ID="section" runat="server"></asp:Label></td>
                                              
                    </tr>
                  <tr>
                  <td width="25%" >
                      Resigned Date</td>
                  <td width="25%" >
                      <asp:TextBox ID="resigndate" runat="server" MaxLength="6" Width="80px"></asp:TextBox></td>
                  <td width="25%" >
                      Status</td>
                  <td width="25%" >
                      <asp:DropDownList ID="status" runat="server">
                          <asp:ListItem>Resigned</asp:ListItem>
                          <asp:ListItem>Abscond</asp:ListItem>
                          <asp:ListItem>Terminated</asp:ListItem>
                          <asp:ListItem>Contract Over</asp:ListItem>
                      </asp:DropDownList></td>
                      <tr>
                          <td width="25%">
                              Reason</td>
                          <td width="25%">
                              <asp:TextBox ID="reason" runat="server" MaxLength="6" TextMode="MultiLine" Width="98px"></asp:TextBox></td>
                          <td width="25%">
                          </td>
                          <td width="25%">
                              <asp:Button ID="save" runat="server" BackColor="LightSteelBlue" Text="Save" /></td>
                      </tr>
                  <tr>
                 </tr>
                </table>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" cssclass="cal_Theme1" format="dd/MM/yy" TargetControlID="resigndate">
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
