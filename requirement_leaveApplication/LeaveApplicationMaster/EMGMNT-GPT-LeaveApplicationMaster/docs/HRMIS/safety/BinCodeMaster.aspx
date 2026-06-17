<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BinCodeMaster.aspx.vb" Inherits="E_Management.BinCodeMaster" 
    title="Bin Code Master" %>
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
        <td align="center" style="width: 176px; height: 9px; text-align: left" valign="top">
            <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="NEW ENTRY"></asp:Label></td>
        <td style="width: 1277px; height: 9px">
        </td>
        <td style="width: 14446px; height: 9px">
            <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="Maroon" Text="EXISTING RECORDS (Click on Rec. No. to edit)"></asp:Label></td>
    </tr> 
        <tr>
            <td style="width: 176px; height: 249px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" style="width: 500px; height: 120px" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="width: 102px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="dep" runat="server" Text="Department"></asp:Label></td>
                        <td style="width: 382px;" valign="top" align="left"><asp:DropDownList ID="deptcode" runat="server" Width="185px" DataSourceID="SqlDataSource3" DataTextField="departmentcode" DataValueField="departmentcode" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="deptcode"
                                    ErrorMessage="Please Select a Department" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 102px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="section" runat="server" Text="Section"></asp:Label></td>
                        <td style="width: 382px;" valign="top" align="left"><asp:DropDownList ID="sectcode" runat="server" Width="185px" DataSourceID="SqlDataSource5" DataTextField="sectioncode" DataValueField="sectioncode" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="sectcode"
                                    ErrorMessage="Please Select a Section" InitialValue="-1"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 102px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="wt" runat="server" Text="Waste Type"></asp:Label></td>
                        <td style="width: 382px;" valign="top" align="left">
                            <asp:DropDownList ID="wastetype" runat="server" Width="185px" DataSourceID="SqlDataSource6" DataTextField="selects" DataValueField="selects" AppendDataBoundItems="True" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="wastetype"
                                    ErrorMessage="Please Select Waste Type" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 102px; background-color: beige; height: 13px;" valign="top" align="left">
                            <asp:Label ID="wi" runat="server" Text="Waste Item"></asp:Label></td>
                        <td style="width: 382px; height: 13px;" valign="top" align="left">
                            <asp:DropDownList ID="items" runat="server" DataSourceID="SqlDataSource7"
                                DataTextField="Item" DataValueField="Item" AppendDataBoundItems="True" Width="185px">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            </asp:DropDownList>&nbsp;
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="items"
                                    ErrorMessage="Please Select Waste Item" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 102px; background-color: beige; height: 15px;" valign="top" align="left">
                            <asp:Label ID="loc" runat="server" Text="Location"></asp:Label></td>
                        <td style="width: 382px; height: 15px;" valign="top" align="left">
                            <asp:TextBox ID="location" runat="server" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="location"
                                ErrorMessage="Please Select Location"></asp:RequiredFieldValidator></td></tr>
                    <tr>
                        <td style="width: 102px; background-color: beige; text-align: left" valign="top">
                            <asp:Label ID="bc" runat="server" Text="Bin Code"></asp:Label></td>
                        <td align="left" style="width: 382px" valign="top">
                            <asp:TextBox ID="bincode" runat="server" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="bincode"
                                ErrorMessage="Please Select Bin Code"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2">
                            <asp:Label ID="lbledit" runat="server" Text="-" Visible="False" Width="32px"></asp:Label><asp:Button ID="SubmitBC" runat="server" Text="SAVE" /></td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label>
                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentcode] FROM [department]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [selects] FROM [Safety_select]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [Item] FROM [safety_schedulemaster] WHERE ([Description] = @Description)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="wastetype" Name="Description" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </td>
            <td style="width: 1177px; height: 249px">
            </td>
            <td style="width: 14446px; height: 249px;">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource8" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="25" AutoGenerateDeleteButton="True" AllowSorting="True" DataKeyNames ="recordno">
                    <Columns>
                        <asp:TemplateField HeaderText="Rec. No." SortExpression="recordno">
                            <ItemTemplate>
                               <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("recordno", "{0}") %>' ForeColor="#0000C0" OnCommand="getsafetybc" Text='<%# Eval("recordno") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="deptcode" HeaderText="Dept Code" SortExpression="deptcode" />
                        <asp:BoundField DataField="sectcode" HeaderText="Sect Code" SortExpression="sectcode" />
                        <asp:BoundField DataField="wastetype" HeaderText="Waste Type" SortExpression="wastetype" />
                        <asp:BoundField DataField="items" HeaderText="Items" SortExpression="items" />
                        <asp:BoundField DataField="bincode" HeaderText="Bin Code" SortExpression="bincode" />
                        <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
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
                    SelectCommand="SELECT DISTINCT [recordno], [deptcode], [sectcode], [wastetype], [items], [bincode], [location] FROM [safety_bincode]"
                    DeleteCommand = "delete from safety_bincode where recordno=@recordno" >
                    <DeleteParameters>
                                <asp:Parameter Name = "recordno" Type = "string" />
                                </DeleteParameters>
                </asp:SqlDataSource>
                                <asp:AccessDataSource ID="DispCompForm" runat="server"></asp:AccessDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
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
