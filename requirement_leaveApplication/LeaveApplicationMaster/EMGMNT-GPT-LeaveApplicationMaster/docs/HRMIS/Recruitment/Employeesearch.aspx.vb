Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Employeesearch
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dt As New DataTable
    Dim ad As SqlDataAdapter
    Dim sqltext, sample As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        con = New SqlConnection(constr)
        con.Open()
    End Sub
    Protected Sub search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles search.Click
        errmsg.Text = ""
        GridView1.DataSource = Nothing
        If keyin.Text = "" Then
            errmsg.Text = "Enter " & ddl.SelectedItem.Text
            keyin.Focus()
            Exit Sub
        End If
        If ddl.SelectedValue = "e" Then
            If IsNumeric(keyin.Text) = False Then
                errmsg.Text = "Enter " & ddl.SelectedItem.Text & "Only"
                keyin.Text = ""
                keyin.Focus()
                Exit Sub
            End If
        End If
        If gnder.SelectedValue = "s" And forn.SelectedValue = "s" Then
            If ddl.SelectedValue = "n" Then
                sample = "select EmpName,Empcode,Departmentcode as Dept,Sectioncode as Sect,Designation from empmaster where resigned='N' and (replace(Empname,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "e" Then
                sample = "select Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Designation from empmaster where resigned='N' and (replace(Empcode,' ','')) like '%key%' " & "order by empcode"
            ElseIf ddl.SelectedValue = "d" Then
                sample = "select Departmentcode as Dept,Empcode,Empname,Sectioncode as Sect,Designation from empmaster where resigned='N' and (replace(departmentcode,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "s" Then
                sample = "select Sectioncode as Sect,Empcode,Empname,Departmentcode as Dept,Designation from empmaster where resigned='N' and (replace(sectioncode,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "dsg" Then
                sample = "select Designation,Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect from empmaster where resigned='N' and (replace(designation,' ','')) like '%key%' " & "order by Designation"
            End If
        End If
        If gnder.SelectedValue <> "s" And forn.SelectedValue = "s" Then
            If ddl.SelectedValue = "n" Then
                sample = "select EmpName,Empcode,Departmentcode as Dept,Sectioncode as Sect,Designation,Sex from empmaster where resigned='N' and sex='" & (gnder.SelectedValue) & "' and (replace(Empname,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "e" Then
                sample = "select Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Designation,Sex from empmaster where resigned='N' and sex='" & (gnder.SelectedValue) & "' and (replace(Empcode,' ','')) like '%key%' " & "order by empcode"
            ElseIf ddl.SelectedValue = "d" Then
                sample = "select Departmentcode as Dept,Empcode,Empname,Sectioncode as Sect,Designation,Sex from empmaster where resigned='N' and sex='" & (gnder.SelectedValue) & "' and (replace(departmentcode,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "s" Then
                sample = "select Sectioncode as Sect,Empcode,Empname,Departmentcode as Dept,Designation,Sex from empmaster where resigned='N' and sex='" & (gnder.SelectedValue) & "' and (replace(sectioncode,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "dsg" Then
                sample = "select Designation,Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Sex from empmaster where resigned='N' and sex='" & (gnder.SelectedValue) & "' and (replace(designation,' ','')) like '%key%' " & "order by Designation"
            End If
        End If
        If gnder.SelectedValue = "s" And forn.SelectedValue <> "s" Then
            If ddl.SelectedValue = "n" Then
                sample = "select EmpName,Empcode,Departmentcode as Dept,Sectioncode as Sect,Designation,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(Empname,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "e" Then
                sample = "select Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Designation,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(Empcode,' ','')) like '%key%' " & "order by empcode"
            ElseIf ddl.SelectedValue = "d" Then
                sample = "select Departmentcode as Dept,Empcode,Empname,Sectioncode as Sect,Designation,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(departmentcode,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "s" Then
                sample = "select Sectioncode as Sect,Empcode,Empname,Departmentcode as Dept,Designation,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(sectioncode,' ','')) like '%key%' " & "order by empname"
            ElseIf ddl.SelectedValue = "dsg" Then
                sample = "select Designation,Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Foreignemp from empmaster where resigned='N' and  oreignemp='" & (forn.SelectedValue) & "' and (replace(designation,' ','')) like '%key%' " & "order by Designation"
            End If
        End If
        If gnder.SelectedValue <> "s" And forn.SelectedValue <> "s" Then
            If gnder.SelectedValue = "Male" Then
                If ddl.SelectedValue = "n" Then
                    sample = "select EmpName,Empcode,Departmentcode as Dept,Sectioncode as Sect,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(Empname,' ','')) like '%key%' " & "  and (sex= 'Male' or sex = 'M' or sex = 'm' or sex = 'male')  order by empname"
                ElseIf ddl.SelectedValue = "e" Then
                    sample = "select Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(Empcode,' ','')) like '%key%' " & " and (sex= 'Male' or sex = 'M' or sex = 'm' or sex = 'male') order by empcode"
                ElseIf ddl.SelectedValue = "d" Then
                    sample = "select Departmentcode as Dept,Empcode,Empname,Sectioncode as Sect,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(departmentcode,' ','')) like '%key%' " & " and (sex= 'Male' or sex = 'M' or sex = 'm' or sex = 'male') order by empname"
                ElseIf ddl.SelectedValue = "s" Then
                    sample = "select Sectioncode as Sect,Empcode,Empname,Departmentcode as Dept,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(sectioncode,' ','')) like '%key%' " & " and (sex= 'Male' or sex = 'M' or sex = 'm' or sex = 'male') order by empname"
                ElseIf ddl.SelectedValue = "dsg" Then
                    sample = "select Designation,Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(designation,' ','')) like '%key%' " & " and (sex= 'Male' or sex = 'M' or sex = 'm' or sex = 'male') order by Designation"
                End If
            ElseIf gnder.SelectedValue = "Female" Then
                If ddl.SelectedValue = "n" Then
                    sample = "select EmpName,Empcode,Departmentcode as Dept,Sectioncode as Sect,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(Empname,' ','')) like '%key%' " & "  and (sex= 'Female' or sex = 'F' or sex = 'f' or sex = 'female') order by empname"
                ElseIf ddl.SelectedValue = "e" Then
                    sample = "select Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(Empcode,' ','')) like '%key%' " & " and (sex= 'Female' or sex = 'F' or sex = 'f' or sex = 'female') order by empcode"
                ElseIf ddl.SelectedValue = "d" Then
                    sample = "select Departmentcode as Dept,Empcode,Empname,Sectioncode as Sect,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(departmentcode,' ','')) like '%key%' " & " and (sex= 'Female' or sex = 'F' or sex = 'f' or sex = 'female') order by empname"
                ElseIf ddl.SelectedValue = "s" Then
                    sample = "select Sectioncode as Sect,Empcode,Empname,Departmentcode as Dept,Designation,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(sectioncode,' ','')) like '%key%' " & " and (sex= 'Female' or sex = 'F' or sex = 'f' or sex = 'female') order by empname"
                ElseIf ddl.SelectedValue = "dsg" Then
                    sample = "select Designation,Empcode,Empname,Departmentcode as Dept,Sectioncode as Sect,Sex,Foreignemp from empmaster where resigned='N' and foreignemp='" & (forn.SelectedValue) & "' and (replace(designation,' ','')) like '%key%' " & " and (sex= 'Female' or sex = 'F' or sex = 'f' or sex = 'female') order by Designation"
                End If
            End If
        End If
        If keyin.Text.Contains(" ") = True Then
            keyin.Text = keyin.Text.Replace(" ", "")
        End If
        sample = sample.Replace("key", keyin.Text.Trim)
        Session("sql") = sample
        Session("start") = "start"
        sqltext = sample
        ad = New SqlDataAdapter(sqltext, con)
        ad.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        sqltext = Session("sql")
        ad = New SqlDataAdapter(sqltext, con)
        ad.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            If forn.SelectedValue <> "s" And gnder.SelectedValue <> "s" Then
                Dim frn As String = GridView1.Rows(i).Cells(7).Text
                If frn = "Y" Then
                    GridView1.Rows(i).Cells(7).Text = "Yes"
                ElseIf frn = "N" Then
                    GridView1.Rows(i).Cells(7).Text = "No"
                End If
            ElseIf forn.SelectedValue <> "s" And gnder.SelectedValue = "s" Then
                Dim frner As String = GridView1.Rows(i).Cells(6).Text
                If frner = "Y" Then
                    GridView1.Rows(i).Cells(6).Text = "Yes"
                ElseIf frner = "N" Then
                    GridView1.Rows(i).Cells(6).Text = "No"
                End If
            End If
        Next
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session("sql").ToString.Contains("desc") = True Then
            Session("sql") = Session("sql").ToString.Replace("desc", "")
        Else
            Session("sql") = Session("sql") & " desc"
        End If
        sqltext = Session("sql")
        ad = New SqlDataAdapter(sqltext, con)
        ad.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
End Class
