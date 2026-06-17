<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CanteenReportMain.aspx.vb" Inherits="E_Management.CanteenReportMain" MasterPageFile="~/ems.Master" %>



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
            <td colspan="5" style="height: 21px; background-color: #5d7b9d; text-align: left">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="White" Text="Select Report Option"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">
                <asp:RadioButton ID="RBtn1" runat="server" Text="Detailed Report" GroupName="Options" />&nbsp;
                <br />
                <asp:RadioButton ID="RBtn5" runat="server" Text="Report By Date - Summary  By Department" GroupName="Options" Visible="False" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 21px; background-color: #5d7b9d; text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">
                <asp:RadioButton ID="Rbtn4" runat="server" Text="Summary by Date" GroupName="Options" /><br />
                <asp:RadioButton ID="RBtn2" runat="server" Text="Summary by Department" GroupName="Options" /><br />
                <asp:RadioButton ID="RBtn3" runat="server" Text="Summary by Section" GroupName="Options" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; background-color: #5d7b9d; text-align: left" colspan="5">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="White" Text="Select Report Date"></asp:Label></td>
        </tr>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label></td>
    <td>
        <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label></td>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Canteen Name"></asp:Label></td>
    <td>
        </td>
    <td></td>
    </tr>
    
    <tr>
    <td>
        <asp:TextBox ID="TxtFrom" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton1"
            runat="server" ImageUrl="~/images/calender.png" />&nbsp;
    </td>
    <td>
        <asp:TextBox ID="TxtTo" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton2"
            runat="server" ImageUrl="~/images/calender.png" />&nbsp;
    </td>
    <td>
        <asp:DropDownList ID="CmbCanteenName" runat="server" DataSourceID="SqlDataSource2" DataTextField="CanteenName" DataValueField="CanteenName">
        </asp:DropDownList></td>
    <td>
        <asp:Button ID="Button1" runat="server" Text="View" /></td>
    <td>
        </td>
    </tr>
        <tr>
            <td>
        <asp:Calendar ID="From1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Visible="False" Width="220px">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        </asp:Calendar>
            </td>
            <td>
        <asp:Calendar ID="To1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Visible="False" Width="220px">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        </asp:Calendar>
            </td>
            <td>
                &nbsp;<asp:CheckBox ID="ChkCanteen" runat="server" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
                    SelectCommand="Select Distinct DepartmentCode From CN_DailyTransaction Order By DepartmentCode">
                </asp:SqlDataSource>
                &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;<asp:CheckBox ID="ChkDepartment" runat="server" Height="1px" Visible="False" />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
                    SelectCommand="Select Distinct CanteenName from CN_DailyTransaction"></asp:SqlDataSource>
                &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Department" Visible="False"></asp:Label>
        <asp:DropDownList ID="CmbDepartment" runat="server" DataSourceID="SqlDataSource1" DataTextField="DepartmentCode" DataValueField="DepartmentCode" Visible="False">
        </asp:DropDownList></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Lblmsg" runat="server" BackColor="Red" Font-Bold="True" Font-Size="Large"
                    ForeColor="White"></asp:Label></td>
            <td>
            </td>
            <td>
            </td>
            <td>
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