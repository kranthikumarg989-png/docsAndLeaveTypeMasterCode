<%@ Page Language="vb" AutoEventWireup="false" Theme="buttonems"  MasterPageFile="~/ems.Master" CodeBehind="BtForm2.aspx.vb" Inherits="E_Management.BtForm2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Label ID="lblmsg" runat="server" Font-Size="Large" ForeColor="DimGray">Please Fill in customer Visit Details</asp:Label><br />

    <asp:GridView ID="GridView1" ShowFooter=True   runat="server" AllowSorting="True" AutoGenerateColumns="False"
        DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333">
        <Columns>
        
            <asp:BoundField DataField="rno" HeaderText="Rno" SortExpression="rno"  />
            <asp:BoundField DataField="custname" HeaderText="Customer" SortExpression="custname" />
            <asp:TemplateField HeaderText="Appointment From ~ To" SortExpression="vfromdate" >
                <ItemTemplate>
                    <asp:TextBox ID="txtfrom" runat="server"  Text='<%# Bind("vfromdate", "{0:dd/MM/yy}") %>' HtmlEncode="false" Width="58px"></asp:TextBox >
                          <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
Mask="99/99/99" MaskType="Date" TargetControlID="txtfrom" 
CultureName="en-GB" AcceptNegative=None  > </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="ccef"  runat="server"
                      TargetControlID="txtfrom" Format = "dd/MM/yy"           
    CssClass="cal_Theme1"  
    PopupButtonID="txtfrom" />
                    ~
                    <asp:TextBox ID="txtto" runat="server" Text='<%# Eval("vtodate", "{0:dd/MM/yy}") %>' HtmlEncode="false" Width="57px"></asp:TextBox> 
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
Mask="99/99/99" MaskType="Date" TargetControlID="txtto" 
CultureName="en-GB" AcceptNegative=None  > </cc1:MaskedEditExtender>
                          <cc1:CalendarExtender ID="CalendarExtender1"  runat="server"
                      TargetControlID="txtto" Format = "dd/MM/yy"           
    CssClass="cal_Theme1"  
    PopupButtonID="txtto" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" />
            <asp:TemplateField HeaderText="Purpose" SortExpression="purpose">
                  <ItemTemplate>
                    <asp:TextBox ID="txtpurpose" runat="server" Text='<%# Bind("purpose") %>' TextMode="MultiLine" Height="37px" Width="141px"></asp:TextBox>
                 </ItemTemplate>
                          </asp:TemplateField>
            <asp:TemplateField HeaderText="Accomadation" SortExpression="Accomadation">
                 <ItemTemplate>
                    <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="vertical" 
                        SelectedValue='<%# Bind("Accomadation") %>'>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
             </asp:TemplateField>       
            
            <asp:TemplateField HeaderText="Checkin@" SortExpression="chkinhr">
                <ItemTemplate>
                 <asp:TextBox ID="txtstayfrom"  runat="server" Text='<%# Bind("Stayfrom", "{0:dd/MM/yy}") %>' HtmlEncode="false" Width="54px"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="Me1" runat="server" 
                    Mask="99/99/99" MaskType="Date" TargetControlID="txtstayfrom" 
                    CultureName="en-GB" AcceptNegative=None >
 </cc1:MaskedEditExtender>
                    <br />
                    <cc1:CalendarExtender ID="ccelf"  runat="server"
    TargetControlID="txtstayfrom" Format = "dd/MM/yy"           
    CssClass="cal_Theme1"  
    PopupButtonID="txtstayfrom" />
                    <asp:DropDownList ID="ddlchkinhr" runat="server" SelectedValue='<%# Bind("chkinhr") %>'>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlchkinmin" runat="server" SelectedValue='<%# Bind("chkinmin") %>'>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlchkinam" runat="server" SelectedValue='<%# Bind("chkinam") %>'>
                        <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>PM</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                       </asp:TemplateField>
                   
           <asp:TemplateField HeaderText="checkout@" SortExpression="cohr">
                <ItemTemplate>
                 <asp:TextBox ID="txtstaytill" runat="server" Text='<%# Bind("staytill", "{0:dd/MM/yy}") %>' HtmlEncode="false" Width="58px"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" 
Mask="99/99/99" MaskType="Date" TargetControlID="txtstaytill" 
CultureName="en-GB" AcceptNegative=None  > </cc1:MaskedEditExtender>
<br />
                     <cc1:CalendarExtender ID="Ce2"  runat="server"
    TargetControlID="txtstaytill" Format = "dd/MM/yy"           
     CssClass="cal_Theme1"  
    PopupButtonID="txtstaytill" />
                    <asp:DropDownList ID="ddlchkohr" runat="server"  selectedvalue='<%# Bind("cohr") %>'>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlchkomin" runat="server"  SelectedValue='<%# Bind("comin") %>'>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlchkoam" runat="server" SelectedValue='<%# Bind("coam") %>'>
                        <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>PM</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <FooterTemplate>
                 <asp:Button ID="Button1" SkinID ="buttonskin1"  runat="server" Text="FINISH" OnClick ="UpdateCustVisit"  />
                </FooterTemplate> 
             </asp:TemplateField>
         </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle  BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT rno,[custname], [vfromdate], [vtodate], [destination], stayfrom,staytill,[Accomadation], [purpose], [chkinhr], [chkinmin], [chkinam], [cohr], [comin], [coam]  FROM [HRMIS_BT_CUSTOMERVISITDETAILS] WHERE ([btnum] = @btnum)">
        <SelectParameters>
            <asp:SessionParameter Name="btnum" SessionField="btnum" Type="Int32"  />
        </SelectParameters>
    </asp:SqlDataSource>


</asp:Content>
