<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Disposal Entry.aspx.vb" Inherits="E_Management.Disposal_Entry" 
    title="Disposal Entry Screen" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

<table id="TABLE2">
    <tr>
        <td align="center" style="width: 216px; height: 9px; text-align: left" valign="top">
            <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="DISPOSAL ENTRY SCREEN" Width="239px"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 216px; height: 57px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="width: 81px; background-color: beige; height: 10px;" valign="middle" align="left" colspan="2">
                            <asp:Label ID="dep" runat="server" Text="Items" Width="57px"></asp:Label></td>
                        <td style="width: 144px; height: 10px;" valign="bottom" align="left"><asp:DropDownList ID="items" runat="server" Width="110px" DataSourceID="SqlDataSource1" DataTextField="item" DataValueField="item" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                        </asp:DropDownList></td>
                        <td align="left" style="width: 31147px; height: 10px; background-color: beige; " valign="middle">
                            <asp:Label ID="Label2" runat="server" Text="Control Spec" Width="90px"></asp:Label>
                            </td>
                        <td align="left" style="width: 112613px; height: 10px;" valign="middle">
                            <asp:Label ID="control" runat="server" Text="" Width="30px"></asp:Label></td>
                        <td align="left" style="width: 350px; height: 10px; background-color: beige;" valign="middle" >
                            <asp:Label ID="Label3" runat="server" Text="Available Qty." Width="91px"></asp:Label></td>
                        <td align="left" style="width: 2px; height: 10px" valign="middle">
                            <asp:Label ID="availableqty" runat="server" Width="30px"></asp:Label></td>
                        <td align="left" style="width: 72966px; height: 10px; background-color: beige;" valign="middle">
                            <asp:Label ID="Label4" runat="server" Text="Disposal Qty." Width="87px"></asp:Label></td>
                        <td align="left" style="width: 13781px; height: 10px" valign="middle">
                            <asp:TextBox ID="dispqty" runat="server" Width="42px"></asp:TextBox>
                            </td>
                        <td align="center" style="width: 5001535px; height: 10px" valign="middle">
                            <asp:Button ID="Button1" runat="server" Text="ADD" /></td>
                    </tr>
                    <tr>
                        <td align="left" colspan="10" style="height: 1px; background-color: white" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 81px; height: 21px; background-color: beige" valign="middle" colspan="2">
                            <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="Disposal Date :" Width="100px"></asp:Label></td>
                        <td align="left" style="width: 144px; height: 21px" valign="middle">
                            <asp:TextBox ID="DISPOSALDATE" runat="server" Width="85px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DISPOSALDATE"
                                ErrorMessage="!" Font-Bold="True" Font-Size="14pt" InitialValue="-"></asp:RequiredFieldValidator></td>
                        <td align="left" style="width: 31147px; height: 21px; background-color: beige" valign="middle">
                            <asp:Label ID="Label6" runat="server" ForeColor="Black" Text=" Disposal Time :" Width="96px"></asp:Label></td>
                        <td align="left" colspan="6" style="height: 21px" valign="middle">
                            <asp:DropDownList ID="HRS" runat="server">
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem Selected="True">-</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="HRS"
                                ErrorMessage="!" Font-Bold="True" Font-Size="14pt" Width="1px"></asp:RequiredFieldValidator>
                            HRS &nbsp;<asp:DropDownList ID="MINS" runat="server">
                                <asp:ListItem>00</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                                <asp:ListItem Selected="True">-</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="MINS"
                                ErrorMessage="!" Font-Bold="True" Font-Size="14pt" InitialValue="-"></asp:RequiredFieldValidator>
                            MINS&nbsp;
                            <asp:DropDownList ID="AMPM" runat="server">
                                <asp:ListItem>AM</asp:ListItem>
                                <asp:ListItem>PM</asp:ListItem>
                                <asp:ListItem Selected="True">-</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="AMPM"
                                ErrorMessage="!" Font-Bold="True" Font-Size="14pt" InitialValue="-"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp;
                             <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="txtfrom" targetcontrolid="DISPOSALDATE"></cc1:calendarextender>
                </td>
        </tr>
    <tr>
        <td align="left" style="width: 216px; height: 249px" valign="top">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Width="717px" AutoGenerateDeleteButton="True" DataKeyNames ="items">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="major" HeaderText="Major" SortExpression="major" />
                    <asp:BoundField DataField="items" HeaderText="Items" SortExpression="items" />
                    <asp:BoundField DataField="dispossalqty" HeaderText="Disposal Qty." SortExpression="dispossalqty" />
                    <asp:BoundField DataField="suppliername" HeaderText="Supplier Name" SortExpression="suppliername" />
                    <asp:BoundField DataField="truckno" HeaderText="Truck No." SortExpression="truckno" />
                    <asp:BoundField DataField="pono" HeaderText="P.O No." SortExpression="pono" />
                    <asp:BoundField DataField="consignmentno" HeaderText="Consignment No." SortExpression="consignmentno" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red"></asp:Label></td>
    </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [Item] FROM [safety_schedulemaster]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                SelectCommand="SELECT major, items, dispossalqty, suppliername, truckno, pono, consignmentno FROM Safety_dispossaldetails"
                DeleteCommand = "delete from Safety_dispossaldetails where items=@items" >
            </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM Safety_domesticwasteconsignment"
                    InsertCommand = "INSERT into Safety_domesticwasteconsignment (recordno, empcode, dateapplied,dept,sect,majortype,status) values (@recno, @empcode, @dateapplied,@dept,@sect,@majortype,@status)"> 
           
                </asp:SqlDataSource>
    
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
    </table></asp:Content>