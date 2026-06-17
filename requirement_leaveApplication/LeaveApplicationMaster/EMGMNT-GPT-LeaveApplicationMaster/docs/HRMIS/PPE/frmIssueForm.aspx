<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" Codebehind="frmIssueForm.aspx.vb"
    Inherits="E_Management.frmIssueForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <script language="javascript" type="text/javascript">
  function winOpen(Issueno)
           {
//           alert("wel");
//           alert(Issueno);
            PrintIssueForm= window.open('frmRptIssueForm.aspx?IssueNo='+Issueno,'IssueForm','height=600,width=990,scrollbars=yes,resizable=yes');
            if(window.focus)
             {
             PrintIssueForm.focus();              
             }    
              return false;
           }   


    </script>

    <table cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16" style="width: 447px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" width="16" style="height: 100px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 100px">
                <table cellpadding="0" cellspacing="0" style="width: 700px">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label8" runat="server" ForeColor="DarkRed" Font-Bold="True" Font-Size="12pt"
                                            Text="PPE Issue Form" Font-Underline="False"></asp:Label></td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Issue No.
                                    </td>
                                    <td style="width: 178px">
                                        <asp:Label ID="lblIssueno" runat="Server" ForeColor="Blue"></asp:Label>
                                    </td>
                                    <td style="width: 86px">
                                        Issued Dept
                                    </td>
                                    <td>
                                        <%-- <asp:Label ID="lblDept" runat="Server"></asp:Label>--%>
                                        <asp:DropDownList ID="ddlDept" runat="Server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Issued to</td>
                                    <td style="width: 178px">
                                        <asp:TextBox ID="txtIssuedTo" runat="server" AutoPostBack="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvRate" runat="server" ErrorMessage="*" ControlToValidate="txtIssuedTo"
                                            ValidationGroup="val"></asp:RequiredFieldValidator></td>
                                    <td style="width: 86px">
                                        Name</td>
                                    <td>
                                        <asp:Label ID="lblName" runat="Server"></asp:Label></td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Category</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Group</td>
                                    <td>
                                        <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Item</td>
                                    <td>
                                        <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Type</td>
                                    <td>
                                        <asp:RadioButtonList ID="rbtnOption" runat="Server" RepeatDirection="Horizontal" AutoPostBack="True">
                                            <asp:ListItem>First</asp:ListItem>
                                            <asp:ListItem>Replace</asp:ListItem>
                                            <asp:ListItem Selected="True">Reissue</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Rate</td>
                                    <td>
                                        <asp:TextBox ID="txtRate" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        Available Stock</td>
                                    <td>
                                        <asp:TextBox ID="txtAstock" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td>
                                        Qty</td>
                                    <td>
                                        <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvQty" runat="server" ErrorMessage="*" ControlToValidate="txtQty"
                                            ValidationGroup="val"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revQty" runat="server" ControlToValidate="txtQty"
                                            ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="val"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        Amount</td>
                                    <td>
                                        <asp:TextBox ID="txtAmount" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" ValidationGroup="val" />
                                        <%--    <asp:Button ID="btnExit" runat="server" Text="Exit" />--%>
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label1" runat="server" ForeColor="Teal" Font-Bold="True" Font-Size="12pt"
                                            Text="Added Items" Font-Underline="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvAddedItem" runat="server" ForeColor="#333333" CellPadding="4"
                                            AutoGenerateColumns="False" PageSize="12" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" CommandArgument=' <%# Container.DataItemIndex + 1 %>'
                                                            CommandName="DeleteRow" ForeColor="blue"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
                                                <asp:BoundField DataField="Group" HeaderText="Group"></asp:BoundField>
                                                <asp:BoundField DataField="Item" HeaderText="Item"></asp:BoundField>
                                                <asp:BoundField DataField="Rate" HeaderText="Rate"></asp:BoundField>
                                                <asp:BoundField DataField="Qty" HeaderText="Qty" FooterText="Grand Total"></asp:BoundField>
                                                <%--  <asp:BoundField DataField="Amount" HeaderText="Amount"></asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("Amount")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnOption" runat="server" Value='<%# Bind("Option") %>' />
                                                        <asp:HiddenField ID="hdnAstock" runat="server" Value='<%# Bind("Astock") %>' />
                                                        <asp:HiddenField ID="hdnAbnormal" runat="Server" Value='<%# Bind("Abnormal") %>' />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotAmt" runat="server"></asp:Label>
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
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnSave" runat="server" Text="Save & Print" Visible="false" />
                                    </td>
                                </tr>
                                <tr height="5">
                                </tr>
                                <%--           <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label2" runat="server" ForeColor="Teal" Font-Bold="True" Font-Size="12pt"
                                            Text="Previously Added Data" Font-Underline="False"></asp:Label>
                                    </td>
                                </tr>
                           <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvItemGroup" runat="server" ForeColor="#333333" CellPadding="4"
                                            AutoGenerateColumns="False" AllowPaging="True" PageSize="12">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl No.">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
                                                <asp:BoundField DataField="ItemGroup" HeaderText="Group"></asp:BoundField>
                                                <asp:BoundField DataField="ItemDesc" HeaderText="Item"></asp:BoundField>
                                                <asp:BoundField DataField="Rate" HeaderText="Rate"></asp:BoundField>
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
                                </tr>--%>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 100px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 447px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
