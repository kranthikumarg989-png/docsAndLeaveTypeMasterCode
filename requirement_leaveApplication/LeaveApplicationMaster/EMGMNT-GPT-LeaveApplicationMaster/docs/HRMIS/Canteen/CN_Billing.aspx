<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CN_Billing.aspx.vb" Inherits="E_Management.CN_Billing" MasterPageFile="~/ems.Master" %>



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
                            
                            
                            
                            <table width="100%">
                                <tr>
                                    <td align="left" colspan="2" style="background-color: #5d7b9d; text-align: center">
                                        <asp:Label ID="Label5" runat="server" Text="Transaction Screen" Width="200px" Font-Bold="True" ForeColor="White"></asp:Label></td>
                                    <td align="left" colspan="1">
                                    </td>
                                </tr>
              
                            <tr>
                            <td align="left" style="background-color: beige">
                                <asp:Label ID="Label1" runat="server" Text="Employee ID" Width="125px"></asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="TxtEID" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left">
                                </td>
                            </tr>
                            
                            <tr>                                                       
                            <td align="left" style="background-color: beige">
                                <asp:Label ID="Label2" runat="server" Text="Transaction Date"></asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="TxtDate" runat="server" Width="130px"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/calender.png" /></td>
                                <td align="left" rowspan="6">
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
                            </tr>
                            
                            <tr>
                            <td  align="left" style="background-color: beige">
                                <asp:Label ID="Label3" runat="server" Text="Bill Amount"></asp:Label></td>
                            <td  align="left">
                                <asp:TextBox ID="TxtBillAmount" runat="server" Width="150px"></asp:TextBox></td>
                            </tr>
                                <tr>
                                    <td align="left" style="background-color: beige">
                                        <asp:Label ID="Label4" runat="server" Text="Canteen Name"></asp:Label></td>
                                    <td  align="left">
                                        <asp:DropDownList ID="CmbCanteen" runat="server" Width="155px">
                                            <asp:ListItem>-Select-</asp:ListItem>
                                            <asp:ListItem>Plant1_Canteen</asp:ListItem>
                                            <asp:ListItem>Plant7_Canteen</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtBillAmount" 
                                            ErrorMessage="Bill Amount Must be Numeric!" ValidationExpression="^[-+]?[0-9]*\.?[0-9]*([eE][-+]?[0-9]+)?$"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="BtnSave" runat="server" Text="Save" /></td>
                                </tr>
                            
                            
                            </table>
                            
                            
            
                            
                   </asp:Panel>
                        </td>
                    </tr>
                </table>               
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