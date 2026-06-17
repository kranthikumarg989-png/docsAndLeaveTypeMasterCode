<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OTstaffEntry.aspx.vb" Inherits="E_Management.OTstaffEntry" 
    title="Ot Staff Entry" Theme="buttonems" %>
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
            <td background="../../images/cen_lef.gif" style="height: 289px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 289px">

<table id="TABLE2">
        <tr>
            <td valign="top" align="left">
                <table id="TABLE1" onclick="return TABLE1_onclick()" style="width: 500px; height: 120px" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2" style="height: 25px" valign="top" align="left">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="OT - STAFF ENTRY"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: beige;" valign="top" align="left">
                            <asp:Label ID="frmdt" runat="server" Text="From Date" Width="77px"></asp:Label></td>
                        <td valign="top" align="left">
                    
                        <asp:TextBox ID="vfdt" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="vfdt"
                                    ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: beige;" valign="top" align="left">
                            <asp:Label ID="todt" runat="server" Text="To Date"></asp:Label></td>
                        <td valign="top" align="left">
                           
                        <asp:TextBox ID="vtdt" runat="server"  Width="180px" ReadOnly="True" BackColor="#E0E0E0"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="vtdt"
                                    ErrorMessage="Please Select End Date"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: beige;" valign="top" align="left">
                            <asp:Label ID="ecode" runat="server" Text="OT Hours"></asp:Label></td>
                        <td valign="top" align="left">
                            <asp:TextBox ID="othrs" runat="server" MaxLength="3" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="othrs"
                                    ErrorMessage="Please Mention OT Hours"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                ControlToValidate="othrs" ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="117px"></asp:RegularExpressionValidator>
                                    </td></tr>
                    <tr>
                        <td align="left" style="background-color: beige" valign="top">
                            <asp:Label ID="Label2" runat="server" Text="Reason"></asp:Label></td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="TxtReason" runat="server" MaxLength="3" TextMode="MultiLine" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtReason"
                                ErrorMessage="Please keyin OT reason."></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2" align="right">
                        
                            <asp:Button ID="applynow" runat="server" Text="APPLY" SkinID="buttonskin1" />&nbsp; &nbsp;</td>
                    </tr>
                </table>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource2" ForeColor="#333333" CellSpacing="1">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>

                        <asp:BoundField DataField="shift" HeaderText="Shift" SortExpression="shift" />
                        <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                        <asp:BoundField DataField="whrs" HeaderText="Total OT Hrs in a Week" SortExpression="whrs" />
                        <asp:BoundField DataField="hrs" HeaderText="OT Hrs" SortExpression="hrs" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                            <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label></td>
            <td valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="RecNo" DataSourceID="SqlDataSource1" ForeColor="#333333" CellSpacing="1" ShowFooter="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                      <asp:BoundField DataField="Recno" HeaderText="Recno" SortExpression="Recno" />
                       
                        <asp:BoundField DataField="shift" HeaderText="Shift" SortExpression="shift" />
                        <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False" />
                        <asp:TemplateField HeaderText="OT Type" SortExpression="ottype">
                             <ItemTemplate>
                                <asp:DropDownList ID="Ddltype" runat="server" SelectedValue='<%# Bind("ottype") %>'>
                                    <asp:ListItem Value="-1">--select--</asp:ListItem>
                                    <asp:ListItem>OTND</asp:ListItem>
                                    <asp:ListItem>OTPH</asp:ListItem>
                                    <asp:ListItem>OTRD</asp:ListItem>                                   
                                </asp:DropDownList>
                            </ItemTemplate>                                                     
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="hrs" HeaderText="OT Hrs" SortExpression="hrs" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                      
                            <ItemTemplate>
                              <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("recno", "{0}") %>'
                                  Text='<%# Eval("status") %>'> </asp:Label>
                             &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Recno", "{0}") %>'
                                   OnCommand="getOTData" Text='<%# Eval("status") %>' Font-Underline=TRUE ></asp:LinkButton>
                            </ItemTemplate>
                              <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="OTEntryedit" Text="SAVE" CausesValidation=false  />
                            </FooterTemplate>  
                        </asp:TemplateField>
                        
                         <asp:BoundField DataField="Remark" HeaderText="Reason" SortExpression="Reason" />
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
        </tr>
    <tr>
        <td align="left" valign="top" style="height: 9px">
            &nbsp;</td>
        <td valign="top" style="height: 9px">
        </td>
    </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT empmaster.empcode, otentry.shift, otentry.RecNo, otentry.datecheck, Ltrim(rtrim(otentry.ottype)) as ottype, otentry.hrs, otentry.status, otentry.Remark FROM empmaster INNER JOIN Ot_TempTotWeekhrs ON empmaster.empcode = Ot_TempTotWeekhrs.empcode INNER JOIN otentry ON Ot_TempTotWeekhrs.recno= otentry.recno WHERE (otentry.empcode = @empcode) order by datecheck desc">
                    <SelectParameters>
                        <asp:SessionParameter  Name="empcode" SessionField="empcode" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT empmaster.empcode, otentry.shift, otentry.datecheck, otentry.ottype, otentry.hrs, otentry.status, Ot_TempTotWeekhrs.whrs FROM empmaster INNER JOIN Ot_TempTotWeekhrs ON empmaster.empcode = Ot_TempTotWeekhrs.empcode INNER JOIN otentry ON Ot_TempTotWeekhrs.recno = otentry.recno WHERE (otentry.empcode = @empcode) AND (otentry.datecheck >= @otdate) AND (otentry.datecheck <= @otto) AND (otentry.status = 'S') order by datecheck desc">
                    <SelectParameters>
                        <asp:SessionParameter  Name="empcode" SessionField="empcode" />
                        <asp:ControlParameter ControlID="lblfrom" Name="otdate" PropertyName="Text" />
                        <asp:ControlParameter ControlID="lblto" Name="otto" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Label ID="lblfrom" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblto" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblpass" runat="server" Visible="False">0</asp:Label>
                        <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="vfdt" targetcontrolid="vfdt"></cc1:calendarextender>
                <asp:Label ID="lbldbot" runat="server" Text="0" Visible="False"></asp:Label>
                                        <%--<cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="vtdt" targetcontrolid="vtdt"></cc1:calendarextender>--%>
                        </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 289px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr></asp:Content>
