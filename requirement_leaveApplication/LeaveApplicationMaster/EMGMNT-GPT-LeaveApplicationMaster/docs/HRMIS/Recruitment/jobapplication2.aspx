<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="jobapplication2.aspx.vb" Inherits="E_Management.jobapplication2" %>

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
            <td colspan="5" align="center" class="td_head">
                JOB APPLICATION</td>
        </tr>
        <tr>
            <td colspan="5" class="td_head" >
                EDUCATIONAL DETAILS</td>
        </tr>
    <tr>
        <td bgcolor="beige">
            Study Level</td>
        <td bgcolor="beige">
            Name of School?/Institution</td>
        <td bgcolor="beige">
            Grade</td>
        <td bgcolor="beige">
            Join Date</td>
        <td bgcolor="beige">
            Left date</td>
       </tr>
    <tr>
        <td bgcolor="beige" >
            Primary</td>
        <td bgcolor="beige" >
            <asp:TextBox ID="sch1" runat="server" ></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="highpass1" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="joined1" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="left1" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            Secondary</td>
        <td bgcolor="beige">
            <asp:TextBox ID="sch2" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="highpass2" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="joined2" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="left2" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige" >
            College/University/Others</td>
        <td bgcolor="beige" >
            <asp:TextBox ID="sch3" runat="server" ></asp:TextBox></td>
        <td bgcolor="beige" >
            <asp:TextBox ID="highpass3" runat="server"></asp:TextBox></td>
        <td bgcolor="beige" >
            <asp:TextBox ID="joined3" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="left3" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            Additional Certificate</td>
        <td bgcolor="beige" >
            <asp:TextBox ID="sch4" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="highpass4" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="joined4" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="left4" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            Sports Activities</td>
        <td bgcolor="beige"colspan="4">
            <asp:TextBox ID="sports" runat="server" TextMode="MultiLine"></asp:TextBox></td>
       
    </tr>
    <tr>
        <td colspan="5" class="td_head">
            WORK EXPERIENCE</td>
        
    </tr>
    <tr>
        <td bgcolor="beige">
            Company Name</td>
        <td bgcolor="beige">
            Telephone.no &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            Date</td>
        <td bgcolor="beige">
            Job Title</td>
        <td bgcolor="beige">
            Duties &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Lastsalary</td>
        <td bgcolor="beige">
            Reason for Leaving</td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:TextBox ID="cmpny1" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="cphone1" runat="server" Width="110px"></asp:TextBox>&nbsp; 
            <asp:TextBox ID="cdate1" runat="server" Width="65px"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="ctitle1" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="cduties1" runat="server"></asp:TextBox>&nbsp;
            <asp:TextBox ID="csalary1" runat="server" Width="65px" ></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="reason1" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:TextBox ID="cmpny2" runat="server"></asp:TextBox></td>
        <td bgcolor="beige" >
            <asp:TextBox ID="cphone2" runat="server" Width="110px"></asp:TextBox>
            &nbsp; 
            <asp:TextBox ID="cdate2" runat="server" Width="65px"></asp:TextBox></td>
        <td bgcolor="beige" >
            <asp:TextBox ID="ctitle2" runat="server"></asp:TextBox></td>
        <td bgcolor="beige" >
            <asp:TextBox ID="cduties2" runat="server"></asp:TextBox>&nbsp;
            <asp:TextBox ID="csalary2" runat="server" Width="65px"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="reason2" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:TextBox ID="cmpny3" runat="server"></asp:TextBox></td>
        <td bgcolor="beige" >
            <asp:TextBox ID="cphone3" runat="server" Width="110px"></asp:TextBox>
            &nbsp; 
            <asp:TextBox ID="cdate3" runat="server" Width="65px"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="ctitle3" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="cduties3" runat="server"></asp:TextBox>&nbsp;
            <asp:TextBox ID="csalary3" runat="server" Width="65px"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="reason3" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige">
            <asp:TextBox ID="cmpny4" runat="server"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="cphone4" runat="server" Width="110px"></asp:TextBox>
            &nbsp; 
            <asp:TextBox ID="cdate4" runat="server" Width="65px"></asp:TextBox></td>
        <td bgcolor="beige">
            <asp:TextBox ID="ctitle4" runat="server"></asp:TextBox></td>
        <td bgcolor="beige" >
            <asp:TextBox ID="cduties4" runat="server"></asp:TextBox>&nbsp;
            <asp:TextBox ID="csalary4" runat="server" Width="65px"></asp:TextBox></td>
        <td bgcolor="beige" width="20%">
            <asp:TextBox ID="reason4" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td bgcolor="beige" ></td>
        <td bgcolor="beige" ></td>
        <td bgcolor="beige" ></td>             
        <td bgcolor="beige" ></td>
        <td bgcolor="beige" ><asp:Button ID="Button2" runat="server" Text="<< back" BackColor="Beige" />
        <asp:Button ID="savenxt" runat="server" BackColor="Beige" Text="Save & Next >>" Width="105px" />
        </td>
    </tr>
    </table> 
    <cc1:CalendarExtender ID="Calendar1" TargetControlID="joined1" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar2" TargetControlID="left1" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar3" TargetControlID="cdate1" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar4" TargetControlID="joined2" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar5" TargetControlID="left2" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar6" TargetControlID="cdate2" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar7" TargetControlID="joined3" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar8" TargetControlID="left3" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar9" TargetControlID="cdate3" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar10" TargetControlID="joined4" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendar11" TargetControlID="left4" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="calendar12" TargetControlID="cdate4" runat="server"></cc1:CalendarExtender>
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
