<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptGpDept.aspx.vb" MasterPageFile ="~/site.Master"  Inherits="E_Management.RptGpDept1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ContentPlaceHolderID = "CPHApplication" runat ="server" >

<asp:Panel ID = "pnlGPreports" runat = "server" Height= "100%" Width ="900px">

   
        <table>
            <tr>
                <td colspan="2" style="width: 776px; border-bottom: 2px solid" >
        <table>
            <tr>
                <td style="background-color: #cccc99">
                    <asp:Label ID="Label1" runat="server" Text="Report TimeLine" Width="143px" ></asp:Label></td>
                <td style="width: 403px" >
                    <asp:TextBox ID="txtfrom" runat="server" Width="87px" ></asp:TextBox> 
                    ~
                    <asp:TextBox ID="txtto" runat="server" Height="14px" Width="77px"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfrom"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                    
                    <cc1:CalendarExtender ID="ccefrom"  runat="server"
    TargetControlID="txtfrom" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtfrom"
  
       />
                    
                    <cc1:CalendarExtender ID="cceto"  runat="server"
    TargetControlID="txtto" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtto"
  
       />
            </tr>
            <tr>
                <td style="height: 33px; background-color: #cccc99">
                    <asp:Label ID="Label5" runat="server" Text="Report By"></asp:Label></td>
                <td style="width: 403px; height: 33px">
                    <asp:RadioButtonList ID="rdoptions" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Value="Dept">ByDept</asp:ListItem>
                        <asp:ListItem Value="Sect">BySect</asp:ListItem>
                        <asp:ListItem Value="Desig">ByDesig</asp:ListItem>
                        <asp:ListItem Value="Emp">ByEmp</asp:ListItem>
                        <asp:ListItem Selected="True" Value="* ">* (ALL)</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="height: 24px; background-color: #cccc99">
                    <asp:Label ID="lbldept" runat="server" Text="Select Department"></asp:Label>&nbsp;</td>
                <td style="width: 403px; height: 24px">
                    <asp:DropDownList ID="ddldept" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="dept" DataValueField="departmentcode">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 24px; background-color: #cccc99">
                    <asp:Label ID="lblsect" runat="server" Text="Select Section"></asp:Label></td>
                <td style="width: 403px; height: 24px">
                    <asp:DropDownList ID="ddlsect" runat="server" DataSourceID="sqlsect" DataTextField="section"
                        DataValueField="sectioncode">
                    </asp:DropDownList>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="background-color: #cccc99; height: 24px;">
                    <asp:Label ID="lbldesig" runat="server" Text="Select Designation"></asp:Label></td>
                <td style="width: 403px; height: 24px;">
                    <asp:DropDownList ID="ddldesig" runat="server" DataSourceID="SqlDesig" DataTextField="desig"
                        DataValueField="desig">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #cccc99">
                    <asp:Label ID="lblemp" runat="server" Text="ByEmployee"></asp:Label></td>
                <td style="width: 403px">
                    <asp:TextBox ID="txtempid" runat="server" Width="83px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 26px">
                    <asp:Button ID="Button1" runat="server" Text="Show Report" /></td>
            </tr>
        </table></td></tr>
                    <asp:SqlDataSource ID="sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select sectioncode +'-' +sectionname as section,sectioncode from sectionmaster">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDesig" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select ( LTRIM(RTRIM( designationname))) as desig from designation">
                    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department">
                    </asp:SqlDataSource>
               
        </table>
  </asp:Panel>    

   
 
    </asp:Content>
  
