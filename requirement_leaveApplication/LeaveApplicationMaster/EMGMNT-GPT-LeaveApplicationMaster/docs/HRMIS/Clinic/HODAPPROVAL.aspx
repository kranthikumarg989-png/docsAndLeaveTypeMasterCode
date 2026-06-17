<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="HODAPPROVAL.aspx.vb" Inherits="E_Management.HODAPPROVAL1" 
    title="CLINIC PASS APPROVAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="#C00000" Text="CLINIC PASS PENDING FOR APPROVAL"></asp:Label><br />
    <asp:Panel ID="Panel1" runat="server">
        <table>
             <tr>
               <td style="background-color: #5d7b9d">
               <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
               Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtsearch1" runat="server"></asp:TextBox>
               <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid1" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsearch1"
                ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search">
                </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter=True PageSize="25" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Name" SortExpression="empname" />
            <asp:TemplateField HeaderText="Dept -Sect" SortExpression="department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("department") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sect") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString="{0:dd-MMM-yy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString="{0:t}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString="{0:t}"   HtmlEncode="False"  />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">SCHEDULED</asp:ListItem>
                                    <asp:ListItem Value="A">APPROVE</asp:ListItem>
                                </asp:RadioButtonList>
                </ItemTemplate>
                 <FooterTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="UpdateclinicApproval" SkinID="buttonskin1"
                 Text="SUBMIT" />
                                        </FooterTemplate>
            </asp:TemplateField>
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
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <table>
                  <tr>
               <td style="background-color: #5d7b9d">
               <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
               Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtsearch2" runat="server"></asp:TextBox>
               <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid2" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsearch2"
                ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search">
                </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter=True PageSize="25" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Name" SortExpression="empname" />
            <asp:TemplateField HeaderText="Dept -Sect" SortExpression="department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("department") %>'></asp:Label>-<asp:Label
                        ID="Label3" runat="server" Text='<%# Eval("sect") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString="{0:dd-MMM-yy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString="{0:t}"  HtmlEncode="False"  />
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString="{0:t}"   HtmlEncode="False"  />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" OnClick="UpdateclinicApproval2" SkinID="buttonskin1"
                 Text="SUBMIT" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                        <asp:ListItem Value="S">SCHEDULED</asp:ListItem>
                        <asp:ListItem Value="A">APPROVE</asp:ListItem>
                    </asp:RadioButtonList>
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
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    &nbsp;<br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT clinicstaffgatepass.passno, clinicstaffgatepass.empcode, clinicstaffgatepass.department, clinicstaffgatepass.category, clinicstaffgatepass.sect, clinicstaffgatepass.status, clinicstaffgatepass.dateapplied, clinicstaffgatepass.etimeout, clinicstaffgatepass.etimein, clinicstaffgatepass.sickness, empmaster.empname FROM clinicstaffgatepass CROSS JOIN empmaster WHERE (clinicstaffgatepass.department = @department) AND (clinicstaffgatepass.status = @status) and empmaster.empcode <> @emp AND  clinicstaffgatepass.empcode = empmaster.empcode ORDER BY clinicstaffgatepass.passno DESC">
        <SelectParameters>
            <asp:SessionParameter Name="department" SessionField="_edept" Type="String" />
                <asp:SessionParameter SessionField="empcode" Name="emp" Type=String DefaultValue=""  />
                    
            <asp:Parameter Name="status" DefaultValue="S" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

</asp:Content>

