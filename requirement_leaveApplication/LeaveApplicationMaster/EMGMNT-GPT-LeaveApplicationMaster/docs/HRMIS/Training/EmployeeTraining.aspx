<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="EmployeeTraining.aspx.vb" Inherits="E_Management.EmployeeTraining" 
    title="Employee Training Details" %>
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
        <td align="center" colspan="1" valign="top" style="width: 929px; height: 21px;">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="EMPLOYEE TRAINING DETAILS"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 929px; height: 227px; text-align: center;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1"><tr>
                    <td style="width: 99px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Employee No."></asp:Label></td>
                    <td style="width: 341px; height: 26px;" valign="top" align="left">
                        <asp:TextBox ID="empcode" runat="server" Width="173px" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode"
                            ErrorMessage="Code !" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    <td style="width: 125px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label14" runat="server" Text="Employee Name" Width="113px"></asp:Label></td>
                    <td style="width: 382px; height: 26px;" valign="top" align="left">
                        &nbsp;<asp:Label ID="Label11" runat="server" Width="170px"></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 99px; background-color: beige; height: 11px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Department" Width="141px"></asp:Label></td>
                        <td style="width: 341px; height: 11px;" valign="top" align="left">
                            &nbsp;<asp:Label ID="Label13" runat="server" Width="175px"></asp:Label>
                        </td>
                    <td align="left" style="width: 125px; background-color: beige; height: 11px;" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Section" Width="122px"></asp:Label></td>
                    <td align="left" style="width: 382px; height: 11px;" valign="top">
                        &nbsp;<asp:Label ID="Label10" runat="server" Width="172px"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                        <td style="width: 99px; background-color: beige; height: 25px;" valign="top" align="left">
                            <asp:Label ID="Label4" runat="server" Text="Date of Join"></asp:Label></td>
                        <td style="width: 341px; height: 25px;" valign="middle" align="left">
                            &nbsp;<asp:Label ID="Label18" runat="server" Width="176px"></asp:Label>&nbsp;
                        </td>
                    <td style="width: 125px; background-color: beige; height: 25px;" valign="top" align="left">
                        <asp:Label ID="Label16" runat="server" Text="Training Attended"></asp:Label></td>
                    <td style="width: 382px; height: 25px;" valign="middle" align="left">
                        <asp:DropDownList ID="td_trainingattended" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="td_title" DataValueField="td_title" AppendDataBoundItems="True" Width="176px" CausesValidation="True" AutoPostBack="True">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="td_trainingattended"
                                    ErrorMessage="Training Attended !" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 99px; background-color: beige; height: 54px;" valign="top" align="left">
                            <asp:Label ID="Label5" runat="server" Text="Training Programme" Width="130px"></asp:Label></td>
                        <td style="width: 341px; height: 54px;" valign="top" align="left">
                            &nbsp;
                            &nbsp;&nbsp;<asp:Label ID="LblProgramme" runat="server"></asp:Label></td>
                    <td style="width: 125px; background-color: beige; height: 54px;" valign="top" align="left">
                        <asp:Label ID="Label19" runat="server" Text="Method" Width="130px"></asp:Label></td>
                    <td valign="top" align="left">
                        &nbsp;<asp:Label ID="LblMethod" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 99px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label12" runat="server" Text="Type" Width="130px"></asp:Label></td>
                        <td align="left" style="width: 341px; height: 26px" valign="top">
                            &nbsp;<asp:Label ID="LblType1" runat="server"></asp:Label></td>
                        <td align="left" style="width: 125px; height: 26px; background-color: beige" valign="top">
                        <asp:Label ID="Label17" runat="server" Text="Remarks" Width="117px"></asp:Label></td>
                        <td align="left" style="width: 382px; height: 26px" valign="top">
                        <asp:TextBox ID="td_remarks" runat="server" Height="50px" TextMode="MultiLine" Width="169px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 99px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label20" runat="server" Text="Trainer Name" Width="130px"></asp:Label></td>
                        <td align="left" style="width: 341px; height: 26px" valign="top">
                            <asp:DropDownList ID="CmbTrainer" runat="server" Width="300px">
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT [empcode], [empname] FROM [empmaster] WHERE ([resigned] = ?) ORDER BY [empname]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="n" Name="resigned" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT code AS empcode, name AS empname FROM td_ProvidedMaster">
                            </asp:SqlDataSource>
                        </td>
                        <td align="left" style="width: 125px; height: 26px; background-color: beige" valign="top">
                        </td>
                        <td align="left" style="width: 382px; height: 26px" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="Label6" runat="server" Text="Total Hours"></asp:Label></td>
                        <td style="width: 341px; height: 26px;" valign="top" align="left">
                            <asp:TextBox ID="td_hrs" runat="server" Width="174px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="td_hrs"
                                ErrorMessage="Hrs !" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                ControlToValidate="td_hrs" ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"></asp:RegularExpressionValidator></td>
                    <td style="width: 125px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label7" runat="server" Text="Mark Scored (%)" Width="113px"></asp:Label></td>
                    <td style="width: 382px; height: 26px;" valign="top" align="left">
                        <asp:TextBox ID="td_markscored" runat="server" Width="173px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="td_markscored"
                                    ErrorMessage="Marks !" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="td_markscored"
                            ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 99px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="Label8" runat="server" Text="Date Attended"></asp:Label></td>
                        <td style="width: 341px; height: 26px;" valign="top" align="left">
                            <asp:TextBox ID="td_dateattended" runat="server" Width="174px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="td_dateattended"
                                ErrorMessage="Date !" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator>
                            <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="td_dateattended" targetcontrolid="td_dateattended"></cc1:calendarextender>
                            </td>
                        <td style="width: 125px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="Label9" runat="server" Text="Attach Certificate" Width="113px"></asp:Label></td>
                        <td style="width: 382px; height: 26px;" valign="top" align="left">
                            <asp:FileUpload ID="trainingattachment" runat="server" Width="263px" />
                            <asp:Button ID="uploadcerti" runat="server" Text="Upload" /><br />
                            <asp:Label ID="labelfile" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <br />
                            <asp:Button ID="SAVEET" runat="server" Text="SAVE" ValidationGroup="b" />
                <asp:Button ID="Button1" runat="server" Text="View" /><br />
                <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
                &nbsp; &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;<br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333"
                    GridLines="None" Width="929px" DataKeyNames="empcode" HorizontalAlign="Center" AutoGenerateEditButton="True" Visible="False">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Empcode" SortExpression="empcode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("empcode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <itemtemplate>
</itemtemplate>
                           <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="True" ForeColor="Blue"
                        OnCommand="Edit_ET" Text='<%# Bind("empcode") %>' CommandArgument ='<%# Eval("empcode", "{0}") %>' ></asp:LinkButton>
           
                </ItemTemplate>
                </asp:TemplateField>
                        <asp:BoundField DataField="td_trainingattended" HeaderText="TrainingAttended" SortExpression="td_trainingattended" />
                        <asp:BoundField DataField="td_programme" HeaderText="Programme" SortExpression="td_programme" />
                        <asp:BoundField DataField="td_remarks" HeaderText="Remarks" SortExpression="td_remarks" />
                        <asp:BoundField DataField="td_markscored" HeaderText="MarkScored" SortExpression="td_markscored" />
                        <asp:BoundField DataField="td_dateattended" HeaderText="DateAttended" SortExpression="td_dateattended" />
                        <asp:BoundField DataField="td_hours" HeaderText="Hours" SortExpression="td_hours" />
                        <asp:BoundField DataField="trainingattachment" HeaderText="Attachment" SortExpression="trainingattachment" />
                        <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method" />
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                        <asp:BoundField DataField="TrainerCode" HeaderText="TrainerCode" SortExpression="TrainerCode" />
                        <asp:BoundField DataField="TrainerCode" HeaderText="TrainerCode" SortExpression="TrainerCode" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                    SelectCommand="SELECT DISTINCT empcode, td_trainingattended, td_programme, td_remarks, td_markscored, td_dateattended, td_hours, trainingattachment, SectionCode, Method, Type, TrainerCode, TrainerName FROM td_employeetraining ORDER BY empcode, td_trainingattended, td_dateattended"
                    DeleteCommand = "delete DISTINCT from [td_employeetraining] WHERE [empcode] = @empcode AND [td_trainingattended]=@td_trainingattended AND [td_hours]=@td_hrs"
                    UpdateCommand = "update td_employeetraining set description=@description where categorycode=@categorycode" ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>">
                    <UpdateParameters>
                       <asp:Parameter Name="categorycode" Type="String" />
                        <asp:Parameter Name="description" Type="String" />       
                    </UpdateParameters>  
                    <DeleteParameters>
                       <asp:Parameter Name="empcode" Type="String" />
                        <asp:Parameter Name="td_trainingattended" Type="String" /> 
                         <asp:Parameter Name="td_hrs" Type="String" />      
                    </DeleteParameters>    
                </asp:SqlDataSource>
                &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;
                &nbsp;
                &nbsp;&nbsp;
                </td>
        </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_programme] FROM [td_traininglist]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                    SelectCommand="SELECT DISTINCT [td_title] FROM [td_traininglist] ORDER BY [td_title]" ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>">
                </asp:SqlDataSource>
    
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
