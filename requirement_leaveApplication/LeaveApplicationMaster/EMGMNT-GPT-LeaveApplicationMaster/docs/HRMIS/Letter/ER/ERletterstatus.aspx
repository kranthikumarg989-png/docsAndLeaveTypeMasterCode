<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ERletterstatus.aspx.vb" Inherits="E_Management.ERletterstatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
     <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="1271px"
            Style="position: relative" Width="1195px">
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="1" DataSourceID="SqlDataSource1" ForeColor="#333333"
                        Style="position: relative; left: 8px; top: 16px;" BorderColor="#404040" BorderWidth="1px" Height="1px" Width="761px" PageSize="25" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="Sno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="LetterName" SortExpression="lettername" />
                            <asp:BoundField DataField="createdby" HeaderText="Created By" SortExpression="createdby" />
                            <asp:BoundField DataField="createdtime" HeaderText="Created @" SortExpression="createdtime" />
                           <asp:TemplateField HeaderText="status" SortExpression="status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Lbl1" runat="server" Text='<%# Bind("status") %>' Width="104px"></asp:Label>&nbsp;
                                    <%--<asp:LinkButton ID="lbprint" runat="server" Style="left: 16px; position: relative;
                                        top: 0px" Width="96px">Print</asp:LinkButton>--%>
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="ERletterview.aspx?letternam={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,createdby,createdtime,status from HRMIS_ER_MASTER_LETTER where  status ='Scheduled'or status='Approved' or status='Rejected' or status='R' order by slno">
                      </asp:SqlDataSource>
                    <br />
                    <br />
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
                        CellPadding="1" DataSourceID="SqlDataSource2" ForeColor="#333333"
                        Style="position: relative; left: 16px; top: 12px;" BorderColor="#404040" BorderWidth="1px" Height="1px" Width="756px" PageSize="25" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="slno" HeaderText="Sno" InsertVisible="False" ReadOnly="True"
                                SortExpression="slno" />
                            <asp:BoundField DataField="lettername" HeaderText="LetterName" SortExpression="lettername" />
                            <asp:BoundField DataField="revision" HeaderText="Rev No" SortExpression="revision" />
                            <asp:BoundField DataField="modifiedby" HeaderText="Edit By" SortExpression="modifiedby" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                             <asp:HyperLinkField HeaderText="Show"  Target="_blank" Text="Show" DataNavigateUrlFields="lettername" DataNavigateUrlFormatString="ERletterview.aspx?letternam={0}">
                <ControlStyle Font-Underline="True" /></asp:HyperLinkField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select slno,lettername,revision,modifiedby,modifiedtime,status from HRMIS_ER_MASTER_LETTER  where status='ES' or status='Rejected' or status='R' order by slno">
                        </asp:SqlDataSource>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <HeaderTemplate>
                    Issue letter
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Label ID="labpnt" runat="server" Style="z-index: 102; left: 853px; position: absolute;
                        top: 141px" Width="71px" Visible="False"></asp:Label>
                    <asp:GridView ID="GridView3" runat="server" Style="position: relative; left: 15px; top: 13px; z-index: 101;" 
                    AllowPaging="True" AutoGenerateColumns="False" CellPadding="1" DataSourceID="SqlDataSource3" ForeColor="#333333" BorderColor="Black" BorderWidth="1px" Height="1px" Width="742px" PageSize="25" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                        <asp:BoundField DataField="sno" HeaderText="Sno" SortExpression="sno" />
                            <asp:BoundField DataField="empcode" HeaderText="Empcode" InsertVisible="False" ReadOnly="True"  SortExpression="empcode" />
                            <asp:BoundField DataField="lettername" HeaderText="LetterName" SortExpression="lettername" />
                            <asp:BoundField DataField="issuedby" HeaderText="Created By" SortExpression="issuedby" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status" />
                              <asp:TemplateField HeaderText="View" SortExpression="status">
                              
                                <ItemTemplate>
                                  
                                    <asp:LinkButton ID="lbprint" runat="server" OnCommand="makprint" CommandArgument='<%# Eval("sno", "{0}") %>' >Print</asp:LinkButton>
                                       <asp:LinkButton ID="lbshow" runat="server"  CommandArgument='<%# Eval("sno", "{0}") %>'
                                      ForeColor="#0000C0" OnCommand="Fncshow" Text="show"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sno,empcode,lettername,createdby,issuedby,issuedate,status from HRMIS_ER_MASTER_LETTER_SAVE order by sno">
                        </asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer><br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
       </asp:Content>

 