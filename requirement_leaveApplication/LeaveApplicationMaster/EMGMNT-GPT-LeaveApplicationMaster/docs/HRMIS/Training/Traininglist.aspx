<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Traininglist.aspx.vb" Inherits="E_Management.Traininglist" 
    title="Training List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table align=center >
        <tr>
            <td class="td_head" colspan="2" style="height: 21px; text-align: center">
                TRAINING PROGRAM</td>
        </tr>
        <tr>
            <td style="width: 115px">
                Department</td>
            <td style="width: 316px">
                <asp:DropDownList ID="CmbDepartment" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                    DataTextField="departmentname" DataValueField="departmentcode" Width="300px">
                </asp:DropDownList><br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                    ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT [departmentcode], [departmentname] FROM [department]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 115px">
                Section</td>
            <td style="width: 316px">
                <asp:DropDownList ID="CmbSection" runat="server" DataSourceID="SqlDataSource4" DataTextField="sectionname"
                    DataValueField="sectioncode" Width="300px">
                </asp:DropDownList><br />
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                    ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT [sectioncode], [sectionname] FROM [sectionmaster] WHERE ([departmentcode] = ?)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbDepartment" Name="departmentcode" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 115px">
                Training List Code</td>
            <td style="width: 316px">
                <asp:Label ID="lbl" runat="server"></asp:Label><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="code"
                    ErrorMessage="CODE !" ValidationGroup="a"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr>
            <td style="width: 115px">
                Training Title</td>
            <td style="width: 316px">
                <asp:DropDownList ID="titleddl" runat="server" DataSourceID="SqlDataSource2"
                    DataTextField="td_title" DataValueField="td_title" Width="300px" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 115px; height: 26px">
                Programme</td>
            <td align="left" style="width: 316px; height: 26px">
                <asp:DropDownList ID="CmbProgramme" runat="server" Width="300px">
                    <asp:ListItem>SAFETY</asp:ListItem>
                    <asp:ListItem>QUALITY</asp:ListItem>
                    <asp:ListItem>7S</asp:ListItem>
                    <asp:ListItem>COMPANY POLICIES</asp:ListItem>
                    <asp:ListItem>WORK PROCESS</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 115px; height: 26px">
                Method</td>
            <td align="left" style="width: 316px; height: 26px">
                <asp:DropDownList ID="CmbMethod" runat="server" Width="300px">
                    <asp:ListItem>THEORY</asp:ListItem>
                    <asp:ListItem>PRACTICAL</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 26px">
                Type</td>
            <td align="left" style="width: 316px; height: 26px">
                <asp:DropDownList ID="CmbType" runat="server" Width="300px">
                    <asp:ListItem>INTERNAL</asp:ListItem>
                    <asp:ListItem>EXTERNAL PROVIDER</asp:ListItem>
                    <asp:ListItem>PUBLIC TRAINING</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 26px;">
            </td>
            <td align="center" style="width: 316px; height: 26px;">
                <asp:Button ID="btnadd" runat="server" Text="ADD"/></td>
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
                    CellPadding="4" DataKeyNames="td_code" DataSourceID="SqlDataSource3"
                    GridLines="None" Width="433px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="td_code" HeaderText="Code" SortExpression="td_code" ReadOnly="True" />
                        <asp:BoundField DataField="td_title" HeaderText="Title" SortExpression="td_title" />
                        <asp:BoundField DataField="td_programme" HeaderText="Programme" SortExpression="td_programme" />
                        <asp:BoundField DataField="DepartmentCode" HeaderText="DepartmentCode" SortExpression="DepartmentCode" />
                        <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />
                        <asp:BoundField DataField="SectionCode" HeaderText="SectionCode" SortExpression="SectionCode" />
                        <asp:BoundField DataField="SectionName" HeaderText="SectionName" SortExpression="SectionName" />
                        <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method" />
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    </Columns>
                    <FooterStyle BackColor="ActiveCaption" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                    SelectCommand="SELECT DISTINCT td_title, td_programme, td_code, DepartmentCode, DepartmentName, SectionCode, SectionName, Method, Type FROM td_traininglist ORDER BY td_code, td_programme, td_title" 
                    DeleteCommand = "delete from [td_traininglist] where td_code = @td_code"
                    UpdateCommand = "update td_traininglist set td_title=@td_title, td_programme=@td_programme, DepartmentCode=@DepartmentCode, DepartmentName=@DepartmentName, SectionCode=@SectionCode, SectionName=@SectionName, Method=@Method, Type=@Type where td_code=@td_code" ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>">
                    <UpdateParameters>
                       <asp:Parameter Name="td_title" Type="String" />
                        <asp:Parameter Name="td_programme" Type="String" />       
                    </UpdateParameters>          
                </asp:SqlDataSource>
                &nbsp;
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_title] FROM [td_trainingtitles]"></asp:SqlDataSource>
          </td>
        </tr>
    </table>
</asp:Content>