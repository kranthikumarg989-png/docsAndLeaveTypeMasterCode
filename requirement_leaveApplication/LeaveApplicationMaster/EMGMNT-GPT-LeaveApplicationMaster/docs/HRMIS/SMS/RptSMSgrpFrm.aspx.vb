Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Web.Security
Imports System.Globalization
Imports E_Management.emanagement.[Global]
Imports e_management.emanagement.NetGlobal
Imports e_management.emanagement.EMSapplications
Partial Public Class RptSMSgrpFrm
    Inherits System.Web.UI.Page
    ' CR variables
    Dim crReportDocument As RptSMSgroups
    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo

    'CR variables export report
    Dim crExportOptions As ExportOptions
    Dim crDiskFileDestinationOptions As DiskFileDestinationOptions
    Dim MyApp As New emanagement.EMSapplications
    Dim MyGlobal As New emanagement.globalinfo
    Dim mynet As New emanagement.Global
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
        InitializeComponent()
        'Create an instance of the strongly-typed report object
        crReportDocument = New RptSMSgroups

        'Create a new instance of the connectioninfo object and
        'set its properties
        'Note: This sample report connects to the sample SQL Server database, Pubs,
        'If you have access to SQL server, enter in your values for the ServerName,
        'UserID and Password properties to connect.  The report included with this
        'sample application connects using OLE-DB and SQL authentication.
        mynet.Application_StartSSS()

        ' *******************************************
        ' Initialize Dropdownlist for Format types
        ' *******************************************

        ''''''''''''''''''''''''''''''''''''''''''''''
        crConnectionInfo = New ConnectionInfo
        With crConnectionInfo
            .ServerName = smssqlServerName
            .DatabaseName = smssqlDBName
            .UserID = smssqlUid
            .Password = smssqlPwd
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

        'Once the connection to the database has been established for
        'each table in the report, the report object can be bound to the viewer
        'using the reportsource property of the viewer to display the report.
        'If Session("CVCHK") = True Then
        '    If Session("Ccode") <> "All" Then
        '        crReportDocument.RecordSelectionFormula = "{hlpgdept.fg_group}= '" & Session("Ccode") & "' and {invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='CV'" ' and Left ({INVDetail.INVNo}, 2)<>'CO' 
        '    Else
        '        crReportDocument.RecordSelectionFormula = "{invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='CV'" 'Left ({INVDetail.INVNo}, 2)<>'NC' and Left ({INVDetail.INVNo}, 2)<>'CO' "
        '    End If
        'ElseIf Session("COCHK") = True Then
        '    If Session("Ccode") <> "All" Then
        '        crReportDocument.RecordSelectionFormula = "{hlpgdept.fg_group}= '" & Session("Ccode") & "' and {invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='CO'" ' and Left ({INVDetail.INVNo}, 2)<>'CO' 
        '    Else
        '        crReportDocument.RecordSelectionFormula = "{invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='CO'" 'Left ({INVDetail.INVNo}, 2)<>'NC' and Left ({INVDetail.INVNo}, 2)<>'CO' "
        '    End If
        'ElseIf Session("DOCHK") = True Then
        '    If Session("Ccode") <> "All" Then
        '        crReportDocument.RecordSelectionFormula = "{hlpgdept.fg_group}= '" & Session("Ccode") & "' and {invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='DO'" ' and Left ({INVDetail.INVNo}, 2)<>'CO' 
        '    Else
        '        crReportDocument.RecordSelectionFormula = "{invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='DO'" 'Left ({INVDetail.INVNo}, 2)<>'NC' and Left ({INVDetail.INVNo}, 2)<>'CO' "
        '    End If
        'ElseIf Session("NCCHK") = True Then
        '    If Session("Ccode") <> "All" Then
        '        crReportDocument.RecordSelectionFormula = "{hlpgdept.fg_group}= '" & Session("Ccode") & "' and {invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='NC'" ' and Left ({INVDetail.INVNo}, 2)<>'CO' 
        '    Else
        '        crReportDocument.RecordSelectionFormula = "{invmaster.invDate} >= Date(" + Format$(Session("startdate"), "yyyy, MM, dd") + ") And {invmaster.invDate} <= Date(" + Format$(Session("enddate"), "yyyy, MM, dd") + ") and Left ({invmaster.INVNo}, 2)='NC'" 'Left ({INVDetail.INVNo}, 2)<>'NC' and Left ({INVDetail.INVNo}, 2)<>'CO' "
        '    End If
        'End If
        'crReportDocument.RecordSelectionFormula = "Left ({INVmaster.INVNo}, 2)='CV'" '"({poDetail.prodqty}-{podetail.invqty}) <> 0 and {POMaster.FCPO}<>'Yes'"
        CrystalReportViewer1.ReportSource = crReportDocument
    End Sub

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (128)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
    End Sub

End Class