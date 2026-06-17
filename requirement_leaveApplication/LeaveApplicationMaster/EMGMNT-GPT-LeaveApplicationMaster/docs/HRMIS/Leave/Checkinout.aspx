<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Checkinout.aspx.vb" Inherits="E_Management.Checkinout"  MasterPageFile="~/ems.Master"  Title="Check In and Out"%>

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
                            
                            
                            

<table align="center">
<tr>
<td style="text-align: left">
    <asp:Label ID="Label1" runat="server" Text="From Date" Width="75px"></asp:Label></td> <td style="text-align: left">
    <asp:TextBox ID="TxtFrm" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/calender.png" /><br />
    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
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
    <td style="text-align: left">
        <asp:Label ID="Label2" runat="server" Text="To Date" Width="75px"></asp:Label></td>
    <td style="text-align: left">
    <asp:TextBox ID="TxtTo" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/calender.png" /><asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
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
</tr>
<tr><td style="text-align: left">
    <asp:Label ID="Label3" runat="server" Text="Employee Id" Width="100px"></asp:Label></td> <td style="text-align: left">
    <asp:TextBox ID="TxtEmpId" runat="server"></asp:TextBox></td>
    <td style="text-align: left">
        <asp:Label ID="Label4" runat="server" Text="Options" Width="100px"></asp:Label></td>
    <td style="text-align: left">
    <asp:DropDownList ID="CmbOptions" runat="server">
        <asp:ListItem>ByDate</asp:ListItem>
        <asp:ListItem>ByID</asp:ListItem>
        <asp:ListItem>ByMins</asp:ListItem>
        <asp:ListItem>ByIDandDate</asp:ListItem>
        <asp:ListItem>BySummary</asp:ListItem>
        <asp:ListItem Selected="True">BySummaryandMinutes</asp:ListItem>
    </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="View.." /></td>
</tr>
    <tr>
        <td style="text-align: left" colspan="4">
            <asp:Label ID="LblCaption" runat="server" Text="Label" Font-Bold="True" Font-Italic="True" ForeColor="#0000C0"></asp:Label></td>
    </tr>
<tr>
    <td colspan="4">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" >
    
            
    <Columns>
    
    <asp:TemplateField HeaderText="SNO">
            <EditItemTemplate>
                <asp:Label ID="SNO" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>                
              <asp:Label ID="SNO" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
    
    
            <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" ReadOnly="True" />
            <asp:BoundField DataField="EmpName" HeaderText="EmpName" ReadOnly="True" />
            <asp:BoundField DataField="CTime1" HeaderText="IN" ReadOnly="True" />
            <asp:BoundField DataField="CTime2" HeaderText="OUT" ReadOnly="True" />
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="TotalSeconds" HeaderText="TotalSeconds" ReadOnly="True" />
            
             <asp:TemplateField HeaderText="Total Minutes">
            <EditItemTemplate>
                <asp:Label ID="Mins" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>                
              <asp:Label ID="Mins" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
    </Columns>
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" >
        <Columns>
            <asp:TemplateField HeaderText="SNO">
                <EditItemTemplate>
                    <asp:Label ID="SNO" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="SNO" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" ReadOnly="True" />
            <asp:BoundField DataField="EmpName" HeaderText="EmpName" ReadOnly="True" />
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="NoofTime" HeaderText="Total Times" ReadOnly="True" />
            
            <asp:TemplateField HeaderText="Avg (No of Time)">
                <EditItemTemplate>
                    <asp:Label ID="ANoofTime" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="ANoofTime" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="TotalSeconds" HeaderText="Total Minutes" ReadOnly="True" />
            
            <asp:TemplateField HeaderText="Average Minutes Per Outing">
                <EditItemTemplate>
                    <asp:Label ID="ADTime" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="ADTime" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Average Minutes Per Day">
                <EditItemTemplate>
                    <asp:Label ID="ATTime" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="ATTime" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </td>
</tr></table>








	</asp:Panel>
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
