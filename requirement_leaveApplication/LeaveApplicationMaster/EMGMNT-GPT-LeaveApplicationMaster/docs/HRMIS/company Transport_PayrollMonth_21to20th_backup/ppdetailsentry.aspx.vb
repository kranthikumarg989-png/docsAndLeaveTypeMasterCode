Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ppdetailsentry
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (103)
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
        MyApp.GetfiscalYear()
    End Sub

    Protected Sub bsave_passport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsave_passport.Click
        Dim fd1 As String
        fd1 = tpedate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = tdatearrived.Text.Trim
        Dim strdated() As String = td1.Split("/"c)
        td1 = strdated(1) & "/" & strdated(0) & "/" & strdated(2)

        Dim td As Date
        td = CDate(td1)
        _eid = Session("empcode")

        Try
            Insertpassportdetails(tpeno.Text, tppno.Text, tpename.Text, fd, tpissuedcountry.Text, tpissuedplace.Text, Convert.ToString(dpgrp.SelectedValue.Trim), Convert.ToString(tpcountry.SelectedValue.Trim), tpaddress.Text, td)

            MessageBox("Record Saved successfully")
            tpeno.Text = ""
            tppno.Text = ""
            tpename.Text = ""
            tpdept.Text = ""
            tpsect.Text = ""
            tpissuedplace.Text = ""
            tpaddress.Text = ""
            tdatearrived.Text = ""
            tpgender.Text = ""
            tpissuedcountry.Text = ""
            tpdesig.Text = ""
            tpcountry.SelectedValue = "-"
            dpgrp.SelectedValue = "-"
            tpedate.Text = ""
            MessageBox("Record Saved!!")
           

        Catch ex As Exception
            MessageBox("Cannot Save Data" & ex.Message)
        End Try
    End Sub

    Protected Sub tpeno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpeno.TextChanged
        empcode = tpeno.Text.Trim
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                tpename.Text = dr("empname").ToString
                tpsect.Text = dr("sectioncode").ToString
                tpdept.Text = dr("departmentcode").ToString
                tpdesig.Text = dr("designation").ToString
                tpgender.Text = dr("sex").ToString
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                tpeno.Text = ""
                tpename.Text = ""
                tpsect.Text = ""
                tpdept.Text = ""
                tpdesig.Text = ""
                tpgender.Text = ""
            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class