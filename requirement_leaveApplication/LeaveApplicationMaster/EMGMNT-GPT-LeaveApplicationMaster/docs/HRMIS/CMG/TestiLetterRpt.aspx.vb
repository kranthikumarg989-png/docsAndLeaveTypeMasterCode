Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TestiLetterRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim ename, eicno As String
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")
        Dim letdt As String = Session("dlt")
        ename = LTrim(RTrim(Session("LTname")))

        MyGlobal.rptcon()

        Dim crReportDocument As emp_testimonial

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New emp_testimonial

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


        'CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{emp_modified.empcode} = '" & ename & "' and {emp_modified.letterdate}= (CDateTime ('" & ldate & "'))"
        crReportDocument.RecordSelectionFormula = "{emp_testimonial.empcode} = '" & ename & "' and {emp_testimonial.vdate}= (CDateTime ('" & letdt & "')) and {emp_testimonial.fromdate}= (CDateTime ('" & fromd & "')) and {emp_testimonial.todate}= (CDateTime ('" & tod & "'))"
        CrystalReportViewer1.ReportSource = crReportDocument
      

    End Sub

End Class