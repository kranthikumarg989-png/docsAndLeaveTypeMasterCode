Public Partial Class test
    Inherits System.Web.UI.Page
    Dim i

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = "this letter is to issue to ERL.empcode from the department ERL.dept"
     

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim strtext As String = TextBox1.Text
        MsgBox(strtext.Replace("ERL.empcode", empcode.Text))
        MsgBox(strtext)

    End Sub
End Class