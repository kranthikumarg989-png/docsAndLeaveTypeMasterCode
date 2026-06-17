Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class VehicleService
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer
    Dim rcount As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (87)
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
        _eid = Session("empcode")
    End Sub

    Protected Sub ddlvno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlvno.SelectedIndexChanged
        Try
            Getvmdetails1(ddlvno.SelectedValue.Trim)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    lblvmodel.Text = dr("model").ToString
                    lbldate.Text = Format(Convert.ToDateTime(dr("datepurchase")), "dd/MM/yy")
                    lblchasis.Text = dr("casisno").ToString
                    lblcolor.Text = dr("colour").ToString
                    lblyear.Text = dr("myear").ToString
                    lblcat.Text = dr("category").ToString
                    lblfuel.Text = dr("fueltype").ToString
                End If
            Else
                lblmsg.Text = MyerrorMsg
            End If
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If txtdate.Text = "" Then
            MessageBox("Please Select Service Date!!")
            Exit Sub
        End If
        If ddlvno.SelectedValue = "-1" Then
            MessageBox("Please Select Vehicle no.!!")
            Exit Sub
        End If
        Dim fd1 As String
        fd1 = txtdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        InsertTempItem(ddlvno.SelectedValue.Trim, txtitem.Text.Trim, txtdesc.Text.Trim, txtamt.Text.Trim, fd)
        If recstatus = True Then
            txtitem.Text = ""
            txtdesc.Text = ""
            txtamt.Text = ""
        Else
            lblmsg.Text = MyerrorMsg & " Error!!! Cannot save Data"
        End If
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fd1 As String
        fd1 = txtdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim pd1 As String
        pd1 = txtpdate.Text.Trim
        Dim strdatep() As String = pd1.Split("/"c)
        pd1 = strdatep(1) & "/" & strdatep(0) & "/" & strdatep(2)

        Dim pd As Date
        pd = CDate(pd1)
        Getservicecode()
        Dim i As Integer = 0
        Dim item As Integer
        Dim desc As String
        Dim amt As Decimal
        Dim total As Decimal
        Dim rno As Integer
        rno = posid

        If txtothers.Text = "" Then
            txtothers.Text = "-"
        End If
        If txtreading1.Text = "" Then
            txtreading1.Text = "0"
        End If
        If txtreading2.Text = "" Then
            txtreading2.Text = "0"
        End If
        If txtpay.SelectedValue.Trim = "Cheque" Then
            If txtcheque.Text = "" Then
                MessageBox("Please Enter Cheque No!!")
                Exit Sub
            End If
        Else
            txtcheque.Text = "-"
        End If


        InsertVService(ddlvno.SelectedValue.Trim, fd, txtpay.SelectedValue.Trim, pd, txtcheque.Text.Trim, txtreading1.Text.Trim, txtreading2.Text.Trim, txtcentre.SelectedValue.Trim, _eid, posid, txtothers.Text.Trim)
        If recstatus = True Then
            GetserviceInfo(ddlvno.SelectedValue.Trim)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    rcount = dsdata.Tables(0).Rows.Count
                    For i = 0 To rcount - 1
                        dr = dsdata.Tables(0).Rows(i)
                        item = dr("item").ToString
                        desc = dr("description").ToString
                        amt = dr("amount").ToString
                        total = total + amt
                        InsertServiceDesc(ddlvno.SelectedValue.Trim, item, desc, amt, fd)
                    Next
                    UpdVService(rno, total)
                    DeldescTemp(ddlvno.SelectedValue.Trim)
                End If
            Else
                lblmsg.Text = MyerrorMsg
            End If
            MessageBox("Record Saved")
        Else
            lblmsg.Text = MyerrorMsg
        End If
     
    End Sub
End Class