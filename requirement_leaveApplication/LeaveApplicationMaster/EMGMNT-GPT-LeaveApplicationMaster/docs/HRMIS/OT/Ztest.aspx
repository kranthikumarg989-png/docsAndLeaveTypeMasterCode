<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Ztest.aspx.vb" Inherits="E_Management.test1" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:GridView ID="OTmaster" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="SqlDataSource7" PageSize="25" ShowFooter="True"
        Width="435px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="sectioncode" HeaderText="sectioncode" SortExpression="sectioncode" />
            <asp:BoundField DataField="sectionname" HeaderText="sectionname" SortExpression="sectionname" />
            <asp:BoundField DataField="departmentcode" HeaderText="departmentcode" SortExpression="departmentcode" />
            <asp:BoundField DataField="ldepartment" HeaderText="ldepartment" SortExpression="ldepartment" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource7" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="recno" HeaderText="Rec. No." SortExpression="recno" />
                        <asp:BoundField DataField="empcode" HeaderText="Emp. Code" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Emp. Name" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept - Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource7"
                                    DataTextField="section" DataValueField="sectioncode" Width="135px">
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT [sectioncode] + '-' + sectionname as section, sectioncode FROM [sectionmaster]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shift" SortExpression="shift">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("shift") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource7"
                                    DataTextField="departmentcode" DataValueField="sectioncode" Width="153px">
                                    <asp:ListItem Value="-1" Selected="True">---Select---</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT attcode + '-' + attdesc AS attendance, attcode FROM prod_attendancemaster">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" />
                        <asp:TemplateField HeaderText="OT" SortExpression="OT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("OT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Bind("OT") %>'
                                    Width="99px">
                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="whrs" HeaderText="Total OT Hrs in a Week" SortExpression="whrs" />
                        <asp:TemplateField HeaderText="OT Hrs" SortExpression="hrs">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hrs") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("hrs") %>' Width="52px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OT Type" SortExpression="ottype">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ottype") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("ottype") %>'
                                    Width="105px">
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                    <asp:ListItem>OTND</asp:ListItem>
                                    <asp:ListItem>OTPH</asp:ListItem>
                                    <asp:ListItem>OTRD</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="remark">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="TextBox8" runat="server" Height="51px" Text='<%# Bind("remark") %>'
                                    Width="223px"></asp:TextBox>
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
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [sectioncode], [sectionname], [departmentcode], [ldepartment] FROM [sectionmaster]">
    </asp:SqlDataSource>
</asp:Content>
