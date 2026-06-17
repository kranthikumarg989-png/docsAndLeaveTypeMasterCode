<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ppdetailsentry.aspx.vb" Inherits="E_Management.ppdetailsentry" 
%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="border-right: steelblue 1px solid; border-top: steelblue 1px solid; border-left: steelblue 1px solid; border-bottom: steelblue 1px solid">
        <tr>
            <td align="center" colspan="5" class="td_head">
              PASSPORT DETAILS ENTRY</td>
        </tr>
        <tr>
            <td style="width: 115px; height: 18px; background-color: beige">
                Employee No</td>
            <td style="height: 18px; width: 202px;">
                <asp:TextBox ID="tpeno" runat="server" AutoPostBack="True" Width="87px" BackColor="#FFFF80"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="tpeno"
                    Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                    ValidationGroup="vpasport">* </asp:RequiredFieldValidator></td>
            <td style="height: 18px; background-color: beige">
                Gender</td>
            <td bgcolor="#ffffff" valign="top" style="height: 18px">
                <asp:Label ID="tpgender" runat="server" Width="160px" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 17px; background-color: beige;">
                Employee Name</td>
            <td bgcolor="#ffffff" style="width: 202px; height: 17px;">
                <asp:Label ID="tpename" runat="server" Width="216px" ForeColor="Maroon"></asp:Label></td>
            <td style="height: 17px; background-color: beige;">
                Department Code</td>
            <td bgcolor="#ffffff" style="height: 17px">
                <asp:Label ID="tpdept" runat="server" Width="160px" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 20px; background-color: beige;">
                Section Code</td>
            <td bgcolor="#ffffff" style="width: 202px; height: 20px">
                <asp:Label ID="tpsect" runat="server" Width="214px" ForeColor="Maroon"></asp:Label></td>
            <td style="height: 20px; background-color: beige;">
                Designation</td>
            <td bgcolor="#ffffff" style="height: 20px">
                <asp:Label ID="tpdesig" runat="server" Width="160px" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 15px; background-color: beige;">
                Passport No</td>
            <td style="width: 202px; height: 15px;">
                <asp:TextBox ID="tppno" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="tppno"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True"
                    ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
            <td style="height: 15px; background-color: beige;">
                Passport Expiry Date</td>
            <td style="height: 15px">
                <asp:TextBox ID="tpedate" runat="server" Width="147px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="tpedate"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True"
                    ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 21px; background-color: beige;">
                Issued Country</td>
            <td style="width: 202px; height: 21px;">
                <asp:TextBox ID="tpissuedcountry" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="tpissuedcountry"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True"
                    ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
            <td style="height: 21px; background-color: beige;">
                Issued Place</td>
            <td style="height: 21px">
                <asp:TextBox ID="tpissuedplace" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="tpissuedplace"
                    Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                    ValidationGroup="vpassport">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 32px; background-color: beige;">
                Address</td>
            <td style="width: 202px">
                <asp:TextBox ID="tpaddress" runat="server" Height="56px" TextMode="MultiLine" Width="192px"></asp:TextBox>
            </td>
            <td style="height: 26px; background-color: beige;">
                GroupCode</td>
            <td style="height: 32px">
                <asp:DropDownList ID="dpgrp" runat="server" DataSourceID="dppgrpcode" DataTextField="Column1"
                    DataValueField="groupcode" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True" Value="-">--select--</asp:ListItem>
                </asp:DropDownList><asp:SqlDataSource ID="dppgrpcode" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT groupcode +'-' + groupname,groupcode FROM groupmaster ORDER BY groupcode"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige;">
                Country name</td>
            <td style="width: 202px; height: 14px">
                <asp:DropDownList ID="tpcountry" runat="server" AppendDataBoundItems="True" DataSourceID="country"
                    DataTextField="countryname" DataValueField="countryname" Width="160px" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="-">Select a value</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="tpcountry"
                    Display="Dynamic" ErrorMessage="!" InitialValue="-"
                    SetFocusOnError="True" ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
            <td style="height: 14px; background-color: beige;">
                Date Arrived</td>
            <td style="height: 14px">
                <asp:TextBox ID="tdatearrived" runat="server" Width="149px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tdatearrived"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True" ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                KDN Ref No</td>
            <td style="width: 202px; height: 14px">
                <asp:DropDownList ID="CmbKdnRefNo" runat="server" DataSourceID="SqlDataSource2" DataTextField="KDNRefNo"
                    DataValueField="KDNRefNo" Width="225px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
                    SelectCommand="SELECT KDNRefNo FROM Tbl_KDNRefNo Order By CreatedOn Desc"></asp:SqlDataSource>
            </td>
            <td style="height: 14px; background-color: beige">
                KDN Approval</td>
            <td style="height: 14px">
                <asp:DropDownList ID="CmbKDNApproval" runat="server" DataSourceID="SqlDataSource3"
                    DataTextField="KDNApproval" DataValueField="KDNApproval" Width="160px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
                    SelectCommand="SELECT KDNApproval FROM Tbl_KDNApproval Order By CreatedOn Desc ">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                Agent</td>
            <td style="width: 202px; height: 14px">
                <asp:TextBox ID="TxtAgent" runat="server"></asp:TextBox></td>
            <td style="height: 14px; background-color: beige">
                Contract Period</td>
            <td style="height: 14px">
                <asp:TextBox ID="TxtContractPeriod" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                Father Name</td>
            <td style="width: 202px; height: 14px">
                <asp:TextBox ID="TxtFatherName" runat="server"></asp:TextBox></td>
            <td style="height: 14px; background-color: beige">
                Mother Name</td>
            <td style="height: 14px">
                <asp:TextBox ID="TxtMotherName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                ContactNo</td>
            <td style="width: 202px; height: 14px">
                <asp:TextBox ID="TxtContactNo" runat="server"></asp:TextBox></td>
            <td style="height: 14px; background-color: beige">
                Barcode</td>
            <td style="height: 14px">
                <asp:TextBox ID="TxtBarcode" runat="server" Font-Names="IDAutomationHC39M"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="height: 28px">
                &nbsp;<asp:Button ID="bsave_passport" runat="server" Text="Save" ValidationGroup="vpassport" SkinID="buttonskin1" />
              
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 28px">
                <asp:GridView ID="GridView1" DataKeyNames=passportno runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="608px">
                    <Columns>
                        <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" ReadOnly="True" />
                        <asp:BoundField DataField="passportno" HeaderText="Passportno" SortExpression="passportno" ReadOnly="True" />
                        <asp:TemplateField HeaderText="PPexpdate" SortExpression="ppexpirydate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBx1" runat="server" Text='<%# Bind("ppexpirydate") %>'></asp:TextBox>
                                <cc1:calendarextender id="CalendarExtender1" runat="server" cssclass="cal_Theme1"
        format="dd/MM/yy" popupbuttonid="textbx1" targetcontrolid="textbx1"></cc1:calendarextender>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ppexpirydate", "{0:dd/MM/yy}") %>' HtmlEncode="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ppissuedcountry" HeaderText="PPissuedcountry" SortExpression="ppissuedcountry" />
                        <asp:BoundField DataField="ppissuedplace" HeaderText="PPissuedplace" SortExpression="ppissuedplace" />
                        <asp:TemplateField HeaderText="Empgroup" SortExpression="empgroup">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dppgrpcode" DataTextField="Column1"
                                    DataValueField="groupcode" SelectedValue='<%# Bind("empgroup") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("empgroup") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country" SortExpression="country">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="country" DataTextField="countryname"
                                    DataValueField="countryname" SelectedValue='<%# Bind("country") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("country") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address" SortExpression="address">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("address") %>' TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Arriveddate" SortExpression="arriveddate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBo5" runat="server" Text='<%# Bind("arriveddate") %>'></asp:TextBox>
                                <cc1:calendarextender id="CalendarExtender2" runat="server" cssclass="cal_Theme1"
        format="dd/MM/yy" popupbuttonid="TextBo5" targetcontrolid="TextBo5"></cc1:calendarextender>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("arriveddate", "{0:dd/MM/yy}") %>' HtmlEncode="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM [passportdetails]  Order By PPExpiryDate Asc"
                     updatecommand = "hrmis_pv_updppdetails" UpdateCommandType=StoredProcedure >
                    <UpdateParameters>
                    <asp:Parameter name = ppexpirydate Type=datetime  />
                    <asp:Parameter Name = ppissuedcountry Type =  string />
                    <asp:Parameter Name = ppissuedplace Type =string />
                    <asp:Parameter Name= empgroup Type=string />
                    <asp:Parameter Name = country Type=string />
                    <asp:Parameter Name = address type=string />
                    <asp:Parameter Name=arriveddate Type=datetime />
                    <asp:SessionParameter Name=emp SessionField=empname Type=string />
                    
                    </UpdateParameters> 
                    
                    </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="country" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [countryname] FROM [countrymaster]"></asp:SqlDataSource>
    <cc1:calendarextender id="CalendarExtender1" runat="server" cssclass="cal_Theme1"
        format="dd/MM/yy" popupbuttonid="tpedate" targetcontrolid="tpedate">
                </cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" cssclass="cal_Theme1"
        format="dd/MM/yy" popupbuttonid="tdatearrived" targetcontrolid="tdatearrived">
                </cc1:calendarextender>
</asp:Content>
