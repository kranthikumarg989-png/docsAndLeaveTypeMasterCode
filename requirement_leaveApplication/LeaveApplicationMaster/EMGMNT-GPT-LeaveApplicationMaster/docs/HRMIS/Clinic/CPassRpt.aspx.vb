Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class CPassRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (46)
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

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        Session("CPdesig") = Trim(ddldesigr.SelectedValue)
        Session("CPemp") = Trim(txtempidr.Text)
        Session("CPsect") = Trim(ddlsectrpt.SelectedValue)
        Session("CPdept") = ddldeptr.SelectedValue.Trim


        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("CPfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("CPtod") = td


        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            Session("CPstat") = "D"
        ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
            Session("CPstat") = "S"
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            Session("CPstat") = "Desi"
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            Session("CPstat") = "E"
        Else
            Session("CPstat") = "O"
        End If

        Response.Redirect("CPREPORTS.aspx")
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
End Class