<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master"  CodeBehind="memoentry.aspx.vb" Inherits="E_Management.memoentry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
     <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 120px; position: relative; top: 30px" Text="Memo application" BackColor="Beige" Width="109px" BorderColor="SkyBlue"></asp:Label>
    <cc1:CalendarExtender ID="CalendarExtender1"  TargetControlID="textbox5"  runat="server">
    </cc1:CalendarExtender>
    <table style="z-index: 101; left: 119px; width: 573px; position: relative; top: 44px" bordercolor="skyblue">
        <tr>
            <td style="width: 70px; height: 21px; background-color:beige" align="right">Serial No</td>
            <td style="width: 31px; height: 21px; background-color:beige"><asp:Label ID="serialno" runat="server"></asp:Label></td>
            <td style="width: 107px; color: #000000; height: 21px; background-color:beige" align="right">Employee No</td>
            <td style="width: 43px; height: 21px; background-color:beige">
                <asp:Label ID="employeeno" runat="server" Width="88px"></asp:Label>
            </td>
        </tr>
        <tr><td style="width: 70px; height: 21px; background-color:beige" align="right">Emp Name</td>
            <td style="width: 31px; height: 21px; background-color:beige">
                <asp:Label ID="empname" runat="server"></asp:Label></td>
            <td style="width: 107px; height: 21px; background-color:beige" align="right">Your Department</td>
            <td style="width: 43px; height: 21px; background-color:beige">
                <asp:Label ID="yourdepartment" runat="server"></asp:Label></td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;
            
    <table style="z-index: 102; left: 119px; width: 573px; position: relative; top: 30px; height: 115px;" bordercolor="skyblue">
        <tr>
        <td style="width: 75px; height: 171px; background-color:beige"><asp:Label ID="Label2" runat="server" Text="Select Date" style="z-index: 100; left: 5px; position: absolute; top: 5px" Width="77px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox5" runat="server" style="z-index: 101; left: 90px; position: absolute; top: 5px" Height="16px" Width="154px" ForeColor="DimGray"></asp:TextBox>
            <asp:Label ID="memotime" runat="server" style="z-index: 102; left: 3px; position: absolute; top: 53px" Width="88px" ></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5"
                ErrorMessage="RequiredFieldValidator" Style="z-index: 104; left: 5px; position: absolute;
                top: 27px" Width="81px">* Select date</asp:RequiredFieldValidator>
        </td>      
            <td style="width:93px; height: 171px; background-color:beige" align="right">
                <asp:Label ID="Label3" runat="server" Text="Send To" style="z-index: 100; left: 258px; position: absolute; top: 6px" Width="52px"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ListBox1"
                    ErrorMessage="RequiredFieldValidator" Style="z-index: 101; left: 579px; position: absolute;
                    top: 4px" Width="118px" Height="4px">* select department</asp:RequiredFieldValidator>
                <asp:ListBox ID="ListBox1" runat="server" style="z-index: 102; left: 312px; position: absolute; top: 6px" Height="145px" SelectionMode="Multiple" Width="256px" Font-Size="X-Small">
                    <asp:ListItem>Select here(single or multiple) department</asp:ListItem>
                </asp:ListBox>
                &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox1" runat="server" style="z-index: 104; left: 260px; position: absolute; top: 154px" Text="Select for All department" Width="173px" AutoPostBack="True" />
                &nbsp;&nbsp;
            </td>
        </tr>    
    </table>
     <table style="z-index: 103; left: 119px; width: 575px; position: relative; top: 34px; height: 37px;" bordercolor="skyblue">
        <tr>
            <td style="width: 95px; background-color:beige; height: 33px;" align="right">Subject</td>
            <td style="width: 88px; background-color:beige; height: 33px;" align="center" ><asp:TextBox ID="TextBox1" runat="server" Width="460px" Height="19px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="RequiredFieldValidator" Style="z-index: 100; left: 578px; position: absolute;
                    top: 0px" Width="97px">* Enter subject</asp:RequiredFieldValidator>
            </td>
            </tr>
            </table>
            <table style="z-index: 104; left: 120px; width: 573px; position: relative; top: 39px; height: 1px;" bordercolor="skyblue">
        <tr>
            <td style="background-color:beige; height: 223px; width: 152px;" align="right">Memo Paragraph 1</td>
            <td align="center" style="width: 1192px; height: 223px; background-color:beige" >
                <asp:TextBox ID="paragraph1" runat="server" Height="205px" Style="z-index: 100; left: 106px;
                    position: absolute; top: 9px" TextMode="MultiLine" Width="454px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="paragraph1"
                    ErrorMessage="RequiredFieldValidator" Style="z-index: 102; left: 574px; position: absolute;
                    top: 2px" Width="127px">* Type memo details</asp:RequiredFieldValidator>
            </td>
            </tr>
            </table>
    &nbsp;&nbsp;
             <table style="z-index: 105; left: 119px; width: 573px; position: relative; top: 26px; height: 1px;" bordercolor="skyblue">
        <tr>
            <td style="background-color:beige; height: 182px; width: 152px;" align="right">Memo Paragraph 2</td>
            <td align="center" style="width: 1192px; height: 182px; background-color:beige" >
                <asp:TextBox ID="paragraph2" runat="server" Height="163px" Style="z-index: 100; left: 106px;
                    position: absolute; top: 9px" TextMode="MultiLine" Width="454px"></asp:TextBox>
            </td>
            </tr>
            </table>
             <table style="z-index: 106; left: 118px; width: 573px; position: relative; top: 32px; height: 1px;" bordercolor="skyblue">
        <tr>
            <td style="background-color:beige; height: 176px; width: 152px;" align="right">Memo Paragraph 3</td>
            <td align="center" style="width: 1192px; height: 176px; background-color:beige" >
                <asp:TextBox ID="paragraph3" runat="server" Height="163px" Style="z-index: 100; left: 106px;
                    position: absolute; top: 9px" TextMode="MultiLine" Width="454px"></asp:TextBox>
            </td>
            </tr>
            </table>
            <table style="z-index: 107; left: 117px; width: 574px; position: relative; top: 37px; height: 1px;" bordercolor="skyblue">
        <tr>
            <td style="background-color:beige; width: 8988px; height: 28px;" align="right">Signature</td>
             <td style="background-color:beige; width: 73252px; height: 28px;" align="center">
                 &nbsp;
                 <asp:Label ID="signature" runat="server" Style="z-index: 102; left: 104px; position: absolute;
                     top: 7px" Text="signature of employee" Width="303px"></asp:Label>
             </td>
              <td style="background-color:beige; width: 8388px; height: 28px;" align="center" > <asp:Button ID="Button1" runat="server" Text="Save" BackColor="Beige" BorderColor="#E0E0E0" />
                 
              </td>
               <td  bgcolor="beige" align="center" >
                   <input type="button" value="Exit" onclick="window.close()" style="background-color: beige"></td>
            </tr>
            </table>
      <br />
    <br />    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    &nbsp;<br />
    <br />
</asp:Content>

