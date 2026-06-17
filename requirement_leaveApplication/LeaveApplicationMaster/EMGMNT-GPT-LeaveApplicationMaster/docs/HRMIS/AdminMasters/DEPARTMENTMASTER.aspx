<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="DEPARTMENTMASTER.aspx.vb" Inherits="E_Management.DEPARTMENTMASTER" 
    title="DEPARTMENT MASTER" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 725px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 725px" valign="top">
                <table style="width: 685px">
                    <tr>
                        <td align="center" class="td_head" colspan="4">
                            <b>Enter Department Details </b>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" valign="top">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="fill in Required fields"
                                Height="42px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 132px; background-color: beige">
                            Department Code:</td>
                        <td style="width: 183px">
                            <asp:TextBox ID="Tdeptcode" runat="server" Width="145px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Tdeptcode"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="vdepartment">* </asp:RequiredFieldValidator></td>
                        <td style="width: 142px; color: #000000; background-color: beige">
                            Department Name:</td>
                        <td>
                            <asp:TextBox ID="TDeptname" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TDeptname"
                                Display="Dynamic" ErrorMessage="enter Department Name" ValidationGroup="vdepartment">* </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="width: 132px; background-color: beige">
                            Got Japanese Head:</td>
                        <td style="width: 183px">
                            <asp:DropDownList ID="dJhead" runat="server" Font-Size="X-Small">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 142px; background-color: beige">
                            Direct/Indirect Dept</td>
                        <td>
                            <asp:DropDownList ID="Ddirect" runat="server" Font-Size="X-Small">
                                <asp:ListItem Value="P">Direct</asp:ListItem>
                                <asp:ListItem Value="O">Indirect</asp:ListItem>
                            </asp:DropDownList>&nbsp;<br />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <%--<tr>
                             <td colspan=4 style="background-color:LightGoldenrodYellow" align=center><b>Request Time (Expected Time)</b></td>            
                             </tr>--%>
                    <tr>
                        <td style="width: 132px; background-color: beige">
                            Got Sections</td>
                        <td style="width: 183px">
                            <asp:DropDownList ID="dsection" runat="server" Font-Size="X-Small">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 142px; background-color: beige">
                            General Abbrevations</td>
                        <td>
                            <asp:TextBox ID="tdabbrevation" runat="server" Width="120px"></asp:TextBox>(Extrusion
                            - EX)<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tdabbrevation"
                                Display="Dynamic" ErrorMessage="enter Abbrevations" ValidationGroup="vdepartment">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige" colspan="4">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="border-top: beige 1px solid; height: 10px">
                            <asp:Button ID="Bdept_save" runat="server" CausesValidation="true" SkinID="buttonskin1"
                                Text="Save" ValidationGroup="vdepartment" />&nbsp;
                            <asp:Button ID="Button32" runat="server" SkinID="buttonskin1" Text="Exit" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="border-top: beige 1px solid; height: 15px">
                            <asp:GridView ID="grddepartment" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" AutoGenerateEditButton="True"
                                CellPadding="4" CellSpacing="2" DataKeyNames="departmentcode" DataSourceID="SqlDepartment"
                                ForeColor="#333333" GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                                    <asp:BoundField DataField="departmentcode" HeaderText="DepartmentCode" ReadOnly="True"
                                        SortExpression="departmentcode" />
                                    <asp:BoundField DataField="departmentname" HeaderText="DepartmentName" SortExpression="departmentname" />
                                    <asp:TemplateField HeaderText="JapanHead" SortExpression="japanhead">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("japanhead") %>'>
                                                <asp:ListItem Value="Y">YES</asp:ListItem>
                                                <asp:ListItem Value="N">NO</asp:ListItem>
                                            </asp:DropDownList>&nbsp;
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("japanhead") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="office" SortExpression="office">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("office") %>'>
                                                <asp:ListItem Value="P">Direct</asp:ListItem>
                                                <asp:ListItem Value="O">Indirect</asp:ListItem>
                                            </asp:DropDownList>&nbsp;
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("office") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Got Section" SortExpression="section">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("section") %>'>
                                                <asp:ListItem Value="Y">YES</asp:ListItem>
                                                <asp:ListItem Value="N">NO</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("section") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="prefix" HeaderText="Prefix" SortExpression="prefix" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                DeleteCommand=" delete from department where departmentcode = @departmentcode"
                                SelectCommand="SELECT [departmentcode], [departmentname], [japanhead], ltrim(rtrim(office)) as office, [section], [prefix] FROM [department] ORDER BY [Recordno] DESC"
                                UpdateCommand="MIS_UPDdepartment_NEW" UpdateCommandType="StoredProcedure">
                                <UpdateParameters>
                                    <asp:Parameter Name="departmentcode" Type="String" />
                                    <asp:Parameter Name="departmentname" Type="string" />
                                    <asp:Parameter Name="japanhead" Type="string" />
                                    <asp:Parameter Name="office" Type="string" />
                                    <asp:Parameter Name="section" Type="string" />
                                    <asp:Parameter Name="prefix" Type="string" />
                                    <asp:Parameter DefaultValue="014543" Name="cby" Type="string" />
                                </UpdateParameters>
                                <DeleteParameters>
                                    <asp:Parameter Name="departmentcode" Type="string" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td style="height: 16px" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" style="width: 725px; height: 16px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>

</asp:Content>
