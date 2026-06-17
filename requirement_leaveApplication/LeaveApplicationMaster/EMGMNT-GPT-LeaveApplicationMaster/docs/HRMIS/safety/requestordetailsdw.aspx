<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="requestordetailsdw.aspx.vb" Inherits="E_Management.requestordetailsdw" 
    title="Untitled Page" %>
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
            <td bgcolor="#ffffff" valign="top">

<table id="TABLE2" border="2" >
        <tr>
            <td valign="top" align="left" rowspan="" colspan="">
                <table id="TABLE3" onclick="return TABLE1_onclick()" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" style="height: 27px; text-align: center; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="REQUESTOR DETAILS"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; height: 28px;" valign="top" align="left">
                            <asp:Label ID="Label2" runat="server" Text="Rec. No. :" Font-Bold="True" Width="70px" ForeColor="#0000C0"></asp:Label></td>
                        <td style="width: 179px; height: 28px; " valign="top" align="left">
                            &nbsp;<asp:Label ID="recordno" runat="server"></asp:Label></td>
                        <td align="left" style="width: 162px; height: 28px;" valign="top">
                            <asp:Label ID="Label6" runat="server" Text="Employee No. :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 287px; height: 28px;" valign="top">
                            &nbsp;<asp:Label ID="empcode" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 150px;height: 28px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Date Applied :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td style="width: 179px; height: 28px;" valign="top" align="left">
                            &nbsp;<asp:Label ID="dateapplied" runat="server"></asp:Label></td>
                        <td align="left" style="width: 162px;height: 28px;" valign="top">
                            <asp:Label ID="Label5" runat="server" Text="Employee Name :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 287px; height: 28px;" valign="top">
                            &nbsp;<asp:Label ID="empname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 150px; height: 24px;" valign="top">
                            <asp:Label ID="Label8" runat="server" Text="Department :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 179px; height: 24px;" valign="top">
                            &nbsp;<asp:Label ID="dept" runat="server"></asp:Label></td>
                        <td align="left" style="width: 162px; height: 24px;" valign="top">
                            <asp:Label ID="Labe10" runat="server" Text="Section :" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                        <td align="left" style="width: 307px;height: 24px;" valign="top">
                            &nbsp;<asp:Label ID="sect" runat="server"></asp:Label></td>
                    </tr>
                </table>
                </td>
        </tr>
    <tr>
        <td align="left" colspan="1" rowspan="1" style="height: 19px" valign="top">
            <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="height: 27px; text-align: center; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label9" runat="server" Font-Underline="True" ForeColor="Maroon" Text="DISPOSAL DETAILS"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 150px; height: 24px;" valign="top">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Date Disposal :" Width="111px"></asp:Label></td>
                    <td align="left" style="width: 179px; height: 24px;" valign="top">
                        &nbsp;<asp:Label ID="datedispossal" runat="server"></asp:Label></td>
                    <td align="left" style="width: 162px; height: 24px;" valign="top">
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Time Disposal :"></asp:Label></td>
                    <td align="left" style="width: 307px;height: 24px;" valign="top">
                        &nbsp;<asp:Label ID="timedispossal" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="1" rowspan="1" style="height: 19px; text-align: center; background-color: beige;" 
            valign="top">
            <asp:Label ID="Label10" runat="server" Font-Underline="True" ForeColor="Maroon" Text="DOMESTIC WASTE CONSIGNMENT DETAILS"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" style="width: 567px; height: 243px; text-align: left;" valign="top">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black"
                GridLines="Vertical" Width="777px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                <Columns>
                 <asp:TemplateField HeaderText="S.No." >
   <ItemTemplate>    
       <%# CType(Container, GridViewRow).RowIndex + 1%>
   </ItemTemplate>
</asp:TemplateField>
                    <asp:BoundField DataField="items" HeaderText="Items" SortExpression="items" />
                    <asp:BoundField DataField="weight" HeaderText="Std. Wt." SortExpression="weight" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
                    <asp:BoundField DataField="total" HeaderText="Total Wt." SortExpression="total" />
                    <asp:BoundField DataField="remarks" HeaderText="Remarks" SortExpression="remarks" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#CCCCCC" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center" style="text-align: left; height: 134px;" valign="top">
            <table id="Table4" onclick="return TABLE1_onclick()" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="height: 27px; text-align: center; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label12" runat="server" Font-Underline="True" ForeColor="Maroon" Text="VERIFICATION DETAILS"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 28px;" valign="top" align="left">
                        <asp:Label ID="Label36" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Date Verification :"
                            Width="127px"></asp:Label></td>
                    <td style="width: 179px; height: 28px; " valign="top" align="left">
                        &nbsp;<asp:Label ID="dateverification" runat="server"></asp:Label></td>
                    <td align="left" style="width: 162px; height: 28px;" valign="top">
                        <asp:Label ID="Label38" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Time Verification :"></asp:Label></td>
                    <td align="left" style="width: 287px; height: 28px;" valign="top">
                        &nbsp;<asp:Label ID="timeverification" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 150px;height: 28px;" valign="top" align="left">
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Person Incharge :"></asp:Label></td>
                    <td style="width: 179px; height: 28px;" valign="top" align="left">
                        &nbsp;<asp:Label ID="personincharge" runat="server"></asp:Label></td>
                    <td align="left" style="width: 162px;height: 28px;" valign="top">
                        <asp:Label ID="Label19" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Head Dept. OSHI :"></asp:Label></td>
                    <td align="left" style="width: 287px; height: 28px;" valign="top">
                        &nbsp;<asp:Label ID="HODcheckedby" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 28px" valign="bottom" colspan="2">
                        <asp:Label ID="Label30" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Signed :"></asp:Label>
                        &nbsp;----------------------------</td>
                    <td align="left" style="height: 28px" valign="bottom" colspan="2">
                        <asp:Label ID="Label31" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Signed :"></asp:Label>
                        &nbsp; -----------------------------</td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
    </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT items, quantity, total, remarks, weight, recordno FROM Safety_domesticwasteconsignmentdetails WHERE (recordno = @rno)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="recordno" Name="rno" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp;&nbsp;
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table></asp:Content>
