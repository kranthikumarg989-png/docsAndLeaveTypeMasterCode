<%@ Page Language="vb" AutoEventWireup="false" Theme ="buttonems" MasterPageFile="~/ems.Master" EnableEventValidation="false"  CodeBehind="LeaveApp.aspx.vb" Inherits="E_Management.LeaveApp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding=0 cellspacing=0 align="center">
	<tr>
    	<td vAlign="top" bgColor="#ffffff">
  
<asp:Panel ID ="pnlleaveform" runat="server">
 <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif" style="height: 622px"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff" style="height: 622px" >

<table>
<tr>

<td style="height: 23px;" class="td_head">
Leave Application Form

</td>
</tr>

<tr>
<td style="height: 133px">

    <asp:Panel ID="Panel1" runat="server"  Font-Bold="True" GroupingText="My Leave Summary">
        <table>
            <tr>
                <td style="height: 21px" >
                    <asp:Label ID="Label1" runat="server" Text="Annual Entitilement" Width="185px" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td style="height: 21px" >
                    <asp:Label ID="lbllannual" runat="server"  Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td style="height: 21px" >
                    <asp:Label ID="Label3" runat="server" Text="Medical Entitilement" Width="183px" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td style="height: 21px" >
                    <asp:Label ID="lbllmedical" runat="server" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 20px" >
                    <asp:Label ID="Label4" runat="server" Text="Bal.Annual Leave" Width="191px" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td style="height: 20px" >
                    <asp:Label ID="lbllbannual" runat="server" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td style="height: 20px" >
                    <asp:Label ID="Label9" runat="server" Text="Bal.Medical Leave" Width="176px" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td style="height: 20px" >
                    <asp:Label ID="lbllbmedical" runat="server" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label2" runat="server" Text="Carry Forward" Width="135px" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td >
                    <asp:Label ID="lbllcfwd" runat="server" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Bal.Carry Forward" Width="174px" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td >
                    <asp:Label ID="lbllbcfwd" runat="server" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <asp:Label ID="Label7" runat="server" Text="Elligible Annual Leave for this month" Font-Bold="True" ForeColor="SlateGray"></asp:Label></td>
                <td colspan="2" style="height: 21px">
                    <asp:Label ID="lbllprorate" runat="server" ForeColor="SlateGray"></asp:Label></td>
            </tr>
        </table>
    
    </asp:Panel>

</td>
</tr>
<tr>
<td>
    <asp:Panel ID="Panel2" runat="server" Font-Bold="True" GroupingText="New Leave Details">
        <table style="width: 594px; ">
        
            <tr>
                <td colspan="2" style="background-color: beige">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fill in all  the Required (*) fields" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige; height: 21px;">
                    <asp:Label ID="Label10" runat="server" Text="Leave App No" Width="123px"></asp:Label></td>
                <td style="width: 552px; height: 21px;">
                    <asp:Label ID="gppassnum" runat="server" BackColor="#FFFFC0" Font-Size="Medium"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="ddlltype" runat="server" Text="Leave Type"></asp:Label></td>
                <td style="width: 552px; ">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="-1">- Select Leave type -</asp:ListItem>
                        <asp:ListItem>Annual</asp:ListItem>
                        <asp:ListItem>Calamity</asp:ListItem>
                        <asp:ListItem Value="CompanyHoliday">Company Holiday</asp:ListItem>
                        <asp:ListItem>Compassionate</asp:ListItem>
                        <asp:ListItem Value="Emergency">Emergency - Annual</asp:ListItem>
                        <asp:ListItem Value="EmergencyUP">EmergencyUnpaid</asp:ListItem>
                        <asp:ListItem>Marriage - Children</asp:ListItem>
                        <asp:ListItem>Maternity</asp:ListItem>
                        <asp:ListItem>Medical</asp:ListItem>
                        <asp:ListItem>Paternity</asp:ListItem>
                        <asp:ListItem Value="Plan Emergency">Plan Emergency - Annual</asp:ListItem>
                        <asp:ListItem Value="Plan Emergency - UP">Plan Emergency - Unpaid</asp:ListItem>
                        <asp:ListItem>Unpaid</asp:ListItem>
                        <asp:ListItem Value="Hospital">Hospitalization</asp:ListItem>
                        <asp:ListItem Value="marriage-self">Marriage-Self</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1"
                        ErrorMessage="Select Leave Type" InitialValue="-1">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="Label8" runat="server" Text="Leave Period" Width="154px"></asp:Label></td>
                <td style="width: 552px;">
                    <asp:TextBox ID="txtlfrom" runat="server" Width="70px"></asp:TextBox>~<asp:TextBox ID="txtlto" runat="server" Width="70px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtlto"
                        ErrorMessage="Select Leave Period">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlfrom"
                        ErrorMessage="Select Leave Period">*</asp:RequiredFieldValidator></td>
                       <cc1:CalendarExtender ID="ccelt"  runat="server"
    TargetControlID="txtlfrom" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtlfrom" />
   
       <cc1:CalendarExtender ID="ccelf"  runat="server"
    TargetControlID="txtlto" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtlto" />
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="Label6" runat="server" Text="Half-DayLeave" Width="151px"></asp:Label></td>
                <td style="width: 552px;" >
                    &nbsp;<asp:CheckBox ID ="cbltype" runat="server" Checked=false AutoPostBack=true  />
                    <asp:DropDownList ID="ddlltime" runat="server">
                        <asp:ListItem Value="-1">-Select Half Day Leave Time -</asp:ListItem>
                        <asp:ListItem>08.00 AM - 12.15 PM</asp:ListItem>
                        <asp:ListItem>12.15 PM - 05.00 PM</asp:ListItem>
                        <asp:ListItem Value="08.00 AM - 12.45 PM">08.00 AM - 12.45 PM(Friday Only)</asp:ListItem>
                        <asp:ListItem Value="01.15 PM - 06.00 PM">01.15 PM - 06.00 PM(Friday Only)</asp:ListItem>
                        <asp:ListItem Value="07.00 AM - 11.15 AM">07.00 AM - 11.15 AM(Production)</asp:ListItem>
                        <asp:ListItem Value="10.30 AM - 03.00 PM">10.30 AM - 03.00 PM(Production)</asp:ListItem>
                        <asp:ListItem Value="03.00 PM - 07.30 PM">03.00 PM - 07.30 PM(Production)</asp:ListItem>
                        <asp:ListItem Value="06.45 PM - 11.00 PM">06.45 PM - 11.00 PM(Production)</asp:ListItem>
                        <asp:ListItem Value="07.00 AM - 01.00 PM">07.00 AM - 01.00 PM(Production)</asp:ListItem>
                        <asp:ListItem Value="01.00 PM - 07.00 PM">01.00 PM - 07.00 PM(Production)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
         <td style="width: 100px; background-color:beige;">
                    <asp:Label ID="lblldays" runat="server" Text="Leave Days"></asp:Label></td>
                <td style="width: 552px">
                    &nbsp;<asp:TextBox ID="txtlDays" runat="server" Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtlDays"
                        ErrorMessage="Enter Leave Days" Width="3px">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige; height: 20px;">
                    <asp:Label ID="Label12" runat="server" Text="Reason"></asp:Label></td>
                <td style="width: 552px;">
                    <asp:TextBox ID="txtreason" runat="server" Height="42px" TextMode="MultiLine" Width="316px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtreason"
                        ErrorMessage="Enter Reason">*</asp:RequiredFieldValidator></td>
            </tr>
        </table>
        &nbsp;</asp:Panel>
