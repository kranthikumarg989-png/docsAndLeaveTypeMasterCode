<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MWLeaveApprovals.aspx.vb" Inherits="E_Management.MWLeaveApprovals" 
    title="Maruwa Group of Companies -Leave Approvals" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <table>
        <tr>
            <td style="background-color: white">
                &nbsp;<asp:Panel ID="Panel4" runat="server" GroupingText="Select company">
                <asp:RadioButtonList ID="rbOption" runat="server" AutoPostBack="true" Font-Size="Small"
                    ForeColor="DimGray" RepeatDirection="Horizontal" Width="521px">
                    <asp:ListItem Value="HA">MMSB</asp:ListItem>
                    <asp:ListItem Value="MA">MELAKA</asp:ListItem>
                    <asp:ListItem Value="LA">LIGHTING</asp:ListItem>
                    <asp:ListItem Value="OA">OUTSOURCE</asp:ListItem>
                    <asp:ListItem Selected="True" Value="A">All</asp:ListItem>
                </asp:RadioButtonList></asp:Panel>
            </td>
        </tr>
            <tr>
             <td style="background-color: white; height: 84px;">
                 <asp:Panel ID="Panel5" runat="server" GroupingText=SEARCH Width="100%">
                              <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF8000"
                                    Text="Empid/EmpName"></asp:Label>:<asp:TextBox ID="Txtsearchapp" runat="server" BackColor="#FFFFC0"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2"
                        runat="server" ImageAlign="AbsMiddle" Height="20px"
                        ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGridapp" 
                        BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsearchapp"
                                    ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search"></asp:RequiredFieldValidator>
                                        </asp:Panel>
                                    </td>

            </tr>
 
            </table>
         <asp:Panel ID="PNLMMSB" runat="server">
              
 <table cellpadding="0" cellspacing="0">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
            
            
        
		 <asp:Panel ID="PGRidEAGM" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA MALAYSIA - LEAVE REQUESTS"></asp:Label></td>
                        </tr>
                     
                                             <tr>
                            <td align="left" valign="top">
                <asp:GridView ID="GRidEAGM" runat="server" AllowPaging="false"
                                AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Leave waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno" />
                         <asp:BoundField DataField="empno" HeaderText="EmpCode" SortExpression="appno" />
                        <asp:BoundField DataField="empname" HeaderText="empname" SortExpression="empname" />
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
                        <asp:BoundField DataField="leavetime" HeaderText="LeaveTime" SortExpression="leavetime" />
                        <asp:BoundField DataField="carryfwd" HeaderText="carryfwd" SortExpression="carryfwd" />
                        <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
                        <asp:TemplateField HeaderText="Status" SortExpression="stat">
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateLeaveApproval2" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rblvstatus" runat="server" SelectedValue='<%# Bind("stat") %>'>
                                    <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                    <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="statusreason">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("statusreason") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="47px" Text='<%# Bind("statusreason") %>'
                                    TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>	
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
      <asp:Panel ID="PNLMEL" runat="server">
       
 <table cellpadding="0" cellspacing="0">
        <tr>
           
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
            
            
            
		 <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA MELAKA- LEAVE REQUESTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                <asp:GridView ID="GridMEL" runat="server" AllowPaging="false"
                                AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Leave waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno" />
                         <asp:BoundField DataField="empno" HeaderText="EmpCode" SortExpression="appno" />
                        <asp:BoundField DataField="empname" HeaderText="empname" SortExpression="empname" />
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
                        <asp:BoundField DataField="leavetime" HeaderText="LeaveTime" SortExpression="leavetime" />
                        <asp:BoundField DataField="carryfwd" HeaderText="carryfwd" SortExpression="carryfwd" />
                        <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
                        <asp:TemplateField HeaderText="Status" SortExpression="stat">
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateLeaveApprovalMelaka" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rblvstatus" runat="server" SelectedValue='<%# Bind("stat") %>'>
                                    <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                    <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="statusreason">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("statusreason") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="47px" Text='<%# Bind("statusreason") %>'
                                    TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>	
 </td>
            <td background="../../images/cen_rig.gif" style="width: 24px;">
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
     <asp:Panel ID="PNLLIG" runat="server">
            
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
            
            
            
		 <asp:Panel ID="Panel2" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA LIGHTING - LEAVE REQUESTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                <asp:GridView ID="GridLig" runat="server" AllowPaging="false"
                                AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Leave waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno" />
                         <asp:BoundField DataField="empno" HeaderText="EmpCode" SortExpression="appno" />
                        <asp:BoundField DataField="empname" HeaderText="empname" SortExpression="empname" />
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
                        <asp:BoundField DataField="leavetime" HeaderText="LeaveTime" SortExpression="leavetime" />
                        <asp:BoundField DataField="carryfwd" HeaderText="carryfwd" SortExpression="carryfwd" />
                        <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
                        <asp:TemplateField HeaderText="Status" SortExpression="stat">
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateLeaveApprovallig" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rblvstatus" runat="server" SelectedValue='<%# Bind("stat") %>'>
                                    <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                    <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="statusreason">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("statusreason") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="47px" Text='<%# Bind("statusreason") %>'
                                    TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>	
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
     <asp:Panel ID="PNLOS" runat="server">
       
     <table cellpadding="0" cellspacing="0">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
            
            
            
		 <asp:Panel ID="Panel3" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA OUTSOURCE - LEAVE REQUESTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                <asp:GridView ID="GridOS" runat="server" AllowPaging="false"
                                AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Leave waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="appno" HeaderText="Appno" SortExpression="appno" />
                         <asp:BoundField DataField="empno" HeaderText="EmpCode" SortExpression="appno" />
                        <asp:BoundField DataField="empname" HeaderText="empname" SortExpression="empname" />
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
                        <asp:BoundField DataField="leavetime" HeaderText="LeaveTime" SortExpression="leavetime" />
                        <asp:BoundField DataField="carryfwd" HeaderText="carryfwd" SortExpression="carryfwd" />
                        <asp:BoundField DataField="nocf" HeaderText="nocf" SortExpression="nocf" />
                        <asp:TemplateField HeaderText="Status" SortExpression="stat">
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateLeaveApprovalOS" SkinID="buttonskin1"
                                                Text="SUBMIT" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rblvstatus" runat="server" SelectedValue='<%# Bind("stat") %>'>
                                    <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                    <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="statusreason">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("statusreason") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="47px" Text='<%# Bind("statusreason") %>'
                                    TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>	
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
</asp:Content>

