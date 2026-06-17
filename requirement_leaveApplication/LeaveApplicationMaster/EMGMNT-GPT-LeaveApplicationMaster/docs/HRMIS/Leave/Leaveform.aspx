<%@ Page Language="vb" AutoEventWireup="True" MasterPageFile="~/NewEMS.Master" CodeBehind="Leaveform.aspx.vb" Inherits="E_Management.Leaveform" 
    title="Leave Form" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="90%">
        <tr>
            <td style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td>
                <table width="100%">
                 
                    <tr>
                        <td style="height: 200px">
                            <asp:Panel ID="Panel1" runat="server" Font-Bold="True" Width="90%">
                                <%--<table width="90%">
                                    <tr>
                                        <td class="bg-primary" colspan="4" style="text-align: center">
                                            <span style="font-size: 12pt">
                         Leave Application</span></td>
                                    </tr>
                                    <tr>
                                        <td class="bg-primary" colspan="4">
                                            <span style="font-size: 12pt">My Leave Summary &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="#FFFFFF">LEAVE STATUS</asp:LinkButton></span></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 34px" bgcolor="#b9d1ea">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="ActiveCaptionText" Text="Annual Entitilement"
                                                Width="225px" CssClass="form-control" Height="20px" BackColor="#B9D1EA" Font-Size="9pt"></asp:Label></td>
                                        <td style="height: 34px" bgcolor="#b9d1ea">
                                            </td>
                                        <td style="height: 34px" bgcolor="#b9d1ea">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" Text="Medical Entitilement"
                                                Width="125px" CssClass="form-control" Height="20px" Font-Size="9pt" BackColor="#B9D1EA"></asp:Label></td>
                                        <td style="height: 34px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#b9d1ea">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" Text="Bal.Annual Leave"
                                                Width="225px" CssClass="form-control" Height="20px" Font-Size="9pt" BackColor="#B9D1EA"></asp:Label></td>
                                        <td bgcolor="#b9d1ea">
                                            </td>
                                        <td bgcolor="#b9d1ea">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Black" Text="Bal.Medical Leave"
                                                Width="125px" CssClass="form-control" Height="20px" Font-Size="9pt" BackColor="#B9D1EA"></asp:Label></td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#b9d1ea">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black" Text="Carry Forward"
                                                Width="225px" CssClass="form-control" Height="20px" Font-Size="9pt" BackColor="#B9D1EA"></asp:Label></td>
                                        <td bgcolor="#b9d1ea">
                                            </td>
                                        <td bgcolor="#b9d1ea">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" Text="Bal.Carry Forward"
                                                Width="125px" CssClass="form-control" Height="20px" Font-Size="9pt" BackColor="#B9D1EA"></asp:Label></td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" bgcolor="#b9d1ea">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" Text="Total Leave (Annual+Carry Forward)" CssClass="form-control" Width="225px" Height="20px" Font-Size="9pt" BackColor="#B9D1EA"></asp:Label></td>
                                        <td colspan="2" bgcolor="#b9d1ea">
                                            </td>
                                    </tr>
                                </table>--%>
                                
                                <table width="90%">
                                    <tr>
                                        <td colspan="5" rowspan="1" style="height: 18px; background-color: #cccccc; text-align: center">
                                            <asp:Label ID="Label1" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="14pt"
                                                ForeColor="Black" Height="20px" Text="LEAVE APPLICATION" Width="209px" BackColor="#CCCCCC" BorderColor="#CCCCCC"></asp:Label></td>
                                        <td colspan="1" rowspan="1" style="height: 18px; background-color: #cccccc; text-align: center">
                                        </td>
                                    </tr>
                                <tr>
                                <td style="height: 18px; background-color: #ccff99" rowspan="3">
                                    <asp:Label ID="Label11" runat="server" Text="Carry Forward Leave" BackColor="#CCFF99" BorderColor="#CCFF99"></asp:Label></td>
                                <td style="height: 18px; background-color: #ccff99">
                                    <asp:Label ID="Label12" runat="server" Text="Total Carry Forward" BackColor="#CCFF99" BorderColor="#CCFF99"></asp:Label></td>
                                <td style="height: 18px; background-color: #ccff99">
                                            <asp:Label ID="lbllcfwd" runat="server" Font-Bold="True" ForeColor="Black" CssClass="form-control" Width="50px" Height="15px" Font-Size="9pt" BackColor="#CCFF99" BorderColor="#CCFF99"></asp:Label></td>
                                    <td colspan="2" rowspan="2" style="background-color: #ccffff; text-align: center">
                                        <asp:Label ID="Label27" runat="server" CssClass="form-control"
                                            Font-Size="12pt" ForeColor="Black" Height="20px" Text="My Leave Summary" Width="150px" Font-Bold="True" BackColor="#CCFFFF" BorderColor="#CCFFFF"></asp:Label></td>
                                    <td colspan="1" rowspan="2" style="background-color: #c0c0ff; text-align: right">
                                        <asp:Label ID="NL1" runat="server" BackColor="#C0C0FF" BorderColor="#C0C0FF" CssClass="form-control"
                                            Font-Bold="True" Font-Size="12pt" ForeColor="Black" Height="20px" Text="Next Year Leave Summary"
                                            Width="200px"></asp:Label></td>
                                </tr>
                                
                                 <tr>
                                <td style="height: 18px; background-color: #ccff99">
                                    <asp:Label ID="Label13" runat="server" Text="Utilised" BackColor="#CCFF99" BorderColor="#CCFF99"></asp:Label></td>
                                <td style="height: 18px; background-color: #ccff99">
                                    <asp:Label ID="LblCFU" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="9pt"
                                        ForeColor="Black" Height="15px" Width="50px" BackColor="#CCFF99" BorderColor="#CCFF99"></asp:Label></td>
                                </tr>
                                
                                <tr>
                                <td style="height: 18px; background-color: #ccff99">
                                    <asp:Label ID="Label14" runat="server" Text="Balance" BackColor="#CCFF99" BorderColor="#CCFF99"></asp:Label></td>
                                <td style="height: 18px; background-color: #ccff99">
                                            <asp:Label ID="lbllbcfwd" runat="server" Font-Bold="True" ForeColor="Black" CssClass="form-control" Width="50px" Height="15px" Font-Size="9pt" BackColor="#CCFF99" BorderColor="#CCFF99"></asp:Label></td>
                                <td style="background-color: #ccffff">
                                    <asp:Label ID="Label20" runat="server" Text="Medical Leave" BackColor="#CCFFFF" BorderColor="#CCFFFF"></asp:Label></td>
                                    <td style="background-color: #ccffff">
                                    </td>
                                    <td style="background-color: #c0c0ff; text-align: right">
                                        <asp:Label ID="NL2" runat="server" BackColor="#C0C0FF" BorderColor="#C0C0FF" Text="Next Year Carry Forward Leave"
                                            Width="200px"></asp:Label></td>
                                </tr>
                                
                                 <tr>
                                <td style="background-color: #ffff99" rowspan="3">
                                    <asp:Label ID="Label15" runat="server" Text="Annual Leave" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label></td>
                                <td style="background-color: #ffff99">
                                    <asp:Label ID="Label16" runat="server" Text="Entitlement" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label></td>
                                <td style="background-color: #ffff99">
                                    <asp:Label ID="lbllannual" runat="server" CssClass="form-control" Font-Bold="True"
                                        Font-Size="9pt" ForeColor="Black" Height="15px" Width="50px" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label></td>
                                <td style="background-color: #ccffff">
                                    <asp:Label ID="Label23" runat="server" Text="Entitlement" BackColor="#CCFFFF" BorderColor="#CCFFFF"></asp:Label></td>
                                     <td style="background-color: #ccffff; text-align: left;">
                                            <asp:Label ID="lbllmedical" runat="server" Font-Bold="True" ForeColor="Black" CssClass="form-control" Width="50px" Height="15px" Font-Size="9pt" BackColor="#CCFFFF" BorderColor="#CCFFFF"></asp:Label></td>
                                     <td style="background-color: #c0c0ff; text-align: right">
                                         <asp:Label ID="NL3" runat="server" BackColor="#C0C0FF" BorderColor="#C0C0FF" CssClass="form-control"
                                             Font-Bold="True" Font-Size="9pt" ForeColor="Black" Height="15px" Width="50px"></asp:Label></td>
                                </tr>
                                    <tr>
                                        <td style="background-color: #ffff99">
                                            <asp:Label ID="Label17" runat="server" Text="Utilised" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label></td>
                                        <td style="background-color: #ffff99">
                                            <asp:Label ID="LblAU" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="9pt"
                                                ForeColor="Black" Height="15px" Width="50px" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label></td>
                                        <td style="background-color: #ccffff">
                                            <asp:Label ID="Label24" runat="server" Text="Utilised" BackColor="#CCFFFF" BorderColor="#CCFFFF"></asp:Label></td>
                                        <td style="background-color: #ccffff; text-align: left;">
                                            <asp:Label ID="LblMU" runat="server" Text="Utilised" Width="50px" BackColor="#CCFFFF" BorderColor="#CCFFFF" Height="15px" CssClass="form-control"></asp:Label></td>
                                        <td style="background-color: #c0c0ff; text-align: right">
                                            <asp:Label ID="NL4" runat="server" BackColor="#C0C0FF" BorderColor="#C0C0FF" Text="Next Year Annual Leave Entitlement"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #ffff99">
                                            <asp:Label ID="Label18" runat="server" Text="Balance" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label></td>
                                        <td style="background-color: #ffff99">
                                            <asp:Label ID="lbllbannual" runat="server" Font-Bold="True" ForeColor="Black" CssClass="form-control" Width="50px" Height="15px" Font-Size="9pt" BackColor="#FFFF99" BorderColor="#FFFF99"></asp:Label></td>
                                        <td style="background-color: #ccffff">
                                            <asp:Label ID="Label25" runat="server" Text="Balance" BackColor="#CCFFFF" BorderColor="#CCFFFF"></asp:Label></td>
                                        <td style="background-color: #ccffff; text-align: left;">
                                            <asp:Label ID="lbllbmedical" runat="server" Font-Bold="True" ForeColor="Black" CssClass="form-control" Width="50px" Height="15px" Font-Size="9pt" BackColor="#CCFFFF" BorderColor="#CCFFFF"></asp:Label></td>
                                        <td style="background-color: #c0c0ff; text-align: right">
                                            <asp:Label ID="NL5" runat="server" BackColor="#C0C0FF" BorderColor="#C0C0FF" CssClass="form-control"
                                                Font-Bold="True" Font-Size="9pt" ForeColor="Black" Height="15px" Width="50px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #cccccc; text-align: right;" colspan="2">
                                            <asp:Label ID="Label22" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="11pt"
                                                ForeColor="Black" Height="15px" Text="Total Entitlement Balance" Width="200px" BackColor="#CCCCCC" BorderColor="#CCCCCC"></asp:Label></td>
                                        <td style="background-color: #cccccc">
                                            <asp:Label ID="lbllprorate" runat="server" ForeColor="Black" CssClass="form-control" Width="50px" Font-Size="11pt" BackColor="#CCCCCC" BorderColor="#CCCCCC" Height="15px"></asp:Label></td>
                                            <td style="background-color: #cccccc" colspan="2">
                                            </td>
                                        <td colspan="1" style="background-color: #cccccc">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                            <asp:Label ID="lblmsg" runat="server" CssClass="form-control" Height="10px" Font-Size="9pt"></asp:Label></td>
                                        <td colspan="1">
                                        </td>
                                    </tr>
                                
                               
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" Font-Bold="True" Width="90%">
                                <table width="90%">
                                    <tr>
                                        <td colspan="2" class="bg-primary">
                                            <span style="font-size: 12pt">New Leave Details</span><%--                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fill in all  the Required (*) fields" />
