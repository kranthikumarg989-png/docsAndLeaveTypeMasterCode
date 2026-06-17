<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TCPRINT.aspx.vb" Inherits="E_Management.TCPRINT" 
     title="Travelling claim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>


    <table width="700">
        <tr>
            <td style="height: 259px">
                   <table width="700">
                    <tr>
                        <td style="width: 100px; height: 42px;">
                            <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/images/maruwa_a.JPG" /></td>
                        <td style="width: 100px; height: 42px;">
                            <asp:Label ID="Label3" runat="server" Font-Size="Medium" Width="177px">TRAVELLING CLAIM</asp:Label></td>
                        <td style="width: 100px; height: 42px;">
                            <asp:LinkButton ID="lbprint" runat="server" Font-Underline="True" ForeColor="#0000C0"
                                PostBackUrl="~/HRMIS/Business Trip/TCPRINT.aspx">Print</asp:LinkButton></td>
                    </tr>
                </table>
                <table width="700" style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; 
                font-size: 10pt;" cellpadding="2" cellspacing="0" id="TABLE1" onclick="return TABLE1_onclick()">
                    <tr>
                        <td style="background-color: beige; ; width: 165px; height: 27px;">
                            <asp:Label ID="Label1" runat="server" Text="Empcode"></asp:Label></td>
                        <td style="height: 27px">
                            :<asp:Label ID="lblemp" runat="server"></asp:Label></td>
                        <td style="height: 27px; background-color: beige; width: 100px;">
                            <asp:Label ID="Label2" runat="server" Text="EmpName"></asp:Label></td>
                        <td style="wdth: 300px; height: 27px;">
                            :<asp:Label ID="lblname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px;">
                            BT.No</td>
                        <td style="height: 23px;">
                            :<asp:Label ID="lblbt" runat="server"></asp:Label></td>
                        <td style="height: 23px; background-color: beige; width: 100px;">
                            Dept-Sect</td>
                        <td style="wdth: 300px;">
                            :<asp:Label ID="lblds" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px;">
                            Share Dept(s).</td>
                        <td colspan="3" style="height: 21px">
                            :<asp:Label ID="tcdept" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px;">
                            Colleague Name(s)</td>
                        <td colspan="3">
                            :<asp:Label ID="tcname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige; width: 165px;" >
                            Destination</td>
                        <td>
                            :<asp:Label ID="TCDEST" runat="server"></asp:Label></td>
                        <td style="background-color: beige" >
                            Purpose</td>
                        <td >
                            :<asp:Label ID="tcpurpose" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
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
                        <td style="width: 165px; background-color: beige; height: 26px;">
                Travelling Allowance</td>
                        <td colspan="3" style="width: 150px; background-color: beige; height: 26px;">
                            :<asp:Label ID="lblallowance" runat="server" Text="Label"></asp:Label>
                             =<asp:Label ID="allowanceRM" runat="server" Text=""></asp:Label> RM@EXR(<asp:Label ID="lblex" runat="server"></asp:Label>)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 119px" align="left" valign="top">
    <table style="width: 700px">
        <tr>
            <td colspan="2">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" ></asp:PlaceHolder>
            </td>
        </tr>
        <tr>
         <td style="width: 165px; background-color: beige;  font-size: 10pt" >
             Remarks &nbsp; &nbsp; :<asp:Label ID="txtremarks" runat="server"></asp:Label></td>
         <td>
             </td>
     </tr>
        <tr>
            <td colspan="2" style=" font-size: 10pt">
                Approved By<br />
                <br />
                ------------------------------------<br />
                DATUK MANIMARAN ANTHONY</td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>
