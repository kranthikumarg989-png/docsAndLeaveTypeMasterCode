<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OTentryPayroll.aspx.vb" Inherits="E_Management.OTentryPayroll" 
    title="OT - Entry by Payroll" %>
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
            <td background="../../images/cen_lef.gif" style="height: 183px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">

<table style="width: 1000px; height: 145px" id="TABLE2">
        <tr>
            <td valign="top" align="left">
                <table id="TABLE1" onclick="return TABLE1_onclick()" style="width: 500px; height: 120px" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2" style="height: 12px" valign="top" align="left">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="OT - ENTRY BY PAYROLL"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 79px; background-color: beige; height: 30px;" valign="top" align="left">
                            <asp:Label ID="frmdt" runat="server" Text="From"></asp:Label></td>
                        <td style="height: 30px; width: 252px;" valign="top" align="left">
                    
                        <asp:TextBox ID="vfd" runat="server" Width="94px"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="vfd"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 79px; background-color: beige;" valign="top" align="left">
                            <asp:Label ID="todt" runat="server" Text="To"></asp:Label></td>
                        <td valign="top" align="left" style="width: 252px">
                           
                        <asp:TextBox ID="vtd" runat="server"  Width="94px"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="vtd"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 79px; background-color: beige;" valign="top" align="left">
                            <asp:Label ID="ecode" runat="server" Text="Employee Code"></asp:Label></td>
                        <td valign="top" align="left" style="width: 252px">
                            <asp:TextBox ID="code" runat="server" MaxLength="10" Width="92px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="code"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                                    </td></tr>
                    <tr>
                        <td valign="top" colspan="2" align="right">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp;
                            <%--<asp:Button ID="Show" runat="server" onclick="showpayroll" Text="SHOW" />--%>&nbsp; &nbsp;&nbsp;<asp:Button ID="Show1" runat="server" Text="SHOW" /></td>
                    </tr>
                </table>
                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblto" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblfrom" runat="server" Visible="False"></asp:Label></td>
            <td>
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
                &nbsp;
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px; height: 183px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
      <tr>
          <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
          </td>
          <td bgcolor="#ffffff" style="width: 1262px; height: 622px" valign="top">
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" ShowFooter="True" AllowSorting="True" CellPadding="4" ForeColor="#333333">
                  <Columns>
                   <asp:BoundField DataField="Recno" HeaderText="Recno" SortExpression="Recno" />
                      <asp:BoundField DataField="empcode" HeaderText="empcode" SortExpression="empcode" />
                      <asp:BoundField DataField="empname" HeaderText="Emp. Name" SortExpression="empname" />
                      <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                      <asp:TemplateField HeaderText="Dept - Sect" SortExpression="departmentcode">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("departmentcode") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="lbld1" runat="server" Text='<%# Eval("departmentcode") %>'></asp:Label>~
                              <asp:Label ID="lbls1" runat="server" Text='<%# Eval("sectioncode") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Shift" SortExpression="shift">
                          <EditItemTemplate>
                              <asp:TextBox ID="ddlempshif" runat="server" Text='<%# Bind("shift") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              &nbsp;<asp:DropDownList ID="ddlempshift" runat="server" DataSourceID="SqlataSource1"
                                  DataTextField="attcode" DataValueField="attcode" Width="108px" >
                                  <asp:ListItem Value="-1">---Select---</asp:ListItem>
                              </asp:DropDownList><asp:SqlDataSource ID="SqlataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                  SelectCommand="SELECT ltrim(rtrim(trans_shiftcode)) as attcode FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
                              </asp:SqlDataSource>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="dateapplied" HeaderText="Date Applied" SortExpression="dateapplied" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                      <asp:BoundField DataField="datecheck" HeaderText="OT Date" SortExpression="datecheck" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                      <asp:TemplateField HeaderText="OT" SortExpression="OT">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OT") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:RadioButtonList ID="Rbemp" runat="server" SelectedValue='<%# Bind("OT") %>'>
                                  <asp:ListItem Value="Y" >Yes</asp:ListItem>
                                  <asp:ListItem Value="N">No</asp:ListItem>
                              </asp:RadioButtonList>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="whrs" HeaderText="Total OT Hrs in a Week" SortExpression="whrs" />
                        <asp:BoundField DataField="hrs" HeaderText="" SortExpression="hrs"  />
                      <asp:TemplateField HeaderText="OT Hrs" SortExpression="hrs">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("hrs") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:TextBox ID="txtemphrs" runat="server" Width="47px" Text='<%# Bind("hrs") %>'></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="OT Type" SortExpression="ottype">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ottype") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:DropDownList ID="ddlemptype" runat="server" Width="78px" SelectedValue='<%# Bind("ottype") %>'>
                                  <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                  <asp:ListItem>OTND</asp:ListItem>
                                  <asp:ListItem>OTPH</asp:ListItem>
                                  <asp:ListItem>OTRD</asp:ListItem>
                              </asp:DropDownList>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                      <asp:TemplateField HeaderText="Remarks" SortExpression="remark">
                          <ItemTemplate>
                              <asp:TextBox ID="txtempremarks" runat="server" Height="46px" Width="149px" Text='<%# Bind("remark") %>'></asp:TextBox>
                          </ItemTemplate>
                           <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="UpdateOTByPayroll" Text="SAVE" CausesValidation=false  />
                            </FooterTemplate>  
                          
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
                  SelectCommand="SELECT empmaster.empname, empmaster.designation, empmaster.sectioncode, empmaster.departmentcode,otentry.recno, otentry.shift, otentry.remark, otentry.datecheck, otentry.OT, otentry.hrs, otentry.ottype, otentry.status, otentry.dateapplied, empmaster.empcode, otentry.empcode AS Expr1, Ot_TempTotWeekhrs.whrs FROM otentry INNER JOIN empmaster ON otentry.empcode = empmaster.empcode INNER JOIN Ot_TempTotWeekhrs ON otentry.recno = Ot_TempTotWeekhrs.recno WHERE (otentry.status = 'A') AND (otentry.empcode = @empcode) AND (otentry.datecheck >= @from ) AND (otentry.datecheck <= @to )">
                  <SelectParameters>
                      <asp:ControlParameter ControlID="code" Name="empcode" PropertyName="Text" />
                      <asp:ControlParameter ControlID="lblfrom" Name="from" PropertyName="Text" />
                      <asp:ControlParameter ControlID="lblto" Name="to" PropertyName="Text" />
                  </SelectParameters>
              </asp:SqlDataSource>
                                        <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="vtd" targetcontrolid="vtd"></cc1:calendarextender>
                        <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="vfd" targetcontrolid="vfd"></cc1:calendarextender>
          </td>
          <td background="../../images/cen_rig.gif" style="width: 24px">
          </td>
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
