<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MWClinicPassApprovals.aspx.vb" Inherits="E_Management.MWClinicPassApprovals" 
    title="Maruwa Group of Companies - Clinic Pass Approvals" %>
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
                              <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF8000"
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
             <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA MALAYSIA - CLINIC PASS  REQUESTS"></asp:Label></td>
                        </tr>
                     
                                             <tr>
                            <td align="left" valign="top">
              <asp:GridView ID="GridMMSB" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter=True PageSize="25" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Name" SortExpression="empname" />
            <asp:TemplateField HeaderText="Dept -Sect" SortExpression="department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("department") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sect") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString="{0:dd-MMM-yy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString="{0:t}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString="{0:t}"   HtmlEncode="False"  />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">SCHEDULED</asp:ListItem>
                                    <asp:ListItem Value="A">APPROVE</asp:ListItem>
                                </asp:RadioButtonList>
                </ItemTemplate>
                 <FooterTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="UpdateclinicApprovalMMSB" SkinID="buttonskin1"
                 Text="SUBMIT" />
                                        </FooterTemplate>
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
             <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA MELAKA - CLINIC PASS  REQUESTS"></asp:Label></td>
                        </tr>
                     
                                             <tr>
                            <td align="left" valign="top">
              <asp:GridView ID="GridMEL" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter=True PageSize="25" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Name" SortExpression="empname" />
            <asp:TemplateField HeaderText="Dept -Sect" SortExpression="department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("department") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sect") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString="{0:dd-MMM-yy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString="{0:t}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString="{0:t}"   HtmlEncode="False"  />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">SCHEDULED</asp:ListItem>
                                    <asp:ListItem Value="A">APPROVE</asp:ListItem>
                                </asp:RadioButtonList>
                </ItemTemplate>
                 <FooterTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="UpdateclinicApprovalMEL" SkinID="buttonskin1"
                 Text="SUBMIT" />
                                        </FooterTemplate>
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
        <asp:Panel ID="PNLLIG" runat="server">
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
             <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA LIGHTING - CLINIC PASS  REQUESTS"></asp:Label></td>
                        </tr>
                     
                                             <tr>
                            <td align="left" valign="top">
              <asp:GridView ID="GridLIG" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter=True PageSize="25" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Name" SortExpression="empname" />
            <asp:TemplateField HeaderText="Dept -Sect" SortExpression="department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("department") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sect") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString="{0:dd-MMM-yy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString="{0:t}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString="{0:t}"   HtmlEncode="False"  />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">SCHEDULED</asp:ListItem>
                                    <asp:ListItem Value="A">APPROVE</asp:ListItem>
                                </asp:RadioButtonList>
                </ItemTemplate>
                 <FooterTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="UpdateclinicApprovalLIG" SkinID="buttonskin1"
                 Text="SUBMIT" />
                                        </FooterTemplate>
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
        </TABLE>
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
             <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                    Text="MARUWA OUTSOURCE - CLINIC PASS  REQUESTS"></asp:Label></td>
                        </tr>
                     
                                             <tr>
                            <td align="left" valign="top">
              <asp:GridView ID="GridOS" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter=True PageSize="25" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Name" SortExpression="empname" />
            <asp:TemplateField HeaderText="Dept -Sect" SortExpression="department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("department") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sect") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString="{0:dd-MMM-yy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString="{0:t}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString="{0:t}"   HtmlEncode="False"  />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">SCHEDULED</asp:ListItem>
                                    <asp:ListItem Value="A">APPROVE</asp:ListItem>
                                </asp:RadioButtonList>
                </ItemTemplate>
                 <FooterTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="UpdateclinicApprovalOS" SkinID="buttonskin1"
                 Text="SUBMIT" />
                                        </FooterTemplate>
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
