<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CategoryMaster.aspx.vb" Inherits="E_Management.CategoryMaster" 
    title="Untitled Page" %>
       <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table align="center" >
        <tr>
            <td class="td_head" colspan="2">
                TRAINING CATEGORY MASTER</td>
        </tr>
        <tr>
            <td style="width: 175px">
                Category &nbsp;Code</td>
            <td style="width: 289px">
                &nbsp;<asp:Label ID="lbl" runat="server"></asp:Label><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="code"
                    ErrorMessage="CODE !" ValidationGroup="a"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr>
            <td style="width: 175px">
                Category Description</td>
            <td style="width: 289px">
                <asp:TextBox ID="description" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="description"
                    ErrorMessage="DESCRIPTION !" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 175px">
            </td>
            <td align="center" style="width: 289px">
                <asp:Button ID="btnadd" runat="server" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; height: 15px;">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" AutoGenerateEditButton="True"
                    CellPadding="4" DataKeyNames="categorycode" DataSourceID="SqlDataSource2"
                    GridLines="None" Width="467px" HorizontalAlign="Center">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="categorycode" HeaderText="Category Code" SortExpression="categorycode" />
                        <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                    </Columns>
                    <FooterStyle BackColor="ActiveCaption" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [categorycode], [description] FROM [td_categorymaster] ORDER BY [categorycode], [description]"
                     DeleteCommand = "delete from [td_categorymaster] where categorycode = @categorycode"
                    UpdateCommand = "update td_categorymaster set description=@description where categorycode=@categorycode">
                    <UpdateParameters>
                       <asp:Parameter Name="categorycode" Type="String" />
                        <asp:Parameter Name="description" Type="String" />       
                    </UpdateParameters>     
                </asp:SqlDataSource>
                &nbsp;&nbsp;
          </td>
        </tr>
    </table>
</asp:Content>
