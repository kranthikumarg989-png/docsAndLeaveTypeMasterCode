<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="adminbtfareentry.aspx.vb" Inherits="E_Management.adminbtfareentry" 
    title="Admin Fare Entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table border="1">
        <tr>
            <td colspan="3">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#C00000"
                    Text="BT.Ref"></asp:Label>:<asp:Label ID="lblrno" runat="server" Font-Size="Small"
                        ForeColor="#C00000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblmsg" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 101px; background-color: beige">
                Description</td>
            <td style="width: 101px; background-color: beige">
                Taxi Fare Details</td>
            <td style="width: 101px; background-color: beige">
                Flight Fare Details</td>
        </tr>
        <tr>
            <td style="width: 101px; height: 21px; background-color: beige">
                Select Supplier</td>
            <td style="width: 101px; height: 21px">
                <asp:DropDownList ID="ddltaxi" runat="server" AppendDataBoundItems="True" DataSourceID="Sqltaxi"
                    DataTextField="suppliername" DataValueField="suppliername" Width="350px">
                    <asp:ListItem Selected="True" Value="-1">SELECT</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddltaxi"
                    ErrorMessage="!" InitialValue="-1" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 100px; height: 21px">
                <asp:DropDownList ID="DDLFLIGHT" runat="server" AppendDataBoundItems="True" DataSourceID="Sqltaxi"
                    DataTextField="suppliername" DataValueField="suppliername" Width="350px">
                    <asp:ListItem Selected="True" Value="-1">SELECT</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DDLFLIGHT"
                    ErrorMessage="!" InitialValue="-1" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 101px; height: 26px; background-color: beige">
                Invoice Number</td>
            <td style="width: 101px; height: 26px">
                <asp:TextBox ID="txttinvoice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttinvoice"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 26px">
                <asp:TextBox ID="txtfinvoice" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtfinvoice" ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 101px; height: 21px; background-color: beige">
                Amount(RM)</td>
            <td style="width: 101px; height: 21px">
                <asp:TextBox ID="txttamt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttamt"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txttamt"
                    ErrorMessage="Enter only Numbers" ValidationExpression="[0-9]*" ValidationGroup="a"></asp:RegularExpressionValidator></td>
            <td style="width: 100px; height: 21px">
                <asp:TextBox ID="txtfamt" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfamt" ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtfamt"
                    ErrorMessage="Enter only Numbers" ValidationExpression="[0-9]*" ValidationGroup="a"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 101px; height: 21px; background-color: beige">
                Destination</td>
            <td style="width: 101px; height: 21px">
                <asp:TextBox ID="txttdest" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttdest"
                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 21px">
                <asp:TextBox ID="txtfdest" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtfdest" ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="3" style="height: 21px">
                &nbsp;<asp:Button ID="btnsave" runat="server" SkinID="buttonskin1" Text="SAVE" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="height: 21px">
                <asp:GridView ID="GridView1" DataKeyNames=rno runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AutoGenerateDeleteButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="Rno" InsertVisible="False" SortExpression="rno">
                                                       <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True"
                                 ForeColor="Navy"
                                    Text='<%# Eval("rno") %>' OnCommand  ="mpop" 
                                     CommandArgument='<%# Eval("rno", "{0}") %>'>
                                    
                                    </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="dept" HeaderText="Dept" SortExpression="dept" ReadOnly="True" />
                        <asp:BoundField DataField="taxiprovider" HeaderText="T.provider" SortExpression="taxiprovider" />
                        <asp:BoundField DataField="tinvoice" HeaderText="T.Invoice" SortExpression="Taxi Invoice" />
                        <asp:BoundField DataField="tdetination" HeaderText="T.Detination" SortExpression="Taxi detination" />
                        <asp:BoundField DataField="fprovider" HeaderText="F.Provider" SortExpression="flight Provider" />
                        <asp:BoundField DataField="finvoice" HeaderText="F.Invoice" SortExpression="Flight invoice" />
                        <asp:BoundField DataField="fdestination" HeaderText="F.Destination" SortExpression="Flight Destination" />
                        <asp:BoundField DataField="tamount" HeaderText="T.Amount" SortExpression="Taxi amt" />
                        <asp:BoundField DataField="famount" HeaderText="F.Amount" SortExpression="Flight amt" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM [hrmis_bt_taxiflightentry] WHERE ([btnum] = @btnum)"
                     DeleteCommand="delete from [hrmis_bt_taxiflightentry] where rno = @rno">
                     <SelectParameters>
                        <asp:ControlParameter ControlID="lblrno" Name="btnum" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
              </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 21px">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                    NavigateUrl="~/HRMIS/Business Trip/AdminBt.aspx">Back To List</asp:HyperLink></td>
        </tr>
    </table>
    &nbsp;
    <asp:SqlDataSource ID="Sqltaxi" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT DISTINCT [suppliername] FROM [pur_suppliermaster] ORDER BY [suppliername]">
    </asp:SqlDataSource>
    <asp:Label ID="lbldate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbldept" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbltno" runat="server" Visible="False"></asp:Label>

</asp:Content>
