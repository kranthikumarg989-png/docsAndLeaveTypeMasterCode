<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="WWTPlabTestEntry.aspx.vb" Inherits="E_Management.WWTPlabTestEntry" 
    title="WWTP Lab Test Entry Screen" %>
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
        <td align="center" colspan="1" valign="top" style="width: 875px">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="WWTP LAB TEST ENTRY SCREEN"></asp:Label></td>
    </tr>
        <tr>
            <td valign="top" align="center" style="width: 875px; height: 312px;">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1"><tr>
                    <td style="width: 96px; background-color: beige; height: 42px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Year"></asp:Label></td>
                    <td style="width: 285px;" valign="top" align="left" colspan="2">
                         <asp:DropDownList ID="year" runat="server" Width="174px">
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
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="year"
                                    ErrorMessage="Year !" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                        <td align="left" style="width: 96px; background-color: beige" valign="top">
                            <asp:Label ID="Label7" runat="server" Text="Month"></asp:Label></td>
                        <td align="left" valign="top" colspan="2">
                            <asp:DropDownList ID="month" runat="server" Width="153px">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            <asp:ListItem Value="Y">january</asp:ListItem>
                            <asp:ListItem Value="F">february</asp:ListItem>
                            <asp:ListItem Value="R">march</asp:ListItem>
                            <asp:ListItem Value="P">april</asp:ListItem>
                            <asp:ListItem Value="M">may</asp:ListItem>
                            <asp:ListItem Value="U">june</asp:ListItem>
                            <asp:ListItem Value="J">july</asp:ListItem>
                            <asp:ListItem Value="A">august</asp:ListItem>
                            <asp:ListItem Value="S">september</asp:ListItem>
                            <asp:ListItem Value="O">october</asp:ListItem>
                            <asp:ListItem Value="N">novomber</asp:ListItem>
                            <asp:ListItem Value="D">december</asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="month"
                                    ErrorMessage="Month !" InitialValue="-1"></asp:RequiredFieldValidator>
                            &nbsp;</td>
                </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 42px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Lab Name" Width="141px"></asp:Label></td>
                        <td style="width: 285px;" valign="top" align="left" colspan="2">
                            <asp:TextBox ID="labname" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="labname"
                                    ErrorMessage="Lab Name !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 96px; background-color: beige" valign="top">
                            <asp:Label ID="Label8" runat="server" Text="Sample Type" Width="109px"></asp:Label></td>
                        <td align="left" valign="top" colspan="2">
                            <asp:TextBox ID="samptyp" runat="server"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="samptyp"
                                    ErrorMessage="Sample Type !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 42px;" valign="top" align="left">
                            <asp:Label ID="Label4" runat="server" Text="Lab No."></asp:Label></td>
                        <td style="width: 285px;" valign="top" align="left" colspan="2">
                            <asp:TextBox ID="labno" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="labno"
                                    ErrorMessage="Lab No. !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 96px; background-color: beige" valign="top">
                            <asp:Label ID="Label13" runat="server" Text="Sample Taken"></asp:Label></td>
                        <td align="left" valign="top" colspan="2">
                            <asp:TextBox ID="samptkn" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="samptkn"
                                    ErrorMessage="Sample Taken !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 42px;" valign="top" align="left">
                            <asp:Label ID="Label5" runat="server" Text="Time Taken" Width="183px"></asp:Label></td>
                        <td style="width: 285px;" valign="top" align="left" colspan="2">
                            &nbsp;<asp:DropDownList ID="hrs" runat="server">
                                <asp:ListItem Value="0">0</asp:ListItem>
                                <asp:ListItem >1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>                                                                                
                            </asp:DropDownList>Hrs&nbsp;
                            <asp:DropDownList ID="mins" runat="server">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
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
                                <asp:ListItem>32</asp:ListItem>
                                <asp:ListItem>33</asp:ListItem>
                                <asp:ListItem>34</asp:ListItem>
                                <asp:ListItem>35</asp:ListItem>
                                <asp:ListItem>36</asp:ListItem>
                                <asp:ListItem>37</asp:ListItem>
                                <asp:ListItem>38</asp:ListItem>
                                <asp:ListItem>39</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>41</asp:ListItem>
                                <asp:ListItem>42</asp:ListItem>
                                <asp:ListItem>43</asp:ListItem>
                                <asp:ListItem>44</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                                <asp:ListItem>46</asp:ListItem>
                                <asp:ListItem>47</asp:ListItem>
                                <asp:ListItem>48</asp:ListItem>
                                <asp:ListItem>49</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>51</asp:ListItem>
                                <asp:ListItem>52</asp:ListItem>
                                <asp:ListItem>53</asp:ListItem>
                                <asp:ListItem>54</asp:ListItem>
                                <asp:ListItem>55</asp:ListItem>
                                <asp:ListItem>56</asp:ListItem>
                                <asp:ListItem>57</asp:ListItem>
                                <asp:ListItem>58</asp:ListItem>
                                <asp:ListItem>59</asp:ListItem>
                            </asp:DropDownList>Mins
                            <asp:DropDownList ID="am" runat="server" Width="49px">
                                <asp:ListItem>AM</asp:ListItem>
                                <asp:ListItem>PM</asp:ListItem>
                            </asp:DropDownList><asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Width="95px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="hrs"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" Width="93px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="mins"></asp:RegularExpressionValidator>
                        </td>
                        <td align="left" style="width: 96px; background-color: beige" valign="top">
                            <asp:Label ID="Label14" runat="server" Text="Taken By" Width="117px"></asp:Label></td>
                        <td align="left" valign="top" colspan="2">
                            <asp:TextBox ID="tknby" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tknby"
                                    ErrorMessage="Taken By !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 42px;" valign="top" align="left">
                            <asp:Label ID="Label6" runat="server" Text="WWTP No." Width="114px"></asp:Label></td>
                        <td style="width: 285px" valign="top" align="left" colspan="2">
                            <asp:TextBox ID="wwtpno" runat="server" Width="171px" MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="wwtpno"
                                    ErrorMessage="WWTP No. !" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 96px; background-color: beige" valign="top">
                            <asp:Label ID="Label15" runat="server" Text="Path"></asp:Label></td>
                        <td align="left" valign="top" colspan="2">
                            <asp:FileUpload ID="myfile" runat="server" /><%--<input id="Button1" type=button value="Upload" OnServerClick="Upload" runat="server">--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="myfile"
                                    ErrorMessage="Path !" InitialValue="-1"></asp:RequiredFieldValidator>--%></td>
                    </tr>
                </table>
                &nbsp;
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="samptkn">
                            </cc1:CalendarExtender>
                <br />
                <table style="text-align: left" border="1">
                    <tr>
                        <td style="height: 23px; background-color: beige;" valign="middle">
                            <span>
                            S.No.</span></td>
                        <td style="height: 23px; background-color: beige; width: 324px;">
                            <span>
                            PARAMETERS</span></td>
                        <td style="height: 23px; background-color: beige;">
                            <span>
                            METHOD</span></td>
                        <td style="height: 23px; background-color: beige;">
                            <span>
                            STD. B</span></td>
                        <td style="height: 23px; background-color: beige;">
                            <span>
                            RESULTS</span></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            1</td>
                        <td style="width: 324px; height: 21px">
                            PH Value</td>
                        <td style="width: 132px; height: 21px">
                            A 4500-B</td>
                        <td style="width: 56px; height: 21px">
                            100</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R1" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="R1"
                                    ErrorMessage="Result1 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            2</td>
                        <td style="width: 324px; height: 21px">
                            Biochemical Oxygen Demand @ 20 Deg.C for 5 days</td>
                        <td style="width: 132px; height: 21px">
                            A 5210-B</td>
                        <td style="width: 56px; height: 21px">
                            50</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R2" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="R2"
                                    ErrorMessage="Result2 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            3</td>
                        <td style="width: 324px; height: 21px">
                            Chemical Oxygen Demand</td>
                        <td style="width: 132px; height: 21px">
                            A 5220-D</td>
                        <td style="width: 56px; height: 21px">
                            100</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R3" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="R3"
                                    ErrorMessage="Result3 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            4</td>
                        <td style="width: 324px">
                            Total Suspended Solid</td>
                        <td style="width: 132px">
                            A 2540-D</td>
                        <td style="width: 56px">
                            100</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R4" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="R4"
                                    ErrorMessage="Result4 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            5</td>
                        <td style="width: 324px; height: 21px">
                            Mercury as Hg</td>
                        <td style="width: 132px; height: 21px">
                            A 3500-HG B</td>
                        <td style="width: 56px; height: 21px">
                            0.05</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R5" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="R5"
                                    ErrorMessage="Result5 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            6</td>
                        <td style="width: 324px">
                            Cadmium as Cd</td>
                        <td style="width: 132px">
                            A 3500-CD B</td>
                        <td style="width: 56px">
                            0.02</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R6" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="R6"
                                    ErrorMessage="Result6 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            7</td>
                        <td style="width: 324px">
                            Chromium as Cr,Hexa</td>
                        <td style="width: 132px">
                            A 3500-CR D</td>
                        <td style="width: 56px">
                            0.05</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R7" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="R7"
                                    ErrorMessage="Result7 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            8</td>
                        <td style="width: 324px">
                            Arsenic as As</td>
                        <td style="width: 132px">
                            A 3500-AS C</td>
                        <td style="width: 56px">
                            0.1</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R8" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="R8"
                                    ErrorMessage="Result8 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            9</td>
                        <td style="width: 324px">
                            Cyanide as CN</td>
                        <td style="width: 132px">
                            A 3500-CN C</td>
                        <td style="width: 56px">
                            0.1</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R9" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="R9"
                                    ErrorMessage="Result9 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            10</td>
                        <td style="width: 324px">
                            Lead as Pb</td>
                        <td style="width: 132px">
                            A 3500-PB B</td>
                        <td style="width: 56px">
                            0.5</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R10" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="R10"
                                    ErrorMessage="Result10 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            11</td>
                        <td style="width: 324px">
                            Chromium as Cr,Tri</td>
                        <td style="width: 132px">
                            A 3500-CR D</td>
                        <td style="width: 56px">
                            1.0</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R11" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="R11"
                                    ErrorMessage="Result11 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            12</td>
                        <td style="width: 324px; height: 21px">
                            Copper as Cu</td>
                        <td style="width: 132px; height: 21px">
                            A 3500-CU B</td>
                        <td style="width: 56px; height: 21px">
                            1.0</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R12" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="R12"
                                    ErrorMessage="Result12 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            13</td>
                        <td style="width: 324px">
                            Manganese as Mn</td>
                        <td style="width: 132px">
                            A 3500-MN B</td>
                        <td style="width: 56px">
                            1.0</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R13" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="R13"
                                    ErrorMessage="Result13 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            14</td>
                        <td style="width: 324px">
                            Nickel as Ni</td>
                        <td style="width: 132px">
                            A 3500-NI B</td>
                        <td style="width: 56px">
                            1.0</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R14" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="R14"
                                    ErrorMessage="Result14 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            15</td>
                        <td style="width: 324px">
                            Tin as Sn</td>
                        <td style="width: 132px">
                            A 3500-CU B</td>
                        <td style="width: 56px">
                            1.0</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R15" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="R15"
                                    ErrorMessage="Result15 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            16</td>
                        <td style="width: 324px; height: 21px">
                            Zinc as Zi</td>
                        <td style="width: 132px; height: 21px">
                            A 3500-ZN B</td>
                        <td style="width: 56px; height: 21px">
                            1.0</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R16" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="R16"
                                    ErrorMessage="Result16 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            17</td>
                        <td style="width: 324px; height: 21px">
                            Boron as B</td>
                        <td style="width: 132px; height: 21px">
                            A 4500-B C</td>
                        <td style="width: 56px; height: 21px">
                            4.0</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R17" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="R17"
                                    ErrorMessage="Result17 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            18</td>
                        <td style="width: 324px">
                            Iron as Fe</td>
                        <td style="width: 132px">
                            A 3500-FE B</td>
                        <td style="width: 56px">
                            5.0</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R18" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="R18"
                                    ErrorMessage="Result18 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            19</td>
                        <td style="width: 324px">
                            Phenol</td>
                        <td style="width: 132px">
                            A 5530- D</td>
                        <td style="width: 56px">
                            1.0</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R19" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="R19"
                                    ErrorMessage="Result19 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px; height: 21px">
                            20</td>
                        <td style="width: 324px; height: 21px">
                            Chlorine as C12</td>
                        <td style="width: 132px; height: 21px">
                            In House</td>
                        <td style="width: 56px; height: 21px">
                            2.0</td>
                        <td style="width: 268px; height: 21px">
                            <asp:TextBox ID="R20" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="R20"
                                    ErrorMessage="Result20 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            21</td>
                        <td style="width: 324px">
                            Sulogude as S</td>
                        <td style="width: 132px">
                            A 3500-S E</td>
                        <td style="width: 56px">
                            0.5</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R21" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="R21"
                                    ErrorMessage="Result21 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 48px">
                            22</td>
                        <td style="width: 324px">
                            Oil and Grease</td>
                        <td style="width: 132px">
                            A 5520 B</td>
                        <td style="width: 56px">
                            10</td>
                        <td style="width: 268px">
                            <asp:TextBox ID="R22" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="R22"
                                    ErrorMessage="Result22 !" ></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="SAVEWWT" runat="server" Text="SAVE" />
                &nbsp;<asp:Button ID="BACKWWT" runat="server" Text="BACK" /><br />
                <br />
                <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
            </td>
        </tr>
    <tr>
        <td align="center" style="height: 227px; width: 875px;" valign="top" colspan="1">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
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

