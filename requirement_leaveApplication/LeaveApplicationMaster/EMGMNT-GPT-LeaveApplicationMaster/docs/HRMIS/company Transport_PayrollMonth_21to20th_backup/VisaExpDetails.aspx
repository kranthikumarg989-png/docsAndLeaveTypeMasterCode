<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="VisaExpDetails.aspx.vb" Inherits="E_Management.VisaExpDetails" Theme="buttonems" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;<table>
        <tr>
            <td class="td_head">
                WORK PERMIT/ VISA EXPIRY DETAILS</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" ShowFooter="True" AllowPaging="True" AllowSorting="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="rno" HeaderText="rno" SortExpression="rno"  />
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:TemplateField HeaderText="Passportno" SortExpression="passportno">
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="txtpp" runat="server" Text='<%# Bind("passportno") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="visavalidto" HeaderText="VisaValidTill" SortExpression="visavalidto" DataFormatString ="{0:dd/MM/yy}" HtmlEncode="false" />
                        <asp:BoundField DataField="workpermitno" HeaderText="Workpermitno" SortExpression="workpermitno" />
                        <asp:BoundField DataField="days" HeaderText="Days" ReadOnly="True" SortExpression="days" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbchoices" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">ToBeNoted</asp:ListItem>
                                    <asp:ListItem Value="C">Under Process</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                                     <FooterTemplate>
                          <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" Text="SUBMIT" onclick="UpdateVisaExpiry"  />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT workpermitdetails.empcode, workpermitdetails.rno, workpermitdetails.modifyby, workpermitdetails.modifytime, empname, workpermitdetails.passportno, visavalidto, workpermitno,  datediff(dd,  getdate() , visavalidto)  AS days, status FROM workpermitdetails workpermitdetails, empmaster empmaster  WHERE (((empmaster.empcode = workpermitdetails.empcode) AND visavalidto BETWEEN  getdate()  AND  dateadd(month, 3,  getdate() ) ) AND (status <> 'C'))">
    </asp:SqlDataSource>


</asp:Content>
