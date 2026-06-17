<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="HODapprovalold.aspx.aspx.vb" Inherits="E_Management.HODapprovalold_aspx" 
   title="HOD APPROVAL" %>
        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Panel ID = "pnlapproval" runat=server >
    <table cellpadding="0" cellspacing="0" >
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table>
                    <tr>
                        <td class="td_head" style="height: 23px">
                            HOD Leave Approvals
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle">
                            &nbsp;
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqlHodapproval" EmptyDataText="No Leave waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno" />
                                    <asp:TemplateField HeaderText="EmpID" SortExpression="empno">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="true" ForeColor="Blue"
                                                OnClick="emphistory_click" Text='<%# Eval("empno") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="applicationdate" DataFormatString="{0:dd/MM/yy}" HeaderText="Applied On"
                                        SortExpression="applicationdate" />
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
                                            <asp:TextBox ID="txtgfrom" runat="server" Text='<%# Bind("grfromdate","{0:dd/MM/yy}") %>'
                                                Width="70px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="cce1" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                                                PopupButtonID="txtgfrom" TargetControlID="txtgfrom">
                                            </cc1:CalendarExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GrantedTill" SortExpression="grtodate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtgto" runat="server" Text='<%# Bind("grtodate","{0:dd/MM/yy}") %>'
                                                Width="70px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="cce2" runat="server" CssClass="cal_Theme1" Format="dd/MM/yy"
                                                PopupButtonID="txtgto" TargetControlID="txtgto">
                                            </cc1:CalendarExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="carryfwd" HeaderText="carryfwd" SortExpression="carryfwd" />
                                    <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
                                    <asp:TemplateField HeaderText="Status" SortExpression="stat">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="rblvstatus" runat="server" SelectedValue='<%# Bind("stat") %>'>
                                                <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                                <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                                <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateLeaveApproval" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <cc1:ModalPopupExtender ID="leavempe" runat="server" BackgroundCssClass="modalBackground"
                                DropShadow="false" EnableViewState="False" OkControlID="okbutton" PopupControlID="pnlhistory"
                                PopupDragHandleControlID="pnlhistory" TargetControlID="btnShowModalPopup">
                            </cc1:ModalPopupExtender>
                            <asp:SqlDataSource ID="sqlHodapproval" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECt  *,(Ltrim(rtrim(status))) as stat,* FROM Leaveform AS Leaveform INNER JOIN empmaster AS Empmaster  ON Empmaster.empcode = Leaveform.empno WHERE ((Leaveform.status = 'SCHEDULED')) AND (leaveform.department ='9000') AND (Leaveform.empno <> '005000')and (leaveform.backdate='N') AND ((Leaveform.leavetype = 'Annual') or (Leaveform.leavetype = 'Emergency') or (Leaveform.leavetype = 'EmergencyUP') or (Leaveform.leavetype = 'EmergencyUnpaid') or (Leaveform.leavetype = 'PlanEmergencyUP')or (Leaveform.leavetype = 'PlanEmergency') or (leaveform.leavetype = 'Unpaid')) ORDER BY Leaveform.appno DESC ">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="9000" Name="dept" />
                                    <asp:Parameter DefaultValue="005000" Name="empcode" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Button ID="btnShowModalPopup" runat="server" SkinID="buttonskin1" Style="display: none" />
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Panel>
	<asp:Panel ID = "Pnlhistory" runat=server >
             <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
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
            <asp:GridView ID="Grdlvhistory"  runat="server" AllowSorting="True"
             BorderColor="#3366CC" BackColor="White" BorderStyle="None" 
            BorderWidth="2px" CellPadding="4" ShowFooter="True" EmptyDataText = "No Leave Utilised So far" 
            AllowPaging="True" >
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
			
</asp:Content>

