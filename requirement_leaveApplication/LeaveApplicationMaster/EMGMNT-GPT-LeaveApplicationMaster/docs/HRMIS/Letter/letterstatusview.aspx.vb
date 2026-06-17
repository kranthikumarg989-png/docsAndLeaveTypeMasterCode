Partial Public Class letterstatusview
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub Gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            Dim label As Label = TryCast(e.Row.FindControl("lbl1"), Label)
            Dim lbprint As LinkButton = TryCast(e.Row.FindControl("lbprint"), LinkButton)
            Dim lbshow As LinkButton = TryCast(e.Row.FindControl("lbshow"), LinkButton)

            If label.Text = "a" Or status = "A" Or status = "Approved" Then
                lbprint.Visible = False
                lbshow.Visible = True
            Else
                lbprint.Visible = False
                lbshow.Visible = True
            End If

            '    If status = "s" Or status = "S" Then
            '        e.Row.Cells(8).ForeColor = Drawing.Color.Yellow
            '        'e.Row.Cells(8).Text = "SCHEDULED"
            '    ElseIf status = "A" Then
            '        e.Row.Cells(8).ForeColor = Drawing.Color.Green
            '        ' e.Row.Cells(8).Text = "APPROVED"
            '    ElseIf status = "R" Then
            '        e.Row.Cells(8).ForeColor = Drawing.Color.Red
            '        ' e.Row.Cells(8).Text = "REJECTED"
            '    End If
            'End If
        End If
    End Sub
    Private Sub Gridview2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            Dim label As Label = TryCast(e.Row.FindControl("lbl1"), Label)
            Dim lbprint As LinkButton = TryCast(e.Row.FindControl("lbprint"), LinkButton)
            Dim lbshow As LinkButton = TryCast(e.Row.FindControl("lbshow"), LinkButton)

            If label.Text = "a" Or status = "A" Or status = "Approved" Then
                lbprint.Visible = False
                lbshow.Visible = True
            Else
                lbprint.Visible = False
                lbshow.Visible = True
            End If
        End If
    End Sub
    Private Sub Gridview3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            Dim label As Label = TryCast(e.Row.FindControl("lbl1"), Label)
            Dim lbprint As LinkButton = TryCast(e.Row.FindControl("lbprint"), LinkButton)
            Dim lbshow As LinkButton = TryCast(e.Row.FindControl("lbshow"), LinkButton)

            If label.Text = "a" Or status = "A" Or status = "Approved" Then
                lbprint.Visible = True
                lbshow.Visible = True
            Else
                lbprint.Visible = False
                lbshow.Visible = True
            End If
        End If
    End Sub
    Public Sub Fncshow(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim ln
        ln = e.CommandArgument

        'MsgBox(ln)
        Session("Lettername") = ln
        Response.Redirect("letterprecmg.aspx")
    End Sub
End Class
'cvselfstatus.aspx