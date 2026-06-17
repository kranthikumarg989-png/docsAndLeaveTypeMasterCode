<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TCview.aspx.vb" Inherits="E_Management.TCview" 
    title="Travelling claim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <%--  &nbsp;<table>
        <tr>
            <td align="center" style="background-color: #eee9d5; height: 21px;">
                Depart@</td>
            <td align="center" style="background-color: beige; height: 21px;">
                Arrive@</td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>--%>
    <br />
    <table width="650">
        <tr>
            <td style="height: 246px">
                <table width="650">
                    <tr>
                        <td style="width: 100px; height: 42px">
                            <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/images/maruwa_a.JPG" /></td>
                        <td style="width: 100px; height: 42px">
                            <asp:Label ID="Label3" runat="server" Font-Size="Medium" Width="177px">TRAVELLING CLAIM</asp:Label></td>
                        <td style="width: 100px; height: 42px">
                            <asp:LinkButton ID="lbprint" runat="server" Font-Underline="True" ForeColor="#0000C0"
                                PostBackUrl="~/HRMIS/Business Trip/TCVIEW.aspx">Print</asp:LinkButton></td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="0" style="border-right: 1px solid; border-top: 1px solid;
                    font-size: 12pt; border-left: 1px solid; color: #000000; border-bottom: 1px solid;
                    font-family: Trebuchet MS" width="650">
                    <tr>
                        <td style="width: 165px; height: 27px; background-color: beige">
                            <asp:Label ID="Label1" runat="server" Text="Empcode"></asp:Label></td>
                        <td style="height: 27px">
                            :<asp:Label ID="lblemp" runat="server"></asp:Label></td>
                        <td style="width: 100px; height: 27px; background-color: beige">
                            <asp:Label ID="Label2" runat="server" Text="EmpName"></asp:Label></td>
                        <td style="height: 27px; wdth: 300px">
                            :<asp:Label ID="lblname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 165px; background-color: beige">
                            BT.No</td>
                        <td style="height: 23px">
                            :<asp:Label ID="lblbt" runat="server"></asp:Label></td>
                        <td style="width: 100px; height: 23px; background-color: beige">
                            Dept-Sect</td>
                        <td style="wdth: 300px">
                            :<asp:Label ID="lblds" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 165px; background-color: beige">
                            Share Dept(s).</td>
                        <td colspan="3" style="height: 21px">
                            :<asp:Label ID="tcdept" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 165px; background-color: beige">
                            Colleague Name(s)</td>
                        <td colspan="3">
                            :<asp:Label ID="tcname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 165px; background-color: beige">
                            Destination</td>
                        <td>
                            :<asp:Label ID="TCDEST" runat="server"></asp:Label></td>
                        <td style="background-color: beige">
                            Purpose</td>
                        <td>
                            :<asp:Label ID="tcpurpose" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 165px; background-color: beige">
                            Departed
                        </td>
                        <td>
                            :<asp:Label ID="lbldepart" runat="server" Text="Label"></asp:Label></td>
                        <td style="background-color: beige">
                            Arrived</td>
                        <td>
                            :<asp:Label ID="lblarrive" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 165px; background-color: beige">
                            Travelling Allowance</td>
                        <td colspan="2" style="width: 150px; background-color: beige">
                            :<asp:Label ID="lblallowance" runat="server" Text="Label"></asp:Label>
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 119px" valign="top">
                <table style="width: 650px">
                    <tr>
                        <td colspan="2">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

