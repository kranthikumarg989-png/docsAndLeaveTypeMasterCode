Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Public Class Preliminarycounselling
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim emp
    Dim ltdt

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        emp = Session("ERpcemp")
        ltdt = Session("ERpcltdt")
        '' CR variables
        MyGlobal.rptcon()

        Dim crReportDocument As er_preliminarycounseling

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New er_preliminarycounseling

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

        crReportDocument.RecordSelectionFormula = "{er_preliminarycounseling.empcode} = '" & emp & "' and {er_preliminarycounseling.letterdate}= (CDateTime ('" & (ltdt) & "'))"
        '   crReportDocument.RecordSelectionFormula = "{er_preliminarycounseling.empcode} = '" & emp & "' and {er_preliminarycounseling.letterdate}= '" & ltdt & "'"
        CrystalReportViewer1.ReportSource = crReportDocument

    End Sub

End Class