<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Vehiclepass_Print.aspx.vb" Inherits="E_Management.Vehiclepass_Print" 
    title="Untitled Page" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

  <div>
   <table style="width: 800px">
        <tr>
            <td colspan="4" style="height: 122px; width: 649px;"><table style="border-right: steelblue 1px solid; border-top: steelblue 1px solid;
                    border-left: steelblue 1px solid; width: 800px; border-bottom: steelblue 1px solid">
                <tr>
                    <td class="td_head" colspan="5" style="text-align: center; height: 21px;" bgcolor="#33cccc">
                        <strong>Vehicle Pass</strong></td>
                </tr>
            </table>
            </td>
            </tr>
            </table>
            <table>
            <tr>
            <td>
            <label id="msg" runat ="Server" visible="false" style="color:red" > No Records to display</label>
            </td>
            </tr>
            
            </table>
            
             <table style="width: 800px">
    <tr>
    <td>
      <asp:GridView ID="GView1" runat="server"  style="width: 800px" OnRowCommand="Gview1_RowCommand"   Font-Size="Small"   AutoGenerateColumns="false">
                    <Columns>
                      
                        <asp:BoundField DataField="Empcode" HeaderText="Empcode" />
                        <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                         <asp:BoundField DataField="Carno" HeaderText="Vehicleno" />
                         
                       
                       
                        
                        <asp:TemplateField HeaderText="print">
<ItemTemplate>
<asp:LinkButton ID="lbltest" runat="server"  Font-Bold="true" ForeColor="blue" OnClick="lnkView_Click"
Text='<%#Bind("Task") %>'>  ></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>                                                            
        
                      
                    </Columns>
                   
                </asp:GridView>
    </td>
    </tr>
    </table>
                
    </div>
    </asp:Content>
