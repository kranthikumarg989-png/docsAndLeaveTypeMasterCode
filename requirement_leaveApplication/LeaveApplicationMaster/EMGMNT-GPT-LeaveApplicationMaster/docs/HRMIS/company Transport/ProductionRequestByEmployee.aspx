<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ProductionRequestByEmployee.aspx.vb" Inherits="E_Management.ProductionRequestByEmployee" 
    title="Production Request For New Employee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 650px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 352px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 650px; height: 352px;" valign="top">
                <table>
                
                    <tr>
                         <td class="td_head" colspan="4" style="height: 21px">
                             Key in Production Request for a New Employee from 01st to 28th/29th/30th/31st based on month </td>                               
                       </tr>
                    <tr>
                         <td style="width: 120px; background-color: beige; height: 26px;">
                             FromDate</td>
                        <td style="width: 143px; background-color: beige; height: 26px;">
                            <asp:TextBox ID="txtfrom" runat="server" Width="87px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator></td>
                        <td style="width: 73px; background-color: beige; height: 26px;">
                            Todate</td>
                        <td style="width: 241px; background-color: beige; height: 26px;">
                            <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                             </tr>
                    <tr>
                        <td style="width: 120px; height: 17px; background-color: beige">
                            EmpCode</td>
                        <td style="width: 138px; background-color: beige">
                            <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Width="85px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtempcode"
                                InitialValue="-1">*</asp:RequiredFieldValidator></td>
                       <td style="width: 73px; background-color: beige;">
                             Section</td>
                        <td  style="background-color: beige; width: 241px;">
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3"
                                DataTextField="sect" DataValueField="sectioncode" Width="212px" AppendDataBoundItems="True" Enabled="False">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2"
                                InitialValue="-1">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 120px; background-color: beige">
                            EmpName</td>
                        <td style="width: 138px; background-color: beige">
                            <asp:Label ID="lblename" runat="server"></asp:Label></td>
                        <td style="width: 118px; color: #000000; background-color: beige">
                            Department</td>
                        <td style="width: 241px; background-color: beige">
                            <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px; background-color: beige">
                            Designation</td>
                        <td style="width: 138px; background-color: beige">
                            <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                        <td style="width: 118px; background-color: beige">
                            Employee Status
                        </td>
                        <td style="width: 241px; background-color: beige">
                            <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px; background-color: beige; height: 24px;">
                             Groupcode</td>
                        <td  style="background-color: beige; width: 143px; height: 24px;">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                                DataTextField="trans_groupcode" DataValueField="trans_groupcode" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
                                InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td><td style="width: 120px; background-color: beige; height: 24px;">
                            Category</td>
                        <td style=" background-color: beige; width: 241px; height: 24px;"><asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" Enabled="False">
                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            <asp:ListItem Value="S">Staff</asp:ListItem>
                            <asp:ListItem Value="LO">Local Operator</asp:ListItem>
                            <asp:ListItem Value="FO">Foreign Operator</asp:ListItem>
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="DropDownList3" InitialValue="-1" Width="5px">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; height: 26px;" colspan="2">
                        </td>
                        <td align="right" colspan="2" style="background-color: beige; height: 26px;">
                            &nbsp;<asp:Label ID="lblfrom" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblto" runat="server" Visible="False"></asp:Label>
                            <asp:Button ID="Button1" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="background-color: beige; height: 21px;">
                            <asp:Label ID="lblmsg" runat="server" Font-Size="Medium"></asp:Label>&nbsp;
                            <asp:Label ID="lblfemp" runat="server" Visible="False"></asp:Label>
                            </td>
                    </tr>
                       <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                                    <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                        popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                </table>
                
                <br />
                <table>
                    <tr>
                        <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" ShowFooter="True" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="departmentcode" HeaderText="Dept" SortExpression="departmentcode" />
                        <asp:TemplateField HeaderText="Existing groupcode" SortExpression="groupcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox33" runat="server" Text='<%# Bind("groupcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblggrp" runat="server" Text='<%# Bind("groupcode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Change Group" SortExpression="groupcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox32" runat="server" Text='<%# Bind("groupcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlgridgrp" runat="server" DataSourceID="sqlgridgroup"
                                DataTextField="trans_groupcode" DataValueField="trans_groupcode" AppendDataBoundItems=true
                                  OnSelectedIndexChanged="Getshiftbygroup" AutoPostBack="True" SelectedValue='<%# Bind("groupcode") %>'>
                                    <asp:ListItem Selected="True" Value="-1" >-Select-</asp:ListItem>
                                                     </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlgridgroup" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_groupcode] FROM [trans_groupmaster] ORDER BY [trans_groupcode]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                        <asp:TemplateField HeaderText="1" SortExpression="day1">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("day1") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                          <asp:DropDownList ID="Ddl1" runat="server" DataSourceID="SqlData12"  SelectedValue='<%# Bind("day1") %>'
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode">
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData12" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="2" SortExpression="day2">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("day2") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                          <asp:DropDownList ID="Ddl2" runat="server" DataSourceID="SqlData13"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day2") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData13" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="3" SortExpression="day3">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("day3") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                       <asp:DropDownList ID="Ddl3" runat="server" DataSourceID="SqlData14"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day3") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData14" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>       </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="4" SortExpression="day4">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("day4") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                         <asp:DropDownList ID="Ddl4" runat="server" DataSourceID="SqlData15"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day4") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData15" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="5" SortExpression="day5">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("day5") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                        <asp:DropDownList ID="Ddl5" runat="server" DataSourceID="SqlData16"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day5") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData16" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="6" SortExpression="day6">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("day6") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                      <asp:DropDownList ID="Ddl6" runat="server" DataSourceID="SqlData17"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day6") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData17" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>  
                                       </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="7" SortExpression="day7">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("day7") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                           <asp:DropDownList ID="Ddl7" runat="server" DataSourceID="SqlData18"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day7") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData18" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>  </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="8" SortExpression="day8">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("day8") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                      <asp:DropDownList ID="Ddl8" runat="server" DataSourceID="SqlData19"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day8") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData19" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>       </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="9" SortExpression="day9">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("day9") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                    <asp:DropDownList ID="Ddl9" runat="server" DataSourceID="SqlData20"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day9") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData20" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="10" SortExpression="day10">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("day10") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                      <asp:DropDownList ID="Ddl10" runat="server" DataSourceID="SqlData21"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day10") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData21" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="11" SortExpression="day11">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("day11") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                      <asp:DropDownList ID="Ddl11" runat="server" DataSourceID="SqlData22"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day11") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData22" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="12" SortExpression="day12">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("day12") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                         <asp:DropDownList ID="Ddl12" runat="server" DataSourceID="SqlData23"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day12") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData23" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                                     </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="13" SortExpression="day13">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox24" runat="server" Text='<%# Bind("day13") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                       <asp:DropDownList ID="Ddl13" runat="server" DataSourceID="SqlData24"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day13") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData24" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>      </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="14" SortExpression="day14">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox25" runat="server" Text='<%# Bind("day14") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                         <asp:DropDownList ID="Ddl14" runat="server" DataSourceID="SqlData25"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day14") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData25" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>     </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="15" SortExpression="day15">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox26" runat="server" Text='<%# Bind("day15") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                         <asp:DropDownList ID="Ddl15" runat="server" DataSourceID="SqlData26"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day15") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData26" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="16" SortExpression="day16">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox27" runat="server" Text='<%# Bind("day16") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:DropDownList ID="Ddl16" runat="server" DataSourceID="SqlData27"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day16") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData27" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>  </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="17" SortExpression="day17">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox28" runat="server" Text='<%# Bind("day17") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                        <asp:DropDownList ID="Ddl17" runat="server" DataSourceID="SqlData28"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day17") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData28" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource> 
                                     </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="18" SortExpression="day18">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox29" runat="server" Text='<%# Bind("day18") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                         <asp:DropDownList ID="Ddl18" runat="server" DataSourceID="SqlData29" AppendDataBoundItems=true 
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day18") %>'>
                                      <asp:ListItem Text="Please select" Value="" /> 
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData29" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="19" SortExpression="day19">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox30" runat="server" Text='<%# Bind("day19") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:DropDownList ID="Ddl19" runat="server" DataSourceID="SqlData30" AppendDataBoundItems=true 
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day19") %>'>
                                      <asp:ListItem Text="Please select" Value="" />
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData30" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="20" SortExpression="day20">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("day20") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                        <asp:DropDownList ID="Ddl20" runat="server" DataSourceID="SqlData31"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode" AppendDataBoundItems=true  SelectedValue='<%# Bind("day20") %>'>
                                <asp:ListItem Text="Please select" Value="" />

                                </asp:DropDownList>
                                
                                <asp:SqlDataSource ID="SqlData31" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>    </ItemTemplate>
                                
                                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="21" SortExpression="day21">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("day21") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="Ddl21" runat="server" DataSourceID="SqlData1"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode" 
                                    SelectedValue='<%# Bind("day21") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="22" SortExpression="day22">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("day22") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:DropDownList ID="Ddl22" runat="server" DataSourceID="SqlData2"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day22") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource> 
                                     </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="23" SortExpression="day23">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("day23") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                             <asp:DropDownList ID="Ddl23" runat="server" DataSourceID="SqlData3"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day23") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>   </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="24" SortExpression="day24">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("day24") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                           <asp:DropDownList ID="Ddl24" runat="server" DataSourceID="SqlData4"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day24") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource> 
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="25" SortExpression="day25">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("day25") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                           <asp:DropDownList ID="Ddl25" runat="server" DataSourceID="SqlData5"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day25") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                                
                           </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="26" SortExpression="day26">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("day26") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:DropDownList ID="Ddl26" runat="server" DataSourceID="SqlData6"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day26") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData6" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="27" SortExpression="day27">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("day27") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                               <asp:DropDownList ID="Ddl27" runat="server" DataSourceID="SqlData7"  SelectedValue='<%# Bind("day27") %>'
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode">
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="28" SortExpression="day28">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("day28") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                            <asp:DropDownList ID="Ddl28" runat="server" DataSourceID="SqlData8"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day28") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData8" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>
                                   </ItemTemplate>
                                    <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdatePRMAster" Text="SAVE" CausesValidation=false  />
                            </FooterTemplate> 
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="29" SortExpression="day29">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("day29") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                    <asp:DropDownList ID="Ddl29" runat="server" DataSourceID="SqlData9"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day29") %>' AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="NA">NA</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData9" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>     
                                     </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="30" SortExpression="day30">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("day30") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                       <asp:DropDownList ID="Ddl30" runat="server" DataSourceID="SqlData10"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day30") %>' AppendDataBoundItems="True">
                           <asp:ListItem Selected="True" Value="NA">NA</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData10" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource>  
                                
                                     </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="31" SortExpression="day31">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("day31") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                         <asp:DropDownList ID="Ddl31" runat="server" DataSourceID="SqlData11"
                                    DataTextField="trans_shiftcode" DataValueField="trans_shiftcode"  SelectedValue='<%# Bind("day31") %>' AppendDataBoundItems="True">
                             <asp:ListItem Selected="True" Value="NA">NA</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlData11" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT DISTINCT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                                </asp:SqlDataSource> 
                          </ItemTemplate>
                        </asp:TemplateField>
                  </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ShowFooter="True" Visible="False">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="Empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="departmentcode" HeaderText="Dept" SortExpression="departmentcode" />
                        <asp:BoundField DataField="groupcode" HeaderText="Group" SortExpression="groupcode" />
                        <asp:BoundField DataField="day1" HeaderText="1" SortExpression="day1" />
                        <asp:BoundField DataField="day2" HeaderText="2" SortExpression="day2" />
                        <asp:BoundField DataField="day3" HeaderText="3" SortExpression="day3" />
                        <asp:BoundField DataField="day4" HeaderText="4" SortExpression="day4" />
                        <asp:BoundField DataField="day5" HeaderText="5" SortExpression="day5" />
                        <asp:BoundField DataField="day6" HeaderText="6" SortExpression="day6" />
                        <asp:BoundField DataField="day7" HeaderText="7" SortExpression="day7" />
                        <asp:BoundField DataField="day8" HeaderText="8" SortExpression="day8" />
                        <asp:BoundField DataField="day9" HeaderText="9" SortExpression="day9" />
                        <asp:BoundField DataField="day10" HeaderText="10" SortExpression="day10" />
                        <asp:BoundField DataField="day11" HeaderText="11" SortExpression="day11" />
                        <asp:BoundField DataField="day12" HeaderText="12" SortExpression="day12" />
                        <asp:BoundField DataField="day13" HeaderText="13" SortExpression="day13" />
                        <asp:BoundField DataField="day14" HeaderText="14" SortExpression="day14" />
                        <asp:BoundField DataField="day15" HeaderText="15" SortExpression="day15" />
                        <asp:BoundField DataField="day16" HeaderText="16" SortExpression="day16" />
                        <asp:BoundField DataField="day17" HeaderText="17" SortExpression="day17" />
                        <asp:BoundField DataField="day18" HeaderText="18" SortExpression="day18" />
                        <asp:BoundField DataField="day19" HeaderText="19" SortExpression="day19" />
                        <asp:BoundField DataField="day20" HeaderText="20" SortExpression="day20" />
                        <asp:BoundField DataField="day21" HeaderText="21" SortExpression="day21" />
                        <asp:BoundField DataField="day22" HeaderText="22" SortExpression="day22" />
                        <asp:BoundField DataField="day23" HeaderText="23" SortExpression="day23" />
                        <asp:BoundField DataField="day24" HeaderText="24" SortExpression="day24" />
                        <asp:BoundField DataField="day25" HeaderText="25" SortExpression="day25" />
                        <asp:BoundField DataField="day26" HeaderText="26" SortExpression="day26" />
                        <asp:BoundField DataField="day27" HeaderText="27" SortExpression="day27" />
                        <asp:BoundField DataField="day28" HeaderText="28" SortExpression="day28" />
                        <asp:BoundField DataField="day29" HeaderText="29" SortExpression="day29" />
                        <asp:BoundField DataField="day30" HeaderText="30" SortExpression="day30" />
                        <asp:BoundField DataField="day31" HeaderText="31" SortExpression="day31" />
                        <asp:BoundField DataField="keyinby" HeaderText="keyinby" SortExpression="keyinby" Visible=False  />
                        <asp:BoundField DataField="datekeyin" HeaderText="Keyindate" SortExpression="datekeyin" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False" Visible=False  />
                    
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Underline="True"
                                ForeColor="Blue" Visible="False">Click here to Print this Schedule</asp:LinkButton><br />
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT empmaster.empname, trans_productionrequesttemp.empcode, trans_productionrequesttemp.departmentcode, trans_productionrequesttemp.sectioncode, trans_productionrequesttemp.fromdate, trans_productionrequesttemp.todate, LTRIM(RTRIM(trans_productionrequesttemp.day1)) AS day1, LTRIM(RTRIM(trans_productionrequesttemp.day2)) AS day2, LTRIM(RTRIM(trans_productionrequesttemp.day3)) AS day3, LTRIM(RTRIM(trans_productionrequesttemp.day4)) AS day4, LTRIM(RTRIM(trans_productionrequesttemp.day5)) AS day5, LTRIM(RTRIM(trans_productionrequesttemp.day6)) AS day6, LTRIM(RTRIM(trans_productionrequesttemp.day7)) AS day7, LTRIM(RTRIM(trans_productionrequesttemp.day8)) AS day8, LTRIM(RTRIM(trans_productionrequesttemp.day9)) AS day9, LTRIM(RTRIM(trans_productionrequesttemp.day10)) AS day10, LTRIM(RTRIM(trans_productionrequesttemp.day11)) AS day11, LTRIM(RTRIM(trans_productionrequesttemp.day12)) AS day12, LTRIM(RTRIM(trans_productionrequesttemp.day13)) AS day13, LTRIM(RTRIM(trans_productionrequesttemp.day14)) AS day14, LTRIM(RTRIM(trans_productionrequesttemp.day15)) AS day15, LTRIM(RTRIM(trans_productionrequesttemp.day16)) AS day16, LTRIM(RTRIM(trans_productionrequesttemp.day17)) AS day17, LTRIM(RTRIM(trans_productionrequesttemp.day18)) AS day18, LTRIM(RTRIM(trans_productionrequesttemp.day19)) AS day19, LTRIM(RTRIM(trans_productionrequesttemp.day20)) AS day20, LTRIM(RTRIM(trans_productionrequesttemp.day21)) AS day21, LTRIM(RTRIM(trans_productionrequesttemp.day22)) AS day22, LTRIM(RTRIM(trans_productionrequesttemp.day23)) AS day23, LTRIM(RTRIM(trans_productionrequesttemp.day24)) AS day24, LTRIM(RTRIM(trans_productionrequesttemp.day25)) AS day25, LTRIM(RTRIM(trans_productionrequesttemp.day26)) AS day26, LTRIM(RTRIM(trans_productionrequesttemp.day27)) AS day27, LTRIM(RTRIM(trans_productionrequesttemp.day28)) AS day28, LTRIM(RTRIM(trans_productionrequesttemp.day29)) AS day29, LTRIM(RTRIM(trans_productionrequesttemp.day30)) AS day30, LTRIM(RTRIM(trans_productionrequesttemp.day31)) AS day31, trans_productionrequesttemp.groupcode FROM trans_productionrequesttemp INNER JOIN empmaster ON trans_productionrequesttemp.empcode = empmaster.empcode WHERE (trans_productionrequesttemp.sectioncode = @sect) AND (trans_productionrequesttemp.groupcode = @grp) AND (trans_productionrequesttemp.empcode = @empcode) ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList2" Name="sect" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="grp" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="txtempcode" Name="empcode" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select sectioncode +'-'+ sectionname as sect,sectioncode from sectionmaster order by sectioncode ">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [trans_groupcode] FROM [trans_groupmaster] ORDER BY [trans_groupcode]">
                </asp:SqlDataSource>
                &nbsp;&nbsp;<asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT empmaster.empname, trans_productionrequest.empcode, trans_productionrequest.departmentcode, trans_productionrequest.sectioncode, trans_productionrequest.fromdate, trans_productionrequest.todate, LTRIM(RTRIM(trans_productionrequest.day1)) AS day1, LTRIM(RTRIM(trans_productionrequest.day2)) AS day2, LTRIM(RTRIM(trans_productionrequest.day3)) AS day3, LTRIM(RTRIM(trans_productionrequest.day4)) AS day4, LTRIM(RTRIM(trans_productionrequest.day5)) AS day5, LTRIM(RTRIM(trans_productionrequest.day6)) AS day6, LTRIM(RTRIM(trans_productionrequest.day7)) AS day7, LTRIM(RTRIM(trans_productionrequest.day8)) AS day8, LTRIM(RTRIM(trans_productionrequest.day9)) AS day9, LTRIM(RTRIM(trans_productionrequest.day10)) AS day10, LTRIM(RTRIM(trans_productionrequest.day11)) AS day11, LTRIM(RTRIM(trans_productionrequest.day12)) AS day12, LTRIM(RTRIM(trans_productionrequest.day13)) AS day13, LTRIM(RTRIM(trans_productionrequest.day14)) AS day14, LTRIM(RTRIM(trans_productionrequest.day15)) AS day15, LTRIM(RTRIM(trans_productionrequest.day16)) AS day16, LTRIM(RTRIM(trans_productionrequest.day17)) AS day17, LTRIM(RTRIM(trans_productionrequest.day18)) AS day18, LTRIM(RTRIM(trans_productionrequest.day19)) AS day19, LTRIM(RTRIM(trans_productionrequest.day20)) AS day20, LTRIM(RTRIM(trans_productionrequest.day21)) AS day21, LTRIM(RTRIM(trans_productionrequest.day22)) AS day22, LTRIM(RTRIM(trans_productionrequest.day23)) AS day23, LTRIM(RTRIM(trans_productionrequest.day24)) AS day24, LTRIM(RTRIM(trans_productionrequest.day25)) AS day25, LTRIM(RTRIM(trans_productionrequest.day26)) AS day26, LTRIM(RTRIM(trans_productionrequest.day27)) AS day27, LTRIM(RTRIM(trans_productionrequest.day28)) AS day28, LTRIM(RTRIM(trans_productionrequest.day29)) AS day29, LTRIM(RTRIM(trans_productionrequest.day30)) AS day30, LTRIM(RTRIM(trans_productionrequest.day31)) AS day31, trans_productionrequest.groupcode, trans_productionrequest.datekeyin, trans_productionrequest.keyinby, trans_productionrequest.category FROM trans_productionrequest INNER JOIN empmaster ON trans_productionrequest.empcode = empmaster.empcode WHERE (trans_productionrequest.sectioncode = @section) AND (trans_productionrequest.groupcode = @grp) AND (trans_productionrequest.fromdate = @fromdate) AND (trans_productionrequest.todate = @todate) AND (trans_productionrequest.category = @cat)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList2" Name="section" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="grp" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="lblfrom" Name="fromdate" PropertyName="Text" />
                        <asp:ControlParameter ControlID="lblto" Name="todate" PropertyName="Text" />
                        <asp:ControlParameter ControlID="DropDownList3" Name="cat" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                  SelectCommand="SELECT empmaster.empname, trans_productionrequest.empcode, trans_productionrequest.departmentcode, trans_productionrequest.sectioncode, trans_productionrequest.fromdate, trans_productionrequest.todate, LTRIM(RTRIM(trans_productionrequest.day1)) AS day1, LTRIM(RTRIM(trans_productionrequest.day2)) AS day2, LTRIM(RTRIM(trans_productionrequest.day3)) AS day3, LTRIM(RTRIM(trans_productionrequest.day4)) AS day4, LTRIM(RTRIM(trans_productionrequest.day5)) AS day5, LTRIM(RTRIM(trans_productionrequest.day6)) AS day6, LTRIM(RTRIM(trans_productionrequest.day7)) AS day7, LTRIM(RTRIM(trans_productionrequest.day8)) AS day8, LTRIM(RTRIM(trans_productionrequest.day9)) AS day9, LTRIM(RTRIM(trans_productionrequest.day10)) AS day10, LTRIM(RTRIM(trans_productionrequest.day11)) AS day11, LTRIM(RTRIM(trans_productionrequest.day12)) AS day12, LTRIM(RTRIM(trans_productionrequest.day13)) AS day13, LTRIM(RTRIM(trans_productionrequest.day14)) AS day14, LTRIM(RTRIM(trans_productionrequest.day15)) AS day15, LTRIM(RTRIM(trans_productionrequest.day16)) AS day16, LTRIM(RTRIM(trans_productionrequest.day17)) AS day17, LTRIM(RTRIM(trans_productionrequest.day18)) AS day18, LTRIM(RTRIM(trans_productionrequest.day19)) AS day19, LTRIM(RTRIM(trans_productionrequest.day20)) AS day20, LTRIM(RTRIM(trans_productionrequest.day21)) AS day21, LTRIM(RTRIM(trans_productionrequest.day22)) AS day22, LTRIM(RTRIM(trans_productionrequest.day23)) AS day23, LTRIM(RTRIM(trans_productionrequest.day24)) AS day24, LTRIM(RTRIM(trans_productionrequest.day25)) AS day25, LTRIM(RTRIM(trans_productionrequest.day26)) AS day26, LTRIM(RTRIM(trans_productionrequest.day27)) AS day27, LTRIM(RTRIM(trans_productionrequest.day28)) AS day28, LTRIM(RTRIM(trans_productionrequest.day29)) AS day29, LTRIM(RTRIM(trans_productionrequest.day30)) AS day30, LTRIM(RTRIM(trans_productionrequest.day31)) AS day31, trans_productionrequest.groupcode, trans_productionrequest.category FROM trans_productionrequest INNER JOIN empmaster ON trans_productionrequest.empcode = empmaster.empcode WHERE (trans_productionrequest.sectioncode = @sect) AND (trans_productionrequest.fromdate = @from ) AND (trans_productionrequest.todate = @to ) AND (trans_productionrequest.category = @cate) AND (trans_productionrequest.empcode = @empcode)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList2" Name="sect" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="lblfrom" Name="from" PropertyName="Text" />
                        <asp:ControlParameter ControlID="lblto" Name="to" PropertyName="Text" />
                        <asp:ControlParameter ControlID="DropDownList3" Name="cate" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="txtempcode" Name="empcode" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
             
                
                    
                                  </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 352px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 650px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
</asp:Content>
