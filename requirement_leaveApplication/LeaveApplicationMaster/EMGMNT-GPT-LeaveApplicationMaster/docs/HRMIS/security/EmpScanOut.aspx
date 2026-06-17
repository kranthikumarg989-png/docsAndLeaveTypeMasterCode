<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="EmpScanOut.aspx.vb" Inherits="E_Management.EmpScanOut" 
    title="Maruwa Group of Companies - Employee going out in the middle" %>
   
    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="CPHApplication">
    
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 362px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 362px" valign="top">
   <table>
        <tr>
            <td style="vertical-align: top; text-align: left">
                &nbsp;&nbsp;
            </td>
            <td style="vertical-align: top; text-align: left">
        <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="#C00000" Text="Employee going out without Gatepass"></asp:Label><br />
                &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" SkinID="buttonskin1"/>&nbsp;
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqldatasource1" ForeColor="#333333"
                    GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="empcode" HeaderText="empcode" ReadOnly="True" SortExpression="empcode" />
                <asp:BoundField DataField="empname" HeaderText="empname" ReadOnly="True" SortExpression="empname" />
                <asp:BoundField DataField="CHECKTIME" HeaderText="CHECKTIME" ReadOnly="True" SortExpression="CHECKTIME" />
                <asp:BoundField DataField="StatusInOut" HeaderText="StatusInOut" ReadOnly="True"
                    SortExpression="StatusInOut" />
                <asp:BoundField DataField="designation" HeaderText="designation" ReadOnly="True"
                    SortExpression="designation" />
                <asp:BoundField DataField="departmentcode" HeaderText="departmentcode" ReadOnly="True"
                    SortExpression="departmentcode" />
                <asp:BoundField DataField="sectioncode" HeaderText="sectioncode" ReadOnly="True"
                    SortExpression="sectioncode" />
            </Columns>
        </asp:GridView>
                &nbsp;
            </td>
        </tr>
    </table>
                &nbsp; &nbsp;
        <td background="../../images/cen_rig.gif" style="width: 24px; height: 362px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>


        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
            ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="Get_ScanRawData;1"
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="empcode" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Content>

