<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MMBTApprovals.aspx.vb" Inherits="E_Management.MMBTApprovals" 
 title="Maruwa Group of Companies - Business Trip Approvals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
        
            <td style="width: 100px">    
            <asp:Panel ID="Panel4" runat="server" GroupingText="Select company">           
                <asp:RadioButtonList ID="rbMainOption" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="377px">
                  <asp:ListItem Value="HA">MMSB</asp:ListItem>
                    <asp:ListItem Value="MA">MELAKA</asp:ListItem>
                    <asp:ListItem Value="LA">LIGHTING</asp:ListItem>
                                <asp:ListItem Selected="True" Value="A">All</asp:ListItem>
                </asp:RadioButtonList></asp:Panel>
                
             
            </td>
        </tr>
         <tr>
             <td style="background-color: white; height: 84px;">
                 <asp:Panel ID="Panel5" runat="server" GroupingText=SEARCH Width="100%">
                              <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF8000"
                                    Text="Empid/EmpName"></asp:Label>:<asp:TextBox ID="txtsearchapp" runat="server" BackColor="#FFFFC0"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton5"
                        runat="server" ImageAlign="AbsMiddle" Height="20px"
                        ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGridapp" 
                        BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsearchapp"
                                    ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search"></asp:RequiredFieldValidator>
                                        </asp:Panel>
                                    </td>

            </tr>
        <tr>
            <td style="width: 100px">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                        BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black"
                        GridLines="both" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="btnum" HeaderText="RecNo" SortExpression="btnum" />
                            <asp:BoundField DataField="custname" HeaderText="Custname" SortExpression="custname" />
                            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
                            <asp:BoundField DataField="vfromdate" HeaderText="Fromdate" SortExpression="vfromdate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="vtodate" HeaderText="Todate" SortExpression="vtodate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                            <asp:BoundField DataField="Accomadation" HeaderText="Accomadation" SortExpression="Accomadation" />
                            <asp:BoundField DataField="checkin" HeaderText="Checkin@" SortExpression="checkin" />
                            <asp:BoundField DataField="checkout" HeaderText="Checkout@" SortExpression="checkout" />
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                    <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" Text="Click Recno for Customer/Supplier Details" Width="321px"></asp:Label>&nbsp; &nbsp;&nbsp;<br />
                    <table>
                        <tr>
                            <td style="width: 697px">
                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" ShowFooter="True" DataSourceID="SqlBTFMD" ForeColor="#333333"
                                    GridLines="Vertical" DataKeyNames="recno" EmptyDataText="No Records waiting for approval">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Recno" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    Font-Underline="True" ForeColor="Blue" Text='<%# Eval("recno") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="EmpCode" />
                                        <asp:BoundField DataField="empname" HeaderText="EmpName" SortExpression="empname" />
                                        <asp:BoundField DataField="app_date" HeaderText="App Date" SortExpression="app_date"
                                            DataFormatString="{0:dd-MMM-yy}" HtmlEncode="False" />
                                        <asp:TemplateField HeaderText="Duration - (Days)" SortExpression="fromdate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'
                                                    HtmlEncode="false"></asp:Label>~
                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'
                                                    HtmlEncode="false"></asp:Label>
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
                                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("btstatus") %>'>
                                                    <asp:ListItem Value="SCHEDULED">SCHEDULED</asp:ListItem>
                                                    <asp:ListItem Value="AEA">APPROVE</asp:ListItem>
                                                    <asp:ListItem Value="REA">REJECT</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="Button1" SkinID="buttonskin1" runat="server" Text="SUBMIT" OnClick="UpdateBTEA" />
                                            </FooterTemplate>
                                            <ControlStyle Width="80px" />
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
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
                        SelectCommand="SELECT [btnum], [custname], [destination], [vfromdate], [vtodate], [purpose], 
        [Accomadation], [checkin], [checkout] 
        FROM [HRMIS_BT_CUSTOMERVISITDETAILS] WHERE ([btnum] = @recno)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="gridview1" Name="recno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlBTFMD" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
                        SelectCommand="SELECT acc_businesstrip.colleague_details, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer,  acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, Ltrim(rtrim(acc_businesstrip.btstatus)) as btstatus, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.colleague_details ,empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode) WHERE (btstatus = 'SCHEDULED' OR btstatus = 's')  ORDER BY recno DESC">
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Panel ID="PanelMelaka" runat="server">
                    <asp:GridView ID="dgvMalakaDetails" runat="server" BackColor="LightGoldenrodYellow"
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource6"
                        ForeColor="Black" GridLines="both" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="btnum" HeaderText="RecNo" SortExpression="btnum" />
                            <asp:BoundField DataField="custname" HeaderText="Custname" SortExpression="custname" />
                            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
                            <asp:BoundField DataField="vfromdate" HeaderText="Fromdate" SortExpression="vfromdate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="vtodate" HeaderText="Todate" SortExpression="vtodate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                            <asp:BoundField DataField="Accomadation" HeaderText="Accomadation" SortExpression="Accomadation" />
                            <asp:BoundField DataField="checkin" HeaderText="Checkin@" SortExpression="checkin" />
                            <asp:BoundField DataField="checkout" HeaderText="Checkout@" SortExpression="checkout" />
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                    <asp:Label ID="Label13" runat="server" Font-Size="Medium" Text="Click Recno for Customer/Supplier Details" Width="396px"></asp:Label>&nbsp;
                    &nbsp; &nbsp;&nbsp;<br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvMalakaMainGrid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" ShowFooter="True" DataSourceID="SqlDataSource7" ForeColor="#333333"
                                    GridLines="Vertical" DataKeyNames="recno" EmptyDataText="No Records waiting for approval">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Recno" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    Font-Underline="True" ForeColor="Blue" Text='<%# Eval("recno") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="EmpCode" />
                                        <asp:BoundField DataField="empname" HeaderText="EmpName" SortExpression="empname" />
                                        <asp:BoundField DataField="app_date" HeaderText="App Date" SortExpression="app_date"
                                            DataFormatString="{0:dd-MMM-yy}" HtmlEncode="False" />
                                        <asp:TemplateField HeaderText="Duration - (Days)" SortExpression="fromdate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" HtmlEncode="false" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                                <asp:Label ID="Label9" runat="server" HtmlEncode="false" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("btstatus") %>'>
                                                    <asp:ListItem Value="SCHEDULED">SCHEDULED</asp:ListItem>
                                                    <asp:ListItem Value="AEA">APPROVE</asp:ListItem>
                                                    <asp:ListItem Value="REA">REJECT</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="Button6" SkinID="buttonskin1" runat="server" Text="SUBMIT" OnClick="UpdateBTMelaka" />
                                            </FooterTemplate>
                                            <ControlStyle Width="80px" />
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
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
                        SelectCommand="SELECT [btnum], [custname], [destination], [vfromdate], [vtodate], [purpose], 
        [Accomadation], [checkin], [checkout] 
        FROM [HRMIS_BT_CUSTOMERVISITDETAILS] WHERE ([btnum] = @recno)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="dgvMalakaMainGrid" Name="recno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
                        SelectCommand="SELECT acc_businesstrip.colleague_details, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer,  acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, Ltrim(rtrim(acc_businesstrip.btstatus)) as btstatus, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.colleague_details ,empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode) WHERE (btstatus = 'SCHEDULED' OR btstatus = 's')  ORDER BY recno DESC">
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 19px">
             <asp:Panel ID="PanelLighting" runat="server">
                    <asp:GridView ID="dgvLightingDetails" runat="server" BackColor="LightGoldenrodYellow"
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource2"
                        ForeColor="Black" GridLines="both" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="btnum" HeaderText="RecNo" SortExpression="btnum" />
                            <asp:BoundField DataField="custname" HeaderText="Custname" SortExpression="custname" />
                            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
                            <asp:BoundField DataField="vfromdate" HeaderText="Fromdate" SortExpression="vfromdate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="vtodate" HeaderText="Todate" SortExpression="vtodate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                            <asp:BoundField DataField="Accomadation" HeaderText="Accomadation" SortExpression="Accomadation" />
                            <asp:BoundField DataField="checkin" HeaderText="Checkin@" SortExpression="checkin" />
                            <asp:BoundField DataField="checkout" HeaderText="Checkout@" SortExpression="checkout" />
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Click Recno for Customer/Supplier Details" Width="329px"></asp:Label>&nbsp;&nbsp;
                    &nbsp; &nbsp;&nbsp;<br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvLightingMainGrid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" ShowFooter="True" DataSourceID="SqlDataSource3" ForeColor="#333333"
                                    GridLines="Vertical" DataKeyNames="recno" EmptyDataText="No Records waiting for approval">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Recno" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    Font-Underline="True" ForeColor="Blue" Text='<%# Eval("recno") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="EmpCode" />
                                        <asp:BoundField DataField="empname" HeaderText="EmpName" SortExpression="empname" />
                                        <asp:BoundField DataField="app_date" HeaderText="App Date" SortExpression="app_date"
                                            DataFormatString="{0:dd-MMM-yy}" HtmlEncode="False" />
                                        <asp:TemplateField HeaderText="Duration - (Days)" SortExpression="fromdate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" HtmlEncode="false" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                                <asp:Label ID="Label9" runat="server" HtmlEncode="false" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("btstatus") %>'>
                                                    <asp:ListItem Value="SCHEDULED">SCHEDULED</asp:ListItem>
                                                    <asp:ListItem Value="AEA">APPROVE</asp:ListItem>
                                                    <asp:ListItem Value="REA">REJECT</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="Button2" SkinID="buttonskin1" runat="server" Text="SUBMIT" OnClick="UpdateBTLighting" />
                                            </FooterTemplate>
                                            <ControlStyle Width="80px" />
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
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis %>"
                        SelectCommand="SELECT [btnum], [custname], [destination], [vfromdate], [vtodate], [purpose], 
        [Accomadation], [checkin], [checkout] 
        FROM [HRMIS_BT_CUSTOMERVISITDETAILS] WHERE ([btnum] = @recno)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="dgvLightingMainGrid" Name="recno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis %>"
                        SelectCommand="SELECT acc_businesstrip.colleague_details, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer,  acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, Ltrim(rtrim(acc_businesstrip.btstatus)) as btstatus, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.colleague_details ,empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode) WHERE (btstatus = 'SCHEDULED' OR btstatus = 's')  ORDER BY recno DESC">
                    </asp:SqlDataSource>
                </asp:Panel>
             
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
               <asp:Panel ID="PanelOutSource" runat="server" Visible="false" >
                    <asp:GridView ID="dgvOutSourceDetails" runat="server" BackColor="LightGoldenrodYellow"
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource4"
                        ForeColor="Black" GridLines="both" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="btnum" HeaderText="RecNo" SortExpression="btnum" />
                            <asp:BoundField DataField="custname" HeaderText="Custname" SortExpression="custname" />
                            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
                            <asp:BoundField DataField="vfromdate" HeaderText="Fromdate" SortExpression="vfromdate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="vtodate" HeaderText="Todate" SortExpression="vtodate"
                                DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
                            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                            <asp:BoundField DataField="Accomadation" HeaderText="Accomadation" SortExpression="Accomadation" />
                            <asp:BoundField DataField="checkin" HeaderText="Checkin@" SortExpression="checkin" />
                            <asp:BoundField DataField="checkout" HeaderText="Checkout@" SortExpression="checkout" />
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                    <asp:Label ID="Label11" runat="server" Font-Size="Medium" Text="Click Recno for Customer/Supplier Details" Width="347px"></asp:Label><br />
              
              <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvOutSourceMainGrid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" ShowFooter="True" DataSourceID="SqlDataSource5" ForeColor="#333333"
                                    GridLines="Vertical" DataKeyNames="recno" EmptyDataText="No Records waiting for approval">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Recno" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    Font-Underline="True" ForeColor="Blue" Text='<%# Eval("recno") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="EmpCode" />
                                        <asp:BoundField DataField="empname" HeaderText="EmpName" SortExpression="empname" />
                                        <asp:BoundField DataField="app_date" HeaderText="App Date" SortExpression="app_date"
                                            DataFormatString="{0:dd-MMM-yy}" HtmlEncode="False" />
                                        <asp:TemplateField HeaderText="Duration - (Days)" SortExpression="fromdate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("fromdate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" HtmlEncode="false" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                                <asp:Label ID="Label9" runat="server" HtmlEncode="false" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("btstatus") %>'>
                                                    <asp:ListItem Value="SCHEDULED">SCHEDULED</asp:ListItem>
                                                    <asp:ListItem Value="AEA">APPROVE</asp:ListItem>
                                                    <asp:ListItem Value="REA">REJECT</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="Button3" SkinID="buttonskin1" runat="server" Text="SUBMIT" OnClick="UpdateBTOutSourceing" />
                                            </FooterTemplate>
                                            <ControlStyle Width="80px" />
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
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:OutsourceHRMIS %>"
                        SelectCommand="SELECT [btnum], [custname], [destination], [vfromdate], [vtodate], [purpose], 
        [Accomadation], [checkin], [checkout] 
        FROM [HRMIS_BT_CUSTOMERVISITDETAILS] WHERE ([btnum] = @recno)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="dgvOutSourceMainGrid" Name="recno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:OutsourceHRMIS %>"
                        SelectCommand="SELECT acc_businesstrip.colleague_details, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer,  acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, Ltrim(rtrim(acc_businesstrip.btstatus)) as btstatus, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.colleague_details ,empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode) WHERE (btstatus = 'SCHEDULED' OR btstatus = 's')  ORDER BY recno DESC">
                    </asp:SqlDataSource>
                </asp:Panel>
              
            </td>
        </tr>
    </table>
    <br />
    &nbsp; &nbsp;
    <br />
</asp:Content>

