<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ManPowerDistribution.aspx.vb" Inherits="E_Management.ManPowerDistribution" 
    title="MMSB Manpower Distribution" %>
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

<table id="TABLE2" style="width: 450px">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 445px; height: 21px; text-align: center;">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="MMSB MANPOWER DISTRIBUTION"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 445px; text-align: left;" valign="top" align="left">
                <asp:Panel ID="Panel2" runat="server" GroupingText="Key in all the Values">
                            <asp:Panel ID="Panel1" runat="server" Width="450px">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1" style="width: 444px; border-right: #cccccc 1px solid; border-top: #cccccc 1px solid; border-left: #cccccc 1px solid; border-bottom: #cccccc 1px solid;"><tr>
                    <td style="width: 98px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label></td>
                    <td style="height: 26px;" valign="top" align="left" colspan="3">
                        <asp:DropDownList ID="dept_ddl" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode"
                            Width="250px">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dept_ddl"
                            ErrorMessage="!" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 26px; background-color: beige" valign="top">
                        <asp:Label ID="Label14" runat="server" Text="Section" Width="113px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top" colspan="3">
                        <asp:DropDownList ID="mcno_ddl" runat="server" AutoPostBack="True"
                            Width="250px" DataSourceID="SqlDataSource3" DataTextField="section" DataValueField="sectioncode">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="mcno_ddl" ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 98px; background-color: beige; height: 11px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Operator" Width="102px"></asp:Label></td>
                        <td valign="top" align="left">
                            <asp:TextBox ID="opt" runat="server" AutoPostBack="True" Width="50px">0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="opt"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="opt"
                                ErrorMessage="Only Nos.!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="82px"></asp:RegularExpressionValidator></td>
                        <td align="left" valign="top" style="background-color: beige">
                        <asp:Label ID="Label15" runat="server" Text="staff" Width="73px"></asp:Label></td>
                        <td align="left" style="height: 11px" valign="top">
                            <asp:TextBox ID="staff" runat="server" AutoPostBack="True" Width="58px">0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="staff"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="R11" runat="server" ControlToValidate="staff"
                                ErrorMessage="Only Nos.!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="80px"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 11px; background-color: beige" valign="top">
                            Total</td>
                        <td align="left" colspan="3" style="height: 11px" valign="top">
                            <asp:Label ID="mptotal" runat="server" BackColor="Yellow">0</asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 11px; background-color: beige" valign="top" colspan="4">
                            <asp:Button ID="Button2" runat="server" Text="ADD" ValidationGroup="b" /></td>
                    </tr>
                </table>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Font-Bold="True" Font-Size="Small"></asp:Label></asp:Panel>
                </asp:Panel>
                <br />
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="firstgrid"
                    ForeColor="#333333" ShowFooter="True" Width="450px" AutoGenerateDeleteButton="True" DataKeyNames=sno>
                    <Columns>
                        <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" />
                        <asp:BoundField DataField="Sect" HeaderText="Sect" SortExpression="Sect" />
                        <asp:BoundField DataField="opt" HeaderText="Operatot" SortExpression="opt" />
                        <asp:TemplateField HeaderText="Staff" SortExpression="staff">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("staff") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("staff") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total" SortExpression="total">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="ADDManpower" Text="SAVE" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                </asp:GridView>
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT ( [departmentcode] +'-'+ [departmentname]) as dept ,departmentcode FROM [department] ORDER BY [departmentcode], [departmentname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server"></asp:SqlDataSource>
                <asp:SqlDataSource ID="firstgrid" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM [EMS_mancounttemp]"
                     DeleteCommand ="delete from [EMS_mancounttemp] where sno =@sno">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT sectioncode +'-'+ sectionname as section,sectioncode  FROM sectionmaster WHERE (departmentcode = @dept)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dept_ddl" Name="dept" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
             
    
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