<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BonusPointCalcualation.aspx.vb" Inherits="E_Management.BonusPointCalcualation" MasterPageFile="~/ems.Master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img alt="" height="16" src="../../images/top_lef.gif" width="16"/></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img alt ="" height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;" >
                <img height="16" src="../../images/top_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16" style="height: 430px">
                <img height="11" src="../../images/cen_lef.gif" width="16" alt="" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 430px">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 250px;">
                            <asp:Panel ID="Panel1" runat="server">      
                            
                            
                            
                            <table>
                                <tr>
                                    <td colspan="7" style="background-color: #5d7b9d">
                                        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Attendance Point Calculation"></asp:Label></td>
                                </tr>
                            <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="From"></asp:Label> </td>
                                
                                <td style="width: 3px">
                                    <asp:TextBox ID="TxtFrom" runat="server"></asp:TextBox></td>
                                <td style="width: 3px">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/calender.png" /></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="To"></asp:Label> </td>
                                
                                <td style="width: 3px">
                                    <asp:TextBox ID="TxtTo" runat="server"></asp:TextBox></td>
                                <td style="width: 3px">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/calender.png" /></td>
                                <td style="width: 3px">
                                    <asp:Button ID="Button1" runat="server" Text="View" /></td>
                            </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="width: 3px">
                                        <asp:Calendar ID="From1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                            ForeColor="#663399" Height="200px" ShowGridLines="True" Visible="False" Width="220px">
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                        </asp:Calendar>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 3px">
                                        <asp:Calendar ID="To1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px"
                                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399"
                                            Height="200px" ShowGridLines="True" Visible="False" Width="220px">
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                        </asp:Calendar>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                    </td>
                                </tr>
                            </table>
                            
                            
                            
                            
                            
                            
                            
                              </asp:Panel>
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../../images/cen_rig.gif" style="width: 24px; height: 430px;">
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