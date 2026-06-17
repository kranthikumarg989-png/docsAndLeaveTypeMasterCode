<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTform.aspx.vb" Inherits="E_Management.BTform" 
    title="Business Trip Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Panel ID ="pnlleaveform" runat="server">
<!-- Top Rounded Panel Code Starts here -->
 <table cellpadding=0 cellspacing=0 style="width:750px">
      <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif" style="height: 622px"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff" style="height: 622px" >
					
<!-- Top Rounded Panel Code Ends here -->								
					
<table style="width: 750px">
<tr>
<td style="height: 23px;" class="td_head">
Business Trip Form
</td>
</tr>
    <tr>
        <td style="height: 23px">
            <asp:Label ID="lblmsg" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label></td>
    </tr>

<tr>
<td style="height: 21px">
<asp:Label ID="lbl" runat="server" Text="Application Number : " BackColor="#FF8000" Font-Size="Small" ForeColor="Yellow"></asp:Label>
<asp:Label ID="lblappno" runat="server" BackColor="#FF8000" Font-Size="Small" ForeColor="Yellow">123</asp:Label>
         
<asp:Panel ID="pnl1" runat= server GroupingText= "TRAVELLING DETAILS">
    <table border="" bordercolor="#E9EAC2" cellpadding=0 cellspacing=0 style="width: 718px" >
       
        <tr>
            <td style="height: 45px">Proposed Date</td>
            <td style="height: 45px">
                <asp:TextBox ID="txtpdate" runat="server" Width="93px" AutoPostBack="True" ></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpdate" ErrorMessage="!"
                    ValidationGroup="aa"></asp:RequiredFieldValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
Mask="99/99/99" MaskType="Date" TargetControlID="txtpdate" 
CultureName="en-GB" AcceptNegative=None > </cc1:MaskedEditExtender>

<cc1:MaskedEditValidator ID="MaskedEditValidator2" 
runat="server" ControlExtender="MaskedEditExtender1" 
ControlToValidate="txtpdate" EmptyValueMessage="Date is required" 
InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
TooltipMessage="Input a Date"></cc1:MaskedEditValidator> 
     
                </td>
                  <cc1:CalendarExtender ID="cce1" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                        PopupButtonID="txtpdate" TargetControlID="txtpdate">
                  </cc1:CalendarExtender>
                  
   



     
            <td style="height: 45px">Return Date</td>
            <td style="width: 158px; height: 45px">
                <asp:TextBox ID="txtrdate" runat="server" Width="101px" AutoPostBack="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtrdate"
                    ErrorMessage="!" ValidationGroup="aa"></asp:RequiredFieldValidator>
          <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
Mask="99/99/99" MaskType="Date" TargetControlID="txtrdate"    
CultureName="en-GB"> </cc1:MaskedEditExtender>

