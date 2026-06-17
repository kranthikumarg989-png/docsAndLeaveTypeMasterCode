<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmSendSMS.aspx.vb" Inherits="E_Management.frmSendSMS" 
    title="SMS Group Creation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;<table align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="16">
                <img height="16" src="/images/top_lef.gif" width="16" /></td>
            <td background="/images/top_mid.gif" height="16">
                <img height="16" src="/images/top_mid.gif" width="16" /></td>
            <td width="24">
                <img height="16" src="/images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="/images/cen_lef.gif" width="16">
                <img height="11" src="/images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table align="center">
                    <tr>
                        <td align="center" colspan="2" style="font-weight: bold; background: #5d7b9d; color: white">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="SMS Group Creation"></asp:Label></td>
                    </tr>
                    <tr>
                        <td id="Td1" runat="server" colspan="3" style="background-color: beige">
                            <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td id="Td4" runat="server" colspan="3" style="background-color: beige" valign="top">
                            &nbsp;<br />
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small">type Message to send (Max. message length is limited to 2000 characters)</asp:Label>&nbsp;<br />
                            <asp:TextBox ID="TxtBoxMessage" runat="server" Width="447px" Height="105px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>
                    </tr>
                   
                     <tr>
                        <td id="Td5" runat="server" colspan="3" style="background-color: beige; text-align: center;">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" Text="Select Groups to Send"></asp:Label>
                            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="groupname" HeaderText="groupname" SortExpression="groupname" />
                                   <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                                SelectCommand="select distinct(groupname) as groupname from tbl_group_sms order by groupname">
                            </asp:SqlDataSource>
                            <asp:Button ID="BtnSave" runat="server" Text="Save" /></td>
                    </tr>
                    
                </table>
            </td>
            <td background="/images/cen_rig.gif" width="24">
                <img height="11" src="/images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="/images/bot_lef.gif" width="16" /></td>
            <td background="/images/bot_mid.gif" height="16">
                <img height="16" src="/images/bot_mid.gif" width="16" /></td>
            <td height="16" width="24">
                <img height="16" src="/images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
