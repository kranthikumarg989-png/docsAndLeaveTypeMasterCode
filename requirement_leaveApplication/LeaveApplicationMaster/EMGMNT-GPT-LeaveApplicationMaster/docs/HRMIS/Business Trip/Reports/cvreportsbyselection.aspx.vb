Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class cvreportsbyselection
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim stat As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (61)
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

        stat = Session("cvStat")
        Dim fromd As String = Session("CVfromd")
        Dim tod As String = Session("CVtod")
        Dim rno As Integer
        rno = Session("cvbt")

        If stat = "E" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {acc_businesstrip.Empcode} =  '" & Session("cvemp") & "'"
        ElseIf stat = "B" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {acc_businesstrip.recno} =  " & rno & ""
        ElseIf stat = "C" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "') and {HRMIS_BT_CUSTOMERVISITDETAILS.custname} =  '" & Session("cvcust") & "'"
        ElseIf stat = "O" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{acc_businesstrip.fromDate} >= datetime('" & fromd & "')  And {acc_businesstrip.fromDate} <= datetime('" & tod & "')"
        End If
        MsgBox(Session("cvbt"))
    End Sub

End Class