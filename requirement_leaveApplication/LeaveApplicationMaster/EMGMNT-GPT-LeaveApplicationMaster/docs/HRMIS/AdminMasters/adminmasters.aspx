<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile ="~/ems.Master" EnableEventValidation="false" 
CodeBehind="adminmasters.aspx.vb" Inherits="E_Management.adminmasters" Theme="buttonems"  %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>


<asp:Content ContentPlaceHolderID =CPHApplication runat =server >
    
 <table cellpadding=0 cellspacing=0 style="height: 336px">
    <tr>
	    <td vAlign="top" bgColor="#ffffff" style="height: 364px">
	    
            	<asp:Panel ID = "pnldesignation" runat=server >
                <table width="100%" cellpadding=0 cellspacing=0>
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
                                <td align="center" colspan="4" style="height: 17px; text-align: left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="tvalidation" />
                                </td>
                            </tr>
                          <TR>
                          <TD style="height: 27px" >Designation Name</TD>
                          <TD colSpan=1 style="height: 27px">
                          <asp:TextBox id="Tdesignation" runat="server" Width="172px" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Tdesignation"
                                  ErrorMessage="Enter Deisgnation Name" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator><br />
                              &nbsp;</TD>
                          <TD style="height: 27px" >DesignationLevel</TD><TD style="height: 27px" ><asp:DropDownList id="Ddesiglevel" runat="server" Width="160px" CssClass="textile">
                                 <asp:ListItem >1</asp:ListItem>
                                 <asp:ListItem >2</asp:ListItem>
                                 <asp:ListItem >3</asp:ListItem>
                                 <asp:ListItem >4</asp:ListItem>
                             </asp:DropDownList> </TD></TR><TR>
                             <TD style="WIDTH: 1581px; HEIGHT: 19px">Designation Code</TD>
                             <TD style="WIDTH: 466px; HEIGHT: 19px">
                             <asp:TextBox id="Tdesigcode" runat="server" ></asp:TextBox>&nbsp;
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Tdesigcode"
                                     ErrorMessage="Enter Deisgnationcode" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator></TD>
                            <TD style="WIDTH: 754px; HEIGHT: 19px">Probation</TD><TD style="HEIGHT: 19px">
                            <asp:DropDownList id="ddesigprobation" runat="server" Width="160px" CssClass="textile" Font-Size="X-Small">
                                 <asp:ListItem Selected=True Value="-1" >-select a value-</asp:ListItem>
                                 <asp:ListItem>0</asp:ListItem>
                                 <asp:ListItem>3</asp:ListItem>
                                 <asp:ListItem>4</asp:ListItem>
                                 <asp:ListItem>6</asp:ListItem>
                                 
                             </asp:DropDownList> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddesigprobation"
                                    ErrorMessage="Select Probation" InitialValue="-1" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 1581px; HEIGHT: 12px">Insurance Category</TD><TD 
