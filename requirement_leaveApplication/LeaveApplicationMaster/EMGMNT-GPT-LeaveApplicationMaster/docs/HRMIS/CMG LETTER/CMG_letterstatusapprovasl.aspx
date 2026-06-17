<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CMG_letterstatusapprovasl.aspx.vb" MasterPageFile="~/ems.Master" Inherits="E_Management.CMG_letterstatusapprovasl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1"         >
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <ContentTemplate>
                    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataSourceID="SqlDataSource1" ForeColor="#333333" Style="z-index: 100;
                        left: 7px; position: relative; top: -10px" AllowPaging="True" PageSize="25" ShowFooter="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="Slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="Lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="createdyby" HeaderText="Createdyby" SortExpression="createdby" />
                            <asp:BoundField DataField="createdtime" HeaderText="Createdtime" SortExpression="createdtime" />
                            <asp:TemplateField HeaderText="Status" SortExpression="status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="1px" SelectedValue='<%# Bind("status") %>'
                                        >
                                        <asp:ListItem>Scheduled</asp:ListItem>
                                        <asp:ListItem>Approved</asp:ListItem>
                                        <asp:ListItem>Reject</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                                  <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdategpApproval1" Text="Save" />
                            </FooterTemplate>
                            </asp:TemplateField>
                             <asp:HyperLinkField DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="CMGpreview.aspx?ln={0}"
                                HeaderText="Show" Target="_blank" Text="Show" >
                                 <ControlStyle Font-Underline="True" ForeColor="Blue"  />
                                 </asp:HyperLinkField>
                                 
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,createdyby,createdtime,ltrim(rtrim(status))as status  from HRMIS_CMG_MASTER_LETTER where status='Scheduled' order by slno">
                    </asp:SqlDataSource>
                </ContentTemplate>
                <HeaderTemplate>
                    New Letter
                </HeaderTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333"
                        AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" PageSize="25" ShowFooter="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="Slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="Lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="createdyby" HeaderText="Createdby" SortExpression="createdby" />
                            <asp:BoundField DataField="createdtime" HeaderText="Createdtime" SortExpression="createdtime" />
                            <asp:BoundField DataField="revision" HeaderText="Revision" SortExpression="revision" />
                            <asp:TemplateField HeaderText="Status" SortExpression="status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Height="1px" SelectedValue='<%# Bind("status") %>'
                                        >
                                        <asp:ListItem Value="ES">Scheduled</asp:ListItem>
                                        <asp:ListItem>Approved</asp:ListItem>
                                        <asp:ListItem>Rejected</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                                  <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdategpApproval2" Style="position: relative" Text="Save" />
                            </FooterTemplate>
                            </asp:TemplateField>
                             <asp:HyperLinkField DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="CMGpreview.aspx?ln={0}"
                                HeaderText="Show" Target="_blank" Text="Show" >
                                 <ControlStyle Font-Underline="True" ForeColor="Blue"  />
                                 </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,createdyby,createdtime,revision,ltrim(rtrim(status))as status  from HRMIS_CMG_MASTER_LETTER where status='ES' order by slno">
                    </asp:SqlDataSource>
                </ContentTemplate>
                <HeaderTemplate>
                    Edit Letter
                </HeaderTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
</asp:Content>
