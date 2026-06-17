<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmFirstWelcome.aspx.vb" Inherits="E_Management.frmFristWelcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td style="width: 1px; height: 279px">
                </td>
                <td align="center" style="width: 868px; height: 279px">
                    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/loading9.gif" /></td>
                <td style="width: 100px; height: 279px">
                </td>
            </tr>
            <tr>
                <td style="width: 1px; height: 155px">
                </td>
                <td align="center" style="width: 868px; height: 155px">
                    <strong><span style="color: #ff0000">Creating User Settings for the first time user..
                        Please wait.. Don't Close your Browser while loading..</span></strong></td>
                <td style="width: 100px; height: 155px">
                </td>
            </tr>
            <tr>
                <td style="width: 1px">
                </td>
                <td style="width: 868px">
                    <span style="color: #ff0000"></span>
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
