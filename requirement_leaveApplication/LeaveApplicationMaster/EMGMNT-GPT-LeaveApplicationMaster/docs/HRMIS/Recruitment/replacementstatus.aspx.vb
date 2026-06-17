Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class replacementstatus
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Dim cmd As New SqlCommand
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim sts = DirectCast(GridView1.Rows(i).FindControl("label1"), Label).Text
            If sts = "S" Or sts = "s" Then
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).Text = "Scheduled"
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).ForeColor = Drawing.Color.Orange
            ElseIf sts = "A" Or sts = "a" Then
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).Text = "Approved"
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).ForeColor = Drawing.Color.Green
            ElseIf sts = "H" Or sts = "h" Then
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).Text = "Hired"
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).ForeColor = Drawing.Color.Blue
            ElseIf sts = "O" Or sts = "o" Then
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).Text = "Onold"
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).ForeColor = Drawing.Color.Orchid
            ElseIf sts = "R" Or sts = "r" Then
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).Text = "Rejected"
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).ForeColor = Drawing.Color.Red
            ElseIf sts = "C" Or sts = "c" Then
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).Text = "Cancelled"
                DirectCast(GridView1.Rows(i).FindControl("label1"), Label).ForeColor = Drawing.Color.Black
            End If
        Next
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            Dim lbl As Label = TryCast(e.Row.FindControl("label1"), Label)
            Dim lnkedit As LinkButton = TryCast(e.Row.FindControl("lnk1"), LinkButton)
            Dim lnkcancel As LinkButton = TryCast(e.Row.FindControl("lnk2"), LinkButton)
            If status = "A" Or status = "H" Or status = "R" Or status = "C" Or status = "O" Then
                lnkedit.Visible = False
                lnkcancel.Visible = False
            ElseIf status = "S" Or status = "s" Then
                lnkedit.Visible = True
                lbl.Visible = False
                lnkedit.Text = "Scheduled"
            End If
        End If
    End Sub
    Protected Sub SqlDataSource1_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        'Session("empcode") = "005000"         'for implement purpose hotcode removed
        'Dim emp = Session("empcode")
        'e.Command.Parameters(0).Value = emp
    End Sub
    Public Sub sendno(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("no") = e.CommandArgument
        Server.Transfer("replacementrequest.aspx")
    End Sub
    Public Sub statuscancel(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim no = e.CommandArgument
        sqltext = "update man_replace set status='C' where RequisitionNo='" & no & "'"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        MessageBox("Status Cancelled")
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class