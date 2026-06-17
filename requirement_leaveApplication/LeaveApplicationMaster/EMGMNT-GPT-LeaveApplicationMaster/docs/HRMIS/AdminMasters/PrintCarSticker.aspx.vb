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
Imports System.Drawing.Printing


Partial Public Class PrintCarSticker
    Inherits System.Web.UI.Page


    Dim crReportDocument1 As CarSticker
    Dim crReportDocument2
    Dim crReportDocument3 As CarSticker2
   


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


            InitializeComponent()


            Dim Opt1 As String


            If Session("rpttype") = "Employee" Then
                crReportDocument2 = New CarSticker
                Opt1 = "Print"
            ElseIf Session("rpttype") = "Supplier" Then
                crReportDocument2 = New CarSticker2
                Opt1 = "Print2"

            End If


            ' crReportDocument2 = New CarSticker
            crConnectionInfo = New ConnectionInfo

            With crConnectionInfo
                .ServerName = "192.168.0.241"
                .DatabaseName = "HRMIS"
                .UserID = "SA"
                .Password = ""
              
                '.ServerName = "PROGRAMMER1\SQLEXPRESS"
                '.DatabaseName = "hrmis"
                '.UserID = ""
                '.Password = ""
            End With

            'Get the tables collection from the report object
            crDatabase = crReportDocument2.Database
            crTables = crDatabase.Tables

            'Apply the logon information to each table in the collection
            For Each crTable In crTables

                crTableLogOnInfo = crTable.LogOnInfo
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                crTable.ApplyLogOnInfo(crTableLogOnInfo)
            Next


            'Dim myTextObjectOnReport As CrystalDecisions.CrystalReports.Engine.TextObject
            'myTextObjectOnReport = CType(crReportDocument2.ReportDefinition.ReportObjects.Item("Text6"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'myTextObjectOnReport.Text = "Canteen Accounts Details By Department"

            'Dim D1 As New DateTime
            'D1 = Convert.ToDateTime(Session("cn_to1").ToString())
            'D1 = D1.AddDays(-1)


            'myTextObjectOnReport = CType(crReportDocument2.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'myTextObjectOnReport.Text = "From  " & Session("cn_from1").ToString & "  To  " & D1.ToString("dd-MMM-yyyy")

            'myTextObjectOnReport = CType(crReportDocument2.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'myTextObjectOnReport.Text = Session("msg").ToString


            crParameterFieldDefinitions = crReportDocument2.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()


            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Opt1
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Session("cempcode")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Session("cempcode")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 0
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = DateTime.Now
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(5)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 0
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(6)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = DateTime.Now
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(7)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = "-"
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(8)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = "-"
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item(9)
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = "-"
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            
            If IsPostBack = False Then
                CrystalReportViewer1.ReportSource = crReportDocument2
                'Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", Print(), True)


            End If

        End If


    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "HRMIS"
        _applyLogin._ServerName = "192.168.0.241"
        _applyLogin._UserId = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

        '_applyLogin._dbName = "hrmis"
        '_applyLogin._ServerName = "PROGRAMMER1\SQLEXPRESS"
        '_applyLogin._UserId = ""
        '_applyLogin._PassWord = ""
        '_applyLogin.ApplyInfo(oRpt)


        'clean up
        ' _applyLogin = Nothing

    End Sub

#End Region

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim printerSettings As PrinterSettings = New PrinterSettings()
        ''Dim pd As New PrintDialog()
        'Dim printDialog As PrintDialog = New PrintDialog()
        'printDialog.PrinterSettings = printerSettings
        'printDialog.AllowPrintToFile = False
        'printDialog.AllowSomePages = True
        'printDialog.UseEXDialog = True

        'crReportDocument2.PrintOptions.PrinterName = PrinterSettings.PrinterName()
        'crReportDocument2.PrintToPrinter(1, False, 0, 0)
        'crReportDocument2.PrintToPrinter(1, True, 1, 1)


        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "Print();", True)
        If Session("licpage") = "LicMaster" Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script1", "window.location.href='UpdateLicenseInfo.aspx';", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script1", "window.location.href='Vehiclepass_Print.aspx';", True)
        End If

        'Response.Redirect("Vehiclepass_Print.aspx")
    End Sub

End Class