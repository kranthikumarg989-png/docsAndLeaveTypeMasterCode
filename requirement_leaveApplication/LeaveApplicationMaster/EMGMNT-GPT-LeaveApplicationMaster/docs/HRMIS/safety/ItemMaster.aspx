<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="ItemMaster.aspx.vb" Inherits="E_Management.ItemMaster" 
    title="Item Master New Entry " %>
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
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table style="width: 1000px; height: 145px" id="TABLE2">
        <tr>
            <td style="width: 190px; height: 249px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" style="width: 700px; height: 120px" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2" style="height: 12px" valign="top" align="left">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="ITEM MASTER - NEW ENTRY"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 72px; background-color: beige; height: 24px;" valign="top" align="left">
                            <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label></td>
                        <td style="width: 422px;" valign="top" align="left"><asp:DropDownList ID="desc" runat="server" Width="191px" DataSourceID="SqlDataSource5" DataTextField="selects" DataValueField="selects" autopostback="true" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="desc"
                                ErrorMessage="Please Select a Description"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 72px; background-color: beige; height: 28px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Item"></asp:Label></td>
                        <td style="width: 422px; height: 28px;" valign="top" align="left">
                            <asp:TextBox ID="item" runat="server" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="item"
                                ErrorMessage="Please Mention Item"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 72px; height: 24px; background-color: beige" valign="top">
                            <asp:Label ID="Label4" runat="server" Text="Code"></asp:Label></td>
                        <td align="left" style="width: 422px;" valign="top">
                            <asp:TextBox ID="code" runat="server" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="code"
                                ErrorMessage="Please Mention  Code"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 72px; height: 24px; background-color: beige" valign="top">
                            <asp:Label ID="Label5" runat="server" Text="UOM"></asp:Label></td>
                        <td align="left" style="width: 422px;" valign="top">
                            <asp:DropDownList ID="oum" runat="server" Width="191px" DataSourceID="SqlDataSource6" DataTextField="oumcode" DataValueField="oumcode" autopostback="true" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="oum"
                                ErrorMessage="Please Select UOM"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 72px; background-color: beige; height: 24px;" valign="top" align="left">
                            <asp:Label ID="category" runat="server" Text="Measurement"></asp:Label></td>
                        <td style="width: 422px;" valign="top" align="left">
                            <asp:DropDownList ID="measurement" runat="server" Width="191px" DataSourceID="SqlDataSource7" DataTextField="measurementname" DataValueField="measurementname" autopostback="true" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="measurement"
                                    ErrorMessage="Please Select Measurement" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 72px; background-color: beige; height: 24px;" valign="top" align="left">
                            <asp:Label ID="sm" runat="server" Text="Control Spec." Width="95px"></asp:Label></td>
                        <td style="width: 422px;" valign="top" align="left">
                            <asp:TextBox ID="controlspec" runat="server" Width="185px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="controlspec"
                                    ErrorMessage="Please Mention Control Spec."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="Only Numbers!" 
                                    ControlToValidate="controlspec"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 72px; background-color: beige; height: 24px;" valign="top" align="left">
                            <asp:Label ID="MH" runat="server" Text="Standard Measurement" Width="152px"></asp:Label></td>
                        <td style="width: 422px;" valign="top" align="left">
                            <asp:TextBox ID="stdmeasurement" runat="server" Width="185px"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="stdmeasurement"
                                    ErrorMessage="Please Mention Control Spec."></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="Only Numbers!" 
                                    ControlToValidate="stdmeasurement"></asp:RegularExpressionValidator>
                                    </td></tr>
                    <tr>
                        <td valign="top" colspan="2" style="height: 28px">
                            <asp:Label ID="lbledit" runat="server" Text="-" Visible="False" Width="32px"></asp:Label><asp:Button ID="saveim" runat="server" Text="SAVE" />&nbsp; &nbsp;&nbsp;</td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT [measurementname] FROM [Safety_measurement]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT [oumcode] FROM [Safety_oum]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                            SelectCommand="SELECT DISTINCT [selects] FROM [Safety_select]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label>
                &nbsp;&nbsp;
                </td>
            <td style="width: 6100px; height: 249px;">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource8" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="25" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Rec. No." SortExpression="recordno">
                                                       
                            <ItemTemplate>
                           <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("recordno") %>'></asp:Label>--%>
                                 <asp:LinkButton ID="itemmast" runat="server" CausesValidation="False" CommandArgument='<%# Eval("recordno", "{0}") %>'
                                                ForeColor="#0000C0" OnCommand="getsafety" Text='<%# Eval("recordno") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                        <asp:BoundField DataField="oum" HeaderText="OUM" SortExpression="oum" />
                        <asp:BoundField DataField="measurement" HeaderText="Measurement" SortExpression="measurement" />
                        <asp:BoundField DataField="stdmeasurement" HeaderText="Std. Measurement" SortExpression="stdmeasurement" />
                        <asp:BoundField DataField="controlspec" HeaderText="Control Spec" SortExpression="controlspec" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [recordno], [Description], [Item], [Code], [oum], [measurement], [stdmeasurement], [controlspec] FROM [safety_schedulemaster]">
                </asp:SqlDataSource>
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
    </table>
</asp:Content>
