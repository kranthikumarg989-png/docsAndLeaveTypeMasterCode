Public Partial Class RptKPISujmmaryMonrpt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("xkpiopt") = "yr" Then
            GridView1.Visible = True
            GridView2.Visible = False
            GridView3.Visible = False


        ElseIf Session("xkpiopt") = "hyr" Then

            If Session("xkp") = "1h" Then
                GridView1.Visible = False
                GridView2.Visible = True
                GridView3.Visible = False
            ElseIf Session("xkp") = "2h" Then
                GridView1.Visible = False
                GridView2.Visible = False
                GridView3.Visible = True
            End If

        End If
    End Sub

End Class