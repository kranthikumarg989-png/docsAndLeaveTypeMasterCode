<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OTentryCategory.aspx.vb" Inherits="E_Management.OTentryCategory" 
    title="OT Entry by Category" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
 
                <table id="TABLE1" style="border-right: #cccccc 1px solid; border-top: #cccccc 1px solid; border-left: #cccccc 1px solid; border-bottom: #cccccc 1px solid">
                    <tr>
                        <td align="left" colspan="2" rowspan="1" style="height: 30px; background-color: beige"
                            valign="top"><asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="OT ENTRY BY CATEGORY"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="background-color: beige" valign="top">
                            <asp:Label ID="frmdt" runat="server" Text="OT Date"></asp:Label></td>
                        <td align="left" style="width: 382px" valign="top">
                            <asp:TextBox ID="otdate" runat="server" Width="180px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator10" runat="server" ControlToValidate="otdate" ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="otdate"
                                ErrorMessage="Please Select OT Date"></asp:RequiredFieldValidator>--%></td>
                    </tr>
                    <tr>
                        <td align="left" style="background-color: beige;" valign="top" rowspan="">
                            <asp:Label ID="Otelig" runat="server" Text="OT Entry by"></asp:Label></td>
                        <td align="left" valign="top" rowspan="">
                            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButtonList ID="rb1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                Width="275px">
                                <asp:ListItem Value="Dept">By Dept.</asp:ListItem>
                                <asp:ListItem Value="sect">By Sect.</asp:ListItem>
                                <asp:ListItem Value="ecode">By Emp. Code</asp:ListItem>
                                </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rb1"
                                ErrorMessage="!"></asp:RequiredFieldValidator>&nbsp;
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rb1"
                                ErrorMessage="Please Select Your Choice"></asp:RequiredFieldValidator>--%>

                            </td>
                    </tr>
                    <tr>
                        <td align="left" style="background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="depart" runat="server" Text="Department"></asp:Label></td>
                        <td align="left" valign="top" rowspan="">
                            <asp:DropDownList ID="Deptddl" runat="server" DataSourceID="SqlDataSource9" DataTextField="NAME"
                                DataValueField="departmentCODE" Width="219px" AppendDataBoundItems="True" AutoPostBack="True"><asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                           <%--<asp:customValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="Deptddl"
                                   ErrorMessage="Please Select Department"></asp:customValidator>--%> </td>
                    </tr>
                    <tr>
                        <td align="left" style="background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="section" runat="server" Text="Section"></asp:Label></td>
                        <td align="left" valign="top" rowspan="">
                            <asp:DropDownList ID="Secddl" runat="server" DataSourceID="SqlDataSource8"
                                DataTextField="section" DataValueField="sectioncode" Width="219px" AppendDataBoundItems="True" AutoPostBack="True">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                                       </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Secddl"
                                ErrorMessage="Please Select Section" InitialValue="-1"></asp:RequiredFieldValidator>--%>
                            &nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td align="left" rowspan="1" style="background-color: beige"
                            valign="top">
                            <asp:Label ID="lbletype" runat="server" Text="EMP Type"></asp:Label></td>
                        <td align="left" rowspan="1" style="height: 26px" valign="top">
                            <asp:DropDownList ID="emptyp2" runat="server" Width="219px">
                                <asp:ListItem Value="-1" Selected="True">---Select---</asp:ListItem>
                                <asp:ListItem Value="ST">Staff</asp:ListItem>
                                <asp:ListItem Value="LO">Local Operator</asp:ListItem>
                                <asp:ListItem Value="FO">Foreign Operator</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="emptyp2"
                                ErrorMessage="Please Select Emp. Type" InitialValue="-1"></asp:RequiredFieldValidator>--%> </td>
                    </tr>
                    <tr>
                        <td align="left" style="background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="ecode" runat="server" Text="EMP code"></asp:Label></td>
                        <td align="left" valign="top" rowspan="">
                            <asp:TextBox ID="code" runat="server" MaxLength="10" Width="129px" AutoPostBack="True"></asp:TextBox>
                           <%-- <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="code"></asp:RegularExpressionValidator>--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="code"
                                ErrorMessage="Please Mention Maximum OT Hours"></asp:RequiredFieldValidator>--%>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" rowspan="" align="right">
                            <asp:Button
                                ID="Show1" runat="server" Text="SHOW" />&nbsp; &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" rowspan="1" style="height: 21px" valign="top">
                            <asp:Label ID="lbldt" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    </table>
                &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                DataSourceID="SqlDept" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Visible="False" ShowFooter="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="recno" HeaderText="Rec. No." SortExpression="recno" />
                        <asp:BoundField DataField="empcode" HeaderText="Emp. Code" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Emp. Name" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept - Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                &nbsp;
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbld1" runat="server" Text='<%# Eval("departmentcode") %>'></asp:Label>-
                                <asp:Label ID="lbls1" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shift" SortExpression="shift">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("shift") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="Ddldeptshift" runat="server" DataSourceID="SqlDataSource1"
                                    DataTextField="attcode" DataValueField="attcode" Width="101px" SelectedValue='<%# Bind("shift") %>'>
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT ltrim(rtrim(trans_shiftcode)) as attcode FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="OT" SortExpression="OT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("OT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="Rbdept" runat="server" SelectedValue='<%# Bind("OT") %>'
                                    Width="99px">
                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="whrs" HeaderText="Total OT Hrs in a Week" SortExpression="whrs" />
                        <asp:BoundField DataField="hrs" SortExpression="hrs"  />
                        <asp:TemplateField HeaderText="OT Hrs" SortExpression="hrs">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hrs") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="txtdepthrs" runat="server" Text='<%# Bind("hrs") %>' Width="52px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OT Type" SortExpression="ottype">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ottype") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:DropDownList ID="ddldepttype" runat="server" SelectedValue='<%# Bind("ottype") %>'
                                    Width="105px">
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                    <asp:ListItem>OTND</asp:ListItem>
                                    <asp:ListItem>OTPH</asp:ListItem>
                                    <asp:ListItem>OTRD</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="remark">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="txtdeptremarks" runat="server" Height="51px" Text='<%# Bind("remark") %>'
                                    Width="150px"></asp:TextBox>
                            </ItemTemplate>
                              <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateOTByDept" Text="SAVE" CausesValidation=false  />
                            </FooterTemplate>  
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                &nbsp;
                &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label>
                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
   
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT otentry.RecNo, otentry.empcode, empmaster.empname, empmaster.designation, empmaster.departmentcode, ltrim(rtrim(otentry.shift)) as shift, otentry.datecheck, otentry.OT, otentry.hrs, otentry.TMsOtHrs, otentry.ottype, otentry.remark FROM otentry INNER JOIN Ot_TempTotWeekhrs ON otentry.empcode = Ot_TempTotWeekhrs.empcode INNER JOIN empmaster ON Ot_TempTotWeekhrs.empcode = empmaster.empcode WHERE (empmaster.sectioncode =@Sect) AND (datecheck = @otdate)">
        <SelectParameters>
            <asp:ControlParameter ControlID="Secddl" Name="Sect" PropertyName="SelectedValue" />
                    </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    &nbsp;&nbsp;<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource6" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Visible="False" ShowFooter="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="recno" HeaderText="Rec. No." SortExpression="recno" />
                        <asp:BoundField DataField="empcode" HeaderText="Emp. Code" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Emp. Name" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept - Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbld2" runat="server" Text='<%# Eval("departmentcode") %>'></asp:Label>-
                                <asp:Label ID="lbls2" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shift" SortExpression="shift">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("shift") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlempshift" runat="server" DataSourceID="SlDataSource6"
                                    DataTextField="attcode" DataValueField="attcode" Width="100px" SelectedValue='<%# Bind("shift") %>'>
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT ltrim(rtrim(trans_shiftcode)) as attcode FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="OT" SortExpression="OT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("OT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rbemp" runat="server" SelectedValue='<%# Bind("OT") %>'
                                    Width="99px">
                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="whrs" HeaderText="Total OT Hrs in a Week" SortExpression="whrs" />
                        <asp:BoundField DataField="hrs" SortExpression="hrs" />
                        <asp:TemplateField HeaderText="OT Hrs" SortExpression="hrs">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hrs") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="txtemphrs" runat="server" Text='<%# Bind("hrs") %>' Width="52px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OT Type" SortExpression="ottype">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ottype") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:DropDownList ID="ddlemptype" runat="server" SelectedValue='<%# Bind("ottype") %>'
                                    Width="105px">
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                    <asp:ListItem>OTND</asp:ListItem>
                                    <asp:ListItem>OTPH</asp:ListItem>
                                    <asp:ListItem>OTRD</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="remark">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="txtempremarks" runat="server" Height="51px" Text='<%# Bind("remark") %>'
                                    Width="150px"></asp:TextBox>
                            </ItemTemplate>
                                 <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateOTByEMP" Text="SAVE" CausesValidation=false  />
                            </FooterTemplate> 
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT empmaster.empname, empmaster.designation, empmaster.sectioncode, empmaster.departmentcode, ltrim(rtrim(otentry.shift)) as shift, otentry.remark, otentry.datecheck, otentry.OT, otentry.hrs, otentry.ottype, otentry.status, otentry.dateapplied, empmaster.empcode, otentry.empcode AS Expr1, Ot_TempTotWeekhrs.whrs, Ot_TempTotWeekhrs.recno FROM otentry INNER JOIN empmaster ON otentry.empcode = empmaster.empcode INNER JOIN Ot_TempTotWeekhrs ON otentry.recno = Ot_TempTotWeekhrs.recno WHERE (otentry.empcode = @empcode) AND (otentry.datecheck = @otdate)">
        <SelectParameters>
            <asp:ControlParameter ControlID="code" Name="empcode" PropertyName="Text" />
            <asp:ControlParameter ControlID="lbldt" Name="otdate" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource7" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Visible="False" ShowFooter="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="recno" HeaderText="Rec. No." SortExpression="recno" />
                        <asp:BoundField DataField="empcode" HeaderText="Emp. Code" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Emp. Name" SortExpression="empname" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                        <asp:TemplateField HeaderText="Dept - Sect" SortExpression="departmentcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbld3" runat="server" Text='<%# Eval("departmentcode") %>'></asp:Label>-
                                <asp:Label ID="lbls3" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                                &nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shift" SortExpression="shift">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("shift") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlsectshift" runat="server" DataSourceID="SqlDataource7"
                                    DataTextField="attcode" DataValueField="attcode" Width="100px" SelectedValue='<%# Bind("shift") %>'>
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT ltrim(rtrim(trans_shiftcode)) as attcode FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="OT" SortExpression="OT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("OT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:RadioButtonList ID="Rbsect" runat="server" SelectedValue='<%# Bind("OT") %>'
                                    Width="99px">
                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="whrs" HeaderText="Total OT Hrs in a Week" SortExpression="whrs" />
                        <asp:BoundField DataField="hrs" SortExpression="hrs"  />
                        <asp:TemplateField HeaderText="OT Hrs" SortExpression="hrs">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("hrs") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:TextBox ID="txtsecthrs" runat="server" Text='<%# Bind("hrs") %>' Width="52px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OT Type" SortExpression="ottype">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ottype") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlsecttype" runat="server" SelectedValue='<%# Bind("ottype") %>'
                                    Width="105px">
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                    <asp:ListItem>OTND</asp:ListItem>
                                    <asp:ListItem>OTPH</asp:ListItem>
                                    <asp:ListItem>OTRD</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="remark">
                            
                            <ItemTemplate>
                                <asp:TextBox ID="txtsectremarks" runat="server" Height="51px" Text='<%# Bind("remark") %>'
                                    Width="150px"></asp:TextBox>
                            </ItemTemplate>
                                 <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateOTBySect" Text="SAVE" CausesValidation=false  />
                            </FooterTemplate> 
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT empmaster.empname, empmaster.designation, empmaster.sectioncode, empmaster.departmentcode, ltrim(rtrim(otentry.shift)) as shift, otentry.remark, otentry.datecheck, otentry.OT, otentry.hrs, otentry.ottype, otentry.status, otentry.dateapplied, empmaster.empcode, otentry.empcode AS Expr1, Ot_TempTotWeekhrs.whrs, Ot_TempTotWeekhrs.recno FROM otentry INNER JOIN empmaster ON otentry.empcode = empmaster.empcode INNER JOIN Ot_TempTotWeekhrs ON otentry.recno = Ot_TempTotWeekhrs.recno WHERE (empmaster.sectioncode = @Sect) AND (otentry.datecheck = @otdate)">
        <SelectParameters>
            <asp:ControlParameter ControlID="Secddl" Name="Sect" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="lbldt" Name="otdate" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
                            <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT sectioncode + '-' + sectionname AS section, sectioncode FROM sectionmaster ORDER BY section">
                            </asp:SqlDataSource>
                            <cc1:CalendarExtender ID="ccelf" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                                PopupButtonID="otdate" TargetControlID="otdate">
                            </cc1:CalendarExtender>
                           <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT departmentcode + '-' + departmentname AS NAME, departmentcode FROM department ORDER BY NAME">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sqldept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT empmaster.empname, empmaster.designation, empmaster.sectioncode, empmaster.departmentcode, ltrim(rtrim(otentry.shift)) as shift, otentry.remark, otentry.datecheck, otentry.OT, otentry.hrs, otentry.ottype, otentry.status, otentry.dateapplied, empmaster.empcode, otentry.empcode AS Expr1, Ot_TempTotWeekhrs.whrs, Ot_TempTotWeekhrs.recno FROM otentry INNER JOIN empmaster ON otentry.empcode = empmaster.empcode INNER JOIN Ot_TempTotWeekhrs ON otentry.recno = Ot_TempTotWeekhrs.recno WHERE (empmaster.departmentcode = @Dept) AND (otentry.datecheck = @otdate)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="Deptddl" Name="Dept" PropertyName="SelectedValue"  />
                                    <asp:ControlParameter ControlID="lbldt" Name="otdate" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] FROM [empmaster]"></asp:SqlDataSource>
    
</asp:Content>
