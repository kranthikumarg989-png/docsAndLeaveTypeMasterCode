<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Letterpage.aspx.vb" Inherits="E_Management.Letterpage" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Issue letter</title>
        <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
        <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
             
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table >
            <tr>
                <td colspan="3" style="height: 54px">
                    <table  id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
                        <tr>
                            <td colspan="4" style="height: 21px; background-color: beige">
                                Key in Empcode and select a CMG Letter to Issue</td>
                        </tr>
                        <tr>
                            <td style="width: 80px; height: 21px; background-color: beige">
                                EmpCode</td>
                            <td style="width: 198px; background-color: beige; height: 21px;">
                                <asp:TextBox ID="empcode" runat="server" AutoPostBack="True" Height="17px" Width="95px" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode"
                                    ErrorMessage="!" ></asp:RequiredFieldValidator></td>
                            <td style="color: #000000; background-color: beige; width: 161px; height: 21px;">
                                EmpName</td>
                            <td style="width: 178px; background-color: beige; height: 21px;">
                                <asp:Label ID="empname" runat="server" Width="152px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 80px; height: 24px; background-color: beige">
                                Department</td>
                            <td style="width: 198px; height: 24px; background-color: beige">
                                <asp:Label ID="departmentcode" runat="server" Width="150px"></asp:Label></td>
                            <td style="height: 24px; background-color: beige; width: 161px;">
                                Section</td>
                            <td style="width: 178px; height: 24px; background-color: beige">
                                <asp:Label ID="sectioncode" runat="server" Width="156px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 120px; background-color: beige; height: 31px;">
                                Designation</td>
                            <td style="width: 198px; background-color: beige; height: 31px;">
                                <asp:Label ID="designation" runat="server" Width="171px"></asp:Label></td>
                            <td style="width: 161px; background-color: beige; height: 31px;">
                                Employee Status
                            </td>
                            <td style="width: 178px; background-color: beige; height: 31px;">
                                <asp:Label ID="emptype" runat="server" Width="152px"></asp:Label></td>
                        </tr>
                    </table>
                    <asp:Label ID="lbllink" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 53px; border-bottom: slategray 1px dashed;">
                    <asp:Label ID="Label1" runat="server"  Text=" Select Letter Name" Width="127px"></asp:Label>
                    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Width="384px" AutoPostBack="True" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="lettername" DataValueField="lettername">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server"  Text="Preview" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <%--<asp:Button ID="Button2" runat="server" Style="z-index: 104; left: 705px; position: absolute;
                        top: 94px" Text="Button" />--%>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label2" runat="server"  Text="Fill in the following details" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    
                    
                    </asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 163px">
                    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:HtmlEditor ID="HtmlEditor1" runat="server" 
                                ToggleMode="None" Width="850px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                </td>
            </tr>
          
            <tr>
                <td style="width: 70px; height: 28px">
                    &nbsp;</td>
                <td style="width: 100px; height: 28px">
                </td>
                <td style="height: 28px" align="right">
                <asp:Button ID="Button3" runat="server" Text="Save & Print" Width="115px" OnClick="Button3_Click" /></td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
            SelectCommand="SELECT DISTINCT [lettername] FROM [HRMIS_CMG_MASTER_LETTER]where status='Approve' ORDER BY [lettername]">
        </asp:SqlDataSource>
        
        
         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
            
            InsertCommand="INSERT INTO [emp_bangladeshi]([empcode],[letterdate],[fromdate],[todate],[witcode]) VALUES (@empcode,@letterdate,@fromdate,@todate,@witcode)" >
                        <%--InsertCommand="INSERT INTO [HRMIS_ER_MASTER_LETTER_SAVE]([lettercontents],[empcode],[lettername],[issuedate],[createdby]) VALUES (@lettercontents,@empcode,@lettername,@issuedate,@createdby)" >--%>
                       
                       <%-- UpdateCommand="UPDATE [HRMIS_ER_MASTER_LETTER] SET [lettercontents] = @lettercontents WHERE [NewsID] = @NewsID">--%>
                        <DeleteParameters>
                            <asp:Parameter Name="NewsID" Type="Int32" />
                      </DeleteParameters>
   
            </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />
        &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        
             
        <br />
        <br />
        <br />
        <br />
        
      
            
           
            
            
            
            
            
            
            
    
    </div>
    </form>
</body>
</html>
