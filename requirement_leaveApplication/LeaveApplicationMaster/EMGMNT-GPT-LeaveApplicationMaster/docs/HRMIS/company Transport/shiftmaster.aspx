<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="shiftmaster.aspx.vb" Inherits="E_Management.shiftmaster" 
    %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 320px">
        <tr>
            <td class="td_head" colspan="2">
                SHIFT MASTER</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 17px">
                ShiftCode</td>
            <td style="width: 133px; height: 17px">
                <asp:TextBox ID="txtshiftcode" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtshiftcode"
                    ErrorMessage="Enter code" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Shift Start Time</td>
            <td style="width: 133px">
                <asp:DropDownList ID="ddlshr" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>:<asp:DropDownList ID="ddlsmin" runat="server">
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem Selected="True">00</asp:ListItem>
                </asp:DropDownList>:<asp:DropDownList ID="ddlsam" runat="server">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Shift End Time</td>
            <td style="width: 133px">
                <asp:DropDownList ID="ddlehr" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>:<asp:DropDownList ID="ddlemin" runat="server">
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem Selected="True">00</asp:ListItem>
                </asp:DropDownList>:<asp:DropDownList ID="ddleam" runat="server">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td align="right" style="width: 133px">
                <asp:Button ID="BTNADD" runat="server" Text="ADD" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="height: 20px">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlSHIFT" ForeColor="#333333" GridLines="None" PageSize="15" Width="100%" DataKeyNames="number" AllowPaging="True" AllowSorting="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="trans_shiftcode" HeaderText="Shiftcode" SortExpression="trans_shiftcode" />
                        <asp:BoundField DataField="trans_shifttime" HeaderText="Shifttime" SortExpression="trans_shifttime" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlSHIFT" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [trans_shiftcode], [trans_shifttime],number FROM [trans_shifttime] ORDER BY [number] desc"
                     DeleteCommand ="delete FROM [trans_shifttime] where number = @number"  >
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
