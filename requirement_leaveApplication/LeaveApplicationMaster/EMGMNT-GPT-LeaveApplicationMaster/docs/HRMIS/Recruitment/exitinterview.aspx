<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="exitinterview.aspx.vb" Inherits="E_Management.exitinterview" %>

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
<table><tr>
           <td colspan="4" width="25%">
            </td>
        </tr>
        <tr>
            <td align="center" class="td_head" colspan="4" width="25%">Exit Interview Form</td>
        </tr>
        <tr><td bgcolor="beige" colspan="4" width="25%" align="right" >Date :<asp:Label ID="datetoday" runat="server"></asp:Label></td></tr>
        <tr>
            <td align="right" bgcolor="beige" width="25%">Employee no</td>
            <td width="25%"><asp:TextBox ID="empcode" runat="server" AutoPostBack="True"></asp:TextBox></td>
            <td align="right" bgcolor="beige" width="25%">Name</td>
            <td width="25%"><asp:Label ID="empname" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" bgcolor="beige" width="25%">Section </td>
            <td width="25%"><asp:Label ID="section" runat="server"></asp:Label>
            </td>
            <td align="right" bgcolor="beige"width="25%">Department </td>
            <td width="25%"><asp:Label ID="department" runat="server"></asp:Label></td>
        </tr>
    <tr>
        <td colspan="4" bgcolor="beige" width="25%">
            Reason for leaving</td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb1" runat="server" Text="Better offer"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb2" runat="server" Text="No career prospect"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb3" runat="server" Text="poor working Environment"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb4" runat="server" Text="Long working hours"/></td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb5" runat="server" Text="Cannot adapt with Maruwa culture"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb6" runat="server" Text="Pressure by leaders"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb7" runat="server" Text="Personal reason"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb8" runat="server" Text="Relocation"/></td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb9" runat="server" Text="Health"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb10" runat="server" Text="Poor Supervision"/></td>
        <td bgcolor="beige" width="25%"><asp:CheckBox ID="cb11" runat="server" Text="Conflict with other employees"/></td>
        <td bgcolor="beige" width="25%"></td>
    </tr>
    <tr>
        <td bgcolor="beige" colspan="4" width="25%" >
            &nbsp;&nbsp;</td>        
    </tr>
     <tr>
        <td bgcolor="beige" width="25%">
            Please specify here in the item does not fit in the above :</td>
        <td width="25%"><asp:TextBox ID="others" runat="server"></asp:TextBox></td>
        <td width="25%"></td>
        <td width="25%"></td>
        </tr>
    <tr>
        <td bgcolor="beige" width="25%">
            What did you like least about your job?</td>
        <td width="25%">
            <asp:TextBox ID="likeleast" runat="server" Width="290" TextMode="MultiLine"></asp:TextBox></td>
        <td  width="25%"></td>
        <td width="25%"></td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%">
            How would you describe the work environment in your department? (i.e. relaxed,tense,stresed,competitive,etc)</td>
        <td width="25%"><asp:TextBox ID="deptenv" runat="server" Width="290" TextMode="MultiLine"></asp:TextBox></td>
        <td width="25%"></td>
        <td width="25%"></td>
    </tr>
    <tr>
        <td bgcolor="beige" width="25%">
            What barrier's, if any,hindered getting your effectiveness? what could Maruwa have
            done to help you be more effective?</td>
        <td width="25%"><asp:TextBox ID="barriers" runat="server" Width="290" TextMode="MultiLine"></asp:TextBox></td>
        <td width="25%"></td>
        <td width="25%"></td>
    </tr>
    <tr><td bgcolor="beige" colspan="4" width="25%">Problem in Relationships</td></tr>
    <tr><td bgcolor="beige" width="25%">Did you encounter any problems in your relationship with?</td></tr>
    <tr>
    <td bgcolor="beige" width="25%">
        Supervisors</td><td width="25%"><asp:TextBox ID="supervisor" runat="server" Width="290" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
     <tr>
    <td bgcolor="beige" width="25%">
        Peers</td><td width="25%"><asp:TextBox ID="peers" runat="server" Width="290" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
     <tr>
    <td bgcolor="beige" width="25%">
        Subordinates</td><td width="25%"><asp:TextBox ID="subordinates" runat="server" Width="290" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
     <tr>
    <td bgcolor="beige" width="25%">Are there any other comments or observations you wish to share?</td>
        <td width="25%"><asp:TextBox ID="comments" runat="server" Width="290" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige" colspan="4" width="25%">Uniform Return Details</td>      
    </tr>
    <tr>
        <td bgcolor="beige" width="25%">Uniform Returned &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
        <td width="25%"><asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N">No</asp:ListItem>
        </asp:RadioButtonList></td>                            
    </tr>
    <tr>
        <td bgcolor="beige" width="25%">Uniform Return Date</td>
        <td width="25%"><asp:TextBox ID="uniformdate" runat="server"></asp:TextBox></td>
       </tr>
    <tr>
        <td bgcolor="beige" width="25%" ></td>
        <td bgcolor="beige" width="25%" >
            <asp:Button ID="save" runat="server" Text="Save" BackColor="Beige" />
            &nbsp;&nbsp;
            <input type="button" value="Exit" onclick="window.close()" style="background-color: beige" id="Button1"></td>
    </tr>
       </table>      
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="uniformdate">
    </cc1:CalendarExtender>
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
   </asp:Content>

