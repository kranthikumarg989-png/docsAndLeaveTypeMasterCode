Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.[Global]
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class CertiLetterRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim ename, eicno As String
    Dim cryRpt As New ReportDocument
    Dim CrTables As Tables
    Dim CrTable As Table
    Dim crtableLogoninfos As New TableLogOnInfos
    Dim crtableLogoninfo As New TableLogOnInfo
    Dim crConnectionInfo As New ConnectionInfo

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
       
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.rptcon()

        Dim hired As String = Session("doh")
        Dim letdt As String = Session("dlt")
        ename = LTrim(RTrim(Session("ECname")))

        Dim crReportDocument As emp_certification

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New emp_certification

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

        crReportDocument.RecordSelectionFormula = "{emp_certification.empcode} = '" & ename & "' and {emp_certification.vdate}= (CDateTime ('" & letdt & "'))"
        CrystalReportViewer1.ReportSource = crReportDocument

        '  CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{emp_certification.empcode} = '" & ename & "' and {emp_certification.vdate}= (CDateTime ('" & letdt & "'))"


    End Sub

End Class