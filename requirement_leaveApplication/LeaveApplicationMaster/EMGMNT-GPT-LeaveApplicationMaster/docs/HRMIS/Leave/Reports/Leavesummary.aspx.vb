Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.[Global]
Partial Public Class Leavesummary
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim leavetype As String = Session("rpttype")

        Dim paramFields As New ParameterFields
        Dim paramField As New ParameterField
        Dim discreteVal As New ParameterDiscreteValue
        Dim rangeVal As New ParameterRangeValue

        Try
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.ServerName = sqlServerName
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.DatabaseName = sqlDBName
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.UserID = sqlUid
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.Password = sqlPwd

            paramField.ParameterFieldName = "@leavetype"
            discreteVal.Value = leavetype
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)

            paramField = New ParameterField
            paramField.ParameterFieldName = "@fromdate"
            discreteVal = New ParameterDiscreteValue
            discreteVal.Value = Session("lfromd")
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)

            paramField = New ParameterField
            paramField.ParameterFieldName = "@todate"
            discreteVal = New ParameterDiscreteValue
            discreteVal.Value = Session("ltod")
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