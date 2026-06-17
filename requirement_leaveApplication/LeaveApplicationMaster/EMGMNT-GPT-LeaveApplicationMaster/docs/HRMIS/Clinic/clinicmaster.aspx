<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="clinicmaster.aspx.vb" Inherits="E_Management.clinicmaster" 
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
                            CLINIC MASTER</td>                      
                    </tr>
                    <tr>
                    <td bgcolor="beige">
                            Clinic Name :</td>
                    <td >
                        <asp:TextBox ID="cn" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td bgcolor="beige" >
                              Doctor Name :</td>
                        <td >
                            <asp:TextBox ID="dn" runat="server"></asp:TextBox></td>
                                              
                    </tr>
                  <tr>
                  <td bgcolor="beige" >
                      Address :</td>
                  <td >
                      <asp:TextBox ID="ad" runat="server" Height="60px" TextMode="MultiLine" Width="147px"></asp:TextBox></td>
                      <tr>
                          <td bgcolor="beige" >
                              Phone No :</td>
                          <td >
                              <asp:TextBox ID="pon" runat="server"></asp:TextBox></td>
                      </tr>
                    <tr>
                       <td colspan="2" align="right">
                            <asp:Button ID="save" runat="server" BackColor="LightSteelBlue" Text="Save" /></td>
                    </tr>
                  <tr>
                 </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" style="left: 280px; position: relative; top: -194px" BorderColor="Gray" BorderWidth="1px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="cliniccode" HeaderText="Cliniccode" SortExpression="cliniccode" />
                        <asp:BoundField DataField="clinicname" HeaderText="Clinicname" SortExpression="clinicname" />
                        <asp:BoundField DataField="doctorname" HeaderText="Doctorname" SortExpression="doctorname" />
                        <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                        <asp:BoundField DataField="phoneno" HeaderText="Phoneno" SortExpression="phoneno" />
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk1"  runat="server" CausesValidation="false" CommandArgument='<%# Eval("cliniccode", "{0}") %>' OnCommand="edi"
                                    Font-Underline="True" Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="lnk2" runat="server" Font-Underline="True" CommandArgument='<%# Eval("cliniccode", "{0}") %>' OnCommand="del">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                                           </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                &nbsp; &nbsp;
                
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
