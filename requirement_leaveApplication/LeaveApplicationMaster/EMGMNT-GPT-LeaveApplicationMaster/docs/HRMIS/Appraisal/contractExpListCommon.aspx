<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="contractExpListCommon.aspx.vb" Inherits="E_Management.contractExpListCommon" 
  title="Contract Expiry List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="STAFF CONTRACT EXPIRY LIST" Width="330px"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView id="GrdContract" runat="server" ForeColor="#333333" PageSize="15" AllowPaging="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CellPadding="4">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                    <Columns>
                         <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                    <asp:LinkButton ID="Link1" runat="server" Text='<%# Eval("empcode") %>'
                    CausesValidation="false" CommandArgument='<%# Eval("empcode", "{0}") %>'
                        ForeColor="BLUE" OnCommand="rptappraisal" ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>   <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nationality" HeaderText="Nationality" SortExpression="nationality" />
                        <asp:BoundField DataField="emptype" HeaderText="Emptype" SortExpression="emptype" />
                        <asp:BoundField DataField="dateofjoin" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Dateofjoin"
                            SortExpression="dateofjoin" />
                        <asp:BoundField DataField="contract" HeaderText="Contract" SortExpression="contract" />
                        <asp:BoundField DataField="probexp" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Contract Expiry"
                            SortExpression="probexp" />
                        <asp:BoundField DataField="extendcontract" HeaderText="Contract Ext" SortExpression="extendcontract" />
                        <asp:BoundField DataField="contracteffectivefrom" DataFormatString="{0:dd-MMM-yyyy}"
                            HeaderText="Contract Effective" SortExpression="contracteffectivefrom" />
                        <asp:BoundField DataField="diff" HeaderText="Remaining Months" ReadOnly="True" SortExpression="diff" />
                        <asp:BoundField DataField="appraisal" HeaderText="Appraisal" SortExpression="appraisal" />
                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                        <asp:BoundField DataField="confirmd" HeaderText="Employement Status" SortExpression="confirmd" />
                 
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#999999"  />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Names="Lucida Sans Unicode" Font-Size="Small"
                    Font-Underline="True" ForeColor="#804000" Text="OPERATOR CONTRACT EXPIRY LIST"
                    Width="599px"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView id="GridView1" runat="server" ForeColor="#333333" PageSize="15" AllowPaging="True" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" CellPadding="4">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                    <Columns>
                           <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("empcode") %>'
                    CausesValidation="false" CommandArgument='<%# Eval("empcode", "{0}") %>'
                        ForeColor="BLUE" OnCommand="rptappraisal_opt" ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField> <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept-Sect" SortExpression="departmentcode">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:Label>-
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nationality" HeaderText="Nationality" SortExpression="nationality" />
                        <asp:BoundField DataField="emptype" HeaderText="Emptype" SortExpression="emptype" />
                        <asp:BoundField DataField="dateofjoin" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Dateofjoin"
                            SortExpression="dateofjoin" />
                        <asp:BoundField DataField="contract" HeaderText="Contract" SortExpression="contract" />
                        <asp:BoundField DataField="probexp" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Contract Expiry"
                            SortExpression="probexp" />
                        <asp:BoundField DataField="extendcontract" HeaderText="Contract Ext" SortExpression="extendcontract" />
                        <asp:BoundField DataField="contracteffectivefrom" DataFormatString="{0:dd-MMM-yyyy}"
                            HeaderText="Contract Effective" SortExpression="contracteffectivefrom" />
                        <asp:BoundField DataField="diff" HeaderText="Remaining Months" ReadOnly="True" SortExpression="diff" />
                        <asp:BoundField DataField="appraisal" HeaderText="Appraisal" SortExpression="appraisal" />
                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                        <asp:BoundField DataField="confirmd" HeaderText="Employement Status" SortExpression="confirmd" />
               
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#999999"  />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="hrmis_getExpcontract_OPT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="hrmis_getExpcontract" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