--%></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#b9d1ea" class="bg " style="width: 200px">
                                    <asp:Label ID="Label10" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                                        Font-Size="9pt" ForeColor="Black" Height="20px" Text="Leave App No" Width="150px"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="gppassnum" runat="server" BackColor="ActiveCaption" Font-Size="11pt" CssClass="form-control" Width="147px" Height="20px" ForeColor="Black"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px" class="bg " bgcolor="#b9d1ea">
                                            <asp:Label ID="ddlltype" runat="server" Text="Leave Type" CssClass="form-control" Width="150px" Height="20px" Font-Size="9pt" ForeColor="Black" BackColor="#B9D1EA"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList  cssclass="form-control" ID="DropDownList1" runat="server" AutoPostBack="True" Height="20px" Width="300px" Font-Size="9pt" ForeColor="Black">
                                                <asp:ListItem Value="-1">- Select Leave type -</asp:ListItem>
                                                <asp:ListItem>Annual</asp:ListItem>
                                                <asp:ListItem>Calamity</asp:ListItem>
                                                <asp:ListItem Value="CompanyHoliday">Company Holiday</asp:ListItem>
                                                <asp:ListItem>Compassionate</asp:ListItem>
                                                <asp:ListItem Value="Emergency">Emergency - Annual</asp:ListItem>
                                                <asp:ListItem Value="EmergencyUP">EmergencyUnpaid</asp:ListItem>
                                                <asp:ListItem>Marriage-Children</asp:ListItem>
                                                <asp:ListItem>Maternity</asp:ListItem>
                                                <asp:ListItem>Medical</asp:ListItem>
                                                <asp:ListItem>Paternity</asp:ListItem>
                                                <asp:ListItem Value="PlanEmergency">Plan Emergency - Annual</asp:ListItem>
                                                <asp:ListItem Value="PlanEmergencyUP">Plan Emergency - Unpaid</asp:ListItem>
                                                <asp:ListItem>Unpaid</asp:ListItem>
                                                <asp:ListItem Value="Hospitalization">Hospitalization</asp:ListItem>
                                                <asp:ListItem Value="marriage-self">Marriage-Self</asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px" class="bg " bgcolor="#b9d1ea" >
                                            <asp:Label ID="Label8" runat="server" Text="Leave Period" Width="154px" CssClass="form-control" Height="20px" Font-Size="9pt" ForeColor="Black" BackColor="#B9D1EA"></asp:Label></td>
                                        <td>
                                            <table width="50">
                                                <tr>
                                                    <td>
                                            <asp:TextBox ID="txtlfrom" runat="server" Width="100px" CssClass="form-control" Height="20px" Font-Size="9pt" ForeColor="Black"></asp:TextBox></td>
                                                    <td style="width: 100px; text-align: center">
                                                        ~</td>
                                                    <td>
                                                        <asp:TextBox
                                                ID="txtlto" runat="server" Width="100px" CssClass="form-control" Height="20px" Font-Size="9pt" ForeColor="Black"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                            &nbsp;&nbsp;
                                        </td>
                                        <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                            popupbuttonid="txtlfrom" targetcontrolid="txtlfrom"></cc1:calendarextender>
                                        <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                            popupbuttonid="txtlto" targetcontrolid="txtlto"></cc1:calendarextender>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px" class="bg " bgcolor="#b9d1ea">
                                            <asp:Label ID="Label6" runat="server" Text="Half-DayLeave" Width="151px" CssClass="form-control" Height="20px" Font-Size="9pt" ForeColor="Black" BackColor="#B9D1EA"></asp:Label></td>
                                        <td style="width: 552px">
                                            &nbsp;<table>
                                                <tr>
                                                    <td style="width: 100px">
                                                        <asp:CheckBox ID="cbltype" runat="server" AutoPostBack="true" Checked="false" CssClass="form-control" Width="100px" Height="20px" Font-Size="9pt" ForeColor="Black" /></td>
                                                    <td style="width: 100px">
                                            <asp:DropDownList ID="ddlltime" runat="server" CssClass="form-control" Width="320px" Height="30px" Font-Size="9pt" ForeColor="Black">
                                                <asp:ListItem Value="-1">-Select Half Day Leave Time -</asp:ListItem>
                                                <asp:ListItem>07.30 AM - 11.30 AM</asp:ListItem>
                                                <asp:ListItem>08.00 AM - 12.00 PM</asp:ListItem>
                                                <asp:ListItem>11.30 AM - 03.30 PM</asp:ListItem>
                                                  <asp:ListItem>12.00 PM - 05.00 PM</asp:ListItem>
                                                <asp:ListItem>03.30 PM - 07.30 PM</asp:ListItem>
                                               
                                                <asp:ListItem>07.30 PM - 11.30 PM</asp:ListItem>
                                                <asp:ListItem Value="11.30 PM - 03.30 AM">11.30 PM - 03.30 AM</asp:ListItem>
                                                <asp:ListItem Value="03.30 AM - 07.30 AM">03.30 AM - 07.30 AM</asp:ListItem>
                                                <asp:ListItem Value="09.00 PM - 03.00 AM">09.00 PM - 03.00 AM</asp:ListItem>
                                                <asp:ListItem Value="03.00 AM - 09.00 AM">03.00 AM - 09.00 AM</asp:ListItem>
                                            </asp:DropDownList></td>
                                                </tr>
                                            </table>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px" class="bg " bgcolor="#b9d1ea">
                                            <asp:Label ID="lblldays" runat="server" Text="Leave Days" CssClass="form-control" Width="150px" Height="20px" Font-Size="9pt" ForeColor="Black" BackColor="#B9D1EA"></asp:Label></td>
                                        <td style="width: 552px">
                                            <asp:TextBox ID="txtlDays" runat="server" Width="100px" CssClass="form-control" Height="20px" Font-Size="9pt" ForeColor="Black" BorderStyle="Solid"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px" class="bg " bgcolor="#b9d1ea">
                                            <asp:Label ID="LblMedicalReason" runat="server" Text="Reason" CssClass="form-control" Width="150px" Height="20px" Font-Size="9pt" ForeColor="Black" BackColor="#B9D1EA"></asp:Label></td>
                                        <td style="height: 91px">
    
     <asp:DropDownList ID="CmbReason" runat="server" AutoPostBack="True" Width="320px" CssClass="form-control" Height="30px" Font-Size="9pt" ForeColor="Black">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtreason" runat="server" Height="35px" TextMode="MultiLine" Width="300px" CssClass="form-control" Font-Size="9pt" ForeColor="Black" BorderStyle="Solid"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: left">
                                            <asp:Label ID="Label4" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                                                Font-Size="9pt" ForeColor="Black" Height="20px" Text="Person in Charge When You are in Leave ! (One PIC is Must)"
                                                Width="597px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#b9d1ea" class="bg " style="width: 200px; text-align: left">
                                            <asp:Label ID="Label2" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                                                Font-Size="9pt" ForeColor="Black" Height="20px" Text="Person in Charge 1:" Width="150px"></asp:Label></td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="CmbEmployeeCode" runat="server" Font-Size="9pt" Width="300px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#b9d1ea" class="bg " style="width: 200px; text-align: left">
                                            <asp:Label ID="Label3" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                                                Font-Size="9pt" ForeColor="Black" Height="20px" Text="Person in Charge 2:" Width="150px"></asp:Label></td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="CmbEmployeeCode2" runat="server" Font-Size="9pt" Width="300px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="bg " style="width: 200px; text-align: left;">
                            <asp:Button ID="btnUpdate" runat="server" SkinID="buttonskin1" Text="UPDATE LEAVE" CssClass="form-control" Width="150px" ForeColor="Black" />
                                            </td>
                                        <td style="text-align: center">
                            <asp:Button ID="btnlsave" runat="server" SkinID="buttonskin1" Text="APPLY LEAVE" CssClass="form-control" Width="150px" Font-Bold="True" ForeColor="Black" /></td>
                                    </tr>
                                </table>
                                &nbsp;</asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: 12pt" class="bg-primary">
                            <p style="text-decoration: underline">
                                Conditions For Applying Annual Leave</p>
                            1. For Half a day - Should apply one day before<br />
                            2. For one day - Should apply three days before
                            <br />
                            3. More than one day - Should apply seven days before
                            <br />
                        </td>
                    </tr>
                </table>
                                           </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td>
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td>
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
