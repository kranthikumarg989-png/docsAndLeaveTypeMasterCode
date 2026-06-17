Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class Report_MajorSubList
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (81)
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

    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged

        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        End If
    End Sub


    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim opt
        opt = RadioButtonList1.SelectedValue
        If opt = "mth" Then
            ddlmon.Enabled = True
            ddlyr.Enabled = True

        ElseIf opt = "yr" Then
            ddlmon.Enabled = False
            ddlyr.Enabled = True

        End If
    End Sub

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        Dim opt
        opt = RadioButtonList1.SelectedValue

        Session("kpidesig") = Trim(ddldesigr.SelectedValue)
        Session("kpiemp") = Trim(txtempidr.Text)
        Session("kpisect") = Trim(ddlsectrpt.SelectedValue)
        Session("kpidept") = ddldeptr.SelectedValue.Trim
        Session("kpiyr") = ddlyr.SelectedValue.Trim
        Session("kpimon") = ddlmon.SelectedValue.Trim
        Session("Kpimthnday") = opt

        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            Session("kpiRptby") = "D"
        ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
            Session("kpiRptby") = "S"
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            Session("kpiRptby") = "Desi"
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            Session("kpiRptby") = "E"
        Else
            Session("kpiRptby") = "O"
        End If
        If opt = "yr" Then
            Response.Redirect("rptmajorsublistyr.aspx")
        ElseIf opt = "mth" Then
            Response.Redirect("rptkpimajorsublist.aspx")
        End If

    End Sub
End Class