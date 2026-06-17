<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="sectionmaster.aspx.vb" Inherits="E_Management.sectionmaster" 
    title="SECTION MASTER" %>
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
                <table>
                    <tbody>
                        <tr>
                            <td align="center" class="td_head" colspan="4">
                                <b>Enter Section Details </b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Section Code:</td>
                            <td>
                                <asp:TextBox ID="Tscode" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Tscode"
                                    Display="Dynamic" ErrorMessage="Enter Section Code" SetFocusOnError="True" ValidationGroup="vsection"
                                    Width="17px">* 
                                </asp:RequiredFieldValidator></td>
                            <td>
                                Section Name:</td>
                            <td>
                                <asp:TextBox ID="Tsname" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Tsname"
                                    Display="Dynamic" ErrorMessage="Enter Setion Name" ValidationGroup="vsection">* </asp:RequiredFieldValidator></td>
                        </tr>
                        <tr style="color: #000000">
                            <td>
                                Department Code:</td>
                            <td>
                                <asp:DropDownList ID="Dsdeptcode" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDepartment"
                                    DataTextField="departmentname" DataValueField="departmentcode" Font-Size="X-Small">
                                    <asp:ListItem Selected="True">Please Select a Value</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Dsdeptcode"
                                    Display="Dynamic" ErrorMessage="Select Department" InitialValue="Please Select a Value"
                                    SetFocusOnError="True" ValidationGroup="vsection">* </asp:RequiredFieldValidator></td>
                            <td>
                                AQIS Approval Department</td>
                            <td>
                                <asp:DropDownList ID="dsaqis" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDepartment"
                                    DataTextField="departmentname" DataValueField="departmentcode" Font-Size="X-Small">
                                    <asp:ListItem Selected="True">Please Select a Value</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="dsaqis"
                                    Display="Dynamic" ErrorMessage="Select Department" InitialValue="Please Select a Value"
                                    SetFocusOnError="True" ValidationGroup="vsection">* </asp:RequiredFieldValidator></td>
                        </tr>
                        <tr style="color: #000000">
                            <td colspan="4">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="bsave_section" runat="server" SkinID="buttonskin1" Text="Save" ValidationGroup="vsection" />&nbsp; 
                                <asp:Button ID="Button51" runat="server" SkinID="buttonskin1" Text="Exit" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:GridView ID="grdsection" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" AutoGenerateEditButton="True"
                    CellPadding="4" CellSpacing="2" DataKeyNames="sectioncode" DataSourceID="Sqlsect"
                    ForeColor="#333333" GridLines="None" PageSize="15">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="sectioncode" HeaderText="SectionCode" ReadOnly="True"
                            SortExpression="sectioncode" />
                        <asp:BoundField DataField="sectionname" HeaderText="Sectionname" SortExpression="sectionname" />
                        <asp:BoundField DataField="departmentcode" HeaderText="departmentcode" SortExpression="departmentcode" ReadOnly="True" />
                        <asp:BoundField DataField="aqisdept" HeaderText="aqisdept" SortExpression="aqisdept" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="Sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectionname], [sectioncode], [departmentcode], [aqisdept] FROM [sectionmaster]"
                    UpdateCommand="update sectionmaster set sectionname=@sectionname,departmentcode=@departmentcode,aqisdept=@aqisdept&#13;&#10; where sectioncode=@sectioncode"
                    DeleteCommand = "delete from sectionmaster where sectioncode=@sectioncode">  
                    <UpdateParameters>
                        <asp:Parameter Name="sectioncode" Type="string" />
                        <asp:Parameter Name="sectionname" Type="string" />
                        <asp:Parameter Name="departmentcode" Type="string" />
                        <asp:Parameter Name="aqisdept" Type="string" />
                    </UpdateParameters>
                    <DeleteParameters>
                                <asp:Parameter Name = "sectioncode" Type = string />
                                </DeleteParameters>
                </asp:SqlDataSource>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
     <asp:SqlDataSource ID="SqlDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT [departmentcode], [departmentname], [japanhead], ltrim(rtrim(office)) as office, [section], [prefix] FROM [department] ORDER BY [Recordno] DESC"
                                                 UpdateCommand = "MIS_UPDdepartment_NEW" UpdateCommandType=StoredProcedure
                                                 DeleteCommand =" delete from department where departmentcode = @departmentcode"                                               >
                                            <UpdateParameters>
                                                      <asp:Parameter Name="departmentcode"  Type="String" />
                                                      <asp:parameter Name ="departmentname" Type = "string" />
                                                      <asp:parameter Name ="japanhead" Type = "string" />
                                                      <asp:parameter Name ="office" Type = "string" />
                                                      <asp:parameter Name ="section" Type = "string" />
                                                      <asp:parameter Name ="prefix" Type = "string" />
                                                      <asp:parameter Name ="cby" Type = "string" DefaultValue= "014543" />                                                          
                                                      
                                             </UpdateParameters>
                                        <DeleteParameters>
                                            <asp:Parameter name = "departmentcode" Type="string"  />                                            
                                        </DeleteParameters>
                                        </asp:SqlDataSource>
</asp:Content>