</td>
</tr>
<tr>
<td style="vertical-align: middle; text-align: right">
    <asp:Button ID="btnlsave" runat="server" Text="APPLY LEAVE"
      SkinID ="buttonskin1" />
    <asp:Button ID="btnUpdate" SkinID ="buttonskin1" runat="server" Text="UPDATE LEAVE" />
    <asp:Button ID="btnlexit" SkinID ="buttonskin1" runat="server" Text="EXIT" />
</td>
</tr>
    <tr>
        <td style="vertical-align: middle; text-align: left;">
           
            
                 <p style="text-decoration: underline" >  
                  Conditions For Applying Annual Leave</p>         
                1. For Half a day - Should apply one day before<br />  
                2. For one day - Should apply three days before <br />
                3. More than one day - Should apply seven days before <br />
    
      
        </td>
    </tr>
</table>
     	<td background="../../images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
</asp:Panel>




<asp:Panel ID ="pnlstatus" runat="server">
			
 <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
					
<table>
<tr>
<td style="height: 23px;" class="td_head">
My Leave History / Status&nbsp;
</td>
</tr>

   
<tr>
<td style="vertical-align: middle; ">
<asp:GridView ID="GridView1" runat="server" DataSourceID="sqlleave"
              AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                   <PagerStyle BackColor="#284775"  HorizontalAlign="Center" ForeColor="White" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               
    
        <Columns>
            <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno" />
            <asp:BoundField DataField="applicationdate" HeaderText="AppliedOn" SortExpression="fromdate" dataformatstring="{0:dd/MM/yy}"  />
           <asp:BoundField DataField="days" HeaderText="No.of Days" SortExpression="days" />
            <asp:TemplateField HeaderText="Applied Dates" SortExpression="fromdate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="leavetype" HeaderText="Type" SortExpression="leavetype" />
            <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" />
            <asp:BoundField DataField="grantedleave" HeaderText="GrantedDays" SortExpression="grantedleave"  >
                <ControlStyle BackColor="Orange" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="GrantedDates" SortExpression="grfromdate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("grfromdate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("grfromdate", "{0:dd/MM/yy}") %>'></asp:Label>~
                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("grtodate","{0:dd/MM/yy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="statusreason" HeaderText="Remarks" SortExpression="statusreason" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">                     
                     <ItemTemplate>                      
                           <asp:Label ID = "Label1" runat="server" Text='<%# Eval("status") %>'  CommandArgument='<%# Eval("appno", "{0}") %>'> </asp:Label>
                           <asp:LinkButton ID="LinkButton1" CausesValidation =false  runat="server" OnCommand  ="getLeaveData"  Text='<%# Eval("status") %>' CommandArgument='<%# Eval("appno", "{0}") %>' ForeColor="#0000C0"></asp:LinkButton>                                       
                           <asp:LinkButton ID="LinkButton5" CausesValidation=false  runat="server" OnCommand  ="leavecancel"  Text="CANCEL" CommandArgument='<%# Eval("appno", "{0}") %>' ForeColor="RED"></asp:LinkButton>                                       
                           <cc1:ConfirmButtonExtender ID ="confirmgpcancel"
                            ConfirmText ="Are you sure you want to cancel the Leave" 
                            ConfirmOnFormSubmit ="true" runat="server" 
                            TargetControlID ="LinkButton5">
                           </cc1:ConfirmButtonExtender>
                    </ItemTemplate>  
           </asp:TemplateField>
            
          
        </Columns>
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="Sqlleave" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT * FROM [Leaveform] WHERE (([fromdate] >= @from) AND ([fromdate] <= @to)) AND ([empno] = @empcode) and (([status] <> 'CANCELLED') and ([status] <> 'C')) order by appno desc">
        <SelectParameters>
        <asp:Parameter Name="empcode" DefaultValue="" />
            <asp:Parameter Name="from" DefaultValue="" />
            <asp:Parameter Name="to" DefaultValue="" />      
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
</td>
</tr> 
</table>
     	<td background="../../images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
</asp:Panel>

<asp:Panel ID = "pnlapproval" runat=server >
 <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
					
<table>
<tr>
<td style="height: 23px;" class="td_head">
HOD Leave Approvals
</td>
</tr>

   
<tr>
<td style="vertical-align: middle; ">
    &nbsp;
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="sqlHodapproval"
    AllowPaging="True" AllowSorting="True" ShowFooter="True" EmptyDataText = "No Leave waiting for Approvals" CellPadding="4" ForeColor="#333333" GridLines="None">
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                   <PagerStyle BackColor="#284775"  HorizontalAlign="Center" ForeColor="White" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /> 
     <Columns>  
     <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno"  />
        
                   <asp:TemplateField HeaderText="EmpID" SortExpression="empno">
                       <ItemTemplate>
                          <asp:LinkButton ID="LinkButton2" ForeColor=Blue Font-Underline=true   runat="server" Text='<%# Eval("empno") %>' OnClick="emphistory_click"></asp:LinkButton>                                                                                             
                       </ItemTemplate>
                  </asp:TemplateField> 
            
         <asp:BoundField DataField="applicationdate" HeaderText="Applied On" dataformatstring="{0:dd/MM/yy}" SortExpression="applicationdate"  />
       
            <asp:BoundField DataField="days" HeaderText="No.of Days" SortExpression="days" />
            <asp:BoundField DataField="workfor" HeaderText="Annual" SortExpression="workfor" />
            <asp:TemplateField HeaderText="LeaveFrom" SortExpression="fromdate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("fromdate", "{0:dd/MM/yy}") %>'></asp:Label>~
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("todate", "{0:dd/MM/yy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="leavetype" HeaderText="LeaveType" SortExpression="leavetype" />
            <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" />
            <asp:BoundField DataField="statusreason" HeaderText="Status Reason" SortExpression="statusreason" />
            <asp:BoundField DataField="leavetime" HeaderText="LeaveTime" SortExpression="leavetime" />
            <asp:TemplateField HeaderText="LeaveGranted" SortExpression="grantedleave">
                  <ItemTemplate>
                       <asp:TextBox ID="txtgranted" runat="server" Text='<%# Bind("grantedleave") %>' Width="60px"></asp:TextBox>
                  </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GrantedFrom" SortExpression="grfromdate">
                  <ItemTemplate>
                    <asp:TextBox ID="txtgfrom" runat="server" Text='<%# Bind("grfromdate","{0:dd/MM/yy}") %>' Width="70px"></asp:TextBox>
                    <cc1:CalendarExtender ID="cce1" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                        PopupButtonID="txtgfrom" TargetControlID="txtgfrom">
                    </cc1:CalendarExtender>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GrantedTill" SortExpression="grtodate">
                  <ItemTemplate>
                        <asp:TextBox ID="txtgto" runat="server" Text='<%# Bind("grtodate","{0:dd/MM/yy}") %>' Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="cce2" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                            PopupButtonID="txtgto" TargetControlID="txtgto">
                        </cc1:CalendarExtender>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="carryfwd" HeaderText="carryfwd" SortExpression="carryfwd" />
            <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
            <asp:TemplateField HeaderText="Status" SortExpression="stat">
                  <ItemTemplate>
                          <asp:RadioButtonList ID="rblvstatus" runat="server"  SelectedValue='<%# Bind("stat") %>'>
                              <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                              <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                              <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                          </asp:RadioButtonList>
                   </ItemTemplate>
                   <FooterTemplate>
                              <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" OnClick ="UpdateLeaveApproval" />
                   </FooterTemplate>              
            </asp:TemplateField>

                  
       </Columns>
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
      <cc1:ModalPopupExtender runat="server" ID = "leavempe"  
             TargetControlID= "btnShowModalPopup"
                          PopupControlID = "pnlhistory" 
                          PopupDragHandleControlID ="pnlhistory" 
                         backgroundcssclass="modalBackground" 
                         OkControlID ="okbutton"   
                         DropShadow="false" EnableViewState="False"   ></cc1:ModalPopupExtender>
                         
   <asp:SqlDataSource ID="sqlHodapproval" runat="server"  ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECt  *,(Ltrim(rtrim(status))) as stat,* FROM Leaveform AS Leaveform INNER JOIN empmaster AS Empmaster  ON Empmaster.empcode = Leaveform.empno WHERE ((Leaveform.status = 'SCHEDULED')) AND (leaveform.department =@dept) AND (Leaveform.empno <> @empcode)and (leaveform.backdate='N') AND ((Leaveform.leavetype = 'Annual') or (Leaveform.leavetype = 'Emergency') or (Leaveform.leavetype = 'EmergencyUP') or (Leaveform.leavetype = 'EmergencyUnpaid') or (Leaveform.leavetype = 'PlanEmergencyUP')or (Leaveform.leavetype = 'PlanEmergency') or (leaveform.leavetype = 'Unpaid')) ORDER BY Leaveform.appno DESC ">
       <SelectParameters>
         <asp:Parameter Name="dept" DefaultValue="" />                       
         <asp:Parameter Name="empcode" DefaultValue="" />
       </SelectParameters>
    </asp:SqlDataSource>
      <asp:Button SkinID ="buttonskin1" runat="server" ID="btnShowModalPopup" style="display:none"/>
        
</td>
</tr>
</table>
     	<td background="../../images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>
			
			
			
		<asp:Panel ID = "PnlERApproval" runat=server >
 <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td style="width: 16px"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td background="../../images/cen_lef.gif" style="width: 16px; height: 1047px"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff" style="height: 1047px">
					
<table>
<tr>
<td style="height: 23px;" class="td_head">
ER Leave Approvals
</td>
</tr>

   
<tr>
<td style="vertical-align: middle; ">
    &nbsp;
    <asp:GridView ID="GrdERapproval" runat="server" AutoGenerateColumns="False" DataSourceID="sqlERapproval"
    AllowPaging="True" AllowSorting="True" ShowFooter="True" EmptyDataText = "No Leave waiting for Approvals" CellPadding="4" ForeColor="#333333" GridLines="None">
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                   <PagerStyle BackColor="#284775"  HorizontalAlign="Center" ForeColor="White" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /> 
     <Columns>  
     <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno"  />
        
                   <asp:TemplateField HeaderText="EmpID" SortExpression="empno">
                       <ItemTemplate>
                          <asp:LinkButton ID="LinkButton2" ForeColor=Blue Font-Underline=true  runat="server" Text='<%# Eval("empno") %>' OnClick="emphistory_click"></asp:LinkButton>                                                                                             
                       </ItemTemplate>
                  </asp:TemplateField> 
            
         <asp:BoundField DataField="applicationdate" HeaderText="Applied On" dataformatstring="{0:dd/MM/yy}" SortExpression="applicationdate"  />
       
            <asp:BoundField DataField="days" HeaderText="No.of Days" SortExpression="days" />
            <asp:BoundField DataField="workfor" HeaderText="Annual" SortExpression="workfor" />
            <asp:TemplateField HeaderText="LeaveFrom" SortExpression="fromdate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("fromdate", "{0:dd/MMM/yy}") %>'></asp:Label>~
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("todate", "{0:dd/MMM/yy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="leavetype" HeaderText="LeaveType" SortExpression="leavetype" />
            <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" />
         <asp:TemplateField HeaderText="Status Reason" SortExpression="statusreason">
             <EditItemTemplate>
                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("statusreason") %>'></asp:TextBox>
             </EditItemTemplate>
             <ItemTemplate>
                 <asp:TextBox ID="txtsreason" runat="server" Height="44px" Rows="2" TextMode="MultiLine"
                     Width="151px"></asp:TextBox>
             </ItemTemplate>
         </asp:TemplateField>
            <asp:BoundField DataField="leavetime" HeaderText="LeaveTime" SortExpression="leavetime" />       
            <asp:BoundField DataField="carryfwd" HeaderText="carryfwd" SortExpression="carryfwd" />
            <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
             <asp:BoundField DataField="backdate" HeaderText="BackDated" SortExpression="BackDated" />
            <asp:TemplateField HeaderText="Status" SortExpression="stat">
                  <ItemTemplate>
                          <asp:RadioButtonList ID="rblvestatus" runat="server"  SelectedValue='<%# Bind("stat") %>'>
                              <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                              <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                              <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                          </asp:RadioButtonList>
                   </ItemTemplate>
                   <FooterTemplate>
                              <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" OnClick ="UpdateLeaveERApproval" />
                   </FooterTemplate>              
            </asp:TemplateField>                  
       </Columns>
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>

   <asp:SqlDataSource ID="SqlERApproval" runat="server"  ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECt  *,(Ltrim(rtrim(status))) as stat,* FROM Leaveform AS Leaveform INNER JOIN empmaster AS Empmaster  ON Empmaster.empcode = Leaveform.empno WHERE ((Leaveform.status = 'SCHEDULED') AND (Leaveform.empno <> @empcode) AND (Leaveform.leavetype <> 'Annual') and (Leaveform.leavetype <> 'Emergency') and (Leaveform.leavetype <> 'EmergencyUP') and (Leaveform.leavetype <> 'EmergencyUnpaid') and (Leaveform.leavetype <> 'PlanEmergencyUP')and         (Leaveform.leavetype <> 'PlanEmergency') and (Leaveform.leavetype <> 'Unpaid')) or (backdate='Y' and status = 'SCHEDULED') ORDER BY Leaveform.appno DESC ">
       <SelectParameters>                    
         <asp:Parameter Name="empcode" DefaultValue="" />
       </SelectParameters>
    </asp:SqlDataSource>
</td>
</tr>
</table>
     	<td background="../../images/cen_rig.gif" style="width: 24px; height: 1047px;">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td height="16" style="width: 16px"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>	
			
			
			
					<asp:Panel ID = "Pnlhistory" runat=server >
             <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td width="16" style="height: 16px"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" style="height: 16px"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px; height: 16px;"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
     
             <table cellpadding ="5px" cellspacing ="5px" style="border-right: #333366 2px solid;
              border-top: #333366 2px solid; border-left: #333366 2px solid;
               border-bottom: #333366 2px solid; background-color: white;">
                 <tr>
                     <td colspan="3" style="color: white; background-color: #003399">
                         <asp:Label ID="lbltxtempid" runat="server"></asp:Label>
                         <asp:Label ID="Label17" runat="server" Text="  History"></asp:Label></td>
                 </tr>
             <tr>
                 <td class="lblclass" colspan="3" style="height: 29px">
                  <asp:Label ID="txtdeptsect"  runat="server" Text="Dept-Sect : "></asp:Label>&nbsp;
                   <asp:Label ID="txtdept2" runat="server"></asp:Label></td>
             </tr>
              <tr>
                  <td class="lblclass" colspan="3">
                  <asp:Label ID="txtdesig2" runat="server" Text="Designation :"></asp:Label>&nbsp;
                   <asp:Label ID="Label15" runat="server" ></asp:Label></td>
             </tr>
                 <tr>
                     <td colspan="3" >
                     <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="DarkGreen"> Leave Summary :</asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="lblclass"> &nbsp;<asp:Label ID="Label16" runat="server" ForeColor="DarkGreen"> Annual Leave Balance :</asp:Label>

              <asp:Label ID="lbltotannual" runat="server" ForeColor="DarkGreen"></asp:Label>
             </td>
                     <td class="lblclass">
                         &nbsp;<asp:Label ID="Label18" runat="server" ForeColor="DarkGreen">  Medical Leave Balance :</asp:Label>
                       
              <asp:Label ID="lbltotMedical" runat="server" ForeColor="DarkGreen"></asp:Label>
                     </td>
                     <td class="lblclass">
                         &nbsp;<asp:Label ID="Label22" runat="server" ForeColor="DarkGreen"> </asp:Label>
                       
              <asp:Label ID="lbllvpending" runat="server" ForeColor="DarkGreen"></asp:Label>
                       </td>                    
                 </tr>
     
                 <tr>
                     <td colspan="3">
            <asp:GridView ID="Grdlvhistory"  runat="server" AllowSorting="True" BorderColor="#3366CC" BackColor="White" BorderStyle="None" 
            BorderWidth="2px" CellPadding="4" ShowFooter="True" EmptyDataText = "No Leave Utilised So far" AllowPaging="True" >
              <RowStyle BackColor="White" ForeColor="#003399" />
                 <FooterStyle ForeColor="#003399" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <HeaderStyle  Font-Bold="True" ForeColor="Red" />
                   
            </asp:GridView>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="3" style="border-top: blue 2px solid">
                
             <asp:Button SkinID ="buttonskin1" ID="okbutton" runat="server" Text= "BACK" />
                     </td>
             </tr>            
             
             
             
             
              </table>
             
         
     	<td background="../../images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>
			
<!--  PAYROLL LEAVE CANCELLATION GRID ---->

			<asp:Panel ID = "Pnllcancel" runat=server >
             <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td width="16" style="height: 16px"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" style="height: 16px"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px; height: 16px;"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
						<table>
                                <tr>
                                <td style="height: 23px;" class="td_head"> PAYROLL LEAVE CANCELLATION </td></tr>  
                                <tr>
                                <td style="vertical-align: middle; ">
                                    <asp:GridView ID="GrdLeaveCancel" runat="server" 
                                    AllowPaging=true AllowSorting =true  AutoGenerateColumns="False" DataSourceID="SqlLeavecancel"
                                     CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter=true >
                                        <Columns>
                                            <asp:BoundField DataField="appno" HeaderText="appno" SortExpression="appno" />
                                            <asp:BoundField DataField="applicationdate" HeaderText="Appliedon" SortExpression="applicationdate" DataFormatString="{0:dd-MMM-yy}" />
                                           <asp:TemplateField HeaderText="EmpCode" SortExpression="empno" >
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empno") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Labeloremp" runat="server" Text='<%# Bind("empno") %>'></asp:Label>-
                                                    <asp:Label ID="Labelprname" runat="server" Text='<%# Eval("empname") %>'></asp:Label>
                                                </ItemTemplate>
                                           </asp:TemplateField>
                                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                                         
                                           <asp:TemplateField HeaderText="AppliedDates" SortExpression="fromdate">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Labelprfrom" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                                    <asp:Label ID="Labelprto" runat="server" Text='<%# Eval("todate", "{0:dd-MMM-yy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField DataField="grantedleave" HeaderText="GrantedDays" ItemStyle-HorizontalAlign=Center ItemStyle-VerticalAlign =Middle  SortExpression="grantedleave" />
                                          
                                            <asp:BoundField DataField="leavetype" HeaderText="leavetype" SortExpression="leavetype" />
                                            <asp:BoundField DataField="reason" HeaderText="reason" SortExpression="reason" />
                                            <asp:TemplateField HeaderText="status" SortExpression="status">
                                              <ItemTemplate>
                                                  <asp:RadioButtonList ID="rbprstatus" runat="server"  SelectedValue='<%# Bind("status") %>'>
                                                     <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                                      <asp:ListItem Value="CANCELLED">Cancel</asp:ListItem>
                                                  </asp:RadioButtonList>
                                           </ItemTemplate>
                                           <FooterTemplate>
                                                      <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="CANCEL LEAVE" OnClick ="UpdateLeavePRApproval" />
                                           </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
                                            <asp:BoundField DataField="carryfwd" HeaderText="cfwd" SortExpression="cfwd" />
                                          
                                       </Columns>
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlLeavecancel" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                        SelectCommand="SELECT *,(Ltrim(rtrim(status))) as status, Empmaster.empname, Empmaster.designation, Empmaster.sectioncode, Empmaster.departmentcode FROM Leaveform Leaveform INNER JOIN Empmaster Empmaster ON (Empmaster.empcode = Leaveform.empno)  and (leaveform.applicationdate >@from) and (leaveform.applicationdate <@to) and (leaveform.status = 'APPROVED') ORDER BY APPNO DESC&#13;&#10;">
                                        <SelectParameters>
                                            <asp:Parameter Name="from" />
                                            <asp:Parameter Name="to" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                					
					
					
					</td>
					</tr>
					</table>
					</td>
						<td background="../../images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>	
			
			
<!-- Leave Setting Master -->

		<asp:Panel ID = "Pnllsetting" runat=server >
             <table width="100%" cellpadding=0 cellspacing=0>
                <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
						<table style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid">
                                <tr>
                                <td style="height: 23px; width: 268px;" class="td_head" > LEAVE SETTING MASTER </td></tr>  
                                <tr>
                                <td style="vertical-align: middle; width: 268px;">
                                <asp:Panel ID =plsetting runat=server>
                                    <table style="width: 450px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                                        <tr>
                                            <td colspan="2" style="background-color: beige">
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Fill in all the fields" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; width: 154px;">
                                                <asp:Label ID="Label19" runat="server" Text="LeaveLevel"></asp:Label></td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtllevel" runat="server" Width="126px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtllevel"
                                                    ErrorMessage="Select Leave Level" ValidationGroup="pnll">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; width: 154px; height: 24px;">
                                                <asp:Label ID="Label20" runat="server" Text="Experience"></asp:Label></td>
                                            <td style="width: 200px; height: 24px;">
                                                <asp:DropDownList ID="Ddlexperience" runat="server">
                                                    <asp:ListItem Value="2">&lt;2</asp:ListItem>
                                                    <asp:ListItem Value="3">&gt;=2 and &lt;5</asp:ListItem>
                                                    <asp:ListItem Value="5">&gt;5</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="-1">select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Ddlexperience"
                                                    ErrorMessage="Select Experience" ValidationGroup="pnll" InitialValue="-1">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; width: 154px;">
                                                <asp:Label ID="Label23" runat="server" Text="Probation"></asp:Label></td>
                                            <td style="width: 130px">
                                                <asp:TextBox ID="txtprobation" runat="server" Width="102px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtprobation"
                                                    ErrorMessage="Select Probation" ValidationGroup="pnll">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; width: 154px;">
                                                <asp:Label ID="Label24" runat="server" Text="Annual Entitilement"></asp:Label></td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtaentitile" runat="server" Width="102px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtaentitile"
                                                     ErrorMessage="Select AnnualEntitilement" ValidationGroup="pnll">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; width: 154px; height: 17px;">
                                                <asp:Label ID="Label25" runat="server" Text="Medical Entitilement" Width="178px"></asp:Label></td>
                                            <td style="width: 200px; height: 17px;">
                                                <asp:TextBox ID="txtmentitile" runat="server" Width="103px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtmentitile"
                                                    ErrorMessage="Select MedicalEntitilement" ValidationGroup="pnll">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblmsg" runat="server" Font-Size="Small" ForeColor="#804000"></asp:Label></td>
                                                <td text-align: right style="vertical-align: baseline; text-align: right";>
                                                <asp:Button ID="Btnsetting"  SkinID ="buttonskin1" runat="server" Text="ADD" ValidationGroup="pnll" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="grdleavelevel" DataKeyNames="leavelevel,experience"  runat="server"  AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqlleavesetting" ForeColor="#333333"
                                                    GridLines="Both" Width="438px" PageSize="20"   AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" >
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"   />
                                                    <Columns >
                                                        <asp:BoundField DataField="Leavelevel" HeaderText="Leavelevel" ReadOnly=true  SortExpression="Leavelevel"   >
                                                        
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                     
                                                        <asp:TemplateField HeaderText="Experience" SortExpression="Experience">
                                                             <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Experience") %>'></asp:Label>
                                                                Yrs
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Probation" SortExpression="probation">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("probation") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("probation") %>'></asp:Label>
                                                                Mnts
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Annual Entitilement" SortExpression="annual">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("annual") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("annual") %>'></asp:Label>
                                                                Days
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Medical Entitilement" SortExpression="medical">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("medical") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("medical") %>'></asp:Label>
                                                                Days
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#999999" />
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="sqlleavesetting" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                     SelectCommand="SELECT * FROM [LeaveLevel]"
                                                      DeleteCommand = "Delete from leavelevel where leavelevel=@leavelevel and experience =@experience "
                                                       UpdateCommand = "hrmis_updleavemaster" UpdateCommandType =  "StoredProcedure"  >
                                                       <UpdateParameters >                                                                                                         
                                                       <asp:Parameter Name="leavelevel" Type="decimal" />
                                                       <asp:Parameter Name="experience" Type="decimal" />
                                                       <asp:Parameter Name="probation" Type="decimal" />
                                                       <asp:Parameter Name="annual" Type="decimal" />
                                                       <asp:Parameter Name="medical" Type="decimal" />
                                                       </UpdateParameters>
                                                       <DeleteParameters>
                                                         <asp:Parameter Name="leavelevel" Type="decimal" />
                                                       <asp:Parameter Name="experience" Type="decimal" />
                                                       </DeleteParameters>
                                                                                
                                             
                                                                                                                                                 
                                                    
                                                    </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                       
                                </asp:Panel>
                                </td>
					            </tr>
					    </table>
					    </td>
						<td background="../../images/cen_rig.gif" style="width: 24px">
					    <IMG height="11" src="../../images/cen_rig.gif" width="24"></td></tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>
			
				
<!-- Reports Overall-->

 	<asp:Panel ID = "pnlreport" runat=server >
             <table width="100%" cellpadding=0 cellspacing=0>
                <tr>
					<td style="width: 16px"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 25px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td background="../../images/cen_lef.gif" style="height: 372px; width: 16px;"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff" style="height: 372px">
				   
        <table>
            <tr>
                <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 295px;" >
        <table>
            <tr>
                <td class="td_head" colspan="2" style="height: 24px;">
                    Leave Report Overall</td>
            </tr>
            <tr>
                <td style="background-color: beige; height: 24px; width: 148px;">
                    <asp:Label ID="Label26" runat="server" Text="Report TimeLine" Width="143px" ></asp:Label></td>
                <td style="width: 403px; height: 26px;" >
                    <asp:TextBox ID="txtfrom" runat="server" Width="87px" ></asp:TextBox> 
                    ~
                    <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                    
                    <cc1:CalendarExtender ID="ccefrom"  runat="server"
    TargetControlID="txtfrom" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtfrom"
  
       />
                    
                    <cc1:CalendarExtender ID="cceto"  runat="server"
    TargetControlID="txtto" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtto"
  
       />
            </tr>
            <tr>
                <td style="height: 17px; background-color: beige; width: 148px;">
                    <asp:Label ID="Label27" runat="server" Text="Report By"></asp:Label></td>
                <td style="width: 403px; height: 17px">
                    <asp:RadioButtonList ID="rdoptions" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="408px">
                        <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                        <asp:ListItem Value="Sect">BySect</asp:ListItem>
                        <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="height: 24px; background-color: beige; width: 148px;">
                    <asp:Label ID="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                <td style="width: 403px; height: 24px">
                    <asp:DropDownList ID="ddldeptr" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="dept" DataValueField="departmentcode" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 24px; background-color: beige; width: 148px;">
                    <asp:Label ID="lblsectr" runat="server" Text="Select Section"></asp:Label></td>
                <td style="width: 403px; height: 24px">
                    <asp:DropDownList ID="ddlsectrpt" runat="server" DataSourceID="selsectreport" DataTextField="sectioncode"
                        DataValueField="sectioncode">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="background-color: beige; height: 24px; width: 148px;">
                    <asp:Label ID="lbldesigr" runat="server" Text="Select Designation"></asp:Label></td>
                <td style="width: 403px; height: 24px;">
                    <asp:DropDownList ID="ddldesigr" runat="server" DataSourceID="SqlDesig" DataTextField="desig"
                        DataValueField="desig" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="background-color: beige; height: 24px; width: 148px;">
                    <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
                <td style="width: 403px">
                    <asp:TextBox ID="txtempidr" runat="server" Width="83px" AutoPostBack="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 148px; height: 33px; background-color: beige">
                    <asp:Label ID="Label28" runat="server" Text="ByStatus"></asp:Label></td>
                <td style="width: 403px; height: 33px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="445px">
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Scheduled</asp:ListItem>
                        <asp:ListItem>Cancelled</asp:ListItem>
                        <asp:ListItem>Rejected</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 26px">
                    &nbsp;<asp:Button ID="Button1" SkinID="buttonskin1" runat="server" Text="SHOW REPORT" />
            </tr>
        </table>
                    <asp:SqlDataSource ID="selsectreport" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                </td></tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department">
                    </asp:SqlDataSource>
                          <asp:SqlDataSource ID="Sqlsecdept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster where departmentcode=@dept">
                    </asp:SqlDataSource>
               
        </table>
 
					
					
                       </td>
						<td background="../../images/cen_rig.gif" style="width: 25px; height: 372px;">
					    <IMG height="11" src="../../images/cen_rig.gif" width="24"></td></tr>
				<tr>
					<td height="16" style="width: 16px"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 25px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>
<!-- Reports Overall by HOD-->

 	<asp:Panel ID = "pnlHODreports" runat=server >
             <table width="100%" cellpadding=0 cellspacing=0>
                <tr>
					<td style="width: 16px; height: 16px"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" style="height: 16px"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px; height: 16px;"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td background="../../images/cen_lef.gif" style="width: 16px"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
				   
        <table>
            <tr>
                <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 295px;" >
        <table>
            <tr>
                <td class="td_head" colspan="2" style="height: 24px;">
                   HOD Overall Leave Report </td>
            </tr>
            <tr>
                <td style="background-color: beige; height: 24px; width: 148px;">
                    <asp:Label ID="Label29" runat="server" Text="Report TimeLine" Width="143px" ></asp:Label></td>
                <td style="width: 403px; height: 26px;" >
                    <asp:TextBox ID="hodtxtfrom" runat="server" Width="87px" ></asp:TextBox> 
                    ~
                    <asp:TextBox ID="hodtxtto" runat="server" Height="14px" Width="77px"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="hodtxtto">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="hodtxtfrom"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                    
                    <cc1:CalendarExtender ID="CalendarExtender1"  runat="server"
    TargetControlID="hodtxtfrom" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="hodtxtfrom"
  
       />
                    
                    <cc1:CalendarExtender ID="CalendarExtender2"  runat="server"
    TargetControlID="hodtxtto" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="hodtxtto"
  
       />
            </tr>
            <tr>
                <td style="height: 17px; background-color: beige; width: 148px;">
                    <asp:Label ID="Label30" runat="server" Text="Report By"></asp:Label></td>
                <td style="width: 403px; height: 17px">
                    <asp:RadioButtonList ID="hodrdorpt" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="408px">
                        <asp:ListItem Value="Sect">BySect</asp:ListItem>
                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
           
            <tr>
                <td style="height: 24px; background-color: beige; width: 148px;">
                    <asp:Label ID="Label32" runat="server" Text="Select Section"></asp:Label></td>
                <td style="width: 403px; height: 24px">
                    <asp:DropDownList ID="hodddlsect" runat="server" DataSourceID="SqlDataSource2" DataTextField="sectioncode"
                        DataValueField="sectioncode" AutoPostBack="True">
                    </asp:DropDownList></td>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT [sectioncode] FROM [sectionmaster] WHERE ([departmentcode] = @departmentcode)">
                         <FilterParameters>
                         <asp:SessionParameter Name = departmentcode SessionField = "_edept" Type ="String" />
                         </FilterParameters>
                         <SelectParameters>
                             <asp:SessionParameter Name="departmentcode" SessionField="_edept" Type="String" />
                         </SelectParameters>
                        </asp:SqlDataSource>
            </tr>
           
            <tr>
                <td style="background-color: beige; height: 24px; width: 148px;">
                    <asp:Label ID="Label34" runat="server" Text="ByEmployee"></asp:Label></td>
                <td style="width: 403px">
                    <asp:TextBox ID="hodtxtemp" runat="server" Width="83px" AutoPostBack="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 148px; height: 33px; background-color: beige">
                    <asp:Label ID="Label35" runat="server" Text="ByStatus"></asp:Label></td>
                <td style="width: 403px; height: 33px">
                    <asp:RadioButtonList ID="hodrdooptions" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="445px">
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Scheduled</asp:ListItem>
                        <asp:ListItem>Cancelled</asp:ListItem>
                        <asp:ListItem>Rejected</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 26px">
                    &nbsp;<asp:Button ID="hodbtnrpt" SkinID="buttonskin1" runat="server" Text="SHOW REPORT" />
            </tr>
        </table>
                 
               
        </table>
 
					
					
                       </td>
						<td background="../../images/cen_rig.gif" style="width: 24px">
					    <IMG height="11" src="../../images/cen_rig.gif" width="24"></td></tr>
				<tr>
					<td height="16" style="width: 16px"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>
			
			<!-- Leave summary reports -->
			
			          <asp:Panel ID = "Pnlleavesummary" runat=server >
             <table width="100%" cellpadding=0 cellspacing=0>
                <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16" style="width: 340px"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif" style="height: 124px"><IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff" style="width: 340px; height: 124px;">
				   
     
        <table style="width: 471px">
            <tr>
                <td class="td_head" colspan="2" style="height: 24px;">
                   Leave Summary Report</td>
            </tr>
            <tr>
                <td style="background-color: beige; height: 24px; width: 148px;">
                    <asp:Label ID="Label31" runat="server" Text="Report TimeLine" Width="143px" ></asp:Label></td>
                <td style="width: 403px; height: 26px;" >
                    <asp:TextBox ID="rpttxtfrom" runat="server" Width="87px" ></asp:TextBox> 
                    ~
                    <asp:TextBox ID="rpttxtto" runat="server" Height="14px" Width="77px"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rpttxtto">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="rpttxtfrom"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                    
                    <cc1:CalendarExtender ID="CalendarExtender3"  runat="server"
    TargetControlID="rpttxtfrom" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="rpttxtfrom"
  
       />
                    
                    <cc1:CalendarExtender ID="CalendarExtender4"  runat="server"
    TargetControlID="rpttxtto" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="rpttxtto"
  
       />
            </tr>
            <tr>
                <td style="width: 148px; height: 24px; background-color: beige">
                    <asp:Label ID="Label33" runat="server" Text="Select Leave type" Width="143px"></asp:Label></td>
                <td style="width: 403px; height: 26px">
                    <asp:DropDownList ID="rptddlltype" runat="server">
                        <asp:ListItem Value="-1">- Select Leave type -</asp:ListItem>
                        <asp:ListItem>Annual</asp:ListItem>
                        <asp:ListItem>Calamity</asp:ListItem>
                        <asp:ListItem Value="CompanyHoliday">Company Holiday</asp:ListItem>
                        <asp:ListItem>Compassionate</asp:ListItem>
                        <asp:ListItem Value="Emergency">Emergency - Annual</asp:ListItem>
                        <asp:ListItem Value="EmergencyUP">EmergencyUnpaid</asp:ListItem>
                        <asp:ListItem>Marriage - Children</asp:ListItem>
                        <asp:ListItem>Maternity</asp:ListItem>
                        <asp:ListItem>Medical</asp:ListItem>
                        <asp:ListItem>Paternity</asp:ListItem>
                        <asp:ListItem Value="Plan Emergency">Plan Emergency - Annual</asp:ListItem>
                        <asp:ListItem Value="Plan Emergency - UP">Plan Emergency - Unpaid</asp:ListItem>
                        <asp:ListItem>Unpaid</asp:ListItem>
                        <asp:ListItem Value="Hospital">Hospitalization</asp:ListItem>
                        <asp:ListItem Value="marriage-self">Marriage-Self</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 26px">
                    &nbsp;<asp:Button ID="btnrptsummary" SkinID="buttonskin1" runat="server" Text="SHOW REPORT" /></td>
                    
            </tr>
        </table>
   
 					
                       </td>
						<td background="../../images/cen_rig.gif" style="width: 24px; height: 124px;">
					    <IMG height="11" src="../../images/cen_rig.gif" width="24"></td></tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16" style="width: 340px"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
			</asp:Panel>
			
			
			
			<asp:Panel ID = "pnlentitilement" runat=server >
                <table width="100%" cellpadding=0 cellspacing=0>
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 473px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 24px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 222px;">
                            <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 473px; height: 222px">
                            <table style="height: 175px">
                                <tr>
                                    <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 187px;" valign="top" >
                                        <table>
                                            <tr>
                                                <td class="td_head" colspan="2" style="height: 24px;">
                                                    Leave Entitilement Report</td>
                                            </tr>
                                            <tr>
                                                <td style="height: 14px; background-color: beige; width: 148px;">
                                                    <asp:Label ID="Label37" runat="server" Text="Report By"></asp:Label></td>
                                                <td style="width: 230px; height: 14px">
                                                    <asp:RadioButtonList ID="rdoentby" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="222px" Height="19px">
                                                        <asp:ListItem Value="Desig" >By Deisgnation</asp:ListItem>
                                                        <asp:ListItem Value="dept" >ByDept</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 24px; background-color: beige; width: 148px;">
                                                    <asp:Label ID="Label38" runat="server" Text="Select Department"></asp:Label></td>
                                                <td style="width: 230px; height: 24px">
                                                    <asp:DropDownList ID="ddlentdept" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="dept" DataValueField="departmentcode" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: beige; height: 24px; width: 148px;">
                                                    <asp:Label ID="Label39" runat="server" Text="Select Designation"></asp:Label></td>
                                                <td style="width: 230px">
                                                    <asp:DropDownList ID="ddlentdesig" runat="server" DataSourceID="SqlDesig" DataTextField="desig"
                        DataValueField="desig" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2" style="height: 26px">
                                                    &nbsp;<asp:Button ID="btnentrpt" SkinID="buttonskin1" runat="server" Text="SHOW REPORT" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 24px; height: 222px;">
                            <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td height="16" style="width: 16px">
                            <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                        <td background="../../images/bot_mid.gif" height="16" style="width: 473px">
                            <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                        <td height="16" style="width: 24px">
                            <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                    </tr>
                </table>
            </asp:Panel>
          <asp:Panel ID = "pnloverall" runat=server >  
            <table cellpadding=0 cellspacing=0 style="width: 60%">
                <tr>
                    <td width="16">
                        <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                    <td background="../../images/top_mid.gif" height="16">
                        <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                    <td style="width: 25px">
                        <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" background="../../images/cen_lef.gif" style="height: 372px">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                    <td vAlign="top" bgColor="#ffffff" style="height: 372px">
                        <table>
                            <tr>
                                <td colspan="2" style="width: 776px; border-bottom: 2px solid; height: 295px;" >
                                    <table>
                                        <tr>
                                            <td class="td_head" colspan="2" style="height: 24px;">
                                                Overall Leave summary
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; height: 24px; width: 148px;">
                                                <asp:Label ID="Label36" runat="server" Text="Report TimeLine" Width="143px"></asp:Label></td>
                                            <td style="width: 403px; height: 26px;" >
                                                <asp:TextBox ID="txtsumfrom" runat="server" Width="87px"></asp:TextBox>
                                                ~
                                                <asp:TextBox ID="txtsumto" runat="server" Height="14px" Width="77px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtsumto">*</asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtsumfrom"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                                            <cc1:CalendarExtender ID="CalendarExtender5"  runat="server"
    TargetControlID="txtsumfrom" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtsumfrom"
  
       />
                                            <cc1:CalendarExtender ID="CalendarExtender6"  runat="server"
    TargetControlID="txtsumto" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtsumto"
  
       />
                                        </tr>
                                        <tr>
                                            <td style="height: 17px; background-color: beige; width: 148px;">
                                                <asp:Label ID="Label40" runat="server" Text="Report By"></asp:Label></td>
                                            <td style="width: 403px; height: 17px">
                                                <asp:RadioButtonList ID="rdosumby" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="408px">
                                                    <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                                                    <asp:ListItem Value="Sect">BySect</asp:ListItem>
                                                    <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                                                    <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 24px; background-color: beige; width: 148px;">
                                                <asp:Label ID="Label41" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                                            <td style="width: 403px; height: 24px">
                                                <asp:DropDownList ID="ddlsumdept" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="dept" DataValueField="departmentcode" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 24px; background-color: beige; width: 148px;">
                                                <asp:Label ID="Label42" runat="server" Text="Select Section"></asp:Label></td>
                                            <td style="width: 403px; height: 24px">
                                                <asp:DropDownList ID="ddlsumsect" runat="server" DataSourceID="selsectreport" DataTextField="sectioncode"
                        DataValueField="sectioncode">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; height: 24px; width: 148px;">
                                                <asp:Label ID="Label43" runat="server" Text="Select Designation"></asp:Label></td>
                                            <td style="width: 403px; height: 24px;">
                                                <asp:DropDownList ID="ddlsumdesig" runat="server" DataSourceID="SqlDesig" DataTextField="desig"
                        DataValueField="desig" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: beige; height: 26px; width: 148px;">
                                                <asp:Label ID="Label44" runat="server" Text="ByEmployee"></asp:Label></td>
                                            <td style="width: 403px; height: 26px;">
                                                <asp:TextBox ID="txtsumemp" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2" style="height: 26px">
                                                &nbsp;<asp:Button ID="btnsumrpt" SkinID="buttonskin1" runat="server" Text="SHOW REPORT" />
                                            </td>
                                        </tr>
                                    </table>
                       
                        </table>
                    </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 372px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>
			
			
						
<!-- Main Table Ends here -->
			
 </td>
    </tr>
		</table>
		
</asp:Content>
