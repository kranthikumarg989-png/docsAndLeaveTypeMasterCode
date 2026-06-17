<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TCFmdEdit.aspx.vb" Inherits="E_Management.TCFmdEdit" 
    title="Travelling Claim Edit amount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
 <table>
     <tr>
                        <td style="background-color: beige; ; width: 165px; height: 19px;">
                            <asp:Label ID="Label1" runat="server" Text="Empcode"></asp:Label></td>
                        <td style="height: 19px">
                            :<asp:Label ID="lblemp" runat="server"></asp:Label>-<asp:Label ID="lblname" runat="server"></asp:Label></td>
                       
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px; height: 9px;">
                            Dept-Sect</td>
                        <td style="height: 9px;">
                            :<asp:Label ID="lblds" runat="server"></asp:Label></td>
                      
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px; height: 15px;">
                            Share Dept(s).</td>
                           <td style="height: 15px;">
                            :<asp:Label ID="tcdept" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px; height: 14px;">
                            Colleague Name(s)</td>
                          <td style="height: 14px;">
                            :<asp:Label ID="tcname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px; height: 11px;" >
                            Destination</td>
                        <td style="height: 11px">
                            :<asp:Label ID="TCDEST" runat="server"></asp:Label></td>
                                           </tr>
     
     
     
     
        <tr>
            <td align="left" style="background-color: #eee9d5; height: 21px;">
                DEPARTURE &nbsp;@
                <asp:Label ID="lbldepart" runat="server" Text="Label"></asp:Label></td>
            <td align="left" style="background-color: beige; height: 21px;">
                ARRIVAL @
                <asp:Label ID="lblarrive" runat="server" Text="Label"></asp:Label></td>
        </tr>
     <tr>
         <td align="center" colspan="2" style="height: 21px; background-color: #eee9d5">
             Traveling allowance<asp:DropDownList ID="DDLALLOWANCE" runat="server" AppendDataBoundItems="True"
                 DataSourceID="SqLCURRECNY" DataTextField="CurrencyCode" DataValueField="CurrencyCode">
                 <asp:ListItem Selected="True" Value="-1">-SELECT-</asp:ListItem>
             </asp:DropDownList><asp:TextBox ID="txttravel" runat="server" Width="62px" AutoPostBack="True"></asp:TextBox>
             EXR:
             <asp:TextBox ID="txtea" runat="server" AutoPostBack="True" ToolTip="keyin Ex.Rate of Selected currency"
                 Width="62px"></asp:TextBox>
             <asp:Label ID="lblTA" runat="server" ForeColor="Maroon"></asp:Label>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttravel"
                 ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" Width="18px"></asp:RegularExpressionValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtea"
                 ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                 Width="18px"></asp:RegularExpressionValidator></td>
     </tr>
        <tr>
            <td colspan="2" style="height: 21px" >
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
     <tr>
         <td >
             Remarks</td>
         <td>
             <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" Width="146px"></asp:TextBox><asp:Button
                 ID="Button1" runat="server" Text="Calculate" /></td>
     </tr>
     <tr>
         <td>
         </td>
         <td align="right">
             <asp:Button ID="btnsave" runat="server" SkinID="buttonskin1" Text="SAVE" /></td>
     </tr>
     
        <tr>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="lblcol" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label ID="lbltc" runat="server" Visible="False"></asp:Label><asp:Label ID="lblclaim" runat="server" Visible="False"></asp:Label><asp:Label ID="lblpay" runat="server" Visible="False"></asp:Label><asp:Label ID="lbltot" runat="server" Visible="False"></asp:Label></td>
        </tr>
    </table>
    <asp:Label ID="lblexp" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblrefund" runat="server" Visible="False"></asp:Label>
    <asp:SqlDataSource ID="SqLCURRECNY" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT DISTINCT [CurrencyCode] FROM [Pur_currencymaster] ORDER BY [CurrencyCode]">
    </asp:SqlDataSource>
</asp:Content>
