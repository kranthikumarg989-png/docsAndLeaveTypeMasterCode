Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.globalinfo
Partial Public Class birthdayreportsMelaka
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim stat As String
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()

        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")
        Dim fd As String = Session("fd")
        Dim td As String = Session("td")
        Dim frommonth As String = Session("fromdm")
        Dim fromdate As String = Session("fromdd")
        Dim tomonth As String = Session("todm")
        Dim todate As String = Session("todd")
        Dim comp As String = Session("RComp")
        Dim resign = "N"

        MyGlobal.rptcon()
        CrystalReportViewer1.LogOnInfo = New CrystalDecisions.Shared.TableLogOnInfos()
        Dim LogonInfo As New CrystalDecisions.Shared.TableLogOnInfo
        LogonInfo.TableName = "empmaster"

        LogonInfo.ConnectionInfo.ServerName = "192.168.0.252" '<- ignores changes to this!!
        LogonInfo.ConnectionInfo.DatabaseName = "melhrmis" '<- ignores changes to this!!
        LogonInfo.ConnectionInfo.UserID = uid '<- accepts changes to this!!
        LogonInfo.ConnectionInfo.Password = pw '<- accepts changes to this!!



        CrystalReportViewer1.LogOnInfo.Add(LogonInfo)
        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{empmaster.resigned} =  'N' and Month(CDate({empmaster.dateofbirth})) >= " & frommonth & " and Month(CDate({empmaster.dateofbirth})) <= " & tomonth & " and Day(CDate({empmaster.dateofbirth})) >= " & fromdate & " and Day(CDate({empmaster.dateofbirth})) <= " & todate & " "
        'selectionFormula = selectionFormula & " Order by {Invoice_Header.Tech Number} "

    End Sub



End Class