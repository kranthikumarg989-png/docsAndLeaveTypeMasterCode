<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="letterprecmg.aspx.vb" Inherits="E_Management.letterprecmg" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        </asp:UpdatePanel>
        &nbsp;
     
        <cc1:HtmlEditor ID="HtmlEditor1" runat="server" Style="position: relative; left: 0px; top: -14px;" Toolbars="" Enabled="False" Height="496px" Width="576px" ToggleMode="None" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
      
    </div>
    </form>
</body>
</html>
