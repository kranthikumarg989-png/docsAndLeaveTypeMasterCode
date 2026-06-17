<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" Theme="buttonems"  CodeBehind="Designationmaster.aspx.vb" Inherits="E_Management.Designationmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID=CPHApplication runat=server >
<asp:Panel ID = "pnldesignation" runat=server >
                <table cellpadding=0 cellspacing=0>
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 740px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 24px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff">
                        <TABLE >
                        <TBODY>
                          <TR><TD style="HEIGHT: 17px; " align=center colSpan=4 class="td_head">
                          <B>Enter Designation Details </B></TD></TR>
                            <tr>
                                <td align="center" colspan="4" style="height: 11px; text-align: left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="tvalidation" Height="32px" />
                                </td>
                            </tr>
                          <TR>
                          <TD style="width: 150px;" >Designation Name</TD>
                          <TD colSpan=1>
                          <asp:TextBox id="Tdesignation" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Tdesignation"
                                  ErrorMessage="Enter Deisgnation Name" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator><br />
                              &nbsp;</TD>
                          <TD >DesignationLevel</TD>
                          <TD  ><asp:DropDownList id="Ddesiglevel" runat="server" CssClass="textile">
                                 <asp:ListItem >1</asp:ListItem>
                                 <asp:ListItem >2</asp:ListItem>
                                 <asp:ListItem >3</asp:ListItem>
                                 <asp:ListItem >4</asp:ListItem>
                             </asp:DropDownList> </TD></TR><TR>
                             <TD >Designation Code</TD>
                             <TD >
                             <asp:TextBox id="Tdesigcode" runat="server" ></asp:TextBox>&nbsp;
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Tdesigcode"
                                     ErrorMessage="Enter Deisgnationcode" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator></TD>
                            <TD style="HEIGHT: 19px">Probation</TD><TD style="HEIGHT: 19px">
                            <asp:DropDownList id="ddesigprobation" runat="server" Width="160px" CssClass="textile" Font-Size="X-Small">
                                 <asp:ListItem Selected=True Value="-1" >-select a value-</asp:ListItem>
                                 <asp:ListItem>0</asp:ListItem>
                                 <asp:ListItem>3</asp:ListItem>
                                 <asp:ListItem>4</asp:ListItem>
                                 <asp:ListItem>6</asp:ListItem>
                                 
                             </asp:DropDownList> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddesigprobation"
                                    ErrorMessage="Select Probation" InitialValue="-1" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator></TD></TR>
                                    <TR><TD >Insurance Category</TD><TD><asp:DropDownList id="TdesiginsCatagory" runat="server" CssClass="textile" Font-Size="X-Small">
                                 <asp:ListItem Selected=True Value="-1">-select a value-</asp:ListItem>
                                 <asp:ListItem>A</asp:ListItem>
                                 <asp:ListItem>B</asp:ListItem>
                                 <asp:ListItem>C</asp:ListItem>
                                 <asp:ListItem>D</asp:ListItem>
                             </asp:DropDownList> 
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TdesiginsCatagory"
                                     ErrorMessage="Select Insurance" InitialValue="-1" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator></TD><TD 
                                     style="WIDTH: 754px; HEIGHT: 12px">Insurance 
                                Amount </TD><TD ><asp:TextBox id="Tdesigins" runat="server" Width="120px" CssClass="textile">0</asp:TextBox>&nbsp;<asp:RegularExpressionValidator
                                        ID="R1" runat="server" ControlToValidate="Tdesigins" ErrorMessage="only Numbers!"
                                        ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="tvalidation"
                                        Width="117px"></asp:RegularExpressionValidator></TD></TR>
                              <TR><TD style="WIDTH: 1581px; HEIGHT: 16px"></TD><TD style="WIDTH: 466px; HEIGHT: 16px">
                                  &nbsp;</TD>
                             <TD >CTQ</TD>
                             <TD >
                             <asp:TextBox id="Tdesigctq" runat="server" Width="120px" CssClass="textile" MaxLength="1">0</asp:TextBox> 
                                 <asp:RegularExpressionValidator ID="R2" runat="server" ControlToValidate="Tdesigctq"
                                     ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                     ValidationGroup="tvalidation" Width="117px"></asp:RegularExpressionValidator></TD>
                                 </TR>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                            </tr>
                            <TR><TD style="border-top: 1px solid; vertical-align: middle; text-align: center;" 
                            colSpan=4>
                                &nbsp;<asp:Button ID="btnsave" runat="server" CausesValidation="true" SkinID="buttonskin1"
                                         Text="SAVE" ValidationGroup="tvalidation" />
                                 
                                  <asp:Button id="Bclear_desig" SkinID=buttonskin1  runat="server" Text="EXIT" CausesValidation="False">
                                 </asp:Button>
                                </TD></TR>
                                 </TBODY></TABLE>
                            <asp:GridView ID="grddesignation" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="4" DataSourceID="Sqldesignation" ForeColor="#333333" GridLines="None"
                                PageSize="15" AutoGenerateEditButton="True" DataKeyNames="desigcode" CellSpacing="3" >
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                                    <asp:BoundField DataField="designationname" HeaderText="DesignationName"  SortExpression="designationname" />
                                    <asp:BoundField DataField="desigcode" HeaderText="Desigcode" SortExpression="desigcode" ReadOnly=True  />
                                    <asp:TemplateField HeaderText="Desiglevel" SortExpression="dlevel">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList4" runat="server" SelectedValue='<%# Bind("dlevel") %>'>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("dlevel") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Probation" SortExpression="probation">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList5" runat="server" SelectedValue='<%# Bind("probation") %>'>
                                                <asp:ListItem>0</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("probation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inscategory" SortExpression="inscategory">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList6" runat="server" SelectedValue='<%# Bind("inscategory") %>'>
                                                <asp:ListItem>A</asp:ListItem>
                                                <asp:ListItem>B</asp:ListItem>
                                                <asp:ListItem>C</asp:ListItem>
                                                <asp:ListItem>D</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("inscategory") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="insamount" HeaderText="Insamount" SortExpression="insamount" />
                                    <asp:BoundField DataField="CTQlevel" HeaderText="CTQlevel" SortExpression="CTQlevel" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="Sqldesignation" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [designationname], [desigcode], [dlevel], [probation], [inscategory], [insamount], [CTQlevel] FROM [designation] ORDER BY [recordno] DESC"
                                DeleteCommand = "delete from designation where desigcode=@desigcode"  
                                 UpdateCommand="update designation set dlevel=@dlevel,designationname=@designationname,probation=@probation,
                        inscategory=@inscategory,insamount=@insamount,modifiedby=@cby,modifieddate=getdate() 
                        where desigcode=@desigcode ">
                                <DeleteParameters>
                                <asp:Parameter Name = "designationname" Type = string />
                                </DeleteParameters>
                                <UpdateParameters>
                                       <asp:Parameter Name = "designationname" Type = string />
                                       <asp:Parameter Name = "dlevel" Type = string />
                                       <asp:Parameter Name = "desigcode" Type = string />
                                       <asp:Parameter Name = "probation" Type = string />
                                       <asp:Parameter Name = "inscategory" Type = string />
                                       <asp:Parameter Name = "insamount" Type = string />
                                       <asp:Parameter Name = "cby" Type = string />
                                       
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        
                        
                        
                         </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 740px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>
								

</asp:Content>
