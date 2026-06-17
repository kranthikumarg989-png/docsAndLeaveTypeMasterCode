Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class transport_report
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim rpt, rpt1, rpt2 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (112)
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

        rpt = Session("tptvalue")
        rpt1 = Session("rd2sval")
        rpt2 = Session("rd3sval")

        If rpt = "R" Then
            grdroute.Visible = True
            grdroute.DataBind()
        ElseIf rpt = "RA" Then
            If Session("route") = "OA" Then
                grdarea.Visible = True
            Else
                grdarear.Visible = True
            End If
        ElseIf rpt = "ER" Then
            If Session("route") = "OA" Then
                grdemp.Visible = True
            Else
                grdempR.Visible = True
            End If
        ElseIf rpt = "ERA" Then
            grdempar.Visible = True
        End If


        If rpt1 = "S" Then
            grdsupplier.Visible = True
        ElseIf rpt1 = "SR" Then
            grdsuppR.Visible = True
        ElseIf rpt1 = "PT" Then
            grdPt.Visible = True
        ElseIf rpt1 = "BV" Then
            grdbv.Visible = True
        End If

        If rpt2 = "D" Then
            grdvehid.Visible = True
        ElseIf rpt2 = "S" Then
            Grdvehisect.Visible = True
        ElseIf rpt2 = "E" Then
            grdownE.Visible = True
        ElseIf rpt2 = "O" Then
            grdvehio.Visible = True
        End If



    End Sub

    Private Sub transport_report_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

    End Sub

    Protected Sub grdownE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdownE.SelectedIndexChanged

    End Sub
End Class