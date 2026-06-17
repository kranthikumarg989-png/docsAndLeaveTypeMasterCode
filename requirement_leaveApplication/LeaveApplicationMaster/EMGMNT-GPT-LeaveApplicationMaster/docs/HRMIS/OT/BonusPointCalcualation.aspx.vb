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


Partial Public Class BonusPointCalcualation
    Inherits System.Web.UI.Page

   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            TxtFrom.Text = DateTime.Today.AddDays(-(Day(DateTime.Today) - 1)).ToString("dd-MMM-yyyy")
            TxtTo.Text = (Convert.ToDateTime(TxtFrom.Text).AddMonths(1)).AddDays(-1).ToString("dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        From1.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        To1.Visible = True
    End Sub

    Protected Sub From1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles From1.SelectionChanged
        TxtFrom.Text = ""
        TxtFrom.Text = From1.SelectedDate.ToString("dd-MMM-yyyy")
        From1.Visible = False
        Session("from1") = TxtFrom.Text
    End Sub

  

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Session("from1") = TxtFrom.Text
        Session("to1") = Convert.ToDateTime(TxtTo.Text).AddDays(1)
        Response.Redirect("BonusPointCalculationRep.aspx")

    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "HRMIS"
        _applyLogin._ServerName = "192.168.0.241"
        _applyLogin._UserId = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

    End Sub


 

   

    Protected Sub To1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles To1.SelectionChanged
        TxtTo.Text = ""
        TxtTo.Text = To1.SelectedDate.ToString("dd-MMM-yyyy")
        To1.Visible = False
        Session("to1") = Convert.ToDateTime(TxtTo.Text).AddDays(1)
    End Sub
End Class