<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ER_letter_EditPage.aspx.vb" Inherits="E_Management.ER_letter_EditPage" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Letter Edit</title>
    <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="z-index: 100; left: 193px; width: 842px; position: absolute; top: 69px;
            height: 430px">
            <tr>
                <td colspan="3" style="width: 1049px; height: 21px;">
                    &nbsp;&nbsp;
                    <table id="TABLE1" language="javascript" onclick="return TABLE1_onclick()" style="z-index: 100;
                        left: 0px; width: 841px; position: absolute; top: 2px; height: 33px">
                        <tr>
                            <td style="width: 63px; height: 21px; background-color: beige; text-align: left;">
                            </td>
                            <td style="width: 191px; height: 21px; background-color: beige">
                                &nbsp; &nbsp;
                            </td>
                            <td style="width: 112px; color: #000000; height: 21px; background-color: beige">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border-bottom: slategray 1px dashed; height: 3px; width: 1049px;">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 19px; position: absolute;
                        top: 11px" Text="Select Letter Name :" Width="128px"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" Style="z-index: 104; left: 154px;
                        position: absolute; top: 9px" Width="422px" AutoPostBack="True">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    
                    <asp:Label ID="Label2" runat="server" Style="z-index: 102; left: 587px; position: absolute;
                        top: 10px" Text="Revision No :" Width="84px"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Style="z-index: 103; left: 676px; position: absolute;
                        top: 11px" Width="39px"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 1201px; width: 1049px;">
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <cc1:htmleditor id="HtmlEditor1" runat="server" style="z-index: 100; left: 2px; position: absolute;
                        top: 37px" width="690px" Height="1200px" DialogButtonBarColor="LightSteelBlue"></cc1:htmleditor>
                            &nbsp;&nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Style="z-index: 101; left: 550px; position: absolute;
                        top: 1220px" Text="Clear" BackColor="LightSteelBlue" BorderColor="LightSteelBlue" />
                    <asp:Button ID="Button2" runat="server" Style="z-index: 103; left: 615px; position: absolute;
                        top: 1220px" Text="Update" BackColor="LightSteelBlue" BorderColor="LightSteelBlue" />
                </td>
            </tr>
        </table>
        <br />
        <table id="Table2" language="javascript" onclick="return TABLE1_onclick()" style="z-index: 101;
            left: 193px; width: 841px; position: absolute; top: 45px; height: 28px">
            <tr>
                <td style="width: 192px; height: 21px; background-color: beige">
                    &nbsp; LETTER EDIT</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
