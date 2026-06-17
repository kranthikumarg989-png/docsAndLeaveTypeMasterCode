<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerVisitPreparationForm.aspx.vb" Inherits="E_Management.CustomerVisitPreparationForm" MasterPageFile="~/ems.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	



<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" alt=""/></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" alt=""/></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16" style="height: 2344px">
                <img height="11" src="../../images/cen_lef.gif" width="16" alt="" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 2344px">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 1098px;">
                            <asp:Panel ID="Panel1" runat="server">
                            
                            <asp:Panel ID="MainPanel" runat="server">
                            
                            <table  border="0">
<tr>
<td Colspan="6" style="background-color: #6699ff">
    <asp:Label ID="Label6" runat="server" Text="Customer Visit Preparation Form" Font-Bold="True" ForeColor="White" Width="1140px"></asp:Label></td>
</tr>
    
    
<tr>
<td style="text-align: left; width: 218px;">
    <asp:Label ID="Label4" runat="server" Text="Customer Visit From" Width="150px"></asp:Label></td>
<td style="text-align: left;">
    <asp:TextBox ID="TxtFrom" runat="server"></asp:TextBox>&nbsp;<asp:ImageButton ID="ImageButton1"
        runat="server" ImageUrl="~/images/calender.png" />
    <asp:Calendar ID="From1" runat="server" Visible="False"></asp:Calendar>
</td>
<td style="text-align: left; ">
    <asp:Label ID="Label3" runat="server" Text="Customer Visit To" Width="150px"></asp:Label></td>
<td style="text-align: left">
    <asp:TextBox ID="TxtTo" runat="server"></asp:TextBox>&nbsp;
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/calender.png" />
    <asp:Calendar ID="To1" runat="server" Visible="False"></asp:Calendar>
</td>
<td style="text-align: left">
    <asp:Label ID="Label2" runat="server" Text="No of Days" Width="100px" Visible="False"></asp:Label></td>
<td style="text-align: left">
    <asp:Label ID="LblNoOfDays" runat="server" Visible="False"></asp:Label></td>
</tr>

<tr>
<td style="text-align: left; width: 218px;">
    <asp:Label ID="Label1" runat="server" Text="Customer Name" Width="100px"></asp:Label></td>
<td colspan="5" style="text-align: left">
    <asp:DropDownList ID="CmbCustomerName" runat="server" Width="540px" AutoPostBack="True">
    </asp:DropDownList></td>
</tr>
                                <tr>
                                    <td style="width: 218px; text-align: left">
                                        <asp:Label ID="Label30" runat="server" Text="Other Customer" Width="100px"></asp:Label></td>
                                    <td colspan="5" style="text-align: left">
                                        <asp:TextBox ID="TxtOtherCustomer" runat="server" Width="530px"></asp:TextBox></td>
                                </tr>
    <tr>
        <td style="text-align: left; width: 218px;">
            <asp:Label ID="Label5" runat="server" Text="Department" Width="100px"></asp:Label></td>
                    <td style="text-align: left;"><asp:CheckBox ID="CeramicValve" runat="server" Text="Ceramic Valve" /></td>
            <td style="text-align: left"><asp:CheckBox ID="FerriteMagnet" runat="server" Text="Ferrite Magnet" /></td>
            <td style="text-align: left"><asp:CheckBox ID="FerriteSheet" runat="server" Text="Ferrite Sheet" /></td>
            <td style="text-align: left"><asp:CheckBox ID="Substrate" runat="server" Text="Substrate" /></td>
            <td style="text-align: left"><asp:CheckBox ID="TPH" runat="server" Text="TPH" /></td>
           
    </tr>
    <tr>
        <td style="text-align: left; width: 218px;">
            <asp:Label ID="Label7" runat="server" Text="No of Customer" Width="150px"></asp:Label></td>
        <td style="text-align: left; width: 216px;">
            <asp:TextBox ID="TxtNoOfCustomer" runat="server"></asp:TextBox></td>
        <td style="text-align: left">
            <asp:Label ID="Label8" runat="server" Text="Attendance Name 1" Width="150px"></asp:Label></td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtAttendance" runat="server"></asp:TextBox></td>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Attendance Designation 1" Width="150px"></asp:Label></td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDesignation" runat="server"></asp:TextBox></td>
    </tr>
                                <tr>
                                    <td style="width: 218px; text-align: left">
                                    </td>
                                    <td style="width: 216px; text-align: left">
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label31" runat="server" Text="Attendance Name 2" Width="150px"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="TxtAttendance2" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label33" runat="server" Text="Attendance Designation 2" Width="150px"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="TxtDesignation2" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 218px; text-align: left">
                                    </td>
                                    <td style="width: 216px; text-align: left">
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label32" runat="server" Text="Attendance Name 3" Width="150px"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="TxtAttendance3" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label34" runat="server" Text="Attendance Designation 3" Width="150px"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="TxtDesignation3" runat="server"></asp:TextBox></td>
                                </tr>
    <tr>
        <td style="text-align: left; width: 218px;">
            <asp:Label ID="Label10" runat="server" Text="Purpose of Visit" Width="150px"></asp:Label></td>
        <td colspan="5" style="text-align: left">
            <asp:TextBox ID="TxtReason" runat="server" Height="21px" TextMode="MultiLine" Width="700px"></asp:TextBox></td>
    </tr>
