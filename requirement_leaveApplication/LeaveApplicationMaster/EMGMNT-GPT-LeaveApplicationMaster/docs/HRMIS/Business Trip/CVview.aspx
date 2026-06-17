<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CVview.aspx.vb" Inherits="E_Management.CVview" 
    title="CV Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField HeaderText="History" Text="View"
             datanavigateurlformatstring="cvhistory.aspx?cust={0}" 
             datanavigateurlfields="custname"
            Target="_blank">
               <ControlStyle Font-Underline="True" ForeColor="SteelBlue" />
            </asp:HyperLinkField>
            
            <asp:BoundField DataField="custname" HeaderText="Visitor" SortExpression="custname" />
            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
            <asp:BoundField DataField="partipiciants" HeaderText="Partipiciants" SortExpression="partipiciants" />
            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    <asp:Label ID="Label1" runat="server" ForeColor="#404000" Text="Customer Visit Report Attachment"></asp:Label>
    :
    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" ForeColor="Navy"></asp:LinkButton><br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [btnum], [custname], [destination], [purpose], [partipiciants], [Details] FROM [HRMIS_BT_CUSTOMERVISITDETAILS] WHERE ([btnum] = @btnum)">
        <SelectParameters>
            <asp:QueryStringParameter Name="btnum" QueryStringField="btno" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
