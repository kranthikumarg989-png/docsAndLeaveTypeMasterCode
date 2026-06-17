<%@ Page Language="vb" AutoEventWireup="true" MasterPageFile="~/EMS.Master" EnableEventValidation="false" Theme="buttonems" CodeBehind="GPApplication.aspx.vb" Inherits="E_Management.GPApplication"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="CPHApplication" runat="server">

    <asp:HiddenField ID="lblempid" runat="server" Value="014543" />
    <asp:HiddenField ID="lblempname" runat="server" Value="satya" />
    <asp:HiddenField ID="lbldept" runat="server" Value="9000" /> 
     <asp:HiddenField ID="lblsect" runat="server" Value="9000" /> &nbsp;
   
     
 <table cellpadding=0 cellspacing = 0 align="center">
 
<tr>
<td style="height: 669px">

<asp:Panel ID = "gpstatus" runat = "server" Height= "100%" Width ="900px">
<table>

      <tr>
      
          <td class="td_head">
             My GatePass History<asp:Label ID="Label24" runat="server" Text=""></asp:Label><br />             
</td>       
      </tr>
      <tr>
         <td>
             <asp:GridView ID="GridView1" runat="server" DataSourceID="sqlgatepass"
              AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                   <PagerStyle BackColor="#284775"  HorizontalAlign="Center" ForeColor="White" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <Columns>
                  
                     <asp:BoundField DataField="Passno" HeaderText="Passno" SortExpression="Passno" />
                     <asp:BoundField DataField="date1" HeaderText="Applied on" SortExpression="date1" dataformatstring="{0:dd/MM/yy}"  />
                     <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                     <asp:BoundField DataField="outdate" HeaderText="OutDate" SortExpression="outdate" dataformatstring="{0:dd/MM/yy}" />
                     <asp:BoundField DataField="outtime" HeaderText="Time out" SortExpression="outtime" DataFormatString="{0:t}" />
                     <asp:BoundField DataField="intime" HeaderText="Time In" SortExpression="intime" DataFormatString="{0:t}" />
                     <asp:BoundField DataField="gatepasstype" HeaderText="Passtype" SortExpression="gatepasstype" />
                 
                     <asp:TemplateField HeaderText="Status" SortExpression="status">                     
                     <ItemTemplate>                      
                           <asp:Label ID = "Label1" runat="server" Text='<%# Eval("status") %>'  CommandArgument='<%# Eval("passno", "{0}") %>'> </asp:Label>
                           <asp:LinkButton ID="LinkButton1"  runat="server" OnCommand  ="mpop"  Text='<%# Eval("status") %>' CommandArgument='<%# Eval("passno", "{0}") %>' ForeColor="#0000C0"></asp:LinkButton>                                       
                            <asp:LinkButton ID="LinkButton5" runat="server" OnCommand  ="gpcancel"  Text="CANCEL" CommandArgument='<%# Eval("passno", "{0}") %>' ForeColor="RED"></asp:LinkButton>                                       
                           <cc1:ConfirmButtonExtender ID ="confirmgpcancel"
                            ConfirmText ="Are you sure you want to cancel the GatePass" 
                            ConfirmOnFormSubmit ="true" runat="server" 
                            TargetControlID ="LinkButton5">
                           </cc1:ConfirmButtonExtender>
                    </ItemTemplate>  
                    </asp:TemplateField>
                  </Columns>
                 <EditRowStyle BackColor="#999999" />
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             </asp:GridView>
              <asp:SqlDataSource OnSelecting ="sqlgatepass_Selecting" ID="sqlgatepass" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" SelectCommand="SELECT [passno], [date1], [purpose], [outdate], [outtime], [indate], [intime], [location], [gatepasstype] ,[status] FROM [staffgatepass] WHERE (([outdate] >= @outdate) AND ([outdate] <= @outdate2) AND ([empcode] = @empcode) and status <> 'CANCELLED')  order by passno desc">
                 <SelectParameters> 
                 <asp:Parameter Name ="empcode"   />                 
                    <asp:Parameter Name ="outdate"   /> 
                    <asp:Parameter Name ="outdate2"   />                        
                 </SelectParameters>
             </asp:SqlDataSource>
          <table style="border-right: #1a5c9b 1px solid; border-top: #1a5c9b 1px solid;
           border-left: #1a5c9b 1px solid;
           border-bottom: #1a5c9b 1px solid;">
      <tr>
          <td colspan="5" class="td_head" style="height: 21px">
              Customer / Supplier Pass status </td>           
                     
      </tr>
      <tr>
      <td>        
             <asp:GridView ID="GrdCVPassStatus" runat="server" DataSourceID="sqlcvpass" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                   <PagerStyle BackColor="#284775"  HorizontalAlign="Center" ForeColor="White" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <Columns>
                   <asp:BoundField DataField="companyname" HeaderText="CompName" SortExpression="companyname" />
                  <asp:BoundField DataField="arrivaldate" HeaderText="Arrivaldate" SortExpression="arrivaldate" DataFormatString="{0:dd/MM/yy}" />
                 <asp:BoundField DataField="arrivaltime" HeaderText="Arrivaltime" SortExpression="arrivaltime" DataFormatString="{0:t}" />
                    <asp:BoundField DataField="personincharge" HeaderText="Visitor Name" SortExpression="personincharge" />
                 <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
                   <asp:BoundField DataField="noofperson" HeaderText="no.of person" SortExpression="noofperson" />
                     <asp:BoundField DataField="companypersonincharge" HeaderText="Comp.PersonIncharge" InsertVisible="False" ReadOnly="True" />
                
               <asp:BoundField DataField="recno" HeaderText="Recno" InsertVisible="False" ReadOnly="True"
                  
                      SortExpression="recno" />
                <asp:TemplateField HeaderText="Status" SortExpression="status">                     
                     <ItemTemplate>                      
                           <asp:Label ID = "lblcv" runat="server" Text='<%# Eval("status") %>'  CommandArgument='<%# Eval("recno", "{0}") %>'> </asp:Label>
                           <asp:LinkButton ID="lbcv" runat="server" OnCommand  ="FncRetreivecpass"  Text='<%# Eval("status") %>' 
                           CommandArgument='<%# Eval("recno", "{0}") %>' ForeColor="#0000C0"></asp:LinkButton>
                           
                           <asp:LinkButton ID="lbcancecv" runat="server" OnCommand  ="cvcancel"  Text="CANCEL" 
                           CommandArgument='<%# Eval("recno", "{0}") %>' ForeColor="RED"></asp:LinkButton>  
                                                                
                           <cc1:ConfirmButtonExtender ID ="confirmCVcancel"
                            ConfirmText ="Are you sure you want to cancel the cust/Supp Pass" 
                            ConfirmOnFormSubmit ="true" runat=server 
                            TargetControlID ="lbcancecv">
                           </cc1:ConfirmButtonExtender>                                      
                    </ItemTemplate>  
                    </asp:TemplateField>
                </Columns>
                 <EditRowStyle BackColor="#999999" />
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          </asp:GridView>
          <asp:SqlDataSource ID="sqlcvpass" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
              SelectCommand="SELECT acc_customerapplication.empcode, acc_customerapplication.REMARKS, acc_customerapplication.visitortype, acc_customerapplication.companyname, acc_customerapplication.personincharge, acc_customerapplication.noofperson, acc_customerapplication.contactno, acc_customerapplication.arrivaldate,acc_customerapplication.arrivaltime, empmaster.empname, acc_customerapplication.purpose, acc_customerapplication.receptionarea, acc_customerapplication.date1, acc_customerapplication.recno, acc_customerapplication.status, acc_customerapplication.approvedby, acc_customerapplication.department, acc_customerapplication.category, acc_customerapplication.visitdepartment,acc_customerapplication.otherarea, acc_customerapplication.companypersonincharge, acc_customerapplication.atimein, acc_customerapplication.atimeout, acc_customerapplication.taxibooking,acc_customerapplication.taxicost, acc_customerapplication.hotelarrangement, acc_customerapplication.hotelcost,acc_customerapplication.hotelname, acc_customerapplication.createdby, acc_customerapplication.createdtime, acc_customerapplication.modifiedby, acc_customerapplication.modifiedtime FROM acc_customerapplication acc_customerapplication INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_customerapplication.empcode)  WHERE ((((department = @dept) and (empmaster.empcode =@emp) ) AND (datepart(mm, arrivaldate) >= datepart(mm,  getdate() ))) AND (datepart(yy, arrivaldate) >= datepart(yy,  getdate() ) AND STATUS <> 'C')) order by recno desc">
                <SelectParameters>                 
                    <asp:Parameter Name ="dept"   />                                     
                    <asp:Parameter Name="emp" />
                 </SelectParameters>
          
          </asp:SqlDataSource>
          
      
      </td>
      </tr>
      
      </table>
          </td>
      </tr>  
       </table>
       
