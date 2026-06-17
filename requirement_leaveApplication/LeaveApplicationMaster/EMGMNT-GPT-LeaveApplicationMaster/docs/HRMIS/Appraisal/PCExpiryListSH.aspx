<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PCExpiryListSH.aspx.vb" Inherits="E_Management.PCExpiryListSH" 
    title="Probation/contract Expiry List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td style="width: 7px">
                <asp:Label ID="Label2" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="OPERATOR PROBATION EXPIRY LIST"
                    Width="535px"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333"
                    PageSize="20">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="Lnlappraisal" runat="server" CommandArgument='<%# Eval("empcode", "{0}") %>'
                                    Font-Underline="True" ForeColor="Blue" OnCommand="Appraisal_view" Text='<%# Bind("empcode") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-<asp:Label
                                    ID="Label3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="emptype" HeaderText="Emptype" SortExpression="emptype" />
                        <asp:BoundField DataField="probation" HeaderText="Probation" SortExpression="probation" />
                        <asp:BoundField DataField="dateofjoin" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="false" HeaderText="Dateofjoin"
                            SortExpression="dateofjoin" />
                        <asp:BoundField DataField="probationends" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="false" HeaderText="Prob.Exp on"
                            ReadOnly="True" SortExpression="probationends" />
                        <asp:BoundField DataField="diff" HeaderText="Days Remain" ReadOnly="True" SortExpression="diff" />
                        <asp:TemplateField HeaderText="Appraisal &lt;br&gt; Done" SortExpression="appraisal">
                            <ItemTemplate>
                                <asp:Label ID="lblappraisal" runat="server" Text='<%# Bind("appraisal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
                <asp:Label ID="Label4" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="OPERATOR CONTRACT EXPIRY LIST"
                    Width="368px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 7px">
                <asp:GridView ID="GrdContract" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" PageSize="15">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="Lnkcontract" runat="server" CommandArgument='<%# Eval("empcode", "{0}") %>'
                                    Font-Underline="True" ForeColor="Blue" OnCommand="appraisal_view" Text='<%# Bind("empcode") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nationality" HeaderText="Nationality" SortExpression="nationality" />
                        <asp:BoundField DataField="emptype" HeaderText="Emptype" SortExpression="emptype" />
                        <asp:BoundField DataField="dateofjoin" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="false" HeaderText="Dateofjoin"
                            SortExpression="dateofjoin" />
                        <asp:BoundField DataField="contract" HeaderText="Contract" SortExpression="contract" />
                        <asp:BoundField DataField="probexp" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="false" HeaderText="Contract Expiry"
                            SortExpression="probexp" />
                        <asp:BoundField DataField="extendcontract" HeaderText="Contract Ext" SortExpression="extendcontract" />
                        <asp:BoundField DataField="contracteffectivefrom" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="false"
                            HeaderText="Contract Effective" SortExpression="contracteffectivefrom" />
                        <asp:BoundField DataField="diff" HeaderText="Remaining Months" ReadOnly="True" SortExpression="diff" />
                        <asp:BoundField DataField="appraisal" HeaderText="Appraisal" SortExpression="appraisal" />
                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="hrmis_appraisal_alert_sh_OPT" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="sect" SessionField="sect" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="hrmis_getExpcontract_sh_POT" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter  Name="sect" SessionField="sect" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