<cc1:MaskedEditValidator ID="MaskedEditValidator1" 
runat="server" ControlExtender="MaskedEditExtender2" 
ControlToValidate="txtrdate" EmptyValueMessage="Date is required" 
InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
TooltipMessage="Input a Date"></cc1:MaskedEditValidator> 
           </td>
                  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                        PopupButtonID="txtrdate" TargetControlID="txtrdate">
                  </cc1:CalendarExtender>
            <td style="height: 45px">
                <asp:Label ID="lblduration" runat="server" BackColor="#FF8000" Font-Bold="True" ForeColor="Yellow" Font-Size="Small">0</asp:Label>
                &nbsp; (Days)</td>
                <td></td>
        </tr>
        <tr>
            <td style="height: 61px">
                Trip &amp; flight Details</td>
            <td colspan ="2" style="height: 61px">
                <asp:TextBox ID="txtdetails" runat="server" Height="29px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdetails"
                    ErrorMessage="!" ValidationGroup="aa"></asp:RequiredFieldValidator></td>
            <td colspan="3" style="height: 61px">
            <font color=#aca899>
                Example : KLIA-Singapore(28/01/08) (Time 12PM),<br />
                Singapore-Japan(01/02/08)(Time1PM), Japan-KLIA(05/02/08)(Time 3PM)</font></td>
        </tr>
        <tr>
            <td>
                Trip type</td>
            <td colspan="2">
                Destination</td>
            <td colspan="2">
                Trip Purpose</td>
            <td>
                <asp:Label ID="lblpurpose" runat="server" Text="Other Purpose" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="border-top-style: none; height: 39px;">
                <asp:DropDownList ID="ddlttype" runat="server">
                    <asp:ListItem>Overseas</asp:ListItem>
                    <asp:ListItem>Local</asp:ListItem>
                    <asp:ListItem Selected="True" Value="-1">-Select-</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlttype"
                    ErrorMessage="!" InitialValue="-1" ValidationGroup="aa"></asp:RequiredFieldValidator></td>
            <td colspan="2" style="border-top-style: none; height: 39px;">
                <asp:TextBox ID="txtdestination" runat="server" Width="138px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdestination"
                    ErrorMessage="!" ValidationGroup="aa"></asp:RequiredFieldValidator></td>
            <td colspan="2" style="border-top-style: none; height: 39px;">
                <asp:DropDownList ID="ddlpurpose" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="customer">Visit Customer</asp:ListItem>
                    <asp:ListItem Value="supplier">Visit Supplier</asp:ListItem>
                    <asp:ListItem Value="cs">Visit Customer &amp; Supplier</asp:ListItem>
                    <asp:ListItem Value="O">Other Visit</asp:ListItem>
                    <asp:ListItem Selected="True" Value="-1">-Select-</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlpurpose"
                    ErrorMessage="!" InitialValue="-1" ValidationGroup="aa"></asp:RequiredFieldValidator></td>
            <td style="border-top-style: none; height: 39px;">
                <asp:TextBox ID="txtpurpose" runat="server" TextMode="MultiLine" Width="155px" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 174px; height: 40px;">
                <asp:CheckBox ID="cbgp" runat="server" Text="Apply Gatepass" AutoPostBack="True" /></td>
            <td colspan="3">
                &nbsp;
                <asp:Label ID="lbltout" runat="server" Text="Time Out(Hr:Min)" Visible="False"></asp:Label>
                <asp:DropDownList ID="ddlohr" runat="server" Visible="False">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlomin" runat="server" Visible="False">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddloam" runat="server" Visible="False">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
            <td colspan="2">
                <asp:Label ID="lblin" runat="server" Text="Time In(Hr:Min)" Visible="False"></asp:Label><asp:DropDownList ID="ddlihr" runat="server" Visible="False">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlimin" runat="server" Visible="False">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddliam" runat="server" Visible="False">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnl2" runat= server GroupingText= "COLLEAGUE DETAILS" >
    <table style="width: 720px">
        <tr>
            <td style="width: 100px">
                Select Colleague Dept</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddldept" runat="server" AutoPostBack="True" Width="250px" >
                  
                </asp:DropDownList>
            </td>
            <td style="width: 100px">
                Select Colleague Sect</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlsect" runat="server" AutoPostBack="True"
                  Width="250px">
                    <asp:ListItem Selected="True" Value="-1">Select any Dept</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                Select Colleague(s)</td>
            <td style="width: 100px">
                <asp:ListBox ID="lstcolleague" runat="server" Width="250px" Rows="5" SelectionMode="Multiple"></asp:ListBox></td>
            <td style="width: 100px" align="center">
                <asp:Button ID="btnadd" runat="server" SkinID="buttonskin1" Text=">>" Width="60px" />
                <asp:Button ID="btnremove" runat="server" SkinID="buttonskin1" Text="<<" Width="59px" /></td>
            <td style="width: 100px">
                &nbsp;<asp:ListBox ID="lstSelcolleague" runat="server" Rows="5" SelectionMode="Multiple"
                    Width="250px"></asp:ListBox>
                <br />
               
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td align="center" style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;<asp:Label ID="Label2" runat="server" BackColor="#FF8000" Font-Size="Small"
                    ForeColor="Yellow" Visible="False">No.Of Selected Colleague :</asp:Label>
                <asp:Label ID="lblselect" runat="server" BackColor="#FF8000" ForeColor="Yellow" Font-Size="Small"></asp:Label></td>
        </tr>
    </table>
    &nbsp;&nbsp;</asp:Panel>

