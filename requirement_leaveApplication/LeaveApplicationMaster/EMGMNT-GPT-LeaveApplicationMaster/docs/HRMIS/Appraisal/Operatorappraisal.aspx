<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Operatorappraisal.aspx.vb" Inherits="E_Management.Operatorappraisal" 
    title="Operator Appraisal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

<table cellpadding=0 cellspacing=0>
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 650px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 650px">
                         <table id="TABLE1" onclick="return TABLE1_onclick()">
                                <tr>
                                    <td align="center" class="td_head" colspan="3" style="height: 17px" valign="middle">
                                        Operator Appraisal</td>
                                        <td align="right">
                                            </td>
                                </tr>
                                <tr>
                                    <td style="height: 17px; background-color: beige; width: 80px;">
                                        EmpCode</td>
                                    <td style="width: 196px; background-color: beige;">
                                        <asp:Label ID="lblemp" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; width: 120px;">
                                        EmpName</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 80px;">
                                        Department</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; width: 120px;">
                                        Section</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 120px;">
                                            Appraisal Date</td>
                                    <td style="background-color: beige; width: 196px;">
                                            <asp:Label ID="Label1" runat="server" ForeColor="#C04000"></asp:Label></td>
                                    <td style="background-color: beige; width: 120px;">
                                        Employee Status
                                    </td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                                </tr>
                             <tr>
                                 <td class="td_head" colspan="4" style="height: 21px">
                                     Employee History
                                     
                                     
                                     
                                     </td>
                                  
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                      
                                     <table style="width: 100%">
                                         
                                                              
                                  <tr>
                                 <td style=" background-color: beige; width: 177px;">
                                     Medical Leave &nbsp;:<asp:Label ID="lblmedical" runat="server"></asp:Label></td>
                                 <td style=" background-color: beige">
                                     Explanation &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; :<asp:Label ID="lblexpl" runat="server"></asp:Label></td>
                                  <td style=" background-color: beige">
                                      Final Warning &nbsp; &nbsp;:<asp:Label ID="lblfinw" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: beige; width: 177px; height: 21px;">
                                     Absent &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label ID="lblabs" runat="server"></asp:Label></td>
                                 <td style="background-color: beige; height: 21px;">
                                     Verbal Warning &nbsp; &nbsp;&nbsp; &nbsp;:<asp:Label ID="lblvw" runat="server"></asp:Label></td>
                                 <td style="background-color: beige; height: 21px;">
                                     Suspension &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsus" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: beige; width: 177px;">
                                     Late &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label
                                         ID="lbllate" runat="server"></asp:Label></td>
                                 <td style=" background-color: beige">
                                     Written Warning &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblww" runat="server"></asp:Label></td>
                                 <td style="background-color: beige">
                                     Showcase &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsc" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: beige; width: 177px;">
                                     Misconduct Counselling:<asp:Label ID="lblcoun" runat="server"></asp:Label></td>
                                 <td style=" background-color: beige">
                                     First Warning &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; :<asp:Label ID="lblfw" runat="server"></asp:Label></td>
                                 <td style="background-color: beige">
                                     Misconduct Rpt :<asp:Label ID="lblrpt" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td class="td_head" colspan="4" style="height: 21px">
                                     Monthly Appraisal Data</td>
                              
                             </tr>
                                         <tr>
                                             <td colspan="4" style="height: 21px">
                                                 <table>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             JAN</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             FEB</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             MAR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             APR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             MAY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             JUNE</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             Avg1-Grd1</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="lbl1" runat="server"></asp:Label>-<asp:Label ID="Label13" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label2" runat="server"></asp:Label>-<asp:Label ID="Label14" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label3" runat="server"></asp:Label>-<asp:Label ID="Label15" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label4" runat="server"></asp:Label>-<asp:Label ID="Label16" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label5" runat="server"></asp:Label>-<asp:Label ID="Label17" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label6" runat="server"></asp:Label>-<asp:Label ID="Label18" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="lbla1" runat="server"></asp:Label>-<asp:Label ID="lblg1" runat="server"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             JULY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             AUG</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             SEP</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             OCT</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             NOV
                                                         </td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             DEC</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             Avg2-Grd2</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label7" runat="server"></asp:Label>-<asp:Label ID="Label19" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label8" runat="server"></asp:Label>-<asp:Label ID="Label20" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label9" runat="server"></asp:Label>-<asp:Label ID="Label21" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label10" runat="server"></asp:Label>-<asp:Label ID="Label22" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label11" runat="server"></asp:Label>-<asp:Label ID="Label23" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: lightgoldenrodyellow; text-align: center;">
                                                             <asp:Label ID="Label12" runat="server"></asp:Label>-<asp:Label ID="Label24" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="lbla2" runat="server"></asp:Label>-<asp:Label ID="lblg2" runat="server"></asp:Label></td>
                                                     </tr>
                                                 </table>
                                             </td>
                                         </tr>
                                     </table>
                                     
                        
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     Purpose Of Appraisal</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:RadioButtonList ID="rdpurpose" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                         <asp:ListItem Value="endprobation">End of Probation Period </asp:ListItem>
                                         <asp:ListItem Value="extcontract ">Extend Contract</asp:ListItem>
                                         <asp:ListItem Value="1/2 Yearly">1/2 Yearly Appraisal</asp:ListItem>
                                     </asp:RadioButtonList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rdpurpose"
                                         ErrorMessage="Please Select appraisal Purpose"></asp:RequiredFieldValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:Label ID="lblapp" runat="server" Text="Yearly appraisal :" Visible="False"></asp:Label>&nbsp;<asp:DropDownList ID="ddlhalf" runat="server" Visible="False">
                                         <asp:ListItem>1st Half</asp:ListItem>
                                         <asp:ListItem>2nd Half</asp:ListItem>
                                         <asp:ListItem Selected="True" Value="-">-Select-</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:Label ID="lblhalf" runat="server" Visible="False">-</asp:Label>
                                     </td>
                             </tr>
                             <tr>
                                 <td class="td_head" colspan="4" style="height: 21px">
                                     Performance Rating Indicator(PRI)</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <div style="text-align: left">
                                         <table style="background-color: aquamarine" border="1">
                                             <tr>
                                                 <td style="width: 100px; height: 21px;" >
                                         A - Excellent</td>
                                                 <td style="width: 100px; height: 21px;">
                                         B - Good</td>
                                                 <td style="width: 100px; height: 21px;">
                                                     C-average</td>
                                                 <td style="width: 130px; height: 21px;">
                                                     D-Below average</td>
                                                 <td style="width: 100px; height: 21px;">
                                                     E-Poor</td>
                                             </tr>
                                             <tr>
                                                 <td style="width: 100px; height: 23px;">
                                                     45 - 50</td>
                                                 <td style="width: 100px; height: 23px;">
                                                     40 - 44</td>
                                                 <td style="width: 100px; height: 23px;">
                                                     35 - 39</td>
                                                 <td style="width: 100px; height: 23px;">
                                                     30 - 34</td>
                                                 <td style="width: 100px; height: 23px;">
                                                     29 &amp;&nbsp; Below</td>
                                             </tr>
                                         </table>
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" class="td_head">
                                     <div align="center" class="style37">
                                         Carefully Appraise employee's performance and tick the appropriate column for the
                                         rating scale as below:</div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:GridView ID="GrdOpt" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                         DataSourceID="SqlDataSource1" ForeColor="#333333" ShowFooter="True">
                                         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                         <Columns>
                                             <asp:BoundField DataField="sno" HeaderText="Sno" SortExpression="sno" />
                                             <asp:TemplateField HeaderText="Performance &amp; scale " SortExpression="description">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                                                 </ItemTemplate>
                                                      <FooterTemplate>
                                                  <asp:Label ID="Label2" runat="server" Text = "Total:" ></asp:Label>
                                                  <asp:Label ID="Lbltotal" runat="server" Text="0"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Grade">
                                                 <ItemTemplate>
                                                     <asp:RadioButtonList ID="rdprating" runat="server" RepeatDirection="Horizontal"
                                                         Width="420px" AutoPostBack="True" OnSelectedIndexChanged="chkDynamic_CheckedChanged">
                                                         <asp:ListItem Value="1">E</asp:ListItem>
                                                         <asp:ListItem Value="2">D</asp:ListItem>
                                                         <asp:ListItem Value="3">C</asp:ListItem>
                                                         <asp:ListItem Value="4">B</asp:ListItem>
                                                         <asp:ListItem Value="5">A</asp:ListItem>
                                                     </asp:RadioButtonList>
                                                     
                                                 </ItemTemplate>
                                                  <FooterTemplate>
                                                  <asp:Label ID="La" runat="server" Text=Grade: ></asp:Label>
                                                  <asp:Label ID="Lblgrade" runat="server" Text="0"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                         </Columns>
                                         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                         <EditRowStyle BackColor="#999999" />
                                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                     </asp:GridView>
                                     &nbsp;
                                 </td>
                             </tr>
                             <tr>
                                 <td char="td_head" colspan="4">
                                       <div align="center" class="whitetext">
                                       Recommendation / Remarks by Department Head </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table border="1" cellpadding="1" cellspacing="1" style="width: 100%">
                                         <tr>
                                             <td style="width: 100px">
                                                 Employement Status</td>
                                             <td colspan="2">
                                                 &nbsp;<asp:RadioButtonList ID="rdconfirm" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem Value="C">Confirmation</asp:ListItem>
                                                     <asp:ListItem Value="E">Extend Probation (3 Mth)</asp:ListItem>
                                                     <asp:ListItem Value="EC">Extend contract</asp:ListItem>
                                                 </asp:RadioButtonList></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" class="td_class" colspan="4">
                                     Appraisal Done By</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table style="width: 591px">
                                         <tr>
                                             <td style="width: 43px; height: 21px;">
                                                 Employee No</td>
                                             <td style="width: 100px; height: 21px;">
                                                 <asp:Label ID="lblempcode" runat="server"></asp:Label></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="td_head" colspan="4">
                                     Section Head
                                     Comments</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine" Width="625px">-</asp:TextBox></td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige" align="right">
                                     &nbsp;<asp:Button ID="txtbutton" runat="server" Text="SAVE" /></td>
                             </tr>
                                </table>
                            &nbsp;
                                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT [description], [sno] FROM [optappraisal]"></asp:SqlDataSource>
                                  </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 650px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
</asp:Content>
                         

