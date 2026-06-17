<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="WasteWaterMonitoring.aspx.vb" Inherits="E_Management.WasteWaterMonitoring" 
    title="Waste Water Monitoring Entry Screen" %>
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
          <td background="../../images/cen_lef.gif" style="height: 21px" width="16">
          </td>
          <td bgcolor="#ffffff" style="width: 1262px; height: 21px; text-align: center" valign="top">
          </td>
          <td background="../../images/cen_rig.gif" style="width: 24px; height: 21px">
          </td>
      </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table id="TABLE2">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 707px">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="WASTE WATER MONITORING ENTRY SCREEN"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 707px; height: 227px; text-align: left;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1" style="text-align: left"><tr>
                    <td style="width: 96px; background-color: beige; height: 20px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Year"></asp:Label></td>
                    <td style="width: 227px;" valign="top" align="left">
                        <asp:DropDownList ID="year" runat="server" Width="154px">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            <asp:ListItem>2000</asp:ListItem>
                            <asp:ListItem>2001</asp:ListItem>
                            <asp:ListItem>2002</asp:ListItem>
                            <asp:ListItem>2003</asp:ListItem>
                            <asp:ListItem>2004</asp:ListItem>
                            <asp:ListItem>2005</asp:ListItem>
                            <asp:ListItem>2006</asp:ListItem>
                            <asp:ListItem>2007</asp:ListItem>
                            <asp:ListItem>2008</asp:ListItem>
                            <asp:ListItem>2009</asp:ListItem>
                            <asp:ListItem>2010</asp:ListItem>
                            <asp:ListItem>2011</asp:ListItem>
                            <asp:ListItem>2012</asp:ListItem>
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="year"
                                    ErrorMessage="Year !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td style="width: 96px; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label6" runat="server" Text="Month"></asp:Label></td>
                    <td style="width: 202px;" valign="top" align="left">
                        <asp:DropDownList ID="month" runat="server" Width="151px">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            <asp:ListItem Value="Y">January</asp:ListItem>
                            <asp:ListItem Value="F">February</asp:ListItem>
                            <asp:ListItem Value="R">March</asp:ListItem>
                            <asp:ListItem Value="P">April</asp:ListItem>
                            <asp:ListItem Value="M">May</asp:ListItem>
                            <asp:ListItem Value="U">June</asp:ListItem>
                            <asp:ListItem Value="J">July</asp:ListItem>
                            <asp:ListItem Value="A">August</asp:ListItem>
                            <asp:ListItem Value="S">September</asp:ListItem>
                            <asp:ListItem Value="O">October</asp:ListItem>
                            <asp:ListItem Value="N">November</asp:ListItem>
                            <asp:ListItem Value="D">December</asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="month"
                                    ErrorMessage="Month !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 28px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Day" Width="141px"></asp:Label></td>
                        <td style="width: 227px; height: 28px;" valign="top" align="left">
                            <asp:DropDownList ID="day" runat="server" Width="154px">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
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
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>26</asp:ListItem>
                                <asp:ListItem>27</asp:ListItem>
                                <asp:ListItem>28</asp:ListItem>
                                <asp:ListItem>29</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>31</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="day"
                                    ErrorMessage="Day !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td align="left" style="width: 96px; height: 28px; background-color: beige" valign="top">
                        <asp:Label ID="Label7" runat="server" Text="Incoming PH" Width="109px"></asp:Label></td>
                    <td align="left" style="width: 202px; height: 28px;" valign="top">
                        P1
                        <asp:TextBox ID="ip1" runat="server" Width="50px">P1:</asp:TextBox>&nbsp;
                        P2
                        <asp:TextBox ID="ip2" runat="server" Width="53px">P2:</asp:TextBox><%--<asp:RegularExpressionValidator id="RegularExpressionValidator7" runat="server" Width="92px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="ip1"></asp:RegularExpressionValidator><asp:RegularExpressionValidator id="RegularExpressionValidator8" runat="server" Width="93px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="ip2"></asp:RegularExpressionValidator>--%></td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 20px;" valign="top" align="left">
                            <asp:Label ID="Label4" runat="server" Text="Treated Water PH" Width="139px"></asp:Label></td>
                        <td style="width: 227px;" valign="top" align="left">
                            P1
                            <asp:TextBox ID="tp1" runat="server" Width="53px">P1:</asp:TextBox>&nbsp;
                            P2
                            <asp:TextBox ID="tp2" runat="server" Width="55px">P2:</asp:TextBox><%--<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" Width="92px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="tp1"></asp:RegularExpressionValidator><asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" Width="93px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="tp2"></asp:RegularExpressionValidator>--%></td>
                    <td style="width: 96px; background-color: beige;" valign="top" align="left">
                        <asp:Label ID="Label11" runat="server" Text="COD"></asp:Label></td>
                    <td style="width: 202px;" valign="top" align="left">
                        P1
                        <asp:TextBox ID="cp1" runat="server" Width="51px">P1:</asp:TextBox>&nbsp;
                        P2
                        <asp:TextBox ID="cp2" runat="server" Width="53px">P2:</asp:TextBox><%--<asp:RegularExpressionValidator id="RegularExpressionValidator10" runat="server" Width="92px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="cp1"></asp:RegularExpressionValidator><asp:RegularExpressionValidator id="RegularExpressionValidator11" runat="server" Width="93px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="cp2"></asp:RegularExpressionValidator>--%></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 96px; height: 20px; background-color: beige" valign="top">
                            <asp:Label ID="Label5" runat="server" Text="Plant No."></asp:Label></td>
                        <td align="left" style="width: 227px;" valign="top">
                            <asp:DropDownList ID="plantno" runat="server" Width="152px">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                <asp:ListItem Value="1">Plant 1</asp:ListItem>
                                <asp:ListItem Value="2">Plant 2</asp:ListItem>
                                <asp:ListItem>Plant1,Plant2</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="plantno"
                                    ErrorMessage="Plant No. !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                        <td align="left" style="text-align: center;" valign="middle" colspan="2">
                            <asp:Button ID="wwmsave" runat="server" Text="SAVE" />
                            &nbsp; &nbsp;
                           </td>
                    </tr>
                </table>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
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
