<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="GpApproval.aspx.vb" 
Inherits="E_Management.GpApproval" title="GP/CP Approvals" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td>
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon"
                    Text="GATE PASS PENDING FOR APPROVAL"></asp:Label>&nbsp; <span style="color: #aca899">
                        (Click Empcode to view Employe GatePass History)<br />
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                         <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td style="background-color: #5d7b9d">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                                    Text="SEARCH "></asp:Label>:<asp:TextBox ID="txtsearchapp" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2"
                        runat="server" ImageAlign="AbsMiddle" Height="20px"
                        ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGridapp" 
                        BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsearchapp"
                                    ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                        <asp:GridView ID="Gridgpapp" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Gatepass waiting for Approvals"
                    ForeColor="#333333" GridLines="None" ShowFooter="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="passno" HeaderText="passno" SortExpression="passno" />
                        <asp:TemplateField HeaderText="EmpID" SortExpression="empcode">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Text='<%# Eval("empcode") %>' Font-Underline="True" ForeColor="Blue"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Empname" SortExpression="empname">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empname") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                            </ItemTemplate>
                              
                        </asp:TemplateField>
                        <asp:BoundField DataField="gatepasstype" HeaderText="PassType" SortExpression="gatepasstype" />
                        <asp:BoundField DataField="outdate" DataFormatString="{0:d}" HeaderText="OutDate"
                            SortExpression="outdate" />
                        <asp:BoundField DataField="outtime" DataFormatString="{0:t}" HeaderText="Time Out"
                            SortExpression="outtime" />
                        <asp:BoundField DataField="intime" DataFormatString="{0:t}" HeaderText="Time In"
                            SortExpression="intime" />
                        <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbgpstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                    <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateGpApproval" SkinID="buttonskin1"
                                    Text="SUBMIT" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlsearch" runat="server">
                <table>
                    <tr>
                        <td style="background-color: #5d7b9d;">
                            &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"
                                Text="SEARCH "></asp:Label>:<asp:TextBox ID="search" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1"
                        runat="server" ImageAlign="AbsMiddle" Height="20px"
                        ImageUrl="~/images/search.gif" width="30px" OnClick="SearchGrid2" 
                        BackColor="Transparent" BorderColor="Black" BorderWidth="1px" ValidationGroup="search" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="search"
                                ErrorMessage="Enter Empid/EmpName to search" ForeColor="Maroon" ValidationGroup="search"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Gatepass waiting for Approvals"
                    ForeColor="#333333" GridLines="None" ShowFooter="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="passno" HeaderText="passno" SortExpression="passno" />
                        <asp:TemplateField HeaderText="EmpID" SortExpression="empcode">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="True" ForeColor="Blue"
                                    OnClick="LinkButton2_Click" Text='<%# Eval("empcode") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Empname" SortExpression="empname">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empname") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:BoundField DataField="gatepasstype" HeaderText="PassType" SortExpression="gatepasstype" />
                        <asp:BoundField DataField="outdate" DataFormatString="{0:d}" HeaderText="OutDate"
                            SortExpression="outdate" />
                        <asp:BoundField DataField="outtime" DataFormatString="{0:t}" HeaderText="Time Out"
                            SortExpression="outtime" />
                        <asp:BoundField DataField="intime" DataFormatString="{0:t}" HeaderText="Time In"
                            SortExpression="intime" />
                        <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateGpApproval2" SkinID="buttonskin1"
                                    Text="SUBMIT" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbgpstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="SCHEDULED">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="APPROVED">Approve</asp:ListItem>
                                    <asp:ListItem Value="REJECTED">Reject</asp:ListItem>
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
                <cc1:ModalPopupExtender ID="rathimpe" runat="server" BackgroundCssClass="modalBackground"
                    DropShadow="false" EnableViewState="False" OkControlID="okbutton" PopupControlID="pnlgphistory"
                    PopupDragHandleControlID="pnlgphistory" TargetControlID="btnShowModalPopup">
                </cc1:ModalPopupExtender>
                <asp:SqlDataSource ID="ApprovalGp" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT staffgatepass.empcode,staffgatepass.passno,staffgatepass.purpose, staffgatepass.date1, staffgatepass.purpose, staffgatepass.outdate, staffgatepass.outtime, staffgatepass.intime, staffgatepass.gatepasstype, staffgatepass.status,staffgatepass.remarks, empmaster.empname,  empmaster.sectioncode, empmaster.departmentcode FROM staffgatepass CROSS JOIN empmaster WHERE ((staffgatepass.status = 'scheduled')  OR (staffgatepass.status = 'SCHEDULED')) AND (staffgatepass.outdate >= convert(varchar(10),GETDATE(),101)) and empmaster.departmentcode = @dept and empmaster.empcode <> @emp and staffgatepass.empcode = empmaster.empcode order by passno desc">
                    <SelectParameters>
                    <asp:SessionParameter SessionField="_edept" Name="dept" Type=String DefaultValue=""  />
                    <asp:SessionParameter SessionField="empcode" Name="emp" Type=String DefaultValue=""  />
                    
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnShowModalPopup" runat="server" SkinID="buttonskin1" Style="display: none" /><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="Maroon" Text="CUSTOMER PASS PENDING FOR APPROVAL"></asp:Label><br />
                <asp:GridView ID="GrdCVApproval" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqlCvapproval" EmptyDataText="No CustomerPass waiting for Approvals"
                    ForeColor="#333333" GridLines="None" ShowFooter="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="recno" HeaderText="Recno" InsertVisible="False" ReadOnly="True"
                            SortExpression="recno" />
                        <asp:BoundField DataField="visitortype" HeaderText="VisitorType" SortExpression="visitortype" />
                        <asp:BoundField DataField="companyname" HeaderText="CompanyName" SortExpression="companyname" />
                        <asp:BoundField DataField="noofperson" HeaderText="No.of Visitor" SortExpression="noofperson" />
                        <asp:BoundField DataField="arrivaldate" DataFormatString="{0:dd/MM/yy}" HeaderText="ArrivalDate"
                            SortExpression="arrivaldate" />
                        <asp:BoundField DataField="arrivaltime" DataFormatString="{0:t}" HeaderText="ArrivalTime"
                            SortExpression="arrivaltime" />
                        <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                        <asp:BoundField DataField="visitdepartment" HeaderText="DepartmentToVisit" SortExpression="visitdepartment" />
                        <asp:BoundField DataField="companypersonincharge" HeaderText="Comppersonincharge"
                            SortExpression="companypersonincharge" />
                        <asp:TemplateField HeaderText="status" SortExpression="status">
                            <ItemTemplate>
                                &nbsp;
                                <asp:RadioButtonList ID="rbcvstatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="A">Approve</asp:ListItem>
                                    <asp:ListItem Value="R">Rejecte</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateCVApproval" SkinID="buttonskin1"
                                    Text="SUBMIT" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 656px">
            
         <asp:Panel ID = "pnlgphistory" runat="server"  Height="100%" >
                <table cellpadding="5" cellspacing="5" style="border-right: #333366 2px solid; border-top: #333366 2px solid;
                    border-left: #333366 2px solid; border-bottom: #333366 2px solid; background-color: white">
                    <tr>
                        <td colspan="3" style="color: white; background-color: #003399">
                            <asp:Label ID="lbltxtempid" runat="server"></asp:Label>
                            <asp:Label ID="Label17" runat="server" Text="  History"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="lblclass" colspan="3" style="height: 29px">
                            <asp:Label ID="txtdeptsect" runat="server" Text="Dept-Sect : "></asp:Label>&nbsp;
                            <asp:Label ID="txtdept2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="lblclass" colspan="3">
                            <asp:Label ID="txtdesig2" runat="server" Text="Designation :"></asp:Label>&nbsp;
                            <asp:Label ID="Label15" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True"
                                ForeColor="DarkGreen"> GatePass Summary :</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lblclass">
                            &nbsp;<asp:Label ID="Label3" runat="server" ForeColor="DarkGreen"> Personal GatePass Utilised :</asp:Label>
                            <asp:Label ID="lbltotpergp" runat="server" ForeColor="DarkGreen"></asp:Label>
                        </td>
                        <td class="lblclass">
                            &nbsp;<asp:Label ID="Label18" runat="server" ForeColor="DarkGreen">  Official GatePass Utilised :</asp:Label>
                            <asp:Label ID="lbltotOffGp" runat="server" ForeColor="DarkGreen"></asp:Label>
                        </td>
                        <td class="lblclass">
                            &nbsp;<asp:Label ID="Label22" runat="server" ForeColor="DarkGreen"> Pass Pending for Approval :</asp:Label>
                            <asp:Label ID="lblgppending" runat="server" ForeColor="DarkGreen"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="GrdGphistory" runat="server" AllowPaging="True" AllowSorting="True"
                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="2px"
                                CellPadding="4" EmptyDataText="No GatePass Utilised So far" ShowFooter="True">
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <FooterStyle ForeColor="#003399" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <HeaderStyle Font-Bold="True" ForeColor="Red" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="border-top: blue 2px solid">
                            <asp:Button ID="okbutton" runat="server" SkinID="buttonskin1" Text="BACK" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp; &nbsp; &nbsp;
                <asp:SqlDataSource ID="sqlCvapproval" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT recno ,[visitortype], [companyname], [personincharge], [noofperson], [arrivaldate], [arrivaltime], [purpose], (LTrim(RTrim(status))) as status, [visitdepartment], [companypersonincharge] FROM [acc_customerapplication] WHERE status = 'S' AND (department = @dept)  AND (datepart(mm, arrivaldate) >= datepart(mm,  getdate())) AND (datepart(yy, arrivaldate) >= datepart(yy,  getdate()))">
                    <SelectParameters>
                        <asp:Parameter Name="dept" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>


</asp:Content>
