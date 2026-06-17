<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CMG_LetterEdit.aspx.vb" Inherits="E_Management.CMG_LetterEdit" 
    title="Untitled Page" StylesheetTheme="buttonems" %>
          
<%@ Register Assembly="Winthusiasm.HtmlEditor" Namespace="Winthusiasm.HtmlEditor"
    TagPrefix="ccC1" %>  

    
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table style="width: 842px">
           
            <tr>
                <td colspan="3" style="height: 24px" >
                   
                    <asp:Label ID="Label1" runat="server"  Text=" Select Letter Name" Width="126px"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource1" DataTextField="lettername" DataValueField="lettername"
                      AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
      <tr>
          <td colspan="3">
                    
                    <asp:Label ID="Label2" runat="server" Text="Revision No :" Width="89px"></asp:Label>
              &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" ></asp:Label></td>
      </tr>
            <tr>
                <td colspan="3" style="height: 155px">
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ccC1:HtmlEditor ID="HtmlEditor1" runat="server" Width="840px" />
                                                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 22px">
                    &nbsp;</td>
                <td align="right" style="height: 22px" >
                    <asp:Button ID="btnUpdate" runat="server"  Text="Update" SkinID="buttonskin1" />
                </td>
            </tr>
        </table>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" SelectCommand="SELECT DISTINCT [lettername] FROM [HRMIS_CMG_MASTER_LETTER] ORDER BY [lettername]"></asp:SqlDataSource>
    
    
</asp:Content>
