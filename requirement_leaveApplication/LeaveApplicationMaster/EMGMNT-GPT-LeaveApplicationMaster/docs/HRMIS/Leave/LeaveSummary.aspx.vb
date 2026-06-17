Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class LeaveSummary1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"
        'Session("_edept") = "9000"     

        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")
        thisdate = DateTime.Now

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (29)
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

    Protected Sub btnrptsummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrptsummary.Click
   

        Session("rpttype") = rptddlltype.SelectedValue.Trim
        Dim ltype As String = Session("rpttype")

        Dim fd1 As String
        fd1 = rpttxtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        Session("lfromd") = CDate(fd1)

        Dim td1 As String
        td1 = rpttxtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        Session("ltod") = CDate(td1)

        If fd1 <> "" And td1 <> "" And ltype <> "-1" Then
            Response.Redirect("~/hrmis/leave/reports/leavesummary.aspx")
        Else
            MessageBox("Select all Required fields")
        End If

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class