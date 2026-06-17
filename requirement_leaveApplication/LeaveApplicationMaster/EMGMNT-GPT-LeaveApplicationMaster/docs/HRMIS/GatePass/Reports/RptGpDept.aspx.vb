Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications


Partial Public Class RptGpDept1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbldept.Enabled = False
        lblsect.Enabled = False
        lbldesig.Enabled = False
        lblemp.Enabled = False

        ddldept.Enabled = False
        ddlsect.Enabled = False
        ddldesig.Enabled = False
        txtempid.Enabled = False


    End Sub

    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldept.Enabled = True
            lbldept.Enabled = True
        ElseIf rdoptions.SelectedValue = "Sect" Then
            lblsect.Enabled = True
            ddlsect.Enabled = True
        ElseIf rdoptions.SelectedValue = "Desig" Then
            lbldesig.Enabled = True
            ddldesig.Enabled = True
        ElseIf rdoptions.SelectedValue = "Emp" Then
            lblemp.Enabled = True
            txtempid.Enabled = True
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue
        Dim designation As String
        designation = Trim(ddldesig.SelectedValue)
        Dim empid As String
        empid = Trim(txtempid.Text)

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        MessageBox(fd & "-" & fd1)

        If rdvalue = "Dept" And ddldept.SelectedValue <> "" Then
            Button1.PostBackUrl = "CrvGpDept.aspx?fromd=" & txtfrom.Text & " &tod=" & txtto.Text & "&dep=" & ddldept.SelectedValue & ""
        ElseIf rdvalue = "Sect" And ddlsect.SelectedValue <> "" Then
            Button1.PostBackUrl = "CvGpSect.aspx?fromd=" & txtfrom.Text & " &tod=" & txtto.Text & "&sec=" & ddlsect.SelectedValue & ""
        ElseIf rdvalue = "Desig" And ddldesig.SelectedValue <> "" Then
            Button1.PostBackUrl = "CrvGpdesig.aspx?fromd=" & txtfrom.Text & " &tod=" & txtto.Text & "&desi=" & designation & ""
        ElseIf rdvalue = "Emp" And txtempid.Text <> "" Then
            Button1.PostBackUrl = "CrvGpemp.aspx?fromd=" & txtfrom.Text & " &tod=" & txtto.Text & "&emp=" & empid & ""
        Else
            Button1.PostBackUrl = "CrvGpall.aspx?fromd=" & fd1 & " &tod=" & td1 & ""
        End If

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class