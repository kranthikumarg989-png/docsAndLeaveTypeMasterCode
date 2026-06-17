<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="empreport.aspx.vb" Inherits="E_Management.empreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px" valign="top">
    <table>
    <tr>
    <td class="td_head" colspan="4">Employee Details Report</td>
     </tr>
     <tr>
     <td><asp:Label ID="Label2" runat="server" Text="Emp No: "></asp:Label>
     <asp:TextBox ID="empcode" runat="server" AutoPostBack="True" MaxLength="6" Width="60px"></asp:TextBox></td>
     <td></td><td align="right"><asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" ForeColor="Blue" >View Js</asp:LinkButton></td>
     </tr>
     <tr><td colspan="4" class="td_head">Personel Details</td>
     </tr>
     <tr>
            <td>EmpName :<asp:Label ID="empname" runat="server"></asp:Label></td>
            <td>Dob :<asp:Label ID="dob" runat="server"></asp:Label></td>
            <td>Old Icno :<asp:Label ID="oldicno" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>New Icno :<asp:Label ID="newicno" runat="server"></asp:Label></td>
            <td>Passport No :<asp:Label ID="Passportno" runat="server"></asp:Label></td>
            <td>Gender :<asp:Label ID="gender" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Race :<asp:Label ID="race" runat="server"></asp:Label></td>
            <td>Religion :<asp:Label ID="religion" runat="server"></asp:Label></td>
            <td>Marital Status :<asp:Label ID="maritalstatus" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Nationality :<asp:Label ID="nationality" runat="server"></asp:Label></td>
            <td>Qualification :<asp:Label ID="qualification" runat="server"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4"class="td_head">Contact Details</td>
        </tr>
        <tr>
        <td>Address :<asp:Label ID="address" runat="server"></asp:Label></td>      
        <td>Email :<asp:Label ID="email" runat="server"></asp:Label></td> 
        <td>Telephone :<asp:Label ID="telephone" runat="server"></asp:Label></td>
        </tr>
        <tr>
        <td>Mobile :<asp:Label ID="mobile" runat="server"></asp:Label></td>
        <td>Route :<asp:Label ID="route" runat="server"></asp:Label></td>
        <td>Area :<asp:Label ID="area" runat="server"></asp:Label></td>
        </tr>
        <tr><td colspan="4" class="td_head">Official Details</td>
        </tr>
        <tr>
        <td>Date of Join :<asp:Label ID="dojemp" runat="server"></asp:Label></td>
        <td>Designation :<asp:Label ID="designation" runat="server"></asp:Label></td>
        <td>Foreign Worker :<asp:Label ID="foreignworker" runat="server"></asp:Label></td>
            
        </tr>
        <tr>
        <td>Dept Code :<asp:Label ID="deptcode" runat="server" ></asp:Label></td>
        <td>Dept Name :<asp:Label ID="deptname" runat="server" ></asp:Label></td>
        <td>EPF No :<asp:Label ID="epfno" runat="server" ></asp:Label></td>
        </tr>
        <tr><td>Section Code :<asp:Label ID="sectioncode" runat="server"></asp:Label></td>
              <td>Section Name :<asp:Label ID="sectionname" runat="server"></asp:Label></td>
              <td>Experience in Maruwa(yrs) :<asp:Label ID="experience" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Employment Status :<asp:Label ID="employmentstatus" runat="server"></asp:Label></td>
              <td>Contract Effective from :<asp:Label ID="contracteffectivefrom" runat="server"></asp:Label></td>
              <td>Contract Period :<asp:Label ID="contractperiod" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Category :<asp:Label ID="category" runat="server"></asp:Label></td>
            <td>Resigned :<asp:Label ID="resigned" runat="server"></asp:Label></td>
            <td>Date of Resign :<asp:Label ID="dateofresign" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Leave Details</tr>
        <tr>
              <td>Carry Forward :<asp:Label ID="cryfwdleave" runat="server"></asp:Label></td>
              <td>Annual Entitlement  :<asp:Label ID="annleave" runat="server"></asp:Label></td>
              <td>Medical Entitlement :<asp:Label ID="medleave" runat="server"></asp:Label></td>
             
        </tr>
        <tr>
            <td>
                Carry Forward Utilised :<asp:Label ID="LblCFU" runat="server"></asp:Label></td>
            <td>
                Annual Utilised :<asp:Label ID="LblAU" runat="server"></asp:Label>
            </td>
            <td>
                Medical Utilised :<asp:Label ID="LblMU" runat="server"></asp:Label></td>
            
        </tr>
        <tr>
        <td>Balance CarryForward :<asp:Label ID="balcryfwd" runat="server"></asp:Label></td>
        <td>Balance Annual Leave :<asp:Label ID="balann" runat="server"></asp:Label></td>
            <td>Balance Medical Leave :<asp:Label ID="balmed" runat="server"></asp:Label></td>
            
        </tr>
        <tr><td>
            Total Entitlement Balance :<asp:Label ID="eligibleleave" runat="server" ></asp:Label></td>
             <td></td>
            <td></td>
            <td></td>
        </tr>
         <tr><td colspan="4" class="td_head">Leave History</td></tr> 
        <tr>
            <td colspan="4" >
                <asp:GridView ID="GridView1" runat="server" CaptionAlign="Left" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BorderColor="Silver" BorderWidth="1px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="fromdate" HeaderText="Fromdate" SortExpression="fromdate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                        <asp:BoundField DataField="todate" HeaderText="Todate" SortExpression="todate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                        <asp:BoundField DataField="days" HeaderText="Days Applied" SortExpression="days" />
                        <asp:BoundField DataField="nocf" HeaderText="CarryFwd" SortExpression="nocf" />
                        <asp:BoundField DataField="workfor" HeaderText="Workfor" SortExpression="workfor" Visible="False" />
                        <asp:BoundField DataField="leavetype" HeaderText="Leavetype" SortExpression="leavetype" />
                        <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" />
                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                        <asp:BoundField DataField="approvedby" HeaderText="Approvedby" SortExpression="approvedby" />
                        <asp:BoundField DataField="approveddate" HeaderText="Approveddate" SortExpression="approveddate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT fromdate, todate, workfor, leavetype, reason, LTRIM(RTRIM(status)) AS status, approvedby, approveddate, nocf, days FROM Leaveform WHERE (empno = @eid) ORDER BY fromdate DESC">
               <SelectParameters>
               <asp:Parameter Name="eid"  />
               </SelectParameters>
                </asp:SqlDataSource>
            </td>
            
        </tr>
        <tr>
            <td colspan="4" class="td_head">Clinic Details</td>
        </tr>
        <tr>
        <td>Amount Entitled :150</td>
        <td>Balance :<asp:Label ID="balance" runat="server"></asp:Label></td>
        <td>Personal Payment :<asp:Label ID="personalpayment" runat="server"></asp:Label></td>
        </tr>
        <tr><td colspan="4" class="td_head">Clinic History</td>
           <tr>
            <td colspan="4">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" BorderColor="Silver" BorderWidth="1px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
                    <asp:BoundField DataField="dateapplied" HeaderText="Dateapplied" SortExpression="dateapplied" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                    <asp:BoundField DataField="etimeout" HeaderText="Timeout" SortExpression="etimeout" dataformatstring="{0:t}" HtmlEncode=False/>
                    <asp:BoundField DataField="etimein" HeaderText="Timein" SortExpression="etimein" dataformatstring="{0:t}" HtmlEncode=False/>
                    <asp:BoundField DataField="sickness" HeaderText="Sickness" SortExpression="sickness" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView> 
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT passno,dateapplied,etimein,etimeout,sickness FROM clinicstaffgatepass where  empcode=@empcod and status='F' order by dateapplied desc">
               <SelectParameters>
               <asp:Parameter Name="empcod" />
               </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Passport Details</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="AppWorkspace" BorderWidth="1px" CellPadding="1" DataSourceID="SqlDataSource3" ForeColor="#333333" CaptionAlign="Left">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="passportno" HeaderText="Passportno" SortExpression="passportno" />
                        <asp:BoundField DataField="ppexpirydate" HeaderText="Expirydate" SortExpression="ppexpirydate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=false/>
                        <asp:BoundField DataField="empgroup" HeaderText="Employeegroup" SortExpression="empgroup" />
                        <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
                        <asp:BoundField DataField="arriveddate" HeaderText="Arriveddate" SortExpression="arriveddate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=false/>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select passportno,ppexpirydate,empgroup,country,arriveddate from passportdetails where empcode=@empcod">
                 <SelectParameters>
               <asp:Parameter Name="empcod" />
               </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Visa / WorkPermit Details</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderColor="ActiveBorder" BorderWidth="1px" CaptionAlign="Left" CellPadding="1" DataSourceID="SqlDataSource4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="visatype" HeaderText="Visatype" SortExpression="visatype" />
                        <asp:BoundField DataField="visareferenceno" HeaderText="Ref.No" SortExpression="visareferenceno" />
                        <asp:BoundField DataField="visavalidfrom" HeaderText="Validfrom" SortExpression="visavalidfrom" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                        <asp:BoundField DataField="visavalidto" HeaderText="Validto" SortExpression="visavalidto" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                        <asp:BoundField DataField="workpermitno" HeaderText="Workpermitno" SortExpression="workpermitno" />
                        <asp:BoundField DataField="receiptno" HeaderText="Receiptno" SortExpression="receiptno" />
                        <asp:BoundField DataField="serialno" HeaderText="Serialno" SortExpression="serialno" />
                        <asp:BoundField DataField="amount" HeaderText="Bankguranteeamount" SortExpression="amount" />
                        <asp:BoundField DataField="bgexpirydate" HeaderText="Bankexpirydate" SortExpression="bgexpirydate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                        <asp:BoundField DataField="inspolicynumber" HeaderText="Inspolicyno" SortExpression="inspolicynumber" />
                        <asp:BoundField DataField="insexpirydate" HeaderText="Insexpirydate" SortExpression="insexpirydate" dataformatstring="{0:dd-MM-yyy}" HtmlEncode=False/>
                        <asp:BoundField DataField="amtpass" HeaderText="Amtpass" SortExpression="amtpass" />
                        <asp:BoundField DataField="amtlevy" HeaderText="Amtlevy" SortExpression="amtlevy" />
                        <asp:BoundField DataField="amtvisa" HeaderText="Amtvisa" SortExpression="amtvisa" />
                        <asp:BoundField DataField="amtprocess" HeaderText="Amtprocess" SortExpression="amtprocess" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select visatype,visareferenceno,visavalidfrom,visavalidto,workpermitno,receiptno,serialno,amount,bgexpirydate,inspolicynumber,insexpirydate,amtpass,amtlevy,amtvisa,amtprocess from workpermitdetails where   empcode=@empcod">
               <SelectParameters>
               <asp:Parameter Name="empcod" />
               </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr><td colspan="4" class="td_head">ER Details</td>
        </tr>
        <tr><td colspan="4" class="td_head">Discipline ----Letter of Explanation(Total) :<asp:Label ID="expcount" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView5" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">
                Discipline ----Verbal Warning - NIL(Total) :<asp:Label ID="verbcount" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView6" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">First Warning :<asp:Label ID="countfirstwarning" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView7" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">
                Final Warning :<asp:Label ID="countfinalwarning" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView8" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Performance Counselling :<asp:Label ID="countcounselling" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView9" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Major Misconduct First Warning :<asp:Label ID="countmisfirst" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView10" runat="server" BorderColor="ActiveBorder" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Misconduct Final Warning :<asp:Label ID="countmisfinal" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView11" runat="server" BorderColor="ActiveBorder" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Showcause Letter :<asp:Label ID="countshowcause" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView12" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Formal Advice Letter :<asp:Label ID="countformal" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView13" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Written Warning :<asp:Label ID="countwarning" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView14" runat="server" CaptionAlign="Left" CellPadding="4" ForeColor="#333333" BorderColor="Silver" BorderWidth="1px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="td_head">Any Type of Letter :<asp:Label ID="countanytypeletter" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView15" runat="server" BorderColor="Silver" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" ForeColor="#333333">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
            <input type="button" value="Exit" onclick="window.close()" style="background-color: beige" id="btn1">
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
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>  
        </table>
</asp:Content>
