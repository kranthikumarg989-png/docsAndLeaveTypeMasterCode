<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="PickUpTimemaster.aspx.vb" Inherits="E_Management.PickUpTimemaster" 
%>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;<table style="width: 318px">
        <tr>
            <td class="td_head" colspan="4" style="height: 17px">
                PICK UP TIME MASTER</td>
        </tr>
        <tr>
            <td style="width: 86px; height: 17px">
                Select route</td>
            <td colspan="3" style="height: 17px">
                <asp:DropDownList ID="ddlroute" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1"
                    DataTextField="route" DataValueField="route" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="-1">--Select route--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlroute"
                    ErrorMessage="Select route" InitialValue="-1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 86px; height: 24px">
                Select area</td>
            <td colspan="3" style="height: 24px">
                <asp:DropDownList ID="ddlarea" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2"
                    DataTextField="area" DataValueField="area" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="-1">--Select area--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlarea"
                    ErrorMessage="Select area" InitialValue="-1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">
                TIME DETAILS</td>
        </tr>
        <tr>
            <td align="center" style="width: 86px; color: maroon; height: 18px; text-decoration: underline">
                Shift</td>
            <td align="center" style="width: 48px; color: maroon; height: 18px; text-decoration: underline">
                Hr</td>
            <td align="center" style="width: 49px; color: maroon; height: 18px; text-decoration: underline">
                Min</td>
            <td align="center" style="width: 86px; color: maroon; height: 18px; text-decoration: underline">
                AM/PM</td>
        </tr>
        <tr>
            <td align="center" style="width: 86px; height: 17px">
                Shift A</td>
            <td align="center" style="width: 48px; height: 17px">
                <asp:DropDownList ID="ddlahr" runat="server">
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
                    <asp:ListItem Selected="True" Value="00">-</asp:ListItem>
                </asp:DropDownList></td>
            <td align="center" style="width: 49px; height: 17px">
                <asp:DropDownList ID="ddlamin" runat="server">
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem Selected="True">00</asp:ListItem>
                
                    
                </asp:DropDownList></td>
            <td align="center" style="width: 34px; height: 17px">
                <asp:DropDownList ID="ddlaam" runat="server">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="center" style="width: 86px; height: 24px;">
                shift B</td>
            <td align="center" style="width: 48px; height: 24px;">
                <asp:DropDownList ID="ddlbhr" runat="server">
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
                      <asp:ListItem Selected="True" Value="00">-</asp:ListItem>
                </asp:DropDownList></td>
            <td align="center" style="width: 49px; height: 24px;">
                <asp:DropDownList ID="ddlbmin" runat="server">
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                   <asp:ListItem Selected="True">00</asp:ListItem>
      
                </asp:DropDownList></td>
            <td align="center" style="width: 34px; height: 24px;">
                <asp:DropDownList ID="ddlbam" runat="server">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="center" style="width: 86px">
                Shift C</td>
            <td align="center" style="width: 48px">
                <asp:DropDownList ID="ddlchr" runat="server">
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
                           <asp:ListItem Selected="True" Value="00">-</asp:ListItem>
                    
                </asp:DropDownList></td>
            <td align="center" style="width: 49px">
                <asp:DropDownList ID="ddlcmin" runat="server">
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
              <asp:ListItem Selected="True">00</asp:ListItem>

                </asp:DropDownList></td>
            <td align="center" style="width: 34px">
                <asp:DropDownList ID="ddlcam" runat="server">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="center" style="width: 86px">
                Shift M</td>
            <td align="center" style="width: 48px">
                <asp:DropDownList ID="ddlmhr" runat="server">
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
                           <asp:ListItem Selected="True" Value="00">-</asp:ListItem>
                </asp:DropDownList></td>
            <td align="center" style="width: 49px">
                <asp:DropDownList ID="ddlmmin" runat="server">
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                  <asp:ListItem Selected="True">00</asp:ListItem>
               
                </asp:DropDownList></td>
            <td align="center" style="width: 34px">
                <asp:DropDownList ID="ddlmam" runat="server">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="center" style="width: 86px">
                Shift N</td>
            <td align="center" style="width: 48px">
                <asp:DropDownList ID="ddlnhr" runat="server">
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
                      <asp:ListItem Selected="True" Value="00">-</asp:ListItem>
                </asp:DropDownList></td>
            <td align="center" style="width: 49px">
                <asp:DropDownList ID="ddlnmin" runat="server">
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                <asp:ListItem Selected="True">00</asp:ListItem>
              
                </asp:DropDownList></td>
            <td align="center" style="width: 34px">
                <asp:DropDownList ID="ddlnam" runat="server">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 86px">
            </td>
            <td style="width: 48px">
            </td>
            <td style="width: 49px">
            </td>
            <td align="right" style="width: 34px">
                <asp:Button ID="BTNADD" runat="server" SkinID="buttonskin1" Text="ADD" Width="40px" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label></td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [area] FROM [trans_areamaster] ORDER BY [area]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [route] FROM [trans_routemaster] ORDER BY [route]"></asp:SqlDataSource>
</asp:Content>
