<%@ Page Language="vb" AutoEventWireup="false" masterpagefile="~/ems.Master" CodeBehind="Customerpassout.aspx.vb" Inherits="E_Management.Customerpassout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label id="Label1" runat="server" ForeColor="#C00000" Font-Bold="True" Text="CUSTOMER PASSOUT" Font-Underline="True"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="0"
        DataSourceID="SqlDataSource1" ForeColor="#333333" ShowFooter="True" AllowPaging="True" BorderColor="Gray" BorderWidth="1px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="recno" HeaderText="recno" InsertVisible="False" ReadOnly="True"
                SortExpression="recno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="date1" HeaderText="Applied Date" SortExpression="date1" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false" />
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
            <asp:BoundField DataField="companypersonincharge" HeaderText="Companypersonincharge" SortExpression="companypersonincharge" />
            <asp:BoundField DataField="companyname" HeaderText="Companyname" SortExpression="companyname" />
            <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
            <asp:BoundField DataField="noofperson" HeaderText="No of person" SortExpression="noofperson" />
            <asp:BoundField DataField="arrivaldate" HeaderText="Arrivaldate" SortExpression="arrivaldate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="false"  />
            <asp:BoundField DataField="atimeout" HeaderText="Atimeout" SortExpression="atimeout" dataformatstring="{0:t}"  HtmlEncode="false" />
            <asp:TemplateField HeaderText="Out">
                <FooterTemplate>
                    <asp:Button ID="Button1" OnClick="UpdategpApproval" runat="server" Text="Submit" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
        SelectCommand="select acc_customerapplication.recno,acc_customerapplication.empcode,empmaster.empname,acc_customerapplication.date1,acc_customerapplication.department,acc_customerapplication.companypersonincharge,acc_customerapplication.companyname,acc_customerapplication.visitortype,acc_customerapplication.noofperson,acc_customerapplication.arrivaldate,ltrim(rtrim(acc_customerapplication.status))as status,acc_customerapplication.atimeout from empmaster inner join acc_customerapplication on empmaster.empcode=acc_customerapplication.empcode where  status='in'" >
    <SelectParameters>
    <asp:Parameter name="status" defaultvalue="in"/>
    <asp:Parameter Name="dt" />
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
    </asp:Content>

