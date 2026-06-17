<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" Codebehind="frmItemGroupMaster.aspx.vb"
    Inherits="E_Management.frmItemGroupMaster" %>

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
                            <table cellspacing="6">
                                <tr>
                                    <td style="height: 24px">
                                        <asp:Label ID="Label8" runat="server" ForeColor="DarkRed" Font-Bold="True" Font-Size="12pt"
                                            Text="ITEM Group Master" Font-Underline="False"></asp:Label></td>
                                    <td style="height: 24px">
                                        <asp:Label ID="Label2" runat="server" ForeColor="Teal" Font-Bold="True" Font-Size="12pt"
                                            Text="Existing Data" Font-Underline="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table>
                                            <tr>
                                                <td style="width: 100px">
                                                    Select Category
                                                </td>
                                                <td style="width: 100px">
                                        <asp:DropDownList ID="ddlCategory" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rvCate" runat="server" ErrorMessage="*" ControlToValidate="ddlCategory"
                                            ValidationGroup="val" InitialValue="0"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    Group</td>
                                                <td style="width: 100px">
                                        <asp:TextBox ID="txtGroup" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvGroup" runat="server" ErrorMessage="*" ControlToValidate="txtGroup"
                                            ValidationGroup="val"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" ValidationGroup="val" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                        </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                        <asp:GridView ID="gvAddedItem" runat="server" ForeColor="#333333" CellPadding="4"
                                            AutoGenerateColumns="False" PageSize="12">
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" CommandArgument=' <%# Container.DataItemIndex + 1 %>'
                                                            CommandName="DeleteRow" ForeColor="blue"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
                                                <asp:BoundField DataField="Group" HeaderText="Group"></asp:BoundField>
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
                                                <td align="center" colspan="2">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" Visible ="false" /></td>
                                            </tr>
                                        </table>
                                        </td>
                                    <td align="left" valign="top">
                                        <asp:GridView ID="gvItemGroup" runat="server" ForeColor="#333333" CellPadding="4"
                                            AutoGenerateColumns="False" AllowPaging="True" PageSize="12">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl No.">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                               
                                                <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
                                                <asp:BoundField DataField="ItemGroup" HeaderText="Group"></asp:BoundField>
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
