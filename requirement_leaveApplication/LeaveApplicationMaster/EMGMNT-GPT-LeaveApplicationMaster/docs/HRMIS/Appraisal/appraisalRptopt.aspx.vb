Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class appraisalRptopt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim rno As Integer = Session("rptapprno")
        'Dim tod As String = Session("alltod")
        'Dim status As String = Session("allstatus")

        Dim paramFields As New ParameterFields
        Dim paramField As New ParameterField
        Dim discreteVal As New ParameterDiscreteValue
        Dim rangeVal As New ParameterRangeValue

        Try
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.ServerName = "NB09"
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.DatabaseName = "hrmis"
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.UserID = "sa"
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.Password = ""


            'paramField = New ParameterField
            'paramField.ParameterFieldName = "empno"
            'discreteVal = New ParameterDiscreteValue
            'discreteVal.Value = "014543"
            'paramField.CurrentValues.Add(discreteVal)
            'paramFields.Add(paramField)

            'paramField = New ParameterField
            'paramField.ParameterFieldName = "year"
            'discreteVal = New ParameterDiscreteValue
            'discreteVal.Value = "2011"
            'paramField.CurrentValues.Add(discreteVal)
            'paramFields.Add(paramField)


            paramField = New ParameterField
            paramField.ParameterFieldName = "rno"
            discreteVal = New ParameterDiscreteValue
            discreteVal.Value = rno
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)


            CrystalReportViewer1.ParameterFieldInfo = paramFields


        Catch ex As Exception
            MessageBox(ex.Message.ToString)
        End Try


    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

End Class