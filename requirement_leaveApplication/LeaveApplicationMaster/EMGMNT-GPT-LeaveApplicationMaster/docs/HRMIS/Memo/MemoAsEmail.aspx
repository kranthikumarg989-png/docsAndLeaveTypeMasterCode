<%@ Page Language="vb" MasterPageFile="~/ems.Master" AutoEventWireup="false" CodeBehind="MemoAsEmail.aspx.vb" Inherits="E_Management.MemoAsEmail" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="Label2" runat="server" Text="eMail - Memo"></asp:Label></td>
                <td colspan="1" style="text-align: center">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Memo ID:"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="CmbMemo" runat="server" Width="171px">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" Text="By Designation"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="CmbDesignation" runat="server" Width="171px">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Button ID="BtnSend" runat="server" Text="Send Email" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="LblMsg" runat="server" BackColor="LightGray" Font-Bold="True" Font-Size="12pt"
                        ForeColor="Blue" Font-Names="Calibri">Don't close the screen until button turn enabled...</asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
        </table>
    
    </div>


</asp:Content>