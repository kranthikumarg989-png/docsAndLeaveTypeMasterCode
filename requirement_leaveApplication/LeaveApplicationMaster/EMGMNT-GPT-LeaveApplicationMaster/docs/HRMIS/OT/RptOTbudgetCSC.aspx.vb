Public Partial Class RptOTbudgetCSC
    Inherits System.Web.UI.Page
    Dim total


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LBLFROM.Text = Session("budgetfrom")
        LBLTO.Text = Session("budgetTO")

    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblUnitsInStock As Label = DirectCast(e.Row.FindControl("Label1"), Label)
            Dim stock As Decimal = [Decimal].Parse(lblUnitsInStock.Text)
            total += stock
        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            Dim lblTotalPrice As Label = DirectCast(e.Row.FindControl("Lbltotal"), Label)
            lblTotalPrice.Text = total.ToString()
        End If

    End Sub
End Class