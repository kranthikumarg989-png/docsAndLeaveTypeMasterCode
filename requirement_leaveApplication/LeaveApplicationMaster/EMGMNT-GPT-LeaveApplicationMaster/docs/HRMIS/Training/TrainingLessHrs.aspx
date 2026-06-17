<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TrainingLessHrs.aspx.vb" Inherits="E_Management.TrainingLessHrs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Less Training Hours</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
            <asp:TemplateField HeaderText="S.No." >
   <ItemTemplate>    
       <%# CType(Container, GridViewRow).RowIndex + 1%>
   </ItemTemplate>
</asp:TemplateField>

                <asp:BoundField DataField="empcode" HeaderText="empcode" SortExpression="empcode" />
                <asp:BoundField DataField="tothrsneeded" HeaderText="tothrsneeded" SortExpression="tothrsneeded" />
                <asp:BoundField DataField="monhrsneeded" HeaderText="monhrsneeded" SortExpression="monhrsneeded" />
                <asp:BoundField DataField="tothrsattended" HeaderText="tothrsattended" SortExpression="tothrsattended" />
                <asp:BoundField DataField="tillmonthtarget" HeaderText="tillmonthtarget" SortExpression="tillmonthtarget" />
                <asp:BoundField DataField="lackinghrs" HeaderText="lackinghrs" SortExpression="lackinghrs" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
            SelectCommand="SELECT [empcode], [tothrsneeded], [monhrsneeded], [tothrsattended], [tillmonthtarget], [lackinghrs] FROM [temp_lesstraininghrs]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
