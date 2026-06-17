Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PRReports
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (238)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click

        If (DropDownList1.SelectedValue = "-1" And CheckBox1.Checked = False) Then
            MessageBox("Please select a group")
            Exit Sub
        End If

        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        Session("PRdesig") = Trim(ddldesigr.SelectedValue)
        Session("PRemp") = Trim(txtempidr.Text)
        Session("PRsect") = Trim(ddlsectrpt.SelectedValue)
        Session("PRdept") = ddldeptr.SelectedValue.Trim
        Session("prcate") = DropDownList3.SelectedValue.Trim

        If CheckBox1.Checked = True Then
            Session("prgrp") = "ag"
        Else
            Session("Prgrp") = DropDownList1.SelectedValue.Trim
        End If

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("fmonth") = strdate(1)
        'MsgBox(strdate(1))
        Session("fyear") = strdate(2)

        Session("Prfromd") = fd
        Session("fromff") = txtfrom.Text.Trim


        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)


        Dim td As Date
        td = CDate(td1)
        Session("Prtod") = td
        Session("toff") = txtto.Text.Trim


        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            Session("PRRptby") = "dept"
        ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
            Session("PRRptby") = "sect"
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            Session("PrRptby") = "desig"
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            Session("PrRptby") = "emp"
        Else
            Session("PRRptby") = "O"
        End If

        Response.Redirect("Prreportview.aspx")

    End Sub
End Class