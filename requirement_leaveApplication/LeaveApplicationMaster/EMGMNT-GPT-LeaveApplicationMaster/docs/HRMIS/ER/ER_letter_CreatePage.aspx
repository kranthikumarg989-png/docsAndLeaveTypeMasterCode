<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ER_letter_CreatePage.aspx.vb" Inherits="E_Management.ER_letter_CreatePage" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Letter create</title>
    <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                         InsertCommand="INSERT INTO [HRMIS_ER_MASTER_LETTER]([lettercontents],[lettername],[createdby],[createdtime]) VALUES (@lettercontents,@lettername,@createdby,@createdtime)" 
                        SelectCommand="SELECT [lettercontents] FROM [HRMIS_ER_MASTER_LETTER]" >
            
             </asp:SqlDataSource>
        &nbsp;</div>
        <table border="1" bordercolor="midnightblue" style="z-index: 104; left: 62px; width: 862px;
            position: absolute; top: 77px; height: 298px">
            <tr>
                <td bordercolor="midnightblue" colspan="4" style="height: 26px">
                    <asp:Label ID="Label1" runat="server" Height="22px" Style="z-index: 100; left: 12px;
                        position: absolute; top: 5px" Text="Label" Width="65px"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Height="22px" Style="z-index: 101; left: 91px;
                        position: absolute; top: 4px" Text="---" Width="21px"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Height="22px" Style="z-index: 103; left: 120px;
                        position: absolute; top: 3px" Text="Label" Width="485px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 55px; height: 33px; text-align: right">
                    Revision No</td>
                <td style="width: 21px; height: 33px">
                    &nbsp;0</td>
                <td bordercolor="midnightblue" colspan="2" style="width: 422px; height: 33px">
                    &nbsp;Select the necessary fields to be added in the content</td>
            </tr>
            <tr>
                <td bordercolor="midnightblue" colspan="4" style="height: 40px; text-align: right">
                    <asp:DropDownList ID="DropDownList1" runat="server" Style="z-index: 100; left: 423px;
                        position: absolute; top: 42px" Width="135px">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button3" runat="server" Style="z-index: 102; left: 572px; position: absolute;
                        top: 41px" Text="Add" Width="41px" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 266px">
                    &nbsp; &nbsp; &nbsp;
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:HtmlEditor ID="HtmlEditor1" runat="server" Style="z-index: 100; left: 7px; position: absolute;
                                top: 128px" Width="847px" />
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="z-index: 102;
                                left: 616px; position: absolute; top: 402px" Text="Submit" Width="109px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 33px">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