</table>
</asp:Panel>

<table>
<tr style="background-color: #6699ff">
<td colspan="6" style="text-align: center; height: 21px;">
    <asp:Label ID="Label11" runat="server" Text="Visit Arrangement" Font-Bold="True" ForeColor="White" Width="1140px" Font-Italic="False"></asp:Label></td>
</tr>
<tr>
<td colspan="6">
    <br />
    <br />
</td>
</tr>
</table>
<asp:Panel runat="server" ID="SalesPanel">
<table>
<tr style="background-color: #6699ff">
    <td colspan="6" style="height: 21px; text-align: left"><asp:Label ID="Label12" runat="server" Text="Sales" Font-Bold="True" ForeColor="White" Width="1140px" Font-Italic="False"></asp:Label></td>
</tr>

<tr>
<td style="height: 16px; text-align: left; width: 218px;">
    <asp:CheckBox ID="Safety" runat="server" Text="Safety Presentation" Width="200px"/></td>
    <td style="height: 16px; text-align: left">
    <asp:CheckBox ID="Company" runat="server" Text="Company Presentation" Width="200px"/></td>
    <td style="height: 16px; text-align: left;">
    <asp:CheckBox ID="Profile1" runat="server" Text="Profile Catalog or Other" Width="175px"/></td>
    <td style="height: 16px; text-align: left;">
    <asp:CheckBox ID="Beverages" runat="server" Text="Beverages and Snacks" Width="175px"/></td>
    <td style="height: 16px; text-align: left;">
    <asp:CheckBox ID="Towels" runat="server" Text="Towels" Width="75px"/></td>
    <td style="height: 16px; text-align: left;">
    <asp:CheckBox ID="Souvenirs" runat="server" Text="Souvenirs" Width="80px"/></td>
</tr>

<tr>

<td style="height: 42px; text-align: left; width: 218px;">
    <asp:CheckBox ID="Stationery" runat="server" Text="Stationery - Marker Pen, Paper" Width="215px"/></td>
    <td style="text-align: left; height: 42px;">
    <asp:CheckBox ID="SafetyPPE" runat="server" Text="Safety PPE Items"/></td>
    <td style="text-align: left; height: 21px;">
    <asp:CheckBox ID="SalesOthers" runat="server" Text="Others"/></td>
    <td colspan="3" style="height: 42px; text-align: left">
        <asp:TextBox ID="SalesOthers1" runat="server" Height="21px" Width="300px"></asp:TextBox>
    </td>
