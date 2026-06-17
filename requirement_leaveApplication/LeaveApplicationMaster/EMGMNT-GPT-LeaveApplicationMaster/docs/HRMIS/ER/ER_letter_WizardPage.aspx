<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master"  CodeBehind="ER_letter_WizardPage.aspx.vb" Inherits="E_Management.ER_letter_WizardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
                          <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 381px; position: relative;
                        top: 10px" Text="ER" Width="26px"></asp:Label>
    &nbsp;
        <asp:Label ID="Label2" runat="server" Style="z-index: 102; left: 242px; position: relative;
            top: 10px" Text="LETTER TYPE" Width="100px"></asp:Label>
    <table border="1" cellpadding="1" cellspacing="1" style="z-index: 102; left: 279px;
            width: 500px; position: relative; top: 12px; height: 112px" bordercolor="#191970">
            <tr>
                <td style="height: 26px" colspan="3">
                    &nbsp;Enter Letter Name&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 141px; position: absolute;
                        top: 5px" Width="345px" AutoPostBack="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="RequiredFieldValidator" Style="z-index: 102; left: 500px; position: absolute;
                        top: 5px" Width="123px">* Enter letter name </asp:RequiredFieldValidator>
                    <strong></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 83px">
                    Select Fields to be
                    <br />
                    added in Letter
                    <asp:ListBox ID="ListBox1" runat="server" Font-Size="Small" Height="80px" SelectionMode="Multiple"
                        Style="z-index: 100; left: 141px; position: absolute; top: 36px" Width="163px"></asp:ListBox>
                         </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 26px; text-align: center">
                    &nbsp;<strong>Key in Fields Name to be added in Letter</strong></td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px; text-align: center">
                    <strong>
                    Serial No</strong></td>
                <td style="width: 325px; height: 26px; text-align: center">
                    Ent<strong>er the Name</strong></td>
                <td style="width: 333px; height: 26px; text-align: center">
                    <strong>Select Any Type</strong></td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    1</td>
                <td style="width: 325px; height: 26px" align="right">
                    <asp:TextBox ID="TextBox2" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 187px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px" >
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 183px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    2</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox3" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 217px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px" >
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 214px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    3</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox4" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 248px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 246px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
             4</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox5" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 279px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 278px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    5</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox6" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 309px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 309px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    6</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox7" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 341px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 339px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    7</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox8" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 372px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 290px; position: absolute; top: 368px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    8</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox9" runat="server" Style="z-index: 100; left: 92px; position: absolute;
                        top: 402px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 400px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    9</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox10" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 434px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 431px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 114px; height: 26px" align="center">
                    10</td>
                <td style="width: 325px; height: 26px" align="center">
                    <asp:TextBox ID="TextBox11" runat="server" Style="z-index: 100; left: 93px; position: absolute;
                        top: 465px" Width="184px"></asp:TextBox>
                </td>
                <td style="width: 333px; height: 26px" >
                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal"
                        Style="z-index: 100; left: 291px; position: absolute; top: 462px">
                        <asp:ListItem>Text Box</asp:ListItem>
                        <asp:ListItem>Text Area</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 26px">
                    <asp:Button ID="Button1" runat="server" Style="z-index: 100; left: 292px; position: absolute;
                        top: 495px" Text="Save && Next" BackColor="LightSteelBlue" BorderColor="LightSteelBlue" Width="102px" />
                </td>
            </tr>
        </table>         
    <br />
    <br />
    <br />
       </asp:Content>
