Public Partial Class BirthdayRpts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub showtTrainingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showtTrainingReport.Click

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("-"c)
        fd1 = strdate(1) & "/" & strdate(0)
        Dim fdm = strdate(1)
        Dim fdd = strdate(0)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd
        Session("fromdm") = fdm
        Session("fromdd") = fdd
        Session("fd") = fd1


        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("-"c)
        td1 = strdate2(1) & "/" & strdate2(0)
        Dim tdm = strdate2(1)
        Dim tdd = strdate2(0)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td
        Session("todm") = tdm
        Session("todd") = tdd
        Session("td") = td1
        Dim comp = RBcomp.SelectedValue.Trim

        If comp = "MM" Then
            Response.Redirect("Bdayreportsbyselection.aspx")
        ElseIf comp = "MEL" Then
            Response.Redirect("birthdayreportsMelaka.aspx")
        ElseIf comp = "MO" Then
            Response.Redirect("birthdatreportOS.aspx")
        End If

    End Sub
End Class