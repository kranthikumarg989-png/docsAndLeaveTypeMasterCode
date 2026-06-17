<%@ Page Language="vb" AutoEventWireup="false" Masterpagefile ="~/ems.master" CodeBehind="Customerpassin.aspx.vb" Inherits="E_Management.Customerpassin" Title="Customer Pass In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label id="Label1" runat="server" ForeColor="#C00000" Font-Bold="True" Text="CUSTOMER PASSIN" Font-Underline="True"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" Height="1px" AllowPaging="True" ShowFooter="True" BorderWidth="1px" BorderColor="Gray" CaptionAlign="Left">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="recno" HeaderText="Recno" InsertVisible="False" ReadOnly="True"
                SortExpression="recno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="date1" HeaderText="Applied date" SortExpression="date1" DataFormatString="{0:dd-MMM-yyy}"  HtmlEncode="false" />
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
            <asp:BoundField DataField="companypersonincharge" HeaderText="Companypersonincharge"  SortExpression="companypersonincharge" />
            <asp:BoundField DataField="companyname" HeaderText="Companyname" SortExpression="companyname" />
            <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
            <asp:BoundField DataField="noofperson" HeaderText="Noofperson" SortExpression="noofperson" />
            <asp:BoundField DataField="arrivaldate" HeaderText="Arrivaldate" SortExpression="arrivaldate" DataFormatString="{0:dd-MMM-yyy}"  HtmlEncode="false"  />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            <asp:TemplateField HeaderText="IN">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="cb1" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" OnClick="UpdategpApproval" runat="server" Text="Submit" />
                </FooterTemplate>
            </asp:TemplateField>
        <asp:BoundField DataField="atimein" HeaderText="Atimein" SortExpression="atimein" DataFormatString="{0:t}" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcon1 %>"
        SelectCommand="select acc_customerapplication.recno,acc_customerapplication.empcode,empmaster.empname,acc_customerapplication.date1,acc_customerapplication.department,acc_customerapplication.companypersonincharge,acc_customerapplication.companyname,acc_customerapplication.visitortype,acc_customerapplication.noofperson,acc_customerapplication.arrivaldate,ltrim(rtrim(acc_customerapplication.status)) as status ,acc_customerapplication.atimein from empmaster inner join acc_customerapplication on empmaster.empcode=acc_customerapplication.empcode where arrivaldate=@dt and (status='S' or status=@status)">
       <SelectParameters>
       <asp:Parameter Name="status" DefaultValue="A" type="string" />
       <asp:Parameter Name="dt"  />
       </SelectParameters>      
       </asp:SqlDataSource>
       </asp:Content>