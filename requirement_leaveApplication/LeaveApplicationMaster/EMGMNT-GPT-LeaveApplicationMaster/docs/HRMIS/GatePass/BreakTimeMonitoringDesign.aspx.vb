Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared
Imports E_Management.[Global]
Imports System.IO
Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Net.Security

Partial Public Class BreakTimeMonitoringDesign
    Inherits System.Web.UI.Page

    Dim crReportDocument As StaffBreakTime
    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo
    Dim TmpDs As New DataSet
    Dim Cr As New ReportDocument
    Dim crDiskFileDestinationOptions As DiskFileDestinationOptions
    Dim crExportOptions As ExportOptions

    Dim SaveRptname, saverptname1 As String
    Dim ExportPath, ExportPath1 As String

    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init

        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        If IsPostBack = False Then


            crReportDocument = New StaffBreakTime
            crConnectionInfo = New ConnectionInfo

            With crConnectionInfo
                .ServerName = "192.168.0.252"
                .DatabaseName = "TMS"
                .UserID = "SA"
                .Password = ""
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


            Dim myTextObjectOnReport As CrystalDecisions.CrystalReports.Engine.TextObject
            myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Ttl"), CrystalDecisions.CrystalReports.Engine.TextObject)
            myTextObjectOnReport.Text = Session("ttl").ToString

            crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()

            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = "All"
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Session("frm").ToString
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Session("tod").ToString
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = "-"
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            If IsPostBack = False Then
                If Len(Trim(CStr(Session("brkDeptCode") & ""))) <> 0 Then
                    crReportDocument.RecordSelectionFormula = "{SP_Select_TblCheckinoutSynchronize_BreakTime;1.DepartmentCode} = '" & Session("brkDeptCode") & "'"
                End If
                CrystalReportViewer1.ReportSource = crReportDocument
                Session("brkDeptCode") = ""
            End If
        End If

    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "TMS"
        _applyLogin._ServerName = "192.168.0.252"
        _applyLogin._UserId = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

        'clean up
        ' _applyLogin = Nothing

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class