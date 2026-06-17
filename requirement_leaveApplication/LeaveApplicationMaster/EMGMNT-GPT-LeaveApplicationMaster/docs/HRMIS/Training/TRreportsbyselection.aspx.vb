Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class TRreportsbyselection
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim stat As String
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        stat = LTrim(RTrim(Session("trstat"))) 'dept,sect,desig,emp,all
        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")

        ' CR variables
        MyGlobal.rptcon()

        Dim crReportDocument As trainingreports

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New trainingreports

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


        If stat = "E" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {td_employeetraining.empcode} =  '" & Session("tremp") & "'"
        ElseIf stat = "D" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {empmaster.departmentcode} =  '" & Session("trdept") & "'"
        ElseIf stat = "Desi" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {ttd_employeetraining.td_dateattended} <= datetime('" & tod & "') and {empmaster.designation} =  '" & Session("trdesig") & "'"
        ElseIf stat = "S" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {empmaster.sectioncode} =  '" & Session("trsect") & "'"
        ElseIf stat = "O" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "')"
        ElseIf stat = "DD" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {empmaster.designation} =  '" & Session("trdesig1") & "'and {empmaster.departmentcode} =  '" & Session("trdept1") & "'"
        ElseIf stat = "T" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {td_employeetraining.td_trainingattended} =  '" & Session("trtr") & "'"
        ElseIf stat = "P" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {td_employeetraining.td_programme} = '" & Session("trpc") & "'"
        ElseIf stat = "M" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {td_employeetraining.Method} = '" & Session("trpc") & "'"
        ElseIf stat = "Y" Then
            crReportDocument.RecordSelectionFormula = "{td_employeetraining.td_dateattended} >= datetime('" & fromd & "')  And {td_employeetraining.td_dateattended} <= datetime('" & tod & "') and {td_employeetraining.Type} = '" & Session("trpc") & "'"

        End If

        CrystalReportViewer1.ReportSource = crReportDocument
    End Sub

End Class