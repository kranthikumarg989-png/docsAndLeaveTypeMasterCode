Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ApptPartTimeRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim ename, eicno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim joindt As String = Session("doj")
        Dim letdt As String = Session("doi")
        ename = LTrim(RTrim(Session("PEname")))
        eicno = LTrim(RTrim(Session("PEicno")))

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyGlobal.rptcon()

        Dim crReportDocument As emp_parttimeappointment


        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New emp_parttimeappointment

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

        crReportDocument.RecordSelectionFormula = "{emp_parttimeletter.icno} = '" & eicno & "' and {emp_parttimeletter.letterdate}= (CDateTime ('" & letdt & "'))"
        CrystalReportViewer1.ReportSource = crReportDocument


      

    End Sub

End Class