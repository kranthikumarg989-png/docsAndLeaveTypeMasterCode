<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="HODapprovalOT.aspx.vb" Inherits="E_Management.HODapprovalOT" 
    title="HOD OT approval" %>
    <%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon"
                    Text="OT PENDING HOD APPROVAL"></asp:Label>&nbsp;
    <br />
    <asp:Panel ID="Panel1" runat="server" GroupingText="SEARCH">
        <table style="width: 239px">
            <tr>
                <td style="width: 100px">
                    Select
                </td>
                <td style="width: 100px">
                    <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                        Width="408px">
                        <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                        <asp:ListItem Value="Sect">BySect</asp:ListItem>
                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                        <asp:ListItem Selected="True" Value="all">* (ALL)</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbldeptr" runat="server" Text="Select Department" Width="131px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddldeptr" runat="server" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 24px">
                    <asp:Label ID="lblsectr" runat="server" Text="Select Section" Width="98px"></asp:Label></td>
                <td style="width: 100px; height: 24px">
                    <asp:DropDownList ID="ddlsectrpt" runat="server">
                        <asp:ListItem Selected="True" Value="-1">--select--</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblempr" runat="server" Text="ByEmployee"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtempidr" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td align="right" style="width: 100px">
                    <asp:Button ID="btnshow" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
            </tr>
        </table>
           </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
       
        <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="#C00000"></asp:Label>
    <br />
                    <table>
            <tr>
                <td colspan="2" valign="top" style="height: 6px;background-color: #5d7b9d"">
                   
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
                <td colspan="2">
                    <asp:GridView runat="server" ID="HodOTapproval" AllowPaging="True"
                    AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No OT claim waiting for Approvals"
                    ForeColor="#333333" GridLines="None" ShowFooter="True"  PageSize="25" >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle" Width="350px" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="RecNo" HeaderText="Rec. No" InsertVisible="False" ReadOnly="True"
                            SortExpression="RecNo" />
                        <asp:BoundField DataField="Expr1" HeaderText="Expr1" SortExpression="Expr1" visible="False"/>
                        <asp:BoundField DataField="empcode" HeaderText="Emp. Code" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Emp. Name" SortExpression="empname" >
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:BoundField DataField="departmentcode" HeaderText="Department." SortExpression="departmentcode" />
                        <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                        <asp:BoundField DataField="dateapplied" HeaderText="Date Applied" SortExpression="dateapplied" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False">
                            <ItemStyle Width="100px" />
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="shift" HeaderText="Shift" SortExpression="shift" />
                        <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False" />
                         
                       
                        <asp:TemplateField HeaderText="OT Hrs" SortExpression="hrs"> 
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("hrs") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hrs") %>' Width="37px"> </asp:TextBox>
                                <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Width="50px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="TextBox4"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                            <ItemStyle Width="10px" VerticalAlign="Bottom" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ottype" HeaderText="Ot Type" SortExpression="ottype" />
                        <asp:TemplateField HeaderText="Remarks" SortExpression="remark">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="TextBox5" runat="server" Height="50px" Text='<%# Bind("remark") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                             <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:RadioButtonList ID="OTapprovalStat" runat="server" width="75px" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="A">Approve</asp:ListItem>
                                    <asp:ListItem Value="R">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                                     </ItemTemplate> 
                                      <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="Hodapproval" Text="SUBMIT" />
                            </FooterTemplate>                     
                               
                        </asp:TemplateField>
                        <asp:BoundField DataField="OT" HeaderText="OT" SortExpression="OT" Visible="False" />
                        <asp:BoundField DataField="resigned" HeaderText="resigned" SortExpression="resigned" Visible="False" />
            
                               
                            </Columns>
        <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                       
                </asp:GridView>
                </td>
            </tr>
        </table>
         </asp:Panel>
                <cc1:ModalPopupExtender ID="rathimpe" runat="server" BackgroundCssClass="modalBackground"
                    DropShadow="false" EnableViewState="False" OkControlID="okbutton" PopupControlID="pnlgphistory"
                    PopupDragHandleControlID="pnlgphistory" TargetControlID="btnShowModalPopup">
                </cc1:ModalPopupExtender>
    
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [id], [startdate], [enddate], [sect], [Category], [MaxHours], [status] FROM [tbl_MaxOTSetting] where status='s'">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <br />
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT empmaster.empcode AS Expr1, otentry.empcode, otentry.shift, otentry.hrs, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode, otentry.dateapplied, otentry.OT, otentry.datecheck, otentry.ottype, empmaster.resigned, otentry.remark, otentry.status, otentry.RecNo FROM empmaster INNER JOIN otentry ON empmaster.empcode = otentry.empcode WHERE (otentry.OT = 'Y') AND (empmaster.resigned = 'N') AND (otentry.status = 'S') AND (empmaster.departmentcode = @Dept)">
                        <SelectParameters>
                            <asp:SessionParameter  Name="Dept" SessionField="_edept" />
                        </SelectParameters>
                    </asp:SqlDataSource>

<asp:Button ID="btnShowModalPopup" runat="server" SkinID="buttonskin1" Style="display: none" /><br />
         </asp:Content>
       
