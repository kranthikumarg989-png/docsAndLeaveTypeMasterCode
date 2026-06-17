<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTHODView.aspx.vb" Inherits="E_Management.BTHODView" 
    title="Business Trip List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    Business Trip Records<br />
  <asp:GridView ID="GridView1" 
        runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" ShowFooter=True DataSourceID="SqlBTFMD" 
        ForeColor="#333333" GridLines="Vertical">
        <Columns>
            <asp:TemplateField HeaderText="recno" >
                <ItemTemplate>
               <asp:LinkButton ID="LinkButton2" CausesValidation =false  runat="server"  Font-Underline=true 
                        Text='<%# Eval("Recno") %>'
                        CommandArgument='<%# Eval("empcode", "{0}") %>' OnCommand="gethistory" ForeColor="#0000C0">
                        </asp:LinkButton>                                       
                        </ItemTemplate>
                        </asp:TemplateField>
           <asp:TemplateField HeaderText="Empcode" SortExpression="empcode" >
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>-<asp:Label
                        ID="Label4" runat="server" Text='<%# Eval("empname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="app_date" HeaderText="App Date" SortExpression="app_date" DataFormatString= "{0:dd-MMM-yy}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Duration - (Days)" SortExpression="fromdate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>' HtmlEncode="false"></asp:Label>~
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>' HtmlEncode="false"></asp:Label>
                    (<asp:Label ID="Label10" runat="server" Text='<%# Eval("duration") %>'></asp:Label>)
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Destination" SortExpression="destination">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("destination") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("destination") %>'></asp:Label>(<asp:Label
                        ID="Label6" runat="server" Text='<%# Eval("triptype") %>'></asp:Label>)
                </ItemTemplate>
            </asp:TemplateField>
              <asp:BoundField DataField="purpose"  HeaderText="Purpose" SortExpression="purpose"  />
              <asp:BoundField DataField="contactperson"  HeaderText="Contact Person" SortExpression="contactperson"  />              
             <asp:BoundField DataField="colleague_details"  HeaderText="Colleague Details" SortExpression="colleague_details"  />
                     
                                           
            <asp:TemplateField HeaderText="Status" SortExpression="btstatus">
               <ItemTemplate>
                    <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("btstatus") %>'></asp:Label>
                </ItemTemplate>                            
            </asp:TemplateField>
  
            
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlBTFMD" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT acc_businesstrip.colleague_details, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer, acc_businesstrip.status, acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, acc_businesstrip.btstatus, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.colleague_details ,empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode) WHERE btstatus <> 'NV'  AND (department = @dept) and  fromdate >= getdate() ORDER BY recno DESC">
        <SelectParameters>
             <asp:SessionParameter SessionField=_edept Name =dept Type=string  />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
