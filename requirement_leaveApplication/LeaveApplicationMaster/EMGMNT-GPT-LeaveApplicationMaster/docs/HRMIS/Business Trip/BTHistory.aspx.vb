Public Partial Class BTHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empcode") = "" Then
            Response.Redirect("~\logout.aspx")
        End If

        If Request.QueryString("empcode") = "" Then
            lblempcode.Text = ""
        Else
            lblempcode.Text = Request.QueryString("empcode")
        End If

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "btstatus")).Trim
            If status = "scheduled" Or status = "SCHEDULED" Then
                ' color the background of the row yellow
                e.Row.Cells(7).BackColor = Drawing.Color.Orange
                e.Row.Cells(7).Text = "PENDING FOR APPROVAL"
                e.Row.Cells(7).ForeColor = Drawing.Color.Yellow
            ElseIf status = "AEA" Or status = "A" Then
                e.Row.Cells(7).BackColor = Drawing.Color.Orange
                e.Row.Cells(7).Text = "APPROVED"
                e.Row.Cells(7).ForeColor = Drawing.Color.Green
            ElseIf status = "REA" Or status = "R" Then
                e.Row.Cells(7).Text = "REJECTED"
                e.Row.Cells(7).BackColor = Drawing.Color.Orange
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub
 

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class