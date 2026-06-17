<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="clinicpassqueue.aspx.vb" Inherits="E_Management.clinicpassqueue" 
    title="CLINIC VISIT LIST" Theme="buttonems" %>
                    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="CLINIC VISIT LIST"></asp:Label><br />
    <span style="color: #aca899">Click Empcode to view Employe Medical History<br />
    </span><span style="color: #aca899">Click Pass No for Treatment entry<br />
        <table>
            <tr>
                <td colspan="4">
    <asp:LinkButton ID="ClinicPassLinkBtn" runat="server" Font-Underline="True" ForeColor="Blue">ADMIN CLINIC PASS ENTRY  (When there is no clinic pass use this)</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LblFrom" runat="server" Font-Bold="True" ForeColor="#000000" Text="From"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="TxtFrom1" runat="server"></asp:TextBox>
                      <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd-MMM-yy"
                                            popupbuttonid="TxtFrom1" targetcontrolid="TxtFrom1"></cc1:calendarextender>
                    </td>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#000000" Text="To"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="TxtTo1" runat="server"></asp:TextBox>
                      <cc1:calendarextender id="Calendarextender1" runat="server" cssclass="cal_Theme1" format="dd-MMM-yy"
                                            popupbuttonid="TxtTo1" targetcontrolid="TxtTo1"></cc1:calendarextender>
                  
                    </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td colspan="2">
                    <asp:Button ID="Btn1" runat="server" Text="Report - Without clinic pass" /></td>
            </tr>
        </table>
        <br />
    </span>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" AllowPaging="True" PageSize="15">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                  <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="True" ForeColor="Blue"
                        Text='<%# Eval("empcode") %>'  CommandArgument='<%# Eval("empcode", "{0}") %>' OnCommand="getClinichistory"></asp:LinkButton>
                        
               </ItemTemplate>
            </asp:TemplateField>
               <asp:BoundField DataField="empname" HeaderText="Name" SortExpression="empname" />
            <asp:TemplateField HeaderText="Passno" SortExpression="passno">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("passno") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" ForeColor="Blue"
                        Text='<%# Eval("passno") %>'  CommandArgument='<%# Eval("passno", "{0}") %>' OnCommand="getClinicData"></asp:LinkButton>
                        
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString={0:dd-MMM-yy}  HtmlEncode="false"  />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString={0:t}  HtmlEncode="false" />
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString={0:t}  HtmlEncode="false" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
     <cc1:ModalPopupExtender ID="leavempe" runat="server" 
                                BackgroundCssClass="modalBackground"
                                DropShadow="false" EnableViewState="False" OkControlID="okbutton"
                                PopupControlID="pnlhistory"
                                PopupDragHandleControlID="pnlhistory" 
                                TargetControlID="btnShowModalPopup">
                            </cc1:ModalPopupExtender>
     <asp:Button ID="btnShowModalPopup" runat="server" SkinID="buttonskin1" Style="display: none" />


    <asp:Panel ID="pnlhistory" runat="server" >
       <table width="100%" cellpadding=0 cellspacing=0>
      <tr>
					<td width="16"><IMG height="16" src="../../images/top_lef.gif" width="16"></td>
					<td background="../../images/top_mid.gif" height="16"><IMG height="16" src="../../images/top_mid.gif"width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../../images/cen_lef.gif">
					<IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
     
       <table cellpadding ="5px" cellspacing ="5px" style="border-right: #333366 2px solid;
              border-top: #333366 2px solid; border-left: #333366 2px solid;
               border-bottom: #333366 2px solid; background-color: white;">
            <tr>
              <td>
        
   <asp:GridView ID="Grdlvhistory"  runat="server" AllowSorting="True" DataSourceid = sqldatasource2
             BorderColor="#3366CC" BackColor="White" BorderStyle="None" 
            BorderWidth="2px" CellPadding="4" ShowFooter="True" EmptyDataText = "No Records" AutoGenerateColumns=false  
            AllowPaging="True"  >
                    <Columns>
                <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
                <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
                <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
                <asp:BoundField DataField="sect" HeaderText="Sect" SortExpression="sect" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                       <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString={0:dd-MMM-yy} />
            <asp:BoundField DataField="etimeout" HeaderText="Time Out" SortExpression="etimeout" DataFormatString={0:t}/>
            <asp:BoundField DataField="etimein" HeaderText="Time In" SortExpression="etimein" DataFormatString={0:t} />
            <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
            </Columns>
            <RowStyle BackColor="White" ForeColor="#003399" />
                 <FooterStyle ForeColor="#003399" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <HeaderStyle  Font-Bold="True" ForeColor="Red" />  
        </asp:GridView>
                </td>
            </tr>
            <tr>
            <td>
             <asp:Button SkinID ="buttonskin1" ID="okbutton" runat="server" Text= "BACK" />
   
            </td>
            </tr>
        </table>
        	<td background="../../images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
					<td background="../../images/bot_mid.gif" height="16"><IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
    </asp:Panel>
   
    <asp:Label ID="lblemp" runat="server" Visible="False"></asp:Label><br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT clinicstaffgatepass.empcode, clinicstaffgatepass.passno,clinicstaffgatepass.status, clinicstaffgatepass.sickness, clinicstaffgatepass.etimein,         clinicstaffgatepass.etimeout, clinicstaffgatepass.dateapplied,         empmaster.empname FROM clinicstaffgatepass INNER JOIN empmaster ON         clinicstaffgatepass.empcode = empmaster.empcode WHERE         (clinicstaffgatepass.status = @status) and clinicstaffgatepass.dateapplied >= @from and clinicstaffgatepass.dateapplied <= @to ORDER BY clinicstaffgatepass.passno DESC">
                <SelectParameters>
            <asp:Parameter DefaultValue="A" Name="status" Type="String" />
             <asp:Parameter  Name="from" />
             <asp:Parameter  Name="to" />
            
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
            SelectCommand="SELECT [empcode], [passno], [department], [category], [sect], [status], [dateapplied], [etimeout], [etimein], [sickness] FROM [clinicstaffgatepass] WHERE ([empcode] = @empcode2)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblemp" Name="empcode2" PropertyName="Text" Type="String"  />
               
            </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>
