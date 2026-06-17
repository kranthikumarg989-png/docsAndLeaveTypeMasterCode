<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" Codebehind="CategoryTypeMaster.aspx.vb"
    Inherits="E_Management.CategoryTypeMaster" %>
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
            <td bgcolor="#ffffff" valign="top" style="height: 100px" align="center">
                <table cellpadding="0" cellspacing="0" style="width: 400px">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr style="border-left-color: #33ffff; border-bottom-color: #33ffff; border-top-color: #33ffff;
                                    height: 24px; background-color: #507cd1; border-right-color: #33ffff">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                                        Text="Category Type Master"></asp:Label></tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td style="height: 19px; text-align: left;" align="left">
                                        <asp:Label ID="Label1" Text="Category Code" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="height: 19px; text-align: left" align="left">
                                        <asp:Label ID="lblCateCode" runat="server">
                                        </asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" Text="Category Description" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtCatDesc" runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 18px" colspan="3">
                                        <asp:Label ID="lblMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        </td>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" /></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3" style="height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3">
                                        <asp:GridView ID="dgvCategory" runat="server" AutoGenerateColumns="False" Width="427px">
                                            <Columns>
                                                <asp:BoundField HeaderText="Category Code" DataField="CatCode" />
                                                <asp:BoundField HeaderText="Category Description" DataField="Description" />
                                            </Columns>
                                            <RowStyle BackColor="#EFF3FB" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
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
