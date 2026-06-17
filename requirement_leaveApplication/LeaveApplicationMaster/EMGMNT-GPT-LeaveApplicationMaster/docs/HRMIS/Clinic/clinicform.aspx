<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewEMS.Master" CodeBehind="clinicform.aspx.vb" Inherits="E_Management.clinicform" 
    title="CLINIC PASS" %>
            <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table width="100%">
        <tr>
            <td class="bg-primary" style="text-align: center">
            <span style="font-size: 12pt">
                                                <br />
                                                CLINIC PASS APPLICATION<br />
                                            </span>
            </td>
            <td class="bg-primary" style="text-align: center">
                                            <span style="font-size: 11pt"> APPLICATION-STATUS</span></td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left; width: 483px;" align="left">
    <table>
        <tr>
             <td Colspan=2 class="bg-primary" style="text-align: center">
                                            </td>

        </tr>
        <tr>
            <td style="width: 222px" bgcolor="#b9d1ea">
                <asp:Label ID="Label5" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Text="Pass No" Width="175px"></asp:Label></td>
            <td style="width: 390px">
                <asp:Label ID="lblpass" runat="server" Font-Bold="True" Font-Size="11pt" CssClass="form-control" Width="200px" BackColor="ActiveCaption" ForeColor="Black" Height="25px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 222px; height: 112px;" bgcolor="#b9d1ea">
                <asp:Label ID="Label4" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Text="Symptoms" Width="175px"></asp:Label></td>
            <td style="width: 390px; height: 112px;">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtsymptoms" runat="server" Rows="4" TextMode="MultiLine" CssClass="form-control" Width="200px"></asp:TextBox></td>
                        <td style="width: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsymptoms"
                    ErrorMessage="!" CssClass="form-control" Width="30px">!</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td style="width: 222px; height: 75px;" bgcolor="#b9d1ea">
                <asp:Label ID="Label3" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Text="Time Out" Width="175px"></asp:Label></td>
            <td style="width: 390px; height: 75px;">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlohr" runat="server" CssClass="form-control" Width="75px" Height="30px">
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
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlomin" runat="server" CssClass="form-control" Width="75px" Height="30px">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddloam" runat="server" CssClass="form-control" Width="75px" Height="30px">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
                    </tr>
                </table>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlohr"
                    ErrorMessage="Select Time Out" InitialValue="-" CssClass="form-control" Height="10px" Width="30px">!</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlomin"
                    ErrorMessage="Select Time Out" InitialValue="-" CssClass="form-control" Height="10px" Width="30px">!</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 222px; height: 83px;" bgcolor="#b9d1ea">
                <asp:Label ID="Label2" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Text="Time In" Width="175px"></asp:Label></td>
            <td style="width: 390px; height: 83px;">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlihr" runat="server" CssClass="form-control" Width="75px" Height="30px">
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
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlimin" runat="server" CssClass="form-control" Width="75px" Height="30px">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddliam" runat="server" CssClass="form-control" Width="75px" Height="30px">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
                    </tr>
                </table>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlihr"
                    ErrorMessage="Select Time In" InitialValue="-" CssClass="form-control" Height="10px" Width="30px">!</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlimin"
                    ErrorMessage="Select Time In" InitialValue="-" Width="30px" CssClass="form-control" Height="10px">!</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lblmsg" runat="server" CssClass="form-control" Width="452px" Height="25px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                &nbsp;<asp:Button ID="SAVE" runat="server" SkinID="buttonskin1" Text="SAVE" CssClass="form-control" Width="100px" Height="40px" /></td>
        </tr>
    </table>
                <asp:Label ID="lblstat" runat="server" Visible="False" CssClass="form-control" Width="400px"></asp:Label></td>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="5"
                    DataSourceID="SqlDataSource1" ForeColor="#333333" AllowPaging="True" CssClass="form-control" CellSpacing="5" Font-Size="9pt">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
                              <asp:TemplateField HeaderText="Status" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("PASSno", "{0}") %>'
                                                Text='<%# Eval("status") %>'> </asp:Label>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("passno", "{0}") %>'
                                                ForeColor="#0000C0" OnCommand="getCLINICData" Text='<%# Eval("status") %>'></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" CommandArgument='<%# Eval("passno", "{0}") %>'
                                                ForeColor="RED" OnCommand="CLINICcancel" Text="CANCEL"></asp:LinkButton>
                                            <cc1:confirmbuttonextender id="confirmgpcancel" runat="server" confirmonformsubmit="true"
                                                confirmtext="Are you sure you want to cancel the clinicPass" targetcontrolid="LinkButton5">
                           </cc1:confirmbuttonextender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                        <asp:BoundField DataField="dateapplied" HeaderText="Applied On" SortExpression="dateapplied" DataFormatString="{0:dd-MMM-yy}"  HtmlEncode="False"  />
                        <asp:BoundField DataField="etimeout" HeaderText="Timeout" SortExpression="etimeout" DataFormatString="{0:t}"   HtmlEncode="False" />
                        <asp:BoundField DataField="etimein" HeaderText="Timein" SortExpression="etimein" DataFormatString="{0:t}"  HtmlEncode="False"  />
                        <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [passno], [status], [dateapplied], [etimeout], [etimein], [sickness] FROM [clinicstaffgatepass] WHERE ([empcode] = @empcode) and dateapplied >= @from and dateapplied <= @to order by passno desc">
        <SelectParameters>
                   <asp:Parameter Name="empcode" DefaultValue="" />
                   <asp:Parameter  Name="from" DefaultValue="" />
                   <asp:Parameter  Name="to" DefaultValue="" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />


</asp:Content>
