Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class letter_master_status
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim clssts As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'session=("_edept")="9000"
        myglobal.Open_Con()
        myglobal.Con_Str()
    End Sub
    Protected Sub UpdategpApproval(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            Dim close As String = DirectCast(GridView1.Rows(i).FindControl("radiobuttonlist1"), RadioButtonList).SelectedValue
            If close = "Yes" Then
                close = "Yes"
            Else
                close = "No"
            End If
            myglobal.Open_Con()
            myglobal.Con_Str()
            DS = Open_Lettermasterstatus(Con, DAP, 2, "update hrmis_er_master_letter set clse = '" & close & " ' where slno='" & slno & "'")
            myglobal.db_close()
        Next
        GridView1.DataBind()
    End Sub
    Private Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        clssts = "No"
        e.Command.Parameters(0).Value = clssts
    End Sub
End Class