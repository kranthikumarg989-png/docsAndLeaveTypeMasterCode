Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Partial Public Class frmRptReceivedByEmp
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    'Dim crReportDocument As rptReceivedByEmp
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
        If Request.QueryString("RptT") = "Sum" Then
            Try
                Dim crReportDocument As rptReceivedByEmp
                crReportDocument = New rptReceivedByEmp
                MyGlobal.rptcon()
                'Dim crConnectionInfo As ConnectionInfo = New ConnectionInfo
                crConnectionInfo = New ConnectionInfo
                With crConnectionInfo
                    .ServerName = sver
                    .DatabaseName = dbname
                    .UserID = uid
                    .Password = pw
                End With
                'crTables = crReportDocument.Database.Tables
                'Get the tables collection from the report object
                crDatabase = crReportDocument.Database
                crTables = crDatabase.Tables
                'Apply the logon information to each table in the collection
                For Each crTable In crTables
                    crTableLogOnInfo = crTable.LogOnInfo
                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                Next

                'MyGlobal.rptcon()
                'Dim crConnectionInfo As ConnectionInfo = New ConnectionInfo
                'With crConnectionInfo
                '    .ServerName = sver
                '    .DatabaseName = dbname
                '    .UserID = uid
                '    .Password = pw
                'End With

                crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()

                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Request.QueryString("emp")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Request.QueryString("FDt")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Request.QueryString("TDt")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Request.QueryString("Type")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                CrystalReportViewer1.ReportSource = crReportDocument

                'Dim crystalReport As New ReportDocument()
                'If Request.QueryString("RptT") = "Sum" Then
                '    crystalReport.Load(Server.MapPath("rptReceivedByEmp.rpt"))
                'ElseIf Request.QueryString("RptT") = "Det" Then
                '    crystalReport.Load(Server.MapPath("rptReceivedDetailByEmp.rpt"))
                'End If

                'crystalReport.SetDatabaseLogon("'" + uid + "'", "'" + pw + "'", "'" + sver + "'", "'" + dbname + "'")
                'crystalReport.SetParameterValue("@ItemOption", Request.QueryString("Type"))
                'crystalReport.SetParameterValue("@IssuedTo", Request.QueryString("emp"))
                'crystalReport.SetParameterValue("@FromDt", Request.QueryString("FDt"))
                'crystalReport.SetParameterValue("@ToDt", Request.QueryString("TDt"))
                'CrystalReportViewer1.ReportSource = crystalReport

            Catch ex As Exception

            End Try
        ElseIf Request.QueryString("RptT") = "Det" Then
            Try
                Dim crReportDocument As rptReceivedDetailByEmp
                crReportDocument = New rptReceivedDetailByEmp
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
                crParameterDiscreteValue.Value = Request.QueryString("emp")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Request.QueryString("FDt")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Request.QueryString("TDt")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Request.QueryString("Type")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                CrystalReportViewer1.ReportSource = crReportDocument
            Catch ex As Exception

            End Try
        End If

    End Sub
End Class