Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.emanagement.[Global]
Partial Public Class BTReportsbySelection
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim stat As String

    Dim cryRpt As New ReportDocument
    Dim CrTables As Tables
    Dim CrTable As Table
    Dim crtableLogoninfos As New TableLogOnInfos
    Dim crtableLogoninfo As New TableLogOnInfo
    Dim crConnectionInfo As New ConnectionInfo


    Private Sub BTReportsbySelection_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Dim ConnInfo As New ConnectionInfo
        'With ConnInfo
        '    .ServerName = sqlServerName
        '    .DatabaseName = sqlDBName
        '    .UserID = sqlUid
        '    .Password = sqlPwd
        'End With

        'cryRpt.Load("btOVERALL.rpt")


        'CrTables = cryRpt.Database.Tables
        'For Each CrTable In CrTables
        '    crtableLogoninfo = CrTable.LogOnInfo
        '    crtableLogoninfo.ConnectionInfo = crConnectionInfo
        '    CrTable.ApplyLogOnInfo(crtableLogoninfo)
        'Next



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (60)
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

        stat = Session("BtStat")
        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")


        If stat = "E" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {acc_businesstrip.Empcode} =  '" & Session("btemp") & "'"
        ElseIf stat = "D" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {empmaster.departmentcode} =  '" & Session("btdept") & "'"
        ElseIf stat = "Desi" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {empmaster.designation} =  '" & Session("btdesig") & "'"
        ElseIf stat = "S" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {empmaster.sectioncode} =  '" & Session("btsect") & "'"
        ElseIf stat = "O" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "')"
        End If


    End Sub

End Class