Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class workpermitdetailsedit
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
            MyScreenId = (107)
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
        ChkWpTable(empcode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                clearcontrols()
                lblinfo.Visible = True
                lblinfo.Text = "Click rno to EDIT records"
                GridView1.DataBind()
            Else
                MessageBox(TextBox1.Text & " - Record doesnot exist")
                clearcontrols()
            End If
        End If

    End Sub
    Public Sub getdetails(ByVal sender As Object, ByVal e As CommandEventArgs)
        empcode = e.CommandArgument
        GetWpDetails(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                txtvfrom.Text = Format(Convert.ToDateTime(dr("visavalidfrom")), "dd/MM/yy")
                txtvto.Text = Format(Convert.ToDateTime(dr("visavalidto")), "dd/MM/yy")
                txtyrs.Text = dr("years").ToString
                txtrefno.Text = dr("visareferenceno").ToString
                txtdoi.Text = Format(Convert.ToDateTime(dr("dateofissue")), "dd/MM/yy")
                txtpoi.Text = dr("placeofissue").ToString
                txtbgno.Text = dr("serialno").ToString
                txtbgdate.Text = Format(Convert.ToDateTime(dr("bgexpirydate")), "dd/MM/yy")
                txtbgamt.Text = dr("amount").ToString
                txtidate.Text = Format(Convert.ToDateTime(dr("insexpirydate")), "dd/MM/yy")
                txtino.Text = dr("inspolicynumber").ToString
                txtpermit.Text = dr("workpermitno").ToString
                txtvtype.Text = dr("visatype").ToString
                txtreceipt.Text = dr("receiptno").ToString
                txtpass.Text = dr("amtpass").ToString
                txtlevy.Text = dr("amtlevy").ToString
                txtvisa.Text = dr("amtvisa").ToString
                txtprocess.Text = dr("amtprocess").ToString
                TxtContractRenewed.Text = Convert.ToDateTime(dr("ContractRenewed").ToString).ToString("dd/MM/yy")

                lblrno.Text = e.CommandArgument
                lblrno.Visible = True
            Else
                lblrno.Visible = False
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        rno = lblrno.Text.Trim
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

        Dim insd As String
        insd = txtidate.Text.Trim
        Dim insdate() As String = insd.Split("/"c)
        insd = insdate(1) & "/" & insdate(0) & "/" & insdate(2)
        Dim insdt As Date
        insdt = CDate(insd)


        Dim insd1 As String
        insd1 = TxtContractRenewed.Text.Trim
        Dim insdate1() As String = insd1.Split("/"c)
        insd1 = insdate1(1) & "/" & insdate1(0) & "/" & insdate1(2)
        Dim insdt1 As Date
        insdt1 = CDate(insd1)

        Try
            _eid = Session("empcode")

            UpdateWPDetails(rno, md, cd, txtyrs.Text.Trim, txtrefno.Text.Trim, fd, txtpoi.Text.Trim, txtbgno.Text.Trim, td, txtbgamt.Text.Trim, insdt, txtino.Text.Trim, txtpermit.Text.Trim, txtvtype.Text.Trim, txtreceipt.Text.Trim, txtpass.Text.Trim, txtlevy.Text.Trim, txtvisa.Text.Trim, txtprocess.Text.Trim, _eid, insdt1)
            If recstatus = True Then
                MessageBox("Record Saved!!")
                clearcontrols()
                TextBox1.Text = ""

            Else
                MessageBox("Record already exist!!")
            End If
        Catch ex As Exception
            MessageBox("Cannot Save Data" & ex.Message)
        End Try
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub clearcontrols()
        txtvfrom.Text = ""
        txtvto.Text = ""
        txtyrs.Text = ""
        txtrefno.Text = ""
        txtdoi.Text = ""
        txtpoi.Text = ""
        txtbgno.Text = ""
        txtbgdate.Text = ""
        txtbgamt.Text = ""
        txtidate.Text = ""
        txtino.Text = ""
        txtpermit.Text = ""
        txtvtype.Text = ""
        txtreceipt.Text = ""
        txtpass.Text = ""
        txtlevy.Text = ""
        txtvisa.Text = ""
        txtprocess.Text = ""
        TxtContractRenewed.Text = ""
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    
End Class