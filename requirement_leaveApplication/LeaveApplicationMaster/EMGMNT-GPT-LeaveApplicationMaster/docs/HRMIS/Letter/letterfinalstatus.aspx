<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="letterfinalstatus.aspx.vb" Inherits="E_Management.letterfinalstatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Letter Approval</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        &nbsp;  
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="760px"
            Style="position: relative" Width="1176px" BorderWidth="1px"><cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                    New letter
                </HeaderTemplate>
            <ContentTemplate>
                &nbsp; &nbsp; &nbsp;
                <asp:GridView ID="GridView1" runat="server" Style="position: relative; left: 24px; top: 8px;" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" gridLines="None" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" Width="688px" Height="496px" BorderColor="Black" BorderWidth="1px" >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                                &nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Bind("status") %>'
                                    Style="left: -6px; position: relative; top: -14px" Width="136px">
                                    <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdategpApproval1" Style="position: relative" Text="Submit" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="letter pre.aspx?letternam={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select slno,lettername,createdby,createdtime,ltrim(rtrim(status)) as status from HRMIS_CMG_MASTER_LETTER where status='Scheduled'">
                    <SelectParameters>
                    <asp:Parameter Name="sts" Type="String" DefaultValue="Scheduled" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </ContentTemplate>
                </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Edit letter
                </HeaderTemplate>
                <ContentTemplate>
                    &nbsp;&nbsp;
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  Style="position: relative; left: 24px; top: 8px;" DataSourceID="SqlDataSource2" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" Width="688px" BorderColor="Black" BorderWidth="1px" Height="688px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="revision" HeaderText="revision" SortExpression="revision" />
                            <asp:BoundField DataField="modifiedby" HeaderText="modifiedby" SortExpression="modifiedby" />
                            <asp:BoundField DataField="modifiedtime" HeaderText="modifiedtime" SortExpression="modifiedtime" />
                            <asp:TemplateField HeaderText="status" SortExpression="status">
                                <FooterTemplate>
                                    <asp:Button ID="Button2" runat="server" OnClick="UpdategpApproval2" Style="position: relative" Text="Submit" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" SelectedValue='<%# Bind("status") %>'
                                        Style="position: relative" Width="144px">
                                        <asp:ListItem Value="ES">ES</asp:ListItem>
                                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="letter pre.aspx?letternam={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,revision,modifiedby,modifiedtime,ltrim(rtrim(status)) as status from HRMIS_CMG_MASTER_LETTER where status='ES'">
                   <SelectParameters>
                   <asp:Parameter Name="ests" Type="String"  DefaultValue="ES"/>
                   </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <HeaderTemplate>
                    Issue letter
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Style="position: relative; left: 24px; top: 24px;" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" BorderColor="Black" BorderWidth="1px" Height="696px" ShowFooter="True" Width="688px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="revision" HeaderText="revision" SortExpression="revision" />
                            <asp:BoundField DataField="issuedby" HeaderText="issuedby" SortExpression="issuedby" />
                            <asp:BoundField DataField="issuedtime" HeaderText="issuedtime" SortExpression="issuedtime" />
                            <asp:TemplateField HeaderText="status" SortExpression="status">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" Style="position: relative"
                                        Width="160px" SelectedValue='<%# Bind("status") %>'>
                                        <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="Button3" runat="server" OnClick="UpdategpApproval3" Style="position: relative" Text="Submit" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="letter pre.aspx?letternam={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,revision,issuedby,issuedtime,ltrim(rtrim(status)) as status from HRMIS_CMG_MASTER_LETTER where status='Approved'">
                    <SelectParameters>
                    <asp:Parameter Name="ists" Type="String" DefaultValue="Approved" />
                    </SelectParameters>
                    </asp:SqlDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
</cc1:TabContainer>
  </div>
    </form>
</body>
</html>
