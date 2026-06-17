<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerVisitApprovalForm.aspx.vb" Inherits="E_Management.CustomerVisitApprovalForm" MasterPageFile="~/ems.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img alt="" height="16" src="../../images/top_lef.gif" width="16"/></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img alt ="" height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;" >
                <img height="16" src="../../images/top_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" alt="" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 250px;">
                            <asp:Panel ID="Panel1" runat="server">                                         
                            
                            
                            
                            
                            <table border="0">
                                <tr>
                                    <td style="background-color: #6699ff">
                                        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Customer Visit - Approval Form"
                                            Width="800px" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"  onselectedindexchanged="Fun1" Visible="False" OnRowEditing="FunEdit">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="UID" HeaderText="ReferenceNo" ReadOnly="True" SortExpression="UID" />
                                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="True"
                                            SortExpression="CustomerName" />
                                                <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="True" SortExpression="Department" />
                                                <asp:BoundField DataField="PurposeofVisit" HeaderText="Purpose" ReadOnly="True" SortExpression="PurposeofVisit" />
                                                <asp:BoundField DataField="VisitFrom" HeaderText="VisitFrom" SortExpression="VisitFrom" />
                                                <asp:BoundField DataField="VisitTo" HeaderText="VisitTo" ReadOnly="True" SortExpression="VisitTo" />
                                                <asp:BoundField DataField="NoofDays" HeaderText="NoofDays" ReadOnly="True" SortExpression="NoofDays" />
                                                <asp:BoundField DataField="RequestedBy" HeaderText="RequestedBy" ReadOnly="True"
                                            SortExpression="RequestedBy" />
                                                <asp:CommandField SelectText="Approve" ShowSelectButton="True" />
                                                <asp:CommandField EditText="View" ShowEditButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                                <br /><br />
                                <table border="0">
                                    <tr>
                                        <td style="background-color: #6699ff; height: 21px;">
                                            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Customer Visit - Acknowledgement"
                                                Width="800px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"  onselectedindexchanged="Fun2"  OnRowEditing="FunEdit2">
                                                <RowStyle BackColor="#EFF3FB" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="UID" HeaderText="ReferenceNo" ReadOnly="True" SortExpression="UID" />
                                                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="True"
                                            SortExpression="CustomerName" />
                                                    <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="True" SortExpression="Department" />
                                                    <asp:BoundField DataField="PurposeofVisit" HeaderText="Purpose" ReadOnly="True" SortExpression="PurposeofVisit" />
                                                    <asp:BoundField DataField="VisitFrom" HeaderText="VisitFrom" SortExpression="VisitFrom" />
                                                    <asp:BoundField DataField="VisitTo" HeaderText="VisitTo" ReadOnly="True" SortExpression="VisitTo" />
                                                    <asp:BoundField DataField="NoofDays" HeaderText="NoofDays" ReadOnly="True" SortExpression="NoofDays" />
                                                    <asp:BoundField DataField="RequestedBy" HeaderText="RequestedBy" ReadOnly="True"
                                            SortExpression="RequestedBy" />
                                                    <asp:CommandField SelectText="Acknowledge" ShowSelectButton="True" />
                                                    <asp:CommandField EditText="View" ShowEditButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                            </table>
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                   </asp:Panel>
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" alt="" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
    </table>



</asp:Content>