<asp:Panel runat=server ID="pnl3" GroupingText="SHARE DEPARTMENT DETAILS">
    <table style="width: 723px">
        <tr>
            <td style="height: 14px;">
                Share Department(s)</td>
            <td style="height: 14px;">
                <asp:RadioButtonList ID="rbdept" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Selected="True" Value ="N">No</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="height: 21px;">
                <asp:Label ID="lblshare" runat="server" Text="Select Share Dept(s)" Visible="False"></asp:Label></td>
            <td style="height: 21px;">
                <asp:ListBox ID="lstsharedept" runat="server" DataSourceID="Sqdept" DataTextField="dept"
                    DataValueField="departmentcode" Visible="False" Width="325px" Rows="5" SelectionMode="Multiple"></asp:ListBox></td>
        </tr>
    </table>


</asp:Panel>    
<asp:Panel ID = "pnl4"  runat=server GroupingText="CUSTOMER / SUPPLIER DETAILS">
    <table>
        <tr>
            <td style="width: 100px">
                Select Customer(s)
            </td>
            <td style="width: 100px">
                <asp:ListBox ID="lstcustomer" runat="server" DataSourceID="sqlcust" DataTextField="customer"
                    DataValueField="customer" Rows="5" SelectionMode="Multiple" Width="250px" AutoPostBack="True"></asp:ListBox>
            </td>
            <td style="width: 100px">
                Select Suppplier(s)</td>
            <td style="width: 100px">
                <asp:ListBox ID="lstsupplier" runat="server" DataSourceID="sqlsupp" DataTextField="suppliername"
                    DataValueField="suppliername" Rows="5" SelectionMode="Multiple" Width="250px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="cbcustomer" runat="server" Text="Non-Registered Customer  " TextAlign="Left" AutoPostBack="True" /></td>
            <td colspan="2">
                <asp:CheckBox ID="cbsupplier" runat="server" Text="Non-Registered Supplier       "
                    TextAlign="Left" Width="228px" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="lblcust" runat="server" Text="Key in Customer & Destination" Visible="False"></asp:Label></td>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="lblsupp" runat="server" Text="Key in Supplier & Destination" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtnewcust" runat="server" Width="214px" Visible="False" BackColor="#FFFF80" AutoPostBack="True"></asp:TextBox><asp:TextBox ID="txtnewcust1" runat="server" Width="116px" Visible="False" BackColor="#FFFF80"></asp:TextBox></td>
            <td colspan="2">
                <asp:TextBox ID="txtnewsupp" runat="server" Width="214px" Visible="False" BackColor="#FFFF80"></asp:TextBox><asp:TextBox
                    ID="txtnewsupp1" runat="server" Width="116px" Visible="False" BackColor="#FFFF80"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 26px">
                Contact Person &nbsp;
                <asp:TextBox ID="txtcontact" runat="server" Width="116px"></asp:TextBox></td>
              <td colspan="2" style="height: 26px">
                  <asp:Label ID="Label1" runat="server" ForeColor="Yellow" Text="No.Of Selected Customers  : " BackColor="#FF8000" Font-Size="Small" Visible="False"></asp:Label>&nbsp;
                  <asp:Label ID="lblnocust" runat="server" BackColor="#FF8000" ForeColor="Yellow" Font-Size="Small"></asp:Label></td>
        </tr>
      </table>

