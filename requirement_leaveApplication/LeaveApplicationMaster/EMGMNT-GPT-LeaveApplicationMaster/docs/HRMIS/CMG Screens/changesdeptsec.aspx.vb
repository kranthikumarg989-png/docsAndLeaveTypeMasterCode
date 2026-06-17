Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class changesdeptsec
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
            MyScreenId = (222)
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
        save.Enabled = False
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
            dept.Focus()
        Else
            empcode.Text = ""
            empcode.Focus()
            name.Text = ""
            department.Text = ""
            section.Text = ""
            messagebox("Entere Employee No")
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept.SelectedIndexChanged
        sect.Items.Clear()
        If dept.SelectedValue <> "-1" Then
            sqltext = "select * from sectionmaster where departmentcode ='" & (dept.SelectedValue) & "'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                sect.Items.Add(New ListItem(rdr(0) & "--" & rdr(1), rdr(0)))
            End While
            rdr.Close()
            save.Enabled = True
            sect.Focus()
        End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        dt = Date.Now.ToShortDateString
        For i As Integer = 0 To 1
            If i = 0 Then
                sqltext = "insert into changesecdept values('" & (empcode.Text.Trim) & "','" & (section.Text.Trim) & "','" & (department.Text.Trim) & "','" & (sect.SelectedValue.Trim) & "','" & (dept.SelectedValue.Trim) & "','" & dt & "')"
            ElseIf i = 1 Then
                sqltext = "update empmaster set sectioncode='" & (sect.SelectedValue.Trim) & "',departmentcode='" & (dept.SelectedValue.Trim) & "' where empcode='" & (empcode.Text) & "'"
            End If
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
        Next
        'conflict rise remind to rathi refer()changesecdept asp page.........
        'If rs.State Then rs.Close()
        'rs.Open("select * from emp_approvalassignment where empcode ='" & Request.Form("empcode") & "'", Con, 3, 2, 1)
        'If rs.EOF <> True Then
        '    rs.Fields("empcode") = Request.Form("empcode")
        '    rs.Fields("lsectioncode") = Request.Form("seccode")
        '    rs.Fields("ldepartmentcode") = Request.Form("deptcode")
        '    rs.Fields("gsectioncode") = Request.Form("seccode")
        '    rs.Fields("gdepartmentcode") = Request.Form("deptcode")
        '    rs.Update()
        'End If
    End Sub
End Class