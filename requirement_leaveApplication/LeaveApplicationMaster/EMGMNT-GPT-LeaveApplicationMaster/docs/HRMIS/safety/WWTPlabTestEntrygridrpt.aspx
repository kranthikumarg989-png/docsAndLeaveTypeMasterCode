
<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="WWTPlabTestEntrygridrpt.aspx.vb" Inherits="E_Management.WWTPlabTestEntrygridrpt" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table width="100%">
   <tr>
   <td width="25%">
       Select Year
       <asp:DropDownList ID="year" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="year" DataValueField="year">
           <asp:ListItem Value="-1">Choose Year</asp:ListItem>
       </asp:DropDownList>
       &nbsp; &nbsp; &nbsp; &nbsp; Enter WwtpNo :
       <asp:TextBox ID="wwtpno" runat="server" Width="36px"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="wwtpno"
           ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
       &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
       <asp:Button ID="show" runat="server" BorderColor="LightSteelBlue" Text="Show" /></td></table>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="Transparent"
     BorderColor="Gray" BorderWidth="1px" CaptionAlign="Left" CellPadding="0" DataSourceID="SqlDataSource2" ForeColor="#333333">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="no" HeaderText="No" SortExpression="No" />          
            <asp:BoundField DataField="Month" HeaderText="Month" SortExpression="Month" />
            <asp:BoundField DataField="january" HeaderText="january" SortExpression="january" />
            <asp:BoundField DataField="february" HeaderText="february" SortExpression="february" />
            <asp:BoundField DataField="march" HeaderText="march" SortExpression="march" />
            <asp:BoundField DataField="april" HeaderText="april" SortExpression="april" />
            <asp:BoundField DataField="may" HeaderText="may" SortExpression="may" />
            <asp:BoundField DataField="june" HeaderText="june" SortExpression="june" />
            <asp:BoundField DataField="july" HeaderText="july" SortExpression="july" />
            <asp:BoundField DataField="august" HeaderText="august" SortExpression="august" />
            <asp:BoundField DataField="september" HeaderText="september" SortExpression="september" />
            <asp:BoundField DataField="october" HeaderText="october" SortExpression="october" />
            <asp:BoundField DataField="novomber" HeaderText="novomber" SortExpression="novomber" />
            <asp:BoundField DataField="december" HeaderText="december" SortExpression="december" />
            <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    &nbsp;
    <asp:GridView ID="GridView1" runat="server" BorderColor="Gray" BorderWidth="1px" CellPadding="0" ForeColor="#333333" DataKeyNames=no  >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         <Columns>
            <asp:TemplateField HeaderText="Details" SortExpression="No">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("No") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName= "Select"
                        Font-Underline="True" ForeColor="Blue" Text='<%# Eval("Year") %>'></asp:LinkButton>
                </ItemTemplate>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
    </asp:GridView> 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SqlconDMIS %>"
        SelectCommand="select distinct(year) from wwtplabtesttemp order by year ">
       
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SqlconDMIS %>"
        SelectCommand="Select No,Paramters as Month,january,february,march,april,may,june,july,august,september,october,novomber,december,Year from wwtplabtesttemp where (no>22 and no<29) and year=@year">
         <SelectParameters>
        <asp:ControlParameter ControlID="year" Name=year  PropertyName="selectedvalue"/>
    <%-- <asp:ControlParameter ControlID="year" Name=year PropertyName="SelectedValue" />--%>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
