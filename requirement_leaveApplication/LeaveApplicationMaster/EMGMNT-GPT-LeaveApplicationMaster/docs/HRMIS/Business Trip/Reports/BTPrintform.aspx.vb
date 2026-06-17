
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class BTPrintform
    Inherits System.Web.UI.Page
    Dim rec As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("rno") <> "" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.recno} =" & Request.QueryString("rno") & ""
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.print('Btprintform.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")
        ElseIf Session("btprintrecno") <> "" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.recno} =" & Session("btprintrecno") & ""
            ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.print('Btprintform.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")
        Else
            Messagebox("No REcords")
        End If

        Session("btprintrecno") = ""
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class