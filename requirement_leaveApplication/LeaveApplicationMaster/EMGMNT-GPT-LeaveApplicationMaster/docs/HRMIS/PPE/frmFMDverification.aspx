<%@ Page Language="vb" AutoEventWireup="false" Codebehind="frmFMDverification.aspx.vb"
    MasterPageFile="~/ems.Master" Inherits="E_Management.frmFMDverification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16" style="width: 447px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" width="16" style="height: 100px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 100px">
                <table cellpadding="0" cellspacing="0" style="width: 700px">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label8" runat="server" ForeColor="DarkRed" Font-Bold="True" Font-Size="12pt"
                                            Text="PPE Payroll/Finance Verification" Font-Underline="False"></asp:Label></td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvItemGroup" runat="server" ForeColor="#333333" CellPadding="4"
                                            AutoGenerateColumns="False" PageSize="12">
                                            <Columns>
                                                <asp:BoundField DataField="IssueNo" HeaderText="IssueNo"></asp:BoundField>
                                                <asp:TemplateField HeaderText="ItemDetails">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="gvItem" runat="Server" ForeColor="#333333" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
                                                                <asp:BoundField DataField="PPEGroup" HeaderText="Group"></asp:BoundField>
                                                                <asp:BoundField DataField="Item" HeaderText="Item"></asp:BoundField>
                                                                <asp:BoundField DataField="Qty" HeaderText="Qty"></asp:BoundField>
                                                                <asp:BoundField DataField="Amount" HeaderText="Amount"></asp:BoundField>
                                                                <asp:BoundField DataField="IssuedTo" HeaderText="IssuedTo"></asp:BoundField>
                                                                <asp:BoundField DataField="IssuedDept" HeaderText="Dept"></asp:BoundField>
                                                                <asp:BoundField DataField="CreatedDate" HeaderText="Issued Date" DataFormatString="{0:d}">
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TotAmount" HeaderText="Amount"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rbtnStatus" runat="server">
                                                            <asp:ListItem Value="P" Selected="true">Pending</asp:ListItem>
                                                            <asp:ListItem Value="R">Received</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnSave" runat="Server" Text="Save" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 100px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 447px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
