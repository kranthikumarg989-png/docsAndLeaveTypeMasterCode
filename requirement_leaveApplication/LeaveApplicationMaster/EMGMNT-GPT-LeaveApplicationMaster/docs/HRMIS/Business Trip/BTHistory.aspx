<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTHistory.aspx.vb" Inherits="E_Management.BTHistory" 
    title="BT HISTORY" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Small" Font-Underline="True" ForeColor="Maroon"
        Text="BUSINESS TRIP HISTORY"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="recno" DataSourceID="SQLBT" ForeColor="#333333"
        GridLines="Vertical" ShowFooter="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="recno" HeaderText="recno" SortExpression="recno" />
            <asp:BoundField DataField="app_date" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" HeaderText="App Date"
                SortExpression="app_date" />
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
                    <asp:Label ID="Lbldest" runat="server" Text='<%# Bind("destination") %>'></asp:Label>(<asp:Label
                        ID="Label6" runat="server" Text='<%# Eval("triptype") %>'></asp:Label>)
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
            <asp:TemplateField HeaderText="Colleague Details" SortExpression="colleague_details">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("colleague_details") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <table border="2" cellpadding="1" cellspacing="1">
                        <tr>
                            <td style="background-color: #cccc66">
                                Colleague Details:</td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("colleague_details") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color: #cccc66">
                                Share Dept:</td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("sharedepts") %>'></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Approved Amount" SortExpression="sanctioned">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("sanctioned") %>'></asp:Label><br />
                    _______________<br />
                    <asp:Label ID="Lbl7" runat="server" Font-Bold="True" Text="TOTAL ADV"></asp:Label>
                    :<asp:Label ID="Lbl6" runat="server" ForeColor="#C00000" Text='<%# Eval("totaladvance") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="btstatus" HeaderText="Status" SortExpression="btstatus">
                          </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SQLBT" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
         SelectCommand="SELECT acc_businesstrip.colleague_details, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer,  acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, Ltrim(rtrim(acc_businesstrip.btstatus)) as btstatus, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.colleague_details ,empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode) WHERE empmaster.empcode =@empcode  ORDER BY recno DESC">
        <SelectParameters>
             <asp:ControlParameter ControlID=lblempcode Name=empcode Type=String  />        
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lblempcode" runat="server" Text=" " ></asp:Label>
</asp:Content>
