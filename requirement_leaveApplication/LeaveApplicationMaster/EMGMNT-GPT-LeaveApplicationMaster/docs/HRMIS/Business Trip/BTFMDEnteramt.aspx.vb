Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class BTFMDEnteramt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim btnum As String
    Dim USD, USDLimit
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (53)
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

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        GetEXR("USD")
        USD = RecordId
        GetUSDLIMIT()
        USDLimit = RecordId
        thisdate = DateTime.Now
        If Len(Request.QueryString("rno")) <> 0 Then
            Label2.Text = Request.QueryString("rno")
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub btncalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncalculate.Click
        If txtamt.Text = "" Then
            Exit Sub
        End If
        If txter.Text = "" Then
            Exit Sub
        End If
        If ddlcurrency.SelectedValue = "-1" Then
            Exit Sub
        End If
        calculateRM()
    End Sub
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim F
        Dim Advance = ""
        For F = 0 To lstdetails.Items.Count - 1
            Advance = Advance & lstdetails.Items(F).Value & ","
        Next

        If Advance = "" Then
            Advance = "0"
        Else
            Advance = Advance
        End If

        Try
            Call MyGlobal.dbSp_open("HRMIS_BT_FMDEditAmt")
            Cmd.Parameters.AddWithValue("@sanction", Advance)
            Cmd.Parameters.AddWithValue("@total", lbltotamt.Text.Trim)
            Cmd.Parameters.AddWithValue("@rno", Label2.Text)
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        Response.Redirect("BTFMDView.aspx")
    End Sub
    Protected Sub ddlcurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlcurrency.SelectedIndexChanged
        Dim CURRENCY = ddlcurrency.SelectedValue.Trim
        GetEXR(CURRENCY)
        txter.Text = RecordId
    End Sub
    Public Sub calculateRM()
        Dim amt = txtamt.Text.Trim
        Dim currency = ddlcurrency.SelectedValue
        Dim amtrqd
        Dim lstadv
        Dim TotUsd, CurUsd, TotRM, CurRM
        CurRM = lbltotamt.Text.Trim
        CurUsd = lblcurusd.Text.Trim
        If CurUsd = "" Then
            CurUsd = "0"
        End If
        amtrqd = amt & " " & currency

        lstadv = "$ " & amtrqd & " (EXR= " & txter.Text & " )"
        lstdetails.Items.Add(lstadv)
        lstdetails.DataValueField = amtrqd
        lstdetails.DataTextField = lstadv
        lstdetails.Focus()

        TotRM = CurRM + (amt * txter.Text)
        TotUsd = TotRM / USD
        TotUsd = CurUsd + TotUsd
        lbltotamt.Text = System.Math.Round(TotRM, 2)

        If TotUsd > USDLimit Then
            lblusdmsg.Text = " Exceeding the Max.USD Limit !!!"
        Else
            lblusdmsg.Text = ""
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim i
        Dim SelVal
        Dim myarray
        Dim USDCalc, RMcalc

        If lstdetails.SelectedIndex = -1 Then
            Exit Sub
        End If

        For i = 0 To lstdetails.Items.Count - 1
            If lstdetails.Items(i).Selected = True Then
                SelVal = lstdetails.Items(i).Value
            End If
        Next
        lstdetails.Items.Remove(SelVal)
        lstdetails.Focus()
        ''''' CALCULATE USD VALUE
        myarray = Split(SelVal, " ")
        RMcalc = myarray(1) * myarray(4)
        USDCalc = RMcalc / USD
        RMcalc = lbltotamt.Text - RMcalc
        If RMcalc < 0 Then
            RMcalc = 0
        End If
        lbltotamt.Text = System.Math.Round(RMcalc, 2)
        If USDCalc > USDLimit Then
            lblusdmsg.Text = " Exceeding the Max.USD Limit !!!"
        Else
            lblusdmsg.Text = ""
        End If

    End Sub
End Class