style="WIDTH: 466px; HEIGHT: 12px"><asp:DropDownList id="TdesiginsCatagory" runat="server" Width="128px" CssClass="textile" Font-Size="X-Small">
                                 <asp:ListItem Selected=True Value="-1">-select a value-</asp:ListItem>
                                 <asp:ListItem>A</asp:ListItem>
                                 <asp:ListItem>B</asp:ListItem>
                                 <asp:ListItem>C</asp:ListItem>
                                 <asp:ListItem>D</asp:ListItem>
                             </asp:DropDownList> 
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TdesiginsCatagory"
                                     ErrorMessage="Select Insurance" InitialValue="-1" ValidationGroup="tvalidation">*</asp:RequiredFieldValidator></TD><TD 
                                     style="WIDTH: 754px; HEIGHT: 12px">Insurance 
                                Amount </TD><TD style="WIDTH: 158px; HEIGHT: 12px"><asp:TextBox id="Tdesigins" runat="server" Width="120px" CssClass="textile">0</asp:TextBox>&nbsp;</TD></TR>
                              <TR><TD style="WIDTH: 1581px; HEIGHT: 16px"></TD><TD style="WIDTH: 466px; HEIGHT: 16px">
                                  &nbsp;</TD>
                             <TD style="WIDTH: 754px; HEIGHT: 16px">CTQ</TD>
                             <TD style="WIDTH: 158px; HEIGHT: 16px">
                             <asp:TextBox id="Tdesigctq" runat="server" Width="120px" CssClass="textile">0</asp:TextBox> </TD>
                                 </TR>
                            <tr>
                                <td style="width: 1581px; height: 16px">
                                </td>
                                <td style="width: 466px; height: 16px">
                                </td>
                                <td style="width: 754px; height: 16px">
                                </td>
                                <td style="width: 158px; height: 16px">
                                </td>
                            </tr>
                            <TR><TD style="HEIGHT: 28px; border-top: 1px solid; vertical-align: middle; text-align: center;" 
                            colSpan=4>
                                &nbsp;<asp:Button ID="btnsave" runat="server" CausesValidation="true" SkinID="buttonskin1"
                                         Text="SAVE" ValidationGroup="tvalidation" />
                                 
                                  <asp:Button id="Bclear_desig" SkinID=buttonskin1  runat="server" Text="EXIT" CausesValidation="False">
                                 </asp:Button>
                                </TD></TR>
                                 </TBODY></TABLE>
                            <asp:GridView ID="grddesignation" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="4" DataSourceID="Sqldesignation" ForeColor="#333333" GridLines="None"
                                PageSize="15" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" DataKeyNames="designationname" CellSpacing="3" >
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="designationname" HeaderText="DesignationName" ReadOnly=True  SortExpression="designationname" />
                                    <asp:BoundField DataField="desigcode" HeaderText="Desigcode" SortExpression="desigcode" />
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
                                DeleteCommand = "delete from designation where designationname=@designationname"  
                                 UpdateCommand="update designation set dlevel=@dlevel,desigcode=@desigcode,probation=@probation,
                        inscategory=@inscategory,insamount=@insamount,modifiedby=@cby,modifieddate=getdate() 
                        where designationname=@designationname ">
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
                                       <asp:Parameter Name = "cby" Type = string DefaultValue = "014543" />
                                       
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
									
        <asp:Panel ID = "pnldepartment" runat=server >
                <table cellpadding=0 cellspacing=0 >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                            <table style="width: 685px">
                                <tr>
                                    <td align="center" colspan="4" class="td_head" >
                                        <b>Enter Department Details </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" valign="top">
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="fill in Required fields"
                                            Height="42px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 132px; background-color: beige;" >
                                        Department Code:</td>
                                    <td style="width: 183px" >
                                        <asp:TextBox ID="Tdeptcode" runat="server" Width="145px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Tdeptcode"
                                            Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="vdepartment">* </asp:RequiredFieldValidator></td>
                                    <td style="width: 142px; background-color: beige;" >
                                        Department Name:</td>
                                    <td>
                                        <asp:TextBox ID="TDeptname" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TDeptname"
                                            Display="Dynamic" ErrorMessage="enter Department Name" ValidationGroup="vdepartment">* </asp:RequiredFieldValidator></td>
                                </tr>
                                <tr >
                                    <td style="width: 132px; background-color: beige;" >
                                        Got Japanese Head:</td>
                                    <td style="width: 183px" >
                                        <asp:DropDownList ID="dJhead" runat="server" Font-Size="X-Small">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 142px; background-color: beige;" >
                                        Direct/Indirect Dept</td>
                                    <td >
                                        <asp:DropDownList ID="Ddirect" runat="server" Font-Size="X-Small">
                                            <asp:ListItem Value="P">Direct</asp:ListItem>
                                            <asp:ListItem Value="O">Indirect</asp:ListItem>
                                        </asp:DropDownList>&nbsp;<br />
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <%--<tr>
                             <td colspan=4 style="background-color:LightGoldenrodYellow" align=center><b>Request Time (Expected Time)</b></td>            
                             </tr>--%>
                                <tr>
                                    <td style="width: 132px; background-color: beige;" >
                                        Got Sections</td>
                                    <td style="width: 183px" >
                                        <asp:DropDownList ID="dsection" runat="server" Font-Size="X-Small">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width: 142px; background-color: beige;" >
                                        General Abbrevations</td>
                                    <td >
                                        <asp:TextBox ID="tdabbrevation" runat="server" Width="120px"></asp:TextBox>(Extrusion
                                        - EX)<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tdabbrevation"
                                            Display="Dynamic" ErrorMessage="enter Abbrevations" ValidationGroup="vdepartment">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 132px; background-color: beige">
                                    </td>
                                    <td style="width: 183px">
                                    </td>
                                    <td style="width: 142px; background-color: beige">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="height: 10px; border-top: beige 1px solid;">
                                        <asp:Button ID="Bdept_save" runat="server" CausesValidation="true"
                                            Text="Save" ValidationGroup="vdepartment" SkinID="buttonskin1" />&nbsp;
                                        <asp:Button ID="Button32" runat="server" Text="Exit" SkinID="buttonskin1" />
                                        &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="border-top: beige 1px solid; height: 15px">
                                        <asp:GridView ID="grddepartment" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True"
                                            CellPadding="4" CellSpacing="2" DataSourceID="SqlDepartment" ForeColor="#333333"
                                            GridLines="None" DataKeyNames="departmentcode">
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <Columns>
                                                <asp:BoundField DataField="departmentcode" HeaderText="DepartmentCode" ReadOnly=True  SortExpression="departmentcode" />
                                                <asp:BoundField DataField="departmentname" HeaderText="DepartmentName" SortExpression="departmentname" />
                                                <asp:TemplateField HeaderText="JapanHead" SortExpression="japanhead">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("japanhead") %>'>
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N">NO</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("japanhead") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="office" SortExpression="office">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("office") %>'>
                                                            <asp:ListItem Selected="True" Value="P">Direct</asp:ListItem>
                                                            <asp:ListItem Value="O">Indirect</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("office") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Got Section" SortExpression="section">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("section") %>'>
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("section") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="prefix" HeaderText="Prefix" SortExpression="prefix" />
                                            </Columns>
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT [departmentcode], [departmentname], [japanhead], ltrim(rtrim(office)) as office, [section], [prefix] FROM [department] ORDER BY [Recordno] DESC"
                                                 UpdateCommand = "MIS_UPDdepartment" UpdateCommandType=StoredProcedure
                                                 DeleteCommand =" delete from department where departmentcode = @departmentcode"                                               >
                                            <UpdateParameters>
                                                      <asp:Parameter Name="departmentcode"  Type="String" />
                                                      <asp:parameter Name ="departmentname" Type = "string" />
                                                      <asp:parameter Name ="japanhead" Type = "string" />
                                                      <asp:parameter Name ="office" Type = "string" />
                                                      <asp:parameter Name ="section" Type = "string" />
                                                      <asp:parameter Name ="prefix" Type = "string" />
                                                      <asp:parameter Name ="cby" Type = "string" DefaultValue= "014543" />                                                          
                                                      
                                             </UpdateParameters>
                                        <DeleteParameters>
                                            <asp:Parameter name = "departmentcode" Type="string"  />                                            
                                        </DeleteParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                            </table>                    
                        
         
                         </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" style="height: 16px">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" style="width: 725px; height: 16px;">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td style="width: 25px; height: 16px;">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>
			        <asp:Panel ID = "Pnlsection" runat=server >
           <table cellpadding=0 cellspacing=0 >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                        <TABLE ><TBODY><TR>
                            <TD align=center colSpan=4  class="td_head"><B>Enter Section Details </B></TD></TR>
                            <TR><TD>Section Code:</TD>
                            <TD><asp:TextBox id="Tscode" runat="server"></asp:TextBox> 
                                <asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" Width="112px" 
                                    ControlToValidate="Tscode" ValidationGroup="vsection" 
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Enter Section Code">* 
                                </asp:RequiredFieldValidator></TD>
                            <TD>Section Name:</TD>
                            <TD><asp:TextBox id="Tsname" runat="server"></asp:TextBox> 
                                <asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server" ControlToValidate="Tsname" 
                                ValidationGroup="vsection" Display="Dynamic" ErrorMessage="Enter Setion Name">* </asp:RequiredFieldValidator></TD>
                            </TR>
                             <TR><TD >Department Code:</TD>
                             <TD><asp:DropDownList id="Dsdeptcode" runat="server" 
                                      DataValueField="departmentcode" DataTextField="departmentname" DataSourceID="SqlDepartment"
                                       AppendDataBoundItems="True" Font-Size="X-Small">
                                    <asp:ListItem Selected =True >Please Select a Value</asp:ListItem>
                                </asp:DropDownList>
                               <asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server" 
                                    ControlToValidate="Dsdeptcode" ValidationGroup="vsection"
                                    SetFocusOnError="True" Display="Dynamic" InitialValue="Please Select a Value"
                                    ErrorMessage="Select Department">* </asp:RequiredFieldValidator></TD>
                              <TD>AQIS Approval Department</TD><TD>
                                     <asp:DropDownList id="dsaqis" runat="server" 
                                        DataValueField="departmentcode" DataTextField="departmentname" 
                                        DataSourceID="SqlDepartment"  AppendDataBoundItems="True" Font-Size="X-Small">
                                        <asp:ListItem Selected="True">Please Select a Value</asp:ListItem>
                                     </asp:DropDownList>
                                  <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ControlToValidate="dsaqis" 
                                ValidationGroup="vsection" SetFocusOnError="True" Display="Dynamic" 
                                InitialValue="Please Select a Value" ErrorMessage="Select Department">* </asp:RequiredFieldValidator></TD></TR>
                                <TR><TD align=center colSpan=4>
                        <asp:Button id="bsave_section" runat="server" Text="Save" ValidationGroup="vsection" SkinID="buttonskin1"></asp:Button>
                                 &nbsp; &nbsp;
                    <asp:Button id="Button51" runat="server" Text="Exit" SkinID="buttonskin1"></asp:Button> 
