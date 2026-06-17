<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewEMS.Master" CodeBehind="Default.aspx.vb" Inherits="E_Management._Default"     title="Welcome to EMS" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
 
 <br /><br /><br /><br /><br /><br />

    <table align=center  id="TABLE1"  class="table table-hover" style="width: 42%; height: 210px; text-align: left">
        <tr>
            <td colspan="2" align="center" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; height: 53px;">
              <br />  <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.jpg" />
              <br /></td>
        </tr>
        <tr>
            <td colspan="2">
            <br />
                <p align="center" designtimesp="6546">
                    <font designtimesp="6547" face="Tahoma" size="3" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none">WELCOME TO e-MANAGEMENT SYSTEMS</font></p>
                 <br />   
            </td>
        </tr>
        <tr>
            <td colspan="" rowspan="" style="height: 19px;" >
                <asp:Label ID="lblecode1" runat="server" Text="Employee Code" Font-Bold="True"></asp:Label></td>
            <td colspan="" rowspan="" style="height: 19px;" >
            <asp:Label ID="lblecode" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="" rowspan="" >
                <asp:Label ID="lblename1" runat="server" Text="Employee Name" Font-Bold="True"></asp:Label></td>
            <td colspan="" rowspan="" >
             <asp:Label ID="lblename" runat="server" Text="EmpName" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="" rowspan="" >
                <asp:Label ID="lbldept1" runat="server" Text="Department" Font-Bold="True"></asp:Label></td>
            <td colspan="" rowspan="" >
             <asp:Label ID="lbldept" runat="server" Text="Department" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="" rowspan="" >
                <asp:Label ID="lblsect1" runat="server" Text="Section" Font-Bold="True"></asp:Label></td>
            <td colspan="" rowspan="" >
             <asp:Label ID="lblsect" runat="server" Text="Section" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="" rowspan="" >
                <asp:Label ID="lbldesig1" runat="server" Text="Designation" Font-Bold="True"></asp:Label></td>
            <td colspan="" rowspan="" >
              <asp:Label ID="lbldesig" runat="server" Text="Designation" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>

   
 <asp:Panel ID="Panel1" runat="server" Visible=false BorderWidth="1px" >
            <table>
                <tr>
                    <td colspan="2" >
            <asp:Label ID="lblMessage" runat="server" Font-Size="Medium" ForeColor="#404040"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" colspan="2" >
                        <asp:Button SkinID ="buttonskin1" ID="btnOk" runat="server" Text= "OK" />&nbsp;
                        <asp:Button SkinID ="buttonskin1" ID="okbutton" runat="server" Text= "Cancel" /></td>
                </tr>
            </table>
     <asp:Label ID="lblp" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblc" runat="server" Visible="False"></asp:Label></asp:Panel>
        
    <cc1:ModalPopupExtender id="alertMpe" runat="server" TargetControlID="btnShowModalPopup"
    PopupDragHandleControlID="panel1" PopupControlID="panel1" OkControlID="okbutton"
    EnableViewState="False" DropShadow="false" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
     <asp:Button style="DISPLAY: none" id="btnShowModalPopup" runat="server" SkinID="buttonskin1"></asp:Button>
 
 
</asp:Content>
