Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class replacementapproval
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        con = New SqlConnection(constr)
        con.Open()
        'Session("_ename") = "IT"
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim no As String = GridView1.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("RadioButtonList1"), RadioButtonList).SelectedValue
            Dim newemp As String = DirectCast(GridView1.Rows(i).FindControl("newempcode"), TextBox).Text
            Dim dthire As String = DirectCast(GridView1.Rows(i).FindControl("datehired"), TextBox).Text
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_gatepass(con, DAP, 2, "update man_replace set status = '" & status & "',newempcode='" & newemp & "',approvedby='" & Session("_ename") & "',datehired='" & dthire & "' where requisitionno = '" & no & "'")
            MyGlobal.db_close()
        Next
        GridView1.DataBind()
    End Sub
End Class