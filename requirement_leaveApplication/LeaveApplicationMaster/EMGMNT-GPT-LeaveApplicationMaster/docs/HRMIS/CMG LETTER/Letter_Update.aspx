<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Letter_Update.aspx.vb" Inherits="E_Management.Letter_Update" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="z-index: 100; left: 116px; width: 785px; position: absolute; top: 14px;
            height: 519px">
            <tr>
                <td colspan="3" style="height: 17px">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border-bottom: slategray 1px dashed; height: 55px">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 58px; position: absolute;
                        top: 92px" Text=" Select Letter Name" Width="126px"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource1" DataTextField="lettername" DataValueField="lettername"
                        Style="z-index: 101; left: 191px; position: absolute; top: 91px" Width="384px" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label2" runat="server" Style="z-index: 103; left: 593px; position: absolute;
                        top: 92px" Text="Revision No :" Width="89px"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Style="z-index: 105; left: 699px; position: absolute;
                        top: 93px" Width="54px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 163px">
                    &nbsp; &nbsp;
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:HtmlEditor ID="HtmlEditor1" runat="server" Style="z-index: 100; left: 6px; position: absolute;
                                top: 156px" Width="1037px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 26px">
                    &nbsp;</td>
                <td style="width: 100px; height: 26px">
                </td>
                <td style="width: 411px; height: 26px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 411px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 9px">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" SelectCommand="SELECT DISTINCT [lettername] FROM [HRMIS_CMG_MASTER_LETTER] ORDER BY [lettername]"></asp:SqlDataSource>
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 411px; height: 9px">
                    <asp:Button ID="Button2" runat="server" Style="z-index: 100; left: 553px; position: absolute;
                        top: 454px" Text="Update" Width="92px" />
                </td>
            </tr>
        </table><asp:Button ID="Button1" runat="server" Style="z-index: 101; left: 773px; position: absolute;
                        top: 467px" Text="Refresh" Width="92px" />
    
    </div>
    </form>
</body>
</html>
