<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CMG_LetterModify.aspx.vb" Inherits="E_Management.CMG_LetterModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>CMG Letter Modify</title>
         <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 842px" border="1">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <tr>
                <td colspan="3" style="height: 24px" >
                    <asp:Label ID="Label5" runat="server" Font-Underline="True" ForeColor="Maroon" Text="CMG LETTER EDIT (Select a Letter from drop downlist and EDIT Letter)"></asp:Label></td>
            </tr>
        <tr>
            <td colspan="3" style="height: 24px">
                <asp:Label ID="Label1" runat="server"  Text=" Select Letter Name" Width="126px"></asp:Label>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource1" DataTextField="lettername" DataValueField="lettername"
                      AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    </asp:DropDownList></td>
        </tr>
      <tr>
          <td colspan="3">
                    
                    <asp:Label ID="Label2" runat="server" Text="Revision No :" Width="89px"></asp:Label>
              &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label3" runat="server" ></asp:Label></td>
      </tr>
            <tr>
                <td colspan="3" style="height: 155px">
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:HtmlEditor ID="HtmlEditor1" runat="server" Width="840px" />
                                                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 22px">
                    &nbsp;</td>
                <td align="right" style="height: 22px" >
                    <asp:Button ID="btnUpdate" runat="server"  Text="Update" SkinID="buttonskin1" />
                </td>
            </tr>
        </table>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" SelectCommand="SELECT DISTINCT [lettername] FROM [HRMIS_CMG_MASTER_LETTER] ORDER BY [lettername]"></asp:SqlDataSource>
    
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" 
       updateCommand="update [HRMIS_CMG_MASTER_LETTER] set modifiedby = @createdby, revision = @rev,modifiedtime =@time ,letterlink =@letterlink,status = @status where Lettername = @lettername" >
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
