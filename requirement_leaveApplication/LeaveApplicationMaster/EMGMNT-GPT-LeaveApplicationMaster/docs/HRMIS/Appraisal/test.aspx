<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="E_Management.test" %>

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
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="199px" TextMode="MultiLine" Width="365px"></asp:TextBox>
        <asp:Label ID="empcode" runat="server" Text="014543"></asp:Label>
        <asp:Label ID="dept" runat="server" Text="9000"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
