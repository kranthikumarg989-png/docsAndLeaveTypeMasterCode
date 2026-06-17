<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="securitymenu.aspx.vb" Inherits="E_Management.securitymenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Table ID="Table1" runat="server" Height="155px" Style="z-index: 100; left: 48px;
        position: absolute; top: 173px" Width="266px">
    </asp:Table>
    <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="Medium" ForeColor="#7C6F57" Height="27px" StaticSubMenuIndent="10px"
        Style="z-index: 102; left: 56px; position: absolute; top: 182px" Width="129px">
        <StaticSelectedStyle BackColor="#5D7B9D" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <DynamicMenuStyle BackColor="#F7F6F3" />
        <DynamicSelectedStyle BackColor="#5D7B9D" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <Items>
            <asp:MenuItem Text="Security" Value="Security">
                <asp:MenuItem NavigateUrl="~/HRMIS/security/businesstrip.aspx" Target="_blank" Text="Businesstrip"
                    Value="Businesstrip"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/security/Customerpassin.aspx" Target="_blank"
                    Text="Customerpassin" Value="Customerpassin"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/security/Customerpassout.aspx" Target="_blank"
                    Text="Customerpassout" Value="Customerpassout"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/security/gpout.aspx" Target="_blank" Text="Gatepassout"
                    Value="Gatepassout"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/security/gpreturn.aspx" Target="_blank" Text="Gatepassreturn"
                    Value="Gatepassreturn"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/security/Halfdayleave.aspx" Target="_blank" Text="Halfdayleave"
                    Value="Halfdayleave"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/security/clinicpassout.aspx" Target="_blank" Text="Clinic Pass Out"
                    Value="Clinic Pass Out"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/security/reportsummary.aspx" Target="_blank" Text="Reportsummary"
                    Value="Reportsummary"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>

</asp:Content>