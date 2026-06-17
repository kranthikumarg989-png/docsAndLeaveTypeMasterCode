Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class TCreportBySelection
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim stat As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (62)
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

        stat = Session("tcStat")
        Dim fromd As String = Session("tcfromd")
        Dim tod As String = Session("tctod")


        If stat = "E" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {acc_businesstrip.Empcode} =  '" & Session("TCemp") & "'"
        ElseIf stat = "D" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {empmaster.departmentcode} =  '" & Session("tcdept") & "'"
        ElseIf stat = "Desi" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {empmaster.designation} =  '" & Session("tcdesig") & "'"
        ElseIf stat = "S" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {empmaster.sectioncode} =  '" & Session("tcsect") & "'"
        ElseIf stat = "O" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "')"
        End If
    End Sub

End Class