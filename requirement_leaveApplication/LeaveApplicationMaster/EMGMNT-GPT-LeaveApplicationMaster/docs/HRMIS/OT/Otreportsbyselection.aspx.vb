Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class Otreportsbyselection
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim rptby, status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (71)
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

        '     CrystalReportViewer1.RefreshReport()

        rptby = Session("otRptby")
        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")
        '  status = LTrim(RTrim(Session("Otstatus")))
      
        'rptby = "O"
        'fromd = "01/01/2011"
        'tod = "06/07/2011"

        If rptby = "E" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{otentry.datecheck} >= datetime('" & fromd & "')  And {otentry.datecheck} <= datetime('" & tod & "') and {otentry.Empcode} =  '" & Session("otemp") & "'"
       ElseIf rptby = "D" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{otentry.datecheck} >= datetime('" & fromd & "')  And {otentry.datecheck} <= datetime('" & tod & "') and {empmaster.departmentcode} =  '" & Session("otdept") & "'"
        ElseIf rptby = "Desi" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{otentry.datecheck} >= datetime('" & fromd & "')  And {otentry.datecheck} <= datetime('" & tod & "') and {empmaster.designation} =  '" & Session("otdesig") & "'"
        ElseIf rptby = "S" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{otentry.datecheck} >= datetime('" & fromd & "')  And {otentry.datecheck} <= datetime('" & tod & "') and {empmaster.sectioncode} =  '" & Session("otsect") & "'"
        ElseIf rptby = "O" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{otentry.datecheck} >= datetime('" & fromd & "')  And {otentry.datecheck} <= datetime('" & tod & "')"
        Else

        End If
       
        Session("otemp") = ""
        Session("otdept") = ""
        Session("otdesig") = ""
        Session("otsect") = ""
        Session("allfromd") = ""
        Session("alltod") = ""
        Session("Otstatus") = ""
        Session("otRptby") = ""




    End Sub

End Class