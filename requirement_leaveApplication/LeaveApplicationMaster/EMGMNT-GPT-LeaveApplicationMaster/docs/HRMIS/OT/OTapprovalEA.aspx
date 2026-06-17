<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OTapprovalEA.aspx.vb" Inherits="E_Management.OTapprovalEA" 
    title="EA OT Approval" %>
    <%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE2_onclick() {

}

// ]]>
</script>
                   &nbsp;<asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon"
                    Text="OT BUDGET PENDING APPROVAL"></asp:Label>&nbsp;<table>
            <tr>
                <td colspan="2" align="left">
                    <asp:GridView runat="server" ID="EAOTapproval" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource4" EmptyDataText="No OT claim waiting for Approvals"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" PageSize="25" Width="538px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle" Width="350px" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
            <asp:BoundField DataField="startdate" HeaderText="StartDate" SortExpression="startdate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
            <asp:BoundField DataField="enddate" HeaderText="EndDate" SortExpression="enddate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
            <asp:BoundField DataField="Sect" HeaderText="Sect" SortExpression="Sect" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="MaxHours" HeaderText="MaxHours" SortExpression="MaxHours" />
                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:RadioButtonList ID="OTapprovalStat" runat="server" SelectedValue='<%# Bind("status") %>'>
                                    <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                    <asp:ListItem Value="A">Approve</asp:ListItem>
                                    <asp:ListItem Value="R">Reject</asp:ListItem>
                                </asp:RadioButtonList>
                                     </ItemTemplate>                      
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateOTapproval" Text="SUBMIT" />
                            </FooterTemplate>
                               
                            
                        </asp:TemplateField>
            
                               
                            </Columns>
        <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                       
                </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 967px" colspan="2">
                </td>
            </tr>
        </table>
                <cc1:ModalPopupExtender ID="rathimpe" runat="server" BackgroundCssClass="modalBackground"
                    DropShadow="false" EnableViewState="False" OkControlID="okbutton" PopupControlID="pnlgphistory"
                    PopupDragHandleControlID="pnlgphistory" TargetControlID="btnShowModalPopup">
                </cc1:ModalPopupExtender>
    
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [id], [startdate], [enddate], [sect], [Category], [MaxHours], [status] FROM [tbl_MaxOTSetting] where status='s'">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

<asp:Button ID="btnShowModalPopup" runat="server" SkinID="buttonskin1" Style="display: none" /><br />
         </asp:Content>
       