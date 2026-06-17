Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class resignedstatus
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, dt As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (223)
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
        Con = New SqlConnection(constr)
        Con.Open()
        empcode.Focus()
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        If IsNumeric(empcode.Text) = True Then
            sqltext = "select empname,departmentcode,sectioncode from empmaster where empcode='" & (empcode.Text) & "'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                name.Text = rdr("empname")
                department.Text = rdr("departmentcode")
                section.Text = rdr("sectioncode")
            End While
            rdr.Close()

        Else
            empcode.Text = ""
            name.Text = ""
            department.Text = ""
            section.Text = ""
            empcode.Focus()
            MessageBox("Enter Employee No")
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If resigndate.Text.Trim = "" Then
            MessageBox("Enter Resign Date")
            resigndate.Focus()
            Exit Sub
        End If
        Dim fd1 As String
        fd1 = resigndate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        For i As Integer = 0 To 1
            If i = 0 Then
                sqltext = "insert into resignedstatus values('" & (empcode.Text) & "','" & fd & "','" & (status.Text.Trim) & "','" & (reason.Text) & "')"
            ElseIf i = 1 Then
                sqltext = "update empmaster set dateoftermination='" & fd & "',resigned='Y' where empcode='" & (empcode.Text) & "'"
            End If
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
        Next
        MessageBox("Record Saved!")
        empcode.Text = ""
        name.Text = ""
        department.Text = ""
        section.Text = ""
        reason.Text = ""
        resigndate.Text = ""
    End Sub
End Class