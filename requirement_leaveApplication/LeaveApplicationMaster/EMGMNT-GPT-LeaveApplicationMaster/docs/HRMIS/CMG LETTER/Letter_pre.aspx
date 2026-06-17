<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Letter_pre.aspx.vb" Inherits="E_Management.Letter_pre1" %>

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
        <table style="z-index: 100; left: 217px; position: absolute; top: 20px">
            <tr>
                <td style="width: 151px; height: 21px">
                    <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 81px; position: absolute;
                        top: 4px" Text="Name" Width="61px"></asp:Label>
                </td>
                <td style="width: 159px; height: 21px">
                    <asp:TextBox ID="Name" runat="server" Style="z-index: 100; left: 159px; position: absolute;
                        top: 3px"></asp:TextBox>
                </td>
                <td style="width: 273px; height: 21px">
                    <asp:Button ID="EditHtml" runat="server" Style="z-index: 100; left: 431px; position: absolute;
                        top: 149px" Text="Preview" TabIndex="7" />
                </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 22px">
                    <asp:Label ID="Label2" runat="server" Style="z-index: 100; left: 82px; position: absolute;
                        top: 30px" Text="EmpNo" Width="61px"></asp:Label>
                </td>
                <td style="width: 159px; height: 22px">
                    <asp:TextBox ID="EmpNo" runat="server" Style="z-index: 100; left: 158px; position: absolute;
                        top: 27px" TabIndex="1"></asp:TextBox>
                </td>
                <td style="width: 273px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 21px">
                    <asp:Label ID="Label3" runat="server" Style="z-index: 100; left: 70px; position: absolute;
                        top: 55px" Text="Department" Width="72px"></asp:Label>
                </td>
                <td style="width: 159px; height: 21px">
                    <asp:TextBox ID="Department" runat="server" Style="z-index: 100; left: 160px; position: absolute;
                        top: 52px" TabIndex="2"></asp:TextBox>
                </td>
                <td style="width: 273px; height: 21px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 151px; height: 21px;">
                    <asp:Label ID="Label4" runat="server" Style="z-index: 100; left: 72px; position: absolute;
                        top: 78px" Text="Designation" Width="61px"></asp:Label>
                </td>
                <td style="width: 159px; height: 21px;">
                    <asp:TextBox ID="Designation" runat="server" Style="z-index: 100; left: 160px; position: absolute;
                        top: 78px" TabIndex="3"></asp:TextBox>
                </td>
                <td style="width: 273px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 151px">
                    <asp:Label ID="Label5" runat="server" Style="z-index: 100; left: 78px; position: absolute;
                        top: 102px" Text="Nomonths" Width="61px"></asp:Label>
                </td>
                <td style="width: 159px">
                    <asp:TextBox ID="Nomonths" runat="server" Style="z-index: 100; left: 161px; position: absolute;
                        top: 101px" TabIndex="4"></asp:TextBox>
                </td>
                <td style="width: 273px">
                </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 21px;">
                    <asp:Label ID="Label6" runat="server" Style="z-index: 100; left: 43px; position: absolute;
                        top: 128px" Text="Probationperiod" Width="61px"></asp:Label>
                </td>
                <td style="width: 159px; height: 21px;">
                    <asp:TextBox ID="Probationperiod" runat="server" Style="z-index: 100; left: 161px; position: absolute;
                        top: 123px" TabIndex="5"></asp:TextBox>
                </td>
                <td style="width: 273px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 151px">
                    <asp:Label ID="Label7" runat="server" Style="z-index: 100; left: 77px; position: absolute;
                        top: 150px" Text="Issuedate" Width="61px"></asp:Label>
                </td>
                <td style="width: 159px">
                    <asp:TextBox ID="Issuedate" runat="server" Style="z-index: 100; left: 160px; position: absolute;
                        top: 147px" TabIndex="6"></asp:TextBox>
                </td>
                <td style="width: 273px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 50px">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 281px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:HtmlEditor ID="HtmlEditor1" runat="server" Style="z-index: 100; left: 1px; position: absolute;
                                top: 173px" Width="800px" HtmlModeEditable="False" ShowModifiedAsterick="False" TextDirection="LeftToRight" ToggleMode="None" Height="360px"/>
                            &nbsp; &nbsp;
                            <asp:Button ID="Button1" runat="server" Style="z-index: 102; left: 471px; position: absolute;
                                top: 479px" Text="Save & Print" Width="97px" OnClick="Button1_Click" TabIndex="8" />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                           
                            
                        </ContentTemplate>
                        
                        
                        
                        
                          
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
       
    


    </div>
 
    </form>
</body>
</html>
