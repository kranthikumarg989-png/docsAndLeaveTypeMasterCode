<%@ Page Language="vb" MasterPageFile="~/ems.Master" AutoEventWireup="false" CodeBehind="memomenu.aspx.vb" Inherits="E_Management.memomenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Table ID="Table1" runat="server" CaptionAlign="Top" Height="56px" Width="145px">
    </asp:Table>
    <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="Medium" ForeColor="#7C6F57" Height="20px" StaticSubMenuIndent="10px"
        Style="z-index: 102; left: 53px; position: absolute; top: 181px" Width="118px">
        <StaticSelectedStyle BackColor="#5D7B9D" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <DynamicMenuStyle BackColor="#F7F6F3" />
        <DynamicSelectedStyle BackColor="#5D7B9D" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <Items>
            <asp:MenuItem Text="Memo" Value="Memo">
                <asp:MenuItem NavigateUrl="~/HRMIS/Memo/memoentry.aspx" Target="_blank" Text="Memo entry"
                    Value="Memo entry"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Memo/memoapproval.aspx" Target="_blank" Text="Approval"
                    Value="Approval"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Memo/memorpt.aspx" Target="_blank" Text="Report"
                    Value="Report"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>

</asp:Content>
