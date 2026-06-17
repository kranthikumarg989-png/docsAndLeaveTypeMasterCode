Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class shiftmaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim stime As String
    Dim etime As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (94)
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
        Dim scode As String
        Dim smin As String
        smin = ddlsmin.SelectedValue.Trim
        If smin = "00" Then
            smin = ""
        Else
            smin = ddlsmin.SelectedValue.Trim
        End If

        Dim emin As String
        emin = ddlemin.SelectedValue.Trim
        If emin = "00" Then
            emin = ""
        Else
            emin = ddlemin.SelectedValue.Trim
        End If

        If smin = "" Then
            stime = ddlshr.SelectedValue.Trim + ddlsam.SelectedValue.Trim
        Else
            stime = ddlshr.SelectedValue.Trim + ":" + smin + " " + ddlsam.SelectedValue.Trim
        End If
        If emin = "" Then
            etime = ddlehr.SelectedValue.Trim + ddleam.SelectedValue.Trim
        Else
            etime = ddlehr.SelectedValue.Trim + ":" + emin + " " + ddleam.SelectedValue.Trim
        End If
        scode = stime + "-" + etime

        GetshiftCode()
        Insertshift(posid, txtshiftcode.Text.Trim, scode, stime, etime)
        If recstatus = True Then
            Label1.Text = "shiftCode Saved successfully"
            txtshiftcode.Text = ""
        Else
            Label1.Text = MyerrorMsg & " Error!!! Cannot save Data"
        End If
        GridView1.DataBind()
    End Sub
End Class