<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="DomWasteConsignment.aspx.vb" Inherits="E_Management.DomWasteConsignment" 
    title="Domestic Waste Consignment Note" %>
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

<table style="width: 1000px; height: 145px" id="TABLE2">
        <tr>
            <td style="height: 110px;" valign="top" align="left" rowspan="" colspan="">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" style="height: 27px" valign="top" align="left">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="REQUESTOR DETAILS"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 38px; background-color: beige; height: 28px;" valign="top" align="left">
                            <asp:Label ID="Label2" runat="server" Text="Rec. No. :" Font-Bold="True" Width="70px" ForeColor="#0000C0"></asp:Label></td>
                        <td style="width: 122px; height: 28px; background-color: beige;" valign="top" align="left">
                            &nbsp;<asp:Label ID="recordno" runat="server"></asp:Label></td>
                        <td align="left" style="width: 85px; background-color: beige; height: 28px;" valign="top">
                            <asp:Label ID="Label6" runat="server" Text="Employee No. :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 219px; height: 28px; background-color: beige;" valign="top">
                            &nbsp;<asp:Label ID="empcode" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 38px; background-color: beige; height: 28px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Date Applied :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td style="width: 122px; height: 28px; background-color: beige;" valign="top" align="left">
                            &nbsp;<asp:Label ID="dateapplied" runat="server"></asp:Label></td>
                        <td align="left" style="width: 85px; background-color: beige; height: 28px;" valign="top">
                            <asp:Label ID="Label5" runat="server" Text="Employee Name :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 219px; height: 28px; background-color: beige;" valign="top">
                            &nbsp;<asp:Label ID="empname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 38px; background-color: beige; height: 24px;" valign="top">
                            <asp:Label ID="Label4" runat="server" Text="Department :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 122px; background-color: beige; height: 24px;" valign="top">
                            &nbsp;<asp:Label ID="dept" runat="server"></asp:Label></td>
                        <td align="left" style="width: 85px; background-color: beige; height: 24px;" valign="top">
                            <asp:Label ID="Label7" runat="server" Text="Section :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 219px; background-color: beige; height: 24px;" valign="top">
                            &nbsp;<asp:Label ID="sect" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <asp:Label ID="majortype" runat="server" Text="Label" Visible="False"></asp:Label></td>
        </tr>
    <tr>
        <td align="center" style="width: 131px; height: 243px; text-align: left;" valign="top">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
                GridLines="None">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No." >
   <ItemTemplate>    
       <%# CType(Container, GridViewRow).RowIndex + 1%>
   </ItemTemplate>
