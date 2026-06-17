Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class VisaExpDetails
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
            MyScreenId = (111)
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

    Public Sub UpdateVisaExpiry(ByVal sender As Object, ByVal e As EventArgs)
        _eid = Session("empcode")
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim rno As Integer = GridView1.Rows(i).Cells(0).Text
            Dim ppno As String = DirectCast(GridView1.Rows(i).FindControl("txtpp"), TextBox).Text.Trim
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rbchoices"), RadioButtonList).SelectedValue
            UpdatevisaExp(rno, ppno, status)

        Next
        GridView1.DataBind()

    End Sub
End Class