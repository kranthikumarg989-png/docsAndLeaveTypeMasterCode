Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class Workpermitdetails
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
            MyScreenId = (106)
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

    Protected Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        empcode = TextBox1.Text.Trim
        clearcontrols()
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                Label1.Text = dr("empname").ToString
                ' Label2.Text = dr("passportno").ToString
            Else
                clearcontrols()
                Label1.Text = ""
                Label2.Text = ""
            End If
        End If

        Getppdata(empcode)
        If recstatus = True Then
            Dim dr1 As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                Label2.Text = dr1("passportno").ToString
            Else
                MessageBox("passport details doesnt exist in passport master")
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim md1 As String
        md1 = txtvfrom.Text.Trim
        Dim mdate() As String
        mdate = md1.Split("/"c)
        md1 = mdate(1) & "/" & mdate(0) & "/" & mdate(2)
        Dim md As Date
        md = CDate(md1)

        Dim cd1 As String
        cd1 = txtvto.Text.Trim
        Dim cpdate() As String
        cpdate = cd1.Split("/"c)
        cd1 = cpdate(1) & "/" & cpdate(0) & "/" & cpdate(2)
        Dim cd As Date
        cd = CDate(cd1)

        Dim fd1 As String
        fd1 = txtdoi.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtbgdate.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
        Dim td As Date
        td = CDate(td1)

        'Dim xd1 As String
        'xd1 = txtidate.Text.Trim
        'Dim strdatex2() As String = xd1.Split("/"c)
        'td1 = strdatex2(1) & "/" & strdatex2(0) & "/" & strdatex2(2)
        'Dim xd As Date
        'xd = CDate(xd1)

        Dim insd As String
        insd = txtidate.Text.Trim
        Dim insdate() As String = insd.Split("/"c)
        insd = insdate(1) & "/" & insdate(0) & "/" & insdate(2)
        Dim insdt As Date
        insdt = CDate(insd)

        _eid = Session("empcode")

        Try
            InsertWPDetails(TextBox1.Text.Trim, Label2.Text.Trim, md, cd, txtyrs.Text.Trim, "-", fd, txtpoi.Text.Trim, txtbgno.Text.Trim, td, txtbgamt.Text.Trim, insdt, txtino.Text.Trim, txtpermit.Text.Trim, txtvtype.Text.Trim, txtreceipt.Text.Trim, txtpass.Text.Trim, txtlevy.Text.Trim, txtvisa.Text.Trim, txtprocess.Text.Trim, _eid)

            MessageBox("Record Saved!!")
            TextBox1.Text = ""
            clearcontrols()
          
        Catch ex As Exception
            MessageBox("Cannot Save Data" & ex.Message)
        End Try
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub clearcontrols()

        Label1.Text = ""
        Label2.Text = ""
        txtvfrom.Text = ""
        txtvto.Text = ""
        txtyrs.Text = ""
        txtrefno.Text = ""
        txtdoi.Text = ""
        'txtpoi.Text = ""
        txtbgno.Text = ""
        'txtbgdate.Text = ""
        txtbgamt.Text = ""
        'txtidate.Text = ""
        txtino.Text = ""
        txtpermit.Text = ""
        'txtvtype.Text = ""
        txtreceipt.Text = ""
        'txtpass.Text = ""
        'txtlevy.Text = ""
        'txtvisa.Text = ""
        'txtprocess.Text = ""
    End Sub

    Protected Sub txtvto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvto.TextChanged
        txtbgdate.Text = txtvto.Text
        txtidate.Text = txtvto.Text
    End Sub
End Class