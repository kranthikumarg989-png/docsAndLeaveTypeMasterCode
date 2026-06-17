<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Training Provider Master.aspx.vb" Inherits="E_Management.Training_Provider_Master" 
    title="Training Provider Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table id="TABLE2">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 1123px">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="TRAINING PROVIDER MASTER - EXTERNAL"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 1123px; height: 227px; text-align: left;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1"><tr>
                    <td style="background-color: beige; height: 26px; width: 91px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Provider Code" Width="105px"></asp:Label></td>
                    <td style="height: 26px;" valign="top" align="left">
                        &nbsp;<asp:Label ID="lblcode" runat="server" Width="54px"></asp:Label></td>
                    <td style="background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label14" runat="server" Text="Company Name" Width="113px"></asp:Label></td>
                    <td style="height: 26px;" valign="top" align="left">
                        <asp:TextBox ID="name" runat="server" Width="175px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="name"
                                    ErrorMessage="Name !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                </tr>
                    <tr>
                        <td style="width: 91px; background-color: beige; height: 11px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Company Reg. No." Width="141px"></asp:Label></td>
                        <td style="width: 253px; height: 11px;" valign="top" align="left">
                            <asp:TextBox ID="registrationno" runat="server" Width="174px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="registrationno"
                                    ErrorMessage="Reg. No. !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td align="left" style="width: 6px; background-color: beige; height: 11px;" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Company Address" Width="122px"></asp:Label></td>
                    <td align="left" style="width: 271px; height: 11px;" valign="top">
                        <asp:TextBox ID="address" runat="server" Height="29px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="address"
                                    ErrorMessage="Address !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 91px; background-color: beige; height: 36px;" valign="top" align="left">
                            <asp:Label ID="Label4" runat="server" Text="Available Courses" Width="122px"></asp:Label></td>
                        <td style="width: 253px; height: 36px;" valign="middle" align="left">
                            <asp:TextBox ID="courses" runat="server" Height="52px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="courses"
                                    ErrorMessage="Courses !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    <td style="width: 6px; background-color: beige; height: 36px;" valign="top" align="left">
                        <asp:Label ID="Label16" runat="server" Text="Other Details" Width="126px"></asp:Label></td>
                    <td style="width: 271px; height: 36px;" valign="middle" align="left">
                        <asp:TextBox ID="others" runat="server" Height="52px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 91px; background-color: beige; height: 54px;" valign="top" align="left">
                            <asp:Label ID="Label5" runat="server" Text="Trainers List (Seperated by comma)" Width="139px"></asp:Label></td>
                        <td style="width: 253px; height: 54px;" valign="middle" align="left">
                            <asp:TextBox ID="trainers" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="trainers"
                                    ErrorMessage="List !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td style="width: 6px; background-color: beige; height: 54px;" valign="top" align="left">
                        <asp:Label ID="Label17" runat="server" Text="Contact Number" Width="117px"></asp:Label></td>
                    <td style="width: 271px; height: 54px;" valign="middle" align="left">
                        <asp:TextBox ID="contactno" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="contactno"
                            ErrorMessage="Contact No. !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 49px; text-align: center;" valign="middle">
                            <br />
                            <asp:Button ID="SAVEPM" runat="server" Text="SAVE" /><br />
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="4" DataKeyNames="code"
                                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="802px">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code" SortExpression="code">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("code") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reg. No." SortExpression="registrationno">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("registrationno") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox1"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# bind("registrationno") %>' Width="99px"></asp:TextBox>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" SortExpression="name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# bind("name") %>' Width="93px"></asp:TextBox>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" SortExpression="address">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("address") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox3"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# bind("address") %>' TextMode="MultiLine" Width="125px"></asp:TextBox>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Courses" SortExpression="courses">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("courses") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TextBox4"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# bind("courses") %>' TextMode="MultiLine" Width="125px"></asp:TextBox>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Others" SortExpression="others">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("others") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="TextBox5"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# bind("others") %>' TextMode="MultiLine" Width="125px"></asp:TextBox>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trainers" SortExpression="trainers">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("trainers") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="TextBox6"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox13" runat="server" Text='<%# bind("trainers") %>' TextMode="MultiLine" Width="127px"></asp:TextBox>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No." SortExpression="contactno">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("contactno") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="TextBox7"
                                                ErrorMessage="*" EnableClientScript="true"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox14" runat="server" Text='<%# bind("contactno") %>' TextMode="MultiLine" Width="117px"></asp:TextBox>
                                            
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
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT DISTINCT [code], [registrationno], [name], [address], [courses], [others], [trainers], [contactno] FROM [td_ProvidedMaster] ORDER BY [code], [name], [registrationno]"
                                DeleteCommand = "delete from [td_ProvidedMaster] where code = @code"
                                UpdateCommand = "update td_ProvidedMaster set registrationno=@registrationno,name=@name,address=@address,courses=@courses,others=@others,trainers=@trainers,contactno=@contactno where code=@code">
                    <UpdateParameters>
                       <asp:Parameter Name="registrationno" Type="String" />
                       <asp:Parameter Name="name" Type="String" />
                       <asp:Parameter Name="address" Type="String" />
                       <asp:Parameter Name="courses" Type="String" />
                       <asp:Parameter Name="others" Type="String" />
                       <asp:Parameter Name="trainers" Type="String" />
                       <asp:Parameter Name="contactno" Type="String" />
                          
                    </UpdateParameters> 
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                &nbsp;<asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
                &nbsp; &nbsp;
                &nbsp;&nbsp;<br />
                &nbsp; &nbsp;
                </td>
        </tr>
    </table>
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>