</asp:Panel>
<asp:Panel ID = "PNL5" GroupingText="ADVANCE DETAILS" runat=SERVER >
    <table style="">
        <tr>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="LblUSD" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label>&nbsp;<span
                    style="color: #aca899"> (Please enter amount and select currency.)</span></td>
            <td colspan="3" style="height: 21px">
                Advance Details<span style="color: #aca899">(click Image to Delete any advance amt entered)</span></td>
        </tr>
        <tr>
            <td style="width: 116px; height: 33px;">
                Enter Amount</td>
            <td style="width: 247px; height: 33px;">
                <asp:TextBox ID="txtamt" runat="server" Width="71px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtamt"
                    ErrorMessage="only Numbers!" ValidationExpression="[0-9]*" Width="112px"></asp:RegularExpressionValidator></td>
            <td colspan="4" rowspan="2">
                <asp:ListBox ID="txtadvance" runat="server" Width="231px"></asp:ListBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/del.jpg" Width="19px" CausesValidation="False" /><br />
                Total RM =
                <asp:Label ID="lbltotamt" runat="server" Font-Bold="True" ForeColor="DarkGreen">0</asp:Label>
                <asp:Label ID="lblusdmsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblcurusd" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 116px; height: 45px">
                Select
                Currency</td>
            <td style="width: 247px; height: 45px">
                <asp:DropDownList ID="ddlcurrency" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="Sqlcurrency" DataTextField="CurrencyCode" DataValueField="CurrencyCode">
                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>

</asp:Panel>
<asp:Panel ID = "pnl6" runat=server GroupingText="TRANSPORT DETAILS">
    <table style="width: 728px">
        <tr>
            <td style="width: 100px">
                Transport</td>
            <td style="width: 107px">
                <asp:DropDownList ID="ddltransport" runat="server">
                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    <asp:ListItem>To Airport</asp:ListItem>
                    <asp:ListItem>Local</asp:ListItem>
                    <asp:ListItem Value="O">Other</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddltransport"
                    ErrorMessage="!" InitialValue="-1" ValidationGroup="aa"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Company Car
            </td>
            <td style="width: 100px">
                <asp:RadioButtonList ID="rdocar" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList></td>
            <td style="width: 100px">
                Vehicle No</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtvehicle" runat="server" Width="116px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Pick Up Place(Hostel)</td>
            <td style="width: 107px">
                <asp:DropDownList ID="ddlplace" runat="server">
                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    <asp:ListItem>Permai</asp:ListItem>
                    <asp:ListItem>Peringgit</asp:ListItem>
                    <asp:ListItem>Bachang</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
                If Others, Please Specify</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtotherplace" runat="server" TextMode="MultiLine" Width="163px"></asp:TextBox></td>
            <td style="width: 100px">
                Contact No</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpcontact" runat="server" Width="116px"></asp:TextBox></td>
        </tr>
    </table>
    </asp:Panel>

   <asp:Panel ID="pnl9" runat="server" Width= 800px>
        <table align=right >
        
        <tr>
        <td style="width: 43px">
        <asp:Button ID="btnsave" runat="server" Text="Next" ValidationGroup="aa" />
        </td></tr></table>
   </asp:Panel> 
      
    </td>
</tr>

<!-- Bottom Rounded Panel Code Starts here -->
</table>



<asp:SqlDataSource ID="Sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select sectioncode +'-' +sectionname as sect,sectioncode,departmentcode from sectionmaster"
                     FilterExpression="departmentcode = '{0}'">
                    <FilterParameters>
                     <asp:ControlParameter ControlID="ddldept" Name="dept" PropertyName="SelectedValue"  />
                    </FilterParameters>

                </asp:SqlDataSource>
                        <asp:SqlDataSource ID="Sqlcurrency" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                            SelectCommand="SELECT DISTINCT [CurrencyCode] FROM [Pur_currencymaster] ORDER BY [CurrencyCode]">
                        </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqdept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select departmentcode + '-' + departmentname as dept,departmentcode from department order by departmentcode">
    </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sqlcust" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                            SelectCommand="SELECT DISTINCT [customer] FROM [custmaster] ORDER BY [customer]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sqlsupp" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                            SelectCommand="SELECT DISTINCT [suppliername] FROM [pur_suppliermaster] ORDER BY [suppliername]">
                        </asp:SqlDataSource>
     	<td background="../../images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
<!-- Bottom Rounded Panel Code Ends here -->	

</asp:Panel>

</asp:Content>
