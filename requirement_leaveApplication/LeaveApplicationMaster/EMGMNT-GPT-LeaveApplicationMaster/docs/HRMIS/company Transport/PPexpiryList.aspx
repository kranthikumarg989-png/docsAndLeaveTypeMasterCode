<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PPexpiryList.aspx.vb" Inherits="E_Management.PPexpiryList" Theme="buttonems"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;
    <table>
        <tr>
            <td class="td_head" style="height: 16px">
                PASSPORT EXPIRY DETAILS</td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" ShowFooter="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:TemplateField HeaderText="Passportno" SortExpression="passportno">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("passportno") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtpp" runat="server" Text='<%# Bind("passportno") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ppexpirydate" HeaderText="ppexpirydate" SortExpression="ppexpirydate" DataFormatString="{0:dd/MM/yy}" HtmlEncode="false" />
            <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
            <asp:BoundField DataField="days" HeaderText="Days" ReadOnly="True" SortExpression="days" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                    &nbsp;
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="rbchoices" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("status") %>'>
                        <asp:ListItem Value="S">ToBeNoted</asp:ListItem>
                        <asp:ListItem Value="C">Under Process</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
                  <FooterTemplate>
                          <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" onclick="UpdatePPExpiry"  />
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
            </td>
        </tr>
    </table>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT passportdetails.empcode, passportdetails.modifiedtime, passportdetails.createdtime, passportdetails.modifiedby, empname, passportdetails.passportno, ppexpirydate, country,  datediff(dd,  getdate() , ppexpirydate)  AS days, status FROM passportdetails passportdetails, empmaster empmaster  WHERE (((empmaster.empcode = passportdetails.empcode) AND ppexpirydate BETWEEN  getdate()  AND  dateadd(month, 3,  getdate() ) ) AND (status <> 'C'))">
    </asp:SqlDataSource>

</asp:Content>
