Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Public Class memoreport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.rptcon()

        Dim crReportDocument As CrystalReport1
        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New CrystalReport1

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

        Dim sno As Integer
        sno = Session("slno")

        crReportDocument.RecordSelectionFormula = "{memo.serialno} = " & sno & ""
        CrystalReportViewer1.ReportSource = crReportDocument

    End Sub
End Class