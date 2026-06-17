<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="recruitmentstatus.aspx.vb" Inherits="E_Management.recruitmentstatus" %>

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
    <asp:Label ID="Label2" runat="server" Text="Man_Recruitment Status" Font-Underline="True" ForeColor="Blue"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" AllowPaging="True" BorderColor="Gray" BorderWidth="1px" AllowSorting="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="RequisitionNo" HeaderText="No" SortExpression="RequisitionNo" />
            <asp:BoundField DataField="RequestorEmpcode" HeaderText="Empcode" SortExpression="RequestorEmpcode" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
            <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
            <asp:BoundField DataField="postvacant" HeaderText="Post" SortExpression="postvacant" />
            <asp:BoundField DataField="equalification" HeaderText="Education" SortExpression="equalification" />
            <asp:BoundField DataField="jobdescription" HeaderText="Description" SortExpression="jobdescription" />
            <asp:BoundField DataField="experiencedetails" HeaderText="Experience" SortExpression="experiencedetails" />
            <asp:BoundField DataField="otherskills" HeaderText="Otherskills" SortExpression="otherskills" />
            <asp:BoundField DataField="requireddate" HeaderText="Requireddate" SortExpression="requireddate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False />
            <asp:BoundField DataField="responsibilites" HeaderText="Responsibilites" SortExpression="responsibilites" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"  Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text='<%# Eval("status") %>'></asp:Label>
                    <asp:LinkButton ID="lnkedit" runat="server" OnCommand="sendno" CommandArgument='<%# Eval("RequisitionNo", "{0}") %>' ForeColor="Blue" Style="z-index: 101;
                        left: 0px; position: relative; top: 0px" Text='<%# Eval("status") %>'></asp:LinkButton>
                    <asp:LinkButton ID="lnkcancel" runat="server" OnCommand="statuscancel" CommandArgument='<%# Eval("RequisitionNo", "{0}")%>' Style="z-index: 103; left: 0px; position: relative;
                        top: 0px">cancel</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="statusreason" HeaderText="Reason" SortExpression="statusreason" />
            <asp:BoundField DataField="approvedby" HeaderText="Approvedby" SortExpression="approvedby" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select RequisitionNo,RequestDate,RequestorEmpcode,designation,Gender,Vacancies,Postvacant,Equalification,Jobdescription,pqualification,Experiencedetails,Otherskills,Requireddate,Responsibilites,ltrim(rtrim(Status))as status,Approvedby,Statusreason from man_request where RequestorEmpcode=@emp order by Requisitionno desc">
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