<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CMG_letterstatus.aspx.vb" MasterPageFile ="~/ems.Master"Inherits="E_Management.CMG_letterstatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
           >
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataSourceID="SqlDataSource1" ForeColor="Black"
                         AllowPaging="True" PageSize="25" BorderColor="Black">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="Slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="Lettername" SortExpression="lettername" />
                                                       <asp:BoundField DataField="createdyby" HeaderText="Createdby" SortExpression="createdby" />
                            <asp:BoundField DataField="createdtime" HeaderText="Created@" SortExpression="createdtime" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                            <asp:HyperLinkField HeaderText="Show" Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="CMGpreview.aspx?ln={0}" >
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
                    &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,createdyby,createdtime,status  from HRMIS_CMG_MASTER_LETTER where status='Scheduled' or status='Rejected' or status='Approved' order by slno">
                    </asp:SqlDataSource>
                </ContentTemplate>
                <HeaderTemplate>
                    New Letter
                </HeaderTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" CellPadding="3" ForeColor="#333333"
                      AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Height="1px" PageSize="25" BorderColor="Black" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="Slno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="Lettername" SortExpression="lettername" />
                            <asp:BoundField DataField="createdyby" HeaderText="Createdby" SortExpression="createdby" />
                            <asp:BoundField DataField="createdtime" HeaderText="Created@" SortExpression="createdtime" />
                            <asp:BoundField DataField="revision" HeaderText="Revision" SortExpression="revision" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                            <asp:HyperLinkField DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="CMGpreview.aspx?ln={0}"
                                HeaderText="Show" Target="_blank" Text="Show" >
                                  <ControlStyle Font-Underline="True" ForeColor="Blue"  />
                                </asp:HyperLinkField>  
                        </Columns>
                    </asp:GridView>
                    &nbsp; &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,createdyby,createdtime,revision,status  from HRMIS_CMG_MASTER_LETTER where status='ES'or status='Rejected' or status='Approved' order by slno">
                    </asp:SqlDataSource>
                </ContentTemplate>
                <HeaderTemplate>
                    Editletter
                </HeaderTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
</asp:Content>