</TD></TR></TBODY></TABLE>
                            <asp:GridView ID="grdsection" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True"
                                CellPadding="4" CellSpacing="2" DataSourceID="Sqlsect" ForeColor="#333333" GridLines="None"
                                PageSize="15" DataKeyNames="sectioncode">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="sectioncode" HeaderText="SectionCode" ReadOnly = True  SortExpression="sectioncode" />
                                    <asp:BoundField DataField="sectionname" HeaderText="Sectionname" SortExpression="sectionname" />
                                    <asp:BoundField DataField="departmentcode" HeaderText="departmentcode" SortExpression="departmentcode" />
                                    <asp:BoundField DataField="aqisdept" HeaderText="aqisdept" SortExpression="aqisdept" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="Sqlsect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectionname], [sectioncode], [departmentcode], [aqisdept] FROM [sectionmaster]"
                                UpdateCommand ="update sectionmaster set sectionname=@sectionname,departmentcode=@departmentcode,aqisdept=@aqisdept
                                  where sectioncode=@sectioncode">
                                <UpdateParameters>
                                <asp:Parameter Name= sectioncode Type=string  />
                                 <asp:Parameter Name= sectionname Type=string  />
                                  <asp:Parameter Name= departmentcode Type=string  />
                                  <asp:Parameter Name= aqisdept Type=string  />
                                   </UpdateParameters>
                            </asp:SqlDataSource>
                        
                        
                        
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>
         <asp:Panel ID = "Pnldeptrpt" runat=server >
           <table cellpadding=0 cellspacing=0 >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
                                DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                                Height="1055px" ReportSourceID="CrystalReportSource1" Width="773px" />
                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                <Report FileName="F:\E-Management\Reports\Hrmis\Department.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        
                        
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>  
                        
          <asp:Panel ID = "Pnldesigrpt" runat=server >
           <table cellpadding=0 cellspacing=0 >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="True"
                                DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                                Height="1055px" ReportSourceID="CrystalReportSource2" Width="773px" />
                            <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                <Report FileName="F:\E-Management\Reports\Hrmis\Designation.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        
                        
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel> 
			
			  <asp:Panel ID = "Pnlsectrpt" runat=server >
           <table cellpadding=0 cellspacing=0 >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="True"
                                 EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                                Height="1055px" ReportSourceID="CrystalReportSource3" Width="773px" />
                            <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
                                <Report FileName="F:\E-Management\Reports\Hrmis\section.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        
                        
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>  
			
				  <asp:Panel ID = "Pnlbirthday" runat=server >
           <table cellpadding=0 cellspacing=0 >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer4" runat="server" AutoDataBind="True"
                                 EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                                Height="1055px" DisplayGroupTree=False  ReportSourceID="CrystalReportSource4" Width="773px" />
                            <CR:CrystalReportSource ID="CrystalReportSource4" runat="server">
                                <Report FileName="F:\E-Management\Reports\Hrmis\birthdaylist.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        
                        
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>  
        	
				  <asp:Panel ID = "pnlemprpt" runat=server >
           <table cellpadding=0 cellspacing=0 >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer5" runat="server" AutoDataBind="True"
                                 EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                                Height="1055px" ReportSourceID="CrystalReportSource5" Width="773px" />
                            <CR:CrystalReportSource ID="CrystalReportSource5" runat="server">
                                <Report FileName="F:\E-Management\Reports\Hrmis\empmaster.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        
                        
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
			</asp:Panel>                   
                     
       <!-- employee master starts here -->
       
        <asp:Panel ID = "Pnlempmaster" runat=server >
           <table cellpadding=0 cellspacing=0 style="width: 900px" >
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 725px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 725px">
                     
                                        <b> FILL IN ALL REQUIRED(*) FIELDS</b><br /><br />
                                    
                            <asp:Panel ID="Pnlempdetails" runat="server" GroupingText="EMPLOYEE NAME & CODE">
                                <table style="width: 848px" cellpadding="3" cellspacing="1">
                               
                                    <tr>
                                        <td style="width: 208px; background-color:beige;">
                                            Employee code
                                        </td>
                                        <td style="width: 220px ">
                                            <asp:TextBox ID="txtempcode" runat="server" AutoPostBack=true ></asp:TextBox>
                                          <asp:Button runat=server ID="btnempedit" text="EDIT" SkinID="buttonskin1" CausesValidation=false   /></td>
                                        <td style="width: 100px" rowspan="8" valign="top">
                                            <asp:Image ID="imgemp" runat="server" Width="200px"    /><br />
                                            (Please select Jpeg file of employee)</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px ; background-color:beige;">
                                            Name(As in Passport/IC)</td>
                                        <td style="width: 146px">
                                            <asp:TextBox ID="txtempname" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                            runat="server" ErrorMessage="*" ControlToValidate="txtempname" ></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px; height: 38px; background-color:beige;">
                                            Department</td>
                                        <td style="width: 146px; height: 38px">
                                            <asp:DropDownList ID="edeptcode" runat="server" DataSourceID="d_deptcode" DataTextField="DepartmentName"
                                                DataValueField="departmentcode"  Width="192px" Font-Size="X-Small" AppendDataBoundItems=true >
                                                <asp:ListItem Value="-1" Selected >--Select Dept--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                                             runat="server" ErrorMessage="*" ControlToValidate="edeptcode" InitialValue="-1">
                                             </asp:RequiredFieldValidator>
                                            <asp:SqlDataSource ID="d_deptcode" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                SelectCommand="select departmentcode,departmentcode +' ' +  +  '-'  +  +' '+departmentname as departmentname from department">
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px ; background-color:beige;">
                                            Section</td>
                                        <td style="width: 146px">
                                            <asp:DropDownList ID="deseccode" runat="server" DataSourceID="d_section" DataTextField="sectionname"
                                                DataValueField="sectioncode"  Width="208px" Font-Size="X-Small" AppendDataBoundItems=true >
                                                  <asp:ListItem Value="-1" Selected >--Select Sect--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                             runat="server" ErrorMessage="*" ControlToValidate="deseccode" InitialValue="-1">
                                             </asp:RequiredFieldValidator>
                                            <asp:SqlDataSource ID="d_section" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                SelectCommand="select sectioncode,sectioncode +' ' +  +  '-'  +  +' '+Sectionname as Sectionname from sectionmaster">
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px ; background-color:beige;">
                                            Designation</td>
                                        <td style="width: 146px">
                                            <asp:DropDownList ID="edesignation" runat="server" DataSourceID="ddesignation" DataTextField="designationname"
                                                DataValueField="designationname" Width="168px" Font-Size="X-Small" AppendDataBoundItems=true >
                                              <asp:ListItem Value="-1" Selected >--Select Desig--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                                             runat="server" ErrorMessage="*" ControlToValidate="edesignation" InitialValue="-1">
                                             </asp:RequiredFieldValidator><asp:SqlDataSource ID="ddesignation" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                SelectCommand="SELECT [designationname] FROM [designation]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px; height: 24px ; background-color:beige;">
                                            category</td>
                                        <td style="width: 146px; height: 24px ">
                                            <asp:DropDownList ID="decategory" runat="server"  Width="184px" Font-Size="X-Small">
                                                <asp:ListItem Value = -1 Selected >--Select--</asp:ListItem>
                                                <asp:ListItem>Employee</asp:ListItem>
                                                <asp:ListItem>Section Head</asp:ListItem>
                                                <asp:ListItem>Department Head</asp:ListItem>
                                                <asp:ListItem>MD</asp:ListItem>
                                                <asp:ListItem>EA</asp:ListItem>
                                                <asp:ListItem>Department head japan</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16"
                                             runat="server" ErrorMessage="*" ControlToValidate="decategory" InitialValue="-1">
                                             </asp:RequiredFieldValidator>
                                            
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px ; background-color:beige;">
                                            Date Of Join</td>
                                        <td style="width: 146px">
                                            <asp:TextBox ID="txtempdoj" runat="server"></asp:TextBox> 
                                            <cc1:CalendarExtender ID="ccemp" runat="server" 
                                                  CssClass="cal_Theme1" Format="dd/MM/yy"
                                                  PopupButtonID="txtempdoj" TargetControlID="txtempdoj">
                                            </cc1:CalendarExtender></td>
                                            <asp:RequiredFieldValidator ID="rf17" runat=server ErrorMessage="*" ControlToValidate="txtempdoj">
                                            </asp:RequiredFieldValidator></tr>
                                    <tr>
                                        <td style="width: 208px ; background-color:beige;">
                                            Employee type</td>
                                        <td style="width: 146px ">
                                            <asp:DropDownList ID="demptype" runat="server" DataSourceID="d_emptype" DataTextField="emptype"
                                                DataValueField="emptype" Font-Size="X-Small" Width="184px" AppendDataBoundItems=true >
                                                  <asp:ListItem Value="-1" Selected >--Select Emptype--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17"
                                             runat="server" ErrorMessage="*" ControlToValidate="demptype" InitialValue="-1">
                                             </asp:RequiredFieldValidator><asp:SqlDataSource ID="d_emptype" runat="server" 
                                             ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                SelectCommand="SELECT [emptype] FROM [emp_emptype]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px; height: 30px ; background-color:beige;">
                                            contract Period</td>
                                        <td style="width: 146px; height: 30px ">
                                            <asp:TextBox ID="txtempcontract" runat="server">0</asp:TextBox>Month(s)&nbsp;
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtempcontract"
                ErrorMessage="RegularExpressionValidator" SetFocusOnError="True" ValidationExpression="^\d*$"
                Display="Dynamic">* Enter numeric fields only</asp:RegularExpressionValidator>
                                            </td>
                                            
                                        <td style="height: 30px">
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <asp:Button ID="btnuploadpic" runat="server" Height="22px" Text="Upload..." CausesValidation="False" /><br />
                                            <asp:Label ID="lblfile" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                </table>                
                                                                                 
                                                       
                            </asp:Panel>                                            
                            <asp:Panel runat=server ID = "pnloff" GroupingText="OFFICIAL DETAILS" >
                                <table style="width: 844px">
                                    <tr>
                                        <td style="width: 158px ; background-color:beige;">
                                            staying in hostel</td>
                                        <td style="width: 100px">
                                            <asp:RadioButtonList ID="rdhostel" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td style="width: 100px ; background-color:beige;">
                                            Hostel Name</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="dehosname" runat="server" DataSourceID="d_hostelname" DataTextField="hostelname"
                                                DataValueField="hostelname" Font-Size="X-small" Width="184px" AppendDataBoundItems=true >
                                                <asp:ListItem Selected Value = "-1">--Select--</asp:ListItem>
                                            </asp:DropDownList><asp:SqlDataSource ID="d_hostelname" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                SelectCommand="SELECT [hostelname] FROM [emp_hostel]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 158px ; background-color:beige;">
                                            Transport Needed</td>
                                        <td style="width: 100px">
                                            <asp:RadioButtonList ID="rdtransport" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 158px ; background-color:beige;">
                                            Route</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="deroute" runat="server" DataSourceID="d_route" DataTextField="route"
                                                DataValueField="route" Font-Size="X-small" Width="184px" AppendDataBoundItems=true >
                                                 <asp:ListItem Selected Value = "-1">--Select--</asp:ListItem>
                                            </asp:DropDownList><asp:SqlDataSource ID="d_route" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                              SelectCommand="SELECT [route] FROM [trans_routemaster]"></asp:SqlDataSource>
                                        </td>
                                        <td style="width: 100px ; background-color:beige;">
                                            Area
                                        </td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="deArea" runat="server" DataSourceID="d_area" DataTextField="area"
                                                DataValueField="area" Font-Size="X-small" Width="168px" AppendDataBoundItems=true >
                                                 <asp:ListItem Selected Value = "-1">--Select--</asp:ListItem>
                                            </asp:DropDownList><asp:SqlDataSource ID="d_area" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                SelectCommand="SELECT [area] FROM [trans_areamaster]"></asp:SqlDataSource>
                                        </td>
                              
                                   </tr>
                                    <tr>
                                        <td style="width: 158px ; background-color:beige;">
                                            foreign Worker</td>
                                        <td style="width: 100px">
                                            <asp:RadioButtonList ID="rdforeign" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td style="width: 100px ; background-color:beige;">
                                            Passport No</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtpassport" runat="server">0</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 158px ; background-color:beige;">
                                            Old ICNO.</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtoldic" runat="server">0</asp:TextBox></td>
                                        <td style="width: 100px ; background-color:beige;">
                                            New ICNO.</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtnewic" runat="server">0</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 158px ; background-color:beige;">
                                            AccountNo.</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtaccount" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat=server ErrorMessage="*" 
                                              ControlToValidate="txtaccount"/>
                                            </td>
                                        <td style="width: 100px ; background-color:beige;">
                                            Bank Name</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="Debank" runat="server" Font-Size="X-small" Width="160px">
                                                <asp:ListItem Value="May" Selected >MAY BANK</asp:ListItem>
                                                <asp:ListItem Value="BSN">BANK SIMPANAN NASIONAL</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 158px ; background-color:beige;">
                                            EPF No.</td>
                                        <td style="width: 100px ">
                                            <asp:TextBox ID="txtepf" runat="server">0</asp:TextBox>
                                            </td>
                                        <td style="width: 100px ; background-color:beige;">
                                            SOSCO</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtsosco" runat="server">0</asp:TextBox></td>
                                    </tr>
                                </table>
                                  </asp:Panel>
                            <asp:Panel ID = "pnlpersonal" runat=server GroupingText="PERSONAL DETAILS" >
                                <table style="width: 838px">
                                    <tr>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Date of birth</td>
                                        <td style="width: 100px; height: 21px">
                                            <asp:TextBox ID="Txtdob" runat="server" Width="83px"></asp:TextBox>
                                               <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                  CssClass="cal_Theme1" Format="dd/MM/yy"
                                                  PopupButtonID="Txtdob" TargetControlID="Txtdob">
                                            </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat=server ErrorMessage="*" 
                                              ControlToValidate="txtdob"/>
                                            </td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Nationality</td>
                                        <td style="width: 100px; height: 21px">
                                            <asp:DropDownList ID="denation" runat="server" Font-Size="X-small" Width="96px">
                                                <asp:ListItem Value="MAL">MALAYSIAN</asp:ListItem>
                                                <asp:ListItem Value="IND">INDIAN</asp:ListItem>
                                                <asp:ListItem Value="JPN">JAPANESE</asp:ListItem>
                                                <asp:ListItem Value="PAK">PAKISTAN</asp:ListItem>
                                                <asp:ListItem Value="INDO">INDONESIAN</asp:ListItem>
                                                <asp:ListItem Value="NEPAL">NEPAL</asp:ListItem>
                                                <asp:ListItem Value="BANG">BANGLADESH</asp:ListItem>
                                                <asp:ListItem Value="OTHERS">OTHERS</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Gender</td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                        <asp:RadioButtonList ID="Rdgender" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="F">Female</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Blood Group</td>
                                        <td style="width: 100px; height: 21px ">
                                            <asp:TextBox ID="txtblood" runat="server" Width="83px">-</asp:TextBox></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Religion</td>
                                        <td style="width: 100px; height: 21px">
                                            <asp:DropDownList ID="Dereligion" runat="server" Font-Size="X-small" Width="96px">
                                                <asp:ListItem Value="ISL">ISLAM</asp:ListItem>
                                                <asp:ListItem Value="HIN">HINDU</asp:ListItem>
                                                <asp:ListItem Value="BUD">BUDDHA</asp:ListItem>
                                                <asp:ListItem Value="CHI">CHINESE</asp:ListItem>
                                                <asp:ListItem Value="CHRIS">CHRISTIAN</asp:ListItem>
                                                <asp:ListItem Value="O">OTHERS</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Race</td>
                                        <td style="width: 100px; height: 21px">
                                            <asp:DropDownList ID="derace" runat="server" Font-Size="X-small" Width="104px" >
                                                <asp:ListItem Value="MLY">MALAY</asp:ListItem>
                                                <asp:ListItem Value="IND">INDIAN</asp:ListItem>
                                                <asp:ListItem Value="JPN">JAPANESE</asp:ListItem>
                                                <asp:ListItem Value="PAK">PAKISTAN</asp:ListItem>
                                                <asp:ListItem Value="INDO">INDONESIAN</asp:ListItem>
                                                <asp:ListItem Value="NEPAL">NEPALESE</asp:ListItem>
                                                <asp:ListItem Value="BANG">BANGLADESH</asp:ListItem>
                                                <asp:ListItem Value="CHI">CHINESE</asp:ListItem>
                                                <asp:ListItem Value="IBAN">IBAN</asp:ListItem>
                                                <asp:ListItem Value="POR">PORTUGESE</asp:ListItem>
                                                <asp:ListItem Value="OTHERS">OTHERS</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px ; background-color:beige;">
                                            Marital Status</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="demarital" runat="server" Font-Size="X-small" Width="96px">
                                                <asp:ListItem Value="Married">MARRIED</asp:ListItem>
                                                <asp:ListItem Value="Single">SINGLE</asp:ListItem>
                                                <asp:ListItem Value="Divorced">DIVORCED</asp:ListItem>
                                                <asp:ListItem Value="Widow">WIDOW</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px ; background-color:beige;">
                                            No.of children</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtchildren" runat="server" Width="87px">0</asp:TextBox></td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 26px; background-color:beige;">
                                            Address1</td>
                                        <td style="width: 100px; height: 26px;">
                                            <asp:TextBox ID="txtadrs1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat=server ErrorMessage="*" 
                                              ControlToValidate="txtadrs1"/></td>
                                        <td style="width: 100px; height: 26px; background-color:beige;">
                                            Address2</td>
                                        <td style="width: 100px; height: 26px;">
                                         <asp:TextBox ID="Txtadrs2" runat="server" TextMode="MultiLine">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px; background-color:beige;">
                                            Address3</td>
                                        <td style="width: 100px; height: 26px;">
                                         <asp:TextBox ID="Txtadrs3" runat="server" TextMode="MultiLine">0</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 21px; background-color:beige;">
                                            Postcode</td>
                                        <td style="width: 100px; height: 21px">
                                         <asp:TextBox ID="Txtposcode" runat="server" Width="94px">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Telephone(Resi)</td>
                                        <td style="width: 100px; height: 21px">
                                         <asp:TextBox ID="Txtphone" runat="server" Width="121px">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            HandPhone</td>
                                        <td style="width: 100px; height: 21px">
                                         <asp:TextBox ID="Txthp" runat="server" Width="126px">0</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px ; background-color:beige;">
                                            Email</td>
                                        <td colspan="5">
                                         <asp:TextBox ID="txtemail" runat="server" Width="355px">0</asp:TextBox></td>
                                    </tr>
                                </table>
                            
                            
                            </asp:Panel>
                              <asp:Panel ID = "pnlunifom" runat=server GroupingText="Uniform Size Details" >
                                <table style="width: 831px">
                                    <tr>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Trousers</td>
                                        <td style="width: 100px; height: 21px">
                                         <asp:TextBox ID="Txttrousers" runat="server" Width="121px" Text="0"></asp:TextBox></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            Shoes</td>
                                        <td style="width: 100px; height: 21px">
                                         <asp:TextBox ID="txtshoes" runat="server" Width="121px" Text="0"/></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            T-Shirts</td>
                                        <td style="width: 100px; height: 21px">
                                         <asp:TextBox ID="txtshirt" runat="server" Width="121px" Text="0"/></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px ; background-color:beige;">
                                            No.of trousers Issued</td>
                                        <td style="width: 100px">
                                         <asp:TextBox ID="txtnotrousers" runat="server" Width="121px" Text="0"/>
                                     
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                             ControlToValidate="txtnotrousers"
                ErrorMessage="RegularExpressionValidator" SetFocusOnError="True" ValidationExpression="^\d*$"
                Display="Dynamic">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                                        <td style="width: 100px ; background-color:beige;">
                                            No.of shoes Issued</td>
                                        <td style="width: 100px">
                                         <asp:TextBox ID="txtnoshoes" runat="server" Width="121px" Text="0"/>
                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtnoshoes"
                ErrorMessage="RegularExpressionValidator" SetFocusOnError="True" ValidationExpression="^\d*$"
                Display="Dynamic">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                                        <td style="width: 100px ; background-color:beige;">
                                            No.of shirt Issued</td>
                                        <td style="width: 100px">
                                         <asp:TextBox ID="txtnoshirt" runat="server" Width="121px" Text="0"/>
                                   
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtnoshirt"
                ErrorMessage="RegularExpressionValidator" SetFocusOnError="True" ValidationExpression="^\d*$"
                Display="Dynamic">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 40px; background-color:beige;">
                                            No.of Jacket Issued</td>
                                        <td style="width: 100px; height: 40px;">
                                         <asp:TextBox ID="txtnojacket" runat="server" Width="121px" Text="0"/>
                                
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtnojacket"
                ErrorMessage="RegularExpressionValidator" SetFocusOnError="True" ValidationExpression="^\d*$"
                Display="Dynamic">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                                        <td style="width: 100px; height: 40px; background-color:beige;">
                                            No.of Cap issued</td>
                                        <td style="width: 100px; height: 40px;">
                                         <asp:TextBox ID="txtnocap" runat="server" Width="121px" Text="0"/>
                             
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtnocap"
                ErrorMessage="RegularExpressionValidator" SetFocusOnError="True" ValidationExpression="^\d*$"
                Display="Dynamic">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                                        <td style="width: 100px; height: 40px; background-color:beige;">
                                            Date of uniform given</td>
                                        <td style="width: 100px; height: 40px;">
                                         <asp:TextBox ID="txtdou" runat="server" Width="121px" Text="0"/>
                                           <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                  CssClass="cal_Theme1" Format="dd/MM/yy"
                                                  PopupButtonID="txtdou" TargetControlID="txtdou">
                                            </cc1:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtdou"
                                                ErrorMessage="*" InitialValue="-1"></asp:RequiredFieldValidator></td>
                                    </tr>
                                  
                                </table>
                            
                            
                            </asp:Panel>
                            <asp:Panel ID = "pnledudet" runat=server GroupingText="EDUCATION & WORK EXPERIENCE DETAILS" >
                                <table style="width: 833px">
                                    <tr>
                                        <td style="width: 201px; height: 21px ; background-color:beige;">
                                            Education Level</td>
                                        <td style="width: 100px; height: 21px">
                                            <asp:DropDownList ID="dElevel" runat="server" Font-Size="X-small" Width="144px">
                                                <asp:ListItem >SPM</asp:ListItem>
                                                <asp:ListItem >PMR</asp:ListItem>
                                                <asp:ListItem >DIPLOMA</asp:ListItem>
                                                <asp:ListItem >DEGREE</asp:ListItem>
                                                <asp:ListItem >MASTERS</asp:ListItem>
                                                <asp:ListItem >PHD</asp:ListItem>
                                                <asp:ListItem >BANGLADESH</asp:ListItem>
                                                <asp:ListItem >OTHERS</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px; height: 21px ; background-color:beige;">
                                            If Others(specify)</td>
                                        <td style="width: 318px; height: 21px">
                                            <asp:TextBox ID="txteduothers" runat="server" Width="121px">-</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 201px ; background-color:beige;">
                                            Work Area</td>
                                        <td style="width: 100px">
                                             <asp:TextBox ID="txteduwork" runat="server" TextMode="MultiLine">--</asp:TextBox>
                                     </td>
                                        <td style="width: 100px ; background-color:beige;">
                                            Year of Experience</td>
                                        <td style="width: 318px">
                                             <asp:TextBox ID="txteduexp" runat="server" Width="121px">0</asp:TextBox>
                                   </td>
                                    </tr>
                                </table>                            
                            </asp:Panel>                       
                          
                                    <asp:Panel ID="pnlaccess" runat=server GroupingText="ACCESS">
                                        <table style="width: 838px">
                                            <tr>
                                                <td style="width: 201px; height: 26px; background-color:beige;" valign="middle">
                                                    Hand Phone Pass</td>
                                                <td style="width: 100px; height: 26px" valign="middle">
                                                    &nbsp;<asp:RadioButtonList ID="rdhp" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                                <td style="width: 100px; height: 26px; background-color:beige;" valign="middle">
                                                    Car Pass</td>
                                                <td style="width: 100px; height: 26px" valign="middle">
                                                    &nbsp;<asp:RadioButtonList ID="rdcar" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 201px; background-color:beige; height: 28px;" valign="middle">
                                                    NoteBook Pass</td>
                                                <td style="width: 100px; height: 28px" valign="middle">
                                                    &nbsp;<asp:RadioButtonList ID="rdnb" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                                <td style="width: 100px; background-color:beige; height: 28px;" valign="middle">
                                                    Remote Login</td>
                                                 <td style="width: 100px; height: 28px" valign="middle">
                                                    &nbsp;<asp:RadioButtonList ID="rdlogin" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                         <tr>
                                        <td align="right" colspan=5>
                                          <asp:Button runat=server ID="btnempsave" text="SAVE" SkinID="buttonskin1" />&nbsp;
                                                                      </td></tr>
                                        </table>
                                    
                                   </asp:Panel>               
                                               
                        </td>
                        <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                    </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
            
          </asp:Panel>    
  
                        
        
        
        <!-- Main Table Ends here -->			
        </td>
    </tr>
</table>
</asp:Content>