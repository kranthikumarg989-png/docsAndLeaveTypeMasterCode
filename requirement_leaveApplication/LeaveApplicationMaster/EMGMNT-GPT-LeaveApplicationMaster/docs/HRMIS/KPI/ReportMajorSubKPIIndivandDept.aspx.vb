Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class ReportMajorSubKPIIndivandDept
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (282)
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

    Protected Sub optionsrb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optionsrb.SelectedIndexChanged

        If optionsrb.SelectedValue = "dept" Then
            ddldeptr.Enabled = True
            txtempidr.Enabled = False
        ElseIf optionsrb.SelectedValue = "indiv" Then
            ddldeptr.Enabled = False
            txtempidr.Enabled = True
        End If
    End Sub

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click

        Dim repby As String
        repby = optionsrb.SelectedValue
        Session("repby") = repby
        Dim kpiyr = Trim(yearddl.SelectedValue)
        Session("kpiyr") = kpiyr

        Session("kpidept") = Trim(ddldeptr.SelectedValue)
        Session("kpiemp") = Trim(txtempidr.Text)


        If repby = "dept" And ddldeptr.SelectedValue <> "-1" Then
            Session("kpiRptby") = "D"
            Response.Redirect("RptMajorKPIforDept.aspx")
        ElseIf repby = "indiv" And txtempidr.Text <> "" Then
            chkecode()
        End If

    End Sub

    Private Sub chkecode()
        Dim ecode = txtempidr.Text
        chksubmajor(ecode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                Dim codemp = dr("Employee_Code").ToString
                Dim indi = dr("Individual").ToString
                Response.Redirect("RptMajForIndiv.aspx")
            Else
                Response.Redirect("RptMajandSubForIndiv.aspx")
            End If
        Else
            Response.Redirect("RptMajandSubForIndiv.aspx")
        End If

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class