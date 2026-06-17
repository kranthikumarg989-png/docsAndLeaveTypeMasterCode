<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTvisaentry.aspx.vb" Inherits="E_Management.BTvisaentry" 
 StylesheetTheme="buttonems" %>
 <%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="border-right: steelblue 1px solid; border-top: steelblue 1px solid; border-left: steelblue 1px solid; border-bottom: steelblue 1px solid" >
        <tr>
            <td align="center" colspan="4" class="td_head" >
              Enter Your Business Type visa Master Details Below
            </td>
        </tr>
        <tr>
            <td style="height: 4px; background-color: beige;">
                Empcode</td>
            <td style="height: 4px;">
                <asp:TextBox ID="tbtempcode" runat="server" AutoPostBack="True" Width="80px" BackColor="#FFFF80"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbtempcode"
                    Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                    ValidationGroup="vbusinesstype">* Required Field</asp:RequiredFieldValidator>
                <%--<asp:LinkButton ID="lbempid" runat="server" Visible="False" OnClientClick ="Getempid(tbtempcode.text);">LinkButton</asp:LinkButton>--%>
            </td>
            <td style="width: 88px; background-color: beige;">
                Name</td>
            <td bgcolor="#ffffff" style="height: 4px">
                <asp:Label ID="lblname" runat="server" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 4px; background-color: beige;">
                Department</td>
            <td bgcolor="#ffffff" style="width: 241px; height: 17px;">
                <asp:Label ID="lbtdept" runat="server" ForeColor="Maroon"></asp:Label></td>
            <td style="width: 88px; background-color: beige;">
                Section</td>
            <td bgcolor="#ffffff" style="height: 17px">
                <asp:Label ID="lbtsection" runat="server" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 4px; background-color: beige;">
                Designation</td>
            <td bgcolor="#ffffff" style="width: 241px; height: 20px">
                <asp:Label ID="lbtdesig" runat="server" ForeColor="Maroon"></asp:Label></td>
            <td style="width: 88px; background-color: beige;">
                Passport</td>
            <td bgcolor="#ffffff" style="height: 20px">
                <asp:Label ID="lbtpassport" runat="server" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 4px; background-color: beige;">
                Nationality</td>
            <td bgcolor="#ffffff" style="width: 241px">
                <asp:Label ID="lbtnation" runat="server" ForeColor="Maroon"></asp:Label></td>
            <td style="width: 88px; background-color: beige;">
                Visa for country</td>
            <td>
                <asp:DropDownList ID="dcountry" runat="server" AppendDataBoundItems="true" DataSourceID="country"
                    DataTextField="countryname" DataValueField="countryname" Width="168px">
                    <asp:ListItem Selected="True" Value="-1">Please Select a Value</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="dcountry"
                    Display="Dynamic" ErrorMessage="*" InitialValue="-1"
                    ValidationGroup="vbusinesstype"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 4px; background-color: beige;">
                Visa type</td>
            <td style="width: 241px">
                <asp:DropDownList ID="Dbtvisatype" runat="server" Font-Bold="True" Font-Size="X-Small"
                    Width="88px">
                    <asp:ListItem Value="B">Business</asp:ListItem>
                    <asp:ListItem Value="T">Tourist</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 88px; background-color: beige;">
                Journey Type</td>
            <td>
                <asp:DropDownList ID="DJourneytype" runat="server" Font-Bold="True" Font-Size="X-Small">
                    <asp:ListItem Value="S">Single entry</asp:ListItem>
                    <asp:ListItem Value="M">Multiple entry</asp:ListItem>
                    <asp:ListItem Value="D">Double</asp:ListItem>
                    <asp:ListItem Value="T">Triple</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 4px; background-color: beige;">
                visa period</td>
            <td style="width: 241px; height: 19px">
                <asp:TextBox ID="Tbtvisaperiod" runat="server" Width="72px"></asp:TextBox>
                (in Months)<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                    ControlToValidate="Tbtvisaperiod" Display="Dynamic" ErrorMessage="RequiredFieldValidator"
                    SetFocusOnError="True" ValidationGroup="vbusinesstype">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Tbtvisaperiod"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="b"></asp:RegularExpressionValidator></td>
            <td style="width: 88px; background-color: beige;">
                Expiry on</td>
            <td style="height: 19px">
                <asp:TextBox ID="TbtVexpiry" runat="server" Width="80px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TbtVexpiry"
                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" ValidationGroup="vbusinesstype">* </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" bordercolor="#bdb76b" colspan="4">
                <asp:Button ID="bsave_btvisa" runat="server" CausesValidation="true" Text="Save"
                    ValidationGroup="vbusinesstype" SkinID="buttonskin1" />
                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" bordercolor="#bdb76b" colspan="4" style="height: 17px">
                <asp:GridView ID="GridView1" DataKeyNames=recordno runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource1" ForeColor="#333333" AllowPaging="True" AllowSorting="True" AutoGenerateEditButton="True" GridLines="None" Width="548px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" ReadOnly=True  SortExpression="empcode" />
                        <asp:TemplateField HeaderText="Country" SortExpression="country">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                    DataTextField="countryname" DataValueField="countryname" SelectedValue='<%# Bind("country") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT [countryname] FROM [countrymaster] ORDER BY [countryname]">
                                </asp:SqlDataSource>
                                &nbsp;
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("country") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visatype" SortExpression="visatype">
                            <EditItemTemplate>
                                <asp:DropDownList ID="visatype" runat="server" Font-Bold="True" Font-Size="X-Small"
                    Width="88px" SelectedValue='<%# Bind("visatype") %>'>
                                    <asp:ListItem Value="B">Business</asp:ListItem>
                                    <asp:ListItem Value="T">Tourist</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("visatype") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TypeofJourney" SortExpression="journeytype">
                            <EditItemTemplate>
                                <asp:DropDownList ID="Journeytype" runat="server" Font-Bold="True" Font-Size="X-Small" SelectedValue='<%# Bind("journeytype") %>'>
                                    <asp:ListItem Value="S">Single entry</asp:ListItem>
                                    <asp:ListItem Value="M">Multiple entry</asp:ListItem>
                                    <asp:ListItem Value="D">Double</asp:ListItem>
                                    <asp:ListItem Value="T">Triple</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("journeytype") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visaperiod" SortExpression="visaperiod">
                            <EditItemTemplate>
                                <asp:TextBox ID="txttempvisa" runat="server" Text='<%# Bind("visaperiod" ) %>' Width="107px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttempvisa"
                                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="b"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("visaperiod") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expiryon" SortExpression="expiryon">
                            <EditItemTemplate>
                                <asp:TextBox ID="itemtxt5" runat="server" Text='<%# Bind("expiryon", "{0:MMM/dd/yyyy}") %>' HtmlEncode="false" Width="81px"></asp:TextBox><br />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
        Format="MMM/dd/yyyy" PopupButtonID="itemtxt5" TargetControlID="itemtxt5">
                                </cc1:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("expiryon", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [empcode], [country], [visatype], [journeytype], [visaperiod], [expiryon], [recordno] FROM [PV_BtVisadetails] WHERE ([empcode] = @empcode) ORDER BY [recordno] DESC"
                     UpdateCommand ="hrmis_pv_btvisa" UpdateCommandType=StoredProcedure >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="tbtempcode" Name="empcode" PropertyName="Text" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="country" Type = string />
                        <asp:Parameter Name="visatype" Type = string />
                        <asp:Parameter Name="journeytype" Type = string />
                        <asp:Parameter Name="visaperiod" Type = int32/>
                        <asp:Parameter Name="expiryon" Type = DateTime  />
                         <asp:Parameter Name="recordno" Type = int32/>
               <asp:SessionParameter Name=cby SessionField=empname Type=string />
                   
                        
                        
                        
                        
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
<asp:SqlDataSource ID="country" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [countryname] FROM [countrymaster]"></asp:SqlDataSource>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="TbtVexpiry" TargetControlID="TbtVexpiry">
    </cc1:CalendarExtender>
</asp:Content>
