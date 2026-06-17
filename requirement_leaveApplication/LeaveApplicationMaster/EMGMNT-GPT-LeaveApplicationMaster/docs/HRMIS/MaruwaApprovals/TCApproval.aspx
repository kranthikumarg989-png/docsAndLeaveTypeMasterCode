<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master"  CodeBehind="TCApproval.aspx.vb" Inherits="E_Management.TCApproval" 
    title = "Travelling claim Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100px">
    Travelling Claim Approval</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 45px">
                <asp:RadioButtonList ID="rbOption" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Width="546px">
                    <asp:ListItem Value="HA">MMSB Approval</asp:ListItem>
                    <asp:ListItem Value="MA">Melaka Approval</asp:ListItem>
                    <asp:ListItem Value="LA">Lighting Approval</asp:ListItem>
                    <asp:ListItem Selected="True" >All</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 537px;" id="tdHrmis" runat="server">
            <table>
            <tr>
               <td style="background-color: #5d7b9d">
               <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                    Text="SEARCH"></asp:Label>:<asp:TextBox ID="txtsearch2" runat="server"></asp:TextBox>
               <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid2" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsearch2"
                ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" >
                </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" ShowFooter="True" Caption="MARUWA MALAYSIA">
        <Columns>
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
            <asp:BoundField DataField="TALLOWANCE" HeaderText="T.Allowances" SortExpression="travellingallowances" />
            <asp:BoundField DataField="Recno" HeaderText="Recno" SortExpression="Recno" Visible="False" />
            <asp:BoundField DataField="REMARKS" HeaderText="Remarks" />
            <asp:BoundField DataField="fmdremarks" HeaderText="FMDRemarks"  />
            <asp:TemplateField HeaderText="EARemarks" SortExpression="remarks">
                <ItemTemplate>
                    <asp:TextBox ID="txtremarks" runat="server" Height="42px" Text='<%# Bind("mdREMARKS") %>'
                        TextMode="MultiLine"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="status">
                <ItemTemplate>
                    <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("STATUS") %>'>
                        <asp:ListItem Value="FMDAPPROVED">PENDING</asp:ListItem>
                        <asp:ListItem Value="EAAPPROVED">APPROVE</asp:ListItem>
                        <asp:ListItem Value="REJECTED">REJECT</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" OnClick="UpdateTC" SkinID="buttonskin1" Text="SUBMIT" />
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
                </td>
            </tr>
        </table>
            </td>
        </tr>
        <tr>
            <td id="Td1" runat="server">
                <table style="width: 547px">
                    <tr>
                        <td style="background-color: #5d7b9d">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                                Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtMelaka" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton4" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchMelaka" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMelaka"
                                ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" >
                </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            &nbsp;<asp:GridView ID="dgvmelaka" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource4" ForeColor="#333333" ShowFooter="True" Caption="MARUWA MELAKA">
                                <Columns>
                                    <asp:BoundField DataField="Rno" HeaderText="Rno" SortExpression="Rno" />
                                    <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="Empcode" />
                                    <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                                    <asp:BoundField DataField="departmentcode" HeaderText="Dept Code" SortExpression="departmentcode" />
                                    <asp:TemplateField HeaderText="BT Period" SortExpression="fromdate">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" HtmlEncode="false" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                            <asp:Label ID="Label9" runat="server" HtmlEncode="false" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                                    <asp:BoundField DataField="TALLOWANCE" HeaderText="T.Allowances" SortExpression="travellingallowances" />
                                    <asp:BoundField DataField="Recno" HeaderText="Recno" SortExpression="Recno" Visible="False" />
                                    <asp:BoundField DataField="REMARKS" HeaderText="Remarks" />
                                    <asp:BoundField DataField="fmdremarks" HeaderText="FMDRemarks"  />
                                    <asp:TemplateField HeaderText="EARemarks" SortExpression="remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" runat="server" Height="42px" Text='<%# Bind("mdREMARKS") %>'
                                                TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("STATUS") %>'>
                                                <asp:ListItem Value="FMDAPPROVED">PENDING</asp:ListItem>
                                                <asp:ListItem Value="EAAPPROVED">APPROVE</asp:ListItem>
                                                <asp:ListItem Value="REJECTED">REJECT</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateTCMelaka" SkinID="buttonskin1" Text="SUBMIT" />
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" id="tdLighting" runat="server">
                <table>
                    <tr>
                        <td style="background-color: #5d7b9d">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                                Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtLighting" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="20px"
                ImageUrl="~/images/search.gif" width="30px" OnClick="SearchLighting" 
                BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLighting"
                                ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" >
                </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:GridView ID="dgvLighting" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource2" ForeColor="#333333" ShowFooter="True" Caption="MARUWA LIGHTING">
                                <Columns>
                                    <asp:BoundField DataField="Rno" HeaderText="Rno" SortExpression="Rno" />
                                    <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="Empcode" />
                                    <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                                    <asp:BoundField DataField="departmentcode" HeaderText="Dept Code" SortExpression="departmentcode" />
                                    <asp:TemplateField HeaderText="BT Period" SortExpression="fromdate">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" HtmlEncode="false" Text='<%# Bind("fromdate", "{0:dd-MMM-yy}") %>'></asp:Label>~
                                            <asp:Label ID="Label9" runat="server" HtmlEncode="false" Text='<%# Eval("todate" , "{0:dd-MMM-yy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                                    <asp:BoundField DataField="TALLOWANCE" HeaderText="T.Allowances" SortExpression="travellingallowances" />
                                    <asp:BoundField DataField="Recno" HeaderText="Recno" SortExpression="Recno" Visible="False" />
                                    <asp:BoundField DataField="REMARKS" HeaderText="Remarks" />
                                    <asp:BoundField DataField="fmdremarks" HeaderText="FMDRemarks"  />
                                    <asp:TemplateField HeaderText="EARemarks" SortExpression="remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" runat="server" Height="42px" Text='<%# Bind("mdREMARKS") %>'
                                                TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="rbstatus" runat="server" SelectedValue='<%# Bind("STATUS") %>'>
                                                <asp:ListItem Value="FMDAPPROVED">PENDING</asp:ListItem>
                                                <asp:ListItem Value="EAAPPROVED">APPROVE</asp:ListItem>
                                                <asp:ListItem Value="REJECTED">REJECT</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" runat="server" OnClick="UpdateTCLighting" SkinID="buttonskin1" Text="SUBMIT" />
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" id="tdMelaka" runat="server">
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
        SelectCommand="SELECT acc_businesstrip.recno, HRMIS_TC_Travellingclaimnew.Empcode, HRMIS_TC_Travellingclaimnew.MDREMARKS,HRMIS_TC_Travellingclaimnew.REMARKS,HRMIS_TC_Travellingclaimnew.FMDREMARKS, HRMIS_TC_Travellingclaimnew.Rno, HRMIS_TC_Travellingclaimnew.paid, empmaster.empname, empmaster.departmentcode, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.purpose, acc_businesstrip.travellingallowances, HRMIS_TC_Travellingclaimnew.tallowance, LTRIM(RTRIM(HRMIS_TC_Travellingclaimnew.status)) AS STATUS FROM acc_businesstrip INNER JOIN HRMIS_TC_Travellingclaimnew ON acc_businesstrip.recno = HRMIS_TC_Travellingclaimnew.btrno INNER JOIN empmaster ON HRMIS_TC_Travellingclaimnew.Empcode = empmaster.empcode WHERE (HRMIS_TC_Travellingclaimnew.paid = 'NP') AND (HRMIS_TC_Travellingclaimnew.status = 'FMDAPPROVED' ) ORDER BY RNO DESC">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis %>"
        SelectCommand="SELECT acc_businesstrip.recno, HRMIS_TC_Travellingclaimnew.Empcode, HRMIS_TC_Travellingclaimnew.MDREMARKS,HRMIS_TC_Travellingclaimnew.REMARKS,HRMIS_TC_Travellingclaimnew.FMDREMARKS, HRMIS_TC_Travellingclaimnew.Rno, HRMIS_TC_Travellingclaimnew.paid, empmaster.empname, empmaster.departmentcode, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.purpose, acc_businesstrip.travellingallowances, HRMIS_TC_Travellingclaimnew.tallowance, LTRIM(RTRIM(HRMIS_TC_Travellingclaimnew.status)) AS STATUS FROM acc_businesstrip INNER JOIN HRMIS_TC_Travellingclaimnew ON acc_businesstrip.recno = HRMIS_TC_Travellingclaimnew.btrno INNER JOIN empmaster ON HRMIS_TC_Travellingclaimnew.Empcode = empmaster.empcode WHERE (HRMIS_TC_Travellingclaimnew.paid = 'NP') AND (HRMIS_TC_Travellingclaimnew.status = 'FMDAPPROVED' ) ORDER BY RNO DESC">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
        SelectCommand="SELECT acc_businesstrip.recno, HRMIS_TC_Travellingclaimnew.Empcode, HRMIS_TC_Travellingclaimnew.MDREMARKS,HRMIS_TC_Travellingclaimnew.REMARKS,HRMIS_TC_Travellingclaimnew.FMDREMARKS, HRMIS_TC_Travellingclaimnew.Rno, HRMIS_TC_Travellingclaimnew.paid, empmaster.empname, empmaster.departmentcode, acc_businesstrip.fromdate, acc_businesstrip.todate, acc_businesstrip.purpose, acc_businesstrip.travellingallowances, HRMIS_TC_Travellingclaimnew.tallowance, LTRIM(RTRIM(HRMIS_TC_Travellingclaimnew.status)) AS STATUS FROM acc_businesstrip INNER JOIN HRMIS_TC_Travellingclaimnew ON acc_businesstrip.recno = HRMIS_TC_Travellingclaimnew.btrno INNER JOIN empmaster ON HRMIS_TC_Travellingclaimnew.Empcode = empmaster.empcode WHERE (HRMIS_TC_Travellingclaimnew.paid = 'NP') AND (HRMIS_TC_Travellingclaimnew.status = 'FMDAPPROVED' ) ORDER BY RNO DESC">
    </asp:SqlDataSource>

</asp:Content>