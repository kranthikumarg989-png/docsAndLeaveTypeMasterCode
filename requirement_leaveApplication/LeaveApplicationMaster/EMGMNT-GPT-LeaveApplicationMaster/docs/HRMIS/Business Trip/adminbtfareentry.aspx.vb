Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class adminbtfareentry
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim btnum, rno As String
    Dim stat As Boolean


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (57)
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
        thisdate = DateTime.Now
        thisdate = Month(DateTime.Now) & "/" & Day(DateTime.Now) & "/" & Year(DateTime.Now)

        If Request.QueryString("rno") <> "" Then
            lblrno.Text = Request.QueryString("rno")
            lbldept.Text = Request.QueryString("dept")
        Else
            lblrno.Text = ""
        End If
    End Sub

    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        GetBtInfo(lblrno.Text)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbldate.Text = Format(Convert.ToDateTime(dr("fromdate")), "MM/dd/yy")
            End If
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If Len(lbltno.Text) = "0" Then

                Call MyGlobal.dbSp_open("hrmis_ins_TaxiFlightEntry")

                Cmd.Parameters.AddWithValue("@btnum", lblrno.Text.Trim)
                Cmd.Parameters.AddWithValue("@dept", lbldept.Text.Trim)
                Cmd.Parameters.AddWithValue("@ddate", lbldate.Text)
                Cmd.Parameters.AddWithValue("@taxipro", ddltaxi.SelectedValue)
                Cmd.Parameters.AddWithValue("@tinv", txttinvoice.Text.Trim)
                Cmd.Parameters.AddWithValue("@tdest", txttdest.Text.Trim)
                Cmd.Parameters.AddWithValue("@fpro", DDLFLIGHT.SelectedValue)
                Cmd.Parameters.AddWithValue("@finv", txtfinvoice.Text.Trim)
                Cmd.Parameters.AddWithValue("@fdest", txtfdest.Text.Trim)
                Cmd.Parameters.AddWithValue("@tamt", txttamt.Text.Trim)
                Cmd.Parameters.AddWithValue("@famt", txtfamt.Text.Trim)

            Else
                Call MyGlobal.dbSp_open("hrmis_upd_TaxiFlightEntry")

                Cmd.Parameters.AddWithValue("@rno", lbltno.Text.Trim)
                Cmd.Parameters.AddWithValue("@taxipro", ddltaxi.SelectedValue)
                Cmd.Parameters.AddWithValue("@tinv", txttinvoice.Text.Trim)
                Cmd.Parameters.AddWithValue("@tdest", txttdest.Text.Trim)
                Cmd.Parameters.AddWithValue("@fpro", DDLFLIGHT.SelectedValue)
                Cmd.Parameters.AddWithValue("@finv", txtfinvoice.Text.Trim)
                Cmd.Parameters.AddWithValue("@fdest", txtfdest.Text.Trim)
                Cmd.Parameters.AddWithValue("@tamt", txttamt.Text.Trim)
                Cmd.Parameters.AddWithValue("@famt", txtfamt.Text.Trim)


            End If

            Cmd.ExecuteNonQuery()
            lblmsg.Text = "Record Saved"
            ClearCtrl()
        Catch ex As Exception
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End Try
        GridView1.DataBind()
    End Sub
    Public Sub mpop(ByVal sender As Object, ByVal e As CommandEventArgs)

        rno = e.CommandArgument
        lbltno.Text = rno
        GetFareDetails(rno)

        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                ddltaxi.SelectedValue = dr("taxiprovider").ToString
                txttinvoice.Text = dr("tinvoice").ToString
                txttdest.Text = dr("tdetination").ToString
                txttamt.Text = dr("tamount").ToString
                lblrno.Text = dr("btnum").ToString
                DDLFLIGHT.SelectedValue = dr("fprovider").ToString
                txtfinvoice.Text = dr("finvoice").ToString
                txtfdest.Text = dr("fdestination").ToString
                txtfamt.Text = dr("famount").ToString
            End If
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub
    Public Sub clearctrl()
        ddltaxi.SelectedValue = -1
        txttinvoice.Text = ""
        txttdest.Text = ""
        txttamt.Text = ""
        DDLFLIGHT.SelectedValue = -1
        txtfinvoice.Text = ""
        txtfdest.Text = ""
        txtfamt.Text = ""
    End Sub
   
End Class