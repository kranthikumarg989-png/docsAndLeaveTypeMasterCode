<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Letterpage.aspx.vb" Inherits="E_Management.Letterpage" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
<script language="javascript" type="text/javascript">
<!--

function TABLE1_onclick() {

}

// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        &nbsp;
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="z-index: 100; left: 240px; position: absolute; top: 10px; height: 519px; width: 785px;">
            <tr>
                <td colspan="3" style="height: 54px">
                    <table style="z-index: 100; left: 6px; position: absolute; top: 3px" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
                        <tr>
                            <td style="width: 80px; height: 21px; background-color: beige">
                                EmpCode</td>
                            <td style="width: 257px; background-color: beige; height: 21px;">
                                &nbsp;
                                <asp:TextBox ID="empcode" runat="server" AutoPostBack="True" Height="17px" Style="z-index: 100;
                                    left: 130px; position: absolute; top: -2px" Width="82px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode"
                                    ErrorMessage="!" style="z-index: 102; left: 229px; position: absolute; top: 1px"></asp:RequiredFieldValidator></td>
                            <td style="color: #000000; background-color: beige; width: 161px; height: 21px;">
                                EmpName</td>
                            <td style="width: 178px; background-color: beige; height: 21px;">
                                <asp:Label ID="empname" runat="server" Width="152px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 80px; height: 21px; background-color: beige">
                                Department</td>
                            <td style="width: 257px; height: 21px; background-color: beige">
                                <asp:Label ID="departmentcode" runat="server" Width="150px"></asp:Label></td>
                            <td style="height: 21px; background-color: beige; width: 161px;">
                                Section</td>
                            <td style="width: 178px; height: 21px; background-color: beige">
                                <asp:Label ID="sectioncode" runat="server" Width="156px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 120px; background-color: beige; height: 73px;">
                                Designation</td>
                            <td style="width: 257px; background-color: beige; height: 73px;">
                                <asp:Label ID="designation" runat="server" Width="171px"></asp:Label></td>
                            <td style="width: 161px; background-color: beige; height: 73px;">
                                Employee Status
                            </td>
                            <td style="width: 178px; background-color: beige; height: 73px;">
                                <asp:Label ID="emptype" runat="server" Width="152px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 53px; border-bottom: slategray 1px dashed;">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 11px; position: absolute;
                        top: 95px" Text=" Select Letter Name" Width="143px"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" Style="z-index: 101; left: 204px;
                        position: absolute; top: 93px" Width="384px" AutoPostBack="True" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="lettername" DataValueField="lettername">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" Style="z-index: 102; left: 618px; position: absolute;
                        top: 91px" Text="Preview" />
                    <asp:Button ID="Button2" runat="server" Style="z-index: 104; left: 705px; position: absolute;
                        top: 94px" Text="Button" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 33px">
                    <asp:Label ID="Label2" runat="server" Style="z-index: 100; left: 6px; position: absolute;
                        top: 131px" Text="Fill in the following details" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    
                    
                    </asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 14px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 163px">
                    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:HtmlEditor ID="HtmlEditor1" runat="server" Style="z-index: 100; left: 2px; position: absolute;
                                top: 228px" Width="635px" Height="300px" SaveButtons="" DesignModeEmulateIE7="False" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                </td>
            </tr>
          
            <tr>
                <td style="width: 70px; height: 26px">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </td>
                <td style="width: 100px; height: 26px">
                </td>
                <td style="width: 409px; height: 26px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 409px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 409px; height: 9px">
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
            SelectCommand="SELECT DISTINCT [lettername] FROM [HRMIS_ER_MASTER_LETTER] ORDER BY [lettername]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
