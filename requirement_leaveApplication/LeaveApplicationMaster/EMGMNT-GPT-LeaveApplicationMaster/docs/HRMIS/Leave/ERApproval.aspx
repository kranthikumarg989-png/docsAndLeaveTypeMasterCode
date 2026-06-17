<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ERApproval.aspx.vb" Inherits="E_Management.ERApproval" 
    title="ER Leave Approval" %>
            <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Panel ID = "PnlERApproval" runat=server >
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 1047px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 1047px" valign="top">
                <table>
                    <tr>
                  <td class="td_head" style="height: 23px">
                            ER Leave Approvals
                        </td>
                    </tr>
                    <tr>
                          <td style="background-color: #5d7b9d">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                                    Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtsearchapp" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2"
                        runat="server" ImageAlign="AbsMiddle" Height="20px"
                        ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid2" 
                        BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsearchapp"
                                    ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="GrdERapproval" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqlERapproval" EmptyDataText="No Leave waiting for Approvals"
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
                                    <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                                    <asp:BoundField DataField="applicationdate" DataFormatString="{0:dd/MM/yy}" HeaderText="Applied On"  HtmlEncode="False" 
                                        SortExpression="applicationdate" />
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
                                            <asp:RadioButtonList ID="rblvestatus" runat="server" SelectedValue='<%# Bind("stat") %>'>
                                                <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                                <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                                <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateLeaveERApproval" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlERApproval" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECt  *,(Ltrim(rtrim(status))) as stat,* FROM Leaveform AS Leaveform INNER JOIN empmaster AS Empmaster  ON Empmaster.empcode = Leaveform.empno WHERE ((Leaveform.status = 'SCHEDULED') AND (Leaveform.empno <> @empcode) AND (Leaveform.leavetype <> 'Annual') and (Leaveform.leavetype <> 'PlanEmergencyUP') and (Leaveform.leavetype <> 'PlanEmergency') and (Leaveform.leavetype <> 'Unpaid')) or (backdate='Y' and status = 'SCHEDULED') ORDER BY Leaveform.appno DESC ">
                                
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="" Name="empcode" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <cc1:ModalPopupExtender ID="leavempe" runat="server" BackgroundCssClass="modalBackground"
                                DropShadow="false" EnableViewState="False" OkControlID="okbutton" PopupControlID="pnlhistory"
                                PopupDragHandleControlID="pnlhistory" TargetControlID="btnShowModalPopup">
                            </cc1:ModalPopupExtender>
                            <asp:Button ID="btnShowModalPopup" runat="server" SkinID="buttonskin1" Style="display: none" />
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 1047px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
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
            BorderWidth="2px" CellPadding="4" ShowFooter="True" EmptyDataText = "No Leave Utilised So far" AllowPaging="True"  pagesixe ="10">
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
