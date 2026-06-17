<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintJs.aspx.vb" Inherits="E_Management.PrintJs" 
   %>
   <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
            <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
            
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
<table width = "670px">
                    <tr>
                        <td align="left" colspan="4" style="height: 17px; border-bottom: 1px solid;" valign="top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/maruwa_a.JPG" ImageAlign="Left" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label
                                ID="Label1" runat="server" Font-Size="Medium" Width="145px">JOB SPECIFICATION</asp:Label>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lbprint" runat="server" Font-Underline="True"
                                ForeColor="#0000C0" PostBackUrl="~/HRMIS/JS/PrintJs.aspx">Print</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblrecno" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 9px; height: 7px;">
                            EmpCode &nbsp; &nbsp;&nbsp;
                        </td>
                        <td style="width: 99px; height: 7px;">
                            <asp:Label ID="lblemp" runat="server"></asp:Label></td>
                        <td colspan="2" style="height: 7px; width: 494px;">
                            EmpName &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblename" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            Department</td>
                        <td colspan="3" style="width: 83px; height: 17px;">
                            <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            Section</td>
                        <td colspan="3" style="width: 83px; height: 17px;">
                            <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td >
                            Designation</td>
                        <td>
                            <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                        <td colspan="2" style="width: 494px" >
                            JobCode &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Label ID="lblcode" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 7px" align="center" class="TD_HEAD">
                        <hr />
                            JOB PURPOSE</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 14px">
                            <asp:Label ID="lblpurpose" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="td_head" colspan="4" style="height: 14px">
                            KEY RESULTS AREA</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 16px; background-color: beige">
                            <asp:GridView ID="grdkey" runat="server" AutoGenerateColumns="False" BorderColor="#404040"
                                BorderWidth="1px" CellPadding="4" DataSourceID="keygoaltemo"
                                ForeColor="Black" Width="100%" BorderStyle="Solid" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField DataField="sno" HeaderText="sno" SortExpression="sno" >
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" BorderColor="#404040" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#404040" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="man_keyresult" HeaderText="Key Result" SortExpression="man_keyresult" >
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" BorderColor="#404040" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#404040" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle ForeColor="Black" HorizontalAlign="Left" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                <SelectedRowStyle  ForeColor="Black" Font-Bold="True" />
                                <HeaderStyle  Font-Bold="True" HorizontalAlign="Left" ForeColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"  />
                                <RowStyle BackColor="White" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="keygoaltemo" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" SelectCommand="SELECT * FROM [man_keygoal] WHERE ([recordno] = @recordno) order by sno">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblrecno" Name="recordno" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="height: 17px" class="td_head">
                            ITEM PENDING/HANDOVER</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 17px">
                            <asp:Label ID="TXTITEM" runat="server" ForeColor="Maroon"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="td_head" colspan="4" style="height: 17px">
                            GOAL ALLIGNMENT</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 17px">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                DataSourceID="sqlgoal" ShowHeader="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" GridLines="None">
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <Columns>
                                    <asp:BoundField DataField="goalalign" HeaderText="goalalign" ReadOnly="True" SortExpression="goalalign" />
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="sqlgoal" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT '* ' + [goalalign] as goalalign FROM [man_goalalign] WHERE ([curyear] = @curyear) order by sno">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="Y" Name="curyear" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="td_head" colspan="4" style="height: 17px">
                            COMPETENCIES </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 17px">
                            TECHNICAL SKILLS
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 17px; background-color: beige">
                            <asp:CheckBoxList ID="cbtechnical" runat="server" AppendDataBoundItems="false" DataSourceID="sqltechnical"
                                DataTextField="skill" DataValueField="skill" RepeatColumns="3" RepeatDirection="Horizontal">
                            </asp:CheckBoxList>&nbsp;<asp:SqlDataSource ID="sqltechnical" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [skill] FROM [man_skillmatch] WHERE (([skilltitle] = @skilltitle) AND ([jobcode] = @jobcode))">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="Technical Skill" Name="skilltitle" Type="String" />
                                    <asp:ControlParameter ControlID="lblcode" Name="jobcode" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 17px">
                            BEHAVIOUR</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 17px; background-color: beige">
                            <asp:CheckBoxList ID="cbbehavior" runat="server" DataSourceID="SQLBEHAVIOUR" DataTextField="skill"
                                DataValueField="skill" RepeatColumns="3" RepeatDirection="Horizontal">
                            </asp:CheckBoxList><asp:SqlDataSource ID="SQLBEHAVIOUR" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [skill] FROM [man_skillmatch] WHERE (([jobcode] = @jobcode) AND ([skilltitle] = @skilltitle))">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblcode" Name="jobcode" PropertyName="Text" Type="String" />
                                    <asp:Parameter DefaultValue="Behavior" Name="skilltitle" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4" style="height: 17px">
                            </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4" style="height: 17px">
                        </td>
                    </tr>
                </table>
    </form>
</body>
</html>




