<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTFMDView.aspx.vb" Inherits="E_Management.BTFMDView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
    <table>
        <tr>
           <td style="background-color: #5d7b9d">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                                    Text="SEARCH By Empcode/Name/BT No"></asp:Label>:<asp:TextBox ID="txtsearchapp" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2"
                        runat="server" ImageAlign="AbsMiddle" Height="20px"
                        ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGridapp" 
                        BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsearchapp"
                                    ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search">
                                    </asp:RequiredFieldValidator></td>
 
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridView1" 
        runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" ShowFooter=True DataSourceID="SqlBTFMD" 
        ForeColor="#333333" GridLines="Vertical">
        <Columns>
            <asp:BoundField DataField="oldsystem" HeaderText="oldsystem" SortExpression="oldsystem" Visible=False  />
            <asp:BoundField DataField="recno" HeaderText="BT no" SortExpression="recno" />
            <asp:BoundField DataField="accountsview" HeaderText="Accountsview" SortExpression="accountsview"  />
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
            <asp:BoundField DataField="triptype" HeaderText="triptype" SortExpression="triptype" />
            <asp:BoundField DataField="advance_amount"  HeaderText="Advance Amount" SortExpression="advance_amount"  />
            <asp:TemplateField HeaderText="Approved Amount" SortExpression="sanctioned">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("sanctioned") %>'></asp:Label><br />
                    _______________<br />
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="TOTAL ADV"></asp:Label>
                    :<asp:Label ID="Label6" runat="server" ForeColor="#C00000" Text='<%# Eval("totaladvance") %>'></asp:Label>
                </ItemTemplate>             
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Edit"  
            datanavigateurlformatstring="BtFMDEnteramt.aspx?rno={0}" 
            datanavigateurlfields="recno"
            Target="_self"
            Text="Enter Amount">
            <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
                 
            <asp:TemplateField HeaderText="AmountStatus" SortExpression="accountsview">
                  <ItemTemplate>
                          <asp:RadioButtonList ID="rbstatus" runat="server"  SelectedValue='<%# Bind("aview") %>'>
                              <asp:ListItem Value="N">PENDING</asp:ListItem>
                              <asp:ListItem Value="Y">APPROVED</asp:ListItem>
                              <asp:ListItem Value="CLOSED">CLOSE</asp:ListItem>
                          </asp:RadioButtonList>
                   </ItemTemplate>                        
            </asp:TemplateField>                                    
            <asp:TemplateField HeaderText="Status" SortExpression="btstatus">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("btstatus") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("btstatus") %>'></asp:Label>
                  </ItemTemplate>
                <ControlStyle BackColor="Red" />
                <FooterTemplate>
                    <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" OnClick ="UpdateBTFMD" />
                </FooterTemplate> 
            </asp:TemplateField>
        <asp:HyperLinkField HeaderText="View"  
            datanavigateurlformatstring="~/HRMIS/Business Trip/Reports/BTPrintform.aspx?rno={0}" 
            datanavigateurlfields="recno"
            Target="_blank"
            Text="Print">
            <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
                     
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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
    <asp:SqlDataSource ID="SqlBTFMD" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT acc_businesstrip.advanceamount AS oldsystem, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer, acc_businesstrip.status, acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, acc_businesstrip.btstatus, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.sdest, acc_businesstrip.odest, empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode)  WHERE (accountsview <> 'CLOSED') and ACCOUNTSVIEW <> 'A' and (btstatus = 'SCHEDULED' or btstatus = 'AEA') and acc_businesstrip.recno > 2269 ORDER BY acc_businesstrip.recno DESC">
    </asp:SqlDataSource>
</asp:Content>
