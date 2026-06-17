<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="VehicleMaster.aspx.vb" Inherits="E_Management.VehicleMaster" Theme="buttonems" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td colspan=4 class="td_head">
                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>Enter Vehicle Master Details Below 
            </td>
        </tr>
        <tr>
            <td style="width: 93px" valign="top">
                vehicle No.</td>
            <td style="width: 175px" valign="top">
                <asp:TextBox ID="Tvno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="Tvno"
                    Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">* </asp:RequiredFieldValidator></td>
            <td style="width: 100px; color: #000000" valign="top">
                Chassis No.</td>
            <td valign="top">
                <asp:TextBox ID="tcno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="Tcno"
                    Display="Dynamic" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">* </asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 93px">
                Model</td>
            <td style="width: 175px">
                <asp:TextBox ID="tvmodel" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="Tvmodel"
                    Display="Dynamic" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">* </asp:RequiredFieldValidator></td>
            <td style="width: 100px; color: #000000">
                Engine CC.</td>
            <td>
                <asp:TextBox ID="tecc" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="Tecc"
                    Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">* </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 93px">
                Engine No.</td>
            <td style="width: 175px">
                <asp:TextBox ID="teno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="Tvno"
                    Display="Dynamic" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">* </asp:RequiredFieldValidator>
            </td>
            <td style="width: 100px">
                Fuel Type</td>
            <td>
                <asp:DropDownList ID="Dfuel" runat="server" Font-Bold="True" Font-Size="X-Small"
                    Width="104px">
                    <asp:ListItem Selected="True">Select a Value</asp:ListItem>
                    <asp:ListItem>Petrol</asp:ListItem>
                    <asp:ListItem>Diesel</asp:ListItem>
                    <asp:ListItem>Gas</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="Dfuel" InitialValue="Select a Value" ValidationGroup="vvehiclemaster">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 93px">
                Seats</td>
            <td style="width: 175px">
                <asp:TextBox ID="Tseats" runat="server" Width="47px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="Tseats"
                    Display="Dynamic" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">* </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Tseats"
                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" SetFocusOnError="True"
                    ValidationExpression="^\d*$" ValidationGroup="vvehiclemaster">Only Numbers</asp:RegularExpressionValidator></td>
            <td style="width: 100px">
                Color</td>
            <td>
                <asp:TextBox ID="Tcolor" runat="server" Width="99px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="Tcolor"
                    Display="Dynamic" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 93px">
                Catagory</td>
            <td style="width: 175px">
                <asp:DropDownList ID="Dvcategory" runat="server" Font-Bold="True" Font-Size="X-Small">
                    <asp:ListItem>Select a Value</asp:ListItem>
                    <asp:ListItem>Company Car</asp:ListItem>
                    <asp:ListItem>Company Van</asp:ListItem>
                    <asp:ListItem>Company Bus</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="Dvcategory"
                    Display="Dynamic" InitialValue="Select a Value"
                    SetFocusOnError="True" ValidationGroup="vvehiclemaster">* </asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Year of model</td>
            <td>
                <asp:TextBox ID="Tymodel" runat="server" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="Tymodel"
                    Display="Dynamic" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">*  </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tymodel"
                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" ValidationExpression="^\d*$"
                    ValidationGroup="vvehiclemaster">Enter year in YYYY format</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 93px; height: 17px">
                Date of Purchase</td>
            <td style="width: 175px; height: 17px">
                <asp:TextBox ID="Tvpurdate" runat="server" Width="96px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="Tvpurdate"
                    Display="Dynamic" SetFocusOnError="True"
                    ValidationGroup="vvehiclemaster">*  </asp:RequiredFieldValidator>&nbsp;
            </td>
            <td style="width: 100px; height: 17px">
                Department</td>
            <td style="height: 17px">
                <asp:DropDownList ID="Ddept" runat="server" AppendDataBoundItems="True" DataSourceID="sqldept"
                    DataTextField="Column1" DataValueField="departmentcode" Font-Size="X-Small"
                    Width="208px">
                    <asp:ListItem Selected="True">Please select a Value</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="Ddept"
                    Display="Dynamic" ErrorMessage="RequiredFieldValidator" InitialValue="Please select a Value"
                    SetFocusOnError="True" ValidationGroup="vvehiclemaster">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                &nbsp;<asp:Button ID="bsave_vehicle" runat="server" Text="Save" ValidationGroup="vvehiclemaster" SkinID="buttonskin1" />
               
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="15">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Vehicleno" SortExpression="vehicleno">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("vehicleno") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="GetVehicleDetails" CommandArgument='<%# Eval("rno", "{0}") %>'
                                 Font-Underline="True"
                                    ForeColor="SteelBlue" Text='<%# Eval("vehicleno") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="model" HeaderText="Model" SortExpression="model" />
                        <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
                        <asp:BoundField DataField="datepurchase" HeaderText="PurchaseDate" SortExpression="datepurchase" dataformatstring="{0:dd/MM/yy}" HtmlEncode="false" />
                        <asp:BoundField DataField="casisno" HeaderText="Casisno" SortExpression="casisno" />
                        <asp:BoundField DataField="fueltype" HeaderText="FuelType" SortExpression="fueltype" />
                        <asp:BoundField DataField="colour" HeaderText="Colour" SortExpression="colour" />
                        <asp:BoundField DataField="engineno" HeaderText="Engineno" SortExpression="engineno" />
                        <asp:BoundField DataField="enginecc" HeaderText="Enginecc" SortExpression="enginecc" />
                        <asp:BoundField DataField="seats" HeaderText="Seats" SortExpression="seats" />
                        <asp:BoundField DataField="department" HeaderText="Dept" SortExpression="department" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [vehicleno], [model], [category], [datepurchase], [casisno], [fueltype], [colour], [engineno], [enginecc], [myear], [seats], [department], [rno] FROM [vehicledetail] ORDER BY [rno] DESC">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <cc1:CalendarExtender ID="cce1"  runat="server"
     TargetControlID="Tvpurdate" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
     PopupButtonID="Tvpurdate"
       /> 
    <asp:SqlDataSource ID="sqldept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        ProviderName="<%$ ConnectionStrings:Sqlcon1.ProviderName %>" SelectCommand="select departmentcode +'-'+departmentname ,departmentcode from department order by departmentcode">
    </asp:SqlDataSource>
</asp:Content>
