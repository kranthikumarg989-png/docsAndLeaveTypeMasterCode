Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PickUpTimemaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim sa As String
    Dim sb As String
    Dim sc As String
    Dim sm As String
    Dim sn As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (93)
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
        Label1.Text = ""
    End Sub
    Protected Sub BTNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNADD.Click
        Getptcode()
        sa = ddlahr.SelectedValue.Trim + ":" + ddlamin.SelectedValue.Trim + " " + ddlaam.SelectedValue.Trim
        sb = ddlbhr.SelectedValue.Trim + ":" + ddlbmin.SelectedValue.Trim + " " + ddlbam.SelectedValue.Trim
        sc = ddlchr.SelectedValue.Trim + ":" + ddlcmin.SelectedValue.Trim + " " + ddlcam.SelectedValue.Trim
        sm = ddlmhr.SelectedValue.Trim + ":" + ddlmmin.SelectedValue.Trim + " " + ddlmam.SelectedValue.Trim
        sn = ddlnhr.SelectedValue.Trim + ":" + ddlnmin.SelectedValue.Trim + " " + ddlnam.SelectedValue.Trim

        InsertPTime(posid, ddlroute.SelectedValue.Trim, ddlarea.SelectedValue.Trim, sa, sb, sc, sm, sn, _eid)

        If recstatus = True Then
            Label1.Text = "ShiftCode Saved successfully"
        Else
            Label1.Text = MyerrorMsg & "Error !!! Cannot save Data"
        End If

    End Sub

    Protected Sub ddlroute_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlroute.SelectedIndexChanged
        ChkRecAvail()
    End Sub

    Protected Sub ddlarea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlarea.SelectedIndexChanged
        ChkRecAvail()
    End Sub
    Private Sub ChkRecAvail()
        Dim route As String
        Dim area As String
        route = ddlroute.SelectedValue.Trim
        area = ddlarea.SelectedValue.Trim
        If route <> "-1" And area <> "-1" Then
            GetrouteareaPkup(route, area)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    MessageBox("Record already Exists!!")
                    Label1.Text = "Record Already Exist!!click add to update existing record"

                    dr = dsdata.Tables(0).Rows(0)
                    ddlahr.SelectedValue = Format(Convert.ToDateTime(dr("shifta")), "hh")
                    ddlamin.SelectedValue = Format(Convert.ToDateTime(dr("shifta")), "mm")
                    ddlamin.SelectedValue = Format(Convert.ToDateTime(dr("shifta")), "tt")

                    ddlbhr.SelectedValue = Format(Convert.ToDateTime(dr("shiftb")), "hh")
                    ddlbmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftb")), "mm")
                    ddlbmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftb")), "tt")

                    ddlchr.SelectedValue = Format(Convert.ToDateTime(dr("shiftc")), "hh")
                    ddlcmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftc")), "mm")
                    ddlcmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftc")), "tt")

                    ddlmhr.SelectedValue = Format(Convert.ToDateTime(dr("shiftd")), "hh")
                    ddlmmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftd")), "mm")
                    ddlmmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftd")), "tt")

                    ddlnhr.SelectedValue = Format(Convert.ToDateTime(dr("shiftd")), "hh")
                    ddlnmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftd")), "mm")
                    ddlnmin.SelectedValue = Format(Convert.ToDateTime(dr("shiftd")), "tt")

                End If
            Else
                Label1.Text = MyerrorMsg

            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class