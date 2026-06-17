Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class RptOTBudgetSetting
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (72)
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


    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("budgetfrom") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("budgetto") = td

        Dim options As String
        options = RadioButtonList1.SelectedValue
        If options = "OD" And ddldeptr.SelectedValue = "-1" Then
            lblmsg.Text = "Select a Department!!!"
            Exit Sub

        End If
        If options = "S" And ddlsectrpt.SelectedValue = "-1" Then
            lblmsg.Text = "Select a Section!!!"
            Exit Sub
        End If

        If options = "OD" Then
            Session("budgetopn") = "dept"
            Session("budgetval") = ddldeptr.SelectedValue
            Response.Redirect("RptBudgetOTalldept.aspx")
        ElseIf options = "S" Then
            Session("budgetopn") = "sect"
            Session("budgetval") = ddlsectrpt.SelectedValue
            Response.Redirect("RptBudgetOTalldept.aspx")
        ElseIf options = "IS" Then
            Session("budgetopn") = "IS"
            Session("budgetval") = ddlsectrpt.SelectedValue
            Response.Redirect("RptBudgetOTalldept.aspx")
        ElseIf options = "CSO" Then
            Response.Redirect("RptOTBudgetcsc.aspx")
        ElseIf options = "OSO" Then
            Response.Redirect("RptBudgetOverall.aspx")

        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim options As String
        options = RadioButtonList1.SelectedValue
        If options = "OD" Then
            ddldeptr.Visible = True
            ddlsectrpt.Visible = False
        ElseIf options = "S" Then
            ddldeptr.Visible = False
            ddlsectrpt.Visible = True
        ElseIf options = "CSO" Then
            ddldeptr.Visible = False
            ddlsectrpt.Visible = False
        ElseIf options = "OSO" Then
            ddldeptr.Visible = False
            ddlsectrpt.Visible = False
        ElseIf options = "IS" Then
            ddldeptr.Visible = False
            ddlsectrpt.Visible = False
        End If
        lblmsg.Text = ""
    End Sub
End Class