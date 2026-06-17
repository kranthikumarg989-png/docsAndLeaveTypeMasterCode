<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="GroupMaster.aspx.vb" Inherits="E_Management.GroupMaster" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td align="center" colspan="2" class="td_head">
               Foreign Employee In</td>
        </tr>
        <tr>
            <td style="height: 24px">
                Group Code</td>
            <td style="height: 24px">
                <asp:TextBox ID="txtgroupcode" runat="server" Width="144px" ReadOnly="True"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ControlToValidate="txtgroupcode"
                    ErrorMessage="!" SetFocusOnError="True"
                    ValidationGroup="vforeign">* </asp:RequiredFieldValidator>--%>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 23px">
                Group Name</td>
            <td style="height: 23px">
                <asp:TextBox ID="txtgname" runat="server" Width="144px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtgname"
                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="vforeign">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Foreign Employee </td>
            <td>
                <asp:TextBox ID="ttotfemp" runat="server" Width="144px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ttotfemp"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="vforeign"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="height: 26px">
                <asp:Button ID="bsave_foreign" runat="server" Text="Save" ValidationGroup="vforeign" SkinID="buttonskin1" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="height: 26px">
                <asp:GridView ID="GridView1" DataKeyNames=rno runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" AutoGenerateEditButton="True"
                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="groupcode" HeaderText="Groupcode" SortExpression="groupcode" ReadOnly="True" />
                        <asp:BoundField DataField="groupname" HeaderText="Groupname" SortExpression="groupname" />
                        <asp:BoundField DataField="foreignemp" HeaderText="Foreignemp" SortExpression="foreignemp" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [groupcode], [groupname], [foreignemp], [rno] FROM [groupmaster] ORDER BY [rno] DESC"
                     UpdateCommand ="hrmis_pv_grpupd" UpdateCommandType=StoredProcedure
                      DeleteCommand ="delete from groupmaster where rno=@rno" >
                     <UpdateParameters>
                     <asp:Parameter Name= groupcode Type=string />
                     <asp:Parameter Name= groupname Type=string />
                     <asp:Parameter Name= foreignemp Type=string />
                     <asp:SessionParameter Name = mby SessionField=empname Type=string />
                     
                     </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
