Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.[Global]
Partial Public Class Leave_all1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sect As String = Session("alldept")
        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")
        Dim status As String = Session("allstatus")

        Dim paramFields As New ParameterFields
        Dim paramField As New ParameterField
        Dim discreteVal As New ParameterDiscreteValue
        Dim rangeVal As New ParameterRangeValue

        Try
            ' CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.ServerName = sqlServerName
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.DatabaseName = sqlDBName
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.UserID = sqlUid
            'CrystalReportViewer1.LogOnInfo(0).ConnectionInfo.Password = sqlPwd

            paramField.ParameterFieldName = "dept"
            discreteVal.Value = sect
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)

            If status = "*" Then ' if status = "all"
                paramField = New ParameterField
                paramField.ParameterFieldName = "status"

                discreteVal = New ParameterDiscreteValue
                discreteVal.Value = "Scheduled"
                paramField.CurrentValues.Add(discreteVal)

                discreteVal = New ParameterDiscreteValue
                discreteVal.Value = "Approved"
                paramField.CurrentValues.Add(discreteVal)

                discreteVal = New ParameterDiscreteValue
                discreteVal.Value = "Cancelled"
                paramField.CurrentValues.Add(discreteVal)

                discreteVal = New ParameterDiscreteValue
                discreteVal.Value = "Rejected"
                paramField.CurrentValues.Add(discreteVal)


                paramFields.Add(paramField)
            Else
                paramField = New ParameterField
                paramField.ParameterFieldName = "status"
                discreteVal = New ParameterDiscreteValue
                discreteVal.Value = status
                paramField.CurrentValues.Add(discreteVal)
                paramFields.Add(paramField)

            End If

            paramField = New ParameterField
            paramField.ParameterFieldName = "leavedaterange"
            rangeVal.StartValue = fromd
            rangeVal.EndValue = tod
            paramField.CurrentValues.Add(rangeVal)
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