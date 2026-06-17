<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="IncomingStockEntry.aspx.vb" Inherits="E_Management.IncomingStockEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
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
            <td background="../../images/cen_lef.gif" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" align="center">
                <table cellpadding="0" cellspacing="0" style="width: 500px">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" style="width: 497px; height: 111px">
                                <tr>
                                    <td align="center" style="border-left-color: #33ffff; border-bottom-color: #33ffff; border-top-color: #33ffff;
                                        height: 19px; background-color: #507cd1; border-right-color: #33ffff">
                                        <span style="color: #ffffff"><strong>Incoming Stock Entry</strong></span></td>
                                </tr>
                                <tr>
                                    <td style="height:19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px" align="center">
                                        <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label></td>
                                                <td style="width: 12px" align="center">
                                                    :</td>
                                                <td style="width: 212px" align="left">
                                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 212px">
                                                    <asp:Label ID="Label1" runat="server" Text="Select Department"></asp:Label></td>
                                                <td align="center" style="width: 212px">
                                                    :</td>
                                                <td align="left" style="width: 212px">
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="185px" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" PopupButtonID="txtDate" TargetControlID="txtDate">
                                        </cc1:CalendarExtender>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            
                        
                        
                        
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px;">
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
            <td style="height: 19px">
                <asp:Label ID="lblmsg" runat="server" Font-Size="Small"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
                                        <asp:GridView ID="dgvIncomingStock" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="Cat.Name" DataField="Category"/>
                                                <asp:BoundField HeaderText="Group" DataField="ItemGroup"/>
                                                <asp:BoundField HeaderText="Item" DataField="ItemDesc"/>
                                                <asp:BoundField HeaderText="Rate" DataField="Rate"/>
                                                <asp:TemplateField HeaderText="Incoming Qty">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtIncomingQty" runat="server" OnTextChanged="txtIncomingQty_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Total Amount" />
                                                <asp:BoundField HeaderText="Dept Code" DataField="Department"/>
                                                <asp:BoundField HeaderText="Date" DataField="ClosingDate"/>
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
                <asp:Button ID="btnSave" runat="server" Text="Save" /></td>
        </tr>
    </table>
</asp:Content>