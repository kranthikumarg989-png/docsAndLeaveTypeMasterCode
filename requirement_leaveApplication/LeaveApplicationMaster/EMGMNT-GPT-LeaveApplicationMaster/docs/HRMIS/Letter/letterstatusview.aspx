<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="letterstatusview.aspx.vb" Inherits="E_Management.letterstatusview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Letter status view</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>       
        </div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="464px"
            Style="position: relative" Width="848px">
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                        Style="position: relative; left: 8px; top: 16px;" BorderColor="#404040" BorderWidth="1px" Height="424px" Width="819px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="createdby" HeaderText="createdby" SortExpression="createdby" />
                            <asp:BoundField DataField="createdtime" HeaderText="createdtime" SortExpression="createdtime" />
                           <asp:TemplateField HeaderText="status" SortExpression="status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Lbl1" runat="server" Text='<%# Bind("status") %>' Width="104px"></asp:Label>&nbsp;
                                    <asp:LinkButton ID="lbprint" runat="server" Style="left: 16px; position: relative;
                                        top: 0px" Width="96px">Print</asp:LinkButton>
                                       <asp:LinkButton ID="lbshow" runat="server" CommandArgument='<%# Eval("lettername", "{0}") %>'
                                    ForeColor="#0000C0" OnCommand="Fncshow" Text="show"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,createdby,createdtime,status from HRMIS_CMG_MASTER_LETTER where  status ='Scheduled'">
                      </asp:SqlDataSource>
                </ContentTemplate>
                <HeaderTemplate>
                    New letter status
                </HeaderTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Edit letter
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
                        Style="position: relative; left: 16px; top: 16px;" BorderColor="#404040" BorderWidth="1px" Height="448px" Width="816px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="revision" HeaderText="revision" SortExpression="revision" />
                            <asp:BoundField DataField="modifiedby" HeaderText="modifiedby" SortExpression="modifiedby" />
                            <asp:BoundField DataField="modifiedtime" HeaderText="modifiedtime" SortExpression="modifiedtime" />
                            <asp:TemplateField HeaderText="status" SortExpression="status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Lbl1" runat="server" Text='<%# Bind("status") %>' Width="104px"></asp:Label>&nbsp;
                                    <asp:LinkButton ID="lbprint" runat="server" Style="left: 16px; position: relative;
                                        top: 0px" Width="96px">Print</asp:LinkButton>
                                       <asp:LinkButton ID="lbshow" runat="server" CommandArgument='<%# Eval("lettername", "{0}") %>'
                                    ForeColor="#0000C0" OnCommand="Fncshow" Text="show"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,revision,modifiedby,modifiedtime,status from HRMIS_CMG_MASTER_LETTER  where status='ES'">
                        </asp:SqlDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <HeaderTemplate>
                    Issue letter
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:GridView ID="GridView3" runat="server" Style="position: relative; left: 24px; top: 24px;" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" BorderColor="Black" BorderWidth="1px" Height="440px" Width="808px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="revision" HeaderText="revision" SortExpression="revision" />
                            <asp:BoundField DataField="issuedby" HeaderText="issuedby" SortExpression="issuedby" />
                            <asp:BoundField DataField="issuedtime" HeaderText="issuetime" SortExpression="issuedtime" />
                           
                            <asp:TemplateField HeaderText="status" SortExpression="status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Lbl1" runat="server" Text='<%# Bind("status") %>' Width="104px"></asp:Label>&nbsp;
                                    <asp:LinkButton ID="lbprint" runat="server" Style="left: 16px; position: relative;
                                        top: 0px" Width="96px">Print</asp:LinkButton>
                                       <asp:LinkButton ID="lbshow" runat="server" CommandArgument='<%# Eval("lettername", "{0}") %>'
                                    ForeColor="#0000C0" OnCommand="Fncshow" Text="show"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,revision,issuedby,issuedtime,status from HRMIS_CMG_MASTER_LETTER where status='Approved'">
                        </asp:SqlDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </form>
</body>
</html>
