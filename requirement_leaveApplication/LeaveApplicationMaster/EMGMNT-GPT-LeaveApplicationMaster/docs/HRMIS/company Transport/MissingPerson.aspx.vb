Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class MissingPerson
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
            MyScreenId = (104)
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
    Protected Sub txtbtnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbtnsave.Click
        Dim md1 As String
        md1 = txtmissing.Text.Trim
        Dim mdate() As String
        mdate = md1.Split("/"c)
        md1 = mdate(1) & "/" & mdate(0) & "/" & mdate(2)
        Dim md As Date
        md = CDate(md1)

        Dim cd1 As String
        cd1 = txtcdate.Text.Trim
        Dim cpdate() As String
        cpdate = cd1.Split("/"c)
        cd1 = cpdate(1) & "/" & cpdate(0) & "/" & cpdate(2)
        Dim cd As Date
        cd = CDate(cd1)

        Dim id1 As String
        id1 = txtidate.Text.Trim
        Dim idate() As String
        idate = id1.Split("/"c)
        id1 = idate(1) & "/" & idate(0) & "/" & idate(2)
        Dim idd As Date
        idd = CDate(id1)

        Dim ed1 As String
        ed1 = txtedate.Text.Trim
        Dim emdate() As String
        emdate = ed1.Split("/"c)
        ed1 = emdate(1) & "/" & emdate(0) & "/" & emdate(2)
        Dim emd As Date
        emd = CDate(ed1)
        _eid = Session("empcode")
        Try
            InsertMissingPerson(txtecode.Text.Trim, md, txtpoliceno.Text.Trim, txtstation.Text.Trim, txtpofficer.Text.Trim, txtpplace.Text.Trim, cd, txtfile.Text.Trim, txtpamt.Text.Trim, txtimm.Text.Trim, txtiofficer.Text.Trim, txtiplace.Text.Trim, idd, txtierofficer.Text.Trim, txtembasssy.Text.Trim, txteplace.Text.Trim, txteofficer.Text.Trim, emd, txteerofficer.Text.Trim, txteamt.Text.Trim, _eid)
            If recstatus = True Then
                MessageBox("Record saved successfully!!!")
                txtecode.Text = ""
                CLEARCONTROLS()
            Else
                MessageBox("Cannot Save Data!!!")

            End If
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub
    Protected Sub txtecode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtecode.TextChanged
        CLEARCONTROLS()
        GetEmpPpdetails(txtecode.Text.Trim)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString
                lbldesig.Text = dr("designation").ToString
                lblppno.Text = dr("passportno").ToString
                lblvisa.Text = dr("visareferenceno").ToString
                lblcountry.Text = dr("ppissuedcountry").ToString
                lbladrs.Text = dr("address").ToString
                lblgroup.Text = dr("empgroup").ToString
            Else
                MessageBox("Empcode doesn't exist")
                CLEARCONTROLS()
            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub CLEARCONTROLS()
        lblename.Text = ""
        lblsect.Text = ""
        lbldesig.Text = ""
        lblppno.Text = ""
        lblvisa.Text = ""
        lblcountry.Text = ""
        lbladrs.Text = ""
        lblgroup.Text = ""
        txtmissing.Text = ""
        txtpoliceno.Text = ""
        txtstation.Text = ""
        txtpofficer.Text = ""
        txtpplace.Text = ""
        txtcdate.Text = ""
        txtfile.Text = ""
        txtpamt.Text = ""
        txtimm.Text = ""
        txtiofficer.Text = ""
        txtiplace.Text = ""
        txtidate.Text = ""
        txtierofficer.Text = ""
        txtembasssy.Text = ""
        txteplace.Text = ""
        txteofficer.Text = ""
        txtedate.Text = ""
        txteerofficer.Text = ""
        txteamt.Text = ""
    End Sub
End Class