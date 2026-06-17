<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" Codebehind="OTApprovalEA.aspx.vb"
    Inherits="E_Management.OTApprovalEA1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE2_onclick() {

}

// ]]>
    </script>

    &nbsp;&nbsp;<br />
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="OT BUDGET PENDING APPROVAL" Width="421px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:RadioButtonList ID="rbOption" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="521px">
                    <asp:ListItem Value="HA">MMSB</asp:ListItem>
                    <asp:ListItem Value="MA">MELAKA</asp:ListItem>
                    <asp:ListItem Value="LA">LIGHTING</asp:ListItem>
                    <asp:ListItem Value="OA">OUTSOURCE</asp:ListItem>
                    <asp:ListItem Selected="True">All</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" id="tdHrmis" runat="server">
                3<table>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:GridView runat="server" ID="EAOTapproval" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource7" EmptyDataText="No OT claim waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25" Width="538px" Caption="MARUWA MALAYSIA - OT REQUESTS">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                    Width="350px" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                                    <asp:BoundField DataField="startdate" HeaderText="StartDate" SortExpression="startdate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="enddate" HeaderText="EndDate" SortExpression="enddate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="Sect" HeaderText="Sect" SortExpression="Sect" />
                                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                    <asp:BoundField DataField="MaxHours" HeaderText="MaxHours" SortExpression="MaxHours" />
                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="OTapprovalStat" runat="server" SelectedValue='<%# Bind("status") %>'>
                                                <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                                <asp:ListItem Value="A">Approve</asp:ListItem>
                                                <asp:ListItem Value="R">Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateOTapproval" Text="SUBMIT" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" id="tdLighting" runat="server"> 
                4<table>
                    <tr>
                        <td colspan="2" align="left">
                          <asp:GridView runat="server" ID="dgvMelakaMain" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource4" EmptyDataText="No OT claim waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25" Width="538px" Caption="MARUWA MELAKA - OT REQUESTS">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                    Width="350px" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                                    <asp:BoundField DataField="startdate" HeaderText="StartDate" SortExpression="startdate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="enddate" HeaderText="EndDate" SortExpression="enddate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="Sect" HeaderText="Sect" SortExpression="Sect" />
                                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                    <asp:BoundField DataField="MaxHours" HeaderText="MaxHours" SortExpression="MaxHours" />
                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="OTapprovalStat" runat="server" SelectedValue='<%# Bind("status") %>'>
                                                <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                                <asp:ListItem Value="A">Approve</asp:ListItem>
                                                <asp:ListItem Value="R">Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateOTMelaka" Text="SUBMIT" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                          
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" id="tdOutSource" runat="server">
                5<table>
                    <tr>
                        <td colspan="2" align="left">
                          <asp:GridView runat="server" ID="dgvLighting" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource5" EmptyDataText="No OT claim waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25" Width="538px" Caption="MARUWA LIGHTING - OT REQUESTS">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                    Width="350px" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                                    <asp:BoundField DataField="startdate" HeaderText="StartDate" SortExpression="startdate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="enddate" HeaderText="EndDate" SortExpression="enddate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="Sect" HeaderText="Sect" SortExpression="Sect" />
                                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                    <asp:BoundField DataField="MaxHours" HeaderText="MaxHours" SortExpression="MaxHours" />
                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="OTapprovalStat" runat="server" SelectedValue='<%# Bind("status") %>'>
                                                <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                                <asp:ListItem Value="A">Approve</asp:ListItem>
                                                <asp:ListItem Value="R">Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateOTLighting" Text="SUBMIT" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                          
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" id="tdMelaka" runat="server">
                6<table>
                    <tr>
                        <td colspan="2" align="left">
                         <asp:GridView runat="server" ID="dgvOutSource" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" EmptyDataText="No OT claim waiting for Approvals"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25" Width="538px" Caption="MARUWA OUTSOURCE - OT REQUESTS">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                    Width="350px" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                                    <asp:BoundField DataField="startdate" HeaderText="StartDate" SortExpression="startdate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="enddate" HeaderText="EndDate" SortExpression="enddate"
                                        DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="Sect" HeaderText="Sect" SortExpression="Sect" />
                                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                    <asp:BoundField DataField="MaxHours" HeaderText="MaxHours" SortExpression="MaxHours" />
                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="OTapprovalStat" runat="server" SelectedValue='<%# Bind("status") %>'>
                                                <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                                <asp:ListItem Value="A">Approve</asp:ListItem>
                                                <asp:ListItem Value="R">Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateOTOutSource" Text="SUBMIT" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 967px" colspan="2">
        
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
                    SelectCommand="SELECT [id], [startdate], [enddate], [sect], [Category], [MaxHours], [status] FROM [tbl_MaxOTSetting] where status='s'">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource8" runat="server"></asp:SqlDataSource>
            
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OutsourceHRMIS %>"
                    SelectCommand="SELECT [id], [startdate], [enddate], [sect], [Category], [MaxHours], [status] FROM [tbl_MaxOTSetting] where status='s'">
                </asp:SqlDataSource>
            
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis %>"
                    SelectCommand="SELECT [id], [startdate], [enddate], [sect], [Category], [MaxHours], [status] FROM [tbl_MaxOTSetting] where status='s'">
                </asp:SqlDataSource>
             
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
                    SelectCommand="SELECT [id], [startdate], [enddate], [sect], [Category], [MaxHours], [status] FROM [tbl_MaxOTSetting] where status='s'">
                </asp:SqlDataSource>
               
            </td>
        </tr>
        
    </table>


</asp:Content>
