<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BTFMDEnteramt.aspx.vb" Inherits="E_Management.BTFMDEnteramt" 
    title="FMD Edit Amount" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server" >
<div align = center>
    <br />
    <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="#C000C0"></asp:Label>
    <hr width="75%" color ="silver"  />

    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333"  >
         <ItemTemplate>
           <table style="font-size:medium ">
        <tr>
            <td >
           <b>Advance Amount Requested: </b> </td>
            <td >
            <asp:Label ID="advance_amountLabel" runat="server" Text='<%# Bind("advance_amount") %>' ForeColor="Maroon"></asp:Label><br /> </td>
        </tr>
        <tr>
            <td align=left> <b> Total Advance Requested(RM) :</b> 
            </td>
            <td  align=left> <asp:Label ID="totaladvanceLabel" runat="server" Text='<%# Bind("totaladvance") %>' ForeColor="Maroon"></asp:Label><br />
            </td>
        </tr>
     </table>                                           
        </ItemTemplate>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

    </asp:FormView>
    <br />
          <asp:Label ID="Label2" runat="server" Text ='<%# Bind("recno") %>' ></asp:Label><br />
 
    <table border="1" cellpadding="1" cellspacing="1" style="width: 461px" >
        <tr>
            <td style="width: 176px; background-color: beige;" align="left">
                Select currency</td>
            <td style="width: 100px" align="left">
                <asp:DropDownList ID="ddlcurrency" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="Sqlcurrency" DataTextField="CurrencyCode" DataValueField="CurrencyCode">
                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td style="width: 176px; background-color: beige;" align="left">
                Enter Amount</td>
            <td style="width: 100px" align="left">
                <asp:TextBox ID="txtamt" runat="server" Width="79px">0</asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtamt"
                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" Width="104px"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 176px; background-color: beige; height: 47px;" align="left">
                Exchange Rate</td>
            <td style="width: 100px; height: 47px;" align="left">
                <asp:TextBox ID="txter" runat="server" Width="77px"></asp:TextBox>&nbsp;
                <asp:Button ID="btncalculate" runat="server" Text="CALCULATE" SkinID="buttonskin1" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txter"
                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" Width="104px"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 176px; background-color: beige;" align="left">
                Approved Amount</td>
            <td style="width: 100px" align="left">
                <asp:ListBox ID="lstdetails" runat="server" Width="180px"></asp:ListBox><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/del.jpg" Width="19px" /></td>
        </tr>
        <tr>
            <td style="width: 176px; background-color: beige;" align="left">
                Total RM
            </td>
            <td style="width: 100px" align="left">
                <asp:Label ID="lbltotamt" runat="server" Font-Bold="True" ForeColor="DarkGreen">0</asp:Label>
                <asp:Label ID="lblusdmsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblcurusd" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 176px; height: 24px;" align="center">
                </td>
            <td style="width: 100px; height: 24px;" align="center">
                <asp:Button ID="btnsave" runat="server" Text="SAVE" SkinID="buttonskin1" /></td>
        </tr>
    </table>
    <br />
    <hr width="75%" color ="silver"  />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
        NavigateUrl="~/HRMIS/Business Trip/BTFMDView.aspx">Back To List</asp:HyperLink><br />
    <br />
    <br />
</div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [advance_amount], [totaladvance] FROM [acc_businesstrip] WHERE ([recno] = @recno)">
        <SelectParameters>
            <asp:QueryStringParameter Name="recno" QueryStringField="rno" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlcurrency" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT DISTINCT [CurrencyCode] FROM [Pur_currencymaster] ORDER BY [CurrencyCode]">
    </asp:SqlDataSource>
</asp:Content>
