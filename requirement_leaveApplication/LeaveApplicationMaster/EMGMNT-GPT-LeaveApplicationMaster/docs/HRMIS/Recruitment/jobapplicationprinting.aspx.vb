Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class jobapplicationprinting
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.rptcon()

        Dim crReportDocument As CrystalReport3

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New CrystalReport3

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





        Dim sno, ssno, crysno As String
        If Session("apno") <> "" Then
            crysno = Session("apno")
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{jobapplication.applicationno} = " & crysno & " "

        ElseIf IsNumeric(Session("noap")) = True Then
            sno = Session("noap").ToString
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{jobapplication.applicationno} = " & sno & " "

        ElseIf IsNumeric(Session("appln").ToString) = True Then
            ssno = Session("appln").ToString
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{jobapplication.applicationno} = " & ssno & " "
        End If
        Session("apno") = ""
        Session("noap") = ""
        Session("appln") = ""
        crysno = ""
        sno = ""
        ssno = ""
    End Sub

    Protected Sub CrystalReportViewer1_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Init

    End Sub
End Class