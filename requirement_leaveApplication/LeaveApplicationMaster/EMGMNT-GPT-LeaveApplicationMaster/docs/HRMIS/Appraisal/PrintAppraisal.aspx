<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintAppraisal.aspx.vb" Inherits="E_Management.PrintAppraisal" %>


<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>CMG_letterpreview</title>
     <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <cc1:HtmlEditor ID="HtmlEditor1" runat="server" EditorBorderSize="1" Height="718px"
                    Style="z-index: 100; left: 6px; position: absolute; top: 10px" ToggleMode="None"
                    ToolbarDocked="False" Width="840px" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

