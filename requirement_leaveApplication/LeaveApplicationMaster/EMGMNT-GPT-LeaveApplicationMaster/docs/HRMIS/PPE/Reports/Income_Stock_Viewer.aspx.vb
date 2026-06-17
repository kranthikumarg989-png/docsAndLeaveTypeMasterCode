Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Partial Public Class Income_Stock_Viewer
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim crReportDocument As rptUsageSummary
    Dim crParameterFields As ParameterFields
    Dim crParameterField As ParameterField
    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterRangeValue As ParameterRangeValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition

    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'MyGlobal.rptcon()
        'crConnectionInfo = New ConnectionInfo
        'With crConnectionInfo
        '    .ServerName = sver
        '    .DatabaseName = dbname
        '    .UserID = uid
        '    .Password = pw
        'End With
        ''Get the tables collection from the report object
        'crDatabase = crReportDocument.Database
        'crTables = crDatabase.Tables
        ''Apply the logon information to each table in the collection
        'For Each crTable In crTables
        '    crTableLogOnInfo = crTable.LogOnInfo
        '    crTableLogOnInfo.ConnectionInfo = crConnectionInfo
        '    crTable.ApplyLogOnInfo(crTableLogOnInfo)
        'Next

        Dim crystalReport As New ReportDocument()
        If Request.QueryString("ScreenId").ToString() = "RS" Then    'RS Means Received Summary
            Dim crReportDocument As RptReceivedSummary
            crReportDocument = New RptReceivedSummary
            MyGlobal.rptcon()
            crConnectionInfo = New ConnectionInfo
            With crConnectionInfo
                .ServerName = sver
                .DatabaseName = dbname
                .UserID = uid
                .Password = pw
            End With
            'Get the tables collection from the report object
            crDatabase = crReportDocument.Database
            crTables = crDatabase.Tables
            'Apply the logon information to each table in the collection
            For Each crTable In crTables
                crTableLogOnInfo = crTable.LogOnInfo
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                crTable.ApplyLogOnInfo(crTableLogOnInfo)
            Next

            crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()

            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Request.QueryString("FromDate")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Request.QueryString("ToDate")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Request.QueryString("Dept")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = Request.QueryString("Type")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            CrystalReportViewer1.ReportSource = crReportDocument

            'crystalReport.Load(Server.MapPath("ReceivedSummary.rpt"))
            'crystalReport.SetDatabaseLogon("'" + MyGlobal.uid + "'", "'" + pw + "'", "'" + sver + "'", "'" + dbname + "'")
            'crystalReport.SetParameterValue("@FromDate", Request.QueryString("FromDate"))
            'crystalReport.SetParameterValue("@Todate", Request.QueryString("ToDate"))
            'crystalReport.SetParameterValue("@Department", Request.QueryString("Dept"))
            'CrystalReportViewer1.ReportSource = crystalReport

        ElseIf Request.QueryString("ScreenId").ToString() = "IR" Then    'IR Means Incoming Report
            Dim crReportDocument As IncomingStock
            crReportDocument = New IncomingStock
            MyGlobal.rptcon()
            crConnectionInfo = New ConnectionInfo
            With crConnectionInfo
                .ServerName = sver
                .DatabaseName = dbname
                .UserID = uid
                .Password = pw
            End With
            'Get the tables collection from the report object
            crDatabase = crReportDocument.Database
            crTables = crDatabase.Tables
            'Apply the logon information to each table in the collection
            For Each crTable In crTables
                crTableLogOnInfo = crTable.LogOnInfo
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                crTable.ApplyLogOnInfo(crTableLogOnInfo)
            Next

            ''crystalReport.Load(Server.MapPath("IncomingStock.rpt"))
            ''crystalReport.SetDatabaseLogon("'" + MyGlobal.uid + "'", "'" + MyGlobal.pw + "'", "'" + MyGlobal.sver + "'", "'" + MyGlobal.dbname + "'")
            'crReportDocument.SetParameterValue("@FromDate", Request.QueryString("FromDate"))
            'crReportDocument.SetParameterValue("@Todate", Request.QueryString("ToDate"))
            'crReportDocument.SetParameterValue("@Department", Request.QueryString("Dept"))
            'CrystalReportViewer1.ReportSource = crReportDocument 'crystalReport

            crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()

            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Request.QueryString("FromDate")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Request.QueryString("ToDate")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Request.QueryString("Dept")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = Request.QueryString("Type")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            CrystalReportViewer1.ReportSource = crReportDocument

        ElseIf Request.QueryString("ScreenId").ToString() = "SR" Then    'SR Means Stock Report
            crystalReport.Load(Server.MapPath("StockReport.rpt"))
            crystalReport.SetDatabaseLogon("'" + MyGlobal.uid + "'", "'" + MyGlobal.pw + "'", "'" + MyGlobal.sver + "'", "'" + MyGlobal.dbname + "'")
            'crystalReport.SetParameterValue("@FromDate", Request.QueryString("FromDate"))
            'crystalReport.SetParameterValue("@Todate", Request.QueryString("ToDate"))
            crystalReport.SetParameterValue("@Department", Request.QueryString("Dept"))
            crystalReport.SetParameterValue("@Item", Request.QueryString("Item"))
            CrystalReportViewer1.ReportSource = crystalReport

        ElseIf Request.QueryString("ScreenId").ToString() = "AR" Then    'AR Means Abnormal Replace
            crystalReport.Load(Server.MapPath("AbnormalReplace.rpt"))
            crystalReport.SetDatabaseLogon("'" + uid + "'", "'" + pw + "'", "'" + sver + "'", "'" + dbname + "'")
            crystalReport.SetParameterValue("@EmployeeId", Request.QueryString("EmpId"))
            CrystalReportViewer1.ReportSource = crystalReport

        ElseIf Request.QueryString("ScreenId").ToString() = "AL" Then    'AR Means Abnormal Replace
            crystalReport.Load(Server.MapPath("AbnormalLifeSpan.rpt"))
            crystalReport.SetDatabaseLogon("'" + uid + "'", "'" + pw + "'", "'" + sver + "'", "'" + dbname + "'")
            crystalReport.SetParameterValue("@EmployeeId", Request.QueryString("EmpId"))
            CrystalReportViewer1.ReportSource = crystalReport
        End If
    End Sub

End Class