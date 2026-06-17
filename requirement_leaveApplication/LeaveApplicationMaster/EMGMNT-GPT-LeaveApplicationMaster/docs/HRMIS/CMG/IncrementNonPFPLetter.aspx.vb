
Partial Public Class IncrementNonPFPLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        name.Text = Session("empname")
        dept.Text = Session("deptcode")
        empno.Text = Session("empcode")
        desig.Text = Session("desig")
        ltdate.Text = Session("letdt")
        refno.Text = Session("refno")

        effdate.Text = Session("effdt")

        If (Session("bsa") = "0" Or Session("bsa") = "") Then
            lblbasic.Visible = False
            lblrm.Visible = False
            bsa.Visible = False
        Else
            lblbasic.Visible = True
            lblrm.Visible = True
            bsa.Visible = True
            bsa.Text = Session("bsa")
        End If

        'If (Session("nbsa") = "0" Or Session("nbsa") = "") Then
        '    lblnba.Visible = False
        '    nbsa.Visible = False
        '    nbarm.Visible = False
        '    'nbsa.Text = Session("nbsa")
        'Else
        '    lblnba.Visible = True
        '    nbsa.Visible = True
        '    nbarm.Visible = True
        nbsa.Text = Session("nbsa")
        'End If

        If (Session("pall") = "0" Or Session("pall") = "") Then
            lblpa.Visible = False
            pall.Visible = False
            parm.Visible = False
            'nbsa.Text = Session("nbsa")
        Else
            lblpa.Visible = True
            pall.Visible = True
            parm.Visible = True
            pall.Text = Session("pall")
        End If

        If (Session("splinc") = "0" Or Session("splinc") = "") Then
            lblIA.Visible = False
            splinc.Visible = False
            Iarm.Visible = False
            'nbsa.Text = Session("nbsa")
        Else
            lblIA.Visible = True
            splinc.Visible = True
            Iarm.Visible = True
            splinc.Text = Session("splinc")
        End If

        If (Session("npall") = "0" Or Session("npall") = "") Then
            lblnpa.Visible = False
            npall.Visible = False
            nparm.Visible = False
            'nbsa.Text = Session("nbsa")
        Else
            lblnpa.Visible = True
            npall.Visible = True
            nparm.Visible = True
            npall.Text = Session("npall")
        End If

    End Sub

End Class