<%@Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="INSuranceRoadtax.aspx.vb" Inherits="E_Management.INSuranceRoadtax" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="border-right: steelblue 1px solid; border-top: steelblue 1px solid; border-left: steelblue 1px solid; border-bottom: steelblue 1px solid">
        <tr>
            <td align="center" colspan="6" style="height: 17px" class="td_head" >
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp;
               Vehicle Insurance / Road Tax &nbsp; (Fill in all(!) the Required fields)</td>
        </tr>
        <tr>
            <td style="background-color: beige;">
                Vehicle No.</td>
            <td style="background-color: beige; width: 110px;">
                <asp:DropDownList ID="ddlvno" runat="server" DataSourceID="d_vehicle" DataTextField="vehicleno"
                    DataValueField="vehicleno" Font-Size="Small" Width="168px" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="-1">--SELECT--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="ddlvno" ErrorMessage="!"></asp:RequiredFieldValidator></td>
            <td style="background-color: beige;">
                Chassis No.</td>
            <td style="background-color: beige; width: 168px;">
                <asp:Label ID="lblchasis" runat="server" ForeColor="Maroon" Width="146px"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-color: beige;">
                Vehicle Model</td>
            <td style="background-color: beige; width: 110px;">
                <asp:Label ID="lblvmodel" runat="server" ForeColor="Maroon"></asp:Label></td>
            <td style="background-color: beige;">
                Year Of Model</td>
            <td style="background-color: beige; width: 168px;">
                <asp:Label ID="lblyear" runat="server" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-color: beige">
                color</td>
            <td style="background-color: beige; width: 110px;">
                <asp:Label ID="lblcolor" runat="server" ForeColor="Maroon"></asp:Label></td>
            <td style="background-color: beige">
                Date of Purchase</td>
            <td style="background-color: beige; width: 168px;">
                <asp:Label ID="lbldate" runat="server" ForeColor="Maroon"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 9px; background-color: beige;">
                            Select Mode &nbsp; &nbsp;</td>
            <td style="height: 9px" colspan="3">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="RT">ROAD TAX</asp:ListItem>
                    <asp:ListItem Value="I">INSURANCE</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="RadioButtonList1"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 15px; background-color: beige;">
                FromDate</td>
            <td style="width: 110px; height: 15px">
                            <asp:TextBox ID="TXTFROM" runat="server" Width="96px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTFROM"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
            <td style="height: 15px; background-color: beige;">
                ToDate</td>
            <td style="height: 15px; width: 168px;">
                            <asp:TextBox ID="txtto" runat="server" Width="96px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 15px; border-bottom: 1px solid; background-color: beige;">
                            Amount</td>
            <td style="height: 15px; border-bottom: 1px solid;" colspan="3">
                            <asp:TextBox ID="txtamt" runat="server" Width="96px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtamt"
                    ErrorMessage="!" ValidationGroup="a">!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtamt"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="a"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="height: 28px; border-bottom: 1px solid;">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                <asp:Button ID="bvisave" runat="server" Text="ADD" SkinID="buttonskin1" ValidationGroup="a" />
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 28px" valign="top">
                <table style="width: 471px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                    <tr>
                        <td class="td_head" style="width: 100px">
                            ROAD TAX</td>
                        <td class="td_head" style="width: 100px">
                            INSURANCE</td>
                    </tr>
                    <tr>
                        <td style="width: 100px; border-right: 1px solid;" align="left" valign="top">
                            <asp:GridView ID="grdtax" runat="server" DataKeyNames=rno AutoGenerateColumns="False" CellPadding="4"
                                DataSourceID="sqltax" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Width="236px" AutoGenerateEditButton="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="vehicleno" HeaderText="Vehicleno " SortExpression="vehicleno" ReadOnly=True  />
                                    <asp:TemplateField HeaderText="Fromdate" SortExpression="rtfromdate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rtfromdate", "{0:MMM/dd/yyyy}") %>' HtmlEncode="false"></asp:TextBox>
                                             <cc1:CalendarExtender ID="cce1" runat=server
                     PopupButtonID="TextBox1" TargetControlID="TextBox1"
                     Format = "MMM/dd/yyyy" CssClass="cal_Theme1"  ></cc1:CalendarExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("rtfromdate", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Todate" SortExpression="rttodate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("rttodate", "{0:MMM/dd/yyyy}") %>' HtmlEncode="false"></asp:TextBox>
                                                 <cc1:CalendarExtender ID="cce2" runat=server
                     PopupButtonID="TextBox2" TargetControlID="TextBox2"
                     Format = "MMM/dd/yyyy" CssClass="cal_Theme1"  ></cc1:CalendarExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("rttodate", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="rtamount" HeaderText="Amount" SortExpression="rtamount" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            &nbsp;
                        </td>
                        <td style="width: 100px" align="left" valign="top">
                            <asp:GridView ID="grdins" runat="server" AutoGenerateColumns="False" DataKeyNames=rno CellPadding="4"
                                DataSourceID="Sqlins" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Width="223px" AutoGenerateEditButton="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="vehicleno" HeaderText="Vehicleno" SortExpression="vehicleno" ReadOnly=True  />
                                    <asp:TemplateField HeaderText="Fromdate" SortExpression="infromdate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("infromdate", "{0:MMM/dd/yyyy}") %>' HtmlEncode="false"></asp:TextBox>
                                                  <cc1:CalendarExtender ID="cce3" runat=server
                     PopupButtonID="TextBox1" TargetControlID="TextBox1"
                     Format = "MMM/dd/yyyy" CssClass="cal_Theme1"  ></cc1:CalendarExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("infromdate", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Todate" SortExpression="intodate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("intodate", "{0:MMM/dd/yyyy}") %>' HtmlEncode="false"></asp:TextBox>
                                                  <cc1:CalendarExtender ID="cce4" runat=server
                     PopupButtonID="TextBox2" TargetControlID="TextBox2"
                     Format = "MMM/dd/yyyy" CssClass="cal_Theme1"  ></cc1:CalendarExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("intodate", "{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="inamount" HeaderText="Amount" SortExpression="inamount" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                    Format="dd/MM/yy" PopupButtonID="txtto" TargetControlID="txtto">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                    Format="dd/MM/yy" PopupButtonID="txtfrom" TargetControlID="txtfrom">
                </cc1:CalendarExtender>

<asp:SqlDataSource ID="d_vehicle" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
    SelectCommand="SELECT [vehicleno] FROM [vehicledetail]" ProviderName="<%$ ConnectionStrings:Sqlcon1.ProviderName %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlins" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [vehicleno], [infromdate], [intodate], [inamount], [active] ,rno FROM [vehicleinsurance] WHERE ([active] = @active) ORDER BY [rno] DESC"
        UpdateCommand = "hrmis_compv_updins" UpdateCommandType=StoredProcedure >
        <SelectParameters>
            <asp:Parameter DefaultValue="y" Name="active" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name= infromdate Type=datetime  />
            <asp:parameter Name =intodate Type=datetime />
            <asp:Parameter Name= inamount Type=decimal />
            <asp:SessionParameter Name = modifiedby SessionField= empname Type=string />
            
            </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqltax" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [vehicleno], [rtfromdate], [rttodate], [rtamount], [active] ,rno FROM [vehicletax] WHERE ([active] = @active) ORDER BY [rno] DESC"
         UpdateCommand = "hrmis_compv_updRT" UpdateCommandType=StoredProcedure >
        <SelectParameters>
            <asp:Parameter DefaultValue="y" Name="active" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name= rtfromdate Type=datetime  />
            <asp:parameter Name = rttodate Type=datetime />
            <asp:Parameter Name= rtamount Type=decimal />
            <asp:SessionParameter Name = modifiedby SessionField= empname Type=string />
            
            </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
