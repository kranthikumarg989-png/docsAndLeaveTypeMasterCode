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

Partial Public Class CanteenDetailedReport
    Inherits System.Web.UI.Page

    Dim crReportDocument As OverallAccountDetails
    Dim crReportDocument2 As Summary
    Dim crReportDocument3 As SummaryBySection
    Dim crReportDocument4 As SummaryByDate
    Dim crReportDocument5 As SummaryByCanteen


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

            If Session("cn_option") = "DepartmentSummary" Then
                crReportDocument2 = New Summary
                crConnectionInfo = New ConnectionInfo

                With crConnectionInfo
                    .ServerName = "192.168.0.241"
                    .DatabaseName = "HRMIS"
                    .UserID = "SA"
                    .Password = ""
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


                Dim myTextObjectOnReport As CrystalDecisions.CrystalReports.Engine.TextObject
                myTextObjectOnReport = CType(crReportDocument2.ReportDefinition.ReportObjects.Item("Text6"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "Canteen Accounts Details By Department"

                Dim D1 As New DateTime
                D1 = Convert.ToDateTime(Session("cn_to1").ToString())
                D1 = D1.AddDays(-1)


                myTextObjectOnReport = CType(crReportDocument2.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "From  " & Session("cn_from1").ToString & "  To  " & D1.ToString("dd-MMM-yyyy")

                myTextObjectOnReport = CType(crReportDocument2.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = Session("msg").ToString


                crParameterFieldDefinitions = crReportDocument2.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()


                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_from1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_to1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_canteenname")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_department")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_option")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crReportDocument.SetDatabaseLogon("sa", "Admin")
                'Once the connection to the database has been established for
                'each table in the report, the report object can be bound to the viewer
                'using the reportsource property of the viewer to display the report.

                'DoCRLogin(crReportDocument)
                If IsPostBack = False Then
                    CrystalReportViewer1.ReportSource = crReportDocument2
                End If

            ElseIf Session("cn_option") = "SectionSummary" Then
                crReportDocument3 = New SummaryBySection
                crConnectionInfo = New ConnectionInfo

                With crConnectionInfo
                    .ServerName = "192.168.0.241"
                    .DatabaseName = "HRMIS"
                    .UserID = "SA"
                    .Password = ""
                End With

                'Get the tables collection from the report object
                crDatabase = crReportDocument3.Database
                crTables = crDatabase.Tables

                'Apply the logon information to each table in the collection
                For Each crTable In crTables

                    crTableLogOnInfo = crTable.LogOnInfo
                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                Next

                Dim myTextObjectOnReport As CrystalDecisions.CrystalReports.Engine.TextObject
                myTextObjectOnReport = CType(crReportDocument3.ReportDefinition.ReportObjects.Item("Text6"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "Canteen Accounts Details By Section"

                Dim D1 As New DateTime
                D1 = Convert.ToDateTime(Session("cn_to1").ToString())
                D1 = D1.AddDays(-1)


                myTextObjectOnReport = CType(crReportDocument3.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "From  " & Session("cn_from1").ToString & "  To  " & D1.ToString("dd-MMM-yyyy")

                myTextObjectOnReport = CType(crReportDocument3.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = Session("msg").ToString


                crParameterFieldDefinitions = crReportDocument3.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()


                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_from1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_to1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_canteenname")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_department")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_option")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crReportDocument.SetDatabaseLogon("sa", "Admin")
                'Once the connection to the database has been established for
                'each table in the report, the report object can be bound to the viewer
                'using the reportsource property of the viewer to display the report.

                'DoCRLogin(crReportDocument)
                If IsPostBack = False Then
                    CrystalReportViewer1.ReportSource = crReportDocument3
                End If

            ElseIf Session("cn_option") = "DateSummary" Then
                crReportDocument4 = New SummaryByDate
                crConnectionInfo = New ConnectionInfo

                With crConnectionInfo
                    .ServerName = "192.168.0.241"
                    .DatabaseName = "HRMIS"
                    .UserID = "SA"
                    .Password = ""
                End With

                'Get the tables collection from the report object
                crDatabase = crReportDocument4.Database
                crTables = crDatabase.Tables

                'Apply the logon information to each table in the collection
                For Each crTable In crTables

                    crTableLogOnInfo = crTable.LogOnInfo
                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                Next

                Dim myTextObjectOnReport As CrystalDecisions.CrystalReports.Engine.TextObject
                myTextObjectOnReport = CType(crReportDocument4.ReportDefinition.ReportObjects.Item("Text6"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "Canteen Accounts Details"

                Dim D1 As New DateTime
                D1 = Convert.ToDateTime(Session("cn_to1").ToString())
                D1 = D1.AddDays(-1)


                myTextObjectOnReport = CType(crReportDocument4.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "From  " & Session("cn_from1").ToString & "  To  " & D1.ToString("dd-MMM-yyyy")


                myTextObjectOnReport = CType(crReportDocument4.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = Session("msg").ToString

                crParameterFieldDefinitions = crReportDocument4.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()


                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_from1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_to1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_canteenname")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_department")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_option")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crReportDocument.SetDatabaseLogon("sa", "Admin")
                'Once the connection to the database has been established for
                'each table in the report, the report object can be bound to the viewer
                'using the reportsource property of the viewer to display the report.

                'DoCRLogin(crReportDocument)
                If IsPostBack = False Then
                    CrystalReportViewer1.ReportSource = crReportDocument4
                End If

            ElseIf Session("cn_option") = "nothing" Then
                crReportDocument = New OverallAccountDetails
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
                myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text6"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "Canteen Accounts Details"

                Dim D1 As New DateTime
                D1 = Convert.ToDateTime(Session("cn_to1").ToString())
                D1 = D1.AddDays(-1)


                myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "From  " & Session("cn_from1").ToString & "  To  " & D1.ToString("dd-MMM-yyyy")


                myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = Session("msg").ToString

                crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()


                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_from1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_to1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_canteenname")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_department")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_option")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crReportDocument.SetDatabaseLogon("sa", "Admin")
                'Once the connection to the database has been established for
                'each table in the report, the report object can be bound to the viewer
                'using the reportsource property of the viewer to display the report.

                'DoCRLogin(crReportDocument)
                If IsPostBack = False Then
                    CrystalReportViewer1.ReportSource = crReportDocument
                End If


            Else

                crReportDocument5 = New SummaryByCanteen
                crConnectionInfo = New ConnectionInfo

                With crConnectionInfo
                    .ServerName = "192.168.0.241"
                    .DatabaseName = "HRMIS"
                    .UserID = "SA"
                    .Password = ""
                End With

                'Get the tables collection from the report object
                crDatabase = crReportDocument5.Database
                crTables = crDatabase.Tables

                'Apply the logon information to each table in the collection
                For Each crTable In crTables

                    crTableLogOnInfo = crTable.LogOnInfo
                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                Next


                Dim myTextObjectOnReport As CrystalDecisions.CrystalReports.Engine.TextObject
                myTextObjectOnReport = CType(crReportDocument5.ReportDefinition.ReportObjects.Item("Text6"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "Canteen Accounts Details"

                Dim D1 As New DateTime
                D1 = Convert.ToDateTime(Session("cn_to1").ToString())
                D1 = D1.AddDays(-1)


                myTextObjectOnReport = CType(crReportDocument5.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = "From  " & Session("cn_from1").ToString & "  To  " & D1.ToString("MM/dd/yyyy")

                myTextObjectOnReport = CType(crReportDocument5.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
                myTextObjectOnReport.Text = Session("msg").ToString


                crParameterFieldDefinitions = crReportDocument5.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()


                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_from1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_to1")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_canteenname")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_department")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Session("cn_option")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crReportDocument.SetDatabaseLogon("sa", "Admin")
                'Once the connection to the database has been established for
                'each table in the report, the report object can be bound to the viewer
                'using the reportsource property of the viewer to display the report.

                'DoCRLogin(crReportDocument)
                If IsPostBack = False Then
                    CrystalReportViewer1.ReportSource = crReportDocument5
                End If

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

        'clean up
        ' _applyLogin = Nothing

    End Sub

#End Region


    Private Sub Loadreport1()

        Dim Str As String

        If Session("cn_option") = "DepartmentSummary" Then
            Str = Server.MapPath("Summary.rpt")
        ElseIf Session("cn_option") = "SectionSummary" Then
            Str = Server.MapPath("SummaryBySection.rpt")
        ElseIf Session("cn_option") = "DateSummary" Then
            Str = Server.MapPath("SummaryByDate.rpt")
        ElseIf Session("cn_option") = "nothing" Then
            Str = Server.MapPath("OverallAccountDetails.rpt")
        Else
            Str = Server.MapPath("SummaryByCanteen.rpt")
        End If

        Cr.Load(Str)

        Cr.SetDataSource(TmpDs.Tables(0))

        CrystalReportViewer1.ReportSource = Cr

        CrystalReportViewer1.RefreshReport()

        CrystalReportViewer1.Visible = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("CanteenReportMain.aspx")
    End Sub
End Class