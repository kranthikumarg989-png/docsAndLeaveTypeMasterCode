<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="UOMmaster.aspx.vb" Inherits="E_Management.UOMmaster" 
    title="UOM-MEASUREMENT Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="height: 16px" width="16">
        </td>
        <td background="../../images/top_mid.gif" style="width: 1262px; height: 16px">
        </td>
        <td style="width: 24px; height: 16px">
        </td>
    </tr>
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
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table style="width: 1000px; height: 145px" id="TABLE2">
    <tr>
        <td align="center" style="width: 1457px; height: 14px; text-align: left" valign="top">
        </td>
        <td style="width: 5455px; height: 14px">
            </td>
    </tr>
    <tr>
        <td align="center" style="width: 1457px; height: 152px; text-align: left" valign="top">
            <table id="TABLE1" border="1" cellpadding="1" cellspacing="1" onclick="return TABLE1_onclick()" style="width: 300px; height: 152px">
                <tr>
                    <td align="left" colspan="2" style="height: 12px" valign="top">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="UOM MASTER - NEW ENTRY"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 337px; height: 28px; background-color: beige" valign="top">
                        <asp:Label ID="name" runat="server" Text="UOM Name"></asp:Label></td>
                    <td align="left" style="width: 496px; height: 28px" valign="top">
                        <asp:TextBox ID="oumname" runat="server" Width="185px"></asp:TextBox>
                       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="oumname"
                            ErrorMessage="Please Mention UOM Name"></asp:RequiredFieldValidator>--%></td>
                </tr>
                <tr>
                    <td align="left" style="width: 337px; height: 24px; background-color: beige" valign="top">
                        <asp:Label ID="code" runat="server" Text="UOM Code"></asp:Label></td>
                    <td align="left" style="width: 496px" valign="top">
                        <asp:TextBox ID="oumcode" runat="server" Width="185px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="oumcode"
                            ErrorMessage="Please Mention  UOM Code"></asp:RequiredFieldValidator>--%></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px; text-align: center" valign="top">
                        <asp:Button ID="saveUOM" runat="server" Text="ADD ENTRY" />&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label
                            ID="lblmsg" runat="server" Text="Label" Visible="False" ForeColor="Green"></asp:Label></td>
                </tr>
            </table>
           </td>
        <td style="width: 300px; height: 152px"><table id="Table3" border="1" cellpadding="1" cellspacing="1" onclick="return TABLE1_onclick()" style="width: 300px; height: 152px">
            <tr>
                <td align="left" colspan="2" style="height: 12px" valign="top">
                    <asp:Label ID="Label3" runat="server" Font-Underline="True" ForeColor="Maroon" Text="MEASUREMENT MASTER - NEW ENTRY"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 337px; height: 39px; background-color: beige" valign="top">
                    <asp:Label ID="Label4" runat="server" Text="Measurement Name" Width="86px"></asp:Label></td>
                <td align="left" style="width: 526px; height: 39px" valign="top">
                    <asp:TextBox ID="measurementname" runat="server" Width="185px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="measurementname"
                        ErrorMessage="Please Mention Measurement Name"></asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 53px; text-align: center" valign="middle">
                    <asp:Label ID="lblmsg1" runat="server" Text="Label" Visible="False" ForeColor="Green"></asp:Label>
                    <asp:Button ID="savemeas" runat="server" Text="ADD ENTRY" />&nbsp; &nbsp;&nbsp;</td>
            </tr>
        </table>
            </td>
    </tr>
    <tr>
        <td align="left" style="width: 1457px; text-align: left; height: 21px;" valign="top">
        </td>
        <td align="left" style="width: 5455px; height: 21px;" valign="top">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 1457px; text-align: left" valign="top">
            <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="Maroon" Text="UOM MASTER"></asp:Label></td>
        <td align="left" style="width: 5455px" valign="top">
            <asp:Label ID="Label5" runat="server" Font-Underline="True" ForeColor="Maroon" Text="MEASUREMENT MASTER"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 1457px; height: 249px; text-align: left;" valign="top" align="left">
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333"
                    GridLines="Horizontal" AutoGenerateEditButton="True" BorderStyle="Solid" AutoGenerateDeleteButton="True" DataKeyNames ="recordno">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Record No." SortExpression="recordno">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("recordno") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("recordno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="oumname" HeaderText="OUM Name" SortExpression="oumname" />
                        <asp:BoundField DataField="oumcode" HeaderText="OUM Code" SortExpression="oumcode" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [recordno], [oumname], [oumcode] FROM [Safety_oum]"
                    DeleteCommand = "delete from Safety_oum where recordno=@recordno" 
                    UpdateCommand="update Safety_oum set oumname=@oumname,oumcode=@oumcode where recordno=@recordno ">
                                        
                                 <DeleteParameters>
                                <asp:Parameter Name = "recordno" Type = "string" />
                                </DeleteParameters>
                                <UpdateParameters>
                                       <asp:Parameter Name = "oumname" Type = "string" />
                                       <asp:Parameter Name = "oumcode" Type = "string" />                                    
                                </UpdateParameters>
                                </asp:SqlDataSource>
                
                </td>
            <td style="width: 5455px; height: 249px;" align="left" valign="top">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" PageSize="25" AllowSorting="True" BorderStyle="Solid" BorderWidth="1px" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Record No." SortExpression="recordno">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("recordno") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("recordno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="measurementname" HeaderText="Measurement Name" SortExpression="measurementname" />
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
                    SelectCommand="SELECT DISTINCT [recordno], [measurementname] FROM [Safety_measurement]"
                    DeleteCommand = "delete from Safety_measurement where recordno=@recordno" 
                    UpdateCommand="update Safety_measurement set measurementname=@measurementname where recordno=@recordno ">
                                        
                                 <DeleteParameters>
                                <asp:Parameter Name = "recordno" Type = "string" />
                                </DeleteParameters>
                                <UpdateParameters>
                                       <asp:Parameter Name = "measurementname" Type = "string" />                                
                                </UpdateParameters>
                </asp:SqlDataSource>
                &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
    </table>
    
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
