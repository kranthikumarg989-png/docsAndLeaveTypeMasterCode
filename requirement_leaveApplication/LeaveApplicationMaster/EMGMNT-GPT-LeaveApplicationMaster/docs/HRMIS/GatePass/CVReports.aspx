<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CVReports.aspx.vb" Inherits="E_Management.CVReports" 
    title="CUSTOMER PASS REPORTS" %>
       <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table>
            <tr>
                <td style="background-color: #cccc99; height: 28px;">
                    <asp:Label ID="Label23" runat="server" Text="Report TimeLine"  ></asp:Label></td>
                <td style="width: 403px; height: 28px;" >
                    <asp:TextBox ID="Txtcsf" runat="server" ></asp:TextBox> 
                    ~
                    <asp:TextBox ID="txtcst" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtcsf">*
                    </asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtcst"
                       >*</asp:RequiredFieldValidator></td>
                    <cc1:CalendarExtender ID="CalendarExtender3"  runat="server"
                    TargetControlID="txtcsf" Format = "dd/MM/yy"           
                    CssClass="cal_Theme1"  
                    PopupButtonID="txtcsf" />
                    
                    <cc1:CalendarExtender ID="CalendarExtender4"  runat="server"
                    TargetControlID="txtcst" Format = "dd/MM/yy"           
                    CssClass="cal_Theme1"  
                    PopupButtonID="txtcst"/>
                <td align="right" colspan="2" style="height: 28px">
                    <asp:Button SkinID ="buttonskin1" ID="btnCvReport" runat="server" Text="SHOW REPORT"  /></td>
            </tr>
        </table>
     
</asp:Content>
