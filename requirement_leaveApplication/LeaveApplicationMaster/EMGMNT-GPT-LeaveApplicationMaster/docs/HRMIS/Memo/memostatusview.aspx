<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="memostatusview.aspx.vb" Inherits="E_Management.memostatusview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 1146px">
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="serialno" DataSourceID="SqlDataSource1" ForeColor="#333333"
        AllowPaging="True" Height="1px" PageSize="25" CaptionAlign="Top" AllowSorting="True" GridLines="None" Width="1141px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="Black" BorderWidth="1px" />
        <Columns>
            <asp:BoundField DataField="serialno" HeaderText="SI. No." ReadOnly="True" SortExpression="serialno" />
            <asp:BoundField DataField="emp_no" HeaderText="Empno" SortExpression="emp_no" />
            <asp:BoundField DataField="emp_name" HeaderText="Empname" SortExpression="emp_name" />
            <asp:BoundField DataField="dept" HeaderText="Dept" SortExpression="dept" />
            <asp:BoundField DataField="subject" HeaderText="Subject" SortExpression="subject" />
            <asp:BoundField DataField="sumit_date" HeaderText="Submit Date" SortExpression="sumit_date" dataformatstring="{0:dd-MM-yyy}" HtmlEncode="False"/>
            <asp:BoundField DataField="to_dept" HeaderText="To Dept" SortExpression="to_dept" />
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            <asp:BoundField DataField="signature" HeaderText="Signature" SortExpression="signature" />
            <asp:TemplateField HeaderText="Print">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="print" runat="server" oncommand="memoprint" CommandArgument='<%# Eval("serialno", "{0}") %>' Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Font-Underline="True">Print</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" BorderWidth="1px" Font-Underline="True" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>       
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select serialno,emp_no,emp_name,dept,subject,sumit_date,to_dept,ltrim(rtrim(status)) as status ,signature from memo where emp_no=@emp order by serialno desc">
    <SelectParameters>
           <asp:SessionParameter Name="emp" SessionField="empcode" />
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

</asp:Content>