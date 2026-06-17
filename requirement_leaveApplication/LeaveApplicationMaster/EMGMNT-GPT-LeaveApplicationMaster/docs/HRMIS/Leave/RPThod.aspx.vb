
Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class RPThod
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (32)
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


        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")
        ' Session("_edept") = "9000"

        thisdate = DateTime.Now

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (32)
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
    Protected Sub hodrdorpt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hodrdorpt.SelectedIndexChanged
        If hodrdorpt.SelectedValue = "Sect" Then
            hodddlsect.Enabled = True
            hodtxtemp.Text = ""
            hodtxtemp.Enabled = False
        ElseIf hodrdorpt.SelectedValue = "Emp" Then
            hodtxtemp.Enabled = True
            hodddlsect.Enabled = False
        Else
            hodtxtemp.Enabled = False
            hodddlsect.Enabled = False
        End If

    End Sub
    Protected Sub hodbtnrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hodbtnrpt.Click




        Session("hodstatus") = hodrdooptions.SelectedValue.Trim
        Session("hodrptby") = hodrdorpt.SelectedValue.Trim
        Session("hodemp") = hodtxtemp.Text.Trim
        Session("hodsect") = hodddlsect.SelectedValue.Trim
        Session("hoddept") = Session("_edept")

        Dim rdvalue As String = Session("hodrptby")
        Dim empid As String = Session("hodemp")
        Dim status As String = Session("hodstatus")


        Dim fd1 As String
        fd1 = hodtxtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        Session("hodfromd") = CDate(fd1)

        Dim td1 As String
        td1 = hodtxtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        Session("hodtod") = CDate(td1)

        If rdvalue = "Sect" And hodddlsect.SelectedValue <> "" Then
            Response.Redirect("~/hrmis/leave/reports/leave_hod_sect.aspx")
        ElseIf rdvalue = "Emp" And hodtxtemp.Text <> "" Then
            CheckEmpDetails(_edept, empid)
            If dsdata1.Tables(0).Rows.Count <> 0 Then
                If recstatus = "true" Then
                    Response.Redirect("~/hrmis/leave/reports/leave_hod_emp.aspx")
                Else
                    MessageBox("Employee Does not belongs to your department")
                End If
            Else
                MessageBox("Employee Does not belongs to your department")
            End If
        Else
            Response.Redirect("~/hrmis/leave/reports/leave_hod_all.aspx")
        End If



    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub hodtxtemp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hodtxtemp.TextChanged

    End Sub
End Class