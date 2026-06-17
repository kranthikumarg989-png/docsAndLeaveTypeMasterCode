<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="areamaster.aspx.vb" Inherits="E_Management.areamaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table align=center style="width: 326px" >
        <tr>
            <td class="td_head" colspan="2">
                AREA MASTER</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Route
            </td>
            <td style="width: 124px">
                <asp:DropDownList ID="ddlroute" runat="server" DataSourceID="Sqlarea" DataTextField="route"
                    DataValueField="route" AppendDataBoundItems="True">
                    <asp:ListItem Value="-1" Selected="True">-Select Area-</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlroute"
                    ErrorMessage="Select Route" InitialValue="-1" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="Sqlarea" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT  [route] FROM [trans_routemaster] ORDER BY [route]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                Area</td>
            <td style="width: 124px">
                <asp:TextBox ID="txtarea" runat="server" Width="121px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtarea"
                    ErrorMessage="Enter Area" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td align="right" style="width: 124px">
                <asp:Button ID="btnadd" runat="server" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlGRDAREA" ForeColor="#333333" Width="100%" AllowPaging="True" AllowSorting="True" PageSize="15" AutoGenerateEditButton="True" DataKeyNames="codearea">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
                        <asp:BoundField DataField="route" HeaderText="Route" ReadOnly="True" SortExpression="route" />
                     </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlGRDAREA" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [area], [route],codearea FROM [trans_areamaster] ORDER BY [codearea] desc"
                    DeleteCommand = "delete from [trans_areamaster] where codearea = @codearea"
                    UpdateCommand = "HRMIS_TRANSPORT_UPDATEAREA" UpdateCommandType=StoredProcedure  >
                    <UpdateParameters>
                        <asp:Parameter Name=route Type=String />
                        <asp:Parameter Name=area Type=String />
                        <asp:Parameter Name=codearea Type=String />   
                        <asp:SessionParameter Name=empcode SessionField=empcode />           
                    </UpdateParameters>                  
                </asp:SqlDataSource>
          </td>
        </tr>
    </table>
</asp:Content>
