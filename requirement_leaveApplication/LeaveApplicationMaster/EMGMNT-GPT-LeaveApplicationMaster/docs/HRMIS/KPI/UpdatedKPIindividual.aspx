<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="UpdatedKPIindividual.aspx.vb" Inherits="E_Management.UpdatedKPIindividual" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 617px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 352px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 617px; height: 352px;" valign="top">
                &nbsp;&nbsp;<br />
                <table style="width: 476px">
                    <tr>
                        <td colspan="3">
                        </td>
                    </tr>
                         <tr>
                      
                   
                                    <td style="height: 17px; background-color: beige; width: 123px;">
                                        EmpCode</td>
                                    <td style="width: 184px; background-color: beige;">
                                        <asp:Label ID="lblempcode" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; ">
                                        EmpName</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 123px;">
                                        Department</td>
                                    <td style="background-color: beige; width: 184px;">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: beige;">
                                        Section</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 123px;">
                                        Designation</td>
                                    <td style="background-color: beige; width: 184px;">
                                        <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; width: 120px;">
                                        Month</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblmonth" runat="server"></asp:Label></td>
                                </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Daily Update">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="Sqldaily" ForeColor="Black"
                                    GridLines="Vertical" ShowFooter="True" EmptyDataText="No daily update KPI">
                                    <Columns>
                                        <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                            SortExpression="slno" />
                                        <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                                        <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                                        <asp:BoundField DataField="curent" HeaderText="Curent" SortExpression="curent" />
                                        <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                        <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                                        <asp:TemplateField HeaderText="day1" SortExpression="day1">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("day1") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 81px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t1" runat="server" Text='<%# Eval("day1") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 81px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a1" runat="server" Text='<%# Eval("act1") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r1" runat="server" Text='<%# Bind("res1") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day2" SortExpression="day2">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("day2") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                             <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t2" runat="server" Text='<%# Eval("day2") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a2" runat="server" Text='<%# Eval("act2") %>' Width="43px"></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r2" runat="server" Text='<%# Bind("res2") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day3" SortExpression="day3">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("day3") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                               <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t3" runat="server" Text='<%# Eval("day3") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a3" runat="server" Text='<%# Eval("act3") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r3" runat="server" Text='<%# Bind("res3") %>' Width="35px"></asp:label></td>
                                                    </tr>
                                                </table> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day4" SortExpression="day4">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("day4") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                               <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t4" runat="server" Text='<%# Eval("day4") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a4" runat="server" Text='<%# Eval("act4") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r4" runat="server" Text='<%# Bind("res4") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day5" SortExpression="day5">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("day5") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t5" runat="server" Text='<%# Eval("day5") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="a5" runat="server" Text='<%# Eval("act5") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r5" runat="server" Text='<%# Bind("res5") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day6" SortExpression="day6">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("day6") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t6" runat="server" Text='<%# Eval("day6") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a6" runat="server" Text='<%# Eval("act6") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r6" runat="server" Text='<%# Bind("res6") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day7" SortExpression="day7">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("day7") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t7" runat="server" Text='<%# Eval("day7") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a7" runat="server" Text='<%# Eval("act7") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r7" runat="server" Text='<%# Bind("res7") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>     </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day8" SortExpression="day8">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("day8") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                             <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t8" runat="server" Text='<%# Eval("day8") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="a7" runat="server" Text='<%# Eval("act7") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r8" runat="server" Text='<%# Bind("res8") %>' Width="37px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day9" SortExpression="day9">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("day9") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t9" runat="server" Text='<%# Eval("day9") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a9" runat="server" Text='<%# Eval("act9") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r9" runat="server" Text='<%# Bind("res9") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day10" SortExpression="day10">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("day10") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                               <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t10" runat="server" Text='<%# Eval("day10") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a10" runat="server" Text='<%# Eval("act10") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r10" runat="server" Text='<%# Bind("res10") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day11" SortExpression="day11">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("day11") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t11" runat="server" Text='<%# Eval("day11") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="a11" runat="server" Text='<%# Eval("act11") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r11" runat="server" Text='<%# Bind("res11") %>' Width="40px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day12" SortExpression="day12">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("day12") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t12" runat="server" Text='<%# Eval("day12") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a12" runat="server" Text='<%# Eval("act12") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r12" runat="server" Text='<%# Bind("res12") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day13" SortExpression="day13">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("day13") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t13" runat="server" Text='<%# Eval("day13") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a13" runat="server" Text='<%# Eval("act13") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r13" runat="server" Text='<%# Bind("res13") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>
                                              </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day14" SortExpression="day14">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("day14") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                               <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t14" runat="server" Text='<%# Eval("day14") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a14" runat="server" Text='<%# Eval("act14") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r14" runat="server" Text='<%# Bind("res14") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day15" SortExpression="day15">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("day15") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                             <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t15" runat="server" Text='<%# Eval("day15") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a15" runat="server" Text='<%# Eval("act15") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r15" runat="server" Text='<%# Bind("res15") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>    </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day16" SortExpression="day16">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("day16") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t16" runat="server" Text='<%# Eval("day16") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a16" runat="server" Text='<%# Eval("act16") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r16" runat="server" Text='<%# Bind("res16") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day17" SortExpression="day17">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("day17") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t17" runat="server" Text='<%# Eval("day17") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="a17" runat="server" Text='<%# Eval("act17") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r17" runat="server" Text='<%# Bind("res17") %>' Width="44px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day18" SortExpression="day18">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("day18") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t18" runat="server" Text='<%# Eval("day18") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a18" runat="server" Text='<%# Eval("act18") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r18" runat="server" Text='<%# Bind("res18") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day19" SortExpression="day19">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("day19") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t19" runat="server" Text='<%# Eval("day19") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a19" runat="server" Text='<%# Eval("act19") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r19" runat="server" Text='<%# Bind("res19") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day20" SortExpression="day20">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("day20") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                           <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t20" runat="server" Text='<%# Eval("day20") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a20" runat="server" Text='<%# Eval("act20") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r20" runat="server" Text='<%# Bind("res20") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>     </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day21" SortExpression="day21">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("day21") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                             <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t21" runat="server" Text='<%# Eval("day21") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a21" runat="server" Text='<%# Eval("act21") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r21" runat="server" Text='<%# Bind("res21") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day22" SortExpression="day22">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("day22") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                               <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t22" runat="server" Text='<%# Eval("day22") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a22" runat="server" Text='<%# Eval("act22") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r22" runat="server" Text='<%# Bind("res22") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day23" SortExpression="day23">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("day23") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t23" runat="server" Text='<%# Eval("day23") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a23" runat="server" Text='<%# Eval("act23") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r23" runat="server" Text='<%# Bind("res23") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day24" SortExpression="day24">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox24" runat="server" Text='<%# Bind("day24") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t24" runat="server" Text='<%# Eval("day24") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a24" runat="server" Text='<%# Eval("act24") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r24" runat="server" Text='<%# Bind("res24") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day25" SortExpression="day25">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox25" runat="server" Text='<%# Bind("day25") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                        <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t25" runat="server" Text='<%# Eval("day25") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a25" runat="server" Text='<%# Eval("act25") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r25" runat="server" Text='<%# Bind("res25") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>          </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day26" SortExpression="day26">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox26" runat="server" Text='<%# Bind("day26") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                             <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t26" runat="server" Text='<%# Eval("day26") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a26" runat="server" Text='<%# Eval("act26") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r26" runat="server" Text='<%# Bind("res26") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>    </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day27" SortExpression="day27">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox27" runat="server" Text='<%# Bind("day27") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t27" runat="server" Text='<%# Eval("day27") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a27" runat="server" Text='<%# Eval("act27") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r27" runat="server" Text='<%# Bind("res27") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day28" SortExpression="day28">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox28" runat="server" Text='<%# Bind("day28") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t28" runat="server" Text='<%# Eval("day28") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a28" runat="server" Text='<%# Eval("act28") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r28" runat="server" Text='<%# Bind("res28") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day29" SortExpression="day29">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox29" runat="server" Text='<%# Bind("day29") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                             <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t29" runat="server" Text='<%# Eval("day29") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a29" runat="server" Text='<%# Eval("act29") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r29" runat="server" Text='<%# Bind("res29") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day30" SortExpression="day30">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox30" runat="server" Text='<%# Bind("day30") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                              <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t30" runat="server" Text='<%# Eval("day30") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a30" runat="server" Text='<%# Eval("act30") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r30" runat="server" Text='<%# Bind("res30") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table>   </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="day31" SortExpression="day31">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("day31") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Target</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Actual</td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            Result</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:Label ID="t31" runat="server" Text='<%# Eval("day31") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            &nbsp;<asp:Label ID="a31" runat="server" Text='<%# Eval("act31") %>'></asp:Label></td>
                                                        <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            width: 100px; border-bottom: #666666 1px solid">
                                                            <asp:label ID="r31" runat="server" Text='<%# Bind("res31") %>' Width="53px"></asp:label></td>
                                                    </tr>
                                                </table> </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Finaltotal" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                     <asp:Label ID="fintotalavg" runat="server" Text="0"></asp:Label>
                                             </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                                &nbsp;
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Panel ID="Panel2" runat="server" GroupingText="Weekly Update">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="Sqlweekly" ForeColor="Black"
                                    GridLines="Vertical" ShowFooter="True" EmptyDataText="No weekly update KPI">
                                <Columns>
                                    <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                            SortExpression="slno" />
                                    <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                                    <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                                    <asp:BoundField DataField="curent" HeaderText="Curent" SortExpression="curent" />
                                    <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                    <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                                    <asp:TemplateField HeaderText="Week1" SortExpression="day1">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("day1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                             border-bottom: #666666 1px solid">
                                                        Target</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        Actual</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                         border-bottom: #666666 1px solid">
                                                        Result</td>
                                                </tr>
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                             border-bottom: #666666 1px solid">
                                                        <asp:Label ID="t1" runat="server" Text='<%# Eval("day1") %>'></asp:Label></td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        <asp:Label ID="a1" runat="server" Text='<%# Eval("act1") %>'></asp:Label></td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        <asp:label ID="r1" runat="server" Text='<%# Bind("res1") %>' Width="53px"></asp:label></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="week2" SortExpression="day2">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("day2") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                             border-bottom: #666666 1px solid">
                                                        Target</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                           border-bottom: #666666 1px solid">
                                                        Actual</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                             border-bottom: #666666 1px solid">
                                                        Result</td>
                                                </tr>
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                             border-bottom: #666666 1px solid">
                                                        <asp:Label ID="t2" runat="server" Text='<%# Eval("day2") %>'></asp:Label></td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        <asp:Label ID="a2" runat="server" Text='<%# Eval("act3") %>'></asp:Label></td>
                                                
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                           border-bottom: #666666 1px solid">
                                                        <asp:label ID="r2" runat="server" Text='<%# Bind("res2") %>' Width="53px"></asp:label></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="week3" SortExpression="day3">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("day3") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        Target</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        Actual</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                           border-bottom: #666666 1px solid">
                                                        Result</td>
                                                </tr>
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                       border-bottom: #666666 1px solid">
                                                        <asp:Label ID="t3" runat="server" Text='<%# Eval("day3") %>'></asp:Label></td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                         border-bottom: #666666 1px solid">
                                                        <asp:Label ID="a3" runat="server" Text='<%# Eval("act3") %>'></asp:Label></td>
                                                
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                        border-bottom: #666666 1px solid">
                                                        <asp:label ID="r3" runat="server" Text='<%# Bind("res3") %>' Width="53px"></asp:label></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Week4" SortExpression="day4">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("day4") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        Target</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                         border-bottom: #666666 1px solid">
                                                        Actual</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                        border-bottom: #666666 1px solid">
                                                        Result</td>
                                                </tr>
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                       border-bottom: #666666 1px solid">
                                                        <asp:Label ID="t4" runat="server" Text='<%# Eval("day4") %>'></asp:Label></td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                   border-bottom: #666666 1px solid">
                                                        <asp:Label ID="a4" runat="server" Text='<%# Eval("act4") %>'></asp:Label></td>
                                                
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                        <asp:label ID="r4" runat="server" Text='<%# Bind("res4") %>' Width="53px"></asp:label></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Finaltotal1" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                     <asp:Label ID="fintotalavg1" runat="server" Text="0"></asp:Label>
                                             </FooterTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                            &nbsp;
                        </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Panel ID="Panel3" runat="server" GroupingText="Monthly Update">
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black"
                                    GridLines="Vertical" ShowFooter="True" EmptyDataText="No Monthly update KPI">
                                <Columns>
                                    <asp:BoundField DataField="slno" HeaderText="slno" InsertVisible="False" ReadOnly="True"
                                            SortExpression="slno" />
                                    <asp:BoundField DataField="MajorKPI_Details" HeaderText="MajorKPI" SortExpression="MajorKPI_Details" />
                                    <asp:BoundField DataField="SubKPI_Details" HeaderText="SubKPI" SortExpression="SubKPI_Details" />
                                    <asp:BoundField DataField="curent" HeaderText="Curent" SortExpression="curent" />
                                    <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                                    <asp:BoundField DataField="subweightage" HeaderText="Weightage" SortExpression="subweightage" />
                                    <asp:TemplateField HeaderText="Marks" SortExpression="day1">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("day1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <table style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                    border-bottom: #666666 1px solid">
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                            border-bottom: #666666 1px solid">
                                                        Target</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                             border-bottom: #666666 1px solid">
                                                        Actual</td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                        border-bottom: #666666 1px solid">
                                                        Result</td>
                                                </tr>
                                                <tr>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                          border-bottom: #666666 1px solid">
                                                        <asp:Label ID="t1" runat="server" Text='<%# Eval("day1") %>'></asp:Label></td>
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                           border-bottom: #666666 1px solid">
                                                        <asp:Label ID="a1" runat="server" Text='<%# Eval("act1") %>'></asp:Label></td>
                                                
                                                    <td style="border-right: #666666 1px solid; border-top: #666666 1px solid; border-left: #666666 1px solid;
                                                          border-bottom: #666666 1px solid">
                                                        <asp:label ID="r1" runat="server" Text='<%# Bind("res1") %>' Width="53px"></asp:label></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Finaltotal2" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                     <asp:Label ID="fintotalavg2" runat="server" Text="0"></asp:Label>
                                             </FooterTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                            &nbsp;
                        </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="TOTAL:"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:Label ID="LBLTOT" runat="server" BackColor="#FFFFC0" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#FF8000" Text="0"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="GRADE:"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:Label
                                ID="LBLGRADE" runat="server" Text="0" BackColor="#FFFFC0" Font-Bold="True" Font-Size="Medium" ForeColor="#FF8000"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px">
                            <asp:Label ID="lblmon" runat="server" Visible="False"></asp:Label><asp:Label ID="lblyr" runat="server" Visible="False"></asp:Label><asp:Label ID="lblrev" runat="server" ForeColor="Maroon" Visible="False"></asp:Label><asp:Label
                                ID="lblrev1" runat="server" ForeColor="Maroon" Visible="False"></asp:Label></td>
                    </tr>
                </table>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                              SelectCommand="SELECT KPI_dailyupdate.slno, KPI_dailyupdate.Major_KPINO, KPI_dailyupdate.MajorKPI_Details, KPI_dailyupdate.Sub_KPINO, KPI_dailyupdate.SubKPI_Details, KPI_dailyupdate.subweightage, KPI_dailyupdate.q1, KPI_dailyupdate.q2, KPI_dailyupdate.q3, KPI_dailyupdate.q4, KPI_dailyupdate.uom, KPI_dailyupdate.curent, KPI_dailyupdate.target, KPI_dailyupdate.Individual, KPI_dailyupdate.Employee_Code, KPI_dailyupdate.Department_Code, KPI_dailyupdate.day1, KPI_dailyupdate.act1, KPI_dailyupdate.res1, KPI_dailyupdate.day2, KPI_dailyupdate.act2, KPI_dailyupdate.res2, KPI_dailyupdate.day3, KPI_dailyupdate.act3, KPI_dailyupdate.res3, KPI_dailyupdate.day4, KPI_dailyupdate.act4, KPI_dailyupdate.res4, KPI_dailyupdate.day5, KPI_dailyupdate.act5, KPI_dailyupdate.res5, KPI_dailyupdate.day6, KPI_dailyupdate.act6, KPI_dailyupdate.res6, KPI_dailyupdate.day7, KPI_dailyupdate.act7, KPI_dailyupdate.res7, KPI_dailyupdate.day8, KPI_dailyupdate.act8, KPI_dailyupdate.res8, KPI_dailyupdate.day9, KPI_dailyupdate.act9, KPI_dailyupdate.res9, KPI_dailyupdate.day10, KPI_dailyupdate.act10, KPI_dailyupdate.res10, KPI_dailyupdate.day11, KPI_dailyupdate.act11, KPI_dailyupdate.res11, KPI_dailyupdate.day12, KPI_dailyupdate.act12, KPI_dailyupdate.res12, KPI_dailyupdate.day13, KPI_dailyupdate.act13, KPI_dailyupdate.res13, KPI_dailyupdate.day14, KPI_dailyupdate.act14, KPI_dailyupdate.res14, KPI_dailyupdate.day15, KPI_dailyupdate.act15, KPI_dailyupdate.res15, KPI_dailyupdate.day16, KPI_dailyupdate.act16, KPI_dailyupdate.res16, KPI_dailyupdate.day17, KPI_dailyupdate.act17, KPI_dailyupdate.res17, KPI_dailyupdate.day18, KPI_dailyupdate.act18, KPI_dailyupdate.res18, KPI_dailyupdate.day19, KPI_dailyupdate.act19, KPI_dailyupdate.res19, KPI_dailyupdate.day20, KPI_dailyupdate.act20, KPI_dailyupdate.res20, KPI_dailyupdate.day21, KPI_dailyupdate.act21, KPI_dailyupdate.res21, KPI_dailyupdate.day22, KPI_dailyupdate.act22, KPI_dailyupdate.res22, KPI_dailyupdate.day23, KPI_dailyupdate.act23, KPI_dailyupdate.res23, KPI_dailyupdate.day24, KPI_dailyupdate.act24, KPI_dailyupdate.res24, KPI_dailyupdate.day25, KPI_dailyupdate.act25, KPI_dailyupdate.res25, KPI_dailyupdate.day26, KPI_dailyupdate.act26, KPI_dailyupdate.res26, KPI_dailyupdate.day27, KPI_dailyupdate.act27, KPI_dailyupdate.res27, KPI_dailyupdate.day28, KPI_dailyupdate.act28, KPI_dailyupdate.res28, KPI_dailyupdate.day29, KPI_dailyupdate.act29, KPI_dailyupdate.res29, KPI_dailyupdate.day30, KPI_dailyupdate.act30, KPI_dailyupdate.res30, KPI_dailyupdate.day31, KPI_dailyupdate.act31, KPI_dailyupdate.res31, KPI_dailyupdate.revision, KPI_dailyupdate.Pdate, KPI_dailyupdate.PreparedBy, KPI_dailyupdate.ModifiedBy, KPI_dailyupdate.Mdate, KPI_dailyupdate.KPI_Year, KPI_dailyupdate.repeat, KPI_dailyupdate.checked, KPI_dailyupdate.KPI_Month, KPI_IndividualSetting.updbasis FROM KPI_dailyupdate INNER JOIN KPI_IndividualSetting ON KPI_dailyupdate.linkno = KPI_IndividualSetting.slno WHERE (KPI_dailyupdate.Employee_Code = @Employee_Code) AND (KPI_dailyupdate.KPI_Year = @KPI_Year) AND (KPI_dailyupdate.KPI_Month = @KPI_Month) AND (KPI_dailyupdate.revision = @revision) AND (KPI_IndividualSetting.updbasis = 'M')">
                                  <SelectParameters>
                                      <asp:ControlParameter ControlID="lblempcode" Name="Employee_Code" PropertyName="Text"
                                          Type="String" />
                                    <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="lblmon" Name="KPI_Month" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sqlweekly" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                 SelectCommand="SELECT KPI_dailyupdate.slno, KPI_dailyupdate.Major_KPINO, KPI_dailyupdate.MajorKPI_Details, KPI_dailyupdate.Sub_KPINO, KPI_dailyupdate.SubKPI_Details, KPI_dailyupdate.subweightage, KPI_dailyupdate.q1, KPI_dailyupdate.q2, KPI_dailyupdate.q3, KPI_dailyupdate.q4, KPI_dailyupdate.uom, KPI_dailyupdate.curent, KPI_dailyupdate.target, KPI_dailyupdate.Individual, KPI_dailyupdate.Employee_Code, KPI_dailyupdate.Department_Code, KPI_dailyupdate.day1, KPI_dailyupdate.act1, KPI_dailyupdate.res1, KPI_dailyupdate.day2, KPI_dailyupdate.act2, KPI_dailyupdate.res2, KPI_dailyupdate.day3, KPI_dailyupdate.act3, KPI_dailyupdate.res3, KPI_dailyupdate.day4, KPI_dailyupdate.act4, KPI_dailyupdate.res4, KPI_dailyupdate.day5, KPI_dailyupdate.act5, KPI_dailyupdate.res5, KPI_dailyupdate.day6, KPI_dailyupdate.act6, KPI_dailyupdate.res6, KPI_dailyupdate.day7, KPI_dailyupdate.act7, KPI_dailyupdate.res7, KPI_dailyupdate.day8, KPI_dailyupdate.act8, KPI_dailyupdate.res8, KPI_dailyupdate.day9, KPI_dailyupdate.act9, KPI_dailyupdate.res9, KPI_dailyupdate.day10, KPI_dailyupdate.act10, KPI_dailyupdate.res10, KPI_dailyupdate.day11, KPI_dailyupdate.act11, KPI_dailyupdate.res11, KPI_dailyupdate.day12, KPI_dailyupdate.act12, KPI_dailyupdate.res12, KPI_dailyupdate.day13, KPI_dailyupdate.act13, KPI_dailyupdate.res13, KPI_dailyupdate.day14, KPI_dailyupdate.act14, KPI_dailyupdate.res14, KPI_dailyupdate.day15, KPI_dailyupdate.act15, KPI_dailyupdate.res15, KPI_dailyupdate.day16, KPI_dailyupdate.act16, KPI_dailyupdate.res16, KPI_dailyupdate.day17, KPI_dailyupdate.act17, KPI_dailyupdate.res17, KPI_dailyupdate.day18, KPI_dailyupdate.act18, KPI_dailyupdate.res18, KPI_dailyupdate.day19, KPI_dailyupdate.act19, KPI_dailyupdate.res19, KPI_dailyupdate.day20, KPI_dailyupdate.act20, KPI_dailyupdate.res20, KPI_dailyupdate.day21, KPI_dailyupdate.act21, KPI_dailyupdate.res21, KPI_dailyupdate.day22, KPI_dailyupdate.act22, KPI_dailyupdate.res22, KPI_dailyupdate.day23, KPI_dailyupdate.act23, KPI_dailyupdate.res23, KPI_dailyupdate.day24, KPI_dailyupdate.act24, KPI_dailyupdate.res24, KPI_dailyupdate.day25, KPI_dailyupdate.act25, KPI_dailyupdate.res25, KPI_dailyupdate.day26, KPI_dailyupdate.act26, KPI_dailyupdate.res26, KPI_dailyupdate.day27, KPI_dailyupdate.act27, KPI_dailyupdate.res27, KPI_dailyupdate.day28, KPI_dailyupdate.act28, KPI_dailyupdate.res28, KPI_dailyupdate.day29, KPI_dailyupdate.act29, KPI_dailyupdate.res29, KPI_dailyupdate.day30, KPI_dailyupdate.act30, KPI_dailyupdate.res30, KPI_dailyupdate.day31, KPI_dailyupdate.act31, KPI_dailyupdate.res31, KPI_dailyupdate.revision, KPI_dailyupdate.Pdate, KPI_dailyupdate.PreparedBy, KPI_dailyupdate.ModifiedBy, KPI_dailyupdate.Mdate, KPI_dailyupdate.KPI_Year, KPI_dailyupdate.repeat, KPI_dailyupdate.checked, KPI_dailyupdate.KPI_Month, KPI_IndividualSetting.updbasis FROM KPI_dailyupdate INNER JOIN KPI_IndividualSetting ON KPI_dailyupdate.linkno = KPI_IndividualSetting.slno WHERE (KPI_dailyupdate.Employee_Code = @Employee_Code) AND (KPI_dailyupdate.KPI_Year = @KPI_Year) AND (KPI_dailyupdate.KPI_Month = @KPI_Month) AND (KPI_dailyupdate.revision = @revision) AND (KPI_IndividualSetting.updbasis = 'W')">
                               
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblempcode" Name="Employee_Code" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="lblmon" Name="KPI_Month" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                                <asp:SqlDataSource ID="Sqldaily" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT KPI_dailyupdate.slno, KPI_dailyupdate.Major_KPINO, KPI_dailyupdate.MajorKPI_Details, KPI_dailyupdate.Sub_KPINO, KPI_dailyupdate.SubKPI_Details, KPI_dailyupdate.subweightage, KPI_dailyupdate.q1, KPI_dailyupdate.q2, KPI_dailyupdate.q3, KPI_dailyupdate.q4, KPI_dailyupdate.uom, KPI_dailyupdate.curent, KPI_dailyupdate.target, KPI_dailyupdate.Individual, KPI_dailyupdate.Employee_Code, KPI_dailyupdate.Department_Code, KPI_dailyupdate.day1, KPI_dailyupdate.act1, KPI_dailyupdate.res1, KPI_dailyupdate.day2, KPI_dailyupdate.act2, KPI_dailyupdate.res2, KPI_dailyupdate.day3, KPI_dailyupdate.act3, KPI_dailyupdate.res3, KPI_dailyupdate.day4, KPI_dailyupdate.act4, KPI_dailyupdate.res4, KPI_dailyupdate.day5, KPI_dailyupdate.act5, KPI_dailyupdate.res5, KPI_dailyupdate.day6, KPI_dailyupdate.act6, KPI_dailyupdate.res6, KPI_dailyupdate.day7, KPI_dailyupdate.act7, KPI_dailyupdate.res7, KPI_dailyupdate.day8, KPI_dailyupdate.act8, KPI_dailyupdate.res8, KPI_dailyupdate.day9, KPI_dailyupdate.act9, KPI_dailyupdate.res9, KPI_dailyupdate.day10, KPI_dailyupdate.act10, KPI_dailyupdate.res10, KPI_dailyupdate.day11, KPI_dailyupdate.act11, KPI_dailyupdate.res11, KPI_dailyupdate.day12, KPI_dailyupdate.act12, KPI_dailyupdate.res12, KPI_dailyupdate.day13, KPI_dailyupdate.act13, KPI_dailyupdate.res13, KPI_dailyupdate.day14, KPI_dailyupdate.act14, KPI_dailyupdate.res14, KPI_dailyupdate.day15, KPI_dailyupdate.act15, KPI_dailyupdate.res15, KPI_dailyupdate.day16, KPI_dailyupdate.act16, KPI_dailyupdate.res16, KPI_dailyupdate.day17, KPI_dailyupdate.act17, KPI_dailyupdate.res17, KPI_dailyupdate.day18, KPI_dailyupdate.act18, KPI_dailyupdate.res18, KPI_dailyupdate.day19, KPI_dailyupdate.act19, KPI_dailyupdate.res19, KPI_dailyupdate.day20, KPI_dailyupdate.act20, KPI_dailyupdate.res20, KPI_dailyupdate.day21, KPI_dailyupdate.act21, KPI_dailyupdate.res21, KPI_dailyupdate.day22, KPI_dailyupdate.act22, KPI_dailyupdate.res22, KPI_dailyupdate.day23, KPI_dailyupdate.act23, KPI_dailyupdate.res23, KPI_dailyupdate.day24, KPI_dailyupdate.act24, KPI_dailyupdate.res24, KPI_dailyupdate.day25, KPI_dailyupdate.act25, KPI_dailyupdate.res25, KPI_dailyupdate.day26, KPI_dailyupdate.act26, KPI_dailyupdate.res26, KPI_dailyupdate.day27, KPI_dailyupdate.act27, KPI_dailyupdate.res27, KPI_dailyupdate.day28, KPI_dailyupdate.act28, KPI_dailyupdate.res28, KPI_dailyupdate.day29, KPI_dailyupdate.act29, KPI_dailyupdate.res29, KPI_dailyupdate.day30, KPI_dailyupdate.act30, KPI_dailyupdate.res30, KPI_dailyupdate.day31, KPI_dailyupdate.act31, KPI_dailyupdate.res31, KPI_dailyupdate.revision, KPI_dailyupdate.Pdate, KPI_dailyupdate.PreparedBy, KPI_dailyupdate.ModifiedBy, KPI_dailyupdate.Mdate, KPI_dailyupdate.KPI_Year, KPI_dailyupdate.repeat, KPI_dailyupdate.checked, KPI_dailyupdate.KPI_Month, KPI_IndividualSetting.updbasis, KPI_IndividualSetting.slno AS Expr1 FROM KPI_dailyupdate INNER JOIN KPI_IndividualSetting ON KPI_dailyupdate.linkno = KPI_IndividualSetting.slno WHERE (KPI_dailyupdate.Employee_Code = @Employee_Code)  AND (KPI_dailyupdate.KPI_Year = @KPI_Year) AND (KPI_dailyupdate.KPI_Month = @KPI_Month) AND (KPI_dailyupdate.revision = @revision) AND (KPI_IndividualSetting.updbasis = 'D')">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblempcode" Name="Employee_Code" PropertyName="Text"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="lblyr" Name="KPI_Year" PropertyName="Text" Type="Int32"  />
                                        <asp:ControlParameter ControlID="lblmon" Name="KPI_Month" PropertyName="Text" Type="Int32" />
                                        <asp:ControlParameter ControlID="lblrev" Name="revision" PropertyName="Text" Type="Int32"  />
                                    </SelectParameters>
                                </asp:SqlDataSource>
               
               
                 </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 352px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 617px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>

</asp:Content>
