Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class UpdatedKPIindividualScreen1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (284)
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
    End Sub

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        ' Dim mon = Session("mth")
        Session("emp") = Trim(txtempidr.Text)
        Session("mth") = Trim(monthddl.SelectedValue)
        Session("yr") = Trim(yearddl.SelectedValue)

        Dim mon = Session("mth")

       
        If mon = "4" Or mon = "5" Or mon = "6" Then
            Session("rqr") = "Q1"
        ElseIf mon = "7" Or mon = "8" Or mon = "9" Then
            Session("rqr") = "Q2"
        ElseIf mon = "10" Or mon = "11" Or mon = "12" Then
            Session("rqr") = "Q3"
        ElseIf mon = "1" Or mon = "2" Or mon = "3" Then
            Session("rqr") = "Q4"
        End If
        Response.Redirect("UpdatedKPIindividual.aspx")
    End Sub
End Class