Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class AptLetCleanerRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim ename, eicno, wename, wit As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fromd As String = Session("efffrom")
        Dim tod As String = Session("effto")
        Dim ldate As String = Session("letdet")
        ename = LTrim(RTrim(Session("AFNname")))
        wename = LTrim(RTrim(Session("AFNwname")))

        Dim crReportDocument As emp_cleanerletter
        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New emp_cleanerletter

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

        crReportDocument.RecordSelectionFormula = "{emp_modified.empcode} = '" & ename & "'"
        CrystalReportViewer1.ReportSource = crReportDocument

        'CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{emp_modified.empcode} = '" & ename & "'"

    End Sub

End Class