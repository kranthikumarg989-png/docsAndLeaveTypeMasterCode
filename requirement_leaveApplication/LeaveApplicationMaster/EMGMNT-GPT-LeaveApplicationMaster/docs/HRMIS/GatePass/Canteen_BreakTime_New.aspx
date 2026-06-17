<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Canteen_BreakTime_New.aspx.vb" Inherits="E_Management.Canteen_BreakTime_New" MasterPageFile="~/ems.Master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
 <table style="text-align: left">
                        <tr>
                            <td style="width: 100px">
                    <asp:RadioButton ID="RBtn1" runat="server" Checked="True" Text="Abnormal" GroupName="A1" Font-Size="9pt" Font-Bold="True" /></td>
                            <td style="width: 100px">
                                <asp:RadioButton ID="RBtn2" runat="server" Text="All" GroupName="A1" Font-Size="9pt" Font-Bold="True" /></td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Text="From Date" Font-Size="9pt"></asp:Label></td>
                            <td style="width: 100px;">
                    <asp:TextBox ID="TxtFrm" runat="server" Font-Size="9pt"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                    <asp:Label ID="Label2" runat="server" Text="To Date" Font-Size="9pt"></asp:Label></td>
                            <td style="width: 100px;">
                   <asp:TextBox ID="TxtTo" runat="server" Font-Size="9pt"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Button ID="BtnView"
                        runat="server" Text="View by Date" Font-Size="9pt" Visible="False" /></td>
                        </tr>
                    </table>
                    
    <div style="text-align: center">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 99%">
          
            <tr>
                <td  colspan="2" style="text-align: center;" width="33%">
                    <asp:Label ID="Label3" runat="server" Text="Departement" Font-Bold="True" Font-Size="9pt"></asp:Label></td>
                <td colspan="2" style="text-align: center;">
                    <asp:Label ID="Label4" runat="server" Text="Section" Font-Bold="True" Font-Size="9pt"></asp:Label></td>
                <td   colspan="2" style="text-align: center;" width="33%">
                    <asp:Label ID="Label5" runat="server" Text="By Employee" Font-Bold="True" Font-Size="9pt" Width="33%"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center">
                    <asp:DropDownList ID="CmbDepartment" runat="server" Width="250px" AutoPostBack="True" Font-Size="9pt" >
                                        </asp:DropDownList></td><td style="text-align: left"><asp:Button ID="DView1"
                        runat="server" Text="View" Font-Size="9pt" /></td>
                <td  style="text-align: center">
                    <asp:DropDownList ID="CmbSection" runat="server" Width="250px" Font-Size="9pt">
                    </asp:DropDownList></td><td style="text-align: left"><asp:Button ID="DView2"
                        runat="server" Text="View" Font-Size="9pt" /></td>
                <td style="width: 100px; text-align: center;">
                    <asp:DropDownList ID="CmbEmployeeCode" runat="server" Width="250px" Font-Size="9pt">
                    </asp:DropDownList></td><td style="text-align: left"><asp:Button ID="DView3"
                        runat="server" Text="View" Font-Size="9pt" /></td>
            </tr>
            <tr>
                <td colspan="6">
                    <cc1:calendarextender id="Dt1"
                               runat="server" popupbuttonid="TxtFrm" targetcontrolid="TxtFrm">
                    </cc1:calendarextender>
                            <cc1:calendarextender id="Dt2"
                            runat="server" popupbuttonid="TxtTo" targetcontrolid="TxtTo">
                    </cc1:calendarextender>
                    <asp:Label ID="Lbl1" runat="server" BackColor="#000000" Font-Bold="True" ForeColor="#FFFFFF"></asp:Label></td>
            </tr>          
        </table>
        
        <table>
          <tr>
                <td style="text-align: center" >
                 <%-- OnPageIndexChanging="OnPaging"  AllowPaging="True" PageSize="100"--%>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999"                    
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" >
                       
                         <Columns>                         
                            <asp:BoundField DataField="EmpCode" HeaderText="Emp Code" ></asp:BoundField>
                            <asp:BoundField DataField="EmpName" HeaderText="Emp Name" ></asp:BoundField>
                            <asp:BoundField DataField="Designation" HeaderText="Designation" ></asp:BoundField>
                            <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" ></asp:BoundField>
                            <asp:BoundField DataField="SectionCode" HeaderText="Section Code" ></asp:BoundField>
                            <asp:BoundField DataField="Scan_IN" HeaderText="Scan IN" ></asp:BoundField>
                            <asp:BoundField DataField="Scan_OUT" HeaderText="Scan OUT" ></asp:BoundField>
                            <asp:BoundField DataField="TotalMinutes" HeaderText="Total Minutes" ></asp:BoundField>                           
                            <asp:BoundField DataField="CardID" HeaderText="Card ID" ></asp:BoundField>                                                   
                        </Columns>
                        
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    </asp:GridView>
                </td>
            </tr>
            </table>
    </div>



</asp:Content>
