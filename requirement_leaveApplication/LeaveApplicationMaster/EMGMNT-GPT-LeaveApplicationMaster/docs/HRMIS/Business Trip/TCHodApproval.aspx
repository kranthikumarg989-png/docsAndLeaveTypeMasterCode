<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TCHodApproval.aspx.vb" Inherits="E_Management.TCHodApproval" 
    title="TC HOD APPROVAL Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:GridView ID="GridView1" runat="server" ShowFooter=TRUE  AutoGenerateColumns="False" 
     CellPadding="4" ForeColor="#333333" GridLines="None">
        <Columns>
             <asp:HyperLinkField HeaderText="TC View"  
            datanavigateurlformatstring="TCview.aspx?rno={0}&btno={1}" 
            datanavigateurlfields="Rno,recno"
            Target="_blank"
            Text="VIEW">
            <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="Rno" HeaderText="Rno" SortExpression="Rno" />
            <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="Empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Dept Code" SortExpression="departmentcode" />
            <asp:TemplateField HeaderText="BT Period" SortExpression="fromdate">
                            <ItemTemplate>
                  <asp:Label ID="Label8" runat="server" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>' HtmlEncode="false"></asp:Label>~
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>' HtmlEncode="false"></asp:Label>
                  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
            <asp:BoundField DataField="travellingallowances" HeaderText="T.Allowances" SortExpression="travellingallowances" />
            <asp:HyperLinkField HeaderText="CV Report"  
            datanavigateurlformatstring="CVview.aspx?btno={0}" 
            datanavigateurlfields="recno"
            Target="_blank"
            Text="VIEW">
            <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
              <asp:BoundField DataField="Recno" HeaderText="Recno" SortExpression="Recno" Visible=false  />
          
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                               <ItemTemplate>
                    <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("STATUS") %>'>
                        <asp:ListItem Value="SCHEDULED">PENDING</asp:ListItem>
                        <asp:ListItem Value="HODAPPROVED">APPROVE</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
                  <FooterTemplate>
                    <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" OnClick ="UpdateTC" />
                </FooterTemplate> 
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
     <asp:GridView ID="GridView2" runat="server" ShowFooter="True"  AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField HeaderText="TC View"  
            datanavigateurlformatstring="TCview.aspx?rno={0}&amp;btno={1}" 
            datanavigateurlfields="Rno,recno"
            Target="_blank"
            Text="VIEW">
                <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="Rno" HeaderText="Rno" SortExpression="Rno" />
            <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="Empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="departmentcode" HeaderText="Dept Code" SortExpression="departmentcode" />
            <asp:TemplateField HeaderText="BT Period" SortExpression="fromdate">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" HtmlEncode="false" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                    <asp:Label ID="Label9" runat="server" HtmlEncode="false" Text='<%# Eval("todate", "{0:dd-MMM-yy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
            <asp:BoundField DataField="travellingallowances" HeaderText="T.Allowances" SortExpression="travellingallowances" />
            <asp:HyperLinkField HeaderText="CV Report"  
            datanavigateurlformatstring="CVview.aspx?btno={0}" 
            datanavigateurlfields="recno"
            Target="_blank"
            Text="VIEW">
                <ControlStyle Font-Underline="True" ForeColor="Blue" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="Recno" HeaderText="Recno" SortExpression="Recno" Visible=False  />
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <FooterTemplate>
                    <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" OnClick ="UpdateTC2" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("STATUS") %>'>
                        <asp:ListItem Value="SCHEDULED">PENDING</asp:ListItem>
                        <asp:ListItem Value="HODAPPROVED">APPROVE</asp:ListItem>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT acc_businesstrip.recno, HRMIS_TC_Travellingclaimnew.Empcode, HRMIS_TC_Travellingclaimnew.HODAPPROVED, HRMIS_TC_Travellingclaimnew.happrovedtime, HRMIS_TC_Travellingclaimnew.Rno, HRMIS_TC_Travellingclaimnew.paid, empmaster.empname, empmaster.departmentcode, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.purpose, acc_businesstrip.travellingallowances, HRMIS_TC_Travellingclaimnew.tallowance, LTRIM(RTRIM(HRMIS_TC_Travellingclaimnew.status)) AS STATUS FROM acc_businesstrip INNER JOIN HRMIS_TC_Travellingclaimnew ON acc_businesstrip.recno = HRMIS_TC_Travellingclaimnew.btrno INNER JOIN empmaster ON HRMIS_TC_Travellingclaimnew.Empcode = empmaster.empcode WHERE (HRMIS_TC_Travellingclaimnew.paid = 'NP') AND (HRMIS_TC_Travellingclaimnew.status = 'SCHEDULED') and empmaster.departmentcode = @dept order by rno desc">
        <SelectParameters>
        <asp:SessionParameter Name=dept SessionField= _edept  />
        </SelectParameters>
    </asp:SqlDataSource>
 


</asp:Content>
