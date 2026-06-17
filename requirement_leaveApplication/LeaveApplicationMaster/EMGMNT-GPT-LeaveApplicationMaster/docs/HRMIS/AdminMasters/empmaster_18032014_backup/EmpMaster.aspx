<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="EmpMaster.aspx.vb" Inherits="E_Management.EmpMaster1" 
    title="EMPLOYEE MASTER" %>
       <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" style="width: 900px">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 725px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 725px" valign="top">
                <b>FILL IN ALL REQUIRED(*) FIELDS</b><br />
                <asp:Label ID="lblmsg" runat="server"></asp:Label><br />
                 <asp:Panel ID="Panel1" runat="server" GroupingText="JOB APPLICATION DETAIL">
                <table style="width: 470px">
                <tr>
                            <td style="height: 59px">
                                KEY IN JOB APPLICATION NUMBER
                            </td>
                            <td style="width: 158px; height: 59px">
                                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true"></asp:TextBox>
                           </td>
                        </tr></table>
                </asp:Panel>
                <asp:Panel ID="Pnlempdetails" runat="server" GroupingText="EMPLOYEE NAME & CODE">
                    <table cellpadding="3" cellspacing="1" style="width: 848px">
                        <tr>
                            <td style="width: 208px; background-color: beige; height: 31px;">
                                Employee code
                            </td>
                            <td style="width: 220px; height: 31px;">
                                <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="true"></asp:TextBox>
                                <asp:Button ID="btnempedit" runat="server" CausesValidation="false" SkinID="buttonskin1"
                                    Text="EDIT" /></td>
                            <td rowspan="8" style="width: 100px" valign="top">
                                <asp:Image ID="imgemp" runat="server" Width="200px" /><br />
                                (Please select Jpeg file of employee)</td>
                        </tr>
                        <tr>
                            <td style="width: 208px; background-color: beige">
                                Name(As in Passport/IC)</td>
                            <td style="width: 146px">
                                <asp:TextBox ID="txtempname" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtempname"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 208px; height: 38px; background-color: beige">
                                Department</td>
                            <td style="width: 146px; height: 38px">
                                <asp:DropDownList ID="edeptcode" runat="server" AppendDataBoundItems="true" DataSourceID="d_deptcode"
                                    DataTextField="DepartmentName" DataValueField="departmentcode" Font-Size="X-Small"
                                    Width="192px" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="-1">--Select Dept--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="edeptcode"
                                    ErrorMessage="*" InitialValue="-1">
                                             </asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="d_deptcode" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="select departmentcode,departmentcode +' ' +  +  '-'  +  +' '+departmentname as departmentname from department order by departmentcode ">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 208px; background-color: beige">
                                Section</td>
                            <td style="width: 146px">
                                <asp:DropDownList ID="deseccode" runat="server" AppendDataBoundItems="true" DataSourceID="d_section"
                                    DataTextField="sectionname" DataValueField="sectioncode" Font-Size="X-Small"
                                    Width="208px">
                                    <asp:ListItem Selected="" Value="-1">--Select Sect--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="deseccode"
                                    ErrorMessage="*" InitialValue="-1">
                                             </asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="d_section" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="select sectioncode,sectioncode +' ' +  +  '-'  +  +' '+Sectionname as Sectionname from sectionmaster">
                                                            
                                 
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 208px; background-color: beige">
                                Designation</td>
                            <td style="width: 146px">
                                <asp:DropDownList ID="edesignation" runat="server" AppendDataBoundItems="true" DataSourceID="ddesignation"
                                    DataTextField="designationname" DataValueField="designationname" Font-Size="X-Small"
                                    Width="168px">
                                    <asp:ListItem Selected="" Value="-1">--Select Desig--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="edesignation"
                                    ErrorMessage="*" InitialValue="-1">
                                             </asp:RequiredFieldValidator><asp:SqlDataSource ID="ddesignation" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" SelectCommand="SELECT [designationname] FROM [designation]">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 208px; height: 24px; background-color: beige">
                                category</td>
                            <td style="width: 146px; height: 24px">
                                <asp:DropDownList ID="decategory" runat="server" Font-Size="X-Small" Width="184px">
                                    <asp:ListItem Selected="" Value="-1">--Select--</asp:ListItem>
                                    <asp:ListItem>Employee</asp:ListItem>
                                    <asp:ListItem>Section Head</asp:ListItem>
                                    <asp:ListItem>Department Head</asp:ListItem>
                                    <asp:ListItem>MD</asp:ListItem>
                                    <asp:ListItem>EA</asp:ListItem>
                                    <asp:ListItem>Department head japan</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="decategory"
                                    ErrorMessage="*" InitialValue="-1">
                                             </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 208px; background-color: beige">
                                Date Of Join</td>
                            <td style="width: 146px">
                                <asp:TextBox ID="txtempdoj" runat="server"></asp:TextBox>
                                <cc1:calendarextender id="ccemp" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                    popupbuttonid="txtempdoj" targetcontrolid="txtempdoj">
                                            </cc1:calendarextender>
                            </td>
                            <asp:RequiredFieldValidator ID="rf17" runat="server" ControlToValidate="txtempdoj"
                                ErrorMessage="*">
                                            </asp:RequiredFieldValidator></tr>
                          <tr>
                            <td style="width: 208px; background-color: beige">
                                Date Of Service
                            </td>
                            <td style="width: 146px">
                                <asp:TextBox ID="txtdos" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdos" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 208px; background-color: beige">
                                Employee type</td>
                            <td style="width: 146px">
                                <asp:DropDownList ID="demptype" runat="server" AppendDataBoundItems="true" DataSourceID="d_emptype"
                                    DataTextField="emptype" DataValueField="emptype" Font-Size="X-Small" Width="184px">
                                    <asp:ListItem Selected="" Value="-1">--Select Emptype--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="demptype"
                                    ErrorMessage="*" InitialValue="-1">
                                             </asp:RequiredFieldValidator><asp:SqlDataSource ID="d_emptype" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT [emptype] FROM [emp_emptype]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 208px; height: 30px; background-color: beige">
                                contract Period</td>
                            <td style="width: 146px; height: 30px">
                                <asp:TextBox ID="txtempcontract" runat="server">0</asp:TextBox>Month(s)&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtempcontract"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" SetFocusOnError="True"
                                    ValidationExpression="^\d*$">* Enter numeric fields only</asp:RegularExpressionValidator>
                            </td>
                            <td style="height: 30px">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="btnuploadpic" runat="server" CausesValidation="False" Height="22px"
                                    Text="Upload..." /><br />
                                <asp:Label ID="lblfile" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnloff" runat="server" GroupingText="OFFICIAL DETAILS">
                    <table style="width: 844px">
                        <tr>
                            <td style="width: 158px; background-color: beige">
                                staying in hostel</td>
                            <td style="width: 100px">
                                <asp:RadioButtonList ID="rdhostel" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="width: 100px; background-color: beige">
                                Hostel Name</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="dehosname" runat="server" AppendDataBoundItems="true" DataSourceID="d_hostelname"
                                    DataTextField="hostelname" DataValueField="hostelname" Font-Size="X-small" Width="184px">
                                    <asp:ListItem Selected="" Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="d_hostelname" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT [hostelname] FROM [emp_hostel]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 158px; background-color: beige">
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
                            <td style="width: 158px; background-color: beige">
                                Route</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="deroute" runat="server" AppendDataBoundItems="true" DataSourceID="d_route"
                                    DataTextField="route" DataValueField="route" Font-Size="X-small" Width="184px">
                                    <asp:ListItem Selected="" Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="d_route" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT [route] FROM [trans_routemaster]"></asp:SqlDataSource>
                            </td>
                            <td style="width: 100px; background-color: beige">
                                Area
                            </td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="deArea" runat="server" AppendDataBoundItems="true" DataSourceID="d_area"
                                    DataTextField="area" DataValueField="area" Font-Size="X-small" Width="168px">
                                    <asp:ListItem Selected="" Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="d_area" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                    SelectCommand="SELECT [area] FROM [trans_areamaster]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 158px; background-color: beige">
                                foreign Worker</td>
                            <td style="width: 100px">
                                <asp:RadioButtonList ID="rdforeign" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="width: 100px; background-color: beige">
                                Passport No</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtpassport" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 158px; background-color: beige">
                                Old ICNO.</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtoldic" runat="server">0</asp:TextBox></td>
                            <td style="width: 100px; background-color: beige">
                                New ICNO.</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtnewic" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 158px; background-color: beige">
                                AccountNo.</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtaccount" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtaccount"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px; background-color: beige">
                                Bank Name</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="Debank" runat="server" Font-Size="X-small" Width="160px">
                                    <asp:ListItem Selected="True">CIMB</asp:ListItem>
                                    <asp:ListItem Value="May">MAY BANK</asp:ListItem>
                                    <asp:ListItem Value="BSN">BANK SIMPANAN NASIONAL</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 158px; background-color: beige">
                                EPF No.</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtepf" runat="server">0</asp:TextBox>
                            </td>
                            <td style="width: 100px; background-color: beige">
                                SOSCO</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtsosco" runat="server">0</asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlpersonal" runat="server" GroupingText="PERSONAL DETAILS">
                    <table style="width: 838px">
                        <tr>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Date of birth</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="Txtdob" runat="server" Width="83px"></asp:TextBox>
                                <cc1:calendarextender id="CalendarExtender1" runat="server" cssclass="cal_Theme1"
                                    format="dd/MM/yy" popupbuttonid="Txtdob" targetcontrolid="Txtdob">
                                            </cc1:calendarextender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtdob"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px; height: 21px; background-color: beige;">
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
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Gender</td>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                <asp:RadioButtonList ID="Rdgender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="F">Female</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Blood Group</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="txtblood" runat="server" Width="83px">-</asp:TextBox></td>
                            <td style="width: 100px; height: 21px; background-color: beige;">
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
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Race</td>
                            <td style="width: 100px; height: 21px">
                                <asp:DropDownList ID="derace" runat="server" Font-Size="X-small" Width="104px">
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
                            <td style="width: 100px; background-color: beige;">
                                Marital Status</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="demarital" runat="server" Font-Size="X-small" Width="96px">
                                    <asp:ListItem Value="Married">MARRIED</asp:ListItem>
                                    <asp:ListItem Value="Single">SINGLE</asp:ListItem>
                                    <asp:ListItem Value="Divorced">DIVORCED</asp:ListItem>
                                    <asp:ListItem Value="Widow">WIDOW</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; background-color: beige;">
                                No.of children</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtchildren" runat="server" Width="87px">0</asp:TextBox></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 26px; background-color: beige;">
                                Address1</td>
                            <td style="width: 100px; height: 26px;">
                                <asp:TextBox ID="txtadrs1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtadrs1"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            <td style="width: 100px; height: 26px; background-color: beige;">
                                Address2</td>
                            <td style="width: 100px; height: 26px;">
                                <asp:TextBox ID="Txtadrs2" runat="server" TextMode="MultiLine">0</asp:TextBox></td>
                            <td style="width: 100px; height: 26px; background-color: beige;">
                                Address3</td>
                            <td style="width: 100px; height: 26px;">
                                <asp:TextBox ID="Txtadrs3" runat="server" TextMode="MultiLine">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Postcode</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="Txtposcode" runat="server" Width="94px">0</asp:TextBox></td>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Telephone(Resi)</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="Txtphone" runat="server" Width="121px">0</asp:TextBox></td>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                HandPhone</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="Txthp" runat="server" Width="126px">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; background-color: beige;">
                                Email</td>
                            <td colspan="5">
                                <asp:TextBox ID="txtemail" runat="server" Width="355px">0</asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlunifom" runat="server" GroupingText="Uniform Size Details">
                    <table style="width: 831px">
                        <tr>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Trousers</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="Txttrousers" runat="server" Text="0" Width="121px"></asp:TextBox></td>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                Shoes</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="txtshoes" runat="server" Text="0" Width="121px"></asp:TextBox></td>
                            <td style="width: 100px; height: 21px; background-color: beige;">
                                T-Shirts</td>
                            <td style="width: 100px; height: 21px">
                                <asp:TextBox ID="txtshirt" runat="server" Text="0" Width="121px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; background-color: beige;">
                                No.of trousers Issued</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtnotrousers" runat="server" Text="0" Width="121px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnotrousers"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" SetFocusOnError="True"
                                    ValidationExpression="^\d*$">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                            <td style="width: 100px; background-color: beige;">
                                No.of shoes Issued</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtnoshoes" runat="server" Text="0" Width="121px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtnoshoes"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" SetFocusOnError="True"
                                    ValidationExpression="^\d*$">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                            <td style="width: 100px; background-color: beige;">
                                No.of shirt Issued</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtnoshirt" runat="server" Text="0" Width="121px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtnoshirt"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" SetFocusOnError="True"
                                    ValidationExpression="^\d*$">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 40px; background-color: beige;">
                                No.of Jacket Issued</td>
                            <td style="width: 100px; height: 40px;">
                                <asp:TextBox ID="txtnojacket" runat="server" Text="0" Width="121px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtnojacket"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" SetFocusOnError="True"
                                    ValidationExpression="^\d*$">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                            <td style="width: 100px; height: 40px; background-color: beige;">
                                No.of Cap issued</td>
                            <td style="width: 100px; height: 40px;">
                                <asp:TextBox ID="txtnocap" runat="server" Text="0" Width="121px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtnocap"
                                    Display="Dynamic" ErrorMessage="RegularExpressionValidator" SetFocusOnError="True"
                                    ValidationExpression="^\d*$">* Enter numeric fields only</asp:RegularExpressionValidator></td>
                            <td style="width: 100px; height: 40px; background-color: beige;">
                                Date of uniform given</td>
                            <td style="width: 100px; height: 40px;">
                                <asp:TextBox ID="txtdou" runat="server" Text="0" Width="121px"></asp:TextBox>
                                <cc1:calendarextender id="CalendarExtender2" runat="server" cssclass="cal_Theme1"
                                    format="dd/MM/yy" popupbuttonid="txtdou" targetcontrolid="txtdou">
                                            </cc1:calendarextender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtdou"
                                    ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnledudet" runat="server" GroupingText="EDUCATION & WORK EXPERIENCE DETAILS">
                    <table style="width: 833px">
                        <tr>
                            <td style="width: 201px; height: 21px; background-color: beige">
                                Education Level</td>
                            <td style="width: 100px; height: 21px">
                                <asp:DropDownList ID="dElevel" runat="server" Font-Size="X-small" Width="144px">
                                    <asp:ListItem>SPM</asp:ListItem>
                                    <asp:ListItem>PMR</asp:ListItem>
                                    <asp:ListItem>DIPLOMA</asp:ListItem>
                                    <asp:ListItem>DEGREE</asp:ListItem>
                                    <asp:ListItem>MASTERS</asp:ListItem>
                                    <asp:ListItem>PHD</asp:ListItem>
                                    <asp:ListItem>BANGLADESH</asp:ListItem>
                                    <asp:ListItem>OTHERS</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 21px; background-color: beige">
                                If Others(specify)</td>
                            <td style="width: 318px; height: 21px">
                                <asp:TextBox ID="txteduothers" runat="server" Width="121px">-</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 201px; background-color: beige">
                                Work Area</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txteduwork" runat="server" TextMode="MultiLine">--</asp:TextBox>
                            </td>
                            <td style="width: 100px; background-color: beige">
                                Year of Experience</td>
                            <td style="width: 318px">
                                <asp:TextBox ID="txteduexp" runat="server" Width="121px">0</asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlaccess" runat="server" GroupingText="ACCESS">
                    <table style="width: 838px">
                        <tr>
                            <td style="width: 201px; height: 5px; background-color: beige" valign="middle">
                                Hand Phone Pass</td>
                            <td style="width: 100px; height: 5px" valign="middle">
                                &nbsp;<asp:RadioButtonList ID="rdhp" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="width: 100px; height: 5px; background-color: beige" valign="middle">
                                Car Pass</td>
                            <td style="width: 100px; height: 5px" valign="middle">
                                &nbsp;<asp:RadioButtonList ID="rdcar" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 201px; height: 28px; background-color: beige" valign="middle">
                                NoteBook Pass</td>
                            <td style="width: 100px; height: 28px" valign="middle">
                                &nbsp;<asp:RadioButtonList ID="rdnb" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="width: 100px; height: 28px; background-color: beige" valign="middle">
                                Remote Login</td>
                            <td style="width: 100px; height: 28px" valign="middle">
                                &nbsp;<asp:RadioButtonList ID="rdlogin" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" colspan="5">
                                <asp:Button ID="btnempsave" runat="server" SkinID="buttonskin1" Text="SAVE" />&nbsp;
                            </td>
                        </tr>
                    </table>
                    <cc1:calendarextender id="Calendarextender3" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                    popupbuttonid="txtdos" targetcontrolid="txtdos">
                    </cc1:CalendarExtender>
                     </asp:Panel>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>

</asp:Content>
