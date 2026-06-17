<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CVselfstatus.aspx.vb" Inherits="E_Management.CVselfstatus" 
    title="CUSTOMER VISIT STATUS" %>
       <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="border-right: #1a5c9b 1px solid; border-top: #1a5c9b 1px solid; border-left: #1a5c9b 1px solid;
        border-bottom: #1a5c9b 1px solid">
        <tr>
            <td class="td_head" colspan="5" style="height: 21px">
                Customer / Supplier Pass status
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GrdCVPassStatus" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqlcvpass" ForeColor="#333333" CellSpacing="2">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="companyname" HeaderText="CompName" SortExpression="companyname" />
                        <asp:BoundField DataField="arrivaldate" DataFormatString="{0:dd/MM/yy}" HeaderText="Arrivaldate"  HtmlEncode="false" 
                            SortExpression="arrivaldate" />
                        <asp:BoundField DataField="arrivaltime" DataFormatString="{0:t}" HeaderText="Arrivaltime"  HtmlEncode="false" 
                            SortExpression="arrivaltime" />
                        <asp:BoundField DataField="personincharge" HeaderText="Visitor Name" SortExpression="personincharge" />
                        <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
                        <asp:BoundField DataField="noofperson" HeaderText="no.of person" SortExpression="noofperson" />
                        <asp:BoundField DataField="companypersonincharge" HeaderText="Comp.PersonIncharge"
                            InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="recno" HeaderText="Recno" InsertVisible="False" ReadOnly="True"
                            SortExpression="recno" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:Label ID="lblcv" runat="server" CommandArgument='<%# Eval("recno", "{0}") %>'
                                    Text='<%# Eval("status") %>'> </asp:Label>
                                <asp:LinkButton ID="lbcv" runat="server" CommandArgument='<%# Eval("recno", "{0}") %>'
                                    ForeColor="#0000C0" OnCommand="FncRetreivecpass" Text='<%# Eval("status") %>'></asp:LinkButton>
                                <asp:LinkButton ID="lbcancecv" runat="server" CommandArgument='<%# Eval("recno", "{0}") %>'
                                    ForeColor="RED" OnCommand="cvcancel" Text="CANCEL"></asp:LinkButton>
                                <cc1:confirmbuttonextender id="confirmCVcancel" runat="server" confirmonformsubmit="true"
                                    confirmtext="Are you sure you want to cancel the cust/Supp Pass" targetcontrolid="lbcancecv">
                           </cc1:confirmbuttonextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="sqlcvpass" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT acc_customerapplication.empcode, acc_customerapplication.REMARKS, acc_customerapplication.visitortype, acc_customerapplication.companyname, acc_customerapplication.personincharge, acc_customerapplication.noofperson, acc_customerapplication.contactno, acc_customerapplication.arrivaldate,acc_customerapplication.arrivaltime, empmaster.empname, acc_customerapplication.purpose, acc_customerapplication.receptionarea, acc_customerapplication.date1, acc_customerapplication.recno, acc_customerapplication.status, acc_customerapplication.approvedby, acc_customerapplication.department, acc_customerapplication.category, acc_customerapplication.visitdepartment,acc_customerapplication.otherarea, acc_customerapplication.companypersonincharge, acc_customerapplication.atimein, acc_customerapplication.atimeout, acc_customerapplication.taxibooking,acc_customerapplication.taxicost, acc_customerapplication.hotelarrangement, acc_customerapplication.hotelcost,acc_customerapplication.hotelname, acc_customerapplication.createdby, acc_customerapplication.createdtime, acc_customerapplication.modifiedby, acc_customerapplication.modifiedtime FROM acc_customerapplication acc_customerapplication INNER JOIN empmaster empmaster ON (empmaster.empcode = acc_customerapplication.empcode)  WHERE ((((empmaster.empcode =@emp) ) AND (datepart(mm, arrivaldate) >= datepart(mm,  getdate() ))) AND (datepart(yy, arrivaldate) >= datepart(yy,  getdate() ) AND STATUS <> 'C')) order by acc_customerapplication.recno desc">
                    <SelectParameters>
                         <asp:Parameter Name="emp" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

</asp:Content>
