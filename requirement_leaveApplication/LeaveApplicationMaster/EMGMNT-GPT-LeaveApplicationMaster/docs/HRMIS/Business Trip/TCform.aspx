<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TCform.aspx.vb" Inherits="E_Management.TCform" 
    title="Travelling Claim" Theme="buttonems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function allownumbers(e)
   {
    var key = window.event ? e.keyCode : e.which;
    var keychar = String.fromCharCode(key);
    var reg = new RegExp("[0-9.]")
    if (key == 8)
    {
     keychar = String.fromCharCode(key);
    }
    if (key == 13)
    {
     key=8;
     keychar = String.fromCharCode(key);     
    }
    return reg.test(keychar);
   } 


// ]]>
</script>

    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="#404040" Text="SELECT YOUR BUSINESS TRIP TO CLAIM"></asp:Label><br />
    <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
         <asp:HyperLinkField HeaderText="BT No"  
            datanavigateurlformatstring="TCform.aspx?rno={0}" 
            datanavigateurlfields="recno"
            Target="_self"
            Text="Select" >
            
            <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="recno" HeaderText="Recno" SortExpression="recno" />
            <asp:TemplateField HeaderText="Duration" SortExpression="fromdate">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>' HtmlEncode="false" >
                    </asp:Label>~<asp:Label ID="Label2" runat="server" Text='<%# Bind("todate", "{0:dd-MMM-yy}") %>' HtmlEncode="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" ItemStyle-Width="200px" >
                <ControlStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="noofcolleague" HeaderText="No.of Colleague" SortExpression="noofcolleague" />
            <asp:BoundField DataField="colleague_details" HeaderText="Colleague_Details" SortExpression="colleague_details" />
            <asp:BoundField DataField="sharedepts" HeaderText="Share_Dept" SortExpression="sharedepts" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
   
    <asp:Panel ID="Panel1" runat="server" GroupingText="Enter Travelling claim Details"
        Visible="False" Width="914px">
         <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" ForeColor="#0000C0" Width="160px">ADD NEW CURRENCY</asp:LinkButton><asp:Label ID="Label4" runat="server" ForeColor="Black" Text="Please add the currencies before you enter your expenses" Width="413px"></asp:Label><br />
   
    <table style="border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid;
        border-bottom: #999999 1px solid" id="table1" onclick="return table1_onclick()">
        <tr>
            <td colspan="4" style="height: 21px; background-color: beige">
    <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#404040"
        Text="SELECTED BUSINESS TRIP : "></asp:Label><asp:Label ID="Label3" runat="server"
            ForeColor="#C00000" Text="Label" Visible="False"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 104px; height: 21px; background-color: beige;">
                Departure Time
            </td>
            <td style="width: 141px">
                <asp:DropDownList ID="ddlohr" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="ddlomin" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="ddloam" runat="server">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 21px; background-color: beige;">
                Arrival time</td>
            <td style="height: 21px">
                <asp:DropDownList ID="ddlihr" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="ddlimin" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="ddliam" runat="server">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="color: #000000">
            <td colspan="4" style="height: 21px; background-color: beige">
                Travelling Allownaces&nbsp;<asp:DropDownList ID="DDLALLOWANCE" runat="server" DataSourceID="SqLCURRECNY"
                    DataTextField="CurrencyCode" DataValueField="CurrencyCode" AppendDataBoundItems="True">
                    <asp:ListItem Value="-1" Selected="True">-SELECT-</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txttravel" runat="server" Width="64px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttravel"
                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                    Width="104px"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="border-top: darkslategray 1px solid; border-bottom: darkslategray 1px solid;" align="left">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 104px">
                Remarks</td>
            <td colspan="3">
                <asp:TextBox ID="txtremarks" runat="server" Height="48px" TextMode="MultiLine"
                    Width="321px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 104px">
            </td>
            <td align="right" colspan="3">
                <asp:Button ID="btnsave" runat="server" SkinID="buttonskin1" Text="SAVE" /></td>
        </tr>
    </table>
        <br />
    </asp:Panel>
    <br />
    &nbsp;<asp:Label ID="lbladvance" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="lblno" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbltotadvacne" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblfdate" runat="server" Text="Label" Visible="False"></asp:Label><br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [recno], [fromdate], [todate], [destination], [purpose], [noofcolleague],colleague_details,sharedepts FROM [acc_businesstrip] WHERE (([cvrpt] = @cvrpt) AND ([tcform] = @tcform) and empcode = @emp AND (([btstatus] = @btstatus) OR (BTSTATUS = 'A'))) and acc_businesstrip.accountsview <> 'N'">
        <SelectParameters>
            <asp:Parameter DefaultValue="Y" Name="cvrpt" Type="String" />
            <asp:Parameter DefaultValue="N" Name="tcform" Type="String" />
            <asp:Parameter DefaultValue="AEA" Name="btstatus" Type="String" />
            <asp:SessionParameter Name=emp SessionField=empcode  />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqLCURRECNY" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT DISTINCT [CurrencyCode] FROM [Pur_currencymaster] ORDER BY [CurrencyCode]">
    </asp:SqlDataSource>

</asp:Content>
