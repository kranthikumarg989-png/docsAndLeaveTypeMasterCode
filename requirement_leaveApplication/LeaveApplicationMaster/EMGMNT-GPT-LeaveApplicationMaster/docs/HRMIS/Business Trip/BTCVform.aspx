<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTCVform.aspx.vb" Inherits="E_Management.BTCVform" 
    title="CV form" Theme="buttonems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#004040"
        Text="Select any Trip to key in Customer Visit Details"></asp:Label><br />
    <table>
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" DataKeyNames=recno BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
        <Columns>
         <asp:HyperLinkField HeaderText="Edit"  
            datanavigateurlformatstring="Btcvform.aspx?rno={0}" 
            datanavigateurlfields="recno"
            Target="_self"
            Text="Select" >
            
            <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
      
            <asp:BoundField DataField="recno" HeaderText="BtNo" SortExpression="Btno" />
            <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" DataFormatString= "{0:dd-MMM-yy}" HtmlEncode="false" />
            <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate"  DataFormatString= "{0:dd-MMM-yy}" HtmlEncode="false" />
            <asp:BoundField DataField="customer_details" HeaderText="Customer_Details" SortExpression="customer_details" />
            <asp:BoundField DataField="supplier_details" HeaderText="Supplier_Details" SortExpression="supplier_details" />
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
        <tr>
            <td>
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#004040"
        Text="Upload your Customer Visit Report" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="FileUploadcontrol" runat="server" Visible="False" />
                <asp:Button ID="btnupload" runat="server" Height="22px" Text="Upload" Width="75px" Visible="False" />
                <asp:Label ID="statuslabel" runat="server" ForeColor="#C00000"></asp:Label><br />
                &nbsp;
                <hr style="background-color: #cccc33" />
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#004040"
                    Text="Selected Business Trip : "></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Label" Visible="False" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource2" AllowPaging="True" ShowFooter=true  BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField HeaderText="History" Text="View"
             datanavigateurlformatstring="cvhistory.aspx?cust={0}" 
             datanavigateurlfields="custname"
            Target="_blank">
            
                <ControlStyle Font-Underline="True" ForeColor="SteelBlue" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="Rno" HeaderText="Rno" InsertVisible="False" ReadOnly="True"
                SortExpression="Rno" />
            <asp:BoundField DataField="custname" HeaderText="Customer/Supplier" SortExpression="custname" />
            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
            <asp:TemplateField HeaderText="Partipiciants" SortExpression="partipiciants">
                            <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Height="48px" Text='<%# Bind("partipiciants") %>'
                        TextMode="MultiLine"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Details" SortExpression="Details">
                            <ItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Height="45px" Text='<%# Bind("Details") %>'
                        TextMode="MultiLine"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SAVE" OnClick="updatecv"  />
                </FooterTemplate> 
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [custname], [purpose], [Details], [partipiciants], [Rno] FROM [HRMIS_BT_CUSTOMERVISITDETAILS] WHERE ([btnum] = @recno)">
        <SelectParameters>
           
           <asp:QueryStringParameter Name=recno QueryStringField= rno />
        </SelectParameters>
        
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [recno], [fromdate], [todate], [customer_details], [supplier_details] FROM [acc_businesstrip] WHERE (([cvrpt] = @cvrpt) AND (([btstatus] = @btstatus) or ([btstatus] = @btstatus2)) AND ([empcode] = @empcode)) order by recno desc">
        <SelectParameters>
            <asp:Parameter  Name="cvrpt" Type="String" DefaultValue ='N' />
            <asp:Parameter  Name="btstatus" Type="String" DefaultValue='AEA' />
            <asp:Parameter Name="btstatus2" Type="String" DefaultValue = 'A' />
            <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String"  />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