</asp:Panel>
   <asp:Panel ID="pGform" runat="server" Height="100%" Width="700px">

  <table cellpadding=0 cellspacing=0>
	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><IMG height="16" src="/images/top_mid.gif" width="16"></td>
					<td width="24"><IMG height="16" src="/images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><IMG height="11" src="/images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
      <table width="100%"><tr>
                <td colspan="2" class="td_head"  style="BORDER-BOTTOM: 1px inset; height: 18px;">
              Fill in all the required fields</td>
                  <asp:ValidationSummary ID="ValidationSummary2"
HeaderText="You must enter a value in the following fields:"
DisplayMode="BulletList"
EnableClientScript="true"
runat="server"/>
      </tr>
      <tr>
          <td style="width: 315px">
              GatePass Num</td>
          <td style="width: 529px">
              <asp:Label ID="gppassnum" runat="server" BackColor="#FFFFC0" Font-Size="Medium"></asp:Label></td>
      </tr>
  
       <tr>
   
            <td style="width: 315px">
                <asp:Label ID="Label1" runat="server" Text="GatePass Type"></asp:Label>
            </td>
            <td style="width: 529px">
                <asp:DropDownList ID="ddltype" runat="server">
                    <asp:ListItem Value="PERSONAL">Personal</asp:ListItem>
                    <asp:ListItem Value="OFFICIAL">Official</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
      <tr>
          <td style="width: 315px">
              Purpose</td>
          <td style="width: 529px">
              <asp:TextBox ID="txtpurpose" runat="server" Height="67px" Rows="5" Width="205px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
              ErrorMessage="Enter the Purpose of gatepass!!" text ="*" 
              ControlToValidate="txtpurpose"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
          <td colspan="2" class="td_head">
              Contact Details</td>
      </tr>
      <tr>
          <td style="width: 315px">
              Location</td>
          <td style="width: 529px">
              <asp:TextBox ID="txtlocation" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <td style="width: 315px; height: 21px">
              Phone Number</td>
          <td style="width: 529px; height: 21px">
              <asp:TextBox ID="txtph" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <td style="width: 315px">
              Vehicle Number</td>
          <td style="width: 529px">
              <asp:TextBox ID="txtvehicle" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <td colspan="2" class="td_head">
              Out and IN Details</td>
      </tr>
      <tr>
          <td style="width: 315px; height: 81px;">
              Date Out</td>
          <td style="width: 529px; height: 81px;">
              <asp:TextBox ID="dategp" runat="server" ></asp:TextBox>
              <asp:Image ID="imgcal" runat="server" ImageUrl="/images/Calender.png" />&nbsp;
          <cc1:CalendarExtender ID="cce1"  runat="server"
    TargetControlID="dategp" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="dategp"
  
       />  <cc1:CalendarExtender ID="CalendarExtender2"  runat="server"
    TargetControlID="dategp" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="imgcal"
  
       />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
              ErrorMessage="Enter GatePass Date!!" text ="*" 
               Width="159px" ControlToValidate="dategp"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
          <td style="width: 315px">
              Time Out (hrs:min)</td>
          <td style="width: 529px">
              <asp:TextBox ID="txtOuthr" runat="server" Width="25px"></asp:TextBox>
              <asp:TextBox ID="Txtoutmin" runat="server" Width="22px"></asp:TextBox>&nbsp;
              <asp:DropDownList ID="ddout" runat="server">
                  <asp:ListItem Value="AM">am</asp:ListItem>
                  <asp:ListItem Value="PM">pm</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOuthr"
                  ErrorMessage="Enter timeOut hour!! " text ="*"  ></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txtoutmin"
                  ErrorMessage="Enter timeOut min" text ="*" ></asp:RequiredFieldValidator>
              <asp:RangeValidator ID="RangeValidator2" runat="server"            
              ErrorMessage="Enter Value from 1 to 12" ControlToValidate ="txtouthr" Type = "Integer" MinimumValue ="1" MaximumValue ="12"></asp:RangeValidator>
              
              <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Enter value from 0 to 60" 
              ControlToValidate ="txtoutmin" MinimumValue="0" MaximumValue="60" Type = "Integer" ></asp:RangeValidator></td>
      </tr>
      <tr>
          <td style="width: 315px">
              Time In(hrs:min)</td>
          <td style="width: 529px">
              <asp:TextBox ID="txtinhr" runat="server" Width="25px"></asp:TextBox>
              <asp:TextBox ID="txtinmin" runat="server" Width="22px"></asp:TextBox>
              &nbsp;<asp:DropDownList ID="ddin" runat="server">
                  <asp:ListItem Value="AM">am</asp:ListItem>
                  <asp:ListItem Value="PM">pm</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtinmin"
                  ErrorMessage="Enter timeIn min!! " text ="*" ></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtinhr"
                  ErrorMessage="Enter timeIn hr" text ="*" ></asp:RequiredFieldValidator>
                  <asp:RangeValidator ID="RangeValidator3" runat="server" 
              ErrorMessage="Enter Value from 1 to 12" Type = "Integer" ControlToValidate ="txtinhr" MinimumValue ="1" MaximumValue ="12"></asp:RangeValidator>
             
             <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Enter value from 0 to 60" 
              ControlToValidate ="txtinmin" Type = "Integer" MinimumValue="0" MaximumValue="60"/></td>
      </tr>
      <tr>
          <td style="width: 315px">
              <asp:Label ID="lblstatus" runat="server" Text="status"></asp:Label></td>
          <td style="width: 529px">
              <asp:RadioButton ID="Scheduled" runat="server" GroupName="status" />
              <asp:RadioButton ID="Cancel" runat="server" GroupName="status" /></td>
      </tr>
      <tr>
          <td colspan="2" style="vertical-align: middle; text-align: center" valign="middle">
              <asp:Button ID="btnupdategp" SkinID ="buttonskin1" runat="server" Text="UPDATE" />
              &nbsp;
               
               <asp:Button ID="txtsavegp" SkinID ="buttonskin1" runat="server" Text="SAVE" />             
              <asp:Button ID="txtgpclear" SkinID ="buttonskin1" runat="server" Text="CLEAR" CausesValidation="False" UseSubmitBehavior="False" />&nbsp;
              <asp:Button ID="BtnGpexit" SkinID ="buttonskin1" runat="server" Text="EXIT" CausesValidation="False" />
               <cc1:ConfirmButtonExtender ID ="confirmgpexit"
                            ConfirmText ="Are you sure you want to Exit from this page" 
                            ConfirmOnFormSubmit ="true" runat="server" 
                            TargetControlID ="BtnGpexit">
                           </cc1:ConfirmButtonExtender>
              
              </td>
      </tr>
      </table>
      </td>
					<td width="24" background="/images/cen_rig.gif">
					<IMG height="11" src="/images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="/images/bot_lef.gif" width="16"></td>
					<td background="/images/bot_mid.gif" height="16"><IMG height="16" src="/images/bot_mid.gif" width="16"></td>
					<td width="24" height="16"><IMG height="16" src="/images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
   
     </asp:panel>
     
     <asp:Panel ID ="gpapproval" runat="server"  Height="130%" Width="800px"> 
       <table style="border-right: #1a5c9b 1px solid; border-top: #1a5c9b 1px solid; border-left: #1a5c9b 1px solid; border-bottom: #1a5c9b 1px solid;">
      <tr>
          <td colspan="2" class="td_head">
              GatePass Approval Pending</td>           
      </tr>
      <tr>
      <td>
            <asp:GridView ID="Gridgpapp"  runat="server" DataSourceID="ApprovalGp" AutoGenerateColumns="False" 
            AllowPaging="True" AllowSorting="True" CellPadding="4" ShowFooter="True" EmptyDataText = "No Gatepass waiting for Approvals" ForeColor="#333333" GridLines="None">
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                   <PagerStyle BackColor="#284775"  HorizontalAlign="Center" ForeColor="White" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <Columns>
                  <asp:BoundField DataField="passno" HeaderText="passno" SortExpression="passno"  />   
                  <asp:TemplateField HeaderText="EmpID" SortExpression="empcode">
                       <ItemTemplate>
                          <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("empcode") %>' OnClick = "LinkButton2_Click"></asp:LinkButton>                                                                                             
                       
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />    
                         
                  <asp:BoundField DataField="gatepasstype" HeaderText="PassType" SortExpression="gatepasstype" />             
                  <asp:BoundField DataField="outdate" HeaderText="OutDate" SortExpression="outdate" DataFormatString="{0:d}" />
                  <asp:BoundField DataField="outtime" HeaderText="Time Out" SortExpression="outtime" DataFormatString="{0:t}" />
                  <asp:BoundField DataField="intime" HeaderText="Time In" SortExpression="intime" DataFormatString="{0:t}" />                
                   <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />             
                
                  <asp:TemplateField HeaderText="Status" SortExpression="status">
                   
                      <ItemTemplate>
                           <asp:RadioButtonList ID="rbgpstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                              <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                              <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                              <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                          </asp:RadioButtonList>
                      </ItemTemplate>
                         <FooterTemplate>
                          <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" onclick="UpdateGpApproval" />
                         </FooterTemplate>               
                     
                  </asp:TemplateField>
                
                  
             
              </Columns>
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          </asp:GridView>
              <cc1:ModalPopupExtender runat="server" ID = "rathimpe"  
             TargetControlID= "btnShowModalPopup"
                          PopupControlID = "pnlgphistory" 
                          PopupDragHandleControlID ="pnlgphistory" 
                         backgroundcssclass="modalBackground" 
                         OkControlID ="okbutton"   
                         DropShadow="false" EnableViewState="False"   ></cc1:ModalPopupExtender>
                         
                         
          <asp:SqlDataSource ID="ApprovalGp" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %> "
              SelectCommand="SELECT staffgatepass.empcode,staffgatepass.passno,staffgatepass.purpose, staffgatepass.date1, staffgatepass.purpose, staffgatepass.outdate, staffgatepass.outtime, staffgatepass.intime, staffgatepass.gatepasstype, staffgatepass.status,staffgatepass.remarks, empmaster.empname,  empmaster.sectioncode, empmaster.departmentcode FROM staffgatepass CROSS JOIN empmaster WHERE ((staffgatepass.status = 'scheduled')  OR (staffgatepass.status = 'SCHEDULED')) AND (staffgatepass.outdate > GETDATE()) and staffgatepass.empcode = empmaster.empcode order by passno desc">
          </asp:SqlDataSource>
          <asp:Button SkinID ="buttonskin1" runat="server" ID="btnShowModalPopup" style="display:none"/>
          </td>
          </tr>
        <tr>
          <td colspan="2" class="td_head">
              Customer Pass Approval Pending</td>           
      </tr>
       <tr>
      <td>
          <asp:SqlDataSource ID="sqlCvapproval" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
              SelectCommand="SELECT recno ,[visitortype], [companyname], [personincharge], [noofperson], [arrivaldate], [arrivaltime], [purpose], (LTrim(RTrim(status))) as status, [visitdepartment], [companypersonincharge] FROM [acc_customerapplication] WHERE status = 'S' AND (department = @dept)  AND (datepart(mm, arrivaldate) >= datepart(mm,  getdate())) AND (datepart(yy, arrivaldate) >= datepart(yy,  getdate()))">
               <SelectParameters>                 
                    <asp:Parameter Name ="dept"   />                             
                 
                 </SelectParameters>
          </asp:SqlDataSource>
            <asp:GridView ID="GrdCVApproval"  runat="server" DataSourceID="sqlCvapproval" AutoGenerateColumns="False" 
            AllowPaging="True" AllowSorting="True" CellPadding="4" ShowFooter="True" EmptyDataText = "No CustomerPass waiting for Approvals" ForeColor="#333333" GridLines="None">
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                   <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                   <PagerStyle BackColor="#284775"  HorizontalAlign="Center" ForeColor="White" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <Columns>
                     <asp:BoundField DataField="recno" HeaderText="Recno" InsertVisible="False" ReadOnly="True"
                         SortExpression="recno" />
                     <asp:BoundField DataField="visitortype" HeaderText="VisitorType" SortExpression="visitortype" />
                     <asp:BoundField DataField="companyname" HeaderText="CompanyName" SortExpression="companyname" />
                     <asp:BoundField DataField="noofperson" HeaderText="No.of Visitor" SortExpression="noofperson" />
                     <asp:BoundField DataField="arrivaldate" HeaderText="ArrivalDate" SortExpression="arrivaldate" DataFormatString="{0:dd/MM/yy}" />
                     <asp:BoundField DataField="arrivaltime" HeaderText="ArrivalTime" SortExpression="arrivaltime" DataFormatString="{0:t}" />
                     <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                     <asp:BoundField DataField="visitdepartment" HeaderText="DepartmentToVisit" SortExpression="visitdepartment" />
                     <asp:BoundField DataField="companypersonincharge" HeaderText="Comppersonincharge"
                         SortExpression="companypersonincharge" />
                     <asp:TemplateField HeaderText="status" SortExpression="status">
                       
                         <ItemTemplate>
                             &nbsp;
                              <asp:RadioButtonList ID="rbcvstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                              <asp:ListItem Value="S">Scheduled</asp:ListItem>
                              <asp:ListItem Value="A">Approve</asp:ListItem>
                              <asp:ListItem Value="R">Rejecte</asp:ListItem>
                              </asp:RadioButtonList>
                         </ItemTemplate>
                          <FooterTemplate>
                          <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" onclick="UpdateCVApproval" />
                 
                      </FooterTemplate>
                     </asp:TemplateField>
                 </Columns>
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             </asp:GridView>
          </td></tr>
      </table>

     </asp:Panel>     
         <asp:Panel ID = "pnlCsPass" runat="server"  Height="100%" Width="800px" >
          <table cellpadding=0 cellspacing=0>
           	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><IMG height="16" src="/images/top_mid.gif" width="16"></td>
					<td width="24"><IMG height="16" src="/images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><IMG height="11" src="/images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
      <table width="100%">
      <tr>
          <td colspan="5" class="td_head" style="height: 21px">
              Enter Supplier/Customer Pass </td>        
      </tr>
              <tr>
                  <td class="td_head" colspan="5" align="left" style="height: 149px">
                      <asp:SqlDataSource ID="Sqldept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                          SelectCommand="SELECT distinct [departmentcode] +' -' + [departmentname]  as deptcode ,departmentcode  FROM [department]">
                      </asp:SqlDataSource>
                      <asp:HiddenField ID="hidrno" runat="server" Visible="False" />
                      <asp:ValidationSummary ID="ValidationSummary1"
