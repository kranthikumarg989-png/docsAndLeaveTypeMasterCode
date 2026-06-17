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


Partial Public Class BonusPointCalculationRep
    Inherits System.Web.UI.Page
    Dim crReportDocument As BonusPoint



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

        CallReport()

    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "HRMIS"
        _applyLogin._ServerName = "192.168.0.241"
        _applyLogin._UserId = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

    End Sub

#End Region


    Private Sub Loadreport1()
        Dim Str As String


        Str = Server.MapPath("BonusPoint.rpt")
        

        Cr.Load(Str)

        Cr.SetDataSource(TmpDs.Tables(0))

        CrystalReportViewer1.ReportSource = Cr

        CrystalReportViewer1.RefreshReport()

        CrystalReportViewer1.Visible = True

    End Sub

    Private Sub CallReport()


        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.

        crReportDocument = New BonusPoint
        crConnectionInfo = New ConnectionInfo

        With crConnectionInfo
            .ServerName = "192.168.0.241"
            .DatabaseName = "HRMIS"
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
        myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text10"), CrystalDecisions.CrystalReports.Engine.TextObject)
        myTextObjectOnReport.Text = "From: " & Session("from1") & " To: " & Convert.ToDateTime(Session("to1").ToString).AddDays(-1).ToString("dd-MMM-yyyy")

        'Dim D1 As New DateTime
        'D1 = Convert.ToDateTime(Session("to1").ToString())
        'D1 = D1.AddDays(-1)

        'myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'myTextObjectOnReport.Text = "From  " & Session("from1").ToString & "  To  " & D1.ToString("dd-MMM-yyyy")

        'myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'myTextObjectOnReport.Text = Session("msg").ToString

        crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()

        crParameterDiscreteValue = New ParameterDiscreteValue()
        crParameterDiscreteValue.Value = Session("from1").ToString
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
        crParameterDiscreteValue = New ParameterDiscreteValue()
        crParameterDiscreteValue.Value = Session("to1").ToString
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = crReportDocument

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class