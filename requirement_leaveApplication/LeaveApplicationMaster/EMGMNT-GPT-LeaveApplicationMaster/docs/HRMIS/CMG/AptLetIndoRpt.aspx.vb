Partial Public Class ApptLetterforIndonesians
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        empname.Text = Session("ename")
        'empname2.Text = Session("ename")
        empname1.Text = Session("ename") 'Session("ecode")
        emp.Text = Session("ename")
        desig.Text = Session("desig")
        age.Text = Session("age")
        If Session("add1") = "0" Then
            addr1.Text = "-"
        Else
            addr1.Text = Session("add1")
        End If
        If Session("add2") = "0" Then
            addr2.Text = "-"
        Else
            addr2.Text = Session("add2")
        End If
        If Session("add3") = "0" Then
            addr3.Text = "-"
        Else
            addr3.Text = Session("add3")
        End If
        dt.Text = Session("letdt")
        ppno.Text = Session("pp")
        doj.Text = Session("doj")
        refno.Text = Session("refno")
        dept.Text = Session("deptname")

    End Sub


End Class