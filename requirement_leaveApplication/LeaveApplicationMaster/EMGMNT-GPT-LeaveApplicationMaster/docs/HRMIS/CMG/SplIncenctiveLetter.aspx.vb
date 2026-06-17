Partial Public Class SplIncenctiveLetter
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        dept.Text = Session("deptcode")
        empno.Text = Session("empcode")
        desig.Text = Session("desig")
        ltdate.Text = Session("letdt")
        refno.Text = Session("refno")


        bsa.Text = Session("bsa")
        nbsa.Text = Session("nbsa")
        pall.Text = Session("pall")
        oldpall.Text = Session("oldpall")
        splinc.Text = Session("splinc")
        pfpall.Text = Session("pfpall")

        effdate.Text = Session("effdt")

        If (Session("pfpall") = "0" Or Session("pfpall") = "") Then
            lpfp.Visible = False
            pfprm.Visible = False
            pfpall.Visible = False
        Else
            lpfp.Visible = True
            pfprm.Visible = True
            pfpall.Visible = True
        End If

        If (Session("oldpall") = "0" Or Session("oldpall") = "") Then
            lpa.Visible = False
            parm.Visible = False
            oldpall.Visible = False
        Else
            lpa.Visible = True
            parm.Visible = True
            oldpall.Visible = True
        End If

        If (Session("pall") = "0" Or Session("pall") = "") Then
            lnpa.Visible = False
            nparm.Visible = False
            pall.Visible = False
        Else
            lpa.Visible = True
            parm.Visible = True
            pall.Visible = True
        End If

        If (Session("splinc") = "0" Or Session("splinc") = "") Then
            lsia.Visible = False
            siarm.Visible = False
            splinc.Visible = False
        Else
            lsia.Visible = True
            siarm.Visible = True
            splinc.Visible = True
        End If


    End Sub

End Class