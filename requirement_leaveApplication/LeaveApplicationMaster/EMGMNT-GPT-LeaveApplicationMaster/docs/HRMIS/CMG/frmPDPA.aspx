<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmPDPA.aspx.vb" Inherits="E_Management.frmPDPA" title="PDPA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 14px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table id="TABLE2" style="height: 185px">
    <tr>
        <td colspan="1" class="td_head" style="width: 619px; height: 40px;">
                        <asp:Label ID="Label1" runat="server" Font-Underline="False" ForeColor="White" Text="New Confirmation Letter" Font-Bold="True" Width="621px"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 619px; height: 132px; text-align: center;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1"><tr>
                    <td style="width: 77px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Employee No." Width="94px"></asp:Label></td>
                    <td style="width: 214px; height: 26px;" valign="top" align="left">
                        <asp:TextBox ID="empcode" runat="server" Width="173px" AutoPostBack="True"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empcode"
                            ErrorMessage="Code !"></asp:RequiredFieldValidator>--%></td>
                    <td style="width: 125px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label14" runat="server" Text="Employee Name" Width="113px"></asp:Label></td>
                    <td style="width: 171px; height: 26px;" valign="top" align="left">
                        &nbsp;<asp:Label ID="Label11" runat="server" Width="170px"></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 77px; background-color: beige; height: 11px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Department" Width="69px"></asp:Label></td>
                        <td style="width: 214px; height: 11px;" valign="top" align="left">
                            &nbsp;<asp:Label ID="Label13" runat="server" Width="175px"></asp:Label>
                        </td>
                    <td align="left" style="width: 125px; background-color: beige; height: 11px;" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Section" Width="122px" ForeColor="Black"></asp:Label></td>
                    <td align="left" style="width: 171px; height: 11px;" valign="top">
                        &nbsp;<asp:Label ID="Label10" runat="server" Width="172px"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;" class="td_head" colspan="4" rowspan="" title=" BACKGROUND-COLOR:lightgrey">
                            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" Visible="False" Width="173px"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="False" ForeColor="White"
                                Text="Options to Change"></asp:Label></td>
                    </tr>
                </table>
                &nbsp;<br />
                                <asp:Button ID="saveconf" runat="server" Text="SAVE" ValidationGroup="g" />
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
                            <asp:Label ID="lblcode" runat="server" Visible="False"></asp:Label></td>
        </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [sectioncode] FROM [sectionmaster] ORDER BY [sectioncode]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentcode] FROM [department] ORDER BY [departmentcode]">
                </asp:SqlDataSource>
                &nbsp;<asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [designationname] FROM [designation] ORDER BY [designationname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentname] FROM [department] ORDER BY [departmentname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectionname] FROM [sectionmaster] ORDER BY [sectionname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_programme] FROM [td_traininglist]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_title] FROM [td_traininglist] ORDER BY [td_title]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [empcode], [td_trainingattended], [td_programme], [td_remarks], [td_markscored], [td_dateattended], [td_hours], [trainingattachment] FROM [td_employeetraining] ORDER BY [empcode], [td_trainingattended], [td_dateattended]"
                    DeleteCommand = "delete DISTINCT from [td_employeetraining] WHERE [empcode] = @empcode AND [td_trainingattended]=@td_trainingattended AND [td_hours]=@td_hrs"
                    UpdateCommand = "update td_employeetraining set description=@description where categorycode=@categorycode">
                    <UpdateParameters>
                       <asp:Parameter Name="categorycode" Type="String" />
                        <asp:Parameter Name="description" Type="String" />       
                    </UpdateParameters>  
                    <DeleteParameters>
                       <asp:Parameter Name="empcode" Type="String" />
                        <asp:Parameter Name="td_trainingattended" Type="String" /> 
                         <asp:Parameter Name="td_hrs" Type="String" />      
                    </DeleteParameters>    
                </asp:SqlDataSource>
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<br />
                &nbsp;<br />
                &nbsp;
                <br />
                <br />
                &nbsp;<br />
                <br />
                <br />
                &nbsp;&nbsp;
                <br />
                
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 14px">
                </td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 14px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>
