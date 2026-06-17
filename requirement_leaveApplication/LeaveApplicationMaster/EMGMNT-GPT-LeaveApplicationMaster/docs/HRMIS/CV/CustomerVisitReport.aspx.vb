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
Imports System.Web.Security



Partial Public Class CustomerVisitReport
    Inherits Messagebox

    Dim crReportDocument As CustomerVisitNew
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

            crReportDocument = New CustomerVisitNew
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

            crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()

            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Session("reprefno").ToString
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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LoadReport1()


        Catch ex As Exception

        End Try
    End Sub


    Private Sub LoadReport1()
        Try
            Dim mynet As New CRMlognetglobal
            mynet.db_cn()
            mynet.db_open()

            TmpDs = New DataSet()
            TmpDs = mynet.SelectCVData(mynet.sConnString2, Session("reprefno").ToString)

            If TmpDs.Tables(0).Rows.Count <= 0 Then
                Response.Redirect("CustomerVisitApprovalForm.aspx")
                Exit Sub

            End If

            Dim Str As String = Server.MapPath("CustomerVisitNew.rpt")
            Cr.Load(Str)

            Cr.SetDataSource(TmpDs.Tables(0))

            CrystalReportViewer1.ReportSource = Cr

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True



            If Session("mlsts") = "t" Then
                SaveRptname = "Customer Visit" & " Name " & Session("custother").ToString & " From " & Session("frm").ToString & " To " & Session("to").ToString & " Department" & Session("cvdepartment") & ".PDF"

                ExportPath = "\\192.168.0.241\DailyDB\CustomerVisit\"
                If Directory.Exists(ExportPath) = False Then
                    Directory.CreateDirectory(ExportPath)
                End If



                crDiskFileDestinationOptions = New DiskFileDestinationOptions
                crExportOptions = crReportDocument.ExportOptions

                Select Case "Portable Document (PDF)"

                    Case "Portable Document (PDF)"

                        crDiskFileDestinationOptions.DiskFileName = ExportPath + SaveRptname

                        With crExportOptions
                            .DestinationOptions = crDiskFileDestinationOptions
                            .ExportDestinationType = ExportDestinationType.DiskFile
                            .ExportFormatType = ExportFormatType.PortableDocFormat
                        End With

                End Select


                crReportDocument.Export()



                Dim attachments = ExportPath & SaveRptname

                Dim filExist As FileInfo = New FileInfo(attachments)

               
                If filExist.Exists = True Then
                    SendSMTP("dashboard@maruwa.com.my", "hod@maruwa.com.my", "Customer Visit" & " Name " & Session("custother").ToString & " From " & Session("frm").ToString & " To " & Session("to").ToString & " Department " & Session("cvdepartment"), "Customer Visit" & " Name " & Session("custother").ToString & " From " & Session("frm").ToString & " To " & Session("to").ToString & " Department " & Session("cvdepartment") & ",  Person Incharge Please Acknowledge by System", "ravi@maruwa.com.my", attachments) 'anthony@maruwa.com.my CC
                    SendSMTP("dashboard@maruwa.com.my", "cs@maruwa.com.my", "Customer Visit" & " Name " & Session("custother").ToString & " From " & Session("frm").ToString & " To " & Session("to").ToString & " Department " & Session("cvdepartment"), "Customer Visit" & " Name " & Session("custother").ToString & " From " & Session("frm").ToString & " To " & Session("to").ToString & " Department " & Session("cvdepartment") & ",  Person Incharge Please Acknowledge by System", "it@maruwa.com.my", attachments)
                End If

                Session("mlsts") = ""
                Response.Redirect("CustomerVisitApprovalForm.aspx")

            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Sub SendSMTP(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, ByVal strCC As String, ByVal strAttachments As String)
        Try

            Dim insMail As New MailMessage(New MailAddress(strFrom), New MailAddress(strTo))
            'Dim Authentication As New Net.NetworkCredential("it", "NowMail", "maruwa")
            With insMail
                .Subject = strSubject
                .Body = strBody
                .CC.Add(New MailAddress(strCC))
                If Not strAttachments.Equals(String.Empty) Then
                    Dim strFile As String
                    Dim strAttach() As String = strAttachments.Split(";"c)
                    For Each strFile In strAttach
                        .Attachments.Add(New Attachment(strFile.Trim()))
                    Next
                End If
            End With

            'insMail.Priority = MailPriority.Normal

            Dim smtp As New System.Net.Mail.SmtpClient
            'smtp.Host = "58.26.100.35"
            smtp.Host = "172.16.0.11"
            smtp.Port = 25


            smtp.Send(insMail)
            insMail.Dispose()
        Catch err As Exception
            'MsgBox(err.Message)
        End Try
    End Sub

    Public Sub SendSMTP_NOCC(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, ByVal strCC As String, ByVal strAttachments As String)
        Try

            Dim insMail As New MailMessage(New MailAddress(strFrom), New MailAddress(strTo))
            'Dim Authentication As New Net.NetworkCredential("it", "NowMail", "maruwa")
            With insMail
                .Subject = strSubject
                .Body = strBody
                '.CC.Add(New MailAddress(strCC))
                If Not strAttachments.Equals(String.Empty) Then
                    Dim strFile As String
                    Dim strAttach() As String = strAttachments.Split(";"c)
                    For Each strFile In strAttach
                        .Attachments.Add(New Attachment(strFile.Trim()))
                    Next
                End If
            End With

            'insMail.Priority = MailPriority.Normal

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "172.16.0.11"
            smtp.Port = 25


            smtp.Send(insMail)
            insMail.Dispose()
        Catch err As Exception
            'MsgBox(err.Message)
        End Try
    End Sub


    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("CustomerVisitApprovalForm.aspx")
    End Sub
End Class