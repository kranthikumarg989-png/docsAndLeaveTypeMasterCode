<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BreakTimeMonitoring.aspx.vb" Inherits="E_Management.BreakTimeMonitoring" MasterPageFile="~/ems.Master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	

<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" alt="" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" alt="" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel1" runat="server">
                            
                            
                            
                            
                            
                            
                       <TABLE align=center><TBODY>
                           <tr>
                               <td colspan="5" style="text-align: center; background-color: beige;">
                                   <strong>
                                   Staff Break Time Monitoring Report<br />
                                       <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                           DataTextField="departmentname" DataValueField="departmentcode">
                                       </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
                                           SelectCommand="exec Sp_GetDepts1"></asp:SqlDataSource>
                                   </strong></td>
                           </tr>
                           <TR><TD style="TEXT-ALIGN: left; background-color: beige;"><asp:Label id="Label1" runat="server" Width="75px" Text="From Date"></asp:Label></TD><TD 
style="TEXT-ALIGN: left">
                           <asp:TextBox ID="TxtFrm" runat="server"></asp:TextBox><cc1:calendarextender id="Dt1"
                               runat="server" popupbuttonid="TxtFrm" targetcontrolid="TxtFrm">
                    </cc1:calendarextender></TD><TD style="TEXT-ALIGN: left; background-color: beige;"><asp:Label id="Label2" runat="server" Width="75px" Text="To Date"></asp:Label></TD><TD 
style="TEXT-ALIGN: left">
                        <asp:TextBox ID="TxtTo" runat="server"></asp:TextBox><cc1:calendarextender id="Dt2"
                            runat="server" popupbuttonid="TxtTo" targetcontrolid="TxtTo">
                    </cc1:calendarextender></TD>
                               <td style="text-align: left">
                                   <asp:Button id="Button1" runat="server" Text="View.."></asp:Button></td>
                           </TR><TR><TD 
style="TEXT-ALIGN: left" colspan="5"><asp:Label id="LblCaption" runat="server" ForeColor="#0000C0" Font-Italic="True" Font-Bold="True" Text="Label" Visible="False"></asp:Label></TD></TR></TBODY></TABLE>     
                            
                            
                            
                            
                            
                            
                            
                            
                            

	</asp:Panel>
                            <asp:LinkButton ID="BtnExport" runat="server" Font-Bold="True">Regular Data - Export to Excel</asp:LinkButton>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True">Anormal Data - Export to Excel</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="width: 435px">
        
                <asp:GridView id="GV1" runat="server" HorizontalAlign="Center">
                </asp:GridView> <asp:GridView id="GV2" runat="server" HorizontalAlign="Center">
                </asp:GridView>
           
                        </td>
                    </tr>
                </table>
                
</td>                
  <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" alt="" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
    </table>



</asp:Content>
