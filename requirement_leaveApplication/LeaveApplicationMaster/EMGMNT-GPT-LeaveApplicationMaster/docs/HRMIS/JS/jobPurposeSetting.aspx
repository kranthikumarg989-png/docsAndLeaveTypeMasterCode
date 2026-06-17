<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="jobPurposeSetting.aspx.vb" Inherits="E_Management.jobPurposeSetting" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding=0 cellspacing=0>
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 740px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 24px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff">
                            <table >
                                <tr>
                                    <td align="center" class="td_head" colspan="4" style="height: 17px" valign="middle">
                                        JOB PURPOSE ASSIGNMENT</td>
                                </tr>
                                <tr>
                                    <td style="height: 17px; background-color: beige">
                                        EmpCode</td>
                                    <td>
                                        <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox></td>
                                    <td style="background-color: beige">
                                        EmpName</td>
                                    <td style="background-color: beige">
                                        <asp:Label ID="lblename" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style=" background-color: beige">
                                        Department</td>
                                    <td style="background-color: beige">
                                        <asp:Label ID="lbldept" runat="server" ></asp:Label></td>
                                    <td style="background-color: beige">
                                        Section</td>
                                    <td style="background-color: beige">
                                        <asp:Label ID="lblsect" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige">
                                        Designation</td>
                                    <td  style="background-color: beige">
                                        <asp:Label ID="lbldesig" runat="server" ></asp:Label></td>
                                    <td  style="background-color: beige">
                                        JobCode</td>
                                    <td  style="background-color: beige"> 
                                        <asp:Label ID="lblcode" runat="server" ></asp:Label></td>  
                                </tr>
                                <tr>
                                    <td style="width: 290px; height: 17px; background-color: beige">
                                        Job Purpose</td>
                                    <td colspan="3" style="width: 66px; background-color: beige">
                                        <asp:Label ID="lblpurpose" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 290px; height: 17px; background-color: beige">
                                        New Job Purpose</td>
                                    <td colspan="3" style="height: 17px">
                                        <asp:TextBox ID="txtpurpose" runat="server" TextMode="MultiLine" Width="501px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 17px; background-color: beige">
                                        <asp:CheckBox ID="chbsave" runat="server" Text="Don't Overwrite Save as New     " TextAlign="Left"
                                            Width="165px" /></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4" style="height: 17px">
                                        <asp:Button ID="btnsave" runat="server" SkinID="buttonskin1" Text="Save" /></td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                DataSourceID="sqlpurpose" ForeColor="#333333" GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                                    <asp:BoundField DataField="jobcode" HeaderText="JobCode" SortExpression="jobcode" />
                                    <asp:BoundField DataField="jobpurpose" HeaderText="JobPurpose" SortExpression="jobpurpose" />
                                    <asp:BoundField DataField="setby" HeaderText="SetBy" SortExpression="setby" />
                                    <asp:BoundField DataField="dateset" DataFormatString="{0:dd-MMM-yy}" HtmlEncode="false" HeaderText="SetOn"
                                        SortExpression="dateset" />
                                    <asp:BoundField DataField="version" HeaderText="Version" SortExpression="version" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="sqlpurpose" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [empcode], [jobcode], [jobpurpose], [setby], [dateset], [version] FROM [man_jobpurpose] WHERE ([empcode] = @empcode)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtempcode" Name="empcode" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        
                          </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 740px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
</asp:Content>
