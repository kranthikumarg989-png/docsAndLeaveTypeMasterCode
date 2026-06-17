<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="SkillMaster.aspx.vb" Inherits="E_Management.SkillMaster" 
    title="Skill Master" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table align=center style="width: 326px" >
        <tr>
            <td class="td_head" colspan="2">
                SKILL MASTER</td>
        </tr>
        <tr>
            <td style="width: 91px">
                Skill Code</td>
            <td style="width: 225px">
                <asp:TextBox ID="td_skillcode" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="td_skillcode"
                    ErrorMessage="CODE !" ValidationGroup="a"></asp:RequiredFieldValidator><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="code"
                    ErrorMessage="CODE !" ValidationGroup="a"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr>
            <td style="width: 91px">
                Skill Title</td>
            <td style="width: 225px">
                <asp:TextBox ID="td_skilltitle" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="td_skilltitle"
                    ErrorMessage="TITLE !" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 91px">
            </td>
            <td align="center" style="width: 225px">
                <asp:Button ID="btnadd" runat="server" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; height: 17px;">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" AutoGenerateEditButton="True" DataKeyNames="td_skillcode" 
                    CellPadding="4" DataSourceID="SqlDataSource2"
                    GridLines="None" Width="318px" >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="td_skillcode" HeaderText="Skill Code" SortExpression="td_skillcode" ReadOnly="True" />
                        <asp:BoundField DataField="td_skilltitle" HeaderText="Skill Title" SortExpression="td_skilltitle" />
                    </Columns>
                    <FooterStyle BackColor="ActiveCaption" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_skillcode], [td_skilltitle] FROM [td_skillmaster] ORDER BY [td_skillcode], [td_skilltitle]"
                    DeleteCommand = "delete from [td_skillmaster] where td_skillcode = @td_skillcode"
                    UpdateCommand = "update td_skillmaster set td_skilltitle=@td_skilltitle where td_skillcode=@td_skillcode">
                    <UpdateParameters>
                       <asp:Parameter Name="td_skillcode" Type="String" />
                        <asp:Parameter Name="td_skilltitle" Type="String" />       
                    </UpdateParameters>          
                </asp:SqlDataSource>
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