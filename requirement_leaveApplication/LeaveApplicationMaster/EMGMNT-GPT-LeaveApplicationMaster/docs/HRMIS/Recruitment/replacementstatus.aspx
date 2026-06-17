<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="replacementstatus.aspx.vb" Inherits="E_Management.replacementstatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 372px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 372px" valign="top">
    <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="Blue" Text="Man_Replacement Status"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" BorderColor="Gray" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="requisitionno" HeaderText="No" SortExpression="requisitionno" />
            <asp:BoundField DataField="requestorempcode" HeaderText="Empcode" SortExpression="requestorempcode" />
            <asp:BoundField DataField="resignedempcode" HeaderText="Resignedempcode" SortExpression="resignedempcode" />
            <asp:BoundField DataField="reasonleaving" HeaderText="reasonleaving" SortExpression="reasonleaving" />
            <asp:BoundField DataField="requestdate" HeaderText="Date applied" SortExpression="requestdate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
            <asp:BoundField DataField="requireddate" HeaderText="Req.date" SortExpression="requireddate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
            <asp:BoundField DataField="equalification" HeaderText="Qualification" SortExpression="equalification" />
            <asp:BoundField DataField="rdesignation" HeaderText="Designation.req" SortExpression="rdesignation" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                    <asp:LinkButton ID="lnk1" runat="server" OnCommand="sendno" CommandArgument='<%# Eval("RequisitionNo", "{0}") %>'  Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Font-Underline="True" ForeColor="#0000C0" Text='<%# Eval("status") %>'></asp:LinkButton>
                    <asp:LinkButton ID="lnk2" runat="server" OnCommand="statuscancel" CommandArgument='<%# Eval("RequisitionNo", "{0}")%>' Style="z-index: 102; left: 0px; position: relative;
                        top: 0px" Font-Underline="True" ForeColor="#0000C0">cancel</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="statusreason" HeaderText="Statusreason" SortExpression="statusreason" />
            <asp:BoundField DataField="approvedby" HeaderText="Approvedby" ReadOnly="True" SortExpression="approvedby" />
        </Columns>
    </asp:GridView>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select requisitionno,requestorempcode,resignedempcode,reasonleaving,equalification,requestdate,requireddate,rdesignation,ltrim(rtrim(status))as status,statusreason,approvedby from man_replace where requestorempcode=@emp  order by requisitionno desc">
  <SelectParameters>
    <asp:SessionParameter Name=emp SessionField="empcode" Type=string />
    </SelectParameters>
    </asp:SqlDataSource>
    </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 372px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>