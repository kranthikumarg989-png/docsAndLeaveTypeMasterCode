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

Partial Public Class FrmLeaveFormView
    Inherits System.Web.UI.Page

    Dim Cmd As New SqlCommand
    Dim SqlCon As New SqlConnection
    Dim SqlCmd As New SqlCommand
    Dim SqlAd As New SqlDataAdapter
    Dim SqlDs As New DataSet

    Dim crReportDocument As CrLeaveFormView

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CallReport()
        Loadreport1()


    End Sub
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init


    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "HRMIS"
        _applyLogin._ServerName = "192.168.0.241"
        _applyLogin._UserId = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

        '_applyLogin._dbName = "HRMIS"
        '_applyLogin._ServerName = "PROGRAMMER3"
        '_applyLogin._UserId = "sa"
        '_applyLogin._PassWord = "123456"
        '_applyLogin.ApplyInfo(oRpt)

    End Sub

#End Region
    Private Sub Loadreport1()
        Dim Str As String


        Str = Server.MapPath("CrLeaveFormView.rpt")
        Cr.Load(Str)
        TmpDs = New DataSet()
        'Dim Rnumber As Integer
        'Rnumber = 1
        Dim appno As String = Session("appnumber")
        Dim appnumber As Integer
        appnumber = Convert.ToInt32(appno)

        TmpDs = GetLeaveFormDetails(appnumber)
        Cr.SetDataSource(TmpDs.Tables(0))
        CrystalReportViewer1.ReportSource = Cr
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.Visible = True



    End Sub


    Private Sub CallReport()

        'ByVal MName As String, ByVal Year As String

        'Start Part
        'TmpDs = New DataSet()
        ''Dim Rnumber As Integer
        ''Rnumber = 1
        'TmpDs = GetPurchaseCostData(MName, Year)
        'Dim Str As String

        'Str = Server.MapPath("PurchasecostgraphReport.rpt")
        'End Part 

        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        crReportDocument = New CrLeaveFormView
        crConnectionInfo = New ConnectionInfo

        With crConnectionInfo
            .ServerName = "192.168.0.241"
            .DatabaseName = "HRMIS"
            .UserID = "sa"
            .Password = ""
        End With

        'With crConnectionInfo
        '    .ServerName = "PROGRAMMER3"
        '    .DatabaseName = "HRMIS"
        '    .UserID = "sa"
        '    .Password = "123456"
        'End With
        'Get the tables collection from the report object
        crDatabase = crReportDocument.Database
        crTables = crDatabase.Tables
        'Apply the logon information to each table in the collection
        For Each crTable In crTables
            crTableLogOnInfo = crTable.LogOnInfo
            crTableLogOnInfo.ConnectionInfo = crConnectionInfo
            crTable.ApplyLogOnInfo(crTableLogOnInfo)
        Next

        CrystalReportViewer1.ReportSource = crReportDocument
        'CrystalReportViewer1.Width = "750px"








    End Sub

    Public Function GetLeaveFormDetails(ByVal Appno As Integer) As DataSet

        'Dim HrmisConstr As String = "User ID=sa;Password=123456;Data Source=PROGRAMMER3;Initial Catalog=HRMIS"
        Dim HrmisConstr As String = "Data Source=192.168.0.241;Initial Catalog=HRMIS;uid=sa;"
        SqlCon = New SqlConnection(HrmisConstr)
        SqlCon.Open()
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "spgetLeaveDetRpt_sa"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Appno", Appno)
        SqlCmd.Connection = SqlCon
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        SqlCon.Close()
        Return SqlDs

    End Function
    Public Function GetLogonInfo() As TableLogOnInfo
        Dim LogonInfo As New TableLogOnInfo
        'Local 
        'LogonInfo.ConnectionInfo.ServerName = "PROGRAMMER3"
        'LogonInfo.ConnectionInfo.DatabaseName = "HRMIS"
        'LogonInfo.ConnectionInfo.UserID = "sa"
        'LogonInfo.ConnectionInfo.Password = "123456"

        'Production
        LogonInfo.ConnectionInfo.ServerName = "192.168.0.241"
        LogonInfo.ConnectionInfo.DatabaseName = "HRMIS"
        LogonInfo.ConnectionInfo.UserID = "SA"
        LogonInfo.ConnectionInfo.Password = ""
        Return LogonInfo
    End Function

End Class