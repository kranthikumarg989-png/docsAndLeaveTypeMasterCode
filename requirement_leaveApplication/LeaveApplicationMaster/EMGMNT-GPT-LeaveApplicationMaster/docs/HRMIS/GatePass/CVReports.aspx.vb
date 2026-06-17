Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CVReports
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (40)
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

    Private Sub btnCvReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCvReport.Click
        '  Response.Redirect("~\Reports\Hrmis\CrvCSall.aspx?fromd=" + txtfrom.Text + " &tod=" + txtto.Text + "")
        Dim fd1 As String
        fd1 = Txtcsf.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("cvfd") = fd

        Dim td1 As String
        td1 = txtcst.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("cvtd") = td

        ' btnCvReport.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/Crvcsall.aspx?fromd={0}&tod={1}','_blank','fullscreen=yes,scrollbars=yes,menubar=yes')", fd, td))
        Response.Redirect("~/hrmis/Gatepass/reports/Crvcsall.aspx")

    End Sub
End Class