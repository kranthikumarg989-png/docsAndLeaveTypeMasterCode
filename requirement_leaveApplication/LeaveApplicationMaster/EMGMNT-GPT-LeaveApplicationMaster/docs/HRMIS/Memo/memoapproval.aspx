<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="memoapproval.aspx.vb" Inherits="E_Management.memoapproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="serialno" DataSourceID="SqlDataSource1"
        ForeColor="#333333" Height="43px" Width="1074px" AllowPaging="True" PageSize="25" ShowFooter="True" CaptionAlign="Top" AllowSorting="True" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="serialno" HeaderText="Sl.No" ReadOnly="True" SortExpression="serialno" />
            <asp:BoundField DataField="emp_no" HeaderText="EmpCode" SortExpression="emp_no" />
            <asp:BoundField DataField="emp_name" HeaderText="EmpName" SortExpression="emp_name" />
            <asp:BoundField DataField="dept" HeaderText="Dept" SortExpression="dept" />
            <asp:BoundField DataField="subject" HeaderText="Subject" SortExpression="subject" />
            <asp:BoundField DataField="sumit_date" HeaderText="Submit_date" SortExpression="sumit_date" dataformatstring="{0:dd-MM-yyy}" HtmlEncode="False"/>
            <asp:BoundField DataField="to_dept" HeaderText="To_Dept" SortExpression="to_dept" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Selected="True" Value="P">Scheduled</asp:ListItem>
                        <asp:ListItem Value="F">Approved</asp:ListItem>
                        <asp:ListItem Value="R">Rejected</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="signature" HeaderText="Signature" SortExpression="signature" />
            <asp:HyperLinkField DataNavigateUrlFields="serialno" DataNavigateUrlFormatString="memoreportapp.aspx?slno={0}"
                HeaderText="View" Target="_blank" Text="View">
                <ControlStyle Font-Underline="True" />
            </asp:HyperLinkField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" BorderWidth="1px" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select serialno,emp_no,emp_name,dept,subject,sumit_date,to_dept,status,signature from memo where status='P' or status='p' order by serialno desc">
        <SelectParameters>
        <asp:Parameter DefaultValue="S"/>
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
 
 </asp:Content>