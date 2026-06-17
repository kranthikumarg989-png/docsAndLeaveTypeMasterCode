Imports System.Data
Imports System
Imports System.io
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OptAppraisalEA
    Inherits System.Web.UI.Page

    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim da As SqlDataAdapter
    Dim rdr, rdr1 As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
    End Sub
    Protected Sub Appraisal_view(ByVal sender As Object, ByVal e As CommandEventArgs)

        'Dim empid As String
        'Dim lb As LinkButton = TryCast(sender, LinkButton)
        Session("optempappEA") = e.CommandArgument
        Response.Redirect("OperatorAppraisalViewEA.aspx")

    End Sub
    Protected Sub UpdateAppraisal(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            Dim stats As String = DirectCast(GridView1.Rows(i).FindControl("radiobuttonlist1"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If stats = "Approved" Then
                stats = "Approve"
            End If
            DS = Open_Letter(Con, DAP, 2, "update hrmis_cmg_master_letter set status = '" & stats & " ' where slno='" & slno & "'")
            MyGlobal.db_close()
        Next
        GridView1.DataBind()
    End Sub
End Class