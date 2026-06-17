<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTSelfstatus.aspx.vb" Inherits="E_Management.BTSelfstatus"  title="My BT status" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SQLBT" CellPadding="4" AutoGenerateColumns=False  
    ForeColor="#333333" GridLines="Vertical" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="recno" HeaderText="Recno" SortExpression="recno" />
            <asp:BoundField DataField="app_date" HeaderText="App date" SortExpression="app_date" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Destination" SortExpression="destination">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("destination") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("destination") %>'></asp:Label>(<asp:Label
                        ID="Label6" runat="server" Text='<%# Eval("triptype") %>'></asp:Label>)
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Duration - Days" SortExpression="fromdate">
               <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>' HtmlEncode="false"></asp:Label>
                    ~<asp:Label ID="Label4" runat="server" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>' HtmlEncode="false"></asp:Label>
                    (<asp:Label ID="Label5" runat="server" Text='<%# Eval("duration") %>'></asp:Label>)
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="totaladvance" HeaderText="Advance amount" SortExpression="totaladvance" />
            <asp:BoundField DataField="sanctioned" HeaderText="Approved amt" SortExpression="sanctioned" />
            <asp:BoundField DataField="vehicleno" HeaderText="Company Car" SortExpression="vehicleno" />
             <asp:TemplateField HeaderText="Status" SortExpression="btstatus">
               <ItemTemplate>                      
                           <asp:Label ID = "Label1" runat="server" Text='<%# Eval("btstatus") %>' 
                            CommandArgument='<%# Eval("recno", "{0}") %>'> </asp:Label>
                           <asp:LinkButton ID="LinkButton1" CausesValidation =false  runat="server" 
                           OnCommand="GetBtData"   Text='<%# Eval("btstatus") %>' CommandArgument='<%# Eval("recno", "{0}") %>' ForeColor="#0000C0"></asp:LinkButton>                                       
                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false"
                             CommandArgument='<%# Eval("recno", "{0}") %>' ForeColor="RED" OnCommand="BTcancel" Text="CANCEL"></asp:LinkButton>
                           <cc1:confirmbuttonextender id="confirmgpcancel" runat="server" confirmonformsubmit="true"
                         confirmtext="Are you sure you want to cancel the Business Trip" targetcontrolid="LinkButton5">
                           </cc1:confirmbuttonextender>
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
    <asp:SqlDataSource ID="SQLBT" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT * FROM [acc_businesstrip] WHERE ([empcode] = @empcode)  and BTstatus <> 'CANCELLED' order by recno desc">
        <SelectParameters>
              <asp:SessionParameter SessionField=empcode Name =empcode Type =string  />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
