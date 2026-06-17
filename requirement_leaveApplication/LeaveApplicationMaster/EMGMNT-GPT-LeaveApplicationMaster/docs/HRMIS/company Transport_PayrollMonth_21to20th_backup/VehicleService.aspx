<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="VehicleService.aspx.vb" Inherits="E_Management.VehicleService" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 626px">
        <tr>
            <td class="td_head" colspan="4">
                VEHICLE SERVICE</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 122px">
                <table style="border-right: steelblue 1px solid; border-top: steelblue 1px solid;
                    border-left: steelblue 1px solid; width: 620px; border-bottom: steelblue 1px solid">
                    <tr>
                        <td align="center" class="td_head" colspan="6" style="height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; Vehicle Insurance / Road Tax &nbsp; (Fill in all(!) the Required fields)</td>
                    </tr>
                    <tr>
                        <td align="left" class="td_head" colspan="6" style="height: 17px">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 111px;">
                            Vehicle No.</td>
                        <td style="width: 187px; background-color: beige">
                            <asp:DropDownList ID="ddlvno" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="d_vehicle" DataTextField="vehicleno" DataValueField="vehicleno"
                                Font-Size="Small" Width="158px">
                                <asp:ListItem Selected="True" Value="-1">--SELECT--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlvno"
                                ErrorMessage="!"></asp:RequiredFieldValidator></td>
                        <td style="background-color: beige">
                            Chassis No.</td>
                        <td style="width: 168px; background-color: beige">
                            <asp:Label ID="lblchasis" runat="server" ForeColor="Maroon" Width="146px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 111px;">
                            Vehicle Model</td>
                        <td style="width: 187px; background-color: beige">
                            <asp:Label ID="lblvmodel" runat="server" ForeColor="Maroon"></asp:Label></td>
                        <td style="color: #000000; background-color: beige">
                            Year Of Model</td>
                        <td style="width: 168px; background-color: beige">
                            <asp:Label ID="lblyear" runat="server" ForeColor="Maroon"></asp:Label>&nbsp;</td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="height: 18px; background-color: beige; width: 111px;">
                            color</td>
                        <td style="width: 187px; height: 18px; background-color: beige">
                            <asp:Label ID="lblcolor" runat="server" ForeColor="Maroon"></asp:Label></td>
                        <td style="color: #000000; height: 18px; background-color: beige">
                            Date of Purchase</td>
                        <td style="width: 168px; height: 18px; background-color: beige">
                            <asp:Label ID="lbldate" runat="server" ForeColor="Maroon">
                            
                            </asp:Label>&nbsp;</td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="height: 5px; background-color: beige; width: 111px;">
                            vehicleCategory</td>
                        <td style="width: 187px; height: 5px; background-color: beige">
                            <asp:Label ID="lblcat" runat="server" ForeColor="Maroon"></asp:Label></td>
                        <td style="color: #000000; height: 5px; background-color: beige">
                            FuelType</td>
                        <td style="width: 168px; height: 5px; background-color: beige">
                            <asp:Label ID="lblfuel" runat="server" ForeColor="Maroon"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">
                Details</td>
        </tr>
        <tr>
            <td style="width: 137px; height: 17px">
                Service Date</td>
            <td style="width: 106px; height: 17px">
                <asp:TextBox ID="txtdate" runat="server" Width="106px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate"
                    ErrorMessage="!" ForeColor="OrangeRed" ValidationGroup="a"></asp:RequiredFieldValidator>&nbsp;</td>
            <td style="width: 165px; height: 17px">
                Service Centre</td>
            <td style="width: 100px; height: 17px">
                <asp:DropDownList ID="txtcentre" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2"
                    DataTextField="centre" DataValueField="centre">
                    <asp:ListItem Selected="True" Value="-">-select-</asp:ListItem>
                </asp:DropDownList>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 137px; height: 44px;">
                If Other Service Centre<br />
                Please Specify</td>
            <td colspan="3" style="height: 44px">
                <asp:TextBox ID="txtothers" runat="server" Width="276px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 137px; height: 14px">
                Service Reading</td>
            <td style="width: 106px; height: 14px">
                <asp:TextBox ID="txtreading1" runat="server"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="R3" runat="server" ControlToValidate="txtreading1"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="b"></asp:RegularExpressionValidator></td>
            <td style="width: 165px; height: 14px">
                Next Service Reading</td>
            <td style="width: 100px; height: 14px">
                <asp:TextBox ID="txtreading2" runat="server"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="R4" runat="server" ControlToValidate="txtreading2"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="b"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="td_head" colspan="4" style="height: 17px">
                ITEM DETAILS</td>
        </tr>
        <tr>
            <td style="width: 137px">
                Item</td>
            <td style="width: 106px">
                <asp:TextBox ID="txtitem" runat="server" Width="57px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtitem"
                    ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtitem"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="b"></asp:RegularExpressionValidator></td>
            <td style="width: 165px">
                Amount</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtamt" runat="server" Width="63px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtamt" ErrorMessage="!"
                    ValidationGroup="b"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtamt"
                    ErrorMessage="Only Numbers" ValidationExpression="^\d*$" ValidationGroup="b"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 137px; height: 40px">
                Description</td>
            <td style="width: 106px; height: 40px">
                <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" Width="142px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdesc"
                    ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
            <td colspan="2" style="height: 40px">
                <asp:Button ID="btnadd" runat="server" SkinID="buttonskin1" Text="ADD" ValidationGroup="b" /></td>
        </tr>
        <tr>
            <td colspan="4">
            <hr style="background-color: #cccccc" />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1"
                    Height="58px" Width="619px" AutoGenerateDeleteButton="True" DataKeyNames="rno" GridLines="Horizontal">
                    <RowStyle ForeColor="#4A3C8C" BackColor="#E7E7FF" />
                    <Columns>
                        <asp:BoundField DataField="item" HeaderText="Item" SortExpression="item" />
                        <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                        <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">
                PAYMENT DETAILS</td>
        </tr>
        <tr>
            <td style="width: 137px">
                Payment Mode</td>
            <td style="width: 106px">
                <asp:DropDownList ID="txtpay" runat="server" AutoPostBack="True">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 165px">
                Date of Payment</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpdate" runat="server" Width="87px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpdate"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 137px">
                If cheque,Cheque No.</td>
            <td colspan="3">
                <asp:TextBox ID="txtcheque" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Button ID="Button2" runat="server" SkinID="buttonskin1" Text="SAVE" ValidationGroup="a" /></td>
        </tr>
    </table>
    <asp:SqlDataSource ID="d_vehicle" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [vehicleno] FROM [vehicledetail]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM [tempvehicleservice] WHERE ([vehicleno] = @vehicleno)"
                     DeleteCommand ="delete from [tempvehicleservice] where rno =@rno">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlvno" Name="vehicleno" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [centre] FROM [servicecentre] ORDER BY [centre]"></asp:SqlDataSource>
<cc1:CalendarExtender ID="CalendarExtender1" runat=server
                     PopupButtonID="txtpdate" TargetControlID="txtpdate"
                     Format = "dd/MM/yy" CssClass="cal_Theme1"  >
                </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="cce1" runat=server
                     PopupButtonID="txtdate" TargetControlID="txtdate"
                     Format = "dd/MM/yy" CssClass="cal_Theme1"  >
        </cc1:CalendarExtender>
</asp:Content>
