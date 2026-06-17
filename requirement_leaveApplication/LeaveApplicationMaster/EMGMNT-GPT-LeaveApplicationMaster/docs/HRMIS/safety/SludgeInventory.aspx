<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="SludgeInventory.aspx.vb" Inherits="E_Management.SludgeInventory" 
    title="Sludge Inventory Entry Screen" %>
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

<table id="TABLE2">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 1037px">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="SLUDGE INVENTORY ENTRY"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 1037px; height: 227px; text-align: left;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1"><tr>
                    <td style="width: 96px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Year"></asp:Label></td>
                    <td style="width: 363px; height: 26px;" valign="top" align="left">
                         <asp:DropDownList ID="year" runat="server" Width="148px">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            <asp:ListItem>2000</asp:ListItem>
                            <asp:ListItem>2001</asp:ListItem>
                            <asp:ListItem>2002</asp:ListItem>
                            <asp:ListItem>2003</asp:ListItem>
                            <asp:ListItem>2004</asp:ListItem>
                            <asp:ListItem>2005</asp:ListItem>
                            <asp:ListItem>2006</asp:ListItem>
                            <asp:ListItem>2007</asp:ListItem>
                            <asp:ListItem>2008</asp:ListItem>
                            <asp:ListItem>2009</asp:ListItem>
                            <asp:ListItem>2010</asp:ListItem>
                            <asp:ListItem>2011</asp:ListItem>
                            <asp:ListItem>2012</asp:ListItem>
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="year"
                                    ErrorMessage="Year !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td style="width: 96px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label14" runat="server" Text="Month"></asp:Label></td>
                    <td style="width: 339px; height: 26px;" valign="top" align="left">
                        <asp:DropDownList ID="month" runat="server" Width="151px">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            <asp:ListItem>January</asp:ListItem>
                            <asp:ListItem>February</asp:ListItem>
                            <asp:ListItem>March</asp:ListItem>
                            <asp:ListItem>April</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>June</asp:ListItem>
                            <asp:ListItem>July</asp:ListItem>
                            <asp:ListItem>August</asp:ListItem>
                            <asp:ListItem>September</asp:ListItem>
                            <asp:ListItem>October</asp:ListItem>
                            <asp:ListItem>November</asp:ListItem>
                            <asp:ListItem>December</asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="month"
                                    ErrorMessage="Month !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 22px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Sludge Disposal Type" Width="141px"></asp:Label></td>
                        <td style="width: 363px;" valign="top" align="left">
                            <asp:DropDownList ID="disptype" runat="server" Width="147px" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="sludgecode" DataValueField="sludgecode" AppendDataBoundItems="True">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="disptype"
                                    ErrorMessage="Disposal Type !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td align="left" style="width: 96px; background-color: beige" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Sludge Category" Width="109px"></asp:Label></td>
                    <td align="left" style="width: 339px" valign="top">
                        <asp:TextBox ID="sludgecat" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="sludgecat"
                                    ErrorMessage="Sludge Category !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 22px;" valign="top" align="left">
                            <asp:Label ID="Label4" runat="server" Text="Department"></asp:Label></td>
                        <td style="width: 363px;" valign="top" align="left">
                            <asp:DropDownList ID="dept" runat="server" DataSourceID="SqlDataSource2" DataTextField="departmentcode"
                                DataValueField="departmentcode" Width="149px" AppendDataBoundItems="True" AutoPostBack="True"><asp:ListItem Selected="True" Value="-1">---Select---</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="dept"
                                    ErrorMessage="Department !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    <td style="width: 96px; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label16" runat="server" Text="Section"></asp:Label></td>
                    <td style="width: 339px;" valign="top" align="left">
                        <asp:DropDownList ID="sect" runat="server" Width="154px" DataSourceID="SqlDataSource3" DataTextField="sectioncode" DataValueField="sectioncode" AppendDataBoundItems="True">
                            <asp:ListItem selected="True" Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="sect"
                                    ErrorMessage="Section !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 22px;" valign="top" align="left">
                            <asp:Label ID="Label5" runat="server" Text="Production Rawmaterial Input" Width="183px"></asp:Label></td>
                        <td style="width: 363px;" valign="top" align="left">
                            <asp:TextBox ID="rawmtl" runat="server" Width="139px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rawmtl"
                                    ErrorMessage="Raw Material Input !" InitialValue="-1"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="RegularExpressionValidator15" runat="server" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="rawmtl"></asp:RegularExpressionValidator></td>
                    <td style="width: 96px; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label17" runat="server" Text="Produce Quantity" Width="117px"></asp:Label></td>
                    <td style="width: 339px;" valign="top" align="left">
                        <asp:TextBox ID="prdqty" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="prdqty"
                                    ErrorMessage="Produce Qty !" InitialValue="-1"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="RegularExpressionValidator16" runat="server" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="prdqty"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 22px;" valign="top" align="left">
                            <asp:Label ID="Label6" runat="server" Text="Disposal Quantity" Width="114px"></asp:Label></td>
                        <td style="width: 363px" valign="top" align="left">
                            <asp:TextBox ID="dispqty" runat="server" Width="141px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="dispqty"
                                    ErrorMessage="Disposal Qty !" InitialValue="-1"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="RegularExpressionValidator14" runat="server" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="dispqty"></asp:RegularExpressionValidator></td>
                    <td style="width: 96px; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label18" runat="server" Text="UOM"></asp:Label></td>
                    <td style="width: 339px" valign="top" align="left">
                        <asp:TextBox ID="uom" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uom"
                                    ErrorMessage="UOM !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 96px; height: 22px; background-color: beige" valign="top">
                            <asp:Label ID="Label7" runat="server" Text="Price"></asp:Label></td>
                        <td align="left" style="width: 363px" valign="top">
                            <asp:TextBox ID="price" runat="server" Width="142px"></asp:TextBox>
                            RM<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="price"
                                    ErrorMessage="Price !" InitialValue="-1"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="RegularExpressionValidator12" runat="server" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="price"></asp:RegularExpressionValidator></td>
                    <td align="left" style="width: 96px; background-color: beige" valign="top">
                        <asp:Label ID="Label19" runat="server" Text="Mode of Disposal" Width="115px"></asp:Label></td>
                    <td align="left" style="width: 339px" valign="top">
                        <asp:TextBox ID="dispmode" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="dispmode"
                                    ErrorMessage="Disposal Mode !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 33px; text-align: center;" valign="middle">
                            <asp:Button ID="SAVESI" runat="server" Text="SAVE" />
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="BACK" /></td>
                    </tr>
                </table>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentcode] FROM [department]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SqlconDMIS %>"
                    SelectCommand="SELECT DISTINCT [sludgecode], [sludgedesc] FROM [sludgemaster]"></asp:SqlDataSource>
                &nbsp;&nbsp;<br />
                &nbsp; &nbsp;
                </td>
        </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [departmentcode] + '-' + DEPARTMENTNAME AS NAME, [departmentCODE] FROM [department]">
                            </asp:SqlDataSource>
    
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
