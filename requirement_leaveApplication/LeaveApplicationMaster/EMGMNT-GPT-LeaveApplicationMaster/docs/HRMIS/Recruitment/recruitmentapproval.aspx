<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="recruitmentapproval.aspx.vb" Inherits="E_Management.recruitmentapproval" %>

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

    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Blue" Text="Man_Recruitment Approval"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="1" DataSourceID="SqlDataSource1" ForeColor="#333333" AllowPaging="True" ShowFooter="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="RequisitionNo" HeaderText="No" SortExpression="RequisitionNo" />
            <asp:BoundField DataField="RequestorEmpcode" HeaderText="Empcode" SortExpression="RequestorEmpcode" />
            <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
            <asp:BoundField DataField="Vacancies" HeaderText="Noofvacancy" SortExpression="Vacancies" />
            <asp:BoundField DataField="Postvacant" HeaderText="Reasonforvacant" SortExpression="Postvacant" />
            <asp:BoundField DataField="Equalification" HeaderText="Qualification" SortExpression="Equalification" />
            <asp:BoundField DataField="RequestDate" HeaderText="Dateapplied" SortExpression="RequestDate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=false />
            <asp:BoundField DataField="Requireddate" HeaderText="Requireddate" SortExpression="Requireddate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=false/>
            <asp:BoundField DataField="Jobdescription" HeaderText="Jobdescription" SortExpression="Jobdescription" />
             <asp:BoundField DataField="Responsibilites" HeaderText="Responsibilites" SortExpression="Responsibilites" />
                       <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                </EditItemTemplate>
                <ItemTemplate>
                    &nbsp;
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Bind("Status") %>'
                        Style="z-index: 100; left: 1px; position: relative; top: -18px" Width="97px">
                        <asp:ListItem Value="S">Scheduled</asp:ListItem>
                        <asp:ListItem Value="A">Approved</asp:ListItem>
                        <asp:ListItem Value="R">Rejected</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Statusreason" SortExpression="Statusreason">
                <EditItemTemplate>
                    &nbsp;
                </EditItemTemplate>
                <ItemTemplate>
                    &nbsp;<asp:TextBox ID="reason" runat="server" Style="z-index: 100; left: -4px; position: relative;
                        top: 0px" Text='<%# Bind("Statusreason") %>' TextMode="MultiLine" Height="42px"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="z-index: 100;
                        left: 0px; position: relative; top: 0px" Text="Submit" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    &nbsp;&nbsp;
                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="#C00000"
                    Width="632px"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select RequisitionNo,RequestDate,RequestorEmpcode,designation,Gender,Vacancies,Postvacant,Equalification,Jobdescription,pqualification,Experiencedetails,Otherskills,Requireddate,Responsibilites,ltrim(rtrim(Status))as Status,Statusreason from man_request where status='S' or status='Scheduled' order by Requisitionno desc">
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
