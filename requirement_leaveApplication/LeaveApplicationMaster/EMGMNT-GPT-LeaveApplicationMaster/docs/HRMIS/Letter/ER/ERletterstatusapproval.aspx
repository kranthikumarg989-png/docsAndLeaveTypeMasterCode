<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ERletterstatusapproval.aspx.vb" Inherits="E_Management.ERletterstatusapproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="876px"
            Style="position: relative" Width="1200px" BorderWidth="1px"><cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                    New letter
                </HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" Style="position: relative; left: 24px; top: 8px;" CellPadding="0" DataSourceID="SqlDataSource1" ForeColor="#333333" gridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" Width="1031px" Height="1px" BorderColor="Black" BorderWidth="1px" AllowSorting="True" >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign=Middle />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="slno" HeaderText="Sno" InsertVisible="False" ReadOnly="True"
                            SortExpression="slno" />
                        <asp:BoundField DataField="lettername" HeaderText="LetterName" SortExpression="lettername" />
                        <asp:BoundField DataField="createdby" HeaderText="Created  By" SortExpression="createdby" />
                        <asp:BoundField DataField="createdtime" HeaderText="Created @" SortExpression="createdtime" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Bind("status") %>'  >
                                    <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdategpApproval1" Style="position: relative" Text="Save" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="ERletterview.aspx?letternam={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select slno,lettername,createdby,createdtime,ltrim(rtrim(status)) as status from HRMIS_ER_MASTER_LETTER where status='Scheduled' order by slno">
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
                    <asp:GridView ID="GridView2" runat="server" CellPadding="1" ForeColor="#333333"  Style="position: relative; left: 24px; top: 8px;" DataSourceID="SqlDataSource2" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" Width="1073px" BorderColor="Black" BorderWidth="1px" Height="1px" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="Sno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="LetterName" SortExpression="lettername" />
                            <asp:BoundField DataField="revision" HeaderText="RevNo" SortExpression="revision" />
                            <asp:BoundField DataField="modifiedby" HeaderText="Edit By" SortExpression="modifiedby" />
                            <asp:TemplateField HeaderText="Status" SortExpression="status">
                                <FooterTemplate>
                                    <asp:Button ID="Button2" runat="server" OnClick="UpdategpApproval2" Style="position: relative" Text="Save" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" SelectedValue='<%# Bind("status") %>'
                                        >
                                        <asp:ListItem Value="ES">Scheduled</asp:ListItem>
                                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                        <asp:ListItem>Rejected</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="ERletterview.aspx?letternam={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,revision,modifiedby,modifiedtime,ltrim(rtrim(status)) as status from HRMIS_ER_MASTER_LETTER where status='ES' order by slno">
                   <SelectParameters>
                   <asp:Parameter  DefaultValue="ES"/>
                   </SelectParameters>
                    </asp:SqlDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <HeaderTemplate>
                    Issue letter
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:GridView ID="GridView3" runat="server" CellPadding="1" ForeColor="#333333"
                        Style="position: relative; left: 24px; top: 24px;" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" BorderColor="Black" BorderWidth="1px" Height="1px" ShowFooter="True" Width="1013px" AllowSorting="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" Wrap="True" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                        <asp:BoundField DataField="sno" HeaderText="Slno" SortExpression="sno" />
                            <asp:BoundField DataField="empcode" HeaderText="Empcode" InsertVisible="False" ReadOnly="True"
                                SortExpression="empcode" />
                            <asp:BoundField DataField="lettername" HeaderText="Letter" SortExpression="lettername" />
                            <asp:BoundField DataField="createdby" HeaderText="Created By" SortExpression="createdby" />
                            <asp:TemplateField HeaderText="Status" SortExpression="status">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server"  SelectedValue='<%# Bind("status") %>' Height="1px" Width="110px">
                                        <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                        <asp:ListItem Value="A">Approved</asp:ListItem>
                                        <asp:ListItem Value="R">Rejected</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="Button3" runat="server" OnClick="UpdategpApproval3" Style="position: relative" Text="Save" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="sno" DataNavigateUrlFormatString="letterapprovalpreview.aspx?slno={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select empcode,lettername,createdby,issuedby,issuedate,ltrim(rtrim(status))as status,sno from HRMIS_ER_MASTER_LETTER_SAVE where status='S'order by sno desc">
                        </asp:SqlDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
</cc1:TabContainer>
   </asp:Content>