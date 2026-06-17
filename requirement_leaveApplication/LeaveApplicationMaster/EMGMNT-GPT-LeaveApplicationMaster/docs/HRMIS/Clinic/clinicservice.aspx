<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="clinicservice.aspx.vb" Inherits="E_Management.clinicservice" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
 <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px" valign="top">
                <table id="TABLE2" language="javascript" onclick="return TABLE1_onclick()">
                    <tr>
                        <td class="td_head" colspan="2" >
                            CLINIC SERVICE COST</td>                      
                    </tr>
                    <tr>
                    <td bgcolor="beige">
                        Month &amp; Year :</td>
                    <td >
                        <asp:DropDownList ID="month" runat="server">
                            <asp:ListItem Value="-1">Month</asp:ListItem>
                            <asp:ListItem Value="1">JAN</asp:ListItem>
                            <asp:ListItem Value="2">FEB</asp:ListItem>
                            <asp:ListItem Value="3">MAR</asp:ListItem>
                            <asp:ListItem Value="4">APR</asp:ListItem>
                            <asp:ListItem Value="5">MAY</asp:ListItem>
                            <asp:ListItem Value="6">JUN</asp:ListItem>
                            <asp:ListItem Value="7">JUL</asp:ListItem>
                            <asp:ListItem Value="8">AUG</asp:ListItem>
                            <asp:ListItem Value="9">SEPT</asp:ListItem>
                            <asp:ListItem Value="10">OCT</asp:ListItem>
                            <asp:ListItem Value="11">NOV</asp:ListItem>
                            <asp:ListItem Value="12">DEC</asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:DropDownList ID="year" runat="server">
                            <asp:ListItem Value="-1">Year</asp:ListItem>
                            <asp:ListItem Value="2000">2000</asp:ListItem>
                            <asp:ListItem Value="2001">2001</asp:ListItem>
                            <asp:ListItem Value="2002">2002</asp:ListItem>
                            <asp:ListItem Value="2003">2003</asp:ListItem>
                            <asp:ListItem Value="2004">2004</asp:ListItem>
                            <asp:ListItem Value="2005">2005</asp:ListItem>
                            <asp:ListItem Value="2006">2006</asp:ListItem>
                            <asp:ListItem Value="2007">2007</asp:ListItem>
                            <asp:ListItem Value="2008">2008</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2013">2013</asp:ListItem>
                            <asp:ListItem Value="2014">2014</asp:ListItem>
                            <asp:ListItem Value="2015">2015</asp:ListItem>
                            <asp:ListItem Value="2016">2016</asp:ListItem>
                            <asp:ListItem Value="2017">2017</asp:ListItem>
                            <asp:ListItem Value="2018">2018</asp:ListItem>
                            <asp:ListItem Value="2019">2019</asp:ListItem>
                            <asp:ListItem Value="2020">2020</asp:ListItem>
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td bgcolor="beige" >
                            Clinic Name :</td>
                        <td >
                            <asp:DropDownList ID="clinic" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1"
                                DataTextField="Column1" DataValueField="cliniccode">
                                <asp:ListItem Value="-1">Select Clinic Name</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                                              
                    </tr>
                  <tr>
                  <td bgcolor="beige" >
                      Maintanance Cost :</td>
                  <td >
                      <asp:TextBox ID="mc" runat="server"></asp:TextBox></td>
                      <tr>
                          <td bgcolor="beige" >
                              Doctor Visit :</td>
                          <td >
                              <asp:TextBox ID="dv" runat="server"></asp:TextBox></td>
                      </tr>
                    <tr>
                        <td bgcolor="beige" >
                            Cost of Medicine :</td>
                        <td >
                            <asp:TextBox ID="com" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        
                        
                        <td colspan="2" align="right">
                            <asp:Button ID="save" runat="server" BackColor="LightSteelBlue" Text="Save" /></td>
                    </tr>
                  <tr>
                 </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select cliniccode+'--'+clinicname,cliniccode from clinicmaster order by cliniccode">
                </asp:SqlDataSource>
                
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>  
        </table>
</asp:Content>
