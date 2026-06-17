<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="DomWasteVerification.aspx.vb" Inherits="E_Management.DomWasteVerification" 
    title="Domestic Waste Verification" %>
   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table style="width: 1000px; height: 145px" id="TABLE2">
    <tr>
        <td style="width: 2912px; height: 11px">
            <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="DOMESTIC WASTE VERIFICATION"></asp:Label></td>
        <td style="width: 6100px; height: 11px">
        </td>
    </tr>
        <tr>
            <td style="width: 2912px; height: 249px;" align="left" valign="top">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False"
                 AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="25" AllowSorting="True" DataKeyNames="RECORDNO" >
                    <Columns>
                        <asp:TemplateField HeaderText="Rec.No" SortExpression="recordno">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("recordno") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("recordno") %>'></asp:Label>--%>
                                <asp:LinkButton ID="domveri" runat="server" Text='<%# Eval("recordno") %>' 
                                CausesValidation="False" CommandName="Select"
                        Font-Underline="True" ForeColor="Blue"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="empcode" HeaderText="EmpCode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Requestor" SortExpression="empname" />
                        <asp:BoundField DataField="dateapplied" HeaderText="DateApplied" SortExpression="dateapplied" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                        <asp:BoundField DataField="dept" HeaderText="Dept" SortExpression="dept" />
                        <asp:BoundField DataField="sect" HeaderText="Sect" SortExpression="sect" />
                        <asp:BoundField DataField="majortype" HeaderText="MajorType" SortExpression="majortype" />
                        <asp:TemplateField HeaderText="Status" SortExpression="recordno">
                      <%--  <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("recordno") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkBut1" runat="server" Font-Underline="True" ForeColor="Blue"
                          CommandArgument='<%# Eval("recordno", "{0}") %>' OnCommand="getDomWaste">Key in Weight</asp:LinkButton>
                            </ItemTemplate>
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
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT Safety_domesticwasteconsignment.empcode, Safety_domesticwasteconsignment.recordno, empmaster.empname, Safety_domesticwasteconsignment.dateapplied, Safety_domesticwasteconsignment.dept, Safety_domesticwasteconsignment.sect, Safety_domesticwasteconsignment.majortype, Safety_domesticwasteconsignment.status FROM Safety_domesticwasteconsignment INNER JOIN empmaster ON Safety_domesticwasteconsignment.empcode = empmaster.empcode">
</asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [recordno], [empcode], [dateapplied], [dept], [sect], [majortype], [status] FROM [Safety_domesticwasteconsignment]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [recordno], [Description], [Item], [Code], [oum], [measurement], [stdmeasurement], [controlspec] FROM [safety_schedulemaster] order by recordno desc">
                </asp:SqlDataSource>
                &nbsp; &nbsp;&nbsp;
            </td>
            <td align="left" style="width: 6100px; height: 249px" valign="top">
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" 
               
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource4" ForeColor="#333333"
                    GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="recordno" HeaderText="Rec. No" SortExpression="recordno" />
                        <asp:BoundField DataField="items" HeaderText="Items" SortExpression="items" />
                        <asp:BoundField DataField="code" HeaderText="Code" SortExpression="code" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [recordno], [items], [code] FROM [Safety_domesticwasteconsignmentdetails] WHERE recordno= @recordno">
                                        <SelectParameters>
           <asp:ControlParameter ControlID="GridView1" Name="recordno" />           
        </SelectParameters>                
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
