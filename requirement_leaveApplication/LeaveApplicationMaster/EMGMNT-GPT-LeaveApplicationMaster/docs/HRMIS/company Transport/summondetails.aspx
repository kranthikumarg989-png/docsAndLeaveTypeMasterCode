<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="summondetails.aspx.vb" Inherits="E_Management.summondetails" Theme="buttonems" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 574px">
        <tr>
            <td class="td_head" colspan="4" style="height: 17px">
                SUMMON DETAILS</td>
        </tr>
        <tr>
            <td style="width: 82px; height: 30px;">
                Vehicle No</td>
            <td style="width: 41px; height: 30px;">
                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="vehicleno" DataValueField="vehicleno">
                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                    ControlToValidate="DropDownList1" ErrorMessage="Select Vehicle No." InitialValue="-1"
                    ValidationGroup="a">!</asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 30px">
                Name</td>
            <td style="width: 100px; height: 30px">
                <asp:TextBox ID="txtname" runat="server" Width="126px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="Enter Name"
                    ValidationGroup="a">!</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 82px">
                Summon Date</td>
            <td style="width: 41px">
                <asp:TextBox ID="txtsdate" runat="server" Width="126px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsdate" ErrorMessage="Enter SummonDate"
                    ValidationGroup="a">!</asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Due Date</td>
            <td style="width: 100px">
                &nbsp;<asp:TextBox ID="txtddate" runat="server" Width="126px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtddate" ErrorMessage="Enter Due date"
                    ValidationGroup="a">!</asp:RequiredFieldValidator>     
            </td>
                    <cc1:CalendarExtender ID="cce1" runat=server
                     PopupButtonID="txtsdate" TargetControlID="txtsdate"
                     Format = "dd/MM/yy" CssClass="cal_Theme1"  >
                     </cc1:CalendarExtender>
        </tr>
        <tr>
            <td style="width: 82px">
                Amount</td>
            <td style="width: 41px">
                <asp:TextBox ID="txtamt" runat="server" Width="126px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtamt" ErrorMessage="Enter Amount"
                    ValidationGroup="a">!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtamt"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="a">!</asp:RegularExpressionValidator></td>
            <td style="width: 100px">
                Paid Date</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpdate" runat="server" Width="123px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 82px; height: 14px;">
                Reason</td>
            <td style="height: 14px;" colspan="3">
                <asp:TextBox ID="txtreason" runat="server" TextMode="MultiLine" Width="423px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtreason"
                    ErrorMessage="Enter Reason" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                &nbsp;<asp:Button ID="btnsave" runat="server" Text="ADD" ValidationGroup="a" SkinID="buttonskin1" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" AutoGenerateEditButton="True"
                    CellPadding="4" DataSourceID="SqlDataSource2" DataKeyNames="rno"  ForeColor="#333333" GridLines="None" Width="546px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="vehicleno" ReadOnly=True HeaderText="Vehicleno" SortExpression="vehicleno" />
                        <asp:TemplateField HeaderText="Summondate" SortExpression="summondate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%#  Bind("summondate", "{0:MMM/dd/yyyy}")%>' HtmlEncode="false">
                                </asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat=server
                     PopupButtonID="TextBox1" TargetControlID="TextBox1"
                     Format = "MMM/dd/yyyy" CssClass="cal_Theme1"  >
                     </cc1:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("summondate", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DueOn" SortExpression="duedate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("duedate", "{0:MMM/dd/yyyy}") %>' HtmlEncode="false"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender4" runat=server
                     PopupButtonID="TextBox2" TargetControlID="TextBox2"
                     Format = "MMM/dd/yyyy" CssClass="cal_Theme1"  >
                     </cc1:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("duedate", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason" SortExpression="reason">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("reason") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" SortExpression="amount">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("amount") %>'></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textbox4"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="a">!</asp:RegularExpressionValidator>
    
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paidon" SortExpression="paiddate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server"  Text='<%# Bind("paiddate", "{0:MMM/dd/yyyy}") %>' HtmlEncode="false"> </asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtende4" runat=server
                     PopupButtonID="TextBox5" TargetControlID="TextBox5"
                     Format = "MMM/dd/yyyy" CssClass="cal_Theme1"  >
                     </cc1:CalendarExtender> 
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("paiddate", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("name") %>'></asp:Label>
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
                     <cc1:CalendarExtender ID="CalendarExtender2" runat=server
                     PopupButtonID="txtpdate" TargetControlID="txtpdate"
                     Format = "dd/MM/yy" CssClass="cal_Theme1"  >
                     </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat=server
                     PopupButtonID="txtddate" TargetControlID="txtddate"
                     Format = "dd/MM/yy" CssClass="cal_Theme1"  >
                     </cc1:CalendarExtender>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM [summondetails] ORDER BY [rno] DESC"
                     UpdateCommand="hrmis_ct_updsummon" UpdateCommandType=StoredProcedure
                      DeleteCommand = "delete from summondetails where rno=@rno"  >
                      <UpdateParameters>
                                  <asp:Parameter Name=summondate Type=datetime />
                      <asp:Parameter Name = duedate  Type=datetime />
                      <asp:Parameter Name=reason Type=string />
                      <asp:Parameter Name= amount Type =Decimal />
                      <asp:Parameter Name="paiddate" Type=datetime />
                      <asp:Parameter Name= name Type=string />
                      <asp:SessionParameter SessionField="empname" Name= modiby Type=string /> 
                      </UpdateParameters>                                       
                    </asp:SqlDataSource>
            </td>
          </tr>
    </table>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [vehicleno] FROM [vehicledetail] ORDER BY [vehicleno]"></asp:SqlDataSource>

</asp:Content>
