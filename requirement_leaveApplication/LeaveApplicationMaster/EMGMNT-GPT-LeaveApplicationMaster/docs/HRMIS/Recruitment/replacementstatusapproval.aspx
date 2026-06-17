<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="replacementstatusapproval.aspx.vb" Inherits="E_Management.replacementstatusapproval" %>

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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#E0E0E0" BorderWidth="1px" CaptionAlign="Left" CellPadding="1" DataSourceID="SqlDataSource1" ForeColor="#333333" ShowFooter="True" AllowPaging="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="requisitionno" HeaderText="No" SortExpression="requisitionno" />
            <asp:BoundField DataField="requestorempcode" HeaderText="Empcode" SortExpression="requestorempcode" />
            <asp:BoundField DataField="resignedempcode" HeaderText="Resignedempcode" SortExpression="resignedempcode" />
            <asp:BoundField DataField="reasonleaving" HeaderText="Reasonleaving" SortExpression="reasonleaving" />
            <asp:BoundField DataField="equalification" HeaderText="Qualification" SortExpression="equalification" />
            <asp:BoundField DataField="requestdate" HeaderText="Requestdate" SortExpression="requestdate" dataformatstring="{0:dd-MM-yyy}" />
            <asp:BoundField DataField="requireddate" HeaderText="Requireddate" SortExpression="requireddate" dataformatstring="{0:dd-MM-yyy}" />
            <asp:BoundField DataField="rdesignation" HeaderText="Designation.req" SortExpression="rdesignation" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Style="z-index: 100; left: 0px;
                        position: relative; top: 0px" Width="90px">
                        <asp:ListItem Value="A">Approved</asp:ListItem>
                        <asp:ListItem Selected="True" Value="S">Scheduled</asp:ListItem>
                        <asp:ListItem Value="R">Rejected</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Statusreason" SortExpression="statusreason">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("statusreason") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="Submit" OnClick="Button1_Click" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="reason" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" TextMode="MultiLine"></asp:TextBox>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select requisitionno,requestorempcode,resignedempcode,reasonleaving,equalification,requestdate,requireddate,&#13;&#10;rdesignation,ltrim(rtrim(status))as status,statusreason&#13;&#10;from man_replace where status='S' order by requisitionno desc">
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
