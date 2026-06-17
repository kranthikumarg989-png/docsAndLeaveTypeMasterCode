Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class AptLocOptMalayRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim ename, eicno As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")
        Dim ldate As String = Session("dlt")
        ename = LTrim(RTrim(Session("OMRname")))
        MyGlobal.rptcon()

        Dim crReportDocument As emp_contractextension

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New emp_contractextension

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

        crReportDocument.RecordSelectionFormula = "{emp_modified.empcode} = '" & ename & "' and {emp_modified.letterdate}= (CDateTime ('" & ldate & "'))"
        CrystalReportViewer1.ReportSource = crReportDocument
        'CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{emp_modified.empcode} = '" & ename & "' and {emp_modified.letterdate}= (CDateTime ('" & ldate & "'))"


    End Sub

End Class