</tr>
    <tr>
        <td style="height: 42px; text-align: left; width: 218px;">
            <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="Blue" Text="Acknowledgement"
                Width="150px" Font-Italic="True"></asp:Label></td>
        <td style="height: 21px; text-align: left "><asp:CheckBox ID="RID" runat="server" Text="RID"/></td>
        <td style="height: 42px; text-align: left"><asp:CheckBox ID="CSID" runat="server" Text="CSID"/></td>
        <td colspan="1" style="height: 42px; text-align: left">
            <asp:CheckBox ID="OSHI" runat="server" Text="OSHI"/></td>
        <td colspan="3" style="height: 42px; text-align: left">
            <asp:TextBox ID="SalesAck" runat="server"></asp:TextBox></td>
    </tr>
        </table>
        </asp:Panel>
        
        <asp:Panel runat="server" ID="ProductionPanel">
        <table>
    <tr>
        <td colspan="6" style="height: 21px; background-color: #6699ff; text-align: left">
            <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="White" Text="Production"
                Width="1140px" Font-Italic="False"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left; width: 218px;">
            <asp:CheckBox ID="FiveS" runat="server" Text="5S" Width="200px"/>
        </td>
        <td style="height: 21px; width: 216px; text-align: left;">
            <asp:CheckBox ID="Production" runat="server" Text="Production Arrangement" Width="175px"/></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="ProductionOthers" runat="server" Text="Others" Width="200px"/></td>
        <td colspan="3" style="height: 21px; text-align: left">
            <asp:TextBox ID="ProductionOthers1" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="height: 14px; text-align: left; width: 218px;">
            <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="Blue" Text="Acknowledgement"
                Width="150px" Font-Italic="True"></asp:Label></td>
        <td style="height: 14px; text-align: left">
            <asp:CheckBox ID="CV" runat="server" Text="Ceramic Valve"/></td>
        <td style="height: 14px; text-align: left">
            <asp:CheckBox ID="FM" runat="server" Text="Ferrite Magnet"/></td>
        <td style="height: 14px; text-align: left">
            <asp:CheckBox ID="FS" runat="server" Text="Ferrite Sheet"/></td>
            <td style="height: 14px; text-align: left">
            <asp:CheckBox ID="SU" runat="server" Text="Substrate"/></td>
            <td style="height: 14px; text-align: left">
            <asp:CheckBox ID="TPH1" runat="server" Text="TPH"/></td>
    </tr>
            <tr>
                <td style="width: 218px; height: 14px; text-align: left">
                </td>
                <td style="height: 14px; text-align: left">
                </td>
                <td style="height: 14px; text-align: left">
                </td>
                <td colspan="3" style="height: 14px; text-align: left">
                    <asp:TextBox ID="ProductionAck" runat="server" Width="265px"></asp:TextBox></td>
            </tr>
    </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="QAPanel">
    <table>
    <tr>
        <td colspan="6" style="height: 21px; background-color: #6699ff; text-align: left">
            <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="White" Text="QA"
                Width="1140px"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left; width: 218px;">
            <asp:CheckBox ID="ProcessFlow" runat="server" Text="Process Flow" Width="114px"/></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="QualityPlan" runat="server" Text="Quality Plan" Width="108px"/>
        </td>
        <td style="height: 21px; text-align: left">
            &nbsp;<asp:CheckBox ID="ClaimStatus" runat="server" Text="Claim Status" Width="100px"/>
        </td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="QualityOthers" runat="server" Text="Others" Width="66px"/></td>
        <td colspan="2" style="height: 21px; text-align: left">
            <asp:TextBox ID="QualityOthers1" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="height: 13px; text-align: left; width: 218px;">
            <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="Blue" Text="Acknowledgement"
                Width="150px" Font-Italic="True"></asp:Label></td>
        <td style="height: 13px; text-align: left">
            <asp:CheckBox ID="QAAck" runat="server" Text="QA" Width="52px"/></td>
        <td style="height: 13px; text-align: left">
            <asp:TextBox ID="QAAck1" runat="server"></asp:TextBox></td>
        <td style="height: 13px; text-align: left">
        </td>
        <td colspan="2" style="height: 13px; text-align: left">
        </td>
    </tr>
    </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="AdminPanel">
    <table>
    <tr style="background-color: #6699ff">
        <td colspan="6" style="height: 21px; text-align: left">
            <asp:Label ID="Label18" runat="server" Font-Bold="True" ForeColor="White" Text="Admin"
                Width="1140px"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 15px; text-align: left; width: 218px;"><asp:CheckBox ID="Arrival" runat="server" Text="Taxi Arrangement - Arrival" Width="200px"/></td>
        <td style="height: 15px; text-align: left; "><asp:CheckBox ID="Departure" runat="server" Text="Taxi Arrangement - Departure" Width="210px"/></td>
        <td style="height: 15px; text-align: left; "><asp:CheckBox ID="Accommodation" runat="server" Text="Accommodation" Width="130px"/></td>
        <td style="height: 15px; text-align: left"><asp:CheckBox ID="Lunch" runat="server" Text="Lunch Booking" Width="126px"/></td>
        <td colspan="2" style="height: 15px; text-align: left">
            <asp:CheckBox ID="Dinner" runat="server" Text="Dinner Booking" Width="120px"/></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left; width: 218px;">
            <asp:Label ID="Label19" runat="server" Font-Bold="True" ForeColor="Blue" Text="Acknowledgement"
                Width="150px" Font-Italic="True"></asp:Label></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="Admin" runat="server" Text="Admin" Width="200px"/></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="Security" runat="server" Text="Security" Width="100px"/></td>
        <td style="height: 21px; text-align: left">
            <asp:TextBox ID="AdminAck" runat="server"></asp:TextBox></td>
        <td colspan="2" style="height: 21px; text-align: left">
        </td>
    </tr>
    </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="ITPanel">
    <table>
    <tr  style="background-color: #6699ff">
        <td colspan="6" style="height: 21px; text-align: left">
            <asp:Label ID="Label20" runat="server" Font-Bold="True" ForeColor="White" Text="IT"
                Width="1140px"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left; width: 218px;">
            <asp:CheckBox ID="WelcomeBoard" runat="server" Text="Welcome Boards" Width="200px"/></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="WIFI" runat="server" Text="Wireless IP Address" Width="200px"/></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="ITOthers" runat="server" Text="Others" Width="100px"/></td>
        <td colspan="3" style="height: 21px; text-align: left">
            <asp:TextBox ID="ITOthers1" runat="server" Width="250px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="height: 2px; text-align: left; width: 218px;">
            <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Blue"
                Text="Acknowledgement" Width="150px"></asp:Label></td>
        <td style="height: 2px; text-align: left">
            <asp:CheckBox ID="IT" runat="server" Text="IT" Width="200px"/></td>
        <td style="height: 2px; text-align: left">
            <asp:TextBox ID="ITAck" runat="server"></asp:TextBox></td>
        <td colspan="3" style="height: 2px; text-align: left">
        </td>
    </tr></table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="TMPanel">
    <table>
    <tr  style="background-color: #6699ff">
        <td colspan="6" style="height: 21px; text-align: left">
            <asp:Label ID="Label21" runat="server" Font-Bold="True" ForeColor="White" Text="Top Management"
                Width="1140px" BackColor="#6699FF"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left; width: 218px;">
            <asp:CheckBox ID="Meeting" runat="server" Text="Meeting Attendance" Width="200px"/></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox ID="TMOthers" runat="server" Text="Others" Width="200px"/></td>
        <td colspan="2" style="height: 21px; text-align: left">
            <asp:TextBox ID="TMOthers1" runat="server" Width="250px"></asp:TextBox></td>
        <td colspan="2" style="height: 21px; text-align: left">
        </td>
    </tr>
    <tr>
        <td style="height: 31px; text-align: left; width: 218px;">
            <asp:Label ID="Label22" runat="server" Font-Bold="True" ForeColor="Blue" Text="Acknowledgement"
                Width="150px" Font-Italic="True"></asp:Label></td>
        <td style="height: 31px; text-align: left"><asp:CheckBox ID="MD" runat="server" Text="MD" Width="200px"/></td>
        <td style="height: 31px; text-align: left"><asp:CheckBox ID="EA" runat="server" Text="EA" Width="60px"/></td>
        <td>
            <asp:TextBox ID="TMAck" runat="server"></asp:TextBox></td>
        <td colspan="2" style="height: 31px; text-align: left">
        </td>
    </tr>
    </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="RemarksPanel">
    <table>
        <tr>
            <td colspan="6">
                <asp:Label ID="Label38" runat="server" BackColor="#6699FF" Font-Bold="True" ForeColor="White"
                    Text="Remarks" Width="1140px"></asp:Label></td>
        </tr>
    <tr>
        <td style="height: 16px; text-align: center; width: 218px;">
            <asp:Label ID="Label24" runat="server" Text="Sales - Remarks"></asp:Label></td>
        <td style="height: 16px; text-align: center">
            <asp:Label ID="Label26" runat="server" Text="Production - Remarks"></asp:Label></td>
        <td style="height: 16px; text-align: center">
            &nbsp;<asp:Label ID="Label25" runat="server" Text="QA - Remarks"></asp:Label></td>
        <td style="height: 16px; text-align: center">
            <asp:Label ID="Label27" runat="server" Text="Admin - Remarks"></asp:Label></td>
        <td style="height: 16px; text-align: center">
            <asp:Label ID="Label28" runat="server" Text="IT - Remarks"></asp:Label></td>
        <td style="height: 16px; text-align: center">
            <asp:Label ID="Label29" runat="server" Text="Top Management - Remarks"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 218px; height: 27px; text-align: center">
            <asp:TextBox ID="SalesRemarks" runat="server" MaxLength="250" TextMode="MultiLine"
                Width="150px" Font-Size="8pt" Height="75px"></asp:TextBox></td>
        <td style="height: 27px; text-align: center">
            <asp:TextBox ID="ProductionRemarks" runat="server" MaxLength="250" TextMode="MultiLine"
                Width="150px" Font-Size="8pt" Height="75px"></asp:TextBox></td>
        <td style="height: 27px; text-align: center">
            <asp:TextBox ID="QARemarks" runat="server" MaxLength="250" TextMode="MultiLine" Width="150px" Font-Size="8pt" Height="75px"></asp:TextBox></td>
        <td style="height: 27px; text-align: center">
            <asp:TextBox ID="AdminRemarks" runat="server" MaxLength="250" TextMode="MultiLine"
                Width="150px" Font-Size="8pt" Height="75px"></asp:TextBox></td>
        <td style="height: 27px; text-align: center">
            <asp:TextBox ID="ITRemarks" runat="server" MaxLength="250" TextMode="MultiLine" Width="150px" Font-Size="8pt" Height="75px"></asp:TextBox></td>
        <td style="height: 27px; text-align: center">
            <asp:TextBox ID="TMRemarks" runat="server" MaxLength="250" TextMode="MultiLine" Width="150px" Font-Size="8pt" Height="75px"></asp:TextBox></td>
    </tr>
    </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="RequestorPanel">
    <table>
                                <tr>
                                    <td style="width: 218px; height: 31px; text-align: left">
                                        <asp:Label ID="Label35" runat="server" Text="Requested By" Width="150px"></asp:Label></td>
                                    <td style="height: 31px; text-align: left">
                                        <asp:TextBox ID="TxtRequestedBy" runat="server"></asp:TextBox></td>
                                    <td colspan="2" style="height: 31px; text-align: left">
                                    </td>
                                    <td colspan="2" style="height: 31px; text-align: left">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 218px; height: 31px; text-align: left">
                                        <asp:Label ID="Label36" runat="server" Text="Requestor Employee Id" Width="150px"></asp:Label></td>
                                    <td style="height: 31px; text-align: left">
                                        <asp:TextBox ID="TxtRequestorEID" runat="server"></asp:TextBox></td>
                                    <td colspan="2" style="height: 31px; text-align: left">
                                    </td>
                                    <td colspan="2" style="height: 31px; text-align: left">
                                    </td>
                                </tr>
    <tr>
        <td style="height: 31px; text-align: left; width: 218px;">
        </td>
        <td style="height: 31px; text-align: left"></td>
        <td colspan="2" style="height: 31px; text-align: left">
            </td>
        <td colspan="2" style="height: 31px; text-align: left">
        </td>
    </tr>

</table>
</asp:Panel>

<table>
    <tr>
        <td style="height: 31px"><asp:Label ID="Label37" runat="server" Font-Bold="True" ForeColor="White"
                Width="1140px"></asp:Label></td>
        
    </tr>
    <tr>
        <td style="height: 26px">
            <asp:Button ID="Button1" runat="server" Text="Submit" /></td>
        
    </tr>
</table>


	</asp:Panel>
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../../images/cen_rig.gif" style="width: 24px; height: 2344px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" alt=""/></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" alt=""/></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" alt=""/></td>
        </tr>
    </table>
</asp:Content>