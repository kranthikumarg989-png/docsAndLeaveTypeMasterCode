<%--<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm3.aspx.vb" Inherits="E_Management.WebForm3" %>--%>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm3.aspx.vb" Inherits="E_Management.WebForm3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Letter wizard</title>
       <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" cellpadding="1" cellspacing="1" style="z-index: 105; left: 234px;
            width: 500px; position: absolute; top: 33px; height: 112px" bordercolor="#191970">
            <tr>
                <td colspan="3" style="height: 40px">
                    &nbsp;Choose Letter Type
                    &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 141px; position: absolute;
                        top: 15px" Text="CMG" Width="52px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 26px" colspan="3">
                    &nbsp;Enter Letter Name&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 140px; position: absolute;
                        top: 50px" Width="344px"></asp:TextBox>
                    <strong></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 35px">
                    Select Fields to be
                    <br />
                    added in Letter
                    <asp:ListBox ID="ListBox1" runat="server" Font-Size="Small" Height="39px" SelectionMode="Multiple"
                        Style="z-index: 100; left: 139px; position: absolute; top: 77px" Width="161px"></asp:ListBox>
                         </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 26px; text-align: center">
                    &nbsp;<strong>Key in Fields Name to be added in Letter</strong></td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px; text-align: center">
                    <strong>
                    Serial No</strong></td>
                <td style="width: 307px; height: 26px; text-align: center">
                    Ent<strong>er the Name</strong></td>
                <td style="width: 339px; height: 26px; text-align: center">
                    <strong>Select Any Type</strong></td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    1</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox2" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 186px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 182px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    2</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox3" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 217px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 214px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;3</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox4" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 248px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 246px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    4</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox5" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 279px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 278px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;5</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox6" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 309px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 309px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp;&nbsp; 6</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox7" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 341px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 339px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp;&nbsp; 7</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox8" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 372px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 368px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp;&nbsp; 8</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox9" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 402px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 400px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp;&nbsp; 9</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox10" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 434px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 431px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 125px; height: 26px">
                    &nbsp; &nbsp; &nbsp; 10</td>
                <td style="width: 307px; height: 26px">
                    <asp:TextBox ID="TextBox11" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 465px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 339px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 462px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 26px" align="right">
                    <asp:Button ID="Button1" runat="server" Style="z-index: 100; left: 274px; position: absolute;
                        top: 494px" Text="Save & Next" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
