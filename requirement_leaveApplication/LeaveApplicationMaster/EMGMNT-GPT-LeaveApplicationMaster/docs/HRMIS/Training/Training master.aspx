<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Training master.aspx.vb" Inherits="E_Management.Training_master" Title="Training Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table align=center style="width: 326px" >
        <tr>
            <td class="td_head" colspan="2">
                TRAINING MASTER</td>
        </tr>
        <tr>
            <td style="width: 91px">
                Training Code</td>
            <td style="width: 124px">
                &nbsp;<asp:Label ID="lbl" runat="server"></asp:Label><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="code"
                    ErrorMessage="CODE !" ValidationGroup="a"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr>
            <td style="width: 91px">
                Training Title</td>
            <td style="width: 124px">
                <asp:TextBox ID="tit" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tit"
                    ErrorMessage="TITLE !" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 91px">
            </td>
            <td align="center" style="width: 124px">
                <asp:Button ID="btnadd" runat="server" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" AutoGenerateEditButton="True"
                    CellPadding="4" DataKeyNames="td_code" DataSourceID="SqlDataSource1"
                    GridLines="None" Width="318px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:TemplateField HeaderText="Training Code" SortExpression="td_code">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("td_code") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("td_code") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="td_title" HeaderText="Training Title" SortExpression="td_title" />
                    </Columns>
                    <FooterStyle BackColor="ActiveCaption" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [td_code], [td_title] FROM [td_trainingtitles] ORDER BY [td_code], [td_title]"
                    DeleteCommand = "delete from [td_trainingtitles] where td_code = @td_code"
                    UpdateCommand = "update td_trainingtitles set td_title=@td_title where td_code=@td_code">
                    <UpdateParameters>
                       <asp:Parameter Name="td_code" Type="String" />
                        <asp:Parameter Name="td_title" Type="String" />       
                    </UpdateParameters>          
                </asp:SqlDataSource>
          </td>
        </tr>
    </table>
</asp:Content>
