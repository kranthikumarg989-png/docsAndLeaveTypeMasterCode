Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class memoentry
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim str As String
    Dim lbtext As String
    Dim n As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim dummy_ecode As Integer                                                 'hot code removal for implement purpose but its usefull for testing
        'dummy_ecode = 14191
        'Session("_ecode") = dummy_ecode
        'Session("_ename") = "SATHIASEELAN A/L M.SATIAH"
        'Session("_edept") = "9004-Value Creation Initiator Division"

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (114)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If

        employeeno.Text = Session("empcode")
        empname.Text = Session("_ename")
        yourdepartment.Text = Session("_edept")
        signature.Text = empname.Text
        memotime.Text = "Memo Time: " & Date.Now.ToShortTimeString
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        MyGlobal.Open_Con()
        con.Open()
        str = "select max(serialno)from memo"
        cmd = New SqlCommand(str, con)
        dr = cmd.ExecuteReader()
        While dr.Read
            n = dr(0)
        End While
        dr.Close()
        serialno.Text = n + 1
        'yourdepartment.Text = "IT"
        str = "select departmentcode,departmentname from department order by departmentcode"
        cmd = New SqlCommand(str, con)
        dr = cmd.ExecuteReader
        While dr.Read
            If IsPostBack = False Then
                ListBox1.Items.Add(New ListItem(dr(0) & "-" & dr(1), dr(0)))
            End If
        End While
        dr.Close()
        con.Close()
    End Sub
    'Protected Sub employeeno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles employeeno.TextChanged
    'If IsNumeric(employeeno.Text) Then
    '    Con.Open()
    '    str = "select empname from empmaster  where empcode='" & (employeeno.Text) & "'"
    '    cmd = New SqlCommand(str, Con)
    '    dr = cmd.ExecuteReader()
    '    While dr.Read
    '        empname.Text = dr(0)
    '    End While
    '    dr.Close()
    '    signature.Text = empname.Text
    'Else
    '    MsgBox("Enter correct Employee nubers only")
    '    employeeno.Text = ""
    '    employeeno.Focus()
    'End If
    'Con.Close()
    'End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        For i As Integer = 1 To ListBox1.Items.Count - 1
            ListBox1.Items.Item(i).Selected = True
            TextBox1.Focus()
            If CheckBox1.Checked = False Then
                ListBox1.Items.Item(i).Selected = False
                ListBox1.Focus()
            End If
        Next
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt, dtt
        dt = Date.Now.ToShortDateString
        dtt = Date.Now.ToShortTimeString
        Call lbsel()
        Con.Open()
        str = "insert into memo values('" & (serialno.Text) & "','" & (employeeno.Text) & "','" & (empname.Text) & "','" & (yourdepartment.Text) & "','" & (TextBox5.Text) & "','" & lbtext & "','" & (paragraph1.Text) & "','" & (paragraph2.Text) & "','" & (paragraph3.Text) & "','P','" & (empname.Text) & "','waiting for approval','','" & dtt & "','" & (TextBox1.Text) & "','','','')"
        cmd = New SqlCommand(str, Con)
        cmd.ExecuteNonQuery()
        'Server.Transfer("memostatusview.aspx?page=last")
        Server.Transfer("memostatusview.aspx?")
    End Sub
    'Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Response.Write("<script language='javascript'> {self.close() }</script>")
    'End Sub
    Sub lbsel()
        If CheckBox1.Checked = True Then
            lbtext = "All Department"
        ElseIf ListBox1.SelectionMode = ListSelectionMode.Multiple = True Then
            lbtext = ""
            For i As Integer = 1 To ListBox1.Items.Count - 1
                If ListBox1.Items.Item(i).Selected = True Then
                    lbtext = lbtext & "," & ListBox1.Items.Item(i).Value
                ElseIf ListBox1.SelectionMode = ListSelectionMode.Single = True Then
                    lbtext = ""
                    lbtext = ListBox1.SelectedItem.Value
                End If
            Next
            lbtext = Right(lbtext, Len(lbtext) - 1)
        End If
    End Sub

End Class