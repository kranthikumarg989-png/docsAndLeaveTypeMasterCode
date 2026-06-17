<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ERletterview.aspx.vb" Inherits="E_Management.ERletterview" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"  TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ER_letterview</title>
    <script type="text/javascript">
function CallPrint(strid)
{
var prtContent = document.getElementById(strid);
var WinPrint = window.open('','','left=0,top=0,width=300,height=300,toolbar=0,scrollbars=0,status=0');
WinPrint.document.write(prtContent.innerHTML);
WinPrint.document.close();
WinPrint.focus();
WinPrint.print();
WinPrint.close();
prtContent.innerHTML=strOldOne;
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id=printz>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;
        <cc1:HtmlEditor ID="HtmlEditor1" runat="server" Style="z-index: 100; left: 12px; position: absolute;
            top: 42px" ToggleMode="None" Toolbars="" EditorBorderSize="1" Height="1200px" Width="840px" />
                   </div>
        </div>
    </form>
</body>
</html>
