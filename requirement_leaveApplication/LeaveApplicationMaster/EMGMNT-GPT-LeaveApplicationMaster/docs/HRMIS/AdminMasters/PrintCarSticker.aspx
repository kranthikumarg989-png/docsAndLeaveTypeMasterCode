<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintCarSticker.aspx.vb" Inherits="E_Management.PrintCarSticker" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
 <script type="text/javascript">



function Print() {

var mywindow = window.open('', 'PRINT', 'height=400,width=600');

    mywindow.document.write('<html><head><title>' + document.title  + '</title></head>');
    mywindow.document.write('<body >');
    mywindow.document.write('<h1>' + document.title  + '</h1>');
    mywindow.document.write(document.getElementById("dvReport").innerHTML);
    mywindow.document.write('</body></html>');

    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    mywindow.print();
    mywindow.close();

    return true;
}
</script>
<head runat="server">
 <%--   <title>Untitled Page</title>--%>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
       
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvReport">
        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true" DisplayGroupTree="False" DisplayToolbar="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"></cr:crystalreportviewer>
    
    </div>
    </form>
</body>
</html>
