<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="printmanual.aspx.vb" Inherits="E_Management.printmanual" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <%--<script type="text/javascript">
<!--
function delayer()
{
    window.print()
}
//-->

</script>--%>
     </head>
<%--<body  onLoad="setTimeout('delayer()', 1000)">--%>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                          </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    
<cc1:HtmlEditor ID="HtmlEditor1" runat="server"  Width="710px" Height="1300px" 
     DesignModeEditable="False" Enabled="False" Toolbars="" ToggleMode="None"
      EditorBorderSize="1"/>

     
                   
    </div>
    </form>
</body>
</html>
