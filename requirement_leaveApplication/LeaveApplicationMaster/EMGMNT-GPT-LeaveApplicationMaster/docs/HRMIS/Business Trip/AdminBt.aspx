<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="AdminBt.aspx.vb" Inherits="E_Management.AdminBt" 
    title="Admin BT Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="BUSINESS TRIP ADMIN FORM"></asp:Label>.<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
        ForeColor="Black" GridLines="both">
        <Columns>
            <asp:BoundField DataField="btnum" HeaderText="RecNo" SortExpression="btnum" />
            <asp:BoundField DataField="custname" HeaderText="Custname" SortExpression="custname" />
            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
            <asp:BoundField DataField="vfromdate" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" HeaderText="Fromdate"
                 SortExpression="vfromdate" />
            <asp:BoundField DataField="vtodate" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" HeaderText="Todate"
                 SortExpression="vtodate" />
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
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="recno" DataSourceID="SqlBTFMD" ForeColor="#333333"
        GridLines="Vertical" ShowFooter="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Recno" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                        Font-Underline="True" ForeColor="Blue" Text='<%# Eval("recno") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl1" runat="server" Text='<%# Eval("empcode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="empname" HeaderText="EmpName" SortExpression="empname" />
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
            <asp:BoundField DataField="Trip_details" HeaderText="Trip_details" SortExpression="Trip_details" >
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Transport" SortExpression="transport">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("transport") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <table border=1 style="border-right: maroon 1px solid; border-top: maroon 1px solid; border-left: maroon 1px solid; border-bottom: maroon 1px solid">
                        <tr>
                            <td style="width: 100px; background-color: #cccc66">
                                Transport
                            </td>
                            <td style="width: 100px">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("transport") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 21px; background-color: #cccc66">
                                Hostel Pick UP
                            </td>
                            <td style="width: 100px; height: 21px">
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("hostel") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; background-color: #cccc66">
                                Others</td>
                            <td style="width: 100px">
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("others") %>'></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
             
            <asp:TemplateField HeaderText="companycar" SortExpression="companycar">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("companycar") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="tvehicleno" DataValueField="tvehicleno">
                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT DISTINCT [tvehicleno] FROM [trans_ownvehicle]"></asp:SqlDataSource>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="btstatus">
                          <ItemTemplate>
                    <asp:RadioButtonList ID="RBSTATUS" runat="server" SelectedValue='<%# Bind("status") %>'>
                        <asp:ListItem>PENDING</asp:ListItem>
                        <asp:ListItem>CLOSED</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
                       <FooterTemplate>
                    <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" OnClick ="UpdateBTaDMIN" />
                </FooterTemplate> 
            </asp:TemplateField>
             <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" Visible=False  />
             
      <asp:HyperLinkField HeaderText="EnterFare"  
            datanavigateurlformatstring="AdminBtFareentry.aspx?rno={0}&dept={1}" 
            datanavigateurlfields="recno,department"
            Target="_self"
            Text="Enter Amount">
            <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT HRMIS_BT_CUSTOMERVISITDETAILS.destination, HRMIS_BT_CUSTOMERVISITDETAILS.vfromdate, HRMIS_BT_CUSTOMERVISITDETAILS.vtodate, HRMIS_BT_CUSTOMERVISITDETAILS.purpose, acc_businesstrip.recno, HRMIS_BT_CUSTOMERVISITDETAILS.Accomadation, HRMIS_BT_CUSTOMERVISITDETAILS.stayfrom, HRMIS_BT_CUSTOMERVISITDETAILS.checkin, HRMIS_BT_CUSTOMERVISITDETAILS.staytill, HRMIS_BT_CUSTOMERVISITDETAILS.checkout, HRMIS_BT_CUSTOMERVISITDETAILS.custname, HRMIS_BT_CUSTOMERVISITDETAILS.btnum FROM HRMIS_BT_CUSTOMERVISITDETAILS HRMIS_BT_CUSTOMERVISITDETAILS INNER JOIN acc_businesstrip acc_businesstrip ON (acc_businesstrip.recno = HRMIS_BT_CUSTOMERVISITDETAILS.btnum) and HRMIS_BT_CUSTOMERVISITDETAILS.btnum = @recno ">
         <SelectParameters>
           <asp:ControlParameter ControlID=gridview1 Name=recno />           
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlBTFMD" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT acc_businesstrip.colleague_details, acc_businesstrip.recno AS recno, acc_businesstrip.accountsview, acc_businesstrip.empcode,empmaster.empname, acc_businesstrip.noofcolleague, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.destination, acc_businesstrip.contactperson, acc_businesstrip.customerno, acc_businesstrip.duration, acc_businesstrip.durationtype, acc_businesstrip.purpose, acc_businesstrip.transport, acc_businesstrip.hostel, acc_businesstrip.others, acc_businesstrip.contactno, acc_businesstrip.othercustomer,  acc_businesstrip.approvedby, acc_businesstrip.department, acc_businesstrip.category, acc_businesstrip.triptype, acc_businesstrip.country, acc_businesstrip.othersupplier, acc_businesstrip.durationselect, acc_businesstrip.sharedept, acc_businesstrip.sharedepts, (lTRIM(rTRIM(acc_businesstrip.accountsview))) AS AVIEW, acc_businesstrip.accountsviewdate, acc_businesstrip.flightconfirm, acc_businesstrip.timereachdestination, acc_businesstrip.scheduletraveller, acc_businesstrip.foodtype, acc_businesstrip.accomodation, acc_businesstrip.vehicleno, acc_businesstrip.hotel, acc_businesstrip.flightrequirements, acc_businesstrip.verified, Ltrim(rtrim(acc_businesstrip.adminstatus)) as status, acc_businesstrip.btstatusdate, acc_businesstrip.app_date, acc_businesstrip.sharing_depts, acc_businesstrip.colleague_details, acc_businesstrip.advance_amount AS advance_amount, acc_businesstrip.advance_amount AS advance, acc_businesstrip.sanctioned, acc_businesstrip.supplier_details, acc_businesstrip.customer_details, acc_businesstrip.Trip_details, acc_businesstrip.totaladvance, acc_businesstrip.cvrpt, acc_businesstrip.travellingallowances, acc_businesstrip.tcform, acc_businesstrip.companycar, acc_businesstrip.cdest, acc_businesstrip.colleague_details ,empmaster.empname, empmaster.departmentcode FROM acc_businesstrip acc_businesstrip INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_businesstrip.empcode) WHERE (convert( varchar(10) , fromdate, 111) >= convert( varchar(10) ,  getdate() , 111)) and acc_businesstrip.ADMINstatus = 'PENDING' AND acc_businesstrip.BTSTATUS <> 'REA' ORDER BY recno DESC">
      
    </asp:SqlDataSource>

</asp:Content>
