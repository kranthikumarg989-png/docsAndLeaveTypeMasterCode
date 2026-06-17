<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OTphMaster.aspx.vb" Inherits="E_Management.OTphMaster" 
      title="OT TMS PH Master" %>
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

<table style="width: 1500px; height: 145px" id="TABLE2">
        <tr>
            <td style="width: 276px; height: 249px;" valign="top" align="left">
                <table width="1000">
                    <tr>
                        <td style="width: 1990px" align="left" valign="top">
                <table id="TABLE1"style="width: 450px; height: 120px" align="center" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="3" style="height: 12px" valign="top" align="left">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="OT BUDGET PH MASTER"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 441px; background-color: beige; height: 34px;" valign="top" align="left">
                            <asp:Label ID="frmdt" runat="server" Text="ENTER A/Cs YEAR"></asp:Label></td>
                        <td style="width: 391px;" valign="top" align="left">
                    
                        <asp:TextBox ID="phfromdate" runat="server" Width="180px"></asp:TextBox>
                        <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="phfromdate" targetcontrolid="phfromdate"></cc1:calendarextender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="phfromdate"
                                    ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                            &nbsp;
                        </td>
                        <td align="left" style="width: 2881px;" valign="top">
                           
                        <asp:TextBox ID="phtodate" runat="server"  Width="180px"></asp:TextBox>
                                        <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="phtodate" targetcontrolid="phtodate"></cc1:calendarextender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="phtodate"
                                    ErrorMessage="Please Select End Date"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 441px; background-color: beige; height: 34px;" valign="top" align="left">
                            &nbsp;<asp:Label ID="holi" runat="server" Text="HOLIDAY"></asp:Label></td>
                        <td style="width: 391px;" valign="top" align="left">
                            <asp:TextBox ID="phdate" runat="server" Width="180px"></asp:TextBox>
                            <cc1:calendarextender id="ccelh" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="phdate" targetcontrolid="phdate"></cc1:calendarextender>
                            
                        </td>
                        <td align="left" style="width: 2881px;" valign="top">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="phdate"
                                ErrorMessage="Please Select a Date for Holiday"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 441px; background-color: beige; height: 34px;" valign="top" align="left">
                            <asp:Label ID="category" runat="server" Text="CATEGORY"></asp:Label></td>
                        <td style="width: 391px;" valign="top" align="left">
                            <asp:DropDownList ID="categorydate" runat="server" Width="185px">
                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                <asp:ListItem Selected="True">PH</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        <td align="left" style="width: 2881px" valign="top">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="categorydate"
                                    ErrorMessage="Please Select Category" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="height: 26px;" valign="top" align="center" colspan="3">
                            <asp:Label ID="lbledit" runat="server" Text="-" Visible="False" Width="32px"></asp:Label><asp:Button ID="SubmitPH" runat="server" Text="SUBMIT" />&nbsp; &nbsp;<asp:Button ID="cancelOT" runat="server" Text="CANCEL" /></td>
                    </tr>
                </table>
                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        <td style="width: 17679px" valign="top">
                            <asp:GridView ID="OTmaster" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" ShowFooter="True" PageSize="25" Width="435px" AllowSorting="True">
                                <Columns>
                                    <asp:BoundField DataField="sno" HeaderText="S.No" InsertVisible="False" SortExpression="sno" />
                                    <asp:BoundField DataField="phfromdate" HeaderText="FROM DATE" SortExpression="phfromdate" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="phtodate" HeaderText="TO DATE" SortExpression="phtodate" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="phdate" HeaderText="HOLIDAYS" SortExpression="phdate" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField DataField="categorydate" HeaderText="CATEGORY" SortExpression="categorydate" />
                         <%--       <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:Button ID="btndel" runat="server" OnClick="delroc" Text="DELETE" CausesValidation="false" />
                                </FooterTemplate>
                    </asp:TemplateField>--%></Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [phfromdate], [phtodate], [phdate], [categorydate], [sno] FROM [TMS_PHMASTER]">
                            </asp:SqlDataSource>
                            <asp:Label ID="lblmsg1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                            
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] + '-' + sectionname as section, sectioncode FROM [sectionmaster]"></asp:SqlDataSource>
                &nbsp;<br />
                &nbsp;
                </td>
                </table>
                </table>
                </asp:Content>
