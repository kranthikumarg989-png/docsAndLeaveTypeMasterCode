<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" Codebehind="OpeningStockEntry.aspx.vb"
    Inherits="E_Management.OpeningStockEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 168px">
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
                        <td bgcolor="#ffffff" valign="top" style="height: 100px; width: 447px;" align="center">
                            <table cellpadding="0" cellspacing="0" style="width: 400px">
                                <tr>
                                    <td style="height: 90px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center" style="border-left-color: #33ffff; border-bottom-color: #33ffff;
                                                    border-top-color: #33ffff; height: 19px; background-color: #507cd1; border-right-color: #33ffff">
                                                    <span style="color: #ffffff"><strong>Opening Stock Entry</strong></span></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 19px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px" align="center">
                                                    <table cellpadding="0" cellspacing="0" style="width: 364px; height: 1px">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label1" runat="server" Text="Select Department"></asp:Label></td>
                                                            <td>
                                                                &nbsp; : &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDepartment" runat="server" Width="185px" AutoPostBack="True">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </table>
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
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server" Font-Size="Small"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="dgvOpeningStock" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Cat.Name" DataField="Category"/>
                        <asp:BoundField HeaderText="Group" DataField="ItemGroup"/>
                        <asp:BoundField HeaderText="Item" DataField="ItemDesc"/>
                        <asp:BoundField HeaderText="Rate" DataField="Rate"/>
                        <asp:TemplateField HeaderText="Opening stock">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOpeningStock" runat="server" OnTextChanged="txtOpeningStock_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Total Amount" />
                        <asp:BoundField HeaderText="Dept Code" DataField="Department"/>
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
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="65px" /></td>
        </tr>
    </table>
</asp:Content>
