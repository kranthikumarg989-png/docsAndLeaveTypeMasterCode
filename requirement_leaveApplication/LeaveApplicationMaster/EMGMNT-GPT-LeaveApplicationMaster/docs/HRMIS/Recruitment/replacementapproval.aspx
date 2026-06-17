<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/ems.Master" CodeBehind="replacementapproval.aspx.vb" Inherits="E_Management.replacementapproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Blue" Text="Man_Replacement approval"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="1" DataSourceID="SqlDataSource1" ForeColor="#333333" AllowPaging="True" ShowFooter="True" AllowSorting="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="requisitionno" HeaderText="No" SortExpression="requisitionno" />
            <asp:BoundField DataField="requestdate" HeaderText="Requset.date" SortExpression="requestdate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False />
            <asp:BoundField DataField="requestorempcode" HeaderText="Empcode" SortExpression="requestorempcode" />
            <asp:BoundField DataField="resignedempcode" HeaderText="Resignedempcode" SortExpression="resignedempcode" />
            <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
            <asp:BoundField DataField="equalification" HeaderText="Qualification" SortExpression="equalification" />
            <asp:BoundField DataField="pqualification" HeaderText="prof.qualification" SortExpression="pqualification" />
            <asp:BoundField DataField="experiencedetails" HeaderText="Experience" SortExpression="experiencedetails" />
            <asp:BoundField DataField="otherskills" HeaderText="Otherskills" SortExpression="otherskills" />
            <asp:BoundField DataField="jobdescription" HeaderText="Jobdescription" SortExpression="jobdescription" />
            <asp:BoundField DataField="rdesignation" HeaderText="Req.designation" SortExpression="rdesignation" />
            <asp:BoundField DataField="requireddate" HeaderText="Req.date" SortExpression="requireddate"  dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Bind("status") %>' >
                    <asp:ListItem Value="H">Hired</asp:ListItem>
                        <asp:ListItem Value="O">Onhold</asp:ListItem>
                        <asp:ListItem Value="A">Pending</asp:ListItem>
                    </asp:RadioButtonList>
                   </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Newempcode" SortExpression="newempcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("newempcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="z-index: 100;
                        left: 0px; position: relative; top: 0px" Text="Submit" />
                </FooterTemplate>
                <ItemTemplate><asp:TextBox ID="newempcode" runat="server" Width="70px"></asp:TextBox>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Datehired" SortExpression="datehired" >
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("datehired") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate><asp:TextBox ID="datehired" runat="server" Width="70px" ></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="datehired">
                    </cc1:CalendarExtender>
                   </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select requisitionno,requestdate,requestorempcode,resignedempcode,gender,equalification,pqualification,&#13;&#10;experiencedetails,otherskills,jobdescription,rdesignation,requireddate,ltrim(rtrim(status))as status,newempcode,datehired from man_replace where (status='A' or status='O')">
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