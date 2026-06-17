<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MMCPout.aspx.vb" Inherits="E_Management.MMCPout" 
     title="Maruwa Group of Companies -Customer Out"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label id="Label1" runat="server" ForeColor="#C00000" Font-Bold="True" Text="CUSTOMER PASSOUT - MARUWA MALAYSIA" Font-Underline="True"></asp:Label><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="0"
        DataSourceID="SqlDataSource1" ForeColor="#333333" ShowFooter="True" AllowPaging="True" BorderColor="Gray" BorderWidth="1px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="recno" HeaderText="recno" InsertVisible="False" ReadOnly="True"
                SortExpression="recno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="date1" HeaderText="Applied Date" SortExpression="date1" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False" />
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
            <asp:BoundField DataField="companypersonincharge" HeaderText="Companypersonincharge" SortExpression="companypersonincharge" />
            <asp:BoundField DataField="companyname" HeaderText="Companyname" SortExpression="companyname" />
            <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
            <asp:BoundField DataField="noofperson" HeaderText="No of person" SortExpression="noofperson" />
            <asp:BoundField DataField="arrivaldate" HeaderText="Arrivaldate" SortExpression="arrivaldate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
            <asp:BoundField DataField="atimeout" HeaderText="Atimeout" SortExpression="atimeout" dataformatstring="{0:t}"  HtmlEncode="False" />
            <asp:TemplateField HeaderText="Out">
                <FooterTemplate>
                    <asp:Button ID="Button1" OnClick="UpdategpApproval" runat="server" Text="Submit" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
        SelectCommand="select acc_customerapplication.recno,acc_customerapplication.empcode,empmaster.empname,acc_customerapplication.date1,acc_customerapplication.department,acc_customerapplication.companypersonincharge,acc_customerapplication.companyname,acc_customerapplication.visitortype,acc_customerapplication.noofperson,acc_customerapplication.arrivaldate,ltrim(rtrim(acc_customerapplication.status))as status,acc_customerapplication.atimeout from empmaster inner join acc_customerapplication on empmaster.empcode=acc_customerapplication.empcode where date1=@dt and status='in'" >
    <SelectParameters>
    <asp:Parameter Name="dt" DefaultValue="1/23/2012" />
    </SelectParameters>
        </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
        Text="CUSTOMER PASSOUT - MARUWA MELAKA" Visible="False"></asp:Label><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" ShowFooter="True" AllowPaging="True" BorderColor="Gray" BorderWidth="1px" Visible="False">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="recno" HeaderText="recno" InsertVisible="False" ReadOnly="True"
                SortExpression="recno" />
                <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                <asp:BoundField DataField="date1" HeaderText="Applied Date" SortExpression="date1" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False" />
                <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
                <asp:BoundField DataField="companypersonincharge" HeaderText="Companypersonincharge" SortExpression="companypersonincharge" />
                <asp:BoundField DataField="companyname" HeaderText="Companyname" SortExpression="companyname" />
                <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
                <asp:BoundField DataField="noofperson" HeaderText="No of person" SortExpression="noofperson" />
                <asp:BoundField DataField="arrivaldate" HeaderText="Arrivaldate" SortExpression="arrivaldate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
                <asp:BoundField DataField="atimeout" HeaderText="Atimeout" SortExpression="atimeout" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:TemplateField HeaderText="Out">
                    <FooterTemplate>
                        <asp:Button ID="Button1" OnClick="UpdategpApprovalmel" runat="server" Text="Submit" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
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
    <asp:SqlDataSource ID="mARUWAmELAKA" runat="server" ConnectionString="<%$ ConnectionStrings:MelakaHrmis %>"
        SelectCommand="select acc_customerapplication.recno,acc_customerapplication.empcode,empmaster.empname,acc_customerapplication.date1,acc_customerapplication.department,acc_customerapplication.companypersonincharge,acc_customerapplication.companyname,acc_customerapplication.visitortype,acc_customerapplication.noofperson,acc_customerapplication.arrivaldate,ltrim(rtrim(acc_customerapplication.status))as status,acc_customerapplication.atimeout from empmaster inner join acc_customerapplication on empmaster.empcode=acc_customerapplication.empcode where date1=@dt and status='in'">
        <SelectParameters>
            <asp:Parameter Name="dt" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
        Text="CUSTOMER PASSOUT - MARUWA LIGHTINGS" Visible="False"></asp:Label><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="0"
        DataSourceID="MaruwaLightings" ForeColor="#333333" ShowFooter="True" AllowPaging="True" BorderColor="Gray" BorderWidth="1px" Visible="False">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="recno" HeaderText="recno" InsertVisible="False" ReadOnly="True"
                SortExpression="recno" />
                <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                <asp:BoundField DataField="date1" HeaderText="Applied Date" SortExpression="date1" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False" />
                <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
                <asp:BoundField DataField="companypersonincharge" HeaderText="Companypersonincharge" SortExpression="companypersonincharge" />
                <asp:BoundField DataField="companyname" HeaderText="Companyname" SortExpression="companyname" />
                <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
                <asp:BoundField DataField="noofperson" HeaderText="No of person" SortExpression="noofperson" />
                <asp:BoundField DataField="arrivaldate" HeaderText="Arrivaldate" SortExpression="arrivaldate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
                <asp:BoundField DataField="atimeout" HeaderText="Atimeout" SortExpression="atimeout" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:TemplateField HeaderText="Out">
                    <FooterTemplate>
                        <asp:Button ID="Button1" OnClick="UpdategpApprovallit" runat="server" Text="Submit" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
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
    <asp:SqlDataSource ID="MaruwaLightings" runat="server" ConnectionString="<%$ ConnectionStrings:lightingshrmis %>"
        SelectCommand="select acc_customerapplication.recno,acc_customerapplication.empcode,empmaster.empname,acc_customerapplication.date1,acc_customerapplication.department,acc_customerapplication.companypersonincharge,acc_customerapplication.companyname,acc_customerapplication.visitortype,acc_customerapplication.noofperson,acc_customerapplication.arrivaldate,ltrim(rtrim(acc_customerapplication.status))as status,acc_customerapplication.atimeout from empmaster inner join acc_customerapplication on empmaster.empcode=acc_customerapplication.empcode where date1=@dt and status='in'">
        <SelectParameters>
            <asp:Parameter Name="dt" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
        Text="CUSTOMER PASSOUT - MARUWA OUTSOURCE"></asp:Label><asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="0"
        DataSourceID="MaruwaOutsource" ForeColor="#333333" ShowFooter="True" AllowPaging="True" BorderColor="Gray" BorderWidth="1px">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="recno" HeaderText="recno" InsertVisible="False" ReadOnly="True"
                SortExpression="recno" />
                <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                <asp:BoundField DataField="date1" HeaderText="Applied Date" SortExpression="date1" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False" />
                <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
                <asp:BoundField DataField="companypersonincharge" HeaderText="Companypersonincharge" SortExpression="companypersonincharge" />
                <asp:BoundField DataField="companyname" HeaderText="Companyname" SortExpression="companyname" />
                <asp:BoundField DataField="visitortype" HeaderText="Visitortype" SortExpression="visitortype" />
                <asp:BoundField DataField="noofperson" HeaderText="No of person" SortExpression="noofperson" />
                <asp:BoundField DataField="arrivaldate" HeaderText="Arrivaldate" SortExpression="arrivaldate" dataformatstring="{0:dd-MM-yyy}"  HtmlEncode="False"  />
                <asp:BoundField DataField="atimeout" HeaderText="Atimeout" SortExpression="atimeout" dataformatstring="{0:t}"  HtmlEncode="False" />
                <asp:TemplateField HeaderText="Out">
                    <FooterTemplate>
                        <asp:Button ID="Button1" OnClick="UpdategpApprovalout" runat="server" Text="Submit" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
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
    <asp:SqlDataSource ID="MaruwaOutsource" runat="server" ConnectionString="<%$ ConnectionStrings:OutsourceHRMIS %>"
        SelectCommand="select acc_customerapplication.recno,acc_customerapplication.empcode,empmaster.empname,acc_customerapplication.date1,acc_customerapplication.department,acc_customerapplication.companypersonincharge,acc_customerapplication.companyname,acc_customerapplication.visitortype,acc_customerapplication.noofperson,acc_customerapplication.arrivaldate,ltrim(rtrim(acc_customerapplication.status))as status,acc_customerapplication.atimeout from empmaster inner join acc_customerapplication on empmaster.empcode=acc_customerapplication.empcode where date1=@dt and status='in'">
        <SelectParameters>
            <asp:Parameter Name="dt" />
        </SelectParameters>
    </asp:SqlDataSource>
    </asp:Content>

