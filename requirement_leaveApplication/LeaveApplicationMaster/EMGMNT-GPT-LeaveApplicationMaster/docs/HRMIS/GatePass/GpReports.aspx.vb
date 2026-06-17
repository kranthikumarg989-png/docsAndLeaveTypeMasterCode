Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class GpReports
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection
    Dim com, com1 As New SqlCommand
    Dim status As Boolean
    Dim hdlstatus As Boolean
    Dim thisdate As Date
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim passno, recno As String
    Dim id, rno As Integer
    Dim curdate As Date
    Dim empID As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (41)
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

        Session("gpdesi") = Trim(ddldesigr.SelectedValue)
        Session("gpemp") = Trim(txtempidr.Text)
        Session("gpdept") = ddldeptr.SelectedValue.Trim
        Session("gpsect") = ddlsectr.SelectedValue.Trim
        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("gpfd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("gptd") = td

        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            '  Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpdept.aspx?fromd={0}&tod={1}&dep={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, ddldeptr.SelectedValue))
            Response.Redirect("~/hrmis/Gatepass/reports/CrvGpdept.aspx")
        ElseIf rdvalue = "Sect" And ddlsectr.SelectedValue <> "" Then
            'Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CvGpSect.aspx?fromd={0}&tod={1}&sec={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, ddlsectr.SelectedValue))
            Response.Redirect("~/hrmis/Gatepass/reports/CvGpSect.aspx")
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            ' Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpdesig.aspx?fromd={0}&tod={1}&desi={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, designation))
            Response.Redirect("~/hrmis/Gatepass/reports/CrvGpdesig.aspx")
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            'Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpemp.aspx?fromd={0}&tod={1}&emp={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, empid))
            Response.Redirect("~/hrmis/Gatepass/reports/CrvGpemp.aspx")
        Else
            ' Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpall.aspx?fromd={0}&tod={1}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td))
            Response.Redirect("~/hrmis/Gatepass/reports/CrvGpall.aspx")
        End If

    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            lbldeptr.Enabled = True
            lblsectr.Enabled = False
            ddlsectr.Enabled = False
            lbldesigr.Enabled = False
            ddldesigr.Enabled = False
            lblempr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            lblsectr.Enabled = True
            ddlsectr.Enabled = True
            lbldesigr.Enabled = False
            ddldesigr.Enabled = False
            ddldeptr.Enabled = False
            lbldeptr.Enabled = False
            lblempr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            lbldesigr.Enabled = True
            ddldesigr.Enabled = True
            ddldeptr.Enabled = False
            lbldeptr.Enabled = False
            lblsectr.Enabled = False
            ddlsectr.Enabled = False
            lblempr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            lblempr.Enabled = True
            txtempidr.Enabled = True
            ddldeptr.Enabled = False
            lbldeptr.Enabled = False
            lblsectr.Enabled = False
            ddlsectr.Enabled = False
            lbldesigr.Enabled = False
            ddldesigr.Enabled = False
        End If
    End Sub
End Class