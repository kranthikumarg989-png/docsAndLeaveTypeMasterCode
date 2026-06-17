<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ER_letter_IssuePage.aspx.vb" Inherits="E_Management.ER_letter_IssuePage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
		<title>Letter issuepage </title>
            <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
                      
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="companyname" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;
    </div>
        <table  border="1" style="width: 817px">
            <tr>
                <td colspan="3" style="width: 833px;">
                    <table style="width: 841px; height: 104px;" >
                        <tr>
                            <td style="width: 153px; height: 21px; background-color: beige">
                                EmpCode</td>
                            <td style="width: 162px; height: 21px; background-color: beige">
                                &nbsp;<asp:TextBox ID="empcode" runat="server" AutoPostBack="True" Height="17px" Width="82px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode"
                                    ErrorMessage="*" Style="z-index: 100; left: 0px; position: relative; top: -4px"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 112px; color: #000000; height: 21px; background-color: beige">
                                EmpName</td>
                            <td style="width: 178px; height: 21px; background-color: beige">
                                <asp:Label ID="empname" runat="server" Width="253px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 153px; height: 21px; background-color: beige">
                                Department</td>
                            <td style="width: 162px; height: 21px; background-color: beige">
                                <asp:Label ID="departmentcode" runat="server" Width="150px"></asp:Label></td>
                            <td style="width: 112px; height: 21px; background-color: beige">
                                Section</td>
                            <td style="width: 178px; height: 21px; background-color: beige">
                                <asp:Label ID="sectioncode" runat="server" Width="156px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 153px; height: 23px; background-color: beige">
                                Designation</td>
                            <td style="width: 162px; height: 23px; background-color: beige">
                                <asp:Label ID="designation" runat="server" Width="171px"></asp:Label></td>
                            <td style="width: 112px; height: 23px; background-color: beige">
                                Employee Status
                            </td>
                            <td style="width: 178px; height: 23px; background-color: beige">
                                <asp:Label ID="emptype" runat="server" Width="152px"></asp:Label></td>
                        </tr>
                        <tr>                                             
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 833px; border-bottom: slategray 1px dashed; height: 6px;">
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        <asp:Panel ID="Panel2" runat="server" Height="189px" Width="846px" >
        <table  id="tbl2" style="width: 376px; z-index: 100; left: 41px; position: absolute; top: 172px; height: 123px;" >
            <tbody>
            <tr>
                    <td class="td_head" colspan="3" >
                        Summary                
                    </td>
                </tr>
                <tr>
                    <td style="background-color: beige; width: 98px;" align="right" >
                        Reason :&nbsp;</td>
                    <td align="left" style="width: 716px"  >
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListBox ID="ListBox1" runat="server" Height="46px" ></asp:ListBox>
                        <table style="z-index: 100; left: 378px; width: 384px; position: absolute; top: 0px; height: 121px;" >
                            <tr>
                                <td colspan="2" class="td_head">
                                    Individual</td>
                            </tr>
                            <tr>
                                <td style="width: 199px; background-color: beige">
                                    Explanation &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; :
                                    <asp:Label ID="lblexpl" runat="server" Style="z-index: 100; left: 129px; position: absolute;
                                        top: 28px"></asp:Label>
                                </td>
                                <td style="background-color: beige">
                                    Final Warning &nbsp; &nbsp;:<asp:Label ID="lblfinw" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 199px; background-color: beige; height: 22px;">
                                    Verbal Warning &nbsp; &nbsp; &nbsp;:<asp:Label ID="lblvw" runat="server"></asp:Label></td>
                                <td style="background-color: beige; height: 22px;">
                                    Suspension &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsus" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 199px; background-color: beige">
                                    Written Warning &nbsp; &nbsp; :<asp:Label ID="lblww" runat="server"></asp:Label></td>
                                <td style="background-color: beige">
                                    Showcase &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsc" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 199px; background-color: beige">
                                    First Warning &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblfw" runat="server"></asp:Label></td>
                                <td style="background-color: beige">
                                    Misconduct Rpt :<asp:Label ID="lblrpt" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: beige;" align="right">
                        &nbsp;Total :&nbsp;</td>
                    <td align="left"  >
                        &nbsp;
                        <asp:Label ID="total" runat="server" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border-bottom: slategray 1px dashed; width: 833px;">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text=" Select Letter Name" Width="127px"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        DataSourceID="SqlDataSource2" DataTextField="lettername" DataValueField="lettername"
                        Width="302px">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="Button1" runat="server"  Text="Preview" BackColor="LightSteelBlue" />
                    <asp:Button ID="Button2" runat="server" Text="Refresh" Width="76px" BackColor="LightSteelBlue" />
                    <%--<asp:Button ID="Button2" runat="server" Style="z-index: 104; left: 705px; position: absolute;
                        top: 94px" Text="Button" />--%>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 833px; height: 42px;">
                    <asp:Label ID="Label2" runat="server"  Text="Fill in the following details" Visible="False"></asp:Label>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <br />
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 119px; width: 833px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <cc1:HtmlEditor ID="HtmlEditor1" runat="server"  width="730px" Height="1200px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
            <td align="right" style="width: 187px; height: 12px;">
                <asp:Button id="Button3" onclick="Button3_Click" runat="server" Width="76px" Text="Save" BackColor="LightSteelBlue"></asp:Button>
            </td>
            </tr>
        </table>
        <br />
        <br />
        &nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
             InsertCommand="INSERT INTO [HRMIS_ER_MASTER_LETTER_SAVE]([lettercontents],[empcode],[lettername],[issuedate],[createdby],[status],[lettertype]) VALUES ((CONVERT(VARCHAR(7000),@lettercontents)),@empcode,@lettername,@issuedate,@createdby,@status,@lettertype)">
          <DeleteParameters>
                <asp:Parameter Name="NewsID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
            SelectCommand="SELECT DISTINCT [lettername] FROM [HRMIS_ER_MASTER_LETTER]  where status='Approved' or status='ES' ">
        </asp:SqlDataSource>
                
    </form>
</body>
</html>
