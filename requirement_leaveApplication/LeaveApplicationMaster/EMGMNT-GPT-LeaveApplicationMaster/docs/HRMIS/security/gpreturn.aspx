<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="gpreturn.aspx.vb"  Inherits="E_Management.gpreturn" title="Gatepassreturn"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:Label id="Label1" runat="server" ForeColor="#C00000" Font-Bold="True" Text="GATEPASS RETURN" Font-Underline="True"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" ShowFooter="True" AllowPaging="True" BorderColor="Gray" CaptionAlign="Left" PageSize="25">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="passno" HeaderText="Passno" SortExpression="passno" />
            <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
            <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
            <asp:BoundField DataField="ds" HeaderText="Dept-Sect" SortExpression="ds" />
            <asp:BoundField DataField="outdate" HeaderText="Outdate" SortExpression="outdate" DataFormatString="{0:dd/MM/yy}"  HtmlEncode="false"  />
             <asp:BoundField DataField="intime" HeaderText="Intime" SortExpression="intime" dataformatstring="{0:t}"  HtmlEncode="false"  />
               <asp:BoundField DataField="pvehicleno" HeaderText="Vehicleno" SortExpression="pvehicleno"/>
            <asp:TemplateField HeaderText="VehicleMeter &lt;br&gt; Reading" SortExpression="speedofmeterin">
            <ItemTemplate>
            <asp:TextBox ID="TextBox1" runat="server" Width="80px" Text='<%# Bind("speedofmeterin") %>' BorderColor="Black" BorderWidth="1px"></asp:TextBox>
                </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="intime" HeaderText="Approvedtimein" SortExpression="intime" dataformatstring="{0:t}"/>
               <asp:TemplateField HeaderText="ActualTimein">
              
                <ItemTemplate>
                    <asp:DropDownList ID="hrs1" runat="server" Width="40px">
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
                    </asp:DropDownList><asp:DropDownList ID="mints1" runat="server" Width="42px">
                        <asp:ListItem>00</asp:ListItem>
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
                    </asp:DropDownList><asp:DropDownList ID="ampm1" runat="server" Width="44px">
                        <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>PM</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Return">
                <EditItemTemplate>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="cb1" runat="server" />
                </ItemTemplate>
                 <FooterTemplate>
                    <asp:Button ID="Button1" OnClick="UpdategpApproval" runat="server" Text="Submit" BackColor="LightSteelBlue" />
                </FooterTemplate>
            </asp:TemplateField>
                    </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrmisConnectionString %>"
        SelectCommand="SELECT staffgatepass.passno,EMPMASTER.empname,staffgatepass.outdate,staffgatepass.intime,(select(EMPMASTER.DEPARTMENTCODE +'-'+ EMPMASTER.SECTIONCODE))as ds,staffgatepass.pvehicleno,staffgatepass.intime,EMPMASTER.DEPARTMENTCODE AS DEPT,EMPMASTER.SECTIONCODE AS SECT, staffgatepass.empcode, staffgatepass.date1, staffgatepass.purpose, staffgatepass.outdate, staffgatepass.outtime, staffgatepass.indate, staffgatepass.intime, staffgatepass.pvehicleno, staffgatepass.gatepasstype, staffgatepass.location, staffgatepass.mobile, staffgatepass.atimein, staffgatepass.atimeout, staffgatepass.status, staffgatepass.status1, staffgatepass.statusreason, staffgatepass.category, staffgatepass.sectioncode, staffgatepass.department, staffgatepass.approvedby, staffgatepass.remarks, staffgatepass.userid, staffgatepass.speedofmeter, staffgatepass.speedofmeterin, staffgatepass.approveddate, staffgatepass.btnum FROM staffgatepass INNER JOIN empmaster ON staffgatepass.empcode = empmaster.empcode WHERE (staffgatepass.status = 'OUT') ORDER BY staffgatepass.passno">
        </asp:SqlDataSource>
</asp:Content>