HeaderText="You must enter a value in the following fields:"
DisplayMode="BulletList"
EnableClientScript="true"
runat="server"/>
                  </td>
              </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label6" runat="server" Text="Visitor Type"></asp:Label></td>
                  <td style="height: 26px; width: 299px;">
                      <asp:DropDownList ID="csddlvtype" runat="server">
                          <asp:ListItem Value="Customer">customer</asp:ListItem>
                          <asp:ListItem Value="Supplier">supplier</asp:ListItem>
                          <asp:ListItem Value="Visitor">visitor</asp:ListItem>
                          <asp:ListItem Value="select">-Select -</asp:ListItem>
                      </asp:DropDownList></td>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label7" runat="server" Text="Visitor Department(s)"></asp:Label></td>
                  <td style="height: 26px; width: 210px;">
                      &nbsp;<asp:ListBox ID="cslstvdept" runat="server" DataSourceID="Sqldept" 
                             DataTextField="deptcode" DataValueField="departmentcode" SelectionMode="Multiple">
                       
                          <asp:ListItem Selected="True">select</asp:ListItem>
                      </asp:ListBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cslstvdept"
                          ErrorMessage="Select Visitor Dept" InitialValue=''>*</asp:RequiredFieldValidator></td>
              </tr>
      <tr>
      <td style="height: 26px; background-color: lightgoldenrodyellow;">
          <asp:Label ID="Label4" runat="server" Text="Person Incharge"></asp:Label></td>
          <td style="height: 26px; width: 299px;">
              <asp:TextBox ID="cstxtpic" runat="server"></asp:TextBox></td>
          <td style="height: 26px; background-color: lightgoldenrodyellow;">
              &nbsp;</td>
         
          <td style="height: 26px; width: 210px;">
              &nbsp;</td>
         </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label8" runat="server" Text="company Name"></asp:Label></td>
                  <td style="height: 26px; width: 299px;">
                      <asp:TextBox ID="cstxtcompname" runat="server"></asp:TextBox></td>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label9" runat="server" Text="Visitor Name"></asp:Label></td>
                  <td style="height: 26px; width: 210px;">
                      <asp:TextBox ID="cstxtvname" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label10" runat="server" Text="No. of Person (s)"></asp:Label></td>
                  <td style="height: 26px; width: 299px;">
                      <asp:TextBox ID="cstxtnop" runat="server"></asp:TextBox>
                      &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cstxtnop"
                          ErrorMessage="Enter No.Of Person">*</asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                   ControlToValidate="cstxtnop"   ErrorMessage="Enter only Numbers" 
                   ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                  
                    <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label11" runat="server" Text="contact No."></asp:Label></td>
                  <td style="height: 26px; width: 210px;">
                      <asp:TextBox ID="cstxtcontact" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label19" runat="server" Text="Arrival Date"></asp:Label></td>
                  <td style="height: 26px; width: 299px;">
                      <asp:TextBox ID="cstxtarrival" runat="server"></asp:TextBox>
                     <asp:Image ID="Imgcal2" runat="server" ImageUrl="/images/Calender.png" />&nbsp;<asp:RequiredFieldValidator
                         ID="RequiredFieldValidator8" runat="server" ControlToValidate="cstxtarrival"
                         ErrorMessage="Enter arrival Date">*</asp:RequiredFieldValidator>
          <cc1:CalendarExtender ID="cce2"  runat="server"
    TargetControlID="cstxtarrival" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="cstxtarrival"          />
     <cc1:CalendarExtender ID="CalendarExtender1"  runat="server"
    TargetControlID="cstxtarrival" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="Imgcal2"          />
                      </td>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label20" runat="server" Text="Arrival Time"></asp:Label></td>
                  <td style="height: 26px; width: 210px;">
                      <asp:DropDownList ID="csddlhr" runat="server">
                          <asp:ListItem>1</asp:ListItem>
                          <asp:ListItem>2</asp:ListItem>
                          <asp:ListItem>3</asp:ListItem>
                          <asp:ListItem>4</asp:ListItem>
                          <asp:ListItem>5</asp:ListItem>
                          <asp:ListItem>6</asp:ListItem>
                          <asp:ListItem>7</asp:ListItem>
                          <asp:ListItem>8</asp:ListItem>
                          <asp:ListItem>9</asp:ListItem>
                          <asp:ListItem>10</asp:ListItem>
                          <asp:ListItem>11</asp:ListItem>
                          <asp:ListItem>12</asp:ListItem>
                      </asp:DropDownList>:<asp:DropDownList ID="csddlmin" runat="server">
                          <asp:ListItem Value="00"></asp:ListItem>
                          <asp:ListItem>15</asp:ListItem>
                          <asp:ListItem>30</asp:ListItem>
                          <asp:ListItem>45</asp:ListItem>
                      </asp:DropDownList>&nbsp;<asp:DropDownList ID="csddlam" runat="server">
                              <asp:ListItem Value="AM">am</asp:ListItem>
                              <asp:ListItem Value="PM">pm</asp:ListItem>
                          </asp:DropDownList></td>
              </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label12" runat="server" Text="Purpose"></asp:Label></td>
                  <td style="height: 26px; width: 299px;">
                      <asp:TextBox ID="cstxtpurpose" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;">
                      <asp:Label ID="Label13" runat="server" Text="Reception area"></asp:Label></td>
                  <td style="height: 26px; width: 210px;">
                      <asp:TextBox ID="cstxtrecp" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;" >
                      <asp:Label ID="Label14" runat="server" Text="Taxi Booking"></asp:Label></td>
                  <td style="vertical-align: baseline; height: 13px; text-align: left; width: 299px;" >
                      <asp:RadioButtonList ID="csrdtaxi" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                          <asp:ListItem Value="Y">Yes</asp:ListItem>
                          <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                      </asp:RadioButtonList></td>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;" >
                      <asp:Label ID="Label16" runat="server" Text="Hotel Booking"></asp:Label></td>
                  <td style="vertical-align: baseline; height: 13px; text-align: left; width: 210px;" >
                      <asp:RadioButtonList ID="csrdhotel" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                          <asp:ListItem Value="Y">Yes</asp:ListItem>
                          <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                      </asp:RadioButtonList></td>
              </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow">
                      &nbsp;<asp:Label ID="lbltaxi" runat="server" Text="Taxi cost" Visible="False"></asp:Label></td>
                  <td style="width: 299px" >
                      &nbsp;<asp:DropDownList ID="csddltaxi" runat="server" Visible="False">
                          <asp:ListItem Selected="True" Value="select">-select-</asp:ListItem>
                          <asp:ListItem>Company</asp:ListItem>
                          <asp:ListItem>Customer</asp:ListItem>
                      </asp:DropDownList></td>
                  <td style="height: 26px; background-color: lightgoldenrodyellow">
                      <asp:Label ID="lblhotel" runat="server" Text="Hotel cost" Visible="False"></asp:Label></td>
                  <td style="height: 26px; width: 210px;">
                      <asp:DropDownList ID="ccddlhotel" runat="server" Visible="False">
                          <asp:ListItem>Company</asp:ListItem>
                          <asp:ListItem>Customer</asp:ListItem>
                          <asp:ListItem Selected="True" Value="select">-select-</asp:ListItem>
                      </asp:DropDownList></td>
              </tr>
              <tr>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;" >
                      &nbsp;<asp:Label ID="cslblstatus" runat="server" Text="Status" Visible="False"></asp:Label></td>
                  <td style="height: 47px; width: 299px;" >
                      &nbsp;<asp:RadioButtonList ID="csrdstatus" runat="server" RepeatDirection="Horizontal" Visible="False">
                          <asp:ListItem Value="S">Scheduled</asp:ListItem>
                          <asp:ListItem Value="CANCEL">Cancel</asp:ListItem>
                      </asp:RadioButtonList></td>
                  <td style="height: 26px; background-color: lightgoldenrodyellow;" >
                      <asp:Label ID="lblhotelname" runat="server" Text="Hotel Name" Visible="False"></asp:Label></td>
                  <td style="width: 210px; height: 47px;" >
                      <asp:TextBox ID="cstxthotel" runat="server" Visible="False"></asp:TextBox></td>
              </tr>
              <tr>
                  <td colspan="4" style="vertical-align: middle; height: 47px; text-align: center">
                      &nbsp;<asp:Button SkinID ="buttonskin1" ID="csbtnsave" runat="server" Text="SAVE" />
                      <asp:Button  SkinID ="buttonskin1" ID="csbtnupd" runat="server" Text="UPDATE" Visible="False" />
                      <asp:Button SkinID ="buttonskin1" ID="btncsclear" runat="server" Text="CLEAR" CausesValidation="False" UseSubmitBehavior="False" />
                      <asp:Button SkinID ="buttonskin1" ID="btnCsexit" runat="server" Text="EXIT" CausesValidation="False" />
                      
                        <cc1:ConfirmButtonExtender ID ="ConfirmButtonExtender1"
                            ConfirmText ="Are you sure you want to Exit from this page" 
                            ConfirmOnFormSubmit ="true" runat="server" 
                            TargetControlID ="btnCsexit">
                           </cc1:ConfirmButtonExtender>
                      
                      </td>
              </tr>
         </table>
          </td>
					<td width="24" background="/images/cen_rig.gif">
					<IMG height="11" src="/images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="/images/bot_lef.gif" width="16"></td>
					<td background="/images/bot_mid.gif" height="16"><IMG height="16" src="/images/bot_mid.gif" width="16"></td>
					<td width="24" height="16"><IMG height="16" src="/images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
         
         </asp:Panel> 
         
          
          
         <asp:Panel ID = "pnlgphistory" runat="server"  Height="100%" >
          
            
     
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
                     <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="DarkGreen"> GatePass Summary :</asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="lblclass"> &nbsp;<asp:Label ID="Label3" runat="server" ForeColor="DarkGreen"> Personal GatePass Utilised :</asp:Label>

              <asp:Label ID="lbltotpergp" runat="server" ForeColor="DarkGreen"></asp:Label>
             </td>
                     <td class="lblclass">
                         &nbsp;<asp:Label ID="Label18" runat="server" ForeColor="DarkGreen">  Official GatePass Utilised :</asp:Label>
                       
              <asp:Label ID="lbltotOffGp" runat="server" ForeColor="DarkGreen"></asp:Label>
                     </td>
                     <td class="lblclass" style="width: 91px">
                         &nbsp;<asp:Label ID="Label22" runat="server" ForeColor="DarkGreen"> Pass Pending for Approval :</asp:Label>
                       
              <asp:Label ID="lblgppending" runat="server" ForeColor="DarkGreen"></asp:Label>
                       </td>
                    
                 </tr>
     
                 <tr>
                     <td colspan="3">
            <asp:GridView ID="GrdGphistory"  runat="server" AllowSorting="True" BorderColor="#3366CC" BackColor="White" BorderStyle="None" 
            BorderWidth="2px" CellPadding="4" ShowFooter="True" EmptyDataText = "No GatePass Utilised So far" AllowPaging="True" >
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
             </tr>             </table>
             
         
             &nbsp;&nbsp;
         </asp:Panel>
            
      <asp:Panel ID = "pnlGPreports" runat = "server" Height= "100%" Width ="900px">

   
        <table>
            <tr>
                <td colspan="2" style="width: 776px; border-bottom: 2px solid" >
        <table>
            <tr>
                <td style="background-color: #cccc99; height: 26px;">
                    <asp:Label ID="Label2" runat="server" Text="Report TimeLine" Width="143px" ></asp:Label></td>
                <td style="width: 403px; height: 26px;" >
                    <asp:TextBox ID="txtfrom" runat="server" Width="87px" ></asp:TextBox> 
                    ~
                    <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfrom"
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
                <td style="height: 33px; background-color: #cccc99">
                    <asp:Label ID="Label5" runat="server" Text="Report By"></asp:Label></td>
                <td style="width: 403px; height: 33px">
                    <asp:RadioButtonList ID="rdoptions" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                        <asp:ListItem Value="Sect">BySect</asp:ListItem>
                        <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="height: 24px; background-color: #cccc99">
                    <asp:Label ID="lbldeptr" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                <td style="width: 403px; height: 24px">
                    <asp:DropDownList ID="ddldeptr" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="dept" DataValueField="departmentcode" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 24px; background-color: #cccc99">
                    <asp:Label ID="lblsectr" runat="server" Text="Select Section"></asp:Label></td>
                <td style="width: 403px; height: 24px">
                    <asp:DropDownList ID="ddlsectr" runat="server" DataSourceID="sqlsect" DataTextField="section"
                        DataValueField="sectioncode" AutoPostBack="True">
                    </asp:DropDownList>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="background-color: #cccc99; height: 24px;">
                    <asp:Label ID="lbldesigr" runat="server" Text="Select Designation"></asp:Label></td>
                <td style="width: 403px; height: 24px;">
                    <asp:DropDownList ID="ddldesigr" runat="server" DataSourceID="SqlDesig" DataTextField="desig"
                        DataValueField="desig" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #cccc99">
                    <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
                <td style="width: 403px">
                    <asp:TextBox ID="txtempidr" runat="server" Width="83px" AutoPostBack="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 26px">
                    &nbsp;<asp:Button ID="Button1" SkinID="buttonskin1" runat="server" Text="SHOW REPORT" />
            </tr>
        </table></td></tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department">
                    </asp:SqlDataSource>
               
        </table>
  </asp:Panel>    

      
     
     
     <asp:Panel ID ="pnlcvrpt" runat ="server" Height= "100%" Width ="900px"> 
                <table>
            <tr>
                <td style="background-color: #cccc99; height: 28px;">
                    <asp:Label ID="Label23" runat="server" Text="Report TimeLine"  ></asp:Label></td>
                <td style="width: 403px; height: 28px;" >
                    <asp:TextBox ID="Txtcsf" runat="server" ></asp:TextBox> 
                    ~
                    <asp:TextBox ID="txtcst" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtcsf">*
                    </asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtcst"
                       >*</asp:RequiredFieldValidator></td>
                    <cc1:CalendarExtender ID="CalendarExtender3"  runat="server"
                    TargetControlID="txtcsf" Format = "dd/MM/yy"           
                    CssClass="cal_Theme1"  
                    PopupButtonID="txtcsf" />
                    
                    <cc1:CalendarExtender ID="CalendarExtender4"  runat="server"
                    TargetControlID="txtcst" Format = "dd/MM/yy"           
                    CssClass="cal_Theme1"  
                    PopupButtonID="txtcst"/>
                <td align="right" colspan="2" style="height: 28px">
                    <asp:Button SkinID ="buttonskin1" ID="btnCvReport" runat="server" Text="SHOW REPORT"  /></td>
            </tr>
        </table>
     
     
     </asp:Panel>
    
     
</td>   
</tr>
</table>
</asp:Content>