</asp:TemplateField>


                    <asp:BoundField DataField="items" HeaderText="Items" SortExpression="items" />
                    <asp:BoundField DataField="controlspec" HeaderText="Control Spec." SortExpression="controlspec" />
                    <asp:BoundField DataField="stdmeasurement" HeaderText="Std. Weight" SortExpression="stdmeasurement" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="quantity" runat="server" Width="74px"></asp:TextBox></br>
                            <asp:RegularExpressionValidator id="RegularExpressionValidator8" runat="server" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="Only Numbers!" 
                                    ControlToValidate="quantity"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                        
                                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="remarks" runat="server" Height="91px" Width="180px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
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
    <tr>
        <td align="center" style="width: 131px; height: 249px; text-align: left" valign="top">
            <table id="Table3" onclick="return TABLE1_onclick()" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 65px; background-color: beige; height: 47px;" valign="top" align="left">
                        <asp:Label ID="Label9" runat="server" Text="Disposal Date :" ForeColor="#0000C0"></asp:Label></td>
                    <td style="height: 47px; background-color: beige; width: 206px;" valign="top" align="left" colspan="2">
                            <asp:TextBox ID="datedispossal" runat="server" Width="85px"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlihr"
                                    ErrorMessage="!" InitialValue="-" Font-Bold="True" Font-Size="14pt"></asp:RequiredFieldValidator>
                        &nbsp; &nbsp;
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label10" runat="server" Text=" Disposal Time :" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 223px; background-color: beige; height: 47px;" valign="top" colspan="2">
                            <asp:DropDownList ID="ddlihr" runat="server">
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
                    <asp:ListItem Selected="True">-</asp:ListItem> </asp:DropDownList>&nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="datedispossal"
                                    ErrorMessage="!" Width="1px" Font-Bold="True" Font-Size="14pt"></asp:RequiredFieldValidator>
                            &nbsp;
                            HRS&nbsp;
                    <asp:DropDownList ID="ddlimin" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlimin"
                                    ErrorMessage="!" InitialValue="-" Font-Bold="True" Font-Size="14pt"></asp:RequiredFieldValidator>
               
               &nbsp;&nbsp;MINS&nbsp;
                            <asp:DropDownList ID="ddliam" runat="server">
                                <asp:ListItem>AM</asp:ListItem>
                                <asp:ListItem>PM</asp:ListItem>
                            <asp:ListItem Selected="True">-</asp:ListItem> </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddliam"
                                    ErrorMessage="!" InitialValue="-" Font-Bold="True" Font-Size="14pt"></asp:RequiredFieldValidator></td>
                    <td align="left" colspan="1" style="height: 47px; background-color: beige; width: 3px;" valign="top">
                    </td>
                    </tr>
                    <tr>
                        <td style="width: 65px; background-color: beige; height: 28px;" valign="top" align="left">
                            <asp:Label ID="Label11" runat="server" Text="Person Incharge :" ForeColor="#0000C0"></asp:Label></td>
                        <td style="height: 28px; background-color: beige;" valign="top" align="left" colspan="4">
                            <asp:DropDownList ID="personincharge" runat="server" DataSourceID="SqlDataSource2"
                                DataTextField="empname" DataValueField="empname" AppendDataBoundItems="True" Width="264px">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="personincharge"
                                    ErrorMessage="!" InitialValue="-1" Font-Bold="True" Font-Size="14pt"></asp:RequiredFieldValidator>
                            &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Button ID="dwc" runat="server" Text="SAVE" />&nbsp;
                        </td>
                        <td align="left" colspan="1" style="height: 28px; background-color: beige; width: 3px;" valign="top">
                        </td>
                    </tr>
            </table>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT [empname] FROM [empmaster] WHERE (([departmentcode] = @departmentcode) AND ([resigned] <> @resigned) AND ([designation] <> @designation))">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="9005" Name="departmentcode" Type="String" />
                                    <asp:Parameter DefaultValue="Y" Name="resigned" Type="String" />
                                    <asp:Parameter DefaultValue="Security Guard" Name="designation" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <cc1:calendarextender id="ddc" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="datedispossal" targetcontrolid="datedispossal"></cc1:calendarextender>
            &nbsp; &nbsp; &nbsp;&nbsp;<br />
            </td>
    </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                   SelectCommand="SELECT Safety_domesticwasteconsignmentdetails.recordno, Safety_domesticwasteconsignmentdetails.items, Safety_domesticwasteconsignmentdetails.code, safety_schedulemaster.controlspec, safety_schedulemaster.stdmeasurement, safety_schedulemaster.recordno AS Expr1, safety_schedulemaster.Item FROM Safety_domesticwasteconsignmentdetails , safety_schedulemaster  where Safety_domesticwasteconsignmentdetails.items = safety_schedulemaster.Item and Safety_domesticwasteconsignmentdetails.recordno = @rno ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="recordno" Name="rno" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    InsertCommand="INSERT into Safety_domesticwasteconsignment (recordno, empcode, dateapplied,dept,sect,majortype,status) values (@recno, @empcode, @dateapplied,@dept,@sect,@majortype,@status)"
                    SelectCommand="SELECT * FROM Safety_domesticwasteconsignment"></asp:SqlDataSource>
    
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
