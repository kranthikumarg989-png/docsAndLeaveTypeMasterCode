<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="letterapprovalpreview.aspx.vb" Inherits="E_Management.letterapprovalpreview" %>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="labpnt" runat="server" Style="z-index: 102; left: 311px; position: absolute;    top: 7px" Text="Label" Width="273px" Visible="False"></asp:Label>
        <cc1:HtmlEditor ID="HtmlEditor1" runat="server" style="left: 2px; position: relative; top: 25px; z-index: 101;" EditorBorderSize="1" Height="1200px" ToggleMode="None" Toolbars="" Width="827px" />
    </div>
    </form>
</body>
</html>
