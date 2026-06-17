
Partial Public Class jobapplicationreport
    Inherits System.Web.UI.Page
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddldesi.Enabled = False
        ddlas.Enabled = False
        ddlat.Enabled = False
    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click
        If txtfrom.Text.Trim = "" Or txtto.Text.Trim = "" Then
            messagebox("Select Date Field")
            Exit Sub
        End If
        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim fd As Date
        fd = CDate(fd1)
        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
        Dim td As Date
        td = CDate(td1)
        If rb1.SelectedValue = "desi" And ddldesi.SelectedValue <> "-1" Then
            Session("qry") = "select applicationno as No,applieddate as Dateapplied,positionapplied as Designation,Name,icnew as Icno,Phone,Nationality,DOB,Race,Country,Sex,Maritalstatus,Religion,Status from jobapplication where ((applieddate >= '" & fd & "') and (applieddate <= '" & td & "')) and positionapplied='" & ddldesi.SelectedValue & "' order by applieddate"
        ElseIf rb1.SelectedValue = "as" And ddlas.SelectedValue.Trim <> "-1" Then
            Session("qry") = "select applicationno as No,applieddate as Dateapplied,positionapplied as Designation,Name,icnew as Icno,Phone,Nationality,DOB,Race,Country,Sex,Maritalstatus,Religion,Status from jobapplication where ((applieddate >= '" & fd & "') and (applieddate <= '" & td & "' )) and status='" & ddlas.SelectedValue.Trim & "' order by applieddate"
        ElseIf rb1.SelectedValue = "at" And ddlat.SelectedValue <> "-1" Then
            Session("qry") = "select applicationno as No,applieddate as Dateapplied,positionapplied as Designation,Name,icnew as Icno,Phone,Nationality,DOB,Race,Country,Sex,Maritalstatus,Religion,Status from jobapplication where ((applieddate >='" & fd & "') and (applieddate <= '" & td & "')) and applicationstatus='" & ddlat.SelectedValue & "' order by applieddate"
        ElseIf rb1.SelectedValue = "a" Then
            Session("qry") = "select applicationno as No,applieddate as Dateapplied,positionapplied as Designation,Name,icnew as Icno,Phone,Nationality,DOB,Race,Country,Sex,Maritalstatus,Religion,Status from jobapplication where ((applieddate >='" & fd & "') and (applieddate <= '" & td & "')) order by applieddate"
        End If
        Response.Redirect("jobapplicationgridreport.aspx")
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        If rb1.SelectedValue = "desi" Then
            ddldesi.Enabled = True
        ElseIf rb1.SelectedValue = "as" Then
            ddlas.Enabled = True
        ElseIf rb1.SelectedValue = "at" Then
            ddlat.Enabled = True
        Else
            ddldesi.Enabled = False
            ddlas.Enabled = False
            ddlat.Enabled = False
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
   End Class