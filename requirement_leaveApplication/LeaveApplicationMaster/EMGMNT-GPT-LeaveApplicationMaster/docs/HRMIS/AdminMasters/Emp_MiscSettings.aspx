<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Emp_MiscSettings.aspx.vb" Inherits="E_Management.Emp_MiscSettings" MasterPageFile="~/ems.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img alt ="" height="16" src="../../images/top_lef.gif" width="16"/></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img alt ="" height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img alt ="" height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif"  width="16">
                <img alt ="" height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel1" runat="server">
                            
                            
                            
   <table><tr><td colspan=4 style="background-color: beige;" bgcolor="#336699">
       <asp:Label ID="Label1" runat="server" Text="Canteen Subsidy Settings" Font-Underline="False" Width="500px" BackColor="#336699" Font-Bold="True" ForeColor="White"></asp:Label></td></tr>
       <tr>
           <td style="background-color: beige">
           </td>
           <td style="background-color: beige; text-align: left">
               <asp:Label ID="Label3" runat="server" Text="Company Name" Width="300px"></asp:Label></td>
           <td>
               <asp:DropDownList ID="CmbOldCompany" runat="server" Width="155px">
                   <asp:ListItem>-Select-</asp:ListItem>
                   <asp:ListItem>MMSB</asp:ListItem>
                   <asp:ListItem>MMEL</asp:ListItem>
                   <asp:ListItem>MLI</asp:ListItem>
                   <asp:ListItem>OutSource</asp:ListItem>
               </asp:DropDownList></td>
           <td>
           </td>
       </tr>
       <tr>
           <td style="background-color: beige;">
           </td>
           <td style="background-color: beige; text-align: left;">
               <asp:Label ID="Label4" runat="server" Text="Employee Code" Width="300px"></asp:Label></td>
           <td style="height: 21px">
               <asp:TextBox ID="TxtOldEmpCode" runat="server" AutoPostBack="true"></asp:TextBox></td>
           <td style="height: 21px">
           </td>
       </tr>
       
       <tr>
       <td style="background-color: beige"></td>
       <td style="background-color: beige; text-align: left">
           <asp:Label ID="Label2" runat="server" Text="Is he / she has an eligiblity of canteen subsidy?" Width="300px"></asp:Label></td>
           <td>
               <asp:RadioButton ID="RBtnYes" runat="server" Text="Yes" GroupName="SubsidySts" Visible="False" /> 
               <asp:RadioButton ID="RbtnNo" runat="server" Text="No" Checked="True" GroupName="SubsidySts" /></td>
           <td></td>
       </tr>
       <tr>
           <td style="height: 23px; background-color: beige;">
           </td>
           <td style="height: 23px; background-color: beige;">
           </td>
           <td style="height: 23px">
           </td>
           <td style="height: 23px">
           </td>
       </tr>
       <tr>
           <td style="background-color: beige;">
           </td>
           <td style="background-color: beige; text-align: left;">
               <asp:Label ID="LblMsg" runat="server" Width="300px" Font-Bold="True" ForeColor="#FF0099"></asp:Label></td>
           <td style="height: 21px">
               <asp:Button ID="BtnSave" runat="server" Text="Save" /></td>
           <td style="height: 21px">
           </td>
       </tr>
       <tr>
           <td style="background-color: beige;">
           </td>
           <td style="background-color: beige;">
           </td>
           <td style="height: 21px">
           </td>
           <td style="height: 21px">
           </td>
       </tr>
       <tr>
           <td colspan="4" style="background-color: beige;" bgcolor="#336699">
               <asp:Label ID="Label5" runat="server" Text="Following employees are don’t have an eligibility of canteen subsidy!"
                   Width="500px" BackColor="#336699" Font-Bold="True" ForeColor="White"></asp:Label></td>
       </tr>
       <tr>
           <td colspan="4" style="height: 21px">
               <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                   <RowStyle BackColor="#EFF3FB" />
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <EditRowStyle BackColor="#2461BF" />
                   <AlternatingRowStyle BackColor="White" />
               </asp:GridView>
           </td>
       </tr>
       </table>                         
                          



                                
                            
	</asp:Panel>
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../../images/cen_rig.gif" style="width: 24px;">
                <img height="11" src="../../images/cen_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" alt=""/></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" alt=""/></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" alt=""/></td>
        </tr>
    </table>
</asp:Content>